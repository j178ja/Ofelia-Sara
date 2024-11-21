using Clases.Reposicon_paneles;
using Ofelia_Sara.Agregar_Componentes;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;



namespace Ofelia_Sara.Clases.Botones.btn_Configuracion
{

    public class AuxiliarConfiguracion
    {
        private readonly Form _menuPrincipal;

        public AuxiliarConfiguracion(Form menuPrincipal)
        {
            if (menuPrincipal == null)
            {
                _menuPrincipal = menuPrincipal ?? throw new ArgumentNullException(nameof(menuPrincipal), "El formulario principal no puede ser null.");
            }

            _menuPrincipal = menuPrincipal;
        }

        public ContextMenuStrip CrearMenuConfigurar()
        {
            // Crear un nuevo ContextMenuStrip
            ContextMenuStrip menu_Configurar = new ContextMenuStrip();

            // Crear ítems para el menú usando el método CrearMenuItem
            var item_Agregar = CrearMenuItem("AGREGAR",null);
            var item_Buscar = CrearMenuItem("BUSCAR ...",null);
            var item_Remover = CrearMenuItem("EDITAR/REMOVER", Item_Remover_Click);
            item_Remover.Click += new EventHandler(Item_Remover_Click);
            var item_Salir = CrearMenuItem("SALIR",null);
            var SubItem_Agregar_Sellos = CrearMenuItem("SELLOS", null);
                        
           // Agregar el evento Click para "EDITAR/REMOVER"
            item_Remover.Click += new EventHandler(Item_Remover_Click);


            // Agregar imágenes a los ítems
            item_Agregar.Image = Properties.Resources.agregar_General;
            item_Buscar.Image = Properties.Resources.buscar75_;
            item_Remover.Image = Properties.Resources.editar;
            item_Salir.Image = Properties.Resources.atras;
            SubItem_Agregar_Sellos.Image = Properties.Resources.sello_de_goma;


         
            // Agregar subítems al ítem "AGREGAR"
            AgregarSubItemsAgregar(item_Agregar);

            // Agregar subítems al ítem "BUSCAR"
            AgregarSubItemsBuscar(item_Buscar);

            // Agregar subítems al ítem "SELLOS"
            AgregarSubItemsSellos(SubItem_Agregar_Sellos);

            // Añadir los subítems al ítem principal
            item_Agregar.DropDownItems.Add(SubItem_Agregar_Sellos);

            // Añadir todos los ítems al ContextMenuStrip
            menu_Configurar.Items.Add(item_Agregar);
            menu_Configurar.Items.Add(item_Buscar);
            menu_Configurar.Items.Add(item_Remover);
            menu_Configurar.Items.Add(item_Salir);

            // Manejo de eventos de salida
            item_Salir.Click += (sender, e) => ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).Close();
            
            menu_Configurar.Renderer = new CustomMenuStripRenderer();
            // Aplicar estilos a todos los ítems del menú
            foreach (ToolStripItem item in menu_Configurar.Items)
            {
                AplicarEstiloItem(item);
            }

            return menu_Configurar;
        }



        private ToolStripMenuItem CrearMenuItem(string texto, EventHandler onClick)
        {
            var menuItem = new ToolStripMenuItem(texto);

            // Estilo inicial
            menuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo original
            menuItem.ForeColor = Color.Black; // Texto original
            menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Regular); // Fuente original

            // Evento MouseEnter para cambiar el color al pasar el cursor
            menuItem.MouseEnter += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(81, 169, 251); // Fondo al pasar el mouse
                menuItem.ForeColor = Color.Black; // Texto negro
                menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size + 2, FontStyle.Bold); // Aumentar tamaño y negrita
            };

            // Evento MouseLeave para restaurar el color al quitar el cursor
            menuItem.MouseLeave += (sender, e) =>
            {
                menuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo original
                menuItem.ForeColor = Color.Black; // Texto original
                menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size - 2, FontStyle.Regular); // Fuente regular
            };

            // Evento Click para cambiar el fondo al hacer clic
            menuItem.Click += (sender, e) =>
            {
                // Cambiar el estilo al hacer clic
                menuItem.BackColor = Color.FromArgb(0, 154, 174); // Fondo tras clic
                menuItem.ForeColor = Color.White; // Texto blanco
                menuItem.Font = new Font(menuItem.Font, FontStyle.Bold); // Negrita

                // Configurar un temporizador para restaurar el estilo después de un corto periodo
                var timer = new Timer { Interval = 300 }; // 300 ms
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();  // Detener el Timer
                    timer.Dispose(); // Liberar recursos

                    // Restaurar el estilo original
                    menuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo original
                    menuItem.ForeColor = Color.Black; // Texto original
                    menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Regular); // Fuente normal

                    // Ejecutar la acción asociada
                    onClick?.Invoke(sender, e); // Llamar al método asociado al clic
                };
                timer.Start();
            };

            //// Evento DropDownOpened para cambiar el estilo cuando el submenú está abierto
            //menuItem.DropDownOpened += (sender, e) =>
            //{
            //    // Estilo al abrir el submenú
            //    menuItem.BackColor = Color.FromArgb(0, 154, 174); // Fondo submenú
            //    menuItem.ForeColor = Color.White; // Texto blanco
            //    menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Bold); // Fuente en negrita
            //};

            //// Evento DropDownClosed para restaurar el estilo cuando el submenú está cerrado
            //menuItem.DropDownClosed += (sender, e) =>
            //{
            //    // Restaurar el estilo al cerrar el submenú
            //    menuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo original
            //    menuItem.ForeColor = Color.Black; // Texto original
            //    menuItem.Font = new Font(menuItem.Font.FontFamily, menuItem.Font.Size, FontStyle.Regular); // Fuente normal
            //};

            return menuItem;
        }



        private ToolStripMenuItem CrearSubMenuItem(string texto, EventHandler onClick)
        {
            var subMenuItem = new ToolStripMenuItem(texto);

            // Asociar evento Click principal
            subMenuItem.Click += onClick;

            // Evento MouseEnter para cambiar el color al pasar el cursor
            subMenuItem.MouseEnter += (sender, e) =>
            {
                subMenuItem.BackColor = Color.FromArgb(81, 169, 251); // Fondo
                subMenuItem.ForeColor = Color.Black; // Texto
                subMenuItem.Font = new Font(subMenuItem.Font.FontFamily, subMenuItem.Font.Size + 2, FontStyle.Bold); // Negrita y tamaño incrementado
            };

            // Evento MouseLeave para restaurar el color al quitar el cursor
            subMenuItem.MouseLeave += (sender, e) =>
            {
                subMenuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo
                subMenuItem.ForeColor = Color.Black; // Texto
                subMenuItem.Font = new Font(subMenuItem.Font.FontFamily, subMenuItem.Font.Size - 2, FontStyle.Regular);
            };

            // Evento Click para cambiar el fondo al hacer clic
            subMenuItem.Click += (sender, e) =>
            {
                // Cambiar el estilo al hacer clic
                subMenuItem.BackColor = Color.FromArgb(0, 154, 174); // Fondo tras clic
                subMenuItem.ForeColor = Color.White; // Texto en blanco para mayor contraste
                subMenuItem.Font = new Font(subMenuItem.Font, FontStyle.Bold); // Negrita

                // Configurar un temporizador para restaurar el estilo después de un corto periodo
                var timer = new Timer { Interval = 300 }; // 300 ms
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();  // Detener el Timer
                    timer.Dispose(); // Liberar recursos

                    // Restaurar el estilo original
                    subMenuItem.BackColor = Color.FromArgb(178, 213, 230); // Fondo original
                    subMenuItem.ForeColor = Color.Black; // Texto original
                    subMenuItem.Font = new Font(subMenuItem.Font.FontFamily, subMenuItem.Font.Size, FontStyle.Regular); // Fuente normal

                    // Ejecutar la acción asociada
                    onClick?.Invoke(sender, e); // Llamar al método de apertura del formulario
                };
                timer.Start();
            };

            return subMenuItem;
        }




        //para aplicar el fondo a los items y a los subitems
        private void AplicarEstiloItem(ToolStripItem item)
        {
            // Aplicamos el estilo al item principal
            item.BackColor = Color.FromArgb(178, 213, 230); // Fondo predeterminado
            item.ForeColor = Color.Black; // Color de texto predeterminado
            item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Regular); // Fuente predeterminada

            // Si el item tiene subitems, aplicamos el estilo a cada uno de ellos
            if (item is ToolStripMenuItem menuItem)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    subItem.BackColor = Color.FromArgb(186, 223, 249); // Fondo predeterminado
                    subItem.ForeColor = Color.Black; // Color de texto predeterminado
                    subItem.Font = new Font(subItem.Font.FontFamily, subItem.Font.Size, FontStyle.Regular); // Fuente predeterminada
                }
            }
        }


        private void AgregarSubItemsAgregar(ToolStripMenuItem item_Agregar)
        {
            // Crear y agregar subítems al ítem "AGREGAR"
            var subItem_Agregar_Secretario = CrearSubMenuItem("SECRETARIO", (s, e) => Agregar_Secretario());
            var subItem_Agregar_Instructor = CrearSubMenuItem("INSTRUCTOR", (s, e) => Agregar_Instructor());
            var subItem_Agregar_Dependencia = CrearSubMenuItem("DEPENDENCIA", (s, e) => Agregar_Dependencia());
            var subItem_Agregar_UFID = CrearSubMenuItem("U.F.I.D.", (s, e) => Agregar_UFID());
            var subItem_Agregar_AgenteFiscal = CrearSubMenuItem("AGENTE FISCAL", (s, e) => Agregar_AgenteFiscal());


            item_Agregar.DropDownItems.Add(subItem_Agregar_Secretario);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Instructor);
            item_Agregar.DropDownItems.Add(subItem_Agregar_Dependencia);
            item_Agregar.DropDownItems.Add(subItem_Agregar_UFID);
            item_Agregar.DropDownItems.Add(subItem_Agregar_AgenteFiscal);

            // agregar imagen a los subitems
            subItem_Agregar_Secretario.Image = Properties.Resources.agregar_Usuario;
            subItem_Agregar_Instructor.Image = Properties.Resources.agregar_Usuario;
            subItem_Agregar_Dependencia.Image = Properties.Resources.agregar_Dependencia;
            subItem_Agregar_UFID.Image = Properties.Resources.agregar_Dependencia;
            subItem_Agregar_AgenteFiscal.Image = Properties.Resources.agregar_Usuario;
           


        }

        private void AgregarSubItemsBuscar(ToolStripMenuItem item_Buscar)
        {
            // Crear y agregar subítems al ítem "BUSCAR"
            var subItem_Buscar_Ipp = CrearSubMenuItem( "N° I.P.P.", (s, e) => Buscar_Ipp());

            var subItem_Buscar_Caratula = CrearSubMenuItem("CARATULA", (s, e) => Buscar_Caratula());
            var subItem_Buscar_Victima = CrearSubMenuItem("VICTIMA", (s, e) => Buscar_Victima());
            var subItem_Buscar_Imputado = CrearSubMenuItem("IMPUTADO", (s, e) => Buscar_Imputado());
            var subItem_Buscar_Fecha = CrearSubMenuItem("FECHA", (s, e) => Buscar_Fecha());
            var subItem_Buscar_Secretario = CrearSubMenuItem("SECRETARIO", (s, e) => Buscar_Secretario());
            var subItem_Buscar_Instructor = CrearSubMenuItem("INSTRUCTOR", (s, e) => Buscar_Instructor());
            var subItem_Buscar_Dependencia = CrearSubMenuItem("DEPENDENCIA", (s, e) => Buscar_Dependencia());

            item_Buscar.DropDownItems.Add(subItem_Buscar_Ipp);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Caratula);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Victima);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Imputado);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Fecha);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Secretario);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Instructor);
            item_Buscar.DropDownItems.Add(subItem_Buscar_Dependencia);

            //agregar imagen a cada item
            subItem_Buscar_Ipp.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Caratula.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Victima.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Imputado.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Fecha.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Secretario.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Instructor.Image = Properties.Resources.buscar75_;
            subItem_Buscar_Dependencia.Image = Properties.Resources.buscar75_;

        }

        private void AgregarSubItemsSellos(ToolStripMenuItem SubItem_Agregar_Sellos)
        {
            // Crear los subítems y asociar la función correspondiente
            var subItem_Sello_Medalla = CrearSubMenuItem("SELLO MEDALLA", (s, e) => Sello_Medalla());
            var subItem_Escalera = CrearSubMenuItem("ESCALERA", (s, e) => Escalera());
            var subItem_Foliador = CrearSubMenuItem("FOLIADOR", (s, e) => Foliador());

            // Agregar los subítems a "SELLOS"
            SubItem_Agregar_Sellos.DropDownItems.Add(subItem_Sello_Medalla);
            SubItem_Agregar_Sellos.DropDownItems.Add(subItem_Escalera);
            SubItem_Agregar_Sellos.DropDownItems.Add(subItem_Foliador);

            AplicarEstiloItem(SubItem_Agregar_Sellos);

            // Agregar imágenes
            subItem_Sello_Medalla.Image = Properties.Resources.ICOes;
            subItem_Escalera.Image = Properties.Resources.ICOes;
            subItem_Foliador.Image = Properties.Resources.ICOes;
        }


        // Crear el ítem "SALIR"
        ToolStripMenuItem item_Salir = new ToolStripMenuItem("SALIR");



        // ----MANEJAR EVENTOS CLICK DE ELEMENTOS DE MENU-----


        // Métodos para abrir formularios
        //--------para abrir formulario agregar secretario
        private void Agregar_Secretario()
        {
            AbrirFormulario<NuevoSecretario>();
        }

        //---------Para abrir formulario AGREGAR INSTRUCTOR-----
        private void Agregar_Instructor()
        {
            AbrirFormulario<NuevoInstructor>();
        }

        //---------Para abrir formulario AGREGAR DEPENDENCIA-----
        private void Agregar_Dependencia()
        {
            AbrirFormulario<NuevaDependencia>();
        }


        //---------Para abrir formulario AGREGAR UFID-----
        private void Agregar_UFID()
        {
            AbrirFormulario<NuevaFiscalia>();
        }

        // ------PARA ABRIR SELLOS--------------------
        private void Agregar_Sellos()
        {
            AbrirFormulario<SellosDependencia>();
        }

        private void Sello_Medalla()
        {
            AbrirFormulario<SellosDependencia>( );
        }

        private void Escalera()
        {
            AbrirFormulario<SellosDependencia>();
        }

        private void Foliador()
        {
            AbrirFormulario<SellosDependencia>();
        }

        //--------PARA AGREGAR FISCAL---------------------
        private void Agregar_AgenteFiscal()
        {
            AbrirFormulario<NuevaFiscalia>();
        }

        // ------PARA BUSCAR Y DERIVADOS----------------------
        private void Buscar_Ipp()
        {
            AbrirFormulario<BuscarForm>("comboBox_Ipp1");
        }

        private void Buscar_Caratula()
        {
            AbrirFormulario<BuscarForm>("textBox_Caratula");

        }

        private void Buscar_Victima()
        {
            AbrirFormulario<BuscarForm>("textBox_Victima");
        }

        private void Buscar_Imputado()
        {
            AbrirFormulario<BuscarForm>("textBox_Imputado");
        }

        private void Buscar_Fecha()
        {
            AbrirFormulario<BuscarForm>("textBox_Fecha");
        }

        private void Buscar_Secretario()
        {
            AbrirFormulario<BuscarForm>("textBox_Secretario");
        }

        private void Buscar_Instructor()
        {
        AbrirFormulario<BuscarForm>("textBox_Instructor");
        }
        // Método para abrir formularios y posicionar el cursor en un control específico
        private void Buscar_Dependencia()
        {
             AbrirFormulario<BuscarForm>("textBox_Dependencia");
        }

        // ------PARA Btn REMOVER----------------------
        private void Item_Remover_Click(object sender, EventArgs e)
        {
            AbrirFormulario<UsuarioForm>();
        }


        //--------------------------------------------------------------------------------
        // Método para abrir formularios sin pasar parámetros (básico)
        private void AbrirFormulario<T>(string controlName = null) where T : Form, new()
        {
            Form form = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (form == null)
            {
                form = new T();
                FormPositioner.PosicionarDebajo(_menuPrincipal, form);
                form.Left = _menuPrincipal.Left - 6;
                form.Top = _menuPrincipal.Top + _menuPrincipal.Height + 10;
                form.Show();
            }
            else
            {
                form.BringToFront();
            }

            if (!string.IsNullOrEmpty(controlName))
            {
                Control control = form.Controls[controlName];
                if (control != null)
                {
                    PosicionarCursorEnTextBox(control);
                }
            }
        }

        private void AbrirConDemora(Action accion, int delayMilliseconds = 100)
        {
            var timer = new Timer { Interval = delayMilliseconds };
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
                accion?.Invoke();
            };
            timer.Start();
        }


        public void PosicionarCursorEnTextBox(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.Focus();
                textBox.SelectAll(); // Selecciona todo el texto
            }
        }
        //-----------------------------------------------------------------------
      


    }

}
