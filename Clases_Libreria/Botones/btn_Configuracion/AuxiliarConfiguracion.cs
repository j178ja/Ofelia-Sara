using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Ofelia_Sara;
using Clases_Libreria.Reposicon_paneles;
using Interfaces_Libreria.Interfaces;



namespace Clases_Libreria.Botones.btn_Configuracion
{
    public class AuxiliarConfiguracion
    {
        private readonly Form _menuPrincipal;

        public AuxiliarConfiguracion(Form menuPrincipal)
        {
            if (menuPrincipal == null)
            {
                throw new ArgumentNullException(nameof(menuPrincipal), "El formulario principal no puede ser null.");
            }

            _menuPrincipal = menuPrincipal;
        }

        public ContextMenuStrip CrearMenuConfigurar()
        {
            // Crear un nuevo ContextMenuStrip
            ContextMenuStrip menu_Configurar = new ContextMenuStrip();

            // Crear ítems para el menú
            var item_Agregar = new ToolStripMenuItem("AGREGAR");
            var item_Buscar = new ToolStripMenuItem("BUSCAR ...");
            var item_Remover = new ToolStripMenuItem("REMOVER");
            var item_Salir = new ToolStripMenuItem("SALIR");
            var SubItem_Agregar_Sellos = new ToolStripMenuItem("SELLOS");

            // Agregar subítems al ítem "AGREGAR"
            AgregarSubItemsAgregar(item_Agregar);

            // Agregar subítems al ítem "BUSCAR"
            AgregarSubItemsBuscar(item_Buscar);

            // Agregar subítems al ítem "SELLOS"
            AgregarSubItemsSellos(SubItem_Agregar_Sellos);

            // Añadir el ítem "SELLOS" al ítem "AGREGAR"
            item_Agregar.DropDownItems.Add(SubItem_Agregar_Sellos);

            // Añadir todos los ítems al ContextMenuStrip
            menu_Configurar.Items.Add(item_Agregar);
            menu_Configurar.Items.Add(item_Buscar);
            menu_Configurar.Items.Add(item_Remover);
            menu_Configurar.Items.Add(item_Salir);
    

            // Manejo de eventos
            item_Salir.Click += (sender, e) => ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).Close();
            return menu_Configurar;
        }


        private void AgregarSubItemsAgregar(ToolStripMenuItem item_Agregar)
        {
            // Crear y agregar subítems al ítem "AGREGAR"
            var subItem_Agregar_Secretario = new ToolStripMenuItem("SECRETARIO", null, (s, e) => Agregar_Secretario());
            var subItem_Agregar_Instructor = new ToolStripMenuItem("INSTRUCTOR", null, (s, e) => Agregar_Instructor());
            var subItem_Agregar_Dependencia = new ToolStripMenuItem("DEPENDENCIA", null, (s, e) => Agregar_Dependencia());
            var subItem_Agregar_UFID = new ToolStripMenuItem("U.F.I.D.", null, (s, e) => Agregar_UFID());
            var subItem_Agregar_AgenteFiscal = new ToolStripMenuItem("AGENTE FISCAL", null, (s, e) => Agregar_AgenteFiscal());
         

            item_Agregar.DropDownItems.Add(subItem_Agregar_Secretario);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Instructor);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Dependencia);
            item_Agregar.DropDownItems.Add(subItem_Agregar_UFID);
            item_Agregar.DropDownItems.Add(subItem_Agregar_AgenteFiscal);

        }

        private void AgregarSubItemsBuscar(ToolStripMenuItem item_Buscar)
        {
            // Crear y agregar subítems al ítem "BUSCAR"
            var subItem_Buscar_Ipp = new ToolStripMenuItem("N° I.P.P.", null, (s, e) => Buscar_Ipp());
            var subItem_Buscar_Caratula = new ToolStripMenuItem("CARATULA", null, (s, e) => Buscar_Caratula());
            var subItem_Buscar_Victima = new ToolStripMenuItem("VICTIMA", null, (s, e) => Buscar_Victima());
            var subItem_Buscar_Imputado = new ToolStripMenuItem("IMPUTADO", null, (s, e) => Buscar_Imputado());
            var subItem_Buscar_Fecha = new ToolStripMenuItem("FECHA", null, (s, e) => Buscar_Fecha());
            var subItem_Buscar_Secretario = new ToolStripMenuItem("SECRETARIO", null, (s, e) => Buscar_Secretario());
            var subItem_Buscar_Instructor = new ToolStripMenuItem("INSTRUCTOR", null, (s, e) => Buscar_Instructor());
            var subItem_Buscar_Dependencia = new ToolStripMenuItem("DEPENDENCIA", null, (s, e) => Buscar_Dependencia());

            item_Buscar.DropDownItems.Add(subItem_Buscar_Ipp);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Caratula);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Victima);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Imputado);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Fecha);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Secretario);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Instructor);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Dependencia);

        }

        private void AgregarSubItemsSellos(ToolStripMenuItem SubItem_Agregar_Sellos)
        {
            // Crear los subítems
            var subItem_Sello_Medalla = new ToolStripMenuItem("SELLO MEDALLA", null, (s, e) => Sello_Medalla());
            var subItem_Escalera = new ToolStripMenuItem("ESCALERA", null, (s, e) => Escalera());
            var subItem_Foliador = new ToolStripMenuItem("FOLIADOR", null, (s, e) => Foliador());

            // Agregar los subítems a "SELLOS"
            SubItem_Agregar_Sellos.DropDownItems.Add(subItem_Sello_Medalla);
            SubItem_Agregar_Sellos.DropDownItems.Add(subItem_Escalera);
            SubItem_Agregar_Sellos.DropDownItems.Add(subItem_Foliador);
        }



        // Crear el ítem "REMOVER"
        ToolStripMenuItem item_Remover = new ToolStripMenuItem("REMOVER");

        // Crear el ítem "SALIR"
        ToolStripMenuItem item_Salir = new ToolStripMenuItem("SALIR");



  // ----MANEJAR EVENTOS CLICK DE ELEMENTOS DE MENU-----


        // Métodos para abrir formularios
        //--------para abrir formulario agregar secretario
        private void Agregar_Secretario()
        {
            //AbrirFormulario<NuevoSecretario>();
        }

        //---------Para abrir formulario AGREGAR INSTRUCTOR-----
        private void Agregar_Instructor()
        {
            //AbrirFormulario<NuevoInstructor>();
        }

        //---------Para abrir formulario AGREGAR DEPENDENCIA-----
        private void Agregar_Dependencia()
        {
           // AbrirFormulario<NuevaDependencia>();
        }


        //---------Para abrir formulario AGREGAR UFID-----
        private void Agregar_UFID()
        {
            //AbrirFormulario<NuevaFiscalia>();
        }

        // ------PARA ABRIR SELLOS--------------------
        private void Agregar_Sellos()
        {
           // AbrirFormulario<SellosDependencia>();
        }

        private void Sello_Medalla()
        {
            //AbrirFormulario<SellosDependencia>();
        }

        private void Escalera()
        {
           // AbrirFormulario<SellosDependencia>();
        }

        private void Foliador()
        {
            //AbrirFormulario<SellosDependencia>();
        }

        //--------PARA AGREGAR FISCAL---------------------
        private void Agregar_AgenteFiscal()
        {
           // AbrirFormulario<NuevaFiscalia>();
        }

        // ------PARA BUSCAR Y DERIVADOS----------------------
        private void Buscar_Ipp()
        {
           // AbrirFormulario<BuscarForm>("comboBox_Ipp1");
        }

        private void Buscar_Caratula()
        {
            //AbrirFormulario<BuscarForm>("textBox_Caratula");

        }

        private void Buscar_Victima()
        {
            //AbrirFormulario<BuscarForm>("textBox_Victima");
        }

        private void Buscar_Imputado()
        {
            //AbrirFormulario<BuscarForm>("textBox_Imputado");
        }

        private void Buscar_Fecha()
        {
            //AbrirFormulario<BuscarForm>("textBox_Fecha");
        }

        private void Buscar_Secretario()
        {
            //AbrirFormulario<BuscarForm>("textBox_Secretario");
        }

        private void Buscar_Instructor()
        {
            //AbrirFormulario<BuscarForm>("textBox_Instructor");
        }

        private void Buscar_Dependencia()
        {
            //AbrirFormulario<BuscarForm>("textBox_Dependencia");
        }

        // ------PARA Btn REMOVER----------------------
        private void Remover()
        {
            //AbrirFormulario<UsuarioForm>();
        }
        //--------------------------------------------------------------------------------



        private void AbrirFormulario<T>(string controlName = null) where T : Form, IFormulario,new()
        {
            // Crear una nueva instancia del formulario
            T form = new T();
            // Inicializar el formulario llamando al método de la interfaz
            form.Inicializar();

            FormPositioner.PosicionarDebajo(_menuPrincipal, form);
            form.Show();

            if (!string.IsNullOrEmpty(controlName))
            {
                Control control = form.Controls[controlName];
                if (control != null)
                {
                    PosicionarCursorEnTextBox(control); // Llama directamente
                }
            }
        }


        public void PosicionarCursorEnTextBox(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.Focus();
                textBox.SelectAll(); // Selecciona todo el texto
            }
        }
    }

}
