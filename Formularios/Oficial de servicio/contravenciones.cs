using Ofelia_Sara.general.clases;
using Clases_Libreria.Reposicon_paneles;
using Clases_Libreria.Botones;
using Clases_Libreria.Texto;
using System;
using System.Windows.Forms;
using System.Drawing;
using Ofelia_Sara.Formularios;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Contravenciones : BaseForm
    {
        public Contravenciones()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }

        private void Contravenciones_Load(object sender, EventArgs e)
        {
            //// Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

           }

      

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
            MessageBox.Show("Formulario eliminado.");
        }

        //------------BOTON GUARDAR---------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_ArtInfraccion.Text) ||
                string.IsNullOrWhiteSpace(textBox_NombreInfractor.Text) ||
                string.IsNullOrWhiteSpace(textBox_ApellidoInfractor.Text) ||
                string.IsNullOrWhiteSpace(textBox_DniInfractor.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar los campos Art, Nombre, Apellido y DNI ", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //------------BOTON IMPRIMIR---------------
        private void MostrarProgreso()
        {
            using (
                MensajeCargarImprimir progressMessageBox = new MensajeCargarImprimir())
            {
                progressMessageBox.ShowDialog();
            }
        }
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            MostrarProgreso();
        }
    }
}
