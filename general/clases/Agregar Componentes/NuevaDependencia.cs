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
    { // Define un delegado para el evento ItemAgregado
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

                MessageBox.Show("Se ha cargado nueva Dependencia a lista en formularios", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

