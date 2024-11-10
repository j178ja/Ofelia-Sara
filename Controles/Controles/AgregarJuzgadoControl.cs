using System;
using System.Windows.Forms;

namespace Controles.Controles
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
