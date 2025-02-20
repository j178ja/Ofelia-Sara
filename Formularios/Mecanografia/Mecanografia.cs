using DocumentFormat.OpenXml.Packaging;
using Ofelia_Sara.Clases.Mecanografia;
using Ofelia_Sara.Formularios.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Ofelia_Sara.Clases.General.Apariencia;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.General.Mensajes;

namespace Ofelia_Sara.Formularios.Mecanografia


{


    public partial class Mecanografia : BaseForm
    {
        #region VARIABLES
        private Label alertaLabel; // Variable para el Label de alerta
        private Label label_Tiempo; // Label para mostrar el tiempo transcurrido
        // Diccionario para mapear letras a paneles
        private Dictionary<char, PanelesResaltados> letraPanelMap;
        // Variable para almacenar el último panel resaltado
        private PanelesResaltados panelResaltadoAnterior = null;

        private readonly Timer timer;
        private int secondsElapsed = 0; // Para llevar la cuenta de los segundos transcurridos
        private int currentPosition = 0; // Para llevar seguimiento de la posición actual
        private bool mecanografiaActiva = true;
        private int indiceCaracterResaltadoAnterior = -1; // Para llevar el seguimiento del último carácter resaltado
        private string archivoSeleccionado;
        // Variables para almacenar los últimos paneles resaltados
        private readonly Panel panelResaltadoAnteriorMano = null;
        private readonly Panel panelResaltadoAnteriorTeclado = null;// Variable para almacenar el último panel resaltado

        #endregion

        #region CONSTRUCTOR
        public Mecanografia()
        {
            InitializeComponent();
            
            RedondearBordes.Aplicar(panel1,15);
            RedondearBordes.Aplicar(panel_TecladoBase, 25);

           
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
            CrearLabelAlerta();
            CrearLabelTimer();
            // Inicializar el Timer
            timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick; // Evento Tick del Timer

            // Mapa de letras a paneles de manos y teclado virtual
            letraPanelMap = new Dictionary<char, PanelesResaltados>
{
    { '1', new PanelesResaltados (panel_MeniqueIzquierdo,panel_Tecla1 ,label_Tecla1 ) },
    { '!', new PanelesResaltados (panel_MeniqueIzquierdo,panel_Tecla1 ,label_Tecla1 ) },
    { 'A', new PanelesResaltados (panel_MeniqueIzquierdo,panel_TeclaA ,label_TeclaA ) },
    { 'Q', new PanelesResaltados (panel_MeniqueIzquierdo,panel_TeclaQ ,label_TeclaQ ) },
    { 'Z', new PanelesResaltados (panel_MeniqueIzquierdo,panel_TeclaZ ,label_TeclaZ ) },

    { '2', new PanelesResaltados (panel_AnularIzquierdo,panel_Tecla2 ,label_Tecla2  ) },
    { '"', new PanelesResaltados (panel_AnularIzquierdo,panel_Tecla2 ,label_Tecla2  ) },
    { 'S', new PanelesResaltados (panel_AnularIzquierdo,panel_TeclaS ,label_TeclaS  ) },
    { 'W', new PanelesResaltados (panel_AnularIzquierdo,panel_TeclaW ,label_TeclaW  ) },
    { 'X', new PanelesResaltados (panel_AnularIzquierdo,panel_TeclaX ,label_TeclaX  ) },

    { '3', new PanelesResaltados (panel_MayorIzquierdo,panel_Tecla3 ,label_Tecla3   ) },
    { '#', new PanelesResaltados (panel_MayorIzquierdo,panel_Tecla3 ,label_Tecla3   ) },
    { 'E', new PanelesResaltados (panel_MayorIzquierdo,panel_TeclaE ,label_TeclaE   ) },
    { 'D', new PanelesResaltados (panel_MayorIzquierdo,panel_TeclaD ,label_TeclaD   ) },
    { 'C', new PanelesResaltados (panel_MayorIzquierdo,panel_TeclaC ,label_TeclaC   ) },

    { '4', new PanelesResaltados (panel_IndiceIzquierdo,panel_Tecla4 ,label_Tecla4  ) },
    { '5', new PanelesResaltados (panel_IndiceIzquierdo,panel_Tecla5 ,label_Tecla5  ) },
    { '$', new PanelesResaltados (panel_IndiceIzquierdo,panel_Tecla4 ,label_Tecla4  ) },
    { '%', new PanelesResaltados (panel_IndiceIzquierdo,panel_Tecla5 ,label_Tecla5  ) },
    { 'R', new PanelesResaltados (panel_IndiceIzquierdo,panel_TeclaR ,label_TeclaR  ) },
    { 'F', new PanelesResaltados (panel_IndiceIzquierdo,panel_TeclaF ,label_TeclaF  ) },
    { 'V', new PanelesResaltados (panel_IndiceIzquierdo,panel_TeclaV ,label_TeclaV  ) },
    { 'T', new PanelesResaltados (panel_IndiceIzquierdo,panel_TeclaT ,label_TeclaT  ) },
    { 'G', new PanelesResaltados (panel_IndiceIzquierdo,panel_TeclaG ,label_TeclaG  ) },
    { 'B', new PanelesResaltados (panel_IndiceIzquierdo,panel_TeclaB ,label_TeclaB  ) },

    { ' ', new PanelesResaltados (panel_PulgarIzquierdo,panel_TeclaEspacio,label_TeclaEspacio) },

    { '7', new PanelesResaltados (panel_IndiceDerecho, panel_Tecla7,label_Tecla7 ) },
    { '6', new PanelesResaltados (panel_IndiceDerecho, panel_Tecla6,label_Tecla6 ) },
    { '/', new PanelesResaltados (panel_IndiceDerecho, panel_Tecla7,label_Tecla7 ) },
    { '&', new PanelesResaltados (panel_IndiceDerecho, panel_Tecla6,label_Tecla6 ) },
    { 'Y', new PanelesResaltados (panel_IndiceDerecho, panel_TeclaY,label_TeclaY ) },
    { 'H', new PanelesResaltados (panel_IndiceDerecho, panel_TeclaH,label_TeclaH ) },
    { 'N', new PanelesResaltados (panel_IndiceDerecho, panel_TeclaN,label_TeclaN ) },
    { 'U', new PanelesResaltados (panel_IndiceDerecho, panel_TeclaU,label_TeclaU ) },
    { 'J', new PanelesResaltados (panel_IndiceDerecho, panel_TeclaJ,label_TeclaJ ) },
    { 'M', new PanelesResaltados (panel_IndiceDerecho, panel_TeclaM,label_TeclaM ) },

    { '8', new PanelesResaltados (panel_MayorDerecho, panel_Tecla8, label_Tecla8) },
    { '(', new PanelesResaltados (panel_MayorDerecho, panel_Tecla8, label_Tecla8) },
    { 'I', new PanelesResaltados (panel_MayorDerecho, panel_TeclaI, label_TeclaI) },
    { 'K', new PanelesResaltados (panel_MayorDerecho, panel_TeclaK, label_TeclaK) },
    { ';', new PanelesResaltados (panel_MayorDerecho, panel_TeclaComa,label_TeclaComa) },
    { ',', new PanelesResaltados (panel_MayorDerecho, panel_TeclaComa,label_TeclaComa) },

    { '9', new PanelesResaltados (panel_AnularDerecho,panel_Tecla9 ,label_Tecla9 )},
    { ')', new PanelesResaltados (panel_AnularDerecho,panel_Tecla9 ,label_Tecla9)},
    { 'O', new PanelesResaltados (panel_AnularDerecho,panel_TeclaO ,label_TeclaO )},
    { 'L', new PanelesResaltados (panel_AnularDerecho,panel_TeclaL ,label_TeclaL )},
    { ':', new PanelesResaltados (panel_AnularDerecho,panel_TeclaPunto,label_TeclaPunto )},
    { '.', new PanelesResaltados (panel_AnularDerecho,panel_TeclaPunto,label_TeclaPunto )},

    { '0', new PanelesResaltados (panel_AnularDerecho,panel_Tecla0,label_Tecla0)},
    { '=', new PanelesResaltados (panel_AnularDerecho,panel_Tecla0,label_Tecla0 )},
    { 'P', new PanelesResaltados (panel_AnularDerecho,panel_TeclaP,label_TeclaP )},
    { 'Ñ', new PanelesResaltados (panel_AnularDerecho,panel_TeclaÑ,label_TeclaÑ )},
    { '-', new PanelesResaltados (panel_AnularDerecho,panel_TeclaGuion ,label_TeclaGuion)},
    { '_', new PanelesResaltados (panel_AnularDerecho,panel_TeclaGuion ,label_TeclaGuion)},

};
        }
        #endregion

        #region LOAD
        private void Mecanografia_Load(object sender, EventArgs e)
        {
            Texto_Tipear.ReadOnly = true;// richtextbox de solo lectura
            CargarTextoYColorear();// remarca la letra que se debe presionar

        }
     

        private void Mecanografia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtenemos la letra actual
            char letraActual = Texto_Tipear.Text[currentPosition];

            // Verificamos si la tecla presionada coincide con la letra resaltada
            if (e.KeyChar == letraActual)
            {
                // Ocultamos el mensaje de alerta si la tecla es correcta
                alertaLabel.Visible = false;

                // Resaltamos el panel del dedo correspondiente
                ResaltarPanelPorLetra(letraActual);

                // Restauramos la letra anterior (negro y sin negrita) si ya se resaltó un carácter anterior
                if (indiceCaracterResaltadoAnterior != -1)
                {
                    Texto_Tipear.Select(indiceCaracterResaltadoAnterior, 1);
                    Texto_Tipear.SelectionColor = System.Drawing.Color.Black; // Volvemos a color negro
                    Texto_Tipear.SelectionFont = new System.Drawing.Font(Texto_Tipear.Font, FontStyle.Regular); // Estilo normal
                }

                // Avanzamos al siguiente carácter
                currentPosition++;

                // Si todavía hay más caracteres, coloreamos el siguiente en azul y negrita
                if (currentPosition < Texto_Tipear.Text.Length)
                {
                    Texto_Tipear.Select(currentPosition, 1);
                    Texto_Tipear.SelectionColor = System.Drawing.Color.Blue; // Azul
                    Texto_Tipear.SelectionFont = new System.Drawing.Font(Texto_Tipear.Font, FontStyle.Bold); // Negrita

                    // Actualizamos el índice del último carácter resaltado
                    indiceCaracterResaltadoAnterior = currentPosition;
                }
                else
                {
                    // Si llegamos al final del texto, restauramos el último carácter
                    if (indiceCaracterResaltadoAnterior != -1)
                    {
                        Texto_Tipear.Select(indiceCaracterResaltadoAnterior, 1);
                        Texto_Tipear.SelectionColor = System.Drawing.Color.Black; // Volvemos a color negro
                        Texto_Tipear.SelectionFont = new System.Drawing.Font(Texto_Tipear.Font, FontStyle.Regular); // Estilo normal
                    }
                }

                Texto_Tipear.DeselectAll(); // Quitamos la selección visible
            }
            else
            {
                if (!mecanografiaActiva)
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

            timer.Stop();
        }
        #endregion




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
            using Pen pen = new Pen(borderColor, borderWidth);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
            {
            }
            // Alinear el borde dentro del control
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
        }


      
        private void PictureBox_SelectArchivo_Click(object sender, EventArgs e)
        {
            // Verifica que el PictureBox esté habilitado
            if (sender is PictureBox pictureBox && pictureBox.Enabled)
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
                            (int cantidadPalabras, int cantidadCaracteres) = ContadorArchivo.ContarPalabrasYCaracteresDocx(openFileDialog.FileName);

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
                            using WordprocessingDocument doc = WordprocessingDocument.Open(openFileDialog.FileName, false);
                            string contenido = doc.MainDocumentPart.Document.Body.InnerText;

                            // Mostrar el contenido en el RichTextBox
                            Texto_Tipear.Text = contenido;


                            // *** ASIGNAR EL NOMBRE DEL ARCHIVO SELECCIONADO ***
                            archivoSeleccionado = openFileDialog.FileName;

                            // Llamar a la validación de botones
                            ValidarSeleccionArchivo();
                        }
                        catch (Exception ex)
                        {
                            MensajeGeneral.Mostrar("No se pudo cambiar la imagen del PictureBox: " , MensajeGeneral.TipoMensaje.Error);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// para que se active btn iniciar solo despues de cargar archivo
        /// </summary>
        private void ValidarSeleccionArchivo()
        {
            // Habilitar el botón btn_Iniciar si hay un archivo seleccionado
            btn_Iniciar.Enabled = !string.IsNullOrEmpty(archivoSeleccionado);
        }


     
        /// <summary>
        /// para que no puedad editar el rich sin que se atenue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        private void Btn_Iniciar_Click(object sender, EventArgs e)
        {
            mecanografiaActiva = true;
            panel_Manos.Visible = true;
            Texto_Tipear.Visible = true;
            panel_Teclado.Location = new Point(21, 242);
            panel1.Height = 559;
            this.Height = 641;
            CargarTextoYColorear(); // Mostrar el panel de la letra correspondiente en color
            btn_Detener.Enabled = true;


            label_Tiempo.Visible = false; // Asegúrate de que el label sea invisible al iniciar
            timer.Start(); // Iniciar el Timer
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsElapsed++; // Incrementar el contador de segundos
                              // Actualizar el Label con el tiempo transcurrido
            label_Tiempo.Text = TimeSpan.FromSeconds(secondsElapsed).ToString(@"hh\:mm\:ss");
        }

        private void CrearLabelTimer()
        {
            // Inicializamos el Label de tiempo
            label_Tiempo = new Label();
            label_Tiempo.ForeColor = SystemColors.Highlight; // Color para el texto
            label_Tiempo.Font = new System.Drawing.Font("Arial", 18);
            label_Tiempo.Location = new Point(315, 95); // Posición dentro del panel
            label_Tiempo.AutoSize = true; // Ajusta el tamaño automáticamente
            label_Tiempo.Visible = true; // Hacerlo visible inicialmente
            panel_Especificaciones.Controls.Add(label_Tiempo); // Añadir al panel
        }


       
        private void Btn_Detener_Click(object sender, EventArgs e)
        {
            timer.Stop();
            label_Tiempo.Visible = true;
            mecanografiaActiva = false; // Desactivar la mecanografía
            alertaLabel.Visible = false;
            panel_Manos.Visible = false;
            Texto_Tipear.Visible = false;
            panel_Teclado.Location = new Point(21, 193);
            RestablecerColores();//PARA QUE NO SE NOTE CAMBIO EN EL TECLADO
            // Ajustar la altura de panel1
            panel1.Height = 380;
            this.Height = panel1.Height + 80;
        }

        private void RestablecerColores()
        {
            // Recorre el diccionario y restablece el color de los paneles y labels
            foreach (var entry in letraPanelMap)
            {
                PanelesResaltados panelesResaltados = entry.Value;

                // Restablecer el color del panel de la tecla
                panelesResaltados.PanelTecla.BackColor = SystemColors.ButtonFace; // Color original
                panelesResaltados.LabelTecla.ForeColor = SystemColors.ControlDarkDark; // Color original del texto


            }
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


       
        /// <summary>
        /// ajustar tamaño y posicion principal de elementos en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            alertaLabel = new Label
            {
                ForeColor = System.Drawing.Color.Red, // Color rojo para el texto
                Font = new System.Drawing.Font("Arial", 14),
                Location = new Point(265, 95), // Posición dentro del panel
                AutoSize = true, // Ajusta el tamaño automáticamente
                Visible = false // Inicialmente invisible
            };
            panel_Especificaciones.Controls.Add(alertaLabel); // Añadir al panel
        }
       
    


        
        private void ResaltarPanelPorLetra(char letra)
        {
            // Restablecer el color del panel anterior y el color del Label, si existe
            if (panelResaltadoAnterior != null)
            {
                // Cambiar el color del panel anterior a su color original
                panelResaltadoAnterior.PanelTecla.BackColor = SystemColors.ButtonFace; // Color original del panel
                panelResaltadoAnterior.LabelTecla.ForeColor = SystemColors.ControlDarkDark; // Color original del Label
                panelResaltadoAnterior.PanelMano.BackColor = System.Drawing.Color.AntiqueWhite;
            }

            // Verificar si el diccionario está bien configurado
            if (letraPanelMap == null)
            {
                Console.WriteLine("El diccionario letraPanelMap no ha sido inicializado.");
                return;
            }

            // Verificar si la letra está en el diccionario
            if (letraPanelMap.TryGetValue(letra, out PanelesResaltados panelesResaltados))
            {
                // Cambiar el color del panel correspondiente a rojo
                panelesResaltados.PanelTecla.BackColor = SystemColors.Highlight; // Color resaltado
                panelesResaltados.LabelTecla.ForeColor = System.Drawing.Color.White; // Cambiar el color del texto a blanco
                                                                                     // Cambiar el color del panel correspondiente a la mano a resaltado
                panelesResaltados.PanelMano.BackColor = SystemColors.Highlight;
                // Almacenar el panel resaltado actual
                panelResaltadoAnterior = panelesResaltados;
            }
        }




        // Clase para almacenar los paneles de la mano y del teclado
        public class PanelesResaltados
        {
            public Panel PanelMano { get; }
            public Panel PanelTecla { get; }
            public Label LabelTecla { get; }

            // Constructor que acepta un Panel de mano, un Panel de tecla y un Label
            public PanelesResaltados(Panel panelMano, Panel panelTecla, Label labelTecla)
            {
                PanelMano = panelMano;
                PanelTecla = panelTecla;
                LabelTecla = labelTecla;
            }
        }






 
        /// <summary>
        /// Evento que maneja el cambio de selección en el RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Texto_Tipear_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si hay una selección y obtener el carácter seleccionado
            if (Texto_Tipear.SelectionLength == 0 && Texto_Tipear.SelectionStart < Texto_Tipear.Text.Length)
            {
                char letraActual = Texto_Tipear.Text[Texto_Tipear.SelectionStart];

                // Resaltar el panel correspondiente a la letra actual
                ResaltarPanelPorLetra(letraActual);
            }
        }
    }
}