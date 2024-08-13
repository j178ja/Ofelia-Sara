/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE AL HACER CLICK EN LA IMAGEN DE LIMPIAR
------SE BORRE EL CONTENIDO DEL FORMULARIO SEA CUAL SEA EN EL PROYECTO----*/
using Ofelia_Sara.general.clases.Apariencia_General.Controles;
using System;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public static class LimpiarFormulario
    {
        // Método estático para limpiar todos los controles dentro del formulario
        public static void Limpiar(Control control)
        {
            // Itera a través de todos los controles dentro del control proporcionado (form o panel)
            foreach (Control c in control.Controls)
            {
                // Si el control es un TextBox, limpia su contenido
                if (c is TextBox textBox)
                {
                    textBox.Clear();
                }
                // Si el control es un ComboBox, limpia y restablece su estado
                else if (c is ComboBox comboBox)
                {
                    LimpiarYRestaurarComboBox(comboBox);
                }
                // Si el control es un DateTimePicker, restablece su valor a la fecha actual o a una fecha actual
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now; //se refiere a fecha ACTUAL
                }
                else if (c is CheckBox checkBox)
                {
                    checkBox.Checked = false; //limpia el check
                }
                // Si el control es un PictureBox, limpiar su imagen
                else if (c is PictureBox pictureBox)
                {
                    pictureBox.Image = null;
                }
                // Si el control es un tipo específico (NuevaCaratulaControl, NuevaPersonaControl), elimínalo
                else if (c is NuevaCaratulaControl || c is NuevaPersonaControl)
                {
                    control.Controls.Remove(c);
                    c.Dispose(); // Libera los recursos del control
                }


                // Limpia los controles anidados si existen
                if (c.HasChildren)
                {
                    Limpiar(c);
                }
            }
        }

        // Método para limpiar y restaurar ComboBox
        private static void LimpiarYRestaurarComboBox(ComboBox comboBox)
        {
            // Limpiar el ComboBox
            comboBox.SelectedIndex = -1;
            comboBox.Text = string.Empty;

            //// Restablecer al valor predeterminado si existe
            if (comboBox.Items.Count > 0)
            {
                // Ejemplo: Establecer diferentes índices predeterminados según el ComboBox
                if (comboBox.Name == "comboBox_Ipp1")
                {
                    comboBox.SelectedIndex = 3;
                }
                else if (comboBox.Name == "comboBox_Ipp2")
                {
                    comboBox.SelectedIndex = 3;
                }
                else
                {
                    comboBox.SelectedIndex = 0; // Establece el primer índice por defecto para otros ComboBoxes
                }
            }
        }
    }
}
