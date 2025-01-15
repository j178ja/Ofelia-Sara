using System.Drawing;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Controles.General
{

    public class PanelConBordePersonalizado : Panel
    {
        public Color BordeColor { get; set; } = Color.Transparent;
        public int BordeGrosor { get; set; } = 1;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BordeColor != Color.Transparent)
            {
                using (Pen pen = new Pen(BordeColor, BordeGrosor))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
    }
}