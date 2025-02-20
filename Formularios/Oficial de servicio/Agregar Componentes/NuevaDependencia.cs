using BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    public partial class NuevaDependencia : BaseForm
    {
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private SellosDependencia sellosDependenciaForm;

        private new ComisariasManager dbManager;

        public event Action<string> DependenciaTextChanged;//para  actualizar en tiempo real con form SellosDependencia
        public event Action<string> LocalidadTextChanged;//para  actualizar en tiempo real con form SellosDependencia

        // Define un delegado para el evento ItemAgregado
        public delegate void ItemAgregadoEventHandler(object sender, string nuevoItem);
     
        #endregion

        #region CONSTRUCTOR
        public NuevaDependencia()
        {
            InitializeComponent();
            // Asocia el evento Load del formulario al manejador NuevaDependencia_Load
            this.Load += new EventHandler(NuevaDependencia_Load);
            // Aplica el estilo de botón de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            //this.FormClosed += new FormClosedEventHandler(NuevaDependencia_FormClosed);

            // Inicializa el estado del Label, el CheckBox y los PictureBox al cargar el formulario
            ActualizarEstado();

            // Asocia el evento TextChanged del TextBox
            textBox_Dependencia.TextChanged += TextBox_Dependencia_TextChanged;

            //para redondear bordes panel
            RedondearBordes.Aplicar(panel1, 15);


            dbManager = new ComisariasManager(); // Inicializar la instancia para cargar datos DB

            this.FormClosing += NuevaDependencia_FormClosing;
        }
        #endregion

        #region LOAD
        private void NuevaDependencia_Load(object sender, EventArgs e)
        {
            MayusculaYnumeros.AplicarAControl(textBox_Dependencia);
            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);
            MayusculaSola.AplicarAControl(textBox_Localidad);

            // Configurar todos los TextBoxes en el formulario
            ConfigurarTextBoxes(this);

            // Inicializar el formulario SellosDependencia
            sellosDependenciaForm = new SellosDependencia();

            // Suscribirse al evento DependenciaTextChanged
            sellosDependenciaForm.DependenciaTextChanged += ActualizarTextoDependencia;
            sellosDependenciaForm.LocalidadTextChanged += ActualizarTextoLocalidad;
            this.Shown += NuevaDependencia_Shown;//para que haga foco en un textBox
        }
        #endregion

        #region VALIDACIONES Y METODOS
        /// <summary>
        /// INICIA CON FOCO EN DEPENDENCIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaDependencia_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_Dependencia.Focus();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto del TextBox al Camel Case
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = ConvertirACamelCase.Convertir(textBox.Text);
                // Mover el cursor al final del texto para evitar que el cursor se mueva al inicio
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // Obtener datos desde los TextBox
            string dependencia = textBox_Dependencia.TextValue;
            string domicilio = textBox_Domicilio.TextValue;
            string localidad = textBox_Localidad.TextValue;
            string partido = textBox_Partido.TextValue;

            if (!string.IsNullOrEmpty(dependencia) && !string.IsNullOrEmpty(localidad))
            {

                // Llamada a la base de datos para insertar los datos en la tabla 'Comisarias'
                try
                {
                    dbManager.InsertComisaria(dependencia, domicilio, localidad, partido); // Utiliza el método de inserción

                    MensajeGeneral.Mostrar("Se ha guardado la nueva Dependencia en la base de datos.", MensajeGeneral.TipoMensaje.Exito);
                    datosGuardados = true; // Marcar que los datos fueron guardados
                    // Limpiar el formulario
                    LimpiarFormulario.Limpiar(this);
                   
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al guardar en la base de datos: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }

                // Limpiar el formulario
                LimpiarFormulario.Limpiar(this);
            }
            else
            {
                MensajeGeneral.Mostrar("Por favor ingrese el nombre y localidad  de la nueva Dependencia.", MensajeGeneral.TipoMensaje.Advertencia);
            }
        }
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            // Muestra un mensaje de información
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        private void TextBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();//habilita check y modifica label

            //---para actualizar en tiempo real textbox DEPENDENCIA
            // Asegura que el cursor esté al final del texto
            textBox_Dependencia.SelectionStart = textBox_Dependencia.TextValue.Length;

            // Dispara el evento si hay suscriptores
            DependenciaTextChanged?.Invoke(textBox_Dependencia.TextValue);
        }
        private void TextBox_Localidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();//habilita check y modifica label

            //---para actualizar en tiempo real textbox DEPENDENCIA
            // Asegura que el cursor esté al final del texto
            textBox_Localidad.SelectionStart = textBox_Localidad.TextValue.Length;

            // Dispara el evento si hay suscriptores
            LocalidadTextChanged?.Invoke(textBox_Localidad.TextValue);
        }

        /// <summary>
        /// CONTROLAR QUE SEAN MAYUSCULAS-
        /// </summary>
        /// <param name="parent"></param>
        private static void ConfigurarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CustomTextBox customtextBox)
                {
                    customtextBox.TextChanged += (s, e) =>
                    {
                        CustomTextBox tb = s as CustomTextBox;
                        if (tb != null)
                        {
                            int pos = tb.SelectionStart;
                             tb.Text = MayusculaYnumeros.ConvertirAMayusculasIgnorandoEspeciales(tb.TextValue);
                            tb.SelectionStart = pos;
                        }
                    };
                }
                else if (control.HasChildren)
                {
                    ConfigurarTextBoxes(control);
                }
            }
        }

        /// <summary>
        /// MENSAJE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaDependencia_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda( "Debe ingresar el nombre de la dependencia tal y como se usa en actuaciones."
                +"El domicilio será empleado en plantilla de Inspeccion Ocular");
          
        }
        
        /// <summary>
        /// ABRIR FORMULARIO SELLOS DESDE CHECK
        /// </summary>
        private Point originalPosition;
        private void CheckBox_AgregarSellos_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el CheckBox está marcado
            if (checkBox_AgregarSellos.Checked)
            {
                
                // Guarda la posición actual del formulario principal
                originalPosition = this.Location;

                // Crear una instancia del formulario SellosDependencia
                SellosDependencia sellosDependenciaForm = new SellosDependencia();

                sellosDependenciaForm.ActualizarTextoDependencia(this.TextoDependencia);
                sellosDependenciaForm.ActualizarTextoLocalidad(this.TextoLocalidad);
                // NO SE EMPLEARA POR EL MOMENTO REFLEJAR DESDE SELLOS 
                this.DependenciaTextChanged += sellosDependenciaForm.ActualizarTextoDependencia;
                this.LocalidadTextChanged += sellosDependenciaForm.ActualizarTextoLocalidad;
                sellosDependenciaForm.DependenciaTextChanged += ActualizarTextoDependenciaDesdeSellosDependencia;
                sellosDependenciaForm.LocalidadTextChanged += ActualizarTextoLocalidadDesdeSellosDependencia;

                // Guardar la posición original del formulario
                originalPosition = this.Location;

                // Obtener el tamaño de ambos formularios
                int totalWidth = this.Width + sellosDependenciaForm.Width;
                int height = Math.Max(this.Height, sellosDependenciaForm.Height);

                // Calcular la posición para centrar ambos formularios en la pantalla
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int startX = (screenWidth - totalWidth) / 2;
                int startY = (screenHeight - height) / 2;

                // Posicionar el formulario original a la izquierda
                this.Location = new Point(startX, startY);

                // Posicionar el formulario AgregarDatosPersonalesConcubina a la derecha del formulario original
                sellosDependenciaForm.StartPosition = FormStartPosition.Manual;
                sellosDependenciaForm.Location = new Point(startX + this.Width, startY);

                // Mostrar el formulario AgregarDatosPersonalesConcubina
                sellosDependenciaForm.FormClosed += SellosDependenciaForm_FormClosed;
                // Mostrar el formulario como una ventana modal
                sellosDependenciaForm.ShowDialog();
            }
        }

        /// <summary>
        /// RESTAURAR POSICION DE FORMULARIOS AL CERRAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellosDependenciaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Restaurar la posición original del formulario
            this.Location = originalPosition;
        }

        /// <summary>
        /// MENSAJE CONFIRMACION AL CERRAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaDependencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
     
            }
        }

        /// <summary>
        /// HABILITA CHECK Y MODIFICA LABEL 
        /// </summary>
        private void ActualizarEstado()
        {
            // Verifica si textBox_Dependencia y textBox_Localidad no están vacíos ni contienen solo espacios
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Dependencia.TextValue) &&
                                 !string.IsNullOrWhiteSpace(textBox_Localidad.TextValue);

            // Actualiza el color del label y el estado del CheckBox según el texto de los TextBox
            label_AgregarSellos.ForeColor = esTextoValido ? Color.Black : Color.Tomato;
            label_AgregarSellos.BackColor = esTextoValido ? Color.Transparent : Color.LightGray;

            // Actualiza el color de fondo del CheckBox y su estado habilitado/deshabilitado
            checkBox_AgregarSellos.Enabled = esTextoValido;

            // Si alguno de los TextBox está vacío, limpia el CheckBox
            if (!esTextoValido)
            {
                checkBox_AgregarSellos.Checked = false;
            }

            checkBox_AgregarSellos.BackColor = esTextoValido ? Color.Transparent : Color.Tomato;
        }
     
        #endregion

        #region PROPIEDADES
        public string TextoDependencia
        {
            get { return textBox_Dependencia.TextValue; }
            set { textBox_Dependencia.TextValue = value; }
        }
        public string TextoLocalidad
        {
            get { return textBox_Localidad.TextValue; }
            set { textBox_Localidad.TextValue = value; }
        }
        public void ActualizarTextoDependencia(string texto)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (textBox_Dependencia.TextValue != texto)
            {
                textBox_Dependencia.TextValue = texto;
            }
        }
        public void ActualizarTextoLocalidad(string texto)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (textBox_Localidad.TextValue != texto)
            {
                textBox_Localidad.TextValue = texto;
            }
        }
        public void ActualizarTextoDependenciaDesdeSellosDependencia(string nuevoTexto)
        {
            if (textBox_Dependencia.TextValue != nuevoTexto)
            {
                textBox_Dependencia.TextValue = nuevoTexto;
            }
        }
        public void ActualizarTextoLocalidadDesdeSellosDependencia(string nuevoTexto)
        {
            if (textBox_Localidad.TextValue != nuevoTexto)
            {
                textBox_Localidad.TextValue = nuevoTexto;
            }
        }
    }
}

#endregion