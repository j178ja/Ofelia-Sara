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

            // Define las excepciones para los TextBox y ComboBox.
            var textBoxExcepciones = new Dictionary<string, bool>
        {
            { "textBox_NumeroIpp", true }  // Este TextBox solo acepta números.
        };

            var comboBoxExcepciones = new Dictionary<string, bool>
        {
            { "ComboBox_Ufid", true }  // Este ComboBox acepta letras, números y espacios.
        };

            // Aplica la configuración a todos los controles del formulario.
            TextoEnMayuscula.AplicarAControles(this, textBoxExcepciones, comboBoxExcepciones); //para guardar los items

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
        
        //_____________________________________________________________________________________
        //-----------------------NUMERO IPP--------------------------------------------------
        private void textBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {// Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;
            }
        }
        //-------------------------------------------------------------
        //---------------COMBO BOX IPP 1      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp1_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp1.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp1.Text = comboBox_Ipp1.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp1.SelectionStart = comboBox_Ipp1.Text.Length;
            }
        }

        //---------------COMBO BOX IPP 2      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp2_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp2.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp2.Text = comboBox_Ipp2.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp2.SelectionStart = comboBox_Ipp2.Text.Length;
            }
        }

        //---------------COMBO BOX IPP 4      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp4_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp4.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp4.Text = comboBox_Ipp4.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp4.SelectionStart = comboBox_Ipp4.Text.Length;
            }
        }
        //-----EVENTO PARA COMPLETAR CON "0" LOS CARACTERES FALTANTE EN NUMERO IPP------
        private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Obtiene el TextBox que disparó el evento
                System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

                if (textBox != null)
                {
                    // Obtiene el texto actual del TextBox
                    string currentText = textBox.Text;

                    // Verifica si el texto es numérico
                    if (int.TryParse(currentText, out _))
                    {
                        // Completa el texto con ceros a la izquierda hasta alcanzar 6 caracteres
                        string completedText = currentText.PadLeft(6, '0');

                        // Actualiza el texto del TextBox
                        textBox.Text = completedText;
                    }
                }

                // Marca el evento como manejado para evitar el comportamiento predeterminado
                e.Handled = true;
            }
        }




    }
}
