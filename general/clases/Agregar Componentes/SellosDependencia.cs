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
    public partial class SellosDependencia : BaseForm
    {
        public string TextoDependencia { get; set; }
        public SellosDependencia()
        {
            InitializeComponent();

          
        }

        private void SellosDependencia_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

            ActualizarControles();//Inicializa  el estado de los controles pictureBox
        }
        //-----------------------------------------------------------------------------
        private void SellosDependencia_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Los sellos que agrege serán usados para completar las distintas planillas de las actuaciones", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //--------------------------------------------------------------------------------
        private void textBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto a mayúsculas ignorando caracteres especiales
            string textoConvertido = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(textBox_Dependencia.Text);

            // Mantiene la posición del cursor
            int selectionStart = textBox_Dependencia.SelectionStart;
            int selectionLength = textBox_Dependencia.SelectionLength;

            // Actualiza el texto del TextBox
            textBox_Dependencia.Text = textoConvertido;

            // Restablece la posición del cursor
            textBox_Dependencia.SelectionStart = selectionStart;
            textBox_Dependencia.SelectionLength = selectionLength;

            // Actualiza los controles
            ActualizarControles();
        }


        //-------------------------------------------------------------------------------

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Dependencia.Text))
            {
                MessageBox.Show("Debe ingresar a que dependencia corresponden los sellos.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Verificar que el PictureBox_SelloMedalla tenga una imagen
            if (pictureBox_SelloMedalla.Image == null)
            {
                MessageBox.Show("Debe agregar una imagen al campo SELLO MEDALLA.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Se ha cargado exitosamente a sellos de la dependencia", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //---------------------------------------------------------------------------------
        //-----EVENTOS PARA HABILITAR Y MODIFICAR PICKTUREBOX------------------------------


        //---Propiedad para que traiga el nombre de la dependencia desde el otro formulario
        public string TextBoxText
        {
            get { return textBox_Dependencia.Text; }
            set { textBox_Dependencia.Text = value; }
        }

        //-----------------------------------------------------------------------------------

        private void ActualizarControles()
        {
            // Verifica si TextoDependencia tiene texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Dependencia.Text);

            // Actualiza el estado de los PictureBox
            ActualizarPictureBox(pictureBox_SelloMedalla, esTextoValido);
            ActualizarPictureBox(pictureBox_SelloEscalera, esTextoValido);
            ActualizarPictureBox(pictureBox_SelloFoliador, esTextoValido);
        }

        private void ActualizarPictureBox(PictureBox pictureBox, bool habilitar)
        {
            if (habilitar)
            {
                pictureBox.Enabled = true;
                pictureBox.Tag = Color.LimeGreen; // Color del borde cuando está habilitado
                pictureBox.BackColor = SystemColors.ControlLight;
            }
            else
            {
                pictureBox.Enabled = false;
                pictureBox.Tag = Color.Tomato; // Color del borde cuando está deshabilitado
                pictureBox.BackColor = Color.DarkGray;
            }

            pictureBox.Invalidate(); // Redibuja el borde
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                Color borderColor = pictureBox.Tag is Color ? (Color)pictureBox.Tag : Color.Transparent;

                using (Pen pen = new Pen(borderColor, 3)) // Grosor del borde
                {
                    // Dibuja el borde exterior
                    e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
                }
            }


        }
    }
}