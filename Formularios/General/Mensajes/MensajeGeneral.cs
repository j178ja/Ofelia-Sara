/*SE LLAMA CREA MENSAJE EN LOS FORMULARIOS ASI:
 
  MensajeGeneral.Mostrar("Debe completar la totalidad de campos.",MensajeGeneral.TipoMensaje.Advertencia);

 */



using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Ofelia_Sara.Formularios.General.Mensajes
{
    public partial class MensajeGeneral : Form
    {
     
      
        #region VARIABLES
        public DateTime FechaMinima { get; set; } = DateTime.MinValue;
        public DateTime FechaSeleccionada { get; private set; }
        public DateTimePicker SelectFecha_Compromiso { get; private set; }
        public DateTimePicker SelectHora_Compromiso { get; private set; }
        private bool datosGuardados = false;
        private Color originalBackColor; // Para almacenar el color original del botón

        #endregion

        public MensajeGeneral(string mensaje, TipoMensaje tipoMensaje, Point? posicion = null)
        {
            InitializeComponent();

            // Configura el mensaje y el icono
            label_Texto.Text = mensaje;
            ConfigurarIcono(tipoMensaje);

            Color bordeForm = Color.Black;
            Color colorBorde = Color.FromArgb(0, 154, 174); // Color del borde
            FormUtils.AplicarBordesRedondeados(this, radioEsquinas: 16, grosorBorde: 2, bordeForm); // Para el formulario
            FormUtils.AplicarBordesRedondeados(panel1, radioEsquinas: 12, grosorBorde: 3, colorBorde); // Para el panel

            // Ajustar altura del Label según el contenido
            AjustarAlturaContenedores();
            PosicionarBotonCerrar();

            // Centrar el label inicialmente
            CenterLabelInPanel();

            // Asignar el evento Resize de panel1
            panel1.Resize += Panel1_Resize;

            btn_No.Visible = false;
            btn_Si.Visible = false;
            Fecha_Compromiso.Visible = false;

            if (SelectFecha_Compromiso == null)
            {
                SelectFecha_Compromiso = new DateTimePicker();
            }

            if (SelectHora_Compromiso == null)
            {
                SelectHora_Compromiso = new DateTimePicker();
            }

            // Configura la posición del formulario si se especificó
            if (posicion.HasValue)
            {
                StartPosition = FormStartPosition.Manual; // Permitir posición manual
                Location = posicion.Value; // Establecer la ubicación
            }
            else
            {
                StartPosition = FormStartPosition.CenterScreen; // Por defecto al centro
            }
        }

        public enum TipoMensaje
        {
            Informacion,
            Advertencia,
            Error,
            Exito,
            Cancelacion
        }

        /// <summary>
        /// ESTABLE ICONO PARA CADA TIPO DE MENSAJE
        /// </summary>
        /// <param name="tipoMensaje"></param>
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

        /// <summary>
        /// ENCAPSULA LOGICA MENSAJE EMERGENTE
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="tipoMensaje"></param>
        /// <param name="posicion"></param>
        public static void Mostrar(string mensaje, TipoMensaje tipoMensaje = TipoMensaje.Informacion, Point? posicion = null)
        {
            using (var form = new MensajeGeneral(mensaje, tipoMensaje, posicion))
            {
                form.ShowDialog(); // Muestra el formulario como modal
            }
        }

        /// <summary>
        /// REDIMENSIONA PANEL1 DE ACUERDO A CONTENIDO
        /// </summary>
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

        /// <summary>
        /// CENTRA EL LABEL EN EL PANEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel1_Resize(object sender, EventArgs e)
        {
            // Centra el label en el panel
            CenterLabelInPanel();
        }

        /// <summary>
        /// CALCULA POSICION PARA CENTRAR EL LABEL
        /// </summary>
        private void CenterLabelInPanel()
        {
            // Calcula la posición X e Y para centrar el label
            int x = (panel1.Width - label_Texto.Width) / 2;
            int y = 65;

            // Asigna la nueva posición al label
            label_Texto.Location = new Point(x, y);
        }
        public void MensajeCompromiso(string mensaje)
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
            btn_No.BackColor = Color.FromArgb(234, 40, 0);
            btn_No.ForeColor = Color.White;
            btn_No.Click += Btn_No_Cancelar_Click;

            btn_Cerrar.Visible = false;
            Fecha_Compromiso.Visible = true;
            Fecha_Compromiso.BringToFront();
            pictureBox_Icono.Visible = false;

        }

        #region BOTONES

        /// <summary>
        /// POSICIONA BOTON CENTRAR
        /// </summary>
        private void PosicionarBotonCerrar()
        {
            // Posiciona btn_Cerrar a 4 píxeles del borde inferior del formulario
            int margenInferior = 4;
            btn_Cerrar.Top = this.ClientSize.Height - btn_Cerrar.Height - margenInferior;
            btn_Si.Top = this.ClientSize.Height - btn_Cerrar.Height - margenInferior;
            btn_No.Top = this.ClientSize.Height - btn_Cerrar.Height - margenInferior;
        }
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {

            this.Close();
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

        /// <summary>
        /// MUESTRA BOTONES DE CONFIRMACION
        /// </summary>
        /// <param name="mostrar"></param>
        public void MostrarBotonesConfirmacion(bool mostrar)
        {
            btn_Si.Visible = mostrar;
            btn_No.Visible = mostrar;
            btn_Cerrar.Visible = false;
            Fecha_Compromiso.Visible = false;
            btn_No.Focus();
            btn_No.BackColor = Color.FromArgb(234, 40, 0);
            btn_No.ForeColor = Color.White;
        }
        private void Btn_Si_Guardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            datosGuardados = true;

            // Verifica que los controles sean del tipo adecuado y que se pueda acceder a su valor
            if (SelectFecha_Compromiso != null && SelectHora_Compromiso != null &&
                SelectFecha_Compromiso.Value != null && SelectHora_Compromiso.Value != null)
            {
                // Combina la fecha y la hora seleccionadas
                FechaSeleccionada = SelectFecha_Compromiso.Value.Date + SelectHora_Compromiso.Value.TimeOfDay;

                // Muestra un mensaje de confirmación con la fecha seleccionada
                Mostrar($"Se ha asignado la fecha {FechaSeleccionada.ToString("dd/MM/yyyy HH:mm")} Hs.", TipoMensaje.Exito);

                // Cierra el formulario después de mostrar el mensaje
                this.Close();
            }
            else
            {
                // Manejo de error si los controles no tienen un valor válido
                Mostrar("No se ha seleccionado una fecha y hora válida.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// BOTON CANCELAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_No_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  // Establece el resultado como Cancel
            this.Close();  // Cierra el formulario
        }

        #endregion

        public static DateTime? MostrarCompromiso(string mensaje, DateTime fechaMinima)
        {
            using (var form = new MensajeGeneral(mensaje, TipoMensaje.Informacion))
            {
                // Establece la fecha mínima en el DateTimePicker de fecha
                form.SelectFecha_Compromiso.MinDate = fechaMinima;

                // Muestra el mensaje de compromiso y configura los controles
                form.MensajeCompromiso(mensaje);

                // Mostrar el formulario y esperar la selección del usuario
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Combina la fecha y la hora seleccionadas en un solo DateTime
                    DateTime fechaCompleta = form.SelectFecha_Compromiso.Value.Date +
                                             form.SelectHora_Compromiso.Value.TimeOfDay;

                    return fechaCompleta;
                }

                return null; // En caso de cancelar
            }
        }
        public DateTime? ObtenerFechaYHoraSeleccionadas()
        {
            if (SelectFecha_Compromiso.Value != null && SelectHora_Compromiso.Value != null)
            {
                return SelectFecha_Compromiso.Value.Date + SelectHora_Compromiso.Value.TimeOfDay;
            }
            return null; // Devuelve null si no se ha seleccionado una fecha o hora
        }

        /// <summary>
        /// MUESTRA SUBRAYADO AL INGRESAR AL CONTROL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subrayado_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Guardar el color original
                originalBackColor = button.BackColor;

                // Cambiar el color del fondo según el color actual
                if (button.BackColor == Color.FromArgb(234, 40, 0))
                {
                    button.BackColor = ControlPaint.Light(button.BackColor); // Hacerlo más claro
                }
                else if (button.BackColor == SystemColors.GradientInactiveCaption)
                {
                    button.BackColor = ControlPaint.Light(button.BackColor); // Hacerlo más claro
                }

                // Iniciar el subrayado animado
                SubrayadoAnimado.Iniciar(button);
            }
        }

        /// <summary>
        /// BORRA SUBRAYADO AL SALIR DEL CONTROL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subrayado_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Restaurar el color original
                button.BackColor = originalBackColor;

                // Detener el subrayado animado
                SubrayadoAnimado.Detener(button);

                // Redibujar el botón para asegurarse de que el subrayado desaparezca
                button.Invalidate();
            }
        }

        /// <summary>
        /// SUBRAYADO ANIMADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subrayado_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Control control)
            {
                // Aplicar el subrayado animado
                SubrayadoAnimado.Aplicar(control, e.Graphics, SystemColors.Highlight, 3);
            }
        }

        private void MensajeGeneral_Load(object sender, EventArgs e)
        {

        }
    }
}
