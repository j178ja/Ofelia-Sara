using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles.Controles
{
    public partial class CALENDARIO : Form
    {
        public DateTime SelectedDate { get; private set; }

        public CALENDARIO()
        {
            InitializeComponent();
        }

        private void CalendarForm_Load(object sender, EventArgs e)
        {
            // No es necesario establecer SelectionMode
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelectedDate = monthCalendar1.SelectionStart; // Obtiene la fecha seleccionada
            MessageBox.Show("Seleccion guardada.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CALENDARIO_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Haga click sobre año, luego mes, y finalice con el dia" , "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
    }
}
