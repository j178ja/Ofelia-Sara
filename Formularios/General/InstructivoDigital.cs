
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General
{
    public partial class InstructivoDigital : BaseForm
    {
        #region VARIABLES
        private List<(string VideoRuta, string ImagenMiniatura)> listaVideos; // Almacén de videos con miniaturas
        private int indiceInicio;         // Índice del primer video visible
        private int videosPorPagina = 3;  // Número de videos visibles en el carrusel

        private readonly Dictionary<ModuloOrigen, List<(string VideoRuta, string ImagenMiniatura)>> videosPorModulo;
        #endregion

        #region PROPIEDADES PUBLICAS
        public ModuloOrigen ModuloActual { get; set; }
        #endregion

        #region CONSTRUCTOR
        public InstructivoDigital(ModuloOrigen moduloOrigen)
        {
            InitializeComponent();
            
            RedondearBordes.Aplicar(panel1, 16);
            RedondearBordes.Aplicar(panel2, 16);

            this.Height = panel1.Height + 90; // Ajustar la altura al tamaño de panel1
            this.MinimumSize = new Size(this.Width, panel1.Height + 90);


           // axWindowsMediaPlayer_Preview.Visible = false;
            // Inicializa las listas de videos para cada módulo
            videosPorModulo = new Dictionary<ModuloOrigen, List<(string VideoRuta, string ImagenMiniatura)>>
            {
                { // AL MOMENTO CON RUTAS RELATIVAS NO FUNCIONA
                    ModuloOrigen.InicioCierre,
                    new List<(string, string)>
                    {
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\ofl-Sara\\instructivoDemo.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\imagenes\\Redactador\\carrusel\\1.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\ofl-Sara\\instructivoDemo2.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/ofl-sara/carrusel/2.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\ofl-Sara\\instructivoDemo3.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/ofl-sara/carrusel/3.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\ofl-Sara\\instructivoDemo4.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/ofl-sara/carrusel/4.png")
                    }
                },
                {
                    ModuloOrigen.Mecanografia,
                    new List<(string, string)>
                    {
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Mecanografia\\instructivoDemo.mp4", " C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Mecanografia/carrusel/1.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Mecanografia\\instructivoDemo2.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Mecanografia/carrusel/2.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Mecanografia\\instructivoDemo3.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Mecanografia/carrusel/3.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Mecanografia\\instructivoDemo4.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Mecanografia/carrusel/4.png")
                    }
                },
                {
                    ModuloOrigen.Redactador,
                    new List<(string, string)>
                    {
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Redactador\\instructivoDemo1.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Redactador/carrusel/1.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Redactador\\instructivoDemo2.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Redactador/carrusel/2.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Redactador\\instructivoDemo3.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Redactador/carrusel/3.png"),
                        ("C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources\\videos\\Redactador\\instructivoDemo4.mp4", "C:\\Users\\Usuario\\OneDrive\\Escritorio\\Ofelia-Sara\\Resources/imagenes/Redactador/carrusel/4.png")
                    }
                }
            };

            // Establece el módulo actual
            ModuloActual = moduloOrigen;

            // Carga los videos correspondientes
            CargarVideos();
        }
        #endregion
        private void CargarVideos()
        {
            // Obtén la lista de videos para el módulo actual
            if (videosPorModulo.TryGetValue(ModuloActual, out var videos))
            {
                listaVideos = videos;
                ActualizarCarrusel();
            }
            else
            {
                MensajeGeneral.Mostrar("No hay videos disponibles", MensajeGeneral.TipoMensaje.Error);
            }
        }


        private void ActualizarCarrusel()
        {
            // Índices para los PictureBoxes
            int indiceCentral = indiceInicio;
            int indiceIzquierda = (indiceCentral - 1 + listaVideos.Count) % listaVideos.Count;
            int indiceDerecha = (indiceCentral + 1) % listaVideos.Count;

            // Configuración de PictureBoxes
            ConfigurarPictureBox(pictureBox_Izquierda, listaVideos[indiceIzquierda].ImagenMiniatura, listaVideos[indiceIzquierda].VideoRuta);
            ConfigurarPictureBox(pictureBox_Central, listaVideos[indiceCentral].ImagenMiniatura, listaVideos[indiceCentral].VideoRuta, true);
            ConfigurarPictureBox(pictureBox_Derecha, listaVideos[indiceDerecha].ImagenMiniatura, listaVideos[indiceDerecha].VideoRuta);
        }

        // Configurar cada PictureBox
        private void ConfigurarPictureBox(PictureBox pictureBox, string imagenMiniatura, string rutaVideo, bool esCentral = false)
        {
            string rutaCompleta = ObtenerRutaRelativa(imagenMiniatura);

            if (File.Exists(rutaCompleta))
            {
                pictureBox.Image = Image.FromFile(rutaCompleta);
            }
            else
            {
                pictureBox.Image = Properties.Resources.EscudoPolicia_PNG; // Imagen predeterminada
            }

            // Ajusta bordes redondeados
            RedondearImagen(pictureBox);
            pictureBox.SizeMode = esCentral ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.StretchImage;
            pictureBox.Tag = rutaVideo; // Almacena el video para manejar el clic
            pictureBox.Click -= PictureBox_Click; // Evita suscripciones duplicadas
            pictureBox.Click += PictureBox_Click;
            pictureBox.Cursor = Cursors.Hand;

            // Calcula tamaño y posición
            int panelHeight = tableLayoutPanel_Videos.Height;
            int panelWidth = tableLayoutPanel_Videos.Width;

            if (esCentral)
            {
                // Configuración para el PictureBox central
                pictureBox.Width = (int)(panelWidth * 0.5); // 50% del ancho del panel
                pictureBox.Height = pictureBox.Width; // Mantiene una proporción cuadrada
                pictureBox.Dock = DockStyle.Fill;
            }
            else
            {
                // Configuración para los PictureBox de los lados
                pictureBox.Width = (int)(panelWidth * 0.375); // 37.5% del ancho del panel
                pictureBox.Height = pictureBox.Width; // Mantiene una proporción cuadrada
            }

            // Centra verticalmente
            pictureBox.Top = (panelHeight - pictureBox.Height) / 2;

            // Ajusta el dock para alinearse correctamente
            pictureBox.Anchor = AnchorStyles.None;
        }

        private void RedondearImagen(PictureBox pictureBox)
        {
            int radio = 24; // Radio de las esquinas redondeadas
            var path = new GraphicsPath();

            // Crear un rectángulo con esquinas redondeadas
            path.AddArc(0, 0, radio, radio, 180, 90); // Esquina superior izquierda
            path.AddArc(pictureBox.Width - radio, 0, radio, radio, 270, 90); // Esquina superior derecha
            path.AddArc(pictureBox.Width - radio, pictureBox.Height - radio, radio, radio, 0, 90); // Esquina inferior derecha
            path.AddArc(0, pictureBox.Height - radio, radio, radio, 90, 90); // Esquina inferior izquierda
            path.CloseFigure(); // Completa el contorno

            // Asignar la región con bordes redondeados al PictureBox
            pictureBox.Region = new Region(path);
        }




        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is string rutaVideo)
            {
                string rutaVideoCompleta = ObtenerRutaRelativa(rutaVideo);
                if (File.Exists(rutaVideoCompleta))
                {
                    ReproducirVideo(rutaVideoCompleta);
                }
                else
                {
                    MensajeGeneral.Mostrar($"El video no se encuentra: {rutaVideoCompleta}", MensajeGeneral.TipoMensaje.Error);
                }
            }
        }



        private void Btn_Anterior_Click(object sender, EventArgs e)
        {
            indiceInicio = (indiceInicio - 1 + listaVideos.Count) % listaVideos.Count; // Cicla al índice anterior
            ActualizarCarrusel();
        }

        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            indiceInicio = (indiceInicio + 1) % listaVideos.Count; // Cicla al siguiente índice
            ActualizarCarrusel();
        }


        public enum ModuloOrigen
        {
            InicioCierre,
            Mecanografia,
            Redactador
        }
        #region LOAD
        private void InstructivoDigital_Load(object sender, EventArgs e)
        {
            panel2.Visible = false; // Ocultar panel2 inicialmente
            ValidarPanel2();
        }
        #endregion

        private string ObtenerRutaRelativa(string rutaArchivo)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaArchivo.Replace("/", Path.DirectorySeparatorChar.ToString()));
        }

        private void ReproducirVideo(string rutaVideo)
        {
            panel1.Height = 100; // Reducir el tamaño de panel1
            panel2.Visible = true;
            ValidarPanel2();

            panel2.Location = new Point(panel2.Location.X, panel1.Bottom + 5); // Posicionar panel2 debajo de panel1

            // Usar Form.ActiveForm para obtener el formulario activo
            if (Form.ActiveForm is InstructivoDigital formulario)
            {
                formulario.Height = panel1.Height + panel2.Height + 100; // Expandir el tamaño del formulario
            }

            axWindowsMediaPlayer_Videos.URL = rutaVideo;
           // axWindowsMediaPlayer_Videos.Ctlcontrols.play();
        }

        private void DetenerVideo()
        {
          //  axWindowsMediaPlayer_Videos.Ctlcontrols.stop();
            panel2.Visible = false;
            panel1.Height = 240; // Restaurar tamaño original de panel1
            //this.Height = panel1.Height + 90; // Restaurar altura del formulario
            // Usar Form.ActiveForm para obtener el formulario activo
            if (Form.ActiveForm is InstructivoDigital formulario)
            {
                formulario.Height = panel1.Height + panel2.Height + 90; // Expandir el tamaño del formulario
            }
        }
        private void axWindowsMediaPlayer_Videos_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Estados de Windows Media Player
            switch (e.newState)
            {
                //siempre tienen el mismo valor de case
                case 1: // Stopped
                    DetenerVideo(); // Llama a tu método para restablecer el estado
                    break;

                case 8: // Media Ended
                    DetenerVideo(); // Restablecer al terminar el video
                    break;
            }
        }
       
        private void ValidarPanel2()
        {
            if (panel2.Visible)
            {
                // Hacer el formulario redimensionable
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MinimumSize = new Size(this.Width, panel1.Height + panel2.Height + 90);
                this.MaximumSize = new Size(0, 0); // Permitir redimensionamiento completo
            }
            else
            {
                // Hacer el formulario no redimensionable
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MinimumSize = new Size(this.Width, this.Height); // Bloquear tamaño actual
                this.MaximumSize = new Size(this.Width, this.Height); // Bloquear tamaño actual
            }
        }





        /// <summary>
        /// EVENTOS CAMBIO DE IMAGEN EN BOTON, POSTERIORMENTE SE DEBE CREAR UN MEJOR BOTON CON ANIMACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Siguiente_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Siguiente.BackgroundImage = Properties.Resources.siguienteClick; // Imagen al presionar
        }

        private void Btn_Siguiente_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Siguiente.BackgroundImage = Properties.Resources.siguiente; // Imagen al soltar
        }

        private void Btn_Siguiente_MouseLeave(object sender, EventArgs e)
        {
            btn_Siguiente.BackgroundImage = Properties.Resources.siguiente; // Imagen al salir del botón
        }

        private void Btn_Anterior_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Anterior.BackgroundImage = Properties.Resources.anteriorClick; // Imagen al presionar
        }

        private void Btn_Anterior_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Anterior.BackgroundImage = Properties.Resources.anterior; // Imagen al soltar
        }

        private void Btn_Anterior_MouseLeave(object sender, EventArgs e)
        {
            btn_Anterior.BackgroundImage = Properties.Resources.anterior; // Imagen al salir del botón
        }

    }
}


