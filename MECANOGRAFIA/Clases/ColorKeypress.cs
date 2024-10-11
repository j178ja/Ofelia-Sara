using System;
using System.Windows.Forms;

namespace MECANOGRAFIA.Clases
{
    public class ColorChanger
    {
        // Método para manejar el cambio de color del panel
        public void ChangePanelColor(Keys key, Panel targetPanel)
        {
            // Verificar si la tecla es una de las especificadas
            if (key == Keys.Q || key == Keys.W || key == Keys.A ||
                key == Keys.S || key == Keys.Z || key == Keys.X)
            {
                // Cambiar el color del panel a naranja
                targetPanel.BackColor = System.Drawing.Color.Orange;
            }
        }
    }
}
