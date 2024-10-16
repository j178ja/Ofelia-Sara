//clase para hacer que el caracter tenga un recuadro

//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MECANOGRAFIA.Clases
//{
//    public class Texto_TipearPersonalizado : RichTextBox


//    {
//        public int CaracterResaltadoIndex { get; set; } = -1;

//        // Sobrescribe el evento OnPaint para dibujar el rectángulo
//        protected override void OnPaint(PaintEventArgs e)
//        {
//            base.OnPaint(e);

//            if (CaracterResaltadoIndex >= 0)
//            {
//                // Obtén el rectángulo de la posición del carácter resaltado
//                Rectangle rect = GetRectFromCharacterIndex(CaracterResaltadoIndex);
//                rect.Inflate(2, 2); // Ajusta el tamaño del rectángulo

//                // Dibuja un rectángulo alrededor del carácter
//                using (Pen pen = new Pen(Color.Red, 2)) // Puedes cambiar el color y el grosor
//                {
//                    e.Graphics.DrawRectangle(pen, rect);
//                }
//            }
//        }
//    }
//}