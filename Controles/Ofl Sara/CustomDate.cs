using Ofelia_Sara.Controles.Controles.Tooltip;
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
        #region VARIABLES
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Transparent;//Se coloco transparente para que nos e vea cuando se carga el formulario
        private Color errorColor = Color.Red;
        #endregion

        #region PROPIEDADES PUBLICAS
        // Propiedades para configurar el rango de años
        public int AñoMinimo { get; set; } = 1930;
        public int AñoMaximo { get; set; } = DateTime.Now.Year;
        public Color SubrayadoGeneralFocusColor { get; set; } = Color.Blue;
        public Color SubrayadoGeneralErrorColor { get; set; } = Color.Red;
        #endregion

        #region CONSTRUCTOR
        public CustomDate()
        {
            InitializeComponent();

            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            isFocused = false;
            showError = false; // No mostrar errores al cargar

            ConfigurarTextBoxes();
            ConfigurarTooltips();
            ConfigurarPlaceholders();

            RestorePlaceholders(); // Forzar los placeholders visibles inicialmente
        }
        #endregion

        #region CONFIGURACIONES GENERALES
        /// <summary>
        /// CONFIGURAR PROPIEDADES DE TEXTBOX
        /// </summary>
        private void ConfigurarTextBoxes()
        {
            // Limitar la cantidad de caracteres en los TextBoxes
            textBox_DateDIA.MaxLength = 2;
            textBox_DateMES.MaxLength = 2;
            textBox_DateAÑO.MaxLength = 4;

            //indices para la recorrida de tab
            textBox_DateDIA.TabIndex = 0;
            textBox_DateMES.TabIndex = 1;
            textBox_DateAÑO.TabIndex = 2;

            // Establecer los placeholders para cada TextBox
            //SetPlaceholder(textBox_DateDIA, "dd");
            //SetPlaceholder(textBox_DateMES, "mm");
            //SetPlaceholder(textBox_DateAÑO, "aaaa");

            // Asociar eventos de cambio de texto para cálculos (como antigüedad o validación)
            textBox_DateDIA.TextChanged += CamposFecha_TextChanged;
            textBox_DateMES.TextChanged += CamposFecha_TextChanged;
            textBox_DateAÑO.TextChanged += CamposFecha_TextChanged;

            // Validar que solo se permitan números
            textBox_DateDIA.KeyPress += TextBox_KeyPress;
            textBox_DateMES.KeyPress += TextBox_KeyPress;
            textBox_DateAÑO.KeyPress += TextBox_KeyPress;

            //autocompleta y pasa al textbox siguiente
            textBox_DateDIA.KeyDown += TextBox_KeyDown;
            textBox_DateMES.KeyDown += TextBox_KeyDown;
            textBox_DateAÑO.KeyDown += TextBox_KeyDown;

            //autocompleta al perder el foco
            textBox_DateDIA.KeyPress += TextBox_Leave;
            textBox_DateMES.KeyPress += TextBox_Leave;
            textBox_DateAÑO.KeyPress += TextBox_Leave;

            // Asociar el evento Leave para el autocompletado al perder el foco
            textBox_DateDIA.Leave += (s, e) => TextBox_Autocompletar(s as CustomTextBox);
            textBox_DateMES.Leave += (s, e) => TextBox_Autocompletar(s as CustomTextBox);
            textBox_DateAÑO.Leave += (s, e) => TextBox_Autocompletar(s as CustomTextBox);

            // Asociar el evento KeyDown para autocompletar y navegación
            textBox_DateDIA.KeyDown += ManejarAutocompletadoYNavegacion;
            textBox_DateMES.KeyDown += ManejarAutocompletadoYNavegacion;
            textBox_DateAÑO.KeyDown += ManejarAutocompletadoYNavegacion;
        }


        /// <summary>
        /// METODO QUE AGRUPA LOS TOOLTIPS DEL CONTROL
        /// </summary>
        private void ConfigurarTooltips()
        {
            ToolTipGeneral.ShowToolTip(btn_Calendario, "Seleccione fecha.");
            ToolTipGeneral.ShowToolTip(textBox_DateDIA, "Ingrese DÍA.");
            ToolTipGeneral.ShowToolTip(textBox_DateMES, "Ingrese MES.");
            ToolTipGeneral.ShowToolTip(textBox_DateAÑO, "Ingrese AÑO.");
        }
        #endregion 
     
        #region autocompletado

        /// <summary>
        /// METODO PARA AUTOCOMPLETAR DIA Y MES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBox_Autocompletar(CustomTextBox textBox)
        {
            if (textBox == textBox_DateDIA || textBox == textBox_DateMES)
            {
                if (textBox.TextValue.Length == 1)
                {
                    textBox.TextValue = "0" + textBox.TextValue; // Agrega un 0 a la izquierda
                }
            }
            else if (textBox == textBox_DateAÑO)
            {
                if (textBox.TextValue.Length == 2)
                {
                    int enteredYear = int.Parse(textBox.TextValue);
                    int currentYearLastTwoDigits = DateTime.Now.Year % 100;

                    if (enteredYear <= currentYearLastTwoDigits)
                    {
                        textBox.TextValue = "20" + textBox.TextValue; // Completa con "20" a la izquierda
                    }
                    else
                    {
                        textBox.TextValue = "19" + textBox.TextValue; // Completa con "19" a la izquierda
                    }
                }
                else if (textBox.TextValue.Length == 1)
                {
                    ValidarCampo("Año", textBox_DateAÑO.TextValue, AñoMinimo, AñoMaximo, textBox_DateAÑO);

                    textBox.Focus();
                }
            }
        }

        /// <summary>
        /// evento PARA CUANDO SE PRESIONA TECLA ENTER O TAB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && sender is CustomTextBox textBox)
            {
                TextBox_Autocompletar(textBox); // Llamar al método de autocompletado
                ManejarAutocompletadoYNavegacion(sender, e); // Manejar navegación
            }
        }

        /// <summary>
        /// METODO PARA CUANDO EL TEXTBOX PIERDE EL FOCO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is CustomTextBox textBox)
            {
                TextBox_Autocompletar(textBox); // Llamar al método de autocompletado al perder foco
            }
        }


        /// <summary>
        /// TEXTO ESPECIFICO PARA CADA PLACEHOLDER
        /// </summary>
        private void ConfigurarPlaceholders()
        {
            ConfigurarPlaceholder(textBox_DateDIA, "dd");
            ConfigurarPlaceholder(textBox_DateMES, "mm");
            ConfigurarPlaceholder(textBox_DateAÑO, "aaaa");
        }

        /// <summary>
        /// CONFIGURACION DE PLACEHOLDER
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="placeholder"></param>
        private void ConfigurarPlaceholder(CustomTextBox textBox, string placeholder)
        {
            textBox.PlaceholderText = placeholder;
            textBox.PlaceholderColor = Color.LightGray;

            textBox.Enter += (s, e) =>
            {
                if (textBox.TextValue == placeholder)
                {
                    textBox.TextValue = string.Empty;
                    textBox.ForeColor = Color.Black;
                }

                ActivarSubrayadoGeneral();
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.TextValue))
                {
                    textBox.TextValue = placeholder;
                    textBox.ForeColor = Color.LightGray;
                }

                VerificarEstadoSubrayadoGeneral();
            };
        }

        /// <summary>
        /// METODO PARA RESTAURAR PLACEHOLDER
        /// </summary>
        public void RestorePlaceholders()
        {
            textBox_DateDIA.TextValue = "dd";
            textBox_DateMES.TextValue = "mm";
            textBox_DateAÑO.TextValue = "aaaa";

            textBox_DateDIA.ForeColor = Color.LightGray;
            textBox_DateMES.ForeColor = Color.LightGray;
            textBox_DateAÑO.ForeColor = Color.LightGray;

            textBox_DateDIA.ShowError = false;
            textBox_DateMES.ShowError = false;
            textBox_DateAÑO.ShowError = false;

            showError = false;
            Invalidate();
        }
        #endregion autocompletado
       
        #region validaciones

        /// <summary>
        /// PERMITE SOLO NUMEROS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool HasValue()
       {
            return ValidarCampos();
        }


        //private void CamposFecha_TextChanged(object sender, EventArgs e)
        //{
        //    showError = HasAnyError();
        //    if (!showError && ValidarCampos())
        //    {
        //        CalcularAntiguedad();
        //    }
        //    Invalidate();
        //}
        private void CamposFecha_TextChanged(object sender, EventArgs e)
        {
            // Validar si los campos están completos
            if (ValidarCampos())
            {
                // Obtener la fecha seleccionada
                DateTime? fechaSeleccionada = ObtenerFecha();
                if (fechaSeleccionada.HasValue)
                {
                    // Validar si el nombre del control es de antiguedad o nacimiento"
                    if (this.Name == "dateTimePicker_Antiguedad"|| this.Name == "dateTimePicker_FechaNacimiento")
                    {
                        // Comprobar si la fecha seleccionada es posterior a la fecha actual
                        if (fechaSeleccionada.Value > DateTime.Now)
                        {
                            // Calcular la posición del control actual en la pantalla
                            Point controlPosition = this.PointToScreen(Point.Empty);

                            // Mostrar mensaje de advertencia
                            using (var mensajeForm = new MensajeGeneral("La fecha no puede ser posterior a la fecha actual.", MensajeGeneral.TipoMensaje.Advertencia))
                            {
                                // Centrar el mensaje con respecto al control
                                int messageX = controlPosition.X + (this.Width / 2) - (mensajeForm.Width / 2);
                                int messageY = controlPosition.Y + this.Height + 3; // Posicionar justo debajo del control

                                mensajeForm.StartPosition = FormStartPosition.Manual;
                                mensajeForm.Location = new Point(messageX, messageY);
                                mensajeForm.ShowDialog();
                            }

                            // Limpiar los campos y restaurar los placeholders
                            ClearDate();
                            RestorePlaceholders();
                            return;
                        }

                    }

                    // Calcular antigüedad si la fecha es válida
                    CalcularAntiguedad();
                }
            }

            // Actualizar estado visual del subrayado general
            showError = HasAnyError();
            Invalidate();
        }

        /// <summary>
        /// PARAMETROS DE VALIDACION 
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            return ValidarCampo("Día", textBox_DateDIA.TextValue, 1, 31, textBox_DateDIA) &&
                   ValidarCampo("Mes", textBox_DateMES.TextValue, 1, 12, textBox_DateMES) &&
                   ValidarCampo("Año", textBox_DateAÑO.TextValue, AñoMinimo, AñoMaximo, textBox_DateAÑO);
        }


        /// <summary>
        /// METODO PARA VALIDAR PARAMETROS DE CAMPOS
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="valorTexto"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private bool ValidarCampo(string campo, string valorTexto, int min, int max, CustomTextBox textBox)
        {
            if (int.TryParse(valorTexto, out int valor))
            {
                if (valor < min || valor > max)
                {
                    // Crear una instancia del formulario sin mostrarlo aún
                    using (var form = new MensajeGeneral($"{campo} debe estar entre {min} y {max}.", MensajeGeneral.TipoMensaje.Advertencia))
                    {
                        // Calcular el ancho del formulario
                        int messageWidth = form.Width;

                        // Calcular la posición del mensaje
                        Point controlPosition = textBox.PointToScreen(Point.Empty);
                        int messageX = controlPosition.X + (textBox.Width / 2) - (messageWidth / 2); // Centrar horizontalmente
                        int messageY = controlPosition.Y + textBox.Height + 6; // Justo debajo del TextBox

                        // Configurar la posición del formulario
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = new Point(messageX, messageY);

                        // Mostrar el formulario
                        form.ShowDialog();
                    }
                    return false;
                }
                return true;
            }
            return false;
        }



        /// <summary>
        /// OBTIENE FECHA SELECCIONADA EN FORMULARIO Y LA MUESTRA EN LOS CAMPOS
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region Animación y Dibujado
        /// <summary>
        /// TIMER PARA CONTROLAR AVANCE DE SUBRAYADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100);
            Invalidate();
            if (animationProgress == 100)
            {
                animationTimer.Stop();
            }
        }

        /// <summary>
        /// ANIMACION DE TEXTBOX Y CONTROL COMPLETO
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool hasError = false;

            foreach (Control control in panel_ContenedorFecha.Controls)
            {
                if (control is CustomTextBox customTextBox)
                {
                    using (Brush brush = new SolidBrush(customTextBox.Focused ? focusColor : (customTextBox.ShowError ? errorColor : focusColor)))
                    {
                        int lineWidth = 2;
                        e.Graphics.FillRectangle(
                            brush,
                            customTextBox.Left + panel_ContenedorFecha.Left,
                            customTextBox.Bottom + 1,
                            customTextBox.Width,
                            lineWidth
                        );
                    }

                    if (customTextBox.ShowError || string.IsNullOrWhiteSpace(customTextBox.TextValue))
                    {
                        hasError = true;
                    }
                }
            }

            using (Brush generalBrush = new SolidBrush(hasError ? SubrayadoGeneralErrorColor : (isFocused ? SubrayadoGeneralFocusColor : Color.Transparent)))
            {
                int generalLineWidth = 3;
                e.Graphics.FillRectangle(
                    generalBrush,
                    panel_ContenedorFecha.Left,
                    panel_ContenedorFecha.Bottom,
                    panel_ContenedorFecha.Width,
                    generalLineWidth
                );
            }
        }

        /// <summary>
        /// VERIFICAR SI ALGUN TEXTBOX ESTA SUBRAYADO EN ROJO
        /// </summary>
        /// <returns></returns>
        private bool HasAnyError()
        {
            foreach (Control control in panel_ContenedorFecha.Controls)
            {
                if (control is CustomTextBox customTextBox && customTextBox.ShowError)
                {
                    return true;
                }
            }
            return false;
        }

        private void ActivarSubrayadoGeneral()
        {
            isFocused = true;
            Invalidate();
        }

        private void VerificarEstadoSubrayadoGeneral()
        {
            isFocused = false;
            showError = HasAnyError();
            Invalidate();
        }
        #endregion Animación y Dibujado
      
        #region Metodos generales
        /// <summary>
        /// MUESTRA FORMULARIO DE SELECCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Calendario_Click(object sender, EventArgs e)
        {
            using (var calendarForm = new CALENDARIO())
            {
                calendarForm.ControlInvocador = this;
                // Determinar si el botón está dentro de un control llamado "dateTimePicker_Antiguedad"
                Control currentParent = this;
                while (currentParent != null)
                {
                    // Verificar si el padre es el control deseado
                    if (currentParent.Name == "dateTimePicker_Antiguedad")
                    {
                        calendarForm.Text = "FECHA DE INGRESO"; // Cambiar el título
                        break;
                    }
                    currentParent = currentParent.Parent; // Subir en la jerarquía
                }

                // Posicionar el formulario debajo del control
                Point parentPosition = this.Parent.PointToScreen(this.Location);
                int formX = parentPosition.X + (this.Width / 2) - (calendarForm.Width / 2);
                int formY = parentPosition.Y + this.Height + 3;

                calendarForm.StartPosition = FormStartPosition.Manual;
                calendarForm.Location = new Point(formX, formY);

                // Mostrar el formulario y manejar la selección
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = calendarForm.SelectedDate;

                    textBox_DateDIA.TextValue = selectedDate.Day.ToString("00");
                    textBox_DateMES.TextValue = selectedDate.Month.ToString("00");
                    textBox_DateAÑO.TextValue = selectedDate.Year.ToString();
                }
            }
        }

        /// <summary>
        /// USADO PARA CALCULAR ANTIGUEDAD EN AÑOS Y MESES
        /// </summary>
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

        public Control ControlInvocador { get; set; }

        public string TextoAsociado { get; set; }

        /// <summary>
        /// METODO PARA PODER BORRAR LOS DATOS DE LOS TEXTBOX
        /// </summary>
        public void ClearDate()
        {
            textBox_DateDIA.Clear();
            textBox_DateMES.Clear();
            textBox_DateAÑO.Clear();
        }


       
        //---------------------------------------------------------------------------

        private void ManejarAutocompletadoYNavegacion(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Evita el comportamiento predeterminado de Enter o Tab

                if (sender is CustomTextBox textBox)
                {
                    // Aplicar autocompletado al TextBox actual
                    TextBox_Autocompletar(textBox);

                    // Navegar entre los campos del CustomDate
                    if (textBox == textBox_DateDIA)
                    {
                        textBox_DateMES.Focus(); // Pasa al TextBox de Mes
                    }
                    else if (textBox == textBox_DateMES)
                    {
                        textBox_DateAÑO.Focus(); // Pasa al TextBox de Año
                    }
                    else if (textBox == textBox_DateAÑO)
                    {
                        // Simula la pérdida de foco quitando el foco del control actual
                        this.Parent?.Focus(); // Establece el foco en el contenedor padre
                    }
                }
            }
        }





    }
}
#endregion