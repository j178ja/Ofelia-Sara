using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles
{


    public partial class TimePickerPersonalizado : UserControl
    {
        public event EventHandler FechaCambiada;
        public TimePickerPersonalizado() : this(200, 30) // Valores por defecto
        {
        }

        public TimePickerPersonalizado(int width, int height)
        {
            InitializeComponent();

            // Ajustar el tamaño del DateTimePicker y del UserControl
            dateTimePickerGeneral.Width = width;
            dateTimePickerGeneral.Height = height;
            this.Size = new Size(width, height);


        }

        private void DateTimePickerGeneral_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada del DateTimePicker
            DateTime fechaSeleccionada = dateTimePickerGeneral.Value;

            // Formatear el texto para mostrar solo el mes y el año en mayúsculas
            string mesEnMayusculas = fechaSeleccionada.ToString("MMMM").ToUpper();

            // Mostrar el mes formateado en mayúsculas
            dateTimePickerGeneral.CustomFormat = $"dd ' DE  ' {mesEnMayusculas} ' DE  ' yyyy";

            // Disparar el evento personalizado
            FechaCambiada?.Invoke(this, EventArgs.Empty);
        }

        // Propiedad para acceder y modificar la fecha desde fuera del control
        public DateTime SelectedDate
        {
            get => dateTimePickerGeneral.Value;
            set
            {
                if (value < MinDate)
                {
                    dateTimePickerGeneral.Value = MinDate; // Ajusta si la fecha es menor
                }
                else
                {
                    dateTimePickerGeneral.Value = value;
                }
            }
        }

        public DateTime MinDate
        {
            get => dateTimePickerGeneral.MinDate;
            set => dateTimePickerGeneral.MinDate = value;
        }
        private void TimePickerPersonalizado_SizeChanged(object sender, EventArgs e)
        {
            AdjustDateTimePickerSize();
        }

        // Método para ajustar el tamaño del DateTimePicker al tamaño del UserControl
        private void AdjustDateTimePickerSize()
        {
            dateTimePickerGeneral.Width = this.Width;
            dateTimePickerGeneral.Height = this.Height;
        }




    }
}

