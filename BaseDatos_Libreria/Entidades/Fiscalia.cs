﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;



namespace BaseDatos.Entidades
{
    public class Fiscalia
    {
        public string NombreFiscalia { get; set; }
        public string AgenteFiscal { get; set; }
        public string Localidad { get; set; }
        public string DeptoJudicial { get; set; }
    }

    public static class FiscaliaManager
    {
        // Ruta del archivo en el directorio de salida bin
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fiscalias.json");

        // Ruta del archivo en el proyecto (para fines de desarrollo)
        private static readonly string filePathEntidades = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Ofelia_Sara\Base_de_Datos\Entidades\fiscalias.json");

        public static void GuardarFiscalias(List<Fiscalia> fiscalias)
        {
            // Configuración de formato para que el JSON esté indentado
            var options = new Newtonsoft.Json.JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            // Serialización de la lista usando JsonConvert.SerializeObject
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(fiscalias, options);

            // Guardar el JSON en un archivo
            File.WriteAllText(filePath, jsonString);
        }


        public static List<Fiscalia> CargarFiscalias()
        {
            if (!File.Exists(filePath))
            {
                return new List<Fiscalia>();
            }
            string jsonString = File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Fiscalia>>(jsonString);
        }



        public static void AgregarFiscalia(Fiscalia fiscalia)
        {
            var fiscalias = CargarFiscalias();
            fiscalias.Add(fiscalia);
            GuardarFiscalias(fiscalias);
        }

        public static List<Fiscalia> ObtenerFiscalias()
        {
            return CargarFiscalias();
        }

        public static Fiscalia ObtenerFiscaliaPorNombre(string nombreFiscalia)
        {
            var fiscalias = CargarFiscalias();
            return fiscalias.FirstOrDefault(f => f.NombreFiscalia == nombreFiscalia);
        }

        public static List<string> ObtenerNombresFiscalias()
        {
            var fiscalias = CargarFiscalias();
            return fiscalias.Select(f => f.NombreFiscalia).Distinct().ToList();
        }

        public static List<string> ObtenerAgentesFiscales()
        {
            var fiscalias = CargarFiscalias();
            return fiscalias.Select(f => f.AgenteFiscal).Distinct().ToList();
        }

        public static List<string> ObtenerLocalidades()
        {
            var fiscalias = CargarFiscalias();
            return fiscalias.Select(f => f.Localidad).Distinct().ToList();
        }

        public static List<string> ObtenerDeptosJudiciales()
        {
            var fiscalias = CargarFiscalias();
            return fiscalias.Select(f => f.DeptoJudicial).Distinct().ToList();
        }

       
    }

}
