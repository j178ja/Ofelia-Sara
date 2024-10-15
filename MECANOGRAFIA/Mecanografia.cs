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
using System.Drawing.Drawing2D;


namespace MECANOGRAFIA
{


    public partial class Mecanografia : Form
    {
        private Label alertaLabel; // Variable para el Label de alerta
              
        // Diccionario para mapear letras a paneles
        private Dictionary<char, Panel> letraPanelMap;

        public Mecanografia()
        {
            InitializeComponent();
            System.Drawing.Color customBorderColor = System.Drawing.Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 25, borderSize: 15, borderColor: customBorderColor);

            System.Drawing.Color BorderColorTeclado = System.Drawing.Color.FromArgb(178, 213, 230);
            panel_TecladoBase.ApplyRoundedCorners(panel_TecladoBase, borderRadius: 25, borderSize: 10, borderColor: BorderColorTeclado);

            this.Load += AjustarTamañoForm;//para ajustar el tamaño del formulario

            panel_Especificaciones.Visible = false;
            panel_Manos.Visible = false;
            Texto_Tipear.Visible = false;
            btn_Iniciar.Visible = false;
            btn_Detener.Visible = false;

            //para redondear dedos
            RedondearPanel.AplicarBordesRedondeados(panel_PulgarDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_IndiceDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MayorDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_AnularDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MeniqueDerecho, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_PulgarIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_IndiceIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MayorIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_AnularIzquierdo, 20, 10);
            RedondearPanel.AplicarBordesRedondeados(panel_MeniqueIzquierdo, 20, 10);

            this.KeyPreview = true; // Permitir que el formulario capture las teclas antes que los controles

            // Mapear paneles a letras
            Dictionary<char, Panel> letraPanelMap = new Dictionary<char, Panel>
{
    { '1', panel_MeniqueIzquierdo },
    { '!', panel_MeniqueIzquierdo },
    { 'A', panel_MeniqueIzquierdo },
    { 'Q', panel_MeniqueIzquierdo },
    { 'Z', panel_MeniqueIzquierdo },

    { '2', panel_AnularIzquierdo },
    { '"', panel_AnularIzquierdo },
    { 'S', panel_AnularIzquierdo },
    { 'W', panel_AnularIzquierdo },
    { 'X', panel_AnularIzquierdo },

    { '3', panel_MayorIzquierdo },
    { '#', panel_MayorIzquierdo },
    { 'E', panel_MayorIzquierdo },
    { 'D', panel_MayorIzquierdo },
    { 'C', panel_MayorIzquierdo },


    { '4', panel_IndiceIzquierdo },
    { '5', panel_IndiceIzquierdo },
    { '$', panel_IndiceIzquierdo },
    { '%', panel_IndiceIzquierdo },
    { 'R', panel_IndiceIzquierdo },
    { 'F', panel_IndiceIzquierdo },
    { 'V', panel_IndiceIzquierdo },
    { 'T', panel_IndiceIzquierdo },
    { 'G', panel_IndiceIzquierdo },
    { 'B', panel_IndiceIzquierdo },

    { ' ', panel_PulgarIzquierdo },

    { '7', panel_IndiceDerecho },
    { '6', panel_IndiceDerecho },
    { '/', panel_IndiceDerecho },
    { '&', panel_IndiceDerecho },
    { 'Y', panel_IndiceDerecho },
    { 'H', panel_IndiceDerecho },
    { 'N', panel_IndiceDerecho },
    { 'U', panel_IndiceDerecho },
    { 'J', panel_IndiceDerecho },
    { 'M', panel_IndiceDerecho },

    { '8', panel_MayorDerecho },
    { '(', panel_MayorDerecho },
    { 'I', panel_MayorDerecho },
    { 'K', panel_MayorDerecho },
    { ';', panel_MayorDerecho },
    { ',', panel_MayorDerecho },

    { '9', panel_AnularDerecho },
    { ')', panel_AnularDerecho },
    { 'O', panel_AnularDerecho },
    { 'L', panel_AnularDerecho },
    { ':', panel_AnularDerecho },
    { '.', panel_AnularDerecho },

    { '0', panel_AnularDerecho },
    { '=', panel_AnularDerecho },
    { 'P', panel_AnularDerecho },
    { 'Ñ', panel_AnularDerecho },
    { '-', panel_AnularDerecho },
    { '_', panel_AnularDerecho },

};
        }


        private void Mecanografia_Load(object sender, EventArgs e)
        {
            Texto_Tipear.ReadOnly = true;// richtextbox de solo lectura
            CargarTextoYColorear();// remarca la letra que se debe presionar
            CrearLabelAlerta();//Label que marca error al presionar tecla
        }

        private int currentPosition = 0; // Para llevar seguimiento de la posición actual
        private bool mecanografiaActiva = true;

        private void Mecanografia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtenemos la letra actual
            char letraActual = Texto_Tipear.Text[currentPosition];

            // Verificamos si la tecla presionada coincide con la letra resaltada
            if (e.KeyChar == letraActual)
            {
                // Ocultamos el mensaje de alerta si la tecla es correcta
                alertaLabel.Visible = false;
                // Resaltar el panel del dedo correspondiente
                ResaltarPanelPorLetra(letraActual);
                // Restauramos la letra anterior (negro y sin negrita)
                Texto_Tipear.Select(currentPosition, 1);
                Texto_Tipear.SelectionColor = System.Drawing.Color.Black; // Volvemos a color negro
                Texto_Tipear.SelectionFont = new System.Drawing.Font(Texto_Tipear.Font, FontStyle.Regular); // Estilo normal

                // Avanzamos al siguiente carácter
                currentPosition++;

                // Si todavía hay más caracteres, coloreamos el siguiente en azul y negrita
                if (currentPosition < Texto_Tipear.Text.Length)
                {
                    Texto_Tipear.Select(currentPosition, 1);
                    Texto_Tipear.SelectionColor = System.Drawing.Color.Blue; // Azul
                    Texto_Tipear.SelectionFont = new System.Drawing.Font(Texto_Tipear.Font, FontStyle.Bold); // Negrita
                }

                Texto_Tipear.DeselectAll(); // Quitamos la selección visible
            }
            else
            {
                if (mecanografiaActiva == false)
                {
                    alertaLabel.Visible = false;
                    return;
                }
                else
                {
                    // Mostrar el mensaje de alerta si la tecla es incorrecta
                    alertaLabel.Text = $"Ud ha presionado: {e.KeyChar}";
                    alertaLabel.Visible = true;
                }
            }
        }
      



        private void Btn_AgregarArchivo_Click(object sender, EventArgs e)
        {

            panel_Especificaciones.Visible = true;
            pictureBox_SelectArchivo.Visible = true;
            btn_Detener.Visible = true;
            btn_Iniciar.Visible = true;
            btn_Iniciar.Enabled = false; // Deshabilitar inicialmente
            btn_Detener.Enabled = false;
            panel_Teclado.Location = new Point(21, 193);
            // Ajustar la altura de panel1
            panel1.Height = 380;
            this.Height = panel1.Height + 80;
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
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            }
        }


        private string archivoSeleccionado;
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
                                Texto_Tipear.Text = contenido;
                                CargarTextoYColorear();

                                // *** ASIGNAR EL NOMBRE DEL ARCHIVO SELECCIONADO ***
                                archivoSeleccionado = openFileDialog.FileName;

                                // Llamar a la validación de botones
                                ValidarSeleccionArchivo();
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
        //para que se active btn iniciar solo despues de cargar archivo
        private void ValidarSeleccionArchivo()
        {
            // Habilitar el botón btn_Iniciar si hay un archivo seleccionado
            btn_Iniciar.Enabled = !string.IsNullOrEmpty(archivoSeleccionado);
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


        //----------------------------------------------------------------


        private void Btn_Iniciar_Click(object sender, EventArgs e)
        {
            panel_Manos.Visible = true;
            Texto_Tipear.Visible = true;
            panel_Teclado.Location = new Point(21, 242);
            panel1.Height = 559;
            this.Height = 641;

            btn_Detener.Enabled = true;
        }

        //-------------------------------------------------------------------
        private void Btn_Detener_Click(object sender, EventArgs e)
        {
           
            mecanografiaActiva = false; // Desactivar la mecanografía
            alertaLabel.Visible = false;
            panel_Manos.Visible = false;
            Texto_Tipear.Visible = false;
            panel_Teclado.Location = new Point(21, 193);
            
            // Ajustar la altura de panel1
            panel1.Height = 380;
            this.Height = panel1.Height + 80;
        }


        //-------------------------------------------------------------------------------------
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


        //----------------------------------------------------------------------
        //ajustar tamaño y posicion principal de elementos en el formulario
        private void AjustarTamañoForm(object sender, EventArgs e)
        {
            // Posicionar el panel_Teclado en la ubicación deseada
            panel_Teclado.Location = new Point(21, 34);
            panel1.Height = panel_Teclado.Height + 60;

            // Ajustar la altura del formulario para que sea más alto que panel1
            this.Height = panel1.Height + 80; // Establece la altura del formulario
        }




        private void CargarTextoYColorear()
        {
            // Texto_Tipear la primera letra en azul y negrita
            Texto_Tipear.Select(0, 1); // Seleccionamos la primera letra
            Texto_Tipear.SelectionColor = System.Drawing.Color.Blue; // La coloreamos en azul
            Texto_Tipear.SelectionFont = new System.Drawing.Font(Texto_Tipear.Font, FontStyle.Bold); // Negrita
            Texto_Tipear.DeselectAll(); // Quitamos la selección
        }


        private void CrearLabelAlerta()
        {
            // Inicializamos el Label de alerta
            alertaLabel = new Label();
            alertaLabel.ForeColor = System.Drawing.Color.Red; // Color rojo para el texto
            alertaLabel.Font = new System.Drawing.Font("Arial", 14);
            alertaLabel.Location = new Point(265, 95); // Posición dentro del panel
            alertaLabel.AutoSize = true; // Ajusta el tamaño automáticamente
            alertaLabel.Visible = false; // Inicialmente invisible
            panel_Especificaciones.Controls.Add(alertaLabel); // Añadir al panel
        }
        //---------------------------------------------------------------------

        // Variable para almacenar el último panel resaltado
        private Panel panelResaltadoAnterior = null;

        private void ResaltarPanelPorLetra(char letra)
        {
            // Restablecer el color del panel anterior a su color original, si existe
            if (panelResaltadoAnterior != null)
            {
                panelResaltadoAnterior.BackColor = SystemColors.Control; // Color original del panel
            }

            // Verificar si la letra está en el diccionario
            if (letraPanelMap.TryGetValue(letra, out Panel panelResaltado))
            {
                // Cambiar el color del panel correspondiente a rojo
                panelResaltado.BackColor = System.Drawing.Color.Red; // Color resaltado
                                                      // Almacenar el panel resaltado actual
                panelResaltadoAnterior = panelResaltado;
            }
        }
        private void texto_Tipear_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si hay texto seleccionado
            if (Texto_Tipear.SelectionLength > 0)
            {
                // Obtener el carácter en la posición del cursor
                int cursorPosition = Texto_Tipear.SelectionStart;
                if (cursorPosition > 0 && cursorPosition <= Texto_Tipear.Text.Length)
                {
                    char letraActual = Texto_Tipear.Text[cursorPosition - 1]; // Obtiene el carácter anterior al cursor
                    ResaltarPanelPorLetra(letraActual);
                }
            }
        }

    }
}