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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ofelia_Sara
{
    public partial class InicioCierre : BaseForm
    {
        public InicioCierre()
        {
            InitializeComponent();
           // ProgressBar ProgressBar = new ProgressBar();
            //ProgressBar.Location = new Point(50, 50); // Ubicación en el formulario
           // this.Controls.Add(customProgressBar);
            SuscribirEventos();
        }

        private void InicioCierreLoad(object sender, EventArgs e)
        {
            // Llama al método para convertir el texto a mayúsculas y filtrar caracteres en este formulario
            TextoEnMayuscula.ConvertirTextoAMayusculas(this);
        }

        //---------BOTON GUARDAR--------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_Caratula.Text) ||
                string.IsNullOrWhiteSpace(textBox_Imputado.Text) ||
                string.IsNullOrWhiteSpace(textBox_Victima.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar los campos Caratula, Imputado y Victima.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                MessageBox.Show("Formulario guardado.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //-----FORMATO ESPECIAL DateTimePicker------------
        // !!!! HACER METODO APARTE!!!--------------------
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Cambiar el formato personalizado del DateTimePicker
            pickTime_DatoFecha.CustomFormat = "dd/MM/yyyy";  // Asegúrate de usar el nombre correcto del DateTimePicker

            // Obtener el texto actual del DateTimePicker
            string texto = pickTime_DatoFecha.Text;

            // Convertir el texto a mayúsculas
            texto = texto.ToUpper();

            // Asignar el texto modificado de nuevo al DateTimePicker
            pickTime_DatoFecha.Text = texto;
        }
        //-------------------------------------------------------

        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
            MessageBox.Show("Formulario eliminado.");
        }



        //---------manejador de eventos--------
        private void SuscribirEventos()
        {
            // Suscribe los eventos de los controles a los métodos de actualización
          //  foreach (Control control in this.Controls)
            //{
            //    if (control is TextBox textBox)
            //    {
            //         textBox.TextChanged += new EventHandler(ActualizarProgressBar);
            //    }
            //    else if (control is ComboBox comboBox)
            //    {
            //          comboBox.SelectedIndexChanged += new EventHandler(ActualizarProgressBar);
            //    }
            //    else if (control is DateTimePicker dateTimePicker)
            //    {
            //         dateTimePicker.ValueChanged += new EventHandler(ActualizarProgressBar);
            //    }
            //}
        }


        //--------EVENTO PARA QUE SEA SOLO NUMERO ---------------------
        //--------EL TEXTBOX DE NUMERO DE IPP---------------------
        private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Verificar si el carácter presionado es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, cancelar el evento KeyPress
                e.Handled = true;
            }
        }
       }
    }


    


