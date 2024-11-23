/*SE LLAMA CREA MENSAJE EN LOS FORMULARIOS ASI:
 
  MensajeGeneral.Mostrar("Debe completar la totalidad de campos.",MensajeGeneral.TipoMensaje.Advertencia);

 */


using Ofelia_Sara.Controles.Controles;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Mensajes
{
    public partial class MensajeGeneral : Form
    {
        public DateTime FechaMinima { get; set; } = DateTime.MinValue;

        private bool datosGuardados = false;


        public MensajeGeneral(string mensaje, TipoMensaje tipoMensaje)
        {
            InitializeComponent();

            // Configura el mensaje y el icono
            label_Texto.Text = mensaje;
            ConfigurarIcono(tipoMensaje);

            //Color bordeForm = System.Drawing.Color.DarkGray;
            Color bordeForm = Color.Black;
            Color colorBorde = Color.FromArgb(0, 154, 174); // Color del borde
            FormUtils.AplicarBordesRedondeados(this, radioEsquinas: 16, grosorBorde: 2, bordeForm); // Para el formulario
            FormUtils.AplicarBordesRedondeados(panel1, radioEsquinas: 12, grosorBorde: 3, colorBorde); // Para el panel

            // Configurar la fecha mínima en el control Fecha_Audiencia
            Fecha_Audiencia.MinDate = FechaMinima;
            Fecha_Audiencia.SelectedDate = FechaMinima > DateTime.Now ? FechaMinima : DateTime.Now;

            // Fecha_Audiencia.SelectedDate = DateTime.Now; //mantener actualizada fecha

            // Ajustar altura del Label según el contenido
            AjustarAlturaContenedores();
            PosicionarBotonCerrar();

            // Centrar el label inicialmente
            CenterLabelInPanel();

            // Asignar el evento Resize de panel1
            panel1.Resize += panel1_Resize;

            btn_No.Visible = false;
            btn_Si.Visible = false;
            Fecha_Audiencia.Visible = false;



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



        private void Btn_Si_Click(object sender, EventArgs e)
        {
            // this.DialogResult = DialogResult.Yes;
            btn_Si.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;

            this.Close();
        }


        public void MostrarBotonesConfirmacion(bool mostrar)
        {
            btn_Si.Visible = mostrar;
            btn_No.Visible = mostrar;
            btn_Cerrar.Visible = false;
            Fecha_Audiencia.Visible = false;
            btn_No.Focus();
            btn_No.BackColor = Color.FromArgb(255, 70, 70);
        }

        public void MensajeAudiencia(string mensaje)
        {
            label_Texto.Text = mensaje; // lbl_Mensaje es el Label que muestra el mensaje en el formulario

            // Configura la visibilidad de los controles
            btn_Si.Visible = true;
            btn_Si.Text = "GUARDAR";
            btn_Si.BackColor = Color.LimeGreen;
            btn_Si.ForeColor = Color.Black;
            btn_Si.Click += Btn_Si_Guardar_Click;

            btn_No.Visible = true;
            btn_No.Text = "CANCELAR";
            btn_No.BackColor = Color.IndianRed;
            btn_No.ForeColor = Color.White;
            btn_No.Click += Btn_No_Cancelar_Click;

            btn_Cerrar.Visible = false;
            Fecha_Audiencia.Visible = true;
            pictureBox_Icono.Visible = false;
        }

        // Manejador para el evento Click del botón "GUARDAR"
        private void Btn_Si_Guardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;  // Establece el resultado del formulario como OK
            datosGuardados = true;

            // Aquí podrías agregar la lógica de guardar la fecha de la audiencia
            Mostrar("Se ha asignado la fecha indicada", TipoMensaje.Exito);

            this.Close();  // Cierra el formulario
        }


        // Manejador para el evento Click del botón "CANCELAR"
        private void Btn_No_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  // Establece el resultado como Cancel
            this.Close();  // Cierra el formulario
        }



        public static DialogResult MostrarAudiencia(string mensaje, TimePickerPersonalizado timePicker)
        {
            DateTime fechaBase = timePicker.SelectedDate; // Obteniendo la fecha base
            using (var form = new MensajeGeneral(mensaje, TipoMensaje.Informacion))
            {
                form.FechaMinima = fechaBase; // Configurando la fecha mínima
                form.MensajeAudiencia(mensaje);
                return form.ShowDialog(); // Devolver el resultado del diálogo
            }
        }




        private void Fecha_Audiencia_ValueChanged(object sender, EventArgs e)
        {
            if (Fecha_Audiencia.SelectedDate < FechaMinima)
            {
                MensajeGeneral.Mostrar("Seleccione una fecha posterior a la fecha de inicio de actuaciones.",
                    MensajeGeneral.TipoMensaje.Advertencia);
                Fecha_Audiencia.SelectedDate = FechaMinima;
            }
        }





    }
}
