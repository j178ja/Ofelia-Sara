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
    public partial class NuevaCaratulaControl : UserControl
    {
        public NuevaCaratulaControl()
        {
            InitializeComponent();
        }

        private void TextBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto a mayúsculas y eliminar caracteres especiales
            textBox_Caratula.Text = LimpiarTexto(textBox_Caratula.Text);
            textBox_Caratula.SelectionStart = textBox_Caratula.Text.Length; // Mantener el cursor al final del texto
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
}
