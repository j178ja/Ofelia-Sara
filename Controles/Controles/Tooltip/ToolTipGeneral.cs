// se aplica asi-->ToolTipGeneral.Mostrar(this, btn_Imprimir, "Guardar e IMPRIMIR."); 


using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.Tooltip
{
    /// <summary>
    /// tooltip multiproposito personalizado
    /// </summary>
    public static class ToolTipGeneral
    {
        #region VARIABLES
        private static readonly Dictionary<Control, ToolTip> toolTips = [];
        private static readonly Bitmap DefaultImage = Properties.Resources.EscudoPolicia_PNG;
        private static readonly char[] separator = ['\n'];
        #endregion

        /// <summary>
        /// PARA MOSTRAR EL TOOLTIP PERSONALIZADO
        /// </summary>
        /// <param name="control"></param>
        /// <param name="toolTipText"></param>
        public static void Mostrar(Control control, string toolTipText)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(control);

                // Crear un ToolTip específico para el control si no existe
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

                    // Configurar eventos de dibujo y tamaño dinámico
                    customToolTip.Draw += (sender, e) => DrawCustomToolTip(e, toolTipText, control);
                    customToolTip.Popup += (sender, e) => ConfigureToolTipSize(e, toolTipText);
                }

                // Asignar el texto al ToolTip del control
                customToolTip.SetToolTip(control, toolTipText);

                // Configurar eventos de control
                control.Disposed += (sender, e) =>
                {
                    DisposeToolTip(control);
                };
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al configurar el ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        private static void DrawCustomToolTip(DrawToolTipEventArgs e, string text, Control control)
        {
            try
            {
                Color backgroundColor = control.Enabled ? Color.FromArgb(0, 154, 174) : Color.Gray;
                e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

                string[] lines = text.Split(separator, StringSplitOptions.None);
                using (Font font = new ("Arial", 10))
                {
                    float lineHeight = font.GetHeight(e.Graphics) + 6;
                    float textY = e.Bounds.Y + 4;
                    int leftMargin = 10;
                    int rightMargin = 30;

                    foreach (string line in lines)
                    {
                        float textX = e.Bounds.X + leftMargin;
                        e.Graphics.DrawString(line, font, Brushes.White, new PointF(textX, textY));
                        textY += lineHeight;
                    }

                    // Dibujar ícono si está disponible
                    if (DefaultImage != null)
                    {
                        Bitmap resizedImage = new Bitmap(DefaultImage, new Size(16, 16));
                        int iconX = e.Bounds.Right - resizedImage.Width - 5;
                        int iconY = e.Bounds.Top + (e.Bounds.Height - resizedImage.Height) / 2;
                        e.Graphics.DrawImage(resizedImage, new Rectangle(iconX, iconY, resizedImage.Width, resizedImage.Height));
                    }
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
                string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.None);

                float maxWidth = 0;
                float totalHeight = 0;

                foreach (string line in lines)
                {
                    SizeF textSize = g.MeasureString(line, font);
                    maxWidth = Math.Max(maxWidth, textSize.Width);
                    totalHeight += textSize.Height;
                }

                int leftMargin = 10;
                int rightMargin = 25;
                e.ToolTipSize = new Size((int)(maxWidth + leftMargin + rightMargin), (int)(totalHeight + 8));
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al configurar el tamaño del ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        public static void DisposeToolTip(Control control)
        {
            if (toolTips.TryGetValue(control, out var toolTip))
            {
                toolTip.Dispose();
                toolTips.Remove(control);
            }
        }

        public static void DisposeAllToolTips()
        {
            foreach (var toolTip in toolTips.Values)
            {
                toolTip.Dispose();
            }
            toolTips.Clear();
        }

        // Método para eliminar todos los ToolTips activos
        public static void RemoveAll()
        {
            // Eliminar todos los ToolTips de los controles
            foreach (var control in toolTips.Keys.ToList())
            {
                toolTips[control].SetToolTip(control, string.Empty); // Establece un ToolTip vacío
            }

            // Limpiar el diccionario
            toolTips.Clear();
        }

    }
}
