using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using Clases.Botones;
using Clases.Texto;
using Controles.Controles.Aplicadas_con_controles;
using MySql.Data.MySqlClient;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Mensajes;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static Ofelia_Sara.Controles.Controles.CustomDate;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class NuevoPersonal : BaseForm
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public NuevoPersonal(string numeroLegajo)
        {
            InitializeComponent();
            // Asigna el valor recibido al TextBox correspondiente en NuevoPersonal
            textBox_NumeroLegajo.Text = numeroLegajo;

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            configurarTextoEnControles();//para formato de texto que ingresa

            this.Load += new System.EventHandler(this.NuevoPersonal_Load);

            CargarDatosDependencia(comboBox_Dependencia, dbManager);//para cargar desde base de datos

            this.FormClosing += NuevoPersonal_FormClosing;
        }


        public NuevoPersonal()
        {
            InitializeComponent();
         
        }




        private void NuevoPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Limpiar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
            //---Inicializar para desactivar los btn AGREGAR PERSONAL RATIFICACION 
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);


            //para que se despliege la lista en los comboBox ESCALAFON -JERARQUIA
            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad
                                                                                   // Asegura la asociación del método MostrarAntiguedad al evento OnCalcularAntiguedad
            dateTimePicker_Antiguedad.OnCalcularAntiguedad = MostrarAntiguedad;

            comboBox_EstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;//descctivar ingreso de datos en estado civil

            numeroTelefonicoControl1.ControlWidth = 159;
            numeroTelefonicoControl2.ControlWidth = 159;
            this.Shown += Focus_Shown;//para que haga foco en un textBox

        
        }
        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox
            textBox_NumeroLegajo.Focus();
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(ComboBox comboBox)
        {
            comboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }
        //--------------------------------------------------------------------------



        private void NuevoPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MensajeGeneral.Mostrar("Debe completar la totalidad de los campos requeridos." + "Todos ellos serán empleados para completar plantilla de Ratificación policial", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;
            comboBox_Escalafon.SelectedIndex = -1;
            comboBox_Jerarquia.SelectedIndex = -1;
            // Muestra un mensaje de información
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }

        private void textBox_NumeroLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            ClaseNumeros.AplicarFormatoYLimite(textBox_NumeroLegajo, 7);
        }

        private void configurarTextoEnControles()
        {
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_Apellido);
            MayusculaSola.AplicarAControl(textBox_LugarNacimiento);
            MayusculaSola.AplicarAControl(textBox_LocalidadPnal);
            MayusculaSola.AplicarAControl(textBox_PartidoPnal);
            MayusculaSola.AplicarAControl(textBox_Funcion);
            MayusculaSola.AplicarAControl(textBox_LocalidadDependencia);
            MayusculaSola.AplicarAControl(textBox_PartidoDependencia);

            MayusculaSola.AplicarAControl(comboBox_Nacionalidad);

            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            MayusculaYnumeros.AplicarAControl(textBox_DomicilioPnal);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaMarca);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaModelo);
            MayusculaYnumeros.AplicarAControl(textBox_ArmaNumero);

            MayusculaYnumeros.AplicarAControl(textBox_ChalecoMarca);
            MayusculaYnumeros.AplicarAControl(textBox_ChalecoModelo);
            MayusculaYnumeros.AplicarAControl(textBox_ChalecoNumero);
            MayusculaYnumeros.AplicarAControl(textBox_DomicilioDependencia);


            ClaseNumeros.AplicarFormatoYLimite(textBox_Dni, 10);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Edad, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_AntiguedadAños, 2);
            ClaseNumeros.AplicarFormatoYLimite(textBox_AntiguedadMeses, 2);
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }

        private void textBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }
        }
        private void ComboBox_Dependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica para cargar datos
            CargarDatosDependencia();
        }

        private void ComboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el texto del ComboBox está vacío
            if (string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
            {
                LimpiarTextBoxes(); // Limpia los TextBox si no hay texto
            }
        }

        private void CargarDatosDependencia()
        {

            if (comboBox_Dependencia.SelectedItem != null)
            {
                // Obtiene el valor seleccionado y extrae el nombre de la dependencia
                string seleccion = comboBox_Dependencia.SelectedItem.ToString();
                string dependenciaSeleccionada = seleccion.Split(' ')[0].Trim(); // Obtiene solo el nombre y elimina espacios

                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                try
                {
                    using (var conexion = new MySqlConnection(connectionString))
                    {
                        conexion.Open();
                        string consulta = "SELECT Direccion, Localidad, Partido FROM Comisarias WHERE Nombre = @nombreDependencia";

                        using (var comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@nombreDependencia", dependenciaSeleccionada);

                            using (var lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    textBox_DomicilioDependencia.Text = lector["Direccion"].ToString();
                                    textBox_LocalidadDependencia.Text = lector["Localidad"].ToString();
                                    textBox_PartidoDependencia.Text = lector["Partido"].ToString();

                                    // Establecer los TextBox como no editables
                                    textBox_DomicilioDependencia.ReadOnly = true;
                                    textBox_LocalidadDependencia.ReadOnly = true;
                                    textBox_PartidoDependencia.ReadOnly = true;
                                }
                                else
                                {
                                    MensajeGeneral.Mostrar("No se encontraron datos para la dependencia seleccionada.", MensajeGeneral.TipoMensaje.Advertencia);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar("Error al cargar los datos de la dependencia: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
            else
            {
                // Limpia los TextBox si no hay selección válida y los habilita para edición
                LimpiarTextBoxes();
            }
        }

        private void LimpiarTextBoxes()
        {
            textBox_DomicilioDependencia.Clear();
            textBox_LocalidadDependencia.Clear();
            textBox_PartidoDependencia.Clear();

            // También puedes habilitar los TextBox si es necesario
            textBox_DomicilioDependencia.ReadOnly = false;
            textBox_LocalidadDependencia.ReadOnly = false;
            textBox_PartidoDependencia.ReadOnly = false;
        }

        private void textBox_DatosDependencia_Enter(object sender, EventArgs e)
        {
            if (textBox_DomicilioDependencia.ReadOnly) // se dejo con ese textBox ya que no es necesario especificar uno por uno
            {
                MensajeGeneral.Mostrar("Para modificar este elemento debe hacerlo desde el botón Configuracion, en el menu principal.", MensajeGeneral.TipoMensaje.Informacion);
                comboBox_Dependencia.Focus(); // Vuelve a enfocar el control
            }
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear el objeto Personal con los datos del formulario
                Personal personal = new Personal
                {
                    // Si el DNI está vacío, asignamos un valor predeterminado o lo dejamos como null
                    DNI = string.IsNullOrEmpty(textBox_Dni.Text) ? null : textBox_Dni.Text,

                    // Si el Domicilio está vacío, asignamos un valor predeterminado o lo dejamos como null
                    Domicilio = string.IsNullOrEmpty(textBox_DomicilioPnal.Text) ? null : textBox_DomicilioPnal.Text,

                    // Verificamos si el comboBox tiene una selección válida
                    Nacionalidad = comboBox_Nacionalidad.SelectedItem != null ? comboBox_Nacionalidad.SelectedItem.ToString() : null,
                    Escalafon = comboBox_Escalafon.SelectedItem != null ? comboBox_Escalafon.SelectedItem.ToString() : null,
                    Jerarquia = comboBox_Jerarquia.SelectedItem != null ? comboBox_Jerarquia.SelectedItem.ToString() : null,

                    // Si la función está vacía, asignamos un valor predeterminado o lo dejamos como null
                    Funcion = string.IsNullOrEmpty(textBox_Funcion.Text) ? null : textBox_Funcion.Text,
                };

                // Llamar al método UpdatePersonal para actualizar los datos en la base de datos
                PersonalManager personalManager = new PersonalManager();
                personalManager.UpdatePersonal(personal);

                // Mostrar mensaje de éxito
                MensajeGeneral.Mostrar("Datos actualizados correctamente.", MensajeGeneral.TipoMensaje.Exito);
                datosGuardados = true; // Marcar que los datos fueron guardados
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre alguna excepción
                MensajeGeneral.Mostrar("Error al actualizar los datos: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                datosGuardados = false; // Marcar que los datos no fueron guardados
            }
        }



        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void NuevoPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
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
                try
                {
                    // Crear una instancia de PersonalManager para interactuar con la base de datos
                    PersonalManager personalManager = new PersonalManager();

                    // Verificar si el número de legajo existe en la base de datos
                    if (!personalManager.ExisteLegajo(textoFormateado))
                    {
                        MensajeGeneral.Mostrar("El número de legajo ingresado no corresponde a un efectivo policial registrado", MensajeGeneral.TipoMensaje.Advertencia);
                        textBox_NumeroLegajo.Focus();
                    }
                    else
                    {
                        // Obtener el DTO del personal por legajo
                        PersonalDTO personalDTO = personalManager.ObtenerPersonalDTOPorLegajo(textoFormateado);

                        // Verificar si se obtuvo el DTO correctamente
                        if (personalDTO != null)
                        { // Asignar los valores del DTO a los controles del formulario
                            textBox_Dni.Text = personalDTO.DNI ?? "00.000.000";
                            textBox_Nombre.Text = personalDTO.Nombres;
                            textBox_Apellido.Text = personalDTO.Apellido;


                            textBox_DomicilioPnal.Text = personalDTO.Domicilio ?? "NO ESPECIFICADO";
                            textBox_LocalidadPnal.Text = personalDTO.Localidad ?? "NO ESPECIFICADO";
                            textBox_PartidoPnal.Text = personalDTO.Partido ?? "NO ESPECIFICADO";
                            comboBox_Nacionalidad.SelectedItem = personalDTO.Nacionalidad ?? "NO ESPECIFICADO";
                            if (comboBox_Nacionalidad.SelectedItem == null && comboBox_Nacionalidad.Items.Count > 0)
                                comboBox_Nacionalidad.SelectedIndex = 0;  // O establecer un valor específico
                                                                         
                            comboBox_Escalafon.SelectedItem = personalDTO.Escalafon;
                            if (comboBox_Escalafon.SelectedItem == null && comboBox_Escalafon.Items.Count > 0)
                                comboBox_Escalafon.SelectedIndex = 0;

                            comboBox_Jerarquia.SelectedItem = personalDTO.Jerarquia;
                            if (comboBox_Jerarquia.SelectedItem == null && comboBox_Jerarquia.Items.Count > 0)
                                comboBox_Jerarquia.SelectedIndex = 0;

                            textBox_Funcion.Text = personalDTO.Funcion;
                            comboBox_Dependencia.SelectedItem = personalDTO.Dependencia?? "NO ESPECIFICADO";
                            if (comboBox_Dependencia.SelectedItem == null && comboBox_Dependencia.Items.Count > 0)
                                comboBox_Dependencia.SelectedIndex = 0;

                            textBox_LocalidadDependencia.Text = personalDTO.LocalidadDependencia;
                            textBox_DomicilioDependencia.Text = personalDTO.Domicilio_Dependencia ?? "NO ESPECIFICADO";
                            textBox_PartidoDependencia.Text = personalDTO.Partido_Dependencia ?? "NO ESPECIFICADO";
                           

                        }
                        else
                        {
                            MensajeGeneral.Mostrar("No se encontraron datos para el número de legajo proporcionado.", MensajeGeneral.TipoMensaje.Advertencia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar("Error al conectar con la base de datos: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }
        //----------------CALCULAR ANTIGUEDAD----------------
        public void MostrarAntiguedad(int años, int meses)
        {
            textBox_AntiguedadAños.Text = años.ToString();
            textBox_AntiguedadMeses.Text = meses.ToString();
        }

    }
}
