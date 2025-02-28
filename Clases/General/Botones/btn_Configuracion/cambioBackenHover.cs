using System.Drawing;
using System.Windows.Forms;

//public class CustomMenuStripRenderer : ToolStripProfessionalRenderer
//{
//    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
//    {
//        // Respeta el color de fondo actual del ítem
//        if (e.Item.Selected)
//        {
//            e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Item.ContentRectangle);
//        }
//        else
//        {
//            base.OnRenderMenuItemBackground(e); // Usa el color de fondo predeterminado si no está seleccionado
//        }
//    }

//    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
//    {

//        using SolidBrush brush = new SolidBrush(Color.FromArgb(230, 240, 255)); // Color claro para el fondo general
//        e.Graphics.FillRectangle(brush, e.AffectedBounds);
//    }
//}
public class CustomMenuStripRenderer : ToolStripProfessionalRenderer
{
    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        if (e.Item.Selected)
        {
            e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Item.ContentRectangle);
        }
        else
        {
            base.OnRenderMenuItemBackground(e);
        }
    }

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        using SolidBrush brush = new SolidBrush(Color.FromArgb(230, 240, 255)); // Color claro para el fondo general
        e.Graphics.FillRectangle(brush, e.AffectedBounds);
    }

    protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
    {
        // SOLO aplicar el fondo si el ítem está en hover (seleccionado)
        if (e.Item.Selected)
        {
            using SolidBrush imageBackground = new SolidBrush(Color.FromArgb(4, 234, 0));
            Rectangle imageRect = new Rectangle(e.ImageRectangle.X - 2, e.ImageRectangle.Y - 2,
                                                e.ImageRectangle.Width + 4, e.ImageRectangle.Height + 4);
            e.Graphics.FillRectangle(imageBackground, imageRect);
        }

        // Dibuja la imagen encima del fondo (siempre visible)
        if (e.Image != null)
        {
            e.Graphics.DrawImage(e.Image, e.ImageRectangle);
        }
    }
}

