/*ESTA CLASE PERMITE EL INGRESO DE TEXTO, ESPACIOS Y NUMEROS,IGNORANDO CARACTERES ESPECIALES
  SE USARA ESPECIALEMENTE EN FORMULARIOS DE AGREGAR SECRETARIO E INSTRUCTOR*/

using System;
using System.Text;
using System.Windows.Forms;

namespace Clases_Libreria.Texto
{
    public class MayusculaYnumeros
    {
        public static void AplicarAControl(Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");

            if (control is TextBox textBox)
            {
                ConfigurarTextBox(textBox);
            }
            else if (control is ComboBox comboBox)
            {
                ConfigurarComboBox(comboBox);
            }
            else if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    AplicarAControl(child);
                }
            }
        }

        private static void ConfigurarTextBox(TextBox textBox)
        {
            textBox.TextChanged += (sender, e) =>
            {
                TextBox tb = sender as TextBox;
                if (tb != null)
                {
                    string textoConvertido = ConvertirAMayusculasIgnorandoEspeciales(tb.Text);
                    tb.Text = textoConvertido;
                    tb.SelectionStart = tb.Text.Length;
                }
            };
        }

        private static void ConfigurarComboBox(ComboBox comboBox)
        {
            comboBox.KeyPress += (sender, e) =>
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
                else
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            };
        }

        private static string ConvertirAMayusculasIgnorandoEspeciales(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            StringBuilder resultado = new StringBuilder(input.Length);

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    resultado.Append(char.ToUpper(c));
                }
                else if (char.IsDigit(c) || char.IsWhiteSpace(c))
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }
    }
}
