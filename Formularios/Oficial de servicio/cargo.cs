
using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.GenerarDocumentos;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.General;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Ofelia_Sara.Controles.General;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Cargo : BaseForm

    {
        private int alturaOriginalPanel_Descripcion;
        private int alturaOriginalPanel_Instruccion;
        private int alturaContraidaPanel = 30; //altura de panel contraido
        private bool panelExpandido_Instruccion = true;// Variable para rastrear el estado del panel
        private bool panelExpandido_Descripcion = true;// 
        
       
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public Cargo()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            CargarDatosDependencia(comboBox_Dependencia, dbManager);
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
            CargarDatosSecretario(comboBox_Secretario, secretariosManager);

            botonDeslizable_Visu.IsOnChanged += botonDeslizable_Visu_IsOnChanged;

            label_Descripcion.BringToFront();
            pictureBox_Descripcion.BringToFront();

            //para q se actualize imagen de panel descripcion
            richTextBox_Descripcion.TextChanged += (sender, e) => ValidarPanelDescripcion();
            panel_ControlesInferiores.Visible = false;// inicialice no visible
            panel_Descripcion.Visible = true;

            AjustarTamanoFormulario();//para cargar formulario con tamaño ajustado
        }
        //---FIN CONSTRUCTOR----------------

        //---sobrecargar para que reciba los datos desde form iniciocierre
        public Cargo(string ipp1, string ipp2, string numeroIpp, string ipp4, string caratula,
                 string victima, string imputado, string fiscalia, string agenteFiscal, string localidad,
                 string instructor, string secretario, string dependencia)
        {
            InitializeComponent();

            // Asignar los valores a los controles específicos del formulario
            comboBox_Ipp1.Text = ipp1;
            comboBox_Ipp2.Text = ipp2;
            textBox_NumeroIpp.Text = numeroIpp;
            comboBox_Ipp4.Text = ipp4;
            textBox_Caratula.Text = caratula;
            textBox_Victima.Text = victima;
            textBox_Imputado.Text = imputado;
            comboBox_Fiscalia.Text = fiscalia;  // Asignación al control
            comboBox_AgenteFiscal.Text = agenteFiscal;
            comboBox_Localidad.Text = localidad;
            comboBox_Instructor.Text = instructor;
            comboBox_Secretario.Text = secretario;
            comboBox_Dependencia.Text = dependencia;

        }
        //-------FIN SOBRECARGA--------------------------------

        private void Cargo_Load(object sender, EventArgs e)
        {
            this.FormClosing += BuscarPersonal_FormClosing;
            textBox_NumeroCargo.MaxLength = 4;//limita a 4 caracteres el numero de cargo
            this.Shown += Focus_Shown;//para que haga foco en un textBox
            textBox_NumeroIpp.MaxLength = 6;
            comboBox_Ipp1.InnerTextBox.MaxLength = 2;
            comboBox_Ipp2.InnerTextBox.MaxLength = 2;
            comboBox_Ipp4.InnerTextBox.MaxLength = 2;

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarCausa);
            InicializarEstiloBotonAgregar(btn_AgregarVictima);
            InicializarEstiloBotonAgregar(btn_AgregarImputado);

            MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            MayusculaSola.AplicarAControl(textBox_Victima);
            MayusculaSola.AplicarAControl(textBox_Imputado);
            MayusculaSola.AplicarAControl(comboBox_Localidad.InnerTextBox);

            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            Fecha_Instruccion.SelectedDate = DateTime.Now;//para tomar el dia actual

            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);

            pictureBox_CheckLegajoVehicular.Visible = false;// para ocultar el check realizado


            //.....................................................
            //// Guardar la altura original del panel
            alturaOriginalPanel_Instruccion = panel_Instruccion.Height;
            alturaOriginalPanel_Descripcion = panel_Descripcion.Height;
            //...................................................
            ValidarPanelDatosInstruccion();
            ValidarPanelDescripcion();
            //para que se carge el panel INSTRUCION contraido
            if (panelExpandido_Instruccion)
            {
                // Contraer el panel
                panel_Instruccion.Height = alturaContraidaPanel;
                btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Instruccion = false; //PANEL CONTRAIDO
                panel_Instruccion.BorderStyle = BorderStyle.FixedSingle;

                // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                btn_AmpliarReducir_INSTRUCCION.Parent = panel_Instruccion;
                btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(422, 0);
                // Ocultar todos los controles excepto el botón de ampliación/reducción
                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    if (control == btn_AmpliarReducir_INSTRUCCION)
                    {
                        control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                    }
                    else
                    {
                        control.Visible = false; // Oculta los demás controles
                        panel_DatosInstruccion.Visible = false;
                    }
                }
            }
           AjustarTamanoFormulario();// para que carge con altura de formulario ajustada
        }

        //-------FIN  LOAD------------------
        private void botonDeslizable_Visu_IsOnChanged(object sender, EventArgs e)
        {
            try
            {
                if (botonDeslizable_Visu.IsOn)
                {
                    // Recolectar datos
                    string ipp1 = comboBox_Ipp1.Text;
                    string ipp2 = comboBox_Ipp2.Text;
                    string numeroIpp = textBox_NumeroIpp.Text;
                    string ipp4 = comboBox_Ipp4.Text;
                    string caratula = textBox_Caratula.Text;
                    string victima = textBox_Victima.Text;
                    string imputado = textBox_Imputado.Text;
                    string fiscalia = comboBox_Fiscalia.Text;
                    string agenteFiscal = comboBox_AgenteFiscal.Text;
                    string localidad = comboBox_Localidad.Text;
                    string instructor = comboBox_Instructor.Text;
                    string secretario = comboBox_Secretario.Text;
                    string dependencia = comboBox_Dependencia.Text;

                    // Crear el formulario Visu con los datos recolectados
                    Visu visu = new Visu(ipp1, ipp2, numeroIpp, ipp4, caratula, victima, imputado,
                                         fiscalia, agenteFiscal, localidad, instructor, secretario, dependencia);

                    // Guardar el formulario actual (Cargo) y su posición original
                    Form formCargo = this;
                    Point posicionOriginalCargo = formCargo.Location;

                    // Obtener el formulario inicio_cierre y guardar su posición original
                    Form inicioCierre = Application.OpenForms["inicio_cierre"];
                    Point posicionOriginalInicioCierre = inicioCierre != null ? inicioCierre.Location : Point.Empty;

                    // Ocultar formularios visibles excepto Cargo
                    List<Form> formsToHide = Application.OpenForms.Cast<Form>()
                        .Where(f => f.Visible && f != formCargo && f != visu)
                        .ToList();

                    foreach (Form f in formsToHide)
                    {
                        f.Hide();
                    }

                    // Restaurar la posición de Cargo antes de mostrar Visu
                    formCargo.Location = posicionOriginalCargo;

                    // Obtener dimensiones de la pantalla
                    int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                    int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                    // Calcular posiciones
                    int margenSuperior = (int)(screenHeight * 0.15); // 15% del margen superior
                    int centerX = (screenWidth - formCargo.Width - visu.Width) / 2;

                    // Asignar las posiciones a los formularios
                    formCargo.Location = new Point(centerX, margenSuperior);
                    visu.StartPosition = FormStartPosition.Manual;
                    visu.Location = new Point(centerX + formCargo.Width + 10, margenSuperior);

                    // Posicionar los formularios
                    formCargo.Location = new Point(centerX, margenSuperior);
                    visu.StartPosition = FormStartPosition.Manual;
                    visu.Location = new Point(centerX + formCargo.Width, margenSuperior);

                    // Manejar el cierre del formulario Visu
                    visu.FormClosed += (s, args) =>
                    {
                        // Restaurar inicio_cierre si estaba oculto
                        if (inicioCierre != null)
                        {
                            inicioCierre.Show();
                            inicioCierre.Location = posicionOriginalInicioCierre;
                            inicioCierre.BringToFront();
                        }

                        // Restaurar los formularios previamente ocultos
                        foreach (Form f in formsToHide)
                        {
                            f.Show();
                            f.BringToFront();
                        }

                        // Manejar el estado del botón deslizante
                        botonDeslizable_Visu.IsOn = visu.DialogResult == DialogResult.OK ? false : true;

                        // Volver a la posición original de Cargo
                        formCargo.Location = posicionOriginalCargo;
                    };

                    // Mostrar el formulario Visu como diálogo
                    visu.Show();
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al abrir el formulario Visu: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }



        //-----------------------------------------------------
        /// <summary>
        /// METODO PARA DAR FOCO EN NUMERO DE CARGO, AL ABRIR FORMULARIO
        /// </summary>

        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox
            textBox_NumeroCargo.Focus();
        }
        //-----------------------------------------------------------------------
        private void HabilitaBTN_Agregar_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                switch (textBox.Name)
                {
                    case "textBox_Caratula":
                        btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
                        break;

                    case "textBox_Victima":
                        btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
                        break;

                    case "textBox_Imputado":
                        btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
                        break;

                    default:
                        break;
                }
            }
        }

        //----------------------------------------------------------------------------------
        private void InicializarComboBoxFISCALIA()
        {

            // Obtener las listas de fiscalías, agentes fiscales, localidades y departamentos judiciales
            List<string> nombresFiscalias = FiscaliaManager.ObtenerNombresFiscalias().Distinct().ToList();
            List<string> agentesFiscales = FiscaliaManager.ObtenerAgentesFiscales().Distinct().ToList();
            List<string> localidades = FiscaliaManager.ObtenerLocalidades().Distinct().ToList();

            // Asignar las listas a los ComboBoxes correspondientes
            comboBox_Fiscalia.DataSource = nombresFiscalias;
            comboBox_AgenteFiscal.DataSource = agentesFiscales;
            comboBox_Localidad.DataSource = localidades;

            comboBox_Fiscalia.SelectedIndex = -1;
            comboBox_AgenteFiscal.SelectedIndex = -1;
            comboBox_Localidad.SelectedIndex = -1;
        }

        private void ComboBox_Fiscalia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desactivar los ComboBoxes de detalle mientras se actualizan
            comboBox_AgenteFiscal.Enabled = false;
            comboBox_Localidad.Enabled = false;

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

                }
                else
                {
                    // Si no se encuentra la fiscalía, limpiar los ComboBoxes
                    comboBox_AgenteFiscal.DataSource = null;
                    comboBox_Localidad.DataSource = null;

                }

                // Reactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.Enabled = true;
                comboBox_Localidad.Enabled = true;
            }
            else
            {
                // Si no hay selección, limpiar y desactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.DataSource = null;
                comboBox_Localidad.DataSource = null;

                comboBox_AgenteFiscal.Enabled = false;
                comboBox_Localidad.Enabled = false;

            }
        }
        //----------------------------------------------------------------
        private void InicializarComboBoxSECRETARIO()
        {
            List<SecretarioJson> secretarios = SecretarioManager.ObtenerSecretarios();
            comboBox_Secretario.DataSource = secretarios;
            comboBox_Secretario.DisplayMember = "DescripcionCompleta";
            comboBox_Secretario.SelectedIndex = -1;
        }
        //---------------------------------------------------------------------
        private void InicializarComboBoxINSTRUCTOR()
        {
            List<InstructorJson> instructores = InstructorManager.ObtenerInstructores();
            comboBox_Instructor.DataSource = instructores;
            comboBox_Instructor.DisplayMember = "DescripcionCompleta";
            comboBox_Instructor.SelectedIndex = -1;
        }
        //------------------------------------------------------------------------
        private void InicializarComboBoxDEPENDENCIAS()
        {
            List<DependenciasPoliciales> dependencias = DependenciaManager.ObtenerDependencias();
            comboBox_Dependencia.DataSource = dependencias;
            comboBox_Dependencia.DisplayMember = "Dependencia";
            comboBox_Dependencia.SelectedIndex = -1;
        }


        private void comboBox_Localidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            checkBox_LegajoVehicular.Visible = true;

            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxSECRETARIO();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxINSTRUCTOR();
            InicializarComboBoxDEPENDENCIAS();

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion); ;


        }
        //-----------------------------------------------------------------------------------

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos básicos están completos
            if (!ValidarAntesdeGuardar()) // Verificación usando ErrorProvider
            {
                // Mostrar mensaje de advertencia si hay errores
                MensajeGeneral.Mostrar("Debe completar los campos requeridos.",
                                       MensajeGeneral.TipoMensaje.Advertencia);
                return; // Detener la ejecución si hay errores
            }

            datosGuardados = true; // Evitar mensaje de alerta al cerrar el formulario
                                   // Mostrar mensaje de confirmación al guardar exitosamente
            MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);
        }


        private bool ValidarAntesdeGuardar()
        {
            bool esValido = false;

            // Validar campos requeridos
            esValido &= ValidarCampo(comboBox_Instructor, "Debe indicar quien es el Instructor de las actuaciones.");
            esValido &= ValidarCampo(comboBox_Secretario, "Debe indicar quien es el Secretario de las actuaciones.");
            esValido &= ValidarCampo(comboBox_Dependencia, "El campo 'Dependencia' es obligatorio.");
            esValido &= ValidarCampo(comboBox_Fiscalia, "El campo 'FISCALIA' es obligatorio.");
            esValido &= ValidarCampo(textBox_Caratula, "El campo 'Carátula' es obligatorio.");
            esValido &= ValidarCampo(textBox_Imputado, "El campo 'Imputado' es obligatorio.");
            esValido &= ValidarCampo(textBox_Victima, "El campo 'Víctima' es obligatorio.");
            esValido &= ValidarCampo(textBox_NumeroCargo, "Ingrese 'N° CARGO' correspondiente.");
            esValido &= ValidarCampo(textBox_NumeroIpp, "Ingrese 'N° IPP' correspondiente.");

            return esValido;
        }

        private bool ValidarCampo(Control control, string mensajeError)
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

        //---------------------------------------------------------------------------------

        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void BuscarPersonal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void textBox_NumeroCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }
 
        /// <summary>
        /// PARA VALIDAR LIMITE DE 2 NUMEROS EN NUMEROS DE IPP
        /// </summary>
       

        private void comboBox_Ipp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        /// <summary>
        /// PARA LIMITAR Y AUTOCOMPLETAR CON 0 NUMERO IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
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
                System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

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



        private void textBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {
            // Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;

            }
        }

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
        private void Cargo_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Complete los campos y una descripcion de la muestra, para poder generar el cargo", MensajeGeneral.TipoMensaje.Advertencia);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //--------------------------------------------------------------------------------------
        //---Validar datos previo impresion 
        private bool ValidarAntesde_IMPRIMIR()
        {
            //Verificar si los campos están completados
            if (ValidarAntesdeGuardar())

            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MensajeGeneral.Mostrar("Debe completar la totalidad de campos para generar el documento ", MensajeGeneral.TipoMensaje.Advertencia);
                return false; // Indica que la validación falló
            }
            //validacion especial numero cargo
            if (string.IsNullOrWhiteSpace(textBox_NumeroCargo.Text))
            {
                MensajeGeneral.Mostrar("Debe ingresar el numero de CARGO", MensajeGeneral.TipoMensaje.Advertencia);
                textBox_NumeroCargo.Focus();
                return false; // Detener el proceso si no hay texto válido
            }


            // validad Descripcion de la muestra
            if (string.IsNullOrWhiteSpace(richTextBox_Descripcion.Text))
            {
                MensajeGeneral.Mostrar("Describa la muestra del cargo", MensajeGeneral.TipoMensaje.Advertencia);
                richTextBox_Descripcion.Focus();
                return false; // Detener el proceso si no hay texto válido
            }


            // Validar ComboBox FISCALIA
            if (comboBox_Fiscalia.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Fiscalia.Text))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese una nacionalidad.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Fiscalia.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Instructor
            if (comboBox_Instructor.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Instructor.Text))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese un instructor.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Instructor.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Secretario
            if (comboBox_Secretario.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Secretario.Text))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese un Secretario.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Secretario.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Dependencia
            if (comboBox_Dependencia.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese una Dependencia.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Dependencia.Focus();
                return false; // Detener el proceso si no hay selección válida
            }
            return true; // Indica que la validación fue exitosa
        }

        //------------------------------------------------------------------------------------------------
        //   METODO PARA OBTENER DATOS DEL FORMULARIO

        public Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>();

            // Verificar si los datos del formulario son válidos
            if (datosFormulario == null)
            {
                // Detener la generación de documentos si hay algún error
                return null;
            }



            // Añadimos los valores de los controles al diccionario
            
            datosFormulario.Add("NumeroIpp", textBox_NumeroIpp.Text);
            datosFormulario.Add("Caratula", textBox_Caratula.Text);
            datosFormulario.Add("Victima", textBox_Victima.Text);
            datosFormulario.Add("Imputado", textBox_Imputado.Text);

            datosFormulario.Add("Fiscalia", comboBox_Fiscalia.SelectedItem.ToString());
            datosFormulario.Add("AgenteFiscal", comboBox_AgenteFiscal.SelectedItem.ToString());
            datosFormulario.Add("Localidad", comboBox_Localidad.SelectedItem.ToString());

            datosFormulario.Add("Instructor", comboBox_Instructor.SelectedItem.ToString());
            datosFormulario.Add("Secretario", comboBox_Secretario.SelectedItem.ToString());
            datosFormulario.Add("Dependencia", comboBox_Dependencia.SelectedItem.ToString());
            datosFormulario.Add("Fecha_Instruccion", Fecha_Instruccion.SelectedDate.ToString("dd/MM/yyyy"));



            return datosFormulario;
        }
        //------------------------------------------------------------------------------------
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            
            // Llamar al método de validación
            if (!ValidarAntesde_IMPRIMIR())
            {
                return; // Detener el proceso si la validación falla
            }
            datosGuardados = true;
            // Usar FolderBrowserDialog para obtener la ruta donde el usuario quiere guardar los documentos
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Seleccione la carpeta donde desea guardar los documentos generados";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Ruta donde el usuario quiere guardar los documentos
                    string rutaCarpetaSalida = folderBrowserDialog.SelectedPath;

                    // Obtener el texto de textBox_Apellido y formar el nombre de la carpeta
                    string nombreCarpeta = $"Cargo {textBox_NumeroCargo.Text}";
                    string rutaSubcarpeta = Path.Combine(rutaCarpetaSalida, nombreCarpeta);

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(rutaSubcarpeta))
                    {
                        Directory.CreateDirectory(rutaSubcarpeta);
                    }

                    // rutas de las plantillas-->DEBEN REEMPLASARSE A RUTAS RELATIVAS
                    string rutaPlantillaCargo = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\IPP\CARGO JUDICIAL.docx";
                    string rutaPlantillaCadenaCustodia = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\IPP\CADENA DE CUSTODIA.docx";
                    string rutaPlantillaFaja = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\IPP\FAJA DE SECUESTRO.doc";
                    string rutaPlantillaVisu = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\IPP\VISU.docx";

                    // Obtener los datos del formulario
                    var datosFormulario = ObtenerDatosFormulario();

                    // Generar cada documento con su respectiva plantilla y guardarlo en la carpeta
                    GeneradorDocumentos generador = new GeneradorDocumentos();
                    generador.GenerarYGuardarDocumento(rutaPlantillaCargo, rutaSubcarpeta, "CARGO", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaCadenaCustodia, rutaSubcarpeta, "CADENA DE CUSTODIA", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaFaja, rutaSubcarpeta, "FAJA SECUESTRO", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaVisu, rutaSubcarpeta, "VISU", datosFormulario);

                    // Mostrar mensaje de éxito
                    // MessageBox.Show("Los documentos han sido generados correctamente.");

                    MensajeCargarImprimir mensajeCargarImprimir = new MensajeCargarImprimir();
                    mensajeCargarImprimir.ShowDialog();

                    // Abrir la ubicación de la carpeta generada
                    System.Diagnostics.Process.Start("explorer.exe", rutaSubcarpeta);
                }
            }
        }

        private void pictureBox_CheckLegajoVehicular_Click(object sender, EventArgs e)
        {

            // Manejar lógica para pictureBox_CheckRatificacion
            pictureBox_CheckLegajoVehicular.Visible = false;
            checkBox_LegajoVehicular.Visible = true;
            checkBox_LegajoVehicular.Checked = false;


        }

        private void checkBox_LegajoVehicular_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkBox_LegajoVehicular.Checked)
            {
                pictureBox_CheckLegajoVehicular.Visible = true;
                // Ajustar la posición del PictureBox con un desplazamiento de -5 en el eje Y
                pictureBox_CheckLegajoVehicular.Location = new Point(
                    checkBox_LegajoVehicular.Location.X,
                    checkBox_LegajoVehicular.Location.Y-8);
            }
        }

        /// <summary>
        /// METODOS PARA LOS BOTONES AMPLIAR Y REDUCIR PANELES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_AmpliarReducir_INSTRUCCION_Click(object sender, EventArgs e)
        {
            if (panel_Instruccion is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Instruccion)
                {
                    // Contraer el panel
                    panel_Instruccion.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Instruccion = false; //PANEL CONTRAIDO

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

                    // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                    btn_AmpliarReducir_INSTRUCCION.Parent = panel_Instruccion;
                    btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(422, 0);


                    // Ocultar todos los controles excepto el botón de ampliación/reducción
                    foreach (Control control in panel_DatosInstruccion.Controls)
                    {
                        if (control == btn_AmpliarReducir_INSTRUCCION)
                        {
                            control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                        }
                        else
                        {
                            control.Visible = false; // Oculta los demás controles
                            panel_DatosInstruccion.Visible = false;
                        }
                    }

                    // Ocultar controles de error personalizados
                    foreach (Control control in panel_DatosInstruccion.Controls)
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
                    panel_Instruccion.Height = alturaOriginalPanel_Instruccion;
                    panel_Instruccion.BorderStyle = BorderStyle.None;
                    btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                    panelExpandido_Instruccion = true;
                    panel_DatosInstruccion.Visible = true;
                    label_DatosInstruccion.BringToFront();
                    pictureBox_PanelInstruccion.BringToFront();

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_INSTRUCCION.Parent = panel_DatosInstruccion;
                    btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(418, 0);

                    // Mostrar todos los controles
                    foreach (Control control in panel_DatosInstruccion.Controls)
                    {
                        control.Visible = true;
                    }

                    // Asegurarte de que las imágenes de error se muestren si es necesario
                    foreach (Control control in panel_DatosInstruccion.Controls)
                    {
                        if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                        {
                            control.Visible = true; // Mostrar imágenes de error
                        }
                    }
                    panel_DatosInstruccion.Visible = true;
                }
                AjustarTamanoFormulario();
            }

        }


        /// <summary>
        /// METODO PARA VALIDAR DAROS DE LOS PANELES
        /// </summary>

        private void ValidarPanelDatosInstruccion()
        {
            bool camposValidos = true;



            // Iterar sobre los controles dentro del panel
            foreach (Control control in panel_DatosInstruccion.Controls)
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
                pictureBox_PanelInstruccion.Image = Properties.Resources.verificacion_exitosa; // Imagen personalizada para validación correcta
                pictureBox_PanelInstruccion.BackColor = Color.Transparent; // Fondo transparente
                label_DatosInstruccion.BackColor = Color.FromArgb(4, 200, 0); // resalta con color verde más brillante que el original

            }
            else
            {
                pictureBox_PanelInstruccion.Image = Properties.Resources.Advertencia_Faltante; // Imagen para error
                pictureBox_PanelInstruccion.BackColor = Color.Transparent; // Fondo transparente
                label_DatosInstruccion.BackColor = Color.FromArgb(0, 192, 192); // retoma color original verde agua

            }

            // Ajustar la posición del pictureBox al lado del label
            pictureBox_PanelInstruccion.Location = new System.Drawing.Point(
                label_DatosInstruccion.Right + 5, // A la derecha del label con un margen de 5 px
                label_DatosInstruccion.Top + (label_DatosInstruccion.Height - pictureBox_PanelInstruccion.Height) / 2 // Centrado verticalmente
            );

            // Configurar el tamaño de la imagen para que abarque todo el contenedor del pictureBox
            pictureBox_PanelInstruccion.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asegurarse de que el pictureBox sea visible
            pictureBox_PanelInstruccion.Visible = true;
        }

     
        /// <summary>
        /// PARA AMPLIAR Y REDUCIR EL AREA DESCRIPCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AmpliarReducir_DESCRIPCION_Click(object sender, EventArgs e)
        {
            // Verificar si el panel es de tipo PanelConBordeNeon
            if (panel_Descripcion is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Descripcion)
                {
                    // Contraer el panel
                    panelConNeon.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_DESCRIPCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Descripcion = false;

                    // Aplicar borde neón para el estado contraído
                    bool camposCompletos = VerificarCamposEnPanel(panelConNeon); // Método personalizado para verificar campos
                    panelConNeon.CambiarEstado(true, camposCompletos);

                    foreach (Control control in panelConNeon.Controls)
                    {
                        if (control == btn_AmpliarReducir_DESCRIPCION ||
                            control == label_Descripcion ||
                            control == pictureBox_Descripcion) // Compara directamente el control
                        {
                            control.Visible = true; // Mantener visible
                        }
                        else
                        {
                            control.Visible = false; // Ocultar los demás controles
                        }
                    }
                }
                else
                {
                    // Expandir el panel
                    panelConNeon.Height = alturaOriginalPanel_Descripcion;
                    btn_AmpliarReducir_DESCRIPCION.Image = Properties.Resources.dobleFlechaARRIBA;
                    panelExpandido_Descripcion = true;

                    // Eliminar el efecto neón para el estado expandido
                    panelConNeon.CambiarEstado(false, false);

                    // Mostrar los demás controles del panel
                    foreach (Control control in panelConNeon.Controls)
                    {
                        control.Visible = true;
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
                    if (pictureBox.Image == null || pictureBox.Image == Properties.Resources.agregar_imagen)
                    {
                        return false; // Campo PictureBox sin imagen válida
                    }
                }
            }
            return true; // Todos los campos están completos
        }
        // METODO PARA VALIDAR DATOS EN PANEL DESCRIPCION
        private void ValidarPanelDescripcion()
        {
            bool camposValidos = !string.IsNullOrWhiteSpace(richTextBox_Descripcion.Text);

            if (camposValidos)
            {
                pictureBox_Descripcion.Image = Properties.Resources.verificacion_exitosa; // Imagen personalizada para validación correcta
                pictureBox_Descripcion.BackColor = Color.Transparent; // Fondo transparente
                label_Descripcion.BackColor = Color.FromArgb(4, 200, 0); // Resalta con color verde más brillante que el original
                panel_ControlesInferiores.Visible = true;
            }
            else
            {
                pictureBox_Descripcion.Image = Properties.Resources.Advertencia_Faltante; // Imagen para error
                pictureBox_Descripcion.BackColor = Color.Transparent; // Fondo de imagen transparente
                label_Descripcion.BackColor = Color.FromArgb(0, 192, 192); // Retoma color original verde agua
                panel_ControlesInferiores.Visible = false;
            }



            // Ajustar la posición del pictureBox al lado del label
            pictureBox_Descripcion.Location = new System.Drawing.Point(
                label_Descripcion.Right + 5, // A la derecha del label con un margen de 5 px
                label_Descripcion.Top + (label_Descripcion.Height - pictureBox_Descripcion.Height) / 2 // Centrado verticalmente
            );

            // Configurar el tamaño de la imagen para que abarque todo el contenedor del pictureBox
            pictureBox_Descripcion.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asegurarse de que el pictureBox sea visible
            pictureBox_Descripcion.Visible = true;
            AjustarTamanoFormulario();

        }

        private void AjustarTamanoFormulario()
        {
            int posicionVertical = 70; // Comienza desde la parte superior de panel1

            // Ajustar posición de panel_Instruccion (se contrae y expande)
            if (panel_Instruccion.Visible)
            {
                panel_Instruccion.Location = new System.Drawing.Point(panel_Instruccion.Location.X, posicionVertical);
                posicionVertical += panel_Instruccion.Height;
                // Agregar separación de 10 píxeles entre panel_Instruccion y panel_SeleccionVisu
              
            }
            posicionVertical += 20;

            // Ajustar posición de panel_SeleccionVisu (tamaño fijo)
            panel_SeleccionVisu.Location = new System.Drawing.Point(panel_SeleccionVisu.Location.X, posicionVertical);
            posicionVertical += panel_SeleccionVisu.Height;
            // Agregar separación de 10 píxeles entre panel_SeleccionVisu y panel_Imagenes
            posicionVertical += 10;

                   

            // Ajustar posición de panel_DatosVehiculo(se contrae y expande)
            if (panel_Descripcion.Visible)
            {
                panel_Descripcion.Location = new System.Drawing.Point(panel_Descripcion.Location.X, posicionVertical);
                posicionVertical += panel_Descripcion.Height;
                posicionVertical += 10; // Agregar separación después de panel_Descripción
            }

            // Ajustar posición de panel_ControlesInferiores
            if (panel_ControlesInferiores.Visible)
            {
                panel_ControlesInferiores.Location = new System.Drawing.Point(panel_ControlesInferiores.Location.X, posicionVertical);
                posicionVertical += panel_ControlesInferiores.Height;
                posicionVertical += 10;
            }
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

       
    }
}