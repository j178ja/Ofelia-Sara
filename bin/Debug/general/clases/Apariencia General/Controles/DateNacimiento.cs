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

            CustomDateTextBox_Load(this, EventArgs.Empty);// inicializar load
        }
        private void CustomDateTextBox_Load(object sender, EventArgs e)
        {
            SetPlaceholder(textBox_DateAÑO, "1990");
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
            if (textBox_DateDIA.Text.Length == 2 && int.TryParse(textBox_DateDIA.Text, out int dia))
            {
                if (dia < 1 || dia > 31)
                {
                    // Mostrar mensaje de error o ajustar el valor
                    MessageBox.Show("El día debe estar entre 1 y 31.", "DIA INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_DateDIA.Clear(); // Método para limpiar el TextBox
                }
            }
        }

        private void textBox_DateMES_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto tiene  dígitos antes de proceder a la validación
            if (textBox_DateMES.Text.Length == 2 && int.TryParse(textBox_DateMES.Text, out int mes))
                
            {
                if (mes < 1 || mes > 12)
                {
                    // Mostrar mensaje de error o ajustar el valor
                    MessageBox.Show("El mes debe estar entre 1 y 12.", "MES INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_DateMES.Clear(); // Método para limpiar el TextBox
                   
                }
            }
        }

        private void textBox_DateAÑO_TextChanged(object sender, EventArgs e)
        {
            // Obtener el año actual
            int añoActual = DateTime.Now.Year;

            // Validar el año ingresado
            // Verificar si el texto tiene 4 dígitos antes de proceder a la validación
            if (textBox_DateAÑO.Text.Length == 4 && int.TryParse(textBox_DateAÑO.Text, out int year))
            {
                // Verificar si el año está en el rango permitido (1930 hasta el año actual)
                if (year < 1930 || year > añoActual)
                {
                    // Mostrar mensaje de error o ajustar el valor
                    MessageBox.Show($"El año debe estar entre 1930 y {añoActual}.", "AÑO INVALIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            // Establecer el texto inicial y el color del placeholder
            textBox.Text = placeholder;
            textBox.ForeColor = Color.LightGray;

            textBox.Enter += (sender, e) =>
            {
                // Cuando el usuario entra en el TextBox, eliminar el placeholder si está presente
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black; // Cambiar el color del texto al normal
                }
            };

            textBox.Leave += (sender, e) =>
            {
                // Cuando el usuario deja el TextBox, mostrar el placeholder si está vacío
                if (textBox.Text == "")
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.LightGray; // Cambiar el color del texto al del placeholder
                }
            };
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
