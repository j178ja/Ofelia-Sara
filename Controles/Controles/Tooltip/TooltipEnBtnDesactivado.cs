using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.Tooltip
{
    public partial class TooltipEnControlDesactivado
    {
        public static void ConfigurarToolTip(Form form, Control control, string toolTipTextDisabled, string toolTipTextEnabled)
        {
            ToolTip customToolTip = new ToolTip
            {
                OwnerDraw = true // Habilitar dibujo personalizado
            };

            Timer timer = new Timer { Interval = 100 };
            bool isCustomToolTipVisible = false;

            // Manejar el evento Draw para personalizar el ToolTip
            customToolTip.Draw += (sender, e) =>
            {
                // Determinar si el control está habilitado o no para ajustar el diseño
                bool isEnabled = control.Enabled;
                Color backgroundColor = isEnabled ? Color.LightBlue : SystemColors.Info;
                Icon icon = isEnabled ? SystemIcons.Information : SystemIcons.Warning;
                string toolTipText = isEnabled ? toolTipTextEnabled : toolTipTextDisabled;

                // Fondo del ToolTip
                e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

                // Icono con padding
                int iconX = e.Bounds.X + 7; // Padding izquierdo
                int iconY = e.Bounds.Y + 5; // Ajuste del ícono
                e.Graphics.DrawIcon(icon, new Rectangle(iconX, iconY, 16, 16));

                // Dividir el texto en líneas
                string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                using (Font font = new Font("Arial", 10))
                {
                    float lineHeight = font.GetHeight(e.Graphics) + 6;
                    float textY = e.Bounds.Y + 4;
                    int leftMargin = 7 + 16 + 20; // Margen izquierdo
                    int rightMargin = 10; // Margen derecho

                    foreach (string line in lines)
                    {
                        float textX = e.Bounds.X + leftMargin;
                        e.Graphics.DrawString(line, font, Brushes.Black, new PointF(textX, textY));
                        textY += lineHeight;
                    }
                }
            };

            // Configurar tamaño dinámico del ToolTip
            customToolTip.Popup += (sender, e) =>
            {
                using (Graphics g = Graphics.FromHwnd(nint.Zero))
                {
                    using (Font font = new Font("Arial", 10))
                    {
                        string toolTipText = control.Enabled ? toolTipTextEnabled : toolTipTextDisabled;
                        string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                        float maxWidth = 0;
                        float totalHeight = 0;

                        foreach (string line in lines)
                        {
                            SizeF textSize = g.MeasureString(line, font);
                            maxWidth = Math.Max(maxWidth, textSize.Width);
                            totalHeight += textSize.Height;
                        }

                        int leftMargin = 7 + 16 + 10; // Margen izquierdo
                        int rightMargin = 10; // Margen derecho
                        int width = (int)(maxWidth + leftMargin + rightMargin);
                        int height = (int)(totalHeight + 8);
                        e.ToolTipSize = new Size(width, height);
                    }
                }
            };

            timer.Tick += (sender, e) =>
            {
                // Verificar si el mouse está sobre el control
                if (control.ClientRectangle.Contains(control.PointToClient(Control.MousePosition)))
                {
                    // Obtener la posición actual del cursor relativa al control
                    Point cursorPosition = control.PointToClient(Control.MousePosition);

                    // Calcular la posición del ToolTip (7 px a la derecha y 5 px abajo)
                    int toolTipX = cursorPosition.X + 7;
                    int toolTipY = cursorPosition.Y + 5;

                    if (!isCustomToolTipVisible)
                    {
                        isCustomToolTipVisible = true;

                        // Determinar el texto del ToolTip según el estado del control
                        string toolTipText = control.Enabled ? toolTipTextEnabled : toolTipTextDisabled;

                        // Mostrar ToolTip personalizado con la posición ajustada
                        customToolTip.Show(toolTipText, control, new Point(toolTipX, toolTipY));
                    }
                }
                else if (isCustomToolTipVisible)
                {
                    isCustomToolTipVisible = false;
                    customToolTip.Hide(control);
                }
            };

            // Manejo del evento FormClosing para limpiar recursos
            form.FormClosing += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }
        //-------

        public static void DesactivarToolTipsEnControlesDesactivados(Control parentControl)
        {
            ToolTip sharedToolTip = new ToolTip
            {
                Active = false
            };

            foreach (Control control in parentControl.Controls)
            {
                if (!control.Enabled)
                {
                    sharedToolTip.SetToolTip(control, string.Empty);
                }

                if (control.HasChildren)
                {
                    DesactivarToolTipsEnControlesDesactivados(control);
                }
            }
        }

        public static void TooltipActivo(Form form, Control control, string toolTipText, bool activar)
        {
            // Verificar si el control está habilitado y visible antes de mostrar el ToolTip
            if (!activar || !control.Visible || !control.Enabled)
            {
                return; // No mostrar el ToolTip si el control está deshabilitado o no es visible
            }

            ToolTip customToolTip = new ToolTip
            {
                OwnerDraw = true // Habilitar dibujo personalizado
            };

            Timer timer = new Timer { Interval = 100 };
            bool isCustomToolTipVisible = false;

            // Manejar el evento Draw para personalizar el ToolTip
            customToolTip.Draw += (sender, e) =>
            {
                // Fondo azul claro
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);

                // Icono de información con padding
                Icon infoIcon = SystemIcons.Information;
                int iconX = e.Bounds.X + 7; // Padding izquierdo
                int iconY = e.Bounds.Y + 5; // Ajuste del ícono
                e.Graphics.DrawIcon(infoIcon, new Rectangle(iconX, iconY, 16, 16));

                // Dividir el texto en líneas
                string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                using (Font font = new Font("Arial", 10))
                {
                    float lineHeight = font.GetHeight(e.Graphics) + 6;
                    float textY = e.Bounds.Y + 4;
                    int leftMargin = 7 + 16 + 20; // Margen izquierdo
                    int rightMargin = 10; // Margen derecho

                    foreach (string line in lines)
                    {
                        float textX = e.Bounds.X + leftMargin;
                        e.Graphics.DrawString(line, font, Brushes.Black, new PointF(textX, textY));
                        textY += lineHeight;
                    }
                }
            };

            // Configurar tamaño dinámico del ToolTip
            customToolTip.Popup += (sender, e) =>
            {
                using (Graphics g = Graphics.FromHwnd(nint.Zero))
                {
                    using (Font font = new Font("Arial", 10))
                    {
                        string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                        float maxWidth = 0;
                        float totalHeight = 0;

                        foreach (string line in lines)
                        {
                            SizeF textSize = g.MeasureString(line, font);
                            maxWidth = Math.Max(maxWidth, textSize.Width);
                            totalHeight += textSize.Height;
                        }

                        int leftMargin = 7 + 16 + 10; // Margen izquierdo
                        int rightMargin = 10; // Margen derecho
                        int width = (int)(maxWidth + leftMargin + rightMargin);
                        int height = (int)(totalHeight + 8);
                        e.ToolTipSize = new Size(width, height);
                    }
                }
            };

            timer.Tick += (sender, e) =>
            {
                // Obtener la posición actual del cursor relativa al control
                Point cursorPosition = control.PointToClient(Control.MousePosition);

                // Calcular la posición del ToolTip (5 px abajo y 5 px a la derecha del cursor)
                int toolTipX = cursorPosition.X + 7; // Ajuste horizontal
                int toolTipY = cursorPosition.Y + 5; // Ajuste vertical

                // Mostrar el ToolTip personalizado si el mouse está sobre el control
                if (control.ClientRectangle.Contains(cursorPosition))
                {
                    if (!isCustomToolTipVisible)
                    {
                        isCustomToolTipVisible = true;

                        // Mostrar ToolTip personalizado en la nueva posición
                        customToolTip.Show(toolTipText, control, new Point(toolTipX, toolTipY));
                    }
                }
                else if (isCustomToolTipVisible)
                {
                    isCustomToolTipVisible = false;
                    customToolTip.Hide(control);
                }
            };

            // Manejo del evento FormClosing para limpiar recursos
            form.FormClosing += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

    }
}
