using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;

namespace  Ofelia_Sara.Controles.Ofl_Sara

{
    public partial class CALENDARIO : Form
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public DateTime SelectedDate { get; private set; }

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

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            SelectedDate = monthCalendar1.SelectionStart; // Obtiene la fecha seleccionada
            datosGuardados = true; // Marcar que los datos fueron guardados
            this.DialogResult = DialogResult.OK;
            this.Close();
            MensajeGeneral.Mostrar("Seleccion guardada.", MensajeGeneral.TipoMensaje.Exito);

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CALENDARIO_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Haga click sobre año, luego mes, y finalice con el dia", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
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

        private void btn_Guardar_MouseHover(object sender, EventArgs e)
        {
            btn_Guardar.BackColor = Color.LimeGreen;
            btn_Guardar.Font = new Font(btn_Guardar.Font, FontStyle.Bold);

        }

        private void btn_Cancelar_MouseHover(object sender, EventArgs e)
        {
            btn_Cancelar.BackColor = Color.LightCoral;
            btn_Cancelar.Font = new Font(btn_Cancelar.Font, FontStyle.Bold);

        }

        private void btn_Guardar_MouseLeave(object sender, EventArgs e)
        {
            btn_Guardar.BackColor = Color.White;
            btn_Guardar.Font = new Font(btn_Cancelar.Font, FontStyle.Regular);

        }

        private void btn_Cancelar_MouseLeave(object sender, EventArgs e)
        {
            btn_Cancelar.BackColor = Color.White;
            btn_Cancelar.Font = new Font(btn_Cancelar.Font, FontStyle.Regular);

        }



    }
}
