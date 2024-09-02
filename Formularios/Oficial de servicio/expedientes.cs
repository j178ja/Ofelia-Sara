using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara
{
    public partial class Expedientes : BaseForm
    {
        public Expedientes()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }

        private void Expedientes_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Buscar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Limpiar);

            MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            MayusculaSola.AplicarAControl(textBox_Causante);
            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            pictureBox_Pdf.AllowDrop = true;
            pictureBox_Word.AllowDrop = true;
        
            pictureBox_Pdf.DragEnter += PictureBox_DragEnter;
            pictureBox_Word.DragEnter += PictureBox_DragEnter;
          
            pictureBox_Pdf.DragDrop += PictureBox_DragDrop;
            pictureBox_Word.DragDrop += PictureBox_DragDrop;
         


        }
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
                    MessageBox.Show("No se pudo cargar el documento: " + ex.Message);
                }
            }
        }

        private void radioButton_Pdf_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el RadioButton está marcado
            if (radioButton_Pdf.Checked)
            {
                // Habilita el PictureBox si el RadioButton_Pdf está seleccionado
                // Llama al método ActualizarPictureBox con el estado actual del RadioButton_Pdf
                ActualizarPictureBox(pictureBox_Pdf, radioButton_Pdf.Checked);
                btn_Convertir.Enabled = true;
            }
            else
            {
                // Deshabilita el PictureBox si el RadioButton_Pdf no está seleccionado
                pictureBox_Pdf.Enabled = false;
                btn_Convertir.Enabled = false;
            }
        }

        private void radioButton_Word_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el RadioButton está marcado
            if (radioButton_Word.Checked)
            {
                // Habilita el PictureBox si el RadioButton_Pdf está seleccionado
                // Llama al método ActualizarPictureBox con el estado actual del RadioButton_Pdf
                ActualizarPictureBox(pictureBox_Word, radioButton_Word.Checked);
                btn_Convertir.Enabled = true;
            }
            else
            {
                // Deshabilita el PictureBox si el RadioButton_Pdf no está seleccionado
                pictureBox_Word.Enabled = false;
                btn_Convertir.Enabled = false;
            }
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
    }
}
