using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.General
{
    public partial class TooltipError : UserControl
    {
        private static TooltipError instanciaActual; // Singleton para evitar duplicados
        private static Timer ocultarTimer;

        public TooltipError()
        {
            InitializeComponent();
            this.Visible = false; // Inicialmente oculto
        }

        /// <summary>
        /// Muestra el TooltipError sobre el control de referencia.
        /// </summary>
        public static void Mostrar(Control controlReferencia, string mensajeError)
        {
            if (instanciaActual == null)
            {
                instanciaActual = new TooltipError();
            }

            // Agregar al contenedor si aún no está
            if (!controlReferencia.Parent.Controls.Contains(instanciaActual))
            {
                controlReferencia.Parent.Controls.Add(instanciaActual);
            }

            // Configurar el mensaje y la visibilidad
            instanciaActual.mensaje.Text = mensajeError;
            instanciaActual.Visible = true;
            instanciaActual.BringToFront(); // Asegurar que esté encima de otros controles

            // Calcular posición relativa dentro del contenedor del controlReferencia
            Point posicion = controlReferencia.Parent.PointToClient(controlReferencia.PointToScreen(Point.Empty));
            instanciaActual.Location = new Point(
                posicion.X + (controlReferencia.Width / 2) - (instanciaActual.Width / 2),
                posicion.Y + controlReferencia.Height + 5
            );

            // Iniciar un temporizador para ocultar después de 3 segundos
            if (ocultarTimer == null)
            {
                ocultarTimer = new Timer { Interval = 3000 };
                ocultarTimer.Tick += (s, e) =>
                {
                    instanciaActual.Visible = false;
                    ocultarTimer.Stop();
                };
            }
            ocultarTimer.Start();
        }

        /// <summary>
        /// Oculta el TooltipError manualmente.
        /// </summary>
        public static void Ocultar()
        {
            if (instanciaActual != null)
            {
                instanciaActual.Visible = false;
                ocultarTimer?.Stop();
            }
        }
    }
}