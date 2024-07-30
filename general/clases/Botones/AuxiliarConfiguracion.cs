using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Crear el ítem "SALIR"
            ToolStripMenuItem item_Salir = new ToolStripMenuItem("SALIR");

            // Añadir todos los ítems al ContextMenuStrip
            menu_Configurar.Items.Add(item_Agregar);
            menu_Configurar.Items.Add(item_Buscar);
            menu_Configurar.Items.Add(item_Salir);

            // Manejar eventos de clic en los ítems
            subItem_Agregar_Secretario.Click += (sender, e) => MessageBox.Show("Seleccionaste SECRETARIO");
            subItem_Agregar_Instructor.Click += (sender, e) => MessageBox.Show("Seleccionaste INSTRUCTOR");
            subItem_Agregar_Dependencia.Click += (sender, e) => MessageBox.Show("Seleccionaste DEPENDENCIA");
            subItem_Agregar_UFID.Click += (sender, e) => MessageBox.Show("Seleccionaste U.F.I.D.");
            subItem_Agregar_AgenteFiscal.Click += (sender, e) => MessageBox.Show("Seleccionaste AGENTE FISCAL");

            subItem_Buscar_NIP.Click += (sender, e) => MessageBox.Show("Seleccionaste N° I.P.P.");
            subItem_Buscar_Caratula.Click += (sender, e) => MessageBox.Show("Seleccionaste CARATULA");
            subItem_Buscar_Victima.Click += (sender, e) => MessageBox.Show("Seleccionaste VICTIMA");
            subItem_Buscar_Imputado.Click += (sender, e) => MessageBox.Show("Seleccionaste IMPUTADO");
            subItem_Buscar_Fecha.Click += (sender, e) => MessageBox.Show("Seleccionaste FECHA");
            subItem_Buscar_Secretario.Click += (sender, e) => MessageBox.Show("Seleccionaste SECRETARIO");
            subItem_Buscar_Instructor.Click += (sender, e) => MessageBox.Show("Seleccionaste INSTRUCTOR");
            subItem_Buscar_Dependencia.Click += (sender, e) => MessageBox.Show("Seleccionaste DEPENDENCIA");

           item_Salir.Click += (sender, e) => menu_Configurar.Close();

            return menu_Configurar;
        }
    }
}
