using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccionesManager
{
    public List<string> Acciones { get; private set; }

    public AccionesManager(string filePath)
    {
        // Leer el archivo JSON y deserializarlo
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var accionesData = JsonSerializer.Deserialize<AccionesData>(json);
            Acciones = accionesData?.acciones ?? new List<string>();
        }
        else
        {
            Acciones = new List<string>();
        }
    }

    private class AccionesData
    {
        public List<string> acciones { get; set; }
    }
}
