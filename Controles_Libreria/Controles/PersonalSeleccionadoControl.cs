
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





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
