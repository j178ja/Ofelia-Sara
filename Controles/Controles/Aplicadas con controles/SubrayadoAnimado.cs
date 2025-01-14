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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public static class SubrayadoAnimado
{
    private static readonly Dictionary<Control, (Timer Timer, int LineWidth, bool IsAnimating)> Estados = new();

    public static void Aplicar(Control control, Graphics g, Color color, int grosor = 3)
    {
        if (!Estados.TryGetValue(control, out var estado) || !estado.IsAnimating) return;

        using (Pen pen = new Pen(color, grosor))
        {
            int textoAncho = TextRenderer.MeasureText(control.Text, control.Font).Width;
            int subrayadoAncho = Math.Min(estado.LineWidth, textoAncho);

            int startX = (control.Width - subrayadoAncho) / 2;
            int endX = startX + subrayadoAncho;
            int y = control.Height - 3;

            g.DrawLine(pen, startX, y, endX, y);
        }
    }

    public static void Iniciar(Control control, int incremento = 5)
    {
        if (!Estados.ContainsKey(control))
        {
            Estados[control] = (null, 0, false);
        }

        // Detén cualquier animación previa
        Detener(control);

        var estado = Estados[control];
        estado.LineWidth = 0;
        estado.IsAnimating = true;

        Timer timer = new Timer { Interval = 15 };
        timer.Tick += (s, e) =>
        {
            if (estado.LineWidth < control.Width)
            {
                estado.LineWidth += incremento;
                Estados[control] = estado; // Actualiza el estado
                control.Invalidate(); // Redibuja el control
            }
            else
            {
                timer.Stop();
                estado.IsAnimating = false;
                Estados[control] = estado; // Actualiza el estado
            }
        };

        estado.Timer = timer;
        Estados[control] = estado; // Actualiza el estado
        timer.Start();
    }

    public static void Detener(Control control)
    {
        if (Estados.TryGetValue(control, out var estado))
        {
            estado.Timer?.Stop();
            estado.Timer?.Dispose();
            estado.LineWidth = 0;
            estado.IsAnimating = false;
            Estados[control] = estado; // Actualiza el estado
        }
    }
}
