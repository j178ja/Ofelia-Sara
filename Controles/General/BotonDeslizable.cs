using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.General
{
    public partial class BotonDeslizable : UserControl
    {
        #region VARIABLES
        private bool isOn = false;
        private RectangleF sliderRect;
        private int sliderPadding = 4;
        private int cornerRadius = 3; // Ajuste de radio para bordes redondeados
        #endregion

        /// <summary>
        /// Delegado para validar los campos antes de cambiar el estado
        /// </summary>
        public Func<bool> ValidarCampos { get; set; }

        /// <summary>
        /// Evento para notificar cambios en el estado de IsOn
        /// </summary>
        public event EventHandler IsOnChanged;

        public BotonDeslizable()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            this.Size = new Size(40, 20); // Tamaño del control ajustado
            UpdateSliderRect();
        }

        public bool IsOn
        {
            get => isOn;
            set
            {
                if (isOn != value)
                {
                    isOn = value;
                    IsOnChanged?.Invoke(this, EventArgs.Empty); // Invocar evento de cambio
                    if (isOn) IsOnChanged?.Invoke(this, EventArgs.Empty); // Dispara el evento solo cuando se activa
                    UpdateSliderRect();
                    Invalidate(); // Redibuja el control para reflejar el nuevo estado
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar fondo redondeado
            using (SolidBrush backgroundBrush = new SolidBrush(isOn ? Color.Green : Color.Red))
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(sliderPadding, sliderPadding, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(this.Width - cornerRadius - sliderPadding, sliderPadding, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(this.Width - cornerRadius - sliderPadding, this.Height - cornerRadius - sliderPadding, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(sliderPadding, this.Height - cornerRadius - sliderPadding, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();
                e.Graphics.FillPath(backgroundBrush, path);
            }

          
            // Dibujar el botón deslizable redondeado
            using (SolidBrush sliderBrush = new SolidBrush(isOn ? Color.White : Color.LightGray))
            {
                e.Graphics.FillEllipse(sliderBrush, sliderRect);
            }

            // Si IsOn es true, dibujar un círculo azul dentro del deslizador
            if (isOn)
            {
                int innerPadding = 2; // Ajuste de tamaño para el círculo interno
                RectangleF innerCircle = new RectangleF(
                    sliderRect.X + innerPadding,
                    sliderRect.Y + innerPadding,
                    sliderRect.Width - innerPadding * 2,
                    sliderRect.Height - innerPadding * 2
                );

                using (SolidBrush innerBrush = new SolidBrush(System.Drawing.SystemColors.Highlight))
                {
                    e.Graphics.FillEllipse(innerBrush, innerCircle);
                }
            }


            // Configurar la posición del texto
            Rectangle textRect;
            if (isOn)
            {
                textRect = new Rectangle(sliderPadding, 0, this.Width / 2, this.Height);
            }
            else
            {
                textRect = new Rectangle(this.Width / 2 - sliderPadding, 0, this.Width / 2, this.Height);
            }

            TextRenderer.DrawText(
                e.Graphics,
                isOn ? "SI" : "NO",
                this.Font,
                textRect,
                Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (ValidarCampos != null && !ValidarCampos.Invoke())
            {
                return;
            }

            IsOn = !IsOn; // Cambiar el estado usando la propiedad
        }

        private void UpdateSliderRect()
        {
            int sliderSize = this.Height - sliderPadding * 2;
            int xPosition = isOn ? this.Width - sliderSize - sliderPadding : sliderPadding;
            sliderRect = new RectangleF(xPosition, sliderPadding, sliderSize, sliderSize);
        }
    }
}