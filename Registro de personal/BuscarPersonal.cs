
using Clases_Libreria.Texto;
using Clases_Libreria.Reposicion_paneles.Buscar_Personal;
using Clases_Libreria.Apariencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios;
using Controles_Libreria.Controles;

namespace Ofelia_Sara.Registro_de_personal
{
    public partial class BuscarPersonal : BaseForm
    {
        private int borderRadius = 15;
        private int borderSize = 7;
        private Color borderColor = Color.FromArgb(0, 154, 174); // Color del borde
        private Color panelColor = Color.FromArgb(178, 213, 230); // Color de fondo del panel


        public BuscarPersonal()
        {
            InitializeComponent();

        }

        private void BuscarPersonal_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Registrar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarPersonal);
            //---Inicializar para desactivar los btn AGREGAR PERSONAL RATIFICACION 
            btn_AgregarPersonal.Enabled = !string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text);

            textBox_NumeroLegajo.MaxLength = 7;
            this.Shown += Focus_Shown;//para que haga foco en un textBox

            this.BackColor = Color.FromArgb(0, 154, 174); // Color de fondo del formulario

           // Configurar el panel
            panel1.BackColor = panelColor; // Color de fondo del panel
            panel1.Paint += panel1_Paint;
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
                MessageBox.Show("El número no corresponde a un número de legajo válido, verifique que el número sea correcto.",
                                "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Crear una nueva instancia del control PersonalSeleccionadoControl
                PersonalSeleccionadoControl nuevoControl = new PersonalSeleccionadoControl();

                // Suscribirse al evento que abrirá el formulario NuevoPersonal
                nuevoControl.ModificarPersonalClicked += PersonalSeleccionadoControl_ModificarPersonalClicked;

                // Instanciar la clase AgregarPersonal
                AgregarPersonal agregarPersonal = new AgregarPersonal();

                // Llamar al método para agregar el control al panel
                agregarPersonal.AgregarControlAlPanel(
                    nuevoControl,                 // El control nuevo a agregar
                    panel_PersonalSeleccionado,   // Panel donde se agregará el control
                    panel_PersonalSeleccionado,   // Panel que se debe ajustar (mismo panel, en este caso)
                    panel_ControlesInferiores,    // Panel inferior a reposicionar
                    panel1,                       // Panel principal
                    this                          // El formulario actual
                );

                // Limpiar el contenido del TextBox
                textBox_NumeroLegajo.Text = string.Empty;
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
            MessageBox.Show("Ingrese un número de legajo policial válido para caragar nueva ratificacion testimonial", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
    }
 }

