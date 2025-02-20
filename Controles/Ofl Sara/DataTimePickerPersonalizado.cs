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
        // Propiedad para acceder al control del TimePicker

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
            calendarForm.Text = "SELECCIONE FECHA"; //cambia el indicador del formulario a mostrar al usuario
            calendarForm.StartPosition = FormStartPosition.Manual;
            calendarForm.Location = new Point(
             controlPos.X + (this.Width / 2) - (calendarForm.Width / 2),
             controlPos.Y + (this.Height / 2) - (calendarForm.Height / 2)
             );
            // Mostrar el formulario y manejar la selección
            if (calendarForm.ShowDialog() == DialogResult.OK)
            {
                DateTime selectedDate = calendarForm.SelectedDate;

                ActualizarConFecha(selectedDate);
            }
        }
        private void RemoveFocus()
        {
            isFocused = false;

            // Validar campos y actualizar showError si hay un error
            if (!ValidarCampos())
            {
                showError = true;
            }

            this.Invalidate(); // Redibuja el control si es necesario
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
            textBox_AÑO.MaxLength = 4;

            //indices para la recorrida de tab
            textBox_DIA.TabIndex = 0;
            textBox_MES.TabIndex = 1;
            textBox_AÑO.TabIndex = 2;

            //// Asociar el evento Leave para el autocompletado al perder el foco
            //textBox_DIA.Leave += (s, e) => TextBox_Autocompletar(s as TextBox);
            //textBox_MES.Leave += (s, e) => TextBox_Autocompletar(s as TextBox);
            //textBox_AÑO.Leave += (s, e) => TextBox_Autocompletar(s as TextBox);

            // Asociar el evento KeyDown para autocompletar y navegación
            textBox_DIA.KeyDown += ManejarAutocompletadoYNavegacion;
            textBox_MES.KeyDown += ManejarAutocompletadoYNavegacion;
            textBox_AÑO.KeyDown += ManejarAutocompletadoYNavegacion;

            //para remover el foco al salir del control
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
                // Llamar al método de autocompletado al perder foco
                TextBox_Autocompletar(textBox);

                // Validar campos
                ValidarCampos();

                // Si el TextBox está vacío, cambiar el fondo a rojo y devolver el foco
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.BackColor = Color.Red;
                    textBox.Focus();
                }
            }
        }





        private void TextBox_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            // Cuando el TextBox recibe el foco, cambia el color de fondo a blanco
            textBox.BackColor = Color.White;
        }

        /// <summary>
        /// METODO PARA AUTOCOMPLETAR DIA Y MES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Autocompletar(TextBox textBox)
        {
            if (textBox == textBox_DIA)
            {
                // Verificar si el texto tiene un solo carácter y no es "0"
                if (textBox.Text.Length == 1 && textBox.Text != "0")
                {
                    textBox.Text = "0" + textBox.Text; // Agrega un 0 a la izquierda
                }

                // Si el contenido es "0" o "00"
                if (textBox.Text == "0" || textBox.Text == "00")
                {
                    // Llama a la función de validación antes de limpiar el campo
                    ValidarCampos();

                    // Limpia el TextBox y vuelve a darle foco
                    textBox.Clear();
                    textBox.Focus();
                }
            }

            //autocompletar año o mostrar mensaje en caso de que no se pueda autocompletar
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
                else if (textBox.Text.Length == 1 || textBox.Text.Length == 3)
                {
                    ValidarCampos();
                }
            }
        }

        /// <summary>
        /// PARAMETROS DE VALIDACION 
        /// </summary>
        /// <returns></returns>
      
        private bool ValidarCampos()
        {
            bool isValid = true;

            // Validar cada campo y actualizar el estado de isValid
            if (!ValidarCampo("Día", textBox_DIA.Text, 1, 31, textBox_DIA))
                isValid = false;

            if (!ValidarCampo("Mes", textBox_MES.Text, 1, 12, textBox_MES))
                isValid = false;

            if (!ValidarCampo("Año", textBox_AÑO.Text, AñoMinimo, AñoMaximo, textBox_AÑO))
                isValid = false;

            // Si algún campo es inválido, marcar showError como true
            showError = !isValid;
            this.Invalidate();// forzar redibujado
            return isValid;
          
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

        /// <summary>
        /// crea una instancia de formulario SelectorCalendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                selector.ShowDialog();
            }
        }
        /// <summary>
        /// hace que no se pueda editar la seleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_MES_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Bloquea cualquier tecla presionada
        }
        private void CargarFechaActual()
        {
            DateTime fechaActual = DateTime.Now;

            textBox_DIA.Text = fechaActual.Day.ToString("00"); // Día con dos dígitos
            textBox_MES.Text = fechaActual.ToString("MMMM").ToUpper(); // Nombre del mes en mayúsculas
            textBox_AÑO.Text = fechaActual.Year.ToString();
        }
        
        /// <summary>
        /// Método para actualizar los TextBox con la fecha seleccionada
        /// </summary>
        /// <param name="selectedDate"></param>
        public void ActualizarConFecha(DateTime selectedDate)
        {
            // Asignar la fecha al DateTimePicker
            FechaSeleccionada = selectedDate;

            // Actualizar los TextBox con la fecha
            textBox_DIA.Text = selectedDate.Day.ToString("00"); // Día con dos dígitos (por ejemplo, 01)
            textBox_MES.Text = selectedDate.ToString("MMMM").ToUpper(); // Mes en nombre completo y en mayúsculas (por ejemplo, "FEBRERO")
            textBox_AÑO.Text = selectedDate.Year.ToString(); // Año
        }


        /// <summary>
        /// hacer que el control dateTimePicker tenga el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            FocusControl();
        }

       




        private void TextBox_DIA_TextChanged(object sender, EventArgs e)
        {
            // Validar solo después de 2 dígitos
            if (textBox_DIA.Text.Length == 2)
            {
                // Realiza la validación para asegurar que el día esté dentro del rango válido (1-31)
                if (int.TryParse(textBox_DIA.Text, out int diaValido) && (diaValido < 1 || diaValido > 31))
                {
                    textBox_DIA.BackColor = Color.Red;  // Color de error si está fuera de rango
                    textBox_DIA.ForeColor = Color.White;
                     ValidarCampos();
                 
                }
                else
                {
                    textBox_DIA.BackColor = Color.White; // Color normal si es válido
                    textBox_DIA.ForeColor = Color.Black;
                    ValidarCampos();
                    showError = false;
                    isFocused = true;
                    this.Invalidate();
                }
            }
        }
        private void TextBox_AÑO_TextChanged(object sender, EventArgs e)
        {
            // Validar solo después de 2 dígitos
            if (textBox_AÑO.Text.Length == 4)
            {
                // Realiza la validación para asegurar que el día esté dentro del rango válido (1-31)
                if (int.TryParse(textBox_AÑO.Text, out int añoValido) && (añoValido < AñoMinimo || añoValido > AñoMaximo))
                {
                    textBox_AÑO.BackColor = Color.Red;  // Color de error si está fuera de rango
                    textBox_AÑO.ForeColor = Color.White;
                    ValidarCampos();

                }
                else
                {
                    textBox_AÑO.BackColor = Color.White; // Color normal si es válido
                    textBox_AÑO.ForeColor = Color.Black;
                    ValidarCampos();
                    showError = false;
                    isFocused = true;
                    this.Invalidate();
                }
            }
        }



    }
}
