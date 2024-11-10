using System;
using System.Windows.Forms;


namespace Clases.Texto
{
    public class ClaseNumeros
    {
        public static string FormatearNumeroConPuntos(string texto)
        {
            // Limitar el texto a 10 caracteres (si quieres mantenerlo igual)
            if (texto.Length > 10)
            {
                texto = texto.Substring(0, 10);
            }

            // Remover puntos existentes
            texto = texto.Replace(".", "");

            // Añadir puntos cada 3 dígitos desde el final
            for (int i = texto.Length - 3; i > 0; i -= 3)
            {
                texto = texto.Insert(i, ".");
            }

            return texto;
        }

        public static void AplicarFormatoYLimite(TextBox textBox, int maxLength)
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            // Establecer la longitud máxima
            textBox.MaxLength = maxLength;

            // Manejar el evento TextChanged para aplicar formato
            textBox.TextChanged += (sender, e) =>
            {
                // Obtener el texto del TextBox
                string texto = textBox.Text;

                // Aplicar formato
                string textoFormateado = FormatearNumeroConPuntos(texto);

                // Evitar un bucle infinito al actualizar el texto
                if (textBox.Text != textoFormateado)
                {
                    textBox.Text = textoFormateado;
                    textBox.SelectionStart = textBox.Text.Length; // Mover el cursor al final del texto
                }
            };
        }
    }
}
