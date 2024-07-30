using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
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

            // Manejar eventos de clic en los ítems
            subItem_Agregar_Secretario.Click += SubItem_Agregar_Secretario_Click;
            subItem_Agregar_Instructor.Click += SubItem_Agregar_Instructor_Click;
            subItem_Agregar_Dependencia.Click += SubItem_Agregar_Dependencia_Click;
            subItem_Agregar_UFID.Click += SubItem_Agregar_UFID_Click;
            subItem_Agregar_AgenteFiscal.Click += SubItem_Agregar_AgenteFiscal_Click;

            subItem_Buscar_NIP.Click += SubItem_Buscar_NIP_Click;
            subItem_Buscar_Caratula.Click += SubItem_Buscar_Caratula_Click;
            subItem_Buscar_Victima.Click += SubItem_Buscar_Victima_Click;
            subItem_Buscar_Imputado.Click += SubItem_Buscar_Imputado_Click;
            subItem_Buscar_Fecha.Click += SubItem_Buscar_Fecha_Click;
            subItem_Buscar_Secretario.Click += SubItem_Buscar_Secretario_Click;
            subItem_Buscar_Instructor.Click += SubItem_Buscar_Instructor_Click;
            subItem_Buscar_Dependencia.Click += SubItem_Buscar_Dependencia_Click;

            item_Salir.Click += Item_Salir_Click;
        }

        // Métodos para manejar los clics en los subítems
        private void SubItem_Agregar_Secretario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste SECRETARIO");
        }

        private void SubItem_Agregar_Instructor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste INSTRUCTOR");
        }

        private void SubItem_Agregar_Dependencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste DEPENDENCIA");
        }

        private void SubItem_Agregar_UFID_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste U.F.I.D.");
        }

        private void SubItem_Agregar_AgenteFiscal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste AGENTE FISCAL");
        }

        private void SubItem_Buscar_NIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste N° I.P.P.");
        }

        private void SubItem_Buscar_Caratula_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste CARATULA");
        }

        private void SubItem_Buscar_Victima_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste VICTIMA");
        }

        private void SubItem_Buscar_Imputado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste IMPUTADO");
        }

        private void SubItem_Buscar_Fecha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste FECHA");
        }

        private void SubItem_Buscar_Secretario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste SECRETARIO");
        }

        private void SubItem_Buscar_Instructor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste INSTRUCTOR");
        }

        private void SubItem_Buscar_Dependencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccionaste DEPENDENCIA");
        }

        private void Item_Salir_Click(object sender, EventArgs e)
        {
            // Implementar la acción deseada al hacer clic en SALIR, como ocultar el menú.
            MessageBox.Show("Salir seleccionado");
        }
    }
}
