using Ofelia_Sara.Base_de_Datos.Entidades;
using Ofelia_Sara.general.clases.Apariencia_General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    public partial class NuevaDependencia : BaseForm
    { 
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
            textBox_Dependencia.TextChanged += textBox_Dependencia_TextChanged;


        }

        private void NuevaDependencia_Load(object sender, EventArgs e)
        {
            // Configurar todos los TextBoxes en el formulario
            ConfigurarTextBoxes(this);

            // Inicialización o asignación de ComboBoxFilePath
            ComboBoxFilePath = "ruta_del_archivo.txt"; // Ejemplo de asignación

           
        }

        private void NuevaDependencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        //------------------------------------------------------------------------------


        //------------BOTON GUARDAR----------------------------------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string nuevoItem = textBox_Dependencia.Text;

            if (!string.IsNullOrEmpty(nuevoItem))
            {
                ComboBoxManager.AddItemToComboBox(this, "comboBox_Dependencia", nuevoItem);
                ItemAgregado?.Invoke(this, nuevoItem);


                string dependencia = textBox_Dependencia.Text;
                string domicilio = textBox_Domicilio.Text;

                var nuevaDependencia = new DependenciasPoliciales
                {
                    Dependencia = dependencia,
                    Domicilio = domicilio
                };

                DependenciaManager.AgregarDependencia(nuevaDependencia);

                MessageBox.Show("Se ha cargado nueva Dependencia a lista en formularios", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario.Limpiar(this); //limpiar todos los controles
            }
            else
            {
                MessageBox.Show("Por favor ingrese el nombre completo de la nueva Dependencia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //------------------------------------------------------------------------------
        //------------BOTON LIMPIAR/ELIMINAR ----------------------------------------------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            // Muestra un mensaje de información
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            tb.Text = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(tb.Text);
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
            MessageBox.Show("Debe ingresar el nombre de la dependencia tal y como se usa en actuaciones."+"El domicilio será empleado en plantilla de Inspeccion Ocular", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void checkBox_AgregarSellos_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el CheckBox está marcado
            if (checkBox_AgregarSellos.Checked)
            {
                // Crear una instancia del formulario SellosDependencia
                SellosDependencia sellosDependenciaForm = new SellosDependencia();

                sellosDependenciaForm.TextBoxText = textBox_Dependencia.Text;

                // Mostrar el formulario como una ventana modal
                sellosDependenciaForm.ShowDialog();
            }
        }
        //-------------------------------------------------------------------------
        //--Para habilitar check y modificar label
        private void ActualizarEstado()
        {
            // Verifica si textBox_Dependencia no está vacío ni solo con espacios
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Dependencia.Text);

            // Actualiza el color del label y el estado del checkbox según el texto del TextBox
            label_AgregarSellos.ForeColor = esTextoValido ? Color.Black : Color.Tomato;
            label_AgregarSellos.BackColor = esTextoValido ? Color.Transparent : Color.Gray;
            
            // Actualiza el color de fondo del CheckBox y su estado habilitado/deshabilitado
            checkBox_AgregarSellos.Enabled = esTextoValido;
            checkBox_AgregarSellos.BackColor = esTextoValido ? Color.Transparent : Color.Tomato;

        }

        private void textBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();//habilita check y modifica label
        }
    }
}

