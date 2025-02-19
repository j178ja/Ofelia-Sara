using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Ofl_Sara

{
    public partial class CALENDARIO : Form
    {
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados

        #endregion

        #region PROPIEDADES PUBLICAS
        public DateTime SelectedDate { get; private set; }
        public Control ControlInvocador { get; set; }

        #endregion

        #region CONSTRUCTOR
        public CALENDARIO()
        {
            InitializeComponent();
            this.FormClosing += Calendario_FormClosing;
            SelectedDate = DateTime.Now; // Inicializa con la fecha actual
            monthCalendar1.SelectionStart = SelectedDate; // Sincroniza con el calendario
        }
        #endregion

        #region LOAD
        private void CalendarForm_Load(object sender, EventArgs e)
        {
            // No es necesario establecer SelectionMode
            SelectedDate = DateTime.Now; // Inicializa con la fecha actual
            monthCalendar1.SelectionStart = SelectedDate; // Sincroniza con el calendario
            //IncrementarTamaño.Incrementar(btn_Guardar); comentado porque se desplaza
        }
        #endregion

        #region METODOS GENERALES

        private Control ObtenerControlInvocador()
        {
            return this.ControlInvocador; // Devuelve el control que se configuró como invocador
        }


        /// <summary>
        /// MUESTRA MENSAJE DE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CALENDARIO_HelpButtonClicked(object sender, CancelEventArgs e) //se usa asi ya que no se accede a baseform
        {
            // Obtener la posición de la instancia del formulario CALENDARIO en pantalla
            Point formularioPosicion = this.PointToScreen(Point.Empty);

            // Mostrar un mensaje de ayuda
            using var mensajeForm = new MensajeGeneral("Haga click sobre año, luego mes, y finalice con el día.", MensajeGeneral.TipoMensaje.Informacion);

            // Calcular posición centrada sobre el formulario CALENDARIO
            int messageX = formularioPosicion.X + (this.Width / 2) - (mensajeForm.Width / 2);
            int messageY = formularioPosicion.Y - mensajeForm.Height - 3; // Posicionar encima del formulario

            mensajeForm.StartPosition = FormStartPosition.Manual;
            mensajeForm.Location = new Point(messageX, messageY);
            mensajeForm.ShowDialog();

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
            
        }


        /// <summary>
        /// MENSAJE DE CONFIRMACION ANTES DE CERRAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                // Obtener la posición de la instancia del formulario CALENDARIO en pantalla
                Point formularioPosicion = this.PointToScreen(Point.Empty);
                //  FALTA OCULTAR EL CALENDARIO CUANDO SE VISUALIZA EL MENSAJE
                using MensajeGeneral mensajeForm = new(
                    "No has guardado la fecha seleccionada. ¿Estás seguro de que deseas cerrar sin guardar?",
                    MensajeGeneral.TipoMensaje.Advertencia);
                // Calcular posición centrada sobre el formulario CALENDARIO
                int messageX = formularioPosicion.X + (this.Width / 2) - (mensajeForm.Width / 2);
                int messageY = formularioPosicion.Y + (this.Height / 4) - (mensajeForm.Height / 2);

                mensajeForm.StartPosition = FormStartPosition.Manual;
                mensajeForm.Location = new Point(messageX, messageY);

                // Hacer visibles los botones
                mensajeForm.MostrarBotonesConfirmacion(true);

                // Mostrar el formulario como modal y capturar el resultado
                DialogResult result = mensajeForm.ShowDialog();

                // Verificar si el usuario seleccionó "No"
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancelar el cierre del formulario
                }
            }
        }
        #endregion

        #region BOTONES
        private void Btn_Guardar_MouseHover(object sender, EventArgs e)
        {
            btn_Guardar.BackColor = System.Drawing.Color.LimeGreen;
            btn_Guardar.Font = new Font(btn_Guardar.Font, FontStyle.Bold);

        }

        private void Btn_Cancelar_MouseHover(object sender, EventArgs e)
        {
            btn_Cancelar.BackColor = System.Drawing.Color.LightCoral;
            btn_Cancelar.Font = new Font(btn_Cancelar.Font, FontStyle.Bold);

        }

        private void Btn_Guardar_MouseLeave(object sender, EventArgs e)
        {
            btn_Guardar.BackColor = System.Drawing.Color.White;
           btn_Guardar.Font = new Font(btn_Cancelar.Font, FontStyle.Regular);

        }

        private void Btn_Cancelar_MouseLeave(object sender, EventArgs e)
        {
            btn_Cancelar.BackColor = System.Drawing.Color.White;
            btn_Cancelar.Font = new Font(btn_Cancelar.Font, FontStyle.Regular);

        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            SelectedDate = monthCalendar1.SelectionStart; // Obtiene la fecha seleccionada
            datosGuardados = true; // Marcar que los datos fueron guardados
                                   //FALTA AGREGAR PARA QUE SE OCULTE CALENDARIO
            this.DialogResult = DialogResult.OK;
            this.Close();

            // Obtener el control invocador
            Control controlInvocador = ObtenerControlInvocador();
            DateTime selectedDate = monthCalendar1.SelectionStart;
            string formattedDate = selectedDate.ToString("dd/MM/yyyy");

            if (controlInvocador != null)
            {
                // Calcular posición debajo del control invocador
                Point controlPosition = controlInvocador.PointToScreen(Point.Empty);
                using var mensajeForm = new MensajeGeneral($"Selección {formattedDate} guardada.", MensajeGeneral.TipoMensaje.Exito);
                int messageX = controlPosition.X + (controlInvocador.Width / 2) - (mensajeForm.Width / 2);
                int messageY = controlPosition.Y + controlInvocador.Height + 3;

                mensajeForm.StartPosition = FormStartPosition.Manual;
                mensajeForm.Location = new Point(messageX, messageY);
                mensajeForm.ShowDialog();
            }
            else
            {
                // Si no hay control invocador, mostrar en posición por defecto
                MensajeGeneral.Mostrar($"Selección {formattedDate} guardada.", MensajeGeneral.TipoMensaje.Exito);
            }
        }
     
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

    }
}
