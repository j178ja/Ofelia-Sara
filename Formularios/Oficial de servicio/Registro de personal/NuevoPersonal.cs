using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using MySql.Data.MySqlClient;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Controles.Controles.General;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Ofelia_Sara.Controles.General.CustomComboBox;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Registro_de_personal
{
    public partial class NuevoPersonal : BaseForm
    {
        #region VARIABLES

        // Variables para rastrear el estado de los paneles
        private bool panelExpandido_DatosPersonales = true;
        private bool panelExpandido_Revista = true;
        private bool panelExpandido_Armamento = true;
        private bool panelExpandido_Destino = true;

        // Altura original y contraída de los paneles (es usado para cuando se reduce y se amplia el panel)
        private int alturaOriginalPanel_DatosPersonales;
        private int alturaOriginalPanel_Revista;
        private int alturaOriginalPanel_Armamento;
        private int alturaOriginalPanel_Destino;
        private int alturaContraidaPanel = 30; //establece altura minima del panel contraido

        // Estado de los datos
        private bool datosGuardados = false;//Inicializa en false para despues hacer verificacion y asi mostrar o no formclosed
        private static string mensajeError;

        #endregion

        #region CONSTRUCTOR
        public NuevoPersonal(string numeroLegajo)
        {
            InitializeComponent();
            // Asigna el valor recibido al TextBox correspondiente en NuevoPersonal
            textBox_NumeroLegajo.TextValue = numeroLegajo;

      

            this.Load += new System.EventHandler(this.NuevoPersonal_Load);


            //traer label al frent
           
            label_SituacionRevista.BringToFront();
            label_Armamento.BringToFront();
            label_Destino.BringToFront();

        }

        public NuevoPersonal()
        {
            InitializeComponent();

        }

        #endregion

        #region LOAD 
        private void NuevoPersonal_Load(object sender, EventArgs e)
        {
           
        
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
            //---Inicializar para desactivar los btn AGREGAR PERSONAL RATIFICACION 
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.TextValue);


            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad
                                                                                   // Asegura la asociación del método MostrarAntiguedad al evento OnCalcularAntiguedad
            dateTimePicker_Antiguedad.OnCalcularAntiguedad = MostrarAntiguedad;

            comboBox_EstadoCivil.DropDownStyle = CustomComboBoxStyle.DropDownList;//descctivar ingreso de datos en estado civil

            this.Shown += Focus_Shown;//para que haga foco en un textBox

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarPersonal, "Ingrese un numero de LEGAJO vàlido para verificar informaciòn.", "Verificar datos de Legajo Ingresado.");

            ToolTipGeneral.Mostrar(btn_AmpliarReducir_DATOSPERSONALES, "Ampliar/Reducir DATOS PERSONALES.");
            ToolTipGeneral.Mostrar(btn_AmpliarReducir_REVISTA, "Ampliar/Reducir SITUACIÓN DE REVISTA.");
            ToolTipGeneral.Mostrar(btn_AmpliarReducir_ARMAMENTO, "Ampliar/Reducir ARMAMENTO.");
            ToolTipGeneral.Mostrar(btn_AmpliarReducir_DESTINO, "Ampliar/Reducir DESTINO LABORAL.");

            //traer label al frent
          
            label_SituacionRevista.BringToFront();
            label_Armamento.BringToFront();
            label_Destino.BringToFront();

            //// Guardar la altura original del panel
            alturaOriginalPanel_DatosPersonales = panel_DatosPersonales.Height;
            alturaOriginalPanel_Revista = panel_Revista.Height;
            alturaOriginalPanel_Armamento = panel_Armamento.Height;
            alturaOriginalPanel_Destino = panel_Destino.Height;

            //para que se carge el panel ARMAMENTO contraido
            if (panelExpandido_Armamento)
            {
                // Contraer el panel
                panel_Armamento.Height = alturaContraidaPanel;
                btn_AmpliarReducir_ARMAMENTO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Armamento = false; //PANEL CONTRAIDO
                panel_Armamento.BorderStyle = BorderStyle.FixedSingle;

                // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                btn_AmpliarReducir_ARMAMENTO.Parent = panel_Armamento;
                btn_AmpliarReducir_ARMAMENTO.Location = new System.Drawing.Point(646, 1);
                // Ocultar todos los controles excepto el botón de ampliación/reducción
                foreach (Control control in panel_Detalle_Armamento.Controls)
                {
                    if (control == btn_AmpliarReducir_ARMAMENTO)
                    {
                        control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                    }
                    else
                    {
                        control.Visible = false; // Oculta los demás controles
                        panel_Detalle_Armamento.Visible = false;
                    }
                }
                AjustarTamanoFormulario();
            }

            //para actualizar picture de cada panel y color de borde y label

            InicializarValidaciones();//revisa los paneles y cambia su estado de acuerdo si esta completo o no 

            ConfigurarTextoEnControles();//para formato de texto que ingresa

            this.FormClosing += NuevoPersonal_FormClosing;

            // Configurar eventos para cada panel
            ConfigurarEventosDeValidacion(panel_DatosPersonales, label_DatosPersonales);
            ConfigurarEventosDeValidacion(panel_Revista, label_SituacionRevista);
            ConfigurarEventosDeValidacion(panel_Armamento, label_Armamento);
            ConfigurarEventosDeValidacion(panel_Destino, label_Destino);


        }
        #endregion

        #region VALIDACIONES

        /// <summary>
        /// METODO PARA APLICAR FORMATO A TEXTO DE CONTROLES
        /// </summary>
        private void ConfigurarTextoEnControles()
        {
            MayusculaSola.AplicarAControl(textBox_Nombre.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_Apellido.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_LugarNacimiento.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_LocalidadPnal.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_PartidoPnal.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_Funcion.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_LocalidadDependencia.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_PartidoDependencia.InnerTextBox);

            MayusculaSola.AplicarAControl(comboBox_Nacionalidad.InnerTextBox);

            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia.InnerTextBox);

            MayusculaYnumeros.AplicarAControl(textBox_DomicilioPnal.InnerTextBox);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaMarca.InnerTextBox);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaModelo.InnerTextBox);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaNumero.InnerTextBox);

            MayusculaYnumeros.AplicarAControl(textBox_ChalecoMarca.InnerTextBox);
            MayusculaYnumeros.AplicarAControl(textBox_ChalecoModelo.InnerTextBox);
            MayusculaYnumeros.AplicarAControl(textBox_ChalecoNumero.InnerTextBox);
            MayusculaYnumeros.AplicarAControl(textBox_DomicilioDependencia.InnerTextBox);

            ClaseNumeros.AplicarFormatoYLimite(textBox_Dni, 10);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Edad, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_AntiguedadAños, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_AntiguedadMeses, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_NumeroLegajo, 7);
        }
        /// <summary>
        /// VALIDACION  SOLO NUMEROS APLICADA A CAMPO DNI Y EDAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        /// <summary>
        /// CARGA LOS DATOS DE DEPENDENCIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Dependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosDependencia();// Lógica para cargar datos
        }

        /// <summary>
        /// METODO PARA TRAER DE BASE DE DATOS ESCALAFON 
        /// </summary>
        /// <param name="comboBox"></param>
        protected static void ConfigurarComboBoxEscalafon(CustomComboBox customComboBox)
        {
            customComboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }

        /// <summary>
        /// VALIDA EL INGRESO DE TEXTO EN CAMPO DEPENDENCIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el texto del ComboBox está vacío
            if (string.IsNullOrWhiteSpace(comboBox_Dependencia.TextValue))
            {
                LimpiarTextBoxes(); // Limpia los TextBox si no hay texto
            }
        }

        /// <summary>
        /// PARA CARGAR LOS DATOS DE DEPENDENCIA DESDE BASE DE DATOS
        /// </summary>
        private void CargarDatosDependencia()
        {

            if (comboBox_Dependencia.SelectedItem != null)
            {
                // Obtiene el valor seleccionado y extrae el nombre de la dependencia
                string seleccion = comboBox_Dependencia.SelectedItem.ToString();
                string dependenciaSeleccionada = seleccion.Split(' ')[0].Trim(); // Obtiene solo el nombre y elimina espacios

                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                try
                {
                    using var conexion = new MySqlConnection(connectionString);
                    conexion.Open();
                    string consulta = "SELECT Direccion, Localidad, Partido FROM Comisarias WHERE Nombre = @nombreDependencia";

                    using var comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreDependencia", dependenciaSeleccionada);

                    using var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        textBox_DomicilioDependencia.TextValue = lector["Direccion"].ToString();
                        textBox_LocalidadDependencia.TextValue = lector["Localidad"].ToString();
                        textBox_PartidoDependencia.TextValue = lector["Partido"].ToString();

                        // Establecer los TextBox como no editables
                        textBox_DomicilioDependencia.ReadOnly = true;
                        textBox_LocalidadDependencia.ReadOnly = true;
                        textBox_PartidoDependencia.ReadOnly = true;
                    }
                    else
                    {
                        MensajeGeneral.Mostrar("No se encontraron datos para la dependencia seleccionada.", MensajeGeneral.TipoMensaje.Advertencia);
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar("Error al cargar los datos de la dependencia: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
            else
            {
                // Limpia los TextBox si no hay selección válida y los habilita para edición
                LimpiarTextBoxes();
            }
        }

        /// <summary>
        /// MARCAR ERROR EN CASO DE NO SE INGRESE LA CANTIDAD DE CARACTERES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Dni_Leave(object sender, EventArgs e)
        {
            if (sender is CustomTextBox customTextBox)
            {
                // Validar si el TextValue tiene exactamente 10 caracteres
                if (string.IsNullOrWhiteSpace(customTextBox.TextValue) || customTextBox.TextValue.Length != 10)
                {
                    // Mostrar error con subrayado rojo
                    customTextBox.ShowError = true;
                }
                else
                {
                    // Quitar el error si la validación pasa
                    customTextBox.ShowError = false;
                }

                // Forzar el redibujado del control para reflejar el cambio en el subrayado
                customTextBox.Invalidate();
            }
        }

        /// <summary>
        /// METODO QUE HABILITA EL INGRESO DE NUMERO COMO NUMERO DE LEGAJO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_NumeroLegajo_TextChanged(object sender, EventArgs e)
        {
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.TextValue);//habilita el btn_AgregarPersonal en caso de tener texto
        }

        /// <summary>
        /// METODO DE VALIDACION SI EL NUMERO PERTENECE A UN LEGAJO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarPersonal_Click(object sender, EventArgs e)
        {
            // Validar que el texto no sea menor a 6 caracteres
            string textoFormateado = textBox_NumeroLegajo.TextValue;
            if (textoFormateado.Length < 6)
            {
                MensajeGeneral.Mostrar("El número no corresponde a un número de legajo válido, verifique que el número sea correcto.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                try
                {
                    // Crear una instancia de PersonalManager para interactuar con la base de datos
                    PersonalManager personalManager = new();

                    // Verificar si el número de legajo existe en la base de datos
                    if (!personalManager.ExisteLegajo(textoFormateado))
                    {
                        MensajeGeneral.Mostrar("El número de legajo ingresado no corresponde a un efectivo policial registrado", MensajeGeneral.TipoMensaje.Advertencia);
                        textBox_NumeroLegajo.Focus();
                    }
                    else
                    {
                        // Obtener el DTO del personal por legajo
                        PersonalDTO personalDTO = personalManager.ObtenerPersonalDTOPorLegajo(textoFormateado);

                        // Verificar si se obtuvo el DTO correctamente
                        if (personalDTO != null)
                        { // Asignar los valores del DTO a los controles del formulario
                            textBox_Dni.TextValue = personalDTO.DNI ?? "00.000.000";
                            textBox_Nombre.TextValue = personalDTO.Nombres;
                            textBox_Apellido.TextValue = personalDTO.Apellido;


                            textBox_DomicilioPnal.TextValue = personalDTO.Domicilio ?? "NO ESPECIFICADO";
                            textBox_LocalidadPnal.TextValue = personalDTO.Localidad ?? "NO ESPECIFICADO";
                            textBox_PartidoPnal.TextValue = personalDTO.Partido ?? "NO ESPECIFICADO";
                            comboBox_Nacionalidad.SelectedItem = personalDTO.Nacionalidad ?? "NO ESPECIFICADO";
                            if (comboBox_Nacionalidad.SelectedItem == null && comboBox_Nacionalidad.Items.Count > 0)
                                comboBox_Nacionalidad.SelectedIndex = 0;  // O establecer un valor específico

                            comboBox_Escalafon.SelectedItem = personalDTO.Escalafon;
                            if (comboBox_Escalafon.SelectedItem == null && comboBox_Escalafon.Items.Count > 0)
                                comboBox_Escalafon.SelectedIndex = 0;

                            comboBox_Jerarquia.SelectedItem = personalDTO.Jerarquia;
                            if (comboBox_Jerarquia.SelectedItem == null && comboBox_Jerarquia.Items.Count > 0)
                                comboBox_Jerarquia.SelectedIndex = 0;

                            textBox_Funcion.TextValue = personalDTO.Funcion;
                            comboBox_Dependencia.SelectedItem = personalDTO.Dependencia ?? "NO ESPECIFICADO";
                            if (comboBox_Dependencia.SelectedItem == null && comboBox_Dependencia.Items.Count > 0)
                                comboBox_Dependencia.SelectedIndex = 0;

                            textBox_LocalidadDependencia.TextValue = personalDTO.LocalidadDependencia;
                            textBox_DomicilioDependencia.TextValue = personalDTO.Domicilio_Dependencia ?? "NO ESPECIFICADO";
                            textBox_PartidoDependencia.TextValue = personalDTO.Partido_Dependencia ?? "NO ESPECIFICADO";


                        }
                        else
                        {
                            MensajeGeneral.Mostrar("No se encontraron datos para el número de legajo proporcionado.", MensajeGeneral.TipoMensaje.Advertencia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar("Error al conectar con la base de datos: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }

        //-----ACTIVACION DE BORDE Y CAMBIO DE IMAGEN INDICADORA

        /// <summary>
        /// Método genérico para validar campos dentro de PanelConBordeNeon y actualizar el estado visual.
        /// </summary>
        private static void ValidarPanelConBorde(PanelConBordeNeon panelConBorde, Label label)
        {
            bool camposValidos = VerificarCamposEnPanel(panelConBorde);

            // Obtener o generar dinámicamente el PictureBox
            PictureBox pictureBox = IndicadorEstadoFormulario(label);

            // Asignar imagen según validación
            pictureBox.Image = camposValidos
                ? Properties.Resources.verificacion_exitosa
                : Properties.Resources.Advertencia_Faltante;

            //  Actualizar color de fondo del Label
            label.BackColor = camposValidos
                ? Color.FromArgb(4, 200, 0)  // Verde brillante si todo está correcto
                : Color.FromArgb(0, 192, 192); // Verde agua si falta algo

            // Cambiar el estado del borde del PanelConBordeNeon
            panelConBorde.CambiarEstado(panelConBorde.EstaContraido, camposValidos);
        }

        /// <summary>
        /// Verifica si todos los CustomTextBox y CustomComboBox dentro de un PanelConBordeNeon están completos.
        /// </summary>
        private static bool VerificarCamposEnPanel(PanelConBordeNeon panelConBordeNeon)
        {
            foreach (Control control in panelConBordeNeon.Controls)
            {
                // Si hay un Panel dentro del PanelConBordeNeon
                if (control is Panel panel)
                {
                    foreach (Control childControl in panel.Controls)
                    {
                        if (childControl is CustomTextBox customTextBox && string.IsNullOrWhiteSpace(customTextBox.TextValue))
                            return false; // CustomTextBox vacío

                        if (childControl is CustomComboBox customComboBox &&
                            (customComboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(customComboBox.TextValue)))
                            return false; // CustomComboBox sin selección
                    }
                }
            }
            return true; // Todos los campos están completos
        }

        /// <summary>
        /// Configura eventos Leave en todos los CustomTextBox y CustomComboBox dentro de un PanelConBordeNeon.
        /// </summary>
        private static void ConfigurarEventosDeValidacion(PanelConBordeNeon panel, Label label)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Panel panelInterno)
                {
                    foreach (Control childControl in panelInterno.Controls)
                    {
                        if (childControl is CustomTextBox customTextBox)
                        {
                            customTextBox.Leave += (s, e) => ValidarPanelConBorde(panel, label);
                            customTextBox.TextChanged += (s, e) => ValidarPanelConBorde(panel, label);
                        }
                        else if (childControl is CustomComboBox customComboBox)
                        {
                            customComboBox.Leave += (s, e) => ValidarPanelConBorde(panel, label);
                            customComboBox.SelectedIndexChanged += (s, e) => ValidarPanelConBorde(panel, label);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Configura validaciones para todos los PanelConBordeNeon en el formulario.
        /// </summary>
        private void InicializarValidaciones()
        {
            ConfigurarEventosDeValidacion(panel_DatosPersonales, label_DatosPersonales);
            ConfigurarEventosDeValidacion(panel_Revista, label_SituacionRevista);
            ConfigurarEventosDeValidacion(panel_Armamento, label_Armamento);
            ConfigurarEventosDeValidacion(panel_Destino, label_Destino);
        }

        #endregion

        #region METODOS GENERALES
        /// <summary>
        /// METODO PARA QUE TENCA EL FOCO NUMERO DE LEGAJO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox
            textBox_NumeroLegajo.Focus();
        }

        /// <summary>
        /// HELPBUTTON -MENSAJE DE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Debe completar la totalidad de los campos requeridos." + "Todos ellos serán empleados para completar plantilla de Ratificación policial");
        }

        /// <summary>
        /// PARA LIMPIAR FORMULARIO Y MODIFICA BASE DE DATOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
       
            EstadoInicialPaneles();
            InicializarValidaciones();//vuelve a colocar imagen y borde rojo
       
        }

        /// <summary>
        /// Tamaño inicial de paneles 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstadoInicialPaneles()
        {
            //para que se carge el panel ARMAMENTO contraido
            if (panelExpandido_Armamento)
            {
                // Contraer el panel
                panel_Armamento.Height = alturaContraidaPanel;
                btn_AmpliarReducir_ARMAMENTO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Armamento = false; //PANEL CONTRAIDO
                panel_Armamento.BorderStyle = BorderStyle.FixedSingle;

                // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                btn_AmpliarReducir_ARMAMENTO.Parent = panel_Armamento;
                btn_AmpliarReducir_ARMAMENTO.Location = new System.Drawing.Point(646, 1);
                // Ocultar todos los controles excepto el botón de ampliación/reducción
                foreach (Control control in panel_Detalle_Armamento.Controls)
                {
                    if (control == btn_AmpliarReducir_ARMAMENTO)
                    {
                        control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                    }
                    else
                    {
                        control.Visible = false; // Oculta los demás controles
                        panel_Detalle_Armamento.Visible = false;
                    }
                }
                AjustarTamanoFormulario();
            }
        }

        /// <summary>
        /// METODO DE LIMPIEZA DE TEXTBOXES
        /// </summary>
        private void LimpiarTextBoxes()
        {
            textBox_DomicilioDependencia.Clear();
            textBox_LocalidadDependencia.Clear();
            textBox_PartidoDependencia.Clear();

            // También puedes habilitar los TextBox si es necesario
            textBox_DomicilioDependencia.ReadOnly = false;
            textBox_LocalidadDependencia.ReadOnly = false;
            textBox_PartidoDependencia.ReadOnly = false;
        }
        /// <summary>
        /// METODO PARA MOSTRAR QUE NO SE PUEDE MODIFICAR EL CAMPO DOMICILIO DE DEPENDENCIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DatosDependencia_Enter(object sender, EventArgs e)
        {
            if (textBox_DomicilioDependencia.ReadOnly) // se dejo con ese textBox ya que no es necesario especificar uno por uno
            {
                MensajeGeneral.Mostrar("Para modificar este elemento debe hacerlo desde el botón Configuracion, en el menu principal.", MensajeGeneral.TipoMensaje.Informacion);
                comboBox_Dependencia.Focus(); // Vuelve a enfocar el control
            }
        }

        /// <summary>
        /// METODO PARA GUARDAR DATOS DE FORMULARIO EN BASE DE DATOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            InicializarValidaciones(); // verifica que los paneles esten completos

            // Validar los campos en los paneles con borde neon
            if (!VerificarCamposEnPanel(panel_DatosPersonales) ||
                !VerificarCamposEnPanel(panel_Armamento) ||
                !VerificarCamposEnPanel(panel_Revista) ||
                !VerificarCamposEnPanel(panel_Destino))
            {
                MensajeGeneral.Mostrar("Por favor, complete todos los campos obligatorios.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Detener el proceso de guardado
            }
            try
            {
                // Crear el objeto Personal con los datos del formulario
                Personal personal = new()
                {
                    // Si el DNI está vacío, asignamos un valor predeterminado o lo dejamos como null
                    DNI = string.IsNullOrEmpty(textBox_Dni.TextValue) ? null : textBox_Dni.TextValue,

                    // Si el Domicilio está vacío, asignamos un valor predeterminado o lo dejamos como null
                    Domicilio = string.IsNullOrEmpty(textBox_DomicilioPnal.TextValue) ? null : textBox_DomicilioPnal.TextValue,

                    // Verificamos si el comboBox tiene una selección válida
                    Nacionalidad = comboBox_Nacionalidad.SelectedItem != null ? comboBox_Nacionalidad.SelectedItem.ToString() : null,
                    Escalafon = comboBox_Escalafon.SelectedItem != null ? comboBox_Escalafon.SelectedItem.ToString() : null,
                    Jerarquia = comboBox_Jerarquia.SelectedItem != null ? comboBox_Jerarquia.SelectedItem.ToString() : null,

                    // Si la función está vacía, asignamos un valor predeterminado o lo dejamos como null
                    Funcion = string.IsNullOrEmpty(textBox_Funcion.TextValue) ? null : textBox_Funcion.TextValue,
                };

                // Llamar al método UpdatePersonal para actualizar los datos en la base de datos
                PersonalManager personalManager = new();
                personalManager.UpdatePersonal(personal);

                // Mostrar mensaje de éxito
                MensajeGeneral.Mostrar("Datos actualizados correctamente.", MensajeGeneral.TipoMensaje.Exito);
                datosGuardados = true; // Marcar que los datos fueron guardados
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre alguna excepción
                MensajeGeneral.Mostrar("Error al actualizar los datos: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                datosGuardados = false; // Marcar que los datos no fueron guardados
            }
        }

        /// <summary>
        /// MENSAJE DE ALERTA para verificar si los datos están guardados antes de cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
               MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
            }
        }

        /// <summary>
        /// METODO PARA MOSTRAR LA ANTIGUEDAD CALCULADA
        /// </summary>
        /// <param name="años"></param>
        /// <param name="meses"></param>
        public void MostrarAntiguedad(int años, int meses)
        {
            textBox_AntiguedadAños.TextValue = años.ToString();
            textBox_AntiguedadMeses.TextValue = meses.ToString();
        }

        /// <summary>
        /// CAMBIAR TEXTO SEGUN CONTROL ---A VERIFICAR PARA SU REMOSION SE AGREGO EN .CS DE CALENDARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_FechaNacimiento_Load(object sender, EventArgs e)
        {
            dateTimePicker_FechaNacimiento.TextoAsociado = "Fecha Nacimiento";
        }

        /// <summary>
        /// CAMBIAR TEXTO SEGUN CONTROL ---A VERIFICAR PARA SU REMOSION SE AGREGO EN .CS DE CALENDARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_Antiguedad_Load(object sender, EventArgs e)
        {
            dateTimePicker_Antiguedad.TextoAsociado = "Fecha Ingreso";

        }

        #endregion

        #region COMPORTAMIENTO DINAMICO
        /// <summary>
        /// METODOS PARA LOS BOTONES AMPLIAR Y REDUCIR PANELES
        /// </summary>
        /// <param name="sender"></param>
        ///<param name="e"></param>
        public void AlternarPanel(PanelConBordeNeon panelConNeon, Panel panelDetalle, ref bool panelExpandido,
                                   Button btnAmpliarReducir, Image imgExpandir, Image imgContraer,
                                   int alturaOriginal, int alturaContraida)
        {
            if (panelConNeon == null || panelDetalle == null || btnAmpliarReducir == null)
                return;

            if (panelExpandido)
            {

                //  CONTRAER EL PANEL
                panelConNeon.Height = alturaContraida;
                btnAmpliarReducir.Image = imgExpandir; // Flecha abajo
                panelExpandido = false;

                // Cambiar el borde a contraído
                panelConNeon.CambiarEstado(true, false);

                // Mover el botón al panel principal (padre)
                btnAmpliarReducir.Parent = panelConNeon;
                btnAmpliarReducir.Location = new System.Drawing.Point(646, 1);

                // Ocultar todos los controles dentro del `panel_Detalle`, excepto el botón de ampliación
                foreach (Control control in panelDetalle.Controls)
                {
                    control.Visible = control == btnAmpliarReducir;
                }

                panelDetalle.Visible = false;
            }
            else
            {
                //  EXPANDIR EL PANEL
                panelConNeon.Height = alturaOriginal;
                panelConNeon.BorderStyle = BorderStyle.None;
                btnAmpliarReducir.Image = imgContraer; // Flecha arriba
                panelExpandido = true;
                panelDetalle.Visible = true;

                // Cambiar el borde a expandido
                panelConNeon.CambiarEstado(false, false);

                // Mover el botón dentro del `panel_Detalle`
                btnAmpliarReducir.Parent = panelDetalle;
                btnAmpliarReducir.Location = new System.Drawing.Point(646, 1);

                // Mostrar todos los controles dentro del `panel_Detalle`
                foreach (Control control in panelDetalle.Controls)
                {
                    control.Visible = true;
                }
            }

            // Ajustar tamaño del formulario después del cambio
            AjustarTamanoFormulario();
        }

        /// <summary>
        /// EVENTOS PARA AMPLIAR Y REDUCIR CADA PANEL ESPECIFICO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AmpliarReducir_DATOSPERSONALES_Click(object sender, EventArgs e)
        {
            AlternarPanel(panel_DatosPersonales, panel_Detalle_Personal, ref panelExpandido_DatosPersonales,
                          btn_AmpliarReducir_DATOSPERSONALES, Properties.Resources.dobleFlechaABAJO, Properties.Resources.dobleFlechaARRIBA,
                          alturaOriginalPanel_DatosPersonales, alturaContraidaPanel);
            InicializarValidaciones();//revisa los paneles y cambia su estado de acuerdo si esta completo o no 
        }

        private void Btn_AmpliarReducir_SITUACIONREVISTA_Click(object sender, EventArgs e)
        {
            AlternarPanel(panel_Revista, panel_Detalle_Revista, ref panelExpandido_Revista,
                          btn_AmpliarReducir_REVISTA, Properties.Resources.dobleFlechaABAJO, Properties.Resources.dobleFlechaARRIBA,
                          alturaOriginalPanel_Revista, alturaContraidaPanel);
            InicializarValidaciones();//revisa los paneles y cambia su estado de acuerdo si esta completo o no

        }

        private void Btn_AmpliarReducir_ARMAMENTO_Click(object sender, EventArgs e)
        {
            AlternarPanel(panel_Armamento, panel_Detalle_Armamento, ref panelExpandido_Armamento,
                          btn_AmpliarReducir_ARMAMENTO, Properties.Resources.dobleFlechaABAJO, Properties.Resources.dobleFlechaARRIBA,
                          alturaOriginalPanel_Armamento, alturaContraidaPanel);
            InicializarValidaciones();//revisa los paneles y cambia su estado de acuerdo si esta completo o no 
        }

        private void Btn_AmpliarReducir_DESTINO_Click(object sender, EventArgs e)
        {
            AlternarPanel(panel_Destino, panel_Detalle_Destino, ref panelExpandido_Destino,
                          btn_AmpliarReducir_DESTINO, Properties.Resources.dobleFlechaABAJO, Properties.Resources.dobleFlechaARRIBA,
                          alturaOriginalPanel_Destino, alturaContraidaPanel);
            InicializarValidaciones();//revisa los paneles y cambia su estado de acuerdo si esta completo o no 
        }

        /// <summary>
        /// CREA UNA INSTANCIA DE PICKTURE PARA EL INDICADOR DE FORMULARIO COMPLETO E INCOMPLETO
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private static PictureBox IndicadorEstadoFormulario(Label label)
        {
            PictureBox pictureBox = label.Parent.Controls
                .OfType<PictureBox>()
                .FirstOrDefault(pb => pb.Tag != null && pb.Tag.ToString() == label.Name);

            // Si no existe, crearlo dinámicamente
            if (pictureBox == null)
            {
                pictureBox = new PictureBox
                {
                    Size = new Size(34, 25),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    Tag = label.Name // Identificador único
                };

                // Agregarlo al mismo contenedor del Label
                label.Parent.Controls.Add(pictureBox);
            }

            // Eliminar eventos previos para evitar duplicación
            pictureBox.MouseEnter -= PictureBox_MouseEnter;
            pictureBox.MouseEnter += PictureBox_MouseEnter;

            pictureBox.MouseLeave -= PictureBox_MouseLeave;
            pictureBox.MouseLeave += PictureBox_MouseLeave;

            // Ajustar posición al lado derecho del Label
            pictureBox.Location = new Point(
                label.Right + 5,
                label.Top + (label.Height - pictureBox.Height) / 2 - 3
            );

            // Asegurar que esté visible
            pictureBox.Visible = true;
            pictureBox.BringToFront();

            return pictureBox;
        }

        // Evento para mostrar el TooltipError cuando el mouse entra
        private static void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Image == Properties.Resources.Advertencia_Faltante)
            {
                // TooltipError.Mostrar(pictureBox, "El formulario posee campos incompletos.");
            }
        }

        // Evento para ocultar el TooltipError cuando el mouse sale
        private static void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            // TooltipError.Ocultar();
        }

        /// <summary>
        /// METODO PARA AJUSTAR TAMAÑO DE FORMULARIO Y REPOSICIONAR PANELES
        /// </summary>
        private void AjustarTamanoFormulario()
        {
            int posicionVertical = 65; // Comienza desde la parte superior de panel1

            // Ajustar posición de panel DATOS PERSONALES
            if (panel_DatosPersonales.Visible)
            {
                panel_DatosPersonales.Location = new System.Drawing.Point(panel_DatosPersonales.Location.X, posicionVertical);
                posicionVertical += panel_DatosPersonales.Height;
                // Agregar separación de 10 píxeles entre panel_Instruccion y panel_SeleccionVisu
                posicionVertical += 5;
            }

            // Ajustar posición de panel REVISTA
            if (panel_Revista.Visible)
            {
                panel_Revista.Location = new System.Drawing.Point(panel_Revista.Location.X, posicionVertical);
                posicionVertical += panel_Revista.Height;
                posicionVertical += 5;
            }

            // Ajustar posición de panel ARMAMENTO
            if (panel_Armamento.Visible)
            {
                panel_Armamento.Location = new System.Drawing.Point(panel_Armamento.Location.X, posicionVertical);
                posicionVertical += panel_Armamento.Height;
                posicionVertical += 5;
            }

            // Ajustar posición de panel DESTINO
            if (panel_Destino.Visible)
            {
                panel_Destino.Location = new System.Drawing.Point(panel_Destino.Location.X, posicionVertical);
                posicionVertical += panel_Destino.Height;

            }

            // Ajustar posición de panel_ControlesInferiores
            panel_ControlesInferiores.Location = new System.Drawing.Point(panel_ControlesInferiores.Location.X, posicionVertical);
            posicionVertical += panel_ControlesInferiores.Height;

            // Ajustar la altura de panel1 para que se ajuste al contenido visible
            panel1.Height = posicionVertical;

            // Ajustar la altura del formulario sumando un margen adicional de 20 px
            this.Height = panel1.Location.Y + panel1.Height + 75;


            // Activar scroll si la altura del formulario supera los 800 píxeles
            if (this.Height > 800)
            {
                this.AutoScroll = true;
            }
            else
            {
                this.AutoScroll = false;
            }
        }
        #endregion

       
    }
}
