using Ofelia_Sara.general.clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios
{
    public partial class VideoInstructivo : BaseForm
    {
        public VideoInstructivo()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            this.Resize += new EventHandler(VideoInstructivo_Resize); // Suscripción al evento Resize
        }

        private void VideoInstructivo_Load(object sender, EventArgs e)
        {

            // Ruta del archivo MP4
            string videoPath = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Resources\videos\instructivoDemo.mp4";

            // Verificar si el archivo existe
            if (System.IO.File.Exists(videoPath))
            {
                // Establecer la URL en el control AxWindowsMediaPlayer
                instructivo.URL = videoPath;

                // Iniciar la reproducción
                instructivo.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show("El archivo de video no se encontró en la ruta especificada.");
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void VideoInstructivo_Resize(object sender, EventArgs e)
        {
            // Margen opcional
            int margen = 10;
            int bottomMargin = 30; // Margen inferior deseado

            // Ajustar el tamaño del panel manteniendo el margen inferior
            panel1.Width = this.ClientSize.Width - margen * 2;
            panel1.Height = this.ClientSize.Height - bottomMargin - margen; // Restar el margen inferior y superior
            panel1.Location = new Point(margen, margen); // Centrar el panel con margen superior y lateral

            // Calcular proporciones del AxWindowsMediaPlayer
            float mediaPlayerProporcionAncho = 444f / 530f; // Proporción de ancho del MediaPlayer
            float mediaPlayerProporcionAlto = 255f / 298f;  // Proporción de alto del MediaPlayer

            // Ajustar el tamaño del AxWindowsMediaPlayer manteniendo proporciones
            instructivo.Width = (int)(panel1.ClientSize.Width * mediaPlayerProporcionAncho);
            instructivo.Height = (int)(panel1.ClientSize.Height * mediaPlayerProporcionAlto);
            instructivo.Location = new Point((panel1.ClientSize.Width - instructivo.Width) / 2, (panel1.ClientSize.Height - instructivo.Height) / 2); // Centrar el MediaPlayer en el panel
        }




    }
}

