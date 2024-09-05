using Microsoft.Office.Interop.Word;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Apariencia_General;
using Ofelia_Sara.general.clases.Apariencia_General.Controles;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WordApp = Microsoft.Office.Interop.Word.Application;
using WinFormsApp = System.Windows.Forms.Application;
using DrawingPoint = System.Drawing.Point;
using WordPoint = Microsoft.Office.Interop.Word.Point;


using Microsoft.Office.Interop.Word;
using System.Linq;




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

            pictureBox_APdf.AllowDrop = true;
            pictureBox_AWord.AllowDrop = true;
        
            pictureBox_APdf.DragEnter += PictureBox_APdf_DragEnter;
            pictureBox_AWord.DragEnter += PictureBox_AWord_DragEnter;
          
            pictureBox_APdf.DragDrop += PictureBox_APdf_DragDrop;
            pictureBox_AWord.DragDrop += PictureBox_AWord_DragDrop;

            ActualizarControles();

            // Estilo inicial del botón
            EstiloBotonConvertir(btn_Convertir);

        }
        //Eventos para cargar imagenes en los pictureBox

        //----CARGAR ARCHIVO WORD PARA CONVERTIR A PDF----------------
        private void PictureBox_APdf_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos Word (*.doc;*.docx)|*.doc;*.docx";
                    openFileDialog.Title = "Selecciona un archivo WORD";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Ruta del archivo Word
                            string wordFilePath = openFileDialog.FileName;

                            // Define la ruta para el archivo PDF
                            string pdfFilePath = System.IO.Path.ChangeExtension(wordFilePath, ".pdf");

                            // Crea una instancia de la aplicación Word
                            WordApp wordApp = new WordApp();
                            Document wordDoc = wordApp.Documents.Open(wordFilePath);

                            // Guarda el documento en formato PDF
                            wordDoc.SaveAs2(pdfFilePath, WdSaveFormat.wdFormatPDF);

                            // Cierra el documento y la aplicación
                            wordDoc.Close();
                            wordApp.Quit();

                            pictureBox.Image = Properties.Resources.doc;

                            // Ajusta la imagen al tamaño del PictureBox manteniendo su proporción
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox.BackColor = Color.LightGreen;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo convertir el archivo Word a PDF. " + ex.Message);
                        }
                    }
                }
            }
        }


        //---´PARA QUE CONVIERTA ARCHIVOS PDF A WORD-----
        private void PictureBox_AWord_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            // Verifica que el PictureBox esté habilitado (si es necesario)
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Configurar el filtro para permitir solo PDF o Word (modificable según lo que desees)
                    openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf|Archivos Word (*.doc;*.docx)|*.doc;*.docx";
                    openFileDialog.Title = "Selecciona un archivo";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Cambia la imagen del PictureBox para indicar que el archivo fue cargado
                            pictureBox.Image = Properties.Resources.pdf;

                            // Ajusta la imagen al tamaño del PictureBox manteniendo su proporción
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            // Opcional: Cambiar también el color de fondo del PictureBox
                            pictureBox.BackColor = Color.LightGreen;

                            // Manejar el archivo cargado según sea necesario
                            string filePath = openFileDialog.FileName;
                            // Puedes realizar más acciones con el archivo si es necesario
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo cambiar la imagen del PictureBox: " + ex.Message);
                        }
                    }
                }
            }
        }




        //----------------------------------------------------
        private void PictureBox_AWord_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && files[0].EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        private void PictureBox_APdf_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 &&
                    (files[0].EndsWith(".doc", StringComparison.OrdinalIgnoreCase) ||
                     files[0].EndsWith(".docx", StringComparison.OrdinalIgnoreCase)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void PictureBox_APdf_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files.Length > 0 &&
                        (files[0].EndsWith(".doc", StringComparison.OrdinalIgnoreCase) ||
                         files[0].EndsWith(".docx", StringComparison.OrdinalIgnoreCase)))
                    {
                        // Puedes realizar una acción específica con el archivo de Word, como abrirlo en Word
                        System.Diagnostics.Process.Start(files[0]);
                    }
                    else
                    {
                        MessageBox.Show("El archivo arrastrado no es un documento de Word.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo procesar el documento: " + ex.Message);
                }
            }
        }

        //_________________________________________________________________________________
        private void PictureBox_AWord_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files.Length > 0 && files[0].EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        // Puedes realizar una acción específica con el archivo PDF, como abrirlo en un visor de PDF
                        System.Diagnostics.Process.Start(files[0]);
                    }
                    else
                    {
                        MessageBox.Show("El archivo arrastrado no es un PDF.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo procesar el documento: " + ex.Message);
                }
            }
        }


        private void ActualizarControles()
        {
            // Si el RadioButton Pdf está marcado
            if (radioButton_Pdf.Checked)
            {
                ActualizarPictureBox(pictureBox_APdf, true);  // Habilita PictureBox Pdf
                ActualizarPictureBox(pictureBox_AWord, false); // Deshabilita PictureBox Word
                btn_Convertir.Enabled = true; // Habilita el botón
            }
            // Si el RadioButton Word está marcado
            else if (radioButton_Word.Checked)
            {
                ActualizarPictureBox(pictureBox_APdf, false);  // Deshabilita PictureBox Pdf
                ActualizarPictureBox(pictureBox_AWord, true);  // Habilita PictureBox Word
                btn_Convertir.Enabled = true; // Habilita el botón
            }
            // Si ninguno de los dos RadioButton está marcado
            else
            {
                ActualizarPictureBox(pictureBox_APdf, false);  // Deshabilita ambos PictureBox
                ActualizarPictureBox(pictureBox_AWord, false);
                btn_Convertir.Enabled = false; // Deshabilita el botón
            }
        }
        //---------------------------------------------------------------------------------

        private bool IsPictureBoxLoaded(PictureBox pictureBox)
        {
            // Verifica si el PictureBox tiene una imagen cargada
            return pictureBox.Image != null;
        }

        // Este método se llamará cuando cambie el estado de cualquiera de los RadioButtons
        private void radioButton_Pdf_CheckedChanged(object sender, EventArgs e)
        {

            ActualizarControles();
            if (radioButton_Pdf.Checked)
            {
                // Si hay un archivo cargado en el PictureBox del Word
                if (IsPictureBoxLoaded(pictureBox_AWord))
                {
                    // Mostrar mensaje de advertencia y revertir la selección
                 MessageBox.Show("Ya has cargado un archivo para convertir a WORD. No puedes cambiar sin eliminar el archivo.",
                                    "Advertencia de Cambio",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    radioButton_Pdf.Checked = false;
                    ActualizarPictureBox(pictureBox_APdf, false);  // Deshabilita PictureBox Pdf
                    ActualizarPictureBox(pictureBox_AWord, true);  // Habilita PictureBox Word
                    radioButton_Word.Checked = true;
                    pictureBox_AWord.BackColor = Color.LightGreen;
                    btn_Convertir.Enabled = true;
                }
                else
                {
                    // Habilitar el PictureBox para PDF     
                    pictureBox_APdf.Enabled = true;
                    pictureBox_AWord.Enabled = false;
                }

            }
        }

        private void radioButton_Word_CheckedChanged(object sender, EventArgs e)
        {

            ActualizarControles();
            if (radioButton_Word.Checked)
            {
                // Si hay un archivo cargado en el PictureBox del pdf
                if (IsPictureBoxLoaded(pictureBox_APdf))
                {
                    // Mostrar mensaje de advertencia y revertir la selección
                    MessageBox.Show("Ya has cargado un archivo para convertir a PDF. No puedes cambiar sin eliminar el archivo.",
                                       "Advertencia de Cambio",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                    radioButton_Word.Checked = false;
                    ActualizarPictureBox(pictureBox_APdf, true);  // Deshabilita PictureBox Pdf
                    ActualizarPictureBox(pictureBox_AWord, false);  // Habilita PictureBox Word
                    radioButton_Pdf.Checked = true;
                    pictureBox_APdf.BackColor = Color.LightGreen;
                    btn_Convertir.Enabled = true;
                }
                else
                {
                    // Habilitar el PictureBox para PDF
                    pictureBox_AWord.Enabled = true;
                    pictureBox_APdf.Enabled = false;

                }
               
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

        //---------------------------------------------------------------------------------------------
        // Método para estilizar el botón según si está habilitado o deshabilitado
        bool botonPresionado = false; // Variable para controlar el estado del botón

        protected void EstiloBotonConvertir(Button boton)
        {
            Size originalSize = boton.Size;
            System.Drawing.Point originalLocation = boton.Location;

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
                    path.AddArc(new System.Drawing.Rectangle(0, 0, bordeRadio, bordeRadio), 180, 90);
                    path.AddArc(new System.Drawing.Rectangle(boton.Width - bordeRadio - 1, 0, bordeRadio, bordeRadio), 270, 90);
                    path.AddArc(new System.Drawing.Rectangle(boton.Width - bordeRadio - 1, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 0, 90);
                    path.AddArc(new System.Drawing.Rectangle(0, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 90, 90);
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

                int incremento = 10;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new System.Drawing.Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

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

        private void btn_EliminarArchivo_Click(object sender, EventArgs e)
        {
            radioButton_Pdf.Checked = false; // Desmarcar el CheckBox
            radioButton_Word.Checked = false; // Desmarcar el CheckBox

            // Eliminar la imagen cargada en el PictureBox
            if (pictureBox_APdf != null && pictureBox_APdf.Image != null)
            {
                pictureBox_APdf.Image.Dispose();  // Liberar los recursos de la imagen actual
                pictureBox_APdf.Image = null;     // Eliminar la imagen del PictureBox
            }

            // Eliminar la imagen cargada en el PictureBox
            if (pictureBox_AWord != null && pictureBox_AWord.Image != null)
            {
                pictureBox_AWord.Image.Dispose();  // Liberar los recursos de la imagen actual
                pictureBox_AWord.Image = null;     // Eliminar la imagen del PictureBox
            }
        }
        //------------------------------------------------------------------------------------

        // Evento que se dispara cuando el RadioButton_Juzgado cambia su estado
        private void radioButton_Juzgado_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Juzgado.Checked)
            {
                // Limpia el panel de cualquier control agregado previamente
                LimpiarPanelControl();

                // Crea una instancia de AgregarJuzgadoControl
                AgregarJuzgadoControl juzgadoControl = new AgregarJuzgadoControl
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                // Agrega el control al panel
                panel_Control.Controls.Add(juzgadoControl);

                // Ajusta el tamaño del panel_Control al tamaño del UserControl
                panel_Control.AutoScroll = true; // Habilita el scroll si es necesario
                panel_Control.Width = juzgadoControl.Width;
                panel_Control.Height = juzgadoControl.Height;

                // Ajusta el formulario en función del nuevo control agregado
                
                AjustarTamañoFormulario(juzgadoControl.Height, eliminar: false);
              
            }
        }
        // Método para ajustar el tamaño del formulario
       


        // Método para limpiar el panel antes de agregar un nuevo control
        private void LimpiarPanelControl()
        {
            if (panel_Control.Controls.Count > 0)
            {
                // Obtén el control actual que será removido
                Control controlARemover = panel_Control.Controls[panel_Control.Controls.Count - 1];

                // Obtén la altura del control a remover
                int alturaControlRemovido = controlARemover.Height;

                // Remueve el control del panel
                panel_Control.Controls.Clear();

                // Ajusta el tamaño del formulario como si se hubiera eliminado un control
                AjustarTamañoFormulario(alturaControlRemovido, eliminar: true);
            }
        }

        private void radioButton_Fiscalia_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Fiscalia.Checked)
            {
                // Limpia el panel de cualquier control agregado previamente
                LimpiarPanelControl();

                // Crea una instancia de AgregarJuzgadoControl
                AgregarFiscaliaControl fiscaliaControl = new AgregarFiscaliaControl
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                // Agrega el control al panel
                panel_Control.Controls.Add(fiscaliaControl);

                // Ajusta el tamaño del panel_Control al tamaño del UserControl
                panel_Control.AutoScroll = true; // Habilita el scroll si es necesario
                panel_Control.Width = fiscaliaControl.Width;
                panel_Control.Height = fiscaliaControl.Height;

                
                AjustarTamañoFormulario(fiscaliaControl.Height, eliminar: false);

            }
        }

        private void AjustarTamañoFormulario(int alturaControlRemovido, bool eliminar = false)
        {
            // Calcula la altura del panel_Control
            int alturaNuevoControl = panel_Control.Controls.OfType<Control>().LastOrDefault()?.Height ?? 0;

            // Ajusta el tamaño del formulario en función del tamaño del panel_Control
            int panelControlBottom = panel_Control.Bottom;
            int formHeight = Math.Max(panelControlBottom + 10, this.ClientSize.Height);

            if (eliminar)
            {
                // Si se eliminó un control, reduce el tamaño del formulario y panel1
                formHeight -= alturaControlRemovido;
                panel1.Height -= alturaControlRemovido;
            }
            else
            {
                // Si se agregó un control, incrementa el tamaño del formulario y panel1
                formHeight += alturaNuevoControl;
                panel1.Height += alturaNuevoControl;
            }

            // Ajusta el tamaño del formulario
            this.ClientSize = new Size(this.ClientSize.Width, formHeight);

            // Calcula la posición horizontal para centrar el formulario en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int formWidth = this.ClientSize.Width;
            int leftPosition = (screenWidth - formWidth) / 2;

            // Ajusta la posición y el tamaño del formulario
            this.StartPosition = FormStartPosition.Manual; // Asegura que el formulario no use la posición predeterminada
            this.Location = new System.Drawing.Point(leftPosition, 0); // Centra horizontalmente y coloca en la parte superior

            // Ajusta la posición de panel2
            if (panel2 != null)
            {
                if (eliminar)
                {
                    // Si eliminamos un control, movemos panel2 hacia arriba
                    panel2.Top -= alturaControlRemovido;
                    panel2.Height -= alturaControlRemovido;
                }
                else
                {
                    // Si agregamos un control, movemos panel2 hacia abajo
                    panel2.Top += alturaNuevoControl;
                    panel2.Height += alturaNuevoControl;
                }
            }
        }


        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Llama al método estático Limpiar de la clase LimpiarFormulario
            LimpiarFormulario.Limpiar(this);
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Secretario.SelectedIndex = -1;
            comboBox_Instructor.SelectedIndex = -1;

            // Verifica si hay algún control en el panel
            if (panel_Control.Controls.Count > 0)
            {
                // Remueve el último control agregado en panel_Control
                Control controlARemover = panel_Control.Controls[panel_Control.Controls.Count - 1];

                // Obtén la altura del control a remover
                int alturaControlRemovido = controlARemover.Height;

                // Remueve el control del panel
                panel_Control.Controls.Remove(controlARemover);

                // Reajusta el tamaño y la posición del formulario
                AjustarTamañoFormulario(alturaControlRemovido, eliminar: true);
            }

            // Muestra un mensaje indicando que el formulario fue limpiado
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Convertir_Click(object sender, EventArgs e)
        {
            // Verifica si los PictureBox tienen imágenes cargadas
            if (pictureBox_APdf.Image == null || pictureBox_AWord.Image == null )
            {
                // Muestra un mensaje de advertencia si algún PictureBox no tiene imagen
                MessageBox.Show("Debe primero cargar el archivo que desea convertir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
           
                // ConvertirImagen();
            }
        }
    }
}

