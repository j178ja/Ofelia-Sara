using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Ofelia_Sara.Controles.General;

public class Autocompletar
{
    private readonly string filePath;
    private readonly Dictionary<Control, AutoCompleteStringCollection> autoCompleteCollections = new();

    public Autocompletar(string filePath)
    {
        this.filePath = filePath;
    }

    /// <summary>
    /// Configura el autocompletado para un control específico.
    /// </summary>
    public void ConfigureAutoComplete(Control control)
    {
        if (control is CustomTextBox customTextBox || control is CustomComboBox customComboBox)
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            var autoCompleteItems = LoadCombinedAutoCompleteItems(control.Name);

            autoCompleteCollection.AddRange(autoCompleteItems);

            if (control is CustomTextBox textBox)
            {
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
            else if (control is CustomComboBox comboBox)
            {
              //  comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.Items.Clear();
                comboBox.Items.AddRange(autoCompleteItems);
            }

            autoCompleteCollections[control] = autoCompleteCollection;

            // Asignar eventos
            control.Leave -= Control_Leave;
            control.Leave += Control_Leave;

            if (control is CustomTextBox)
            {
                control.KeyUp -= Control_KeyUp;
                control.KeyUp += Control_KeyUp;
            }
        }
    }

    /// <summary>
    /// Filtra dinámicamente las sugerencias según el texto ingresado.
    /// </summary>
    private void Control_KeyUp(object sender, KeyEventArgs e)
    {
        if (sender is CustomTextBox customTextBox && autoCompleteCollections.ContainsKey(customTextBox))
        {
            var autoCompleteItems = LoadCombinedAutoCompleteItems(customTextBox.Name).ToList();
            var filteredItems = autoCompleteItems
                .Where(item => item.StartsWith(customTextBox.TextValue, StringComparison.OrdinalIgnoreCase))
                .ToArray();

            autoCompleteCollections[customTextBox].Clear();
            autoCompleteCollections[customTextBox].AddRange(filteredItems);
        }
    }

    /// <summary>
    /// Guarda el texto ingresado al perder el foco.
    /// </summary>
    private void Control_Leave(object sender, EventArgs e)
    {
        if (sender is Control control)
        {
            string textValue = control is CustomTextBox textBox ? textBox.TextValue : control.Text;

            if (!string.IsNullOrWhiteSpace(textValue))
            {
                var autoCompleteItems = LoadAutoCompleteItems().ToList();
                autoCompleteItems.Remove(textValue);
                autoCompleteItems.Insert(0, textValue);
                autoCompleteItems = autoCompleteItems.Take(100).ToList();

                SaveAutoCompleteItems(autoCompleteItems.ToArray());

                if (autoCompleteCollections.ContainsKey(control))
                {
                    autoCompleteCollections[control].Clear();
                    autoCompleteCollections[control].AddRange(autoCompleteItems.ToArray());
                }

                if (control is CustomComboBox comboBox)
                {
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(autoCompleteItems.ToArray());
                }
            }
        }
    }

    /// <summary>
    /// Carga las sugerencias combinadas según el nombre del control.
    /// </summary>
    private string[] LoadCombinedAutoCompleteItems(string controlName)
    {
        var autoCompleteItems = LoadAutoCompleteItems().ToList();

        // Caso especial para textBox_Caratula
        if (controlName == "textBox_Caratula")
        {
            // Ruta relativa al archivo JSON
            string rutaRelativa = Path.Combine("BaseDatos", "Json", "sugerencias_Caratula.json");

            // Obtener la ruta completa usando la ruta base del ejecutable
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

            // Leer las sugerencias desde el archivo JSON
            var sugerenciasCaratula = LeerSugerenciasDesdeJson(rutaCompleta);

            // Combinar y eliminar duplicados
            autoCompleteItems = sugerenciasCaratula.Concat(autoCompleteItems).Distinct().ToList();
        }
        // Caso especial para comboBox_Buscar
        else if (controlName == "comboBox_Buscar")
        {
            // Ruta relativa al archivo JSON
            string rutaRelativa = Path.Combine("BaseDatos", "Json", "acciones.json");

            // Obtener la ruta completa usando la ruta base del ejecutable
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

            // Leer las sugerencias desde el archivo JSON
            var sugerenciasAcciones = LeerSugerenciasDesdeJson(rutaCompleta);

            // Combinar y eliminar duplicados
            autoCompleteItems = sugerenciasAcciones.Concat(autoCompleteItems).Distinct().ToList();
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
    /// Guarda los últimos 100 ingresos en el archivo JSON.
    /// </summary>
    private void SaveAutoCompleteItems(string[] items)
    {
        File.WriteAllText(filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
    }

    /// <summary>
    /// Lee sugerencias desde un archivo JSON.
    /// </summary>
    private static string[] LeerSugerenciasDesdeJson(string path)
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<string>>(json)?.ToArray() ?? new string[] { };
        }
        return new string[] { };
    }
}