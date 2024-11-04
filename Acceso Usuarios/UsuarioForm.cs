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
using Ofelia_Sara.Mensajes;




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

        private void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de registro
            Registro registroForm = new Registro();

            // Obtener la ubicación de UsuarioForm (este es 'this' ya que el código está dentro de UsuarioForm)
            Form usuarioForm = this;

            // Ajustar la posición del formulario de registro para que esté justo encima de UsuarioForm
            int posicionX = usuarioForm.Location.X + (usuarioForm.Width - registroForm.Width) / 2; // Centrar en X
            int posicionY = usuarioForm.Location.Y + (usuarioForm.Height - registroForm.Height) / 2+112; // no es la mejor forma pero se posiciona debajo de menu_Principal


            // Establecer la posición manualmente
            registroForm.StartPosition = FormStartPosition.Manual;
            registroForm.Location = new Point(posicionX, posicionY);

            // Mostrar el formulario de registro como un diálogo modal
            registroForm.ShowDialog();
        }


        private void UsuarioForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            
            MensajeGeneral.Mostrar("Ingrese en los campos correspondientes, Usuario y contraseña." + "En caso de no estar registrado, presione boton REGISTRARSE",MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

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

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            // Asumiendo que tienes acceso al formulario principal (MenuPrincipal)
            Form menuPrincipal = Application.OpenForms["MenuPrincipal"]; // O usa una referencia directa si la tienes
            if (menuPrincipal != null)
            {
                // Obtener la ubicación y tamaño del formulario principal
                Point menuPrincipalLocation = menuPrincipal.Location;
                Size menuPrincipalSize = menuPrincipal.Size;

                // Cierra el formulario actual (UsuarioForm)
                this.Close();

                // Crear una instancia del formulario ModificarEliminar
                ModificarEliminar formModificarEliminar = new ModificarEliminar();

                // Calcular la nueva ubicación para el formulario ModificarEliminar
                int x = menuPrincipalLocation.X-6; // Mantener la misma posición horizontal
                int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

                // Ajustar la ubicación del formulario ModificarEliminar
                formModificarEliminar.StartPosition = FormStartPosition.Manual;
                formModificarEliminar.Location = new Point(x, y);

                // Mostrar el formulario como una ventana modal
                formModificarEliminar.Show();
            }
            
        }

    }
}
