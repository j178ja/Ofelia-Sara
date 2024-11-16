using System.Drawing;
using System;
using System.Windows.Forms;

namespace Controles.Controles.Aplicadas_con_controles
{
    public partial class TooltipEnControlDesactivado
    {
        public static void ConfigurarToolTip(Form form, Control control, string toolTipText)
        {
            ToolTip customToolTip = new ToolTip
            {
                OwnerDraw = true // Habilitar dibujo personalizado
            };

            ToolTip defaultToolTip = new ToolTip();
            defaultToolTip.SetToolTip(control, ""); // Inicializar vacío

            Timer timer = new Timer { Interval = 100 };
            bool isCustomToolTipVisible = false;

            // Manejar el evento Draw para personalizar el ToolTip
            customToolTip.Draw += (sender, e) =>
            {
                // Fondo del ToolTip
                e.Graphics.FillRectangle(SystemBrushes.Info, e.Bounds);

                // Icono de advertencia con padding izquierdo de 7 px (4 + 3)
                Icon warningIcon = SystemIcons.Warning;
                int iconX = e.Bounds.X + 7; // Padding izquierdo de 7 px (4 + 3)
                int iconY = e.Bounds.Y + 5; // Ajuste del ícono
                e.Graphics.DrawIcon(warningIcon, new Rectangle(iconX, iconY, 16, 16));

                // Dividir el texto en líneas si es necesario
                string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                using (Font font = new Font("Arial", 10))
                {
                    float lineHeight = font.GetHeight(e.Graphics) + 6; // Reducir altura del texto en 3 px
                    float textY = e.Bounds.Y + 4; // Margen superior

                    // Definir el ancho disponible para el texto, considerando el icono y un margen izquierdo específico
                    int leftMargin = 7 + 16 + 20; // Margen izquierdo (icono + padding)
                    int rightMargin = 10; // Margen derecho del texto

                    foreach (string line in lines)
                    {
                        SizeF textSize = e.Graphics.MeasureString(line, font);

                        // Posición X del texto (después del icono y margen izquierdo, con margen derecho ajustado)
                        float textX = e.Bounds.X + leftMargin; // Posición del texto desde la izquierda
                        float maxTextX = e.Bounds.X + e.Bounds.Width - rightMargin - textSize.Width; // Margen derecho ajustado

                        // Asegurar que el texto no sobrepase el margen derecho
                        textX = Math.Min(textX, maxTextX);

                        e.Graphics.DrawString(line, font, Brushes.Black, new PointF(textX, textY));
                        textY += lineHeight; // Avanzar a la siguiente línea
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
                        // Dividir el texto en líneas y calcular el tamaño total
                        string[] lines = toolTipText.Split(new[] { '\n' }, StringSplitOptions.None);
                        float maxWidth = 0;
                        float totalHeight = 0;

                        foreach (string line in lines)
                        {
                            SizeF textSize = g.MeasureString(line, font);
                            maxWidth = Math.Max(maxWidth, textSize.Width);
                            totalHeight += textSize.Height;
                        }

                        // Asegurar que el tamaño tenga en cuenta el espacio del icono y los márgenes
                        int leftMargin = 7 + 16 + 10; // Margen izquierdo
                        int rightMargin = 10; // Margen derecho
                        int width = (int)(maxWidth + leftMargin + rightMargin); // Espacio total para el texto con márgenes
                        int height = (int)(totalHeight + 8); // Alto con espacio para varias líneas
                        e.ToolTipSize = new Size(width, height);
                    }
                }
            };

            timer.Tick += (sender, e) =>
            {
                // Asegurarse de que el ToolTip personalizado se muestre solo si el control está deshabilitado
                if (!control.Enabled && control.ClientRectangle.Contains(control.PointToClient(Control.MousePosition)))
                {
                    if (!isCustomToolTipVisible)
                    {
                        isCustomToolTipVisible = true;
                        defaultToolTip.Active = false; // Desactivar ToolTip predeterminado

                        // Mostrar ToolTip más abajo
                        Point toolTipLocation = new Point(control.Width / 2, control.Height / 5 + 5);
                        customToolTip.Show(toolTipText, control, toolTipLocation);
                    }
                }
                else
                {
                    // Si el control está habilitado o el ToolTip personalizado está oculto, mostrar el predeterminado
                    if (isCustomToolTipVisible)
                    {
                        isCustomToolTipVisible = false;
                        customToolTip.Hide(control); // Ocultar ToolTip personalizado
                        defaultToolTip.Active = true; // Reactivar ToolTip predeterminado
                    }
                }
            };

            form.FormClosing += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public static void DesactivarToolTipsEnControlesDesactivados(Control parentControl)
        {
            // Instancia única del ToolTip compartido
            ToolTip sharedToolTip = new ToolTip
            {
                Active = false // Inicialmente desactivado
            };

            foreach (Control control in parentControl.Controls)
            {
                // Si el control está deshabilitado, desactivar el ToolTip predeterminado
                if (!control.Enabled)
                {
                    sharedToolTip.SetToolTip(control, string.Empty); // Desactivar el ToolTip
                }

                // Si el control tiene hijos, recorrerlos recursivamente
                if (control.HasChildren)
                {
                    DesactivarToolTipsEnControlesDesactivados(control); // Llamada recursiva
                }
            }
        }


    }
}
