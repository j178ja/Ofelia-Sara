using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
                string jsonContent = File.ReadAllText(rutaJson);

                try
                {
                    var listaSugerencias = JsonConvert.DeserializeObject<List<string>>(jsonContent);
                    return listaSugerencias ?? new List<string>();
                }
                catch (JsonSerializationException ex)
                {
                    MessageBox.Show("Error al deserializar las sugerencias de Carátula. Se usará la lista por defecto.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return new List<string> { "ROBO", "HURTO", "DESOBEDIENCIA", "ESTAFA", "AVERIGUACION DE ILICITO" }; //ABRA QUE AGREGRA MAS CUANDO SE PASE A BD
                }
            }
            else
            {
                return new List<string> { "ROBO", "HURTO", "DESOBEDIENCIA", "ESTAFA", "AVERIGUACION DE ILICITO" };
            }
        }

    }
}
