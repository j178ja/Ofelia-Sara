using System;
using System.Collections.Generic;
using System.Linq;
/*EJEMPLO DE USO
 // Aplicar estilo
EstiloControles.AplicarEstiloRadioButton(radioButton_Acta);

// Restaurar estilos
EstiloControles.RestaurarEstiloPictureBox(pictureBox_Acta, pictureBox_Denuncia);*/


using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ofelia_Sara.Clases.General.Apariencia
{
    public static class EstiloRadiobuttom
    {
        private static readonly Color ColorSeleccionado = Color.FromArgb(4, 234, 0);
        private static readonly Color ColorNoSeleccionado = Color.FromArgb(178, 213, 230);
        private static readonly Color ColorFondoRadio = Color.FromArgb(228, 247, 222);

        public static void AplicarEstiloRadioButton(RadioButton radioButton)
        {
            var customFont = new Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Bold);
            radioButton.Font = customFont;
            radioButton.ForeColor = SystemColors.HotTrack;
            radioButton.BackColor = ColorFondoRadio;
            radioButton.Invalidate();
        }

        public static void RestaurarEstiloPictureBox(params PictureBox[] pictureBoxes)
        {
            foreach (var pictureBox in pictureBoxes)
                pictureBox.BackColor = ColorNoSeleccionado;
        }

        /// <summary>
        /// Aplica el estilo visual completo cuando un RadioButton es seleccionado,
        /// incluyendo su PictureBox y restaurando el otro.
        /// </summary>
        public static void AplicarEstiloSeleccionRadioButton(
            RadioButton seleccionado,
            RadioButton radioActa,
            RadioButton radioDenuncia,
            PictureBox pictureActa,
            PictureBox pictureDenuncia)
        {
            AplicarEstiloRadioButton(seleccionado);

            if (seleccionado == radioActa)
            {
                RestaurarEstiloPictureBox(pictureDenuncia);
                AplicarEstiloVisual(pictureActa, seleccionado);
            }
            else if (seleccionado == radioDenuncia)
            {
                RestaurarEstiloPictureBox(pictureActa);
                AplicarEstiloVisual(pictureDenuncia, seleccionado);
            }
        }

        private static void AplicarEstiloVisual(PictureBox picture, RadioButton radio)
        {
            RedondearBordes.Aplicar(picture, 6, true, false, false, true);
            picture.BackColor = ColorSeleccionado;
            RedondearBordes.Aplicar(radio, 6, false, true, true, false);
        }
    }
}
