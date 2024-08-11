using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class NuevaPersonaControl : UserControl
    {
        public static int ContadorVictimas { get; set; } = 2; // Inicia en 2 para Victimas
        public static int ContadorImputados { get; set; } = 2; // Inicia en 2 para Imputados
        private string tipoControl;

        // Asegúrate de definir el TextBox_Persona
        public TextBox TextBox_Persona { get; private set; }

        public NuevaPersonaControl(string tipo)
        {
            InitializeComponent();
            tipoControl = tipo;
            label_Persona.Text = tipo + " " + (tipo == "Victima" ? ContadorVictimas++ : ContadorImputados++);
            TextBox_Persona = new TextBox(); // Inicializa el TextBox
            // Configuración adicional del TextBox si es necesario
            this.Controls.Add(TextBox_Persona); // Agrega el TextBox al control
        }

        private void Btn_EliminarControl_Click(object sender, EventArgs e)
        {
            Panel panel = this.Parent as Panel;
            if (panel != null)
            {
                int posicionY = this.Location.Y;
                panel.Controls.Remove(this);
                ReposicionarControles(panel, posicionY);
                if (tipoControl == "Victima") ContadorVictimas--;
                else ContadorImputados--;
            }
        }

        private void ReposicionarControles(Panel panel, int posicionY)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl.Location.Y > posicionY)
                {
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y - this.Height - 10);
                }
            }
        }
    }

    // Clase auxiliar para manejar la inserción
    public static class NuevaPersonaControlInserter
    {
        public static void InsertarNuevaPersonaControl(Panel panel, string tipoPersona)
        {
            // Calcular la nueva posición Y basada en la cantidad de controles existentes en el panel
            int nuevaPosicionY = CalcularPosicionY(panel);

            // Crear una instancia del control NuevaPersonaControl
            NuevaPersonaControl nuevaPersonaControl = new NuevaPersonaControl(tipoPersona)
            {
                Location = new Point(0, nuevaPosicionY) // X = 0 (alineado a la izquierda del panel), Y = calculada
            };

            // Insertar el control en el panel
            panel.Controls.Add(nuevaPersonaControl);

            // Ajustar la altura del panel para acomodar el nuevo espacio
            panel.Height += nuevaPersonaControl.Height + 9;
        }

        private static int CalcularPosicionY(Panel panel)
        {
            int posicionY = 10; // Posición inicial
            int alturaControl = 20; // Altura de cada NuevaPersonaControl
            int espacioEntreControles = 9; // Espacio entre cada control

            // Recorrer todos los controles en el panel para calcular la posición Y
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is NuevaPersonaControl)
                {
                    // Ajustar posicionY sumando la altura del control más el espacio entre controles
                    posicionY = ctrl.Location.Y + alturaControl + espacioEntreControles;
                }
            }

            return posicionY;
        }
    }
}
