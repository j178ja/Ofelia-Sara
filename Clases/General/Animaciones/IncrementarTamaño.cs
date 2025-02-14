

// se lo utiliza-- IncrementarTamaño.Incrementar(btn_xxx);

using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/// <summary>
/// ESTA CLASE ES UNA CLASE GENERICAR QUE PERMITE INCREMENTAR EL TAMAÑO DE BOTONES E IMAGENES,SIN PERDER EL POSICIONAMIENTO
/// </summary>
public static class IncrementarTamaño
{
    public static void Incrementar(System.Windows.Forms.Button boton)
    {
        IncrementarTamañoInterno(boton, 5); // Ajusta el valor 3 para cambiar el incremento
    }

    public static void Incrementar(System.Windows.Forms.PictureBox pictureBox)
    {
        IncrementarTamañoInterno(pictureBox, 5); // Ajusta el valor 3 para cambiar el incremento
    }

    private static void IncrementarTamañoInterno(Control control, int incrementValue)
    {
        Size originalSize = control.Size;
        Point originalLocation = control.Location;
        Image originalImage = control.BackgroundImage;
        Color originalBackColor = control.BackColor;

        // Evento MouseEnter: Inicia la animación de cambio de tamaño
        control.MouseEnter += (sender, e) =>
        {
            // Inicia el cambio de tamaño
            ResizeControl(control, originalSize, originalLocation, originalImage, originalBackColor, incrementValue, 10, true);
        };

        // Evento MouseLeave: Inicia la reversa de la animación de cambio de tamaño
        control.MouseLeave += (sender, e) =>
        {
            // Restaura el tamaño
            ResizeControl(control, originalSize, originalLocation, originalImage, originalBackColor, incrementValue, 10, false);
        };

        void ResizeControl(Control ctrl, Size origSize, Point origLocation, Image origImage, Color origBackColor, int incrementValueInner, int interval, bool expanding)
        {
            Timer timer = new Timer();
            int currentIncrement = 0;
            timer.Interval = interval;
            timer.Tick += (sender, e) =>
            {
                if (expanding)
                {
                    if (currentIncrement < incrementValueInner)
                    {
                        currentIncrement += 1; // Ajusta este valor para controlar la velocidad de expansión
                        UpdateControlSize(ctrl, origSize, origLocation, origImage, currentIncrement);
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
                else
                {
                    if (currentIncrement > 0)
                    {
                        currentIncrement -= 1; // Ajusta este valor para controlar la velocidad de reducción
                        UpdateControlSize(ctrl, origSize, origLocation, origImage, currentIncrement);
                    }
                    else
                    {
                        timer.Stop();
                        // Restaura el tamaño original y la imagen
                        ctrl.Size = origSize;
                        ctrl.Location = origLocation;
                        ctrl.BackgroundImage = origImage;
                        ctrl.BackColor = origBackColor; // Restaura el color de fondo original
                    }
                }
            };
            timer.Start();
        }

        void UpdateControlSize(Control ctrl, Size origSize, Point origLocation, Image origImage, int incremento)
        {
            int nuevoAncho = origSize.Width + incremento;
            int nuevoAlto = origSize.Height + incremento;
            int deltaX = (nuevoAncho - origSize.Width) / 2;
            int deltaY = (nuevoAlto - origSize.Height) / 2;

            ctrl.Size = new Size(nuevoAncho, nuevoAlto);
            ctrl.Location = new Point(origLocation.X - deltaX, origLocation.Y - deltaY);

            if (origImage != null)
            {
                // Cambia el tamaño de la imagen para que coincida con el tamaño del control
                ctrl.BackgroundImage = new Bitmap(origImage, ctrl.Size);
            }
        }
    }
}



