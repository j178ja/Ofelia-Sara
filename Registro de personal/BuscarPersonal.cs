
using BaseDatos.Adm_BD.Manager;
using Clases.Texto;
using Controles.Controles;
using Controles.Controles.Aplicadas_con_controles;
using Controles.Controles.Reposicionar_paneles.Buscar_Personal;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class BuscarPersonal : BaseForm
    {
        private int borderRadius = 15;
        private int borderSize = 7;
        private Color borderColor = Color.FromArgb(0, 154, 174); // Color del borde
        private Color panelColor = Color.FromArgb(178, 213, 230); // Color de fondo del panel

        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public BuscarPersonal()
        {
            InitializeComponent();
            this.FormClosing += BuscarPersonal_FormClosing;

        }

        private void BuscarPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Registrar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
            //---Inicializar para desactivar los btn AGREGAR PERSONAL 
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);

            textBox_NumeroLegajo.MaxLength = 7;
            this.Shown += Focus_Shown;//para que haga foco en un textBox

            this.BackColor = Color.FromArgb(0, 154, 174); // Color de fondo del formulario

            // Configurar el panel
            panel1.BackColor = panelColor; // Color de fondo del panel
            panel1.Paint += panel1_Paint;

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarPersonal, "Ingrese un numero de LEGAJO vàlido para agregar ratificafciòn.", "Agregar nueva ratificacion");
        }

        //---redibujar para solucionar problema de bordes redondeados

        private void DrawRoundedBorder(Panel panel, int borderRadius, int borderSize, Color borderColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(panel.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(panel.Width - borderRadius, panel.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, panel.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                using (Pen pen = new Pen(borderColor, borderSize))
                {
                    panel.CreateGraphics().DrawPath(pen, path);
                }
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedBorder(panel1, borderRadius, borderSize, borderColor);
        }

        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_NumeroLegajo.Focus();
        }


        //________________________________________________________________________________

        //------- BOTON PARA REGISTRAR DATOS COMPLETOS DE NUEVO PERSONAL----------
        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            // Obtener el texto del TextBox_NumeroLegajo en BuscarPersonal
            string numeroLegajo = textBox_NumeroLegajo.Text;

            // Crear y mostrar el formulario NuevoPersonal, pasando el número de legajo
            NuevoPersonal nuevoPersonalForm = new NuevoPersonal(numeroLegajo);
            nuevoPersonalForm.ShowDialog();
        }


        //-----------------METODO PARA LOS NUMEROS EN TEXTBOX NUMERO LEGAJO-----------------
        private void textBox_NumeroLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Si el carácter es dígito, continúa con el procesamiento
            if (char.IsDigit(e.KeyChar))
            {
                // Aplicar formato y longitud máxima al textBox_NumeroLegajo
                ClaseNumeros.AplicarFormatoYLimite(textBox_NumeroLegajo, 7);

            }
        }

        //_________________________________________________________________________________________

        //-------VALIDACION ACTIVACION BTN_AGREGAR PERSONAL------------------------------------------
        private void textBox_NumeroLegajo_TextChanged(object sender, EventArgs e)
        {
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);//habilita el btn_AgregarPersonal en caso de tener texto
        }

        private void btn_AgregarPersonal_Click(object sender, EventArgs e)
        {
            // Validar que el texto no sea menor a 6 caracteres
            string textoFormateado = textBox_NumeroLegajo.Text;
            if (textoFormateado.Length < 6)
            {
                MensajeGeneral.Mostrar("El número no corresponde a un número de legajo válido, verifique que el número sea correcto.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                VerificarNumeroLegajo();
            }
        }



        // Este método manejará el evento cuando el botón Modificar Personal sea clicado
        private void PersonalSeleccionadoControl_ModificarPersonalClicked(object sender, EventArgs e)
        {
            // Abrir el formulario NuevoPersonal
            NuevoPersonal nuevoPersonalForm = new NuevoPersonal();
            nuevoPersonalForm.ShowDialog();
        }

        //---------------------------------------------------------------------------------------------------------------------


        //____________________________________________________________________________________________

        private void BuscarPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Ingrese un número de legajo policial válido para caragar nueva ratificacion testimonial", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verificar si se han agregado controles del tipo PersonalSeleccionadoControl al panel
            var controlesAgregados = panel_PersonalSeleccionado.Controls.OfType<PersonalSeleccionadoControl>().Count();

            if (controlesAgregados <= 0)
            {
                MensajeGeneral.Mostrar(
                    "No ha seleccionado ningún efectivo policial al que recepcionarle Ratificación Testimonial.",
                    MensajeGeneral.TipoMensaje.Advertencia
                );
            }
            else
            {
                // Marcar que los datos fueron guardados
                datosGuardados = true;

                MensajeGeneral.Mostrar(
                    "Listado de Ratificaciones Testimoniales guardado exitosamente.",
                    MensajeGeneral.TipoMensaje.Exito
                );
            }
        }



        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void BuscarPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado las ratificaciones testimoniales agregadas. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
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
        // Método para verificar que el personal seleccionado no haya sido previamente agregado
        private void VerificarNumeroLegajo()
        {
            string numeroIngresado = textBox_NumeroLegajo.Text;

            // Verificar si el legajo ya existe en el panel antes de agregar un nuevo control
            if (EsLegajoYaAgregado(numeroIngresado))
            {
                MensajeGeneral.Mostrar("El personal seleccionado ya ha sido ingresado para su ratificación testimonial.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                // Si no se encuentra el legajo, llama a AgregarPersonalSeleccionado
                AgregarPersonalSeleccionado();
            }
        }

        // Método auxiliar para buscar si el legajo ya está agregado en los controles existentes
        private bool EsLegajoYaAgregado(string numeroLegajo)
        {
            foreach (Control control in panel_PersonalSeleccionado.Controls)
            {
                // Verificar si el control es una instancia de PersonalSeleccionadoControl
                if (control is PersonalSeleccionadoControl personalControl)
                {
                    // Buscar el Label con el nombre específico "label_NumeroLegajo"
                    Label label_NumeroLegajo = personalControl.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "label_NumeroLegajo");

                    // Comparar el texto del Label con el número de legajo ingresado
                    if (label_NumeroLegajo != null && label_NumeroLegajo.Text == numeroLegajo)
                    {
                        return true; // Si encuentra coincidencia, retorna true
                    }
                }
            }
            return false; // Retorna false si no encuentra coincidencias
        }

        // Método para agregar un nuevo control de personal seleccionado al panel
        private void AgregarPersonalSeleccionado()
        {
            try
            {
                PersonalManager personalManager = new PersonalManager();
                string textoFormateado = textBox_NumeroLegajo.Text;

                // Verificar si el número de legajo existe en la base de datos
                if (!personalManager.ExisteLegajo(textoFormateado))
                {
                    MensajeGeneral.Mostrar("El número de legajo ingresado no corresponde a un efectivo policial registrado", MensajeGeneral.TipoMensaje.Advertencia);
                    return; // Termina la ejecución si el legajo no existe
                }

                // Crear y configurar el nuevo control de personal seleccionado
                PersonalSeleccionadoControl nuevoControl = new PersonalSeleccionadoControl();
                nuevoControl.ModificarPersonalClicked += PersonalSeleccionadoControl_ModificarPersonalClicked;
                nuevoControl.ActualizarDatosPorLegajo(textoFormateado);

                // Agregar el nuevo control al panel
                AgregarPersonal agregarPersonal = new AgregarPersonal();
                agregarPersonal.AgregarControlAlPanel(
                    nuevoControl,
                    panel_PersonalSeleccionado,
                    panel_PersonalSeleccionado,
                    panel_ControlesInferiores,
                    panel1,
                    this
                );
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al conectar con la base de datos: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                // Limpiar el contenido del TextBox independientemente del resultado
                textBox_NumeroLegajo.Text = string.Empty;
                textBox_NumeroLegajo.Focus();
            }
        }


    }

}