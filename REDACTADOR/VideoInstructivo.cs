using Clases;
using REDACTADOR.Mensaje;
using REDACTADOR.Clases;
using System.Drawing.Drawing2D;
using System;
using System.Drawing;

using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;



namespace REDACTADOR
{
    public partial class VideoInstructivo : Form
    {
        private List<Image> imagenes = new List<Image>(); // Lista para almacenar las imágenes cargadas
        private int indiceInicio = 0; // Índice para manejar las imágenes mostradas
        private Dictionary<PictureBox, string> videoPaths = new Dictionary<PictureBox, string>();
  
        public VideoInstructivo()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.RedondearBordes(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

           // this.Resize += new EventHandler(VideoInstructivo_Resize); // Suscripción al evento Resize
            SetDoubleBuffered(Carrusel);
        }


        private void VideoInstructivo_Load(object sender, EventArgs e)
        {
            
            BuscarCarpetaImagenes();//metodo para buscar la carpeta de imagenes a mostrar en el carrusell

            InicializarCarruselConImagenes();//carga las imagenes en el carrusel
            CentrarPanelContenedorCarrusel(); // centra el carrusel en el panel1
            CargarImagenFondo(); // carga e inicia animacion de fondo del carrusel

            this.MaximizeBox = false; // Deshabilitar el botón de maximizar
            this.FormBorderStyle = FormBorderStyle.FixedDialog;  // Evita redimensionar el formulario
        }

        /// <summary>
        /// metodo para buscar las imagenes que seran mostradas en el carrusel
        /// </summary>
        private void BuscarCarpetaImagenes()
        {
            string rutaCarpetaImagenes = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\REDACTADOR\Resources\Imagenes\carrusel\Fotogramas\";

            if (Directory.Exists(rutaCarpetaImagenes))
            {
                foreach (string archivo in Directory.GetFiles(rutaCarpetaImagenes, "*.jpg"))
                {
                    try
                    {
                        Image img = Image.FromFile(archivo);
                        imagenes.Add(img);
                    }
                    catch (Exception ex)
                    {
                        MensajeGeneral.Mostrar($"Error al cargar la imagen {archivo}: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                    }
                }
            }
            else
            {
                MensajeGeneral.Mostrar("La carpeta de imágenes no existe.", MensajeGeneral.TipoMensaje.Error);
            }
        }
            /// <summary>
            /// Método para activar DoubleBuffered en cualquier control
            /// </summary>
            private void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        /// <summary>
        /// panel contenedor de tableLayout CARRUSEL usado para cuando carga el formulario tenga un tamño mayor
        /// y contenga tanto el carrusel como los botones anterior y siguiente
        /// </summary>
        private void CentrarPanelContenedorCarrusel()
        {
            if (panel1 != null && panel_ContenedorCarrusel != null)
            {
                // Establecer la altura de panel1 
                panel1.Height = 280;

                // Aumentar la altura de panel_ContenedorCarrusel 
                int nuevaAltura = (int)(panel_ContenedorCarrusel.Height * 2.8);
                panel_ContenedorCarrusel.Height = nuevaAltura;

                // Calcular la posición vertical (alineación vertical / 2)
                int nuevaPosicionY = (panel1.Height - panel_ContenedorCarrusel.Height) / 2;

                // Establecer la nueva ubicación del panel_ContenedorCarrusel
                panel_ContenedorCarrusel.Location = new Point(
                    panel_ContenedorCarrusel.Location.X, // Mantener la posición horizontal
                    nuevaPosicionY                       // Establecer la posición vertical centrada
                    );
            }
        }




        //private void VideoInstructivo_Resize(object sender, EventArgs e)
        //{

        //    //int margen = 10;
        //    //int bottomMargin = 30; // Margen inferior deseado

        //    //// Ajustar el tamaño del panel manteniendo el margen inferior
        //    //panel1.Width = this.ClientSize.Width - margen * 2;
        //    //panel1.Height = this.ClientSize.Height - bottomMargin - margen; // Restar el margen inferior y superior
        //    //panel1.Location = new Point(margen, margen); // Centrar el panel con margen superior y lateral

        //    //// Calcular proporciones del AxWindowsMediaPlayer
        //    float mediaPlayerProporcionAncho = 444f / 530f; // Proporción de ancho del MediaPlayer
        //    float mediaPlayerProporcionAlto = 255f / 298f;  // Proporción de alto del MediaPlayer

        //    // Ajustar el tamaño del AxWindowsMediaPlayer manteniendo proporciones
        //    instructivo.Width = (int)(panel1.ClientSize.Width * mediaPlayerProporcionAncho);
        //    instructivo.Height = (int)(panel1.ClientSize.Height * mediaPlayerProporcionAlto);
        //    instructivo.Location = new Point((panel1.ClientSize.Width - instructivo.Width) / 2, (panel1.ClientSize.Height - instructivo.Height) / 2); // Centrar el MediaPlayer en el panel
        //}
        /// <summary>
        /// carga las imagenes en las columnas obteniendolas por medio de su indice
        /// </summary>
        private void InicializarCarruselConImagenes()
        {
            // Limpiar controles del carrusel
            Carrusel.Controls.Clear();

            // Máximo de imágenes a mostrar
            int maxImagenesMostrar = 5;

            for (int i = 0; i < maxImagenesMostrar; i++)
            {
                int indiceImagen = (indiceInicio + i) % imagenes.Count; // Calcula el índice circular

                // Crear PictureBox para la imagen correspondiente
                PictureBox pictureBox = CrearPictureBoxConImagen(imagenes[indiceImagen]);

                // Configurar la imagen según su posición
                AplicarFormatoAImagen(pictureBox, i);

                // Agregar al carrusel
                Carrusel.Controls.Add(pictureBox, i, 0);
            }
        }

        /// <summary>
        /// establece propiedades para las imagenes del carrusel LE DA BORDE REDONDEADO
        /// </summary>
    
        private PictureBox CrearPictureBoxConImagen(Image imagen)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = imagen,
                SizeMode = PictureBoxSizeMode.StretchImage,
                 Dock = DockStyle.None,
                 Anchor = AnchorStyles.None
                         
            };

            // Aplicar bordes redondeados
            pictureBox.Paint += (sender, e) =>
            {
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    int radius = 6;
                    GraphicsPath path = CreateRoundedRectanglePath(pb.ClientRectangle, radius);
                    pb.Region = new Region(path);
                }
            };
            return pictureBox;
        }

        /// <summary>
        /// aplicar formato de columnas para cuando se inicializa y se carga el carrusel
        /// </summary>
      
        private void AplicarFormatoAImagen(PictureBox pictureBox, int columna)
        {
            int alturaBase = 180;
            int anchoColumna = Carrusel.Width / Carrusel.ColumnCount;
            int anchoColumna3 = (int)(Carrusel.Width * 0.40);

            switch (columna)
            {
                case 2: // Columna 3 (CENTRAL)
                    pictureBox.Height = alturaBase;
                    pictureBox.Dock = DockStyle.Fill; //establece que la imagen ocupe el ancho y alto de la columna
               
                    break;
                case 1: // Columna 2
                case 3: // Columna 4
                    pictureBox.Height = (int)(alturaBase * 0.75);
                    break;
                case 0: // Columna 1
                case 4: // Columna 5
                    pictureBox.Height = (int)(alturaBase * 0.5);
                    break;
            }
            // Ajustar el ancho de la imagen para que abarque el ancho de la columna
            pictureBox.Width = anchoColumna;

            // Centrar la imagen verticalmente dentro de la celda
            pictureBox.Top = (alturaBase - pictureBox.Height) / 2;

            // Ajustar la posición horizontal para centrar la imagen dentro de la columna
            pictureBox.Left = 0; // No es necesario centrar horizontalmente, ya que abarcará todo el ancho de la columna
        }


        /// <summary>
        /// Crea un GraphicsPath para un rectángulo con esquinas redondeadas. REDIBUJA TABLELAYOUT "CARRUSEL"
        /// </summary>
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Verifica si el radio es mayor que 0, para evitar bordes excesivamente planos
            if (radius > 0)
            {
                // Agregar las esquinas y bordes con un radio menor
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Esquina superior izquierda
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Esquina superior derecha
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Esquina inferior derecha
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Esquina inferior izquierda
                path.CloseFigure();
            }
            else
            {
                // Si el radio es 0 o menor, no redondear
                path.AddRectangle(rect);
            }

            return path;
        }

        /// <summary>
        /// declaracion de variables que se van a usar para la animacion del fondo del carrusel
        /// </summary>

        private float scaleFactor = 0.1f;  // Inicial tamaño pequeño
        private float scaleSpeed = 0.02f;  // Velocidad de expansión
        private Timer animacionTimer;      // Timer para controlar la animación
        private Image fondoAnimado;

        /// <summary>
        /// // establecer la imagen que se va a ampliar e iniciarla
        /// </summary>
        private void CargarImagenFondo()
        {
            // Asignar la imagen al fondoAnimado desde Resources
            fondoAnimado = Properties.Resources.ICOes;

            // Si la imagen se carga correctamente, inicia la animación
            if (fondoAnimado != null)
            {
                IniciarAnimacionFondo();
            }
        }
        /// <summary>
        ///     // para inicializar la imagen que se amplia en el fondo del carrusel
        /// </summary>

        private void IniciarAnimacionFondo()
        {
            animacionTimer = new Timer
            {
                Interval = 10
            };
            animacionTimer.Tick += AnimacionFondo_Tick;
            animacionTimer.Start();

            // Inicializar el factor de escala
            scaleFactor = 0.1f;
        }


        /// <summary>
        /// Evento Tick del Timer para controlar la animación
        /// </summary>
        private void AnimacionFondo_Tick(object sender, EventArgs e)
        {
            // Incrementar el factor de escala para hacer crecer la imagen
            scaleFactor += 0.01f;

            // Si la imagen alcanza o supera el tamaño máximo, reinicia el ciclo
            if (scaleFactor >= 4f)
            {
                scaleFactor = 0.1f; // Reinicia al tamaño pequeño
            }

            // Redibujar únicamente el TableLayoutPanel (Carrusel)
            Carrusel.Invalidate();
        }

        /// <summary>
         /// Evento Paint para dibujar la imagen de fondo animada en el TableLayoutPanel
        /// </summary>
        private void Carrusel_Paint(object sender, PaintEventArgs e)
        {
            TableLayoutPanel table = sender as TableLayoutPanel;

            if (table != null && fondoAnimado != null)
            {
                Graphics g = e.Graphics;

                // Calcular el nuevo tamaño de la imagen basado en scaleFactor
                int imagenWidth = (int)(fondoAnimado.Width * scaleFactor);
                int imagenHeight = (int)(fondoAnimado.Height * scaleFactor);

                // Calcular la posición para centrar la imagen
                int imageX = (table.ClientSize.Width - imagenWidth) / 2;
                int imageY = (table.ClientSize.Height - imagenHeight) / 2;

                // Dibujar la imagen escalada en el centro
                g.DrawImage(fondoAnimado, new Rectangle(imageX, imageY, imagenWidth, imagenHeight));

                // Opcional: Dibujar bordes redondeados en el TableLayoutPanel
                int radius = 6; // Radio de los bordes redondeados
                Rectangle clientRect = table.ClientRectangle;

                using (GraphicsPath path = RedondearBordes.CreateRoundedRectangle(clientRect, radius))
                {
                    using (Pen pen = new Pen(Color.Black, 2)) // Color y grosor del borde
                    {
                        g.DrawPath(pen, path);
                    }

                    // Aplicar la región redondeada al TableLayoutPanel
                    table.Region = new Region(path);
                }
            }
        }

       
      

        /// <summary>
        /// METODOS PARA CAMBIAR IMAGENES DENTRO DEL CARRUSEL
        /// </summary>
        
        private void btn_SiguienteImagen_Click(object sender, EventArgs e)
        {
            if (imagenes.Count == 0) return;

            // Avanzar el índice y actualizar el carrusel
            indiceInicio = (indiceInicio + 1) % imagenes.Count;
            InicializarCarruselConImagenes();
        }

        private void btn_AnteriorImagen_Click(object sender, EventArgs e)
        {
            if (imagenes.Count == 0) return;

            // Retroceder el índice y actualizar el carrusel
            indiceInicio = (indiceInicio - 1 + imagenes.Count) % imagenes.Count;
            InicializarCarruselConImagenes();
        }




        // Evento Click para el PictureBox
        //private void PictureBox_Click(object sender, EventArgs e)
        //{
        //    PictureBox clickedPictureBox = sender as PictureBox;

        //    // Verificar si el PictureBox tiene un video asignado en el diccionario
        //    if (clickedPictureBox != null && videoPaths.ContainsKey(clickedPictureBox))
        //    {
        //        // Obtener la ruta del video desde el diccionario
        //        string videoPath = videoPaths[clickedPictureBox];

        //        // Asignar la ruta al reproductor de video
        //        instructivo.URL = videoPath;

        //        // Reproducir el video
        //        instructivo.Ctlcontrols.play();

        //        // Hacer visible el reproductor de video
        //        instructivo.Visible = true;

        //        // Ajustar el tamaño del reproductor (opcional)
        //        instructivo.Dock = DockStyle.Fill;
        //    }
        //}

      
    }
}
