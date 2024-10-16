using System;
using MySql.Data.MySqlClient;//Para vincular a base de datos
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;
using Clases.Apariencia;
using BaseDatos.Entidades;
using Clases.Texto;
using Clases.Botones;
using MySqlX.XDevAPI.Common;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Registro : BaseForm
    {
        public Registro()
        {
            InitializeComponent();

            //para redondear bordes panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

        }

        private void Registro_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);
            InicializarEstiloBoton(btn_Limpiar);

            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
            pictureBox_OjoContraseña.Enabled = false;

            //  deshabilitar la edición del ComboBox_Escalafon
            comboBox_Escalafon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Jerarquia.DropDownStyle = ComboBoxStyle.DropDownList;

            ClaseNumeros.AplicarFormatoYLimite(textBox_Legajo, 7);
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_Apellido);
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(ComboBox comboBox)
        {
            comboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }
       //--------------------------------------------------------------------------

        private void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están completados
            if (!ValidarTextBoxes(this))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar la totalidad de campos", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                DialogResult result = MessageBox.Show("Se ha registrado un nuevo Usuario.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                // Si el usuario presiona "OK", cerrar el formulario actual
                if (result == DialogResult.OK)
                {
                    this.Close(); // Cierra el formulario actual
                }
            }
        }
        private bool ValidarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Verificar si es un TextBox y está vacío
                if (control is TextBox && string.IsNullOrWhiteSpace(((TextBox)control).Text))
                {
                    return false;
                }

                // Si el control tiene controles hijos, aplicar la validación recursivamente
                if (control.HasChildren)
                {
                    if (!ValidarTextBoxes(control))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            comboBox_Escalafon.SelectedIndex = -1;
            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
            pictureBox_OjoContraseña.Enabled = false;

            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);//esto muestra una ventana con boton aceptar
        }

        private void Registro_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Vomplete la totalidad de los campos para poder registrar un nuevo Usuario.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //--------------------------------------------------------------------

        // Define una variable para llevar el control del estado de visibilidad
        private bool esContraseñaVisible = false;

        private void PictureBox_OjoContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '\0'; // Muestra el texto real
            pictureBox_OjoContraseña.Image = Properties.Resources.ojo_Contraseña; // Cambia la imagen al icono de "visible"
        }

        private void PictureBox_OjoContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '*'; // Oculta el texto con asteriscos
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoCerrado; // Cambia la imagen al icono de "oculto"
        }

        private void TextBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Contraseña.Text))
            {
                // Desactiva la imagen si no hay texto
                pictureBox_OjoContraseña.Enabled = false;
            }
            else
            {
                // Activa la imagen si hay texto
                pictureBox_OjoContraseña.Enabled = true;
            }
        }

        private void TextBox_Legajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }
    }

}
