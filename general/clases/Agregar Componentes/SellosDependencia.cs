﻿using Ofelia_Sara.general.clases.Apariencia_General;
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
    public partial class SellosDependencia : BaseForm
    {
        public string TextoDependencia { get; set; }
        public SellosDependencia()
        {
            InitializeComponent();

          
        }

        private void SellosDependencia_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);

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
        }
        //-----------------------------------------------------------------------------
        private void SellosDependencia_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Los sellos que agrege serán usados para completar las distintas planillas de las actuaciones", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //--------------------------------------------------------------------------------
        private void textBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto a mayúsculas ignorando caracteres especiales
            string textoConvertido = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(textBox_Dependencia.Text);

            // Mantiene la posición del cursor
            int selectionStart = textBox_Dependencia.SelectionStart;
            int selectionLength = textBox_Dependencia.SelectionLength;

            // Actualiza el texto del TextBox
            textBox_Dependencia.Text = textoConvertido;

            // Restablece la posición del cursor
            textBox_Dependencia.SelectionStart = selectionStart;
            textBox_Dependencia.SelectionLength = selectionLength;

            // Actualiza los controles
            ActualizarControles();
        }


        //-------------------------------------------------------------------------------
        //---------------------BOTON LIMPIAR------------------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //-------------------------------------------------------------------------------
        //---------------------BOTON GUARDAR------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verifica que se haya ingresado texto en el textBox_Dependencia
            if (string.IsNullOrWhiteSpace(textBox_Dependencia.Text))
            {
                MessageBox.Show("Debe ingresar a qué dependencia corresponden los sellos.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verifica que al menos uno de los PictureBox tenga una imagen
            bool tieneImagen = pictureBox_SelloMedalla.Image != null ||
                                pictureBox_SelloEscalera.Image != null ||
                                pictureBox_SelloFoliador.Image != null;

            if (!tieneImagen)
            {
                MessageBox.Show("Debe agregar al menos una imagen a los campos de sello.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si se ingresó el texto y se cargaron imágenes, muestra un mensaje de éxito
            MessageBox.Show("Se ha cargado exitosamente los sellos de la dependencia.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //---------------------------------------------------------------------------------
        //-----EVENTOS PARA HABILITAR Y MODIFICAR PICKTUREBOX------------------------------


        //---Propiedad para que traiga el nombre de la dependencia desde el otro formulario
        public string TextBoxText
        {
            get { return textBox_Dependencia.Text; }
            set { textBox_Dependencia.Text = value; }
        }

        //-----------------------------------------------------------------------------------

        private void ActualizarControles()
        {
            // Verifica si TextoDependencia tiene texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Dependencia.Text);

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
                    MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                }
            }
        }

    }
}