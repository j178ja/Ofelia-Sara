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
using Spire.Pdf;
using System.IO;
using Spire.Doc;
using Microsoft.Office.Interop.Word;
using System.Linq;
using Spire.Doc.Documents;




namespace Ofelia_Sara
{
    public partial class Expedientes : BaseForm
    {
        private string rutaArchivoPdf;
        private string rutaArchivoWord;


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




        //---´PARA QUE CONVIERTA ARCHIVOS PDF A WORD-----
        private void PictureBox_AWord_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            // Verifica que el PictureBox esté habilitado
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Configurar el filtro para permitir solo archivos PDF
                    openFileDialog.Filter = "Archivos Word (*.pdf)|*.pdf";
                    openFileDialog.Title = "Selecciona un archivo PDF";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Guardar la ruta del archivo en la variable correspondiente
                            rutaArchivoWord = openFileDialog.FileName;

                            // Cambiar la imagen del PictureBox para indicar que el archivo fue cargado
                            pictureBox.Image = Properties.Resources.pdf; // Asegúrate de tener la imagen pdf en los recursos
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            // Opcional: Cambiar el color de fondo del PictureBox
                            pictureBox.BackColor = Color.LightGreen;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo cambiar la imagen del PictureBox: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void CargarArchivoEnPictureBox(PictureBox pictureBox, ref string rutaArchivo, string filtro, Bitmap icono)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filtro;
                openFileDialog.Title = "Selecciona un archivo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = openFileDialog.FileName; // Guarda la ruta del archivo

                    // Cargar la imagen de recurso para indicar que el archivo fue cargado
                    pictureBox.Image = icono;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.BackColor = Color.LightGreen; // Color de confirmación
                }
            }
        }




        //---´PARA QUE CONVIERTA ARCHIVOS PDF A WORD-----
        private void PictureBox_APdf_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            // Verifica que el PictureBox esté habilitado
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Configurar el filtro para permitir solo archivos PDF
                    openFileDialog.Filter = "Archivos PDF (*.docx)|*.docx";
                    openFileDialog.Title = "Selecciona un archivo WORD";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Guardar la ruta del archivo en la variable correspondiente
                            rutaArchivoPdf = openFileDialog.FileName;

                            // Cambiar la imagen del PictureBox para indicar que el archivo fue cargado
                            pictureBox.Image = Properties.Resources.doc; // Asegúrate de tener la imagen doc en los recursos
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            // Opcional: Cambiar el color de fondo del PictureBox
                            pictureBox.BackColor = Color.LightGreen;
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
              
                boton.ForeColor = Color.White; // Mantiene el texto blanco
                boton.Invalidate(); // Redibuja el botón
            };

            // Llama a Invalidate para asegurarse de que el borde se dibuje inicialmente
            boton.Invalidate();
        }
        //____________________________________________________________________________________
        //-----btn para eliminar archivo en pickturebox

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
        //----------------------------------------------------------------------------------------------
        //----AJUSTAR TAMAÑO Y ´POSICION DEL FORMULARIO DE ACUERDO AL CONTROL AGREGADO----
        private void AjustarTamañoFormulario(int alturaControlRemovido, bool eliminar = false)
        {
            // Calcula la altura del nuevo control agregado al panel_Control
            int alturaNuevoControl = panel_Control.Controls.OfType<Control>().LastOrDefault()?.Height ?? 0;

            // Ajusta el tamaño del formulario en función del tamaño del panel_Control
            int panelControlBottom = panel_Control.Bottom;
            int formHeight = Math.Max(panelControlBottom + 10, this.ClientSize.Height); // Añade un margen opcional de 10 píxeles

            if (eliminar)
            {
                // Si se eliminó un control, reduce el tamaño del formulario y panel1
                formHeight -= alturaControlRemovido;
                panel1.Height -= (alturaControlRemovido ); // Reducir la altura y restar 5 unidades a panel1
            }
            else
            {
                // Si se agregó un control, incrementa el tamaño del formulario y panel1
                formHeight += alturaNuevoControl;
                panel1.Height += (alturaNuevoControl ); // Aumentar la altura y sumar 5 unidades a panel1
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


        //--------------------------------------------------------------------------------------
        //----CONVERSOR DE DOCUMENTOS-------------------

        private void ConvertirWordAPdf(string rutaWord, string archivoConvertido)
        {
            try
            {
                // Crea una instancia del documento de Word
                Spire.Doc.Document documento = new Spire.Doc.Document();

                // Carga el archivo Word
                documento.LoadFromFile(rutaWord);

                // Guarda el documento en formato PDF
                documento.SaveToFile(archivoConvertido, Spire.Doc.FileFormat.PDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir el archivo de Word a PDF: " + ex.Message);
            }
        }

        private void ConvertirPdfAWord(string rutaPdf, string archivoConvertido)
        {
            try
            {
                // Crea una instancia del documento de Word usando Spire.Doc
                Spire.Doc.Document documento = new Spire.Doc.Document();

                // Carga el archivo PDF
                documento.LoadFromFile(rutaPdf, Spire.Doc.FileFormat.PDF);

                // Guarda el documento en formato Word
                documento.SaveToFile(archivoConvertido, Spire.Doc.FileFormat.Docx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir el archivo de PDF a Word: " + ex.Message);
            }
        }
        //----------------BOTON CONVERTIR-----------------------------

        private void btn_Convertir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rutaArchivoPdf))
            {
                string archivoConvertido = "archivo_convertido.docx";
                ConvertirPdfAWord(rutaArchivoPdf, archivoConvertido);
                MostrarArchivoConvertidoEnPanel(rutaArchivoPdf, "PDF", archivoConvertido);
            }

            if (!string.IsNullOrEmpty(rutaArchivoWord))
            {
                string archivoConvertido = "archivo_convertido.pdf";
                ConvertirWordAPdf(rutaArchivoWord, archivoConvertido);
                MostrarArchivoConvertidoEnPanel(rutaArchivoWord, "Word", archivoConvertido);
            }
        }
        //--------------------para mostrar el archivo en el panel-------------------------------
        private void MostrarArchivoConvertidoEnPanel(string rutaArchivoOriginal, string tipoArchivo, string archivoConvertido)
        {
            // Crea un nuevo Panel para mostrar el archivo
            Panel panelArchivo = new Panel
            {
                Width = groupBox_TextosConvertidos.Width ,
                Height = 25,
                Padding = new Padding(5),
                Margin = new Padding(5),
                BackColor = ObtenerColorDeFondo(tipoArchivo, groupBox_TextosConvertidos.Controls.Count)
            };
            // Agrega el ícono del Borrar
            PictureBox iconoBorrar = new PictureBox
            {
                Width = 20,
                Height = 20,
                Image = Properties.Resources.borrar, // Asegúrate de que este recurso está disponible en tus recursos del proyecto
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new System.Drawing.Point(5, 2) // Ubica el ícono en la esquina superior derecha
            };
            // Asocia el manejador de eventos al clic en el ícono de borrar
            iconoBorrar.Click += IconoBorrar_Click;
            // Asocia los manejadores de eventos al hover
            iconoBorrar.MouseEnter += IconoBorrar_MouseEnter;
            iconoBorrar.MouseLeave += IconoBorrar_MouseLeave;
            panelArchivo.Controls.Add(iconoBorrar);

            // Agrega el icono del archivo
            PictureBox icono = new PictureBox
            {
                Width = 50,
                Height = 20,
                Image = tipoArchivo == "PDF" ? Properties.Resources.pdf : Properties.Resources.doc,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new System.Drawing.Point(35, 2)
            };
            panelArchivo.Controls.Add(icono);

            // Agrega el nombre del archivo como un link
            LinkLabel linkArchivo = new LinkLabel
            {
                Text = archivoConvertido,
                Location = new System.Drawing.Point(90, 3),
                AutoSize = true,
                Tag = rutaArchivoOriginal // Guarda la ruta original en el Tag para referencia futura
            };
            linkArchivo.LinkClicked += (s, ev) =>
            {
                // Abre el archivo cuando se hace clic en el link
                LinkLabel link = s as LinkLabel;
                if (link != null && !string.IsNullOrEmpty(link.Tag as string))
                {
                    System.Diagnostics.Process.Start(link.Tag as string);
                }
            };
            panelArchivo.Controls.Add(linkArchivo);

            // Agrega un radiobutton para seleccionar el archivo
            RadioButton radioButton = new RadioButton
            {
                Location = new System.Drawing.Point(panelArchivo.Width - 25, 6),
                AutoSize = true
            };
            panelArchivo.Controls.Add(radioButton);

            // Agrega el panel al groupBox
            groupBox_TextosConvertidos.Controls.Add(panelArchivo);
        }
        //--------------------para alternar los colores dependiendo de si es word o pdf y si es par o impar--------
        private Color ObtenerColorDeFondo(string tipoArchivo, int index)
        {
            // Determinar el color de fondo basado en el tipo de archivo y el índice
            if (tipoArchivo == "PDF")
            {
                return index % 2 == 0 ? Color.LightCoral : Color.DarkRed;
            }
            else if (tipoArchivo == "Word")
            {
                return index % 2 == 0 ? Color.LightSkyBlue : Color.DarkBlue;
            }
            else
            {
                return Color.LightGray; // Color predeterminado si el tipo de archivo no es reconocido
            }
        }

        // Manejador de eventos para el clic en el ícono de borrar
        private void IconoBorrar_Click(object sender, EventArgs e)
        {
            // Obtén el PictureBox que disparó el evento
            PictureBox iconoBorrar = sender as PictureBox;

            if (iconoBorrar != null)
            {
                // Obtén el panel que contiene el PictureBox
                Panel panelContenedor = iconoBorrar.Parent as Panel;

                if (panelContenedor != null)
                {
                    // Confirmar antes de eliminar el panel (opcional)
                    var resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este archivo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Elimina el panel del formulario o contenedor
                        panelContenedor.Dispose(); // También podrías usar panelContenedor.Remove() si el panel está en un contenedor que permite esta operación
                    }
                }
            }
        }


        // Manejador de eventos para el hover (cuando el cursor entra en el PictureBox)
        private void IconoBorrar_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.Width += 3; // Aumenta el ancho en 10 píxeles
                pictureBox.Height += 3; // Aumenta la altura en 10 píxeles
                pictureBox.Cursor = Cursors.Hand;
            }
        }

        // Manejador de eventos para el hover (cuando el cursor sale del PictureBox)
        private void IconoBorrar_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.Width -= 3; // Reduce el ancho en 10 píxeles
                pictureBox.Height -= 3; // Reduce la altura en 10 píxeles
            }
        }
    }
}


