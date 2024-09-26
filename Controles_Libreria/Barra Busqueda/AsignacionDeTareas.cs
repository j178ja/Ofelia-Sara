using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles_Libreria.Barra_Busqueda
{
    using System;
    using System.Collections.Generic;

        public class TareasManager
        {
            // Lista interna de tareas
            private List<string> tareas;

            public TareasManager()
            {
                // Inicializa la lista de tareas
                tareas = new List<string>();

                // Llenar la lista con algunas tareas predeterminadas (puedes agregar más o cargarlas desde otra fuente)
             
                /*----se eliminaron todas las taresa hay que vincular el listado
                
                de tareas al listado json ------*/
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
