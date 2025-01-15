using Ofelia_Sara.Clases.General.Apariencia;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General
{

    public partial class Presentacion : Form
    {
        private Bitmap bufferImagenFondo;
        private BufferedGraphics bufferedGraphics;


        private Timer animacionPresentacionTimer;
        private Rectangle destino; // Posición y tamaño final del formulario.
        private Point origen;     // Coordenadas del ícono (aproximadas).
        private int pasos = 20;   // Número de pasos para la animación.
        private int contador = 0; // Contador del progreso.

        private float scaleFactor = 0.1f;  // Tamaño inicial pequeño
        private float scaleSpeed = 0.02f;  // Velocidad de expansión
        private Timer animacionFondoTimer;      // Timer para controlar la animación
        private Image fondoAnimado;        // Imagen de fondo animada

        private Timer aparecerTimer;
        private Timer desaparecerTimer;
        private Timer blurTimer; // Timer adicional para monitorear opacidad

        //---------------------------------------------------------
        // Importar la API moderna
        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        private enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public int AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        private const int ACCENT_ENABLE_BLURBEHIND = 3;

        //---------------------------------------------------------

        private int inicioAncho;
        private int inicioAlto;
        public Presentacion()
        {
            InitializeComponent();
            //----presentacion
            // Definir la posición de inicio y el destino
            origen = ObtenerCoordenadasIcono(); // Obtiene las coordenadas del ícono 
            Size origenTamaño = new Size(15, 15);
            // Calcular la posición para centrar el formulario
            int xCentro = (Screen.PrimaryScreen.WorkingArea.Width - 600) / 2;
            int yCentro = (Screen.PrimaryScreen.WorkingArea.Height - 450) / 2;

            // Crear el destino
            destino = new Rectangle(xCentro, yCentro, 600, 450);

            // Configurar el formulario para que inicie en la posición del ícono
            this.StartPosition = FormStartPosition.Manual;
            this.Location = origen;


            // Inicializar el timer para la animación
            animacionPresentacionTimer = new Timer();
            animacionPresentacionTimer.Interval = 13; // Velocidad de la animación en milisegundos.
            animacionPresentacionTimer.Tick += AnimacionPresentacionTimer_Tick;

            // Iniciar la animación
            animacionPresentacionTimer.Start();
            //-----------------------

            this.Opacity = 0;
            this.DoubleBuffered = true; // Reducir parpadeos en la animación

            // Inicializar timers
            aparecerTimer = new Timer { Interval = 30 };
            desaparecerTimer = new Timer { Interval = 50 };
            blurTimer = new Timer { Interval = 10 }; // Monitorear opacidad cada 100ms

            // Asociar eventos
            aparecerTimer.Tick += AparecerTimer_Tick;
            desaparecerTimer.Tick += DesaparecerTimer_Tick;
            blurTimer.Tick += BlurTimer_Tick; // Monitorear opacidad

            blurTimer.Start(); // Iniciar el monitoreo de opacidad

            fondoAnimado = Properties.Resources.EscudoPolicia_PNG;


        }
        //---finalizacion de constructor-----
        //--------------------------------------------------------------------

        private void Presentacion_Load(object sender, EventArgs e)
        {
            aparecerTimer.Start(); // Iniciar el efecto de aparición al cargar el formulario
            AplicarBlurEfecto(); // Llamar al efecto blur
            InicializarBufferedGraphics();

        }
        private void InicializarBufferedGraphics()
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            bufferedGraphics = context.Allocate(this.CreateGraphics(), this.ClientRectangle);
        }
        //--------------------------------------------------------------------------------
        /// <summary>
        /// inicia secuencia de efecto blur
        /// </summary>

        private void BlurTimer_Tick(object sender, EventArgs e)
        {
            // Aplicar el efecto de desenfoque si la opacidad es menor o igual a PARAMETRO INDICADO
            if (this.Opacity <= 1)
            {
                AplicarBlurEfecto();
            }
        }

        /// <summary>
        /// inicia aparicion de formulario presentacion 
        /// </summary>

        private void AparecerTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; // Incrementar la opacidad gradualmente
                RedondearBordes.Aplicar(this, 36);//Redondea los bordes de panel superior e inferior
            }
            else
            {
                aparecerTimer.Stop(); // Detener el Timer cuando la opacidad llegue a 1

                // Iniciar la pausa de manera asíncrona
                PauseEntreEventos();
            }
        }
        /// <summary>
        /// genera pausa entre eventos de aparicion y desvanecimiento de formulario Presentacion
        /// </summary>
        private async void PauseEntreEventos()
        {
            await Task.Delay(1200);
            desaparecerTimer.Start(); // Ahora iniciar el desvanecimiento
        }


        /// <summary>
        /// inicia secuencia de desvanecimiento de formulario
        /// </summary>
        private void DesaparecerTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05; // Reducir la opacidad gradualmente
            }
            else
            {
                desaparecerTimer.Stop(); // Detener el Timer cuando la opacidad llegue a 0
                blurTimer.Stop(); // Detener el monitoreo de opacidad
                this.Close(); // Cerrar el formulario
            }
        }



        private void AplicarBlurEfecto()
        {
            AccentPolicy accent = new AccentPolicy
            {
                AccentState = ACCENT_ENABLE_BLURBEHIND,
                AccentFlags = 2,
                GradientColor = 0x00FFFFFF // Color transparente
            };

            int accentStructSize = Marshal.SizeOf(accent);
            IntPtr accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            WindowCompositionAttributeData data = new WindowCompositionAttributeData
            {
                Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(this.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        //----------------------------
        // ANIMACION IMAGEN DE FONDO
        private void IniciarAnimacionFondo()
        {
            if (this.Size == destino.Size)
            {
                animacionFondoTimer = new Timer
                {
                    Interval = 25 // Intervalo en milisegundos para el efecto suave
                };
                animacionFondoTimer.Tick += AnimacionFondo_Tick;
                animacionFondoTimer.Start();
            }
        }

        private void AnimacionFondo_Tick(object sender, EventArgs e)
        {
            // Incrementar el factor de escala
            scaleFactor += 0.01f;

            // Reiniciar el ciclo si alcanza el tamaño máximo
            if (scaleFactor >= 0.95f)
            {
                scaleFactor = 0.1f; // Reinicia al tamaño pequeño

                // Detener la animación cuando alcance el tamaño máximo
                animacionFondoTimer.Stop();
                animacionFondoTimer.Dispose();
            }
            // Redibujar el formulario
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (fondoAnimado != null && bufferedGraphics != null)
            {
                Graphics g = bufferedGraphics.Graphics;

                // Limpia el gráfico del buffer
                g.Clear(this.BackColor);

                // Dibuja la imagen de fondo
                int imagenWidth = (int)(fondoAnimado.Width * scaleFactor);
                int imagenHeight = (int)(fondoAnimado.Height * scaleFactor);
                int imageX = (this.ClientSize.Width - imagenWidth) / 2;
                int imageY = (this.ClientSize.Height - imagenHeight) / 2;

                g.DrawImage(fondoAnimado, new Rectangle(imageX, imageY, imagenWidth, imagenHeight));

                // Renderiza el buffer al contexto gráfico actual
                bufferedGraphics.Render(e.Graphics);
            }
        }


        /// <summary>
        /// animacion de presentacion
        /// </summary>

        private void AnimacionPresentacionTimer_Tick(object sender, EventArgs e)
        {
            contador++;

            // Interpolación lineal para la posición
            int nuevoX = origen.X + (destino.X - origen.X) * contador / pasos;
            int nuevoY = origen.Y + (destino.Y - origen.Y) * contador / pasos;

            // Interpolación para el tamaño (usando tamaños iniciales)
            int nuevoAncho = inicioAncho + (destino.Width - inicioAncho) * contador / pasos;
            int nuevoAlto = inicioAlto + (destino.Height - inicioAlto) * contador / pasos;

            // Actualizar posición y tamaño
            this.Location = new Point(nuevoX, nuevoY);
            this.Size = new Size(nuevoAncho, nuevoAlto);

            // Detener la animación al alcanzar el destino
            if (contador >= pasos)
            {
                animacionPresentacionTimer.Stop();
                animacionPresentacionTimer.Dispose();

                // Llamar al inicio de la animación del fondo
                IniciarAnimacionFondo();
            }
        }

        /// <summary>
        /// obtiene la ubicacion del cursor para iniciar desde ahi la animacion
        /// </summary>

        private Point ObtenerCoordenadasIcono()
        {
            // Obtener la posición actual del cursor
            Point posicionCursor = Cursor.Position;

            // Retornar la posición como punto de inicio
            return posicionCursor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (bufferedGraphics != null)
            {
                bufferedGraphics.Dispose(); // Libera el buffer anterior
            }

            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            bufferedGraphics = context.Allocate(this.CreateGraphics(), this.ClientRectangle);
        }

    }
}



