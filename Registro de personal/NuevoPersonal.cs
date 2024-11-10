using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using Clases.Botones;
using Clases.Texto;
using Controles.Controles.Aplicadas_con_controles;
using MySql.Data.MySqlClient;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Mensajes;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

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
        }


        public NuevoPersonal()
        {
            InitializeComponent();
            this.FormClosing += NuevoPersonal_FormClosing;
        }


        // Implementación del método de la interfaz IFormulario
        public void Inicializar()
        {
            // para logica de interfaz IFormulario
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



            comboBox_EstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;//descctivar ingreso de datos en estado civil

            numeroTelefonicoControl1.ControlWidth = 159;
            numeroTelefonicoControl2.ControlWidth = 159;
            this.Shown += Focus_Shown;//para que haga foco en un textBox

        }
        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
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
            datosGuardados = true; // Marcar que los datos fueron guardados
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
                        {
                            // Asignar los valores del DTO a los controles del formulario
                            textBox_DomicilioPnal.Text = personalDTO.Domicilio;
                            comboBox_Nacionalidad.SelectedItem = personalDTO.Nacionalidad; // Asignar el valor al ComboBox
                            comboBox_Escalafon.SelectedItem = personalDTO.Escalafon;       // Asignar el valor al ComboBox
                            comboBox_Jerarquia.SelectedItem = personalDTO.Jerarquia;       // Asignar el valor al ComboBox
                            textBox_Funcion.Text = personalDTO.Funcion;                     // Asignar el valor al TextBox
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

    }
}
