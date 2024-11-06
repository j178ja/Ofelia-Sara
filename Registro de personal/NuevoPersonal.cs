using BaseDatos;
using Ofelia_Sara.general.clases;
using Controles.Controles.Aplicadas_con_controles;
using Clases.Texto;
using Clases.Botones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios;
using BaseDatos.Entidades;

using Controles.Controles;
using MySql.Data.MySqlClient;
using System.Configuration;
using Ofelia_Sara.Mensajes;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class NuevoPersonal : BaseForm
    {

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
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Debe completar la totalidad de los campos requeridos." + "Todos ellos serán empleados para completar plantilla de Ratificación policial", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Limpia el formulario
            LimpiarFormulario.Limpiar(this);
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;
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
                                    MessageBox.Show("No se encontraron datos para la dependencia seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de la dependencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Para modificar este elemento debe hacerlo desde el botón Configuracion, en el menu principal.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox_Dependencia.Focus(); // Vuelve a enfocar el control
            }
        }

    }
}
