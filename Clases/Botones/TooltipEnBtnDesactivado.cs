using System.Windows.Forms;

namespace Clases.Botones
{
    public partial class TooltipEnBtnDesactivado
    {
        public static void ConfigurarToolTipYTimer(Form form, Button button, string toolTipText)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(button, toolTipText);

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender, e) =>
            {
                if (!button.Enabled && button.ClientRectangle.Contains(button.PointToClient(Control.MousePosition)))
                {
                    toolTip.Show(toolTipText, button, button.Width / 2, button.Height / 2);
                }
                else
                {
                    toolTip.Hide(button);
                }
            };

            // Evento para detener y eliminar el Timer cuando el formulario se cierre
            form.FormClosing += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }
    }
}