﻿using NAudio.Wave;
using Ofelia_Sara.Clases.General.Animaciones;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Botones.btn_Configuracion;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; // Para la importación de funciones nativas
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ofelia_Sara.Formularios.General.InstructivoDigital;


namespace Ofelia_Sara.Formularios.Redactador
{

    public partial class Redactador : BaseForm
    {
        #region mover formulario
        //funcion nativa para ARRASTRAR EL FORMULARIO
        // Importar las funciones de la API de Windows
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        //-----------------------------------------------------
        //cambiar el caret
        // Importar la función nativa de Windows para ocultar el caret
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);
        //-----------------------------------------------------------
        #endregion

        #region VARIABLES
        //AMPLIAR FORMULARIO
        private bool isResizing = false;
        private Point lastMousePosition;
        //------------------------------------------------------
        private WaveInEvent waveIn;
        private WaveFileWriter waveFileWriter;
        private string outputFile = "mic_recording.wav";
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private Button botonAlineacionSeleccionado = null; //para saber con que formato de texto se esta trabajando
                                                           // Bandera para activar o desactivar el subrayado personalizado
        private bool mostrarSubrayado = false;
        //para hacer que se extienda 
        private int lineWidth = 0;
        private bool isAnimating = false;
        private Timer animationTimer;
        private readonly Timer timerCerrarForm = new();
        private readonly Timer timerMinimizarForm = new();

        private bool estadoMicrofono = false;
        #endregion

        #region CONSTRUCTOR
        public Redactador()
        {
            InitializeComponent();
            LabelVideoInstructivo(label_OfeliaSara);// llama al metodo baseform para el comportamiento del label
            btn_Actuacion.BringToFront();
            panel_Botones.BringToFront();  // Coloca el panel encima del AudioVisualizerControl
            audioVisualizerControl.Visible = false;
            //timer para animacion de barras
            timer_Barras = new Timer
            {
                Interval = 100
            };
            timer_Barras.Tick += timer_Barras_Tick;

            menu_SeleccionPlantilla.Renderer = new CustomMenuStripRenderer();
            // Aplicar estilos a todos los ítems del menú

            foreach (ToolStripItem item in menu_SeleccionPlantilla.Items)
            {
                //  MessageBox.Show("Aplicando estilo a: " + item.Text);
                EstiloMenu.AplicarEstiloItem(item);
            }

            ToolTipGeneral.Mostrar(btn_Microfono, "ACTIVAR microfono.");//inicializa este tooltip ya que inicia el btn desactivado
            ToolTipGeneral.Mostrar(btn_Actuacion,"Seleccione modelo de actuación y/o plantilla");
        }
        #endregion

        #region LOAD
        private void Redactador_Load(object sender, EventArgs e)
        {


            IncrementarTamaño.Incrementar(btn_Actuacion);

            //metodo recursivo para comportamiento de aumentar tamaño en botones de panel
            foreach (Control control in panel_Botones.Controls)
            {
                if (control is Button boton)
                {
                    IncrementarTamaño.Incrementar(boton);
                }
            }


            this.FormClosing += Redactador_FormClosing;// para mensaje previo a cerrar

            CambiarAlineacion(btn_Justificar, HorizontalAlignment.Left);// para que inicie en justificado

         
            InicializarEstiloBoton(btn_Enviar);

            BotonesControlFormulario(this, btn_Cerrar,btn_Maximizar, btn_Minimizar);

            ConfigurarTooltips();

            richTextBox_Redactor.GotFocus += RichTextBox_Redactor_GotFocus;



        }


        #endregion

        #region GENERAL

        /// <summary>
        /// agrupa los toltips 
        /// </summary>
        private void ConfigurarTooltips()
        {

            ToolTipGeneral.Mostrar(btn_Guardar, "CREAR DOCUMENTO WORD");
            ToolTipGeneral.Mostrar(btn_Limpiar, "ELIMINAR");
            ToolTipGeneral.Mostrar(btn_Negrita, "NEGRITA");
            ToolTipGeneral.Mostrar(btn_Cursiva, "CURSIVA");
            ToolTipGeneral.Mostrar(btn_Subrayado, "SUBRAYAR");
            ToolTipGeneral.Mostrar(btn_AumentarTamaño, "Aumentar tamaño");
            ToolTipGeneral.Mostrar(btn_ReducirTamaño, "Reducir tamaño");
            ToolTipGeneral.Mostrar(btn_MayusculaMinuscula, "MAYUSCULA/minuscula");
            ToolTipGeneral.Mostrar(btn_AlinearIzquierda, "Alinear a la Izquierda");
            ToolTipGeneral.Mostrar(btn_Centrar, "CENTRAR");
            ToolTipGeneral.Mostrar(btn_AlinearDerecha, "Alinear a la Derecha");
            ToolTipGeneral.Mostrar(btn_Justificar, "JUSTIFICAR");
            ToolTipGeneral.Mostrar(label_OfeliaSara, "Instructivo de la aplicación");
            ToolTipGeneral.Mostrar(btn_Enviar, "Enviar");// a posteriori establer tooltip personalizado para enviar wwp, email
        }

        #endregion

        #region BTN PANEL MENU_SUPERIO
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      

    


     
      
        /// <summary>
        /// evento click MAXIMIZAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
        
                richTextBox_Redactor.Focus();
           
        }

        /// <summary>
        /// para poder arrastrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MenuSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion

        #region BTN PANEL BOTONES
        private void Btn_Panel_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Lavender;
                btn.FlatAppearance.BorderColor = SystemColors.MenuHighlight;
            }
        }

        private void Btn_Panel_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = SystemColors.ButtonFace;
                btn.ForeColor = SystemColors.ControlDarkDark;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            }
        }


        #region Aumentar tamaño fuente
        private void Btn_AumentarTamaño_Click(object sender, EventArgs e)
        {
            CambiarTamañoFuente(2);  // Aumentar el tamaño de la fuente en 2 puntos
            richTextBox_Redactor.Focus();
        }

        private void Btn_DisminuirTamaño_Click(object sender, EventArgs e)
        {
            CambiarTamañoFuente(-2);  // Disminuir el tamaño de la fuente en 2 puntos
            richTextBox_Redactor.Focus();
        }

        private void CambiarTamañoFuente(int cambio)
        {
            // Verificar si hay texto seleccionado
            if (richTextBox_Redactor.SelectionFont != null)
            {
                // Obtener el tamaño actual de la fuente
                float tamañoActual = richTextBox_Redactor.SelectionFont.Size;

                // Calcular el nuevo tamaño
                float nuevoTamaño = tamañoActual + cambio;

                // Asegurarse de que el tamaño no sea menor que un valor mínimo (por ejemplo, 8 puntos)
                if (nuevoTamaño < 8) nuevoTamaño = 8;

                // Aplicar el nuevo tamaño a la selección
                richTextBox_Redactor.SelectionFont = new Font(richTextBox_Redactor.SelectionFont.FontFamily, nuevoTamaño);
            }
        }
        #endregion


        #region Alternancia mayuscula
        // Variable para almacenar si la escritura actual está en mayúsculas o minúsculas
        private bool escribirEnMayusculas = false;

        private void Btn_MayusculaMiniscula_Click(object sender, EventArgs e)
        {
            // Verificar si hay texto seleccionado
            if (richTextBox_Redactor.SelectionLength > 0)
            {
                // Obtener el texto seleccionado
                string textoSeleccionado = richTextBox_Redactor.SelectedText;

                // Alternar entre mayúsculas y minúsculas
                if (textoSeleccionado == textoSeleccionado.ToUpper())
                {
                    // Si está en mayúsculas, cambiar a minúsculas
                    richTextBox_Redactor.SelectedText = textoSeleccionado.ToLower();
                    escribirEnMayusculas = false; // Establecer que lo siguiente debe ser en minúsculas
                    richTextBox_Redactor.Focus();
                }
                else
                {
                    // Si está en minúsculas, cambiar a mayúsculas
                    richTextBox_Redactor.SelectedText = textoSeleccionado.ToUpper();
                    escribirEnMayusculas = true; // Establecer que lo siguiente debe ser en mayúsculas
                    richTextBox_Redactor.Focus();
                }
            }
            else
            {
                // Si no hay texto seleccionado, verificar el último carácter escrito y decidir
                if (escribirEnMayusculas)
                {
                    // Establecer que el siguiente texto escrito debe ser en mayúsculas
                    richTextBox_Redactor.SelectedText = richTextBox_Redactor.SelectedText.ToUpper();
                    richTextBox_Redactor.Focus();
                }
                else
                {
                    // Establecer que el siguiente texto escrito debe ser en minúsculas
                    richTextBox_Redactor.SelectedText = richTextBox_Redactor.SelectedText.ToLower();
                    richTextBox_Redactor.Focus();
                }
            }
        }
        #endregion

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button boton = sender as Button; // Convertir el sender a tipo Button
            if (boton != null)
            {
                boton.BackColor = Color.SkyBlue;
            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button boton = sender as Button; // Convertir el sender a tipo Button
            if (boton != null)
            {
                boton.BackColor = Color.White;
            }
        }

        private void Btn_AlinearIzquierda_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_AlinearIzquierda, HorizontalAlignment.Left);
            richTextBox_Redactor.Focus();
        }

        private void Btn_AlinearDerecha_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_AlinearDerecha, HorizontalAlignment.Right);
            richTextBox_Redactor.Focus();
        }

        private void Btn_Centrar_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_Centrar, HorizontalAlignment.Center);
            richTextBox_Redactor.Focus();
        }

        private void Btn_Justificar_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_Justificar, HorizontalAlignment.Left); // Usa Center ya que Justify no es soportado directamente
            richTextBox_Redactor.Focus();
        }

        private void CambiarAlineacion(Button boton, HorizontalAlignment alineacion)
        {
            // Restablecer el color del botón anterior
            if (botonAlineacionSeleccionado != null)
            {
                botonAlineacionSeleccionado.BackColor = Color.White;
            }

            // Aplicar el nuevo color al botón seleccionado
            boton.BackColor = Color.SkyBlue;

            // Actualizar la alineación en el RichTextBox
            richTextBox_Redactor.SelectionAlignment = alineacion;

            // Guardar el botón actual como el botón seleccionado
            botonAlineacionSeleccionado = boton;
        }


        #endregion

        #region LABEL INSTRUCTIVO DIGITAL

 
        //// Variable para almacenar la posición original del formulario Redactador
        private Point posicionOriginalRedactador;
        private List<(Form formulario, Point posicion)> otrasInstanciasRedactador = new List<(Form, Point)>(); // Lista para almacenar las instancias ocultas y sus posiciones originales

        private void Label_OfeliaSara_Click(object sender, EventArgs e)
        {
          

            // Guardar la posición original del formulario actual
            posicionOriginalRedactador = this.Location;

            // Calcular la posición de los formularios debajo de `menuPrincipal`
            Rectangle screenBounds = Screen.PrimaryScreen.WorkingArea;

            int formWidth = this.Width;
            int totalWidth = formWidth * 2 + 5; // Espacio para `Redactador` y `videoInstructivo` con margen
            int centerX = (screenBounds.Width - totalWidth) / 2; // Centrado horizontal

            // Mover el formulario Redactador al centro-izquierdo
            int xRedactador = centerX;
            this.Location = new Point(xRedactador);

            // Crear e inicializar el formulario VideoInstructivo
            InstructivoDigital videoInstructivo = new InstructivoDigital(ModuloOrigen.Redactador);

            // Posicionar VideoInstructivo al centro-derecho
            int xVideoInstructivo = xRedactador + formWidth; // A la derecha de Redactador
            videoInstructivo.StartPosition = FormStartPosition.Manual;
            videoInstructivo.Location = new Point(xVideoInstructivo);

            // Guardar las posiciones originales de otras instancias y ocultarlas
            otrasInstanciasRedactador = Application.OpenForms.Cast<Form>()
                .Where(f => f != this && f is Redactador)
                .Select(f => (f, f.Location)) // Guardar el formulario y su posición original
                .ToList();

            foreach (var (formulario, _) in otrasInstanciasRedactador)
            {
                formulario.WindowState = FormWindowState.Minimized; // Minimizar otras instancias
            }

            // Restaurar posiciones originales y estado de otras instancias al cerrar VideoInstructivo
            videoInstructivo.FormClosed += (s, args) => RestaurarLabelVideoInstructivo(label_OfeliaSara);
            {
               

                // Restaurar la posición del formulario Redactador actual
                this.Location = posicionOriginalRedactador;

                // Restaurar las posiciones originales y estado de otras instancias
                foreach (var (formulario, posicion) in otrasInstanciasRedactador)
                {
                    formulario.WindowState = FormWindowState.Normal;
                    formulario.Location = posicion;
                }
            };
            // Mostrar VideoInstructivo como diálogo modal
            videoInstructivo.ShowDialog();
        }

        #endregion



        #region FUNCION GRABAR

        private void Btn_Microfono_Click(object sender, EventArgs e)
        {
            // Verificar si hay dispositivos de entrada (micrófono)
            if (WaveIn.DeviceCount == 0)
            {
                // Pasar el formulario actual ('this') como el propietario del mensaje
                MensajeGeneral.Mostrar("No se ha detectado ningún micrófono conectado. Conecte un micrófono e inténtelo de nuevo.",
                                       MensajeGeneral.TipoMensaje.MicrofonoDesconectado, owner: this);
                return;
            }
            ConfiguracionMicrofono();
        }

        private void ConfiguracionMicrofono()
        {
            // Eliminar cualquier ToolTip previo
            ToolTipGeneral.RemoveAll(); // Si tienes un método para eliminar todos los ToolTips

            if (estadoMicrofono) // Si el micrófono está activado
            {
                // Detener la grabación y cambiar el estado del micrófono
                StopRecording();
                timer_Barras.Stop();
                btn_Microfono.BackColor = System.Drawing.Color.Red;
                audioVisualizerControl.Visible = false;
                richTextBox_Redactor.Focus();

                // Actualizar el estado
                estadoMicrofono = false;

                // Actualizar el ToolTip
                ToolTipGeneral.Mostrar(btn_Microfono, "ACTIVAR micrófono");
            }
            else // Si el micrófono está desactivado
            {
                // Iniciar la grabación y cambiar el estado del micrófono
                StartRecording();
                timer_Barras.Start();
                btn_Microfono.BackColor = System.Drawing.Color.LimeGreen;
                audioVisualizerControl.Visible = true;
                richTextBox_Redactor.Focus();

                // Actualizar el estado
                estadoMicrofono = true;

                // Actualizar el ToolTip
                ToolTipGeneral.Mostrar(btn_Microfono, "DESACTIVAR micrófono");
            }
        }


        private void StartRecording()
        {
            // Iniciar la grabación del micrófono
            waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0; // Selecciona el dispositivo de entrada (micrófono por defecto)
            waveIn.WaveFormat = new WaveFormat(44100, 1); // Definir el formato de audio (mono, 44.1 kHz)
            waveIn.DataAvailable += WaveIn_DataAvailable;

            waveFileWriter = new WaveFileWriter(outputFile, waveIn.WaveFormat);

            waveIn.StartRecording();
        }

        private void StopRecording()
        {
            // Detener la grabación y guardar el archivo
            waveIn.StopRecording();
            waveIn.Dispose();
            waveFileWriter.Close();
            waveFileWriter.Dispose();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Guardar los datos de audio grabados en el archivo
            waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveFileWriter.Flush();
        }
        private void timer_Barras_Tick(object sender, EventArgs e)
        {
            // Generar amplitudes de ejemplo o basadas en datos de audio
            Random random = new();
            int[] amplitudes = new int[audioVisualizerControl.Controls.Count];
            for (int i = 0; i < amplitudes.Length; i++)
            {
                amplitudes[i] = random.Next(5, 50); // Alturas aleatorias como ejemplo
            }

            // Llamar al método de actualización de visualización en el control de visualización
            audioVisualizerControl.UpdateVisualization(amplitudes);
        }

        #endregion

        #region FUNCIONALIDAD DE TECLAS
        private void Btn_Negrita_Click(object sender, EventArgs e)
        {
            if (btn_Negrita.BackColor == Color.White)
            {
                btn_Negrita.BackColor = Color.SkyBlue;
                AplicarFormato(FontStyle.Bold);
                richTextBox_Redactor.Focus();
            }
            else
            {
                btn_Negrita.BackColor = Color.White;
                AplicarFormato(FontStyle.Bold);
                richTextBox_Redactor.Focus();
            }
        }

        private void btn_Cursiva_Click(object sender, EventArgs e)
        {
            if (btn_Cursiva.BackColor == Color.White)
            {
                btn_Cursiva.BackColor = Color.SkyBlue;
                AplicarFormato(FontStyle.Italic);
                richTextBox_Redactor.Focus();
            }
            else
            {
                btn_Cursiva.BackColor = Color.White;
                AplicarFormato(FontStyle.Italic);
                richTextBox_Redactor.Focus();
            }

        }
        private void Btn_Subrayado_Click(object sender, EventArgs e)
        {

            if (btn_Subrayado.BackColor == Color.White)
            {
                btn_Subrayado.BackColor = Color.SkyBlue;
                AplicarFormato(FontStyle.Underline);
                richTextBox_Redactor.Focus();
            }
            else
            {
                btn_Subrayado.BackColor = Color.White;
                AplicarFormato(FontStyle.Underline);
                richTextBox_Redactor.Focus();
            }
        }
        #endregion


        private void AplicarFormato(FontStyle estilo)
        {
            if (richTextBox_Redactor.SelectionFont != null)
            {
                FontStyle nuevoEstilo = richTextBox_Redactor.SelectionFont.Style;

                // Alternar el estilo especificado
                if (richTextBox_Redactor.SelectionFont.Style.HasFlag(estilo))
                    nuevoEstilo &= ~estilo;
                else
                    nuevoEstilo |= estilo;

                richTextBox_Redactor.SelectionFont = new Font(richTextBox_Redactor.SelectionFont, nuevoEstilo);
            }
        }




        /// <summary>
        /// metodos para cambiar el caret en el richtextBox
        /// </summary>
        /// 
        // Ruta al archivo de cursor personalizado

        private void ChangeCursorToCustom()
        {
            // Obtener la posición del caret (índice de caracteres)
            int caretIndex = richTextBox_Redactor.SelectionStart;

            // Obtener las coordenadas de la posición del caret en el control
            Point caretPosition = richTextBox_Redactor.GetPositionFromCharIndex(caretIndex);

            // Convertir coordenadas del control a coordenadas absolutas de pantalla
            Point caretScreenPosition = richTextBox_Redactor.PointToScreen(caretPosition);

            // Cargar el cursor desde los recursos del proyecto
            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.CursorlapizDerecha))
            {
                Cursor myCustomCursor = new Cursor(cursorStream);
                richTextBox_Redactor.Cursor = myCustomCursor; // Asigna el cursor personalizado
            }

            // Mover el cursor a la posición convertida
            Cursor.Position = new Point(caretScreenPosition.X + 15, caretScreenPosition.Y);
        }


        private void RichTextBox_Redactor_GotFocus(object sender, EventArgs e)
        {
            // Ocultar el caret del RichTextBox
            HideCaret(richTextBox_Redactor.Handle);
            // Llamar al método que cambia el cursor y lo mueve junto al caret
            ChangeCursorToCustom();
        }

        private void RichTextBox_Redactor_MouseMove(object sender, MouseEventArgs e)
        {
            // Opcional: Vuelve a ocultar el caret si reaparece
            HideCaret(richTextBox_Redactor.Handle);
            // Llamar al método que cambia el cursor y lo mueve junto al caret
            ChangeCursorToCustom();
        }


        // Evento que se activa cada vez que el contenido del RichTextBox cambia
        private void RichTextBox_Redactor_TextChanged(object sender, EventArgs e)
        {
            // Ocultar el caret
            HideCaret(richTextBox_Redactor.Handle);// oculta caret
            ChangeCursorToCustom(); //muestra cursor especial

            // Detectar si el último carácter escrito es en mayúsculas o minúsculas
            if (richTextBox_Redactor.Text.Length > 0)
            {
                char ultimoCarácter = richTextBox_Redactor.Text[richTextBox_Redactor.Text.Length - 1];
                if (char.IsUpper(ultimoCarácter))
                {
                    escribirEnMayusculas = false; // Si el último carácter es mayúscula, escribir en mayúsculas
                }
                else if (char.IsLower(ultimoCarácter))
                {
                    escribirEnMayusculas = true; // Si el último carácter es minúscula, escribir en minúsculas
                }
            }
        }

        #region PANEL CONTROLES INFERIORES
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this);
            CambiarAlineacion(btn_Justificar, HorizontalAlignment.Left);// para que inicie en justificado
            richTextBox_Redactor.Focus();
        }
        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void Redactador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
        }

        #endregion


        #region redimencionar
        private void Redactador_MouseDown(object sender, MouseEventArgs e)
        {
            // Detectar si el usuario está cerca de un borde para redimensionar
            if (e.Button == MouseButtons.Left)
            {
                isResizing = true;
                lastMousePosition = e.Location;
            }
        }

        private void Redactador_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                // Calcular el nuevo tamaño del formulario
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                // Cambiar el tamaño del formulario
                this.Width += deltaX;
                this.Height += deltaY;

                // Actualizar la última posición del mouse
                lastMousePosition = e.Location;
            }
            else
            {
                // Cambiar el cursor para mostrar que el formulario es redimensionable
                if (e.X >= this.ClientSize.Width - 10 && e.Y >= this.ClientSize.Height - 10)
                    this.Cursor = Cursors.SizeNWSE;
                else
                    this.Cursor = Cursors.Default;
            }
        }

        private void Redactador_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        /// <summary>
        /// TRIANGULO INFERIOR PARA AMPLIAR Y REDUCIR FORMULARIO,
        ///  CAMBIARLO POR PICTURE O BOTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Triangulo_Paint(object sender, PaintEventArgs e)
        {
            // Crear un pincel gris para dibujar el triángulo
            using (Brush brush = new SolidBrush(SystemColors.ControlDark))
            {
                // Dibujar un triángulo en la esquina inferior derecha
                Point p1 = new Point(this.ClientSize.Width - 20, this.ClientSize.Height - 5);
                Point p2 = new Point(this.ClientSize.Width - 5, this.ClientSize.Height - 5);
                Point p3 = new Point(this.ClientSize.Width - 5, this.ClientSize.Height - 20);
                e.Graphics.FillPolygon(brush, new Point[] { p1, p2, p3 });
            }
        }
        #endregion

        #region subir audio

        private void SubirAudio_MouseHover(object sender, EventArgs e)
        {
            panel_SubirAudio.BackColor = Color.LightGreen;
            pictureBox_SubirAudio.BackColor = Color.LightGreen;
            label_SubirAudio.BackColor = Color.LightGreen;
        }
        private async void SubirAudio_Click(object sender, EventArgs e)
        {
            // Cambiar la ubicación del panel
            panel_SubirAudio.Location = new Point(370, 3);

            panel_SubirAudio.BackColor = Color.LimeGreen;
            pictureBox_SubirAudio.BackColor = Color.LightGreen;
            label_SubirAudio.BackColor = Color.LightGreen;
            label_SubirAudio.ForeColor = Color.White;

            // Cambiar el estilo de la fuente a Bold, Subrayado, y tamaño más pequeño
            label_SubirAudio.Font = new Font(
                label_SubirAudio.Font.FontFamily,
                6.5f, // Tamaño más pequeño
                FontStyle.Bold | FontStyle.Underline
            );

            // Convertir el texto a mayúsculas
            label_SubirAudio.Text = label_SubirAudio.Text.ToUpper();

            await Task.Delay(700); // Delay antes de abrir fileDialog

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurar el filtro para mostrar solo archivos de audio
                openFileDialog.Filter = "Archivos de audio (*.mp3;*.wav;*.flac)|*.mp3;*.wav;*.flac|Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccionar un archivo de audio";
                openFileDialog.Multiselect = false; // Solo permitir seleccionar un archivo

                // Mostrar el diálogo y verificar si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta completa del archivo seleccionado
                    string archivoSeleccionado = openFileDialog.FileName;

                    // Obtener solo el nombre del archivo (sin la ruta)
                    string nombreArchivo = Path.GetFileName(archivoSeleccionado);

                    // Aquí puedes manejar el archivo seleccionado, por ejemplo, reproducirlo o cargarlo
                    MensajeGeneral.Mostrar($"Archivo seleccionado: {nombreArchivo}", MensajeGeneral.TipoMensaje.Informacion);
                }

            }
        }



        private void SubirAudio_MouseLeave(object sender, EventArgs e)
        {
            // Cambiar la ubicación del panel
            panel_SubirAudio.Location = new Point(378, 3);

            panel_SubirAudio.BackColor = SystemColors.Menu;
            label_SubirAudio.BackColor = SystemColors.Menu;
            pictureBox_SubirAudio.BackColor = SystemColors.Menu;

            label_SubirAudio.ForeColor = SystemColors.ControlText; // Color de texto predeterminado

            // Restaurar la fuente a regular (sin subrayado ni negrita)
            label_SubirAudio.Font = new Font(
                label_SubirAudio.Font.FontFamily, // Familia de la fuente actual
                label_SubirAudio.Font.Size,       // Tamaño de la fuente actual
                FontStyle.Regular                 // Estilo regular
            );
            // Restaurar la fuente al formato original
            label_SubirAudio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

            // Restaurar el texto a CamelCase
            label_SubirAudio.Text = "Transcribir";
        }

        #endregion

        #region seleccion plantilla
        private void btn_Actuacion_Click(object sender, EventArgs e)
        {
            // Muestra el menú contextual en la posición del botón
            menu_SeleccionPlantilla.Show(btn_Actuacion, new Point(0, btn_Actuacion.Height));
        }


        /// <summary>
        /// Inserta un texto en el RichTextBox con formato específico
        /// </summary>
        private void InsertarTextoFormato(string texto, bool negrita = false, bool subrayado = false)
        {
            richTextBox_Redactor.SelectionStart = richTextBox_Redactor.TextLength;
            richTextBox_Redactor.SelectionLength = 0;

            // Aplicar formato
            FontStyle estilo = FontStyle.Regular;
            if (negrita) estilo |= FontStyle.Bold;
            if (subrayado) estilo |= FontStyle.Underline;

            richTextBox_Redactor.SelectionFont = new Font(richTextBox_Redactor.Font, estilo);
            richTextBox_Redactor.AppendText(texto);
            richTextBox_Redactor.SelectionFont = richTextBox_Redactor.Font; // Restaurar fuente normal
        }

        Dictionary<string, string> campos = new Dictionary<string, string>();
        private void CrearPlantilla()
        {

            string CortitoDelito = @"

            S.S.R.A.1.-
            PDS PINAMAR.-
            CRIA. PINAMAR 1ERA.-
            FECHA:{Fecha}.-
            LUGAR DEL HECHO: {Lugar del hecho}
            HECHO: {Caratula}.-
            INTERVIENE: UFID NRO.  {Fiscalia}. -
            DENUNCIANTE: {Denunciante}.-
            IMPUTADO: {Imputado}.-
            SINTESIS: Fecha  denuncia  {Denunciante} ({Edad}), D.N.I {Dni} ({turista/residente}) 
            {Relato del hecho} Crio. Mayor Valerio O. Gallo, jefe PDS Pinamar. Fdo. Crío. Mayor Carlos Abraham Domínguez
    ";

            richTextBox_Redactor.Text = CortitoDelito; // Cargar la plantilla



            string CortitoDroga = @"

            S.S.R.A.1.-
            PDS PINAMAR.-
            CRIA. PINAMAR 1ERA.-
            FECHA:{Fecha}.-
            LUGAR DEL HECHO: {Lugar del hecho}
            HECHO: {Caratula}.-
            INTERVIENE: UFID NRO.  AYUDANTIA FISCAL ESTUPEFACIENTES PINAMAR.-. -
            DENUNCIANTE: PERSONAL POLICIAL.-
            CAUSANTE: {Imputado}.-
            SINTESIS: Fecha personal de esta dependencia, procede en {Lugar del Hecho}, de este medio a {Relato del Hecho}la identificando a {Imputado},{Edad},{Dni}
             a quien se el eincauta en su poder sustancia compatible con {Tipo sustancia}, se realiza pesaje el cual arroja guarismo de {gramos sustancia}gms, se labran actuaciones por {Caratula}. 
            Interviene Ayudantía Fiscal de estupefacientes. 
            Crio. Mayor Valerio O. Gallo, jefe PDS Pinamar. Fdo. Crío. Mayor Carlos Abraham Domínguez
    ";

            richTextBox_Redactor.Text = CortitoDroga; // Cargar la plantilla



            string CortitoContravension = @"

               S.S.R.A.1.-
            PDS PINAMAR.-
            CRIA. PINAMAR 1ERA.-
            FECHA: {Fecha}.-
            LUGAR DEL HECHO:{Lugar del hecho}
            HECHO: INF. ART { Art Infraccion} DECRETO LEY 8031/73.-
            INTERVIENE: JUZGADO DE PAZ LETRADO PINAMAR.-
            DENUNCIANTE: PERSONAL POLICIAL.-
            CAUSANTE: {Imputado} -
            SINTESIS: Fecha  personal de esta dependencia , constituidos en calle  {Lugar del hecho},proceden  a la aprehensión de {Imputado} ({Edad}), DNI {Dni}, DDO {Domicilio}, 
            quien se encontraba {Relato del hecho}.Se labran actuaciones por infracción a los artículos {Art Infraccion} DEL DECRETO Ley 8031/73 .- 
            Interviene Juzgado de Paz Letrado de Pinamar, Dra. Guglielmetti.- Crio. Mayor Valerio O. Gallo, jefe PDS Pinamar. Fdo. Crío. Mayor Carlos Abraham Domíngue
                ";

            richTextBox_Redactor.Text = CortitoContravension; // Cargar la plantilla
        }

       
    }

}

#endregion