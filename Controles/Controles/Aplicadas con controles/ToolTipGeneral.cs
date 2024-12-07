// se aplica asi-->ToolTipGeneral.ShowToolTip(this, btn_Imprimir, "Guardar e IMPRIMIR."); 


using System;
using System.Drawing;
using System.Windows.Forms;
namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    public static class ToolTipGeneral
    {
        private static Timer timer;
        private static ToolTip customToolTip;
        private static readonly string DefaultIconPath = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Resources\imagenes\ICOes.png";

        /// <summary>
        /// Muestra un ToolTip personalizado con un ícono al final del texto.
        /// </summary>
        /// <param name="control">Control al que se asocia el ToolTip.</param>
        /// <param name="toolTipText">Texto que se mostrará en el ToolTip.</param>
        public static void ShowToolTip(Control control, string toolTipText)
        {
            try
            {
                customToolTip = new ToolTip
                {
                    OwnerDraw = true // Habilitar dibujo personalizado
                };

                timer = new Timer { Interval = 100 };
                bool isCustomToolTipVisible = false;

                // Configurar dibujo personalizado
                customToolTip.Draw += (sender, e) =>
                {
                    try
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 154, 174)), e.Bounds);

                        string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                        using (Font font = new Font("Arial", 10))
                        {
                            float lineHeight = font.GetHeight(e.Graphics) + 6;
                            float textY = e.Bounds.Y + 4;
                            int leftMargin = 10; // Margen izquierdo
                            int rightMargin = 30; // Espacio reservado para el ícono

                            foreach (string line in lines)
                            {
                                float textX = e.Bounds.X + leftMargin;
                                e.Graphics.DrawString(line, font, Brushes.White, new PointF(textX, textY));
                                textY += lineHeight;
                            }

                            // Dibujar el ícono
                            if (System.IO.File.Exists(DefaultIconPath))
                            {
                                using (Bitmap iconBitmap = new Bitmap(DefaultIconPath))
                                {
                                    Bitmap resizedIcon = new Bitmap(iconBitmap, new Size(16, 16));
                                    int iconX = e.Bounds.Right - resizedIcon.Width - 5;
                                    int iconY = e.Bounds.Top + (e.Bounds.Height - resizedIcon.Height) / 2;
                                    e.Graphics.DrawImage(resizedIcon, new Rectangle(iconX, iconY, resizedIcon.Width, resizedIcon.Height));
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString("Ícono no encontrado", font, Brushes.Red, new PointF(e.Bounds.Right - 120, e.Bounds.Y + 5));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Graphics.DrawString($"Error: {ex.Message}", new Font("Arial", 8), Brushes.Red, e.Bounds.Location);
                    }
                };

                // Configurar tamaño dinámico
                customToolTip.Popup += (sender, e) =>
                {
                    try
                    {
                        using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
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

                                int leftMargin = 10;
                                int rightMargin = 25;
                                e.ToolTipSize = new Size((int)(maxWidth + leftMargin + rightMargin), (int)(totalHeight + 8));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error configurando el tamaño del ToolTip: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                timer.Tick += (sender, e) =>
                {
                    try
                    {
                        if (control == null || control.IsDisposed || !control.IsHandleCreated)
                            return;

                        Point cursorPosition = control.PointToClient(Control.MousePosition);
                        int toolTipX = cursorPosition.X + 8;
                        int toolTipY = cursorPosition.Y + 10;

                        if (control.ClientRectangle.Contains(cursorPosition))
                        {
                            if (!isCustomToolTipVisible)
                            {
                                isCustomToolTipVisible = true;
                                customToolTip.Show(toolTipText, control, new Point(toolTipX, toolTipY));
                            }
                        }
                        else if (isCustomToolTipVisible)
                        {
                            isCustomToolTipVisible = false;
                            customToolTip.Hide(control);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error durante el Tick del ToolTip: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el ToolTip: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Libera recursos asociados con los ToolTips.
        /// </summary>
        public static void DisposeToolTips()
        {
            try
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }

                if (customToolTip != null)
                {
                    customToolTip.Dispose();
                    customToolTip = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al liberar recursos del ToolTip: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}