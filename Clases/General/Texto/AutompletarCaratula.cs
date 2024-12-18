using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Ofelia_Sara.Clases.General.Texto
{
    public class AutocompletarCaratula
    {
        // Propiedad que contendrá la lista de sugerencias
        public List<string> Sugerencias_Caratula { get; set; }

        // Método para leer las sugerencias desde el archivo JSON
        public static List<string> LeerSugerenciasDesdeJson(string rutaJson)
        {
            if (File.Exists(rutaJson))
            {
                // Leer el contenido del archivo JSON
                string jsonContent = File.ReadAllText(rutaJson);

                // Deserializar el contenido del JSON en un objeto
                var data = JsonConvert.DeserializeObject<AutocompletarCaratula>(jsonContent);

                // Devolver la lista de sugerencias si existe, o una lista vacía
                return data?.Sugerencias_Caratula ?? new List<string>();
            }
            else
            {
                // Si el archivo no existe, se devuelve una lista de nombres de flores
                return new List<string> { "Rosa", "Tulipán", "Margarita", "Girasol", "Lirio", "Orquídea", "Lavanda" };
            }
        }
    }
}
