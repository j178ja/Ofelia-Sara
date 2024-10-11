using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Controles.Controles
{
    public partial class EmailControl : UserControl
    {
        private string placeholder = "Ingrese correo electronico";

        public EmailControl()
        {
            InitializeComponent();
            ConfigurarTxtEmail();
            comboBox_EmpresaEmail.MaxLength = 20;
            CustomEmailTextBox_Load(this, EventArgs.Empty); // Inicializar load
        }

        private void ConfigurarTxtEmail()
        {
            // Habilitar la selección automática de todo el texto al obtener el foco
            textBox_Email.Enter += TextBox_Email_Enter;
            textBox_Email.Leave += TextBox_Email_Leave;
            textBox_Email.TextChanged += TextBox_Email_TextChanged;
            textBox_Email.MaxLength = 40; // Limita el TextBox a 35 caracteres
        }

        private void AjustarLongitudComboBox(ComboBox comboBox)
        {
            // Mide el tamaño del texto contenido en el ComboBox
            Size textSize = TextRenderer.MeasureText(comboBox.Text, comboBox.Font);

            // Ajusta el ancho del ComboBox según el tamaño del texto
            comboBox.Width = textSize.Width + 20; // Añade un margen para padding y desplegable
        }

        private void comboBox_EmpresaEmail_TextChanged(object sender, EventArgs e)
        {
            AjustarLongitudComboBox(comboBox_EmpresaEmail);
        }

        private void CustomEmailTextBox_Load(object sender, EventArgs e)
        {
            SetPlaceholder(textBox_Email, placeholder);
        }

        private void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
        }

        private void TextBox_Email_Enter(object sender, EventArgs e)
        {
            if (textBox_Email.Text == placeholder && textBox_Email.ForeColor == Color.Gray)
            {
                textBox_Email.Text = "";
                textBox_Email.ForeColor = Color.Black;
                textBox_Email.SelectionStart = 0; // Posicionar el cursor al inicio
            }
        }

        private void TextBox_Email_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Email.Text))
            {
                SetPlaceholder(textBox_Email, placeholder);
            }
        }

        private void TextBox_Email_TextChanged(object sender, EventArgs e)
        {
            // Si el texto actual es el placeholder, no hacer nada
            if (textBox_Email.Text == placeholder && textBox_Email.ForeColor == Color.Gray)
            {
                return;
            }

            // Obtiene el texto actual del TextBox
            string input = textBox_Email.Text;

            // Verifica si el texto no es el placeholder
            if (input != placeholder && textBox_Email.ForeColor == Color.Black)
            {
                // Filtra los caracteres no deseados, permitiendo letras, dígitos, '@', '.', '_', y '-'
                string filteredText = new string(input
                    .Where(c => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-')
                    .ToArray());

                // Convierte a minúsculas
                filteredText = filteredText.ToLower();

                // Evita la modificación del texto si ya es igual al filtrado
                if (textBox_Email.Text != filteredText)
                {
                    // Actualiza el texto del TextBox con el texto filtrado
                    textBox_Email.Text = filteredText;

                    // Mueve el cursor al final del texto
                    textBox_Email.SelectionStart = filteredText.Length;
                }
            }
        }


        public void RestorePlaceholders()
        {
            SetPlaceholder(textBox_Email, placeholder);
        }

        public void ClearEmailFields()
        {
            textBox_Email.Clear();
            RestorePlaceholders();
        }

      
    }
}
