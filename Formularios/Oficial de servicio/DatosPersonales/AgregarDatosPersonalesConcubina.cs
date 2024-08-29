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

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales
{
    public partial class AgregarDatosPersonalesConcubina : BaseForm
    {
        public AgregarDatosPersonalesConcubina()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }

        private void AgregarDatosPersonalesConcubina_Load(object sender, EventArgs e)
        {

        }

        

    }
}
