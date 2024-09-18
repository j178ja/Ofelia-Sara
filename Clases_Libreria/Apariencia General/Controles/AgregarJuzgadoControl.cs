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
    public partial class AgregarJuzgadoControl : UserControl
    {
        public AgregarJuzgadoControl()
        {
            InitializeComponent();

            InitializeComponent();
            this.Dock = DockStyle.None; // Asegúrate de que el UserControl no esté acoplado a ningún borde del panel
            this.AutoSize = true; // Asegura que el UserControl ajuste su tamaño automáticamente
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
