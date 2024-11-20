using iTextSharp.text;
using Ofelia_Sara.Clases.Botones.btn_Configuracion;
using System.Windows.Forms;
using System.Drawing;

namespace Clases.Botones.btn_Configuracion
{
    public class MenuConfigurar
    {
        /// <summary>
        /// Método estático para crear un menú contextual configurado.
        /// </summary>
        /// <returns>Una instancia de CustomContextMenu con los ítems configurados.</returns>
        public static ContextMenuStrip CrearMenu()
        {
            // Crear el menú contextual
            ContextMenuStrip menu_Configurar = new ContextMenuStrip();
           
            // Crear ítems para el menú
            ToolStripMenuItem item_Agregar = new ToolStripMenuItem("AGREGAR");
            ToolStripMenuItem item_Buscar = new ToolStripMenuItem("BUSCAR ...");
            ToolStripMenuItem item_Remover = new ToolStripMenuItem("REMOVER");
            ToolStripMenuItem item_Salir = new ToolStripMenuItem("SALIR");

            // Crear subítems para "AGREGAR"
            ToolStripMenuItem subItem_Agregar_Secretario = new ToolStripMenuItem("SECRETARIO");
            ToolStripMenuItem subItem_Agregar_Instructor = new ToolStripMenuItem("INSTRUCTOR");

            // Agregar subítems al ítem "AGREGAR"
            item_Agregar.DropDownItems.Add(subItem_Agregar_Secretario);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Instructor);

          

            // Añadir ítems al menú
            menu_Configurar.Items.Add(item_Agregar);
            menu_Configurar.Items.Add(item_Buscar);
            menu_Configurar.Items.Add(item_Remover);
            menu_Configurar.Items.Add(item_Salir);

            return menu_Configurar;
        }
    }
}
