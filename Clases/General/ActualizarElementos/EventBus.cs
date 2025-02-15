using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.Clases.General.ActualizarElementos
{
    public static class EventBus
    {
        private static readonly Dictionary<string, Action<object>> eventos = [];

        public static void Suscribirse(string evento, Action<object> accion)
        {
            if (!eventos.ContainsKey(evento))
                eventos[evento] = accion;
            else
                eventos[evento] += accion;
        }

        public static void Publicar(string evento, object datos)
        {
            if (eventos.ContainsKey(evento))
                eventos[evento].Invoke(datos);
        }

        public static void Desuscribirse(string evento, Action<object> accion)
        {
            if (eventos.ContainsKey(evento))
                eventos[evento] -= accion;
        }
    }
}