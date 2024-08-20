using Ofelia_Sara.Base_de_Datos;
using Ofelia_Sara.general.clases.Apariencia_General;
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

namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    public partial class NuevoInstructor : BaseForm
    {
        public NuevoInstructor()
        {
            InitializeComponent();

            this.Load += new EventHandler(NuevoInstructor_Load);// inicializar Load


            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

        }
        //---PARA GENERAR LISTA EN COMBOBOX---------
        private void LlenarComboBoxEscalafon()
        {
            comboBox_Escalafon.Items.Clear();
            comboBox_Escalafon.Items.AddRange(JerarquiasManager.ObtenerEscalafones().ToArray());
        }

        private void comboBox_Escalafon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string escalafonSeleccionado = comboBox_Escalafon.SelectedItem.ToString();

            var jerarquias = JerarquiasManager.ObtenerJerarquias(escalafonSeleccionado);

            if (jerarquias.Count > 0)
            {
                comboBox_Jerarquia.Items.Clear();
                comboBox_Jerarquia.Items.AddRange(jerarquias.ToArray());
                comboBox_Jerarquia.Enabled = true; // Habilita el ComboBox de Jerarquías si estaba deshabilitado
            }
            else
            {
                comboBox_Jerarquia.Items.Clear();
                comboBox_Jerarquia.Enabled = false; // Deshabilita el ComboBox de Jerarquías si no hay datos
            }
        }

        //-------------------------------------------

        private void NuevoInstructor_Load(object sender, EventArgs e)
        {
            // Configurar todos los TextBoxes en el formulario
            ConfigurarTextBoxes(this);
            InicializarPictureBox();//para inicializar estilo pickturebox

            LlenarComboBoxEscalafon();
            comboBox_Jerarquia.Enabled = false; // Deshabilitar al principio hasta que se seleccione un escalafón
        }
        //---------------------BOTON LIMPIAR------------------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //---------BOTON GUARDAR---------------------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if
              (string.IsNullOrWhiteSpace(comboBox_Jerarquia.Text) ||
               string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
               string.IsNullOrWhiteSpace(textBox_Apellido.Text))
            {
                MessageBox.Show("Debe completar los campos JERARQUIA, NOMBRE y APELLIDO.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Se ha cargado nuevo Instructor a lista de Instructores en los formularios.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //----------------------------------------------------------------------------
        //-------------------CONTROLAR QUE SEAN MAYUSCULAS------------------
        private void ConfigurarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += (s, e) =>
                    {
                        TextBox tb = s as TextBox;
                        if (tb != null)
                        {
                            int pos = tb.SelectionStart;
                            tb.Text = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(tb.Text);
                            tb.SelectionStart = pos;
                        }
                    };
                }
                else if (control.HasChildren)
                {
                    ConfigurarTextBoxes(control);
                }
            }
        }

        private void NuevoInstructor_HelpButtonClicked(object sender, CancelEventArgs e)
        {
                // Mostrar un mensaje de ayuda
                MessageBox.Show("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable de instructor" , "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        //---------------------------------------------------------------------------------
        //-----EVENTOS PARA HABILITAR Y MODIFICAR PICKTUREBOX------------------------------
        private void InicializarPictureBox()
        {
            // Inicializa el PictureBox con un borde rojo y deshabilitado
            pictureBox_FirmaDigitalizada.Tag = Color.Tomato;
            pictureBox_FirmaDigitalizada.Enabled = false;
            pictureBox_FirmaDigitalizada.BackColor = Color.DarkGray;
            pictureBox_FirmaDigitalizada.Invalidate(); // Redibuja el borde
        }
        private void checkBox_AgregarFirma_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    pictureBox_FirmaDigitalizada.Enabled = true;
                    pictureBox_FirmaDigitalizada.Tag = Color.LimeGreen; // Color del borde cuando está habilitado
                    pictureBox_FirmaDigitalizada.BackColor = SystemColors.ControlLight;
                }
                else
                {
                    pictureBox_FirmaDigitalizada.Enabled = false;
                    pictureBox_FirmaDigitalizada.Tag = Color.Tomato; // Color del borde cuando está deshabilitado
                    pictureBox_FirmaDigitalizada.BackColor = Color.DarkGray;
                }

                pictureBox_FirmaDigitalizada.Invalidate(); // Redibuja el borde
            }
        }

        private void PictureBox_FirmaDigitalizada_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                Color borderColor = pictureBox.Tag is Color ? (Color)pictureBox.Tag : Color.Transparent;

                using (Pen pen = new Pen(borderColor, 3)) // Grosor del borde
                {
                    // Dibuja el borde exterior
                    e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
                }
            }
        }

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
                // Inserta el carácter en la posición actual
                TextBox textBox = sender as TextBox;
                int selectionStart = textBox.SelectionStart;
                textBox.Text = textBox.Text.Insert(selectionStart, e.KeyChar.ToString());
                e.Handled = true;

                // Usar la clase separada para formatear el texto
                string textoFormateado = ClaseNumeros.FormatearNumeroConPuntos(textBox.Text);

                // Actualizar el texto en el TextBox y restaurar la posición del cursor
                textBox.Text = textoFormateado;
                textBox.SelectionStart = textoFormateado.Length;


            }
        }
    }
}
