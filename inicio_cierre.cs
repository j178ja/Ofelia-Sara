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

namespace Ofelia_Sara
{
    public partial class InicioCierre : BaseForm
    { 
        public InicioCierre()
        {
            InitializeComponent();
        }

        private void InicioCierreLoad(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Cambiar el formato personalizado del DateTimePicker
            datoFecha.CustomFormat = "dd/MM/yyyy";  // Asegúrate de usar el nombre correcto del DateTimePicker

            // Obtener el texto actual del DateTimePicker
            string texto = datoFecha.Text;

            // Convertir el texto a mayúsculas
            texto = texto.ToUpper();

            // Asignar el texto modificado de nuevo al DateTimePicker
            datoFecha.Text = texto;
        }

    }
}

