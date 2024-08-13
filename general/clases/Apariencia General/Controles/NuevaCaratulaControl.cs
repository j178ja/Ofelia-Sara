using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class NuevaCaratulaControl : UserControl
    {

        private Label Label_Caratula;
        // Asegúrate de definir el TextBox_Caratula
        public TextBox TextBox_Caratula { get; private set; }
        public static int ContadorCaratulas { get; set; } = 2; // Inicia en II

        public NuevaCaratulaControl()
        {
            InitializeComponent();
          
            

            // Configurar el texto del label aquí

            // Suscribirse al evento Load para cualquier inicialización adicional
            this.Load += NuevaCaratulaControl_Load;
        }

        private void NuevaCaratulaControl_Load(object sender, EventArgs e)
        {

            

        }
        //--------------------------------------------------------------------------------
        public static class NuevaCaratulaControlHelper
        {
            public static void AgregarNuevoControl(Panel panel)
            {
                NuevaCaratulaControl nuevoControl = new NuevaCaratulaControl();

                int nuevaPosicionY = ObtenerPosicionSiguiente(panel);
                nuevoControl.Location = new Point(0, nuevaPosicionY);

                panel.Controls.Add(nuevoControl);

                AjustarAlturaPanel(panel);
            }

            private static int ObtenerPosicionSiguiente(Panel panel)
            {
                if (panel.Controls.Count == 0) return 2;
                var ultimoControl = panel.Controls[panel.Controls.Count - 1];
                return ultimoControl.Bottom + 2;
            }

            public static void AjustarAlturaPanel(Panel panel)
            {
                if (panel.Controls.Count == 0) return;

                var ultimoControl = panel.Controls[panel.Controls.Count - 1];
                int nuevaAltura = ultimoControl.Bottom + 2;

                panel.Height = nuevaAltura;
            }
        }
//----------------------------------------------------------------------------------------
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
            if (number == 11) return "XI";
            if (number == 12) return "XII";
            if (number == 13) return "XIII";
            if (number == 14) return "XIV";
            if (number == 15) return "XV";
            if (number == 16) return "XVI";
            if (number == 17) return "XVII";
            if (number == 18) return "XVIII";
            if (number == 19) return "XIX";
            if (number == 20) return "XX";
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
                // Obtener la posición vertical del control a eliminar
                int posicionY = this.Location.Y;

                // Eliminar el control
                panel.Controls.Remove(this);

                // Reposicionar controles restantes
                ReposicionarControles(panel, posicionY);

                // Actualizar los labels después de reposicionar los controles
                ActualizarLabels(panel);

                // Decrementar el contador de carátulas
                ContadorCaratulas--;

                // Redimensionar el panel después de eliminar el control
                NuevaCaratulaControlHelper.AjustarAlturaPanel(panel);
            }

            // Llamar al método de reposicionamiento en el formulario principal
            Form formularioPrincipal = this.FindForm();
            if (formularioPrincipal is InicioCierre inicioCierre)
            {
                inicioCierre.ReposicionarPanelesInferiores();
            }
        }


        //-------------------------------------------------------------------------
        private void ReposicionarControles(Panel panel, int posicionY)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl.Location.Y > posicionY)
                {
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y - this.Height - 2);
                }
            }
        }

        //-------------TEXT BOX-----------------------------------------------
        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Guarda la posición actual del cursor
                int selectionStart = textBox.SelectionStart;
                int selectionLength = textBox.SelectionLength;

                // Convierte el texto a mayúsculas y filtra solo letras, números y espacios
                string originalText = textBox.Text;
                string processedText = string.Empty;

                foreach (char c in originalText)
                {
                    if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                    {
                        processedText += char.ToUpper(c);
                    }
                }

                // Actualiza el texto del TextBox si ha cambiado
                if (processedText != originalText)
                {
                    textBox.Text = processedText;

                    // Restaura la posición del cursor
                    textBox.SelectionStart = Math.Min(selectionStart, textBox.Text.Length);
                    textBox.SelectionLength = selectionLength;
                }
            }
        }
        //-----------------------------------------------------------
        //----METODO ACTUALIZAR CONTADORES LABEL--------------------
        // Método para actualizar los números de los labels en los controles del panel
        private void ActualizarLabels(Panel panel)
        {
            // Primero, ordenar los controles por su ubicación vertical (en el eje Y)
            var controlesOrdenados = panel.Controls
                .OfType<NuevaCaratulaControl>()
                .OrderBy(c => c.Location.Y)
                .ToList();

            int contador = 1;
            foreach (var control in controlesOrdenados)
            {
                control.ActualizarLabel(contador);
                contador++;
            }
        }

        public void ActualizarLabel(int nuevoNumero)
        {
            // Verifica si Label_Caratula no es null antes de acceder a él
            if (Label_Caratula != null)
            {
                Label_Caratula.Text = "Carátula " + nuevoNumero;
            }
            else
            {
                // Manejar el caso en que Label_Caratula es null
                Console.WriteLine("Label_Caratula no está inicializado.");
            }
        }

    }
}
