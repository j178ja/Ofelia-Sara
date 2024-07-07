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
           // SuscribirEventos();
            // Suscribirse a los eventos
           // textBox_NumeroIpp.KeyPress += new KeyPressEventHandler(textBox_NumeroIpp_KeyPress);
            textBox_NumeroIpp.TextChanged += new EventHandler(textBox_NumeroIpp_TextChanged);
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
                MessageBox.Show("Debe completar los campos Caratula, Imputado y Victima.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //-----FORMATO ESPECIAL DateTimePicker------------
        // !!!! HACER METODO APARTE!!!--------------------
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada del DateTimePicker
            DateTime fechaSeleccionada = pickTime_DatoFecha.Value;

            // Formatear el texto para mostrar solo el mes y el año
            string mesEnMayusculas = fechaSeleccionada.ToString("MM/yyyy");

            // Convertir el mes a mayúsculas
            mesEnMayusculas = mesEnMayusculas.Substring(0, 2).ToUpper() + mesEnMayusculas.Substring(2);

            // Establecer el formato personalizado del DateTimePicker
            pickTime_DatoFecha.CustomFormat = mesEnMayusculas;
        }
        //-------------------------------------------------------

        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
            //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        //---------manejador de eventos--------
        //private void SuscribirEventos()
        //{
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
        //}


        //--------EVENTO PARA QUE SEA SOLO NUMERO ---------------------
        //--------EL TEXTBOX DE NUMERO DE IPP---------------------
        //private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        //{ // keypress ideal para manejar los caracteres ingresados 

        //    // Verificar si el carácter presionado es un número o una tecla de control
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        // Si no es un número ni una tecla de control, cancelar el evento KeyPress
        //        e.Handled = true;
        //    }
        //}
        
        //--------------METODO PARA LIMITAR LOS CARACTERES A 6--------------
        private void textBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {
            // Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;
            }
        }
        //------------BOTON IMPRIMIR---------------
        private void MostrarProgreso()
        {
            using (
                MensajeCargarImprimir progressMessageBox = new MensajeCargarImprimir())
            {
                progressMessageBox.ShowDialog();
            }
        }
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            MostrarProgreso();
        }
        //-----------------------------------------------------


    }
    }


    


