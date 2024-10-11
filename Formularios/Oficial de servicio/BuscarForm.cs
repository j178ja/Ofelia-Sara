using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ofelia_Sara.general.clases;
using System.Windows.Forms;
using System.Windows.Controls;
using Clases.Apariencia;
using Clases.Botones;
using Controles.Controles;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class BuscarForm : BaseForm 
    {
        public BuscarForm()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1,borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            // Crear una instancia de TimePickerPersonalizado con tamaño especificado
            TimePickerPersonalizado fecha_Instruccion = new TimePickerPersonalizado(263, 26);

            // Establecer la ubicación del UserControl
            fecha_Instruccion.Location = new Point(150, 50);

            // Agregar el UserControl al formulario
            this.Controls.Add(fecha_Instruccion);
        }
        // Implementación del método de la interfaz IFormulario
        
        private void Buscar_Load(object sender, EventArgs e)
        {

            // Aplica el estilo de botón de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Buscar);

            InicializarComboBox();
        }
        private void InicializarComboBox()
        {
            comboBox_Ipp1.SelectedIndex = 3;
            comboBox_Ipp2.SelectedIndex = 3;
            comboBox_Ipp4.SelectedIndex = 0;

        }
     

        private void BuscarForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Complete alguno de los campos requeridos para iniciar la busqueda.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //_____________________________________________________________________________________
        //-----------------------NUMERO IPP--------------------------------------------------
        private void TextBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {// Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;
            }
        }
        //-------------------------------------------------------------
        //---------------COMBO BOX IPP 1      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void ComboBox_Ipp1_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp1.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp1.Text = comboBox_Ipp1.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp1.SelectionStart = comboBox_Ipp1.Text.Length;
            }
        }

        //---------------COMBO BOX IPP 2      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void ComboBox_Ipp2_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp2.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp2.Text = comboBox_Ipp2.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp2.SelectionStart = comboBox_Ipp2.Text.Length;
            }
        }

        //---------------COMBO BOX IPP 4      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void ComboBox_Ipp4_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp4.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp4.Text = comboBox_Ipp4.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp4.SelectionStart = comboBox_Ipp4.Text.Length;
            }
        }
        //-----EVENTO PARA COMPLETAR CON "0" LOS CARACTERES FALTANTE EN NUMERO IPP------
        // Verifica si el carácter presionado es un número o una tecla de control (como Backspace)
        private void TextBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter presionado es un número o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, bloquea la entrada
                e.Handled = true;
            }
        }


        private void ComboBox_Ipp4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Ipp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Ipp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_Victima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_Imputado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_Victima_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null)
            {
                // Convertir todo el texto a mayúsculas
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = textBox.Text.Length; // Coloca el cursor al final del texto
            }
        }

        private void TextBox_Imputado_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null)
            {
                // Convertir todo el texto a mayúsculas
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = textBox.Text.Length; // Coloca el cursor al final del texto
            }
        }

        private void ComboBox_Dependencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Instructor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Secretario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Secretario_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

            if (comboBox != null)
            {
                // Obtén el texto actual
                string textoActual = comboBox.Text;

                // Conviértelo a mayúsculas, ignorando caracteres especiales
                StringBuilder textoFormateado = new StringBuilder();

                foreach (char c in textoActual)
                {
                    if (char.IsLetter(c) || char.IsDigit(c) || char.IsWhiteSpace(c))
                    {
                        textoFormateado.Append(char.ToUpper(c));
                    }
                }

                // Actualiza el texto en el ComboBox y coloca el cursor al final
                comboBox.Text = textoFormateado.ToString();
                comboBox.SelectionStart = textoFormateado.Length;
            }
        }

        private void ComboBox_Instructor_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

            if (comboBox != null)
            {
                // Obtén el texto actual
                string textoActual = comboBox.Text;

                // Conviértelo a mayúsculas, ignorando caracteres especiales
                StringBuilder textoFormateado = new StringBuilder();

                foreach (char c in textoActual)
                {
                    if (char.IsLetter(c) || char.IsDigit(c) || char.IsWhiteSpace(c))
                    {
                        textoFormateado.Append(char.ToUpper(c));
                    }
                }

                // Actualiza el texto en el ComboBox y coloca el cursor al final
                comboBox.Text = textoFormateado.ToString();
                comboBox.SelectionStart = textoFormateado.Length;
            }
        }

        private void ComboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

            if (comboBox != null)
            {
                // Obtén el texto actual
                string textoActual = comboBox.Text;

                // Conviértelo a mayúsculas, ignorando caracteres especiales
                StringBuilder textoFormateado = new StringBuilder();

                foreach (char c in textoActual)
                {
                    if (char.IsLetter(c) || char.IsDigit(c) || char.IsWhiteSpace(c))
                    {
                        textoFormateado.Append(char.ToUpper(c));
                    }
                }

                // Actualiza el texto en el ComboBox y coloca el cursor al final
                comboBox.Text = textoFormateado.ToString();
                comboBox.SelectionStart = textoFormateado.Length;
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox != null)
            {
                // Construir el nuevo texto que contiene solo letras, números y espacios
                StringBuilder nuevoTexto = new StringBuilder();

                foreach (char c in textBox.Text)
                {
                    if (char.IsLetter(c) || char.IsDigit(c) || char.IsWhiteSpace(c))
                    {
                        nuevoTexto.Append(char.ToUpper(c));
                    }
                }

                // Actualizar el texto del TextBox
                textBox.Text = nuevoTexto.ToString();

                // Coloca el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}