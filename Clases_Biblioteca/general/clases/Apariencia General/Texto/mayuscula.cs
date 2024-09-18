/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE EL TEXTO INTRODUCIDO SE COLOQUE AUTOMATICAMENTE EN
  ---------------MAYUSCULAS---------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General;
// Esta clase contiene métodos para convertir texto a mayúsculas y filtrar caracteres especiales y números.
public static class TextoEnMayuscula
{
    // Método principal para aplicar la lógica de conversión a controles dentro de un formulario o panel.
    public static void AplicarAControles(Control control, Dictionary<string, bool> textBoxExcepciones = null, Dictionary<string, bool> comboBoxExcepciones = null)
    {
        // Verifica si el control no es nulo.
        if (control == null)
            throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");

        // Recorre todos los controles hijos del control proporcionado.
        foreach (Control c in control.Controls)
        {
            // Configura los TextBox según las excepciones especificadas.
            if (c is TextBox textBox)
            {
                ConfigurarTextBox(textBox, textBoxExcepciones);
            }
            // Configura los ComboBox según las excepciones especificadas.
            else if (c is ComboBox comboBox)
            {
                ConfigurarComboBox(comboBox, comboBoxExcepciones);
            }
            // Llama recursivamente para aplicar la configuración a los controles anidados.
            else if (c.HasChildren)
            {
                AplicarAControles(c, textBoxExcepciones, comboBoxExcepciones);
            }
        }
    }

    // Método para configurar un TextBox.
    public static void ConfigurarTextBox(TextBox textBox, Dictionary<string, bool> textBoxExcepciones)
    {
        // Verifica si el TextBox está en la lista de excepciones para solo permitir dígitos.
        if (textBoxExcepciones != null && textBoxExcepciones.ContainsKey(textBox.Name) && textBoxExcepciones[textBox.Name])
        {
            // Maneja el evento KeyPress para permitir solo números.
            textBox.KeyPress += (sender, e) =>
            {
                // Permite solo caracteres de control y dígitos.
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Rechaza otros caracteres.
                }
            };
        }
        //------para manejar facil textbox caratula
        else if (textBox.Name == "textBox_Caratula")
        {
            // Configura para permitir letras, números y espacios.
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true; // Rechaza otros caracteres.
                }
            };

            // Maneja el evento TextChanged para convertir a mayúsculas usando MayusculaSimple.
            textBox.TextChanged += (sender, e) =>
            {
                //    // Guarda la posición del cursor.
                //    int selectionStart = textBox.SelectionStart;

                //    // Convierte el texto usando la clase MayusculaSimple.
                //    string convertedText = MayusculaYnumeros.ConvertirAMayusculasIgnorandoEspeciales(textBox.Text);

                //    // Actualiza el texto del TextBox y posiciona el cursor al final.
                //    textBox.Text = convertedText;
                //    textBox.SelectionStart = convertedText.Length; // Establece la posición del cursor al final del texto.
                MayusculaYnumeros.AplicarAControl(textBox);

            };
        }

        else
        {
            // Maneja el evento KeyPress para permitir solo letras y espacios.
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true; // Rechaza otros caracteres.
                }
            };
            // Maneja el evento TextChanged para convertir el texto a mayúsculas y filtrar caracteres especiales.
            textBox.TextChanged += (sender, e) =>
            {
                int selectionStart = textBox.SelectionStart; // Guarda la posición del cursor.
                string filteredText = FiltrarTexto(textBox.Text); // Filtra el texto.
                textBox.Text = filteredText.ToUpper(); // Convierte el texto a mayúsculas.
                                                       // Establece la posición del cursor al final del texto.
                textBox.SelectionStart = textBox.Text.Length;
            };
        }
    }




    // Método para configurar un ComboBox.
    public static void ConfigurarComboBox(ComboBox comboBox, Dictionary<string, bool> comboBoxExcepciones)
    {
        // Verifica si el ComboBox tiene una excepción específica.
        if (comboBoxExcepciones != null && comboBoxExcepciones.ContainsKey(comboBox.Name) && comboBoxExcepciones[comboBox.Name])
        {
            // Configuración para ComboBox con excepciones específicas (acepta letras, números y espacios).
            comboBox.KeyPress += (sender, e) =>
            {
                // Permite letras, dígitos, espacios y caracteres de control.
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true; // Rechaza caracteres no válidos.
                }
                else
                {
                    e.KeyChar = char.ToUpper(e.KeyChar); // Convierte el carácter a mayúsculas.
                }
            };
        }
        else
        {
            // Configuración por defecto (acepta letras y espacios, convierte las letras a mayúsculas).
            comboBox.KeyPress += (sender, e) =>
            {
                // Permite letras, dígitos, espacios y caracteres de control.
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true; // Rechaza caracteres no válidos.
                }
                else
                {
                    e.KeyChar = char.ToUpper(e.KeyChar); // Convierte el carácter a mayúsculas.
                }
            };
        }
    }

    // Método para filtrar el texto, permitiendo solo letras y espacios en blanco.
    private static string FiltrarTexto(string input)
    {
        StringBuilder filteredText = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetter(c) || char.IsWhiteSpace(c))
            {
                filteredText.Append(c); // Agrega caracteres válidos al texto filtrado.
            }
        }
        return filteredText.ToString(); // Devuelve el texto filtrado.
    }
}

