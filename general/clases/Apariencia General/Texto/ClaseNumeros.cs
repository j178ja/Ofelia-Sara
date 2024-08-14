using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Texto
{
    internal class ClaseNumeros
    {
        public static string FormatearNumeroConPuntos(string texto)
        {
            // Remover puntos existentes
            texto = texto.Replace(".", "");

            // Añadir puntos cada 3 dígitos desde el final
            for (int i = texto.Length - 3; i > 0; i -= 3)
            {
                texto = texto.Insert(i, ".");
            }

            return texto;
        }
    }
}