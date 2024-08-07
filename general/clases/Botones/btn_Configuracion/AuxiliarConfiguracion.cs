using Ofelia_Sara.general.clases.Agregar_Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio;

namespace Ofelia_Sara.general.clases.Botones
{
    internal class AuxiliarConfiguracion
    {
        public ContextMenuStrip CrearMenuConfigurar()
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

            // Crear el nuevo subítem "SELLOS" y sus subítems
            ToolStripMenuItem subItem_Sello_Medalla = new ToolStripMenuItem("SELLO MEDALLA");
            ToolStripMenuItem subItem_Escalera = new ToolStripMenuItem("ESCALERA");
            ToolStripMenuItem subItem_Foliador = new ToolStripMenuItem("FOLIADOR");

            // Agregar los subítems a "SELLOS"
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

            // ----MANEJAR EVENTOS CLICK DE ELEMENTOS DE MENU-----

            //--------para abrir formulario agregar secretario
            subItem_Agregar_Secretario.Click += (sender, e) => {
                NuevoSecretario nuevoSecretarioForm = new NuevoSecretario(); // Crear una instancia del formulario NuevoSecretario
                nuevoSecretarioForm.ShowDialog();
            };

            //---------Para abrir formulario AGREGAR INSTRUCTOR-----
            subItem_Agregar_Instructor.Click += (sender, e) => {
                NuevoInstructor nuevoInstructor = new NuevoInstructor();
                nuevoInstructor.ShowDialog();
            };

            //---------Para abrir formulario AGREGAR DEPENDENCIA-----
            subItem_Agregar_Dependencia.Click += (sender, e) => {
                NuevaDependencia nuevaDependencia = new NuevaDependencia();
                nuevaDependencia.ShowDialog();
            };



            subItem_Agregar_UFID.Click += (sender, e) =>
            {
                NuevaFiscalia nuevaFiscalia = new NuevaFiscalia();
                nuevaFiscalia.ShowDialog();
            };

            subItem_Agregar_Sellos.Click += (sender, e) =>
            {
                SellosDependencia sellosDependencia = new SellosDependencia();
                sellosDependencia.ShowDialog();
            };
           

            subItem_Agregar_AgenteFiscal.Click += (sender, e) =>
            {
                NuevaFiscalia nuevaFiscalia = new NuevaFiscalia();
                nuevaFiscalia.ShowDialog();
            };

            //subItem_Buscar_NIP.Click += (sender, e) => MessageBox.Show("Seleccionaste N° I.P.P.");
            subItem_Buscar_Caratula.Click += (sender, e) => {// Crear una instancia del formulario de destino
                     BuscarForm buscarForm = new BuscarForm();
            buscarForm.Show();// Mostrar el formulario
            buscarForm.PosicionarCursorEnTextBox();// Posicionar el cursor en el textBox específico
            };
        //subItem_Buscar_Victima.Click += (sender, e) => MessageBox.Show("Seleccionaste VICTIMA");
        //subItem_Buscar_Imputado.Click += (sender, e) => MessageBox.Show("Seleccionaste IMPUTADO");
        //subItem_Buscar_Fecha.Click += (sender, e) => MessageBox.Show("Seleccionaste FECHA");
        //subItem_Buscar_Secretario.Click += (sender, e) => MessageBox.Show("Seleccionaste SECRETARIO");
        //subItem_Buscar_Instructor.Click += (sender, e) => MessageBox.Show("Seleccionaste INSTRUCTOR");
        //subItem_Buscar_Dependencia.Click += (sender, e) => MessageBox.Show("Seleccionaste DEPENDENCIA");

        item_Salir.Click += (sender, e) => menu_Configurar.Close(); // para que se cierre el menu

            return menu_Configurar;
        }
    }
}
