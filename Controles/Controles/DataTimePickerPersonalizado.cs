using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Controles
{
    public partial class TimePickerPersonalizado : UserControl
    {
        private DateTimePicker dateTimePickerPersonalizado;

        public TimePickerPersonalizado()
        {
            InitializeComponent();
            CrearControles();
        }

        // Constructor para permitir pasar parámetros de tamaño
        public TimePickerPersonalizado(int width, int height)
        {
            InitializeComponent();
            CrearControles();
            this.Width = width;
            this.Height = height;
            AjustarTamanoDateTimePicker();
        }

        private void CrearControles()
        {
            dateTimePickerPersonalizado = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd 'DE' MMMM 'DE' yyyy",
                ShowUpDown = false, // Desactiva el selector de flechas
                Width = this.Width, // Ajuste automático
                Height = this.Height,
                Cursor = Cursors.Hand
            };

            dateTimePickerPersonalizado.ValueChanged += dateTimePickerPersonalizado_ValueChanged;
            this.Controls.Add(dateTimePickerPersonalizado);

            // Ajustar el tamaño del DateTimePicker al cambiar el tamaño del UserControl
            this.SizeChanged += (sender, e) => AjustarTamanoDateTimePicker();
        }

        private void dateTimePickerPersonalizado_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePickerPersonalizado.Value;
            string fechaFormateada = fechaSeleccionada.ToString("dd 'DE' MMMM 'DE' yyyy", CultureInfo.InvariantCulture).ToUpper();

            // Usar un método auxiliar para establecer el texto, si el DateTimePicker permite actualizar el texto directamente
            dateTimePickerPersonalizado.Text = fechaFormateada;
        }



        private void AjustarTamanoDateTimePicker()
        {
            dateTimePickerPersonalizado.Width = this.Width;
            dateTimePickerPersonalizado.Height = this.Height;
        }

        public DateTime SelectedDate
        {
            get => dateTimePickerPersonalizado.Value;
            set => dateTimePickerPersonalizado.Value = value;
        }
    }
}