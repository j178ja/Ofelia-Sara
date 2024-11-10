using System.Windows.Forms;

namespace Clases.Botones.btn_Configuracion
{
    public class MenuConfigurar
    {
        private Button boton; // Referencia al botón que tendrá el menú

        // Constructor que recibe el botón al que se asociará el menú
        public MenuConfigurar(Button boton)
        {
            this.boton = boton;
            InicializarMenuConfigurar();
        }

        private void InicializarMenuConfigurar()
        {
            // Crear un nuevo ContextMenuStrip
            ContextMenuStrip menu_Configurar = new ContextMenuStrip();

            // Crear ítems para el menú
            ToolStripMenuItem item_Agregar = new ToolStripMenuItem("AGREGAR");

            // Crear y agregar subítems al ítem "AGREGAR"
            ToolStripMenuItem subItem_Agregar_Secretario = new ToolStripMenuItem("SECRETARIO");
            ToolStripMenuItem subItem_Agregar_Instructor = new ToolStripMenuItem("INSTRUCTOR");
            ToolStripMenuItem subItem_Agregar_Dependencia = new ToolStripMenuItem("DEPENDENCIA");
            ToolStripMenuItem subItem_Agregar_UFID = new ToolStripMenuItem("U.F.I.D.");
            ToolStripMenuItem subItem_Agregar_AgenteFiscal = new ToolStripMenuItem("AGENTE FISCAL");
            ToolStripMenuItem subItem_Agregar_Sellos = new ToolStripMenuItem("SELLOS");

            // Añadir los subítems al ítem "AGREGAR"
            item_Agregar.DropDownItems.Add(subItem_Agregar_Secretario);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Instructor);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Dependencia);
            item_Agregar.DropDownItems.Add(subItem_Agregar_UFID);
            item_Agregar.DropDownItems.Add(subItem_Agregar_AgenteFiscal);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Sellos);

            //Crear subItems para SELLOS
            ToolStripMenuItem subItem_Sello_Medalla = new ToolStripMenuItem("SELLO MEDALLA");
            ToolStripMenuItem subItem_Escalera = new ToolStripMenuItem("ESCALERA");
            ToolStripMenuItem subItem_Foliador = new ToolStripMenuItem("FOLIADOR");

            //Agregar los sub items al item sello
            subItem_Agregar_Sellos.DropDownItems.Add(subItem_Sello_Medalla);
            subItem_Agregar_Sellos.DropDownItems.Add(subItem_Escalera);
            subItem_Agregar_Sellos.DropDownItems.Add(subItem_Foliador);

            // Crear el ítem "BUSCAR" y sus subítems
            ToolStripMenuItem item_Buscar = new ToolStripMenuItem("BUSCAR ...");

            ToolStripMenuItem subItem_Buscar_NIP = new ToolStripMenuItem("N° I.P.P.");
            ToolStripMenuItem subItem_Buscar_Caratula = new ToolStripMenuItem("CARATULA");
            ToolStripMenuItem subItem_Buscar_Victima = new ToolStripMenuItem("VICTIMA");
            ToolStripMenuItem subItem_Buscar_Imputado = new ToolStripMenuItem("IMPUTADO");
            ToolStripMenuItem subItem_Buscar_Fecha = new ToolStripMenuItem("FECHA");
            ToolStripMenuItem subItem_Buscar_Secretario = new ToolStripMenuItem("SECRETARIO");
            ToolStripMenuItem subItem_Buscar_Instructor = new ToolStripMenuItem("INSTRUCTOR");
            ToolStripMenuItem subItem_Buscar_Dependencia = new ToolStripMenuItem("DEPENDENCIA");

            // Añadir los subítems al ítem "BUSCAR"
            item_Buscar.DropDownItems.Add(subItem_Buscar_NIP);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Caratula);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Victima);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Imputado);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Fecha);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Secretario);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Instructor);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Dependencia);

            // Crear el ítem "REMOVER"
            ToolStripMenuItem item_Remover = new ToolStripMenuItem("REMOVER");

            // Crear el ítem "SALIR"
            ToolStripMenuItem item_Salir = new ToolStripMenuItem("SALIR");

            // Añadir todos los ítems al ContextMenuStrip
            menu_Configurar.Items.Add(item_Agregar);
            menu_Configurar.Items.Add(item_Buscar);
            menu_Configurar.Items.Add(item_Remover);
            menu_Configurar.Items.Add(item_Salir);

            // Asociar el ContextMenuStrip al botón
            boton.ContextMenuStrip = menu_Configurar;


        }


    }
}
