
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    public partial class SellosDependencia : BaseForm
    {
        public event Action<string> DependenciaTextChanged;
        public event Action<string> LocalidadTextChanged;

        public SellosDependencia()
        {
            InitializeComponent();

            //para redondear bordes de panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            textBox_Localidad.Enabled = false;// inicializar en false
        }



        private void SellosDependencia_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

            MayusculaSola.AplicarAControl(textBox_Localidad);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            ActualizarControles();//Inicializa  el estado de los controles pictureBox

            // Configura el arrastrar y soltar para los PictureBox
            pictureBox_SelloMedalla.AllowDrop = true;
            pictureBox_SelloEscalera.AllowDrop = true;
            pictureBox_SelloFoliador.AllowDrop = true;

            pictureBox_SelloMedalla.DragEnter += PictureBox_DragEnter;
            pictureBox_SelloEscalera.DragEnter += PictureBox_DragEnter;
            pictureBox_SelloFoliador.DragEnter += PictureBox_DragEnter;

            pictureBox_SelloMedalla.DragDrop += PictureBox_DragDrop;
            pictureBox_SelloEscalera.DragDrop += PictureBox_DragDrop;
            pictureBox_SelloFoliador.DragDrop += PictureBox_DragDrop;

            // Ajusta el SizeMode de cada PictureBox
            pictureBox_SelloMedalla.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_SelloEscalera.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_SelloFoliador.SizeMode = PictureBoxSizeMode.StretchImage;

            // Dispara el evento si hay suscriptores
            DependenciaTextChanged?.Invoke(comboBox_Dependencia.Text);

            this.Shown += NuevaDependencia_Shown;//para que haga foco en un textBox

            //cargar desde base de datos
            CargarDatosDependencia(comboBox_Dependencia, dbManager);
        }
        //-----------------------------------------------------------------------------
        private void NuevaDependencia_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            comboBox_Dependencia.Focus();
        }
        //____________________________________________________________________
        private void SellosDependencia_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Los sellos que agrege serán usados para completar las distintas planillas de las actuaciones", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //--------------------------------------------------------------------------------
        private void ComboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {

            // Actualiza los controles
            ActualizarControles();

            //----para actualizar textbox entre formularios
            // Asegura que el cursor esté al final del texto
            comboBox_Dependencia.SelectionStart = comboBox_Dependencia.Text.Length;
            // Disparar el evento si hay suscriptores
            DependenciaTextChanged?.Invoke(comboBox_Dependencia.Text);

            // Si el texto cambia (cuando el usuario escribe), permite la edición nuevamente

            if (comboBox_Dependencia.SelectedIndex == -1) // -1 indica que no hay un elemento seleccionado de la lista
            {
                comboBox_Dependencia.DropDownStyle = ComboBoxStyle.DropDown;
            }
            // Habilitar el TextBox_Localidad si se escribe en el ComboBox
            if (!string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
            {
                textBox_Localidad.Enabled = true;
            }
        }
        private void TextBox_Localidad_TextChanged(object sender, EventArgs e)
        {

            // Actualiza los controles
            ActualizarControles();

            //----para actualizar textbox entre formularios
            // Asegura que el cursor esté al final del texto
            textBox_Localidad.SelectionStart = textBox_Localidad.Text.Length;
            // Disparar el evento si hay suscriptores
            LocalidadTextChanged?.Invoke(textBox_Localidad.Text);

        }

        //-------------------------------------------------------------------------------
        //---------------------BOTON LIMPIAR------------------------
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Dependencia.SelectedIndex = -1;
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        //-------------------------------------------------------------------------------
        //---------------------BOTON GUARDAR------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verifica que se haya ingresado texto en el textBox_Dependencia
            if (string.IsNullOrWhiteSpace(comboBox_Dependencia.Text))
            {
                MensajeGeneral.Mostrar("Debe ingresar a qué dependencia corresponden los sellos.", MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            // Verifica que al menos uno de los PictureBox tenga una imagen
            bool tieneImagen = pictureBox_SelloMedalla.Image != null ||
                                pictureBox_SelloEscalera.Image != null ||
                                pictureBox_SelloFoliador.Image != null;

            if (!tieneImagen)
            {
                MensajeGeneral.Mostrar("Debe agregar al menos una imagen a los campos de sello.", MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            // Si se ingresó el texto y se cargaron imágenes, muestra un mensaje de éxito
            MensajeGeneral.Mostrar("Se ha cargado exitosamente los sellos de la dependencia.", MensajeGeneral.TipoMensaje.Exito);
        }


        //---------------------------------------------------------------------------------
        //-----EVENTOS PARA HABILITAR Y MODIFICAR PICKTUREBOX------------------------------



        private void ActualizarControles()
        {
            // Verifica si TextoDependencia tiene texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(comboBox_Dependencia.Text);

            // Actualiza el estado de los PictureBox
            ActualizarPictureBox(pictureBox_SelloMedalla, esTextoValido);
            ActualizarPictureBox(pictureBox_SelloEscalera, esTextoValido);
            ActualizarPictureBox(pictureBox_SelloFoliador, esTextoValido);
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
                            MensajeGeneral.Mostrar("No se pudo cargar la imagen: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && (files[0].EndsWith(".jpg") || files[0].EndsWith(".jpeg") || files[0].EndsWith(".png") || files[0].EndsWith(".bmp")))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        //------------------------------------------------------------
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files.Length > 0)
                    {
                        // Cargar la imagen desde el archivo
                        Image img = Image.FromFile(files[0]);

                        // Establecer la imagen en el PictureBox
                        pictureBox.Image = img;
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar("No se pudo cargar la imagen: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }
        //---------------------------------------------------------------------
        //---para actualizar automaticamente entre form nuevaDependencia y sellosDependencia

        public string TextoDependencia
        {
            get { return comboBox_Dependencia.Text; }
            set { comboBox_Dependencia.Text = value; }
        }
        public string TextoLocalidad
        {
            get { return textBox_Localidad.Text; }
            set { textBox_Localidad.Text = value; }
        }

        public void UpdateDependenciaTextBox(string text)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (comboBox_Dependencia.Text != text)
            {
                comboBox_Dependencia.Text = text;
            }
        }
        public void ActualizarTextoDependencia(string texto)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (comboBox_Dependencia.Text != texto)
            {
                comboBox_Dependencia.Text = texto;
            }
        }

        public void ActualizarTextoLocalidad(string texto)
        {
            // Solo actualiza el texto si es diferente para evitar un bucle infinito
            if (textBox_Localidad.Text != texto)
            {
                textBox_Localidad.Text = texto;
            }
        }

        //habilita localidad en caso de que no se seleccione un item, para ser usado cuando se llama al form individualmente
        private void ComboBox_Dependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el usuario selecciona un elemento de la lista, deshabilitar la edición
            if (comboBox_Dependencia.SelectedIndex >= 0)
            {
                comboBox_Dependencia.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            // Deshabilitar el TextBox si se selecciona un ítem del ComboBox
            if (comboBox_Dependencia.SelectedIndex != -1) // Asegurarse de que hay un ítem seleccionado
            {
                textBox_Localidad.Enabled = false;
                textBox_Localidad.Clear();
            }
        }


    }
}