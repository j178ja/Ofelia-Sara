using BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using Ofelia_Sara.Formularios.General.Mensajes;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Adm_BD;
using Ofelia_Sara.Controles.General;
using System.Collections.Generic;
using BaseDatos.Entidades;
using Newtonsoft.Json;
using System.Windows.Media;


namespace Ofelia_Sara.Formularios.General
{
    /// <summary>
    /// CARGA LOS MANEJADORES Y BASE DE DATOS EN EJECUCION
    /// </summary>
    public partial class BaseFormDATOS : Form
    {
        #region VARIABLES
        protected DatabaseConnection dbConnection;
        protected  Autocompletar autocompletar;
        protected ComisariasManager comisariasManager;
        protected InstructoresManager instructoresManager;
        protected SecretariosManager secretariosManager;
        protected FiscaliasManager fiscaliasManager;
        protected bool IsInDesignMode => DesignMode ||
                                  LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                                  Process.GetCurrentProcess().ProcessName == "devenv";
        #endregion

        public BaseFormDATOS()
        {
            if (IsInDesignMode)
            {
                try
                {
                    InitializeComponent(); // Solo se llama al método generado automáticamente

                }
                catch (Exception ex)
                {
                    // Log o manejo de errores para evitar bloqueos en el diseñador
                    Console.WriteLine($"Error en tiempo de diseño: {ex.Message}");
                }
            }
            else
            {
                InitializeRuntimeMode();
              
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); // Llama al método base para no perder funcionalidad
            InitializarAutocompletado(); //guarda los ultimos ingresos para ser mostrados
            CargarDatosComboBox(this);//carga los datos en todos los combobox segun su nombre
            ConfigurarEscalafonYjerarquia(this);
        }

        /// <summary>
        /// INICIALIZA EN TIEMPO DE EJECUCION
        /// </summary>
        protected void InitializeRuntimeMode()
        {
            InitializeComponent(); // Llama primero para inicializar los controles
            InitializarAutocompletado(); //guarda los ultimos ingresos para ser mostrados
            CargarDatosComboBox(this);//carga los datos en todos los combobox segun su nombre
            ConfigurarEscalafonYjerarquia(this);
        }
   

        /// <summary>
        /// guarda los ultimos ingresos para ser mostrados y autocompleta
        /// </summary>
        private void InitializarAutocompletado()
        {
            try
            {
                // Ruta relativa al archivo JSON
                string rutaRelativa = Path.Combine("BaseDatos", "Json", "ultimos_ingresos.json");

                // Obtener la ruta completa usando la ruta base del ejecutable
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

                // Crear el archivo si no existe
                if (!File.Exists(rutaCompleta))
                {
                    File.WriteAllText(rutaCompleta, JsonConvert.SerializeObject(new List<string>(), Formatting.Indented));
                }

                // Inicializa AutocompletarManager con la ruta del archivo JSON
                autocompletar = new Autocompletar(rutaCompleta);

                // Configura el autocompletado para los controles del formulario
                ConfigurarAutocompletado();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inicializando managers: {ex.Message}");
            }
        }

        #region CARGA DATOS

        /// <summary>
        /// inicializa conexion y carga los datos dependiendo el nombre del control en todos los formularios,
        /// </summary>
        public void CargarDatosComboBox(Control parent)
        {
            try
            {
                foreach (Control control in GetAllControls(parent))
                {
                    if (control is CustomComboBox comboBox)
                    {
                        switch (comboBox.Name)
                        {
                            case "comboBox_Dependencia":
                                CargarDatosDependencia(comboBox, new ComisariasManager());
                                break;

                            case "comboBox_Instructor":
                                CargarDatosInstructor(comboBox, new InstructoresManager());
                                break;

                            case "comboBox_Secretario":
                                CargarDatosSecretario(comboBox, new SecretariosManager());
                                break;

                            case "comboBox_Fiscalia":
                                CargarDatosFiscalia(comboBox, new FiscaliasManager());
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar los ComboBox: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }



        /// <summary>
        /// CARGAR DATOS DE DEPENDENCIA
        /// </summary>
        /// <param name="customComboBox"></param>
        /// <param name="dbManager"></param>
        public static void CargarDatosDependencia(CustomComboBox customComboBox, ComisariasManager dbManager)
        {
            try
            {
                // Validar que los parámetros no sean nulos
                if (customComboBox == null)
                {
                    throw new ArgumentNullException(nameof(customComboBox), "El ComboBox no puede ser nulo.");
                }

                if (dbManager == null)
                {
                    throw new ArgumentNullException(nameof(dbManager), "El gestor de base de datos no puede ser nulo.");
                }

                // Obtener los datos desde la base de datos
                List<Comisarias> comisarias = dbManager.GetComisarias() ?? throw new InvalidOperationException("No se pudieron obtener las comisarías desde la base de datos.");

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                customComboBox.Items.Clear();

                //// Recorrer la lista de comisarías y agregar los datos al ComboBox
                foreach (Comisarias comisaria in comisarias)
                {
                    string item = $"{comisaria.Nombre}   {comisaria.Localidad}"; // Utiliza las propiedades de la clase Comisaria
                    customComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje más detallado con la pila de llamadas
                MensajeGeneral.Mostrar(
                    $"Error al cargar datos de Dependencias: {ex.Message}\n{ex.StackTrace}",
                    MensajeGeneral.TipoMensaje.Error
                );
            }
        }

        /// <summary>
        /// CARGAR DATOS DE INSTRUCTOR
        /// </summary>
        /// <param name="customComboBox"></param>
        /// <param name="dbManager"></param>
        public static void CargarDatosInstructor(CustomComboBox customComboBox, InstructoresManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Instructores> instructores = dbManager.GetInstructors(); // Asegúrate de usar el método correcto

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                customComboBox.Items.Clear();

                // Recorrer la lista de instructores y agregar los datos al ComboBox
                foreach (Instructores instructor in instructores)
                {
                    // Utiliza las propiedades de la clase Instructor
                    string item = $"{instructor.Jerarquia} {instructor.Nombre} {instructor.Apellido}";
                    customComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Instructores: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// CARGAR DATOS DE SECRETARIO
        /// </summary>
        /// <param name="customComboBox"></param>
        /// <param name="dbManager"></param>
        public static void CargarDatosSecretario(CustomComboBox customComboBox, SecretariosManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Secretarios> secretarios = dbManager.GetSecretarios();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                customComboBox.Items.Clear();

                // Recorrer la lista de secretarios y agregar los datos al ComboBox
                foreach (Secretarios secretario in secretarios)
                {
                    // Utiliza las propiedades de la clase Secretario
                    string item = $"{secretario.Jerarquia} {secretario.Nombre} {secretario.Apellido}";
                    customComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Secretarios: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// CARGAR DATOS DE FISCALIA
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="dbManager"></param>
        public static void CargarDatosFiscalia(CustomComboBox comboBox, FiscaliasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Fiscalias> fiscalias = dbManager.GetFiscalias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de fiscalías y agregar los datos al ComboBox
                foreach (Fiscalias fiscalia in fiscalias)
                {
                    string item = $"{fiscalia.Ufid} "; //carga unicamente columna fiscalia 
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Fiscalías: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        /// <summary>
        /// Método virtual para ser sobreescrito en los formularios hijos
        /// </summary>
        /// <returns></returns>
        protected virtual CustomComboBox ObtenerComboBoxDependencia()
        {
            return null; // Devuelve null por defecto, será sobrescrito en cada formulario específico
        }

        /// <summary>
        /// asocia combobox escalafon y jerarquia
        /// </summary>
        /// <param name="parent"></param>
        protected void ConfigurarEscalafonYjerarquia(Control parent) //ConfigurarComboBoxEscalafon(comboBox_Escalafon);
        {
            CustomComboBox comboBox_Escalafon = null;
            CustomComboBox comboBox_Jerarquia = null;

            foreach (Control control in GetAllControls(parent))

            {
                if (control is CustomComboBox customComboBox)
                {
                    //Aplicar DropDownList automáticamente
                    customComboBox.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;

                    // Detectar comboBox_Escalafon
                    if (customComboBox.Name == "comboBox_Escalafon")
                    {
                        comboBox_Escalafon = customComboBox;
                        CargarEscalafon(/*customComboBox*/);
                    }

                    // Detectar comboBox_Jerarquia
                    if (customComboBox.Name == "comboBox_Jerarquia")
                    {
                        comboBox_Jerarquia = customComboBox;
                    }
                }

                // Si el control tiene hijos, los recorremos también
                if (control.Controls.Count > 0)
                {
                    ConfigurarEscalafonYjerarquia(control);
                }
            }

            // Si ambos ComboBoxes existen, configuramos la dependencia
            if (comboBox_Escalafon != null && comboBox_Jerarquia != null)
            {
                ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            }
        }


        // Configura el ComboBox Escalafón con su DataSource
        protected void CargarEscalafon()
        {
            // Recorre todos los controles dentro de la clase BaseForm
            foreach (Control control in this.Controls)
            {
                // Verificar si el control es un CustomComboBox y su nombre es comboBox_Escalafon
                if (control is CustomComboBox customComboBox)
                {
                    if (customComboBox.Name == "comboBox_Escalafon")
                    {
                        // Configurar el ComboBox Escalafón con su DataSource
                        customComboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
                        customComboBox.SelectedIndex = -1; // No seleccionar automáticamente el primer ítem
                    }
                }
            }
        }

        /// <summary>
        /// Configura el ComboBox_Jerarquia dependiente de ComboBox_Escalafon
        /// </summary>
        /// <param name="comboBox_Escalafon"></param>
        /// <param name="comboBox_Jerarquia"></param>
        /// // Configurar el comportamiento de los ComboBox
     //   ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
        protected static void ConfigurarComboBoxEscalafonJerarquia(CustomComboBox comboBox_Escalafon, CustomComboBox comboBox_Jerarquia)
        {
            // Configurar el evento SelectedIndexChanged
            comboBox_Escalafon.SelectedIndexChanged += (sender, e) =>
            {
                if (comboBox_Escalafon.SelectedItem != null)
                {
                    string escalafon = comboBox_Escalafon.SelectedItem.ToString();
                    comboBox_Jerarquia.Enabled = true;
                    comboBox_Jerarquia.DataSource = JerarquiasManager.ObtenerJerarquias(escalafon);
                    comboBox_Jerarquia.SelectedIndex = -1; // Para que no seleccione el primer valor automáticamente
                }
                else
                {
                    comboBox_Jerarquia.Enabled = false;
                    comboBox_Jerarquia.DataSource = null;
                }
            };

            // Configurar el ComboBox_Jerarquia inicialmente como desactivado
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;
        }

        /// <summary>
        /// Configura el autocompletado 
        /// </summary>
        private void ConfigurarAutocompletado()
        {
            foreach (Control control in GetAllControls(this))
            {
                if (control is CustomTextBox or CustomComboBox)
                {
                    autocompletar.ConfigureAutoComplete(control);
                }
            }
        }

        /// <summary>
        /// Método recursivo para buscar controles dentro de contenedores como Panel, GroupBox, etc.
        /// </summary>
        /// <param name="parent"></param>
        // En BaseFormDatos
        protected static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (var child in GetAllControls(control))
                {
                    yield return child;
                }
            }
        }

        #endregion

    }
}


 



