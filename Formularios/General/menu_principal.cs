using Ofelia_Sara.Clases.General.Animaciones;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones.btn_Configuracion;
using Ofelia_Sara.Clases.General.Conexion;
using Ofelia_Sara.Controles.Barra_Busqueda;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; // Para la importación de funciones nativas
using System.Windows.Forms;
using static iText.Commons.Utils.PlaceHolderTextUtil;
using static Ofelia_Sara.Formularios.General.InstructivoDigital;


namespace Ofelia_Sara.Formularios.General
{

    public partial class MenuPrincipal : BaseForm
    {
        //funcion nativa para ARRASTRAR EL FORMULARIO
        // Importar las funciones de la API de Windows
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void ReleaseCapture();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        #region VARIABLES
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        //private ContextMenuStrip contextMenu;
        private AuxiliarConfiguracion auxiliarConfiguracion;
        private AccionesManager accionesManager;//para el comboBox
        Timer timerCerrarForm = new Timer();
        Timer timerMinimizarForm = new Timer();
        private Size originalSizeMecanografia;
        private Point originalLocationMecanografia;
        // Definir el texto del placeholder
        private string placeholderText = "Buscar tipo de actuación...";
        // Variables auxiliares para animación
        private int lineWidth = 0;
        private bool isAnimating = false;
        private Form videoInstructivo; // Variable para almacenar la instancia del formulario
        private Form formularioSecundarioAbierto = null;
        private Form leyesForm = null; // Variable para almacenar la referencia del formulario

        //eventos para abrir aplicacion mecanografia
        private Form mecanografia = null; // Variable para almacenar la referencia del formulario

        // Diccionarios para almacenar el tamaño y la ubicación originales de cada botón
        private Dictionary<System.Windows.Forms.Button, Size> originalSizes = new Dictionary<System.Windows.Forms.Button, Size>();
        private Dictionary<System.Windows.Forms.Button, Point> originalLocations = new Dictionary<System.Windows.Forms.Button, Point>();
        private List<Form> redactadorForms = new List<Form>(); // Lista para almacenar las instancias de los formularios

        #endregion

        #region CONSTRUCTOR
        public MenuPrincipal()
        {

            InitializeComponent();

            auxiliarConfiguracion = new AuxiliarConfiguracion(this);// instancia de clase que crea menu y submenu de btn_configuracion
            PosicionarMenu();

             RedondearBordes.Aplicar(this, 12);  // Redondea los bordes del formulario
             RedondearBordes.Aplicar(panel_MenuSuperior, 12, true, true, false, false);  // Redondea solo los bordes superiores del panel

            comboBox_Buscar.BringToFront(); // que comboBoxBuscar está encima de comboBoxGNUA
            LabelVideoInstructivo(label_OfeliaSara);// llama al metodo baseform para el comportamiento del label
            //----timer para que se vea efecto de cambio de color en los btn cerrar y minimizar
            timerCerrarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerMinimizarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerCerrarForm.Tick += TimerCerrar_Tick;
            timerMinimizarForm.Tick += TimerMinimizar_Tick;

            placeholderText = "Buscar tipo de actuación...";
          

            comboBox_Buscar.InnerTextBox.GotFocus += ComboBox_Buscar_GotFocus;
           comboBox_Buscar.InnerTextBox.LostFocus += ComboBox_Buscar_LostFocus;
          
            comboBox_Buscar.InnerTextBox.MouseEnter += ComboBox_Buscar_MouseEnter;
        
        }
        #endregion

        #region LOAD
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            // Configurar el botón para usar el menú de contexto
            btn_Configurar.ContextMenuStrip = auxiliarConfiguracion.CrearMenuConfigurar();// btn_configuracion
            btn_BuscarTarea.Enabled = false;//deshabilitar btn al cargar //se habilitara al ingresar texto compatible con la lista

            Tooltips(); 
            ConfigurarBotones();
          
            Rotacion.Aplicar(btn_Configurar, Properties.Resources.engranajeConfiguracion, // Imagen para animar
                                             Properties.Resources.engranajeOriginal);   // Imagen original

           
        }
        #endregion

        #region BOTONES
        /// <summary>
        /// metodos aplicados a btn_Configurar
        /// </summary>

        private void Btn_Configurar_Click(object sender, EventArgs e)
        {
            // Mostrar el ContextMenuStrip en la posición del botón
            Point botonPosicion = btn_Configurar.PointToScreen(Point.Empty);
            btn_Configurar.ContextMenuStrip.Show(botonPosicion);
        }

        /// <summary>
        /// EVENTO ACTIVACION ROTACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Configurar_Hover(object sender, EventArgs e)
        {
            // Aplicar rotación (animación izquierda)
            Rotacion.Aplicar(
                btn_Configurar,
                Properties.Resources.engranajeConfiguracion, // Imagen animada
                Properties.Resources.engranajeOriginal      // Imagen original
            );
        }

        private void Btn_InicioCierre_Click(object sender, EventArgs e)
        {

            AbrirFormularioSecundario(new InicioCierre());
        }

        private void Btn_Contravenciones_Click(object sender, EventArgs e)
        {

            AbrirFormularioSecundario(new Contravenciones());
        }

        private void Btn_Expedientes_Click(object sender, EventArgs e)
        {

            AbrirFormularioSecundario(new Expedientes());
        }


        /// <summary>
        /// ABRIR LISTADO DE LEYES Y DECRETOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Leyes_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario ya está abierto y no está cerrado o eliminado
            if (leyesForm == null || leyesForm.IsDisposed)
            {
                // Crear e inicializar el formulario para mostrar documentos
                leyesForm = new LeyesForm(); // Usar la variable global en lugar de declarar una nueva local

                // Obtener la ubicación y tamaño del formulario principal
                Point menuPrincipalLocation = this.Location;
                Size menuPrincipalSize = this.Size;

                // Calcular la nueva ubicación para el formulario LeyesForm
                int x = menuPrincipalLocation.X - 6; // Mantener la misma posición horizontal
                int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

                // Ajustar la ubicación del formulario LeyesForm
                leyesForm.StartPosition = FormStartPosition.Manual;
                leyesForm.Location = new Point(x, y);

                leyesForm.Show();
            }
            else
            {
                // Si ya está abierto, lo trae al frente
                leyesForm.WindowState = FormWindowState.Normal; // Si estaba minimizado
                leyesForm.BringToFront();
            }
        }

        /// <summary>
        /// BOTN DEL BUSCADOR PARA BUSCAR LA TAREA INGRESADA O SELECCIONADA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_BuscarTarea_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un formulario
            if (comboBox_Buscar.SelectedItem == null)
            {
                MensajeGeneral.Mostrar("Por favor, selecciona un formulario antes de continuar.", MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            // Obtener el nombre del formulario seleccionado desde el comboBox
            string nombreFormularioSeleccionado = comboBox_Buscar.SelectedItem as string;

            // Verifica que se haya seleccionado un formulario
            if (!string.IsNullOrEmpty(nombreFormularioSeleccionado))
            {
                // Busca el formulario correspondiente en la lista de acciones
                var formularioSeleccionado = accionesManager.Acciones.Find(accion => accion == nombreFormularioSeleccionado);

                if (formularioSeleccionado != null)
                {
                    var abrirFormulario = new AbrirFormularios_BarraBusqueda();
                    // abrirFormulario.AbrirFormulario(formularioSeleccionado);
                }
                else
                {
                    MensajeGeneral.Mostrar("El formulario seleccionado no está disponible.", MensajeGeneral.TipoMensaje.Error);
                }
            }
            else
            {
                MensajeGeneral.Mostrar("Por favor, selecciona un formulario.", MensajeGeneral.TipoMensaje.Advertencia);
            }


        }

        /// <summary>
        /// BOTON CREADO PARA CERRAR FORMULARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.FromArgb(255, 69, 58);// ROJO ANARANJADO
            btn_Cerrar.ForeColor = SystemColors.Control;
            btn_Cerrar.Font = new Font(btn_Cerrar.Font, FontStyle.Bold);
            btn_Cerrar.FlatAppearance.BorderSize = 2;
            btn_Cerrar.FlatAppearance.BorderColor = Color.Red;
            timerCerrarForm.Start();
        }

        /// <summary>
        /// CAMBIAR BORDE Y COLOR DEL BTN CERRAR AL PASAR CURSOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cerrar_MouseHover(object sender, EventArgs e)
        {
           // btn_Cerrar.BackColor = Color.Lavender;
            btn_Cerrar.FlatAppearance.BorderSize = 2;
            btn_Cerrar.FlatAppearance.BorderColor = Color.Coral;
            btn_Cerrar.BackColor = Color.Coral;
            btn_Cerrar.ForeColor = SystemColors.Control;
            btn_Cerrar.Font = new Font(btn_Cerrar.Font, FontStyle.Bold);
        }

        /// <summary>
        /// CAMBIAR BORDE Y COLOR DEL BTN CERRAR AL SALIR CURSOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cerrar_MouseLeave(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = SystemColors.ButtonFace;
            btn_Cerrar.ForeColor = SystemColors.ControlDarkDark;
            btn_Cerrar.Font = new Font(btn_Cerrar.Font, FontStyle.Regular);
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);//GRIS CLARO
        }

        /// <summary>
        /// CAMBIAR BORDE Y COLOR DEL BTN MINIMIZAR AL ENTRAR CURSOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Minimizar_MouseHover(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.LightBlue;
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.MenuHighlight;
            btn_Minimizar.ForeColor = SystemColors.Control;
            btn_Minimizar.Font = new Font(btn_Cerrar.Font, FontStyle.Bold);
        }

        /// <summary>
        /// CAMBIAR BORDE Y COLOR DEL BTN MINIMIZAR AL SALIR CURSOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = SystemColors.ButtonFace;
            btn_Minimizar.ForeColor = SystemColors.ControlDarkDark;
            btn_Minimizar.FlatAppearance.BorderSize = 1;
            btn_Minimizar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);//gris claro
            btn_Minimizar.Font = new Font(btn_Cerrar.Font, FontStyle.Regular);
        }

        /// <summary>
        /// MINIMIZAR FORMULARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Blue;
            btn_Minimizar.ForeColor = SystemColors.Control;
            btn_Minimizar.Font = new Font(btn_Cerrar.Font, FontStyle.Bold);
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.Highlight;
      
            timerMinimizarForm.Start();

        }

        /// <summary>
        /// Método para configurar los valores originales al cargar el formulario
        /// </summary>
        private void ConfigurarBotones()
        {
            // Almacena el tamaño y la ubicación originales de cada botón
            originalSizes[btn_Mecanografia] = btn_Mecanografia.Size;
            originalLocations[btn_Mecanografia] = btn_Mecanografia.Location;

            originalSizes[btn_Redactador] = btn_Redactador.Size;
            originalLocations[btn_Redactador] = btn_Redactador.Location;

            IncrementarTamaño.Incrementar(btn_Configurar);
            IncrementarTamaño.Incrementar(btn_Leyes);
            IncrementarTamaño.Incrementar(btn_BoletinOficial);
            IncrementarTamaño.Incrementar(btn_InicioCierre);
            IncrementarTamaño.Incrementar(btn_Contravenciones);
            IncrementarTamaño.Incrementar(btn_Expedientes);
        }


        /// <summary>
        /// Método MouseDown para simular animación de "clic"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton && originalSizes.ContainsKey(boton) && originalLocations.ContainsKey(boton))
            {
                // Disminuye temporalmente el tamaño del botón para simular un clic
                int reductionAmount = 5; // La cantidad que se reduce el botón
                boton.Size = new Size(originalSizes[boton].Width - reductionAmount, originalSizes[boton].Height - reductionAmount);

                // Ajusta temporalmente la ubicación para centrar la reducción
                boton.Location = new Point(
                    originalLocations[boton].X + reductionAmount / 2,
                    originalLocations[boton].Y + reductionAmount / 2
                );
            }
        }

        /// <summary>
        /// Método MouseUp para restaurar tamaño y ubicación originales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton && originalSizes.ContainsKey(boton) && originalLocations.ContainsKey(boton))
            {
                // Restaurar tamaño y ubicación originales
                boton.Size = originalSizes[boton];
                boton.Location = originalLocations[boton];
            }
        }

        /// <summary>
        /// Método MouseHover para cambiar borde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseHover(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton)
            {
                boton.FlatAppearance.BorderSize = 1;
                boton.FlatAppearance.BorderColor = Color.FromArgb(108, 156, 173);//borde celeste claro para indicar que esta seleccionado
            }
        }

        /// <summary>
        ///  Método MouseLeave para restaurar borde y tamaño originales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton && originalSizes.ContainsKey(boton))
            {
                boton.FlatAppearance.BorderSize = 0;
                boton.Size = originalSizes[boton];
            }
        }


        private void Boton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button boton)
            {
                boton.BackColor = Color.FromArgb(136, 198, 219); // Fondo al presionar

            }

        }
        private void Boton_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button boton)
            {
                boton.BackColor = Color.FromArgb(0, 154, 174); // Fondo original

            }
        }

        /// <summary>
        /// ABRIR FUNCION REDACTADOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Redactador_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario Redactador
            var nuevaRedactadorForm = new Ofelia_Sara.Formularios.Redactador.Redactador();

            // Ajustar el texto del Label para indicar el número de instancia
            int numeroInstancia = redactadorForms.Count + 1;
            Label labelRedactador = nuevaRedactadorForm.Controls.Find("label_Redactador", true).FirstOrDefault() as Label;

            if (labelRedactador != null)
            {
                labelRedactador.Text = $"DOCUMENTO N° {numeroInstancia}";
                labelRedactador.ForeColor = Color.Blue;
                labelRedactador.Font = new Font(labelRedactador.Font, FontStyle.Bold);
            }

            // Obtener la ubicación y tamaño del formulario principal (menuPrincipal)
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la posición base para las instancias
            int baseY = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Debajo de menuPrincipal
            int baseX = menuPrincipalLocation.X + (menuPrincipalSize.Width / 2); // Centro horizontal de menuPrincipal

            // Ajustar el tamaño del formulario `Redactador`
            Size redactadorSize = nuevaRedactadorForm.Size;

            // Posición inicial para la primera instancia
            if (redactadorForms.Count == 0)
            {
                nuevaRedactadorForm.StartPosition = FormStartPosition.Manual;
                nuevaRedactadorForm.Location = new Point(
                    baseX - (redactadorSize.Width / 2), // Centrar en el eje X
                    baseY // Posición debajo de menuPrincipal
                );
            }
            else
            {
                // Minimizar formularios anteriores si ya hay dos visibles
                if (redactadorForms.Count >= 2)
                {
                    foreach (var form in redactadorForms)
                    {
                        if (!form.IsDisposed)
                        {
                            form.WindowState = FormWindowState.Minimized;
                        }
                    }
                }

                // Reposicionar las dos últimas instancias si existen
                if (redactadorForms.Count > 0)
                {
                    var ultimaInstancia = redactadorForms.LastOrDefault(f => !f.IsDisposed);
                    if (ultimaInstancia != null)
                    {
                        ultimaInstancia.Location = new Point(
                            baseX - redactadorSize.Width - 10, // Izquierda
                            baseY
                        );
                        ultimaInstancia.WindowState = FormWindowState.Normal;
                    }
                }

                // Posicionar la nueva instancia a la derecha
                nuevaRedactadorForm.StartPosition = FormStartPosition.Manual;
                nuevaRedactadorForm.Location = new Point(baseX + 10, baseY); // Derecha
            }

            // Mostrar el formulario
            nuevaRedactadorForm.Show();

            // Agregar la nueva instancia a la lista
            redactadorForms.Add(nuevaRedactadorForm);

            // Manejar el cierre del formulario
            nuevaRedactadorForm.FormClosed += (s, args) =>
            {
                redactadorForms.Remove(nuevaRedactadorForm);

                // Restaurar las últimas dos instancias visibles al cerrar una
                var ultimasDos = redactadorForms.Where(f => !f.IsDisposed).TakeLast(2).ToList();
                if (ultimasDos.Count > 0)
                {
                    int xOffset = (menuPrincipalSize.Width - (ultimasDos.Count * redactadorSize.Width)) / 2;
                    for (int i = 0; i < ultimasDos.Count; i++)
                    {
                        ultimasDos[i].Location = new Point(
                            menuPrincipalLocation.X + xOffset + (i * redactadorSize.Width),
                            baseY
                        );
                        ultimasDos[i].WindowState = FormWindowState.Normal;
                    }
                }
            };
        }

        /// <summary>
        /// ACCEDER A BOLETIN OFICIAL POLICIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_BoletinOficial_Click(object sender, EventArgs e)
        {

            ConexionGeneral.AbrirUrl("https://boletin.mseg.gba.gov.ar/");
        }

        /// <summary>
        /// ABRIR FUNCION MECANOGRAFIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Mecanografia_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario ya está abierto y no está cerrado o eliminado
            if (mecanografia == null || mecanografia.IsDisposed)
            {
                // Desplazar el formulario menuPrincipal un 10% hacia abajo desde el borde superior de la pantalla
                int newY = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.05); // 5% de la altura de la pantalla

                // Cambiar la ubicación del formulario menuPrincipal
                this.Location = new Point(this.Location.X, newY);

                // Crear una instancia del formulario Redactador
                mecanografia = new Ofelia_Sara.Formularios.Mecanografia.Mecanografia();

                // Obtener la ubicación y tamaño del formulario principal
                Point menuPrincipalLocation = this.Location;
                Size menuPrincipalSize = this.Size;

                // Obtener el tamaño del formulario Mecanografia
                Size mecanografiaSize = mecanografia.Size;

                // Calcular la nueva ubicación para el formulario 
                int x = menuPrincipalLocation.X + (menuPrincipalSize.Width - mecanografiaSize.Width) / 2; // Centramos en el eje X
                int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10;

                // Ajustar la ubicación del formulario 
                mecanografia.StartPosition = FormStartPosition.Manual;
                mecanografia.Location = new Point(x, y);

                mecanografia.Show();
            }
            else
            {
                // Si ya está abierto, lo trae al frente
                mecanografia.WindowState = FormWindowState.Normal; // Si estaba minimizado
                mecanografia.BringToFront();
            }
        }

        /// <summary>
        /// TIMER PARA BTN CERRAR FORMULARIO MENU PRINCIPAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            timerCerrarForm.Stop();
            Application.Exit();
        }

        /// <summary>
        /// TIMER PARA BTN MINIMIZAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerMinimizar_Tick(object sender, EventArgs e)
        {
            timerMinimizarForm.Stop();
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region METODOS GENERALES

        /// <summary>
        /// AGRUPACION DE TOOLTIPS 
        /// </summary>
        private void Tooltips()
        {
            ToolTipGeneral.Mostrar(btn_Configurar, "Configuración de elementos.");
            ToolTipGeneral.Mostrar(btn_Leyes, "Leyes y decretos útiles.");
            ToolTipGeneral.Mostrar(btn_Mecanografia, "MECANOGRAFIA");
            ToolTipGeneral.Mostrar(btn_Redactador, "REDACTAR POR VOZ");
            ToolTipGeneral.Mostrar(label_OfeliaSara, "Instructivo de la aplicación.");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_BuscarTarea, "Seleccione o indique una tarea antes de realizar busqueda.", "Buscar tarea seleccionada.");
            ToolTipGeneral.Mostrar(comboBox_Buscar, " Ingrese que tarea desea realizar.");
            ToolTipGeneral.Mostrar(btn_BoletinOficial, "Boletín Informativo.");
            ToolTipEliminar.Mostrar(btn_Cerrar,"CERRAR");
        }

        /// <summary>
        /// POSICIONAR MENU EN PANTALLA
        /// </summary>
        private void PosicionarMenu()
        {
            // Obtener las dimensiones de la pantalla
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calcular la posición en X (centrado)
            int formX = (screenWidth - this.Width) / 2;

            // Calcular la posición en Y (20% desde el borde superior)
            int formY = (int)(screenHeight * 0.15);

            // Establecer la ubicación del formulario
            this.Location = new Point(formX, formY);
        }
        private void OpenFormBelowMenuPrincipal(Form formToOpen)
        {
            formToOpen.StartPosition = FormStartPosition.Manual;
            formToOpen.Location = new Point(this.Location.X, this.Location.Y + this.Height);
            formToOpen.Show();
        }

        /// <summary>
        /// RESTABLECE LA POSICION ORIGINAL DEL FORMULARIO MENUPRINCIPAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restablecer_MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioSecundarioAbierto = null;

            // Restaurar el formulario principal
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        /// <summary>
        /// ABRIR Y POSICIONAR FORMULARIO SECUNDARIO
        /// </summary>
        /// <param name="formulario"></param>
        private void AbrirFormularioSecundario(Form formulario)
        {
            // Si ya hay un formulario secundario abierto
            if (formularioSecundarioAbierto != null)
            {
                // Si el formulario que se intenta abrir ya está abierto, solo restaurarlo
                if (formularioSecundarioAbierto.GetType() == formulario.GetType())
                {
                    formularioSecundarioAbierto.WindowState = FormWindowState.Normal;
                    formularioSecundarioAbierto.BringToFront();
                    return;
                }

                // Cerrar el formulario secundario actual
                formularioSecundarioAbierto.Close();
            }

            // Configurar y abrir el nuevo formulario secundario
            formularioSecundarioAbierto = formulario;
            formularioSecundarioAbierto.FormClosed += Restablecer_MenuPrincipal_FormClosed;
            formularioSecundarioAbierto.Show();

            // Minimizar el formulario principal
            this.Hide();
        }


        /// <summary>
        /// para poder arrastrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MenuSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }



        /// <summary>
        /// Sobrescribir el evento Resize del formulario principal para ocultarlo si se intenta restaurar
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Si hay un formulario secundario abierto, mantener minimizado MenuPrincipal
            if (this.WindowState == FormWindowState.Normal && formularioSecundarioAbierto != null)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        #endregion

        #region BUSCADOR
       
       

        /// <summary>
        /// cargar el listado de acciones al list del comboBox
        /// </summary>
        private void CargarAcciones()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "acciones.json");
                accionesManager = new AccionesManager(filePath);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al cargar las acciones: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
        }


        private void ComboBox_Buscar_Validating(object sender, CancelEventArgs e)
        {
            if (!accionesManager.Acciones.Contains(comboBox_Buscar.TextValue))
            {
                MensajeGeneral.Mostrar("La tarea que quiere realizar no se encuentra disponible.", MensajeGeneral.TipoMensaje.Advertencia);
                e.Cancel = true; // Cancela la acción si la entrada no es válida
            }
        }

        private void ComboBox_Buscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Buscar.SelectedIndex > 0 || !string.IsNullOrWhiteSpace(comboBox_Buscar.TextValue))
            {
                btn_BuscarTarea.Enabled = true;
                IncrementarTamaño.Incrementar(btn_BuscarTarea);
            }
            else
            {
                btn_BuscarTarea.Enabled = false;
            }
        }
      


        private void ComboBox_Buscar_MouseEnter(object sender, EventArgs e)
        {
            if (!comboBox_Buscar.InnerTextBox.Focused && string.IsNullOrWhiteSpace(comboBox_Buscar.InnerTextBox.Text))
            {
                MostrarPlaceholder();
            }
        }


        private void ComboBox_Buscar_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Buscar.InnerTextBox.Text))
            {
                OcultarPlaceholder();
                comboBox_Buscar.ShowError = false; // Ocultar subrayado si está vacío y no tiene foco
            }
        }

        private void ComboBox_Buscar_GotFocus(object sender, EventArgs e)
        {
            if (comboBox_Buscar.InnerTextBox.Text == placeholderText)
            {
                comboBox_Buscar.InnerTextBox.Text = string.Empty;
                comboBox_Buscar.InnerTextBox.ForeColor = Color.Black;
            }
        }


        private void ComboBox_Buscar_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Buscar.InnerTextBox.Text))
            {
                OcultarPlaceholder();
                comboBox_Buscar.ShowError = false; // Ocultar subrayado al perder foco si está vacío
            }
        }

        private void MostrarPlaceholder()
        {
            if (!comboBox_Buscar.Focused) // Solo mostrar si el ComboBox no tiene foco
            {
                comboBox_Buscar.InnerTextBox.Text = placeholderText;
                comboBox_Buscar.InnerTextBox.ForeColor = Color.FromArgb(32, 123, 171); // Color del placeholder
                comboBox_Buscar.ShowError = false; // Asegurar que no aparezca subrayado rojo
            }
        }


        private void OcultarPlaceholder()
        {
            if (comboBox_Buscar.InnerTextBox.Text == placeholderText)
            {
                comboBox_Buscar.InnerTextBox.Text = string.Empty;
                comboBox_Buscar.InnerTextBox.ForeColor = Color.Black;
            }
        }

        #endregion

        #region LABEL CENTRAL

        /// <summary>
        /// ABRIR FORMULARIO VIDEO INSTRUCTIVO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_OfeliaSara_Click(object sender, EventArgs e)
        {
            

            if (videoInstructivo == null || videoInstructivo.IsDisposed) // Verifica si no está abierto
            {
                // Crear e inicializar el formulario para mostrar el video
                videoInstructivo = new InstructivoDigital(ModuloOrigen.InicioCierre);

                // Suscribirse al evento FormClosed para restaurar el Label
                videoInstructivo.FormClosed += (s, args) => RestaurarLabelVideoInstructivo(label_OfeliaSara);
               

                // Obtener la ubicación y tamaño del formulario principal
                Point menuPrincipalLocation = this.Location;
                Size menuPrincipalSize = this.Size;

                // Calcular la nueva ubicación para el formulario InstructivoDigital
                int x = menuPrincipalLocation.X - 6; // Mantener la misma posición horizontal
                int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

                // Ajustar la ubicación del formulario InstructivoDigital
                videoInstructivo.StartPosition = FormStartPosition.Manual;
                videoInstructivo.Location = new Point(x, y);

                videoInstructivo.Show();
            }
            else
            {
                videoInstructivo.Focus(); // Llevar al frente si ya está abierto
            }
        }

     
       
   

        #endregion

       
    }
}
