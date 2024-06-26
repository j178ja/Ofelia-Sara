/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE EL TEXTO INTRODUCIDO SE COLOQUE AUTOMATICAMENTE EN
  ---------------MAYUSCULAS---------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public static class TextoEnMayuscula
    {
        // Método para suscribir TextBox a evento TextChanged que convierte texto a mayúsculas
        public static void ConvertirTextoAMayusculas(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.TextChanged += (sender, e) =>
                    {
                        int selectionStart = textBox.SelectionStart;
                        textBox.Text = textBox.Text.ToUpper();
                        textBox.SelectionStart = selectionStart; // Mantener la posición del cursor
                    };
                }
                // Suscribir controles anidados
                if (c.HasChildren)
                {
                    ConvertirTextoAMayusculas(c);
                }
            }
        }
        // Método auxiliar para filtrar caracteres no deseados
        private static string FiltrarTexto(string input)
        {
            StringBuilder filteredText = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // permite solo letras o espacios
                {
                    filteredText.Append(c);
                }
            }
            return filteredText.ToString();
        }
    }
}
    

