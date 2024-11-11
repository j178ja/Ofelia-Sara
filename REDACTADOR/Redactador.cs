using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using REDACTADOR.Mensaje;


namespace REDACTADOR
{
    public partial class Redactador : Form
    {
        private WaveInEvent waveIn;
        private WaveFileWriter waveFileWriter;
        private string outputFile = "mic_recording.wav";
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private Button botonAlineacionSeleccionado = null; //para saber con que formato de texto se esta trabajando

        public Redactador()
        {
            InitializeComponent();
            // Coloca el panel encima del AudioVisualizerControl
            panel_Botones.BringToFront();
            
        }
        private void Redactador_Load(object sender, EventArgs e)
        {
            audioVisualizerControl.Visible = false;
            toolTip.SetToolTip(btn_Microfono, "ACTIVAR micrófono");
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.RedondearBordes(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            this.FormClosing += Redactador_FormClosing;// para mensaje previo a cerrar

            CambiarAlineacion(btn_Justificar, HorizontalAlignment.Left);// para que inicie en justificado

            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
        }


        private ToolTip toolTip = new ToolTip();
        private void btn_Microfono_Click(object sender, EventArgs e)
        {
            // Verificar si hay dispositivos de entrada (micrófono)
            if (WaveIn.DeviceCount == 0)
            {
                // No hay micrófono disponible; mostrar mensaje al usuario
                MensajeGeneral.Mostrar("No se ha detectado ningún micrófono conectado. Conecte un micrófono e inténtelo de nuevo.",MensajeGeneral.TipoMensaje.Error);
                return;
            }
            //   DESACTIVAR MICROFONO
            if (btn_Microfono.BackColor == System.Drawing.Color.LimeGreen)
            {
                StopRecording();
                btn_Microfono.BackColor = System.Drawing.Color.Red;
                audioVisualizerControl.Visible = false;
                btn_Microfono.Focus();
                toolTip.SetToolTip(btn_Microfono, "ACTIVAR micrófono");
            }
            else //  ACTIVAR MICROFONO
            {
                
                btn_Microfono.BackColor = System.Drawing.Color.LimeGreen;
                audioVisualizerControl.Visible = true;
                richTextBox_Redactor.Focus();
                toolTip.SetToolTip(btn_Microfono, "DESACTIVAR micrófono");
                StartRecording();
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

        // Evento que se activa cada vez que el contenido del RichTextBox cambia
        private void richTextBox_Redactor_TextChanged(object sender, EventArgs e)
        {
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
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;

            // Evento MouseEnter: Cambia el tamaño desde el centro y el color de fondo
            boton.MouseEnter += (sender, e) =>
            {
                // Calcula el incremento para centrar el cambio de tamaño
                int incremento = 12;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);
                boton.BackColor = Color.FromArgb(51, 174, 189);
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
                boton.BackColor = Color.FromArgb(51, 174, 189); //20% MAS CLARO QUE EL COLOR OFICIAL Y DE FONDO
            };

            // Evento MouseLeave: Restaura el tamaño y la posición original, y el color de fondo original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.SkyBlue;
            };
        }
    }
}
