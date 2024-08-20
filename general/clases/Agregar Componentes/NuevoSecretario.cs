using Ofelia_Sara.general.clases.Apariencia_General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SkiaSharp;//biblioteca para efecto visual
using System.Drawing.Imaging;
using Ofelia_Sara.general.clases.Apariencia_General.Texto;
//using Ofelia_Sara.Base_de_Datos;
using System.IO;
using Ofelia_Sara.Base_de_Datos;


namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    public partial class NuevoSecretario : BaseForm
    {
        public NuevoSecretario()
        {
            InitializeComponent();
            this.Load += new EventHandler(NuevoSecretario_Load);// inicializar Load

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

          
        }

        private void NuevoSecretario_Load(object sender, EventArgs e)
        {
            // Configurar todos los TextBoxes en el formulario
            ConfigurarTextBoxes(this);
            InicializarPictureBox();//para agregar estetica de picktureBox cuando carga formulario


            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(ComboBox comboBox)
        {
            comboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }

        //-----------BOTON LIMPIAR---------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //______________________________________________________________________________
       
//----------------------------------------------------------------------------------
        private void GuardarDatosSecretario()
        {
            // Obtener los datos del formulario
            string jerarquia = comboBox_Jerarquia.Text;
            string nombre = textBox_Nombre.Text;
            string apellido = textBox_Apellido.Text;
            double legajo = Convert.ToDouble(textBox_NumeroLegajo.Text);
            string funcion = textBox_Funcion.Text;

            // Convertir la imagen en el PictureBox a un array de bytes
            byte[] firmaDigitalizada = null;
            if (pictureBox_FirmaDigitalizada.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox_FirmaDigitalizada.Image.Save(ms, pictureBox_FirmaDigitalizada.Image.RawFormat);
                    firmaDigitalizada = ms.ToArray();
                }
            }

            // Llamar al método GuardarSecretario para la tabla Secretario
            //dataInserter.GuardarSecretario(jerarquia, nombre, apellido, legajo, funcion, firmaDigitalizada);
        }


        //-------------BOTON GUARDAR--------------------
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
               // GuardarDatosSecretario();
                MessageBox.Show("Se ha cargado nuevo Secretario a lista de Secretarios en los formularios", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        //-------------MENSAJE DE AYUDA BOTON HELP---------
        private void NuevoSecretario_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Debe ingresar los datos conforme se solicitan. Será incorporado a la lista de secretarios en los formularios", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
