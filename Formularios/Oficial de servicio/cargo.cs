
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using Clases.Texto;
using Clases.Apariencia;
using Clases.Botones;
using Ofelia_Sara.Formularios;
using System.ComponentModel;
using Ofelia_Sara.general.clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Controls;
using Clases.GenerarDocumentos;
using System.IO;
using Controles.Controles;
using System.Collections.Generic;
using BaseDatos.Entidades;
using System.Linq;
using Ofelia_Sara.Mensajes;



namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Cargo : BaseForm

    {
        public Cargo()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

        }
        //----------------------------------------------------------------------------------
        //---sobrecargar para que reciba los datos desde form iniciocierre
        public Cargo(string ipp1, string ipp2, string numeroIpp, string ipp4, string caratula,
                 string victima, string imputado, string fiscalia, string agenteFiscal,string localidad,
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

            CargarDatosDependencia(comboBox_Dependencia, dbManager);
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
            CargarDatosSecretario(comboBox_Secretario, secretariosManager);
        }
        //----------------------------------------------------------------------------------------

        private void Cargo_Load(object sender, EventArgs e)
        {
            textBox_NumeroCargo.MaxLength = 4;//limita a 4 caracteres el numero de cargo
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

            Fecha_Instruccion.SelectedDate = DateTime.Now;
        }

        //-----------------------------------------------------------------------
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

            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxSECRETARIO();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxINSTRUCTOR();
            InicializarComboBoxDEPENDENCIAS();

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Exito); ;


        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

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
        private bool ValidarDatosFormulario()
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_NumeroIpp.Text) ||
                string.IsNullOrWhiteSpace(textBox_Caratula.Text) ||
                string.IsNullOrWhiteSpace(textBox_Victima.Text) ||
                string.IsNullOrWhiteSpace(textBox_Imputado.Text))

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
            if (!ValidarDatosFormulario())
            {
                return; // Detener el proceso si la validación falla
            }

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
    }
}
