using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.general.clases.Apariencia_General.Generales
{
    using System.Drawing;
    using System.Windows.Forms;

    namespace Ofelia_Sara.general.clases.Botones
    {
        internal static class FormPositioner
        {
            public static void PosicionarDebajo(Form formPrincipal, Form formHijo)
            {
                // Obtener la ubicación del formulario principal en la pantalla
                Point location = formPrincipal.Location;

                // Configurar la ubicación del formulario hijo justo debajo del formulario principal
                formHijo.StartPosition = FormStartPosition.Manual;
                formHijo.Location = new Point(location.X, location.Y + formPrincipal.Height);
            }
        }
    }
}
