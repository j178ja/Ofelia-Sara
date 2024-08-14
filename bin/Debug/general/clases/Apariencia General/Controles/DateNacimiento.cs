using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class CustomDateTextBox : UserControl
    {
        public CustomDateTextBox()
        {
            InitializeComponent();

            // Configurar textBox_DateDIA
            textBox_DateDIA.MaxLength = 2; // Limitar a 2 caracteres
            textBox_DateDIA.KeyPress += TextBox_Date_KeyPress;

            // Configurar textBox_DateMES
            textBox_DateMES.MaxLength = 2; // Limitar a 2 caracteres
            textBox_DateMES.KeyPress += TextBox_Date_KeyPress;

            // Configurar textBox_DateAÑOÑ
            textBox_DateAÑO.MaxLength = 4; // Limitar a 4 caracteres
            textBox_DateAÑO.KeyPress += TextBox_Date_KeyPress;
        }

        // Manejar el evento KeyPress para permitir solo números
        private void TextBox_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento si el carácter no es un dígito o una tecla de control
            }
        }

        private void textBox_DateDIA_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_DateDIA.Text, out int dia))
            {
                if (dia < 1 || dia > 31)
                {
                    // Mostrar mensaje de error o ajustar el valor
                    MessageBox.Show("El día debe estar entre 1 y 31.", "Día Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox_DateMES_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_DateMES.Text, out int mes))
            {
                if (mes < 1 || mes > 12)
                {
                    // Mostrar mensaje de error o ajustar el valor
                    MessageBox.Show("El mes debe estar entre 1 y 12.", "Mes Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_DateMES.Clear(); // Método para limpiar el TextBox
                   
                }
            }
        }

        private void textBox_DateAÑO_TextChanged(object sender, EventArgs e)
        {
            // Obtener el año actual
            int añoActual = DateTime.Now.Year;

            // Validar el año ingresado
            if (int.TryParse(textBox_DateAÑO.Text, out int year))
            {
                // Verificar si el año está en el rango permitido (1930 hasta el año actual)
                if (year < 1930 || year > añoActual)
                {
                    // Mostrar mensaje de error o ajustar el valor
                    MessageBox.Show($"El año debe estar entre 1930 y {añoActual}.", "Año Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // limpiar el TextBox o ajustar el texto
                    textBox_DateAÑO.Clear(); // Método para limpiar el TextBox
                }
            }
        
            else if (textBox_DateAÑO.Text.Length == 4)
            {
                // Mensaje de error si no es un número válido y ya tiene 4 caracteres
                MessageBox.Show("El año ingresado no es válido. Asegúrese de ingresar solo números.", "Año Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_DateAÑO.Text = ""; // Opcional: limpiar el TextBox
            }
        }



        private void btn_Calendario_Click(object sender, EventArgs e)
        {
            using (var calendarForm = new CALENDARIO())
            {
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    textBox_Date.Text = calendarForm.SelectedDate.ToShortDateString();
                }
            }
        }

      
    }
}
