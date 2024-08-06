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
            PosicionarCursorEnTextBox();
        }
        // Método para posicionar el cursor en el textBox específico
        public void PosicionarCursorEnTextBox()
        {
            textBox_Caratula.Focus();
        }
    }
}
