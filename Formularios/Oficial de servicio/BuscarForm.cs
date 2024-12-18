
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Controles.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Ofl_Sara;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class BuscarForm : BaseForm
    {
        public BuscarForm()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            // Crear una instancia de TimePickerPersonalizado con tamaño especificado
            TimePickerPersonalizado fecha_Instruccion = new TimePickerPersonalizado();

            // Establecer la ubicación del UserControl
            fecha_Instruccion.Location = new Point(150, 50);

            // Agregar el UserControl al formulario
            this.Controls.Add(fecha_Instruccion);
        }

        private void Buscar_Load(object sender, EventArgs e)
        {

            // Aplica el estilo de botón de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Buscar);

            InicializarComboBox();

            CargarDatosDependencia(comboBox_Dependencia, dbManager);
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
            CargarDatosSecretario(comboBox_Secretario, secretariosManager);
        }
        private void InicializarComboBox()
        {
            comboBox_Ipp1.SelectedIndex = 3;
            comboBox_Ipp2.SelectedIndex = 3;
            comboBox_Ipp4.SelectedIndex = 0;

        }


        private void BuscarForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MensajeGeneral.Mostrar("Complete alguno de los campos requeridos para iniciar la busqueda.", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
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
        

 
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void ComboBox_Ipp_TextUpdate(object sender, EventArgs e)
        {
        // se aplica a textBox ya que el customComboBox esta construido con textBox
            if (sender is TextBox textBox)
            {
                // Limitar a 2 caracteres
                if (textBox.Text.Length > 2)
                {
                    textBox.Text = textBox.Text.Substring(0, 2);

                    // Mover el cursor al final del texto
                    textBox.SelectionStart = textBox.Text.Length;
                }
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
            Ofelia_Sara.Controles.General.CustomComboBox comboBox = sender as Ofelia_Sara.Controles.General.CustomComboBox;

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
            Ofelia_Sara.Controles.General.CustomComboBox comboBox = sender as Ofelia_Sara.Controles.General.CustomComboBox;

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
            Ofelia_Sara.Controles.General.CustomComboBox comboBox = sender as Ofelia_Sara.Controles.General.CustomComboBox;

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