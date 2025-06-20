/*clase para dar formato al texto de los richtextbox
 se la invoca desde baseform*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Texto
{
    public static class RichTextBoxUtils
    {
        public static void FormatearOracionYMayuscula(RichTextBox rtb)
        {
            if (rtb == null || string.IsNullOrWhiteSpace(rtb.Text))
                return;

            int cursorPos = rtb.SelectionStart;

            string texto = rtb.Text;
            StringBuilder textoFormateado = new();

            bool convertirSiguiente = true;

            foreach (char c in texto)
            {
                if (convertirSiguiente && char.IsLetter(c))
                {
                    textoFormateado.Append(char.ToUpper(c));
                    convertirSiguiente = false;
                }
                else
                {
                    textoFormateado.Append(c);
                }

                if (c == '.')
                    convertirSiguiente = true;
            }

            if (rtb.Text != textoFormateado.ToString())
            {
                rtb.Text = textoFormateado.ToString();
                rtb.SelectionStart = Math.Min(cursorPos, rtb.Text.Length);
            }
        }
    }
}
