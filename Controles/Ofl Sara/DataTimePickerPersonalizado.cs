using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using Spire.Xls.Core;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Ofl_Sara
{

    public partial class TimePickerPersonalizado : UserControl
    {
        #region VARIABLES
        private Button Btn_Calendario; // Botón para abrir el formulario de calendario
        private DateTime fechaSeleccionada;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private readonly Color focusColor = Color.Blue;
        private readonly Color errorColor = Color.Red;
        internal DateTime SelectedDate;

        #endregion


        #region CONSTRUCTOR
        public TimePickerPersonalizado()
        {
            InitializeComponent();
            this.Load += TimePickerPersonalizado_Load;

            ConfigurarTooltips();
            ConfigurarTextBoxes();
            CargarFechaActual();
        }
        #endregion
        private void TimePickerPersonalizado_Load(object sender, EventArgs e)
        {
            CargarFechaActual();
        }

        #region PROPIEDADES PUBLICAS
        // Propiedades para configurar el rango de años
        public int AñoMinimo { get; set; } = 1930;
        public int AñoMaximo { get; set; } = DateTime.Now.Year;
        public Color SubrayadoGeneralFocusColor { get; set; } = Color.Blue;
        public Color SubrayadoGeneralErrorColor { get; set; } = Color.Red;
        public DateTime FechaSeleccionada
        {
            get => fechaSeleccionada;
            set
            {
                fechaSeleccionada = value;
            }
        }

        public bool HasValue()
        {
            return ValidarCampos();
        }
        #endregion



        /// <summary>
        /// ABRIR CALENDARIO PARA SELECCIONAR FECHA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Calendario_Click(object sender, EventArgs e)
        {
            FocusControl();

            var controlPos = this.PointToScreen(Point.Empty); // Obtiene la posición del control en la pantalla
            using var calendarForm = new CALENDARIO();
            calendarForm.StartPosition = FormStartPosition.Manual;
            calendarForm.Location = new Point(
             controlPos.X + (this.Width / 2) - (calendarForm.Width / 2),
             controlPos.Y + (this.Height / 2) - (calendarForm.Height / 2)
             );

            if (calendarForm.ShowDialog() == DialogResult.OK)
            {
                _ = calendarForm.SelectedDate;

            }
        }
        private void RemoveFocus()
        {
            isFocused = false;
            showError = false;
            this.Invalidate();
        }

        /// <summary>
        /// INICIAR ANIMACION DE SUBRAYADO
        /// </summary>
        private void StartAnimation()
        {
            animationProgress = 0;

            if (animationTimer == null)
            {
                animationTimer = new Timer { Interval = 15 };
                animationTimer.Tick += (s, e) =>
                {
                    if (animationProgress < 100)
                    {
                        animationProgress += 5;
                        this.Invalidate();
                    }
                    else
                    {
                        animationTimer.Stop();
                    }
                };
            }

            animationTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color underlineColor = showError ? errorColor : (isFocused ? focusColor : this.BackColor);
            using Brush brush = new SolidBrush(underlineColor);
            int lineWidth = 3;
            float progress = animationProgress / 100f;
            int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
            int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
            e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
        }

        private void OnCustomPaint(object sender, PaintEventArgs e)
        {
            this.Invalidate();
        }

        private void FocusControl()
        {
            isFocused = true;
            showError = false;
            StartAnimation();
        }

        /// <summary>
        /// CONFIGURAR PROPIEDADES DE TEXTBOX
        /// </summary>
        private void ConfigurarTextBoxes()
        {
            // Limitar la cantidad de caracteres en los TextBoxes
            textBox_DIA.MaxLength = 2;
            textBox_MES.MaxLength = 2;
            textBox_AÑO.MaxLength = 4;

            //indices para la recorrida de tab
            textBox_DIA.TabIndex = 0;
            textBox_MES.TabIndex = 1;
            textBox_AÑO.TabIndex = 2;



            // Asociar eventos de cambio de texto para cálculos (como antigüedad o validación)
            textBox_DIA.TextChanged += CamposFecha_TextChanged;
            textBox_MES.TextChanged += CamposFecha_TextChanged;
            textBox_AÑO.TextChanged += CamposFecha_TextChanged;

            // Validar que solo se permitan números
            textBox_DIA.KeyPress += TextBox_KeyPress;
            textBox_MES.KeyPress += TextBox_KeyPress;
            textBox_AÑO.KeyPress += TextBox_KeyPress;

            //autocompleta y pasa al textbox siguiente
            textBox_DIA.KeyDown += TextBox_KeyDown;
            textBox_MES.KeyDown += TextBox_KeyDown;
            textBox_AÑO.KeyDown += TextBox_KeyDown;

            //autocompleta al perder el foco
            textBox_DIA.KeyPress += TextBox_Leave;
            textBox_MES.KeyPress += TextBox_Leave;
            textBox_AÑO.KeyPress += TextBox_Leave;

            // Asociar el evento Leave para el autocompletado al perder el foco
            textBox_DIA.Leave += (s, e) => TextBox_Autocompletar(s as TextBox);
            textBox_MES.Leave += (s, e) => TextBox_Autocompletar(s as TextBox);
            textBox_AÑO.Leave += (s, e) => TextBox_Autocompletar(s as TextBox);


            // Asociar el evento KeyDown para autocompletar y navegación
            textBox_DIA.KeyDown += ManejarAutocompletadoYNavegacion;
            textBox_MES.KeyDown += ManejarAutocompletadoYNavegacion;
            textBox_AÑO.KeyDown += ManejarAutocompletadoYNavegacion;




            textBox_DIA.Leave += (s, e) => RemoveFocus();
            textBox_MES.Leave += (s, e) => RemoveFocus();
            textBox_AÑO.Leave += (s, e) => RemoveFocus();
            Btn_Calendario.Leave += (s, e) => RemoveFocus();
        }

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
        /// <summary>
        /// evento PARA CUANDO SE PRESIONA TECLA ENTER O TAB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && sender is TextBox textBox)
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
            if (sender is TextBox textBox)
            {
                TextBox_Autocompletar(textBox); // Llamar al método de autocompletado al perder foco
            }
        }

        /// <summary>
        /// METODO PARA AUTOCOMPLETAR DIA Y MES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBox_Autocompletar(TextBox textBox)
        {
            if (textBox == textBox_DIA || textBox == textBox_MES)
            {
                if (textBox.Text.Length == 1)
                {
                    textBox.Text = "0" + textBox.Text; // Agrega un 0 a la izquierda
                }
            }
            else if (textBox == textBox_AÑO)
            {
                if (textBox.Text.Length == 2)
                {
                    int enteredYear = int.Parse(textBox.Text);
                    int currentYearLastTwoDigits = DateTime.Now.Year % 100;

                    if (enteredYear <= currentYearLastTwoDigits)
                    {
                        textBox.Text = "20" + textBox.Text; // Completa con "20" a la izquierda
                    }
                    else
                    {
                        textBox.Text = "19" + textBox.Text; // Completa con "19" a la izquierda
                    }
                }
                else if (textBox.Text.Length == 1)
                {
                    ValidarCampo("Año", textBox_AÑO.Text, AñoMinimo, AñoMaximo, textBox_AÑO);

                    textBox.Focus();
                }
            }
        }

        /// <summary>
        /// PARAMETROS DE VALIDACION 
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            return ValidarCampo("Día", textBox_DIA.Text, 1, 31, textBox_DIA) &&
                   ValidarCampo("Mes", textBox_MES.Text, 1, 12, textBox_MES) &&
                   ValidarCampo("Año", textBox_AÑO.Text, AñoMinimo, AñoMaximo, textBox_AÑO);
        }

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
                    if (this.Name == "dateTimePicker_Antiguedad" || this.Name == "dateTimePicker_FechaNacimiento")
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



                            return;
                        }

                    }


                }
            }

            // Actualizar estado visual del subrayado general
            // showError = HasAnyError();
            Invalidate();
        }

        /// <summary>
        /// METODO PARA VALIDAR PARAMETROS DE CAMPOS
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="valorTexto"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static bool ValidarCampo(string campo, string valorTexto, int min, int max, TextBox textBox)
        {
            if (int.TryParse(valorTexto, out int valor))
            {
                if (valor < min || valor > max)
                {
                    // Crear una instancia del formulario sin mostrarlo aún
                    using var form = new MensajeGeneral($"{campo} debe estar entre {min} y {max}.", MensajeGeneral.TipoMensaje.Advertencia);
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
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// METODO QUE AGRUPA LOS TOOLTIPS DEL CONTROL
        /// </summary>
        private void ConfigurarTooltips()
        {
            ToolTipGeneral.Mostrar(Btn_Calendario, "Seleccione fecha.");
            ToolTipGeneral.Mostrar(textBox_DIA, "Ingrese DÍA.");
            ToolTipGeneral.Mostrar(textBox_MES, "Ingrese MES.");
            ToolTipGeneral.Mostrar(textBox_AÑO, "Ingrese AÑO.");
        }
        private void ManejarAutocompletadoYNavegacion(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Evita el comportamiento predeterminado de Enter o Tab

                if (sender is TextBox textBox)
                {


                    // Navegar entre los campos del CustomDate
                    if (textBox == textBox_DIA)
                    {
                        textBox_MES.Focus(); // Pasa al TextBox de Mes
                    }
                    else if (textBox == textBox_MES)
                    {
                        textBox_AÑO.Focus(); // Pasa al TextBox de Año
                    }
                    else if (textBox == textBox_AÑO)
                    {
                        // Simula la pérdida de foco quitando el foco del control actual
                        this.Parent?.Focus(); // Establece el foco en el contenedor padre
                    }
                }
            }
        }
        /// <summary>
        /// OBTIENE FECHA SELECCIONADA EN FORMULARIO Y LA MUESTRA EN LOS CAMPOS
        /// </summary>
        /// <returns></returns>
        public DateTime? ObtenerFecha()
        {
            if (ValidarCampos() &&
                int.TryParse(textBox_DIA.Text, out int dia) &&
                int.TryParse(textBox_MES.Text, out int mes) &&
                int.TryParse(textBox_AÑO.Text, out int año))
            {
                return new DateTime(año, mes, dia);
            }
            return null;
        }

        private void TextBox_MES_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBoxMes)
            {
                // Crear una instancia del formulario SelectorCalendario
                SelectorCalendario selector = new(textBoxMes);

                // Calcular la posición del control en la pantalla
                Point screenPoint = textBoxMes.PointToScreen(Point.Empty);

                // Ajustar la posición del formulario SelectorCalendario
                selector.StartPosition = FormStartPosition.Manual;
                selector.Location = new Point(
                    screenPoint.X + (textBoxMes.Width - selector.Width) / 2, // Centrar horizontalmente
                    screenPoint.Y - selector.Height - 3 // 3px por encima del control
                );

                // Mostrar el formulario
                selector.Show();
            }
        }
        private void CargarFechaActual()
        {
            DateTime fechaActual = DateTime.Now;

            textBox_DIA.Text = fechaActual.Day.ToString("00"); // Día con dos dígitos
            textBox_MES.Text = fechaActual.ToString("MMMM").ToUpper(); // Nombre del mes en mayúsculas
            textBox_AÑO.Text = fechaActual.Year.ToString();
        }

        private void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            FocusControl();
        }
    }
}
