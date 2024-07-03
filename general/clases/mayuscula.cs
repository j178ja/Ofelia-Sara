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
        public static void ConvertirTextoAMayusculas(Control control)
        {
            // Verifica si el control no es nulo
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");
            }

            // Recorre todos los controles hijos del control proporcionado
            foreach (Control c in control.Controls)
            {
                // Verifica si el control actual es un TextBox
                if (c is TextBox textBox)
                {
                    // Suscribe el evento TextChanged del TextBox
                    textBox.TextChanged += (sender, e) =>
                    {
                        // Guarda la posición actual del cursor
                        int selectionStart = textBox.SelectionStart;
                        // Filtra el texto para eliminar números y caracteres especiales
                        string filteredText = FiltrarTexto(textBox.Text);
                        // Convierte el texto filtrado a mayúsculas
                        textBox.Text = filteredText.ToUpper();
                        // Restaura la posición del cursor
                        textBox.SelectionStart = selectionStart;
                    };
                }
                // Verifica si el control actual es un ComboBox
                else if (c is ComboBox comboBox)
                {
                    // Suscribe el evento KeyPress del ComboBox para manejar la entrada de texto
                    comboBox.KeyPress += (sender, e) =>
                    {
                        // Verifica si la tecla presionada no es un número ni un carácter especial
                        if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
                        {
                            // Si es un número o un carácter especial, cancela el evento
                            e.Handled = true;
                        }
                        else
                        {
                            // Si es una letra, convierte a mayúsculas
                            e.KeyChar = char.ToUpper(e.KeyChar);
                        }
                    };
                }

                // Aplica la misma lógica a los controles anidados si existen
                if (c.HasChildren)
                {
                    ConvertirTextoAMayusculas(c);
                }
            }
        }

        // Método auxiliar para filtrar caracteres no deseados
        private static string FiltrarTexto(string input)
        {
            // StringBuilder para construir la cadena filtrada
            StringBuilder filteredText = new StringBuilder();
            // Recorre cada carácter en la cadena de entrada
            foreach (char c in input)
            {
                // Verifica si el carácter es una letra o un espacio
                if (char.IsLetter(c) || char.IsWhiteSpace(c))
                {
                    // Si es una letra o un espacio, se añade al StringBuilder
                    filteredText.Append(c);
                }
            }
            // Convierte el StringBuilder a una cadena y la retorna
            return filteredText.ToString();
        }
    }
}
