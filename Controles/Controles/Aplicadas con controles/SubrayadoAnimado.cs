/*    EJEMPLO DE USO 
 
 private int lineWidth = 0;
private bool isAnimating = true;

private void Label_TextoMesAño_Paint(object sender, PaintEventArgs e)
{
    SubrayadoAnimado.Aplicar(label_TextoMesAño, e.Graphics, ref lineWidth, isAnimating, SystemColors.Highlight);

    // Asegúrate de manejar la animación con un Timer o lógica personalizada
}
*/




using System;
using System.Drawing;
using System.Windows.Forms;

public static class SubrayadoAnimado
{
    public static void Aplicar(Control control, Graphics g, ref int lineWidth, bool isAnimating, Color color, int grosor = 3)
    {
        if (!isAnimating) return;

        using (Pen pen = new Pen(color, grosor))
        {
            // Calcular ancho del texto si el control es un Label
            int textoAncho = control is Label
                ? TextRenderer.MeasureText(control.Text, control.Font).Width
                : control.Width;

            // Ajustar la animación al ancho del texto
            int subrayadoAncho = Math.Min(lineWidth, textoAncho);

            // Posición inicial y final del subrayado
            int startX = (control.Width - subrayadoAncho) / 2;
            int endX = startX + subrayadoAncho;

            // Posición vertical del subrayado (debajo del control)
            int y = control.Height - 3;

            // Dibujar la línea
            g.DrawLine(pen, startX, y, endX, y);
        }
    }
}
