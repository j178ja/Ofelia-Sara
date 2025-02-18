
using Ofelia_Sara.Controles.Controles.Tooltip;

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
       // public string TipoPersona { get; private set; }
        public static int ContadorVictimas { get; set; } = 2; // Inicia en 2 para Victimas
        public static int ContadorImputados { get; set; } = 2; // Inicia en 2 para Imputados
        private string tipoControl;

        public TextBox TextBox_Persona { get; private set; }
        #endregion

        private string tipoPersona;
  

        public string TipoPersona
        {
            get => tipoPersona;
            set
            {
                tipoPersona = value;
                ConfigurarTooltipAgregarDatos(); // Actualiza el Tooltip al cambiar el tipo
            }
        }


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
                // Actualizar el tooltip al cambiar el texto
                ConfigurarTooltipAgregarDatos();

                // Redimensionar el panel después de eliminar el control
                NuevaPersonaControlHelper.AjustarAlturaPanel(panel);
            }
            // metodo reposiconamiento
        }


        private void NuevaPersonaControl_Load(object sender, EventArgs e)
        {
            ConfigurarTooltipAgregarDatos();


            ToolTipEliminar.Mostrar(btn_EliminarControl, "Eliminar este elemento");
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


            // Actualizar el tooltip al cambiar el texto
            ConfigurarTooltipAgregarDatos();
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
                // Cerrar formulario anterior si está abierto
                if (formulario.IsDisposed)
                {
                    formulario = null;
                }

                //obtiene posicion del formulario origen
                Form originalForm = this.FindForm();


                // Obtener dimensiones de ambos formularios
                int totalWidth = originalForm.Width + formulario.Width;
                int height = Math.Max(originalForm.Height, formulario.Height);

                // Calcular la posición para centrar ambos formularios en la pantalla
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int startX = (screenWidth - totalWidth) / 2;
                int startY = (screenHeight - height) / 2;

                // Posicionar el nuevo formulario a la izquierda del formulario original
                formulario.StartPosition = FormStartPosition.Manual;
                formulario.Location = new Point(startX, startY);

                // Posicionar el formulario original a la derecha del nuevo formulario
                originalForm.Location = new Point(startX + formulario.Width, startY);

                // Manejar evento FormClosed para re-centrar el formulario original
                formulario.FormClosed += (s, args) =>
                {
                    int centerX = (screenWidth - originalForm.Width) / 2;
                    int centerY = (screenHeight - originalForm.Height) / 2;

                    originalForm.Location = new Point(centerX, centerY);
                };

                // Mostrar el formulario
                formulario.Show();
            }
            else
            {
                MensajeGeneral.Mostrar("No se pudo determinar el formulario a abrir.", MensajeGeneral.TipoMensaje.Error);
            }
        }
        private void ConfigurarTooltipAgregarDatos()
        {
            if (string.IsNullOrWhiteSpace(TipoPersona))
            {
                return; // No configurar si no hay tipo de persona definido
            }

            string numeroIteracion = ObtenerNumeroIteracion();
            string mensajeDesactivado = $"Completar nombre de {TipoPersona} {numeroIteracion} para ingresar más datos.";
            string mensajeActivado = string.IsNullOrWhiteSpace(textBox_Persona.TextValue)
                ? mensajeDesactivado  // Si el nombre está vacío, usa el mismo mensaje
                : $"Agregar datos personales de {TipoPersona} {textBox_Persona.TextValue}.";

            var formularioPadre = this.FindForm();

            if (formularioPadre != null)
            {
                // **1. Remover cualquier tooltip previo en el botón antes de agregar uno nuevo**
                TooltipEnControlDesactivado.RemoverToolTip(btn_AgregarDatosPersona);

                // **2. Asignar el tooltip con los mensajes correctos**
                TooltipEnControlDesactivado.ConfigurarToolTip(
                    formularioPadre, btn_AgregarDatosPersona, mensajeDesactivado, mensajeActivado
                );

                // **3. Asegurar que el evento de entrada del mouse actualiza correctamente el tooltip**
                btn_AgregarDatosPersona.MouseEnter -= Btn_AgregarDatosPersona_MouseEnter;
                btn_AgregarDatosPersona.MouseEnter += Btn_AgregarDatosPersona_MouseEnter;

                // **4. Forzar la actualización visual del tooltip**
                toolTip1.Hide(btn_AgregarDatosPersona);  // Oculta cualquier tooltip visible
                toolTip1.Show(mensajeDesactivado, btn_AgregarDatosPersona, btn_AgregarDatosPersona.Width / 2, btn_AgregarDatosPersona.Height, 2000);
            }
        }

        // Evento para manejar el tooltip cuando el mouse entra al botón
        private void Btn_AgregarDatosPersona_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Hide(btn_AgregarDatosPersona);  // Oculta tooltips previos
            toolTip1.Show(TooltipEnControlDesactivado.ObtenerToolTipActual(btn_AgregarDatosPersona),
                          btn_AgregarDatosPersona,
                          btn_AgregarDatosPersona.Width / 2,
                          btn_AgregarDatosPersona.Height,
                          2000);
        }



        private string ObtenerNumeroIteracion()
        {
            if (TipoPersona == "Victima")
            {
                return (ContadorVictimas -1).ToString(); // Devuelve el número de iteración para Victima
            }
            else if (TipoPersona == "Imputado")
            {
                return (ContadorImputados -1).ToString(); // Devuelve el número de iteración para Imputado
            }
            return "0"; // Si no es Victima ni Imputado, retornar 0
        }

        private void Btn_EliminarControl_MouseHover(object sender, EventArgs e)
        {
            btn_EliminarControl.BackColor = Color.Red;
            btn_EliminarControl.ForeColor = Color.White;

        }

        private void Btn_EliminarControl_MouseLeave(object sender, EventArgs e)
        {
            btn_EliminarControl.BackColor = Color.Tomato;
            btn_EliminarControl.ForeColor = Color.Black;
        }
    }
}
