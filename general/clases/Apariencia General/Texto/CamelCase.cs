using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.general.clases.Apariencia_General
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
                // Si el carácter es un dígito, lo añade tal cual
                else if (char.IsDigit(c))
                {
                    resultado.Append(c);
                    // Si es un dígito, la próxima letra no debe ser mayúscula
                    proximaMayuscula = false;
                }
                // Si el carácter es especial, se ignora
                else
                {
                    // No hace nada si es un carácter especial
                    continue;
                }
            }

            return resultado.ToString();
        }
    }
}