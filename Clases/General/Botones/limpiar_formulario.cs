/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE AL HACER CLICK EN LA IMAGEN DE LIMPIAR
------SE BORRE EL CONTENIDO DEL FORMULARIO SEA CUAL SEA EN EL PROYECTO----*/

using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;


namespace Ofelia_Sara.Clases.General.Botones

{
    public static class LimpiarFormulario
    {
        /// <summary>
        /// // Método estático para limpiar todos los controles dentro del formulario
        /// Itera a través de todos los controles dentro del control proporcionado (form o panel)
        /// </summary>
        /// <param name="control"></param>
        //NO MUESTRA MENSAJE:Limpiar(Formulario, true, false);
        // MUESTRA MENSAJE : LimpiarFormulario.Limpiar(this);

        public static void Limpiar(Control control, bool mostrarMensaje = true, bool forzarMensaje = true)
        {
            bool limpiezaRealizada = false;

            foreach (Control c in control.Controls)
            {
                switch (c)
                {
                    case CustomTextBox textBox:
                        textBox.Clear();
                        textBox.ShowError = false;
                        textBox.RestorePlaceholders();
                        limpiezaRealizada = true;
                        break;

                    case CustomComboBox comboBox:
                        comboBox.ShowError = false;
                        comboBox.SelectedIndex = -1;
                        LimpiarYRestaurarComboBox(comboBox);
                        limpiezaRealizada = true;
                        break;

                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Value = DateTime.Now;
                        limpiezaRealizada = true;
                        break;

                    case TimePickerPersonalizado timePickerPersonalizado:
                        timePickerPersonalizado.Value = DateTime.Now;
                        limpiezaRealizada = true;
                        break;

                    //case DateCompromiso_Control dateCompromiso_Control:
                    //    dateCompromiso_Control.Value = DateTime.Now;
                    //    limpiezaRealizada = true;
                    //    break;


                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        checkBox.Visible = true;
                        checkBox.BringToFront();
                        limpiezaRealizada = true;
                        break;

                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        limpiezaRealizada = true;
                        break;

                    case PictureBox pictureBox when !(pictureBox.Parent is CustomComboBox):
                        pictureBox.Image = null;
                        limpiezaRealizada = true;
                        break;

                    case CustomDate customDateTextBox:
                        customDateTextBox.ClearDate();
                        customDateTextBox.RestorePlaceholders();
                        limpiezaRealizada = true;
                        break;

                    

                    case EmailControl customEmailTextBox:
                        customEmailTextBox.ClearEmailFields();
                        customEmailTextBox.RestorePlaceholders();
                        limpiezaRealizada = true;
                        break;

                    case NumeroTelefonicoControl numeroTelefonico:
                        numeroTelefonico.ClearTelefonoFields();
                        numeroTelefonico.RestorePlaceholders();
                        limpiezaRealizada = true;
                        break;

                    case BotonDeslizable botonDeslizable:
                        botonDeslizable.IsOn = false;
                        limpiezaRealizada = true;
                        break;

                    case Control nestedControl when nestedControl.HasChildren:
                        Limpiar(nestedControl, false, forzarMensaje); // Llamada recursiva sin mostrar mensaje
                        limpiezaRealizada = true;
                        break;

                    case NuevaPersonaControl _:
                        control.Controls.Remove(c);
                        c.Dispose();
                        limpiezaRealizada = true;
                        break;

                    case NuevaImagen nuevaImagen:
                        nuevaImagen.RestaurarImagenPredeterminada();
                        limpiezaRealizada = true;
                        break;

                    case RichTextBox richTextBox:
                        richTextBox.Clear();
                        limpiezaRealizada = true;
                        break;
                }
            }

            // Solo mostrar el mensaje si estamos en la primera llamada y se hizo una limpieza
            if (mostrarMensaje && limpiezaRealizada && forzarMensaje)
            {
                MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
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


            // Restablecer al valor predeterminado si existen elementos en el ComboBox
            if (comboBox.Items.Count > 0)
            {
                switch (comboBox.Name)
                {
                    case "comboBox_Ipp1":
                    case "comboBox_Ipp2":
                    case "comboBox_Ipp4":
                        comboBox.SelectedIndex = 3;
                        break;

                    default:
                        comboBox.SelectedIndex = -1; // Establece el primer índice por defecto para otros ComboBoxes
                        break;
                }
            }

        }



    }
}
