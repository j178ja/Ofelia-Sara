

using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    public partial class NuevaFiscalia : BaseForm
    {
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        #endregion

        #region CONSTRUCTOR
        public NuevaFiscalia()
        {
            InitializeComponent();

            this.Load += new EventHandler(Fiscalia_Load);// inicializar Load

      
            this.FormClosing += NuevaFiscalia_FormClosing;
        }
        #endregion

        #region LOAD
        private void Fiscalia_Load(object sender, EventArgs e)
        {
            this.Shown += Focus_Shown;//para que haga foco en un textBox
        }
        #endregion
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_Fiscalia.Focus();
        }

        /// <summary>
        /// Mensaje de advertencia al cierre del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaFiscalia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
               MostrarMensajeCierre(e,"No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
               
               
            }
        }

        /// <summary>
        /// mensaje de ayuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FISCALIA_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MostrarMensajeAyuda("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable en los formularios");

        }


       

       



        //---------------------BOTON LIMPIAR------------------------
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        //---------BOTON GUARDAR---------------------------------------
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if
              (string.IsNullOrWhiteSpace(textBox_Fiscalia.TextValue) ||
               string.IsNullOrWhiteSpace(textBox_AgenteFiscal.TextValue) ||
               string.IsNullOrWhiteSpace(textBox_Localidad.TextValue) ||
               string.IsNullOrWhiteSpace(textBox_DeptoJudicial.TextValue))
            {
                MensajeGeneral.Mostrar("Debe completar la totalidad de campos.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {

                // Crear una instancia de Fiscalia con los datos del formulario
                var nuevaFiscalia = new Fiscalias
                {
                    Ufid = textBox_Fiscalia.TextValue,
                    AgenteFiscal = textBox_AgenteFiscal.TextValue,
                    Localidad = textBox_Localidad.TextValue,
                    DeptoJudicial = textBox_DeptoJudicial.TextValue
                };

                // Instanciar FiscaliasManager y llamar a InsertFiscalia para guardar los datos
                // FiscaliasManager fiscaliaManager = new FiscaliasManager(dbConnection);
                // fiscaliaManager.InsertFiscalia(nuevaFiscalia);
                datosGuardados = true;
                MensajeGeneral.Mostrar("Se ha cargado nueva fiscalia y Agente Fiscal en los formularios.", MensajeGeneral.TipoMensaje.Informacion);

                // Limpiar los campos después de guardar
                 LimpiarFormulario.Limpiar(this);
            }
        }
    }
}
