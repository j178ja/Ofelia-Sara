using Ofelia_Sara.general.clases.Apariencia_General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    public partial class NuevoSecretario : BaseForm
    {
        public NuevoSecretario()
        {
            InitializeComponent();
            this.Load += new EventHandler(NuevoSecretario_Load);// inicializar Load

            btn_Limpiar.Click += new EventHandler(btn_Limpiar_Click);// inicializar btn_Limpiar

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
        }

        private void NuevoSecretario_Load(object sender, EventArgs e)
        {
            // Configurar todos los TextBoxes en el formulario
            ConfigurarTextBoxes(this);
        }

        //-----------BOTON LIMPIAR---------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //-------------BOTON GUARDAR--------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha cargado nuevo Secretario a lista de ComboBox.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //----------------------------------------------------------------------------
        //-------------------CONTROLAR QUE SEAN MAYUSCULAS------------------
        private void ConfigurarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += (s, e) =>
                    {
                        TextBox tb = s as TextBox;
                        if (tb != null)
                        {
                            int pos = tb.SelectionStart;
                            tb.Text = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(tb.Text);
                            tb.SelectionStart = pos;
                        }
                    };
                }
                else if (control.HasChildren)
                {
                    ConfigurarTextBoxes(control);
                }
            }
        }
    }
}

