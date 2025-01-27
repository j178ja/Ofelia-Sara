using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class CustomDate : UserControl
    {
        private bool isPlaceholderActive;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;

        // Propiedades para configurar el rango de años
        public int AñoMinimo { get; set; } = 1930;
        public int AñoMaximo { get; set; } = DateTime.Now.Year;

        public CustomDate()
        {
            InitializeComponent();

            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            ConfigurarTextBoxes();
            ConfigurarTooltips();
        }

        private void ConfigurarTextBoxes()
        {
            textBox_DateDIA.MaxLength = 2;
            textBox_DateMES.MaxLength = 2;
            textBox_DateAÑO.MaxLength = 4;

            SetPlaceholder(textBox_DateDIA, "dd");
            SetPlaceholder(textBox_DateMES, "mm");
            SetPlaceholder(textBox_DateAÑO, "aaaa");

            textBox_DateDIA.TextChanged += CamposFecha_TextChanged;
            textBox_DateMES.TextChanged += CamposFecha_TextChanged;
            textBox_DateAÑO.TextChanged += CamposFecha_TextChanged;

            textBox_DateDIA.KeyPress += TextBox_KeyPress;
            textBox_DateMES.KeyPress += TextBox_KeyPress;
            textBox_DateAÑO.KeyPress += TextBox_KeyPress;
        }

        private void ConfigurarTooltips()
        {
            ToolTipGeneral.ShowToolTip(btn_Calendario, "Seleccione fecha.");
            ToolTipGeneral.ShowToolTip(textBox_DateDIA, "Ingrese DÍA.");
            ToolTipGeneral.ShowToolTip(textBox_DateMES, "Ingrese MES.");
            ToolTipGeneral.ShowToolTip(textBox_DateAÑO, "Ingrese AÑO.");
        }

        private void SetPlaceholder(CustomTextBox textBox, string placeholder)
        {
            textBox.PlaceholderText = placeholder;
            textBox.PlaceholderColor = Color.LightGray;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CamposFecha_TextChanged(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CalcularAntiguedad();
            }
            Invalidate(); // Redibujar para actualizar el subrayado
        }

        private bool ValidarCampos()
        {
            return ValidarCampo("Día", textBox_DateDIA.TextValue, 1, 31) &&
                   ValidarCampo("Mes", textBox_DateMES.TextValue, 1, 12) &&
                   ValidarCampo("Año", textBox_DateAÑO.TextValue, AñoMinimo, AñoMaximo);
        }

        private bool ValidarCampo(string campo, string valorTexto, int min, int max)
        {
            if (int.TryParse(valorTexto, out int valor))
            {
                if (valor < min || valor > max)
                {
                    MensajeGeneral.Mostrar($"{campo} debe estar entre {min} y {max}.", MensajeGeneral.TipoMensaje.Advertencia);
                    return false;
                }
                return true;
            }
            return false;
        }

        public DateTime? ObtenerFecha()
        {
            if (ValidarCampos() &&
                int.TryParse(textBox_DateDIA.TextValue, out int dia) &&
                int.TryParse(textBox_DateMES.TextValue, out int mes) &&
                int.TryParse(textBox_DateAÑO.TextValue, out int año))
            {
                return new DateTime(año, mes, dia);
            }
            return null;
        }

        public void CalcularAntiguedad()
        {
            DateTime? fechaNacimiento = ObtenerFecha();
            if (fechaNacimiento.HasValue)
            {
                DateTime fechaActual = DateTime.Now;
                int años = fechaActual.Year - fechaNacimiento.Value.Year;
                int meses = fechaActual.Month - fechaNacimiento.Value.Month;

                if (fechaActual.Day < fechaNacimiento.Value.Day)
                {
                    meses--;
                }
                if (meses < 0)
                {
                    meses += 12;
                    años--;
                }

                OnCalcularAntiguedad?.Invoke(años, meses);
            }
        }

        public Action<int, int> OnCalcularAntiguedad;

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100);
            Invalidate();
            if (animationProgress == 100)
            {
                animationTimer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush brush = new SolidBrush(HasValue() ? focusColor : errorColor))
            {
                int lineWidth = 3;
                e.Graphics.FillRectangle(brush, 0, this.Height - lineWidth, this.Width, lineWidth);
            }
        }

        public bool HasValue()
        {
            return ValidarCampos();
        }

        private void Btn_Calendario_Click(object sender, EventArgs e)
        {
            using (var calendarForm = new CALENDARIO())
            {
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = calendarForm.SelectedDate;

                    textBox_DateDIA.TextValue = selectedDate.Day.ToString("00");
                    textBox_DateMES.TextValue = selectedDate.Month.ToString("00");
                    textBox_DateAÑO.TextValue = selectedDate.Year.ToString();
                }
            }
        }

        public string TextoAsociado { get; set; }

        public void ClearDate()
        {
            textBox_DateDIA.Clear();
            textBox_DateMES.Clear();
            textBox_DateAÑO.Clear();
        }

        public void RestorePlaceholders()
        {
            SetPlaceholder(textBox_DateDIA, "dd");
            SetPlaceholder(textBox_DateMES, "mm");
            SetPlaceholder(textBox_DateAÑO, "aaaa");
        }

    }
}

//namespace Ofelia_Sara.Controles.Ofl_Sara
//{
//    public partial class CustomDate : UserControl
//    {

//        private bool isClosing = false; // Declarar la variable a nivel de clase
//        public CustomDate()
//        {
//            InitializeComponent();

//            // Configurar textBox_DateDIA
//            textBox_DateDIA.MaxLength = 2; // Limitar a 2 caracteres
//            textBox_DateDIA.TextChanged += CamposFecha_TextChanged;

//            // Configurar textBox_DateMES
//            textBox_DateMES.MaxLength = 2; // Limitar a 2 caracteres
//            textBox_DateMES.TextChanged += CamposFecha_TextChanged;

//            // Configurar textBox_DateAÑO
//            textBox_DateAÑO.MaxLength = 4; // Limitar a 4 caracteres
//            textBox_DateAÑO.TextChanged += CamposFecha_TextChanged;

//            CustomDateTextBox_Load(this, EventArgs.Empty);// inicializar load

//            ToolTipGeneral.ShowToolTip(btn_Calendario, "Seleccione fecha.");
//            ToolTipGeneral.ShowToolTip(textBox_DateDIA, " Ingrese DIA.");
//            ToolTipGeneral.ShowToolTip(textBox_DateMES, " Ingrese MES.");
//            ToolTipGeneral.ShowToolTip(textBox_DateAÑO, " Ingrese AÑO.");

//        }
//        private void CustomDateTextBox_Load(object sender, EventArgs e)
//        {

//            textBox_DateDIA.PlaceholderText = "dd";
//            textBox_DateMES.PlaceholderText = "mm";
//            textBox_DateAÑO.PlaceholderText = "aaaa";
//            textBox_DateDIA.PlaceholderColor = Color.LightGray;
//            textBox_DateMES.PlaceholderColor = Color.LightGray;
//            textBox_DateAÑO.PlaceholderColor = Color.LightGray;

//        }
//        //-----------------------------------------------------------------------
//        // Método para verificar si el texto ingresado es una fecha válida
//        public bool HasValue()
//        {
//            // Verifica si los campos de día, mes y año no están vacíos
//            if (string.IsNullOrWhiteSpace(textBox_DateDIA.TextValue) ||
//                string.IsNullOrWhiteSpace(textBox_DateMES.TextValue) ||
//                string.IsNullOrWhiteSpace(textBox_DateAÑO.TextValue))
//            {
//                return false; // Retorna false si alguno de los campos está vacío
//            }

//            // Intenta convertir los valores de texto a enteros
//            if (int.TryParse(textBox_DateDIA.TextValue, out int dia) &&
//                int.TryParse(textBox_DateMES.TextValue, out int mes) &&
//                int.TryParse(textBox_DateAÑO.TextValue, out int año))
//            {
//                try
//                {
//                    // Intenta crear una fecha válida con los valores proporcionados
//                    new DateTime(año, mes, dia);  // Si la fecha es válida, pasa
//                    return true;
//                }
//                catch (ArgumentOutOfRangeException)
//                {
//                    // Si la fecha no es válida (como 31 de febrero, etc.), retorna false
//                    return false;
//                }
//            }

//            // Si alguno de los campos no contiene un número válido, retorna false
//            return false;
//        }



//        //----OBTENER DATOS DE FECHA NACIMIENTO----------------------
//        public DateTime? ObtenerFecha()
//        {
//            // Verifica que los campos de día, mes y año estén completos y sean válidos.
//            if (int.TryParse(textBox_DateDIA.TextValue, out int dia) &&
//                int.TryParse(textBox_DateMES.TextValue, out int mes) &&
//                int.TryParse(textBox_DateAÑO.TextValue, out int año))
//            {
//                try
//                {
//                    // Intenta crear un DateTime con los valores proporcionados.
//                    return new DateTime(año, mes, dia);
//                }
//                catch
//                {
//                    // Si la combinación de valores no es válida, devuelve null.
//                    MensajeGeneral.Mostrar("La fecha ingresada no es válida.", MensajeGeneral.TipoMensaje.Error);
//                    return null;
//                }
//            }
//            // Si algún campo no es válido, devuelve null.
//            return null;
//        }



//        //----------------------------------------------------------------------


//        // Manejar el evento KeyPress para permitir solo números
//        private void TextBox_Date_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
//            {
//                e.Handled = true; // Cancelar el evento si el carácter no es un dígito o una tecla de control
//            }
//        }

//        private bool ValidarCampo(string campo, int valor, int min, int max)
//        {
//            if (valor < min || valor > max)
//            {
//                MensajeGeneral.Mostrar($"{campo} debe estar entre {min} y {max}.", MensajeGeneral.TipoMensaje.Advertencia);
//                return false;
//            }
//            return true;
//        }

//        private void TextBox_DateDIA_TextChanged(object sender, EventArgs e)
//        {
//            if (textBox_DateDIA.TextValue.Length == 2 && int.TryParse(textBox_DateDIA.TextValue, out int dia))
//            {
//                if (!ValidarCampo("Día", dia, 1, 31))
//                {
//                    textBox_DateDIA.Clear();
//                }
//            }
//        }

//        private void TextBox_DateMES_TextChanged(object sender, EventArgs e)
//        {
//            if (textBox_DateMES.TextValue.Length == 2 && int.TryParse(textBox_DateMES.TextValue, out int mes))
//            {
//                if (!ValidarCampo("Mes", mes, 1, 12))
//                {
//                    textBox_DateMES.Clear();
//                }
//            }
//        }

//        private void TextBox_DateAÑO_TextChanged(object sender, EventArgs e)
//        {
//            int añoActual = DateTime.Now.Year;
//            if (textBox_DateAÑO.TextValue.Length == 4 && int.TryParse(textBox_DateAÑO.TextValue, out int year))
//            {
//                if (!ValidarCampo("Año", year, 1930, añoActual))
//                {
//                    textBox_DateAÑO.Clear();
//                }
//            }
//        }




//        // Propiedad para almacenar el control asociado
//        public string TextoAsociado { get; set; }

//        private void Btn_Calendario_Click(object sender, EventArgs e)
//        {
//            using (var calendarForm = new CALENDARIO())
//            {
//                // Cambiar el texto de CustomDate basado en la propiedad
//                if (!string.IsNullOrEmpty(TextoAsociado))
//                {
//                    this.Text = TextoAsociado;
//                }

//                if (calendarForm.ShowDialog() == DialogResult.OK)
//                {
//                    DateTime selectedDate = calendarForm.SelectedDate;

//                    textBox_DateDIA.TextValue = selectedDate.Day.ToString("00");  // Día con dos dígitos
//                    textBox_DateMES.TextValue = selectedDate.Month.ToString("00"); // Mes con dos dígitos
//                    textBox_DateAÑO.TextValue = selectedDate.Year.ToString(); // Año completo

//                    textBox_DateDIA.ForeColor = Color.Black;
//                    textBox_DateMES.ForeColor = Color.Black;
//                    textBox_DateAÑO.ForeColor = Color.Black;
//                }
//            }
//        }




//        public void RestorePlaceholders()
//        {
//            SetPlaceholder(textBox_DateDIA, "dd");
//            SetPlaceholder(textBox_DateMES, "mm");
//            SetPlaceholder(textBox_DateAÑO, "aaaa");
//        }

//        public void ClearDate()
//        {
//            textBox_DateDIA.Clear();
//            textBox_DateMES.Clear();
//            textBox_DateAÑO.Clear();
//        }


//        // Método para manejar el evento de cierre del formulario
//        /*con este evento se pretende que no se muestre el mensaje de advertencia cuandos e elimina
//         el formulario, indicando que debe tener 4 digitos */
//        // Método para manejar el cierre del formulario
//        public void HandleFormClosing()
//        {
//            // Marca que el formulario se está cerrando para evitar mostrar mensajes de advertencia
//            isClosing = true;
//        }


//        private void TextBox_DateAÑO_Validating(object sender, CancelEventArgs e)
//        {
//            if (!isClosing)
//            {
//                // Lógica de validación y mostrar mensaje de advertencia si es necesario
//                if (textBox_DateAÑO.TextValue.Length < 4)
//                {
//                    // Mostrar mensaje de advertencia
//                    MensajeGeneral.Mostrar("El año debe tener al menos 4 dígitos.", MensajeGeneral.TipoMensaje.Advertencia);
//                    e.Cancel = true; // Previene que se cierre el formulario
//                }
//            }
//            else
//            {
//                // Resetea la bandera después de usarla
//                isClosing = false;
//            }
//        }
//        //---------------------------------------------------------------------------
//        //--------CALCULAR ANTIGUEDAD----------------------------------------------
//        // Método para validar automáticamente cuando cambia el texto en los campos de fecha
//        private void CamposFecha_TextChanged(object sender, EventArgs e)
//        {
//            // Llama a CalcularAntiguedad cada vez que se modifica un campo de fecha
//            if (HasValue()) // Asegura que todos los campos tengan valores válidos antes de calcular
//            {
//                CalcularAntiguedad();
//            }
//        }

//        public Action<int, int> OnCalcularAntiguedad;

//        public void CalcularAntiguedad()
//        {
//            DateTime? fechaNacimiento = ObtenerFecha();
//            if (fechaNacimiento.HasValue)
//            {
//                DateTime fechaActual = DateTime.Now;
//                DateTime fechaNac = fechaNacimiento.Value;

//                int años = fechaActual.Year - fechaNac.Year;
//                if (fechaActual.Month < fechaNac.Month || (fechaActual.Month == fechaNac.Month && fechaActual.Day < fechaNac.Day))
//                {
//                    años--;
//                }

//                int meses = fechaActual.Month - fechaNac.Month;
//                if (meses < 0)
//                {
//                    meses += 12;
//                }

//                // Llama al método en el formulario de destino para mostrar la antigüedad
//                OnCalcularAntiguedad?.Invoke(años, meses);
//            }
//            else
//            {
//                MensajeGeneral.Mostrar("Por favor, ingrese una fecha válida.", MensajeGeneral.TipoMensaje.Advertencia);
//            }
//        }

//    }

//}