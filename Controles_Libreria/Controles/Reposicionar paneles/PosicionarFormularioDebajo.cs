using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    using System.Drawing;
    using System.Windows.Forms;

    namespace Clases.Reposicon_paneles
    {
        public static class FormPositioner
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

