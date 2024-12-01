using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    public class PanelConBordeNeon : Panel
    {
        public int BorderRadius { get; set; } = 10; // Radio del borde
        public bool EstaContraido { get; set; } = false; // Estado del panel
        public bool CamposCompletos { get; set; } = false; // Indica si los campos están completos
        public Color NeonColorCompleto { get; set; } = Color.FromArgb(0, 255, 0); // Verde para campos completos
        public Color NeonColorIncompleto { get; set; } = Color.FromArgb(255, 0, 0); // Rojo para campos incompletos
        public Color SombraColor { get; set; } = Color.FromArgb(200, 0, 198, 255); // Sombra más oscura y transparente
      
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!EstaContraido) return; // Solo se dibuja el borde si el panel está contraído

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Tamaño y radio para el borde
            int grosorBorde = 2; // Grosor principal
            int sombraExtra = 3; // Grosor para la sombra oscura
            int radio = BorderRadius;

            // Determinar color principal según el estado de los campos
            Color colorNeon = CamposCompletos ? NeonColorCompleto : NeonColorIncompleto;

            // Dibujar la sombra (borde más oscuro)
            using (GraphicsPath pathSombra = GenerarPathRedondeado(ClientRectangle, radio, sombraExtra))
            using (Pen penSombra = new Pen(SombraColor, sombraExtra))
            {
                graphics.DrawPath(penSombra, pathSombra);
            }

            // Dibujar el borde principal (efecto neón)
            using (GraphicsPath pathBorde = GenerarPathRedondeado(ClientRectangle, radio, grosorBorde))
            using (Pen penBorde = new Pen(colorNeon, grosorBorde))
            {
                graphics.DrawPath(penBorde, pathBorde);
            }
        }

        // Método auxiliar para generar un path redondeado
        private GraphicsPath GenerarPathRedondeado(Rectangle rect, int radio, int ajuste)
        {
            GraphicsPath path = new GraphicsPath();
            int ajusteMitad = ajuste / 2;
            rect = new Rectangle(rect.X + ajusteMitad, rect.Y + ajusteMitad, rect.Width - ajuste, rect.Height - ajuste);

            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
            path.CloseFigure();

            return path;
        }

        // Método para cambiar el estado del panel y redibujar
        public void CambiarEstado(bool estaContraido, bool camposCompletos)
        {
            EstaContraido = estaContraido;
            CamposCompletos = camposCompletos;
            Invalidate(); // Redibujar el panel con el nuevo estado
        }
    }
}
