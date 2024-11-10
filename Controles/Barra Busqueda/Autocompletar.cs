using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class AutocompletarManager
{
    private readonly string filePath;

    public AutocompletarManager(string filePath)
    {
        this.filePath = filePath;
    }

    public void ConfigureTextBoxAutoComplete(TextBox textBox)
    {
        var autoCompleteCollection = new AutoCompleteStringCollection();

        // Cargar elementos para autocompletado
        string[] autoCompleteItems = LoadAutoCompleteItems();

        // Agregar los elementos cargados a la colección de autocompletado
        autoCompleteCollection.AddRange(autoCompleteItems);

        // Configurar el TextBox para usar autocompletado
        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        textBox.AutoCompleteCustomSource = autoCompleteCollection;

        // Mensaje de depuración para verificar el funcionamiento
        MessageBox.Show($"Autocompletado configurado para {textBox.Name}. Elementos: {string.Join(", ", autoCompleteItems)}");
    }

    private string[] LoadAutoCompleteItems()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var items = JsonConvert.DeserializeObject<List<string>>(json);
            return items.ToArray();
        }
        else
        {
            // Retorna una lista vacía si el archivo no existe
            return new string[] { };
        }
    }
}


