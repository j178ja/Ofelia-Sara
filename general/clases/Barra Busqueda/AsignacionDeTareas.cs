using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.general.clases.Barra_Busqueda
{
    using System;
    using System.Collections.Generic;

    namespace Ofelia_Sara
    {
        public class TareasManager
        {
            // Lista interna de tareas
            private List<string> tareas;

            public TareasManager()
            {
                // Inicializa la lista de tareas
                tareas = new List<string>();

                // Llenar la lista con algunas tareas predeterminadas (puedes agregar más o cargarlas desde otra fuente)
                tareas.Add("Notificacion Art. 60 C.P.P.");
                tareas.Add("Legajo AUTOMOVIL");
                tareas.Add("Legajo MOTOVEHICULO");
                tareas.Add("Legajo de Detenidos");
                tareas.Add("Cargo de elementos");
                tareas.Add("Cadena de custodia de elementos en Gral");
                tareas.Add("Cargo de custodia 'Sangre'");
                tareas.Add("Cargo de custodia telefonos celulares");
                tareas.Add("Contravenciones");
                tareas.Add("Notas");
                tareas.Add("Nota stud. camaras");
                tareas.Add("Notas stud colaboración GTO");
                tareas.Add("Notas stud colaboración DDI");
                tareas.Add("I.P.P Completa");
                tareas.Add("Inicio, cierre y elevación");
                tareas.Add("Decreto de inicio");
                tareas.Add("Plana");
                tareas.Add("Informe");
            }

            // Método para obtener todas las tareas
            public List<string> ObtenerTareas()
            {
                return tareas;
            }

            // Método para agregar una tarea a la lista
            public void AgregarTarea(string tarea)
            {
                if (!tareas.Contains(tarea))
                {
                    tareas.Add(tarea);
                }
            }

            // Método para filtrar tareas basadas en un texto de búsqueda
            public List<string> FiltrarTareas(string filtro)
            {
                return tareas.FindAll(t => t.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }
    }
}