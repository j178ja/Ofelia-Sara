using Ofelia_Sara.Controles.General;
using System;


namespace Ofelia_Sara.Clases.General.Texto
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

        public static void AplicarFormatoYLimite(CustomTextBox customTextBox, int maxLength)
        {
            if (customTextBox == null)
                throw new ArgumentNullException(nameof(customTextBox));

            // Establecer la longitud máxima
            customTextBox.MaxLength = maxLength;

            // Manejar el evento TextChanged para aplicar formato
            customTextBox.TextChanged += (sender, e) =>
            {
                // Obtener el texto del CustomTextBox
                string texto = customTextBox.TextValue; // Usa TextValue para acceder al texto

                // Aplicar formato
                string textoFormateado = FormatearNumeroConPuntos(texto);

                // Evitar un bucle infinito al actualizar el texto
                if (texto != textoFormateado)
                {
                    customTextBox.TextValue = textoFormateado; // Actualiza el texto
                    customTextBox.InnerTextBox.SelectionStart = textoFormateado.Length; // Mover el cursor al final
                }
            };
        }

    }
}
