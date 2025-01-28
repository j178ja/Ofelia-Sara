using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static iText.Commons.Utils.PlaceHolderTextUtil;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    [Designer(typeof(ResizableControlDesigner))] // Permitir ajustes en el diseñador
    public partial class NumeroTelefonicoControl : UserControl
    {
        private bool isPlaceholderActive;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;
        public NumeroTelefonicoControl()
        {
            InitializeComponent();
            animationTimer = new Timer
            {
                Interval = 15 // Intervalo para la animación
            };
            animationTimer.Tick += AnimationTimer_Tick;
            CustomNumeroTelefonicoControl_Load(this, EventArgs.Empty);

            SetStyle(ControlStyles.ResizeRedraw, true); // Habilitar redibujado en redimensionamiento
        }

        // Sobreescribir el evento OnResize para ajustar el comportamiento al redimensionar
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Forzar redibujado
        }
        internal class ResizableControlDesigner : ControlDesigner
        {
            public override SelectionRules SelectionRules
            {
                get
                {
                    // Permitir mover y redimensionar en todas las direcciones
                    return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.AllSizeable;
                }
            }
        }
        // Propiedad para ajustar el ancho del control

        public int ControlWidth
        {
            get { return this.Width; }
            set
            {
                this.Width = value;

            }
        }

        private void CustomNumeroTelefonicoControl_Load(object sender, EventArgs e)
        {
            SetPlaceholder(maskedTextBox_Telefono, "02254000000000");
        }

        private void SetPlaceholder(MaskedTextBox maskedTextBox, string placeholder)
        {
            isPlaceholderActive = true;
            maskedTextBox.Text = placeholder;
            maskedTextBox.ForeColor = Color.Gray;

            maskedTextBox.Enter += (sender, e) =>
            {
                if (isPlaceholderActive)
                {
                    maskedTextBox.Text = ""; // Borra el placeholder
                    maskedTextBox.ForeColor = Color.Black; // Cambia el color del texto
                    isPlaceholderActive = false;
                }

                // Asegura que el cursor esté al inicio
                maskedTextBox.BeginInvoke(new Action(() =>
                {
                    maskedTextBox.SelectionStart = 0;
                }));

                // Cambia el estado al enfocado
                isFocused = true;
                showError = false; // Oculta error al enfocar
                animationProgress = 0; // Reinicia la animación
                animationTimer.Start();
                Invalidate(); // Fuerza el redibujado
            };

            maskedTextBox.Leave += (sender, e) =>
            {
                // Configura el formato de texto sin literales para la validación
                maskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
                {
                    // Reactiva el placeholder si el texto está vacío
                    isPlaceholderActive = true;
                    maskedTextBox.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // Vuelve a incluir literales
                    maskedTextBox.Text = placeholder;
                    maskedTextBox.ForeColor = Color.Gray;
                    showError = true; // Activa el subrayado rojo
                }
                else
                {
                    // El texto es válido
                    showError = false;
                }

                // Cambia el estado a desenfocado
                isFocused = false;
                animationProgress = 0; // Reinicia la animación
                animationTimer.Start();
                Invalidate(); // Fuerza el redibujado
            };
        }



        public void RestorePlaceholders()
        {
            SetPlaceholder(maskedTextBox_Telefono, "02254000000000");
        }

        public void ClearTelefonoFields()
        {
            maskedTextBox_Telefono.Clear();
            RestorePlaceholders();
        }

        private void NumeroTelefonicoControl_Load(object sender, EventArgs e)
        {

        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100); // Incremento gradual
            this.Invalidate(); // Forza el redibujado
            if (animationProgress == 100)
            {
                animationTimer.Stop(); // Detén el Timer al completar la animación
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Determina el color según el estado
            using (Brush brush = new SolidBrush(isFocused ? focusColor : (showError ? errorColor : this.BackColor)))
            {
                int lineWidth = 3; // Ancho de la línea
                float progress = animationProgress / 100f;
                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);

                // Dibuja la línea
                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth-2/*para que quede mas pegado al masqued*/, endX - startX, lineWidth);
            }
        }


    }
}
