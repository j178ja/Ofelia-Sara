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
    }
}
