using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Validaciones
{
    public static class ValidacionError
    {
        public static bool ValidacionFaltanteCampos(Control container, ErrorProvider errorProvider)
        {
            // Limpiar errores previos
            errorProvider.Clear();

            bool allValid = true;

            // Recorrer todos los controles del formulario
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorProvider.SetError(textBox, "Este campo es obligatorio.");
                        allValid = false;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        errorProvider.SetError(comboBox, "Seleccione una opción.");
                        allValid = false;
                    }
                }

            }

            if (!allValid)
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return allValid;
        }
    }
}


