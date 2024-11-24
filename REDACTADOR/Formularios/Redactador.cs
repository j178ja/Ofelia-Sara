using REDACTADOR.Clases;
using NAudio.Wave;
using REDACTADOR.Mensaje;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices; // Para la importación de funciones nativas
using System.Threading.Tasks;
using System.Windows.Forms;
using REDACTADOR.Formularios;


namespace REDACTADOR.Formularios
{
    public partial class Redactador : BaseForm
    {
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
        //AMPLIAR FORMULARIO
        private bool isResizing = false;
        private Point lastMousePosition;
        //------------------------------------------------------
        private WaveInEvent waveIn;
        private WaveFileWriter waveFileWriter;
        private string outputFile = "mic_recording.wav";
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private Button botonAlineacionSeleccionado = null; //para saber con que formato de texto se esta trabajando

        Timer timerCerrarForm = new Timer();
        Timer timerMinimizarForm = new Timer();
        public Redactador()
        {
            InitializeComponent();
            // Coloca el panel encima del AudioVisualizerControl
            panel_Botones.BringToFront();

            timer_Barras = new Timer();
            timer_Barras.Interval = 100; // Ajusta el intervalo
            timer_Barras.Tick += timer_Barras_Tick;
        
        }
        private void Redactador_Load(object sender, EventArgs e)
        {
            audioVisualizerControl.Visible = false;
            ToolTipGeneral.ShowToolTip(this, btn_Microfono, "ACTIVAR micrófono");
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.RedondearBordes(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);


            this.FormClosing += Redactador_FormClosing;// para mensaje previo a cerrar

            CambiarAlineacion(btn_Justificar, HorizontalAlignment.Left);// para que inicie en justificado

            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

            //----timer para que se vea efecto de cambio de color en los btn cerrar y minimizar
            timerCerrarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerMinimizarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerCerrarForm.Tick += TimerCerrar_Tick;
            timerMinimizarForm.Tick += TimerMinimizar_Tick;

            ToolTipGeneral.ShowToolTip(this, btn_Guardar, "CREAR DOCUMENTO WORD");
            ToolTipGeneral.ShowToolTip(this, btn_Limpiar, "ELIMINAR");
            ToolTipGeneral.ShowToolTip(this, btn_Negrita, "NEGRITA");
            ToolTipGeneral.ShowToolTip(this, btn_Cursiva, "CURSIVA");
            ToolTipGeneral.ShowToolTip(this, btn_Subrayado, "SUBRAYAR");
            ToolTipGeneral.ShowToolTip(this, btn_AumentarTamaño, "Aumentar tamaño");
            ToolTipGeneral.ShowToolTip(this, btn_ReducirTamaño, "Reducir tamaño");
            ToolTipGeneral.ShowToolTip(this, btn_MayusculaMinuscula, "MAYUSCULA/minuscula");
            ToolTipGeneral.ShowToolTip(this, btn_AlinearIzquierda, "Alinear a la Izquierda");
            ToolTipGeneral.ShowToolTip(this, btn_Centrar, "CENTRAR");
            ToolTipGeneral.ShowToolTip(this, btn_AlinearDerecha, "Alinear a la Derecha");
            ToolTipGeneral.ShowToolTip(this, btn_Justificar, "JUSTIFICAR");
            ToolTipGeneral.ShowToolTip(this, label_OfeliaSara, "Instructivo de la aplicación");

            richTextBox_Redactor.GotFocus += RichTextBox_Redactor_GotFocus;
        }
        //---------------------------------------------------------------------------------
        //----BARRA SUPERIOR-----
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.FromArgb(255, 69, 58);
            btn_Cerrar.ForeColor = SystemColors.Control;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.LightCoral;
            timer_Barras.Stop();
            audioVisualizerControl.Visible = false;

            timerCerrarForm.Start();
        }
        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            timerCerrarForm.Stop();
            this.Close();
        }

        private void Btn_Cerrar_MouseHover(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.Lavender;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.LightCoral;
        }

        private void Btn_Cerrar_MouseLeave(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = SystemColors.ButtonFace;
            btn_Cerrar.ForeColor = SystemColors.ControlDarkDark;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }
        //-------------------------------------------------------------------------
        private void TimerMinimizar_Tick(object sender, EventArgs e)
        {
            // Detener el timer
            timerMinimizarForm.Stop();

            // Minimizar solo el formulario actual
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            // Cambiar estilo visual del botón de minimizar
            btn_Minimizar.BackColor = SystemColors.ActiveCaption;
            btn_Minimizar.ForeColor = SystemColors.Control;
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.Highlight;

            // Si el formulario actual es menuPrincipal, minimizarlo
            if (this.Name == "menuPrincipal")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                // Iniciar el timer solo para minimizar el formulario actual (no el menuPrincipal)
                timerMinimizarForm.Start();
            }
        }

        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            // Cambiar estilo visual del botón de maximizar
            btn_Maximizar.BackColor = SystemColors.ActiveCaption;
            btn_Maximizar.ForeColor = SystemColors.Control;
            btn_Maximizar.FlatAppearance.BorderSize = 2;

            // Verificar si el formulario está maximizado
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Si está maximizado, restaurar al tamaño mínimo
                this.WindowState = FormWindowState.Normal;
                this.Size = this.MinimumSize;
                richTextBox_Redactor.Focus();
            }
            else
            {
                // Si no está maximizado, maximizar el formulario
                this.WindowState = FormWindowState.Maximized;
                richTextBox_Redactor.Focus();
            }
        }

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

        //--------------------------------------------------------------------------------
        // Bandera para activar o desactivar el subrayado personalizado
        private bool mostrarSubrayado = false;
        //para hacer que se extienda 
        private int lineWidth = 0;
        private bool isAnimating = false;
        private Timer animationTimer;

        // Método para activar el subrayado en MouseHover
        private void Label_OfeliaSara_MouseHover(object sender, EventArgs e)
        {
            isAnimating = true;
            lineWidth = 0;

            // Configurar el Timer si aún no está configurado
            if (animationTimer == null)
            {
                animationTimer = new Timer();
                animationTimer.Interval = 15; // Intervalo en ms para una animación suave
                animationTimer.Tick += (s, args) =>
                {
                    if (lineWidth < label_OfeliaSara.Width / 2)
                    {
                        lineWidth += 2; // Aumenta gradualmente la longitud de la línea
                        label_OfeliaSara.Invalidate(); // Redibuja el Label
                    }
                    else
                    {
                        animationTimer.Stop(); // Detiene el Timer cuando se completa la animación
                    }
                };
            }

            animationTimer.Start(); // Inicia el Timer para la animación
        }

        // Método para desactivar el subrayado en MouseLeave
        private void Label_OfeliaSara_MouseLeave(object sender, EventArgs e)
        {
            isAnimating = false;
            lineWidth = 0;
            animationTimer?.Stop(); // Detener el Timer
            label_OfeliaSara.Invalidate(); // Redibuja el Label para eliminar el subrayado
        }


        // Método Paint para dibujar el subrayado personalizado


        private void Label_OfeliaSara_Paint(object sender, PaintEventArgs e)
        {
            if (isAnimating)
            {
                // Define el color y grosor de la línea
                using (Pen pen = new Pen(SystemColors.Highlight, 3))
                {
                    // Centro del Label
                    int centerX = label_OfeliaSara.Width / 2;
                    int y = label_OfeliaSara.Font.Height; // Posición 3 píxeles debajo del texto

                    // Dibuja la línea desde el centro hacia los extremos
                    e.Graphics.DrawLine(pen, centerX - lineWidth, y, centerX + lineWidth, y);
                }
            }
        }

        // Variable para almacenar la posición original del formulario Redactador
        private Point posicionOriginalRedactador;

        private void Label_OfeliaSara_Click(object sender, EventArgs e)
        {
            // Cambiar color y subrayar el texto del label
            label_OfeliaSara.ForeColor = Color.Coral;
            label_OfeliaSara.Font = new Font(label_OfeliaSara.Font, FontStyle.Underline);

            // Calcular la nueva ubicación para el formulario Redactador
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;
            int xRedactador = menuPrincipalLocation.X - menuPrincipalSize.Width / 2;
            int y = menuPrincipalLocation.Y; // Mantener la misma posición vertical

            // Almacenar la posición original del formulario Redactador antes de moverlo
            posicionOriginalRedactador = menuPrincipalLocation;

            // Mover el formulario Redactador
            this.Location = new Point(xRedactador, y);

            // Crear e inicializar el formulario para mostrar el video
            VideoInstructivo videoInstructivo = new VideoInstructivo();

            // Suscribirse al evento FormClosed para restaurar el Label y la posición de Redactador
            videoInstructivo.FormClosed += (s, args) =>
            {
                label_OfeliaSara.ForeColor = SystemColors.ControlText;
                label_OfeliaSara.Font = new Font(label_OfeliaSara.Font, FontStyle.Regular); // Restablecer estilo original

                // Restaurar la posición original del formulario Redactador
                this.Location = posicionOriginalRedactador;
            };

            // Calcular la posición de VideoInstructivo al lado de la posición desplazada de Redactador
            int xVideoInstructivo = xRedactador + menuPrincipalSize.Width + 10;

            // Ajustar la ubicación del formulario VideoInstructivo
            videoInstructivo.StartPosition = FormStartPosition.Manual;
            videoInstructivo.Location = new Point(xVideoInstructivo, y);

            videoInstructivo.Show();
        }




        //para poder arrastrar el formulario
        private void panel_MenuSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        //----------------------------------------------------------------------------------


        // private ToolTip toolTip = new ToolTip();

        private ToolTip toolTip = new ToolTip();

        private void btn_Microfono_Click(object sender, EventArgs e)
        {
            // Verificar si hay dispositivos de entrada (micrófono)
            if (WaveIn.DeviceCount == 0)
            {
                MensajeGeneral.Mostrar("No se ha detectado ningún micrófono conectado. Conecte un micrófono e inténtelo de nuevo.", MensajeGeneral.TipoMensaje.Error);
                return;
            }

            // Ocultar cualquier ToolTip existente antes de mostrar uno nuevo
            ToolTipGeneral.HideToolTip(btn_Microfono);

            // Cambiar el estado del micrófono (activar/desactivar)
            if (btn_Microfono.BackColor == System.Drawing.Color.LimeGreen) // Desactivar micrófono
            {
                timer_Barras.Stop();
                StopRecording();
                btn_Microfono.BackColor = System.Drawing.Color.Red;
                audioVisualizerControl.Visible = false;
                richTextBox_Redactor.Focus();

                // Mostrar ToolTip para activar el micrófono
                ToolTipGeneral.ShowToolTip(this, btn_Microfono, "ACTIVAR micrófono");
            }
            else // Activar micrófono
            {
                btn_Microfono.BackColor = System.Drawing.Color.LimeGreen;
                audioVisualizerControl.Visible = true;
                richTextBox_Redactor.Focus();

                // Mostrar ToolTip para desactivar el micrófono
                ToolTipGeneral.ShowToolTip(this, btn_Microfono, "DESACTIVAR micrófono");

                StartRecording();
                timer_Barras.Start(); // Inicia el temporizador para actualizar las barras de visualización
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
            Random random = new Random();
            int[] amplitudes = new int[audioVisualizerControl.Controls.Count];
            for (int i = 0; i < amplitudes.Length; i++)
            {
                amplitudes[i] = random.Next(5, 50); // Alturas aleatorias como ejemplo
            }

            // Llamar al método de actualización de visualización en el control de visualización
            audioVisualizerControl.UpdateVisualization(amplitudes);
        }
        //----------- FUNCIONALIDAD DE TECLAS-------------------------------
        private void btn_Negrita_Click(object sender, EventArgs e)
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
        private void btn_Subrayado_Click(object sender, EventArgs e)
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
        //--------------BOTONES AUMENTAR Y DISMINUIR TAMAÑO----------------
        private void btn_AumentarTamaño_Click(object sender, EventArgs e)
        {
            CambiarTamañoFuente(2);  // Aumentar el tamaño de la fuente en 2 puntos
            richTextBox_Redactor.Focus();
        }

        private void btn_DisminuirTamaño_Click(object sender, EventArgs e)
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
        //--------------BOTON ALTERNANCIA MAYUSCULA-MINUSCULA------




        // Variable para almacenar si la escritura actual está en mayúsculas o minúsculas
        private bool escribirEnMayusculas = false;

        private void btn_MayusculaMiniscula_Click(object sender, EventArgs e)
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
        private void richTextBox_Redactor_TextChanged(object sender, EventArgs e)
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
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button boton = sender as Button; // Convertir el sender a tipo Button
            if (boton != null)
            {
                boton.BackColor = Color.SkyBlue;
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button boton = sender as Button; // Convertir el sender a tipo Button
            if (boton != null)
            {
                boton.BackColor = Color.White;
            }
        }
        //-------------------------------------
        private void btn_AlinearIzquierda_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_AlinearIzquierda, HorizontalAlignment.Left);
            richTextBox_Redactor.Focus();
        }

        private void btn_AlinearDerecha_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_AlinearDerecha, HorizontalAlignment.Right);
            richTextBox_Redactor.Focus();
        }

        private void btn_Centrar_Click(object sender, EventArgs e)
        {
            CambiarAlineacion(btn_Centrar, HorizontalAlignment.Center);
            richTextBox_Redactor.Focus();
        }

        private void btn_Justificar_Click(object sender, EventArgs e)
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


        //------------------------------------
        private void btn_Eliminar_Click(object sender, EventArgs e)
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
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
                {
                    // Hacer visibles los botones
                    mensaje.MostrarBotonesConfirmacion(true);

                    DialogResult result = mensaje.ShowDialog();
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Cancelar el cierre del formulario
                    }
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
        }

        //-------------------------------------------
        protected void InicializarEstiloBoton(Button boton)
        {
            // Variables para almacenar el tamaño y la posición original solo al entrar en el botón
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;
            Color originalBackColor = boton.BackColor;
            bool posicionOriginalGuardada = false;

            // Evento MouseEnter: captura la posición original y amplía desde el centro
            boton.MouseEnter += (sender, e) =>
            {
                if (!posicionOriginalGuardada)
                {
                    originalSize = boton.Size;
                    originalLocation = boton.Location;
                    posicionOriginalGuardada = true;
                }

                // Ajustar tamaño y posición desde el centro
                int incremento = 12;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;

                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);
                boton.BackColor = Color.FromArgb(51, 174, 189);
            };

            // Evento MouseLeave: Restaura el tamaño y posición originales
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = originalBackColor;
                posicionOriginalGuardada = false;  // Restablecer la bandera para la próxima entrada
            };
        }


        //---------------------------------------------------------------

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


    }

}

