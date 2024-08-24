using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.general.clases.Apariencia_General.Generales
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public static class PanelExtensions
    {
        // Método para aplicar bordes redondeados a un panel específico
        public static void ApplyRoundedCorners(this Panel panel, Panel targetPanel, int borderRadius = 10, int borderSize = 2, Color? borderColor = null)
        {
            if (panel != targetPanel)
                return;

            panel.Paint += (sender, e) =>
            {
                // Establecer el color del borde si no se proporciona
                Color effectiveBorderColor = borderColor ?? Color.Black;

                // Crear un GraphicsPath para el borde redondeado
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
                    path.AddArc(new Rectangle(panel.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
                    path.AddArc(new Rectangle(panel.Width - borderRadius, panel.Height - borderRadius, borderRadius, borderRadius), 0, 90);
                    path.AddArc(new Rectangle(0, panel.Height - borderRadius, borderRadius, borderRadius), 90, 90);
                    path.CloseAllFigures();

                    // Rellenar el fondo del panel
                    using (Brush brush = new SolidBrush(panel.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    // Dibujar el borde
                    using (Pen pen = new Pen(effectiveBorderColor, borderSize))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // Redibujar el panel cuando cambie de tamaño
            panel.Resize += (sender, e) => { panel.Invalidate(); };
        }
    }
}
