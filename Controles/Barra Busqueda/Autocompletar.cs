using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Clases.General.Texto;

public class AutocompletarManager
{
    private readonly string filePath;
    private readonly Dictionary<Control, AutoCompleteStringCollection> autoCompleteCollections = new();

    public AutocompletarManager(string filePath)
    {
        this.filePath = filePath;
    }

    public void ConfigureAutoComplete(Control control)
    {
        if (control is CustomTextBox customTextBox)
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            var autoCompleteItems = LoadCombinedAutoCompleteItems(customTextBox.Name);

            autoCompleteCollection.AddRange(autoCompleteItems);

            customTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customTextBox.AutoCompleteCustomSource = autoCompleteCollection;

            autoCompleteCollections[customTextBox] = autoCompleteCollection;

            // Manejo de evento para actualizar autocompletado al perder foco
            customTextBox.Leave -= TextBox_Leave;
            customTextBox.Leave += TextBox_Leave;

            // Manejo de evento para actualizar sugerencias dinámicamente mientras el usuario escribe
            customTextBox.KeyUp -= TextBox_KeyUp;
            customTextBox.KeyUp += TextBox_KeyUp;
        }
    }

    /// <summary>
    /// Filtra dinámicamente las sugerencias según la tecla presionada por el usuario.
    /// </summary>
    private void TextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (sender is CustomTextBox customTextBox)
        {
            var autoCompleteItems = LoadCombinedAutoCompleteItems(customTextBox.Name).ToList();

            // Filtrar las sugerencias que empiezan con el texto ingresado
            var filteredItems = autoCompleteItems
                .Where(item => item.StartsWith(customTextBox.TextValue, StringComparison.OrdinalIgnoreCase))
                .ToArray();

            // Actualizar la lista de autocompletado
            if (autoCompleteCollections.ContainsKey(customTextBox))
            {
                autoCompleteCollections[customTextBox].Clear();
                autoCompleteCollections[customTextBox].AddRange(filteredItems);
            }
        }
    }

    /// <summary>
    /// Agrega el texto ingresado tras perder el foco, manteniendo persistencia en JSON.
    /// </summary>
    private void TextBox_Leave(object sender, EventArgs e)
    {
        if (sender is CustomTextBox customTextBox && !string.IsNullOrWhiteSpace(customTextBox.TextValue))
        {
            var autoCompleteItems = LoadAutoCompleteItems().ToList();

            // Agregar nuevo valor y mantener solo los últimos 100
            autoCompleteItems.Remove(customTextBox.TextValue);
            autoCompleteItems.Insert(0, customTextBox.TextValue);
            autoCompleteItems = autoCompleteItems.Take(100).ToList();

            SaveAutoCompleteItems(autoCompleteItems.ToArray());

            if (autoCompleteCollections.ContainsKey(customTextBox))
            {
                autoCompleteCollections[customTextBox].Clear();
                autoCompleteCollections[customTextBox].AddRange(autoCompleteItems.ToArray());
            }
        }
    }

    /// <summary>
    /// Carga las sugerencias combinadas: Prioriza las sugerencias de `AutocompletarCaratula` si el TextBox se llama `textBox_Caratula`.
    /// </summary>
    private string[] LoadCombinedAutoCompleteItems(string textBoxName)
    {
        var autoCompleteItems = LoadAutoCompleteItems().ToList();

        if (textBoxName == "textBox_Caratula")
        {
            var sugerenciasCaratula = AutocompletarCaratula.LeerSugerenciasDesdeJson(filePath);
            autoCompleteItems = sugerenciasCaratula.Concat(autoCompleteItems).Distinct().ToList();
        }

        return autoCompleteItems.ToArray();
    }

    /// <summary>
    /// Carga los últimos 100 ingresos desde el archivo JSON.
    /// </summary>
    private string[] LoadAutoCompleteItems()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<string>>(json)?.ToArray() ?? new string[] { };
        }
        return new string[] { };
    }

    /// <summary>
    /// Guarda los últimos 100 ingresos en el archivo JSON, manteniendo la persistencia.
    /// </summary>
    private void SaveAutoCompleteItems(string[] items)
    {
        File.WriteAllText(filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
    }
}




