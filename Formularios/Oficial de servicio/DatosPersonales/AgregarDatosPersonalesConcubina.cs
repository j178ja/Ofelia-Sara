using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Formularios.General;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales
{
    public partial class AgregarDatosPersonalesConcubina : BaseForm
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public AgregarDatosPersonalesConcubina()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            this.FormClosing += AgregarDatos_FormClosing;//para mensaje de alerta en caso de no guardar datos
        }

        private void AgregarDatosPersonalesConcubina_Load(object sender, EventArgs e)
        {
            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad

            MayusculaSola.AplicarAControl(comboBox_Parentesco.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_LugarNacimiento);
            MayusculaSola.AplicarAControl(comboBox_Nacionalidad.InnerTextBox);
            MayusculaSola.AplicarAControl(textBox_Ocupacion);
            MayusculaSola.AplicarAControl(textBox_Apodo);
            MayusculaSola.AplicarAControl(textBox_Localidad);
            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Dni, 10);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Edad, 2);

            btn_AgregarConcubina.Enabled = false;
            InicializarEstiloBotonAgregar(btn_AgregarConcubina);// estilo boton

            comboBox_EstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;//deshabilita ingreso de datos del usuario en comboBox estado civil

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarConcubina, "Seleccione ESTADO CIVIL para agregar un nuevo vinculo.", "Seleccione para agregar nuevo familiar");
        }

        private void comboBox_EstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar el botón cuando se seleccione un ítem en el ComboBox
            if (comboBox_EstadoCivil.SelectedIndex >= 0)
            {
                btn_AgregarConcubina.Enabled = true;

            }
            else
            {
                btn_AgregarConcubina.Enabled = false;
            }

        }
        //-------------------------------------------------------------------
        // Variable para almacenar la posición original
        private Point originalPosition;
        private void btn_AgregarConcubina_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario AgregarDatosPersonalesConcubina
            Form agregarDatosPersonalesConcubina = new AgregarDatosPersonalesConcubina();

            // Guardar la posición original del formulario
            originalPosition = this.Location;

            // Obtener el tamaño de ambos formularios
            int totalWidth = this.Width + agregarDatosPersonalesConcubina.Width;
            int height = Math.Max(this.Height, agregarDatosPersonalesConcubina.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario original a la izquierda
            this.Location = new Point(startX, startY);

            // Posicionar el formulario AgregarDatosPersonalesConcubina a la derecha del formulario original
            agregarDatosPersonalesConcubina.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesConcubina.Location = new Point(startX + this.Width, startY);

            // Mostrar el formulario AgregarDatosPersonalesConcubina
            agregarDatosPersonalesConcubina.FormClosed += AgregarDatosPersonalesConcubina_FormClosed;
            agregarDatosPersonalesConcubina.Show();

        }
        private void AgregarDatosPersonalesConcubina_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Restaurar la posición original del formulario
            this.Location = originalPosition;
        }

        private void textBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);

        }


        //--------------------------------------------------------------------
        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void AgregarDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado los datos de esta persona. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
                {
                    // Hacer visibles los botones
                    mensaje.MostrarBotonesConfirmacion(true);

                    DialogResult result = mensaje.ShowDialog();
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Cancelar el cierre del formulario
                    }
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
        }
    }
}
