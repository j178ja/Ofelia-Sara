/*ESTA CLASE PERMITE EL INGRESO DE TEXTO, ESPACIOS Y NUMEROS,IGNORANDO CARACTERES ESPECIALES
  SE USARA ESPECIALEMENTE EN FORMULARIOS DE AGREGAR SECRETARIO E INSTRUCTOR*/

using Ofelia_Sara.Controles.General;
using System;
using System.Text;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Texto
{
    public class MayusculaYnumeros
    {
        public static void AplicarAControl(Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");

            if (control is CustomTextBox customtextBox)
            {
                ConfigurarTextBox(customtextBox);
            }
            else if (control is CustomComboBox customComboBox)
            {
                ConfigurarComboBox(customComboBox);
            }
            else if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    AplicarAControl(child);
                }
            }
        }

        private static void ConfigurarTextBox(CustomTextBox customTextBox)
        {
            customTextBox.TextChanged += (sender, e) =>
            {
                CustomTextBox tb = sender as CustomTextBox;
                if (tb != null)
                {
                    string textoConvertido = ConvertirAMayusculasIgnorandoEspeciales(tb.Text);
                    tb.Text = textoConvertido;
                    tb.SelectionStart = tb.Text.Length;
                }
            };
        }

        private static void ConfigurarComboBox(CustomComboBox customComboBox)
        {
            customComboBox.KeyPress += (sender, e) =>
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

        public static string ConvertirAMayusculasIgnorandoEspeciales(string input)
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
