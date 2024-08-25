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
        }
    }
}
