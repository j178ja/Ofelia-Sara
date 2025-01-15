/*ESTA CLASE CONTIENE EL METODO PARA ITERAR LOS CONTROLES DEL FORMULARIO Y ENCONTRAL EL QUE TENGA EL MISMO NOMBRE CON 
 EL COMBOBOX AL QUE SE QUIERE AGREGRAR UN NUEVO ITEM*/


using System.Windows.Forms;



public static class ConfiguradorTextBox
{
    // Método estático para configurar los TextBoxes en un formulario
    public static void ConfigurarTextBoxes(Control parent)
    {
        // Itera a través de todos los controles dentro del control proporcionado (form o panel)
        foreach (Control control in parent.Controls)
        {
            // Si el control es un TextBox
            if (control is TextBox textBox)
            {
                // Agrega un manejador de eventos para el evento TextChanged del TextBox
                textBox.TextChanged += (s, e) =>
                {
                    // Convierte el texto del TextBox a mayúsculas ignorando caracteres especiales
                    TextBox tb = s as TextBox;
                    if (tb != null)
                    {
                        int pos = tb.SelectionStart; // Guarda la posición del cursor
                                                     // tb.Text = MayusculaYnumeros.ConvertirAMayusculasIgnorandoEspeciales(tb.Text); // Convierte a mayúsculas
                        tb.SelectionStart = pos; // Restaura la posición del cursor
                    }
                };
            }
            // Si el control tiene controles hijos, llama al método recursivamente
            else if (control.HasChildren)
            {
                ConfigurarTextBoxes(control);
            }
        }
    }
}
