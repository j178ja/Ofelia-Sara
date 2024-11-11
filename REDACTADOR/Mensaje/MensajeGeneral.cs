/*SE LLAMA CREA MENSAJE EN LOS FORMULARIOS ASI:
 
  MensajeGeneral.Mostrar("Debe completar la totalidad de campos.",MensajeGeneral.TipoMensaje.Advertencia);

 */


using System;
using System.Drawing;
using System.Windows.Forms;

namespace REDACTADOR.Mensaje
{
    public partial class MensajeGeneral : Form
    {
        public MensajeGeneral(string mensaje, TipoMensaje tipoMensaje)
        {
            InitializeComponent();

            // Configura el mensaje y el icono
            label_Texto.Text = mensaje;
            ConfigurarIcono(tipoMensaje);

            //Color bordeForm = System.Drawing.Color.DarkGray;
            Color bordeForm = Color.Black;
            Color colorBorde = Color.FromArgb(0, 154, 174); // Color del borde
            FormUtils.BordesRedondeados(this, radioEsquinas: 16, grosorBorde: 2, bordeForm); // Para el formulario
            FormUtils.BordesRedondeados(panel1, radioEsquinas: 12, grosorBorde: 3, colorBorde); // Para el panel

            // Ajustar altura del Label según el contenido
            AjustarAlturaContenedores();
            PosicionarBotonCerrar();

            // Centrar el label inicialmente
            CenterLabelInPanel();

            // Asignar el evento Resize de panel1
            panel1.Resize += panel1_Resize;

            btn_No.Visible = false;
            btn_Si.Visible = false;
        }
        public enum TipoMensaje
        {
            Informacion,
            Advertencia,
            Error,
            Exito,
            Cancelacion
        }

        private void ConfigurarIcono(TipoMensaje tipoMensaje)
        {
            switch (tipoMensaje)
            {
                case TipoMensaje.Informacion:
                    pictureBox_Icono.Image = Properties.Resources.IconoInformacion;
                    break;
                case TipoMensaje.Advertencia:
                    pictureBox_Icono.Image = Properties.Resources.IconoAdvertencia;
                    break;
                case TipoMensaje.Error:
                    pictureBox_Icono.Image = Properties.Resources.IconoError;
                    break;
                case TipoMensaje.Exito:
                    pictureBox_Icono.Image = Properties.Resources.IconoExito;
                    break;
                case TipoMensaje.Cancelacion:
                    pictureBox_Icono.Image = Properties.Resources.IconoCancelacion;
                    break;
                default:
                    pictureBox_Icono.Image = null;
                    break;
            }
        }

        public static void Mostrar(string mensaje, TipoMensaje tipoMensaje = TipoMensaje.Informacion)
        {
            using (var form = new MensajeGeneral(mensaje, tipoMensaje))
            {
                form.ShowDialog(); // Muestra el formulario como modal
            }
        }


        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void AjustarAlturaContenedores()
        {
            // Deshabilita el AutoSize del Label para controlar su tamaño manualmente
            label_Texto.AutoSize = false;

            // Fija el ancho del Label y permite que se ajuste verticalmente al texto
            int anchoFijoLabel = label_Texto.Width;
            label_Texto.MaximumSize = new Size(anchoFijoLabel, 0); // Máximo ancho, altura flexible
            label_Texto.AutoSize = true; // Ahora el label se expandirá solo hacia abajo

            // Obtener el nuevo alto del Label después de ajustarse al texto
            int nuevoAltoLabel = label_Texto.Height;

            // Ajustar altura de panel1 para que abarque el label y un margen vertical adicional
            int paddingVertical = 20; // Margen extra dentro del panel
            panel1.Height = label_Texto.Top + nuevoAltoLabel + paddingVertical;

            // Ajustar altura del formulario MensajeGeneral
            int margenFormulario = 20; // Espacio adicional para el margen inferior del formulario
            this.Height = panel1.Top + panel1.Height + margenFormulario;
        }

        private void PosicionarBotonCerrar()
        {
            // Posiciona btn_Cerrar a 4 píxeles del borde inferior del formulario
            int margenInferior = 4;
            btn_Cerrar.Top = this.ClientSize.Height - btn_Cerrar.Height - margenInferior;
            btn_Si.Top = this.ClientSize.Height - btn_Cerrar.Height - margenInferior;
            btn_No.Top = this.ClientSize.Height - btn_Cerrar.Height - margenInferior;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            // Centra el label en el panel
            CenterLabelInPanel();
        }

        private void CenterLabelInPanel()
        {
            // Calcula la posición X e Y para centrar el label
            int x = (panel1.Width - label_Texto.Width) / 2;
            int y = 65;

            // Asigna la nueva posición al label
            label_Texto.Location = new Point(x, y);
        }

        // Dentro de MensajeGeneral

        private void Btn_Si_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        // En MensajeGeneral
        public void MostrarBotonesConfirmacion(bool mostrar)
        {
            btn_Si.Visible = mostrar;
            btn_No.Visible = mostrar;
            btn_Cerrar.Visible = false;
            btn_No.Focus();
            btn_No.BackColor = Color.FromArgb(255, 70, 70);
        }

    }
}
