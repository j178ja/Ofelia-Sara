using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

using System.Threading.Tasks;


namespace BaseDatos.Entidades
{
    public class DependenciasPoliciales
    {
        public string Dependencia { get; set; }
        public string Domicilio { get; set; }
    }

    public static class DependenciaManager
    {
        private static readonly string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Ofelia_Sara\Base_de_Datos\Entidades");
        private static readonly string filePath = Path.Combine(folderPath, "dependencias.json");

        static DependenciaManager()
        {
            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static void GuardarDependencias(List<DependenciasPoliciales> dependencias)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(dependencias, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<DependenciasPoliciales> CargarDependencias()
        {
            if (!File.Exists(filePath))
            {
                return new List<DependenciasPoliciales>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<DependenciasPoliciales>>(jsonString);
        }

        public static void AgregarDependencia(DependenciasPoliciales dependencia)
        {
            var dependencias = CargarDependencias();
            dependencias.Add(dependencia);
            GuardarDependencias(dependencias);
        }

        public static List<DependenciasPoliciales> ObtenerDependencias()
        {
            return CargarDependencias();
        }
    }
}
