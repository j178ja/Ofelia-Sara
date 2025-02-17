
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Ofl_Sara
{
    /// <summary>
    /// CONTROL PARA AGREGAR NUEVAS VICTIMAS E IMPUTADOS
    /// </summary>
    public partial class NuevaPersonaControl : UserControl
    {
        #region VARIABLES
        public string TipoPersona { get; private set; }
        public static int ContadorVictimas { get; set; } = 2; // Inicia en 2 para Victimas
        public static int ContadorImputados { get; set; } = 2; // Inicia en 2 para Imputados
        private string tipoControl;

        public TextBox TextBox_Persona { get; private set; }
        #endregion

        #region CONSTRUCTOR
        public NuevaPersonaControl(string tipo)
        {
            InitializeComponent();
            tipoControl = tipo;
            label_Persona.Text = tipo + " " + (tipo == "Victima" ? ContadorVictimas++ : ContadorImputados++);
            TipoPersona = tipo;

            // Asocia el evento TextChanged al método de validación
            textBox_Persona.TextChanged += new EventHandler(TextBox_Persona_TextChanged);

            //-----para los botones de agregar datos personales completos------------------
            // Inicialmente, deshabilita el botón
            btn_AgregarDatosPersona.Enabled = false;
            btn_AgregarDatosPersona.BackColor = Color.Tomato;


        }
        #endregion
        public static class NuevaPersonaControlHelper
        {
            public static void AgregarNuevoControl(Panel panel, string tipoPersona)
            {
                NuevaPersonaControl nuevoControl = new(tipoPersona);

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

        private void Btn_EliminarControl_Click(object sender, EventArgs e)
        {
            Panel panel = this.Parent as Panel;
            if (panel != null)
            {
                int posicionY = this.Location.Y;
                panel.Controls.Remove(this);
                //  ReposicionarControles(panel, posicionY);

                if (tipoControl == "Victima") ContadorVictimas--;
                else ContadorImputados--;

                // Redimensionar el panel después de eliminar el control
                NuevaPersonaControlHelper.AjustarAlturaPanel(panel);
            }
            // metodo reposiconamiento
        }


        private void NuevaPersonaControl_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_Persona_TextChanged(object sender, EventArgs e)
        {
            // Filtra y convierte el texto
            string textoConvertido = ConvertirTexto(textBox_Persona.TextValue);

            // Evita ciclos infinitos al actualizar solo si el texto cambia
            if (textBox_Persona.TextValue != textoConvertido)
            {
                textBox_Persona.TextValue = textoConvertido;
                textBox_Persona.SelectionStart = textBox_Persona.TextValue.Length; // Mantiene el cursor al final
            }

            // Contar los caracteres reales (ignorando espacios)
            int caracteresReales = textoConvertido.Count(c => !char.IsWhiteSpace(c));

            // Habilita el botón solo si hay al menos 3 caracteres no blancos
            bool habilitar = caracteresReales >= 3;

            btn_AgregarDatosPersona.Enabled = habilitar;

            // Cambiar color del botón según estado
            btn_AgregarDatosPersona.BackColor = habilitar ? Color.GreenYellow : Color.Tomato;
        }



        private static string ConvertirTexto(string texto)
        {
            var textoFiltrado = new string(texto.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            return textoFiltrado.ToUpper();
        }
        /// <summary>
        /// METODO PARA QUE ABRA FORMULARIO AGREGAR DATOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AgregarDatosPersona_Click(object sender, EventArgs e)
        {
            Form formulario = null;

            // Dependiendo del tipo, instanciar el formulario correspondiente
            if (TipoPersona == "Victima")
            {
                formulario = new AgregarDatosPersonalesVictima();
            }
            else if (TipoPersona == "Imputado")
            {
                formulario = new AgregarDatosPersonalesImputado();
            }

            if (formulario != null)
            {
                formulario.ShowDialog();
            }
            else
            {
                MensajeGeneral.Mostrar("No se pudo determinar el formulario a abrir.", MensajeGeneral.TipoMensaje.Error);
            }
        }

        private void Btn_EliminarControl_MouseHover(object sender, EventArgs e)
        {
            btn_EliminarControl.BackColor = Color.Red;
            btn_EliminarControl.ForeColor = Color.White;
         
        }
    }
}
