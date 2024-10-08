using Ofelia_Sara.general.clases;
using Clases.Reposicon_paneles;
using Clases.Botones;
using Clases.Texto;
using System;
using System.Windows.Forms;
using System.Drawing;
using Ofelia_Sara.Formularios;
using System.ComponentModel;
using Controles.Controles;
using BaseDatos.Entidades;
using System.Collections.Generic;
using Clases.GenerarDocumentos;
using System.IO;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Contravenciones : BaseForm
    {
        public Contravenciones()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

        }

        private void Contravenciones_Load(object sender, EventArgs e)
        {
            Fecha_Instruccion.SelectedDate = DateTime.Now;
            //// Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);
            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);
            MayusculaYnumeros.AplicarAControl(textBox_Localidad);
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_Apellido);
            MayusculaSola.AplicarAControl(comboBox_Nacionalidad);

            InicializarComboBoxSECRETARIO();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxINSTRUCTOR();
            InicializarComboBoxDEPENDENCIAS();
        }

      

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            InicializarComboBoxSECRETARIO();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxINSTRUCTOR();
            InicializarComboBoxDEPENDENCIAS();
            comboBox_Nacionalidad.SelectedIndex = -1;
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //------------BOTON GUARDAR---------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_ArtInfraccion.Text) ||
                string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                string.IsNullOrWhiteSpace(textBox_Apellido.Text) ||
                string.IsNullOrWhiteSpace(textBox_Dni.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar los campos Art, Nombre, Apellido y DNI ", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //--------------------------------------------------------------------------------------------
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

            // Crear una instancia de CustomDateTextBox para llamar a ObtenerFecha()
            CustomDateTextBox customDateTextBox = new CustomDateTextBox();
            var fechaNacimiento = customDateTextBox.ObtenerFecha(); // Llamada al método de instancia

            // Añadimos los valores de los controles al diccionario
            datosFormulario.Add("Nombre", textBox_Nombre.Text);  // "Nombre" es el marcador en Word
            datosFormulario.Add("Apellido", textBox_Apellido.Text);
            datosFormulario.Add("Dni", textBox_Dni.Text);
            datosFormulario.Add("Edad", textBox_Edad.Text);
            datosFormulario.Add("Domicilio", textBox_Domicilio.Text);
            datosFormulario.Add("Localidad", textBox_Localidad.Text);
            datosFormulario.Add("Nacionalidad", comboBox_Nacionalidad.SelectedItem.ToString());  
            datosFormulario.Add("Instructor", comboBox_Instructor.SelectedItem.ToString());  
            datosFormulario.Add("Secretario", comboBox_Secretario.SelectedItem.ToString());
            datosFormulario.Add("Dependencia", comboBox_Dependencia.SelectedItem.ToString());
            datosFormulario.Add("Fecha_Instruccion", Fecha_Instruccion.SelectedDate.ToString("dd/MM/yyyy"));
           
            // Verificar que fechaNacimiento no sea nula antes de agregarla al diccionario
            if (fechaNacimiento.HasValue)
            {
                datosFormulario.Add("Fecha_Nacimiento", fechaNacimiento.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una fecha de nacimiento válida.", "Fecha Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Hacer que el control CustomDateTextBox reciba el foco
                customDateTextBox.Focus();

                return null;// Detener el proceso si la fecha de instrucción no es válida
            }
            
            return datosFormulario;
        }
        //------------------------------------------------------------------------------------
        private bool ValidarDatosFormulario()
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_ArtInfraccion.Text) ||
                string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                string.IsNullOrWhiteSpace(textBox_Apellido.Text) ||
                string.IsNullOrWhiteSpace(textBox_Dni.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar los campos Art, Nombre, Apellido y DNI ", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Indica que la validación falló
            }

            // Validar fecha de nacimiento
            if (!Fecha_Nacimiento.HasValue()) // Usando el método HasValue() de CustomDateTextBox
            {
                MessageBox.Show("Por favor, ingrese una fecha de nacimiento válida.", "Fecha Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Fecha_Nacimiento.Focus();
                return false; // Detener el proceso si la fecha no es válida
            }


            DateTime fechaNacimiento;
            // Convertir la fecha ingresada a un objeto DateTime
            if (!DateTime.TryParse(Fecha_Nacimiento.Text, out fechaNacimiento))
            {
                MessageBox.Show("La fecha de nacimiento no es válida. Por favor, intente nuevamente.", "Fecha Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Fecha_Nacimiento.Focus();
                return false; // Detener el proceso si la fecha no se puede convertir
            }

            // Validar ComboBox Nacionalidad
            if (comboBox_Nacionalidad.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Nacionalidad.Text))
            {
                MessageBox.Show("Por favor, seleccione o ingrese una nacionalidad.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_Nacionalidad.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Instructor
            if (comboBox_Instructor.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Instructor.Text))
            {
                MessageBox.Show("Por favor, seleccione o ingrese un instructor.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_Instructor.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Secretario
            if (comboBox_Secretario.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Secretario.Text))
            {
                MessageBox.Show("Por favor, seleccione o ingrese un Secretario.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_Secretario.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Dependencia
            if (comboBox_Dependencia.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
            {
                MessageBox.Show("Por favor, seleccione o ingrese una Dependencia.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_Dependencia.Focus();
                return false; // Detener el proceso si no hay selección válida
            }
            return true; // Indica que la validación fue exitosa
        }
        //------------BOTON IMPRIMIR---------------

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
                    string nombreCarpeta = $"Contrav. {textBox_Apellido.Text}";
                    string rutaSubcarpeta = Path.Combine(rutaCarpetaSalida, nombreCarpeta);

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(rutaSubcarpeta))
                    {
                        Directory.CreateDirectory(rutaSubcarpeta);
                    }

                    // rutas de las plantillas-->DEBEN REEMPLASARSE A RUTAS RELATIVAS
                    string rutaPlantillaRecepcion = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\DECRETO RECEPCION EXPEDIENTE.docx";
                    string rutaPlantillaCierre = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\DECRETO CIERRE EXPEDIENTE.docx";
                    string rutaPlantillaNotificacion = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\NOTIFICACION EXPEDIENTE.docx";

                    // Obtener los datos del formulario
                    var datosFormulario = ObtenerDatosFormulario();

                    // Generar cada documento con su respectiva plantilla y guardarlo en la carpeta
                    GeneradorDocumentos generador = new GeneradorDocumentos();
                    generador.GenerarYGuardarDocumento(rutaPlantillaRecepcion, rutaSubcarpeta, "DECRETO RECEPCION", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaCierre, rutaSubcarpeta, "DECRETO CIERRE", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaNotificacion, rutaSubcarpeta, "NOTIFICACION", datosFormulario);

                    // Mostrar mensaje de éxito
                    // MessageBox.Show("Los documentos han sido generados correctamente.");

                    MensajeCargarImprimir mensajeCargarImprimir = new MensajeCargarImprimir();
                    mensajeCargarImprimir.ShowDialog();

                    // Abrir la ubicación de la carpeta generada
                    System.Diagnostics.Process.Start("explorer.exe", rutaSubcarpeta);
                }
            }
        }




        //---------------------------------------------------------------------------------------------
        private void textBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene menos de 2 caracteres
            if (textBox_Edad.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 2 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }
        private void textBox_Edad_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto actual del TextBox es "0" o "00"
            if (/*textBox_Edad.Text == "0" || */textBox_Edad.Text == "00")
            {
                // Mostrar un mensaje de error y limpiar el TextBox
                MessageBox.Show("El valor no puede ser 0 o 00", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Edad.Clear();
            }
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene  10 caracteres
            if (textBox_Dni.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 10 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }

        private void textBox_Dni_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Obtener la posición del cursor antes del formateo
            int cursorPosition = textBox.SelectionStart;

            // Usar la clase separada para formatear el texto con puntos
            string textoFormateado = ClaseNumeros.FormatearNumeroConPuntos(textBox.Text);

            // Actualizar el texto en el TextBox
            textBox.Text = textoFormateado;

            // Asegurarse de que el cursor se posicione al final del texto
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void textBox_Localidad_KeyPress(object sender, KeyPressEventArgs e)
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
        private void Contravenciones_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Complete la totalidad de campos requeridos para generar el documento.", "OFELIA- SARA   Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }


        private void InicializarComboBoxSECRETARIO()
        {
            List<Secretario> secretarios = SecretarioManager.ObtenerSecretarios();
            comboBox_Secretario.DataSource = secretarios;
            comboBox_Secretario.DisplayMember = "DescripcionCompleta";
            comboBox_Secretario.SelectedIndex = -1;
        }
        //---------------------------------------------------------------------
        private void InicializarComboBoxINSTRUCTOR()
        {
            List<Instructor> instructores = InstructorManager.ObtenerInstructores();
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
    }
}
