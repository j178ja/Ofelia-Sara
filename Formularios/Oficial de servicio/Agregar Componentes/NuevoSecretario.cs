
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
//using Ofelia_Sara.Base_de_Datos;
using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
//using SkiaSharp;//biblioteca para efecto visual
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
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

            //para redondear bordes de panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }
        // Implementación del método de la interfaz IFormulario
        public void Inicializar()
        {
            // Lógica de inicialización adicional si es necesario
        }
        private void NuevoSecretario_Load(object sender, EventArgs e)
        {
            // Configurar todos los TextBoxes en el formulario
            TextoEspecialCampos();
            InicializarPictureBox();//para deshabilitar pictureBox al cargar formulario


            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
           // ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);
            // Asegúrate de que no haya selección y el ComboBox_Jerarquia esté desactivado
            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;
            //para recibir imagenes y cargarlas con click
            pictureBox_FirmaDigitalizada.AllowDrop = true;
            pictureBox_FirmaDigitalizada.DragEnter += PictureBox_DragEnter;
            pictureBox_FirmaDigitalizada.DragDrop += PictureBox_DragDrop;
            pictureBox_FirmaDigitalizada.SizeMode = PictureBoxSizeMode.StretchImage;

            textBox_NumeroLegajo.MaxLength = 7;//limitando numero de legajo
            this.Shown += Focus_Shown;//para que haga foco en un textBox

            //cargar desde base de datos
            CargarDatosDependencia(comboBox_Dependencia, dbManager);
        }
        //-----------------------------------------------------------------------------
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_NumeroLegajo.Focus();
        }
        //-----------------------------------------------------------------
        protected void ConfigurarComboBoxEscalafon(CustomComboBox customComboBox)
        {
            customComboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }

        //-----------BOTON LIMPIAR---------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Escalafon.SelectedIndex = -1;
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }
        //______________________________________________________________________________

        //----------------------------------------------------------------------------------


        //-------------BOTON GUARDAR--------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Jerarquia.Text) ||
                 string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                 string.IsNullOrWhiteSpace(textBox_Apellido.Text))
            {
                MensajeGeneral.Mostrar("Debe completar los campos JERARQUIA, NOMBRE y APELLIDO.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                // Convertir el valor de textBox_NumeroLegajo a float, y asignar un valor por defecto si está vacío
                float legajo = string.IsNullOrWhiteSpace(textBox_NumeroLegajo.Text)
                               ? 100000 // valor por defecto
                               : float.Parse(textBox_NumeroLegajo.Text);



                var nuevoSecretario = new Secretario
                {
                    Legajo = legajo,
                    Subescalafon = comboBox_Escalafon.Text,
                    Jerarquia = comboBox_Jerarquia.Text,
                    Nombre = textBox_Nombre.Text,
                    Apellido = textBox_Apellido.Text,
                    Dependencia = comboBox_Dependencia.Text,
                    Funcion = textBox_Funcion.Text
                };

                SecretariosManager manager = new SecretariosManager();
                manager.InsertSecretario(nuevoSecretario.Legajo, nuevoSecretario.Subescalafon, nuevoSecretario.Jerarquia, nuevoSecretario.Nombre, nuevoSecretario.Apellido, nuevoSecretario.Dependencia, nuevoSecretario.Funcion);

                MensajeGeneral.Mostrar("Se ha guardado un nuevo secretario.", MensajeGeneral.TipoMensaje.Exito);
                LimpiarFormulario.Limpiar(this);
                comboBox_Escalafon.SelectedIndex = -1;
                comboBox_Dependencia.SelectedIndex = -1;
            }
        }

        //----------------------------------------------------------------------------
        //-------------------CONTROLAR QUE SEAN MAYUSCULAS------------------
        private void TextoEspecialCampos()
        {
            // Configurar TextBox(solo letras y espacios, convertir a mayúsculas)
            Dictionary<string, bool> textBoxExcepciones = new Dictionary<string, bool>
    {
        { "textBox_Nombre", false },
        { "textBox_Apellido", false },
        { "textBox_NumeroLegajo", true },
        { "texBox_Funcion", false }
    };

            // Configurar ComboBox (acepta números, letras, y espacios, convierte a mayúsculas)
            Dictionary<string, bool> comboBoxExcepciones = new Dictionary<string, bool>
    {

        { "comboBox_Dependencia", true },
        { "comboBox_Escalafon", false } // Configuración según la opción seleccionada
    };

            // Aplicar la lógica a los controles del formulario
            TextoEnMayuscula.AplicarAControles(this, textBoxExcepciones, comboBoxExcepciones);

            //  deshabilitar la edición del ComboBox_Escalafon
            comboBox_Escalafon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Jerarquia.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        //-------------MENSAJE DE AYUDA BOTON HELP---------
        private void NuevoSecretario_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Debe ingresar los datos conforme se solicitan. Será incorporado a la lista de secretarios en los formularios", MensajeGeneral.TipoMensaje.Informacion);

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
        }

        private void textBox_NumeroLegajo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Guardar la posición actual del cursor antes de actualizar el texto
            int selectionStart = textBox.SelectionStart;
            int originalLength = textBox.Text.Length;

            // Formatear el número con puntos
            string textoFormateado = ClaseNumeros.FormatearNumeroConPuntos(textBox.Text);

            // Actualizar el texto en el TextBox
            textBox.Text = textoFormateado;

            // Calcular la nueva posición del cursor
            int deltaLength = textoFormateado.Length - originalLength;
            int newCursorPosition = selectionStart + deltaLength;

            // Ajustar la posición del cursor solo si la nueva posición está dentro del rango
            if (newCursorPosition >= 0 && newCursorPosition <= textoFormateado.Length)
            {
                textBox.SelectionStart = newCursorPosition;
            }
            else
            {
                textBox.SelectionStart = textoFormateado.Length; // Colocar al final si está fuera de rango
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

    }
}
