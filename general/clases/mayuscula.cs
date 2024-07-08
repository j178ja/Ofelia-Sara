/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE EL TEXTO INTRODUCIDO SE COLOQUE AUTOMATICAMENTE EN
  ---------------MAYUSCULAS---------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public static class TextoEnMayuscula
    {
        // Método para suscribir TextBox y ComboBox al evento TextChanged/KeyPress que convierte texto a mayúsculas y filtra números y caracteres especiales
        public static void ConvertirTextoAMayusculas(Control control, params ComboBox[] comboBoxesNumericos)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");
            }

            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.TextChanged += (sender, e) =>
                    {
                        int selectionStart = textBox.SelectionStart;
                        string filteredText = FiltrarTexto(textBox.Text);
                        textBox.Text = filteredText.ToUpper();
                        textBox.SelectionStart = selectionStart;
                    };
                }
                else if (c is ComboBox comboBox)
                {
                    if (Array.Exists(comboBoxesNumericos, element => element == comboBox))
                    {
                        comboBox.KeyPress += (sender, e) =>
                        {
                            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                        };
                    }
                    else
                    {
                        comboBox.KeyPress += (sender, e) =>
                        {
                            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                e.KeyChar = char.ToUpper(e.KeyChar);
                            }
                        };
                    }
                }

                // Llama recursivamente al método para procesar controles anidados
                ConvertirTextoAMayusculas(c, comboBoxesNumericos);
            }
        }

        // Método auxiliar para filtrar caracteres no deseados
        private static string FiltrarTexto(string input)
        {
            StringBuilder filteredText = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c))
                {
                    filteredText.Append(c);
                }
            }
            return filteredText.ToString();
        }
    }
}



//-----------------------------------------------------------------------------------
//-------PROBANDO UN METODO DIFERENTE, MAS COMPLETO Y A SIN POSIBILIDAD DE ERRORES-----------
