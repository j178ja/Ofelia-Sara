using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ofelia_Sara.Base_de_Datos.Entidades
{
   public class Instructor
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
    public static class InstructorManager
    {
        private static readonly string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Ofelia_Sara\Base_de_Datos\Entidades");
        private static readonly string filePath = Path.Combine(folderPath, "instructor.json");

        static InstructorManager()
        {
            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static void GuardarInstructores(List<Instructor> instructores)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(instructores, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Instructor> CargarInstructores()
        {
            if (!File.Exists(filePath))
            {
                return new List<Instructor>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Instructor>>(jsonString);
        }

        public static void AgregarInstructor(Instructor instructor)
        {
            var instructores = CargarInstructores();
            instructores.Add(instructor);
            GuardarInstructores(instructores);
        }

        public static List<Instructor> ObtenerInstructores()
        {
            return CargarInstructores();
        }

        public static Instructor ObtenerInstructorPorNumeroLegajo(float numeroLegajo)
        {
            var instructores = CargarInstructores();
            return instructores.FirstOrDefault(i => i.NumeroLegajo == numeroLegajo);
        }
    }
}