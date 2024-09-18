/*ESTA CLASE PERMITE AGREGAR UN NUEVO ITEM A UN COMBOBOX EXPECIFICO, AMBOS ELEMENTOS SON REFERIDOS 
 EN FORMULARIO ESPECIFICO*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    public static class ComboBoxManager
    {
        // Evento que se dispara cuando se agrega un ítem
        public static event Action<string> ItemAdded;

        public static void AddItemToComboBox(Control parent, string comboBoxName, string item)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox comboBox && comboBox.Name == comboBoxName)
                {
                    comboBox.Items.Add(item);

                    // Dispara el evento ItemAdded
                    ItemAdded?.Invoke(item);

                    // Notifica a todos los formularios registrados
                    NotifyAllForms(comboBoxName, item);

                    return;
                }
                else if (control.HasChildren)
                {
                    AddItemToComboBox(control, comboBoxName, item);
                }
            }
        }

        // Método para notificar a todos los formularios registrados
        private static void NotifyAllForms(string comboBoxName, string item)
        {
            foreach (var form in forms)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is ComboBox comboBox && comboBox.Name == comboBoxName)
                    {
                        comboBox.Items.Add(item);
                    }
                }
            }
        }

        // Lista de formularios registrados
        private static List<Form> forms = new List<Form>();

        // Método para registrar un formulario
        public static void RegisterForm(Form form)
        {
            if (!forms.Contains(form))
            {
                forms.Add(form);
            }
        }

        // Método para desregistrar un formulario
        public static void UnregisterForm(Form form)
        {
            forms.Remove(form);
        }
    
        
    }


}
