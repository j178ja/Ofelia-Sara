using System.Drawing;
using System.Windows.Forms;


namespace Ofelia_Sara.general.clases
{
    public class ConfiguracionMenu
    {
        private ContextMenuStrip contextMenuStrip;

        public ConfiguracionMenu()
        {
            InitializeContextMenu();
        }

        private void InitializeContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();

            // Crear elementos del menú contextual
            ToolStripMenuItem opcion1MenuItem = new ToolStripMenuItem("Agregar..");
            ToolStripMenuItem opcion2MenuItem = new ToolStripMenuItem("Buscar por..");
            ToolStripMenuItem salirMenuItem = new ToolStripMenuItem("Salir");

            // Crear subelementos para "Agregar.."
            ToolStripMenuItem comisariaSubItem = new ToolStripMenuItem("Comisaria");
            ToolStripMenuItem instructorSubItem = new ToolStripMenuItem("Instructor");
            ToolStripMenuItem secretarioSubItem = new ToolStripMenuItem("Secretario");
            ToolStripMenuItem ufidSubItem = new ToolStripMenuItem("U.F.I.D.");
            ToolStripMenuItem agenteFiscalSubItem = new ToolStripMenuItem("Agente Fiscal");
            ToolStripMenuItem selloSubItem = new ToolStripMenuItem("Sello Medalla");

            // Agregar subelementos al elemento "Agregar.."
            opcion1MenuItem.DropDownItems.Add(comisariaSubItem);
            opcion1MenuItem.DropDownItems.Add(instructorSubItem);
            opcion1MenuItem.DropDownItems.Add(secretarioSubItem);
            opcion1MenuItem.DropDownItems.Add(ufidSubItem);
            opcion1MenuItem.DropDownItems.Add(agenteFiscalSubItem);
            opcion1MenuItem.DropDownItems.Add(selloSubItem);

            // Agregar elementos al ContextMenuStrip
            contextMenuStrip.Items.Add(opcion1MenuItem);
            contextMenuStrip.Items.Add(opcion2MenuItem);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(salirMenuItem);

            // Manejadores de eventos (puedes descomentar y completar según sea necesario)
            //opcion1MenuItem.Click += (s, e) => MessageBox.Show("Opción 1 seleccionada.");
            //opcion2MenuItem.Click += (s, e) => MessageBox.Show("Opción 2 seleccionada.");
            //salirMenuItem.Click += (s, e) => Application.Exit();
        }

        public void ShowMenu(Control control, Point position)
        {
            contextMenuStrip.Show(control, position);
        }
    }
}
