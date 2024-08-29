using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General.Controles;
using Ofelia_Sara.general.clases.Apariencia_General.Generales;
using Ofelia_Sara.general.clases.Apariencia_General.Texto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class BuscarPersonal : BaseForm
    {
        public BuscarPersonal()
        {
            InitializeComponent();

            //Color customBorderColor = Color.FromArgb(0, 154, 174);
            //panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }

        private void BuscarPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Registrar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);

            textBox_NumeroLegajo.MaxLength = 7;
            this.Shown += Focus_Shown;//para que haga foco en un textBox
        }
        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_NumeroLegajo.Focus();
        }
        //________________________________________________________________________________
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
                MessageBox.Show("El número no correspone a un número de legajo valido, verifique que el número sea correcto.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Crear una nueva instancia del control PersonaSeleccionadaControl
                PersonalSeleccionadoControl nuevoControl = new PersonalSeleccionadoControl();

                //posicionar el nuevo control
                int nuevaPosicionY = ObtenerPosicionSiguienteControl(panel_PersonalSeleccionado);
                nuevoControl.Location = new Point(0, nuevaPosicionY);

                // Añadir el nuevo control al panel_PersonalSeleccionado
                panel_PersonalSeleccionado.Controls.Add(nuevoControl);

                // Ajustar la altura del panel si es necesario
                AjustarAlturaPanel(panel_PersonalSeleccionado);

                // Limpiar el contenido del TextBox
                textBox_NumeroLegajo.Text = string.Empty;
            }
        }
        private int ObtenerPosicionSiguienteControl(Panel panel)
        {
            if (panel.Controls.Count == 0)
            {
                return 0; // Si no hay controles, coloca el nuevo control en la posición inicial
            }

            // Obtener la posición Y del último control en el panel
            Control ultimoControl = panel.Controls[panel.Controls.Count - 1];
            return ultimoControl.Bottom + 20; // Espacio entre controles
        }

        private void AjustarAlturaPanel(Panel panel)
        {
            if (panel.Controls.Count == 0) return;

            // Ajustar la altura del panel según el último control agregado
            Control ultimoControl = panel.Controls[panel.Controls.Count - 1];
            panel.Height = ultimoControl.Bottom + 1; // Ajusta el espacio inferior según sea necesario
        }

        private void BuscarPersonal_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Ingrese un número de legajo policial válido para caragar nueva ratificacion testimonial", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
    }
 }

