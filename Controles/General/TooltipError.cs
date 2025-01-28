using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.General
{
    public partial class TooltipError : UserControl
    {
        public TooltipError()
        {
            InitializeComponent();
            //this.AutoSize = false; // Evitar que el TooltipError se ajuste automáticamente
            //this.BackColor = Color.IndianRed;
            //mensaje.AutoSize = true; // Permitir que el Label ajuste su tamaño
            //mensaje.MaximumSize = new Size(0, 0); // No establecer un ancho máximo, evitar multiline
            //mensaje.TextAlign = ContentAlignment.MiddleLeft; // Alinear el texto a la izquierda
            //this.Padding = new Padding(8); // Espaciado interno del Tooltip
        }

        /// <summary>
        /// Configura el mensaje de error en el Tooltip.
        /// </summary>
        /// <param name="mensajeError">Texto del mensaje.</param>
        //public void ConfigurarMensaje(string mensajeError)
        //{
        //    mensaje.Text = mensajeError;

        //    // Ajustar dinámicamente el tamaño y posición de los controles internos
        //    AjustarTamaño();
        //}

        /// <summary>
        /// Ajusta el tamaño y las posiciones del PictureBox y Label dinámicamente.
        /// </summary>
        //private void AjustarTamaño()
        //{
        //    // Establecer posición del PictureBox
        //    icono.Location = new Point(8, 8); // Espaciado inicial (izquierda y arriba)
        //    icono.Size = new Size(24, 24); // Tamaño del PictureBox (puedes personalizarlo)

        //    // Posicionar el Label (a la derecha del PictureBox)
        //    mensaje.Location = new Point(icono.Right + 8, icono.Top); // Espaciado a la derecha del PictureBox

        //    // Calcular el ancho total basado en el texto del mensaje
        //    using (Graphics g = CreateGraphics())
        //    {
        //        SizeF textSize = g.MeasureString(mensaje.Text, mensaje.Font);
        //        mensaje.Width = (int)textSize.Width; // Ajustar el ancho del Label al texto
        //    }

        //    // Ajustar el tamaño del TooltipError en función del contenido
        //    this.Width = mensaje.Right + 8; // Espaciado a la derecha del Label
        //    this.Height = Math.Max(mensaje.Bottom, icono.Bottom) + 8; // Altura basada en el control más alto
        //}

        /// <summary>
        /// Método estático para mostrar el TooltipError.
        /// </summary>
        /// <param name="controlReferencia">El control de referencia.</param>
        /// <param name="mensajeError">El mensaje de error a mostrar.</param>
        public static void Mostrar(Control controlReferencia, string mensajeError)
        {
            if (controlReferencia == null)
                throw new ArgumentNullException(nameof(controlReferencia));

            // Verifica si ya existe un TooltipError en el contenedor
            if (controlReferencia.Parent?.Controls.OfType<TooltipError>().Any() == true)
                return; // Si ya hay uno, no agregar otro

            TooltipError tooltip = new TooltipError();
          //  tooltip.ConfigurarMensaje(mensajeError); // Configurar el mensaje dinámicamente

            // Calcular la posición del Tooltip en relación con el control de referencia
            Point posicionControl = controlReferencia.PointToScreen(Point.Empty);
            int x = posicionControl.X + (controlReferencia.Width / 2) - (tooltip.Width / 2);
            int y = posicionControl.Y + controlReferencia.Height + 5; // Justo debajo del control

            tooltip.Location = controlReferencia.Parent?.PointToClient(new Point(x, y)) ?? new Point(x, y);

            // Agregar el Tooltip al mismo contenedor que el control de referencia
            if (controlReferencia.Parent != null)
            {
                controlReferencia.Parent.Controls.Add(tooltip);
                tooltip.BringToFront();
                tooltip.Visible = true;

                // Ocultar automáticamente después de unos segundos (opcional)
                Timer timer = new Timer { Interval = 3000 }; // 3 segundos
                timer.Tick += (s, e) =>
                {
                    tooltip.Visible = false;
                    controlReferencia.Parent.Controls.Remove(tooltip);
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }
    }
}