using System;
using System.Collections.Generic;
using Ofelia_Sara.general.clases;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.general.clases.Apariencia_General;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales

{
    public partial class AgregarDatosPersonalesImputado : BaseForm
    {
        // Propiedad pública para establecer el texto del TextBox
        public string TextoNombre
        {
            get { return textBox_Nombre.Text; }
            set { textBox_Nombre.Text = value; }
        }
        //-------------------------------------------------------------------
        public  AgregarDatosPersonalesImputado()
        {
            InitializeComponent();
            
            
        }
        //-------------------------------------------------------------------------------
        private void AgregarDatosPersonales_Load(object sender, EventArgs e)
        {
            //permite que pictureBox reciba imagenes
            pictureBox_Frente.AllowDrop = true;
            pictureBox_PerfilDerecho.AllowDrop = true;
            pictureBox_PerfilIzquierdo.AllowDrop = true;
            pictureBox_CuerpoEntero.AllowDrop = true;

            // Asocia los eventos DragEnter y DragDrop para cada PictureBox
            pictureBox_Frente.DragEnter += new DragEventHandler(pictureBox_DragEnter);
            pictureBox_Frente.DragDrop += new DragEventHandler(pictureBox_DragDrop);

            pictureBox_PerfilDerecho.DragEnter += new DragEventHandler(pictureBox_DragEnter);
            pictureBox_PerfilDerecho.DragDrop += new DragEventHandler(pictureBox_DragDrop);

            pictureBox_PerfilIzquierdo.DragEnter += new DragEventHandler(pictureBox_DragEnter);
            pictureBox_PerfilIzquierdo.DragDrop += new DragEventHandler(pictureBox_DragDrop);

            pictureBox_CuerpoEntero.DragEnter += new DragEventHandler(pictureBox_DragEnter);
            pictureBox_CuerpoEntero.DragDrop += new DragEventHandler(pictureBox_DragDrop);

          

            // Asociar el evento KeyPress al TextBox_Edad
            textBox_Edad.KeyPress += new KeyPressEventHandler(textBox_Edad_KeyPress);
            textBox_Edad.TextChanged += new EventHandler(textBox_Edad_TextChanged);

            // Asociar el evento KeyPress al TextBox_Dni
            textBox_Dni.KeyPress += new KeyPressEventHandler(textBox_Dni_KeyPress);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            //-------------------------------------------------------------------------------
            // Define las excepciones para los TextBox y ComboBox.
            var textBoxExcepciones = new Dictionary<string, bool>
        {
            { "textBox_Dni", true },  // Este TextBox solo acepta números.
            {"textBox_Edad", true },
            {"textBox_Telefono", true }
            }; 

            // Aplica la configuración a todos los controles del formulario.
            TextoEnMayuscula.AplicarAControles(this, textBoxExcepciones, null);
        }
        

        //-----------------------------------------------------------------------------
        //-------ARRASTRAR IMAGEN A CADA PICKTUREBOX--------------------------------
        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            // Verifica si el archivo arrastrado es una imagen
            if (e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Cambia el cursor para indicar que se puede soltar
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Indica que el tipo de datos no es aceptable
                e.Effect = DragDropEffects.None;
            }
        }
        //-----------------------------------------------------------------------------
        //-------EVENTO SOLTAR IMAGEN EN CADA PICKTUREBOX--------------------------------
        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            // Obtiene el PictureBox que disparó el evento
            PictureBox pictureBox = sender as PictureBox;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Obtiene los archivos arrastrados
                string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Verifica que se haya arrastrado al menos un archivo
                if (archivos.Length > 0)
                {
                    // Carga la primera imagen arrastrada
                    string archivo = archivos[0];
                    try
                    {
                        pictureBox.Image = Image.FromFile(archivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                    }
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                // Obtiene la imagen arrastrada
                Image imagen = (Image)e.Data.GetData(DataFormats.Bitmap);
                pictureBox.Image = imagen;
            }
        }
        //---------------------------------------------------------------------
        //------------limitar textBox_Edad a 2 digitos--------------------------
        private void textBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene menos de 2 caracteres
            if (textBox_Edad.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 2 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }
        private void textBox_Edad_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto actual del TextBox es "0" o "00"
            if (/*textBox_Edad.Text == "0" || */textBox_Edad.Text == "00")
            {
                // Mostrar un mensaje de error y limpiar el TextBox
                MessageBox.Show("El valor no puede ser 0 o 00", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Edad.Clear();
            }
        }
        //---------------------------------------------------------------------
        //------------limitar textBox_Dni a 8 digitos--------------------------
        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene menos de 6 caracteres
            if (textBox_Dni.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 2 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //------------------------------------------------------------------------------------
        //------------EVENTO PARA QUE EL COMBOBOX ESPECIFICO DE NACIONALIDAD ACEPTE SOLO LETRAS

        private void comboBox_Nacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es una letra
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la entrada si no es una letra
            }
        }
    }
}
