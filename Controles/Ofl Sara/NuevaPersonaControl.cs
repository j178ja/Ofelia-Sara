
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Ofl_Sara
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
            // metodo reposiconamiento
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
            string nombreFormulario = string.Empty;

            // Dependiendo del tipo, seleccionar el nombre del formulario a cargar
            if (TipoPersona == "Victima")
            {
                nombreFormulario = "OfeliaSara.Formularios.DatosPersonales.AgregarDatosPersonalesVictima";
            }
            else if (TipoPersona == "Imputado")
            {
                nombreFormulario = "OfeliaSara.Formularios.DatosPersonales.AgregarDatosPersonalesImputado";
            }

            if (!string.IsNullOrEmpty(nombreFormulario))
            {
                // Cargar el ensamblado dinámicamente
                try
                {
                    // Suponiendo que el ensamblado está cargado o en la misma carpeta que tu ejecutable
                    var assembly = System.Reflection.Assembly.LoadFrom("Ruta_Al_Proyecto_Otro.dll");

                    // Obtener el tipo del formulario
                    var formType = assembly.GetType(nombreFormulario);

                    if (formType != null)
                    {
                        // Crear una instancia del formulario
                        Form formulario = (Form)Activator.CreateInstance(formType);

                        // Mostrar el formulario
                        formulario.ShowDialog();
                    }
                    else
                    {
                        MensajeGeneral.Mostrar("No se pudo encontrar el formulario especificado.", MensajeGeneral.TipoMensaje.Error);
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar("Error al cargar el formulario: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }

    }
}
