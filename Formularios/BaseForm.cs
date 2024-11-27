
using BaseDatos.Adm_BD;
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using BaseDatos.Mensaje;
using Clases.Apariencia;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using System;
// Alias para el ShadowForm de tu propia clase

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Ofelia_Sara.Formularios

{

    public class BaseForm : Form
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
        //protected FiscaliasManager fiscaliasManager = new FiscaliasManager();    // Para cargar fiscalias

        private readonly AutocompletarManager autocompletarManager; // Define una lista para almacenar los elementos de autocompletado

        private LinkLabel footerLinkLabel;

        private IContainer components;
        protected TimePickerPersonalizado timePickerPersonalizadoFecha;

       

        public BaseForm()
        {

            CargarIconoFormulario();

            InitializeFooterLinkLabel();

            // Llamar al método para aplicar TextBoxConBorde a todos los controles TextBox
            AplicarTextBoxConBorde(this);
            //------------------CAMBIAR FONDO----------------------------------------------------
            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
                                                             //---ESTE COLOR PERTENECE AL ACTUAL DE MINISTERIO DE SEGURIDAD-----
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);//llama a la clase que modifica el color de fondo
                                                                         //-------------------------------------------------------------------------

            this.Paint += new PaintEventHandler(BaseForm_Paint);
            //this.Load += new System.EventHandler(this.BaseForm_Load);
            //---------------------------------------------
            //--para cargar los distintos comboBox desde la base de datos
            // Solo ejecutar si NO es tiempo de diseño
            InitializeComponent();

            // Verificamos si está en tiempo de ejecución
            // Evitar que se ejecute el código en modo diseño
            // Evitar ejecución en tiempo de diseño
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; // Salir si estamos en modo diseño
            }

            autocompletarManager = new AutocompletarManager(@"path\to\Cartatulas_Autocompletar.json");
            ConfigureTextBoxAutoComplete();

            instructoresManager = new InstructoresManager();

            // Inicializar el Timer
            errorTimer = new Timer
            {
                Interval = 500 // Intervalo en milisegundos (500 ms = 0.5 segundos)
            };
            errorTimer.Tick += ErrorTimer_Tick;


            // Cargar el cursor desde los recursos
            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.cursorFlecha))
            {
                this.Cursor = new Cursor(cursorStream);
            }
            // Cargar el cursor personalizado desde los recursos
            using (MemoryStream cursorHand = new MemoryStream(Properties.Resources.hand))
            {
                customHandCursor = new Cursor(cursorHand);
            }
            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.CursorlapizDerecha))
            {
                CursorLapizDerecha = new Cursor(cursorStream);
            }
        }

        //--------------------------------------------------------------------------------
        // Método OnLoad combinado
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Recorre todos los controles y asigna el cursor "Hand" personalizado donde sea necesario
            AsignarCursorPersonalizado(this.Controls);

            foreach (var control in ObtenerTodosLosControles(this))
            {
                if (control is ComboBox comboBox)
                {
                    AplicarFlechaPersonalizada(comboBox);
                }
            }
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
            //AsignarCursorPersonalizado(this.Controls);
           // PersonalizarComboBoxes(this);

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
            string iconPath;

            if (this.DesignMode)
            {
                // Ruta de ícono para el diseñador de Visual Studio
                iconPath = Path.Combine(@"C:\Ruta\Absoluta\A\Tu\Proyecto\Resources\imagenes", "IconoEscudoPolicia.ico");
            }
            else
            {
                // Ruta relativa para el tiempo de ejecución
                iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "imagenes", "IconoEscudoPolicia.ico");
            }

            // Llama a SetFormIcon solo si el archivo existe
            if (File.Exists(iconPath))
            {
                IconoEscudo.SetFormIcon(this, iconPath);
            }
            else
            {
                Console.WriteLine("No se pudo encontrar el ícono en la ruta especificada.");
            }
        }
        /// <summary>
        /// Sustituir CURSOR HAND
        /// </summary>
        private void AsignarCursorPersonalizado(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Si el control es un TextBox, ComboBox o RichTextBox, asigna el cursor CursorLapizDerecha
                if (control is TextBox || control is ComboBox || control is RichTextBox )
                {
                    control.Cursor = CursorLapizDerecha;
                }
                // Si el control tiene el cursor predeterminado "Hand", reemplázalo con el personalizado
                else if (control.Cursor == Cursors.Hand || control is LinkLabel )
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
        //--------------------------------------------------------------------------
        /// <summary>
        /// METODOS PARA ASIGNAR FLECHA A COMBOBOX
        /// </summary>
        /// 


        private void PersonalizarComboBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    AplicarFlechaPersonalizada(comboBox);
                }

                // Procesar controles hijos (recursivo)
                if (control.HasChildren)
                {
                    PersonalizarComboBoxes(control);
                }
            }
        }


        private Rectangle ObtenerAreaFlecha(ComboBox comboBox)
        {
            int arrowWidth = SystemInformation.VerticalScrollBarWidth; // Ancho típico del área de la flecha
            int x = comboBox.Width - arrowWidth; // Inicia al borde derecho menos el ancho de la flecha
            int y = 0; // Inicia desde la parte superior del ComboBox
            int height = comboBox.Height; // Coincide con el alto del ComboBox
            return new Rectangle(comboBox.Left + x, comboBox.Top + y, arrowWidth, height);
        }
       
        private void AplicarFlechaPersonalizada(ComboBox comboBox)
        {
            Rectangle flechaArea = ObtenerAreaFlecha(comboBox); // Obtener el área completa de la flecha

            PictureBox flechaPersonalizada = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,//ajusta la imagen sin que se deforme
                Size = new Size(flechaArea.Width-1, flechaArea.Height-2), // Tamaño completo del área de la flecha
              //  BackColor = SystemColors.ControlLight, // Fondo que destaca la propiedad de desplegar
                BackColor = Color.White, //blanco resalta y es igual al comboBox
                Cursor = Cursors.Hand,
                Location = new Point(flechaArea.X, flechaArea.Y+1), // Ajustar la ubicación
                Anchor = AnchorStyles.Top | AnchorStyles.Right ,// Alinear correctamente
                  Tag = comboBox
            };

            ActualizarFlecha(comboBox, flechaPersonalizada);

            // Agregar el PictureBox al contenedor padre del ComboBox
            comboBox.Parent.Controls.Add(flechaPersonalizada);
            flechaPersonalizada.BringToFront();

            // Abrir el desplegable del ComboBox al hacer clic en la flecha personalizada
            flechaPersonalizada.Click += (s, e) => comboBox.DroppedDown = true;

            // Actualizar la flecha cuando el estado del ComboBox cambie
            comboBox.EnabledChanged += (s, e) => ActualizarFlecha(comboBox, flechaPersonalizada);

            // Actualizar la posición y tamaño de la flecha personalizada si el ComboBox cambia de tamaño
            comboBox.SizeChanged += (s, e) =>
            {
                Rectangle nuevaArea = ObtenerAreaFlecha(comboBox);
                flechaPersonalizada.Size = new Size(nuevaArea.Width, nuevaArea.Height);
                flechaPersonalizada.Location = new Point(nuevaArea.X, nuevaArea.Y);
            };
        }

        private void ActualizarFlecha(ComboBox comboBox, PictureBox flechaPersonalizada)
        {
            // Imagen neutra por defecto
            flechaPersonalizada.Image = Properties.Resources.icoPredeterminadoComboBox;
           
            // Eventos para cambiar el color en Hover
            flechaPersonalizada.MouseEnter += (s, e) =>
            {
                flechaPersonalizada.Image = comboBox.Enabled
                    ? Properties.Resources.flechaG_Verde // Imagen verde si está habilitado
                    : Properties.Resources.flechaG_Roja; // Imagen roja si está deshabilitado
            };

            // Volver a la imagen neutra al salir del hover
            flechaPersonalizada.MouseLeave += (s, e) =>
            {
                flechaPersonalizada.Image = Properties.Resources.icoPredeterminadoComboBox;
            };
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

        //---


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
                    ToolTipGeneral.ShowToolTip(this, button, entry.Value);
                }
            }
        }

      

        //---- para error provider

        // Método para establecer el error en un control
        protected void SetError(Control control, string mensaje)
        {
            if (control == null || string.IsNullOrEmpty(mensaje))
                return;

            // Validar si el control es un TextBoxConBorde y aplicar borde de error
            if (control is TextBoxConBorde textBox)
            {
                textBox.MostrarBordeError = true;
            }

            // Si no existe un PictureBox asociado al control, se crea
            if (!pictureBoxesErrores.ContainsKey(control))
            {
                PictureBox pictureBoxError = new PictureBox
                {
                    Image = Properties.Resources.errorProvider, // Imagen de error
                    Size = new Size(18, 16),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.White,
                    Visible = false // Oculto inicialmente
                };



                // Agregar el PictureBox al formulario y al diccionario
                this.Controls.Add(pictureBoxError);
                pictureBoxesErrores[control] = pictureBoxError;
            }

            // Obtener el PictureBox asociado al control
            PictureBox pictureBox = pictureBoxesErrores[control];

            // Calcular la posición absoluta del control en relación al formulario
            Point controlLocation = control.Parent.PointToScreen(control.Location);
            Point formLocation = this.PointToClient(controlLocation);

            // Ajustar la posición del PictureBox
            pictureBox.Location = new Point(
                formLocation.X + control.Width - pictureBox.Width - 7,
                formLocation.Y + 2);

            // Asegurarse de que el PictureBox esté visible y al frente
            pictureBox.BringToFront();
            pictureBox.Visible = true;

            // Configurar el ToolTip asociado al PictureBox con un error
            ToolTipError.InitializeToolTipOnHover(pictureBox, mensaje);
        }

        protected void ClearError(Control control)
        {
            if (control == null)
                return;

            // Validar si el control es un TextBoxConBorde y quitar el borde de error
            if (control is TextBoxConBorde textBox)
            {
                textBox.MostrarBordeError = false;
            }

            // Si existe un PictureBox asociado al control, ocultarlo
            if (pictureBoxesErrores.TryGetValue(control, out PictureBox pictureBox))
            {
                pictureBox.Visible = false;
                ToolTipError.HideToolTip();
            }
        }


        //----------------------------------------------------------------------


        // Método que recorre los controles del formulario y cambia los TextBox a TextBoxConBorde
        private void AplicarTextBoxConBorde(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is TextBox)
                {
                    // Crea un nuevo TextBoxConBorde
                    TextBoxConBorde textBoxConBorde = new TextBoxConBorde
                    {
                        Text = control.Text,             // Copia el texto actual
                        Location = control.Location,     // Copia la ubicación
                        Size = control.Size              // Copia el tamaño
                    };

                    // Remueve el control viejo (TextBox) y añade el nuevo (TextBoxConBorde)
                    formulario.Controls.Remove(control);
                    formulario.Controls.Add(textBoxConBorde);
                }
            }
        }




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

    }





}





