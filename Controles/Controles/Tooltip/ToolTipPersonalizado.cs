﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using global::Ofelia_Sara.Formularios.General.Mensajes;


namespace Ofelia_Sara.Controles.Controles.Tooltip
{

    public static class ToolTipPersonalizado
    {
        public enum TipoToolTip { Eliminar,Cerrar, Minimizar, Maximizar,Imprimir}

        private static readonly Dictionary<Control, ToolTip> toolTips = new();

        // Configuración por tipo
        private static readonly Dictionary<TipoToolTip, (Image icono, Color colorFondo)> configuraciones = new()
    {
        { TipoToolTip.Eliminar,  (Properties.Resources.borrar, Color.FromArgb(200, 50, 50)) },   // Rojo tenue
        { TipoToolTip.Cerrar,  (Properties.Resources.IconoError, Color.FromArgb(200, 50, 50)) },   // Rojo tenue
        { TipoToolTip.Minimizar, (Properties.Resources.minimizar_tooltip, Color.FromArgb(50, 100, 200)) }, // Azul tenue
        { TipoToolTip.Maximizar, (Properties.Resources.maximizar_tooltip, Color.FromArgb(50, 150, 50)) }, // Verde tenue
        { TipoToolTip.Imprimir, (Properties.Resources.imprimir, Color.FromArgb(17, 139, 184)) }  // Verde agua a revisar
    };

        public static void Mostrar(Control control, string toolTipText, TipoToolTip tipo)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(control);

                if (!toolTips.TryGetValue(control, out var customToolTip))
                {
                    customToolTip = new ToolTip
                    {
                        OwnerDraw = true,
                        InitialDelay = 500,
                        ReshowDelay = 100,
                        AutoPopDelay = 5000
                    };
                    toolTips[control] = customToolTip;

                    customToolTip.Draw += (sender, e) => DrawCustomToolTip(e, toolTipText, tipo);
                    customToolTip.Popup += (sender, e) => ConfigureToolTipSize(e, toolTipText);
                }

                customToolTip.SetToolTip(control, toolTipText);

                control.Disposed += (sender, e) => DisposeToolTip(control);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al configurar el ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        private static void DrawCustomToolTip(DrawToolTipEventArgs e, string text, TipoToolTip tipo)
        {
            try
            {
                if (!configuraciones.TryGetValue(tipo, out var config))
                    return;

                e.Graphics.FillRectangle(new SolidBrush(config.colorFondo), e.Bounds);

                string[] lines = text.Split('\n');
                using Font font = new("Arial", 10);
                float lineHeight = font.GetHeight(e.Graphics) + 6;
                float textY = e.Bounds.Y + 4;
                int leftMargin = 30;
                int rightMargin = 5;

                if (config.icono != null)
                {
                    Bitmap resizedImage = new(config.icono, new Size(16, 16));
                    int iconX = e.Bounds.Left + 5;
                    int iconY = e.Bounds.Top + (e.Bounds.Height - resizedImage.Height) / 2;
                    e.Graphics.DrawImage(resizedImage, new Rectangle(iconX, iconY, resizedImage.Width, resizedImage.Height));
                }

                foreach (string line in lines)
                {
                    float textX = e.Bounds.X + leftMargin;
                    e.Graphics.DrawString(line, font, Brushes.White, new PointF(textX, textY));
                    textY += lineHeight;
                }
            }
            catch (Exception ex)
            {
                e.Graphics.DrawString($"Error: {ex.Message}", new Font("Arial", 8), Brushes.Red, e.Bounds.Location);
            }
        }

        private static void ConfigureToolTipSize(PopupEventArgs e, string text)
        {
            try
            {
                using Graphics g = Graphics.FromHwnd(nint.Zero);
                using Font font = new("Arial", 10);
                string[] lines = text.Split('\n');

                float maxWidth = 0;
                float totalHeight = 0;

                foreach (string line in lines)
                {
                    SizeF textSize = g.MeasureString(line, font);
                    maxWidth = Math.Max(maxWidth, textSize.Width);
                    totalHeight += textSize.Height;
                }

                int leftMargin = 30;
                int rightMargin = 5;
                e.ToolTipSize = new Size((int)(maxWidth + leftMargin + rightMargin), (int)(totalHeight + 8));
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al configurar el tamaño del ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        private static void DisposeToolTip(Control control)
        {
            if (toolTips.TryGetValue(control, out var toolTip))
            {
                toolTip.Dispose();
                toolTips.Remove(control);
            }
        }
    }

}


