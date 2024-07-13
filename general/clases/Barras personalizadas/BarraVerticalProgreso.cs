using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofelia_Sara.general.clases
{
    // Hereda de ProgressBar para extender su funcionalidad
    public class ProgressVerticalBar : ProgressBar
    {
        public ProgressVerticalBar()
        {
            // Establecer características predeterminadas
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.LightBlue; // Color de fondo LightBlue
            this.ForeColor = Color.DodgerBlue; // Color de frente DodgerBlue
            this.Value = 0; // Valor inicial 0
            this.Width = 30; // Ancho predeterminado
            this.Width = 4; // Ancho específico 3 píxeles
           
            // Anclar el control al borde superior e inferior
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawVerticalBar(g, rect);

            rect.Inflate(0, 0); // Ajustar la reducción del rectángulo interno
            if (this.Value > 0)
            {
                Rectangle chunk = new Rectangle(rect.X, rect.Y, rect.Width, (int)(rect.Height * ((double)this.Value / this.Maximum)));
                ProgressBarRenderer.DrawVerticalChunks(g, chunk);
            }
        }
    }
}