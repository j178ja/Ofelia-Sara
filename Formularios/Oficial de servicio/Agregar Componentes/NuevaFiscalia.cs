
using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
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
        public NuevaFiscalia()
        {
            InitializeComponent();

            this.Load += new EventHandler(Fiscalia_Load);// inicializar Load

            //para redondear bordes de panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            MayusculaSola.AplicarAControl(textBox_Localidad);

        }

        private void Fiscalia_Load(object sender, EventArgs e)
        {
            InicializarTextBoxes();

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            this.Shown += Focus_Shown;//para que haga foco en un textBox
        }
        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_Fiscalia.Focus();
        }

        private void FISCALIA_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable en los formularios", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        //------------------------------------------------------------------------------
        private void InicializarTextBoxes()
        {
            // Suscribirse al evento TextChanged sin conflicto de nombres
            textBox_AgenteFiscal.TextChanged += TextBox_TextChanged;
            textBox_DeptoJudicial.TextChanged += TextBox_TextChanged;

            MayusculaYnumeros.AplicarAControl(textBox_Fiscalia);
            MayusculaSola.AplicarAControl(textBox_Localidad);


        }
        ////--------------------------------------------------------------------
        //private void LimpiarTextBox()
        //{
        //    textBox_Fiscalia.Clear();
        //    textBox_AgenteFiscal.Clear();
        //    textBox_Localidad.Clear();
        //    textBox_DeptoJudicial.Clear();
        //}


        //--------------------------------------------------------------------
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto del TextBox al Camel Case
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = ConvertirACamelCase.Convertir(textBox.Text);
                // Mover el cursor al final del texto para evitar que el cursor se mueva al inicio
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
        private void TextBox_Fiscalia_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                MayusculaYnumeros.AplicarAControl(textBox_Fiscalia);
                // Mover el cursor al final del texto después de la conversión
                textBox.SelectionStart = textBox.Text.Length;
            }
        }



        //---------------------BOTON LIMPIAR------------------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        //---------BOTON GUARDAR---------------------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if
              (string.IsNullOrWhiteSpace(textBox_Fiscalia.Text) ||
               string.IsNullOrWhiteSpace(textBox_AgenteFiscal.Text) ||
               string.IsNullOrWhiteSpace(textBox_Localidad.Text) ||
               string.IsNullOrWhiteSpace(textBox_DeptoJudicial.Text))
            {
                MessageBox.Show("Debe completar la totalidad de campos.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                // Crear una instancia de Fiscalia con los datos del formulario
                var nuevaFiscalia = new Fiscalia
                {
                    Ufid = textBox_Fiscalia.Text,
                    AgenteFiscal = textBox_AgenteFiscal.Text,
                    Localidad = textBox_Localidad.Text,
                    DeptoJudicial = textBox_DeptoJudicial.Text
                };

                // Instanciar FiscaliasManager y llamar a InsertFiscalia para guardar los datos
                // FiscaliasManager fiscaliaManager = new FiscaliasManager(dbConnection);
                // fiscaliaManager.InsertFiscalia(nuevaFiscalia);

                MensajeGeneral.Mostrar("Se ha cargado nueva fiscalia y Agente Fiscal en los formularios.", MensajeGeneral.TipoMensaje.Informacion);

                // Limpiar los campos después de guardar
                // LimpiarTextBox();
                LimpiarFormulario.Limpiar(this);
            }
        }
    }
}
