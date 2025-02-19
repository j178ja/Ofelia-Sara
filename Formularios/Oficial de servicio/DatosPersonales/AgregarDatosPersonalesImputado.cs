﻿using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Controles.Tooltip;


namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales

{
    /// <summary>
    /// formulario para agregar circunstancias personales de imputados y familiares, asi como tamb imagenes
    /// </summary>
    public partial class AgregarDatosPersonalesImputado : BaseForm
    {
        #region VARIABLES

        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Email;
        // Variable para almacenar la posición original
        private Point originalPosition;
        #endregion

        #region PROPIEDADES PUBLICAS
        // Propiedad pública para establecer el texto del TextBox
        public string TextoNombre
        {
            get { return textBox_Nombre.TextValue; }
            set { textBox_Nombre.TextValue = value; }
        }

        // Definir el evento personalizado
        public event Action<string> ImputadoTextChanged;
        #endregion

        #region CONSTRUCTOR
        public AgregarDatosPersonalesImputado()
        {
            InitializeComponent();
           
            // Asigna el evento TextChanged de textBox_Nombre a ActualizarEstado
            textBox_Nombre.TextChanged += (sender, e) => ActualizarEstado();

            // Asigna el evento TextChanged de textBox_Dni a ActualizarEstado
            textBox_Dni.TextChanged += (sender, e) => ActualizarEstado();


            this.FormClosing += AgregarDatosPersonalesImputado_FormClosing;//para mensaje de alerta en caso de no guardar datos

            this.textBox_Email = new Ofelia_Sara.Controles.General.CustomTextBox();// Configuración del textBox_Email

            comboBox_EstadoCivil.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;//deshabilita ingreso de datos del usuario en comboBox estado civil

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);


            SetupBotonDeslizable();  // Configurar el delegado de validación

            label_TITULO.BringToFront();
        }
        #endregion

        #region LOAD
        private void AgregarDatosPersonales_Load(object sender, EventArgs e)
        {

            btn_AgregarConcubina.Enabled = false;
            InicializarEstiloBotonAgregar(btn_AgregarConcubina);// estilo boton


            //-----INICIALIZAR EVENTOS PICKTUREBOX-------------
            //-----Del domicilio------------------
            pictureBox_Domicilio.AllowDrop = true;
            pictureBox_Geoposicionamiento.AllowDrop = true;

            pictureBox_Domicilio.DragEnter += new DragEventHandler(PictureBox_DragEnter);
            pictureBox_Domicilio.DragDrop += new DragEventHandler(PictureBox_DragDrop);

            pictureBox_Geoposicionamiento.DragEnter += new DragEventHandler(PictureBox_DragEnter);
            pictureBox_Geoposicionamiento.DragDrop += new DragEventHandler(PictureBox_DragDrop);

            // Ajusta el SizeMode de cada PictureBox
            pictureBox_Domicilio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Geoposicionamiento.SizeMode = PictureBoxSizeMode.StretchImage;
            //----------------------------------------------------

            //----------PARA IMAGENES DEL LEGAJO----------------------
            pictureBox_Frente.AllowDrop = true;//permite que pictureBox reciba imagenes
            pictureBox_PerfilDerecho.AllowDrop = true;
            pictureBox_PerfilIzquierdo.AllowDrop = true;
            pictureBox_CuerpoEntero.AllowDrop = true;


            pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_PerfilDerecho.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_PerfilIzquierdo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_CuerpoEntero.SizeMode = PictureBoxSizeMode.StretchImage;


            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            ActualizarControlesPictureDOM();

            // Asocia los eventos Paint
            AsociarEventosPaint();

            // Inicializa los PictureBox como deshabilitados
            ActualizarControlesPicture();

            // Actualiza el estado de los PictureBox basado en el estado del CheckBox
            ActualizarCheckBox();

            // Inicializa los PictureBox como deshabilitados
            pictureBox_Frente.Enabled = true;
            pictureBox_PerfilDerecho.Enabled = true;
            pictureBox_PerfilIzquierdo.Enabled = true;
            pictureBox_CuerpoEntero.Enabled = true;
            //-------------------------------------------------------------------------------

            MayusculaSola.AplicarAControl(textBox_LugarNacimiento);
            ActualizarEstado();

            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarConcubina, "Seleccione ESTADO CIVIL para agregar un nuevo vinculo.", "Seleccione para agregar nuevo familiar");
        }
        #endregion

      
       

       
        /// <summary>
        /// PARA RECUADRO VERDE Y ROJO DEL PICKTUREBOX
        /// </summary>
        private void ActualizarControlesPictureDOM()
        {
            // Verifica si TextoDomicilio y localidad tienen texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Domicilio.TextValue) && !string.IsNullOrWhiteSpace(textBox_Localidad.TextValue);

            // Actualiza el estado de los PictureBox
            ActualizarPictureBox(pictureBox_Geoposicionamiento, esTextoValido);
            ActualizarPictureBox(pictureBox_Domicilio, esTextoValido);

            pictureBox_Geoposicionamiento.Paint += PictureBox_Paint;
            pictureBox_Domicilio.Paint += PictureBox_Paint;

        }

        private static void ActualizarPictureBox(PictureBox pictureBox, bool habilitar)
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
            if (sender is PictureBox pictureBox)
            {
                Color borderColor = pictureBox.Tag is Color color ? color : Color.Transparent;

                using Pen pen = new(borderColor, 3); // Grosor del borde
                                                     // Dibuja el borde exterior
                e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            }
        }
     
        /// <summary>
        /// Eventos para cargar imagenes en los pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Enabled)
            {
                using OpenFileDialog openFileDialog = new();
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MensajeGeneral.Mostrar("No se pudo cargar la imagen: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                    }
                }
            }
        }

        /// <summary>
        /// ARRASTRAR IMAGEN A CADA PICKTUREBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            // Verifica si el archivo arrastrado es una imagen
            if (e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Cambia el cursor para indicar que se puede soltar
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Indica que el tipo de datos no es aceptable
                e.Effect = DragDropEffects.None;
            }
        }
     
        /// <summary>
        /// EVENTO SOLTAR IMAGEN EN CADA PICKTUREBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            // Obtiene el PictureBox que disparó el evento
            PictureBox pictureBox = sender as PictureBox;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Obtiene los archivos arrastrados
                string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Verifica que se haya arrastrado al menos un archivo
                if (archivos.Length > 0)
                {
                    // Carga la primera imagen arrastrada
                    string archivo = archivos[0];
                    try
                    {
                        pictureBox.Image = Image.FromFile(archivo);
                    }
                    catch (Exception ex)
                    {
                        MensajeGeneral.Mostrar("No se pudo cargar la imagen: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                    }
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                // Obtiene la imagen arrastrada
                Image imagen = (Image)e.Data.GetData(DataFormats.Bitmap);
                pictureBox.Image = imagen;
            }
        }
       
        /// <summary>
        /// evento para que si se completa control domicilio y localidad se habiliten los pickture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Domicilio_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPictureDOM();

            // Obtiene el texto actual del TextBox
            string input = textBox_Domicilio.TextValue;

            // Convierte el texto a mayúsculas
            string upperText = input.ToUpper();

            // Evita la modificación del texto si ya está en mayúsculas
            if (textBox_Domicilio.TextValue != upperText)
            {
                // Desasocia temporalmente el evento TextChanged para evitar bucles infinitos
                textBox_Domicilio.TextChanged -= TextBox_Domicilio_TextChanged;

                // Actualiza el texto del TextBox con el texto convertido a mayúsculas
                textBox_Domicilio.TextValue = upperText;

                // Restaura la posición del cursor al final del texto
                textBox_Domicilio.SelectionStart = upperText.Length;

                // Vuelve a asociar el evento TextChanged
                textBox_Domicilio.TextChanged += TextBox_Domicilio_TextChanged;
            }
        }

        private void TextBox_Localidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPictureDOM();

            // Obtiene el texto actual del TextBox
            string input = textBox_Localidad.TextValue;

            // Convierte el texto a mayúsculas
            string upperText = input.ToUpper();

            // Evita la modificación del texto si ya está en mayúsculas
            if (textBox_Localidad.TextValue != upperText)
            {
                // Desasocia temporalmente el evento TextChanged para evitar bucles infinitos
                textBox_Localidad.TextChanged -= TextBox_Localidad_TextChanged;

                // Actualiza el texto del TextBox con el texto convertido a mayúsculas
                textBox_Localidad.TextValue = upperText;

                // Restaura la posición del cursor al final del texto
                textBox_Localidad.SelectionStart = upperText.Length;

                // Vuelve a asociar el evento TextChanged
                textBox_Localidad.TextChanged += TextBox_Localidad_TextChanged;
            }
        }
       
        /// <summary>
        /// limitar textBox_Edad a 2 digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene menos de 2 caracteres
            if (textBox_Edad.TextValue.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 2 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }
        private void TextBox_Edad_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto actual del TextBox es "0" o "00"
            if (/*textBox_Edad.Text == "0" || */textBox_Edad.TextValue == "00")
            {
                // Mostrar un mensaje de error y limpiar el TextBox
                MensajeGeneral.Mostrar("El valor no puede ser 0 o 00", MensajeGeneral.TipoMensaje.Error);
                textBox_Edad.Clear();
            }
        }
       
        /// <summary>
        /// limitar textBox_Dni a 8 digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene  10 caracteres
            if (textBox_Dni.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 10 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }
        private void TextBox_Dni_TextChanged(object sender, EventArgs e)
        {
            CustomTextBox textBox = sender as CustomTextBox;

            // Obtener la posición del cursor antes del formateo
            int cursorPosition = textBox.SelectionStart;

            // Usar la clase separada para formatear el texto con puntos
            string textoFormateado = ClaseNumeros.FormatearNumeroConPuntos(textBox.TextValue);

            // Actualizar el texto en el TextBox
            textBox.TextValue = textoFormateado;

            // Asegurarse de que el cursor se posicione al final del texto
            textBox.SelectionStart = textBox.TextValue.Length;
        }


        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
            MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;
            //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);

        }
        // Método para restablecer el placeholder
        private static void ClearTextBoxPlaceholder(CustomTextBox textBox)
        {
            if (textBox != null)
            {
                textBox.Text = "";
                // Asegurarse de que el placeholder se restablezca si es necesario
                if (string.IsNullOrWhiteSpace(textBox.TextValue))
                {
                    textBox.TextValue = "Ingrese email";
                    textBox.ForeColor = Color.Gray;
                }
            }
        }

        /// <summary>
        /// EVENTO PARA QUE EL COMBOBOX ESPECIFICO DE NACIONALIDAD ACEPTE SOLO LETRAS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Nacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite letras y espacios
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsControl(e.KeyChar))
            {
                // Permite el carácter
                e.Handled = false;
            }
            else
            {
                // Bloquea el carácter
                e.Handled = true;
            }
        }

       
        /// <summary>
        /// METODO PARA HABILITAR FOTOS DEL LEGAJO
        /// </summary>
        // Método para asociar los eventos Paint
        private void AsociarEventosPaint()
        {
            pictureBox_Frente.Paint += PictureBox_Paint;
            pictureBox_PerfilDerecho.Paint += PictureBox_Paint;
            pictureBox_PerfilIzquierdo.Paint += PictureBox_Paint;
            pictureBox_CuerpoEntero.Paint += PictureBox_Paint;
        }

        
        /// <summary>
        /// actualizar el estado de los PictureBox
        /// </summary>
        private void ActualizarControlesPicture()
        {
            pictureBox_Frente.Enabled = false;
            pictureBox_PerfilDerecho.Enabled = false;
            pictureBox_PerfilIzquierdo.Enabled = false;
            pictureBox_CuerpoEntero.Enabled = false;

            ActualizarPictureBox(pictureBox_Frente, false);
            ActualizarPictureBox(pictureBox_PerfilDerecho, false);
            ActualizarPictureBox(pictureBox_PerfilIzquierdo, false);
            ActualizarPictureBox(pictureBox_CuerpoEntero, false);
        }
        private void CheckBox_LegajoDetenido_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarCheckBox();
        }

        private void ActualizarCheckBox()
        {
            bool isChecked = checkBox_LegajoDetenido.Checked;

            ActualizarPictureBox(pictureBox_Frente, isChecked);
            ActualizarPictureBox(pictureBox_PerfilDerecho, isChecked);
            ActualizarPictureBox(pictureBox_PerfilIzquierdo, isChecked);
            ActualizarPictureBox(pictureBox_CuerpoEntero, isChecked);
        }

     
        /// <summary>
        /// Para habilitar check y modificar label
        /// </summary>
        private void ActualizarEstado()
        {
            // Verifica si textBox_Nombre y textBox_Dni no están vacíos ni solo con espacios
            bool esTextoValidoNombre = !string.IsNullOrWhiteSpace(textBox_Nombre.TextValue);
            bool esTextoValidoDni = !string.IsNullOrWhiteSpace(textBox_Dni.TextValue);

            // Ambos textos deben ser válidos para que el estado sea verdadero
            bool esTextoValido = esTextoValidoNombre && esTextoValidoDni;

            // Actualiza el color del label y el estado del checkbox según el texto de los TextBoxes
            label_LegajoDetenido.ForeColor = esTextoValido ? Color.Black : Color.Tomato;
            label_LegajoDetenido.BackColor = esTextoValido ? Color.Transparent : Color.FromArgb(211, 211, 211);


            // Actualiza el color de fondo del CheckBox y su estado habilitado/deshabilitado
            checkBox_LegajoDetenido.Enabled = esTextoValido;
            checkBox_LegajoDetenido.BackColor = esTextoValido ? Color.Transparent : Color.Tomato;
        }
       
        /// <summary>
        /// para actualizar el textBox2 en tiempo real
        /// </summary>
        /// <param name="text"></param>
        public void UpdateImputadoTextBox(string text)
        {
            textBox_Nombre.TextValue = text;
        }


        private void TextBox_Nombre_TextChanged(object sender, EventArgs e)
        {
            // Asegura que el cursor esté al final del texto
            textBox_Nombre.SelectionStart = textBox_Nombre.TextValue.Length;

            ImputadoTextChanged?.Invoke(textBox_Nombre.TextValue);
        }
    


        private void TextBox_Ocupacion_TextChanged(object sender, EventArgs e)
        {
            // Obtiene el texto actual del TextBox
            string input = textBox_Ocupacion.TextValue;

            // Convierte el texto a mayúsculas
            string upperText = input.ToUpper();

            // Evita la modificación del texto si ya está en mayúsculas
            if (textBox_Ocupacion.TextValue != upperText)
            {
                // Desasocia temporalmente el evento TextChanged para evitar bucles infinitos
                textBox_Ocupacion.TextChanged -= TextBox_Ocupacion_TextChanged;

                // Actualiza el texto del TextBox con el texto convertido a mayúsculas
                textBox_Ocupacion.TextValue = upperText;

                // Restaura la posición del cursor al final del texto
                textBox_Ocupacion.SelectionStart = upperText.Length;

                // Vuelve a asociar el evento TextChanged
                textBox_Ocupacion.TextChanged += TextBox_Ocupacion_TextChanged;
            }
        }


        private void ComboBox_Nacionalidad_TextChanged(object sender, EventArgs e)
        {
            // Obtiene el texto actual del TextBox
            string input = comboBox_Nacionalidad.TextValue;

            // Convierte el texto a mayúsculas
            string upperText = input.ToUpper();

            // Evita la modificación del texto si ya está en mayúsculas
            if (comboBox_Nacionalidad.TextValue != upperText)
            {
                // Actualiza el texto del TextBox con el texto convertido a mayúsculas
                comboBox_Nacionalidad.TextValue = upperText;

                // Mueve el cursor al final del texto
                comboBox_Nacionalidad.SelectionStart = upperText.Length;
            }
        }

        private void TextBox_Ocupacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como Backspace y Enter, así como teclas de navegación
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ')
            {
                // Permitir el carácter
                e.Handled = false;
            }
            else
            {
                // Anular el carácter si no es una letra
                e.Handled = true;
            }
        }


        private void TextBox_Localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como Backspace y Enter, así como espacios
            if (char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false; // Permitir la tecla
            }
            else if (char.IsLetter(e.KeyChar)) // Permitir letras
            {
                e.Handled = false; // Permitir la tecla
            }
            else
            {
                e.Handled = true; // Ignorar caracteres especiales
            }
        }

        private void TextBox_Apodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite letras y espacios
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsControl(e.KeyChar))
            {
                // Permite el carácter
                e.Handled = false;
            }
            else
            {
                // Bloquea el carácter
                e.Handled = true;
            }
        }

 

        private void TextBox_Apodo_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto a mayúsculas
            if (sender is CustomTextBox textBox)
            {
                // Guarda la posición del cursor
                int cursorPosition = textBox.SelectionStart;

                // Convierte el texto a mayúsculas
                textBox.Text = textBox.TextValue.ToUpper();

                // Restaura la posición del cursor
                textBox.SelectionStart = cursorPosition;
            }
        }



        private void TextBox_LugarNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite letras y espacios
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || char.IsControl(e.KeyChar))
            {
                // Permite el carácter
                e.Handled = false;
            }
            else
            {
                // Bloquea el carácter
                e.Handled = true;
            }
        }



        private void ComboBox_EstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar el botón cuando se seleccione un ítem en el ComboBox
            if (comboBox_EstadoCivil.SelectedIndex >= 0)
            {
                btn_AgregarConcubina.Enabled = true;

            }
            else
            {
                btn_AgregarConcubina.Enabled = false;
            }

        }
      
       
        private void Btn_AgregarConcubina_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario AgregarDatosPersonalesConcubina
            Form agregarDatosPersonalesConcubina = new AgregarDatosPersonalesConcubina();

            // Guardar la posición original del formulario
            originalPosition = this.Location;

            // Obtener el tamaño de ambos formularios
            int totalWidth = this.Width + agregarDatosPersonalesConcubina.Width;
            int height = Math.Max(this.Height, agregarDatosPersonalesConcubina.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario original a la izquierda
            this.Location = new Point(startX, startY);

            // Posicionar el formulario AgregarDatosPersonalesConcubina a la derecha del formulario original
            agregarDatosPersonalesConcubina.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesConcubina.Location = new Point(startX + this.Width, startY);

            // Mostrar el formulario AgregarDatosPersonalesConcubina
            agregarDatosPersonalesConcubina.FormClosed += AgregarDatosPersonalesConcubina_FormClosed;
            agregarDatosPersonalesConcubina.Show();

        }

        private void AgregarDatosPersonalesConcubina_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Restaurar la posición original del formulario
            this.Location = originalPosition;
        }

       
        /// <summary>
        /// para verificar si los datos están guardados antes de cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarDatosPersonalesImputado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los datos del IMPUTADO. ¿Estás seguro de que deseas cerrar sin guardar?");
               
            }
        }

      
        private void SetupBotonDeslizable()
        {
            // Configurar el delegado de validación en el control BotonDeslizable
            botonDeslizable_StarPlana.ValidarCampos = () =>
            {
                // Lógica de validación
                bool camposIncompletos =
                    string.IsNullOrWhiteSpace(textBox_Nombre.TextValue) ||
                    string.IsNullOrWhiteSpace(textBox_Dni.TextValue) ||
                    !dateTimePicker_FechaNacimiento.HasValue();

                if (camposIncompletos)
                {
                    // Obtener el control invocador (en este caso, el control que activó la validación)
                    Control controlInvocador = botonDeslizable_StarPlana; // Aquí puedes usar el control específico que desees

                    // Calcular la posición debajo del control invocador
                    Point controlPosition = controlInvocador.PointToScreen(Point.Empty);
                    using var mensajeForm = new MensajeGeneral("Debe completar los campos NOMBRE, DNI y FECHA DE NACIMIENTO para poder solicitar plana del ciudadano", MensajeGeneral.TipoMensaje.Advertencia);
                    int messageX = controlPosition.X + (controlInvocador.Width / 2) - (mensajeForm.Width / 2);
                    int messageY = controlPosition.Y + controlInvocador.Height + 5; // 5px debajo del control

                    mensajeForm.StartPosition = FormStartPosition.Manual;
                    mensajeForm.Location = new Point(messageX, messageY);
                    mensajeForm.ShowDialog();

                    return false; // Retorna false si los campos están incompletos
                }
                else
                {
                    // Obtener el control invocador para mostrar el mensaje
                    Control controlInvocador = botonDeslizable_StarPlana;

                    // Calcular la posición debajo del control invocador
                    Point controlPosition = controlInvocador.PointToScreen(Point.Empty);
                    using var mensajeForm = new MensajeGeneral("Datos Guardados para solicitar plana del ciudadano. Cuando imprima formulario IPP se enviará automáticamente la solicitud de plana", MensajeGeneral.TipoMensaje.Exito);
                    int messageX = controlPosition.X + (controlInvocador.Width / 2) - (mensajeForm.Width / 2);
                    int messageY = controlPosition.Y + controlInvocador.Height + 5; // 5px debajo del control

                    mensajeForm.StartPosition = FormStartPosition.Manual;
                    mensajeForm.Location = new Point(messageX, messageY);
                    mensajeForm.ShowDialog();

                    return true; // Retorna true si los campos están completos
                }
            };
        }


    }
}