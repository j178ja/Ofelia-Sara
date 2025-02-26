using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Clases.GenerarDocumentos;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{


    public partial class Contravenciones : BaseForm
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public Contravenciones()
        {
            InitializeComponent();

         
        }

        private void Contravenciones_Load(object sender, EventArgs e)
        {
            this.FormClosing += BuscarPersonal_FormClosing;
            //Fecha_Instruccion.SelectedDate = DateTime.Now;
            //// Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

          
            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);
            MayusculaYnumeros.AplicarAControl(textBox_Localidad);
            MayusculaSola.AplicarAControl(textBox_Nombre);

            MayusculaSola.AplicarAControl(comboBox_Nacionalidad.InnerTextBox);

            CalcularEdad.Inicializar(Fecha_Nacimiento, textBox_Edad);//para automatizar edad


            //cargar desde base de datos
            CargarDatosDependencia(comboBox_Dependencia, dbManager);
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
            CargarDatosSecretario(comboBox_Secretario, secretariosManager);

            SetupBotonDeslizable();  // Configurar el delegado de validación
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Nacionalidad.SelectedIndex = -1; //para que no aparesca ningun item del combobox
            comboBox_Dependencia.SelectedIndex = -1;
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);

        }

        //------------BOTON GUARDAR---------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_ArtInfraccion.Text) ||
                string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||

                string.IsNullOrWhiteSpace(textBox_Dni.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MensajeGeneral.Mostrar("Debe completar los campos Art, Nombre y DNI ", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                datosGuardados = true; // Marcar que los datos fueron guardados
                MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);
            }
        }
        //--------------------------------------------------------------------------------------------

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
            CustomDate customDateTextBox = new CustomDate();
            var fechaNacimiento = customDateTextBox.ObtenerFecha(); // Llamada al método de instancia

            // Añadimos los valores de los controles al diccionario
            datosFormulario.Add("Nombre", textBox_Nombre.Text);  // "Nombre" es el marcador en Word

            datosFormulario.Add("Dni", textBox_Dni.Text);
            datosFormulario.Add("Edad", textBox_Edad.Text);
            datosFormulario.Add("Domicilio", textBox_Domicilio.Text);
            datosFormulario.Add("Localidad", textBox_Localidad.Text);
            datosFormulario.Add("Nacionalidad", comboBox_Nacionalidad.SelectedItem.ToString());
            datosFormulario.Add("Instructor", comboBox_Instructor.SelectedItem.ToString());
            datosFormulario.Add("Secretario", comboBox_Secretario.SelectedItem.ToString());
            datosFormulario.Add("Dependencia", comboBox_Dependencia.SelectedItem.ToString());
            // datosFormulario.Add("Fecha_Instruccion", Fecha_Instruccion.SelectedDate.ToString("dd/MM/yyyy"));

            // Verificar que fechaNacimiento no sea nula antes de agregarla al diccionario
            if (fechaNacimiento.HasValue)
            {
                datosFormulario.Add("Fecha_Nacimiento", fechaNacimiento.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                MensajeGeneral.Mostrar("Por favor, ingrese una fecha de nacimiento válida.", MensajeGeneral.TipoMensaje.Advertencia);
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

                string.IsNullOrWhiteSpace(textBox_Dni.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MensajeGeneral.Mostrar("Debe completar los campos Art, Nombre, Apellido y DNI ", MensajeGeneral.TipoMensaje.Advertencia);
                return false; // Indica que la validación falló
            }

            // Validar fecha de nacimiento
            if (!Fecha_Nacimiento.HasValue()) // Usando el método HasValue() de CustomDateTextBox
            {
                MensajeGeneral.Mostrar("Por favor, ingrese una fecha de nacimiento válida.", MensajeGeneral.TipoMensaje.Advertencia);
                Fecha_Nacimiento.Focus();
                return false; // Detener el proceso si la fecha no es válida
            }


            DateTime fechaNacimiento;
            // Convertir la fecha ingresada a un objeto DateTime
            if (!DateTime.TryParse(Fecha_Nacimiento.Text, out fechaNacimiento))
            {
                MensajeGeneral.Mostrar("La fecha de nacimiento no es válida. Por favor, intente nuevamente.", MensajeGeneral.TipoMensaje.Error);
                Fecha_Nacimiento.Focus();
                return false; // Detener el proceso si la fecha no se puede convertir
            }

            // Validar ComboBox Nacionalidad
            if (comboBox_Nacionalidad.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Nacionalidad.Text))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese una nacionalidad.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Nacionalidad.Focus();
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
                    //   string nombreCarpeta = $"Contrav. {textBox_Apellido.Text}";
                    string rutaSubcarpeta = Path.Combine(rutaCarpetaSalida/*, nombreCarpeta*/);

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
                MensajeGeneral.Mostrar("El valor no puede ser 0 o 00", MensajeGeneral.TipoMensaje.Error);
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
            MensajeGeneral.Mostrar("Complete la totalidad de campos requeridos para generar el documento.", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        //-------BOTON STAR PLANA---------------------------------
        private void SetupBotonDeslizable()
        {
            // Configurar el delegado de validación en el control BotonDeslizable
            botonDeslizable_StarPlana.ValidarCampos = () =>
            {
                // Lógica de validación
                bool camposIncompletos =
                    string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Dni.Text) ||
                        !Fecha_Nacimiento.HasValue();

                if (camposIncompletos)
                {
                    // Mostrar mensaje de advertencia si los campos están incompletos
                    MensajeGeneral.Mostrar("Debe completar los campos NOMBRE, DNI y FECHA DE NACIMIENTO para poder solicitar plana del ciudadano", MensajeGeneral.TipoMensaje.Advertencia);
                    return false; // Retorna false si los campos están incompletos
                }
                else
                {
                    // Mostrar mensaje de éxito si los campos están completos
                    MensajeGeneral.Mostrar("Datos Guardados para solicitar plana del ciudadano. Cuando imprima formulario  se enviara automaticamente la solicitud de plana" +
                        "", MensajeGeneral.TipoMensaje.Exito);
                    return true; // Retorna true si los campos están completos
                }
            };
        }

        private void Fecha_Instruccion_Load(object sender, EventArgs e)
        {

        }
    }
}
