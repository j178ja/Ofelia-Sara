/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE AL HACER CLICK EN LA IMAGEN DE LIMPIAR
------SE BORRE EL CONTENIDO DEL FORMULARIO SEA CUAL SEA EN EL PROYECTO----*/
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using System;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Botones

{
    public static class LimpiarFormulario
    {

        // Método estático para limpiar todos los controles dentro del formulario
        // Itera a través de todos los controles dentro del control proporcionado (form o panel)

        public static void Limpiar(Control control)
        {
            foreach (Control c in control.Controls)
            {
                switch (c)
                {
                    // Si el control es un TextBox, limpia su contenido
                    case TextBox textBox:
                        textBox.Clear();
                        break;

                    // Si el control es un ComboBox, limpia y restablece su estado
                    case ComboBox comboBox:
                        LimpiarYRestaurarComboBox(comboBox);
                        break;

                    // Si el control es un DateTimePicker, restablece su valor a la fecha actual o a una fecha actual
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Value = DateTime.Now;
                        break;

                    // si es un checkbox -->limpiar
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;

                    // si es un radiobutom -->limpiar
                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        break;

                    // Si el control es un PictureBox, limpiar su imagen
                    case PictureBox pictureBox:
                        pictureBox.Image = null;
                        break;

                    // Si el control es FECHA DE NACIMIENTO
                    case CustomDate customDateTextBox:
                        customDateTextBox.ClearDate(); // Limpiar el control personalizado
                                                       // customDateTextBox.RestorePlaceholders(); // Restaurar los placeholders
                        break;

                    // Si el control es email 
                    case EmailControl customEmailTextBox:
                        customEmailTextBox.ClearEmailFields(); // Limpiar el control de email
                        customEmailTextBox.RestorePlaceholders(); // Restaurar los placeholders
                        break;

                    // Si el control es NUMERO TELEFONO
                    case NumeroTelefonicoControl numeroTelefonico:
                        numeroTelefonico.ClearTelefonoFields(); // Limpiar el control de NumeroTelefonicoControl
                        numeroTelefonico.RestorePlaceholders(); // Restaurar los placeholders
                        break;

                    case Control nestedControl when nestedControl.HasChildren:
                        Limpiar(nestedControl);
                        break;

                    case BotonDeslizable botonDeslizable:
                        botonDeslizable.IsOn = false;
                        break;


                    // Si el control es un tipo específico (NuevaCaratulaControl, NuevaPersonaControl), 
                    case NuevaCaratulaControl _:
                    case NuevaPersonaControl _:
                        control.Controls.Remove(c);
                        c.Dispose();
                        break;
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
