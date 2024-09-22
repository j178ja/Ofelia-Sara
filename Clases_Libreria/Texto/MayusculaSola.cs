using System;
using System.Text;
using System.Windows.Forms;

public static class MayusculaSola
{
    // Método para aplicar la lógica de conversión a mayúsculas a un TextBox específico.
    public static void AplicarAControl(TextBox textBox)
    {
        if (textBox == null)
            throw new ArgumentNullException(nameof(textBox), "El TextBox no puede ser nulo.");

        // Configura el evento KeyPress para permitir solo letras y espacios.
        textBox.KeyPress += (sender, e) =>
        {
            // Permite letras, espacios y caracteres de control.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza otros caracteres.
            }
        };

        // Configura el evento TextChanged para convertir el texto a mayúsculas y filtrar caracteres no permitidos.
        textBox.TextChanged += (sender, e) =>
        {
            // Guarda la posición del cursor.
            int selectionStart = textBox.SelectionStart;

            // Convierte el texto usando el método FiltrarYConvertirAMayusculas.
            string convertedText = FiltrarYConvertirAMayusculas(textBox.Text);

            // Actualiza el texto del TextBox y posiciona el cursor al final.
            textBox.Text = convertedText;
            textBox.SelectionStart = convertedText.Length; // Establece la posición del cursor al final del texto.
        };
    }

    // Método para aplicar la lógica de conversión a mayúsculas a un ComboBox específico.
    public static void AplicarAControl(ComboBox comboBox)
    {
        if (comboBox == null)
            throw new ArgumentNullException(nameof(comboBox), "El ComboBox no puede ser nulo.");

        // Configura el evento KeyPress para permitir solo letras y espacios.
        comboBox.KeyPress += (sender, e) =>
        {
            // Permite letras, espacios y caracteres de control.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza otros caracteres.
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convierte el carácter a mayúsculas.
            }
        };
    }

    // Método para filtrar el texto permitiendo solo letras y espacios en blanco.
    private static string FiltrarYConvertirAMayusculas(string input)
    {
        StringBuilder filteredText = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetter(c) || char.IsWhiteSpace(c))
            {
                filteredText.Append(c); // Agrega caracteres válidos al texto filtrado.
            }
        }
        return filteredText.ToString().ToUpper(); // Convierte el texto a mayúsculas.
    }
}
