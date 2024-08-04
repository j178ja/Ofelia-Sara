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
    public partial class SellosDependencia : BaseForm
    {
        public SellosDependencia()
        {
            InitializeComponent();
        }

        private void SellosDependencia_Load(object sender, EventArgs e)
        {

        }

        private void SellosDependencia_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Los sellos que agrege serán usados para completar las distintas planillas de las actuaciones", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
            {
                MessageBox.Show("Debe ingresar a que dependencia corresponden los sellos.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                // Verificar que el PictureBox_SelloMedalla tenga una imagen
                if (pictureBox_SelloMedalla.Image == null)
            {
                MessageBox.Show("Debe agregar una imagen al campo SELLO MEDALLA.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Se ha cargado exitosamente a sellos de la dependencia", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}