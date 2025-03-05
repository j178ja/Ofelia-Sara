using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;

/// <summary>
/// para cargar el listado de acciones a list de combobox
/// </summary>
public class AccionesManager
{
    public List<string> Acciones { get; private set; }

    public AccionesManager(string filePath)
    {
        LoadActions(filePath);
    }

    private void LoadActions(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            Acciones = JsonConvert.DeserializeObject<List<string>>(json);
            // Ordenar la lista de acciones
            Acciones = Acciones.OrderBy(a => a).ToList();
        }
        else
        {
            Acciones = new List<string>();
        }
    }
}

