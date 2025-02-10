using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using System;

namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    /// <summary>
    /// CLASE PARA CALCULAR EDAD DEPENDIENDO DE FECHA INGRESADA EN CONTROL ESPECIFICO
    /// </summary>
    public static class CalcularEdad
    {
        private static CustomDate customDateTextBox;
        private static CustomTextBox textBoxEdad;

        public static void Inicializar(CustomDate customDateTextBox, CustomTextBox textBoxEdad)
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