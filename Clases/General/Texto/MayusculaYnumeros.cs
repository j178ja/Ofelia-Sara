/*ESTA CLASE PERMITE EL INGRESO DE TEXTO, ESPACIOS Y NUMEROS,IGNORANDO CARACTERES ESPECIALES
  SE USARA ESPECIALEMENTE EN FORMULARIOS DE AGREGAR SECRETARIO E INSTRUCTOR*/

using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;

public class MayusculaYnumeros
{
    /// <summary>
    /// Aplica la conversión a mayúsculas y permite solo números y caracteres especiales a un control.
    /// </summary>
    public static void AplicarAControl(Control control)
    {
        if (control == null)
            throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");

        if (control is CustomTextBox customTextBox)
        {
            ConfigurarTextBox(customTextBox);
        }
        else if (control is CustomComboBox customComboBox)
        {
            ConfigurarComboBox(customComboBox);
        }
        else if (control.HasChildren)
        {
            foreach (Control child in control.Controls)
            {
                AplicarAControl(child);
            }
        }
    }

    /// <summary>
    /// Configura un CustomTextBox para que solo acepte mayúsculas, números, espacios y los caracteres especiales "-" y "*".
    /// </summary>
    private static void ConfigurarTextBox(CustomTextBox customTextBox)
    {
        customTextBox.TextChanged += (sender, e) =>
        {
            if (sender is CustomTextBox tb)
            {
                int cursorPos = tb.SelectionStart; // Guardar la posición del cursor
                string textoConvertido = ConvertirAMayusculasIgnorandoEspeciales(tb.TextValue);

                if (tb.TextValue != textoConvertido)
                {
                    tb.TextValue = textoConvertido;
                    tb.SelectionStart = Math.Min(cursorPos, tb.TextValue.Length); // Restaurar la posición del cursor
                }
            }
        };

        // También manejamos KeyPress para evitar entrada de caracteres no permitidos y mostrar alerta
        customTextBox.KeyPress += (sender, e) =>
        {
            if (!EsCaracterPermitido(e.KeyChar))
            {
                e.Handled = true; // Bloquear la entrada del carácter no permitido
                MostrarAlerta(customTextBox, "Solo puede ingresar letras, números y carácteres ' * '  y  ' - ' .");
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convertir a mayúsculas
            }
        };
    }

    /// <summary>
    /// Configura un CustomComboBox para que solo acepte mayúsculas, números, espacios y los caracteres especiales "-" y "*".
    /// </summary>
    private static void ConfigurarComboBox(CustomComboBox customComboBox)
    {
        customComboBox.KeyPress += (sender, e) =>
        {
            if (!EsCaracterPermitido(e.KeyChar))
            {
                e.Handled = true; // Bloquear la entrada del carácter no permitido
                MostrarAlerta(customComboBox, "Solo puede ingresar letras, números y carácteres ' * '  y  ' - ' .");
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convertir a mayúsculas
            }
        };
    }

    /// <summary>
    /// Convierte una cadena a mayúsculas, permitiendo solo letras, números, espacios, "-" y "*".
    /// </summary>
    public static string ConvertirAMayusculasIgnorandoEspeciales(string input)
    {
        if (input == null)
            return string.Empty;

        StringBuilder resultado = new StringBuilder(input.Length);

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                resultado.Append(char.ToUpper(c));
            }
            else if (char.IsDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '*')
            {
                resultado.Append(c);
            }
        }

        return resultado.ToString();
    }

    /// <summary>
    /// Verifica si un carácter es permitido (mayúsculas, números, espacios, "-" y "*").
    /// </summary>
    private static bool EsCaracterPermitido(char c)
    {
        return char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '*';
    }

    /// <summary>
    /// Muestra una alerta visual debajo del control cuando se ingresa un carácter no permitido.
    /// </summary>
    private static void MostrarAlerta(Control control, string mensaje)
    {
        // Obtener la posición del control en pantalla
        Point posicionControl = control.Parent.PointToScreen(control.Location);
        int x = posicionControl.X + (control.Width / 2);
        int y = posicionControl.Y + control.Height + 5; // Posicionar justo debajo con un margen de 5px

        // Mostrar el mensaje en la posición calculada
        MensajeGeneral.MostrarEnPosicion(mensaje, MensajeGeneral.TipoMensaje.Advertencia, x, y);
    }
}
