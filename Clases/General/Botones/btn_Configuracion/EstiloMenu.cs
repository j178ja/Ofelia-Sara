using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ofelia_Sara.Clases.General.Botones.btn_Configuracion
{
    public static class EstiloMenu
    {
        public static void AplicarEstiloItem(ToolStripItem item)
        {
            // Aplicamos el estilo al item principal
            item.BackColor = Color.FromArgb(178, 213, 230); // Fondo predeterminado
            item.ForeColor = Color.Black; // Color de texto predeterminado
            item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Regular); // Fuente predeterminada

            // Si el item tiene subitems, aplicamos el estilo a cada uno de ellos
            if (item is ToolStripMenuItem menuItem)
            {
                Cursor cursorPersonalizado = CursorHelper.ObtenerCursorDesdeRecursos(Properties.Resources.hand);

                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    subItem.BackColor = Color.FromArgb(186, 223, 249); // Fondo predeterminado
                    subItem.ForeColor = Color.Black; // Color de texto predeterminado
                    subItem.Font = new Font(subItem.Font.FontFamily, subItem.Font.Size, FontStyle.Regular); // Fuente predeterminada
                    menuItem.DropDown.Cursor = cursorPersonalizado; // Aplica el cursor personalizado a los subitems
                }
            }
        }

        public static ToolStripMenuItem CrearMenuItem(string texto, EventHandler onClick)
        {
            var menuItem = new ToolStripMenuItem(texto);
            // Aplicar los eventos y estilo aquí
            AplicarEstilo(menuItem, onClick);
            return menuItem;
        }

        public static ToolStripMenuItem CrearSubMenuItem(string texto, EventHandler onClick)
        {
            var subMenuItem = new ToolStripMenuItem(texto);
            // Aplicar los eventos y estilo aquí
            AplicarEstilo(subMenuItem, onClick);
            return subMenuItem;
        }

        private static void AplicarEstilo(ToolStripMenuItem menuItem, EventHandler onClick)
        {
            // Estilo inicial
            menuItem.BackColor = Color.FromArgb(178, 213, 230);
            menuItem.ForeColor = Color.Black;
            menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Regular);

            // Evento MouseEnter
            menuItem.MouseEnter += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(81, 169, 251);
                menuItem.ForeColor = Color.Black;
                menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size + 2, FontStyle.Bold);
            };

            // Evento MouseLeave
            menuItem.MouseLeave += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(178, 213, 230);
                menuItem.ForeColor = Color.Black;
                menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size - 2, FontStyle.Regular);
            };

            // Evento Click
            menuItem.Click += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(0, 154, 174);
                menuItem.ForeColor = Color.White;
                menuItem.Font = new Font(menuItem.Font, FontStyle.Bold);

                var timer = new Timer { Interval = 300 };
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    timer.Dispose();

                    menuItem.BackColor = Color.FromArgb(178, 213, 230);
                    menuItem.ForeColor = Color.Black;
                    menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Regular);

                    onClick?.Invoke(sender, e);
                };
                timer.Start();
            };

            // Evento DropDownOpened para cambiar el estilo cuando el submenú está abierto
            menuItem.DropDownOpened += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(0, 154, 174); // Fondo submenú
                menuItem.ForeColor = Color.White; // Texto blanco
                menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Bold); // Fuente en negrita
            };

            // Evento DropDownClosed para restaurar el estilo cuando el submenú está cerrado
            menuItem.DropDownClosed += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo original
                menuItem.ForeColor = Color.Black; // Texto original
                menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Regular); // Fuente normal
            };
        }

    }
}