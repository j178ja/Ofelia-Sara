﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using BaseDatos.Adm_BD;
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Clases.BaseDatos;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;

namespace Ofelia_Sara.Formularios.General
{
    public class BaseForm : BaseFormBase
    {
        // Propiedades y campos específicos de BaseForm
        private Cursor customHandCursor;
        private Cursor CursorLapizDerecha;
        private Timer errorTimer;
        private DatabaseConnection dbConnection;
        private LinkLabel footerLinkLabel;

        protected ComisariasManager dbManager;
        protected InstructoresManager instructoresManager;
        protected SecretariosManager secretariosManager;

        private AutocompletarManager autocompletarManager;

        public BaseForm()
        {
            if (IsInDesignMode)
            {
                // Evita inicializaciones en tiempo de diseño
                return;
            }

            // Inicialización en tiempo de ejecución
            InitializeRuntimeMode();
        }
        //-----INICIALIZAR EN TIEMPO DE EJECUCION-----------
        protected override void InitializeRuntimeMode()
        {
            base.InitializeRuntimeMode();
            CargarIconoFormulario();

            // Inicialización específica de BaseForm
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeManagers();
            dbManager = new ComisariasManager();
            instructoresManager = new InstructoresManager();
            secretariosManager = new SecretariosManager();

            InitializeCustomCursors();
            TraerLabelsAlFrente();
            InitializeComponent();
            InitializeFooterLinkLabel();
        }
        //----------------------------------------------------------

        /// <summary>
        /// Inicializa los manejadores necesarios.
        /// </summary>
        private void InitializeManagers()
        {
            try
            {
                dbManager = new ComisariasManager();
                instructoresManager = new InstructoresManager();
                secretariosManager = new SecretariosManager();
                autocompletarManager = new AutocompletarManager(@"path\to\Cartatulas_Autocompletar.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inicializando managers: {ex.Message}");
            }
        }

        /// <summary>
        /// Inicializa cursores personalizados.
        /// </summary>
        private void InitializeCustomCursors()
        {
            try
            {
                using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.cursorFlecha))
                {
                    this.Cursor = new Cursor(cursorStream);
                }

                using (MemoryStream cursorHand = new MemoryStream(Properties.Resources.hand))
                {
                    customHandCursor = new Cursor(cursorHand);
                }

                using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.CursorlapizDerecha))
                {
                    CursorLapizDerecha = new Cursor(cursorStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando cursores: {ex.Message}");
            }
        }

        /// <summary>
        /// Configura el autocompletado en los TextBox relevantes.
        /// </summary>
        private void ConfigureTextBoxAutoComplete()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox && textBox.Name.StartsWith("textBox_Caratula"))
                {
                    autocompletarManager.ConfigureTextBoxAutoComplete(textBox);
                }
            }
        }

        /// <summary>
        /// Sobrecarga del método OnLoad para inicializar eventos y configuraciones adicionales.
        /// </summary>
        /// <param name="e">Argumentos del evento.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Lógica adicional al cargar el formulario
            ConfigureFormAppearance();
        }

        /// <summary>
        /// Configura la apariencia general del formulario.
        /// </summary>
        private void ConfigureFormAppearance()
        {
            // Cambiar el color de fondo
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado
            this.BackColor = customColor;

            // Aplicar otras configuraciones visuales si es necesario
        }

        /// <summary>
        /// Método generado por el diseñador para inicializar componentes.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "BaseForm";
            this.ResumeLayout(false);
        }

        //--------------------------------------------------------------------------
        private void DibujarFondoDegradado(Graphics g, int width, int height)
        {
            // Definir el centro del área de degradado
            PointF center = new PointF(width / 2f, height / 2f);

            // Ajustar el radio máximo del degradado para que se ajuste al tamaño del formulario
            float maxRadius = Math.Max(width, height) * 0.75f; // Ajusta el valor según sea necesario

            // Crear un rectángulo que envuelve el área del degradado
            RectangleF gradientRectangle = new RectangleF(center.X - maxRadius, center.Y - maxRadius, maxRadius * 2, maxRadius * 2);
        }



        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            // Obtener las dimensiones del formulario
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Llamar al método que dibuja el fondo degradado
            DibujarFondoDegradado(e.Graphics, width, height);


        }
        //----------------------------------------------
        // Método para cargar el ícono según el modo (diseñador o ejecución)
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


        //--------
        public void CargarDatosDependencia(CustomComboBox customComboBox, ComisariasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Comisaria> comisarias = dbManager.GetComisarias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                customComboBox.Items.Clear();

                // Recorrer la lista de comisarías y agregar los datos al ComboBox
                foreach (Comisaria comisaria in comisarias)
                {
                    string item = $"{comisaria.Nombre}   {comisaria.Localidad}"; // Utiliza las propiedades de la clase Comisaria
                    customComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Dependencias: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }




        public void CargarDatosInstructor(CustomComboBox customComboBox, InstructoresManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Instructor> instructores = dbManager.GetInstructors(); // Asegúrate de usar el método correcto

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                customComboBox.Items.Clear();

                // Recorrer la lista de instructores y agregar los datos al ComboBox
                foreach (Instructor instructor in instructores)
                {
                    // Utiliza las propiedades de la clase Instructor
                    string item = $"{instructor.Jerarquia} {instructor.Nombre} {instructor.Apellido}";
                    customComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Instructores: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        public void CargarDatosSecretario(CustomComboBox customComboBox, SecretariosManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Secretario> secretarios = dbManager.GetSecretarios();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                customComboBox.Items.Clear();

                // Recorrer la lista de secretarios y agregar los datos al ComboBox
                foreach (Secretario secretario in secretarios)
                {
                    // Utiliza las propiedades de la clase Secretario
                    string item = $"{secretario.Jerarquia} {secretario.Nombre} {secretario.Apellido}";
                    customComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Secretarios: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        public void CargarDatosFiscalia(ComboBox comboBox, FiscaliasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Fiscalia> fiscalias = dbManager.GetFiscalias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de fiscalías y agregar los datos al ComboBox
                foreach (Fiscalia fiscalia in fiscalias)
                {
                    string item = $"{fiscalia.Ufid} - {fiscalia.AgenteFiscal} - {fiscalia.Localidad}"; // Puedes personalizar el formato
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Fiscalías: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }



        // Método virtual para ser sobreescrito en los formularios hijos
        protected virtual ComboBox ObtenerComboBoxDependencia()
        {
            return null; // Devuelve null por defecto, será sobrescrito en cada formulario específico
        }


        //para traer label titulo siempre al frente
        private void TraerLabelsAlFrente()
        {
            // Itera a través de todos los controles de la forma
            foreach (Control control in Controls)
            {
                // Verifica si el control es un Label y su nombre comienza con "label_TITULO"
                if (control is Label label && label.Name.StartsWith("label_TITULO"))
                {
                    label.BringToFront(); // Trae el label al frente
                }
            }

        }

        //-----METODO PARA MOSTRAR FOOTER-----------------------
        private void InitializeFooterLinkLabel()
        {

            // Llama al método estático de FooterHelper para obtener el footerLabel configurado
            this.footerLinkLabel = FooterHelper.CreateFooterLinkLabel(this);

            this.Controls.Add(this.footerLinkLabel);
        }


        //------------------------------------------------------------
        //-----METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES-------
        //-------BUSCAR----GUARDAR----LIMPIAR---------
        protected void InicializarEstiloBoton(Button boton)
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

        //------------------------------------------------------------
        //-----METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES-------
        //-------AGREGAR --->CARATULA-->IMPUTADO--->VICTIMA---------
        protected void InicializarEstiloBotonAgregar(Button boton)
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
    }
}





/*using BaseDatos.Adm_BD;
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using Ofelia_Sara.Clases.BaseDatos;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General
{
    public class BaseForm : BaseFormBase
    {
        private Cursor customHandCursor;
        private Cursor CursorLapizDerecha;
        private PictureBox pictureBoxError;
        private ToolTip toolTipError;
        private Timer errorTimer;
        private bool isPictureBoxVisible = true;
        private Dictionary<Control, PictureBox> pictureBoxesErrores = new Dictionary<Control, PictureBox>();

        private DatabaseConnection dbConnection;
        protected ComisariasManager dbManager = new ComisariasManager();//para cargar comisarias// Para cargar comisarías
        protected InstructoresManager instructoresManager = new InstructoresManager();    // Para cargar instructores
        protected SecretariosManager secretariosManager = new SecretariosManager();    // Para cargar instructores
                                                                                       //  protected FiscaliasManager fiscaliasManager = new FiscaliasManager();    // Para cargar fiscalias

        private readonly AutocompletarManager autocompletarManager; // Define una lista para almacenar los elementos de autocompletado

        private LinkLabel footerLinkLabel;

        private IContainer components;
        protected TimePickerPersonalizado timePickerPersonalizadoFecha;

        

        public BaseForm()
        {

            this.AutoScaleMode = AutoScaleMode.Dpi;//para evitar redimencionamiento con respecto a version anterior
            if (IsInDesignMode)
            {
                // Evita inicializaciones en tiempo de diseño
                return;
            }

            // Inicialización en tiempo de ejecución
            InitializeRuntimeMode();
        }
        //-------------------FIN CONSTRUCTOR------------------
        /// <summary>
        /// Lógica específica para tiempo de ejecución.
        /// </summary>
        protected override void InitializeRuntimeMode()
        {
            base.InitializeRuntimeMode(); // Llama a la inicialización básica del formulario base

            // Configuración inicial
            CargarIconoFormulario();
            InitializeFooterLinkLabel();

            // Cambiar el color de fondo del formulario
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);

            // Traer labels al frente
            TraerLabelsAlFrente();

            // Cargar cursores personalizados
            CargarCursoresPersonalizados();

            // Inicializar Timer para el manejo de errores
            InicializarErrorTimer();

            // Inicializar managers
            InicializarManagers();

            // Configurar autocompletado
           // autocompletarManager = new AutocompletarManager(@"path\to\Cartatulas_Autocompletar.json");
            ConfigureTextBoxAutoComplete();

            // Eventos del formulario
            this.Paint += new PaintEventHandler(BaseForm_Paint);
            this.Load += new EventHandler(BaseForm_Load);
        }
        //-------------------------------------------------------------------
        private void ConfigurarFormulario()
        {
            // Configurar propiedades generales del formulario
            CargarIconoFormulario();
            CambiarColorDeFondo();
            InitializeFooterLinkLabel();
            // Inicializar componentes específicos
            TraerLabelsAlFrente();// traer label_TITULO al frente
            CargarCursoresPersonalizados();// cursor hand , flecha y lapiz
            InicializarErrorTimer();
            // InicializarManagers();
            // ConfigurarAutocompletado();

            // Configurar eventos
            this.Paint += BaseForm_Paint;
            this.Load += BaseForm_Load;

        }

        private void CambiarColorDeFondo()
        {
            //// Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);
        }


        private void CargarCursoresPersonalizados()
        {
            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.cursorFlecha))
            {
                this.Cursor = new Cursor(cursorStream);
            }

            using (MemoryStream cursorHand = new MemoryStream(Properties.Resources.hand))
            {
                customHandCursor = new Cursor(cursorHand);
            }

            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.CursorlapizDerecha))
            {
                CursorLapizDerecha = new Cursor(cursorStream);
            }
        }
        private void InicializarErrorTimer()
        {
            errorTimer = new Timer
            {
                Interval = 500 // Intervalo en milisegundos (500 ms = 0.5 segundos)
            };
            errorTimer.Tick += ErrorTimer_Tick;
        }

        private void InicializarManagers()
        {
            dbManager = new ComisariasManager();
            instructoresManager = new InstructoresManager();
            secretariosManager = new SecretariosManager();
        }

        //--------------------------------------------------------------------------------
        // Método OnLoad combinado
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Recorre todos los controles y asigna el cursor "Hand" personalizado donde sea necesario
            AsignarCursorPersonalizado(this.Controls);


        }
        private IEnumerable<Control> ObtenerTodosLosControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;

                // Llamada recursiva para controles hijos
                foreach (Control child in ObtenerTodosLosControles(control))
                {
                    yield return child;
                }
            }
        }

        //--------------------------------------------------------------------------------
        private void BaseForm_Load(object sender, EventArgs e)
        {
            ToolTipsGenerales();// para aplicar tooltip comun a los formularios

            //// Recorre todos los controles y asigna el cursor "Hand" personalizado donde sea necesario
            AsignarCursorPersonalizado(this.Controls);

            TraerLabelsAlFrente();//traer los label titulo al frente

            // Determinar el modo de diseño
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                try
                {
                    ConsoleHelper.AllocConsole();
                    Console.WriteLine($"baseform ejecucion");
                }
                catch (Exception ex)
                {
                    ConsoleHelper.AllocConsole();
                    Console.WriteLine($"Error en tiempo de diseño: {ex.Message}");
                }
            }

            
        }
        //--------------------------------------------------------------------------
        private void DibujarFondoDegradado(Graphics g, int width, int height)
        {
            // Definir el centro del área de degradado
            PointF center = new PointF(width / 2f, height / 2f);

            // Ajustar el radio máximo del degradado para que se ajuste al tamaño del formulario
            float maxRadius = Math.Max(width, height) * 0.75f; // Ajusta el valor según sea necesario

            // Crear un rectángulo que envuelve el área del degradado
            RectangleF gradientRectangle = new RectangleF(center.X - maxRadius, center.Y - maxRadius, maxRadius * 2, maxRadius * 2);
        }



        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            // Obtener las dimensiones del formulario
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Llamar al método que dibuja el fondo degradado
            DibujarFondoDegradado(e.Graphics, width, height);

        
        }
        //----------------------------------------------
        // Método para cargar el ícono según el modo (diseñador o ejecución)
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

        /// <summary>
        /// Sustituir CURSOR HAND
        /// </summary>
        private void AsignarCursorPersonalizado(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Si el control es RichTextBox, asigna el cursor CursorLapizDerecha
                if (control is RichTextBox)
                {
                    control.Cursor = CursorLapizDerecha;
                }
                if (control is ComboBox)
                {
                    control.Cursor = Cursors.IBeam;
                }

                // Si el control tiene el cursor predeterminado "Hand", reemplázalo con el personalizado
                else if (control.Cursor == Cursors.Hand || control is LinkLabel)
                {
                    control.Cursor = customHandCursor;
                }

                // Si el control tiene hijos, aplica el cambio recursivamente
                if (control.HasChildren)
                {
                    AsignarCursorPersonalizado(control.Controls);
                }
            }
        }







        //-------------------------------------------------------------------------------
        //----para cargar lista en comboBox ESCALAFON Y JERARQUIA-------------------
        protected void ConfigurarComboBoxEscalafonJerarquia(ComboBox comboBox_Escalafon, ComboBox comboBox_Jerarquia)
        {    // Configurar el evento SelectedIndexChanged
            comboBox_Escalafon.SelectedIndexChanged += (sender, e) =>
            {
                if (comboBox_Escalafon.SelectedItem != null)
                {
                    string escalafon = comboBox_Escalafon.SelectedItem.ToString();
                    comboBox_Jerarquia.Enabled = true;
                    comboBox_Jerarquia.DataSource = JerarquiasManager.ObtenerJerarquias(escalafon);
                }
                else
                {
                    comboBox_Jerarquia.Enabled = false;
                    comboBox_Jerarquia.DataSource = null;
                }
            };

            // Configurar el ComboBox_Jerarquia inicialmente como desactivado
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

        }



        //-----METODO PARA MOSTRAR FOOTER-----------------------
        private void InitializeFooterLinkLabel()
        {

            // Llama al método estático de FooterHelper para obtener el footerLabel configurado
            this.footerLinkLabel = FooterHelper.CreateFooterLinkLabel(this);

            this.Controls.Add(this.footerLinkLabel);
        }


        //------------------------------------------------------------
        //-----METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES-------
        //-------BUSCAR----GUARDAR----LIMPIAR---------
        protected void InicializarEstiloBoton(Button boton)
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

        //------------------------------------------------------------
        //-----METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES-------
        //-------AGREGAR --->CARATULA-->IMPUTADO--->VICTIMA---------
        protected void InicializarEstiloBotonAgregar(Button boton)
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
        //--------------------------------------------------------------------------------------------------------

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }
        private void ConfigureTextBoxAutoComplete()
        {

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && textBox.Name.StartsWith("textBox_Caratula"))
                {
                    autocompletarManager.ConfigureTextBoxAutoComplete(textBox);
                }
            }
        }


        //--------
        public void CargarDatosDependencia(ComboBox comboBox, ComisariasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Comisaria> comisarias = dbManager.GetComisarias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de comisarías y agregar los datos al ComboBox
                foreach (Comisaria comisaria in comisarias)
                {
                    string item = $"{comisaria.Nombre}   {comisaria.Localidad}"; // Utiliza las propiedades de la clase Comisaria
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Dependencias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void CargarDatosInstructor(ComboBox comboBox, InstructoresManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Instructor> instructores = dbManager.GetInstructors(); // Asegúrate de usar el método correcto

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de instructores y agregar los datos al ComboBox
                foreach (Instructor instructor in instructores)
                {
                    // Utiliza las propiedades de la clase Instructor
                    string item = $"{instructor.Jerarquia} {instructor.Nombre} {instructor.Apellido}";
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Instructores: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        public void CargarDatosSecretario(ComboBox comboBox, SecretariosManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Secretario> secretarios = dbManager.GetSecretarios();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de secretarios y agregar los datos al ComboBox
                foreach (Secretario secretario in secretarios)
                {
                    // Utiliza las propiedades de la clase Secretario
                    string item = $"{secretario.Jerarquia} {secretario.Nombre} {secretario.Apellido}";
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Secretarios: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        public void CargarDatosFiscalia(ComboBox comboBox, FiscaliasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Fiscalia> fiscalias = dbManager.GetFiscalias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de fiscalías y agregar los datos al ComboBox
                foreach (Fiscalia fiscalia in fiscalias)
                {
                    string item = $"{fiscalia.Ufid} - {fiscalia.AgenteFiscal} - {fiscalia.Localidad}"; // Puedes personalizar el formato
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Fiscalías: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }



        // Método virtual para ser sobreescrito en los formularios hijos
        protected virtual ComboBox ObtenerComboBoxDependencia()
        {
            return null; // Devuelve null por defecto, será sobrescrito en cada formulario específico
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Configura automáticamente los ToolTips para los botones comunes en todos los formularios.
        /// </summary>
        private void ToolTipsGenerales()
        {
            // Lista de botones y sus textos de ToolTip
            var buttonsWithToolTips = new Dictionary<string, string>
        {
            { "btn_Imprimir", "Guardar e IMPRIMIR." },
            { "btn_Limpiar", "Limpiar formulario." },
            { "btn_Guardar", "GUARDAR." },
            { "btn_Buscar", "Buscar archivos guardados." }
        };

            // Iterar por cada par de botón y texto
            foreach (var entry in buttonsWithToolTips)
            {
                // Buscar el botón por su nombre
                var button = Controls.Find(entry.Key, true).FirstOrDefault() as Control;
                if (button != null)
                {
                    // Aplicar el ToolTip
                    //  ToolTipGeneral.ShowToolTip(button, entry.Value);
                }
            }
        }



        ////---- para error provider
        //protected void CrearPictureBoxError(Control parent, string nombre, Point ubicacion)
        //{
        //    PictureBox pictureBoxError = new PictureBox
        //    {
        //        Name = nombre,
        //        Size = new Size(16, 16), 
        //        Location = ubicacion,
        //        Image = Properties.Resources.errorProvider, 
        //        SizeMode = PictureBoxSizeMode.StretchImage,
        //        Visible = false // Por defecto, no visible
        //    };

        //    // Agrega el PictureBox al panel o al control padre
        //    parent.Controls.Add(pictureBoxError);
        //}
        //// Método para establecer el error en un control
        //// Método para configurar un PictureBox de error en el control.
        //protected void SetError(Control control, string mensaje)
        //{
        //    if (control == null || string.IsNullOrEmpty(mensaje))
        //        return;

        //    // Si el control es un TextBoxConBorde, aplica el borde de error.
        //    if (control is TextBoxCon textBox)
        //    {
        //        textBox.MostrarBordeError = true;
        //    }

        //    // Verifica si ya existe un PictureBox asociado a este control, si no, lo crea.
        //    if (!pictureBoxesErrores.ContainsKey(control))
        //    {
        //        // Crea un nuevo PictureBox usando el método CrearPictureBoxError.
        //        CrearPictureBoxError(control.Parent, $"Error_{control.Name}", new Point(0, 0));

        //        // Agrega el PictureBox al diccionario.
        //        pictureBoxesErrores[control] = control.Parent.Controls.Find($"Error_{control.Name}", true).FirstOrDefault() as PictureBox;
        //    }

        //    // Obtén el PictureBox asociado al control.
        //    PictureBox pictureBox = pictureBoxesErrores[control];

        //    // Calcula la posición del PictureBox en relación al control.
        //    Point controlLocation = control.Parent.PointToScreen(control.Location);
        //    Point formLocation = this.PointToClient(controlLocation);

        //    // Ajusta la posición del PictureBox.
        //    pictureBox.Location = new Point(
        //        formLocation.X + control.Width - pictureBox.Width - 7,
        //        formLocation.Y + 2);

        //    // Asegúrate de que el PictureBox esté visible y al frente.
        //    pictureBox.BringToFront();
        //    pictureBox.Visible = true;

        //    // Configura el ToolTip asociado al PictureBox con el mensaje de error.
        //    ToolTipError.InitializeToolTipOnHover(pictureBox, mensaje);
        //}

        //// Método para limpiar el error de un control.
        //protected void ClearError(Control control)
        //{
        //    if (control == null)
        //        return;

        //    // Si el control es un TextBoxConBorde, quita el borde de error.
        //    if (control is TextBox textBox)
        //    {
        //        textBox.MostrarBordeError = false;
        //    }

        //    // Si existe un PictureBox asociado al control, ocúltalo.
        //    if (pictureBoxesErrores.TryGetValue(control, out PictureBox pictureBox))
        //    {
        //        pictureBox.Visible = false;
        //        ToolTipError.HideToolTip();
        //    }
        //}



        //----------------------------------------------------------------------


        //// Método que recorre los controles del formulario y cambia los TextBox a TextBoxConBorde
        //private void AplicarTextBoxConBorde(Form formulario)
        //{
        //    foreach (Control control in formulario.Controls)
        //    {
        //        if (control is TextBox)
        //        {
        //            // Crea un nuevo TextBoxConBorde
        //            TextBoxConBorde textBoxConBorde = new TextBoxConBorde
        //            {
        //                Text = control.Text,             // Copia el texto actual
        //                Location = control.Location,     // Copia la ubicación
        //                Size = control.Size              // Copia el tamaño
        //            };

        //            // Remueve el control viejo (TextBox) y añade el nuevo (TextBoxConBorde)
        //            formulario.Controls.Remove(control);
        //            formulario.Controls.Add(textBoxConBorde);
        //        }
        //    }
        //}




        private int Counter = 0;

        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            // Alternar la visibilidad de todos los PictureBox de error
            foreach (var pictureBox in pictureBoxesErrores.Values)
            {
                pictureBox.Visible = !pictureBox.Visible; // Alterna la visibilidad
            }

            // Incrementar el contador
            Counter++;

            // Detener el timer después de 6 pulsaciones (3 ciclos completos de parpadeo)
            if (Counter >= 6)
            {
                errorTimer.Stop();
                Counter = 0; // Reiniciar el contador

                // Asegurarse de que los PictureBox queden visibles al finalizar
                foreach (var pictureBox in pictureBoxesErrores.Values)
                {
                    pictureBox.Visible = true;
                }
            }
        }

        //para traer label titulo siempre al frente
        private void TraerLabelsAlFrente()
        {
            // Itera a través de todos los controles de la forma
            foreach (Control control in Controls)
            {
                // Verifica si el control es un Label y su nombre comienza con "label_TITULO"
                if (control is Label label && label.Name.StartsWith("label_TITULO"))
                {
                    label.BringToFront(); // Trae el label al frente
                }
            }

        }


       

    }

}*/