/* Esta clase contiene las clases para incorporar 
    1) ICONO ESCUDO POLICIA BS AS
    2) ICONO ESCUDO ESCRIBIENTE
 */

using System.Drawing;
using System.Windows.Forms;

namespace Clases_Libreria.Apariencia
{
    public static class IconoEscudo
    {
        // Método para establecer el icono en la barra de título del formulario
        public static void SetFormIcon(Form form, string iconFilePath)
        {
            form.Icon = new Icon(iconFilePath); // Carga el icono desde el archivo especificado
        }

    }
}
