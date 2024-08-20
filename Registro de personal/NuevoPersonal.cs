using Ofelia_Sara.Base_de_Datos;
using Ofelia_Sara.general.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class NuevoPersonal : BaseForm
    {

        public NuevoPersonal(string numeroLegajo)
        {
            InitializeComponent();
            // Asigna el valor recibido al TextBox correspondiente en NuevoPersonal
            textBox_NumeroLegajo.Text = numeroLegajo;
        }


        public NuevoPersonal()
        {
            InitializeComponent();
        }

        private void NuevoPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Limpiar);

            //para que se despliege la lista en los comboBox ESCALAFON -JERARQUIA
            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(ComboBox comboBox)
        {
            comboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }
        //--------------------------------------------------------------------------



        private void NuevoPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Debe completar la totalidad de los campos requeridos." + "Todos ellos serán empleados para completar plantilla de Ratificación policial", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            // Muestra un mensaje de información
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_NumeroLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_NumeroLegajo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
