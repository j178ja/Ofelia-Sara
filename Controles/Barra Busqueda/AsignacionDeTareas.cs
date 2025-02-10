using System;
using System.Collections.Generic;

namespace Ofelia_Sara.Controles.Barra_Busqueda
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

            /*----se eliminaron todas las taresa hay que vincular el listado

            de tareas al listado json ------*/
        }

        
        /// <summary>
        /// Método para obtener todas las tareas
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerTareas()
        {
            return tareas;
        }

        
        /// <summary>
        /// Método para agregar una tarea a la lista
        /// </summary>
        /// <param name="tarea"></param>
        public void AgregarTarea(string tarea)
        {
            if (!tareas.Contains(tarea))
            {
                tareas.Add(tarea);
            }
        }

        
        /// <summary>
        /// Método para filtrar tareas basadas en un texto de búsqueda
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<string> FiltrarTareas(string filtro)
        {
            return tareas.FindAll(t => t.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
