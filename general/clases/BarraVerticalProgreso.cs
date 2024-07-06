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
            // Para evitar parpadeos al dibujar
            this.SetStyle(ControlStyles.UserPaint, true);

            // Establecer los colores de primer plano y fondo
            this.ForeColor = Color.BlueViolet; //CAMBIAR A HEIGHTLIGHT
            this.BackColor = Color.Green;      //CAMBIAR A COLOR DE PANEL

            // TAMAÑO de la barra de progreso
            this.Size = new Size(30, 380); // Cambiado a vertical

            // Establecer el valor inicial
            this.Value = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            Graphics g = e.Graphics;

            // Dibujar el fondo
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(brush, rect);
            }

            // Dibujar el progreso
            if (this.Value > 0)
            {
                // Ajustar para barra de progreso vertical
                Rectangle clip = new Rectangle(rect.X, rect.Y + rect.Height - (int)Math.Round((float)this.Value / this.Maximum * rect.Height), rect.Width, (int)Math.Round((float)this.Value / this.Maximum * rect.Height));
                using (SolidBrush brush = new SolidBrush(this.ForeColor))
                {
                    g.FillRectangle(brush, clip);
                }
            }
        }
    }
}