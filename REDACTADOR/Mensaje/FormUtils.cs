using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public static class FormUtils
{
    public static void BordesRedondeados(Control control, int radioEsquinas, int grosorBorde, Color colorBorde)
    {
        // Evento Paint para aplicar solo bordes redondeados y un borde de color
        control.Paint += (sender, e) =>
        {
            // Crear la ruta para los bordes redondeados
            using (GraphicsPath bordePath = new GraphicsPath())
            {
                bordePath.StartFigure();
                bordePath.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
                bordePath.AddArc(control.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
                bordePath.AddArc(control.Width - radioEsquinas, control.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
                bordePath.AddArc(0, control.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
                bordePath.CloseFigure();

                // Aplicar la región al control para que tenga bordes redondeados
                control.Region = new Region(bordePath);

                // Dibujar el borde
                using (Pen bordePen = new Pen(colorBorde, grosorBorde))
                {
                    e.Graphics.DrawPath(bordePen, bordePath);
                }
            }
        };

        // Refrescar el control para aplicar el diseño inmediatamente
        control.Refresh();
    }

}