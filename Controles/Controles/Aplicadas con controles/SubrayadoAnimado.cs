/*    EJEMPLO DE USO 
 
 private int lineWidth = 0;
private bool isAnimating = true;

private void Label_TextoMesAño_Paint(object sender, PaintEventArgs e)
{
    SubrayadoAnimado.Aplicar(label_TextoMesAño, e.Graphics, ref lineWidth, isAnimating, SystemColors.Highlight);

  
}
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public static class SubrayadoAnimado
{
    /// <summary>
    /// CLASE PARA SUBRAYAR ANIMADAMENTE LABELS
    /// </summary>
    private static readonly Dictionary<object, (Timer Timer, int LineWidth, bool IsAnimating)> Estados = new();

    public static void Aplicar(object target, Graphics g, Color color, int grosor = 3)
    {
        if (!Estados.TryGetValue(target, out var estado) || !estado.IsAnimating) return;

        using (Pen pen = new Pen(color, grosor))
        {
            int width;
            int startX, endX, y;

            if (target is Control control)
            {
                width = control.Width;
                y = control.Height - grosor; // Línea cerca del borde inferior del control
            }
            else if (target is ListViewItem item)
            {
                width = item.Bounds.Width;
                y = item.Bounds.Bottom - grosor; // Línea cerca del borde inferior del ítem
            }
            else
            {
                return; // No es un tipo soportado
            }

            int subrayadoAncho = Math.Min(estado.LineWidth, width);
            startX = (width - subrayadoAncho) / 2; // Comenzar desde el centro
            endX = startX + subrayadoAncho;

            g.DrawLine(pen, startX, y, endX, y);
        }
    }

    public static void Iniciar(object target, int incrementoBase = 5)
    {
        if (!Estados.ContainsKey(target))
        {
            Estados[target] = (null, 0, false);
        }

        Detener(target);

        var estado = Estados[target];
        estado.LineWidth = 0;
        estado.IsAnimating = true;

        int maxWidth = target switch
        {
            Control control => control.Width-20,
            ListViewItem item => item.Bounds.Width,
            _ => 0
        };

        if (maxWidth == 0) return;

        int incremento = Math.Max(1, incrementoBase * maxWidth / 200); // Ajustar velocidad según el tamaño

        Timer timer = new Timer { Interval = 15 };
        timer.Tick += (s, e) =>
        {
            if (estado.LineWidth < maxWidth)
            {
                estado.LineWidth += incremento;
                Estados[target] = estado;
                if (target is Control control)
                {
                    control.Invalidate();
                }
                else if (target is ListViewItem item)
                {
                    item.ListView?.Invalidate(item.Bounds);
                }
            }
            else
            {
                timer.Stop();
                estado.IsAnimating = false;
                Estados[target] = estado;
            }
        };

        estado.Timer = timer;
        Estados[target] = estado;
        timer.Start();
    }

    public static void Detener(object target)
    {
        if (Estados.TryGetValue(target, out var estado))
        {
            estado.Timer?.Stop();
            estado.Timer?.Dispose();
            estado.LineWidth = 0;
            estado.IsAnimating = false;
            Estados[target] = estado;
        }
    }
}

