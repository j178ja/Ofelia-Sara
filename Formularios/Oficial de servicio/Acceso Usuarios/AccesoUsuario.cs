using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Acceso_Usuarios
{
    public partial class AccesoUsuario : BaseForm
    {
        #region VARIABLES
        private Timer capsLockTimer; // Timer para verificar Caps Lock

        // Define una variable para llevar el control del estado de visibilidad
        private readonly bool esContraseñaVisible = false;
        // Variables auxiliares para animación
        private readonly int lineWidth = 0;
        private readonly bool isAnimating = false;
        private bool capsLockState = false; // Almacena el estado actual de Caps Lock (MAYUSCULA ACTIVADO)
        #endregion

        #region CONSTRUCTOR
        public AccesoUsuario()
        {
            InitializeComponent();


            pictureBox_OjoContraseña.Enabled = false;
        
            textBox_Contraseña.InnerTextBox.GotFocus += (s, e) => IndicadorMayusculaActivado();
            textBox_Contraseña.InnerTextBox.KeyPress += (s, e) => IndicadorMayusculaActivado();
            textBox_Contraseña.InnerTextBox.LostFocus += (s, e) => pictureBox_MayusculaActivada.Visible = false;
            InicializarCapsLockTimer(); // Inicializar el Timer

            // Inicializa el estado de Caps Lock al cargar el formulario
            capsLockState = Control.IsKeyLocked(Keys.CapsLock);
            IndicadorMayusculaActivado(); // Muestra u oculta el indicador inicial

            // Inicia el Timer para seguir verificando el estado
            InicializarCapsLockTimer();
        }

        #endregion CONSTRUCTOR

        #region LOAD
        private void Usuario_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);
            InicializarEstiloBoton(btn_Ingresar);

            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;

            this.Shown += Focus_Shown;//para que haga foco en un textBox
        }
        #endregion

        /// <summary>
        /// asegura posicionamiento de foco en usuario al cargar form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_Shown(object sender, EventArgs e)
        {
            textBox_Usuario.Focus();
        }

        private void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de registro
            Registro registroForm = new Registro();

            // Obtener la ubicación de UsuarioForm (este es 'this' ya que el código está dentro de UsuarioForm)
            Form usuarioForm = this;

            // Ajustar la posición del formulario de registro para que esté justo encima de UsuarioForm
            int posicionX = usuarioForm.Location.X + (usuarioForm.Width - registroForm.Width) / 2; // Centrar en X
            int posicionY = usuarioForm.Location.Y + (usuarioForm.Height - registroForm.Height) / 2 + 112; // no es la mejor forma pero se posiciona debajo de menu_Principal


            // Establecer la posición manualmente
            registroForm.StartPosition = FormStartPosition.Manual;
            registroForm.Location = new Point(posicionX, posicionY);

            // Mostrar el formulario de registro como un diálogo modal
            registroForm.ShowDialog();
        }

        /// <summary>
        /// MENSAJE DE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsuarioForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Ingrese en los campos correspondientes, Usuario y contraseña." + "En caso de no estar registrado, presione boton REGISTRARSE");
        }

       
        /// <summary>
        /// MOSTRAR CONTRASEÑA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_OjoContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '\0'; // Muestra el texto real
            pictureBox_OjoContraseña.Image = Properties.Resources.ojo_Contraseña; // Cambia la imagen al icono de "visible"
        }

        /// <summary>
        /// OCULTAR CONTRASEÑA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_OjoContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '*'; // Oculta el texto con asteriscos
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoCerrado; // Cambia la imagen al icono de "oculto"
        }

        /// <summary>
        /// activa/desactiva visualizador de contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Contraseña.TextValue))
            {
                // Desactiva la imagen si no hay texto
                pictureBox_OjoContraseña.Enabled = false;
            }
            else
            {
                // Activa la imagen si hay texto
                pictureBox_OjoContraseña.Enabled = true;
            }
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            // Realizar validación de usuario (ejemplo)
            if (ValidarUsuario())
            {
                // Si la validación es exitosa, cerrar con OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MensajeGeneral.Mostrar("Credenciales incorrectas. Intente de nuevo.", MensajeGeneral.TipoMensaje.Error);
            }
            // Asumiendo que tienes acceso al formulario principal (MenuPrincipal)
            Form menuPrincipal = Application.OpenForms["MenuPrincipal"];
            if (menuPrincipal != null)
            {
                // Obtener la ubicación y tamaño del formulario principal
                Point menuPrincipalLocation = menuPrincipal.Location;
                Size menuPrincipalSize = menuPrincipal.Size;

                // Cierra el formulario actual (UsuarioForm)
                this.Close();

                // Crear una instancia del formulario ModificarEliminar
                ModificarEliminar formModificarEliminar = new ModificarEliminar();

                // Calcular la nueva ubicación para el formulario ModificarEliminar
                int x = menuPrincipalLocation.X - 6; // Mantener la misma posición horizontal
                int y = menuPrincipalLocation.Y + menuPrincipalSize.Height + 10; // Colocar justo debajo

                // Ajustar la ubicación del formulario ModificarEliminar
                formModificarEliminar.StartPosition = FormStartPosition.Manual;
                formModificarEliminar.Location = new Point(x, y);

                // Mostrar el formulario como una ventana modal
                formModificarEliminar.Show();
            }

        }

        
        /// <summary>
        /// Método de ejemplo para la validación
        /// </summary>
        /// <returns></returns>
        private bool ValidarUsuario()
        {
            // Lógica de validación (e.g., comparación de contraseñas, etc.)
            return true; // Retornar true si la validación es correcta
        }
      
        /// <summary>
        ///  iniciar timer para verificar activacion de mayuscula
        /// </summary>
        private void InicializarCapsLockTimer()
        {
            capsLockTimer = new Timer
            {
                Interval = 200 // Verificar cada 200 ms
            };
            capsLockTimer.Tick += CapsLockTimer_Tick;
            capsLockTimer.Start();
        }

        /// <summary>
        /// temporizador para verificar mayuscula activado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CapsLockTimer_Tick(object sender, EventArgs e)
        {
            // Verifica si el estado de Caps Lock ha cambiado
            bool isCapsLock = Control.IsKeyLocked(Keys.CapsLock);

            if (isCapsLock != capsLockState) // Solo actualiza si hay un cambio en el estado
            {
                capsLockState = isCapsLock;
                IndicadorMayusculaActivado(); // Actualiza el indicador visual
            }
        }

        /// <summary>
        /// Indicador de mayuscula activado
        /// </summary>
        private void IndicadorMayusculaActivado()
        {
            if (capsLockState)
            {
                pictureBox_MayusculaActivada.Visible = true; // Mostrar el indicador visual
                ToolTipGeneral.Mostrar(pictureBox_MayusculaActivada, "Mayúsculas activadas.");
            }
            else
            {
                pictureBox_MayusculaActivada.Visible = false; // Ocultar el indicador visual
            }
        }

        /// <summary>
        /// cierre de recursos al cerrar formulario
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Detener el Timer al cerrar el formulario para evitar fugas de recursos
            capsLockTimer?.Stop();
            capsLockTimer?.Dispose();
            base.OnFormClosing(e);
        }


       
        /// <summary>
        /// Llama a que se active subrayado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subrayado_MouseEnter(object sender, EventArgs e)
        {

            if (sender is Control control)
            {
                SubrayadoAnimado.Iniciar(control);

            }
        }

        /// <summary>
        /// Llama a que se desactive subrayado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subrayado_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                SubrayadoAnimado.Detener(control);
                control.Invalidate(); // Redibuja para eliminar el subrayado
            }
        }

        /// <summary>
        /// dibuja subrayado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subrayado_Paint(object sender, PaintEventArgs e)
        {
            
                if (sender is Control control)
                {
                    // Asegúrate de que se use el método correcto
                    SubrayadoAnimado.Aplicar(control, e.Graphics, SystemColors.Highlight, 3);
                }
            
        }
    }
}
