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
          //  panel1.Height = panel_TipoActuacion.Height + 5;

            // Ajustar la altura del formulario en base al tamaño de panel1 + 25
         //   this.Height = panel1.Bottom + 80;
        }

        private void ActaDenuncia_Load(object sender, EventArgs e)
        {
            // Inicializa alturaGroupBox con la altura original
            alturaGroupBox = groupBox_SeleccionPlantilla.Height;
          
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is not RadioButton radioButton) return;

            if (radioButton.Checked)
            {
                // Aplica el estilo personalizado (negrita y subrayado)
                ApplyCustomFontStyle(radioButton);

                // Muestra el groupBox
                groupBox_SeleccionPlantilla.Visible = true;

                radioButton_ModeloActuacion.Checked = false;
                radioButton_ActuacionEstandar.Checked = false;
                comboBox_ModeloActuacion.Visible = false;

                // Restaura los estilos por defecto de los PictureBox
                ResetPictureBoxStyles();

                // Cambia la imagen y el color de fondo del PictureBox correspondiente
                if (radioButton == radioButton_Acta)
                {
                    // Estilos para 'Acta'
                    RedondearBordes.Aplicar(pictureBox_Acta, 6, true, false, false, true); // Solo esquinas izquierdas
                    pictureBox_Acta.BackColor = Color.FromArgb(4, 234, 0); // Color de fondo verde
                    RedondearBordes.Aplicar(radioButton, 6, false, true, true, false); // Bordes redondeados en el radioButton
                }
                else if (radioButton == radioButton_Denuncia)
                {
                    // Estilos para 'Denuncia'
                    RedondearBordes.Aplicar(pictureBox_Denuncia, 6, true, false, false, true); // Solo esquinas izquierdas
                    pictureBox_Denuncia.BackColor = Color.FromArgb(4, 234, 0); // Color de fondo verde
                    RedondearBordes.Aplicar(radioButton, 6, false, true, true, false); // Bordes redondeados en el radioButton
                }
            }
            else
            {
                // Restaura el estilo normal si el RadioButton se desmarca
                radioButton.Font = new System.Drawing.Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Regular);
                radioButton.ForeColor = SystemColors.ControlText;
                radioButton.BackColor = Color.FromArgb(178, 213, 230);

                // Si se desmarca, también ocultamos el groupBox
                groupBox_SeleccionPlantilla.Visible = false;

             
            }
        }


        /// <summary>
        /// Método para ajustar la altura de panel1 y del formulario.
        /// </summary>
        //private void AjustarAlturaFormularioYPaneles()
        //{
        //    // Ajustar la altura de panel1
        //    if (groupBox_SeleccionPlantilla.Visible)
        //    {
        //        panel1.Height = panel_TipoActuacion.Height + groupBox_SeleccionPlantilla.Height + 5;
        //    }
        //    else
        //    {
        //        panel1.Height = panel_TipoActuacion.Height + 5; // Si no está visible, solo el panel_TipoActuacion
        //    }

        //    // Ajustar la altura del formulario en base a panel1 y agregar un margen de 25
        //    this.Height = panel1.Bottom + 25;
        //}

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

        private void CargarDatosEnComboBox(List<string> datos)
        {
            comboBox_ModeloActuacion.Items.Clear(); // Limpia los elementos anteriores
            comboBox_ModeloActuacion.Items.AddRange(datos.ToArray()); // Agrega los nuevos elementos
        }

    }
}
