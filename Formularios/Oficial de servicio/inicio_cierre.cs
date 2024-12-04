using BaseDatos.Entidades;
using Clases.Botones;
using Clases.GenerarDocumentos;
using Clases.Texto;
using Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Clases.Texto;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.general.animaciones;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Mensajes;
using Ofelia_Sara.Controles;
using Ofelia_Sara.Registro_de_personal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles; //para tooltip general
using Ofelia_Sara.Controles.Controles.Reposicionar_paneles.InicioCierre;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class InicioCierre : BaseForm
    {
        private ReposicionarSegunAgregado reposicionador;//para reposicionar paneles

        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        // Listas para almacenar víctimas e imputados
        private List<string> victimas = new List<string>();
        private List<string> imputados = new List<string>();

        //Lista para autocompletar caratula
        private List<string> sugerencias;

        private const string ComboBoxFilePath = "comboBoxDependenciaItems.txt"; // Ruta del archivo
        private AgregarDatosPersonalesVictima agregarDatosPersonalesVictima;
        private AgregarDatosPersonalesImputado agregarDatosPersonalesImputado;
        public InicioCierre()
        {
            InitializeComponent();

            //.......para reposicionar paneles
            reposicionador = new ReposicionarSegunAgregado(
            this,
            panel_Ipp,
            panel_Caratula,
            panel_Victima,
            panel_Imputado,
            panel_Instruccion,
            panel_ControlesInferiores
            );
            //..............................

            textBox_NumeroIpp.TextChanged += (s, e) => ActualizarEstado();
            textBox_Caratula.TextChanged += (s, e) => ActualizarEstado();
            textBox_Victima.TextChanged += (s, e) => ActualizarEstado();
            textBox_Imputado.TextChanged += (s, e) => ActualizarEstado();

            comboBox_AgenteFiscal.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Instructor.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Secretario.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Dependencia.SelectedIndexChanged += (s, e) => ActualizarEstado();

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarCausa);
            InicializarEstiloBotonAgregar(btn_AgregarVictima);
            InicializarEstiloBotonAgregar(btn_AgregarImputado);

            this.Load += new System.EventHandler(this.InicioCierre_Load);

            // Asocia el evento TextChanged al método de validación
            textBox_Victima.TextChanged += new EventHandler(TextBox_Victima_TextChanged);
            textBox_Imputado.TextChanged += new EventHandler(TextBox_Imputado_TextChanged);

            //-----para los botones de agregar datos personales completos------------------
            // Inicialmente, deshabilita el botón
            btn_AgregarDatosVictima.Enabled = false;
            btn_AgregarDatosVictima.BackColor = Color.Tomato;

            // Inicialmente, deshabilita el botón
            btn_AgregarDatosImputado.Enabled = false;
            btn_AgregarDatosImputado.BackColor = Color.Tomato;

            comboBox_DeptoJudicial.TextChanged += ComboBox_DeptoJudicial_TextChanged;

            // Ruta completa del archivo JSON
            string rutaJson = @"C:\Users\Usuario\OneDrive\Escritorio\BaseDatos_Libreria\Json\sugerencias_Caratula.json";

            // Cargar sugerencias desde el archivo JSON
            sugerencias = AutocompletarCaratula.LeerSugerenciasDesdeJson(rutaJson);

            // Configurar el TextBox para utilizar autocompletar
            ConfigurarAutocompletar(textBox_Caratula, sugerencias);

            SetupBotonDeslizable();  // Configurar el delegado de validación

            fecha_Pericia.Enabled = false;//deshabilitado e invisible para aplicar el tooltip especial e impedir que se vea
            fecha_Pericia.Visible = false;
        }
        //---FIN CONSTRUCTOR----

        // Propiedad pública para acceder al botón
        // En InicioCierre, agrega una propiedad pública que devuelva el botón
        public Boton_Contador BtnContadorRatificaciones
        {
            get { return btn_ContadorRatificaciones; } // Asegúrate de que esta instancia esté inicializada en el diseñador
        }
        //-------------------------------------------------

        private void InicioCierre_Load(object sender, EventArgs e)
        {
            InicializarComboBox(); //para que se inicialicen los indices predeterminados de comboBox

            pictureBox_CheckRatificacion.Visible = false; //oculata ambos check hasta ques se marque
            pictureBox_CheckCargo.Visible = false;

            timePickerPersonalizado1.SelectedDate = DateTime.Now; //para que actualice automaticamente la fecha

            //  tooltip DESCATIVADO-ACTIVADO
            TooltipEnControlDesactivado.DesactivarToolTipsEnControlesDesactivados(this);
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarDatosVictima, "Completar nombre de VICTIMA para ingresar más datos.", "Agregar datos personales de Victima");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarDatosImputado, "Completar nombre de IMPUTADO para ingresar más datos.", "Agregar datos personales de Imputado");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, botonDeslizable_Not247, "Completar la totalidad de campos para establecer fecha pericia.", "Marcar para establecer fecha de Pericia");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, checkBox_Cargo, "Completar la totalidad de campos para realizar Cargo Judicial.", "Marcar si requiere agregar CARGO JUDICIAL");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarCausa, "Ingrese una caratula antes de anexar la siguiente.", "Agregar una caratula adicional");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarVictima, "Ingrese una VICTIMA/DENUNCIANTE antes de anexar la siguiente.", "Agregar Victima");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarImputado, "Ingrese un IMPUTADO antes de anexar el siguiente.", "Agregar Imputado");
            TooltipEnControlDesactivado.TooltipActivo(this, checkBox_RatificacionTestimonial, "Marcar para agregar RATIFICACIONES TESTIMONIALES.", checkBox_RatificacionTestimonial.Enabled && checkBox_RatificacionTestimonial.Visible);

            TooltipEnControlDesactivado.TooltipActivo(this, fecha_Pericia, "Modificar fecha de Pericia.", fecha_Pericia.Enabled && fecha_Pericia.Visible);

            ToolTipGeneral.ShowToolTip(Btn_ContadorRML, " Mostrar listado de solicitudes RML.");
            ToolTipGeneral.ShowToolTip(btn_ContadorRatificaciones, " Mostrar listado de RATIFICACIONES TESTIMONIALES.");
            ToolTipGeneral.ShowToolTip(Btn_Contador247, " Mostrar listado de NOTIFCACIONES Pericia.");
            //...........................................................................
            //carcteristicas de texto en controles
            MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            MayusculaSola.AplicarAControl(textBox_Victima);
            MayusculaSola.AplicarAControl(textBox_Imputado);
            MayusculaSola.AplicarAControl(comboBox_Localidad);
            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Fiscalia);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);
            //.....................................................................

            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);

            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON

            //cargar desde base de datos
            CargarDatosDependencia(comboBox_Dependencia, dbManager);
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
            CargarDatosSecretario(comboBox_Secretario, secretariosManager);

            ActualizarEstado();//PARA LABEL Y CHECK CARGO,labell btn_not247 y btn_StudRML
            //............................................................................

            //invisibilizar controles al cargar
            Btn_Contador247.Visible = false;//invisibiliza el contador hasta que pase a SI btn deslizable
            fecha_Pericia.Visible = false;  //para ocultar fecha de pericia hasta ques se establesca
            btn_ContadorRatificaciones.Visible = false;// oculta contador hasta el check
            Btn_ContadorRML.Visible = false;
            //..................................................................

            Btn_ContadorRML.Text = "0";
           
        
        }
        // --FIN LOAD
        //-----------------------------------------------------------------------------
        private void GuardarDatos()
        {
            // Obtener los datos del formulario
            int numeroIpp = int.Parse(textBox_NumeroIpp.Text);
            string ufid = comboBox_Fiscalia.Text;
            string dr = comboBox_AgenteFiscal.Text;
            string localidad = comboBox_Localidad.Text;
            string DeptoJudicial = comboBox_DeptoJudicial.Text;
            string instructor = comboBox_Instructor.Text;
            string secretario = comboBox_Secretario.Text;
            string dependencia = comboBox_Dependencia.Text;
            //string fecha = timePickerPersonalizado1.Value.ToString("yyyy-MM-dd");

            // Obtener las listas de víctimas e imputados
            List<string> victimas = new List<string>();
            List<string> imputados = new List<string>();

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
        /// METODO PARA AUTOCOMPLETAR CARATULA
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="sugerencias"></param>
        private void ConfigurarAutocompletar(TextBox textBox, List<string> sugerencias)
        {
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(sugerencias.ToArray());

            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource = autoCompleteCollection;
        }
        //---------------------------------------------------------------------

        /// <summary>
        /// LOGICA DE BOTON GUARDAR
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
        //............................................................

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
        //.............................................................................

        /// <summary>
        /// METODO PARA MOSTRAR ERROR EN CAMPOS VACIOS
        /// </summary>
        /// <param name="control"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>

        private bool ValidarCampo(Control control, string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                // Si el campo está vacío, se establece un error en el control y se muestra el PictureBoxError
                SetError(control, mensajeError);
                return false;
            }

            // Si el campo está completo, se limpia el error
            ClearError(control);
            return true;
        }
        //-------------------------------------------------------------------------------

        /// <summary>
        /// METODO PARA BOTON ELIMINAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON

           comboBox_Dependencia.SelectedIndex = -1;
           comboBox_Instructor.SelectedIndex = -1;
           comboBox_Secretario.SelectedIndex = -1;

            Btn_Contador247.Visible = false;
            Btn_Contador247.Enabled = false;
            fecha_Pericia.Visible = false;
            fecha_Pericia.Enabled = false;

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        //-------------------------------------------------------------------------------

        /// <summary>
        /// METODO PARA LIMITAR LOS CARACTERES A 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {
            // Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;
                ActualizarEstado();
            }

        }
        //-------------------------------------------------------------

        /// <summary>
        /// LIMITAR A 2 CARACTERES COMBOBOX IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void ComboBox_Ipp_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp2.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp2.Text = comboBox_Ipp2.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp2.SelectionStart = comboBox_Ipp2.Text.Length;
            }
        }
        //------------------------------------------------------------------

        /// <summary>
        /// EVENTO PARA COMPLETAR CON "0" LOS CARACTERES FALTANTE EN NUMERO IPP------
        /// </summary>
        private void TextBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }

            // Verifica si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Obtiene el TextBox que disparó el evento
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Obtiene el texto actual del TextBox
                    string currentText = textBox.Text;

                    // Verifica si el texto es numérico
                    if (int.TryParse(currentText, out _))
                    {
                        // Completa el texto con ceros a la izquierda hasta alcanzar 6 caracteres
                        string completedText = currentText.PadLeft(6, '0');

                        // Actualiza el texto del TextBox
                        textBox.Text = completedText;

                        // Posiciona el cursor al final del texto
                        textBox.SelectionStart = textBox.Text.Length;

                        // Cancelar el manejo predeterminado de la tecla Enter
                        e.Handled = true;
                    }
                }
            }
        }
        //-------------------------------------------------------------------------

        /// <summary>
        /// EVENTO PARA AUTOCOMPLETAR CUANDO PIERDE EL FOCO
        /// </summary>
        private void TextBox_NumeroIpp_Leave(object sender, EventArgs e)
        {
            CompletarConCeros(sender as TextBox);
        }

        // Método reutilizable para completar con ceros
        private void CompletarConCeros(TextBox textBox)
        {
            if (textBox != null)
            {
                // Obtiene el texto actual del TextBox
                string currentText = textBox.Text;

                // Verifica si el texto es numérico y no está vacío
                if (int.TryParse(currentText, out _) && !string.IsNullOrEmpty(currentText))
                {
                    // Completa el texto con ceros a la izquierda hasta alcanzar 6 caracteres
                    textBox.Text = currentText.PadLeft(6, '0');

                    textBox.SelectionStart = textBox.Text.Length; // Posiciona el cursor al final del texto (opcional)
                }
            }
        }

        //--------------------------------------------------------------------------------------------


        /// <summary>
        /// METODO BOTON IMPRIMIR
        /// </summary>

        // Crea ventana que muestra archivo cargando
        private void CargarImpresion()
        {
            using (MensajeCargarImprimir imprimirMessageBox = new MensajeCargarImprimir())
            {
                imprimirMessageBox.ShowDialog();//showdialog implica "bloquea interaccion con ventana principal hasta que se cierra"
            }
        }

        // Evento Click del botón Imprimir
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

        //---------------------------------------------------------------------------------

        /// <summary>
        /// METODO PARA INICIALIZAR COMBOBOX EN INDICE PREDETERMINADO
        /// </summary>
        private void InicializarComboBox()
        {
            comboBox_Ipp1.SelectedIndex = 3;
            comboBox_Ipp2.SelectedIndex = 3;
            comboBox_Ipp4.SelectedIndex = 0;

        }
        //----------------------------------------------------------------------

        /// <summary>
        ///  CARGAR DATOS DESDE FORMULARIO INICIO-CIERRE
        /// </summary>

        //--------Diccionario para cargar los datos a los marcadores del documento-------------
        private Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>
    {
        { "caratula", textBox_Caratula.Text },
        { "victima", textBox_Victima.Text },
        { "imputado", textBox_Imputado.Text },
        { "instructor", comboBox_Instructor.Text },
        { "secretario", comboBox_Secretario.Text },
        { "DeptoJudicial", comboBox_DeptoJudicial.Text },
         };
            return datosFormulario;
        }
        //----------------------------------------------------------------------

        /// <summary>
        /// METODO PARA VALIDAD Y ABRIR FORMULARIO AGREGAR DATOS VICTIMA
        /// </summary>
        private void Btn_AgregarDatosVictima_Click(object sender, EventArgs e)
        {
            if (agregarDatosPersonalesVictima == null || agregarDatosPersonalesVictima.IsDisposed)
            {
                agregarDatosPersonalesVictima = new AgregarDatosPersonalesVictima();

                // Suscribirse al evento personalizado del formulario de destino
                agregarDatosPersonalesVictima.VictimaTextChanged += UpdateVictimaTextBox;
            }

            // Establecer el texto inicial en el formulario de destino
            agregarDatosPersonalesVictima.TextoNombre = textBox_Victima.Text;

            // Suscribirse al evento TextChanged del TextBox en el formulario de origen
            textBox_Victima.TextChanged += (s, ev) =>
            {
                agregarDatosPersonalesVictima.TextoNombre = textBox_Victima.Text;
            };


            // Obtener el formulario original (inicioCierre)
            Form originalForm = this;

            // Obtener el tamaño de ambos formularios
            int totalWidth = originalForm.Width + agregarDatosPersonalesVictima.Width;
            int height = Math.Max(originalForm.Height, agregarDatosPersonalesVictima.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario agregarDatosPersonales a la izquierda del original
            agregarDatosPersonalesVictima.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesVictima.Location = new Point(startX, startY);

            // Posicionar el formulario original a la derecha del agregarDatosPersonales
            originalForm.Location = new Point(startX + agregarDatosPersonalesVictima.Width, startY);

            // Suscribirse al evento FormClosed del formulario Cargo
            agregarDatosPersonalesVictima.FormClosed += (s, args) =>
            {
                // Calcular la nueva posición para centrar el formulario original
                int centerX = (screenWidth - originalForm.Width) / 2;
                int centerY = (screenHeight - originalForm.Height) / 2;

                // Reposicionar el formulario original en el centro de la pantalla
                originalForm.Location = new Point(centerX, centerY);
            };

            agregarDatosPersonalesVictima.Show();

        }
        //---------------------------------------------------------------------------

        /// <summary>
        /// METODO PARA ACTUALIZAR TEXTBOX 'VICTIMA' DESDE FORM AGREGAR DATOS VICTIMA
        /// </summary>

        // Método para actualizar el TextBox en inicioCierre
        private void UpdateVictimaTextBox(string text)
        {
            textBox_Victima.Text = text;
        }
        //------------------------------------------------------------------------------

        /// <summary>
        /// METODO PARA HABILITAR BTN AGREGAR CAUSA
        /// </summary>

        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//habilita el btn_AgregarCausa en caso de tener texto
            ActualizarEstado();
        }
        //-------------------------------------------------------------------------------

        /// <summary>
        /// EVENTO PARA ABRIR FORMULARIO AGREGAR DATOS IMPUTADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AgregarDatosImputado_Click(object sender, EventArgs e)
        {
            if (agregarDatosPersonalesImputado == null || agregarDatosPersonalesImputado.IsDisposed)
            {
                agregarDatosPersonalesImputado = new AgregarDatosPersonalesImputado();

                // Suscribirse al evento personalizado del formulario de destino
                agregarDatosPersonalesImputado.ImputadoTextChanged += UpdateImputadoTextBox;
            }

            // Establecer el texto inicial en el formulario de destino
            agregarDatosPersonalesImputado.TextoNombre = textBox_Imputado.Text;

            // Suscribirse al evento TextChanged del TextBox en el formulario de origen
            textBox_Imputado.TextChanged += (s, ev) =>
            {
                agregarDatosPersonalesImputado.TextoNombre = textBox_Imputado.Text;
            };

            // Obtener el formulario original(inicioCierre)
            Form originalForm = this;

            // Obtener el tamaño de ambos formularios
            int totalWidth = originalForm.Width + agregarDatosPersonalesImputado.Width;
            int height = Math.Max(originalForm.Height, agregarDatosPersonalesImputado.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario agregarDatosPersonales a la izquierda del original
            agregarDatosPersonalesImputado.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesImputado.Location = new Point(startX, startY);

            // Posicionar el formulario original a la derecha del agregarDatosPersonales
            originalForm.Location = new Point(startX + agregarDatosPersonalesImputado.Width, startY);

            // Suscribirse al evento FormClosed del formulario Cargo
            agregarDatosPersonalesImputado.FormClosed += (s, args) =>
            {
                // Calcular la nueva posición para centrar el formulario original
                int centerX = (screenWidth - originalForm.Width) / 2;
                int centerY = (screenHeight - originalForm.Height) / 2;

                // Reposicionar el formulario original en el centro de la pantalla
                originalForm.Location = new Point(centerX, centerY);
            };

            agregarDatosPersonalesImputado.Show();
        }

        /// <summary>
        /// METODO PARA QUE SE ACTUALICE EL NOMBRE DEL IMPUTADO EN INICIOCIERRE DESDE EL FORM DATOS IMPUTADO
        /// </summary>
        /// <param name="text"></param>
        private void UpdateImputadoTextBox(string text)
        {
            textBox_Imputado.Text = text;
        }
        //---------------------------------------------------------------------

        /// <summary>
        /// METODOS PARA VALIDAR Y HABILITAR BOTON DESDE VICTIMA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Victima_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text))
            {
                btn_AgregarDatosVictima.BackColor = Color.GreenYellow;
                ActualizarEstado();
                if (agregarDatosPersonalesVictima != null && !agregarDatosPersonalesVictima.IsDisposed)
                {
                    // Actualizar el TextBox en el formulario de destino
                    agregarDatosPersonalesVictima.UpdateVictimaTextBox(textBox_Victima.Text);
                }
            }
            else
            {
                btn_AgregarDatosVictima.BackColor = Color.Tomato;

            }
            // Habilita o deshabilita btn_AgregarVictima según si el TextBox tiene texto
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
        }
        //----------------------------------------------------------------------------------
        /// <summary>
        /// METODOS PARA VALIDAR Y HABILITAR BOTON DESDE IMPUTADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBox_Imputado_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text))
            {
                btn_AgregarDatosImputado.BackColor = Color.GreenYellow;
                ActualizarEstado();
                if (agregarDatosPersonalesImputado != null && !agregarDatosPersonalesImputado.IsDisposed)
                {
                    // Actualizar el TextBox en el formulario de destino
                    agregarDatosPersonalesImputado.UpdateImputadoTextBox(textBox_Imputado.Text);
                }
            }
            else
            {
                btn_AgregarDatosImputado.BackColor = Color.Tomato;
            }
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);// deshabilita el btn agregarImputado si el textBox no tiene texto

        }
        //--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// EVENTO PARA AGREGAR CONTROL CARATULA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarCausa_Click(object sender, EventArgs e)
        {
            // Llamar al método en el UserControl para agregar el control
            NuevaCaratulaControl.NuevaCaratulaControlHelper.AgregarNuevoControl(panel_Caratula);

        }
        //---------------------------------------------------------------
        /// <summary>
        /// METODO PARA AGREGAR NUEVO CONTROL VICTIMA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AgregarVictima_Click(object sender, EventArgs e)
        {
            // Primero, valida todos los controles existentes en el panel
            bool controlesCompletos = ValidarControlesExistentes(panel_Victima);

            if (!controlesCompletos)
            {

                // Muestra un mensaje si algún control en el panel está vacío
                MensajeGeneral.Mostrar("Todos los campos en los controles existentes deben completarse antes de agregar una nueva víctima.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Sal de la función para evitar agregar un nuevo control
            }
            else
            {
                // Llamar al método en el UserControl para agregar el control
                NuevaPersonaControl.NuevaPersonaControlHelper.AgregarNuevoControl(panel_Victima, "Victima");

                // Agregar la nueva víctima a la lista
                string nuevaVictima = "Nombre de la nueva víctima";
                victimas.Add(nuevaVictima);

                // Actualizar la lista visual en el formulario, si corresponde
                //lstVictimas.Items.Add(nuevaVictima);
            }
        }
        //---------------------------------------------------------------
        /// <summary>
        /// METODO PARA AGREGAR NUEVO CONTROL IMPUTADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AgregarImputado_Click(object sender, EventArgs e)
        {
            // Primero, valida todos los controles existentes en el panel
            bool controlesCompletos = ValidarControlesExistentes(panel_Imputado);

            if (!controlesCompletos)
            {
                // Muestra un mensaje si algún control en el panel está vacío
                MensajeGeneral.Mostrar("Todos los campos en los controles existentes deben completarse antes de agregar un nuevo imputado.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Sal de la función para evitar agregar un nuevo control
            }
            else
            {
                // Llamar al método en el UserControl para agregar el control
                NuevaPersonaControl.NuevaPersonaControlHelper.AgregarNuevoControl(panel_Imputado, "Imputado");

                // Agregar el nuevo imputado a la lista
                string nuevoImputado = "Nombre del nuevo imputado"; // Aquí deberías obtener el nombre del imputado del nuevo control agregado
                imputados.Add(nuevoImputado);

            }
        }
        //....................................................
        /// <summary>
        /// METODO DE VALIDACION PARA VERIFICAR QUE ESTEN LOS CAMPOS COMPLETOS Y AGREGAR O NO CONTROL
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>

        private bool ValidarControlesExistentes(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                var personaControl = control as NuevaPersonaControl;
                if (personaControl != null && string.IsNullOrWhiteSpace(personaControl.TextBox_Persona.Text))
                {
                    return false; // Retorna false si se encuentra un control vacío
                }
            }
            return true; // Todos los controles están completos
        }
        //-------------------------------------------------------------------------

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
                pictureBox_CheckRatificacion.Visible = true;

                // Ajustar la posición del PictureBox con un desplazamiento de -5 en el eje Y
                pictureBox_CheckRatificacion.Location = new Point(
                    checkBox_RatificacionTestimonial.Location.X,
                    checkBox_RatificacionTestimonial.Location.Y - 8
                );

                // Ocultar el CheckBox
                checkBox_RatificacionTestimonial.Visible = false;

                // Crear y mostrar el formulario BuscarPersonal
                BuscarPersonal buscarPersonalForm = new BuscarPersonal();

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
                        pictureBox_CheckRatificacion.Visible = false;
                    }
                    else if (buscarPersonalForm.DialogResult == DialogResult.Yes)
                    {
                        checkBox_RatificacionTestimonial.Visible = false;
                        pictureBox_CheckRatificacion.Visible = true;
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

        //...........................................................
        /// <summary>
        /// METODO PARA VOLVER A CHECK VACIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPickture_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                if (clickedPictureBox.Name == "pictureBox_CheckRatificacion")
                {
                    // Manejar lógica para pictureBox_CheckRatificacion
                    pictureBox_CheckRatificacion.Visible = false;
                    checkBox_RatificacionTestimonial.Visible = true;
                    checkBox_RatificacionTestimonial.Checked = false;
                }
                else if (clickedPictureBox.Name == "pictureBox_CheckCargo")
                {
                    // Manejar lógica para pictureBox_CheckCargo
                    pictureBox_CheckCargo.Visible = false;
                    checkBox_Cargo.Visible = true;
                    checkBox_Cargo.Checked = false;
                }
            }
        }
        //-----------------------------------------------------------------------------

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
        //------------------------------------------------------------------------------

        /// <summary>
        /// INICIALIZAR COMBOX FISCALIA
        /// </summary>
        private void InicializarComboBoxFISCALIA()
        {
            // Obtener las listas de fiscalías, agentes fiscales, localidades y departamentos judiciales
            List<string> nombresFiscalias = FiscaliaManager.ObtenerNombresFiscalias().Distinct().ToList();
            List<string> agentesFiscales = FiscaliaManager.ObtenerAgentesFiscales().Distinct().ToList();
            List<string> localidades = FiscaliaManager.ObtenerLocalidades().Distinct().ToList();
            List<string> deptosJudiciales = FiscaliaManager.ObtenerDeptosJudiciales().Distinct().ToList();

            // Asignar las listas a los ComboBoxes correspondientes
            comboBox_Fiscalia.DataSource = nombresFiscalias;
            comboBox_AgenteFiscal.DataSource = agentesFiscales;
            comboBox_Localidad.DataSource = localidades;
            comboBox_DeptoJudicial.DataSource = deptosJudiciales;

            comboBox_Fiscalia.SelectedIndex = -1;
            comboBox_AgenteFiscal.SelectedIndex = -1;
            comboBox_Localidad.SelectedIndex = -1;
            comboBox_DeptoJudicial.SelectedIndex = -1;
        }
        //.....................................................

        private void ComboBox_Fiscalia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desactivar los ComboBoxes de detalle mientras se actualizan
            comboBox_AgenteFiscal.Enabled = false;
            comboBox_Localidad.Enabled = false;
            comboBox_DeptoJudicial.Enabled = false;

            // Verificar si hay un ítem seleccionado en el comboBox_Fiscalia
            if (comboBox_Fiscalia.SelectedItem != null)
            {
                string nombreFiscalia = comboBox_Fiscalia.SelectedItem.ToString();
                Fiscaliajson fiscalia = FiscaliaManager.ObtenerFiscaliaPorNombre(nombreFiscalia);

                if (fiscalia != null)
                {
                    // Asignar los valores de la fiscalía a los ComboBoxes correspondientes
                    comboBox_AgenteFiscal.DataSource = new List<string> { fiscalia.AgenteFiscal }.Distinct().ToList();
                    comboBox_Localidad.DataSource = new List<string> { fiscalia.Localidad }.Distinct().ToList();
                    comboBox_DeptoJudicial.DataSource = new List<string> { fiscalia.DeptoJudicial }.Distinct().ToList();
                    ActualizarEstado();
                }
                else
                {
                    // Si no se encuentra la fiscalía, limpiar los ComboBoxes
                    comboBox_AgenteFiscal.DataSource = null;
                    comboBox_Localidad.DataSource = null;
                    comboBox_DeptoJudicial.DataSource = null;
                }

                // Reactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.Enabled = true;
                comboBox_Localidad.Enabled = true;
                comboBox_DeptoJudicial.Enabled = true;
            }
            else
            {
                // Si no hay selección, limpiar y desactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.DataSource = null;
                comboBox_Localidad.DataSource = null;
                comboBox_DeptoJudicial.DataSource = null;

                comboBox_AgenteFiscal.Enabled = false;
                comboBox_Localidad.Enabled = false;
                comboBox_DeptoJudicial.Enabled = false;
            }
        }
        //----------------------------------------------------------------




        private void ComboBox_Localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza caracteres no válidos.
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convierte a mayúsculas.
            }
        }

        private void TextBox_Caratula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza caracteres no válidos.
            }
            else
            {
                // Convierte letras a mayúsculas y mantiene números y espacios sin cambios
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
        }

        private void ComboBox_AgenteFiscal_TextChanged(object sender, EventArgs e)
        {
            comboBox_AgenteFiscal.Text = ConvertirACamelCase.Convertir(comboBox_AgenteFiscal.Text);
            comboBox_AgenteFiscal.SelectionStart = comboBox_AgenteFiscal.Text.Length;
        }

        private void ComboBox_Ipp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Ipp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        //--Para habilitar check y modificar label
        private void ActualizarEstado()
        {
            // Verifica si cada campo no está vacío ni solo con espacios
            bool esTextoValidoNumeroIPP = !string.IsNullOrWhiteSpace(textBox_NumeroIpp.Text);
            bool esTextoValidoCaratula = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);
            bool esTextoValidoVictima = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            bool esTextoValidoImputado = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);
            bool esTextoValidoUfid = !string.IsNullOrWhiteSpace(comboBox_Fiscalia.Text);
            bool esTextoValidoInstructor = !string.IsNullOrWhiteSpace(comboBox_Instructor.Text);
            bool esTextoValidoSecretario = !string.IsNullOrWhiteSpace(comboBox_Secretario.Text);
            bool esTextoValidoDependencia = !string.IsNullOrWhiteSpace(comboBox_Dependencia.Text);


            // Todos los campos deben ser válidos para que esTextoValido sea verdadero
            bool esTextoValido = esTextoValidoNumeroIPP && esTextoValidoCaratula && esTextoValidoVictima &&
                                 esTextoValidoImputado && esTextoValidoUfid &&
                                 esTextoValidoInstructor && esTextoValidoSecretario && esTextoValidoDependencia;


            // Actualiza el color del label y el estado del checkbox según el estado de validación
            if (esTextoValido)
            {
                label_Cargo.ForeColor = Color.Black;
                label_Cargo.BackColor = Color.Transparent;
                checkBox_Cargo.Enabled = true;
                checkBox_Cargo.BackColor = Color.Transparent;

                label_Not247.ForeColor = Color.Black;
                label_Not247.BackColor = Color.Transparent;
                botonDeslizable_Not247.Enabled = true;// habilitar btn 247
                botonDeslizable_Not247.BackColor = Color.Transparent;


                Btn_ContadorRML.Visible = true;
                label_StudRML.Visible = true;

            }
            else
            {
                label_Cargo.ForeColor = Color.Tomato;
                label_Cargo.BackColor = Color.FromArgb(211, 211, 211); // Gris claro
                checkBox_Cargo.Enabled = false;
                checkBox_Cargo.BackColor = Color.Tomato;

                label_Not247.ForeColor = Color.Tomato;
                label_Not247.BackColor = Color.FromArgb(211, 211, 211);
                botonDeslizable_Not247.Enabled = false;// deshabilitar btn 247
                botonDeslizable_Not247.BackColor = Color.FromArgb(211, 211, 211);

                Btn_ContadorRML.Visible = false;
                label_StudRML.Visible = false;


            }
        }
        //--------------------------------------------------------------------


        //------------------------------------------------------------------
        private void CheckBox_Cargo_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkBox_Cargo.Checked)
            {
                pictureBox_CheckCargo.Visible = true;

                // Ajustar la posición del PictureBox con un desplazamiento de -5 en el eje Y
                pictureBox_CheckCargo.Location = new Point(
                    checkBox_Cargo.Location.X,
                    checkBox_Cargo.Location.Y - 5
                );
                // Ocultar el CheckBox
                checkBox_Cargo.Visible = false;

                string Ipp1 = comboBox_Ipp1.Text;
                string Ipp2 = comboBox_Ipp2.Text;
                string NumeroIpp = textBox_NumeroIpp.Text;
                string Ipp4 = comboBox_Ipp4.Text;
                string Caratula = textBox_Caratula.Text;
                string Victima = textBox_Victima.Text;
                string Imputado = textBox_Imputado.Text;
                string Fiscalia = comboBox_Fiscalia.Text;
                string AgenteFiscal = comboBox_AgenteFiscal.Text;
                string Localidad = comboBox_Localidad.Text;
                string Instructor = comboBox_Instructor.Text;
                string Secretario = comboBox_Secretario.Text;
                string Dependencia = comboBox_Dependencia.Text;

                // Crear y mostrar el formulario CARGO, pasando los valores obtenidos
                Cargo cargo = new Cargo(Ipp1, Ipp2, NumeroIpp, Ipp4, Caratula, Victima, Imputado,
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
                        pictureBox_CheckCargo.Visible = false;
                    }
                    else
                    {
                        checkBox_Cargo.Visible = false;
                        pictureBox_CheckCargo.Visible = true;
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

        //________________________________________________________________________________________
        //---para que permita desbloquear check cargo tambien con texto

        // Este método maneja la lógica común para desmarcar el CheckBox
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
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                // Guarda la posición actual del cursor para evitar perderla
                int cursorPosition = comboBox.SelectionStart;

                // Convierte el texto a camelCase
                string textoConvertido = ConvertirACamelCase.Convertir(comboBox.Text);

                // Actualiza el texto del ComboBox
                comboBox.Text = textoConvertido;

                // Mueve el cursor al final del texto
                comboBox.SelectionStart = comboBox.Text.Length;
                comboBox.SelectionLength = 0; // Opcional, para asegurarse de que no haya selección activa
            }
            ActualizarEstado();
        }
        private void SetupBotonDeslizable()
        {
            botonDeslizable_Not247.ValidarCampos = () =>
            {
                // Validar campos completos
                if (!ValidarControlesCompletosEnPaneles())
                {
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
                    DateTime fechaBase = timePickerPersonalizado1.SelectedDate;

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

                        fecha_Pericia.Text = fechaSeleccionada.Value.ToString("dd/MM/yyyy");
                        fecha_Pericia.Visible = true;
                        fecha_Pericia.Enabled = true;
                        panel_Not247.BackColor = SystemColors.GradientInactiveCaption;

                        Btn_Contador247.Visible = true;
                        Btn_Contador247.Text = "3"; // Por FISCALIA, DEFENSORIA, JUZ.GTIAS + imputados y víctimas
                    }
                    else
                    {
                        // En caso de no seleccionar una fecha
                        botonDeslizable_Not247.Location = new Point(botonDeslizable_Not247.Location.X + 10,botonDeslizable_Not247.Location.Y);
                        panel_Not247.BackColor=Color.Transparent;
                        fecha_Pericia.Visible = false;
                        fecha_Pericia.Enabled=false;
                        Btn_Contador247.Visible = false;
                        botonDeslizable_Not247.IsOn = false;
                    }
                }

                return botonDeslizable_Not247.IsOn;
            };
        }


        //--Para verificar los controles y habilitar boton
        private bool ValidarControlesCompletosEnPaneles()
        {
            // Verificar los paneles uno por uno
            bool camposIncompletos = false;

            camposIncompletos |= !VerificarPanelCompleto(panel_Ipp);
            camposIncompletos |= !VerificarPanelCompleto(panel_Caratula);
            camposIncompletos |= !VerificarPanelCompleto(panel_Victima);
            camposIncompletos |= !VerificarPanelCompleto(panel_Imputado);
            camposIncompletos |= !VerificarPanelCompleto(panel_Instruccion);
            botonDeslizable_Not247.IsOn = true;
            return !camposIncompletos;// Devuelve verdadero si todos los campos están completos

        }

        private bool VerificarPanelCompleto(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                // Verificar si el control es un TextBox y está vacío
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return false; // Campo incompleto
                }

                // Verificar si el control es un ComboBox y no tiene un elemento seleccionado
                if (control is ComboBox comboBox && string.IsNullOrWhiteSpace(comboBox.Text))
                {
                    return false; // Campo incompleto si el texto está vacío
                }


            }
            return true; // Todos los campos en el panel están completos
        }
        //---------------------------------------------------------------------------

        /// <summary>
        /// para que muestre mensaje de advertencia previo cerrar formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void InicioCierre_FormClosing(object sender, FormClosingEventArgs e)
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
        //--------------------------------------------------------------------

        private void Fecha_Audiencia(object sender, EventArgs e)
        {
            if (sender is TimePickerPersonalizado control)
            {
                // Tomar la fecha seleccionada del TimePicker
                DateTime nuevaFecha = control.SelectedDate;

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

        private void fecha_Pericia_Click(object sender, EventArgs e)
        {

            // Configurar fecha mínima basada en otro TimePicker
            DateTime fechaBase = timePickerPersonalizado1.SelectedDate;
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

        private void fecha_Pericia_Enter(object sender, EventArgs e)
        {
            fecha_Pericia.BackColor = Color.Crimson;
            fecha_Pericia.ForeColor = Color.White;
        }

        private void fecha_Pericia_Leave(object sender, EventArgs e)
        {
            fecha_Pericia.BackColor = SystemColors.ActiveCaption; // Cambiar el color de fondo al color de control activo
            fecha_Pericia.ForeColor = SystemColors.WindowText; // Cambiar el color del texto al color de texto de la ventana

            //// Verificar si el texto ingresado es una fecha válida
            //if (DateTime.TryParse(fecha_Pericia.Text, out DateTime fechaIngresada))
            //{
            //    // Comparar la fecha ingresada con la fecha de instrucción
            //    if (fechaIngresada < timePickerPersonalizado1.SelectedDate)
            //    {
            //        MensajeGeneral.Mostrar("La fecha no puede ser anterior a la fecha de instrucción.", MensajeGeneral.TipoMensaje.Advertencia);
            //        fecha_Pericia.Focus(); // Opcional: volver a poner el foco en el control
            //        fecha_Pericia.Clear(); // Opcional: limpiar el texto ingresado
            //    }
            //}
            //else
            //{
            //    MensajeGeneral.Mostrar("La fecha ingresada no es válida. Por favor, ingrese una fecha en el formato correcto.", MensajeGeneral.TipoMensaje.Error);
            //    fecha_Pericia.Focus(); // Opcional: volver a poner el foco en el control
            //    fecha_Pericia.Clear(); // Opcional: limpiar el texto ingresado

            //}
        }


            private void fecha_Pericia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Verificar si el texto ingresado es una fecha válida
            if (DateTime.TryParse(fecha_Pericia.Text, out DateTime fechaIngresada))
            {
                // Comparar la fecha ingresada con la fecha de instrucción
                if (fechaIngresada < timePickerPersonalizado1.SelectedDate)
                {
                    MensajeGeneral.Mostrar("La fecha no puede ser anterior a la fecha de instrucción.", MensajeGeneral.TipoMensaje.Advertencia);
                    fecha_Pericia.Focus(); // Opcional: volver a poner el foco en el control
                    fecha_Pericia.Clear(); // Opcional: limpiar el texto ingresado
                }
            }
            else
            {
                MensajeGeneral.Mostrar("La fecha ingresada no es válida. Por favor, ingrese una fecha en el formato correcto.", MensajeGeneral.TipoMensaje.Error);
                fecha_Pericia.Focus(); // Opcional: volver a poner el foco en el control
                fecha_Pericia.Clear(); // Opcional: limpiar el texto ingresado
            }

        }
        //-------------------------------------------------------------

    }
}