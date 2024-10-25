using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseDatos.Entidades
{
    public class Secretario
    {
            public float NumeroLegajo { get; set; }
            public string Escalafon { get; set; }
            public string Jerarquia { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Dependencia { get; set; }
            public string Funcion { get; set; }
        // public string FirmaDigitalizada { get; set; } // Se almacenará como una cadena en base64

        // Propiedad calculada para mostrar Jerarquia, Nombre y Apellido juntos
        public string DescripcionCompleta => $"{Jerarquia} {Nombre} {Apellido}";
    }

    public static class SecretarioManager
    {
        private static readonly string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Ofelia_Sara\Base_de_Datos\Entidades");
        private static readonly string filePath = Path.Combine(folderPath, "secretarios.json");

        static SecretarioManager()
        {
            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static void GuardarSecretarios(List<Secretario> secretarios)
        {
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(secretarios, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Secretario> CargarSecretarios()
        {
            if (!File.Exists(filePath))
            {
                return new List<Secretario>();
            }

            string jsonString = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<Secretario>>(jsonString);
        }

        public static void AgregarSecretario(Secretario secretario)
        {
            var secretarios = CargarSecretarios();
            secretarios.Add(secretario);
            GuardarSecretarios(secretarios);
        }

        public static List<Secretario> ObtenerSecretarios()
        {
            return CargarSecretarios();
        }

        public static Secretario ObtenerSecretarioPorNumeroLegajo(float numeroLegajo)
        {
            var secretarios = CargarSecretarios();
            return secretarios.FirstOrDefault(s => s.NumeroLegajo == numeroLegajo);
        }
    }


}

