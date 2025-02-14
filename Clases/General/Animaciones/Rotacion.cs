using System;
using System.Drawing;
using System.Windows.Forms;



namespace Ofelia_Sara.Clases.General.Animaciones
{
    /// <summary>
    /// Aplica efecto de rotacion a imagen de engranaje
    /// </summary>
    public static class Rotacion
    {
        public static void Aplicar(Button boton, Image imagenAnimada, Image imagenOriginal, int intervalo = 20)
        {
            Timer rotationTimer = new Timer { Interval = intervalo };
            float angle = 0;
            bool isMouseOver = false; // Bandera para evitar superposición de eventos

            // Evento MouseEnter: Comienza la rotación (un cuarto de vuelta a la izquierda)
            boton.MouseEnter += (s, e) =>
            {
                if (!isMouseOver)
                {
                    isMouseOver = true;
                    angle = 0; // Resetear ángulo al entrar
                    rotationTimer.Tick += RotarIzquierda; // Asociar evento
                    rotationTimer.Start();
                }
            };

            // Evento MouseLeave: Realiza una vuelta completa hacia la derecha
            boton.MouseLeave += (s, e) =>
            {
                isMouseOver = false; // Permitir nueva interacción
                angle = 0; // Resetear ángulo
                rotationTimer.Tick -= RotarIzquierda; // Desasociar evento previo
                rotationTimer.Tick += RotarDerecha; // Asociar nuevo evento
                rotationTimer.Start();
            };

            // Rotación de un cuarto de vuelta hacia la izquierda
            void RotarIzquierda(object sender, EventArgs args)
            {
                angle -= 10; // Reducir ángulo en pequeños pasos
                boton.BackgroundImage = RotarImagen(imagenAnimada, angle);

                if (angle <= -90)
                {
                    rotationTimer.Stop();
                    rotationTimer.Tick -= RotarIzquierda; // Desasociar evento
                    boton.BackgroundImage = imagenOriginal; // Restaurar imagen original
                }
            }

            // Rotación completa hacia la derecha
            void RotarDerecha(object sender, EventArgs args)
            {
                angle += 10; // Incrementar ángulo en pequeños pasos
                boton.BackgroundImage = RotarImagen(imagenAnimada, angle);

                if (angle >= 360)
                {
                    rotationTimer.Stop();
                    rotationTimer.Tick -= RotarDerecha; // Desasociar evento
                    boton.BackgroundImage = imagenOriginal; // Restaurar imagen original
                }
            }
        }

        /// <summary>
        /// para rotar la imagen
        /// </summary>
        /// <param name="imagen"></param>
        /// <param name="angulo"></param>
        /// <returns></returns>
        private static Image RotarImagen(Image imagen, float angulo)
        {
            Bitmap bmp = new Bitmap(imagen.Width, imagen.Height);
            bmp.SetResolution(imagen.HorizontalResolution, imagen.VerticalResolution); // Mantener calidad
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform(imagen.Width / 2, imagen.Height / 2);
                g.RotateTransform(angulo);
                g.TranslateTransform(-imagen.Width / 2, -imagen.Height / 2);
                g.DrawImage(imagen, new Point(0, 0));
            }
            return bmp;
        }
    }
}
