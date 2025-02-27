/* se lo usa asi 
  RedondearBordes.Aplicar(this, 16);//Redondea los bordes de panel superior e inferior
 RedondearBordes.Aplicar(pictureBox_Objeto, 6, true, false, false, true); para bordes personalizados en cada angulo
*/


using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Apariencia
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public static class RedondearBordes
    {
        /// <summary>
        /// Aplica bordes redondeados a un control o formulario, permitiendo personalizar qué esquinas redondear.
        /// </summary>
        /// <param name="control">El control al que se le aplicarán los bordes redondeados.</param>
        /// <param name="radio">El radio del redondeo.</param>
        /// <param name="redondearSupIzq">Si la esquina superior izquierda debe redondearse.</param>
        /// <param name="redondearSupDer">Si la esquina superior derecha debe redondearse.</param>
        /// <param name="redondearInfDer">Si la esquina inferior derecha debe redondearse.</param>
        /// <param name="redondearInfIzq">Si la esquina inferior izquierda debe redondearse.</param>
        public static void Aplicar(Control control, int radio,
                                   bool redondearSupIzq = true, bool redondearSupDer = true,
                                   bool redondearInfDer = true, bool redondearInfIzq = true)
        {
            if (control == null || radio <= 0) return;

            using GraphicsPath path = ObtenerRutaBordes(control.ClientRectangle, radio,
                                                         redondearSupIzq, redondearSupDer,
                                                         redondearInfDer, redondearInfIzq);
            control.Region?.Dispose(); // Libera la región anterior si existe
            control.Region = new Region(path);
        }

        /// <summary>
        /// Genera un `GraphicsPath` con las esquinas redondeadas según los parámetros dados.
        /// </summary>
        private static GraphicsPath ObtenerRutaBordes(Rectangle bounds, int radio,
                                                      bool redondearSupIzq, bool redondearSupDer,
                                                      bool redondearInfDer, bool redondearInfIzq)
        {
            GraphicsPath path = new();
            int diametro = radio * 2;

            // Esquina superior izquierda
            if (redondearSupIzq)
                path.AddArc(bounds.X, bounds.Y, diametro, diametro, 180, 90);
            else
                path.AddLine(bounds.X, bounds.Y, bounds.X + radio, bounds.Y);

            // Esquina superior derecha
            if (redondearSupDer)
                path.AddArc(bounds.Right - diametro, bounds.Y, diametro, diametro, 270, 90);
            else
                path.AddLine(bounds.Right - radio, bounds.Y, bounds.Right, bounds.Y);

            // Esquina inferior derecha
            if (redondearInfDer)
                path.AddArc(bounds.Right - diametro, bounds.Bottom - diametro, diametro, diametro, 0, 90);
            else
                path.AddLine(bounds.Right, bounds.Bottom - radio, bounds.Right, bounds.Bottom);

            // Esquina inferior izquierda
            if (redondearInfIzq)
                path.AddArc(bounds.X, bounds.Bottom - diametro, diametro, diametro, 90, 90);
            else
                path.AddLine(bounds.X + radio, bounds.Bottom, bounds.X, bounds.Bottom);

            path.CloseFigure();
            return path;
        }
    }

}
