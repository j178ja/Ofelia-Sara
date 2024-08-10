using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.general.clases.Apariencia_General.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
   
    public partial class NuevaPersonaControl : UserControl
    {
        // Propiedad para determinar el tipo de persona
        public string TipoPersona
        {
            get => label_Persona.Text.Contains("Víctima") ? "Victima" : "Imputado";
            set
            {
                if (value == "Victima")
                {
                    label_Persona.Text = "Víctima n°";
                }
                else if (value == "Imputado")
                {
                    label_Persona.Text = "Imputado n°";
                }
                else
                {
                    label_Persona.Text = "Persona";
                }
            }
        }

        public NuevaPersonaControl()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            // Configurar el botón de eliminar
            btn_EliminarControl.Click += Btn_EliminarControl_Click;

            // Configurar el botón de agregar datos
            btn_AgregarDatosPersona.Click += Btn_AgregarDatosPersona_Click;

            // Configurar el TextBox para convertir texto a mayúsculas
            textBox_Persona.TextChanged += TextBox_Persona_TextChanged;
        }

        private void TextBox_Persona_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto a mayúsculas y eliminar caracteres especiales
            textBox_Persona.Text = LimpiarTexto(textBox_Persona.Text);
            textBox_Persona.SelectionStart = textBox_Persona.Text.Length; // Mantener el cursor al final del texto
        }

        private string LimpiarTexto(string texto)
        {
            // Convertir a mayúsculas
            texto = texto.ToUpper();

            // Eliminar caracteres especiales y mantener solo letras y espacios
            var caracteresValidos = texto.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c));
            return new string(caracteresValidos.ToArray());
        }

        private void Btn_EliminarControl_Click(object sender, EventArgs e)
        {
            // Obtener la referencia al panel que contiene este control
            Panel panel = this.Parent as Panel;

            if (panel != null)
            {
                // Obtener la posición Y del control a eliminar
                int posicionY = this.Location.Y;

                // Remover el control actual del panel
                panel.Controls.Remove(this);

                // Reposicionar los controles que están por debajo del control eliminado
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl.Location.Y > posicionY)
                    {
                        ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y - this.Height - 9);
                    }
                }

                // Reajustar la altura del panel
                AjustarAlturaPanel(panel);
               
            }
        }

        private void Btn_AgregarDatosPersona_Click(object sender, EventArgs e)
        {
            Form formulario = null;

            if (TipoPersona == "Victima")
            {
                formulario = new AgregarDatosPersonalesVictima();
            }
            else if (TipoPersona == "Imputado")
            {
                formulario = new AgregarDatosPersonalesImputado();
            }

            if (formulario != null)
            {
                formulario.ShowDialog(); // Mostrar el formulario como cuadro de diálogo
            }
        }

        private void AjustarAlturaPanel(Panel panel)
        {
            // Calcular la altura necesaria del panel basada en todos los controles visibles
            int nuevaAltura = 0;

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl.Visible)
                {
                    int posicionYConAltura = ctrl.Top + ctrl.Height;
                    if (posicionYConAltura > nuevaAltura)
                    {
                        nuevaAltura = posicionYConAltura;
                    }
                }
            }

            // Añadir un margen para evitar que el panel esté justo en el borde
            nuevaAltura += 6; // Ajustar según el margen deseado

            // Establecer la nueva altura del panel
            panel.Height = nuevaAltura;
        }
    }









    // Clase auxiliar para manejar la inserción
    public static class NuevaPersonaControlInserter
    {
        public static void InsertarNuevaPersonaControl(Panel panel, string tipoPersona)
        {
            // Calcular la nueva posición Y basada en la cantidad de controles existentes en el panel
            int nuevaPosicionY = CalcularPosicionY(panel);

            // Crear una instancia del control NuevaPersonaControl
            NuevaPersonaControl nuevaPersonaControl = new NuevaPersonaControl
            {
                TipoPersona = tipoPersona,
                Location = new Point(0, nuevaPosicionY) // X = 0 (alineado a la izquierda del panel), Y = calculada
            };

            // Insertar el control en el panel
            panel.Controls.Add(nuevaPersonaControl);

            // Ajustar la altura del panel para acomodar el nuevo espacio
            panel.Height += nuevaPersonaControl.Height + 9;
        }

        private static int CalcularPosicionY(Panel panel)
        {
            int posicionY = 10; // Posición inicial
            int alturaControl = 20; // Altura de cada NuevaPersonaControl
            int espacioEntreControles = 9; // Espacio entre cada control

            // Recorrer todos los controles en el panel para calcular la posición Y
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is NuevaPersonaControl)
                {
                    // Ajustar posicionY sumando la altura del control más el espacio entre controles
                    posicionY = ctrl.Location.Y + alturaControl + espacioEntreControles;
                   
                }
            }

            return posicionY;
        }

    }


}

