
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
using Controles.Controles.Reposicionar_paneles.Buscar_Personal;





namespace Controles.Controles
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

           /* NuevoPersonal nuevoPersonalForm = new NuevoPersonal();
            nuevoPersonalForm.ShowDialog(); // Mostrar como cuadro de diálogo*/
        }

        private void btn_EliminarControl_Click(object sender, EventArgs e)
        {
            Control controlEliminado = this;
            // Obtener el panel y el formulario principal donde están los controles
            Panel panel_PersonalSeleccionado = this.Parent as Panel; // Asumiendo que este control está dentro de este panel
            Panel panel1 = panel_PersonalSeleccionado.Parent as Panel; // El panel contenedor del panel_PersonalSeleccionado
            Form formulario = panel1.FindForm(); // El formulario principal

            // Verificar si las referencias son válidas antes de llamar al método
            if (panel_PersonalSeleccionado != null && panel1 != null && formulario != null)
            {
                // Instanciar la clase AgregarPersonal
                AgregarPersonal agregarPersonal = new AgregarPersonal();
                // Llamar al método para reposicionar los controles y ajustar tamaños
                agregarPersonal.ReposicionarControles(panel_PersonalSeleccionado, controlEliminado, panel1, formulario);
            }

            // Eliminar este control del panel
            panel_PersonalSeleccionado.Controls.Remove(controlEliminado);
        }



        private void PersonalSeleccionadoControl_Load(object sender, EventArgs e)
        {

        }
    }
}
