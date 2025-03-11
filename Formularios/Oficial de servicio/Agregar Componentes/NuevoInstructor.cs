
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
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
    public partial class NuevoInstructor : BaseForm
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        public NuevoInstructor()
        {
            InitializeComponent();

            this.Load += new EventHandler(NuevoInstructor_Load);// inicializar Load

            this.FormClosing += NuevoInstructor_FormClosing;
        }
        #endregion

        #region LOAD
        private void NuevoInstructor_Load(object sender, EventArgs e)
        {
            
            InicializarPictureBox();//para inicializar estilo pickturebox

            comboBox_Escalafon.SelectedIndex = -1; // No selecciona ningún ítem
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
        /// METODO PARA QUE EL LEGJO TENGA EL FOCO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_Shown(object sender, EventArgs e)
        {
            // Asegura que el cursor esté en textBox_Dependencia
            textBox_NumeroLegajo.Focus();
        }

        /// <summary>
        /// MUESTRA MENSAJE DE CONFIRMACION AL CIERRE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoInstructor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e,"No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
         
            }
        }

   
       

        /// <summary>
        /// BOTON LIMPIAR-click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario


        }

        /// <summary>
        /// BOTON GUARDAR-click
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

                var nuevoInstructor = new Instructores
                {
                    Legajo = legajo,
                    Subescalafon = comboBox_Escalafon.TextValue,
                    Jerarquia = comboBox_Jerarquia.TextValue,
                    Nombre = textBox_Nombre.TextValue,
                    Apellido = textBox_Apellido.TextValue,
                    Dependencia = comboBox_Dependencia.TextValue,
                    Funcion = textBox_Funcion.TextValue
                };

                InstructoresManager manager = new InstructoresManager();
                manager.InsertInstructor(nuevoInstructor.Legajo, nuevoInstructor.Subescalafon, nuevoInstructor.Jerarquia, nuevoInstructor.Nombre, nuevoInstructor.Apellido, nuevoInstructor.Dependencia, nuevoInstructor.Funcion);
                datosGuardados = true;
                MensajeGeneral.Mostrar("Se ha guardado un nuevo instructor.", MensajeGeneral.TipoMensaje.Exito);
                LimpiarFormulario.Limpiar(this);
              
            }
        }



        /// <summary>
        /// MENSAJE DE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoInstructor_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Debe ingresar los datos conforme se solicitan. Seran agregados a la lista desplegable de instructor");
            
              
        }

        #endregion 

        #region CHECK Y PICKTURE
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
         
            checkBox_AgregarFirma.Visible = true;
            checkBox_AgregarFirma.Checked = false;
            pictureBox_FirmaDigitalizada.Enabled = false;
            pictureBox_FirmaDigitalizada.Tag = Color.Tomato; // Color del borde cuando está deshabilitado
            pictureBox_FirmaDigitalizada.BackColor = Color.DarkGray;
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