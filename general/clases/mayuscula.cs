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
        // Método para suscribir TextBox al evento TextChanged que convierte texto a mayúsculas y filtra números y caracteres especiales
        public static void ConvertirTextoAMayusculas(Panel panel)
        {
            // Verifica si el panel no es nulo
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel), "El panel no puede ser nulo.");
            }

            // Recorre todos los controles hijos del panel
            foreach (Control c in panel.Controls)
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
