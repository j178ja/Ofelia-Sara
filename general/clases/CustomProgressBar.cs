using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            // Permitir estilos de propietario
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(Brushes.DarkCyan, 2, 2, rec.Width, rec.Height);
            //Por ahora elcolor se mantiene a posteriori habra que emplearmismo tono para todos los progressBar
        }
    }
}