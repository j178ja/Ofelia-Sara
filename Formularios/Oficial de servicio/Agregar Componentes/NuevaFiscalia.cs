
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

            //para redondear bordes de panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            MayusculaSola.AplicarAControl(textBox_Localidad);
            this.FormClosing += NuevaFiscalia_FormClosing;
        }
        #endregion

        #region LOAD
        private void Fiscalia_Load(object sender, EventArgs e)
        {
            InicializarTextBoxes();

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
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
                using MensajeGeneral mensaje = new("No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia);
                // Hacer visibles los botones
                mensaje.MostrarBotonesConfirmacion(true);

                DialogResult result = mensaje.ShowDialog();
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancelar el cierre del formulario
                }
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
            MensajeGeneral.Mostrar("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable en los formularios", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }


        private void InicializarTextBoxes()
        {
            // Suscribirse al evento TextChanged sin conflicto de nombres
            textBox_AgenteFiscal.TextChanged += TextBox_TextChanged;
            textBox_DeptoJudicial.TextChanged += TextBox_TextChanged;

            MayusculaYnumeros.AplicarAControl(textBox_Fiscalia);
            MayusculaSola.AplicarAControl(textBox_Localidad);


        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto del TextBox al Camel Case
            if (sender is CustomTextBox textBox)
            {
                textBox.TextValue = ConvertirACamelCase.Convertir(textBox.TextValue);
                // Mover el cursor al final del texto para evitar que el cursor se mueva al inicio
                textBox.SelectionStart = textBox.TextValue.Length;
            }
        }
        private void TextBox_Fiscalia_TextChanged(object sender, EventArgs e)
        {
            if (sender is CustomTextBox textBox)
            {
                MayusculaYnumeros.AplicarAControl(textBox_Fiscalia);
                // Mover el cursor al final del texto después de la conversión
                textBox.SelectionStart = textBox.Text.Length;
            }
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
