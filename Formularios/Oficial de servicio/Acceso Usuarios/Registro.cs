using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
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
        private Timer capsLockTimer; // Timer para verificar Caps Lock
        private bool capsLockState; // Timer para verificar Caps Lock
        public Registro()
        {
            InitializeComponent();

            //para redondear bordes panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
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

        private void Registro_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);
            InicializarEstiloBoton(btn_Limpiar);

            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            //  ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
            //pictureBox_OjoContraseña.Enabled = false;

            //  deshabilitar la edición del ComboBox_Escalafon
            comboBox_Escalafon.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;
            comboBox_Jerarquia.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;

            ClaseNumeros.AplicarFormatoYLimite(textBox_Legajo, 7);
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_Apellido);
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(CustomComboBox customComboBox)
        {
            customComboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }
        //--------------------------------------------------------------------------

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
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                DialogResult result = MessageBox.Show("Se ha registrado un nuevo Usuario.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si el usuario presiona "OK", cerrar el formulario actual
                if (result == DialogResult.OK)
                {
                    this.Close(); // Cierra el formulario actual
                }
            }
        }
        private bool ValidarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Verificar si es un TextBox y está vacío
                if (control is TextBox && string.IsNullOrWhiteSpace(((TextBox)control).Text))
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

        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            comboBox_Escalafon.SelectedIndex = -1;
            //sobre ojo
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoINICIO;
            pictureBox_OjoContraseña.Enabled = false;

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Advertencia);//esto muestra una ventana con boton aceptar
        }

        private void Registro_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Complete la totalidad de los campos para poder registrar un nuevo Usuario.", MensajeGeneral.TipoMensaje.Advertencia);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //--------------------------------------------------------------------

        // Define una variable para llevar el control del estado de visibilidad
        private bool esContraseñaVisible = false;

        private void PictureBox_OjoContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '\0'; // Muestra el texto real
            pictureBox_OjoContraseña.Image = Properties.Resources.ojo_Contraseña; // Cambia la imagen al icono de "visible"
        }

        private void PictureBox_OjoContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_Contraseña.PasswordChar = '*'; // Oculta el texto con asteriscos
            pictureBox_OjoContraseña.Image = Properties.Resources.ojoCerrado; // Cambia la imagen al icono de "oculto"
        }

        private void TextBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Contraseña.InnerTextBox.Text))
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

        private void TextBox_Legajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

  
        private void InicializarCapsLockTimer()
        {
            capsLockTimer = new Timer
            {
                Interval = 200 // Verificar cada 200 ms
            };
            capsLockTimer.Tick += CapsLockTimer_Tick;
            capsLockTimer.Start();
        }

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

        private void IndicadorMayusculaActivado()
        {
            if (capsLockState)
            {
                pictureBox_MayusculaActivada.Visible = true; // Mostrar el indicador visual
                ToolTipGeneral.ShowToolTip(pictureBox_MayusculaActivada, "Mayúsculas activadas.");
            }
            else
            {
                pictureBox_MayusculaActivada.Visible = false; // Ocultar el indicador visual
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Detener el Timer al cerrar el formulario para evitar fugas de recursos
            capsLockTimer?.Stop();
            capsLockTimer?.Dispose();
            base.OnFormClosing(e);
        }

      
    }
}
