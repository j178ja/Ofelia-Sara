using Clases;
using REDACTADOR.Mensaje;
using REDACTADOR.Clases;
using System.Drawing.Drawing2D;
using System;
using System.Drawing;

using System.Windows.Forms;



namespace REDACTADOR
{
    public partial class VideoInstructivo : Form
    {
        // Declarar las instancias de PictureBoxCircular
       
        public VideoInstructivo()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.RedondearBordes(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            this.Resize += new EventHandler(VideoInstructivo_Resize); // Suscripción al evento Resize

            this.Carrusel.Paint += Carrusel_Paint;
        }

        private void VideoInstructivo_Load(object sender, EventArgs e)
        {
            InicializarCarruselConImagenes();
   

            // Habilitar doble búfer en el TableLayoutPanel (Carrusel)
            Carrusel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(Carrusel, true, null);

            CargarImagenFondo();// para cargar imagen e iniciar animacion

            // Ruta del archivo MP4
            string videoPath = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\REDACTADOR\Resources\videos\instructivoDemo.mp4";

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
                MensajeGeneral.Mostrar("El archivo de video no se encontró en la ruta especificada.", MensajeGeneral.TipoMensaje.Error);
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

        private void InicializarCarruselConImagenes()
        {
            // Lista de imágenes desde recursos
            Image[] imagenes = {
        Properties.Resources.casa_hobbit,
        Properties.Resources.chochis,
        Properties.Resources.Fondo_De_Pantalla_De_Dibujos_Animados,
        Properties.Resources.gandalf,
        Properties.Resources.TENEBRIOS
    };

            // Limpiar controles existentes en el TableLayoutPanel
            Carrusel.Controls.Clear();

            // Establecer el número de filas y columnas
            Carrusel.RowCount = 1; // Solo una fila
            Carrusel.ColumnCount = imagenes.Length; // Número de columnas basado en las imágenes

            // Establecer las propiedades de las columnas para que se distribuyan igualmente
            for (int i = 0; i < Carrusel.ColumnCount; i++)
            {
                Carrusel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / Carrusel.ColumnCount));
            }

            // Establecer la altura de la fila para que sea fija de 76
            Carrusel.RowStyles.Clear(); // Limpiar estilos previos de fila
            Carrusel.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F)); // Establecer altura fija de la fila

            // Agregar imágenes a las celdas con bordes redondeados
            for (int i = 0; i < imagenes.Length; i++)
            {
                // Crear el PictureBox
                PictureBox pictureBox = new PictureBox
                {
                    Image = imagenes[i],
                    SizeMode = PictureBoxSizeMode.StretchImage, // Estiramos la imagen para que cubra el área
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.None // No anclado a los bordes
                };

                // Aplicar bordes redondeados
                pictureBox.Paint += (sender, e) =>
                {
                    PictureBox pb = sender as PictureBox;
                    if (pb != null)
                    {
                        int radius = 6; // Tamaño del radio de las esquinas
                        GraphicsPath path = CreateRoundedRectanglePath(pb.ClientRectangle, radius);
                        pb.Region = new Region(path);
                    }
                };

                // Ajustar la altura y el ancho de la imagen según la columna
                if (i == 2) // Columna 3 (índice 2)
                {
                    // La imagen en la columna 3 tiene la altura completa de 76 y debe estirarse para cubrir todo el ancho
                    pictureBox.Height = 76;
                    pictureBox.Width = Carrusel.GetColumnWidths()[i]; // Establecer el ancho para abarcar toda la celda

                    // Centrar verticalmente
                    pictureBox.Top = (76 - pictureBox.Height) / 2;
                    // Centrar horizontalmente (en este caso, con DockStyle.None y configurando Left)
                    pictureBox.Left = (Carrusel.ClientSize.Width / Carrusel.ColumnCount - pictureBox.Width) / 2;
                }
                else if (i == 1 || i == 3) // Columnas 2 y 4 (índices 1 y 3)
                {
                    // Las imágenes en las columnas 2 y 4 tienen una altura del 75% de 76 (es decir, 57)
                    pictureBox.Height = (int)(76 * 0.75);
                    pictureBox.Width = Carrusel.GetColumnWidths()[i]; // Ajustar el ancho

                    // Centrar verticalmente
                    pictureBox.Top = (76 - pictureBox.Height) / 2;
                    // Centrar horizontalmente
                    pictureBox.Left = (Carrusel.ClientSize.Width / Carrusel.ColumnCount - pictureBox.Width) / 2;
                }
                else if (i == 0 || i == 4) // Columnas 1 y 5 (índices 0 y 4)
                {
                    // Las imágenes en las columnas 1 y 5 tienen una altura del 50% de 76 (es decir, 38)
                    pictureBox.Height = (int)(76 * 0.5);
                    pictureBox.Width = Carrusel.GetColumnWidths()[i]; // Ajustar el ancho

                    // Centrar verticalmente
                    pictureBox.Top = (76 - pictureBox.Height) / 2;
                    // Centrar horizontalmente
                    pictureBox.Left = (Carrusel.ClientSize.Width / Carrusel.ColumnCount - pictureBox.Width) / 2;
                }

                // Agregar el PictureBox al TableLayoutPanel en la columna `i` y fila `0`
                Carrusel.Controls.Add(pictureBox, i, 0);
            }
        }


        /// <summary>
        /// Crea un GraphicsPath para un rectángulo con esquinas redondeadas.
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

        //--------------------
        //para fondo animado de carrusel

        private float scaleFactor = 0.1f;  // Inicial tamaño pequeño
        private float scaleSpeed = 0.02f;  // Velocidad de expansión
        private Timer animacionTimer;      // Timer para controlar la animación
        private Image fondoAnimado;

        // Iniciar la animación

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

        // Evento Tick del Timer para controlar la animación
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

        // Evento Paint para dibujar la imagen de fondo animada en el TableLayoutPanel
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



        // Evento Paint para dibujar la imagen de fondo animada
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (fondoAnimado != null)
            {
                Graphics g = e.Graphics;

                // Calcular el centro del área de dibujo
                int centerX = this.ClientSize.Width / 2;
                int centerY = this.ClientSize.Height / 2;

                // Calcular las dimensiones de la imagen escalada
                int scaledWidth = (int)(fondoAnimado.Width * scaleFactor);
                int scaledHeight = (int)(fondoAnimado.Height * scaleFactor);

                // Calcular la posición para centrar la imagen
                int posX = centerX - (scaledWidth / 2);
                int posY = centerY - (scaledHeight / 2);

                // Dibujar la imagen escalada en la posición calculada
                g.DrawImage(fondoAnimado, new Rectangle(posX, posY, scaledWidth, scaledHeight));
            }
        }

        //--------------------
       

        // Eventos para manejar el clic en los PictureBox
        private void Btn_Anterior_MouseClick(object sender, MouseEventArgs e)
        {
            // Acción al hacer clic en el botón "Anterior"
            MessageBox.Show("Anterior clickeado");
        }

        private void Btn_Siguiente_MouseClick(object sender, MouseEventArgs e)
        {
            // Acción al hacer clic en el botón "Siguiente"
            MessageBox.Show("Siguiente clickeado");
        }
    }
}

