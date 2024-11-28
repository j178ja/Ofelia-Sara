
using BaseDatos.Entidades;
using Clases.Apariencia;
using Clases.Botones;
using Clases.GenerarDocumentos;
using Clases.Texto;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Cargo : BaseForm

    {
        
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
        }
        //----------------------------------------------------------------------------------
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
        //----------------------------------------------------------------------------------------

        private void Cargo_Load(object sender, EventArgs e)
        {
            this.FormClosing += BuscarPersonal_FormClosing;
            textBox_NumeroCargo.MaxLength = 4;//limita a 4 caracteres el numero de cargo
            this.Shown += Focus_Shown;//para que haga foco en un textBox
            textBox_NumeroIpp.MaxLength = 6;
            comboBox_Ipp1.MaxLength = 2;
            comboBox_Ipp2.MaxLength = 2;
            comboBox_Ipp4.MaxLength = 2;

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
            MayusculaSola.AplicarAControl(comboBox_Localidad);

            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            Fecha_Instruccion.SelectedDate = DateTime.Now;//para tomar el dia actual

            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);

            pictureBox_CheckLegajoVehicular.Visible = false;// para ocultar el check realizado

        }




        private void botonDeslizable_Visu_IsOnChanged(object sender, EventArgs e)
        {
            try
            {
                if (botonDeslizable_Visu.IsOn)
                {
                    Visu formVISU = new Visu();
                    formVISU.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario Visu: {ex.Message}");
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
                SetError(control, mensajeError);
                return false;
            }

            // Si el campo está completo, se limpia el error
            ClearError(control);
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

        private void comboBox_Ipp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void comboBox_Ipp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void comboBox_Ipp4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

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
            if (string.IsNullOrWhiteSpace(textBox_DescripcionMuestra.Text))
            {
                MensajeGeneral.Mostrar("Describa la muestra del cargo", MensajeGeneral.TipoMensaje.Advertencia);
                textBox_DescripcionMuestra.Focus();
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
            datosFormulario.Add("NumeroCargo", textBox_NumeroCargo.Text);
            datosFormulario.Add("NumeroIpp", textBox_NumeroIpp.Text);
            datosFormulario.Add("Caratula", textBox_Caratula.Text);
            datosFormulario.Add("Victima", textBox_Victima.Text);
            datosFormulario.Add("Imputado", textBox_Imputado.Text);


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

     

    }
}