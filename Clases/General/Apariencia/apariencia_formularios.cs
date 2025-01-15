/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE DARLE APARIENCIA A LOS FORMULARIOS
  --------------COLOR/TAMAÑO/--------------*/
using System.Drawing;
using System.Windows.Forms;


namespace Ofelia_Sara.Clases.General.Apariencia
{
    public static class AparienciaFormularios
    {
        // Método para cambiar el color de fondo del formulario
        public static void CambiarColorDeFondo(Form form, Color color)
        {
            form.BackColor = color;
        }
    }
}

