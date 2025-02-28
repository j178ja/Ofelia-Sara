

using BaseDatos.Entidades;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using Ofelia_Sara.Clases.General.ActualizarElementos;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones.btn_Configuracion;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General
{
    /// <summary>
    /// SE ESTABLECEN TODAS LAS CARACTERISTICAS ESTETICAS QUE AFECTAN AL PROYECTO
    /// </summary>
    public class BaseForm : BaseFormDATOS
    {

        #region VARIABLES
        private Cursor cursorFlecha;
        private Cursor customHandCursor;
        private Cursor CursorLapizDerecha;
        private Timer errorTimer;
        private DatabaseConnection dbConnection;
        private LinkLabel footerLinkLabel;
        private AutocompletarManager autocompletarManager;
        private object panel1;
        public Instruccion _instruccion;// llama a clase que contiene todo el coportamiento de panel_Instruccion
        private SaltoDeImput _saltoDeImput;
        #endregion
        public BaseForm()
        {
            if (IsInDesignMode)
            {
                // Evita inicializaciones en tiempo de diseño
                return;
            }
            // Inicialización en tiempo de ejecución
            InitializeRuntime();
            autocompletarManager = new AutocompletarManager("autocompletar.json");
            _instruccion = new Instruccion(this);
            _saltoDeImput = new SaltoDeImput(this);
        }

        /// <summary>
        /// INICIALIZAR EN TIEMPO DE EJECUCION
        /// </summary>
        protected void InitializeRuntime()
        {
            CargarIconoFormulario();
            InitializeCustomCursors();
            AjustarLabelEnPanel();
            InitializeComponent();
            InitializeFooterLinkLabel();
            AplicarFormatoTexto(this);
            MaxLengthControl(this);
          

            Load += BaseForm_Load;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
          
            BordePanel1();// redondea los bordes unicamente de panel 1
            AjustarLabelEnPanel(); //centra unicamente Label_TITULO
            ReemplazarCursores(this); // Recorre todos los controles del formulario y reemplaza los cursores
                                      // Escuchar cuando se agreguen nuevos controles en tiempo de ejecución
            AplicarFormatoTexto(this);
            MaxLengthControl(this);
          

            this.ControlAdded += (s, e) => AplicarCursorEnControl(e.Control);
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            AplicarCursorEnControl(e.Control);
        }
       

        #region LOAD
        private void BaseForm_Load(object sender, EventArgs e)
        {
            ConfigurarCheckBoxesConImagen();
            InitializeCustomCursors();
            ConfigurarToolTips();
            AplicarFormatoTexto(this);
            MaxLengthControl(this);
        }
        #endregion

        #region CURSORES
        /// <summary>
        /// Inicializa cursores personalizados.
        /// </summary>
        private void InitializeCustomCursors()
        {
            try
            {
                cursorFlecha = new Cursor(new MemoryStream(Properties.Resources.cursorFlecha));
                customHandCursor = new Cursor(new MemoryStream(Properties.Resources.hand));
                CursorLapizDerecha = new Cursor(new MemoryStream(Properties.Resources.CursorlapizDerecha));

                this.Cursor = cursorFlecha; // Aplicar un cursor base si es necesario
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando cursores: {ex.Message}");
            }
        }

        private void ReemplazarCursores(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                // Si el control tiene Cursor = Cursors.Hand, lo reemplazamos
                if (ctrl.Cursor == Cursors.Hand)
                {
                    ctrl.Cursor = customHandCursor;
                }

                // Si el control tiene más subcontroles (paneles, usercontrols, etc.), recorrerlos recursivamente
                if (ctrl.HasChildren)
                {
                    ReemplazarCursores(ctrl);
                }
            }
        }
        private void AplicarCursorEnControl(Control control)
        {
            if (control.Cursor == Cursors.Hand)
            {
                control.Cursor = customHandCursor;
            }

            // Si el control tiene más subcontroles, aplicarlo recursivamente
            if (control.HasChildren)
            {
                foreach (Control subcontrol in control.Controls)
                {
                    AplicarCursorEnControl(subcontrol);
                }
            }

            // Escuchar futuros controles agregados a este control
            control.ControlAdded += (s, e) => AplicarCursorEnControl(e.Control);
        }

        #endregion

        #region TOOLTIPS
        /// <summary>
        /// establece los tooltip para botones que se repiten en varios formularios
        /// </summary>
        protected void ConfigurarToolTips()
        {
            // Buscando los controles por nombre en el formulario actual
            var btn_AgregarDatosVictima = this.Controls.Find("btn_AgregarDatosVictima", true).FirstOrDefault() as Button;
            var btn_AgregarDatosImputado = this.Controls.Find("btn_AgregarDatosImputado", true).FirstOrDefault() as Button;
            var btn_AgregarCausa = this.Controls.Find("btn_AgregarCausa", true).FirstOrDefault() as Button;
            var btn_AgregarVictima = this.Controls.Find("btn_AgregarVictima", true).FirstOrDefault() as Button;
            var btn_AgregarImputado = this.Controls.Find("btn_AgregarImputado", true).FirstOrDefault() as Button;

            // Verificamos que los botones existan y configuramos los tooltips
            if (btn_AgregarDatosVictima != null)
            {
                TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarDatosVictima,
                    "Completar nombre de VICTIMA para ingresar más datos.", "Agregar datos personales de Victima");
            }
            if (btn_AgregarDatosImputado != null)
            {
                TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarDatosImputado,
                    "Completar nombre de IMPUTADO para ingresar más datos.", "Agregar datos personales de Imputado");
            }
            if (btn_AgregarCausa != null)
            {
                TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarCausa,
                    "Ingrese una caratula antes de anexar la siguiente.", "Agregar una caratula adicional");
            }
            if (btn_AgregarVictima != null)
            {
                TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarVictima,
                    "Ingrese una VICTIMA/DENUNCIANTE antes de anexar la siguiente.", "Agregar Victima");
            }
            if (btn_AgregarImputado != null)
            {
                TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarImputado,
                    "Ingrese un IMPUTADO antes de anexar el siguiente.", "Agregar Imputado");
            }

            // Para los botones del panel inferior
            var btn_Buscar = this.Controls.Find("btn_Buscar", true).FirstOrDefault() as Button;
            var btn_Guardar = this.Controls.Find("btn_Guardar", true).FirstOrDefault() as Button;
            var btn_Limpiar = this.Controls.Find("btn_Limpiar", true).FirstOrDefault() as Button;
            var btn_Imprimir = this.Controls.Find("btn_Imprimir", true).FirstOrDefault() as Button;

            if (btn_Buscar != null) ToolTipGeneral.Mostrar(btn_Buscar, "BUSCAR archivos creados, estadísticas y antecedentes");
            if (btn_Guardar != null) ToolTipGeneral.Mostrar(btn_Guardar, "GUARDAR datos ingresados y documentos generados");
            if (btn_Limpiar != null) ToolTipGeneral.Mostrar(btn_Limpiar, "ELIMINAR los datos ingresados en este formulario");
            if (btn_Imprimir != null) ToolTipGeneral.Mostrar(btn_Imprimir, "IMPRIMIR este documento específico");
        }

        #endregion





        /// <summary>
        /// Método generado por el diseñador para inicializar componentes.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            ClientSize = new Size(800, 600);
            Name = "BaseForm";
            Load += BaseForm_Load;
            ResumeLayout(false);
        }

        #region BORDES PANEL 1
        /// <summary>
        /// Configura la apariencia general del formulario, aplicando el redondeo a los paneles.
        /// </summary>
        protected virtual void BordePanel1()
        {
            // Cambiar el color de fondo
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado
            this.BackColor = customColor;

            // Aplicar el redondeo de bordes a todos los paneles
            foreach (Control control in this.Controls)
            {
                if (control is Panel panel1)
                {
                    RedondearBordes.Aplicar(panel1, 8);
                }
            }
        }
        #endregion

        #region FONDO DEGRADE
        /// <summary>
        /// METODO DIBUJAR FONDO DEGRADADO EN FORMULARIOS
        /// </summary>
        /// <param name="g"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private static void DibujarFondoDegradado(Graphics g, int width, int height)
        {
            // Definir el centro del área de degradado
            PointF center = new(width / 2f, height / 2f);

            // Ajustar el radio máximo del degradado para que se ajuste al tamaño del formulario
            float maxRadius = Math.Max(width, height) * 0.75f; // Ajusta el valor según sea necesario

            // Crear un rectángulo que envuelve el área del degradado
            _ = new RectangleF(center.X - maxRadius, center.Y - maxRadius, maxRadius * 2, maxRadius * 2);
        }

        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            // Obtener las dimensiones del formulario
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Llamar al método que dibuja el fondo degradado
            DibujarFondoDegradado(e.Graphics, width, height);
        }
        #endregion

        #region ICONO PRINCIPAL
        /// <summary>
        ///  Método para cargar el ícono según el modo (diseñador o ejecución)
        /// </summary>
        private void CargarIconoFormulario()
        {
            try
            {
                // Obtener el ícono desde los recursos
                var icono = Properties.Resources.EscudoPolicia_ICO;

                if (icono != null)
                {
                    // Asignar el ícono al formulario
                    this.Icon = icono;
                }
                else
                {
                    // Manejo en caso de que el recurso sea nulo
                    MensajeGeneral.Mostrar("El ícono no se pudo cargar desde los recursos.", MensajeGeneral.TipoMensaje.Advertencia);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar el ícono del formulario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }
        #endregion

        #region CENTRAR TITULO

        protected void AjustarLabelEnPanel()
        {
            Panel panel1 = ObtenerPanelTitulo();
            if (panel1 == null) return;

            foreach (Label label in GetAllControls(this).OfType<Label>().Where(lbl => lbl.Name.Contains("TITULO")))
            {
                if (label.Parent != this) // Lo movemos al formulario
                {
                    label.Parent = this;
                }

                // Aplicar estilos personalizados
                label.Height = 30;
                label.BackColor = Color.FromArgb(0, 154, 174);
                label.ForeColor = SystemColors.ControlLightLight;
                label.TextAlign = ContentAlignment.MiddleCenter;

                // Centrar horizontalmente con respecto a panel1
                int nuevoX = panel1.Left + (panel1.Width - label.Width) / 2;

                // 15px deben superponerse con panel1
                int nuevoY = panel1.Top - 15;

                label.Location = new Point(nuevoX, nuevoY);
                label.BringToFront();
            }
        }


        protected virtual Panel ObtenerPanelTitulo()
        {
            return this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "panel1");
        }







        #endregion

        #region FOOTER

        /// <summary>
        /// METODO PARA MOSTRAR FOOTER
        /// </summary>   
        private void InitializeFooterLinkLabel()
        {
            // Llama al método estático de FooterHelper para obtener el footerLabel configurado
            this.footerLinkLabel = FooterHelper.CreateFooterLinkLabel(this);

            this.Controls.Add(this.footerLinkLabel);
        }

        #endregion 

        /// <summary>
        /// METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES BUSCAR-GUARDAR-LIMPIAR
        /// </summary>
        /// <param name="boton"></param>
        protected static void InicializarEstiloBoton(Button boton)
        {
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;

            // Evento MouseEnter: Cambia el tamaño desde el centro y el color de fondo
            boton.MouseEnter += (sender, e) =>
            {
                // Calcula el incremento para centrar el cambio de tamaño
                int incremento = 12;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);
                boton.BackColor = Color.FromArgb(51, 174, 189);
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
                boton.BackColor = Color.FromArgb(51, 174, 189); //20% MAS CLARO QUE EL COLOR OFICIAL Y DE FONDO
            };

            // Evento MouseLeave: Restaura el tamaño y la posición original, y el color de fondo original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.SkyBlue;
            };
        }

        /// <summary>
        /// METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES AGREGAR CARATULA/IMPUTADO/VICTIMA
        /// </summary>
        /// <param name="boton"></param>
        protected static void InicializarEstiloBotonAgregar(Button boton)
        {
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;

            // Evento Paint: Dibuja un borde redondeado y aplica el color del texto solo si el botón está habilitado
            boton.Paint += (sender, e) =>
            {
                int bordeGrosor;
                int bordeRadio;
                Color bordeColor;
                Color textoColor;

                if (boton.Enabled)
                {
                    bordeGrosor = 3;
                    bordeRadio = 4;
                    bordeColor = Color.LightGreen;
                    textoColor = Color.Green; // Color del texto cuando el botón está habilitado
                }
                else
                {
                    bordeGrosor = 2;
                    bordeRadio = 8;
                    bordeColor = Color.Tomato;
                    textoColor = Color.Red;// Color del texto cuando el botón está deshabilitado //NO FUNCIONA!!
                }

                using (GraphicsPath path = new())
                {
                    // Define el rectángulo con el radio especificado
                    path.AddArc(new Rectangle(0, 0, bordeRadio, bordeRadio), 180, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, 0, bordeRadio, bordeRadio), 270, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 0, 90);
                    path.AddArc(new Rectangle(0, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 90, 90);
                    path.CloseAllFigures();

                    // Dibuja el borde con el color especificado
                    e.Graphics.DrawPath(new Pen(bordeColor, bordeGrosor), path);
                }

                // Establece el color del texto
                boton.ForeColor = textoColor;
                boton.TextAlign = ContentAlignment.MiddleCenter;
            };

            // Evento MouseEnter: Cambia el tamaño desde el centro y el color del texto
            boton.MouseEnter += (sender, e) =>
            {
                int incremento = 5;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

                boton.ForeColor = Color.Green; // Cambia el color del texto a verde
                boton.Invalidate(); // Redibuja el botón para aplicar el borde
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
                boton.BackColor = Color.FromArgb(15, 209, 29);
                boton.ForeColor = Color.White; // Cambia el color del texto a blanco
            };

            // Evento MouseLeave: Restaura el tamaño, la posición y el color del texto original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.White;
                boton.ForeColor = Color.Green; // Mantiene el color del texto en verde
                boton.Invalidate(); // Redibuja el botón para aplicar el borde
            };

            // Llama a Invalidate para asegurarse de que el borde se dibuje inicialmente
            boton.Invalidate();
        }

        #region MENSAJE HELP
        /// <summary>
        /// para centrar el mensaje de ayuda en el formulario que se va a cerrar
        /// </summary>
        /// <param name="mensaje"></param>

        protected void MostrarMensajeAyuda(string mensaje)
        {
            if (this.ParentForm != null)
            {
                // Obtener el formulario que activó el HelpButton
                Form formularioActivo = this.FindForm();
                if (formularioActivo == null) return;

                // Crear la instancia del mensaje
                MensajeGeneral mensajeAyuda = new(mensaje, MensajeGeneral.TipoMensaje.Informacion, null);

                // Calcular la posición centrada respecto al formulario activo
                int x = formularioActivo.Left + (formularioActivo.Width - mensajeAyuda.Width) / 2;
                int y = formularioActivo.Top + (formularioActivo.Height - mensajeAyuda.Height) / 2;

                // Establecer la posición centrada
                mensajeAyuda.StartPosition = FormStartPosition.Manual; // Establecer la posición manualmente
                mensajeAyuda.Location = new Point(x, y);

                // Mostrar el mensaje
                mensajeAyuda.ShowDialog(formularioActivo);
            }
            else
            {
                // Si no hay un ParentForm, usar un tamaño y posición por defecto
                MensajeGeneral mensajeAyuda = new(mensaje, MensajeGeneral.TipoMensaje.Informacion, null);
                mensajeAyuda.StartPosition = FormStartPosition.CenterScreen; // Usar CenterScreen si no hay ParentForm
                mensajeAyuda.ShowDialog();
            }
        }

        #endregion

        #region MENSAJE FORM CLOSING
        /// <summary>
        /// para centrar el mensaje al centro del formulario que se va a cerrar
        /// </summary>
        /// <param name="e"></param>
        /// <param name="mensaje"></param>
        protected void MostrarMensajeCierre(FormClosingEventArgs e, string mensaje)
        {
            Form formularioActivo = this.FindForm();
            if (formularioActivo == null) return;

            using MensajeGeneral mensajeCierre = new(mensaje, MensajeGeneral.TipoMensaje.Advertencia, null);
            // Hacer visibles los botones de confirmación
            mensajeCierre.MostrarBotonesConfirmacion(true);

            // Asegurar que el mensaje se posiciona manualmente
            mensajeCierre.StartPosition = FormStartPosition.Manual;

            // Verificar si el formulario aún está visible antes de calcular la posición
            if (formularioActivo.Visible)
            {
                int x = formularioActivo.Left + (formularioActivo.Width - mensajeCierre.Width) / 2;
                int y = formularioActivo.Top + (formularioActivo.Height - mensajeCierre.Height) / 2;
                mensajeCierre.Location = new Point(x, y);
            }

            // Mostrar el mensaje y capturar la respuesta
            DialogResult resultado = mensajeCierre.ShowDialog(formularioActivo);

            // Si el usuario elige "No", cancelar el cierre del formulario
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion


        #region FORMATO TEXTO

        /// <summary>
        /// Formato de texto de campos especificos
        /// </summary>
        /// <param name="control"></param>
        protected static  void AplicarFormatoTexto(Control control)
        {
            if (control is CustomTextBox textBox)
            {
                switch (textBox.Name)
                {
                    case "textBox_Caratula":
                        MayusculaYnumeros.AplicarAControl(textBox);
                        break;
                    case "textBox_Victima":
                    case "textBox_Imputado":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_Edad":
                        ClaseNumeros.SoloNumeros(textBox);
                        break;
                    case "textBox_Dni":
                        ClaseNumeros.AplicarFormatoYLimite(textBox, 10);
                        break;
                    case "textBox_NumeroLegajo":
                        ClaseNumeros.AplicarFormatoYLimite(textBox, 7);
                        break;
                    case "textBox_Nombre":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_Apellido":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_Domicilio":
                        MayusculaYnumeros.AplicarAControl(textBox);
                        break;
                    case "textBox_Localidad":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_Partido":
                        ConvertirACamelCase.AplicarAControl(textBox);
                        break;
                    case "textBox_Fiscalia":
                        MayusculaYnumeros.AplicarAControl(textBox);
                        break;
                    case "textBox_AgenteFiscal":
                        ConvertirACamelCase.AplicarAControl(textBox);
                        break;
                    case "textBox_DeptoJudicial":
                        ConvertirACamelCase.AplicarAControl(textBox);
                        break;
                    case "textBox_LugarNacimiento":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_Ocupacion":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_Apodo":
                        MayusculaSola.AplicarAControl(textBox);
                        break;
                    case "textBox_ArtInfraccion":
                        ClaseNumeros.SoloNumeros(textBox);
                        break;

                }
            }
            else if (control is CustomComboBox comboBox)
            {
                switch (comboBox.Name)
                {
                    case "comboBox_Fiscalia":
                        MayusculaYnumeros.AplicarAControl(comboBox);
                        break;
                    case "comboBox_AgenteFiscal":
                    case "comboBox_DeptoJudicial":
                        ConvertirACamelCase.AplicarAControl(comboBox);
                        break;
                    case "comboBox_Localidad":
                    case "comboBox_Escalafon":
                    case "comboBox_Jerarquia":
                    case "comboBox_Funcion":
                    case "comboBox_Parentesco":
                    case "comboBox_Nacionalidad":
                        MayusculaSola.AplicarAControl(comboBox);
                        break;
                    case "comboBox_Instructor":
                    case "comboBox_Secretario":
                    case "comboBox_Dependencia":
                        MayusculaYnumeros.AplicarAControl(comboBox);
                        break;
                }

                // Aplicar restricción de solo números a los IPP
                if (comboBox.Name == "comboBox_Ipp1" || comboBox.Name == "comboBox_Ipp2" || comboBox.Name == "comboBox_Ipp4")
                {
                    ClaseNumeros.SoloNumeros(comboBox);
                }
            }
        }


        private static void MaxLengthControl(Control control)
        {
            if (control is CustomComboBox customComboBox)
            {
                switch (customComboBox.Name)
                {
                    case "comboBox_Ipp1":
                    case "comboBox_Ipp2":
                    case "comboBox_Ipp4":
                        customComboBox.InnerTextBox.MaxLength = 2;
                        break;
                }
            }
            else if (control is CustomTextBox textBox)
            {
                switch (textBox.Name)
                {
                    case "textBox_NumeroIpp":
                        textBox.MaxLength = 6;
                        break;
                    case "textBox_NumeroLegajo":
                        textBox.MaxLength = 7;// tiene en cuenta el punto
                        break;
                    case "textBox_Dni":
                        textBox.MaxLength = 10;
                        break;
                    case "textBox_Edad":
                        textBox.MaxLength = 2;
                        break;
                    case "textBox_ArtInfraccion":// corresponde a art infraccion contravenciona
                        textBox.MaxLength = 3;
                        break;
                }
            }
        }

        #endregion

        #region COMPORTAMIENTO FISCALIA
        /// <summary>
        /// Método para inicializar los ComboBox de fiscalía desde cualquier formulario que herede de BaseForm.
        /// </summary>
        protected void InicializarComboBoxFiscalia(ComboBox comboFiscalia, ComboBox comboAgente, ComboBox comboLocalidad, ComboBox comboDepto)
        {
            _instruccion.InicializarComboBoxFiscalia(comboFiscalia, comboAgente, comboLocalidad, comboDepto);
        }

        /// <summary>
        /// Método para actualizar los ComboBox cuando cambia la selección de fiscalía.
        /// </summary>
        protected void ActualizarComboBoxFiscalia(string nombreFiscalia, ComboBox comboAgente, ComboBox comboLocalidad, ComboBox comboDepto)
        {
            _instruccion.ActualizarComboBoxFiscalia(nombreFiscalia, comboAgente, comboLocalidad, comboDepto);
        }
        #endregion

        #region VERIFICACION EN PANEL

        /// <summary>
        /// VERIFICA QUE TODOS LOS CAMPOS CONTENGAN ELEMENTOS
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static bool VerificarCamposEnPanel(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                // Si el control es un Panel, llamamos recursivamente al método
                if (control is Panel || control is GroupBox)
                {
                    if (!VerificarCamposEnPanel(control)) // Recursión
                    {
                        return false;
                    }
                }
                // Verificar CustomTextBox
                if (control is CustomTextBox customTextBox)
                {
                    if (string.IsNullOrWhiteSpace(customTextBox.TextValue)) // Usa TextValue si es la propiedad correcta
                    {
                        return false;
                    }
                }

                // Verificar CustomComboBox
                if (control is CustomComboBox customComboBox)
                {
                    if (customComboBox.SelectedIndex == -1 && string.IsNullOrWhiteSpace(customComboBox.TextValue)) // Usa TextValue si es necesario
                    {
                        return false;
                    }
                }

                // Verificar RichTextBox
                if (control is RichTextBox richTextBox)
                {
                    int minimoCaracteres = 20; // Define el mínimo de caracteres requeridos
                    string textoIngresado = richTextBox.Text.Trim(); // Eliminar espacios en blanco iniciales y finales

                    if (string.IsNullOrWhiteSpace(textoIngresado) || textoIngresado.Length < minimoCaracteres)
                    {
                        return false;
                    }
                }

                // Verificar PictureBox
                if (control is PictureBox pictureBox)
                {
                    // Verificar si no hay imagen o si la imagen es la predeterminada
                    if (pictureBox.Image == null || pictureBox.Image == Properties.Resources.agregar_imagen)
                    {
                        return false; // Campo PictureBox sin imagen válida
                    }
                }
            }
            return true; // Todos los campos están completos
        }



        /// <summary>
        /// CAMBIA IMAGEN DE CONFIRMACION Y COLOR DE LABEL
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="pictureBox"></param>
        /// <param name="label"></param>
        /// <param name="validarCampos"></param>
        public static void ValidarPanel(Control panel, PictureBox pictureBox, Label label, Func<bool> validarCampos)
        {
            bool camposValidos = validarCampos();

            if (camposValidos)
            {
                pictureBox.Image = Properties.Resources.verificacion_exitosa;
                label.BackColor = Color.FromArgb(4, 200, 0);
            }
            else
            {
                pictureBox.Image = Properties.Resources.Advertencia_Faltante;
                label.BackColor = Color.FromArgb(0, 192, 192);
            }

            pictureBox.Location = new System.Drawing.Point(
                label.Right + 5,
                label.Top + (label.Height - pictureBox.Height) / 2
            );

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Visible = true;
        }
        #endregion

        public static class CompartirTexto
        {
            public static string Descripcion { get; set; }
        }


        #region CHECKBOX
        protected void ConfigurarCheckBoxesConImagen()
        {
            foreach (var checkBox in GetAllControls(this).OfType<CheckBox>())
            {
                AgregarImagenCheckBox(checkBox);
            }
        }

        private static void AgregarImagenCheckBox(CheckBox checkBox)
        {
            checkBox.Cursor = Cursors.Hand;
            PictureBox pbCheck = new()
            {
                Size = new Size(24, 25),
                Image = Properties.Resources.check_Personalizado,
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false, // Inicialmente oculto
                Anchor = checkBox.Anchor, // Mantiene su posición en caso de redimensionamiento
                Cursor = Cursors.Hand
            };

            checkBox.Parent.Controls.Add(pbCheck);

            // Ajustar la posición al centro del CheckBox
            pbCheck.Location = new Point(
                checkBox.Left + (checkBox.Width - pbCheck.Width) / 2,
                checkBox.Top + (checkBox.Height - pbCheck.Height) / 2
            );

            // Guardar la referencia al PictureBox en el Tag del CheckBox
            checkBox.Tag = pbCheck;

            checkBox.CheckedChanged += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    pbCheck.Visible = true;
                    checkBox.Visible = false;
                    pbCheck.BringToFront(); // Asegura que la imagen esté por encima
                }
            };

            pbCheck.Click += (s, e) =>
            {
                pbCheck.Visible = false;
                checkBox.Visible = true;
                checkBox.Checked = false;
            };
        }



        #endregion

        /// <summary>
        /// metodo recursivo para buscar entre controles
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (var child in GetAllControls(control))
                {
                    yield return child;
                }
            }
        }

      


    }
}










































