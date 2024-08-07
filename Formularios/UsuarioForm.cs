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

        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            Registro registroForm = new Registro();// Crear una instancia del formulario de registro

            registroForm.ShowDialog();// Mostrar el formulario de registro como un diálogo modal
        }
    }
}
