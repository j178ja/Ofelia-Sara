
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.Mecanografia
{
    /// <summary>
    /// para hacer que el caracter tenga un recuadro
    /// </summary>
    public class Texto_TipearPersonalizado : RichTextBox


    {
        public int CaracterResaltadoIndex { get; set; } = -1;

        /// <summary>
        /// Sobrescribe el evento OnPaint para dibujar el rectángulo
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (CaracterResaltadoIndex >= 0)
            {
              //  // Obtén el rectángulo de la posición del carácter resaltado
              ////  Rectangle rect = GetRectFromCharacterIndex(CaracterResaltadoIndex);
              //  rect.Inflate(2, 2); // Ajusta el tamaño del rectángulo

              //  // Dibuja un rectángulo alrededor del carácter
              //  using Pen pen = new(Color.Red, 2); // Puedes cambiar el color y el grosor
              //  e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}