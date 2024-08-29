using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General.Generales;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Ofelia_Sara
{
    public partial class Cargo : BaseForm

    {
        public Cargo()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }
        //----------------------------------------------------------------------------------
        //---sobrecargar para que reciba los datos desde form iniciocierre
        public Cargo(string ipp1, string ipp2, string numeroIpp, string ipp4, string caratula,
                 string victima, string imputado, string fiscalia, string agenteFiscal,
                 string instructor, string secretario, string dependencia)
        {
            InitializeComponent();

            // Asignar los valores a los controles específicos del formulario
            comboBox_Ipp1.Text = ipp1;
            comboBox_Ipp2.Text = ipp2;
            textBox_NumeroIpp.Text = numeroIpp;
            comboBox_Ipp4.Text = ipp4;
            textBox_Caratula.Text = caratula;
            textBox_Victima.Text = victima;
            textBox_Imputado.Text = imputado;
            comboBox_Fiscalia.Text = fiscalia;  // Asignación al control
            comboBox_AgenteFiscal.Text = agenteFiscal;
            comboBox_Instructor.Text = instructor;
            comboBox_Secretario.Text = secretario;
            comboBox_Dependencia.Text = dependencia;
        }
        //----------------------------------------------------------------------------------------

        private void Cargo_Load(object sender, EventArgs e)
        {
            textBox_NumeroCargo.MaxLength = 4;//limita a 4 caracteres el numero de cargo
            textBox_NumeroIpp.MaxLength = 6;
            comboBox_Ipp1.MaxLength = 2;
            comboBox_Ipp2.MaxLength = 2;
            comboBox_Ipp4.MaxLength = 2;

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarCausa);
            InicializarEstiloBotonAgregar(btn_AgregarVictima);
            InicializarEstiloBotonAgregar(btn_AgregarImputado);

            MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            MayusculaSola.AplicarAControl(textBox_Victima);
            MayusculaSola.AplicarAControl(textBox_Imputado);
            
            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);
        }

     

      

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
            MessageBox.Show("Formulario eliminado.");
            

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

        }

        private void textBox_NumeroCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void comboBox_Ipp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void comboBox_Ipp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void comboBox_Ipp4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }

            // Verifica si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Obtiene el TextBox que disparó el evento
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Obtiene el texto actual del TextBox
                    string currentText = textBox.Text;

                    // Verifica si el texto es numérico
                    if (int.TryParse(currentText, out _))
                    {
                        // Completa el texto con ceros a la izquierda hasta alcanzar 6 caracteres
                        string completedText = currentText.PadLeft(6, '0');

                        // Actualiza el texto del TextBox
                        textBox.Text = completedText;

                        // Posiciona el cursor al final del texto
                        textBox.SelectionStart = textBox.Text.Length;

                        // Cancelar el manejo predeterminado de la tecla Enter
                        e.Handled = true;
                    }
                }
            }
        }



        private void textBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {
            // Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;
               
            }
        }
    }
}
