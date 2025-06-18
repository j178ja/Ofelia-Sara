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

    
        // ENUM por fuera de la clase principal
        public enum DireccionDesplazamiento
        {
            Izquierda,
            Derecha,
            Arriba,
            Abajo,
            Centro,
            DesdeIzquierdaAlCentroX,
            DesdeDerechaAlCentroX
        }

        public static class Desplazar
        {
            private static Dictionary<Control, Timer> animacionesActivas = new();

            private static double EaseOut(double t)
            {
                return 1 - Math.Pow(1 - t, 3);
            }

            public static void DesplazamientoDesde(Control control, DireccionDesplazamiento direccion, int distancia = 100, int duracion = 500, Action? alTerminar = null)
            {
                if (animacionesActivas.ContainsKey(control))
                    return;

                int pasos = 30;
                int intervalo = duracion / pasos;
                int pasoActual = 0;

                Point posicionFinal = control.Location;

                if (direccion == DireccionDesplazamiento.DesdeIzquierdaAlCentroX || direccion == DireccionDesplazamiento.DesdeDerechaAlCentroX)
                {
                    if (control.Parent != null)
                    {
                        int centroX = CalcularCentroX(control);
                        posicionFinal = new Point(centroX, control.Location.Y);
                    }
                }

                Point posicionInicial = direccion switch
                {
                    DireccionDesplazamiento.Izquierda => new Point(posicionFinal.X - distancia, posicionFinal.Y),
                    DireccionDesplazamiento.Derecha => new Point(posicionFinal.X + distancia, posicionFinal.Y),
                    DireccionDesplazamiento.Arriba => new Point(posicionFinal.X, posicionFinal.Y - distancia),
                    DireccionDesplazamiento.Abajo => new Point(posicionFinal.X, posicionFinal.Y + distancia),
                    DireccionDesplazamiento.DesdeIzquierdaAlCentroX => new Point(-control.Width, posicionFinal.Y),
                    DireccionDesplazamiento.DesdeDerechaAlCentroX => new Point(
                        control.Parent?.Width ?? (posicionFinal.X + distancia + control.Width),
                        posicionFinal.Y
                    ),
                    DireccionDesplazamiento.Centro => CalcularDestino(posicionFinal, direccion, distancia, control),
                    _ => posicionFinal
                };

                control.Location = posicionInicial;

                Timer timer = new() { Interval = intervalo };
                animacionesActivas[control] = timer;

                timer.Tick += (s, e) =>
                {
                    pasoActual++;
                    double progreso = (double)pasoActual / pasos;
                    double easing = EaseOut(progreso);

                    int nuevoX = (int)(posicionInicial.X + (posicionFinal.X - posicionInicial.X) * easing);
                    int nuevoY = (int)(posicionInicial.Y + (posicionFinal.Y - posicionInicial.Y) * easing);
                    control.Location = new Point(nuevoX, nuevoY);

                    if (pasoActual >= pasos)
                    {
                        control.Location = posicionFinal;
                        timer.Stop();
                        timer.Dispose();
                        animacionesActivas.Remove(control);
                        alTerminar?.Invoke();
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

                return inicio;
            }

            private static int CalcularCentroX(Control control)
            {
                if (control.Parent != null)
                {
               // int ajusteManual = -45; //se recurrio a esto ya que ante al usar desplazamiento no quedaba centrado pese al calculo
                return (control.Parent.ClientSize.Width - control.Width) / 2 /*+ ajusteManual*/;

            }
            return control.Location.X;
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
        }
    }



