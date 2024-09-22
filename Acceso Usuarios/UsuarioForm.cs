using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using Ofelia_Sara;
using Ofelia_Sara.Acceso_Usuarios;




namespace Ofelia_Sara.Formularios
{
    public partial class UsuarioForm : BaseForm
    {
        public UsuarioForm()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);
            InicializarEstiloBoton(btn_Ingresar);

            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
            pictureBox_OjoContraseña.Enabled = false;
            this.Shown += Focus_Shown;//para que haga foco en un textBox
        }
        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_Usuario.Focus();
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            Registro registroForm = new Registro();// Crear una instancia del formulario de registro

            registroForm.ShowDialog();// Mostrar el formulario de registro como un diálogo modal
        }

        private void UsuarioForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Ingrese en los campos correspondientes, Usuario y contraseña." + "En caso de no estar registrado, presione boton REGISTRARSE", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

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

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario ModificarEliminar
            ModificarEliminar formModificarEliminar = new ModificarEliminar();

            // Muestra el formulario como una ventana modal
            formModificarEliminar.ShowDialog();

            this.Close();
        }
    }
}
