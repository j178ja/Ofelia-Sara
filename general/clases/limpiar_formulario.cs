/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE AL HACER CLICK EN LA IMAGEN DE LIMPIAR
------SE BORRE EL CONTENIDO DEL FORMULARIO SEA CUAL SEA EN EL PROYECTO----*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public static class LimpiarFormulario
    {
        // Método estático para limpiar todos los controles dentro del formulario
        public static void Limpiar(Control control)
        {
            // Itera a través de todos los controles dentro del control proporcionado (form o panel, por ejemplo)
            foreach (Control c in control.Controls)
            {
                // Si el control es un TextBox, limpia su contenido
                if (c is TextBox textBox)
                {
                    textBox.Clear();
                }
                // Si el control es un ComboBox, restablece su selección a "-1" (ninguna selección)
                else if (c is ComboBox comboBox)
                {
                    // comboBox.SelectedIndex = -1;
                   // comboBox.SelectedItem = null;
                    comboBox.Text = string.Empty;
                }
                // Si el control es un DateTimePicker, restablece su valor a la fecha actual o a una fecha predeterminada
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now; // o una fecha predeterminada si lo prefieres
                }
                // Puedes agregar más lógica para limpiar otros tipos de controles aquí

                // Limpia los controles anidados si existen
                if (c.HasChildren)
                {
                    Limpiar(c);
                }
            }
        }
    }
}