using Ofelia_Sara.Clases.General.Animaciones;

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
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private int alturaOriginalGroupBox;
        private int alturaOriginalPanel1;
        #endregion

        #region CONSTRUCTOR
        public ActaDenuncia()
        {
            InitializeComponent();

            //oculta de entrada todos los elementos menos tipo de actuacion
            comboBox_ModeloActuacion.Visible = false;
            groupBox_SeleccionPlantilla.Visible = false;
            panel_ControlesInferiores.Visible = false;
            panel_Actuacion.Visible = false;
            comboBox_ModeloActuacion.Enabled = false;//desactiva el combobox hasta q se seleccione actuacion estandar o de modelo de actuacion

            panel_Actuacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;


            //  AjustarTamanoFormulario();

        }
        #endregion

        #region LOAD
        private void ActaDenuncia_Load(object sender, EventArgs e)
        {
            this.FormClosing += ActaDenuncia_FormClosing;
        }
        #endregion

        /// <summary>
        /// Ajusta dinámicamente el tamaño del formulario y sus paneles según la visibilidad de los elementos
        /// </summary>
        //private void AjustarTamanoFormulario()
        //{


        //    if (groupBox_SeleccionPlantilla.Visible)
        //    {
        //        // Asegurarse de que esté posicionado correctamente y calcular Bottom real
        //        panel1.Height = groupBox_SeleccionPlantilla.Bottom+10;

        //    }
        //    else
        //    {
        //        panel1.Height = groupBox_SeleccionPlantilla.Top - 5;
        //    }

        //    // Ajusta el alto total del formulario
        //    this.Height = panel1.Top + panel1.Height + 80;

        //    this.PerformLayout(); // Opcional: asegura redibujo correcto
        //}





        /// <summary>
        /// amplia formulario y muestra contenido segun seleccion de radiobuttom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is not RadioButton radioButton) return;

            if (radioButton.Checked)
            {
                groupBox_SeleccionPlantilla.Visible = true;
                radioButton_ModeloActuacion.Checked = false;
                radioButton_ActuacionEstandar.Checked = false;
                comboBox_ModeloActuacion.Visible = true;

                Animar.CrecimientoY(groupBox_SeleccionPlantilla, altoInicial: 0, duracion: 500); // hace que aparesca el group expandiendose hacia abajo

                EstiloRadiobuttom.AplicarEstiloSeleccionRadioButton(
                    radioButton,
                    radioButton_Acta,
                    radioButton_Denuncia,
                    pictureBox_Acta,
                    pictureBox_Denuncia
                );
            }
            else
            {
                radioButton.Font = new Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Regular);
                radioButton.ForeColor = SystemColors.ControlText;
                radioButton.BackColor = Color.FromArgb(178, 213, 230);
                groupBox_SeleccionPlantilla.Visible = false;
            }

            // AjustarTamanoFormulario(); 
            ActualizarTextoTipoActuacion();
        }

        /// <summary>
        /// Centra el label de tipo de actuacion sin importar el largo
        /// </summary>
        /// <param name="nuevoTexto"></param>
        private void ActualizarTextoTipoActuacion()
        {
            string tipo = "";
            string complemento = "";

            if (radioButton_Acta.Checked)
                tipo = "ACTA";
            else if (radioButton_Denuncia.Checked)
                tipo = "DENUNCIA";

            if (radioButton_ActuacionEstandar.Checked)
                complemento = "ESTANDAR";
            else if (radioButton_ModeloActuacion.Checked && comboBox_ModeloActuacion.SelectedItem != null)
                complemento = comboBox_ModeloActuacion.SelectedItem.ToString();

            string textoFinal = string.IsNullOrWhiteSpace(complemento) ? tipo : $"{tipo} {complemento}";

            label_TipoActuacion.Text = textoFinal;

            // Centrar en el panel
            label_TipoActuacion.Left = (panel_Actuacion.Width - label_TipoActuacion.Width) / 2;
        }




        /// <summary>
        /// carga lista en combobox segun se seleccione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_ModeloActuacion_CheckedChanged(object sender, EventArgs e)
        {

          //  groupBox_SeleccionPlantilla.Height = alturaOriginalGroupBox;
            comboBox_ModeloActuacion.Visible = true;
            comboBox_ModeloActuacion.Enabled = true;
            comboBox_ModeloActuacion.Focus();

            if (radioButton_Acta.Checked)
            {
                CargarDatosEnComboBox(listaACTAS);
            }
            if (radioButton_Denuncia.Checked)
            {
                CargarDatosEnComboBox(listaDENUNCIAS);
            }
            // AjustarTamanoFormulario();
            ActualizarTextoTipoActuacion();
        }

        private void RadioButton_ActuacionEstandar_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_ModeloActuacion.Visible = false;
           panel_Actuacion.Visible = true;
            Desplazar.DesplazamientoDesde(label_TipoActuacion, DireccionDesplazamiento.DesdeIzquierdaAlCentroX, duracion: 800);


            //   groupBox_SeleccionPlantilla.Height = alturaOriginalGroupBox - 25; // Reduce la altura para 'Denuncia'
            // AjustarTamanoFormulario();
            ActualizarTextoTipoActuacion();
            Animar.CrecimientoY(richTextBox_Actuacion, altoInicial: 0, duracion: 500);
            richTextBox_Actuacion.Focus();
        }



        private List<string> listaACTAS = new List<string> { "PARADERO", "CAPTURA ACTIVA", "INFR. LEY 23.737", "CONTRAVENCION ART 72" };
        private List<string> listaDENUNCIAS = new List<string> { "ESTAFA", "RUEDA AUXILIO", "HURTO VEHICULO", "HURTO / ROBO" };
        private object radioButton;

        private void CargarDatosEnComboBox(List<string> datos)
        {
            comboBox_ModeloActuacion.Items.Clear(); // Limpia los elementos anteriores
            comboBox_ModeloActuacion.Items.AddRange(datos.ToArray()); // Agrega los nuevos elementos
            ActualizarTextoTipoActuacion();
        }

        #region MENSAJE CIERRE
        /// <summary>
        /// MENSAJE CONFIRMACION AL CIERRE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActaDenuncia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
            }
        }
        #endregion



    }
}
