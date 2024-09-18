using System.Drawing;
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
            this.BackColor = Color.FromArgb(178, 213, 230); // Color de fondo igual a panel1
            this.ForeColor = Color.DodgerBlue;//FromArgb(30, 144, 255); // Color de dodgeblue
            this.Value = 0; // Valor inicial 0
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