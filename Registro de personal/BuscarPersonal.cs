using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General.Controles;
using Ofelia_Sara.general.clases.Apariencia_General.Generales;
using Ofelia_Sara.general.clases.Apariencia_General.Texto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                MessageBox.Show("El número no correspone a un número de legajo valido, verifique que el número sea correcto.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Crear una nueva instancia del control PersonaSeleccionadaControl
                PersonalSeleccionadoControl nuevoControl = new PersonalSeleccionadoControl();

                // Llamar al método para agregar el control al panel
                AgregarControlAlPanel(nuevoControl, panel_PersonalSeleccionado);

                // Limpiar el contenido del TextBox
                textBox_NumeroLegajo.Text = string.Empty;
            }
        }
        //---------------------------------------------------------------------------------------------------
        private const int MaxControlesVisibles = 7;
        private Color colorPar = Color.FromArgb(230, 230, 230); // Gris claro
        private Color colorImpar = Color.FromArgb(200, 200, 200); // Gris medio
        private const int MaxHeight = 750; // Altura máxima para el formulario

        private void AgregarControlAlPanel(Control nuevoControl, Panel panel)
        {
            // Configurar el control para que se ajuste al ancho del panel
            nuevoControl.Width = panel.ClientSize.Width - 20; // Ajusta el ancho del control al ancho del panel menos un margen

            // Si el panel tiene controles, colocar el nuevo control debajo del último control existente.
            if (panel.Controls.Count > 0)
            {
                Control ultimoControl = panel.Controls[panel.Controls.Count - 1];
                nuevoControl.Top = ultimoControl.Bottom; // Sin espacio adicional entre controles
            }
            else
            {
                nuevoControl.Top = 0; // Si no hay controles, el control se coloca en la parte superior.
            }

            // Determinar si el número de controles es par o impar
            if (panel.Controls.Count % 2 == 0) // Número par
            {
                nuevoControl.BackColor = colorPar;
            }
            else // Número impar
            {
                nuevoControl.BackColor = colorImpar;
            }

            // Agregar el nuevo control al panel
            panel.Controls.Add(nuevoControl);

            // Ajustar el tamaño del panel para permitir el scroll vertical si es necesario
            if (panel.Controls.Count > MaxControlesVisibles)
            {
                panel.AutoScroll = true; // Habilitar el scroll vertical
                int visibleHeight = nuevoControl.Bottom;
                panel.Height = visibleHeight > MaxHeight ? MaxHeight : visibleHeight;
            }
            else
            {
                panel.AutoScroll = false;
                panel.Height = nuevoControl.Bottom + 1;
            }

            // Asegúrate de que el formulario y los paneles se ajusten adecuadamente
            AjustarFormulario(panel);
        }

        private void AjustarFormulario(Panel panel)
        {
            // Obtener la altura total del panel actual
            int alturaPanel = panel.Bottom + panel1.Top + panel1.Margin.Bottom;

            // Asegurarse de que el panel_ControlesInferiores esté al final del formulario
            panel_ControlesInferiores.Top = panel.Bottom + 5; // Espacio entre el panel de controles y el final del panel
            panel_ControlesInferiores.Width = panel.Width;
            panel_ControlesInferiores.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Ajustar el tamaño del formulario para no exceder el tamaño máximo
            if (panel.Height > MaxHeight)
            {
                this.Height = MaxHeight;
            }
            else
            {
                this.Height = panel.Bottom + panel_ControlesInferiores.Height + 40; // Espacio adicional para el panel de controles
            }
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

