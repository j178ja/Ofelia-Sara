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
        private int alturaGroupBox;


        public ActaDenuncia()
        {
            InitializeComponent();

            comboBox_ModeloActuacion.Visible = false;
            groupBox_SeleccionPlantilla.Visible = false;

          panel1.Height = panel_TipoActuacion.Height + 10;
            this.Height = panel1.Height + 80;

        }

        private void ActaDenuncia_Load(object sender, EventArgs e)
        {
            // Inicializa alturaGroupBox con la altura original
            alturaGroupBox = groupBox_SeleccionPlantilla.Height;
       
        }

        private void AjustarTamanoFormulario()
        {
            int alturaBase = panel_TipoActuacion.Height + 10;

            if (groupBox_SeleccionPlantilla.Parent != null && groupBox_SeleccionPlantilla.Parent.Visible)
            {
                panel1.Height = alturaBase + alturaGroupBox + 15;
            }

            else
            {   
                panel1.Height = alturaBase ;

            }
            this.Height = panel1.Bottom + 80;

            // Forzar actualización visual
            panel1.Invalidate();
            panel1.Update();
            panel1.Refresh();
            
        }

      



        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is not RadioButton radioButton) return;

            if (radioButton.Checked)
            {
                ApplyCustomFontStyle(radioButton);
                groupBox_SeleccionPlantilla.Visible = true;
                radioButton_ModeloActuacion.Checked = false;
                radioButton_ActuacionEstandar.Checked = false;
                comboBox_ModeloActuacion.Visible = false;
                ResetPictureBoxStyles();

                if (radioButton == radioButton_Acta)
                {
                    RedondearBordes.Aplicar(pictureBox_Acta, 6, true, false, false, true);
                    pictureBox_Acta.BackColor = Color.FromArgb(4, 234, 0);
                    RedondearBordes.Aplicar(radioButton, 6, false, true, true, false);
                }
                else if (radioButton == radioButton_Denuncia)
                {
                    RedondearBordes.Aplicar(pictureBox_Denuncia, 6, true, false, false, true);
                    pictureBox_Denuncia.BackColor = Color.FromArgb(4, 234, 0);
                    RedondearBordes.Aplicar(radioButton, 6, false, true, true, false);
                }
            }
            else
            {
                radioButton.Font = new System.Drawing.Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Regular);
                radioButton.ForeColor = SystemColors.ControlText;
                radioButton.BackColor = Color.FromArgb(178, 213, 230);
                groupBox_SeleccionPlantilla.Visible = false;
            }

            AjustarTamanoFormulario();
         
        }




        /// <summary>
        /// Método para aplicar el estilo personalizado (negrita y subrayado).
        /// </summary>
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

        private void RadioButton_ModeloActuacion_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_SeleccionPlantilla.Height = alturaGroupBox;
            comboBox_ModeloActuacion.Visible = true;
            comboBox_ModeloActuacion.Focus();

            if (radioButton_Acta.Checked)
            {
                CargarDatosEnComboBox(listaACTAS);
            }
            if (radioButton_Denuncia.Checked)
            {
                CargarDatosEnComboBox(listaDENUNCIAS);
            }

        }

        private void RadioButton_ActuacionEstandar_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_ModeloActuacion.Visible = false;
            groupBox_SeleccionPlantilla.Height = alturaGroupBox - 25; // Reduce la altura para 'Denuncia'

        }



        private List<string> listaACTAS = new List<string> { "PARADERO", "CAPTURA ACTIVA", "INFR. LEY 23.737","CONTRAVENCION ART 72" };
        private List<string> listaDENUNCIAS = new List<string> { "ESTAFA", "RUEDA AUXILIO", "HURTO VEHICULO", "HURTO / ROBO" };
        private object radioButton;

        private void CargarDatosEnComboBox(List<string> datos)
        {
            comboBox_ModeloActuacion.Items.Clear(); // Limpia los elementos anteriores
            comboBox_ModeloActuacion.Items.AddRange(datos.ToArray()); // Agrega los nuevos elementos
        }

    }
}
