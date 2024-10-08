using Ofelia_Sara.general.clases;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using System.Linq;
using Clases.Botones.btn_Configuracion;
using Clases.Botones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;
using Controles.Barra_Busqueda;
using System.Drawing.Drawing2D;
using MECANOGRAFIA;


namespace Ofelia_Sara.Formularios
{
    public partial class MenuPrincipal : BaseForm
    {

        private ContextMenuStrip contextMenu;
        private AuxiliarConfiguracion auxiliarConfiguracion;
        private AccionesManager accionesManager;//para el comboBox
        Timer timerCerrarForm = new Timer();
        Timer timerMinimizarForm = new Timer();
        private Size originalSizeMecanografia;
        private Point originalLocationMecanografia;

        // Definir el texto del placeholder
        private string placeholderText = "Buscar tipo de actuación...";

        public MenuPrincipal()
        {
            InitializeComponent();

            auxiliarConfiguracion = new AuxiliarConfiguracion(this);
            PosicionarMenu();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            accionesManager = new AccionesManager("acciones.json");
            ConfigureComboBox(comboBox_Buscar);
            CargarAcciones();//para comboBox_Buscar
           
            comboBox_Buscar.BringToFront(); // Asegúrate de que comboBoxBuscar está encima de comboBoxGNUA

            //----timer para que se vea efecto de cambio de color en los btn cerrar y minimizar
            timerCerrarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerMinimizarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerCerrarForm.Tick += TimerCerrar_Tick;
            timerMinimizarForm.Tick += TimerMinimizar_Tick;

            //para reducir el btn_Mecanografia
            originalSizeMecanografia = btn_Mecanografia.Size;
            originalLocationMecanografia = btn_Mecanografia.Location;

        }
       
        //_________________________________--________________________________

        private void PosicionarMenu()
        {
            // Obtener las dimensiones de la pantalla
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calcular la posición en X (centrado)
            int formX = (screenWidth - this.Width) / 2;

            // Calcular la posición en Y (20% desde el borde superior)
            int formY = (int)(screenHeight * 0.15);

            // Establecer la ubicación del formulario
            this.Location = new Point(formX, formY);
        }
        private void OpenFormBelowMenuPrincipal(Form formToOpen)
        {
            formToOpen.StartPosition = FormStartPosition.Manual;
            formToOpen.Location = new Point(this.Location.X, this.Location.Y + this.Height);
            formToOpen.Show();
        }
        //_________________________________________________________

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Configurar el botón para usar el menú de contexto
            btn_Configurar.ContextMenuStrip = auxiliarConfiguracion.CrearMenuConfigurar();

            //Para incrementar el tamaño de btn_configuracion y btn_CambiarTema
            IncrementarTamaño.Incrementar(btn_Configurar);
            IncrementarTamaño.Incrementar(btn_Leyes);

            comboBox_Buscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Buscar.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Asignar eventos de GotFocus y LostFocus para que se vea placeholder
            comboBox_Buscar.GotFocus += ComboBox_Buscar_GotFocus;
         //   comboBox_Buscar.LostFocus += ComboBox_Buscar_LostFocus; //se comento porque genera problemas


            //MostrarPlaceholder();
        }
        //--------------------------------------------------------------------------------



        //------------BOTON CONFIGURAR--------------------------------------------------
        private void Btn_Configurar_Click(object sender, EventArgs e)
        {
            // Mostrar el ContextMenuStrip en la posición del botón
            Point botonPosicion = btn_Configurar.PointToScreen(Point.Empty);
            btn_Configurar.ContextMenuStrip.Show(botonPosicion);
        }



        //-----BOTON INICIO-CIERRE------------
        private void Btn_InicioCierre_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            InicioCierre inicioCierreForm = new InicioCierre();
            // Mostrar el formulario
            inicioCierreForm.Show();

            // Minimizar el formulario "Menu Principal"
            this.WindowState = FormWindowState.Minimized;//cierra formulario actual
        }



        //-------------BOTON CONTRAVENCIONES------------
        private void Btn_Contravenciones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Contravenciones ContravencionesForm = new Contravenciones();
            // Mostrar el formulario
            ContravencionesForm.Show();

            // Minimizar el formulario "Menu Principal"
            this.WindowState = FormWindowState.Minimized;//cierra formulario actual
        }

        //----------------BOTON EXPEDIENTES-----------
        private void Btn_Expedientes_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Expedientes ExpedientesForm = new Expedientes();
            // Mostrar el formulario
            ExpedientesForm.Show();

            // Minimizar el formulario "Menu Principal"
            this.WindowState = FormWindowState.Minimized;//cierra formulario actual
        }




        //------------- BOTON BUSCAR--------------------------
        private BindingSource bindingSource;

        private void ConfigureComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            // Configurar el ComboBox para autocompletado
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Habilita el autocompletado
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Ajustar la altura de la lista desplegable para mostrar más ítems
            comboBox.DropDownHeight = 80;
            comboBox.Font = new Font("Arial", 11, FontStyle.Regular); // Cambia a la fuente deseada

            // Cargar las acciones y ordenar
            CargarAcciones();

            // Inicializar y configurar el BindingSource
            bindingSource = new BindingSource();
            bindingSource.DataSource = accionesManager.Acciones;

            // Establecer el DataSource del ComboBox al BindingSource
            comboBox.DataSource = bindingSource;

            // Manejar el evento de texto modificado
            comboBox.TextChanged += (sender, e) =>
            {
                // Filtrar la lista de acciones según el texto ingresado
                string searchText = comboBox.Text.ToLower();
                var filteredActions = accionesManager.Acciones
                    .Where(a => a.ToLower().Contains(searchText))
                    .ToList();

                // Actualizar la fuente de datos del ComboBox
                bindingSource.DataSource = filteredActions;

                // Reabrir la lista desplegable para mostrar las coincidencias
                if (comboBox.Items.Count > 0)
                {
                    comboBox.DroppedDown = true;
                }
            };
        }

        private void CargarAcciones()
        {
            try
            {
                string filePath = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\bin\Debug\acciones.json";
                accionesManager = new AccionesManager(filePath);

                // Elimina el DataSource si está asignado
                comboBox_Buscar.DataSource = null;

                // Poblar el ComboBox con las acciones
                comboBox_Buscar.Items.AddRange(accionesManager.Acciones.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las acciones: " + ex.Message);
            }
        }


        private void ComboBox_Buscar_Validating(object sender, CancelEventArgs e)
        {
            if (!accionesManager.Acciones.Contains(comboBox_Buscar.Text))
            {
                MessageBox.Show("La tarea que quiere realizar no se encuentra disponible.");
                e.Cancel = true; // Cancela la acción si la entrada no es válida
            }
        }



        private void ComboBox_Buscar_GotFocus(object sender, EventArgs e)
        {
            if (comboBox_Buscar.Text == placeholderText)
            {
                comboBox_Buscar.Text = "";
                comboBox_Buscar.ForeColor = Color.Black;
            }
        }

        //esta generando problemas
        //private void ComboBox_Buscar_LostFocus(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(comboBox_Buscar.Text))
        //    {
        //        MostrarPlaceholder();
        //    }
        //}


        private void ComboBox_Buscar_MouseHover(object sender, EventArgs e)
        {
          MostrarPlaceholder();
        }
        private void MostrarPlaceholder()
        {
            // Establecer el texto del placeholder y cambiar el color a gris
            comboBox_Buscar.Text = placeholderText;
            comboBox_Buscar.ForeColor = Color.Gray;
        }

            //_________________________________________________________________________________
            //----------------BTON LEYES------------------------------
            private void Btn_Leyes_Click(object sender, EventArgs e)
        {
            // Crear e inicializar el formulario para mostrar documentos
            LeyesForm leyesForm = new LeyesForm();

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la nueva ubicación para el formulario DocumentosForm
            int x = menuPrincipalLocation.X-6; // Mantener la misma posición horizontal
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height +10; // Colocar justo debajo

            // Ajustar la ubicación del formulario DocumentosForm
            leyesForm.StartPosition = FormStartPosition.Manual;
            leyesForm.Location = new Point(x, y);

            leyesForm.Show();
        }

        private void Btn_BuscarTarea_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un formulario
            if (comboBox_Buscar.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un formulario antes de continuar.", "OFELIA-SARA   Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el nombre del formulario seleccionado desde el comboBox
            string nombreFormularioSeleccionado = comboBox_Buscar.SelectedItem as string;

            // Verifica que se haya seleccionado un formulario
            if (!string.IsNullOrEmpty(nombreFormularioSeleccionado))
            {
                // Busca el formulario correspondiente en la lista de acciones
                var formularioSeleccionado = accionesManager.Acciones.Find(accion => accion == nombreFormularioSeleccionado);

                if (formularioSeleccionado != null)
                {
                    var abrirFormulario = new AbrirFormularios_BarraBusqueda();
                    abrirFormulario.AbrirFormulario(formularioSeleccionado);
                }
                else
                {
                    MessageBox.Show("El formulario seleccionado no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un formulario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        //-------------------------------------------------------------------------------------
        //eventos para la barra menu

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.FromArgb(255, 69, 58);
            btn_Cerrar.ForeColor = SystemColors.Control;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
          btn_Cerrar.FlatAppearance.BorderColor = Color.LightCoral;
            timerCerrarForm.Start();
        }
        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            timerCerrarForm.Stop();
            Application.Exit();   
        }

        private void Btn_Cerrar_MouseHover(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.Lavender;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.LightCoral;
        }

        private void Btn_Cerrar_MouseLeave(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = SystemColors.ButtonFace;
            btn_Cerrar.ForeColor = SystemColors.ControlDarkDark;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }
        //-------------------------------------------------------------------------
        private void TimerMinimizar_Tick(object sender, EventArgs e)
        {
            timerMinimizarForm.Stop();
            this.WindowState = FormWindowState.Minimized;
        }
        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = SystemColors.ActiveCaption;
            btn_Minimizar.ForeColor = SystemColors.Control;
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.Highlight;
            timerMinimizarForm.Start();
            
        }

        private void Btn_Minimizar_MouseHover(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Lavender;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.MenuHighlight;
        }

        private void Btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = SystemColors.ButtonFace;
            btn_Minimizar.ForeColor = SystemColors.ControlDarkDark;
            btn_Minimizar.FlatAppearance.BorderSize = 1;
            btn_Minimizar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }
        //--------------------------------------------------------------------------------
        //eventos para abrir aplicacion mecanografia
        private void Btn_Mecanografia_Click(object sender, EventArgs e)
        {
            // Desplazar el formulario menuPrincipal un 10% hacia abajo desde el borde superior de la pantalla
            int newY = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.05); // 5% de la altura de la pantalla

            // Cambiar la ubicación del formulario menuPrincipal
            this.Location = new Point(this.Location.X, newY);

            // Crear e inicializar el formulario para mostrar documentos
            Mecanografia mecanografia = new Mecanografia();

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Obtener el tamaño del formulario Mecanografia
            Size mecanografiaSize = mecanografia.Size;

            // Calcular la nueva ubicación para el formulario 

            int x = menuPrincipalLocation.X + (menuPrincipalSize.Width - mecanografiaSize.Width) / 2; // Centramos en el eje X
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10;

            // Ajustar la ubicación del formulario 
            mecanografia.StartPosition = FormStartPosition.Manual;
            mecanografia.Location = new Point(x, y);

            mecanografia.Show();
        }


        private void Btn_Mecanografia_MouseDown(object sender, MouseEventArgs e)
        {
            int reducedWidth = (int)(originalSizeMecanografia.Width * 0.85);
            int reducedHeight = (int)(originalSizeMecanografia.Height * 0.85);

            // Calcular el desplazamiento para centrar el PictureBox
            int offsetX = (originalSizeMecanografia.Width - reducedWidth) / 2;
            int offsetY = (originalSizeMecanografia.Height - reducedHeight) / 2;

            // Aplicar el nuevo tamaño y centrar el PictureBox
            btn_Mecanografia.Size = new Size(reducedWidth, reducedHeight);
          btn_Mecanografia.Location =new Point(originalLocationMecanografia.X + offsetX, originalLocationMecanografia.Y + offsetY);
        }

        private void Btn_Mecanografia_MouseUp(object sender, MouseEventArgs e)
        {
            // Restaurar el tamaño y la ubicación original
           
            btn_Mecanografia.Size = originalSizeMecanografia;
            btn_Mecanografia.Location = originalLocationMecanografia;
        }

        private void Btn_Mecanografia_MouseHover(object sender, EventArgs e)
        {
            btn_Mecanografia.FlatAppearance.BorderSize = 1;
            btn_Mecanografia.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }

        private void Btn_Mecanografia_MouseLeave(object sender, EventArgs e)
        {
            btn_Mecanografia.FlatAppearance.BorderSize = 0;
            btn_Mecanografia.Size = originalSizeMecanografia;

        }

        private void Label_OfeliaSara_Click(object sender, EventArgs e)
        {
            label_OfeliaSara.ForeColor=Color.Coral;
            label_OfeliaSara.Font = new Font(label_OfeliaSara.Font, FontStyle.Underline);//para subrayar

        
                // Crear e inicializar el formulario para mostrar el video
                VideoInstructivo videoInstructivo = new VideoInstructivo();

            // Suscribirse al evento FormClosed para restaurar el Label
            videoInstructivo.FormClosed += (s, args) =>
            {
                label_OfeliaSara.ForeColor = SystemColors.ControlText;
                label_OfeliaSara.Font = new Font(label_OfeliaSara.Font, FontStyle.Regular); // Eliminar subrayado
            };

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la nueva ubicación para el formulario DocumentosForm
            int x = menuPrincipalLocation.X-6; // Mantener la misma posición horizontal
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height +10; // Colocar justo debajo
            
            // Ajustar la ubicación del formulario DocumentosForm
            videoInstructivo.StartPosition = FormStartPosition.Manual;
            videoInstructivo.Location = new Point(x, y);

            videoInstructivo.Show();
        }

    }
}
