using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases.Animaciones;
using Clases.Apariencia;
using Ofelia_Sara.Controles.Controles;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Visu : BaseForm
    {
        public Visu()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            panel_Imagenes.Visible = false;
            panel_DatosVehiculo.Visible = false;
            panel_Descripcion.Visible = false;
        }

        private void Visu_Load(object sender, EventArgs e)
        {
            IncrementarTamaño.Incrementar(btn_AgregarImagen);
            IncrementarTamaño.Incrementar(btn_QuitarImagen);

            Fecha_Instruccion.SelectedDate = DateTime.Now; //para que actualice automaticamente la fecha
        }

        /// <summary>
        /// metodo para destacar seleccion de VISU
        /// </summary>
       
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Asegúrate de que el sender es un RadioButton
            if (sender is RadioButton radioButton)
            {
                // Verifica qué RadioButton fue marcado y aplica el estilo correspondiente
                if (radioButton.Checked)
                {
                    radioButton.Font = new Font(radioButton.Font, FontStyle.Bold | FontStyle.Underline);
                }
                else
                {
                    // Restaura el estilo normal si el RadioButton se desmarca
                    radioButton.Font = new Font(radioButton.Font, FontStyle.Regular);
                }
            }
        }

 
    }
}
