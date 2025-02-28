using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Apariencia
{
    public class PosicionarBordeSuPerior
    {
        /// <summary>
        /// Reposiciona un formulario centrado en X y a un 10% desde el borde superior de la pantalla.
        /// </summary>
        /// <param name="form">El formulario a reposicionar.</param>
        public static void PosicionarFormulario(Form form)
        {
            if (form == null) return;

            // Obtener el tamaño de la pantalla
            Screen screen = Screen.FromControl(form);
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;

            // Calcular la nueva posición
            int newX = (screenWidth - form.Width) / 2; // Centrar en X
            int newY = (int)(screenHeight * 0.1); // Ubicar a un 10% del borde superior

            // Asignar la nueva ubicación
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(newX, newY);
        }
    }
}