using System;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General
{
    public partial class TimePickerPersonalizado : UserControl
    {
        public   TimePickerPersonalizado()
        {
            InitializeComponent();
            // Configurar el DateTimePicker para mostrar el formato personalizado
            dateTimePickerGeneral.Format = DateTimePickerFormat.Custom;
            dateTimePickerGeneral.CustomFormat = "dd 'DE' MMMM 'DE' yyyy"; // Formato específico para INICIO-CIERRE e IPP
                                                                           // Configurar el valor inicial
            dateTimePickerGeneral.Value = DateTime.Now;

            // Vincular el evento ValueChanged del dateTimePickerGeneral al método DateTimePickerGeneral_ValueChanged
            dateTimePickerGeneral.ValueChanged += DateTimePickerGeneral_ValueChanged;

            // Configurar propiedades para mostrar el calendario
            dateTimePickerGeneral.ShowUpDown = false; // Permite seleccionar fecha y hora
            dateTimePickerGeneral.DropDownAlign = LeftRightAlignment.Right; // Alinea el calendario a la derecha del control
        }

        private void DateTimePickerGeneral_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada del DateTimePicker
            DateTime fechaSeleccionada = dateTimePickerGeneral.Value;

            // Formatear el texto para mostrar solo el mes y el año en mayúsculas
            string mesEnMayusculas = fechaSeleccionada.ToString("MMMM").ToUpper();

            // Mostrar el mes formateado en mayúsculas
            dateTimePickerGeneral.CustomFormat = $"dd ' DE  ' {mesEnMayusculas} ' DE  ' yyyy";
        }

        // Propiedad para acceder y modificar la fecha desde fuera del control
        public DateTime SelectedDate
        {
            get => dateTimePickerGeneral.Value;
            set => dateTimePickerGeneral.Value = value;
        }
    }
}
