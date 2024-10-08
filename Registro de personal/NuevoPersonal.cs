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
using Interfaces_Libreria.Interfaces;
using Controles.Controles;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class NuevoPersonal : BaseForm ,IFormulario
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

            InicializarComboBoxDEPENDENCIAS();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON

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
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void InicializarComboBoxDEPENDENCIAS()
        {
            List<DependenciasPoliciales> dependencias = DependenciaManager.ObtenerDependencias();
            comboBox_Dependencia.DataSource = dependencias;
            comboBox_Dependencia.DisplayMember = "Dependencia";
            comboBox_Dependencia.SelectedIndex = -1;
        }
    }
}
