
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
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
        private string tipoPersona;
        public TextBox TextBox_Persona { get; private set; }

        public event Action<CustomTextBox> ValidarYHabilitarBotonEvent;


        #endregion

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

            MayusculaYnumeros.AplicarAControl(textBox_Persona);
        }
        #endregion

        #region LOAD
        private void NuevaPersonaControl_Load(object sender, EventArgs e)
        {
            ConfigurarTooltipAgregarDatos();
            ToolTipEliminar.Mostrar(btn_EliminarControl, "Eliminar este elemento");
        }
        #endregion
        public static class NuevaPersonaControlHelper
        {
            /// <summary>
            /// agrega un control distinguiendo por tipo de persona y panel de origen
            /// </summary>
            /// <param name="panel"></param>
            /// <param name="tipoPersona"></param>
            /// <param name="origen"></param>
            public static NuevaPersonaControl AgregarNuevoControl(Panel panel, string tipoPersona, string origen = "")
            {
                // Verificar si ya hay 10 o más controles en el panel
                if (panel.Controls.OfType<NuevaPersonaControl>().Count() >= 10)
                {
                    string mensaje = origen switch
                    {
                        "Causa" => "Se ha establecido un máximo de 10 CARÁTULAS por I.P.P.",
                        "Victima" => "Se ha establecido un máximo de 10 VÍCTIMAS por I.P.P.",
                        "Imputado" => "Se ha establecido un máximo de 10 IMPUTADOS por I.P.P.",
                        _ => "No se pueden agregar más de 10 ITEMS."
                    };

                    MensajeGeneral.Mostrar(mensaje, MensajeGeneral.TipoMensaje.Advertencia);
                    return null; // Retorna null si no se puede agregar más controles
                }

                // Obtener el número de iteración basado en la cantidad de controles existentes
                int iteracion = panel.Controls.OfType<NuevaPersonaControl>().Count() + 1;

                // Crear la instancia del control
                NuevaPersonaControl nuevoControl = new(tipoPersona);

                // Calcular la nueva posición en X y Y antes de modificar el control
                Point nuevaPosicion = ObtenerPosicionSiguiente(panel, origen);

                // Si el origen es "Causa", aplicar las modificaciones específicas
                if (origen == "Causa")
                {
                    string numeroRomano = ConvertToRoman(iteracion);
                    nuevoControl.btn_AgregarDatosPersona.Visible = false;
                    nuevoControl.label_Persona.Text = $"CARÁTULA {numeroRomano}";
                    nuevoControl.textBox_Persona.TextAlign = HorizontalAlignment.Center;
                }

                // Asignar la nueva posición calculada
                nuevoControl.Location = nuevaPosicion;

                // Agregar el control al panel
                panel.Controls.Add(nuevoControl);

                // Ajustar la altura del panel después de agregar el nuevo control
                AjustarAlturaPanel(panel);

                return nuevoControl; // Retornar el control agregado
            }


            /// <summary>
            /// posiciona cada control uno debajo del otro
            /// </summary>
            /// <param name="panel"></param>
            /// <param name="origen"></param>
            /// <returns></returns>
            private static Point ObtenerPosicionSiguiente(Panel panel, string origen = "")
            {
                if (panel.Controls.Count == 0)
                {
                    return new Point(10, 2);  // El primer control se posiciona en (10, 2) para el origen "Causa"
                }

                var ultimoControl = panel.Controls[panel.Controls.Count - 1];

                // Si el origen es "Causa", le damos un padding izquierdo de 10
                if (origen == "Causa")
                {
                    // Calculamos la posición X con padding de 10
                    int nuevaPosicionX = 0;

                    // La posición en Y será la siguiente, debajo del último control
                    int nuevaPosicionY = ultimoControl.Bottom + 2;

                    return new Point(nuevaPosicionX, nuevaPosicionY);
                }

                // Si no es "Causa", mantenemos la lógica de la posición Y normal
                return new Point(0, ultimoControl.Bottom + 2);
            }

            /// <summary>
            /// ajusta la altura del panel para contener a los contenedores creados
            /// </summary>
            /// <param name="panel"></param>
            public static void AjustarAlturaPanel(Panel panel)
            {
                if (panel.Controls.Count == 0) return;

                var ultimoControl = panel.Controls[panel.Controls.Count - 1];
                int nuevaAltura = ultimoControl.Bottom + 2;

                panel.Height = nuevaAltura;
            }

            /// <summary>
            /// convierte el numero de iteracion a numeros romanos unicamente para caratula
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            private static string ConvertToRoman(int number)
            {
                string[] romanos = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
                return romanos[number - 1]; // Se ajusta al índice del array
            }
        }


        private void TextBox_Persona_TextChanged(object sender, EventArgs e)
        {
               // Disparar el evento cuando el texto cambie
              ValidarYHabilitarBotonEvent?.Invoke(textBox_Persona);
            // Actualizar el tooltip al cambiar el texto
            ConfigurarTooltipAgregarDatos();
        }

        /// <summary>
        /// PASAR EL TEXTO A MAYUSCULA
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private static string ConvertirTexto(string texto)
        {
            var textoFiltrado = new string(texto.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            return textoFiltrado.ToUpper();
        }
        private string ObtenerNumeroIteracion()
            {
                if (TipoPersona == "Victima")
                {
                    return (ContadorVictimas - 1).ToString(); // Devuelve el número de iteración para Victima
                }
                else if (TipoPersona == "Imputado")
                {
                    return (ContadorImputados - 1).ToString(); // Devuelve el número de iteración para Imputado
                }
                return "0"; // Si no es Victima ni Imputado, retornar 0
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
                    //  Remover cualquier tooltip previo en el botón antes de agregar uno nuevo**
                    TooltipEnControlDesactivado.RemoverToolTip(btn_AgregarDatosPersona);

                    //  Asignar el tooltip con los mensajes correctos
                    TooltipEnControlDesactivado.ConfigurarToolTip(
                        formularioPadre, btn_AgregarDatosPersona, mensajeDesactivado, mensajeActivado
                    );

                    //  Asegurar que el evento de entrada del mouse actualiza correctamente el tooltip**
                    btn_AgregarDatosPersona.MouseEnter -= Btn_AgregarDatosPersona_MouseEnter;
                    btn_AgregarDatosPersona.MouseEnter += Btn_AgregarDatosPersona_MouseEnter;

                    //  Forzar la actualización visual del tooltip
                    toolTip1.Hide(btn_AgregarDatosPersona);  // Oculta cualquier tooltip visible
                    toolTip1.Show(mensajeDesactivado, btn_AgregarDatosPersona, btn_AgregarDatosPersona.Width / 2, btn_AgregarDatosPersona.Height, 2000);
                }
            }

        /// <summary>
        /// METODO PARA QUE ABRA FORMULARIO AGREGAR DATOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarDatosPersona_Click(object sender, EventArgs e)
        {
            Form formulario = null;

            // Obtener el texto del customTextBox_Nombre
            string nombreIngresado = textBox_Persona.TextValue;

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
                // Establecer el texto en el formulario recién creado usando la propiedad TextoNombre
                if (formulario is AgregarDatosPersonalesVictima victimaForm)
                {
                    victimaForm.TextoNombre = nombreIngresado;
                }
                else if (formulario is AgregarDatosPersonalesImputado imputadoForm)
                {
                    imputadoForm.TextoNombre = nombreIngresado;
                }

                // Asignar el número de iteración al título del formulario
                Label labelTitulo = formulario.Controls.Find("label_TITULO", true).FirstOrDefault() as Label;
                if (labelTitulo != null)
                {
                    labelTitulo.Text += $" N° {ObtenerNumeroIteracion()}"; // Usar ObtenerNumeroIteracion en lugar de contadorInstancias
                }

                // Obtener el formulario original
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

        /// <summary>
        /// Evento para manejar el tooltip cuando el mouse entra al botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarDatosPersona_MouseEnter(object sender, EventArgs e)
            {
                toolTip1.Hide(btn_AgregarDatosPersona);  // Oculta tooltips previos
                toolTip1.Show(TooltipEnControlDesactivado.ObtenerToolTipActual(btn_AgregarDatosPersona),
                              btn_AgregarDatosPersona,
                              btn_AgregarDatosPersona.Width / 2,
                              btn_AgregarDatosPersona.Height,
                              2000);
            }
        private void Btn_EliminarControl_Click(object sender, EventArgs e)
        {
            if (this.Parent is Panel panel)
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
