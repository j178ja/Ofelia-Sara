using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases_Libreria.Apariencia;

namespace MECANOGRAFIA
{
    public partial class Mecanografia : Form
    {
        public Mecanografia()
        {
            InitializeComponent();
           Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
            panel_Especificaciones.Visible = false;
            panel_Manos.Visible = false;
            Texto_Tipear.Visible = false;
            btn_Iniciar.Visible = false;
            btn_Detener.Visible = false;
        }

        private void Btn_AgregarArchivo_Click(object sender, EventArgs e)
        {
            if (panel_Especificaciones.Controls.Count > 0)
            {
                panel_Especificaciones.Controls.Clear();
            }
                panel_Especificaciones.Visible = true;
                pictureBox_SelectArchivo.Visible = true;
                btn_Iniciar.Visible = true;
                btn_Detener.Visible = true;
            
        }


        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Establecer el color del borde (LightGreen) y el grosor del borde (3 píxeles)
            Color borderColor = Color.LightGreen;
            int borderWidth = 5;

            // Dibujar el borde
            Control pictureBox = sender as Control;
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
                    // Configurar el filtro para permitir solo archivos PDF
                    openFileDialog.Filter = "Seleccionar Archivo (*.docx)|*.docx";
                    openFileDialog.Title = "Selecciona un archivo WORD";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {

                            // Cambiar la imagen del PictureBox para indicar que el archivo fue cargado
                            pictureBox.Image = Properties.Resources.doc; // Asegúrate de tener la imagen doc en los recursos
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                            // Asociar el evento Paint al PictureBox
                            pictureBox_SelectArchivo.Paint += new PaintEventHandler(PictureBox_Paint);
                            pictureBox.BackColor = SystemColors.GradientInactiveCaption;
                            pictureBox.Width = 150;
                            pictureBox.Location = new Point(panel_Especificaciones.Right - 170, panel_Especificaciones.Top - 25); //posiciona el picture almargen derecho a 20px


                            // Establecer el color de fondo del panel
                            panel_Especificaciones.BackColor = Color.FromArgb(180, 180, 180);

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
                            Color colorLetraTexto = Color.Black; // Color de letra
                            Color colorLetraValor = Color.White;

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
                                labelTexto.Font = new Font(labelTexto.Font.FontFamily, tamanoLetra, estiloTexto);
                                labelTexto.ForeColor = colorLetraTexto;


                                panel_Especificaciones.Controls.Add(labelTexto);

                              
                                    // Crear un nuevo Label para el valor
                                    Label labelValor = new Label();
                                    labelValor.Text = valores[i];
                                    labelValor.AutoSize = true;
                                    labelValor.Location = new Point(labelTexto.Location.X + labelTexto.Width + 10, labelTexto.Location.Y);
                                labelValor.Font = new Font(labelValor.Font.FontFamily, tamanoLetra, FontStyle.Regular);
                                    labelValor.ForeColor = colorLetraValor;

                                    // Agregar el Label de valor al Panel
                                    panel_Especificaciones.Controls.Add(labelValor);
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
            panel_Especificaciones.BackColor = Color.FromArgb(180, 180, 180);

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
            Color colorLetraTexto = Color.Black; // Color de letra
            Color colorLetraValor = Color.White;

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
                labelTexto.Font = new Font(labelTexto.Font.FontFamily, tamanoLetra, estiloTexto);
                labelTexto.ForeColor = colorLetraTexto;


                panel_Especificaciones.Controls.Add(labelTexto);


                // Crear un nuevo Label para el valor
                Label labelValor = new Label();
                labelValor.Text = valores[i];
                labelValor.AutoSize = true;
                labelValor.Location = new Point(labelTexto.Location.X + labelTexto.Width + 10, labelTexto.Location.Y);
                labelValor.Font = new Font(labelValor.Font.FontFamily, tamanoLetra, FontStyle.Regular);
                labelValor.ForeColor = colorLetraValor;

                // Agregar el Label de valor al Panel
                panel_Especificaciones.Controls.Add(labelValor);
            }
         }

    }
}
