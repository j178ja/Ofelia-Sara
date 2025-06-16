/*  ejemplo de uso  Desplazamiento.AnimarDesplazamiento(label_Titulo, DireccionDesplazamiento.Izquierda);
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Animaciones
{


    public enum DireccionDesplazamiento
    {
        Izquierda,
        Derecha,
        Arriba,
        Abajo,
        Centro
    }


    public static class Desplazamiento
    {
        private static readonly Dictionary<Control, Timer> animacionesActivas = new();

        public static void AnimarDesplazamiento(
            Control control,
            DireccionDesplazamiento direccion,
            int distancia = 100,
            int duracion = 500,
            bool regresar = false,
            Action? alTerminar = null)
        {
            if (animacionesActivas.ContainsKey(control))
                return; // Ya hay una animación en curso para este control

            int pasos = 30;
            int intervalo = duracion / pasos;
            int pasoActual = 0;

            Point posicionInicial = control.Location;
            Point destino = CalcularDestino(posicionInicial, direccion, distancia,control);

            Timer timer = new() { Interval = intervalo };
            animacionesActivas[control] = timer;

            timer.Tick += (s, e) =>
            {
                pasoActual++;

                double progreso = (double)pasoActual / pasos;
                double easing = EaseOut(progreso);

                int nuevoX = (int)(posicionInicial.X + (destino.X - posicionInicial.X) * easing);
                int nuevoY = (int)(posicionInicial.Y + (destino.Y - posicionInicial.Y) * easing);

                control.Location = new Point(nuevoX, nuevoY);

                if (pasoActual >= pasos)
                {
                    timer.Stop();
                    animacionesActivas.Remove(control);
                    timer.Dispose();

                    if (regresar)
                    {
                        AnimarDesplazamiento(control, DireccionOpuesta(direccion), distancia, duracion, false, alTerminar);
                    }
                    else
                    {
                        alTerminar?.Invoke();
                    }
                }
            };

            timer.Start();
        }

        private static Point CalcularDestino(Point inicio, DireccionDesplazamiento direccion, int distancia, Control control)
        {
            if (direccion == DireccionDesplazamiento.Centro && control.Parent != null)
            {
                var parent = control.Parent;
                int destinoX = (parent.Width - control.Width) / 2;
                int destinoY = (parent.Height - control.Height) / 2;
                return new Point(destinoX, destinoY);
            }

            return direccion switch
            {
                DireccionDesplazamiento.Izquierda => new Point(inicio.X - distancia, inicio.Y),
                DireccionDesplazamiento.Derecha => new Point(inicio.X + distancia, inicio.Y),
                DireccionDesplazamiento.Arriba => new Point(inicio.X, inicio.Y - distancia),
                DireccionDesplazamiento.Abajo => new Point(inicio.X, inicio.Y + distancia),
                _ => inicio
            };
        }


        private static DireccionDesplazamiento DireccionOpuesta(DireccionDesplazamiento direccion)
        {
            return direccion switch
            {
                DireccionDesplazamiento.Izquierda => DireccionDesplazamiento.Derecha,
                DireccionDesplazamiento.Derecha => DireccionDesplazamiento.Izquierda,
                DireccionDesplazamiento.Arriba => DireccionDesplazamiento.Abajo,
                DireccionDesplazamiento.Abajo => DireccionDesplazamiento.Arriba,
                _ => direccion
            };
        }

        // Curva de desaceleración (ease-out)
        private static double EaseOut(double t)
        {
            return 1 - Math.Pow(1 - t, 3); // cúbica suave
        }
    }
}