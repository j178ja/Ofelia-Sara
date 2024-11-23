using Clases.Apariencia;
using Clases.Botones;
using Controles.Barra_Busqueda;
using MECANOGRAFIA;
using Ofelia_Sara.Clases.Botones.btn_Configuracion;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Mensajes;
using REDACTADOR.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // Para la importación de funciones nativas
using System.Windows.Forms;




namespace Ofelia_Sara.Formularios
{
    public partial class MenuPrincipal : BaseForm
    {
        //funcion nativa para ARRASTRAR EL FORMULARIO
        // Importar las funciones de la API de Windows
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;


        //private ContextMenuStrip contextMenu;
        private AuxiliarConfiguracion auxiliarConfiguracion;
        private AccionesManager accionesManager;//para el comboBox
        Timer timerCerrarForm = new Timer();
        Timer timerMinimizarForm = new Timer();
        private Size originalSizeMecanografia;
        private Point originalLocationMecanografia;
        private PictureBox iconoEscudo;

        // Definir el texto del placeholder
        private string placeholderText = "Buscar tipo de actuación...";

        public MenuPrincipal()
        {
            InitializeComponent();

            auxiliarConfiguracion = new AuxiliarConfiguracion(this);
            PosicionarMenu();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            accionesManager = new AccionesManager("acciones.json");
            ConfigureComboBox(comboBox_Buscar);
            CargarAcciones();//para comboBox_Buscar

            comboBox_Buscar.BringToFront(); // que comboBoxBuscar está encima de comboBoxGNUA

            //----timer para que se vea efecto de cambio de color en los btn cerrar y minimizar
            timerCerrarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerMinimizarForm.Interval = 500;  // Tiempo en milisegundos (500 ms = 0.5 segundos)
            timerCerrarForm.Tick += TimerCerrar_Tick;
            timerMinimizarForm.Tick += TimerMinimizar_Tick;

            //para reducir el btn_Mecanografia
            originalSizeMecanografia = btn_Mecanografia.Size;
            originalLocationMecanografia = btn_Mecanografia.Location;

        }

        //_________________________________--________________________________

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
        //_________________________________________________________

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Configurar el botón para usar el menú de contexto
            btn_Configurar.ContextMenuStrip = auxiliarConfiguracion.CrearMenuConfigurar();

            //Para incrementar el tamaño de btn_configuracion y btn_CambiarTema
            IncrementarTamaño.Incrementar(btn_Configurar);
            IncrementarTamaño.Incrementar(btn_Leyes);
            IncrementarTamaño.Incrementar(iconoEscudo);



            comboBox_Buscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Buscar.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Asignar eventos de GotFocus y LostFocus para que se vea placeholder
            comboBox_Buscar.GotFocus += ComboBox_Buscar_GotFocus;
            //   comboBox_Buscar.LostFocus += ComboBox_Buscar_LostFocus; //se comento porque genera problemas

            ConfigurarBotones();
            //MostrarPlaceholder();

            ToolTipGeneral.ShowToolTip(this, btn_Configurar, "Configuración de elementos.");
            ToolTipGeneral.ShowToolTip(this, btn_Leyes, "Leyes y decretos útiles.");
            ToolTipGeneral.ShowToolTip(this, btn_Mecanografia, "MECANOGRAFIA");
            ToolTipGeneral.ShowToolTip(this, btn_Redactador, "REDACTAR POR VOZ");
            ToolTipGeneral.ShowToolTip(this, label_OfeliaSara, "Instructivo de la aplicación.");
            ToolTipGeneral.ShowToolTip(this, btn_BuscarTarea, "Buscar tarea seleccionada.");
            ToolTipGeneral.ShowToolTip(this, comboBox_Buscar, " Ingrese que tarea desea realizar.");
            ToolTipGeneral.ShowToolTip(this, iconoEscudo, "Boletín Informativo.");


        }

        //--------------------------------------------------------------------------------



        //------------BOTON CONFIGURAR--------------------------------------------------
        private void Btn_Configurar_Click(object sender, EventArgs e)
        {
            // Mostrar el ContextMenuStrip en la posición del botón
            Point botonPosicion = btn_Configurar.PointToScreen(Point.Empty);
            btn_Configurar.ContextMenuStrip.Show(botonPosicion);
        }
        //-------------------------------------------------------------------
        private Form formularioSecundarioAbierto = null;

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

        private void Restablecer_MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioSecundarioAbierto = null;

            // Restaurar el formulario principal
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        // Sobrescribir el evento Resize del formulario principal para ocultarlo si se intenta restaurar
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Si hay un formulario secundario abierto, mantener minimizado MenuPrincipal
            if (this.WindowState == FormWindowState.Normal && formularioSecundarioAbierto != null)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }


        //------------- BOTON BUSCAR--------------------------
        private BindingSource bindingSource;

        private void ConfigureComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            // Configurar el ComboBox para autocompletado
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Habilita el autocompletado
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Ajustar la altura de la lista desplegable para mostrar más ítems
            comboBox.DropDownHeight = 80;
            comboBox.Font = new Font("Arial", 11, FontStyle.Regular); // Cambia a la fuente deseada

            // Cargar las acciones y ordenar
            CargarAcciones();

            // Inicializar y configurar el BindingSource
            bindingSource = new BindingSource();
            bindingSource.DataSource = accionesManager.Acciones;

            // Establecer el DataSource del ComboBox al BindingSource
            comboBox.DataSource = bindingSource;

            // Manejar el evento de texto modificado
            comboBox.TextChanged += (sender, e) =>
            {
                // Filtrar la lista de acciones según el texto ingresado
                string searchText = comboBox.Text.ToLower();
                var filteredActions = accionesManager.Acciones
                    .Where(a => a.ToLower().Contains(searchText))
                    .ToList();

                // Actualizar la fuente de datos del ComboBox
                bindingSource.DataSource = filteredActions;

                // Reabrir la lista desplegable para mostrar las coincidencias
                if (comboBox.Items.Count > 0)
                {
                    comboBox.DroppedDown = true;
                }
            };
        }

        private void CargarAcciones()
        {
            try
            {
                string filePath = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\bin\Debug\acciones.json";
                accionesManager = new AccionesManager(filePath);

                // Elimina el DataSource si está asignado
                comboBox_Buscar.DataSource = null;

                // Poblar el ComboBox con las acciones
                comboBox_Buscar.Items.AddRange(accionesManager.Acciones.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las acciones: " + ex.Message);
            }
        }


        private void ComboBox_Buscar_Validating(object sender, CancelEventArgs e)
        {
            if (!accionesManager.Acciones.Contains(comboBox_Buscar.Text))
            {
                MensajeGeneral.Mostrar("La tarea que quiere realizar no se encuentra disponible.", MensajeGeneral.TipoMensaje.Advertencia);
                e.Cancel = true; // Cancela la acción si la entrada no es válida
            }
        }



        private void ComboBox_Buscar_GotFocus(object sender, EventArgs e)
        {
            if (comboBox_Buscar.Text == placeholderText)
            {
                comboBox_Buscar.Text = "";
                comboBox_Buscar.ForeColor = Color.Black;
            }
        }

        //esta generando problemas
        //private void ComboBox_Buscar_LostFocus(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(comboBox_Buscar.Text))
        //    {
        //        MostrarPlaceholder();
        //    }
        //}


        private void ComboBox_Buscar_MouseHover(object sender, EventArgs e)
        {
            MostrarPlaceholder();
        }
        private void MostrarPlaceholder()
        {
            // Establecer el texto del placeholder y cambiar el color a gris
            comboBox_Buscar.Text = placeholderText;
            comboBox_Buscar.ForeColor = Color.Gray;
        }

        //_________________________________________________________________________________
        //----------------BTON LEYES------------------------------
        private void Btn_Leyes_Click(object sender, EventArgs e)
        {
            // Crear e inicializar el formulario para mostrar documentos
            LeyesForm leyesForm = new LeyesForm();

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la nueva ubicación para el formulario DocumentosForm
            int x = menuPrincipalLocation.X - 6; // Mantener la misma posición horizontal
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

            // Ajustar la ubicación del formulario DocumentosForm
            leyesForm.StartPosition = FormStartPosition.Manual;
            leyesForm.Location = new Point(x, y);

            leyesForm.Show();
        }

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
                    abrirFormulario.AbrirFormulario(formularioSeleccionado);
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
        //-------------------------------------------------------------------------------------
        //eventos para la barra menu

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.FromArgb(255, 69, 58);
            btn_Cerrar.ForeColor = SystemColors.Control;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.LightCoral;
            timerCerrarForm.Start();
        }
        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            timerCerrarForm.Stop();
            Application.Exit();
        }

        private void Btn_Cerrar_MouseHover(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = Color.Lavender;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.LightCoral;
        }

        private void Btn_Cerrar_MouseLeave(object sender, EventArgs e)
        {
            btn_Cerrar.BackColor = SystemColors.ButtonFace;
            btn_Cerrar.ForeColor = SystemColors.ControlDarkDark;
            btn_Cerrar.FlatAppearance.BorderSize = 1;
            btn_Cerrar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }
        //-------------------------------------------------------------------------
        private void TimerMinimizar_Tick(object sender, EventArgs e)
        {
            timerMinimizarForm.Stop();
            this.WindowState = FormWindowState.Minimized;
        }
        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = SystemColors.ActiveCaption;
            btn_Minimizar.ForeColor = SystemColors.Control;
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.Highlight;
            timerMinimizarForm.Start();

        }

        private void Btn_Minimizar_MouseHover(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Lavender;
            btn_Minimizar.FlatAppearance.BorderColor = SystemColors.MenuHighlight;
        }

        private void Btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = SystemColors.ButtonFace;
            btn_Minimizar.ForeColor = SystemColors.ControlDarkDark;
            btn_Minimizar.FlatAppearance.BorderSize = 1;
            btn_Minimizar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }
        //--------------------------------------------------------------------------------
        //eventos para abrir aplicacion mecanografia
        private void Btn_Mecanografia_Click(object sender, EventArgs e)
        {
            // Desplazar el formulario menuPrincipal un 10% hacia abajo desde el borde superior de la pantalla
            int newY = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.05); // 5% de la altura de la pantalla

            // Cambiar la ubicación del formulario menuPrincipal
            this.Location = new Point(this.Location.X, newY);

            // Crear e inicializar el formulario para mostrar mecanografiado
            Mecanografia mecanografia = new Mecanografia();

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


        // Diccionarios para almacenar el tamaño y la ubicación originales de cada botón
        private Dictionary<System.Windows.Forms.Button, Size> originalSizes = new Dictionary<System.Windows.Forms.Button, Size>();
        private Dictionary<System.Windows.Forms.Button, Point> originalLocations = new Dictionary<System.Windows.Forms.Button, Point>();

        // Método para configurar los valores originales al cargar el formulario
        private void ConfigurarBotones()
        {
            // Almacena el tamaño y la ubicación originales de cada botón
            originalSizes[btn_Mecanografia] = btn_Mecanografia.Size;
            originalLocations[btn_Mecanografia] = btn_Mecanografia.Location;

            originalSizes[btn_Redactador] = btn_Redactador.Size;
            originalLocations[btn_Redactador] = btn_Redactador.Location;
        }

        // Método MouseDown para simular animación de "clic"

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

        // Método MouseUp para restaurar tamaño y ubicación originales
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton && originalSizes.ContainsKey(boton) && originalLocations.ContainsKey(boton))
            {
                // Restaurar tamaño y ubicación originales
                boton.Size = originalSizes[boton];
                boton.Location = originalLocations[boton];
            }
        }


        // Método MouseHover para cambiar borde
        private void Btn_MouseHover(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton)
            {
                boton.FlatAppearance.BorderSize = 1;
                boton.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            }
        }

        // Método MouseLeave para restaurar borde y tamaño originales
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button boton && originalSizes.ContainsKey(boton))
            {
                boton.FlatAppearance.BorderSize = 0;
                boton.Size = originalSizes[boton];
            }
        }
        //-----------------------------------------------------------------------------------

        // Bandera para activar o desactivar el subrayado personalizado
        private bool mostrarSubrayado = false;
        //para hacer que se extienda 
        private int lineWidth = 0;
        private bool isAnimating = false;
        private Timer animationTimer;

        // Método para activar el subrayado en MouseHover
        private void Label_OfeliaSara_MouseHover(object sender, EventArgs e)
        {
            isAnimating = true;
            lineWidth = 0;

            // Configurar el Timer si aún no está configurado
            if (animationTimer == null)
            {
                animationTimer = new Timer();
                animationTimer.Interval = 15; // Intervalo en ms para una animación suave
                animationTimer.Tick += (s, args) =>
                {
                    if (lineWidth < label_OfeliaSara.Width / 2)
                    {
                        lineWidth += 2; // Aumenta gradualmente la longitud de la línea
                        label_OfeliaSara.Invalidate(); // Redibuja el Label
                    }
                    else
                    {
                        animationTimer.Stop(); // Detiene el Timer cuando se completa la animación
                    }
                };
            }

            animationTimer.Start(); // Inicia el Timer para la animación
        }

        // Método para desactivar el subrayado en MouseLeave
        private void Label_OfeliaSara_MouseLeave(object sender, EventArgs e)
        {
            isAnimating = false;
            lineWidth = 0;
            animationTimer?.Stop(); // Detener el Timer
            label_OfeliaSara.Invalidate(); // Redibuja el Label para eliminar el subrayado
        }


        // Método Paint para dibujar el subrayado personalizado


        private void Label_OfeliaSara_Paint(object sender, PaintEventArgs e)
        {
            if (isAnimating)
            {
                // Define el color y grosor de la línea
                using (Pen pen = new Pen(SystemColors.Highlight, 3))
                {
                    // Centro del Label
                    int centerX = label_OfeliaSara.Width / 2;
                    int y = label_OfeliaSara.Font.Height; // Posición 3 píxeles debajo del texto

                    // Dibuja la línea desde el centro hacia los extremos
                    e.Graphics.DrawLine(pen, centerX - lineWidth, y, centerX + lineWidth, y);
                }
            }
        }





        private void Label_OfeliaSara_Click(object sender, EventArgs e)
        {
            label_OfeliaSara.ForeColor = Color.Coral;
            label_OfeliaSara.Font = new Font(label_OfeliaSara.Font, FontStyle.Underline);//para subrayar


            // Crear e inicializar el formulario para mostrar el video
            VideoInstructivo videoInstructivo = new VideoInstructivo();

            // Suscribirse al evento FormClosed para restaurar el Label
            videoInstructivo.FormClosed += (s, args) =>
            {
                label_OfeliaSara.ForeColor = SystemColors.ControlText;
                label_OfeliaSara.Font = new Font(label_OfeliaSara.Font, FontStyle.Regular); // Eliminar subrayado
            };

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la nueva ubicación para el formulario DocumentosForm
            int x = menuPrincipalLocation.X - 6; // Mantener la misma posición horizontal
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

            // Ajustar la ubicación del formulario DocumentosForm
            videoInstructivo.StartPosition = FormStartPosition.Manual;
            videoInstructivo.Location = new Point(x, y);

            videoInstructivo.Show();
        }


        //para poder arrastrar el formulario
        private void panel_MenuSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btn_Redactador_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Dictado 
            Redactador redactadorForm = new Redactador();

            // Obtener la ubicación y tamaño del formulario principal
            Point menuPrincipalLocation = this.Location;
            Size menuPrincipalSize = this.Size;

            // Calcular la nueva ubicación para el formulario DocumentosForm
            int x = menuPrincipalLocation.X - 2; // Mantener la misma posición horizontal
            int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

            // Ajustar la ubicación del formulario DocumentosForm
            redactadorForm.StartPosition = FormStartPosition.Manual;
            redactadorForm.Location = new Point(x, y);

            redactadorForm.ShowDialog(); // Mostrar el formulario como modal
        }



        private void iconoEscudo_Click(object sender, EventArgs e)
        {
            string url = "https://boletin.mseg.gba.gov.ar/";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Necesario para abrir el navegador predeterminado
                });
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir la página web: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


    }
}
