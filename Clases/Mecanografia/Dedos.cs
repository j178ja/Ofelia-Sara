/*ESTA CLASE LE DA FORMATO REDONDEADO A LOS PANELES DE LOS DEDOS*/

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.Mecanografia
{
    public static class RedondearPanel
    {
        // Método para aplicar bordes redondeados a los paneles con radios diferentes para cada borde
        public static void AplicarBordesRedondeados(Panel panel, int radioSuperior, int radioInferior)
        {
            // Asignar el evento Paint del panel
            panel.Paint += (sender, e) =>
            {
                // Dibujar el borde redondeado
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Crear la forma redondeada del borde
                using (GraphicsPath path = new GraphicsPath())
                {
                    // Bordes superiores (con radioSuperior)
                    path.AddArc(new Rectangle(0, 0, radioSuperior, radioSuperior), 180, 90); // Esquina superior izquierda
                    path.AddArc(new Rectangle(panel.Width - radioSuperior, 0, radioSuperior, radioSuperior), 270, 90); // Esquina superior derecha

                    // Bordes inferiores (con radioInferior)
                    path.AddArc(new Rectangle(panel.Width - radioInferior, panel.Height - radioInferior, radioInferior, radioInferior), 0, 90); // Esquina inferior derecha
                    path.AddArc(new Rectangle(0, panel.Height - radioInferior, radioInferior, radioInferior), 90, 90); // Esquina inferior izquierda

                    path.CloseFigure();

                    // Asignar la forma recortada al panel
                    panel.Region = new Region(path);
                }
            };

            // Forzar repintado del panel
            panel.Invalidate();
        }
    }
}
