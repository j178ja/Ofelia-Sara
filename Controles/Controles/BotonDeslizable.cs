using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Mensajes;

namespace Ofelia_Sara.Controles.Controles
{
   
    public partial class BotonDeslizable : UserControl
    {
        private bool isOn = false;
        private RectangleF sliderRect;
        private int sliderPadding = 4;
        private int cornerRadius = 3; // Ajuste de radio para bordes redondeados

        // Delegado para validar los campos antes de cambiar el estado
   
        public BotonDeslizable()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            this.Size = new Size(40, 20); // Tamaño del control ajustado
            UpdateSliderRect();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar fondo redondeado
            using (SolidBrush backgroundBrush = new SolidBrush(isOn ? Color.Green : Color.Red))
            using (GraphicsPath path = new GraphicsPath())
            {
                // Esquinas redondeadas con el nuevo radio ajustado
                path.AddArc(sliderPadding, sliderPadding, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(this.Width - cornerRadius - sliderPadding, sliderPadding, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(this.Width - cornerRadius - sliderPadding, this.Height - cornerRadius - sliderPadding, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(sliderPadding, this.Height - cornerRadius - sliderPadding, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();
                e.Graphics.FillPath(backgroundBrush, path);
            }

            // Dibujar el botón deslizable redondeado
            using (SolidBrush sliderBrush = new SolidBrush(Color.LightGray))
            {
                e.Graphics.FillEllipse(sliderBrush, sliderRect);
            }

            // Configurar la posición del texto
            Rectangle textRect;
            if (isOn)
            {
                // Texto "SI" alineado a la izquierda con margen
                textRect = new Rectangle(sliderPadding, 0, this.Width / 2, this.Height);
            }
            else
            {
                // Texto "NO" alineado a la derecha con margen para evitar recorte
                textRect = new Rectangle(this.Width / 2 - sliderPadding, 0, this.Width / 2, this.Height);
            }

            // Dibujar el texto
            TextRenderer.DrawText(
                e.Graphics,
                isOn ? "SI" : "NO",
                this.Font,
                textRect,
                Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );
        }
        // Delegado para la validación de campos
        public Func<bool> ValidarCampos { get; set; }

       
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            // Si hay un delegado de validación asignado, lo invocamos
            if (ValidarCampos != null && !ValidarCampos.Invoke())
            {
                // Si la validación falla, no cambiamos el estado del botón
                return;
            }

            // Cambiar el estado del botón
            IsOn = !IsOn; // Cambia el estado usando la propiedad
        }

        public bool IsOn
        {
            get => isOn;
            set
            {
                if (isOn != value)
                {
                    isOn = value;
                    UpdateSliderRect();
                    Invalidate(); // Redibuja el control para reflejar el nuevo estado
                }
            }
        }
    

    private void UpdateSliderRect()
        {
            int sliderSize = this.Height - sliderPadding * 2;
            int xPosition = isOn ? this.Width - sliderSize - sliderPadding : sliderPadding;
            sliderRect = new RectangleF(xPosition, sliderPadding, sliderSize, sliderSize);
        }
    }
}