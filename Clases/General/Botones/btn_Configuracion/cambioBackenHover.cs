using System.Drawing;
using System.Windows.Forms;

public class CustomMenuStripRenderer : ToolStripProfessionalRenderer
{
    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        // Respeta el color de fondo actual del ítem
        if (e.Item.Selected)
        {
            e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Item.ContentRectangle);
        }
        else
        {
            base.OnRenderMenuItemBackground(e); // Usa el color de fondo predeterminado si no está seleccionado
        }
    }

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {

        using SolidBrush brush = new SolidBrush(Color.FromArgb(230, 240, 255)); // Color claro para el fondo general
        e.Graphics.FillRectangle(brush, e.AffectedBounds);
    }
}
