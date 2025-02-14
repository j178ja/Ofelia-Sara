
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Apariencia
{
    public static class IconoEscudo
    {
        /// <summary>
        /// para establecer el icono en la barra de título del formulario
        /// </summary>
        /// <param name="form"></param>
        /// <param name="iconFilePath"></param>
        public static void SetFormIcon(Form form, string iconFilePath)
        {
            // Carga el icono desde el archivo especificado
            form.Icon = new Icon(iconFilePath);
        }
    }
}
