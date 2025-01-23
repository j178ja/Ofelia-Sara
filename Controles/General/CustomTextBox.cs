using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.General
{
    public partial class CustomTextBox : Control
    {
        private TextBox textBox;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;
        private string placeholderText = string.Empty;
        private Color placeholderColor = Color.Gray;
        public CustomTextBox()
        {
            // Configuración del TextBox

            textBox = new TextBox
            {
                Size = new Size(21, this.Height),
                BorderStyle = BorderStyle.None,
            
                TextAlign = HorizontalAlignment.Center,
                BackColor = Color.White, // color provisorio para analizar errores
                ForeColor = this.ForeColor,

            };
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            textBox.TextChanged += TextBox_TextChanged;
            Controls.Add(textBox);

            // Configuración del Timer para animaciones
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            // Estilo inicial
            this.Height = 30;
            this.Width = 200;
            this.BackColor = Color.White;
        }

        // Propiedad para exponer el TextBox interno
        public TextBox InnerTextBox => textBox;

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            isFocused = true;
            showError = false; // Quita el subrayado rojo si estaba activo
            animationProgress = 0; // Reinicia la animación
            animationTimer.Start();

            Invalidate(); // Redibuja el control
        }


        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            isFocused = false;

            // Verifica si el texto está vacío para activar el subrayado rojo
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                showError = true; // Activa el subrayado rojo
            }
            else
            {
                showError = false; // Desactiva el subrayado rojo
            }

            animationProgress = 0; // Reinicia la animación
            animationTimer.Start();

            Invalidate(); // Redibuja el control para reflejar los cambios
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100);
            this.Invalidate();
            if (animationProgress == 100) animationTimer.Stop();
        }

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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush brush = new SolidBrush(isFocused ? focusColor : (showError ? errorColor : this.BackColor)))
            {
                int lineWidth = 3;
                float progress = animationProgress / 100f;
                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
            }

            // Si el control está vacío y no tiene foco, muestra el placeholder
            if (string.IsNullOrEmpty(this.Text) && !this.Focused && !string.IsNullOrEmpty(PlaceholderText))
            {
                using (Brush brush = new SolidBrush(PlaceholderColor))
                {
                    e.Graphics.DrawString(PlaceholderText, this.Font, brush, new PointF(1, 1));
                }
            }
        }

        // Propiedades Públicas
        public string TextValue
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public bool ShowError
        {
            get => showError;
            set
            {
                showError = value;
                this.Invalidate();
            }
        }

        public Color FocusColor
        {
            get => focusColor;
            set => focusColor = value;
        }

        public Color ErrorColor
        {
            get => errorColor;
            set => errorColor = value;
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



        // Propiedad para TextAlign
        public HorizontalAlignment TextAlign
        {
            get => textBox.TextAlign;
            set => textBox.TextAlign = value;
        }

        // Propiedad para Multiline
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
        // Propiedad para acceder a SelectionStart
        public int SelectionStart
        {
            get => textBox.SelectionStart;
            set => textBox.SelectionStart = value;
        }

        // Método para limpiar el texto
        public void Clear()
        {
            textBox.Clear();
        }

        // Propiedad para ReadOnly
        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        // Propiedad para PasswordChar
        public char PasswordChar
        {
            get => textBox.PasswordChar;
            set => textBox.PasswordChar = value;
        }

        // Propiedad AutoCompleteSource
        public AutoCompleteSource AutoCompleteSource
        {
            get => textBox.AutoCompleteSource;
            set => textBox.AutoCompleteSource = value;
        }

        // Propiedad para MaxLength
        public int MaxLength
        {
            get => textBox.MaxLength;
            set => textBox.MaxLength = value;
        }

        // Propiedad AutoCompleteMode
        public AutoCompleteMode AutoCompleteMode
        {
            get => textBox.AutoCompleteMode;
            set => textBox.AutoCompleteMode = value;
        }

        // Propiedad AutoCompleteCustomSource
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => textBox.AutoCompleteCustomSource;
            set => textBox.AutoCompleteCustomSource = value;
        }
    }
}
