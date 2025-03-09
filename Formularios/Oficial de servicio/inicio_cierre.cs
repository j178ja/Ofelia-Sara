using BaseDatos.Adm_BD;
using BaseDatos.Entidades;
using DocumentFormat.OpenXml.Office2010.Excel;
using Ofelia_Sara.Clases.General.ActualizarElementos;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Conexion;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Clases.GenerarDocumentos;
using Ofelia_Sara.Controles.Controles.Reposicionar_paneles.InicioCierre;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.Formularios.Oficial_de_servicio.Registro_de_personal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;



namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    /// <summary>
    /// FORMULARIO PRINCIPAL CARGA IPP
    /// </summary>
    public partial class InicioCierre : BaseForm
    {
        #region VARIABLES

        private ReposicionarSegunAgregado reposicionador;//para reposicionar paneles
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados

        // Listas para almacenar víctimas e imputados
        private List<string> victimas = [];
        private List<string> imputados = [];

        //Lista para autocompletar caratula
        private List<string> sugerencias;

        private const string ComboBoxFilePath = "comboBoxDependenciaItems.txt"; // Ruta del archivo
        private AgregarDatosPersonalesVictima agregarDatosPersonalesVictima;
        private AgregarDatosPersonalesImputado agregarDatosPersonalesImputado;

        #endregion

        #region CONSTRUCTOR
        public InicioCierre()
        {
            InitializeComponent();
         
            //.para reposicionar paneles
            reposicionador = new ReposicionarSegunAgregado(
            this,
            panel_Ipp,
            panel_Caratula,
            panel_Victima,
            panel_Imputado,
            panel_Instruccion,
            panel_Compromisos,
            panel_ControlesInferiores
            );

            textBox_NumeroIpp.TextChanged += (s, e) => ActualizarEstado();
            textBox_Caratula.TextChanged += (s, e) => ActualizarEstado();
            textBox_Victima.TextChanged += (s, e) => ActualizarEstado();
            textBox_Imputado.TextChanged += (s, e) => ActualizarEstado();

            comboBox_AgenteFiscal.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Instructor.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Secretario.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Dependencia.SelectedIndexChanged += (s, e) => ActualizarEstado();

            InvisibilizarDesactivarControles();//invisibilizar controles al cargar

      
        }
        #endregion

        #region LOAD
        private void InicioCierre_Load(object sender, EventArgs e)
        {

            IncrementarTamaño.Incrementar(btn_SDA);
            IncrementarTamaño.Incrementar(btn_CrearDenuncia);

            // Configurar autocompletado para `textBox_Caratula`
            Autocompletar autocompletarManager = new("autocompletar.json");
            autocompletarManager.ConfigureAutoComplete(textBox_Caratula);

            timePickerPersonalizado1.SelectedDate = DateTime.Now; //para que actualice automaticamente la fecha

            // RegistrarBotonesAgregar(victimas, imputados);//otorga validacion para los botones agregar, agregando un control especifico en panel correspondiente

            ConfigurarTooltip();//agrega la totalidad de tooltip al LOAD

            ActualizarEstado();//PARA LABEL Y CHECK CARGO,labell btn_not247 y btn_StudRML

            Btn_ContadorRML.Text = "0";

            fecha_Pericia.ValidatingType = typeof(DateTime); // Configurar tipo de validación

            SubscribirCaratulaTextchanged();

            BotonDeslizable_247();  // Configurar el delegado de validación

            botonDeslizable_Not247.IsOn = false;// inicializa desactivado
        }
        #endregion

        #region PROPIEDADES PUBLICAS
        /// <summary>
        /// Propiedad pública para acceder al botón
        /// </summary>
        public Boton_Contador BtnContadorRatificaciones
        {  // En InicioCierre, agrega una propiedad pública que devuelva el botón
            get { return btn_ContadorRatificaciones; } // Asegúrate de que esta instancia esté inicializada en el diseñador
        }
        #endregion

        #region CONFIGURACIONES
        /// <summary>
        /// CONTIENE LOS TOOLTIPS DE LOS CONTROLES DEL FORM INICIO-CIERRE
        /// </summary>
        private void ConfigurarTooltip()
        {

            TooltipEnControlDesactivado.DesactivarToolTipsEnControlesDesactivados(this);
            TooltipEnControlDesactivado.ConfigurarToolTip(this, botonDeslizable_Not247, "Completar la totalidad de campos para establecer fecha pericia.", "Marcar para establecer fecha de Pericia");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, checkBox_Cargo, "Completar la totalidad de campos para realizar Cargo Judicial.", "Marcar si requiere agregar CARGO JUDICIAL");
            TooltipEnControlDesactivado.TooltipActivo(this, checkBox_RatificacionTestimonial, "Marcar para agregar RATIFICACIONES TESTIMONIALES.", checkBox_RatificacionTestimonial.Enabled && checkBox_RatificacionTestimonial.Visible);
            TooltipEnControlDesactivado.ConfigurarToolTip(this, botonDeslizable_InsertarSecuestro, "Complete la totalidad de datos para poder solicitar inserte secuestro.", "Marcar para generar solicitud de INSERTE SECUESTRO.");
            TooltipEnControlDesactivado.TooltipActivo(this, fecha_Pericia, "Modificar fecha de Pericia.", fecha_Pericia.Enabled && fecha_Pericia.Visible);
            ToolTipGeneral.Mostrar(btn_SDA, "Redirige a página SDA para carga de actuaciones");
            ToolTipGeneral.Mostrar(btn_CrearDenuncia, "Crear DENUNCIA/ACTA");
            ToolTipGeneral.Mostrar(Btn_ContadorRML, " Mostrar listado de solicitudes RML.");
            ToolTipGeneral.Mostrar(btn_ContadorRatificaciones, " Mostrar listado de RATIFICACIONES TESTIMONIALES.");
            ToolTipGeneral.Mostrar(Btn_Contador247, " Mostrar listado de NOTIFCACIONES Pericia.");
        }



        /// <summary>
        /// INVISIBILIZA Y DESACTIVA CONTROLES 
        /// </summary>
        private void InvisibilizarDesactivarControles()
        {
           
            panel_InsertarSecuestro.Visible = false; // inicializa panel inserte secuetro oculto// se visiviliza con texto en caratula
            panel_Not247.Visible = false;
            panel_StudRML.Visible = false;
            panel_RatificacionPersonal.Visible = false;
            panel_Cargo.Visible = false;


            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.TextValue);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.TextValue);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.TextValue);

            btn_AgregarDatosImputado.Enabled = false;
            btn_AgregarDatosVictima.Enabled = false;
        }
        #endregion

        #region VALIDACION Y GUARDADO DE DATOS
        /// <summary>
        /// TOMA LOS DATOS DE DISTINTOS CONTROLES
        /// </summary>
        private void GuardarDatos()
        {
            // Obtener los datos del formulario
            int numeroIpp = int.Parse(textBox_NumeroIpp.TextValue);
            string ufid = comboBox_Fiscalia.TextValue;
            string dr = comboBox_AgenteFiscal.TextValue;
            string localidad = comboBox_Localidad.TextValue;
            string DeptoJudicial = comboBox_DeptoJudicial.TextValue;
            string instructor = comboBox_Instructor.TextValue;
            string secretario = comboBox_Secretario.TextValue;
            string dependencia = comboBox_Dependencia.TextValue;
            // string fecha = timePickerPersonalizado1.Value.ToString("yyyy-MM-dd");

            // Obtener las listas de víctimas e imputados
            List<string> victimas = [];
            List<string> imputados = [];

            //foreach (var item in lstVictimas.Items)
            //{
            //    victimas.Add(item.ToString());
            //}

            //foreach (var item in lstImputados.Items)
            //{
            //    imputados.Add(item.ToString());
            //}

            //// Llamar al método GuardarIPP
            //dataInserter.GuardarIPP(numeroIpp, ufid, dr, localidad, DeptoJudicial, instructor, secretario, dependencia, fecha, victimas, imputados);

        }



        /// <summary>
        /// METODO VALIDAR ANTES DE GUARDAR
        /// </summary>
        /// <returns></returns>
        private bool ValidarAntesdeGuardar()
        {
            bool esValido = false;

            // Validar campos requeridos
            esValido &= ValidarCampo(textBox_Caratula, "El campo 'Carátula' es obligatorio.");
            esValido &= ValidarCampo(textBox_Imputado, "El campo 'Imputado' es obligatorio.");
            esValido &= ValidarCampo(textBox_Victima, "El campo 'Víctima' es obligatorio.");

            return esValido;
        }

        /// <summary>
        /// METODO PARA MOSTRAR ERROR EN CAMPOS VACIOS
        /// </summary>
        /// <param name="control"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        private static bool ValidarCampo(System.Windows.Forms.Control control, string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                // Si el campo está vacío, se establece un error en el control y se muestra el PictureBoxError
                //SetError(control, mensajeError);
                return false;
            }

            // Si el campo está completo, se limpia el error
            //ClearError(control);
            return true;
        }
        #endregion

        #region BOTONES INFERIORES

        /// <summary>
        /// BOTON ELIMINAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            Btn_Contador247.Visible = false;
            Btn_Contador247.Enabled = false;
            fecha_Pericia.Visible = false;
            fecha_Pericia.Enabled = false;

        }

        /// <summary>
        /// METODO BOTON IMPRIMIR
        /// </summary>
        private static void CargarImpresion()
        {  // Crea ventana que muestra archivo cargando
            using MensajeCargarImprimir imprimirMessageBox = new();
            imprimirMessageBox.ShowDialog();//showdialog implica "bloquea interaccion con ventana principal hasta que se cierra"
        }

        /// <summary>
        /// BOTON IMPRIMIR-click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (btn_Imprimir.Enabled) //si el boton esta habilitado -->mostrar progreso
            {
                datosGuardados = true;
                CargarImpresion();

                var generador = new GeneradorDocumentos();
                var datosFormulario = ObtenerDatosFormulario();

                // Definir rutas
                string rutaPlantilla = @"C:\Users\Usuario\OneDrive\Escritorio\.net\plantillaPrototipo.dotx";
                string rutaArchivoSalida = @"C:\Users\Usuario\OneDrive\Escritorio\.net\archivos de salida";

                generador.GenerarDocumento(rutaPlantilla, rutaArchivoSalida, datosFormulario);

            }
        }

        /// <summary>
        /// METODO BOTON BUSCAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario BuscarPersonal
            BuscarForm buscarForm = new BuscarForm();

            buscarForm.ShowDialog();
        }

        /// <summary>
        /// BOTON GUARDAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos básicos están completos
            if (!ValidarAntesdeGuardar()) // Verificación usando ErrorProvider
            {
                // Mostrar mensaje de advertencia si hay errores
                MensajeGeneral.Mostrar("Debe completar los campos Carátula, Imputado y Víctima.",
                                       MensajeGeneral.TipoMensaje.Advertencia);
                return; // Detener la ejecución si hay errores
            }

            datosGuardados = true; // Evitar mensaje de alerta al cerrar el formulario
                                   // Mostrar mensaje de confirmación al guardar exitosamente
            MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);

        }

        #endregion

        #region METODOS GENERALES

        /// <summary>
        ///  CARGAR DATOS DESDE FORMULARIO INICIO-CIERRE
        /// </summary>
        private Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>
    {
        { "caratula", textBox_Caratula.TextValue },
        { "victima", textBox_Victima.TextValue },
        { "imputado", textBox_Imputado.TextValue },
        { "instructor", comboBox_Instructor.TextValue },
        { "secretario", comboBox_Secretario.TextValue },
        { "DeptoJudicial", comboBox_DeptoJudicial.TextValue },
         };
            return datosFormulario;
        } //Diccionario para cargar los datos a los marcadores del documento-------------



        /// <summary>
        /// METODO PARA AGREGAR PERSONAL A LAS RATIFICACIONES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_RatificacionTestimonial_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkBox_RatificacionTestimonial.Checked)
            {
                btn_ContadorRatificaciones.Text = "0";
                btn_ContadorRatificaciones.Visible = true;


                // Ocultar el CheckBox
                checkBox_RatificacionTestimonial.Visible = false;

                // Crear y mostrar el formulario BuscarPersonal
                BuscarPersonal buscarPersonalForm = new();

                // Obtener el formulario original (inicioCierre)
                Form originalForm = this;

                // Obtener el tamaño de ambos formularios
                int totalWidth = originalForm.Width + buscarPersonalForm.Width;
                int height = Math.Max(originalForm.Height, buscarPersonalForm.Height);

                // Calcular la posición para centrar ambos formularios en la pantalla
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int startX = (screenWidth - totalWidth) / 2;
                int startY = (screenHeight - height) / 2;

                // Posicionar el formulario original a la izquierda
                originalForm.Location = new Point(startX, startY);

                // Posicionar el formulario  a la derecha del formulario original
                buscarPersonalForm.StartPosition = FormStartPosition.Manual;
                buscarPersonalForm.Location = new Point(startX + originalForm.Width, startY);

                // Suscribirse al evento FormClosed del formulario Cargo
                buscarPersonalForm.FormClosed += (s, args) =>
                {
                    if (buscarPersonalForm.DialogResult == DialogResult.Cancel)
                    {
                        // Acciones si el resultado del diálogo es "Sí"
                        checkBox_RatificacionTestimonial.Visible = true;
                        checkBox_RatificacionTestimonial.Checked = false;
                        btn_ContadorRatificaciones.Visible = false;

                    }
                    else if (buscarPersonalForm.DialogResult == DialogResult.Yes)
                    {
                        checkBox_RatificacionTestimonial.Visible = false;

                    }

                    // Calcular la nueva posición para centrar el formulario original
                    int centerX = (screenWidth - originalForm.Width) / 2;
                    int centerY = (screenHeight - originalForm.Height) / 2;

                    // Reposicionar el formulario original en el centro de la pantalla
                    originalForm.Location = new Point(centerX, centerY);
                };

                buscarPersonalForm.ShowDialog();
            }
        }

        private void CheckBox_Cargo_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkBox_Cargo.Checked)
            {

                // Ocultar el CheckBox
                checkBox_Cargo.Visible = false;

                string Ipp1 = comboBox_Ipp1.TextValue;
                string Ipp2 = comboBox_Ipp2.TextValue;
                string NumeroIpp = textBox_NumeroIpp.TextValue;
                string Ipp4 = comboBox_Ipp4.TextValue;
                string Caratula = textBox_Caratula.TextValue;
                string Victima = textBox_Victima.TextValue;
                string Imputado = textBox_Imputado.TextValue;
                string Fiscalia = comboBox_Fiscalia.TextValue;
                string AgenteFiscal = comboBox_AgenteFiscal.TextValue;
                string Localidad = comboBox_Localidad.TextValue;
                string Instructor = comboBox_Instructor.TextValue;
                string Secretario = comboBox_Secretario.TextValue;
                string Dependencia = comboBox_Dependencia.TextValue;

                // Crear y mostrar el formulario CARGO, pasando los valores obtenidos
                Cargo cargo = new(Ipp1, Ipp2, NumeroIpp, Ipp4, Caratula, Victima, Imputado,
                                        Fiscalia, AgenteFiscal, Localidad, Instructor, Secretario, Dependencia);


                // Obtener el formulario original (inicioCierre)
                Form originalForm = this;

                // Obtener el tamaño de ambos formularios
                int totalWidth = originalForm.Width + cargo.Width;
                int height = Math.Max(originalForm.Height, cargo.Height);

                // Calcular la posición para centrar ambos formularios en la pantalla
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int startX = (screenWidth - totalWidth) / 2;
                int startY = (screenHeight - height) / 2;

                // Posicionar el formulario original a la izquierda
                originalForm.Location = new Point(startX, startY);

                // Posicionar el formulario Cargo a la derecha del formulario original
                cargo.StartPosition = FormStartPosition.Manual;
                cargo.Location = new Point(startX + originalForm.Width, startY);

                // Suscribirse al evento FormClosed del formulario Cargo
                cargo.FormClosed += (s, args) =>
                {
                    if (cargo.DialogResult == DialogResult.OK)
                    {
                        // Acciones si el resultado del diálogo es "Sí"
                        checkBox_Cargo.Visible = true;
                        checkBox_Cargo.Checked = false;

                    }
                    else
                    {
                        checkBox_Cargo.Visible = false;

                    }
                    // Calcular la nueva posición para centrar el formulario original
                    int centerX = (screenWidth - originalForm.Width) / 2;
                    int centerY = (screenHeight - originalForm.Height) / 2;

                    // Reposicionar el formulario original en el centro de la pantalla
                    originalForm.Location = new Point(centerX, centerY);


                };

                // Mostrar el nuevo formulario
                cargo.ShowDialog();

            }

        }

        /// <summary>
        /// Este método maneja la lógica común para desmarcar el CheckBox
        /// </summary>
        private void DesmarcarCheckBoxConTexto()
        {
            if (checkBox_Cargo.Checked)
            {
                checkBox_Cargo.Checked = false;

            }
        }
        private void ComboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
            DesmarcarCheckBoxConTexto();
        }
        private void ComboBox_Secretario_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
            DesmarcarCheckBoxConTexto();
        }
        private void ComboBox_Instructor_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
            DesmarcarCheckBoxConTexto();
        }
        private void ComboBox_DeptoJudicial_TextChanged(object sender, EventArgs e)
        {

            ActualizarEstado();
        }

        /// <summary>
        /// CONFIGURACION DE EVENTOS DESENCADENADOS EN BTN_DESLIZABLE
        /// </summary>
        private void BotonDeslizable_247()
        {
            botonDeslizable_Not247.ValidarCampos = () =>
            {
                // Validar campos completos
                if (!ValidarControlesCompletosEnPaneles()) //verifica que esten los campos de datos instruccion completos 
                {                                          // pero como el btn solo se desbloquea si estan completos, no se usa
                    // No están completos: mostrar mensaje de advertencia
                    MensajeGeneral.Mostrar(
                        "Debe completar la totalidad de los campos para crear la NOTIFICACIÓN de Art. 247 C.P.P.",
                        MensajeGeneral.TipoMensaje.Advertencia);
                    return false;
                }

                // Si los campos están completos, proceder
                if (botonDeslizable_Not247.IsOn)
                {
                    // Configurar fecha mínima basada en otro TimePicker
                    DateTime fechaBase = timePickerPersonalizado1.FechaSeleccionada;

                    // Mostrar el formulario de MensajeGeneral con el DateTimePicker
                    var fechaSeleccionada = MensajeGeneral.MostrarCompromiso(
                        "Indique fecha de pericia.",
                        fechaMinima: fechaBase);

                    if (fechaSeleccionada.HasValue)
                    {
                        if (fechaSeleccionada.Value < fechaBase)
                        {
                            MensajeGeneral.Mostrar(
                                "Seleccione una fecha posterior a la fecha de inicio de actuaciones.",
                                MensajeGeneral.TipoMensaje.Advertencia);
                            return false;
                        }

                        // Si la fecha es válida, realizar las actualizaciones
                        botonDeslizable_Not247.IsOn = true;

                        // Reposicionar el botón 10 píxeles a la izquierda
                        botonDeslizable_Not247.Location = new Point(
                            botonDeslizable_Not247.Location.X - 10,
                            botonDeslizable_Not247.Location.Y);

                        fecha_Pericia.Text = fechaSeleccionada.Value.ToString("dd/MM/yyyy HH:mm");
                        fecha_Pericia.Visible = true;
                        fecha_Pericia.Enabled = true;
                        panel_Not247.BackColor = SystemColors.GradientInactiveCaption;

                        Btn_Contador247.Visible = true;
                        Btn_Contador247.Text = "3"; // Por FISCALIA, DEFENSORIA, JUZ.GTIAS + imputados y víctimas
                    }
                    else
                    {
                        // En caso de no seleccionar una fecha
                        botonDeslizable_Not247.Location = new Point(botonDeslizable_Not247.Location.X + 10, botonDeslizable_Not247.Location.Y);
                        panel_Not247.BackColor = System.Drawing.Color.Transparent;
                        fecha_Pericia.Visible = false;
                        fecha_Pericia.Enabled = false;
                        Btn_Contador247.Visible = false;
                        botonDeslizable_Not247.IsOn = false;
                    }
                }

                return botonDeslizable_Not247.IsOn;
            };
        }

        /// <summary>
        /// Para habilitar check y modificar label
        /// </summary>
        public void ActualizarEstado()
        {
            // Verifica si cada campo no está vacío ni solo con espacios
            bool esTextoValidoNumeroIPP = !string.IsNullOrWhiteSpace(textBox_NumeroIpp.TextValue);
            bool esTextoValidoCaratula = !string.IsNullOrWhiteSpace(textBox_Caratula.TextValue);
            bool esTextoValidoVictima = !string.IsNullOrWhiteSpace(textBox_Victima.TextValue);
            bool esTextoValidoImputado = !string.IsNullOrWhiteSpace(textBox_Imputado.TextValue);
            bool esTextoValidoUfid = !string.IsNullOrWhiteSpace(comboBox_Fiscalia.TextValue);
            bool esTextoValidoInstructor = !string.IsNullOrWhiteSpace(comboBox_Instructor.TextValue);
            bool esTextoValidoSecretario = !string.IsNullOrWhiteSpace(comboBox_Secretario.TextValue);
            bool esTextoValidoDependencia = !string.IsNullOrWhiteSpace(comboBox_Dependencia.TextValue);


            // Todos los campos deben ser válidos para que esTextoValido sea verdadero
            bool esTextoValido = esTextoValidoNumeroIPP && esTextoValidoCaratula && esTextoValidoVictima &&
                                 esTextoValidoImputado && esTextoValidoUfid &&
                                 esTextoValidoInstructor && esTextoValidoSecretario && esTextoValidoDependencia;


            // Actualiza el color del label y el estado del checkbox según el estado de validación
            if (esTextoValido)
            {
                //panel CARGO
                label_Cargo.ForeColor = System.Drawing.Color.Black;
                label_Cargo.BackColor = System.Drawing.Color.Transparent;
                checkBox_Cargo.Enabled = true;
                checkBox_Cargo.BackColor = System.Drawing.Color.Transparent;

                //panel NOT 247
                label_Not247.ForeColor = System.Drawing.Color.Black;
                label_Not247.BackColor = System.Drawing.Color.Transparent;
                botonDeslizable_Not247.Enabled = true;// habilitar btn 247
                botonDeslizable_Not247.BackColor = System.Drawing.Color.Transparent;

                //panel INSERTAR SECUESTRO
                panel_InsertarSecuestro.BackColor = System.Drawing.Color.Transparent;
                label_InsertarSecuestro.ForeColor = System.Drawing.Color.Black;
                botonDeslizable_InsertarSecuestro.Enabled = true;

                //panel STUD RML
                Btn_ContadorRML.Visible = true;
                label_StudRML.Visible = true;

            }
            else
            {
                //panel CARGO
                label_Cargo.ForeColor = System.Drawing.Color.Tomato;
                label_Cargo.BackColor = System.Drawing.Color.FromArgb(211, 211, 211); // Gris claro
                checkBox_Cargo.Enabled = false;
                checkBox_Cargo.BackColor = System.Drawing.Color.Tomato;

                //panel NOT 247
                label_Not247.ForeColor = System.Drawing.Color.Tomato;
                label_Not247.BackColor = System.Drawing.Color.FromArgb(211, 211, 211);
                botonDeslizable_Not247.Enabled = false;// deshabilitar btn 247
                botonDeslizable_Not247.BackColor = System.Drawing.Color.FromArgb(211, 211, 211);

                //panel INSERTAR SECUESTRO
                panel_InsertarSecuestro.BackColor = System.Drawing.Color.FromArgb(211, 211, 211);
                label_InsertarSecuestro.ForeColor = System.Drawing.Color.Tomato;
                botonDeslizable_InsertarSecuestro.Enabled = false;

                //panel STUD RML
                Btn_ContadorRML.Visible = false;
                label_StudRML.Visible = false;


            }
        }


        /// <summary>
        /// Para verificar los controles y habilitar boton
        /// </summary>
        /// <returns></returns>
        private bool ValidarControlesCompletosEnPaneles()
        {
            // Verificar los paneles uno por uno
            bool camposIncompletos = false;

            camposIncompletos |= !VerificarCamposEnPanel(panel_Ipp);
            camposIncompletos |= !VerificarCamposEnPanel(panel_Caratula);
            camposIncompletos |= !VerificarCamposEnPanel(panel_Victima);
            camposIncompletos |= !VerificarCamposEnPanel(panel_Imputado);
            camposIncompletos |= !VerificarCamposEnPanel(panel_Instruccion);
            botonDeslizable_Not247.IsOn = true;
            return !camposIncompletos;// Devuelve verdadero si todos los campos están completos

        }

        /// <summary>
        /// para que muestre mensaje de advertencia previo cerrar formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InicioCierre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
            }
        }

        #endregion

        #region INSERTE SECUESTRO
        private void MostrarInserteSecuestro()
        {
            // Lista de palabras clave a buscar
            string[] palabrasClave = { "HURTO", "ROBO", "VEHICULO", "MOTOVEHICULO", "ESTAFA" };

            // Obtener todos los CustomTextBox en panel_Caratula
            var textBoxes = panel_Caratula.Controls.OfType<CustomTextBox>().ToList();

            // Obtener los CustomTextBox dentro de cada nuevaPersonaControl agregado dinámicamente
            foreach (var personaControl in panel_Caratula.Controls.OfType<NuevaPersonaControl>())
            {
                textBoxes.AddRange(personaControl.Controls.OfType<CustomTextBox>());
            }

            // Verificar si alguno contiene una palabra clave
            bool mostrarPanel = textBoxes.Any(txt => palabrasClave.Any(palabra => txt.TextValue.Contains(palabra, StringComparison.OrdinalIgnoreCase)));

            // Mostrar u ocultar el panel según el resultado
            panel_InsertarSecuestro.Visible = mostrarPanel;
            // Llamar a MostrarPanelInterno solo si se debe mostrar
            if (mostrarPanel)
            {
                MostrarPanelInterno(panel_InsertarSecuestro);

            }
        }

        /// <summary>
        /// subscribe textchanged a todas las caratualas del panel_Caratulas , para mostrar panel_InsertarSecuestro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaratulaInserteSecuestro_TextChanged(object sender, EventArgs e)
        {
            MostrarInserteSecuestro();
        }

        private void SubscribirCaratulaTextchanged()
        {
            //subscribir evento textchanged en forma recursiva a todos los textBox de panel caratula
            foreach (var txt in panel_Caratula.Controls.OfType<CustomTextBox>())
            {
                txt.TextChanged += CaratulaInserteSecuestro_TextChanged;
            }
            // Suscribir los CustomTextBox dentro de cada nuevaPersonaControl
            foreach (var personaControl in panel_Caratula.Controls.OfType<NuevaPersonaControl>())
            {
                foreach (var txt in personaControl.Controls.OfType<CustomTextBox>())
                {
                    txt.TextChanged += CaratulaInserteSecuestro_TextChanged;
                }
            }
        }

        private void AsignarEventosCustomTextBox(System.Windows.Forms.Control control)
        {
            // Verificar si el control es un NuevaPersonaControl
            if (control is NuevaPersonaControl personaControl)
            {
                foreach (var txt in personaControl.Controls.OfType<CustomTextBox>())
                {
                    txt.TextChanged += CaratulaInserteSecuestro_TextChanged;
                }
            }
        }

        private void BotonDeslizable_InserteSecuestro()
        {
            // Validar campos completos
            if (!ValidarControlesCompletosEnPaneles())
            {
                MensajeGeneral.Mostrar(
                    "Complete la totalidad de los campos para INSERTAR SECUESTRO.",
                    MensajeGeneral.TipoMensaje.Advertencia);
                botonDeslizable_InsertarSecuestro.IsOn = false;
                botonDeslizable_InsertarSecuestro.Invalidate();
                return;
            }

            // Si los campos están completos, proceder
            if (botonDeslizable_InsertarSecuestro.IsOn)
            {


                // Crear una nueva instancia del formulario MensajeEmail
                MensajeEmail mensajeEmail = new();

                // Mostrar el formulario como un cuadro de diálogo o de forma normal
                mensajeEmail.ShowDialog();
            }


        }
        /// <summary>
        /// muestra paneles internos segun se indique
        /// </summary>
        /// <param name="panel"></param>
        private void MostrarPanelInterno(System.Windows.Forms.Panel panel)
        {
            // Asegurar que el contenedor principal esté visible
            if (!panel_Compromisos.Visible)
                panel_Compromisos.Visible = true;

            // Mostrar solo el panel interno deseado
            panel.Visible = true;
        }


        #endregion

        #region CONTROL FECHA AUDIENCIA/PERICIA
        private void Fecha_Audiencia(object sender, EventArgs e)
        {
            if (sender is TimePickerPersonalizado control)
            {
                // Tomar la fecha seleccionada del TimePicker
                DateTime nuevaFecha = control.FechaSeleccionada;

                // Lógica de asignación para el caso específico (ejemplo: fecha_Pericia)
                if (control.Name == "timePickerFechaCompromiso")
                {
                    fecha_Pericia.Text = nuevaFecha.ToString("dd/MM/yyyy");
                    fecha_Pericia.Visible = true; // Asegurar que el label sea visible
                }
            }
        }

        /// <summary>
        /// METODO PARA CAMBIAR FECHA DE COMPROMISO SELECCIONADA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fecha_Pericia_Click(object sender, EventArgs e)
        {

            // Configurar fecha mínima basada en otro TimePicker
            DateTime fechaBase = timePickerPersonalizado1.FechaSeleccionada;
            // Mostrar el formulario con el TimePicker
            var mensajeCompromiso = new DateTimePicker();

            // Mostrar el formulario con el TimePicker
            var fechaSeleccionada = MensajeGeneral.MostrarCompromiso("Indique fecha de pericia.", fechaMinima: fechaBase);

            if (fechaSeleccionada < fechaBase)
            {
                MensajeGeneral.Mostrar("Seleccione una fecha posterior a la fecha de inicio de actuaciones.",
                    MensajeGeneral.TipoMensaje.Advertencia);

            }
            if (fechaSeleccionada.HasValue)
            {
                botonDeslizable_Not247.IsOn = true; // Mantener activado si el usuario guarda

                fecha_Pericia.Text = fechaSeleccionada.Value.ToString("dd/MM/yyyy");
                fecha_Pericia.Visible = true;
                fecha_Pericia.Enabled = true;

                Btn_Contador247.Visible = true;
                Btn_Contador247.Text = "3"; // comienza con 3 por FISCALIA, DEFENSORIA, JUZ.GTIAS + imputados y víctimas
            }
            else
            {
                return;
            }
        }
        private void Fecha_Pericia_Enter(object sender, EventArgs e)
        {
            fecha_Pericia.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            fecha_Pericia.ForeColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// Se ejecuta automáticamente cuando el usuario abandona el control MaskedTextBox (pierde el foco) y la propiedad ValidatingType está configurada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fecha_Pericia_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MensajeGeneral.Mostrar("Por favor, ingrese una fecha y hora válida.", MensajeGeneral.TipoMensaje.Advertencia);

                //  Evitar que el control pierda el foco si el dato no es válido
                ((MaskedTextBox)sender).Focus();
            }
        }

        /// <summary>
        /// VALIDA QUE COUNCIDA CON PARAMETRO DE FECHA INSTRUCCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fecha_Pericia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Verificar si el texto ingresado es una fecha válida
            if (DateTime.TryParse(fecha_Pericia.Text, out DateTime fechaIngresada))
            {
                if (fechaIngresada < timePickerPersonalizado1.FechaSeleccionada)
                {
                    MensajeGeneral.Mostrar("La fecha no puede ser anterior a la fecha de instrucción.", MensajeGeneral.TipoMensaje.Advertencia);
                    e.Cancel = true; // Evitar que el control pierda el foco
                }
            }

        }
        private void Fecha_Pericia_MouseLeave(object sender, EventArgs e)
        {
            fecha_Pericia.BackColor = SystemColors.ActiveCaption; // Cambiar el color de fondo al color de control activo
            fecha_Pericia.ForeColor = SystemColors.WindowText; // Cambiar el color del texto al color de texto de la ventana

        }

        #endregion


        #region BTN AGREGAR CAUSA/VMA/IMP



        #endregion

        #region BTN AGREGAR DATOS PERSONALES

        /// <summary>
        /// EVENTO PARA ABRIR FORMULARIO AGREGAR DATOS IMPUTADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarDatosImputado_Click(object sender, EventArgs e)
        {
            //AbrirFormularioSecundario(ref agregarDatosPersonalesImputado, textBox_Imputado, "TextoNombre");
        }

        /// <summary>
        /// METODO PARA VALIDAD Y ABRIR FORMULARIO AGREGAR DATOS VICTIMA
        /// </summary>
        private void Btn_AgregarDatosVictima_Click(object sender, EventArgs e)
        {
            //  AbrirFormularioSecundario(ref agregarDatosPersonalesVictima, textBox_Victima, "TextoNombre");

        }

        #endregion

        #region BTN SDA

        /// <summary>
        /// abre pagina ministerial, pero no funciona porque trabaja con intranet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SDA_Click(object sender, EventArgs e)
        {

            ConexionGeneral.AbrirUrl("https://sda.mseg.gba.gov.ar/sso/login");
        }

        #endregion

        #region CREAR DENUNCIA
        /// <summary>
        /// abre formulario  para estructura de denuncias y actas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CrearDenuncia_Click(object sender, EventArgs e)
        {
            ActaDenuncia actaDenunciaForm = new();

            // Posicionar el formulario
            PosicionarBordeSuPerior.PosicionarFormulario(actaDenunciaForm);

            // Mostrar y ocultar los demás formularios
            VisibilidadYOcultamientoForm.MostrarFormularioYOcultar(actaDenunciaForm);
        }
        #endregion

     
    }
}