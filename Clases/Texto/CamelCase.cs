using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases.Texto;


namespace Clases.Texto
{
    public static class ConvertirACamelCase
    {
        public static string Convertir(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            // Inicializa el StringBuilder con la longitud del input
            StringBuilder resultado = new StringBuilder(input.Length);
            // Indica si el próximo carácter debe ser mayúscula
            bool proximaMayuscula = true;

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    // Si el carácter es un espacio en blanco, añade el espacio tal cual
                    resultado.Append(c);
                    // La próxima letra debe ser mayúscula
                    proximaMayuscula = true;
                }
                else if (char.IsLetter(c))
                {
                    // Si es una letra, la convierte según la bandera proximaMayuscula
                    if (proximaMayuscula)
                    {
                        resultado.Append(char.ToUpper(c));
                    }
                    else
                    {
                        resultado.Append(char.ToLower(c));
                    }
                    // Después de agregar una letra, la siguiente no debe ser mayúscula
                    proximaMayuscula = false;
                }
                // Si el carácter es un dígito o especial, se ignora
                else
                {
                    // No hace nada si es un carácter especial o dígito
                    continue;
                }
            }

            return resultado.ToString();
        }
    }
}
