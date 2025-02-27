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
        public static void Aplicar(Control control, int radio,
                                   bool redondearSupIzq = true, bool redondearSupDer = true,
                                   bool redondearInfDer = true, bool redondearInfIzq = true)
        {
            if (control == null || radio <= 0) return;

            // Asegurémonos de que no se redondeen bordes no deseados.
            using GraphicsPath path = ObtenerRutaBordes(control.ClientRectangle, radio,
                                                         redondearSupIzq, redondearSupDer,
                                                         redondearInfDer, redondearInfIzq);

            control.Region?.Dispose(); // Libera la región anterior si existe
            control.Region = new Region(path);
        }

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
                path.AddLine(bounds.X, bounds.Y, bounds.X, bounds.Y);

            // Esquina superior derecha
            if (redondearSupDer)
                path.AddArc(bounds.Right - diametro, bounds.Y, diametro, diametro, 270, 90);
            else
                path.AddLine(bounds.Right, bounds.Y, bounds.Right, bounds.Y);

            // Esquina inferior derecha
            if (redondearInfDer)
                path.AddArc(bounds.Right - diametro, bounds.Bottom - diametro, diametro, diametro, 0, 90);
            else
                path.AddLine(bounds.Right, bounds.Bottom, bounds.Right, bounds.Bottom);

            // Esquina inferior izquierda
            if (redondearInfIzq)
                path.AddArc(bounds.X, bounds.Bottom - diametro, diametro, diametro, 90, 90);
            else
                path.AddLine(bounds.X, bounds.Bottom, bounds.X, bounds.Bottom);

            path.CloseFigure();
            return path;
        }
    }


}
