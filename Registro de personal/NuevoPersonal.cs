using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using Clases.Botones;
using Clases.Texto;
using Controles.Controles.Aplicadas_con_controles;
using MySql.Data.MySqlClient;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Mensajes;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class NuevoPersonal : BaseForm
    {
        private bool panelExpandido_DatosPersonales = true;// Variable para rastrear el estado del panel
        private bool panelExpandido_Revista = true;// 
        private bool panelExpandido_Armamento = true;// 
        private bool panelExpandido_Descripcion = true;// 
        private bool panelExpandido_Destino = true;// 

        // Altura original y contraída del panel
        private int alturaOriginalPanel_DatosPersonales;
        private int alturaOriginalPanel_Revista;
        private int alturaOriginalPanel_Armamento;
        private int alturaOriginalPanel_Descripcion;
        private int alturaOriginalPanel_Destino;
        private int alturaContraidaPanel = 30;

        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public NuevoPersonal(string numeroLegajo)
        {
            InitializeComponent();
            // Asigna el valor recibido al TextBox correspondiente en NuevoPersonal
            textBox_NumeroLegajo.Text = numeroLegajo;

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            configurarTextoEnControles();//para formato de texto que ingresa

            this.Load += new System.EventHandler(this.NuevoPersonal_Load);

            CargarDatosDependencia(comboBox_Dependencia, dbManager);//para cargar desde base de datos

            this.FormClosing += NuevoPersonal_FormClosing;

            //traer label al frent
            label_TITULO.BringToFront();
            label_SituacionRevista.BringToFront();
            label_Armamento.BringToFront();
            label_DestinoLaboral.BringToFront();
             //cargar con picture no visible
             pictureBox_DatosPersonales.Visible = false;
            pictureBox_SituacionRevista.Visible = false;
            pictureBox_Armamento.Visible = false;
            pictureBox_SituacionRevista.Visible=false;
        }


        public NuevoPersonal()
        {
            InitializeComponent();

        }
        //--FIN CONSTRUCTOR



        private void NuevoPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Limpiar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
            //---Inicializar para desactivar los btn AGREGAR PERSONAL RATIFICACION 
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);


            //para que se despliege la lista en los comboBox ESCALAFON -JERARQUIA
            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad
                                                                                   // Asegura la asociación del método MostrarAntiguedad al evento OnCalcularAntiguedad
            dateTimePicker_Antiguedad.OnCalcularAntiguedad = MostrarAntiguedad;

            comboBox_EstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;//descctivar ingreso de datos en estado civil

            numeroTelefonicoControl1.ControlWidth = 159;
            numeroTelefonicoControl2.ControlWidth = 159;
            this.Shown += Focus_Shown;//para que haga foco en un textBox

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarPersonal, "Ingrese un numero de LEGAJO vàlido para verificar informaciòn.", "Verificar datos de Legajo Ingresado.");

            ToolTipGeneral.ShowToolTip(btn_AmpliarReducir_DATOSPERSONALES, "Ampliar/Reducir DATOS PERSONALES.");
            ToolTipGeneral.ShowToolTip(btn_AmpliarReducir_REVISTA, "Ampliar/Reducir SITUACIÓN DE REVISTA.");
            ToolTipGeneral.ShowToolTip(btn_AmpliarReducir_ARMAMENTO, "Ampliar/Reducir ARMAMENTO.");
            ToolTipGeneral.ShowToolTip(btn_AmpliarReducir_DESTINO, "Ampliar/Reducir DESTINO LABORAL.");

            //traer label al frent
            label_TITULO.BringToFront();
            label_SituacionRevista.BringToFront();
            label_Armamento.BringToFront();
            label_DestinoLaboral.BringToFront();

            //.....................................................
            //// Guardar la altura original del panel
            alturaOriginalPanel_DatosPersonales = panel_DatosPersonales.Height;
            alturaOriginalPanel_Revista = panel_Revista.Height;
            alturaOriginalPanel_Armamento = panel_Armamento.Height;
            alturaOriginalPanel_Destino = panel_Destino.Height;

            //.....................................................
        }
        //--- FIN LOAD----------


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
        //--------------------------------------------------------



        /// <summary>
        /// METODO PARA TRAER DE BASE DE DATOS ESCALAFON 
        /// </summary>
        /// <param name="comboBox"></param>
        protected void ConfigurarComboBoxEscalafon(ComboBox comboBox)
        {
            comboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }
        /// <summary>
        /// HELPBUTTON -MENSAJE DE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MensajeGeneral.Mostrar("Debe completar la totalidad de los campos requeridos." + "Todos ellos serán empleados para completar plantilla de Ratificación policial", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        /// <summary>
        /// PARA LIMPIAR FORMULARIO Y MODIFICA BASE DE DATOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;
            comboBox_Escalafon.SelectedIndex = -1;
            comboBox_Jerarquia.SelectedIndex = -1;
            // Muestra un mensaje de información
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        /// <summary>
        /// VALIDACION PARA NUMERO DE LEGAJO, SOLO NUMEROS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_NumeroLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            ClaseNumeros.AplicarFormatoYLimite(textBox_NumeroLegajo, 7);
        }

        /// <summary>
        /// METODO PARA APLICAR FORMATO A TEXTO DE CONTROLES
        /// </summary>
        private void configurarTextoEnControles()
        {
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_Apellido);
            MayusculaSola.AplicarAControl(textBox_LugarNacimiento);
            MayusculaSola.AplicarAControl(textBox_LocalidadPnal);
            MayusculaSola.AplicarAControl(textBox_PartidoPnal);
            MayusculaSola.AplicarAControl(textBox_Funcion);
            MayusculaSola.AplicarAControl(textBox_LocalidadDependencia);
            MayusculaSola.AplicarAControl(textBox_PartidoDependencia);

            MayusculaSola.AplicarAControl(comboBox_Nacionalidad);

            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            MayusculaYnumeros.AplicarAControl(textBox_DomicilioPnal);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaMarca);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaModelo);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaNumero);

            MayusculaYnumeros.AplicarAControl(textBox_ChalecoMarca);
            MayusculaYnumeros.AplicarAControl(textBox_ChalecoModelo);
            MayusculaYnumeros.AplicarAControl(textBox_ChalecoNumero);
            MayusculaYnumeros.AplicarAControl(textBox_DomicilioDependencia);

            ClaseNumeros.AplicarFormatoYLimite(textBox_Dni, 10);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Edad, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_AntiguedadAños, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_AntiguedadMeses, 2);
        }
        /// <summary>
        /// VALIDACION PARA NUMERO DE DNI - SOLO NUMEROS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }


        /// <summary>
        /// VALIDACION PARA CAMPO EDAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void textBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
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
        /// VALIDA EL INGRESO DE TEXTO EN CAMPO DEPENDENCIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el texto del ComboBox está vacío
            if (string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
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
                    using (var conexion = new MySqlConnection(connectionString))
                    {
                        conexion.Open();
                        string consulta = "SELECT Direccion, Localidad, Partido FROM Comisarias WHERE Nombre = @nombreDependencia";

                        using (var comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@nombreDependencia", dependenciaSeleccionada);

                            using (var lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    textBox_DomicilioDependencia.Text = lector["Direccion"].ToString();
                                    textBox_LocalidadDependencia.Text = lector["Localidad"].ToString();
                                    textBox_PartidoDependencia.Text = lector["Partido"].ToString();

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
                        }
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
        private void textBox_DatosDependencia_Enter(object sender, EventArgs e)
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
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear el objeto Personal con los datos del formulario
                Personal personal = new Personal
                {
                    // Si el DNI está vacío, asignamos un valor predeterminado o lo dejamos como null
                    DNI = string.IsNullOrEmpty(textBox_Dni.Text) ? null : textBox_Dni.Text,

                    // Si el Domicilio está vacío, asignamos un valor predeterminado o lo dejamos como null
                    Domicilio = string.IsNullOrEmpty(textBox_DomicilioPnal.Text) ? null : textBox_DomicilioPnal.Text,

                    // Verificamos si el comboBox tiene una selección válida
                    Nacionalidad = comboBox_Nacionalidad.SelectedItem != null ? comboBox_Nacionalidad.SelectedItem.ToString() : null,
                    Escalafon = comboBox_Escalafon.SelectedItem != null ? comboBox_Escalafon.SelectedItem.ToString() : null,
                    Jerarquia = comboBox_Jerarquia.SelectedItem != null ? comboBox_Jerarquia.SelectedItem.ToString() : null,

                    // Si la función está vacía, asignamos un valor predeterminado o lo dejamos como null
                    Funcion = string.IsNullOrEmpty(textBox_Funcion.Text) ? null : textBox_Funcion.Text,
                };

                // Llamar al método UpdatePersonal para actualizar los datos en la base de datos
                PersonalManager personalManager = new PersonalManager();
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
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
                {
                    // Hacer visibles los botones
                    mensaje.MostrarBotonesConfirmacion(true);

                    DialogResult result = mensaje.ShowDialog();
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Cancelar el cierre del formulario
                    }
                }
            }
        }

        /// <summary>
        /// METODO QUE HABILITA EL INGRESO DE NUMERO COMO NUMERO DE LEGAJO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_NumeroLegajo_TextChanged(object sender, EventArgs e)
        {
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);//habilita el btn_AgregarPersonal en caso de tener texto
        }

        /// <summary>
        /// METODO DE VALIDACION SI EL NUMERO PERTENECE A UN LEGAJO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AgregarPersonal_Click(object sender, EventArgs e)
        {
            // Validar que el texto no sea menor a 6 caracteres
            string textoFormateado = textBox_NumeroLegajo.Text;
            if (textoFormateado.Length < 6)
            {
                MensajeGeneral.Mostrar("El número no corresponde a un número de legajo válido, verifique que el número sea correcto.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                try
                {
                    // Crear una instancia de PersonalManager para interactuar con la base de datos
                    PersonalManager personalManager = new PersonalManager();

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
                            textBox_Dni.Text = personalDTO.DNI ?? "00.000.000";
                            textBox_Nombre.Text = personalDTO.Nombres;
                            textBox_Apellido.Text = personalDTO.Apellido;


                            textBox_DomicilioPnal.Text = personalDTO.Domicilio ?? "NO ESPECIFICADO";
                            textBox_LocalidadPnal.Text = personalDTO.Localidad ?? "NO ESPECIFICADO";
                            textBox_PartidoPnal.Text = personalDTO.Partido ?? "NO ESPECIFICADO";
                            comboBox_Nacionalidad.SelectedItem = personalDTO.Nacionalidad ?? "NO ESPECIFICADO";
                            if (comboBox_Nacionalidad.SelectedItem == null && comboBox_Nacionalidad.Items.Count > 0)
                                comboBox_Nacionalidad.SelectedIndex = 0;  // O establecer un valor específico

                            comboBox_Escalafon.SelectedItem = personalDTO.Escalafon;
                            if (comboBox_Escalafon.SelectedItem == null && comboBox_Escalafon.Items.Count > 0)
                                comboBox_Escalafon.SelectedIndex = 0;

                            comboBox_Jerarquia.SelectedItem = personalDTO.Jerarquia;
                            if (comboBox_Jerarquia.SelectedItem == null && comboBox_Jerarquia.Items.Count > 0)
                                comboBox_Jerarquia.SelectedIndex = 0;

                            textBox_Funcion.Text = personalDTO.Funcion;
                            comboBox_Dependencia.SelectedItem = personalDTO.Dependencia ?? "NO ESPECIFICADO";
                            if (comboBox_Dependencia.SelectedItem == null && comboBox_Dependencia.Items.Count > 0)
                                comboBox_Dependencia.SelectedIndex = 0;

                            textBox_LocalidadDependencia.Text = personalDTO.LocalidadDependencia;
                            textBox_DomicilioDependencia.Text = personalDTO.Domicilio_Dependencia ?? "NO ESPECIFICADO";
                            textBox_PartidoDependencia.Text = personalDTO.Partido_Dependencia ?? "NO ESPECIFICADO";


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
     /// <summary>
     /// METODO PARA MOSTRAR LA ANTIGUEDAD CALCULADA
     /// </summary>
     /// <param name="años"></param>
     /// <param name="meses"></param>
        public void MostrarAntiguedad(int años, int meses)
        {
            textBox_AntiguedadAños.Text = años.ToString();
            textBox_AntiguedadMeses.Text = meses.ToString();
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// METODOS PARA LOS BOTONES AMPLIAR Y REDUCIR PANELES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_AmpliarReducir_DATOSPERSONALES_Click(object sender, EventArgs e)
        {
            if (panel_DatosPersonales is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_DatosPersonales)
                {
                    // Contraer el panel
                    panel_DatosPersonales.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_DATOSPERSONALES.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_DatosPersonales = false; //PANEL CONTRAIDO

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

                    // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                    btn_AmpliarReducir_DATOSPERSONALES.Parent = panel_DatosPersonales;
                    btn_AmpliarReducir_DATOSPERSONALES.Location = new System.Drawing.Point(561, 1);


                    // Ocultar todos los controles excepto el botón de ampliación/reducción
                    foreach (Control control in panel_Detalle_Personal.Controls)
                    {
                        if (control == btn_AmpliarReducir_DATOSPERSONALES)
                        {
                            control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                        }
                        else
                        {
                            control.Visible = false; // Oculta los demás controles
                            panel_Detalle_Personal.Visible = false;
                        }
                    }

                    // Ocultar controles de error personalizados
                    foreach (Control control in panel_Detalle_Personal.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = false; // Ocultar imágenes de error
                        }
                    }
                }
                else
                {
                    // Expandir el panel
                    panel_DatosPersonales.Height = alturaOriginalPanel_DatosPersonales;
                    panel_DatosPersonales.BorderStyle = BorderStyle.None;
                    btn_AmpliarReducir_DATOSPERSONALES.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                    panelExpandido_DatosPersonales = true;
                    panel_Detalle_Personal.Visible = true;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_DATOSPERSONALES.Parent = panel_Detalle_Personal;
                    btn_AmpliarReducir_DATOSPERSONALES.Location = new System.Drawing.Point(552, 0);

                    // Mostrar todos los controles
                    foreach (Control control in panel_Detalle_Personal.Controls)
                    {
                        control.Visible = true;
                    }

                    // Asegurarte de que las imágenes de error se muestren si es necesario
                    foreach (Control control in panel_Detalle_Personal.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = true; // Mostrar imágenes de error
                        }
                    }
                }
                AjustarTamanoFormulario();
            }

        }

        private void btn_AmpliarReducir_SITUACIONREVISTA_Click(object sender, EventArgs e)
        {
            if (panel_Revista is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Revista)
                {
                    // Contraer el panel
                    panel_Revista.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_REVISTA.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Revista = false; //PANEL CONTRAIDO

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

                    // Cambiar la posición y el padre del botón al panel
                    btn_AmpliarReducir_REVISTA.Parent = panel_Revista;
                    btn_AmpliarReducir_REVISTA.Location = new System.Drawing.Point(561, 1);


                    // Ocultar todos los controles excepto el botón de ampliación/reducción
                    foreach (Control control in panel_Detalle_Revista.Controls)
                    {
                        if (control == btn_AmpliarReducir_REVISTA)
                        {
                            control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                        }
                        else
                        {
                            control.Visible = false; // Oculta los demás controles
                            panel_Detalle_Revista.Visible = false;
                        }
                    }

                    // Ocultar controles de error personalizados
                    foreach (Control control in panel_Detalle_Revista.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = false; // Ocultar imágenes de error
                        }
                    }
                }
                else
                {
                    // Expandir el panel
                    panel_Revista.Height = alturaOriginalPanel_Revista;
                    panel_Revista.BorderStyle = BorderStyle.None;
                    btn_AmpliarReducir_REVISTA.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                    panelExpandido_Revista = true;
                    panel_Detalle_Revista.Visible = true;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_REVISTA.Parent = panel_Detalle_Revista;
                    btn_AmpliarReducir_REVISTA.Location = new System.Drawing.Point(554, 0);

                    // Mostrar todos los controles
                    foreach (Control control in panel_Detalle_Revista.Controls)
                    {
                        control.Visible = true;
                    }

                    // Asegurarte de que las imágenes de error se muestren si es necesario
                    foreach (Control control in panel_Detalle_Revista.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = true; // Mostrar imágenes de error
                        }
                    }
                }
                AjustarTamanoFormulario();
            }

        }


        private void btn_AmpliarReducir_ARMAMENTO_Click(object sender, EventArgs e)
        {
            if (panel_Armamento is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Armamento)
                {
                    // Contraer el panel
                    panel_Armamento.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_ARMAMENTO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Armamento = false; //PANEL CONTRAIDO

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

                    // Cambiar la posición y el padre del botón al panel
                    btn_AmpliarReducir_ARMAMENTO.Parent = panel_Armamento;
                    btn_AmpliarReducir_ARMAMENTO.Location = new System.Drawing.Point(561, 1);


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

                    // Ocultar controles de error personalizados
                    foreach (Control control in panel_Detalle_Armamento.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = false; // Ocultar imágenes de error
                        }
                    }
                }
                else
                {
                    // Expandir el panel
                    panel_Armamento.Height = alturaOriginalPanel_Armamento;
                    panel_Armamento.BorderStyle = BorderStyle.None;
                    btn_AmpliarReducir_ARMAMENTO.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                    panelExpandido_Armamento = true;
                    panel_Detalle_Armamento.Visible = true;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_ARMAMENTO.Parent = panel_Detalle_Armamento;
                    btn_AmpliarReducir_ARMAMENTO.Location = new System.Drawing.Point(554, 1);

                    // Mostrar todos los controles
                    foreach (Control control in panel_Detalle_Armamento.Controls)
                    {
                        control.Visible = true;
                    }

                    // Asegurarte de que las imágenes de error se muestren si es necesario
                    foreach (Control control in panel_Detalle_Armamento.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = true; // Mostrar imágenes de error
                        }
                    }
                }
                AjustarTamanoFormulario();
            }
        }

        private void btn_AmpliarReducir_DESTINO_Click(object sender, EventArgs e)
        {
            if (panel_Destino is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Destino)
                {
                    // Contraer el panel
                    panel_Destino.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_DESTINO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Destino = false; //PANEL CONTRAIDO

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

                    // Cambiar la posición y el padre del botón al panel
                    btn_AmpliarReducir_DESTINO.Parent = panel_Destino;
                    btn_AmpliarReducir_DESTINO.Location = new System.Drawing.Point(561, 1);


                    // Ocultar todos los controles excepto el botón de ampliación/reducción
                    foreach (Control control in panel_Detalle_Destino.Controls)
                    {
                        if (control == btn_AmpliarReducir_DESTINO)
                        {
                            control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                        }
                        else
                        {
                            control.Visible = false; // Oculta los demás controles
                            panel_Detalle_Destino.Visible = false;
                        }
                    }

                    // Ocultar controles de error personalizados
                    foreach (Control control in panel_Detalle_Destino.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = false; // Ocultar imágenes de error
                        }
                    }
                }
                else
                {
                    // Expandir el panel
                    panel_Destino.Height = alturaOriginalPanel_Destino;
                    panel_Destino.BorderStyle = BorderStyle.None;
                    btn_AmpliarReducir_DESTINO.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                    panelExpandido_Destino = true;
                    panel_Detalle_Destino.Visible = true;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_DESTINO.Parent = panel_Detalle_Destino;
                    btn_AmpliarReducir_DESTINO.Location = new System.Drawing.Point(554, 1);

                    // Mostrar todos los controles
                    foreach (Control control in panel_Detalle_Destino.Controls)
                    {
                        control.Visible = true;
                    }

                    // Asegurarte de que las imágenes de error se muestren si es necesario
                    foreach (Control control in panel_Detalle_Destino.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = true; // Mostrar imágenes de error
                        }
                    }
                }
                AjustarTamanoFormulario();
            }
        }
        private bool VerificarCamposEnPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                // Verificar TextBox
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return false; // Campo TextBox incompleto
                }

                // Verificar ComboBox
                if (control is ComboBox comboBox && comboBox.SelectedIndex == -1 && string.IsNullOrWhiteSpace(comboBox.Text))
                {
                    return false; // Campo ComboBox incompleto
                }

                // Verificar RichTextBox
                if (control is RichTextBox richTextBox && string.IsNullOrWhiteSpace(richTextBox.Text))
                {
                    return false; // Campo RichTextBox incompleto
                }

                // Verificar PictureBox
                if (control is PictureBox pictureBox)
                {
                    // Verificar si no hay imagen o si la imagen es la predeterminada
                    if (pictureBox.Image == null || pictureBox.Image == Properties.Resources.agregar_imagen1)
                    {
                        return false; // Campo PictureBox sin imagen válida
                    }
                }
            }
            return true; // Todos los campos están completos
        }


        /// <summary>
        /// METODO PARA VALIDAR DAROS DE LOS PANELES
        /// </summary>

        private void ValidarPanelDatosInstruccion()
        {
            bool camposValidos = true;



            // Iterar sobre los controles dentro del panel
            foreach (Control control in panel_Detalle_Personal.Controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    camposValidos = false;
                    break; // Si encontramos un campo vacío, no es necesario seguir buscando
                }
                else if (control is ComboBox comboBox && (comboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox.Text)))
                {
                    camposValidos = false;
                    break; // Si encontramos un ComboBox sin selección o sin texto, salimos
                }
            }

            // Actualizar la imagen en pictureBox
            if (camposValidos)
            {
                pictureBox_DatosPersonales.Image = Properties.Resources.verificacion_exitosa; // Imagen personalizada para validación correcta
                pictureBox_DatosPersonales.BackColor = Color.Transparent; // Fondo transparente
                label_DatosPersonales.BackColor = Color.FromArgb(4, 200, 0); // resalta con color verde más brillante que el original

            }
            else
            {
                pictureBox_DatosPersonales.Image = Properties.Resources.Advertencia_Faltante; // Imagen para error
                pictureBox_DatosPersonales.BackColor = Color.Transparent; // Fondo transparente
                label_DatosPersonales.BackColor = Color.FromArgb(0, 192, 192); // retoma color original verde agua

            }

            // Ajustar la posición del pictureBox al lado del label
            pictureBox_DatosPersonales.Location = new System.Drawing.Point(
                label_DatosPersonales.Right + 5, // A la derecha del label con un margen de 5 px
                label_DatosPersonales.Top + (label_DatosPersonales.Height - pictureBox_DatosPersonales.Height) / 2 // Centrado verticalmente
            );

            // Configurar el tamaño de la imagen para que abarque todo el contenedor del pictureBox
            pictureBox_DatosPersonales.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asegurarse de que el pictureBox sea visible
            pictureBox_DatosPersonales.Visible = true;
            AjustarTamanoFormulario();
        }

        //------------------------------------------------------------------------------

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
                //posicionVertical += 10; // Agregar separación después de panel_Descripción
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



        //----------------------------------------------------------------------------------



    }
}
