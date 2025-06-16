using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Animaciones
{
    public static class Animador
    {
        // Campo para manejar animaciones activas
        private static Dictionary<Control, Timer> animacionesActivas = new();

        // Función de interpolación (puede ser EaseOut, EaseInOut, etc.)
        private static double EaseOut(double t)
        {
            // Suavizado tipo "desaceleración"
            return 1 - Math.Pow(1 - t, 3);
        }

        // Método de crecimiento en eje X
        public static void CrecimientoX(Control control, int anchoInicial = 0, int duracion = 500, Action? alTerminar = null)
        {
            if (animacionesActivas.ContainsKey(control))
                return;

            int pasos = 30;
            int intervalo = duracion / pasos;
            int pasoActual = 0;

            int anchoFinal = control.Width;
            control.Width = anchoInicial;

            Timer timer = new() { Interval = intervalo };
            animacionesActivas[control] = timer;

            timer.Tick += (s, e) =>
            {
                pasoActual++;
                double progreso = (double)pasoActual / pasos;
                double easing = EaseOut(progreso);

                int nuevoAncho = (int)(anchoInicial + (anchoFinal - anchoInicial) * easing);
                control.Width = nuevoAncho;

                if (pasoActual >= pasos)
                {
                    control.Width = anchoFinal;
                    timer.Stop();
                    timer.Dispose();
                    animacionesActivas.Remove(control);
                    alTerminar?.Invoke();
                }
            };

            timer.Start();
        }
    }
}
