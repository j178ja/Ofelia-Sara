using Ofelia_Sara.Controles.General;
using System;
using System.Text;

using System.Windows.Forms; // Necesario para reconocer Control, CustomTextBox y CustomComboBox



namespace Ofelia_Sara.Clases.General.Texto
{
    public static class ConvertirACamelCase
    {
        /// <summary>
        /// Método para convertir una cadena a Camel Case.
        /// </summary>
        public static string Convertir(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            StringBuilder resultado = new(input.Length);
            bool proximaMayuscula = true;

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    resultado.Append(c);
                    proximaMayuscula = true; // La próxima letra será mayúscula
                }
                else if (char.IsLetter(c))
                {
                    resultado.Append(proximaMayuscula ? char.ToUpper(c) : char.ToLower(c));
                    proximaMayuscula = false; // La siguiente letra no será mayúscula
                }
                else
                {
                    resultado.Append(c); // Mantiene caracteres especiales y dígitos
                }
            }

            return resultado.ToString();
        }

        /// <summary>
        /// Aplica la conversión Camel Case automáticamente a un CustomTextBox o CustomComboBox.
        /// </summary>
        public static void AplicarAControl(Control control)
        {
            if (control is CustomTextBox customTextBox)
            {
                customTextBox.TextChanged += (sender, e) =>
                {
                    if (sender is CustomTextBox tb)
                    {
                        int cursorPos = tb.SelectionStart; // Guardar posición del cursor
                        tb.TextValue = Convertir(tb.TextValue);
                        tb.SelectionStart = Math.Min(cursorPos, tb.TextValue.Length); // Restaurar posición del cursor
                    }
                };
            }
            else if (control is CustomComboBox customComboBox)
            {
                customComboBox.TextChanged += (sender, e) =>
                {
                    if (sender is CustomComboBox cb)
                    {
                        int cursorPos = cb.SelectionStart; // Guardar posición del cursor
                        cb.TextValue = Convertir(cb.TextValue);
                        cb.SelectionStart = Math.Min(cursorPos, cb.TextValue.Length); // Restaurar posición del cursor
                    }
                };
            }
            else if (control.HasChildren) // Si el control tiene hijos (como un Panel o Form), aplicamos recursivamente
            {
                foreach (Control child in control.Controls)
                {
                    AplicarAControl(child);
                }
            }
        }
    }
}
