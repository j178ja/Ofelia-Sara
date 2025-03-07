using Ofelia_Sara.Clases.General.Apariencia;
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
         

            SetupBotonDeslizable();  // Configurar el delegado de validación

        }
        #endregion

        #region LOAD
        private void AgregarDatosPersonales_Load(object sender, EventArgs e)
        {

            btn_AgregarConcubina.Enabled = false;
            InicializarEstiloBotonAgregar(btn_AgregarConcubina);// estilo boton, borde rojo cuando esta desactivado



            PropiedadesPicture();



            ActualizarControlesPictureDOM();

      

            // Inicializa los PictureBox como deshabilitados
            ActualizarControlesPicture();

            // Actualiza el estado de los PictureBox basado en el estado del CheckBox
            ActualizarCheckBox();

            
            ActualizarEstado();      /// Para habilitar check y modificar label

            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarConcubina, "Seleccione ESTADO CIVIL para agregar un nuevo vinculo.", "Seleccione para agregar nuevo familiar");
        }
        #endregion

      

        /// <summary>
        /// acumula las propiedades de los picture para cargarlos en load
        /// </summary>
        private void PropiedadesPicture()
        {
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


            //----------PARA IMAGENES DEL LEGAJO----------------------
            pictureBox_Frente.AllowDrop = true;//permite que pictureBox reciba imagenes
            pictureBox_PerfilDerecho.AllowDrop = true;
            pictureBox_PerfilIzquierdo.AllowDrop = true;
            pictureBox_CuerpoEntero.AllowDrop = true;


            pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_PerfilDerecho.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_PerfilIzquierdo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_CuerpoEntero.SizeMode = PictureBoxSizeMode.StretchImage;

            // Inicializa los PictureBox como deshabilitados
            pictureBox_Frente.Enabled = true;
            pictureBox_PerfilDerecho.Enabled = true;
            pictureBox_PerfilIzquierdo.Enabled = true;
            pictureBox_CuerpoEntero.Enabled = true;

            pictureBox_Frente.Paint += PictureBox_Paint;
            pictureBox_PerfilDerecho.Paint += PictureBox_Paint;
            pictureBox_PerfilIzquierdo.Paint += PictureBox_Paint;
            pictureBox_CuerpoEntero.Paint += PictureBox_Paint;
        }

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

        /// <summary>
        /// cambia el aspecto estetico de los picture dependiendo si esta habilitado o no
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="habilitar"></param>
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

           
        }

       
        



        /// <summary>
        /// eventos del boton guardar,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
            MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);
        }

        /// <summary>
        /// eliminar contenido de controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;
          
            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);

        }
        
        /// <summary>
        ///  Método para restablecer el placeholder
        /// </summary>
        /// <param name="textBox"></param>
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
      
       /// <summary>
       /// abre y posiciona formulario concuvina
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
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

        /// <summary>
        /// restaura posicion de formulario al cerrarse el de concuvina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

      /// <summary>
      /// funcionalidades derivadas de Btn_SolicitarPlana
      /// </summary>
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