using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ofelia_Sara.general.clases;
using System.Windows.Forms;
using Ofelia_Sara.general.clases.Apariencia_General;
using System.Windows.Controls;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class BuscarForm : BaseForm
    {
        public BuscarForm()
        {
            InitializeComponent();

            // Crear una instancia de TimePickerPersonalizado con tamaño especificado
            TimePickerPersonalizado timePicker = new TimePickerPersonalizado(263, 26);

            // Establecer la ubicación del UserControl
            timePicker.Location = new Point(150, 50);

            // Agregar el UserControl al formulario
            this.Controls.Add(timePicker);
        }

        private void Buscar_Load(object sender, EventArgs e)
        {

            // Aplica el estilo de botón de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Buscar);
        }
        // Método para posicionar el cursor en el textBox específico
        public void PosicionarCursorEnTextBox(System.Windows.Forms.Control control)
        {
            if (control != null)
            {
                control.Focus();
            }
        }

        private void BuscarForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Complete alguno de los campos requeridos para iniciar la busqueda.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
