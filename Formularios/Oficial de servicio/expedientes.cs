using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            ActualizarControles();

            // Estilo inicial del botón
            EstiloBotonConvertir(btn_Convertir);

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

        private void ActualizarControles()
        {
            // Si el RadioButton Pdf está marcado
            if (radioButton_Pdf.Checked)
            {
                ActualizarPictureBox(pictureBox_Pdf, true);  // Habilita PictureBox Pdf
                ActualizarPictureBox(pictureBox_Word, false); // Deshabilita PictureBox Word
                btn_Convertir.Enabled = true; // Habilita el botón
            }
            // Si el RadioButton Word está marcado
            else if (radioButton_Word.Checked)
            {
                ActualizarPictureBox(pictureBox_Pdf, false);  // Deshabilita PictureBox Pdf
                ActualizarPictureBox(pictureBox_Word, true);  // Habilita PictureBox Word
                btn_Convertir.Enabled = true; // Habilita el botón
            }
            // Si ninguno de los dos RadioButton está marcado
            else
            {
                ActualizarPictureBox(pictureBox_Pdf, false);  // Deshabilita ambos PictureBox
                ActualizarPictureBox(pictureBox_Word, false);
                btn_Convertir.Enabled = false; // Deshabilita el botón
            }
        }

        // Este método se llamará cuando cambie el estado de cualquiera de los RadioButtons
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarControles();
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
        // Método para estilizar el botón según si está habilitado o deshabilitado
        bool botonPresionado = false; // Variable para controlar el estado del botón

        protected void EstiloBotonConvertir(Button boton)
        {
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;

            // Evento Paint: Dibuja un borde redondeado y aplica el color del texto solo si el botón está habilitado
            boton.Paint += (sender, e) =>
            {
                int bordeGrosor;
                int bordeRadio;
                Color bordeColor;
                Color textoColor;

                if (boton.Enabled)
                {
                    bordeGrosor = 3;
                    bordeRadio = 12;
                    bordeColor = Color.LightGreen;
                    textoColor = botonPresionado ? Color.White : Color.Green; // Cambia el texto a blanco si está presionado
                }
                else
                {
                    bordeGrosor = 2;
                    bordeRadio = 12;
                    bordeColor = Color.Tomato;
                    textoColor = Color.Red; // Color del texto cuando el botón está deshabilitado
                }

                using (GraphicsPath path = new GraphicsPath())
                {
                    // Define el rectángulo con el radio especificado
                    path.AddArc(new Rectangle(0, 0, bordeRadio, bordeRadio), 180, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, 0, bordeRadio, bordeRadio), 270, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 0, 90);
                    path.AddArc(new Rectangle(0, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 90, 90);
                    path.CloseAllFigures();

                    // Dibuja el borde con el color especificado
                    e.Graphics.DrawPath(new Pen(bordeColor, bordeGrosor), path);
                }

                // Establece el color del texto
                boton.ForeColor = textoColor;
            };

            // Evento MouseEnter: Cambia el tamaño desde el centro, fondo verde claro y texto blanco
            boton.MouseEnter += (sender, e) =>
            {
                boton.BackColor = Color.LightGreen; // Cambia el fondo a verde claro
                if (!botonPresionado)
                {
                    boton.ForeColor = Color.White; // Cambia el color del texto a blanco si no está presionado
                }

                int incremento = 5;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

                boton.Invalidate(); // Redibuja el botón para aplicar el borde
            };

            // Evento MouseLeave: Restaura el tamaño, la posición y los colores originales
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.White; // Fondo original blanco
                if (!botonPresionado)
                {
                    boton.ForeColor = Color.Green; // Letra verde cuando no está en hover
                }

                boton.Invalidate(); // Redibuja el botón para aplicar el borde
            };

            // Evento MouseDown: Cambia el color cuando el botón se presiona
            boton.MouseDown += (sender, e) =>
            {
                botonPresionado = true; // Indica que el botón está presionado
                boton.BackColor = Color.Green; // Cambia el fondo a verde oscuro
                boton.ForeColor = Color.White; // Cambia el texto a blanco
                boton.Invalidate(); // Redibuja el botón
            };

            // Evento MouseUp: Restaura el color cuando se suelta el botón
            boton.MouseUp += (sender, e) =>
            {
                botonPresionado = false; // Indica que el botón ya no está presionado
                boton.BackColor = Color.LightGreen; // Cambia el fondo a verde claro
                boton.ForeColor = Color.White; // Mantiene el texto blanco
                boton.Invalidate(); // Redibuja el botón
            };

            // Llama a Invalidate para asegurarse de que el borde se dibuje inicialmente
            boton.Invalidate();
        }

    }
}
