using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.general.clases.Apariencia_General.Controles.Aplicadas_con_controles;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class CustomDateTextBox : UserControl
    {



        private bool isClosing = false; // Declarar la variable a nivel de clase
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
            SetPlaceholder(textBox_DateDIA, "dd");
            SetPlaceholder(textBox_DateMES, "mm");
            SetPlaceholder(textBox_DateAÑO, "aaaa");
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


        }


        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (textBox.Text == "")
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }



        private void btn_Calendario_Click(object sender, EventArgs e)
        {
            using (var calendarForm = new CALENDARIO())
            {
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = calendarForm.SelectedDate;

                    // Dividir la fecha seleccionada en día, mes y año
                    textBox_DateDIA.Text = selectedDate.Day.ToString("00");  // Día con dos dígitos
                    textBox_DateMES.Text = selectedDate.Month.ToString("00"); // Mes con dos dígitos
                    textBox_DateAÑO.Text = selectedDate.Year.ToString(); // Año completo

                    textBox_DateDIA.ForeColor = Color.Black;
                    textBox_DateMES.ForeColor = Color.Black;
                    textBox_DateAÑO.ForeColor = Color.Black;// Cambiar el color del texto del TextBox a negro
                }
            }
        }


        public void RestorePlaceholders()
        {
            SetPlaceholder(textBox_DateDIA, "dd");
            SetPlaceholder(textBox_DateMES, "mm");
            SetPlaceholder(textBox_DateAÑO, "aaaa");
        }

        public void ClearDate()
        {
            textBox_DateDIA.Clear();
            textBox_DateMES.Clear();
            textBox_DateAÑO.Clear();
        }


        // Método para manejar el evento de cierre del formulario
        /*con este evento se pretende que no se muestre el mensaje de advertencia cuandos e elimina
         el formulario, indicando que debe tener 4 digitos */
        // Método para manejar el cierre del formulario
        public void HandleFormClosing()
        {
            // Marca que el formulario se está cerrando para evitar mostrar mensajes de advertencia
            isClosing = true;
        }


        private void textBox_DateAÑO_Validating(object sender, CancelEventArgs e)
        {
            if (!isClosing)
            {
                // Lógica de validación y mostrar mensaje de advertencia si es necesario
                if (textBox_DateAÑO.Text.Length < 4)
                {
                    // Mostrar mensaje de advertencia
                    MessageBox.Show("El año debe tener al menos 4 dígitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Previene que se cierre el formulario
                }
            }
            else
            {
                // Resetea la bandera después de usarla
                isClosing = false;
            }
        }
        //---------------------------------------------------------------------------
        //--------CALCULAR ANTIGUEDAD----------------------------------------------

     
    }

}