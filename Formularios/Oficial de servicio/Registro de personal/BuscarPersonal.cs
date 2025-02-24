
using BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Ofl_Sara;
using Ofelia_Sara.Controles.Controles.Reposicionar_paneles.Buscar_Personal;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Registro_de_personal
{
    public partial class BuscarPersonal : BaseForm
    {
        #region VARIABLES



        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        #endregion

        #region CONSTRUCTOR
        public BuscarPersonal()
        {
            InitializeComponent();
            this.FormClosing += BuscarPersonal_FormClosing;
            textBox_NumeroLegajo.ShortcutsEnabled = false; // Desactiva atajos como Ctrl+V
        }
        #endregion

        #region LOAD

        private void BuscarPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Registrar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
        
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.TextValue); //inicializa desactivado si no tiene numero

            textBox_NumeroLegajo.MaxLength = 7;//6 para numero legajo +1 por el "punto"
            this.Shown += Focus_Shown;//para que haga foco en un textBox





            ToolTipGeneral.Mostrar(btn_Registrar, " Registrar o modificar PERSONAL.");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarPersonal, "Ingrese un numero de LEGAJO vàlido para agregar ratificafciòn.", "Agregar nueva ratificacion");
            //..........................
            //Suscribir eventos para controles existentes en el panel al cargar el formulario
            foreach (var control in panel_PersonalSeleccionado.Controls.OfType<PersonalSeleccionadoControl>())
            {
                control.Eliminado += (s, arg) => ActualizarContadorRatificaciones();
            }

        }
        #endregion



        /// <summary>
        /// METODO PARA CARGAR CON FOCO EN NUMERO DE LEGAJO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_NumeroLegajo.Focus();
        }


        /// <summary>
        /// METODO PARA REGISTRAR UNA NUEVA RATIFICACION TESTIMONIAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            // Obtener el texto del TextBox_NumeroLegajo en BuscarPersonal
            string numeroLegajo = textBox_NumeroLegajo.Text;

            // Crear y mostrar el formulario NuevoPersonal, pasando el número de legajo
            NuevoPersonal nuevoPersonalForm = new(numeroLegajo);
            nuevoPersonalForm.ShowDialog();
        }

        #region CONFUGURACION TEXTBOX NUMERO LEGAJO
        /// <summary>
        /// METODO DE VALIDACION DE NUMERO DE LEGAJO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBox_NumeroLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Intercepta comandos de teclado (Ctrl+V, Shift+Insert) y los bloquea si el contenido no es numérico
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.V) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                if (Clipboard.ContainsText() && !Regex.IsMatch(Clipboard.GetText(), @"^\d+$"))
                {
                    e.SuppressKeyPress = true; // Bloquea la acción de pegado si hay caracteres no numéricos
                }
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Intercepta el pegado desde el menú contextual y solo permite números
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x0302;
            const int WM_CONTEXTMENU = 0x007B;

            if (m.Msg == WM_PASTE)
            {
                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();
                    string soloNumeros = new string(clipboardText.Where(char.IsDigit).ToArray());

                    if (clipboardText != soloNumeros) // Si el texto pegado tenía caracteres inválidos
                    {
                        int cursorPos = textBox_NumeroLegajo.SelectionStart; // Guardar la posición del cursor
                        textBox_NumeroLegajo.TextValue = soloNumeros; // Reemplazar con solo los números
                        textBox_NumeroLegajo.SelectionStart = Math.Min(cursorPos, textBox_NumeroLegajo.TextValue.Length); // Restaurar posición del cursor
                    }
                }
                return; // Evita que el pegado original de Windows ocurra
            }

            if (m.Msg == WM_CONTEXTMENU) // Bloquear menú contextual
            {
                return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Borra automáticamente caracteres no numéricos si logran colarse
        /// </summary>
        protected override void OnTextChanged(EventArgs e)
        {
            string newText = Regex.Replace(textBox_NumeroLegajo.TextValue, "[^0-9]", ""); // Solo permite números
            if (textBox_NumeroLegajo.TextValue != newText)
            {
                int cursorPos = textBox_NumeroLegajo.SelectionStart - 1; // Guardar posición del cursor
                textBox_NumeroLegajo.TextValue = newText;
                textBox_NumeroLegajo.SelectionStart = Math.Max(0, cursorPos); // Restaurar posición del cursor
            }
            base.OnTextChanged(e);
        }


        /// <summary>
        /// VALIDACION ACTIVACION BTN_AGREGAR PERSONAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBox_NumeroLegajo_TextChanged(object sender, EventArgs e)
        {
            
            ValidarYHabilitarBoton(textBox_NumeroLegajo, btn_AgregarPersonal, null, 6);//habilita el btn_AgregarPersonal en caso de tener (5 caracteres)
        }

        #endregion
        /// <summary>
        /// METODO PARA VERIFICAR NUMERO DE LEGAJO EN BASE DE DATOS Y AGREGAR RATIFICACION 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AgregarPersonal_Click(object sender, EventArgs e)
        {
            // Validar que el texto no sea menor a 6 caracteres
            string textoFormateado = textBox_NumeroLegajo.TextValue;
            if (textoFormateado.Length < 6)
            {
                MensajeGeneral.Mostrar("El número no corresponde a un número de legajo válido, verifique que el número sea correcto.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                VerificarNumeroLegajo();
                ActualizarContadorRatificaciones();
            }
        }


        /// <summary>
        /// Este método manejará el evento cuando el botón Modificar Personal sea clicado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void PersonalSeleccionadoControl_ModificarPersonalClicked(object sender, EventArgs e)
        {
            // Abrir el formulario NuevoPersonal
            NuevoPersonal nuevoPersonalForm = new();
            nuevoPersonalForm.ShowDialog();
        }


        /// <summary>
        /// MENSAJE DE AYUDA EN FORMULARIO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BuscarPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {

            MostrarMensajeAyuda("Ingresando número de legajo, al guardar se generará las ratificaciones testimoniales del personal seleccionado");
        }


        /// <summary>
        /// EVENTO PARA GUARDAR LAS RATIFICACIONES TESTIMONIALES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Guardar_Click(object sender, EventArgs e)
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


        /// <summary>
        /// Evento FormClosing para verificar si los datos están guardados antes de cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BuscarPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {

            MostrarMensajeCierre(e, "No has guardado las ratificaciones testimoniales agregadas. ¿Estás seguro de que deseas cerrar sin guardar?");
        }


        /// <summary>
        /// Método para verificar que el personal seleccionado no haya sido previamente agregado
        /// </summary>

        private void VerificarNumeroLegajo()
        {
            string numeroIngresado = textBox_NumeroLegajo.TextValue;

            // Verificar si el legajo ya existe en el panel antes de agregar un nuevo control
            if (EsLegajoYaAgregado(numeroIngresado))
            {
                MensajeGeneral.Mostrar("El personal seleccionado ya ha sido ingresado para su ratificación testimonial.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                // Si no se encuentra el legajo, llama a AgregarPersonalSeleccionado
                AgregarPersonalSeleccionado(); //verifica si existe en base de datos  y lo agrega 
            }
        }


        /// <summary>
        ///  Método auxiliar para buscar si el legajo ya está agregado en los controles existentes
        /// </summary>
        /// <param name="numeroLegajo"></param>
        /// <returns></returns>

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


        /// <summary>
        ///  Método para agregar un nuevo control de personal seleccionado al panel
        /// </summary>
        private void AgregarPersonalSeleccionado()
        {
            try
            {
                PersonalManager personalManager = new();
                string textoFormateado = textBox_NumeroLegajo.TextValue;

                // Verificar si el número de legajo existe en la base de datos
                if (!personalManager.ExisteLegajo(textoFormateado))
                {
                    MensajeGeneral.Mostrar("El número de legajo ingresado no corresponde a un efectivo policial registrado", MensajeGeneral.TipoMensaje.Advertencia);
                    return; // Termina la ejecución si el legajo no existe
                }

                // Crear y configurar el nuevo control de personal seleccionado
                PersonalSeleccionadoControl nuevoControl = new();
                nuevoControl.ModificarPersonalClicked += PersonalSeleccionadoControl_ModificarPersonalClicked;
                nuevoControl.ActualizarDatosPorLegajo(textoFormateado);

                // Agregar el nuevo control al panel
                AgregarPersonal agregarPersonal = new();
                agregarPersonal.AgregarControlAlPanel(
                    nuevoControl,
                    panel_PersonalSeleccionado,
                    panel_PersonalSeleccionado,
                    panel_ControlesInferiores,
                    panel1,
                    this
                );
                ActualizarContadorRatificaciones();
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al conectar con la base de datos: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                // Limpiar el contenido del TextBox independientemente del resultado
                textBox_NumeroLegajo.TextValue = string.Empty;
                textBox_NumeroLegajo.Focus();
                ActualizarContadorRatificaciones();
            }
        }


        /// <summary>
        /// METODO PARA ACTUALIZAR CONTADOR DE RATIFICACIONES EN FORM INCIO CIERRE
        /// </summary>
        private void ActualizarContadorRatificaciones()
        {
            // Contar los controles en el panel
            int numeroControles = panel_PersonalSeleccionado.Controls.OfType<PersonalSeleccionadoControl>().Count();

            // Obtener el formulario inicio_cierre si está abierto
            Form inicioCierre = Application.OpenForms["InicioCierre"];
            if (inicioCierre != null && inicioCierre is InicioCierre formInicioCierre)
            {
                // Acceder a la propiedad pública que devuelve la instancia de Boton_Contador
                Boton_Contador btnContadorControl = formInicioCierre.BtnContadorRatificaciones;

                if (btnContadorControl != null)
                {
                    // Actualizar el texto del botón usando la propiedad Text
                    btnContadorControl.Text = numeroControles.ToString();

                    // Llamar al método para actualizar el color del botón
                     btnContadorControl.ActualizarTamañoYColor();
                }
            }
        }


        private void AgregarControlPersonalSeleccionado(PersonalSeleccionadoControl control)
        {
            // Agregar el control al panel
            panel_PersonalSeleccionado.Controls.Add(control);

            // Suscribir el evento Eliminado
            control.Eliminado += (s, e) => ActualizarContadorRatificaciones();

            // Actualizar el contador después de agregar el control
            ActualizarContadorRatificaciones();
        }

        
    }

}