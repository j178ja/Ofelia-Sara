using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General.Controles.Aplicadas_con_controles;
using Ofelia_Sara.general.clases.Apariencia_General.Texto;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales
{
    public partial class AgregarDatosPersonalesConcubina : BaseForm
    {
        public AgregarDatosPersonalesConcubina()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }

        private void AgregarDatosPersonalesConcubina_Load(object sender, EventArgs e)
        {
            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad

            MayusculaSola.AplicarAControl(comboBox_Parentesco);
            MayusculaSola.AplicarAControl(textBox_Nombre);
            MayusculaSola.AplicarAControl(textBox_LugarNacimiento);
            MayusculaSola.AplicarAControl(comboBox_Nacionalidad);
            MayusculaSola.AplicarAControl(textBox_Ocupacion);
            MayusculaSola.AplicarAControl(textBox_Apodo);
            MayusculaSola.AplicarAControl(textBox_Localidad);
            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Dni, 10);
            ClaseNumeros.AplicarFormatoYLimite(textBox_Edad, 2);

            btn_AgregarConcubina.Enabled = false;
            InicializarEstiloBotonAgregar(btn_AgregarConcubina);// estilo boton

            comboBox_EstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;//deshabilita ingreso de datos del usuario en comboBox estado civil
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
        //--------------------------------------------------------------------

    }
}
