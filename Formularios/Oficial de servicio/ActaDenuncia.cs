using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class ActaDenuncia : BaseForm
    {
        

        public ActaDenuncia()
        {
            InitializeComponent();
        }

        private void ActaDenuncia_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                // Verifica qué RadioButton fue marcado y aplica el estilo correspondiente
                if (radioButton.Checked)
                {
                    // Aplica el estilo personalizado (negrita y subrayado)
                    ApplyCustomFontStyle(radioButton);

                
                // Cambia la imagen y el color de fondo del PictureBox correspondiente
                if (radioButton == radioButton_Acta)
                {

                    RedondearBordes.Aplicar(pictureBox_Acta, 6, true, false, false, true); // Solo esquinas izquierdas
                    ResetPictureBoxStyles(); // Restaura los estilos por defecto de los PictureBox
                    pictureBox_Acta.BackColor = Color.FromArgb(4, 234, 0);
                    RedondearBordes.Aplicar(radioButton, 6, false, true, true, false); // Solo esquinas derechas
                }
                else if (radioButton == radioButton_Denuncia)
                {

                    RedondearBordes.Aplicar(pictureBox_Denuncia, 6, true, false, false, true);
                    ResetPictureBoxStyles();
                    pictureBox_Denuncia.BackColor = Color.FromArgb(4, 234, 0);
                    RedondearBordes.Aplicar(radioButton, 6, false, true, true, false);
                }
                }
                else
                {
                    // Restaura el estilo normal si el RadioButton se desmarca
                    radioButton.Font = new System.Drawing.Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Regular);
                    radioButton.ForeColor = SystemColors.ControlText;
                    radioButton.BackColor = Color.FromArgb(178, 213, 230);
                }
            }
        }

        /// <summary>
        /// Método para aplicar el estilo personalizado (negrita y subrayado)
        /// </summary>
        /// <param name="radioButton"></param>
        private static void ApplyCustomFontStyle(RadioButton radioButton)
        {
            // Crea una fuente con negrita y subrayado
            System.Drawing.Font customFont = new(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Bold);

            // Cambia la fuente del RadioButton
            radioButton.Font = customFont;
            radioButton.ForeColor = SystemColors.HotTrack;
            radioButton.BackColor = Color.FromArgb(228, 247, 222);

            // Redibuja el RadioButton para reflejar el cambio
            radioButton.Invalidate();
        }

        /// <summary>
        /// Restaura los estilos por defecto de todos los PictureBox.
        /// </summary>
        private void ResetPictureBoxStyles()
        {
            pictureBox_Acta.BackColor = Color.FromArgb(178, 213, 230);
            pictureBox_Denuncia.BackColor = Color.FromArgb(178, 213, 230);
          

        }
    }
}
