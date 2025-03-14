using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Acceso_Usuarios
{
    public partial class Registro : BaseForm
    {
        #region VARIABLES
        private Timer capsLockTimer; // Timer para verificar Caps Lock
        private bool capsLockState; // Timer para verificar Caps Lock

        private bool esContraseñaVisible = false; // Define una variable para llevar el control del estado de visibilidad
        #endregion

        #region CONSTRUCTOR
        public Registro()
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
        #endregion

        #region LOAD
        private void Registro_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);



            // Configurar el comportamiento de los ComboBox

            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;//inicializa con la imagen predeterminada de inicio
            //pictureBox_OjoContraseña.Enabled = false;


        }
        #endregion



        private void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están completados
            if (!ValidarTextBoxes(this))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                MensajeGeneral.Mostrar("Debe completar la totalidad de campos.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                //AGREGAR LOGICA PARA ALMACENAR EL NUEVO REGISTRO DE USUARIO
                MensajeGeneral.Mostrar("Se ha registrado un nuevo Usuario.", MensajeGeneral.TipoMensaje.Exito);

            }
        }

        /// <summary>
        /// VERIFICA LOS CAMPOS ANTES DE REGISTRARSE
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static bool ValidarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Verificar si es un TextBox y está vacío
                if (control is CustomTextBox && string.IsNullOrWhiteSpace(((CustomTextBox)control).TextValue))
                {
                    return false;
                }
                // Si el control tiene controles hijos, aplicar la validación recursivamente
                if (control.HasChildren)
                {
                    if (!ValidarTextBoxes(control))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// BOTON LIMPIAR/ELIMINAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
            pictureBox_OjoContraseña.Enabled = false;

        }

        /// <summary>
        /// MENSAJE DE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registro_HelpButtonClicked(object sender, CancelEventArgs e)
        {

            MostrarMensajeAyuda("Complete la totalidad de los campos para poder registrar un nuevo Usuario.");
        }

        /// <summary>
        /// MUESTRA CONTRASEÑA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_OjoContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '\0'; // Muestra el texto real
            pictureBox_OjoContraseña.Image = Properties.Resources.ojo_Contraseña; // Cambia la imagen al icono de "visible"
        }

        /// <summary>
        /// OCULTA CONTRASEÑA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_OjoContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '*'; // Oculta el texto con asteriscos
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoCerrado; // Cambia la imagen al icono de "oculto"
        }

        /// <summary>
        /// DESACTIVA IMAGEN SI NO HAY TEXTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Contraseña.InnerTextBox.Text))
            {
                pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
                // Desactiva la imagen si no hay texto
                pictureBox_OjoContraseña.Enabled = false;
            }
            else
            {
                // Activa la imagen si hay texto
                pictureBox_OjoContraseña.Enabled = true;
            }
        }



        /// <summary>
        /// INICIALIZA VERIFICADOR DE MAYUSCULA
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
        /// VERIFICA ESTADO DE TECLA MAYUSCULA
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
        /// MUESTRA IMAGEN INDICADORA DE MAYUSCULA ACTIVADO
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
        /// DETIENE EVENTOS AL CERRAR EL FORMULARIO
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Detener el Timer al cerrar el formulario para evitar fugas de recursos
            capsLockTimer?.Stop();
            capsLockTimer?.Dispose();
            base.OnFormClosing(e);
        }


    }
}
