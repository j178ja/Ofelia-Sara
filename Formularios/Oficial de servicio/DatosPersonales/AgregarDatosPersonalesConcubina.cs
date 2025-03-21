﻿
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales
{
    public partial class AgregarDatosPersonalesConcubina : BaseForm
    {
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private Point originalPosition;
        #endregion

        #region CONSTRUCTOR
        public AgregarDatosPersonalesConcubina()
        {
            InitializeComponent();
            this.FormClosing += AgregarDatosConcubina_FormClosing;//para mensaje de alerta en caso de no guardar datos

        }
        #endregion

        #region LOAD
        private void AgregarDatosPersonalesConcubina_Load(object sender, EventArgs e)
        {
            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad

            btn_AgregarConcubina.Enabled = false;
            InicializarEstiloBotonAgregar(btn_AgregarConcubina);// estilo boton

            comboBox_EstadoCivil.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;//deshabilita ingreso de datos del usuario en comboBox estado civil

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarConcubina, "Seleccione ESTADO CIVIL para agregar un nuevo vinculo.", "Seleccione para agregar nuevo familiar");
        }
        #endregion

   

        private void ComboBox_EstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar el botón cuando se seleccione un ítem en el ComboBox
            if (comboBox_EstadoCivil.SelectedIndex >= 0)
            {
                btn_AgregarConcubina.Enabled = true;

            }
            else
            {
                btn_AgregarConcubina.Enabled = false;
            }

        }

  
        /// <summary>
        /// Variable para almacenar la posición original
        /// </summary>
      
        private void Btn_AgregarConcubina_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario AgregarDatosPersonalesConcubina
            Form agregarDatosPersonalesConcubina = new AgregarDatosPersonalesConcubina();

            // Guardar la posición original del formulario
            originalPosition = this.Location;

            // Obtener el tamaño de ambos formularios
            int totalWidth = this.Width + agregarDatosPersonalesConcubina.Width;
            int height = Math.Max(this.Height, agregarDatosPersonalesConcubina.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario original a la izquierda
            this.Location = new Point(startX, startY);

            // Posicionar el formulario AgregarDatosPersonalesConcubina a la derecha del formulario original
            agregarDatosPersonalesConcubina.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesConcubina.Location = new Point(startX + this.Width, startY);

            // Mostrar el formulario AgregarDatosPersonalesConcubina
            agregarDatosPersonalesConcubina.FormClosed += AgregarDatosPersonalesConcubina_FormClosed;
            agregarDatosPersonalesConcubina.Show();

        }

        /// <summary>
        /// restaurar posicion de formulario una vez cerrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarDatosPersonalesConcubina_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Restaurar la posición original del formulario
            this.Location = originalPosition;
        }

   

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario


        }


      
        /// <summary>
        /// Evento FormClosing para verificar si los datos están guardados antes de cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarDatosConcubina_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los datos de esta persona. ¿Estás seguro de que deseas cerrar sin guardar?");

        
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
        }
    }
}
