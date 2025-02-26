using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.General
{
    //public partial class CustomTextBox : Control
    //{
    //    #region VARIABLES
    //    private TextBox textBox;
    //private Timer animationTimer;
    //private int animationProgress;
    //private bool isFocused;
    //private bool showError;
    //private Color focusColor = Color.Blue;
    //private Color errorColor = Color.Red;
    //private string placeholderText = string.Empty;
    //private Color placeholderColor = Color.Gray;
    //private bool isPlaceholderVisible;
    //#endregion

    //    #region CONSTRUCTOR
    //    public CustomTextBox()
    //    {
    //        // Configuración del TextBox
    //        textBox = new TextBox
    //        {
    //            Size = new Size(21, this.Height),
    //            BorderStyle = BorderStyle.None,

    //            TextAlign = HorizontalAlignment.Center,
    //            BackColor = Color.White, // color provisorio para analizar errores
    //            ForeColor = this.ForeColor,

    //        };
    //        textBox.GotFocus += TextBox_GotFocus;
    //        textBox.LostFocus += TextBox_LostFocus;
    //        textBox.TextChanged += TextBox_TextChanged;
    //        Controls.Add(textBox);

    //        // Configuración del Timer para animaciones
    //        animationTimer = new Timer { Interval = 15 };
    //        animationTimer.Tick += AnimationTimer_Tick;

    //        // Estilo inicial
    //        this.Height = 30;
    //        this.Width = 200;
    //        this.BackColor = Color.White;
    //    }
    //    #endregion

    //    #region VALIDACIONES Y METODOS
    //    private void TextBox_GotFocus(object sender, EventArgs e)
    //    {
    //        isFocused = true;
    //        showError = false; // Quita el subrayado rojo si estaba activo
    //        animationProgress = 0; // Reinicia la animación
    //        animationTimer.Start();

    //        Invalidate(); // Redibuja el control
    //    }

    //    /// <summary>
    //    /// COMPORTAMIENTO CUANDO PIERDE EL FOCO
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void TextBox_LostFocus(object sender, EventArgs e)
    //    {
    //        isFocused = false;

    //        // Verifica si el texto está vacío para activar el subrayado rojo
    //        if (string.IsNullOrWhiteSpace(textBox.Text))
    //        {
    //            showError = true; // Activa el subrayado rojo
    //        }
    //        else
    //        {
    //            showError = false; // Desactiva el subrayado rojo
    //        }

    //        animationProgress = 0; // Reinicia la animación
    //        animationTimer.Start();

    //        Invalidate(); // Redibuja el control para reflejar los cambios
    //    }
    //    private void TextBox_TextChanged(object sender, EventArgs e)
    //    {
    //        OnTextChanged(e);
    //    }
    //    private void AnimationTimer_Tick(object sender, EventArgs e)
    //    {
    //        animationProgress = Math.Min(animationProgress + 5, 100);
    //        this.Invalidate();
    //        if (animationProgress == 100) animationTimer.Stop();
    //    }
    //    protected override void OnResize(EventArgs e)
    //    {
    //        base.OnResize(e);

    //        // Calcula la altura ajustada del TextBox para adaptarlo al control
    //        int textBoxHeight = (int)(this.Height * 0.9); // El TextBox ocupa el 80% de la altura del control
    //        int verticalPadding = (this.Height - textBoxHeight) / 2; // Espaciado vertical para centrar el TextBox

    //        // Ajusta las dimensiones y posición del TextBox dentro del control
    //        textBox.SetBounds(
    //            5,                   // Margen izquierdo
    //            verticalPadding,     // Margen superior
    //            this.Width - 10,     // Ancho ajustado (control - márgenes)
    //            textBoxHeight        // Altura ajustada
    //        );
    //    }
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        base.OnPaint(e);
    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //        using (Brush brush = new SolidBrush(isFocused ? focusColor : (showError ? errorColor : this.BackColor)))
    //        {
    //            int lineWidth = 3;
    //            float progress = animationProgress / 100f;
    //            int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
    //            int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
    //            e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
    //        }

    //        // Si el control está vacío y no tiene foco, muestra el placeholder
    //        if (string.IsNullOrEmpty(this.Text) && !this.Focused && !string.IsNullOrEmpty(PlaceholderText))
    //        {
    //            using (Brush brush = new SolidBrush(PlaceholderColor))
    //            {
    //                e.Graphics.DrawString(PlaceholderText, this.Font, brush, new PointF(1, 1));
    //            }
    //        }
    //    }


    //    #endregion

    public partial class CustomTextBox : Control
    {
        #region VARIABLES
        private TextBox textBox;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private bool isValidText; // Nuevo indicador de validación
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;
        private Color validColor = Color.LightGreen; // Nuevo color para texto válido
        private string placeholderText = string.Empty;
        private Color placeholderColor = Color.Gray;
        
        private bool isPlaceholderVisible;
        #endregion

        #region CONSTRUCTOR
        public CustomTextBox()
        {
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ForeColor = this.ForeColor,
                TextAlign = HorizontalAlignment.Center
            };

            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            textBox.TextChanged += TextBox_TextChanged;
            Controls.Add(textBox);

            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            this.Height = 21;
            this.Width = 200;
            this.BackColor = Color.White;
        }
        #endregion

        #region EVENTOS
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            isFocused = true;
            showError = false;
            animationProgress = 0;
            animationTimer.Start();
            Invalidate();
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            isFocused = false;
            ValidateText(); // Se valida al perder el foco
            animationProgress = 0;
            animationTimer.Start();
            Invalidate();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateText();
            OnTextChanged(e);
            Invalidate();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100);
            Invalidate();
            if (animationProgress == 100) animationTimer.Stop();
        }
        #endregion

        #region MÉTODOS
        private void ValidateText()
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                showError = true;
               // isValidText = false;
            }
            else
            {
                showError = false;
                //isValidText = EsTextoValido(textBox.Text);
            }
        }

        //private bool EsTextoValido(string texto)
        //{
        //    // Ejemplo de validación: acepta solo letras y espacios, y debe tener al menos 3 caracteres
        //    return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z\s]{3,}$");
        //}
        #endregion

        #region DIBUJADO
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color underlineColor = isFocused ? focusColor :
                                   showError ? errorColor :
                                  // isValidText ? validColor :
                                   this.BackColor;

            using (Brush brush = new SolidBrush(underlineColor))
            {
                int lineWidth = 3;
                float progress = animationProgress / 100f;
                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
            }

           // Placeholder
            if (string.IsNullOrEmpty(textBox.Text) && !textBox.Focused && !string.IsNullOrEmpty(PlaceholderText))
            {
                using Brush brush = new SolidBrush(PlaceholderColor);
                e.Graphics.DrawString(PlaceholderText, this.Font, brush, new PointF(5, 5));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Calcula la altura ajustada del TextBox para adaptarlo al control
            int textBoxHeight = (int)(this.Height * 0.9); // El TextBox ocupa el 80% de la altura del control
            int verticalPadding = (this.Height - textBoxHeight) / 2; // Espaciado vertical para centrar el TextBox

            // Ajusta las dimensiones y posición del TextBox dentro del control
            textBox.SetBounds(
                5,                   // Margen izquierdo
                verticalPadding,     // Margen superior
                this.Width - 10,     // Ancho ajustado (control - márgenes)
                textBoxHeight        // Altura ajustada
            );
        }
        #endregion

        #region PROPIEDADES PUBLICAS 
        /// <summary>
        /// PROPIEDADES PLACEHOLDER
        /// </summary>
        /// <param name="e"></param>

        [Category("Custom Properties")]
        [Description("The text displayed as a placeholder.")]
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                Invalidate(); // Redibuja el control
            }
        }

        [Category("Custom Properties")]
        [Description("The color of the placeholder text.")]
        public Color PlaceholderColor
        {
            get => placeholderColor;
            set
            {
                placeholderColor = value;
                Invalidate(); // Redibuja el control
            }
        }

        /// <summary>
        /// Propiedad para exponer el TextBox interno
        /// </summary>
        public TextBox InnerTextBox => textBox;

        /// <summary>
        /// ACCEDE A TEXTO DE TEXBOX INTERNO
        /// </summary>
        public string TextValue
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        /// <summary>
        /// propiedad para indicar error/subrayado rojo
        /// </summary>
        public bool ShowError
        {
            get => showError;
            set
            {
                showError = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// dar foco y activar subrayado azul
        /// </summary>
        public Color FocusColor
        {
            get => focusColor;
            set => focusColor = value;
        }

        /// <summary>
        /// subrayado rojo
        /// </summary>
        public Color ErrorColor
        {
            get => errorColor;
            set => errorColor = value;
        }

        /// <summary>
        /// PARA ALINEAR
        /// </summary>
        public HorizontalAlignment TextAlign
        {
            get => textBox.TextAlign;
            set => textBox.TextAlign = value;
        }

        /// <summary>
        /// Propiedad para Multiline
        /// </summary>
        public bool Multiline
        {
            get => textBox.Multiline;
            set
            {
                textBox.Multiline = value;
                // Ajustar altura si es multiline
                if (value)
                {
                    textBox.Height = this.Height - 10;
                }
            }
        }

        /// <summary>
        /// acceder a SelectionStart
        /// </summary>
        public int SelectionStart
        {
            get => textBox.SelectionStart;
            set => textBox.SelectionStart = value;
        }

        /// <summary>
        /// limpiar el texto
        /// </summary>
        public void Clear()
        {
            textBox.Clear();
        }

        /// <summary>
        /// ReadOnly
        /// </summary>
        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        /// <summary>
        ///  Propiedad para PasswordChar
        /// </summary>
        public char PasswordChar
        {
            get => textBox.PasswordChar;
            set => textBox.PasswordChar = value;
        }

        /// <summary>
        /// Propiedad AutoCompleteSource
        /// </summary>
        public AutoCompleteSource AutoCompleteSource
        {
            get => textBox.AutoCompleteSource;
            set => textBox.AutoCompleteSource = value;
        }

        /// <summary>
        /// Propiedad para MaxLength
        /// </summary>
        public int MaxLength
        {
            get => textBox.MaxLength;
            set => textBox.MaxLength = value;
        }

        /// <summary>
        ///  Propiedad AutoCompleteMode
        /// </summary>
        public AutoCompleteMode AutoCompleteMode
        {
            get => textBox.AutoCompleteMode;
            set => textBox.AutoCompleteMode = value;
        }

        /// <summary>
        /// Propiedad AutoCompleteCustomSource
        /// </summary>
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => textBox.AutoCompleteCustomSource;
            set => textBox.AutoCompleteCustomSource = value;
        }

        /// <summary>
        /// Evento para TextChanged
        /// </summary>
        public new event EventHandler TextChanged
        {
            add => textBox.TextChanged += value;
            remove => textBox.TextChanged -= value;
        }

        /// <summary>
        /// PROPIEDAD KEYPRESS
        /// </summary>
        public new event KeyPressEventHandler KeyPress
        {
            add => textBox.KeyPress += value; // textBox es el InnerTextBox
            remove => textBox.KeyPress -= value;
        }

        /// <summary>
        /// RESTAURA PLACEHOLDER
        /// </summary>
        public void RestorePlaceholders()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = PlaceholderText;
                this.ForeColor = PlaceholderColor;
                isPlaceholderVisible = true;
            }
        }

        /// <summary>
        /// Método para quitar el placeholder
        /// </summary>
        public void RemovePlaceholder()
        {
            if (isPlaceholderVisible)
            {
                this.Text = string.Empty;
                this.ForeColor = Color.Black; // Ajusta el color según sea necesario
                isPlaceholderVisible = false;
            }
        }
        

        public int Whidth { get; set; }
        public new int Height { get; set; }
        public bool ShortcutsEnabled { get; internal set; }
    }
}
#endregion
