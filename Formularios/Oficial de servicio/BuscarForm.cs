using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ofelia_Sara.general.clases;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class BuscarForm : BaseForm
    {
        public BuscarForm()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            PosicionarCursorEnTextBox();
        }
        // Método para posicionar el cursor en el textBox específico
        public void PosicionarCursorEnTextBox()
        {
            textBox_Caratula.Focus();
        }
    }
}
