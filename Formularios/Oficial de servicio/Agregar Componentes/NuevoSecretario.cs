
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;

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
    #region CONSTRUCTOR
    public partial class NuevoSecretario : BaseForm
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public NuevoSecretario()
        {
            InitializeComponent();
            this.Load += new EventHandler(NuevoSecretario_Load);// inicializar Load

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

 

            this.FormClosing += NuevoSecretario_FormClosing;

            comboBox_Jerarquia.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;
            comboBox_Escalafon.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;

        }
        #endregion

        #region LOAD
        private void NuevoSecretario_Load(object sender, EventArgs e)
        {
            // Configurar todos los TextBoxes en el formulario
            TextoEspecialCampos();
            InicializarPictureBox();//para deshabilitar pictureBox al cargar formulario


            ConfigurarComboBoxEscalafon(comboBox_Escalafon);
            // Configurar el comportamiento de los ComboBox
            ConfigurarComboBoxEscalafonJerarquia(comboBox_Escalafon, comboBox_Jerarquia);

            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.SelectedIndex = -1; // No selecciona ningún ítem
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;
            //para recibir imagenes y cargarlas con click
            pictureBox_FirmaDigitalizada.AllowDrop = true;
            pictureBox_FirmaDigitalizada.DragEnter += PictureBox_DragEnter;
            pictureBox_FirmaDigitalizada.DragDrop += PictureBox_DragDrop;
            pictureBox_FirmaDigitalizada.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Shown += Focus_Shown;//para que haga foco en un textBox

           
        }
        #endregion

        #region METODOS GENERALES
        /// <summary>
        /// METODO PARA QUE TEXTBOX LEGAJO RECIBA EL FOCO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_NumeroLegajo.Focus();
        }

        /// <summary>
        /// METODO PARA MOSTRAR MENSAJE DE CONFIRMACION 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoSecretario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e,"No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
 
            }
        }

        protected static void ConfigurarComboBoxEscalafon(CustomComboBox customComboBox)
        {
            customComboBox.DataSource = JerarquiasManager.ObtenerEscalafones();
        }

        /// <summary>
        /// BOTON LIMPIAR -EVENTO CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Escalafon.SelectedIndex = -1;
            comboBox_Jerarquia.SelectedIndex = -1;

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }

        /// <summary>
        /// BOTON GUARDAR-EVENTO CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Jerarquia.TextValue) ||
                 string.IsNullOrWhiteSpace(textBox_Nombre.TextValue) ||
                 string.IsNullOrWhiteSpace(textBox_Apellido.TextValue))
            {
                MensajeGeneral.Mostrar("Debe completar los campos JERARQUIA, NOMBRE y APELLIDO.", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                // Convertir el valor de textBox_NumeroLegajo a float, y asignar un valor por defecto si está vacío
                float legajo = string.IsNullOrWhiteSpace(textBox_NumeroLegajo.TextValue)
                               ? 100000 // valor por defecto
                               : float.Parse(textBox_NumeroLegajo.TextValue);

                var nuevoSecretario = new Secretarios
                {
                    Legajo = legajo,
                    Subescalafon = comboBox_Escalafon.TextValue,
                    Jerarquia = comboBox_Jerarquia.TextValue,
                    Nombre = textBox_Nombre.TextValue,
                    Apellido = textBox_Apellido.TextValue,
                    Dependencia = comboBox_Dependencia.TextValue,
                    Funcion = textBox_Funcion.TextValue
                };

                SecretariosManager manager = new SecretariosManager();
                manager.InsertSecretario(nuevoSecretario.Legajo, nuevoSecretario.Subescalafon, nuevoSecretario.Jerarquia, nuevoSecretario.Nombre, nuevoSecretario.Apellido, nuevoSecretario.Dependencia, nuevoSecretario.Funcion);
                datosGuardados = true;
                MensajeGeneral.Mostrar("Se ha guardado un nuevo secretario.", MensajeGeneral.TipoMensaje.Exito);
                LimpiarFormulario.Limpiar(this);
                comboBox_Escalafon.SelectedIndex = -1;
                comboBox_Dependencia.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// CONTROLAR QUE SEAN MAYUSCULAS
        /// </summary>
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


            //  deshabilitar la edición del ComboBox_Escalafon
            comboBox_Escalafon.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;
            comboBox_Jerarquia.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;

        }

        

       

        /// <summary>
        /// MENSAJE DE AYUDA BOTON HELP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoSecretario_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Debe ingresar los datos conforme se solicitan. Será incorporado a la lista de secretarios en los formularios");
        }

        #endregion

        #region CHECK Y PICTURE
        /// <summary>
        /// EVENTOS PARA HABILITAR Y MODIFICAR PICKTUREBOX
        /// </summary>
        private void InicializarPictureBox()
        {
            // Inicializa el PictureBox con un borde rojo y deshabilitado
            pictureBox_FirmaDigitalizada.Tag = Color.Tomato;
            pictureBox_FirmaDigitalizada.Enabled = false;
            pictureBox_FirmaDigitalizada.BackColor = Color.DarkGray;
            pictureBox_FirmaDigitalizada.Invalidate(); // Redibuja el borde
        }
        /// <summary>
        /// EVENTOS PARA EL CHECK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_AgregarFirma_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    pictureBox_FirmaDigitalizada.Enabled = true;
                    pictureBox_FirmaDigitalizada.Tag = Color.LimeGreen; // Color del borde cuando está habilitado
                    pictureBox_FirmaDigitalizada.BackColor = SystemColors.ControlLight;
                    checkBox_AgregarFirma.Visible = false;

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
        private void PictureBox_CheckFirmaDigitalizada_Click(object sender, EventArgs e)
        {

            pictureBox_FirmaDigitalizada.Enabled = false;
            pictureBox_FirmaDigitalizada.Tag = Color.Tomato; // Color del borde cuando está deshabilitado
            pictureBox_FirmaDigitalizada.BackColor = Color.DarkGray;
        }

        /// <summary>
        /// MODIFICA ASPECTO PICTURE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_FirmaDigitalizada_Paint(object sender, PaintEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                Color borderColor = pictureBox.Tag is Color ? (Color)pictureBox.Tag : Color.Transparent;

                using Pen pen = new Pen(borderColor, 3); // Grosor del borde
                                                         // Dibuja el borde exterior
                e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Enabled)
            {
                using OpenFileDialog openFileDialog = new OpenFileDialog();
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
#endregion