using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.Redactador
{



    public class PictureBoxCircular : PictureBox
    {
        private Color hoverColor = Color.LightSkyBlue;  // Color cuando el mouse pasa por encima
        private Color clickColor = Color.LightSeaGreen; // Color cuando se hace clic
        private Color originalColor = Color.Transparent; // Color original del fondo
        private bool isMouseOver = false;
        private bool isMouseDown = false;

        public PictureBoxCircular()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;  // Ajusta la imagen al tamaño del PictureBox
            BackColor = originalColor;  // Fondo inicial transparente
            Cursor = Cursors.Hand;  // Cambio de cursor para simular interactividad

            // Configura los eventos
            MouseEnter += PictureBoxCircular_MouseEnter;
            MouseLeave += PictureBoxCircular_MouseLeave;
            MouseDown += PictureBoxCircular_MouseDown;
            MouseUp += PictureBoxCircular_MouseUp;
        }

        // Maneja el evento cuando el mouse entra en el área del PictureBox
        private void PictureBoxCircular_MouseEnter(object sender, EventArgs e)
        {
            isMouseOver = true;

            Invalidate();  // Redibujar el PictureBox
        }

        // Maneja el evento cuando el mouse sale del área del PictureBox
        private void PictureBoxCircular_MouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            isMouseDown = false;
            Invalidate();  // Redibujar el PictureBox
        }

        // Maneja el evento cuando el mouse hace clic
        private void PictureBoxCircular_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            Invalidate();  // Redibujar el PictureBox
        }

        // Maneja el evento cuando el mouse deja de hacer clic
        private void PictureBoxCircular_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Invalidate();  // Redibujar el PictureBox
        }

        // Dibujar el PictureBox con el color de fondo correspondiente
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Establecer el color de fondo dependiendo de los eventos
            Color fillColor = originalColor;

            if (isMouseDown)
            {
                fillColor = clickColor;
            }
            else if (isMouseOver)
            {
                fillColor = hoverColor;
            }

            // Dibujar el círculo con el color de fondo
            using (Brush brush = new SolidBrush(fillColor))
            {
                g.FillEllipse(brush, 0, 0, Width - 3, Height - 3);
            }

            // Dibujar la imagen en el centro
            if (Image != null)
            {
                int imageX = (Width - Image.Width) / 2;
                int imageY = (Height - Image.Height) / 2;
                g.DrawImage(Image, imageX, imageY, Image.Width, Image.Height);
            }

            // Dibujar el borde circular
            //using (Pen pen = new Pen(Color.Transparent, 0))  // Ajusta el color del borde según sea necesario
            //{
            //    g.DrawEllipse(pen, 0, 0, this.Width -2, this.Height - 2);
            //}
        }
    }
}