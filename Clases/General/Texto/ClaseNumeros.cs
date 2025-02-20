using Ofelia_Sara.Controles.General;
using System;
using System.Windows.Controls;
using System.Windows.Forms;


namespace Ofelia_Sara.Clases.General.Texto
{
    public class ClaseNumeros
    {
        /// <summary>
        /// metodo para darle formato a numero de legajo y dni 
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
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
            ArgumentNullException.ThrowIfNull(customTextBox);

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
        /// <summary>
        /// Aplica la restricción de solo números a CustomTextBox y CustomComboBox.
        /// </summary>
        public static void SoloNumeros(System.Windows.Forms.Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (control is CustomTextBox customTextBox)
            {
                customTextBox.KeyPress += Control_KeyPress;
            }
            else if (control is CustomComboBox customComboBox)
            {
                customComboBox.KeyPress += Control_KeyPress;
            }
            else
            {
                throw new ArgumentException("El control no admite restricciones de solo números.", nameof(control));
            }
        }

        /// <summary>
        /// Método KeyPress común para restringir a solo números.
        /// </summary>
        private static void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como backspace y suprimir)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear entrada
            }
        }
    }
}
