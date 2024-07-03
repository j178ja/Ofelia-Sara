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
            SuscribirEventos();
        }

        private void InicioCierreLoad(object sender, EventArgs e)
        {
            // Llama al método para convertir el texto a mayúsculas y filtrar caracteres en este formulario
            TextoEnMayuscula.ConvertirTextoAMayusculas(this);
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

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
            MessageBox.Show("Formulario eliminado.");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //sin uso al momento
        }

        //---------PROGRESSBAR-------------
        //---------manejador de eventos--------
        private void SuscribirEventos()
        {
            // Suscribe los eventos de los controles a los métodos de actualización
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += new EventHandler(ActualizarProgressBar);
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += new EventHandler(ActualizarProgressBar);
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.ValueChanged += new EventHandler(ActualizarProgressBar);
                }
            }
        }

        //private void ActualizarProgressBar(object sender, EventArgs e)
        //{
        //    int totalCampos = 0;
        //    int camposCompletados = 0;

        //    foreach (Control control in this.Controls)
        //    {
        //        if (control is TextBox textBox)
        //        {
        //            totalCampos++;
        //            if (!string.IsNullOrEmpty(textBox.Text))
        //            {
        //                camposCompletados++;
        //            }
        //        }
        //        else if (control is ComboBox comboBox)
        //        {
        //            totalCampos++;
        //            if (comboBox.SelectedIndex >= 0)
        //            {
        //                camposCompletados++;
        //            }
        //        }
        //        else if (control is DateTimePicker dateTimePicker)
        //        {
        //            totalCampos++;
        //            if (dateTimePicker.Value != DateTimePicker.MinimumDateTime)
        //            {
        //                camposCompletados++;
        //            }
        //        }
        //    }



        private void ActualizarProgressBar(object sender, EventArgs e)
        {
            int totalCampos = 0;
            int camposCompletados = 0;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    totalCampos++;
                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        camposCompletados++;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    totalCampos++;
                    if (comboBox.SelectedIndex >= 0)
                    {
                        camposCompletados++;
                    }
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    totalCampos++;
                    if (dateTimePicker.Value != DateTimePicker.MinimumDateTime)
                    {
                        camposCompletados++;
                    }
                }
            }

            if (totalCampos > 0)
            {
                // Calcular el porcentaje de campos completados
                int progreso = (int)((camposCompletados / (float)totalCampos) * 100);

                // Actualizar el valor de la ProgressBar
                ProgressBarHelper.UpdateProgressBar(progressBar, progreso);
                
            }
        }
    }
}

    


