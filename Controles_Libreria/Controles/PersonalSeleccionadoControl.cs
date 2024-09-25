
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces_Libreria.Interfaces;




namespace Controles_Libreria.Controles
{
    public partial class PersonalSeleccionadoControl : UserControl
    {
        // Evento que será lanzado cuando se clickee el botón para modificar el personal
        public event EventHandler ModificarPersonalClicked;
        public PersonalSeleccionadoControl()
        {
            InitializeComponent();
        }

        private void btn_ModificarPersonal_Click(object sender, EventArgs e)
        {
            ModificarPersonalClicked?.Invoke(this, EventArgs.Empty);

            if (this.Parent is IFormulario formulario)
            {
                // llamar para inicializar datos
               // formulario.InicializarDatos();
            }
            // Crear y mostrar la instancia de RegistrarPersonal

            //NuevoPersonal nuevoPersonalForm = new NuevoPersonal();
            //nuevoPersonalForm.ShowDialog(); // Mostrar como cuadro de diálogo
        }

        private void btn_EliminarControl_Click(object sender, EventArgs e)
        {
            // Obtén el panel o contenedor que contiene este UserControl
            Panel panel = this.Parent as Panel;

            if (panel != null)
            {
                // Eliminar el control del panel
                panel.Controls.Remove(this);

            }
        }



        private void PersonalSeleccionadoControl_Load(object sender, EventArgs e)
        {

        }
    }
}
