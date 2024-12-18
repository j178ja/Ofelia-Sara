// se aplica asi-->ToolTipGeneral.ShowToolTip(this, btn_Imprimir, "Guardar e IMPRIMIR."); 


using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    public static class ToolTipGeneral
    {
//        private static Timer timer;
//        private static ToolTip customToolTip;
//        private static readonly System.Drawing.Bitmap DefaultImage = Properties.Resources.EscudoPolicia_PNG;

//        /// <summary>
//        /// Muestra un ToolTip personalizado con un ícono al final del texto.
//        /// </summary>
//        /// <param name="control">Control al que se asocia el ToolTip.</param>
//        /// <param name="toolTipText">Texto que se mostrará en el ToolTip.</param>
//        public static void ShowToolTip(Control control, string toolTipText)
//        {
//            try
//            {
//                customToolTip = new ToolTip
//                {
//                    OwnerDraw = true, // Habilitar dibujo personalizado
//                    InitialDelay = 500, // Retraso inicial antes de aparecer
//                    ReshowDelay = 100, // Retraso entre reapariciones
//                    AutoPopDelay = 5000 // Tiempo que permanece visible
//                };

//                timer = new Timer { Interval = 100 };
//                bool isCustomToolTipVisible = false;

//                // Configurar dibujo personalizado
//                customToolTip.Draw += (sender, e) =>
//                {
//                    try
//                    {
//                        Color backgroundColor = control.Enabled ? Color.FromArgb(0, 154, 174) : Color.Gray;
//                        e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

//                        string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
//                        using (Font font = new Font("Arial", 10))
//                        {
//                            float lineHeight = font.GetHeight(e.Graphics) + 6;
//                            float textY = e.Bounds.Y + 4;
//                            int leftMargin = 10; // Margen izquierdo
//                            int rightMargin = 30; // Espacio reservado para el ícono

//                            foreach (string line in lines)
//                            {
//                                float textX = e.Bounds.X + leftMargin;
//                                e.Graphics.DrawString(line, font, Brushes.White, new PointF(textX, textY));
//                                textY += lineHeight;
//                            }

//                            // Dibujar la imagen del recurso
//                            if (DefaultImage != null)
//                            {
//                                Bitmap resizedImage = new Bitmap(DefaultImage, new Size(16, 16));
//                                int iconX = e.Bounds.Right - resizedImage.Width - 5;
//                                int iconY = e.Bounds.Top + (e.Bounds.Height - resizedImage.Height) / 2;
//                                e.Graphics.DrawImage(resizedImage, new Rectangle(iconX, iconY, resizedImage.Width, resizedImage.Height));
//                            }
//                            else
//                            {
//                                e.Graphics.DrawString("Ícono no encontrado", new Font("Arial", 8), Brushes.Red, new PointF(e.Bounds.Right - 120, e.Bounds.Y + 5));
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        e.Graphics.DrawString($"Error: {ex.Message}", new Font("Arial", 8), Brushes.Red, e.Bounds.Location);
//                    }
//                };

//                // Configurar tamaño dinámico
//                customToolTip.Popup += (sender, e) =>
//                {
//                    try
//                    {
//                        using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
//                        {
//                            using (Font font = new Font("Arial", 10))
//                            {
//                                string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
//                                float maxWidth = 0;
//                                float totalHeight = 0;

//                                foreach (string line in lines)
//                                {
//                                    SizeF textSize = g.MeasureString(line, font);
//                                    maxWidth = Math.Max(maxWidth, textSize.Width);
//                                    totalHeight += textSize.Height;
//                                }

//                                int leftMargin = 10;
//                                int rightMargin = 25;
//                                e.ToolTipSize = new Size((int)(maxWidth + leftMargin + rightMargin), (int)(totalHeight + 8));
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        MensajeGeneral.Mostrar($"Error configurando el tamaño del ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
//                    }
//                };

//                // Manejar visibilidad del ToolTip
//                timer.Tick += (sender, e) =>
//                {
//                    try
//                    {
//                        if (control == null || control.IsDisposed || !control.IsHandleCreated || !control.Visible)
//                        {
//                            if (isCustomToolTipVisible)
//                            {
//                                isCustomToolTipVisible = false;
//                                customToolTip.Hide(control);
//                            }
//                            return;
//                        }

//                        Point cursorPosition;
//                        try
//                        {
//                            cursorPosition = control.PointToClient(Control.MousePosition);
//                        }
//                        catch (Exception ex)
//                        {
//                            Debug.WriteLine($"Error en PointToClient: {ex.Message}");
//                            return;
//                        }

//                        int toolTipX = cursorPosition.X + 8;
//                        int toolTipY = cursorPosition.Y + 10;

//                        if (control.ClientRectangle.Contains(cursorPosition))
//                        {
//                            if (!isCustomToolTipVisible)
//                            {
//                                isCustomToolTipVisible = true;
//                                customToolTip.Show(toolTipText, control, new Point(toolTipX, toolTipY));
//                            }
//                        }
//                        else if (isCustomToolTipVisible)
//                        {
//                            isCustomToolTipVisible = false;
//                            customToolTip.Hide(control);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//#if DEBUG
//                        MensajeGeneral.Mostrar($"Error durante el Tick del ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
//#else
//    Debug.WriteLine($"Error durante el Tick del ToolTip: {ex.Message}");
//#endif
//                    }

//                };

//                // Manejar eventos del control
//                control.VisibleChanged += (sender, e) =>
//                {
//                    if (!control.Visible && customToolTip != null)
//                    {
//                        customToolTip.Hide(control);
//                    }
//                };

//                control.Disposed += (sender, e) =>
//                {
//                    DisposeToolTips();
//                };

//                control.MouseLeave += (sender, e) =>
//                {
//                    if (customToolTip != null)
//                    {
//                        customToolTip.Hide(control);
//                    }
//                };

//                timer.Start();
//            }
//            catch (Exception ex)
//            {
//                MensajeGeneral.Mostrar($"Error al inicializar el ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
//            }
//        }

//        /// <summary>
//        /// Libera recursos asociados con los ToolTips.
//        /// </summary>
//        public static void DisposeToolTips()
//        {
//            try
//            {
//                if (timer != null)
//                {
//                    timer.Stop();
//                    timer.Dispose();
//                    timer = null;
//                }

//                if (customToolTip != null)
//                {
//                    customToolTip.Dispose();
//                    customToolTip = null;
//                }
//            }
//            catch (Exception ex)
//            {
//                MensajeGeneral.Mostrar($"Error al liberar recursos del ToolTip: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
//            }
//        }
    }
}