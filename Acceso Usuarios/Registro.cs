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
using Ofelia_Sara.general.clases.Apariencia_General;
using Ofelia_Sara.general.clases.Apariencia_General.Generales;
using Ofelia_Sara.Base_de_Datos;
using Ofelia_Sara.general.clases.Apariencia_General.Texto;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Registro : BaseForm
    {
        public Registro()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

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
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(ComboBox comboBox)
        {
            comboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }
       //--------------------------------------------------------------------------


        private void textBox_Legajo_KeyPress(object sender, KeyPressEventArgs e)
        {
                           // Solo permite dígitos y teclas de control
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Si el carácter es dígito, continúa con el procesamiento
                if (char.IsDigit(e.KeyChar))
                {
                    // Inserta el carácter en la posición actual
                    TextBox textBox = sender as TextBox;
                    int selectionStart = textBox.SelectionStart;
                    textBox.Text = textBox.Text.Insert(selectionStart, e.KeyChar.ToString());
                    e.Handled = true;

                    // Usar la clase separada para formatear el texto
                    string textoFormateado = ClaseNumeros.FormatearNumeroConPuntos(textBox.Text);

                    // Actualizar el texto en el TextBox y restaurar la posición del cursor
                    textBox.Text = textoFormateado;
                    textBox.SelectionStart = textoFormateado.Length;


                }
            }
        

      

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //TextBox textBox = sender as TextBox;
            //if (textBox != null)
            //{
            //    // Convertir el texto a mayúsculas ignorando caracteres especiales
            //    textBox.Text = MayusculaYnumeros.AplicarAControl(textBox textBox);

            //    // Para mantener el cursor al final del texto
            //    textBox.SelectionStart = textBox.Text.Length;
            //}
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
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
                MessageBox.Show("Se ha registrado un nuevo Usuario.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_Limpiar_Click(object sender, EventArgs e)
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

        private void pictureBox_OjoContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '\0'; // Muestra el texto real
            pictureBox_OjoContraseña.Image = Properties.Resources.ojo_Contraseña; // Cambia la imagen al icono de "visible"
        }

        private void pictureBox_OjoContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '*'; // Oculta el texto con asteriscos
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoCerrado; // Cambia la imagen al icono de "oculto"
        }

        private void textBox_Contraseña_TextChanged(object sender, EventArgs e)
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
    }

}
