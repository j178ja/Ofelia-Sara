using Ofelia_Sara.Registro_de_personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class PersonalSeleccionadoControl : UserControl
    {
        public PersonalSeleccionadoControl()
        {
            InitializeComponent();
        }

        private void btn_ModificarPersonal_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario NuevoPersonal, pasando el número de legajo
            NuevoPersonal nuevoPersonalForm = new NuevoPersonal();
            nuevoPersonalForm.ShowDialog();
        }

        private void btn_EliminarControl_Click(object sender, EventArgs e)
        {
            // Obtén el panel o contenedor que contiene este UserControl
            Panel panel = this.Parent as Panel;

            if (panel != null)
            {
                // Remover este UserControl del panel
                panel.Controls.Remove(this);

                // Recalcular la altura del panel si es necesario, o reposicionar otros controles
                ReposicionarControles(panel);
            }
        }

        private void ReposicionarControles(Panel panel)
        {
            // Reposicionar otros controles en el panel si es necesario
            foreach (Control control in panel.Controls)
            {
                
            }
        }

        private void PersonalSeleccionadoControl_Load(object sender, EventArgs e)
        {

        }
    }
}
