using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class NuevaCaratulaControl : UserControl
    {
        #region VARIABLES
        private Label Label_Caratula;
        public CustomTextBox TextBox_Caratula { get; private set; }
        public static int ContadorCaratulas { get; set; } = 1; // Inicia en I
        #endregion

        public NuevaCaratulaControl()
        {
            InitializeComponent();
            InicializarControles(); // Asegura que Label_Caratula esté inicializado

        }

        private void InicializarControles()
        {
            Label_Caratula = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 5), // Ajusta la ubicación del label
                Text = "Carátula " + ConvertToRoman(ContadorCaratulas)
            };

            this.Controls.Add(Label_Caratula);
        }

        public static class NuevaCaratulaControlHelper
        {
            public static void AgregarNuevoControl(Panel panel)
            {
                NuevaCaratulaControl nuevoControl = new NuevaCaratulaControl();

                int nuevaPosicionY = ObtenerPosicionSiguiente(panel);
                nuevoControl.Location = new Point(0, nuevaPosicionY);

                // Asignar número romano
                nuevoControl.ActualizarLabel(ContadorCaratulas);
                ContadorCaratulas++;

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

        /// <summary>
        /// Convierte un número a su representación en números romanos.
        /// </summary>
        private static string ConvertToRoman(int number)
        {
            if (number < 1 || number > 20)
            {
                MensajeGeneral.Mostrar("El número de carátula se encuentra fuera del rango.", MensajeGeneral.TipoMensaje.Advertencia);
                return number.ToString();
            }

            string[] romanos = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X",
                             "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX" };
            return romanos[number - 1]; // Se ajusta al índice del array
        }

        /// <summary>
        /// Método para actualizar los números de los labels en los controles del panel.
        /// </summary>
        private static void ActualizarLabels(Panel panel)
        {
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
            if (Label_Caratula != null)
            {
                Label_Caratula.Text = "Carátula " + ConvertToRoman(nuevoNumero);
            }
        }

        /// <summary>
        //        /// BOTON ELIMINAR
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>
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

            //// Llamar al método de reposicionamiento en el formulario principal
            //Form formularioPrincipal = this.FindForm();
            //if (formularioPrincipal is InicioCierre inicioCierre)
            //{
            //   // inicioCierre.ReposicionarPanelesInferiores();
            //} //  CREAR O BUSCAR METODO PARA REPOSICIONAMIENTO EFICIENTE
        }

        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
        {
          //  MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            if (sender is CustomTextBox customTextBox)
            {
                // Guarda la posición actual del cursor
                int selectionStart = customTextBox.SelectionStart;

                // Convierte el texto a mayúsculas y filtra solo letras, números y espacios
                string originalText = customTextBox.TextValue;
                string processedText = new string(originalText.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                                                             .Select(char.ToUpper).ToArray());

                // Actualiza el texto del TextBox si ha cambiado
                if (processedText != originalText)
                {
                    customTextBox.TextValue = processedText;

                    // Restaura la posición del cursor
                    customTextBox.SelectionStart = Math.Min(selectionStart, customTextBox.TextValue.Length);
                }
            }
        }

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

        private void TextBox_Caratula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza caracteres no válidos.
            }
            else
            {
                // Convierte letras a mayúsculas y mantiene números y espacios sin cambios
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
        }
    }
}
//{
//    public partial class NuevaCaratulaControl : UserControl
//    {
//        #region VARIABLES
//        private Label Label_Caratula;
//        public CustomTextBox TextBox_Caratula { get; private set; }
//        public static int ContadorCaratulas { get; set; } = 2; // Inicia en II
//        #endregion
//        public NuevaCaratulaControl()
//        {
//            InitializeComponent();

//        }


//        public static class NuevaCaratulaControlHelper
//        {
//            public static void AgregarNuevoControl(Panel panel)
//            {
//                NuevaCaratulaControl nuevoControl = new NuevaCaratulaControl();

//                int nuevaPosicionY = ObtenerPosicionSiguiente(panel);
//                nuevoControl.Location = new Point(0, nuevaPosicionY);

//                panel.Controls.Add(nuevoControl);

//                AjustarAlturaPanel(panel);
//            }

//            private static int ObtenerPosicionSiguiente(Panel panel)
//            {
//                if (panel.Controls.Count == 0) return 2;
//                var ultimoControl = panel.Controls[panel.Controls.Count - 1];
//                return ultimoControl.Bottom + 2;
//            }

//            public static void AjustarAlturaPanel(Panel panel)
//            {
//                if (panel.Controls.Count == 0) return;

//                var ultimoControl = panel.Controls[panel.Controls.Count - 1];
//                int nuevaAltura = ultimoControl.Bottom + 2;

//                panel.Height = nuevaAltura;
//            }
//        }
//        //----------------------------------------------------------------------------------------
//        private static string ConvertToRoman(int number)
//        {
//            // Convertir número a romano (simplificado para este caso)
//            if (number == 1) return "I";
//            if (number == 2) return "II";
//            if (number == 3) return "III";
//            if (number == 4) return "IV";
//            if (number == 5) return "V";
//            if (number == 6) return "VI";
//            if (number == 7) return "VII";
//            if (number == 8) return "VIII";
//            if (number == 9) return "IX";
//            if (number == 10) return "X";
//            if (number == 11) return "XI";
//            if (number == 12) return "XII";
//            if (number == 13) return "XIII";
//            if (number == 14) return "XIV";
//            if (number == 15) return "XV";
//            if (number == 16) return "XVI";
//            if (number == 17) return "XVII";
//            if (number == 18) return "XVIII";
//            if (number == 19) return "XIX";
//            if (number == 20) return "XX";
//            else
//            {
//                MensajeGeneral.Mostrar("El número de caratula se encuentra fuera del rango.", MensajeGeneral.TipoMensaje.Advertencia);
//            }
//            return number.ToString();
//        }


//        /// <summary>
//        /// BOTON ELIMINAR
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void Btn_EliminarControl_Click(object sender, EventArgs e)
//        {
//            Panel panel = this.Parent as Panel;
//            if (panel != null)
//            {
//                // Obtener la posición vertical del control a eliminar
//                int posicionY = this.Location.Y;

//                // Eliminar el control
//                panel.Controls.Remove(this);

//                // Reposicionar controles restantes
//                ReposicionarControles(panel, posicionY);

//                // Actualizar los labels después de reposicionar los controles
//                ActualizarLabels(panel);

//                // Decrementar el contador de carátulas
//                ContadorCaratulas--;

//                // Redimensionar el panel después de eliminar el control
//                NuevaCaratulaControlHelper.AjustarAlturaPanel(panel);
//            }

//            //// Llamar al método de reposicionamiento en el formulario principal
//            //Form formularioPrincipal = this.FindForm();
//            //if (formularioPrincipal is InicioCierre inicioCierre)
//            //{
//            //   // inicioCierre.ReposicionarPanelesInferiores();
//            //} //  CREAR O BUSCAR METODO PARA REPOSICIONAMIENTO EFICIENTE
//        }


//        //-------------------------------------------------------------------------
//        private void ReposicionarControles(Panel panel, int posicionY)
//        {
//            foreach (Control ctrl in panel.Controls)
//            {
//                if (ctrl.Location.Y > posicionY)
//                {
//                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y - this.Height - 2);
//                }
//            }
//        }


//        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
//        {
//            if (sender is CustomTextBox customTextBox)
//            {
//                // Guarda la posición actual del cursor
//                int selectionStart = customTextBox.SelectionStart;

//                // Convierte el texto a mayúsculas y filtra solo letras, números y espacios
//                string originalText = customTextBox.TextValue;
//                string processedText = new string(originalText.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
//                                                             .Select(char.ToUpper).ToArray());

//                // Actualiza el texto del TextBox si ha cambiado
//                if (processedText != originalText)
//                {
//                    customTextBox.TextValue = processedText;

//                    // Restaura la posición del cursor
//                    customTextBox.SelectionStart = Math.Min(selectionStart, customTextBox.TextValue.Length);
//                }
//            }
//        }


//        /// <summary>
//        /// METODO ACTUALIZAR CONTADORES LABE
//        /// </summary>
//        /// <param name="panel"></param>
//        private static void ActualizarLabels(Panel panel)
//        {   // Método para actualizar los números de los labels en los controles del panel
//            // Primero, ordenar los controles por su ubicación vertical (en el eje Y)
//            var controlesOrdenados = panel.Controls
//                .OfType<NuevaCaratulaControl>()
//                .OrderBy(c => c.Location.Y)
//                .ToList();

//            int contador = 1;
//            foreach (var control in controlesOrdenados)
//            {
//                control.ActualizarLabel(contador);
//                contador++;
//            }
//        }

//        public void ActualizarLabel(int nuevoNumero)
//        {
//            // Verifica si Label_Caratula no es null antes de acceder a él
//            if (Label_Caratula != null)
//            {
//                Label_Caratula.Text = "Carátula " + nuevoNumero;
//            }
//            else
//            {
//                // Manejar el caso en que Label_Caratula es null
//                Console.WriteLine("Label_Caratula no está inicializado.");
//            }
//        }

//    }
//}
