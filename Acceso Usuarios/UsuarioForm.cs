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



namespace Ofelia_Sara.Formularios
{
    public partial class UsuarioForm : BaseForm
    {
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);
            InicializarEstiloBoton(btn_Ingresar);
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
    }
}
