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
    /// Aplica la conversión a mayúsculas y restringe los caracteres permitidos en CustomTextBox y CustomComboBox.
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
    /// Configura un CustomTextBox para que solo acepte letras, números y espacios.
    /// Además, evita que el primer carácter sea un espacio.
    /// </summary>
    private static void ConfigurarTextBox(CustomTextBox customTextBox)
    {
        customTextBox.TextChanged += (sender, e) =>
        {
            if (sender is CustomTextBox tb)
            {
                int cursorPos = tb.SelectionStart;
                string textoConvertido = ConvertirAMayusculasSoloLetrasNumeros(tb.TextValue);

                if (tb.TextValue != textoConvertido)
                {
                    tb.TextValue = textoConvertido;
                    tb.SelectionStart = Math.Min(cursorPos, tb.TextValue.Length);
                }
            }
        };

        customTextBox.KeyPress += (sender, e) =>
        {
            // Permitir tecla "Borrar" (Backspace) y "Eliminar" (Delete)
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                return;
            }
            if (!EsCaracterPermitido(e.KeyChar, permitirEspeciales: false))
            {
                e.Handled = true;
                MostrarAlerta(customTextBox, "Solo puede ingresar letras, números y espacios.");
            }
            else if (customTextBox.TextValue.Length == 0 && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Evita que el primer carácter sea un espacio
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        };
    }

    /// <summary>
    /// Configura un CustomComboBox para que solo acepte letras, números y espacios.
    /// Además, evita que el primer carácter sea un espacio.
    /// </summary>
    private static void ConfigurarComboBox(CustomComboBox customComboBox)
    {
        customComboBox.KeyPress += (sender, e) =>
        {
            // Permitir tecla "Borrar" (Backspace) y "Eliminar" (Delete)
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                return;
            }
            if (!EsCaracterPermitido(e.KeyChar, permitirEspeciales: false))
            {
                e.Handled = true;
                MostrarAlerta(customComboBox, "Solo puede ingresar letras, números y espacios.");
            }
            else if (customComboBox.Text.Length == 0 && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Evita que el primer carácter sea un espacio
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        };
    }

    /// <summary>
    /// Configura un CustomTextBox para que permita letras, números, espacios y los caracteres "*", "/", "-", "-".
    /// </summary>
    public static void ConfigurarTextoConEspeciales(CustomTextBox customTextBox)
    {
        if (customTextBox == null)
            throw new ArgumentNullException(nameof(customTextBox), "El control no puede ser nulo.");

        customTextBox.TextChanged += (sender, e) =>
        {
            if (sender is CustomTextBox tb)
            {
                int cursorPos = tb.SelectionStart;
                string textoConvertido = ConvertirAMayusculasConEspeciales(tb.TextValue);

                if (tb.TextValue != textoConvertido)
                {
                    tb.TextValue = textoConvertido;
                    tb.SelectionStart = Math.Min(cursorPos, tb.TextValue.Length);
                }
            }
        };

       
            customTextBox.KeyPress += (sender, e) =>
            {
                // Permitir tecla "Borrar" (Backspace) y "Eliminar" (Delete)
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                {
                    return;
                }

                // Si no es Backspace ni Delete, validar caracteres
                if (!EsCaracterPermitido(e.KeyChar, permitirEspeciales: true))
                {
                    e.Handled = true;
                    MostrarAlerta(customTextBox, "Solo puede ingresar letras, números, espacios y los caracteres '*', '/', '-'.");
                }
                else if (customTextBox.TextValue.Length == 0 && char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true; // Evita que el primer carácter sea un espacio
                }
                else
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            };

        }


    /// <summary>
    /// Convierte una cadena a mayúsculas, permitiendo solo letras y números.
    /// </summary>
    private static string ConvertirAMayusculasSoloLetrasNumeros(string input)
    {
        if (input == null)
            return string.Empty;

        StringBuilder resultado = new(input.Length);
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
            {
                resultado.Append(char.ToUpper(c));
            }
        }

        return resultado.ToString();
    }

    /// <summary>
    /// Convierte una cadena a mayúsculas, permitiendo letras, números, espacios y los caracteres "*", "/", "-".
    /// </summary>
    private static string ConvertirAMayusculasConEspeciales(string input)
    {
        if (input == null)
            return string.Empty;

        StringBuilder resultado = new(input.Length);
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '*' || c == '/' || c == '-')
            {
                resultado.Append(char.ToUpper(c));
            }
        }

        return resultado.ToString();
    }

    /// <summary>
    /// Verifica si un carácter es permitido según la configuración especificada.
    /// </summary>
    private static bool EsCaracterPermitido(char c, bool permitirEspeciales)
    {
        return char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || (permitirEspeciales && (c == '*' || c == '/' || c == '-'));
    }

    /// <summary>
    /// Muestra una alerta visual debajo del control cuando se ingresa un carácter no permitido.
    /// </summary>
    private static void MostrarAlerta(Control control, string mensaje)
    {
        Point posicionControl = control.Parent.PointToScreen(control.Location);
        int x = posicionControl.X + (control.Width / 2);
        int y = posicionControl.Y + control.Height + 5;

        using (MensajeGeneral mensajeForm = new MensajeGeneral(mensaje, MensajeGeneral.TipoMensaje.Advertencia))
        {
            mensajeForm.StartPosition = FormStartPosition.Manual;
            mensajeForm.Location = new Point(x - (mensajeForm.Width / 2), y);
            mensajeForm.ShowDialog();
        }
    }
}
