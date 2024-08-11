using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class NuevaCaratulaControl : UserControl
    {
        // Asegúrate de definir el TextBox_Caratula
        public TextBox TextBox_Caratula { get; private set; }
        public static int ContadorCaratulas { get; set; } = 2; // Inicia en II

        public NuevaCaratulaControl()
        {
            InitializeComponent();
            label_Caratula.Text = "Causa " + ConvertToRoman(ContadorCaratulas++);
            TextBox_Caratula = new TextBox(); // Inicializa el TextBox
            // Configuración adicional del TextBox si es necesario
            this.Controls.Add(TextBox_Caratula); // Agrega el TextBox al control
        }

        private string ConvertToRoman(int number)
        {
            // Convertir número a romano (simplificado para este caso)
            if (number == 1) return "I";
            if (number == 2) return "II";
            // Añadir más conversiones si es necesario
            return number.ToString();
        }

        private void Btn_EliminarControl_Click(object sender, EventArgs e)
        {
            Panel panel = this.Parent as Panel;
            if (panel != null)
            {
                int posicionY = this.Location.Y;
                panel.Controls.Remove(this);
                ReposicionarControles(panel, posicionY);
                ContadorCaratulas--; // Decrementar contador al eliminar
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
}
