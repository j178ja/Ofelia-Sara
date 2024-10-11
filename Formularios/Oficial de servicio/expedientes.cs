using Microsoft.Office.Interop.Word;
using Ofelia_Sara.general.clases;
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
using System.Linq;
using Spire.Doc.Documents;
using System.Collections.Generic;
using Clases.Texto;
using Clases.Botones;
using Clases.GenerarDocumentos;
using Clases.Reposicon_paneles;
using Ofelia_Sara.Formularios;
using Controles.Controles;
using System.ComponentModel;
using Controles.Controles.Reposicionar_paneles.Expedientes;




namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Expedientes : BaseForm
    {
        private string rutaArchivoPdf;
        private string rutaArchivoWord;


        public Expedientes()
        {
            InitializeComponent();

            //Color customBorderColor = Color.FromArgb(0, 154, 174);
            // panel1.ApplyRoundedCorners( panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            panel_ControlesInferiores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            groupBox_TextosConvertidos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            panel_ConversorDocumentos.AutoSize = true;
            panel_ConversorDocumentos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_ConversorDocumentos.AutoScroll = true;

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

            // Inicialmente oculta el GroupBox
            groupBox_TextosConvertidos.Visible = false;

            AgregarRadioButtonALosPaneles();

            Fecha_Instruccion.SelectedDate = DateTime.Now;//actualizar fecha
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

                            // Cambiar el color de fondo del PictureBox
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
                panel_Control.Width = fiscaliaControl.Width;
                panel_Control.Height = fiscaliaControl.Height;

                AjustarTamañoFormulario(fiscaliaControl.Height, eliminar: false);

            }
        }
        //----------------------------------------------------------------------------------------------





        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Llama al método estático Limpiar de la clase LimpiarFormulario
            LimpiarFormulario.Limpiar(this);
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Secretario.SelectedIndex = -1;
            comboBox_Instructor.SelectedIndex = -1;
            groupBox_TextosConvertidos.Visible = false;

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
                MessageBox.Show("Error al convertir el archivo de PDF a Word: " + ex.Message);
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
                MessageBox.Show("Error al convertir el archivo de Word a Pdf: " + ex.Message);
            }
        }
        //----------------BOTON CONVERTIR-----------------------------
        // Variable global para mantener la referencia del RadioButton seleccionado
        private RadioButton radioButtonSeleccionado = null;
        // HashSet para almacenar los hashes de los archivos convertidos
        HashSet<string> archivosConvertidos = new HashSet<string>();


        private void btn_Convertir_Click(object sender, EventArgs e)
        {
            // Verifica si se ha cargado un archivo PDF o Word
            if (string.IsNullOrEmpty(rutaArchivoPdf) && string.IsNullOrEmpty(rutaArchivoWord))
            {
                // Muestra un mensaje si no se ha seleccionado ningún archivo
                MessageBox.Show("Para realizar la conversión primero debe seleccionar un archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método para evitar la conversión
            }

            // Verifica si la ruta del archivo PDF no es nula o vacía
            if (!string.IsNullOrEmpty(rutaArchivoPdf))
            {
                // Obtener el hash del archivo PDF
                string hashArchivoPdf = ObtenerHashArchivo(rutaArchivoPdf);

                // Verificar si el archivo PDF ya ha sido convertido
                if (archivosConvertidos.Contains(hashArchivoPdf))
                {
                    MessageBox.Show("Este archivo PDF ya ha sido convertido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // *** Convertir el archivo PDF a Word ***
                string rutaArchivoWordConvertido = Path.ChangeExtension(rutaArchivoPdf, ".docx");
                ConvertirPdfAWord(rutaArchivoPdf, rutaArchivoWordConvertido);

                // Mostrar el archivo Word convertido en el panel
                MostrarArchivoConvertidoEnPanel(rutaArchivoWordConvertido, "Word");

                // Añadir el hash al HashSet de archivos convertidos
                archivosConvertidos.Add(hashArchivoPdf);
            }

            // Verifica si la ruta del archivo Word no es nula o vacía
            if (!string.IsNullOrEmpty(rutaArchivoWord))
            {
                // Obtener el hash del archivo Word
                string hashArchivoWord = ObtenerHashArchivo(rutaArchivoWord);

                // Verificar si el archivo Word ya ha sido convertido
                if (archivosConvertidos.Contains(hashArchivoWord))
                {
                    MessageBox.Show("Este archivo Word ya ha sido convertido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // *** Convertir el archivo Word a PDF ***
                string rutaArchivoPdfConvertido = Path.ChangeExtension(rutaArchivoWord, ".pdf");
                ConvertirWordAPdf(rutaArchivoWord, rutaArchivoPdfConvertido);

                // Mostrar el archivo PDF convertido en el panel
                MostrarArchivoConvertidoEnPanel(rutaArchivoPdfConvertido, "PDF");

                // Añadir el hash al HashSet de archivos convertidos
                archivosConvertidos.Add(hashArchivoWord);
            }

            // Verifica si el groupBox está oculto y lo hace visible
            if (!groupBox_TextosConvertidos.Visible)
            {
                groupBox_TextosConvertidos.Visible = true;
            }


            // Limpia la referencia al RadioButton seleccionado al inicio
            radioButtonSeleccionado = null;

            // Agrega los RadioButton a los Paneles y asigna el manejador de eventos
            AgregarRadioButtonALosPaneles();

            this.Top = 0; // Posicionar el formulario en la parte superior de la pantalla

            // Ajustar altura del formulario y posición de controles inferiores

            AjustarPosicionControlesInferiores();
            AjustarAlturaPaneles();
        }


        // Método para calcular el hash del archivo
        private string ObtenerHashArchivo(string rutaArchivo)
        {
            if (string.IsNullOrEmpty(rutaArchivo))
            {
                throw new ArgumentNullException(nameof(rutaArchivo), "La ruta de acceso no puede ser nula o vacía.");
            }

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(rutaArchivo))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        private void AgregarRadioButtonALosPaneles()
        {
            // Limpia los RadioButton existentes para evitar duplicados
            foreach (Control control in groupBox_TextosConvertidos.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control c in panel.Controls.OfType<RadioButton>().ToList())
                    {
                        panel.Controls.Remove(c);
                        c.Dispose(); // Liberar recursos
                    }
                }
            }

            foreach (Control control in groupBox_TextosConvertidos.Controls)
            {
                if (control is Panel panel)
                {
                    // Crea un nuevo RadioButton
                    RadioButton radioButton = new RadioButton
                    {
                        Location = new System.Drawing.Point(panel.Width - 45, 6),
                        AutoSize = true
                    };
                    // Asigna el manejador de eventos CheckedChanged
                    radioButton.CheckedChanged += RadioButton_Convertido_CheckedChanged;
                    panel.Controls.Add(radioButton);
                }
            }
        }

        private void RadioButton_Convertido_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Checked)
            {
                // Si hay un RadioButton seleccionado, desmárcalo
                if (radioButtonSeleccionado != null && radioButtonSeleccionado != radioButton)
                {
                    radioButtonSeleccionado.Checked = false;
                }
                // Actualiza la referencia del RadioButton seleccionado
                radioButtonSeleccionado = radioButton;
            }
        }


        //--------------------para mostrar el archivo en el panel-------------------------------
        private void MostrarArchivoConvertidoEnPanel(string rutaArchivo, string tipoArchivo)
        {

            Panel panelArchivo = new Panel
            {
                Width = groupBox_TextosConvertidos.Width - 20, // Ajusta el ancho para dar espacio al borde del GroupBox
                Height = 25, // Ajusta la altura del panel
                Padding = new Padding(5),
                Margin = new Padding(5),
                BackColor = ObtenerColorDeFondo(tipoArchivo, groupBox_TextosConvertidos.Controls.Count)
            };

            // Configurar la posición del panel
            int panelCount = groupBox_TextosConvertidos.Controls.OfType<Panel>().Count(); // Cuenta los paneles existentes
            int verticalOffset = 20 + (panelCount * (panelArchivo.Height));

            // Asigna la ubicación calculada
            panelArchivo.Location = new System.Drawing.Point(10, verticalOffset);

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

            LinkLabel linkArchivo = new LinkLabel
            {
                Text = Path.GetFileName(rutaArchivo), // Muestra solo el nombre del archivo
                Location = new System.Drawing.Point(90, 3), // Posición del link en el panel
                AutoSize = false, // Desactivar el ajuste automático del tamaño
                Width = 400, // Establece un ancho fijo para el LinkLabel
                Height = 20, // Fija una altura adecuada para el LinkLabel
                Tag = rutaArchivo // Guarda la ruta completa en el Tag
            };

            // Evento para abrir el archivo cuando se hace clic en el link
            linkArchivo.LinkClicked += (s, ev) =>
            {
                LinkLabel link = s as LinkLabel;
                if (link != null && !string.IsNullOrEmpty(link.Tag as string))
                {
                    try
                    {
                        // Abre el archivo con la aplicación predeterminada del sistema
                        System.Diagnostics.Process.Start(link.Tag as string);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo abrir el archivo: " + ex.Message);
                    }
                }

            };

            // Mostrar el nombre completo en un Tooltip
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(linkArchivo, Path.GetFileName(rutaArchivo));

            // Habilitar el desplazamiento (scroll) si el texto es más largo que el ancho del LinkLabel
            linkArchivo.MouseWheel += (s, e) =>
            {
                LinkLabel link = s as LinkLabel;
                if (link != null)
                {
                    // Desplazar el texto horizontalmente usando la rueda del mouse
                    link.Left += (e.Delta > 0) ? 10 : -10; // Mueve el texto a la izquierda o derecha
                }
            };

            // Agrega el LinkLabel al panel
            panelArchivo.Controls.Add(linkArchivo);



            // Agrega un radiobutton para seleccionar el archivo
            RadioButton radioButton = new RadioButton
            {
                Location = new System.Drawing.Point(panelArchivo.Width - 45, 6),
                AutoSize = true
            };
            panelArchivo.Controls.Add(radioButton);

            int nuevoHeight = panelCount * 25 + 50; // Altura total = altura del panel * número de paneles + margen adicional
            groupBox_TextosConvertidos.Height = nuevoHeight;
            // Agrega el panel al groupBox
            groupBox_TextosConvertidos.Controls.Add(panelArchivo);
        }
        //--------------------para alternar los colores dependiendo de si es word o pdf y si es par o impar--------
        private Color ObtenerColorDeFondo(string tipoArchivo, int index)
        {
            // Determinar el color de fondo basado en el tipo de archivo y el índice
            if (tipoArchivo == "PDF")
            {
                return index % 2 == 0 ? Color.Salmon : Color.Tomato;
            }
            else if (tipoArchivo == "Word")
            {
                return index % 2 == 0 ? Color.LightSkyBlue : Color.PowderBlue;
            }
            else
            {
                return Color.LightGray; // Color predeterminado si el tipo de archivo no es reconocido
            }
        }
        //----------------------------------------------------------------------
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
                    // Confirmar antes de eliminar el panel
                    var resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este archivo?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Obtener la altura del panel antes de eliminarlo
                        int alturaPanelRemovido = panelContenedor.Height;

                        // Obtener el hash del archivo desde el Tag del panel
                        string hashArchivo = panelContenedor.Tag as string;



                        // Elimina el panel del formulario o contenedor
                        panelContenedor.Dispose(); // Eliminar el panel

                        // Reposicionar los paneles restantes
                        ReposicionarPanelesRestantes();

                        // Ajustar el tamaño del groupBox y el formulario
                        AjustarAlturaGroupBoxYFormulario(alturaPanelRemovido, eliminar: true);
                    }
                }
            }
        }


        private void ReposicionarPanelesRestantes()
        {
            int nuevaPosicionY = 20; // Margen superior para el primer panel
            foreach (Control control in groupBox_TextosConvertidos.Controls)
            {
                if (control is Panel)
                {
                    // Ajustar la posición vertical del panel
                    control.Location = new System.Drawing.Point(control.Location.X, nuevaPosicionY);

                    // Incrementar la posición para el siguiente panel
                    nuevaPosicionY += control.Height;
                }
            }
        }

        private void AjustarAlturaGroupBoxYFormulario(int alturaPanelRemovido, bool eliminar)
        {
            // Ajustar la altura del groupBox basado en los paneles que quedan
            int nuevaAlturaGroupBox = groupBox_TextosConvertidos.Controls.Cast<Control>()
                                    .Where(c => c is Panel)
                                    .Sum(c => c.Height + 10); // 10 píxeles de margen entre paneles

            // Ajustar la altura del groupBox
            groupBox_TextosConvertidos.Height = nuevaAlturaGroupBox + 20; // Añadir margen inferior de 20

            // Ajustar la posición del panel_ControlesInferiores
            AjustarPosicionControlesInferiores();

            AjustarAlturaPaneles();
        }
        //----------------------------------------------------------------------------------------------------------

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
        //----------------------------------------------------------------------------------
        public void AjustarTamañoFormulario(int alturaControlRemovido, bool eliminar = false)
        {
            // Calcula la altura del nuevo control agregado al panel_Control
            int alturaNuevoControl = panel_Control.Controls.OfType<Control>().LastOrDefault()?.Height ?? 0;

            // Ajusta el tamaño del formulario en función del tamaño del panel_Control
            int panelControlBottom = panel_Control.Bottom;
            int formHeight = Math.Max(panelControlBottom + 10, this.ClientSize.Height); // Añade un margen opcional de 10 píxeles

            // Ajustar la altura del formulario y panel1 según si se agrega o se elimina un control
            if (eliminar)
            {
                // Si se eliminó un control, reduce el tamaño del formulario y panel1
                formHeight -= alturaControlRemovido;
                panel1.Height -= (alturaControlRemovido); // Reducir la altura y restar 5 unidades a panel1
            }
            else
            {
                // Si se agregó un control, incrementa el tamaño del formulario y panel1
                formHeight += alturaNuevoControl;
                panel1.Height += (alturaNuevoControl); // Aumentar la altura y sumar 5 unidades a panel1
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

            // Ajusta la posición de panel2 con un espacio adicional
            int espacioEntreControlYPanel2 = 5; // Espacio adicional en píxeles entre el control y panel2
            if (panel_ConversorDocumentos != null)
            {
                if (eliminar)
                {
                    // Si eliminamos un control, movemos panel2 hacia arriba
                    panel_ConversorDocumentos.Top -= (alturaControlRemovido + espacioEntreControlYPanel2);
                    panel_ConversorDocumentos.Height -= (alturaControlRemovido + espacioEntreControlYPanel2);
                }
                else
                {
                    // Si agregamos un control, movemos panel2 hacia abajo
                    panel_ConversorDocumentos.Top += (alturaNuevoControl + espacioEntreControlYPanel2);
                    panel_ConversorDocumentos.Height += (alturaNuevoControl + espacioEntreControlYPanel2);
                }
            }
        }

        //-----AJUSTAR POSICIONAMIENTO DE PANELES
        //permite que se visualice completo textos convertidos
        private void AjustarPosicionControlesInferiores()
        {
            int nuevaPosicionY = groupBox_TextosConvertidos.Bottom + 5; // Añadir un pequeño margen de separación
            panel_ControlesInferiores.Location = new System.Drawing.Point(panel_ControlesInferiores.Location.X, nuevaPosicionY);
        }

        private void AjustarAlturaPaneles()
        {


            //// Ajustar la altura del panel_ConversorDocumentos basado en el groupBox y panel_ControlesInferiores
            //panel_ConversorDocumentos.Height = groupBox_TextosConvertidos.Bottom  + panel_ControlesInferiores.Height+5;

            //// Reposicionar panel_ControlesInferiores debajo del groupBox_TextosConvertidos
            //panel_ControlesInferiores.Top = groupBox_TextosConvertidos.Bottom + 5;

            //// Ajustar la altura de panel1 para contener a panel_ConversorDocumentos
            //panel1.Height = panel_ConversorDocumentos.Bottom + 5;

            //// Ajustar la altura del formulario para contener a panel1
            //this.Height = panel1.Bottom + 5;
        }



        private void Expedientes_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Complete los datos requeridos para generar el documento EXPEDIENTE.", "OFELIA-SARA  Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

     

   
        //------------------------------------------------------------------------------------------------
        //   METODO PARA OBTENER DATOS DEL FORMULARIO

        public Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>();

            // Añadimos los valores de los controles al diccionario
            datosFormulario.Add("Nombre", textBox_Caratula.Text);  // "Nombre" es el marcador en Word
            datosFormulario.Add("Apellido", textBox_Causante.Text);
            datosFormulario.Add("Instructor", comboBox_Instructor.SelectedItem.ToString());  // Ajusté los nombres de las claves para ser únicos
            datosFormulario.Add("Secretario", comboBox_Secretario.SelectedItem.ToString());
            datosFormulario.Add("Dependencia", comboBox_Dependencia.SelectedItem.ToString());
            datosFormulario.Add("Fecha_Instruccion", Fecha_Instruccion.SelectedDate.ToString("dd/MM/yyyy"));

            return datosFormulario;
        }
        //------------------------------------------------------------------------------------
        private bool ValidarDatosFormulario()
        {
            // Verificar si los campos están completos
            if (string.IsNullOrWhiteSpace(textBox_Causante.Text) ||
                comboBox_Instructor.SelectedItem == null ||
                comboBox_Secretario.SelectedItem == null ||
                comboBox_Dependencia.SelectedItem == null ||
                Fecha_Instruccion.SelectedDate == null)

            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return false; // Indica que la validación falló
            }
            return true; // Indica que la validación fue exitosa
        }


        //------------------------------------------------------------------------------------
        // Método para manejar el evento de impresión
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            // Llamar al método de validación
            if (!ValidarDatosFormulario())
            {
                return; // Detener el proceso si la validación falla
            }

            // Usar FolderBrowserDialog para obtener la ruta donde el usuario quiere guardar los documentos
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Seleccione la carpeta donde desea guardar los documentos generados";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Ruta donde el usuario quiere guardar los documentos
                    string rutaCarpetaSalida = folderBrowserDialog.SelectedPath;

                    // Obtener el texto de textBox_Causante y formar el nombre de la carpeta
                    string nombreCarpeta = $"Exp {textBox_Causante.Text}";
                    string rutaSubcarpeta = Path.Combine(rutaCarpetaSalida, nombreCarpeta);

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(rutaSubcarpeta))
                    {
                        Directory.CreateDirectory(rutaSubcarpeta);
                    }

                    // rutas de las plantillas-->DEBEN REEMPLASARSE A RUTAS RELATIVAS
                    string rutaPlantillaRecepcion = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\DECRETO RECEPCION EXPEDIENTE.docx";
                    string rutaPlantillaCierre = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\DECRETO CIERRE EXPEDIENTE.docx";
                    string rutaPlantillaNotificacion = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\NOTIFICACION EXPEDIENTE.docx";

                    // Obtener los datos del formulario
                    var datosFormulario = ObtenerDatosFormulario();

                    // Generar cada documento con su respectiva plantilla y guardarlo en la carpeta
                    GeneradorDocumentos generador = new GeneradorDocumentos();
                    generador.GenerarYGuardarDocumento(rutaPlantillaRecepcion, rutaSubcarpeta, "DECRETO RECEPCION", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaCierre, rutaSubcarpeta, "DECRETO CIERRE", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaNotificacion, rutaSubcarpeta, "NOTIFICACION", datosFormulario);

                    // Mostrar mensaje de éxito
                    // MessageBox.Show("Los documentos han sido generados correctamente.");

                    MensajeCargarImprimir mensajeCargarImprimir = new MensajeCargarImprimir();
                    mensajeCargarImprimir.ShowDialog();

                    // Abrir la ubicación de la carpeta generada
                    System.Diagnostics.Process.Start("explorer.exe", rutaSubcarpeta);
                }
            }
        }

    

    }
}
  



