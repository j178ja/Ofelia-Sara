using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class NumeroTelefonicoControl : UserControl
    {
        private bool isPlaceholderActive;

        public NumeroTelefonicoControl()
        {
            InitializeComponent();
            CustomNumeroTelefonicoControl_Load(this, EventArgs.Empty);
            
        }
        // Propiedad para ajustar el ancho del control
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
                    maskedTextBox.Text = "";
                    maskedTextBox.ForeColor = Color.Black;
                    isPlaceholderActive = false;
                }

                // Aseguramos que el cursor esté en la posición inicial
                maskedTextBox.BeginInvoke(new Action(() =>
                {
                    maskedTextBox.SelectionStart = 0;
                }));
            };

            maskedTextBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
                {
                    isPlaceholderActive = true;
                    maskedTextBox.Text = placeholder;
                    maskedTextBox.ForeColor = Color.Gray;

                    // Colocar el cursor al inicio si el placeholder está activo
                    maskedTextBox.SelectionStart = 0;
                }
            };

            maskedTextBox.KeyPress += (sender, e) =>
            {
                if (isPlaceholderActive)
                {
                    maskedTextBox.Text = "";
                    maskedTextBox.ForeColor = Color.Black;
                    isPlaceholderActive = false;
                }
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
    }
}
