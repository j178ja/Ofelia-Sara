
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases.Texto;
using Clases.Apariencia;
using Clases.Botones;
using Ofelia_Sara.Formularios;
using BaseDatos.Entidades;
using Clases.Agregar_Componentes;
using BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Mensajes;


namespace Ofelia_Sara.Agregar_Componentes
{
    public partial class NuevaDependencia : BaseForm
    {
        private SellosDependencia sellosDependenciaForm;

        private ComisariasManager dbManager; 

        public event Action<string> DependenciaTextChanged;//para  actualizar en tiempo real con form SellosDependencia
        public event Action<string> LocalidadTextChanged;//para  actualizar en tiempo real con form SellosDependencia

        // Define un delegado para el evento ItemAgregado
        public delegate void ItemAgregadoEventHandler(object sender, string nuevoItem);
                           // Evento que se dispara cuando se agrega un nuevo ítem
        public event ItemAgregadoEventHandler ItemAgregado;

        // Definición de ComboBoxFilePath como propiedad
        private string ComboBoxFilePath { get; set; }
        public NuevaDependencia()
        {
            InitializeComponent();
                            // Asocia el evento Load del formulario al manejador NuevaDependencia_Load
            this.Load += new EventHandler(NuevaDependencia_Load);
                           // Aplica el estilo de botón de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            this.FormClosed += new FormClosedEventHandler(NuevaDependencia_FormClosed);

            // Inicializa el estado del Label, el CheckBox y los PictureBox al cargar el formulario
            ActualizarEstado();

            // Asocia el evento TextChanged del TextBox
            textBox_Dependencia.TextChanged += TextBox_Dependencia_TextChanged;
          
            //para redondear bordes panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1,borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            dbManager = new ComisariasManager(); // Inicializar la instancia para cargar datos DB
        }

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
        //-----------------------------------------------------------------------------
       
        private void NuevaDependencia_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_Dependencia.Focus();
        }
        //___________________________________________________________________________
        private void NuevaDependencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        //------------------------------------------------------------------------------
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

        //------------BOTON GUARDAR----------------------------------------------------
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // Obtener datos desde los TextBox
            string dependencia = textBox_Dependencia.Text;
            string domicilio = textBox_Domicilio.Text;
            string localidad = textBox_Localidad.Text;
            string partido = textBox_Partido.Text;

            if (!string.IsNullOrEmpty(dependencia)&& !string.IsNullOrEmpty(localidad))
            {
                

                // Llamada a la base de datos para insertar los datos en la tabla 'Comisarias'
                try
                {
                    dbManager.InsertComisaria(dependencia, domicilio, localidad, partido); // Utiliza el método de inserción

                    MensajeGeneral.Mostrar("Se ha guardado la nueva Dependencia en la base de datos.", MensajeGeneral.TipoMensaje.Exito);
                    
                    // Limpiar el formulario
                    LimpiarFormulario.Limpiar(this);
                
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al guardar en la base de datos: {ex.Message}",MensajeGeneral.TipoMensaje.Error);
                }

                // Limpiar el formulario
                LimpiarFormulario.Limpiar(this);
            }
            else
            {
                MensajeGeneral.Mostrar("Por favor ingrese el nombre y localidad  de la nueva Dependencia.",MensajeGeneral.TipoMensaje.Advertencia); 
            }
        }


        //------------------------------------------------------------------------------
        //------------BOTON LIMPIAR/ELIMINAR ----------------------------------------------------
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            // Muestra un mensaje de información
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }

        //-------------------CONTROLAR QUE SEAN MAYUSCULAS------------------
        private void ConfigurarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += (s, e) =>
                    {
                        TextBox tb = s as TextBox;
                        if (tb != null)
                        {
                            int pos = tb.SelectionStart;
                           // tb.Text = MayusculaYnumeros.ConvertirAMayusculasIgnorandoEspeciales(tb.Text);
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

        private void NuevaDependencia_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Debe ingresar el nombre de la dependencia tal y como se usa en actuaciones." + "El domicilio será empleado en plantilla de Inspeccion Ocular", MensajeGeneral.TipoMensaje.Informacion);
           // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //_________________________________________________________________________
        //---ABRIR FORMULARIO SELLOS DESDE CHECK-------------------------
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
        private void SellosDependenciaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Restaurar la posición original del formulario
            this.Location = originalPosition;
        }

        //-------------------------------------------------------------------------
        //--Para habilitar check y modificar label
        private void ActualizarEstado()
        {
            // Verifica si textBox_Dependencia y textBox_Localidad no están vacíos ni contienen solo espacios
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Dependencia.Text) &&
                                 !string.IsNullOrWhiteSpace(textBox_Localidad.Text);

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


        private void TextBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();//habilita check y modifica label

            //---para actualizar en tiempo real textbox DEPENDENCIA
            // Asegura que el cursor esté al final del texto
            textBox_Dependencia.SelectionStart = textBox_Dependencia.Text.Length;

            // Dispara el evento si hay suscriptores
           DependenciaTextChanged?.Invoke(textBox_Dependencia.Text);
        }


        private void TextBox_Localidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();//habilita check y modifica label

            //---para actualizar en tiempo real textbox DEPENDENCIA
            // Asegura que el cursor esté al final del texto
            textBox_Localidad.SelectionStart = textBox_Localidad.Text.Length;

            // Dispara el evento si hay suscriptores
            LocalidadTextChanged?.Invoke(textBox_Localidad.Text);
        }
        //-----------------------------------------------------------------------------
        //---para actualizar automaticamente entre form NuevaDependencia y SellosDependencia--
   
        public string TextoDependencia
        {
            get { return textBox_Dependencia.Text; }
            set { textBox_Dependencia.Text = value; }
        }
        public string TextoLocalidad
        {
            get { return textBox_Localidad.Text; }
            set { textBox_Localidad.Text = value; }
        }


        public void ActualizarTextoDependencia(string texto)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (textBox_Dependencia.Text != texto)
            {
                textBox_Dependencia.Text = texto;
            }
        }
        public void ActualizarTextoLocalidad(string texto)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (textBox_Localidad.Text != texto)
            {
                textBox_Localidad.Text = texto;
            }
        }

        public void ActualizarTextoDependenciaDesdeSellosDependencia(string nuevoTexto)
        {
            if (textBox_Dependencia.Text != nuevoTexto)
            {
                textBox_Dependencia.Text = nuevoTexto;
            }
        }
        public void ActualizarTextoLocalidadDesdeSellosDependencia(string nuevoTexto)
        {
            if (textBox_Localidad.Text != nuevoTexto)
            {
                textBox_Localidad.Text = nuevoTexto;
            }
        }
    }
}

