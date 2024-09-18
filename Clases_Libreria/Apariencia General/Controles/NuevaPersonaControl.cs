using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Ofelia_Sara.general.clases.Apariencia_General.Controles.NuevaCaratulaControl;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class NuevaPersonaControl : UserControl
    {
        public string TipoPersona { get; private set; }
        public static int ContadorVictimas { get; set; } = 2; // Inicia en 2 para Victimas
        public static int ContadorImputados { get; set; } = 2; // Inicia en 2 para Imputados
        private string tipoControl;

        public TextBox TextBox_Persona { get; private set; }

        public NuevaPersonaControl(string tipo)
        {
            InitializeComponent();
            tipoControl = tipo;
            label_Persona.Text = tipo + " " + (tipo == "Victima" ? ContadorVictimas++ : ContadorImputados++);
            TipoPersona = tipo;

            // Asocia el evento TextChanged al método de validación
            textBox_Persona.TextChanged += new EventHandler(textBox_Persona_TextChanged);

            //-----para los botones de agregar datos personales completos------------------
            // Inicialmente, deshabilita el botón
            btn_AgregarDatosPersona.Enabled = false;
            btn_AgregarDatosPersona.BackColor = Color.Tomato;


        }

        public static class NuevaPersonaControlHelper
        {
            public static void AgregarNuevoControl(Panel panel, string tipoPersona)
            {
                NuevaPersonaControl nuevoControl = new NuevaPersonaControl(tipoPersona);

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
            // Llamar al método de reposicionamiento en el formulario principal
            Form formularioPrincipal = this.FindForm();
            if (formularioPrincipal is InicioCierre inicioCierre)
            {
               
            }
        }

       
        private void NuevaPersonaControl_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox_Persona_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosPersona.Enabled = !string.IsNullOrWhiteSpace(textBox_Persona.Text))
            {
                btn_AgregarDatosPersona.BackColor = Color.GreenYellow;

            }
            else
            {
                btn_AgregarDatosPersona.BackColor = Color.Tomato;

            }
            // Habilita o deshabilita btn_AgregarVictima según si el TextBox tiene texto
            btn_AgregarDatosPersona.Enabled = !string.IsNullOrWhiteSpace(textBox_Persona.Text);


        }

        private string ConvertirTexto(string texto)
        {
            var textoFiltrado = new string(texto.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            return textoFiltrado.ToUpper();
        }
        //__________________________________________________________________________________________

        //-------METODO PARA QUE ABRA FORMULARIO AGREGAR DATOS ------------------------------------
        private void btn_AgregarDatosPersona_Click(object sender, EventArgs e)
        {
            // Dependiendo del tipo, abrir el formulario correspondiente
            if (TipoPersona == "Victima")
            {
                AgregarDatosPersonalesVictima formVictima = new AgregarDatosPersonalesVictima();
                formVictima.ShowDialog();
            }
            else if (TipoPersona == "Imputado")
            {
                AgregarDatosPersonalesImputado formImputado = new AgregarDatosPersonalesImputado();
                formImputado.ShowDialog();
            }
        }
    }
}
