/*ESTA CLASE PERMITE EL INGRESO DE TEXTO, ESPACIOS Y NUMEROS,IGNORANDO CARACTERES ESPECIALES
  SE USARA ESPECIALEMENTE EN FORMULARIOS DE AGREGAR SECRETARIO E INSTRUCTOR*/

using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System.Text.RegularExpressions;
public class MayusculaYnumeros
{
    private static bool evitandoReentrada = false; //



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
        else if (control.HasChildren) //para que aplique a controles hijos
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
        if (customTextBox == null || (bool)(customTextBox.Tag ?? false))
            return;

        customTextBox.Tag = true; // Marcar como configurado

        string textoFormateado = ConvertirAMayusculasSoloLetrasNumeros(customTextBox.TextValue);

        if (customTextBox.TextValue != textoFormateado)
        {
            customTextBox.TextValue = textoFormateado;

            // Poner el cursor al final
            customTextBox.SelectionStart = customTextBox.TextValue.Length;
        }

        // --- Evento KeyPress ---
        customTextBox.KeyPress += (sender, e) =>
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                return;

            if (!EsCaracterPermitido(e.KeyChar, permitirEspeciales: false))
            {
                e.Handled = true;
                MostrarAlerta(customTextBox, "Solo puede ingresar letras, números y espacios.");
                return;
            }

            if (customTextBox.TextValue.Length == 0 && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // No permitir espacios iniciales
                return;
            }

            // Insertar en la posición actual
            int cursorPos = customTextBox.SelectionStart;
            string textoActual = customTextBox.TextValue;
            string textoNuevo = textoActual.Substring(0, cursorPos) + e.KeyChar + textoActual.Substring(cursorPos);

            string textoConvertido = ConvertirAMayusculasSoloLetrasNumeros(textoNuevo);

            e.Handled = true;
            customTextBox.TextValue = textoConvertido;
            customTextBox.SelectionStart = Math.Min(cursorPos + 1, customTextBox.TextValue.Length);
        };

        // --- Evento TextChanged ---
        customTextBox.TextChanged += (sender, e) =>
        {
            if (evitandoReentrada)
                return;

            if (sender is CustomTextBox tb)
            {
                int cursorPos = tb.SelectionStart;
                string convertido = ConvertirAMayusculasSoloLetrasNumeros(tb.TextValue);

                if (tb.TextValue != convertido)
                {
                    evitandoReentrada = true;
                    tb.TextValue = convertido;
                    tb.SelectionStart = Math.Min(cursorPos, tb.TextValue.Length);
                    evitandoReentrada = false;
                }
            }
        };
    }
    /// <summary>
    /// Configura un CustomComboBox para que solo acepte letras, números y espacios.
    /// Además, evita que el primer carácter sea un espacio.
    /// </summary>
    private static void ConfigurarComboBox(CustomComboBox customComboBox)
    {
        if (customComboBox == null)
            return;

        customComboBox.KeyPress += (sender, e) =>
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                return;

            if (!EsCaracterPermitido(e.KeyChar, permitirEspeciales: false))
            {
                e.Handled = true;
                if (!customComboBox.Tag?.ToString().Contains("alerta") ?? true)
                {
                    customComboBox.Tag = "alerta";
                    MostrarAlerta(customComboBox, "Solo puede ingresar letras, números y espacios.");
                    customComboBox.Tag = null;
                }
                return;
            }

            if (customComboBox.Text.Length == 0 && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            int cursorPos = customComboBox.SelectionStart;
            string nuevoTexto = customComboBox.Text[..cursorPos] + e.KeyChar + customComboBox.Text[cursorPos..];
            string convertido = ConvertirAMayusculasSoloLetrasNumeros(nuevoTexto);

            e.Handled = true;
            customComboBox.Text = convertido;
            customComboBox.SelectionStart = Math.Min(cursorPos + 1, customComboBox.Text.Length);
        };

        customComboBox.TextChanged += (sender, e) =>
        {
            if (sender is CustomComboBox cb)
            {
                int cursorPos = cb.SelectionStart;
                string convertido = ConvertirAMayusculasSoloLetrasNumeros(cb.Text);

                if (cb.Text != convertido)
                {
                    cb.Text = convertido;
                    cb.SelectionStart = Math.Min(cursorPos, cb.Text.Length);
                }
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
                    // Obtener el texto actual + la nueva tecla
                    if (sender is CustomTextBox tb)
                    {
                      
                        int cursorPos = tb.SelectionStart;
                        string textoActual = tb.TextValue;
                       
                        // Insertar la nueva tecla en la posición del cursor
                        string textoNuevo = textoActual.Substring(0, cursorPos) +
                                            e.KeyChar +
                                            textoActual.Substring(cursorPos);

                        // Procesar el texto nuevo
                        string textoConvertido = ConvertirAMayusculasSoloLetrasNumeros(textoNuevo);

                        // Cancelar la entrada original
                        e.Handled = true;

                        // Aplicar el texto procesado
                        tb.TextValue = textoConvertido;
                        tb.SelectionStart = Math.Min(cursorPos + 1, tb.TextValue.Length);
                    }
                }

            };

        }


    /// <summary>
    /// Convierte una cadena a mayúsculas, permitiendo solo letras y números.
    /// </summary>
    //private static string ConvertirAMayusculasSoloLetrasNumeros(string input)
    //{
    //    if (input == null)
    //        return string.Empty;

    //    StringBuilder resultado = new(input.Length);
    //    foreach (char c in input)
    //    {
    //        if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
    //        {
    //            resultado.Append(char.ToUpper(c));
    //        }
    //    }

    //    return resultado.ToString();
    //}
    private static string ConvertirAMayusculasSoloLetrasNumeros(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        StringBuilder resultado = new(input.Length);
        char? ultimoTipo = null;
        bool primerCaracterAgregado = false;

        foreach (char c in input)
        {
            char caracter = char.ToUpper(c);

            if (char.IsWhiteSpace(caracter))
            {
                if (primerCaracterAgregado && resultado[^1] != ' ')
                {
                    resultado.Append(' ');
                    ultimoTipo = 'S';
                }
            }
            else if (char.IsLetter(caracter))
            {
                if (ultimoTipo == 'D')
                    resultado.Append("  ");

                if (!primerCaracterAgregado)
                {
                    resultado.Append(caracter);
                    primerCaracterAgregado = true;
                }
                else
                {
                    resultado.Append(caracter);
                }

                ultimoTipo = 'L';
            }
            else if (char.IsDigit(caracter))
            {
                if (!primerCaracterAgregado && caracter == '0')
                    continue;

                if (ultimoTipo == 'L')
                    resultado.Append("  ");

                resultado.Append(caracter);
                primerCaracterAgregado = true;
                ultimoTipo = 'D';
            }
            else
            {
                // Caracter especial → ignorado
                continue;
            }
        }

        return resultado.ToString().Trim();
    }


    /// <summary>
    /// Convierte una cadena a mayúsculas, permitiendo letras, números, espacios y los caracteres "*", "/", "-".
    /// </summary>
    private static string ConvertirAMayusculasConEspeciales(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        StringBuilder resultado = new(input.Length);
        char? ultimoTipo = null; // 'L' = letra, 'D' = dígito, 'S' = espacio, 'E' = especial

        foreach (char c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                if (resultado.Length > 0 && resultado[^1] != ' ')
                    resultado.Append(' ');

                ultimoTipo = 'S';
            }
            else if (char.IsLetter(c))
            {
                if (ultimoTipo == 'D' || ultimoTipo == 'S' || ultimoTipo == 'E')
                    resultado.Append(' ');

                resultado.Append(char.ToUpper(c));
                ultimoTipo = 'L';
            }
            else if (char.IsDigit(c))
            {
                if (ultimoTipo == 'L' || ultimoTipo == 'S' || ultimoTipo == 'E')
                    resultado.Append(' ');

                resultado.Append(c);
                ultimoTipo = 'D';
            }
            else if (c == '*' || c == '/' || c == '-')
            {
                if (ultimoTipo == 'L' || ultimoTipo == 'D')
                    resultado.Append(' ');

                resultado.Append(c);
                ultimoTipo = 'E';
            }
            // cualquier otro carácter: ignorar
        }

        // Eliminar espacios duplicados y recortar
        return Regex.Replace(resultado.ToString(), @"\s{2,}", " ").Trim();
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
