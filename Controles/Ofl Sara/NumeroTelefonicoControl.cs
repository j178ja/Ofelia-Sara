using Ofelia_Sara.Controles.General;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static iText.Commons.Utils.PlaceHolderTextUtil;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
        #region VARIABLES
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
            #endregion
        #region CONSTRUCTOR
            public NumeroTelefonicoControl()
            {
                InitializeComponent();
                animationTimer = new Timer
                {
                    Interval = 15 // Intervalo para la animación
                };
                animationTimer.Tick += AnimationTimer_Tick;
                NumeroTelefonicoControl_Load(this, EventArgs.Empty);

                SetStyle(ControlStyles.ResizeRedraw, true); // Habilitar redibujado en redimensionamiento
            }
        #endregion
        #region LOAD
        private void NumeroTelefonicoControl_Load(object sender, EventArgs e)
        {
            SetPlaceholder(maskedTextBox_Telefono, "02254000000000");

        }
        #endregion
        /// <summary>
        /// Sobreescribir el evento OnResize para ajustar el comportamiento al redimensionar
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// Propiedad para ajustar el ancho del control
        /// </summary>
        public int ControlWidth
        {
            get { return this.Width; }
            set
            {
                this.Width = value;

            }
        }

        #region VALIDACIONES Y METODOS
        /// <summary>
        /// VALIDAR CAMPO PARA ASEGURARSE QUE TENGA 10 CARACTERES MINIMOS
        /// </summary>
        private void ValidarLongitudCampo(MaskedTextBox maskedTextBox)
        {
            if (maskedTextBox.Text.Length < 10)
            {
                showError = true; // Mostrar subrayado rojo
            }
            else
            {
                showError = false; // Ocultar error
            }
            Invalidate(); // Forzar redibujado del control
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
                    maskedTextBox.Text = "";
                    maskedTextBox.ForeColor = Color.Black;
                    isPlaceholderActive = false;
                }

                // Asegurar cursor al inicio
                maskedTextBox.BeginInvoke(new Action(() => maskedTextBox.SelectionStart = 0));

                // Cambiar estado visual
                isFocused = true;
                showError = false;
                animationProgress = 0;
                animationTimer.Start();
                Invalidate();
            };

            maskedTextBox.Leave += (sender, e) =>
            {
                // Excluir literales para obtener solo números
                maskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                ValidarLongitudCampo(maskedTextBox);

                // Restaurar formato si está vacío
                if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
                {
                    isPlaceholderActive = true;
                    maskedTextBox.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    maskedTextBox.Text = placeholder;
                    maskedTextBox.ForeColor = Color.Gray;
                }

                isFocused = false;
                animationProgress = 0;
                animationTimer.Start();
                Invalidate();
            };
        }

        /// <summary>
        /// RESTAURAR PLACEHOLDER
        /// </summary>
        public void RestorePlaceholders()
        {
            SetPlaceholder(maskedTextBox_Telefono, "02254000000000");
        }
        /// <summary>
        /// LIMPIAR CONTROL
        /// </summary>
        public void ClearTelefonoFields()
        {
            maskedTextBox_Telefono.Clear();
            RestorePlaceholders();
        }
        #endregion

        #region ANIMACION SUBRAYADO
        /// <summary>
        /// TIMER PARA ANIMACION 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100); // Incremento gradual
            this.Invalidate(); // Forza el redibujado
            if (animationProgress == 100)
            {
                animationTimer.Stop(); // Detén el Timer al completar la animación
            }
        }

/// <summary>
/// MEDO PARA EL SUBRAYADO
/// </summary>
/// <param name="e"></param>
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
#endregion