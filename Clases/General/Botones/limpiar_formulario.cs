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
        /// <summary>
        /// // Método estático para limpiar todos los controles dentro del formulario
        /// Itera a través de todos los controles dentro del control proporcionado (form o panel)
        /// </summary>
        /// <param name="control"></param>

        public static void Limpiar(Control control)
        {
            foreach (Control c in control.Controls)
            {
                switch (c)
                {
                    // Si el control es un CustomTextBox, limpia su contenido
                    case CustomTextBox textBox:
                        textBox.Clear(); // Limpia el texto del CustomTextBox
                        textBox.RestorePlaceholders(); // Restaura los placeholders si es necesario
                        break;

                    // Si el control es un CustomComboBox, limpia pero conserva las imágenes
                    case CustomComboBox comboBox:
                        LimpiarYRestaurarComboBox(comboBox);
                        break;

                    // Si el control es un DateTimePicker, restablece su valor a la fecha actual
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Value = DateTime.Now;
                        break;

                    // Si el control es un CheckBox, desmarca la casilla
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        checkBox.Visible = true;
                        checkBox.BringToFront();
                        break;

                    // Si el control es un RadioButton, desmarca el botón
                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        break;

                    // Si el control es un PictureBox, solo limpia la imagen si no forma parte de un CustomComboBox
                    case PictureBox pictureBox when !(pictureBox.Parent is CustomComboBox):
                        pictureBox.Image = null;
                        break;

                    // Si el control es un CustomDate, limpia los campos y restaura los placeholders
                    case CustomDate customDateTextBox:
                        customDateTextBox.ClearDate();
                        customDateTextBox.RestorePlaceholders();
                        break;

                    // Si el control es un EmailControl, limpia los campos y restaura los placeholders
                    case EmailControl customEmailTextBox:
                        customEmailTextBox.ClearEmailFields();
                        customEmailTextBox.RestorePlaceholders();
                        break;

                    // Si el control es un NumeroTelefonicoControl, limpia los campos y restaura los placeholders
                    case NumeroTelefonicoControl numeroTelefonico:
                        numeroTelefonico.ClearTelefonoFields();
                        numeroTelefonico.RestorePlaceholders();
                        break;

                    // Si el control es un BotonDeslizable, restablece su estado a apagado
                    case BotonDeslizable botonDeslizable:
                        botonDeslizable.IsOn = false;
                        break;

                    // Si el control tiene controles hijos, aplica la limpieza recursivamente
                    case Control nestedControl when nestedControl.HasChildren:
                        Limpiar(nestedControl);
                        break;

                   
                    case NuevaPersonaControl _:
                        control.Controls.Remove(c);
                        c.Dispose();
                        break;

                    case NuevaImagen nuevaImagen:
                        nuevaImagen.RestaurarImagenPredeterminada(); // Restaurar la imagen predeterminada
                        break;

                    case RichTextBox richTextBox:
                        richTextBox.Clear();
                        break;

                }
            }
        }

        
        /// <summary>
        /// para limpiar y restaurar un CustomComboBox
        /// </summary>
        /// <param name="comboBox"></param>
        private static void LimpiarYRestaurarComboBox(CustomComboBox comboBox)
        {
            comboBox.SelectedIndex = -1; // Deselecciona cualquier elemento
            comboBox.TextValue = string.Empty; // Limpia el texto si tiene alguno
            comboBox.RestorePlaceholders(); // Restaura los placeholders si los tiene
                                            // Aseguramos que las imágenes, si existen, no se eliminen
            if (comboBox.ArrowPictureBox != null && comboBox.ArrowPictureBox.Image != null)
            {
                comboBox.ArrowPictureBox.Image = comboBox.ArrowPictureBox.Image; // Mantiene la imagen actual
            }
           

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
