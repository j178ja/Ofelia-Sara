using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles
{
    public class CustomTextBox : Control
    {
        private TextBox textBox;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;

        public CustomTextBox()
        {
            // Configuración del TextBox
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(5, 5),
                Width = this.Width - 10,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                BackColor = this.BackColor,
                ForeColor = this.ForeColor
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

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            isFocused = true;
            showError = false;
            animationProgress = 0;
            animationTimer.Start();
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            isFocused = false;
            animationProgress = 0;
            animationTimer.Start();
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
            textBox.Width = this.Width - 10;
            textBox.Height = this.Height - 10;
        }
    }
}
