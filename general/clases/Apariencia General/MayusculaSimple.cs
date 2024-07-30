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
                if (char.IsLetter(c))
                {
                    resultado.Append(char.ToUpper(c));
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }
    }
}