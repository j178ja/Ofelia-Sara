using System;
using System.Windows.Forms;

namespace Controles.Controles.Aplicadas_con_controles
{
    public static class CalcularEdad
    {
        private static CustomDateTextBox customDateTextBox;
        private static TextBox textBoxEdad;

        public static void Inicializar(CustomDateTextBox customDateTextBox, TextBox textBoxEdad)
        {
            CalcularEdad.customDateTextBox = customDateTextBox;
            CalcularEdad.textBoxEdad = textBoxEdad;

            // Suscribirse a los eventos de cambio de texto de los campos de fecha
            customDateTextBox.textBox_DateDIA.TextChanged += (sender, e) => ActualizarEdad();
            customDateTextBox.textBox_DateMES.TextChanged += (sender, e) => ActualizarEdad();
            customDateTextBox.textBox_DateAÑO.TextChanged += (sender, e) => ActualizarEdad();
        }

        private static void ActualizarEdad()
        {
            // Asegurarse de que los tres campos de fecha contienen valores válidos antes de proceder
            if (int.TryParse(customDateTextBox.textBox_DateDIA.Text, out int dia) &&
                int.TryParse(customDateTextBox.textBox_DateMES.Text, out int mes) &&
                int.TryParse(customDateTextBox.textBox_DateAÑO.Text, out int año))
            {
                try
                {
                    DateTime fechaNacimiento = new DateTime(año, mes, dia);
                    int edadCalculada = Calcular(fechaNacimiento);
                    textBoxEdad.Text = edadCalculada.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Manejar casos en los que la fecha no es válida (por ejemplo, 31 de febrero)
                    textBoxEdad.Clear();
                }
            }
            else
            {
                textBoxEdad.Clear();
            }
        }

        public static int Calcular(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad;
        }
    }
}