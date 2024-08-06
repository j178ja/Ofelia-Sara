/*ESTA CLASE PERMITE EL INGRESO DE TEXTO, ESPACIOS Y NUMEROS,IGNORANDO CARACTERES ESPECIALES
  SE USARA ESPECIALEMENTE EN FORMULARIOS DE AGREGAR SECRETARIO E INSTRUCTOR*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.general.clases.Apariencia_General
{


    internal class MayusculaSimple
    {
        public static string ConvertirAMayusculasIgnorandoEspeciales(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            StringBuilder resultado = new StringBuilder(input.Length);

            foreach (char c in input)
            {
                // Convierte a mayúsculas si es una letra, o agrega el carácter tal cual si es un número o espacio
                if (char.IsLetter(c))
                {
                    resultado.Append(char.ToUpper(c));
                }
                else if (char.IsDigit(c) || char.IsWhiteSpace(c))
                {
                    resultado.Append(c);
                }
                // Si el carácter no es una letra, número o espacio, se ignora
            }

            return resultado.ToString();
        }
    }
}