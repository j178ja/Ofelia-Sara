
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases_Libreria.Texto;
using Clases_Libreria.Botones;
using Ofelia_Sara.Formularios;
using Clases_Libreria.Apariencia;
using Interfaces_Libreria.Interfaces;
using BaseDatos_Libreria.Entidades;

namespace Ofelia_Sara.Agregar_Componentes
{
    public partial class NuevaFiscalia: BaseForm, IFormulario
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
        // Implementación del método de la interfaz IFormulario
        public void Inicializar()
        {
            //para interfaz formulario
        }
        private void FISCALIA_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable en los formularios", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //---------BOTON GUARDAR---------------------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if
              (string.IsNullOrWhiteSpace(textBox_Fiscalia.Text) ||
               string.IsNullOrWhiteSpace(textBox_AgenteFiscal.Text) ||
               string.IsNullOrWhiteSpace(textBox_Localidad.Text)||
               string.IsNullOrWhiteSpace(textBox_DeptoJudicial.Text))
            {
                MessageBox.Show("Debe completar la totalidad de campos.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Fiscalia nuevaFiscalia = new Fiscalia
                {
                    NombreFiscalia = textBox_Fiscalia.Text,
                    AgenteFiscal = textBox_AgenteFiscal.Text,
                    Localidad = textBox_Localidad.Text,
                    DeptoJudicial = textBox_DeptoJudicial.Text
                };
                // Agregar la nueva fiscalía a la lista usando el FiscaliaManager
                FiscaliaManager.AgregarFiscalia(nuevaFiscalia);

                MessageBox.Show("Se ha cargado nueva fiscalia y Agente Fiscal en los formularios.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos después de guardar
                // LimpiarTextBox();
                LimpiarFormulario.Limpiar(this);
            }
        }
    }
}
