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
            label_Caratula.Text = "Caratula " + ConvertToRoman(ContadorCaratulas++);
            TextBox_Caratula = new TextBox(); // Inicializa el TextBox
         
            this.Controls.Add(TextBox_Caratula); // Agrega el TextBox al control
            this.Load += NuevaCaratulaControl_Load;
        }
        private void NuevaCaratulaControl_Load(object sender, EventArgs e)
        {
            TextBox_Caratula.TextChanged += TextBox_Caratula_TextChanged; // Suscribirse al evento TextChanged
            this.Controls.Add(TextBox_Caratula); // Agrega el TextBox al control
        }

        private string ConvertToRoman(int number)
        {
            // Convertir número a romano (simplificado para este caso)
            if (number == 1) return "I";
            if (number == 2) return "II";
            if (number == 3) return "III";
            if (number == 4) return "IV";
            if (number == 5) return "V";
            if (number == 6) return "VI";
            if (number == 7) return "VII";
            if (number == 8) return "VIII";
            if (number == 9) return "IX";
            if (number == 10) return "X";
            if (number == 10) return "XI";
            if (number == 10) return "XII";
            if (number == 10) return "XIII";
            if (number == 10) return "XIV";
            if (number == 10) return "XV";
            if (number == 10) return "XVI";
            if (number == 10) return "XVII";
            if (number == 10) return "XVIII";
            if (number == 10) return "XIX";
            if (number == 10) return "XX";
            else 
            {
                MessageBox.Show("El número de caratula se encuentra fuera del rango.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            return number.ToString();
        }
        //-----------------------------------------------------------------------------

        //----------BOTON ELIMINAR CONTROL --------------------------------------------
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
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y - this.Height - 20);
                }
            }
        }

        //-------------TEXT BOX-----------------------------------------------
        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            // Aplicar la conversión a mayúsculas
            TextBox_Caratula.Text = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(TextBox_Caratula.Text);
            TextBox_Caratula.SelectionStart = TextBox_Caratula.Text.Length; // Mantener el cursor al final
        }
        //__________________________________________________________________________

       
    }
}
