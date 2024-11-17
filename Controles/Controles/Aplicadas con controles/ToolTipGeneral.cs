// se aplica asi-->ToolTipGeneral.ShowToolTip(this, btn_Imprimir, "Guardar e IMPRIMIR."); 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    public static class ToolTipGeneral
    {
        // Ruta predeterminada del ícono
        private static readonly string DefaultIconPath = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Resources\imagenes\ICOes.png";

        /// <summary>
        /// Muestra un ToolTip personalizado con un ícono al final del texto.
        /// </summary>
        /// <param name="form">Formulario padre donde se muestra el ToolTip.</param>
        /// <param name="control">Control al que se asocia el ToolTip.</param>
        /// <param name="toolTipText">Texto que se mostrará en el ToolTip.</param>
        public static void ShowToolTip(Form form, Control control, string toolTipText)
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
                // Color de fondo
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 154, 174)), e.Bounds);

                // Dividir el texto en líneas
                string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                using (Font font = new Font("Arial", 10))
                {
                    float lineHeight = font.GetHeight(e.Graphics) + 6;
                    float textY = e.Bounds.Y + 4;
                    int leftMargin = 10; // Margen izquierdo
                    int rightMargin = 30; // Espacio reservado para el ícono

                    // Dibujar el texto
                    foreach (string line in lines)
                    {
                        float textX = e.Bounds.X + leftMargin;
                        e.Graphics.DrawString(line, font, Brushes.White, new PointF(textX, textY));
                        textY += lineHeight;
                    }

                    // Dibujar el ícono al final
                    try
                    {
                        if (System.IO.File.Exists(DefaultIconPath))
                        {
                            // Cargar el ícono fuera del bloque 'using'
                            Bitmap iconBitmap = new Bitmap(DefaultIconPath);

                            // Redimensionar el ícono a 16x16 si es necesario
                            iconBitmap = new Bitmap(iconBitmap, new Size(16, 16));

                            int iconX = e.Bounds.Right - iconBitmap.Width - 5; // Ajustar al borde derecho
                            int iconY = e.Bounds.Top + (e.Bounds.Height - iconBitmap.Height) / 2; // Centrar verticalmente
                            e.Graphics.DrawImage(iconBitmap, new Rectangle(iconX, iconY, iconBitmap.Width, iconBitmap.Height));
                        }
                        else
                        {
                            // Mostrar un mensaje de error si no se encuentra el ícono
                            e.Graphics.DrawString("Icono no encontrado", new Font("Arial", 10), Brushes.Red, new PointF(e.Bounds.Right - 120, e.Bounds.Y + 5));
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Graphics.DrawString($"Error: {ex.Message}", new Font("Arial", 10), Brushes.Red, new PointF(e.Bounds.Right - 120, e.Bounds.Y + 5));
                    }
                }
            };

            // Configurar tamaño dinámico del ToolTip
            customToolTip.Popup += (sender, e) =>
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

                        int leftMargin = 10; // Margen izquierdo
                        int rightMargin = 25; // Espacio para el ícono
                        int width = (int)(maxWidth + leftMargin + rightMargin );
                        int height = (int)(totalHeight + 8);
                        e.ToolTipSize = new Size(width, height);
                    }
                }
            }; timer.Tick += (sender, e) =>
            {
                // Obtener la posición actual del cursor en relación al control
                Point cursorPosition = control.PointToClient(Control.MousePosition);

                // Calcular la posición del ToolTip
                int toolTipX = cursorPosition.X+5; //  posición horizontal del cursor
                int toolTipY = cursorPosition.Y + 5; // píxeles debajo del cursor

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


            form.FormClosing += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }
    }
}