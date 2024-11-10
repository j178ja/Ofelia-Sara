using Ofelia_Sara.general.clases;
using System;
using System.Drawing;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class ConversorDeDocumentos : BaseForm
    {
        public ConversorDeDocumentos()
        {
            InitializeComponent();

            //para redondear bordes de panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

        }

        private void ConversorDeDocumentos_Load(object sender, EventArgs e)
        {

        }
    }
}
