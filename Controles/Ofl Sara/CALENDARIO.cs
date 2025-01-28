using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace Ofelia_Sara.Controles.Ofl_Sara

{
    public partial class CALENDARIO : Form
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public DateTime SelectedDate { get; private set; }

        public Control ControlInvocador { get; set; }

        public CALENDARIO()
        {
            InitializeComponent();
            this.FormClosing += Calendario_FormClosing;
            SelectedDate = DateTime.Now; // Inicializa con la fecha actual
            monthCalendar1.SelectionStart = SelectedDate; // Sincroniza con el calendario
        }

        private void CalendarForm_Load(object sender, EventArgs e)
        {
            // No es necesario establecer SelectionMode
            SelectedDate = DateTime.Now; // Inicializa con la fecha actual
            monthCalendar1.SelectionStart = SelectedDate; // Sincroniza con el calendario
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
                using (var mensajeForm = new MensajeGeneral($"Selección {formattedDate} guardada.", MensajeGeneral.TipoMensaje.Exito))
                {
                    int messageX = controlPosition.X + (controlInvocador.Width / 2) - (mensajeForm.Width / 2);
                    int messageY = controlPosition.Y + controlInvocador.Height + 3;

                    mensajeForm.StartPosition = FormStartPosition.Manual;
                    mensajeForm.Location = new Point(messageX, messageY);
                    mensajeForm.ShowDialog();
                }
            }
            else
            {
                // Si no hay control invocador, mostrar en posición por defecto
                MensajeGeneral.Mostrar($"Selección {formattedDate} guardada.", MensajeGeneral.TipoMensaje.Exito);
            }
        }


        private Control ObtenerControlInvocador()
        {
            return this.ControlInvocador; // Devuelve el control que se configuró como invocador
        }



        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CALENDARIO_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Obtener la posición de la instancia del formulario CALENDARIO en pantalla
            Point formularioPosicion = this.PointToScreen(Point.Empty);

            // Mostrar un mensaje de ayuda
            using (var mensajeForm = new MensajeGeneral("Haga click sobre año, luego mes, y finalice con el día.", MensajeGeneral.TipoMensaje.Informacion))
            {
                // Calcular posición centrada sobre el formulario CALENDARIO
                int messageX = formularioPosicion.X + (this.Width / 2) - (mensajeForm.Width / 2);
                int messageY = formularioPosicion.Y - mensajeForm.Height - 3; // Posicionar encima del formulario

                mensajeForm.StartPosition = FormStartPosition.Manual;
                mensajeForm.Location = new Point(messageX, messageY);
                mensajeForm.ShowDialog();

                // Cancelar el evento para que no se cierre el formulario
                e.Cancel = true;
            }
        }


        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void Calendario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado la fecha seleccionada. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
                {
                    // Hacer visibles los botones
                    mensaje.MostrarBotonesConfirmacion(true);

                    DialogResult result = mensaje.ShowDialog();
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Cancelar el cierre del formulario
                    }
                    //           ToolTipGeneral.DisposeToolTips();
                }
            }
        }

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



    }
}
