

using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using Ofelia_Sara.Clases.General.Apariencia;
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
           Load +=BaseForm_Load;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigurarTextoEnControles();//carga items especificos a comboBox especificos
            InicializarComboBoxIpp(this);//inicializa valores predeterminados en combobox ipp
      
            BordePanel1();// redondea los bordes unicamente de panel 1
            AjustarLabelEnPanel(); //centra unicamente Label_TITULO
            ReemplazarCursores(this); // Recorre todos los controles del formulario y reemplaza los cursores
                                      // Escuchar cuando se agreguen nuevos controles en tiempo de ejecución
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
            ConfigurarMaxLengthIpp();
            ConfigurarToolTips();
            ConfigurarEventosIpp();
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
                    RedondearBordes.Aplicar(panel1, 15);
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

                using (GraphicsPath path = new GraphicsPath())
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
                mensajeAyuda.Location = new Point(x, y);

                // Mostrar el mensaje
                mensajeAyuda.ShowDialog(formularioActivo);
            }
            else
            {
                // Si no hay un ParentForm, usar un tamaño y posición por defecto
                MensajeGeneral mensajeAyuda = new(mensaje, MensajeGeneral.TipoMensaje.Informacion, null);

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


        #region DATOS IPP

        /// <summary>
        /// CARGAR UN LISTADO DE AÑOS DESDE EL ACTUAL
        /// </summary>
        /// <param name="customComboBox"></param>
        public static void CargarAño(CustomComboBox customComboBox)
        {
            customComboBox.Items.Clear(); // Limpia la lista antes de agregar nuevos valores
            int anioActual = DateTime.Now.Year;

            for (int i = 0; i <= 5; i++) // Desde el año actual hasta los últimos 5 años
            {
                int ultimosDosDigitos = (anioActual - i) % 100;
                customComboBox.Items.Add(ultimosDosDigitos.ToString("D2")); // Agrega con dos dígitos
            }
        }

        /// <summary>
        /// METODO PARA QUE SOLO SE AGREGEN NUMEROS A COMBOBOX IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Ipp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Si el evento viene del InnerTextBox, obtenemos el control padre
                if (sender is CustomTextBox innerTextBox && innerTextBox.Parent is CustomComboBox customComboBox)
                {
                    // Obtiene el texto actual
                    string currentText = customComboBox.TextValue;

                    // Verifica si es un número válido
                    if (int.TryParse(currentText, out _))
                    {
                        // Completa el texto con ceros a la izquierda hasta 6 caracteres
                        string completedText = currentText.PadLeft(2, '0');

                        // Actualiza el texto en el CustomTextBox
                        customComboBox.TextValue = completedText;

                        // Posiciona el cursor al final del texto
                        customComboBox.SelectionStart = customComboBox.TextValue.Length;

                        // Cancela el manejo predeterminado de la tecla Enter
                        e.Handled = true;
                    }
                }
            }
        }



        /// <summary>
        /// llamar en load de cada form para establecer cantidad de caracteres
        /// </summary>
        protected virtual void ConfigurarMaxLengthIpp()
        {
            foreach (Control control in this.Controls)
            {
                AplicarConfiguracionIpp(control);

                // Si hay controles anidados, recorrerlos también
                if (control.HasChildren)
                {
                    RecorrerControlesAnidados(control);
                }
            }
        }


        /// <summary>
        /// agrega 10 items al list del comboBox
        /// </summary>
        /// <param name="comboBox"></param>
        private static void ConfigurarItemsComboBox(CustomComboBox comboBox)
        {
            comboBox.DataSource = null; // Desvincula la lista de datos
            comboBox.Items.Clear();

            for (int i = 0; i <= 10; i++)
            {
                comboBox.Items.Add(i.ToString("D2")); // "00", "01", "02", ..., "10"
            }
        }

        ///// <summary>
        ///// llamar en load de cada form para establecer cantidad de caracteres
        ///// </summary>

        private static void AplicarConfiguracionIpp(Control control)
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
                if (textBox.Name == "textBox_NumeroIpp")
                {
                    textBox.MaxLength = 6;
                }
            }
        }
        /// <summary>
        /// ESTABLECE CARACTERÍSTICAS DE TEXTO EN CONTROLES
        /// </summary>
        private void ConfigurarTextoEnControles()
        {
            foreach (Control control in this.Controls)
            {
                AplicarFormatoTexto(control);

                if (control.HasChildren)
                {
                    RecorrerControlesAnidados(control);
                }
            }
        }

        private static void RecorrerControlesAnidados(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                AplicarFormatoTexto(control);

                if (control.HasChildren)
                {
                    RecorrerControlesAnidados(control);
                }
            }
        }

        private static void AplicarFormatoTexto(Control control)
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

        /// <summary>
        /// Inicializa valores por defecto en los ComboBox IPP
        /// </summary>
        private static void InicializarComboBoxIpp(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CustomComboBox comboBox)
                {
                    switch (comboBox.Name)
                    {
                        case "comboBox_Ipp1":
                        case "comboBox_Ipp2":
                            ConfigurarItemsComboBox(comboBox);
                            comboBox.SelectedIndex = 3; // Posición predeterminada


                            break;
                        case "comboBox_Ipp4":
                            CargarAño(comboBox);
                            break;
                    }
                }

                // Si el control tiene hijos, llamar recursivamente al método
                if (control.HasChildren)
                {
                    InicializarComboBoxIpp(control);
                }
            }
        }




        /// <summary>
        /// Evento Leave para completar con ceros los ComboBox IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Ipp_Leave(object sender, EventArgs e)
        {
            if (sender is CustomComboBox customComboBox)
            {
                if (int.TryParse(customComboBox.TextValue, out _))
                {
                    customComboBox.TextValue = customComboBox.TextValue.PadLeft(2, '0');
                    customComboBox.SelectionStart = customComboBox.TextValue.Length;
                }
            }
        }

    
        /// <summary>
        /// Evento KeyPress para solo permitir números en los TextBox IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                CompletarConCeros(sender as CustomTextBox);
                e.Handled = true; // Evitar que se procese Enter
            }
        }

      
        /// <summary>
        /// Evento Leave para completar con ceros los TextBox IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_NumeroIpp_Leave(object sender, EventArgs e)
        {
            CompletarConCeros(sender as CustomTextBox);
        }

       
        /// <summary>
        ///  Método reutilizable para completar con ceros
        /// </summary>
        /// <param name="customTextBox"></param>
        private static void CompletarConCeros(CustomTextBox customTextBox)
        {
            if (customTextBox != null && int.TryParse(customTextBox.TextValue, out _))
            {
                customTextBox.TextValue = customTextBox.TextValue.PadLeft(6, '0');
                customTextBox.SelectionStart = customTextBox.TextValue.Length;
            }
        }

        /// <summary>
        /// agerga eventos leave y keypress a ComboBoxIPP
        /// </summary>
        protected virtual void ConfigurarEventosIpp()
        {
            foreach (Control control in this.Controls)
            {
                if (control is CustomComboBox customComboBox)
                {
                    customComboBox.Leave += ComboBox_Ipp_Leave;
                }
                else if (control is CustomTextBox customTextBox)
                {
                    customTextBox.Leave += TextBox_NumeroIpp_Leave;
                    customTextBox.KeyPress += TextBox_NumeroIpp_KeyPress;
                }

                // Si hay paneles o controles anidados, recorrerlos también
                if (control.HasChildren)
                {
                    ConfigurarEventosEnHijos(control);
                }
            }
        }

        private void ConfigurarEventosEnHijos(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is CustomComboBox customComboBox)
                {
                    customComboBox.Leave += ComboBox_Ipp_Leave;
                }
                else if (control is CustomTextBox customTextBox)
                {
                    customTextBox.Leave += TextBox_NumeroIpp_Leave;
                    customTextBox.KeyPress += TextBox_NumeroIpp_KeyPress;
                }

                // Si el control tiene más hijos, aplicar recursivamente
                if (control.HasChildren)
                {
                    ConfigurarEventosEnHijos(control);
                }
            }
        }

        /// <summary>
        /// ABRE LOS FORMULARIOS DATOS VICTIMA E IMPUTADO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="formularioSecundario"></param>
        /// <param name="textBoxOrigen"></param>
        /// <param name="propiedadTexto"></param>
        protected void AbrirFormularioSecundario<T>(ref T formularioSecundario, CustomTextBox textBoxOrigen, string propiedadTexto) where T : Form, new()
        {
            if (formularioSecundario == null || formularioSecundario.IsDisposed)
            {
                formularioSecundario = new T();

                // Si el formulario secundario tiene un evento personalizado, suscribirse
                if (formularioSecundario is IFormularioConTexto formularioConTexto)
                {
                    formularioConTexto.TextoCambiado += (s, e) =>
                    {
                        textBoxOrigen.TextValue = formularioConTexto.TextoNombre;
                    };
                }
            }

            // Copia local para evitar el problema con "ref" en la lambda
            T formulario = formularioSecundario;

            // Establecer el texto inicial
            var propiedad = formulario.GetType().GetProperty(propiedadTexto);
            if (propiedad != null)
            {
                propiedad.SetValue(formulario, textBoxOrigen.TextValue);
            }

            // Suscribirse al evento TextChanged del TextBox en el formulario de origen
            textBoxOrigen.TextChanged += (s, ev) =>
            {
                if (propiedad != null)
                {
                    propiedad.SetValue(formulario, textBoxOrigen.TextValue);
                }
            };

            // Obtener el formulario original
            Form originalForm = this;

            // Obtener el tamaño de ambos formularios
            int totalWidth = originalForm.Width + formulario.Width;
            int height = Math.Max(originalForm.Height, formulario.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario secundario a la izquierda del original
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point(startX, startY);

            // Posicionar el formulario original a la derecha
            originalForm.Location = new Point(startX + formulario.Width, startY);

            // Suscribirse al evento FormClosed usando la copia local
            formulario.FormClosed += (s, args) =>
            {
                int centerX = (screenWidth - originalForm.Width) / 2;
                int centerY = (screenHeight - originalForm.Height) / 2;
                originalForm.Location = new Point(centerX, centerY);
            };

            formulario.Show();
        }

        public interface IFormularioConTexto
        {
            event EventHandler TextoCambiado;
            string TextoNombre { get; set; }
        }



        /// <summary>
        /// generico para botones agregar causa,imputado y victima
        /// </summary>
        /// <param name="panelDestino"></param>
        /// <param name="tipoControl"></param>
        /// <param name="etiqueta"></param>
        /// <param name="lista"></param>
        /// <param name="mensajeValidacion"></param>
        protected void AgregarNuevoControl(Panel panelDestino, string tipoControl, string etiqueta, List<string> lista = null, string mensajeValidacion = null)
        {
            // Si se proporciona un mensaje de validación, validar los controles existentes antes de agregar uno nuevo
            if (!string.IsNullOrEmpty(mensajeValidacion) && !ValidarControlesExistentes(panelDestino))
            {
                MensajeGeneral.Mostrar(mensajeValidacion, MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            // Agregar un nuevo control al panel especificado
            var nuevoControl = NuevaPersonaControl.NuevaPersonaControlHelper.AgregarNuevoControl(panelDestino, tipoControl, etiqueta);

            // Si la lista no es nula, agregar el nuevo valor a la lista correspondiente
            if (lista != null && nuevoControl != null)
            {
                lista.Add("Nombre de la nueva " + etiqueta);
            }

            // Si el control es un CustomTextBox, asignar eventos
            if (nuevoControl != null)
            {
                AsignarEventosCustomTextBox(nuevoControl);
            }
        }


        protected void ValidarYHabilitarBoton(CustomTextBox textBox, Button botonPrincipal, Button? botonSecundario, int caracteresMinimos = 5)
        {
            // Contar los caracteres reales (ignorando espacios)
            int caracteresReales = textBox.TextValue.Count(c => !char.IsWhiteSpace(c));

            // Habilita los botones solo si hay al menos 'caracteresMinimos' caracteres no blancos
            bool habilitar = caracteresReales >= caracteresMinimos;

            botonPrincipal.Enabled = habilitar;

            // Si botonSecundario no es null, se habilita
            if (botonSecundario != null)
            {
                botonSecundario.Enabled = habilitar;
            }

            // Cambiar el color de fondo del botonPrincipal
        //    botonPrincipal.BackColor = habilitar ? System.Drawing.Color.GreenYellow : System.Drawing.Color.Tomato;
        }

        protected void RegistrarBotonesAgregar(List<string> victimas, List<string> imputados)
        {
            // Definir la configuración de botones una sola vez (Nombres de los controles)
            ConfiguracionesBotones = new()
    {
        { "btn_AgregarCausa", ("panel_Caratula", "CARATULA", "Causa", null, null) },
        { "btn_AgregarVictima", ("panel_Victima", "VICTIMA", "Victima", victimas,
            "Todos los campos en los controles existentes deben completarse antes de agregar una nueva víctima.") },
        { "btn_AgregarImputado", ("panel_Victima", "IMPUTADO", "Imputado", imputados,
            "Todos los campos en los controles existentes deben completarse antes de agregar un nuevo imputado.") }
    };

            // Buscar y asignar eventos a los botones en tiempo de ejecución
            foreach (var (nombreBoton, config) in ConfiguracionesBotones)
            {
                // Buscar los controles en el formulario hijo
                Button boton = this.Controls.Find(nombreBoton, true).FirstOrDefault() as Button;
                Panel panel = this.Controls.Find(config.Item1, true).FirstOrDefault() as Panel;

                if (boton != null && panel != null)
                {
                    // Guardar la configuración asociada
                    BotonesConfigurados[boton] = (panel, config.Item2, config.Item3, config.Item4, config.Item5);

                    // Evitar múltiples suscripciones
                    boton.Click -= Btn_Agregar_Click;
                    boton.Click += Btn_Agregar_Click;
                }
            }
        }

        private Dictionary<string, (string, string, string, List<string>?, string?)> ConfiguracionesBotones;
        private Dictionary<Button, (Panel, string, string, List<string>?, string?)> BotonesConfigurados = new();

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (sender is Button boton && BotonesConfigurados.TryGetValue(boton, out var config))
            {
                AgregarNuevoControl(config.Item1, config.Item2, config.Item3, config.Item4, config.Item5);
            }
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

        /// <summary>
        /// METODO DE VALIDACION PARA VERIFICAR QUE ESTEN LOS CAMPOS COMPLETOS Y AGREGAR O NO CONTROL
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>


        protected bool ValidarControlesExistentes(Panel panel)
        {
            string tipoPersona = panel.Name.Contains("Victima", StringComparison.OrdinalIgnoreCase) ? "VICTIMA" :
                                 panel.Name.Contains("Imputado", StringComparison.OrdinalIgnoreCase) ? "IMPUTADO" : "PERSONA";

            foreach (Control control in panel.Controls)
            {
                if (control is NuevaPersonaControl personaControl)
                {
                    // Removemos espacios en blanco para contar solo caracteres significativos
                    string texto = personaControl.TextBox_Persona.Text.Trim();

                    if (texto.Length < 3) // Validar al menos 5 caracteres no vacíos
                    {
                        MensajeGeneral.Mostrar($"Complete todos los campos con al menos 3 caracteres para agregar una nueva {tipoPersona}",
                                               MensajeGeneral.TipoMensaje.Advertencia);
                        return false; // Retorna false si hay un control con texto inválido
                    }
                }
            }
            return true; // Todos los controles cumplen con la validación
        }

        protected void AsignarEventosCustomTextBox(Control nuevoControl)
        {
            if (nuevoControl is CustomTextBox customTextBox)
            {
                customTextBox.TextChanged += (s, e) =>
                {
                   
                };
            }
        }

        #endregion

    }
}










































