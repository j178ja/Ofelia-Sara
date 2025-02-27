using Ofelia_Sara.Controles.General;
using System;
using System.Text;
using System.Windows.Forms;
public static class MayusculaSola
{
    
    /// <summary>
    /// Método para aplicar la lógica de conversión a mayúsculas a cualquier control de texto.
    /// </summary>
    /// <param name="control"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static void AplicarAControl(Control control)
    {
      
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



    
    /// <summary>
    /// Configurar eventos para controles TextBox o RichTextBox
    /// </summary>
    /// <param name="textBox"></param>
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

    
    /// <summary>
    /// Configurar eventos para ComboBox
    /// </summary>
    /// <param name="CustomComboBox"></param>
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


    /// <summary>
    /// filtrar el texto permitiendo solo letras y espacios en blanco
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static string FiltrarYConvertirAMayusculas(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder filteredText = new ();
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
