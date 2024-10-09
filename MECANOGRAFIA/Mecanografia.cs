using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MECANOGRAFIA.Clases;
using DocumentFormat.OpenXml.Packaging; 
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace MECANOGRAFIA
{

    
    public partial class Mecanografia : Form
    {
        private Mecano _mecano;
        public Mecanografia()
        {
            InitializeComponent();
           System.Drawing.Color customBorderColor = System.Drawing.Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 25, borderSize: 15, borderColor: customBorderColor);
            panel_Especificaciones.Visible = false;
            panel_Manos.Visible = false;
            Texto_Tipear.Visible = false;
            btn_Iniciar.Visible = false;
            btn_Detener.Visible = false;

            //para redondear dedos
            RedondearPanel.AplicarBordesRedondeados(panel_PulgarDerecho, 20,10);
            RedondearPanel.AplicarBordesRedondeados(panel_IndiceDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MayorDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_AnularDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MeniqueDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_PulgarIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_IndiceIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MayorIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_AnularIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MeniqueIzquierdo, 20, 10);

            Texto_Tipear.Enter += Texto_Tipear_Enter;

            // Obtener todos los botones que forman parte del teclado
            Button[] tecladoButtons = { btn_A, btn_B, btn_C, btn_D, btn_E, btn_F, btn_G, btn_H, btn_I, btn_J,
                btn_K, btn_L,btn_M,btn_N,btn_Ñ,btn_O,btn_P,btn_Q,btn_R,btn_S,btn_T,btn_U,btn_V,btn_W,btn_X,
                btn_Y,btn_Z,btn_1,btn_2,btn_3,btn_4,btn_5,btn_6,btn_7,btn_8,btn_9,btn_0 }; // Agrega todos tus botones aquí

            foreach (var button in tecladoButtons)
            {
                button.Enabled = false; // Deshabilita cada botón
            }

            _mecano = new Mecano(Texto_Tipear, tecladoButtons); // Inicializa Mecano
  
        }

        private void Mecanografia_Load(object sender, EventArgs e)
        {
            _mecano.StartTypingTest(); // Comienza la prueba de escritura

        }
        private void Btn_AgregarArchivo_Click(object sender, EventArgs e)
        {
           
                panel_Especificaciones.Visible = true;
                pictureBox_SelectArchivo.Visible = true;
                btn_Detener.Visible = true;
                btn_Iniciar.Visible = true;
     
        }
       
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Establecer el color del borde (LightGreen) y el grosor del borde (3 píxeles)
            System.Drawing.Color borderColor = System.Drawing.Color.LightGreen;
            int borderWidth = 5;

            // Dibujar el borde
            System.Windows.Forms.Control pictureBox = sender as System.Windows.Forms.Control;
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
                {
                }
                // Alinear el borde dentro del control
                e.Graphics.DrawRectangle(pen,new Rectangle(0, 0, pictureBox.Width, pictureBox.Height ));
            }
        }



        private void PictureBox_SelectArchivo_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            // Verifica que el PictureBox esté habilitado
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Configurar el filtro para permitir solo archivos .docx
                    openFileDialog.Filter = "Archivos de Word (*.docx)|*.docx";
                    openFileDialog.Title = "Selecciona un archivo WORD";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Cambiar la imagen del PictureBox para indicar que el archivo fue cargado
                            pictureBox.Image = Properties.Resources.doc;
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            // Asociar el evento Paint al PictureBox
                            pictureBox_SelectArchivo.Paint += new PaintEventHandler(PictureBox_Paint);
                            pictureBox.BackColor = SystemColors.GradientInactiveCaption;
                            pictureBox.Width = 150;
                            pictureBox.Location = new Point(panel_Especificaciones.Right - 200, panel_Especificaciones.Top - 25);

                            // Establecer el color de fondo del panel
                            panel_Especificaciones.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);

                            // Array de textos fijos para los labels
                            string[] textosLabels = { "Nombre Archivo:", "Cantidad de palabras:", "Cantidad de caracteres:" };

                            // Usar la clase ContadorArchivo para contar palabras y caracteres
                            ContadorArchivo contador = new ContadorArchivo();
                            (int cantidadPalabras, int cantidadCaracteres) = contador.ContarPalabrasYCaracteresDocx(openFileDialog.FileName);

                            // Crear un array con los valores a mostrar
                            string[] valores = {
                        Path.GetFileName(openFileDialog.FileName),  // Nombre del archivo
                        cantidadPalabras.ToString(),                 // Cantidad de palabras
                        cantidadCaracteres.ToString()                // Cantidad de caracteres
                    };

                            // Establecer el tamaño de letra y color
                            float tamanoLetra = 12f;
                            System.Drawing.Color colorLetraTexto = System.Drawing.Color.Black;
                            System.Drawing.Color colorLetraValor = System.Drawing.Color.White;

                            FontStyle estiloTexto = FontStyle.Bold | FontStyle.Underline;

                            // Agregar los labels al panel
                            for (int i = 0; i < textosLabels.Length; i++)
                            {
                                // Crear un nuevo Label
                                Label labelTexto = new Label();
                                labelTexto.Text = textosLabels[i];
                                labelTexto.AutoSize = true;
                                labelTexto.Location = new Point(10, 10 + (i * 30));
                                labelTexto.Font = new System.Drawing.Font(labelTexto.Font.FontFamily, tamanoLetra, estiloTexto);
                                labelTexto.ForeColor = colorLetraTexto;
                                panel_Especificaciones.Controls.Add(labelTexto);

                                // Crear un nuevo Label para el valor
                                Label labelValor = new Label();
                                labelValor.Text = valores[i];
                                labelValor.AutoSize = true;
                                labelValor.Location = new Point(labelTexto.Location.X + labelTexto.Width + 10, labelTexto.Location.Y);
                                labelValor.Font = new System.Drawing.Font(labelValor.Font.FontFamily, tamanoLetra, FontStyle.Regular);
                                labelValor.ForeColor = colorLetraValor;

                                // Agregar el Label de valor al Panel
                                panel_Especificaciones.Controls.Add(labelValor);
                            }

                            // Leer el contenido del archivo Word
                            using (WordprocessingDocument doc = WordprocessingDocument.Open(openFileDialog.FileName, false))
                            {
                                string contenido = doc.MainDocumentPart.Document.Body.InnerText;

                                // Mostrar el contenido en el RichTextBox
                                Texto_Tipear.Text = contenido; // Asegúrate de que el nombre del RichTextBox sea correcto
                               
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo cambiar la imagen del PictureBox: " + ex.Message);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------------------
        //para que no puedad editar el rich sin que se atenue
        private void Texto_Tipear_Click(object sender, EventArgs e)
        {
            // Evitar que el usuario haga clic en el RichTextBox
            Texto_Tipear.Select(0, 0); // Desmarca cualquier texto
        }

        private void Texto_Tipear_Enter(object sender, EventArgs e)
        {
            // Evitar que el RichTextBox reciba el foco
            this.ActiveControl = null; // Establecer el control activo en null
        }

        private void Texto_Tipear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evitar cualquier entrada de teclado
            e.Handled = true;
        }
        //----------------------------------------------------------------

        private void Btn_Iniciar_Click(object sender, EventArgs e)
        {

            panel_Manos.Visible = true;
            Texto_Tipear.Visible =true;
        }

        private void Btn_Detener_Click(object sender, EventArgs e)
        {
            panel_Manos.Visible = false;
            Texto_Tipear.Visible = false;
        }

        private void Btn_Elegir_Click(object sender, EventArgs e)
        {
            // Mostrar el menú en la ubicación del botón
            menu_ElegirArchivos.Show(Btn_Elegir, new Point(0, Btn_Elegir.Height));
        }

        private void AsignacionDocumentos_Click(object sender, EventArgs e)
        {
            panel_Especificaciones.Visible = true;
            btn_Iniciar.Visible = true;
            btn_Detener.Visible = true;
            pictureBox_SelectArchivo.Visible = true;

            // Cambiar la imagen del PictureBox para indicar que el archivo fue cargado
            pictureBox_SelectArchivo.Image = Properties.Resources.doc; // Asegúrate de tener la imagen doc en los recursos
            pictureBox_SelectArchivo.SizeMode = PictureBoxSizeMode.Zoom;

            // Asociar el evento Paint al PictureBox
            pictureBox_SelectArchivo.Paint += new PaintEventHandler(PictureBox_Paint);
            pictureBox_SelectArchivo.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox_SelectArchivo.Width = 150;
            pictureBox_SelectArchivo.Location = new Point(panel_Especificaciones.Right - 170, panel_Especificaciones.Top - 25); //posiciona el picture almargen derecho a 20px


            // Establecer el color de fondo del panel
            panel_Especificaciones.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);

            //agregar los label de especificaciones del documento
            // Array de textos fijos para los labels
            string[] textosLabels = { "Nombre Archivo:", "Cantidad de palabras:", "Cantidad de caracteres:" };
            /*para ejemplo*/
            string[] valores = { "miArchivo.txt", // Valor del nombre del archivo
                                                  "100",           // Valor de cantidad de palabras
                                                  "500"            // Valor de cantidad de caracteres
                            };

            // Establecer el tamaño de letra y color
            float tamanoLetra = 12f; // Tamaño de letra
            System.Drawing.Color colorLetraTexto = System.Drawing.Color.Black; // Color de letra
            System.Drawing.Color colorLetraValor = System.Drawing.Color.White;

            // Establecer el estilo de fuente (negrita y subrayado)
            FontStyle estiloTexto = FontStyle.Bold | FontStyle.Underline;

            // Agregar los labels al panel
            for (int i = 0; i < textosLabels.Length; i++)
            {// Crear un nuevo Label
                Label labelTexto = new Label();
                // Establecer el texto del Label (parte inmutable + parte variable)
                labelTexto.Text = $"{textosLabels[i]}"; // Combina el texto 
                labelTexto.AutoSize = true;

                labelTexto.Location = new Point(10, 10 + (i * 30)); // Espaciado vertical entre los labels
                labelTexto.Font = new System.Drawing.Font(labelTexto.Font.FontFamily, tamanoLetra, estiloTexto);
                labelTexto.ForeColor = colorLetraTexto;


                panel_Especificaciones.Controls.Add(labelTexto);


                // Crear un nuevo Label para el valor
                Label labelValor = new Label();
                labelValor.Text = valores[i];
                labelValor.AutoSize = true;
                labelValor.Location = new Point(labelTexto.Location.X + labelTexto.Width + 10, labelTexto.Location.Y);
                labelValor.Font = new System.Drawing.Font(labelValor.Font.FontFamily, tamanoLetra, FontStyle.Regular);
                labelValor.ForeColor = colorLetraValor;

                // Agregar el Label de valor al Panel
                panel_Especificaciones.Controls.Add(labelValor);
            }
         }
        //-----------------------------------------------------------------------
     


        private void panel_Manos_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
