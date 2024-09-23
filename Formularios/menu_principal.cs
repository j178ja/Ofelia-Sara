using Ofelia_Sara.general.clases;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using System.Linq;
using Clases_Libreria.Botones.btn_Configuracion;
using Clases_Libreria.Botones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;

namespace Ofelia_Sara.Formularios
{
    public partial class MenuPrincipal : BaseForm
    {

        private ContextMenuStrip contextMenu;
        private AuxiliarConfiguracion auxiliarConfiguracion;
        private AccionesManager accionesManager;//para el comboBox


        public MenuPrincipal()
        {
            InitializeComponent();

            auxiliarConfiguracion = new AuxiliarConfiguracion(this);
            posicionarMenu();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            accionesManager = new AccionesManager("acciones.json");
            ConfigureComboBox(comboBox_Buscar);
            CargarAcciones();//para comboBox_Buscar
            ConfigurePlaceholderComboBox();

            comboBox_Buscar.BringToFront(); // Asegúrate de que comboBoxBuscar está encima de comboBoxGNUA

            
        }
        //---------------------------------------------
        private void ConfigurePlaceholderComboBox()
        {
            var placeholderComboBox = new PlaceholderComboBox
            {
                PlaceholderText = "Buscar tipo actuacion",
                PlaceholderColor = Color.Red,
                Location = new Point(147, 28), // Ajusta la ubicación según tu diseño
                Size = new Size(294, 28) // Ajusta el tamaño según tus necesidades
            };

            // Agregar al formulario
            this.Controls.Add(placeholderComboBox);
        }
        //_________________________________--________________________________

        private void posicionarMenu()
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

        }
        //--------------------------------------------------------------------------------



        //------------BOTON CONFIGURAR--------------------------------------------------
        private void btn_Configurar_Click(object sender, EventArgs e)
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


        private void comboBox_Buscar_Validating(object sender, CancelEventArgs e)
        {
            if (!accionesManager.Acciones.Contains(comboBox_Buscar.Text))
            {
                MessageBox.Show("La tarea que quiere realizar no se encuentra disponible.");
                e.Cancel = true; // Cancela la acción si la entrada no es válida
            }
        }

       
        //_________________________________________________________________________________
        //----------------BTON LEYES------------------------------
        private void btn_Leyes_Click(object sender, EventArgs e)
        {
            // Crear e inicializar el formulario para mostrar documentos
            LeyesForm leyesForm = new LeyesForm();

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la nueva ubicación para el formulario DocumentosForm
            int x = menuPrincipalLocation.X; // Mantener la misma posición horizontal
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height; // Colocar justo debajo

            // Ajustar la ubicación del formulario DocumentosForm
            leyesForm.StartPosition = FormStartPosition.Manual;
            leyesForm.Location = new Point(x, y);
                       
            leyesForm.Show();
        }
     

    }
}
