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

            // Asigna el evento TextChanged de textBox_Nombre a ActualizarEstado
            textBox_Nombre.TextChanged += (sender, e) => ActualizarEstado();

            // Asigna el evento TextChanged de textBox_Dni a ActualizarEstado
            textBox_Dni.TextChanged += (sender, e) => ActualizarEstado();
        }
        //-------------------------------------------------------------------------------
        private void AgregarDatosPersonales_Load(object sender, EventArgs e)
        {
           //-----INICIALIZAR EVENTOS PICKTUREBOX-------------
           //-----Del domicilio------------------
            pictureBox_Domicilio.AllowDrop = true;
            pictureBox_Geoposicionamiento.AllowDrop = true;

            pictureBox_Domicilio.DragEnter += new DragEventHandler(pictureBox_DragEnter);
            pictureBox_Domicilio.DragDrop += new DragEventHandler(pictureBox_DragDrop);

            pictureBox_Geoposicionamiento.DragEnter += new DragEventHandler(pictureBox_DragEnter);
            pictureBox_Geoposicionamiento.DragDrop += new DragEventHandler(pictureBox_DragDrop);

            // Ajusta el SizeMode de cada PictureBox
            pictureBox_Domicilio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Geoposicionamiento.SizeMode = PictureBoxSizeMode.StretchImage;
            //----------------------------------------------------

            //----------PARA IMAGENES DEL LEGAJO----------------------
            pictureBox_Frente.AllowDrop = true;//permite que pictureBox reciba imagenes
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
             
            pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_PerfilDerecho.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_PerfilIzquierdo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_CuerpoEntero.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asociar el evento KeyPress al TextBox_Edad
            textBox_Edad.KeyPress += new KeyPressEventHandler(textBox_Edad_KeyPress);
            textBox_Edad.TextChanged += new EventHandler(textBox_Edad_TextChanged);

            // Asociar el evento KeyPress al TextBox_Dni
            textBox_Dni.KeyPress += new KeyPressEventHandler(textBox_Dni_KeyPress);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            ActualizarControlesPictureDOM();

            // Asocia los eventos Paint
            AsociarEventosPaint();

            // Inicializa los PictureBox como deshabilitados
            ActualizarControlesPicture();

            // Actualiza el estado de los PictureBox basado en el estado del CheckBox
            actualizarCheckBox();

            // Inicializa los PictureBox como deshabilitados
            pictureBox_Frente.Enabled = true;
            pictureBox_PerfilDerecho.Enabled = true;
            pictureBox_PerfilIzquierdo.Enabled = true;
            pictureBox_CuerpoEntero.Enabled = true;
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
            //------------------------------------------------------------------------------------

            ActualizarEstado();
        }

        //-------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------
        //----PARA RECUADRO VERDE Y ROJO DEL PICKTUREBOX-------------
        private void ActualizarControlesPictureDOM()
        {
            // Verifica si TextoDomicilio y localidad tienen texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Domicilio.Text) && !string.IsNullOrWhiteSpace(textBox_Localidad.Text);

            // Actualiza el estado de los PictureBox
            ActualizarPictureBox(pictureBox_Geoposicionamiento, esTextoValido);
            ActualizarPictureBox(pictureBox_Domicilio, esTextoValido);

            pictureBox_Geoposicionamiento.Paint += PictureBox_Paint;
            pictureBox_Domicilio.Paint += PictureBox_Paint;

        }

        private void ActualizarPictureBox(PictureBox pictureBox, bool habilitar)
        {
            if (habilitar)
            {
                pictureBox.Enabled = true;
                pictureBox.Tag = Color.LimeGreen; // Color del borde cuando está habilitado
                pictureBox.BackColor = SystemColors.ControlLight;
            }
            else
            {
                pictureBox.Enabled = false;
                pictureBox.Tag = Color.Tomato; // Color del borde cuando está deshabilitado
                pictureBox.BackColor = Color.DarkGray;
            }

            pictureBox.Invalidate(); // Redibuja el borde
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
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
        //---------------------------------------------------------------------
        //Eventos para cargar imagenes en los pictureBox
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------

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
        //evento para que si se completa control domicilio y localidad se habiliten los pickture
        private void textBox_Domicilio_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPictureDOM();
        }

        private void textBox_Localidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPictureDOM();
        }
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

        //-----METODO PARA HABILITAR FOTOS DEL LEGAJO---------------
        // Método para asociar los eventos Paint
        private void AsociarEventosPaint()
        {
            pictureBox_Frente.Paint += PictureBox_Paint;
            pictureBox_PerfilDerecho.Paint += PictureBox_Paint;
            pictureBox_PerfilIzquierdo.Paint += PictureBox_Paint;
            pictureBox_CuerpoEntero.Paint += PictureBox_Paint;
        }

        // Método para actualizar el estado de los PictureBox
        private void ActualizarControlesPicture()
        {
            pictureBox_Frente.Enabled = false;
            pictureBox_PerfilDerecho.Enabled = false;
            pictureBox_PerfilIzquierdo.Enabled = false;
            pictureBox_CuerpoEntero.Enabled = false;

            ActualizarPictureBox(pictureBox_Frente, false);
            ActualizarPictureBox(pictureBox_PerfilDerecho, false);
            ActualizarPictureBox(pictureBox_PerfilIzquierdo, false);
            ActualizarPictureBox(pictureBox_CuerpoEntero, false);
        }
        private void checkBox_LegajoDetenido_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCheckBox();
        }

        private void actualizarCheckBox()
        {
            bool isChecked = checkBox_LegajoDetenido.Checked;

            ActualizarPictureBox(pictureBox_Frente, isChecked);
            ActualizarPictureBox(pictureBox_PerfilDerecho, isChecked);
            ActualizarPictureBox(pictureBox_PerfilIzquierdo, isChecked);
            ActualizarPictureBox(pictureBox_CuerpoEntero, isChecked);
        }

        //-------------------------------------------------------------------------
        //--Para habilitar check y modificar label
        private void ActualizarEstado()
        {
            // Verifica si textBox_Nombre y textBox_Dni no están vacíos ni solo con espacios
            bool esTextoValidoNombre = !string.IsNullOrWhiteSpace(textBox_Nombre.Text);
            bool esTextoValidoDni = !string.IsNullOrWhiteSpace(textBox_Dni.Text);

            // Ambos textos deben ser válidos para que el estado sea verdadero
            bool esTextoValido = esTextoValidoNombre && esTextoValidoDni;

            // Actualiza el color del label y el estado del checkbox según el texto de los TextBoxes
            label_LegajoDetenido.ForeColor = esTextoValido ? Color.Black : Color.Tomato;
            label_LegajoDetenido.BackColor = esTextoValido ? Color.Transparent : Color.Gray;

            // Actualiza el color de fondo del CheckBox y su estado habilitado/deshabilitado
            checkBox_LegajoDetenido.Enabled = esTextoValido;
            checkBox_LegajoDetenido.BackColor = esTextoValido ? Color.Transparent : Color.Tomato;
        }
       

    }
}
