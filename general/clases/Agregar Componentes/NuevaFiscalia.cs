using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    public partial class NuevaFiscalia: BaseForm
    {
        public NuevaFiscalia()
        {
            InitializeComponent();
        }

        private void Fiscalia_Load(object sender, EventArgs e)
        {

        }

        private void FISCALIA_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable en los formularios", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
    }
}
