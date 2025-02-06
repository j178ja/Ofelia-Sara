using Ofelia_Sara.Controles.General;
using System;
using System.Text;
using System.Windows.Forms;
public static class MayusculaSola
{
    // Método para aplicar la lógica de conversión a mayúsculas a cualquier control de texto.
    public static void AplicarAControl(Control control)
    {
        if (control == null)
            throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");

        // Verificar si el control es compatible
        if (!(control is TextBoxBase || control is CustomComboBox || control is CustomTextBox))
            throw new ArgumentException("El control no es compatible. Solo se admiten TextBox, ComboBox y controles personalizados derivados.");

        // Configurar eventos para convertir texto a mayúsculas y filtrar caracteres
        if (control is TextBoxBase textBox)
        {
            ConfigurarEventosTextBox(textBox);
        }
        else if (control is CustomComboBox customComboBox)
        {
            ConfigurarEventosComboBox(customComboBox);
        }
        else if (control is CustomTextBox customTextBox)
        {
            ConfigurarEventosCustomTextBox(customTextBox);
        }
    }



    // Configurar eventos para controles TextBox o RichTextBox
    private static void ConfigurarEventosTextBox(TextBoxBase textBox)
    {
        textBox.KeyPress += (sender, e) =>
        {
            // Permite letras, espacios y caracteres de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza otros caracteres
            }
        };

        textBox.TextChanged += (sender, e) =>
        {
            // Guarda la posición del cursor
            int selectionStart = textBox.SelectionStart;

            // Convierte el texto a mayúsculas
            string convertedText = FiltrarYConvertirAMayusculas(textBox.Text);

            // Actualiza el texto del TextBox y posiciona el cursor al final
            if (textBox.Text != convertedText)
            {
                textBox.Text = convertedText;
                textBox.SelectionStart = convertedText.Length; // Establece la posición del cursor al final
            }
        };
    }

    // Configurar eventos para ComboBox
    private static void ConfigurarEventosComboBox(CustomComboBox CustomComboBox)
    {
        CustomComboBox.KeyPress += (sender, e) =>
        {
            // Permite letras, espacios y caracteres de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza otros caracteres
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convierte el carácter a mayúsculas
            }
        };
    }

    // Configurar eventos para CustomTextBox
    private static void ConfigurarEventosCustomTextBox(CustomTextBox customTextBox)
    {
        customTextBox.KeyPress += (sender, e) =>
        {
            // Permite letras, espacios y caracteres de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza otros caracteres
            }
        };

        customTextBox.TextChanged += (sender, e) =>
        {
            // Guarda la posición del cursor
            int selectionStart = customTextBox.SelectionStart;

            // Convierte el texto a mayúsculas
            string convertedText = FiltrarYConvertirAMayusculas(customTextBox.TextValue);

            // Actualiza el texto del CustomTextBox y posiciona el cursor al final
            if (customTextBox.TextValue != convertedText)
            {
                customTextBox.TextValue = convertedText;
                customTextBox.SelectionStart = convertedText.Length; // Establece la posición del cursor al final
            }
        };
    }

    // Método para filtrar el texto permitiendo solo letras y espacios en blanco
    private static string FiltrarYConvertirAMayusculas(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder filteredText = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetter(c) || char.IsWhiteSpace(c))
            {
                filteredText.Append(c); // Agrega caracteres válidos al texto filtrado
            }
        }
        return filteredText.ToString().ToUpper(); // Convierte el texto a mayúsculas
    }
}
