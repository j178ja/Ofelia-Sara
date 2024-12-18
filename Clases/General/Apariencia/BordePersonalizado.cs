/* se lo usa asi 
  RedondearBordes.Aplicar(this, 16);//Redondea los bordes de panel superior e inferior
*/


using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Apariencia
{
    public static class RedondearBordes
    {
        /// <summary>
        /// Aplica bordes redondeados a un control o formulario.
        /// </summary>
        /// <param name="control">El control o formulario al que se le aplicarán los bordes redondeados.</param>
        /// <param name="radio">El radio del redondeo.</param>
        public static void Aplicar(Control control, int radio)
        {
            if (control == null || radio <= 0) return;

            GraphicsPath path = new GraphicsPath();

            // Crear bordes redondeados
            path.AddArc(0, 0, radio, radio, 180, 90); // Esquina superior izquierda
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90); // Superior derecha
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90); // Inferior derecha
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90); // Inferior izquierda
            path.CloseFigure();

            // Aplicar la región al control
            control.Region = new Region(path);
        }
    }
}
