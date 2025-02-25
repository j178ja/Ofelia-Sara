using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Clases.General.Apariencia;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales
{
    /// <summary>
    /// formulario para agregar datos de victimas
    /// </summary>
    public partial class AgregarDatosPersonalesVictima : BaseForm
    {
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        #endregion

        public string TextoNombre
        {
            get { return textBox_Nombre.TextValue; }
            set { textBox_Nombre.TextValue = value; }
        }

        // Definir el evento personalizado
        public event Action<string> VictimaTextChanged;

        #region CONSTRUCTOR
        public AgregarDatosPersonalesVictima()
        {
            InitializeComponent();
          


            this.Load += new System.EventHandler(this.AgregarDatosPersonalesVictima_Load);

          

            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);

            this.FormClosing += AgregarDatosPersonalesVictima_FormClosing;//para mensaje de alerta en caso de no guardar datos
            label_Titulo.BringToFront();
        }
        #endregion

        #region LOAD
        private void AgregarDatosPersonalesVictima_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Configura el arrastrar y soltar para los PictureBox
            pictureBox_Domicilio.AllowDrop = true;
            pictureBox_Geoposicionamiento.AllowDrop = true;

            pictureBox_Domicilio.DragEnter += PictureBox_DragEnter;
            pictureBox_Geoposicionamiento.DragEnter += PictureBox_DragEnter;

            pictureBox_Geoposicionamiento.DragDrop += PictureBox_DragDrop;
            pictureBox_Domicilio.DragDrop += PictureBox_DragDrop;

            // Ajusta el SizeMode de cada PictureBox
            pictureBox_Domicilio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Geoposicionamiento.SizeMode = PictureBoxSizeMode.StretchImage;
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            ActualizarControlesPicture();

            comboBox_EstadoCivil.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)ComboBoxStyle.DropDownList;//deshabilita ingreso de datos del usuario en comboBox estado civil

            CalcularEdad.Inicializar(dateTimePicker_FechaNacimiento, textBox_Edad);//para automatizar edad

        }
        #endregion

        #region designer
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarDatosPersonalesVictima));
            panel1 = new Panel();
            botonDeslizable_StudRML = new BotonDeslizable();
            label_StudRML = new Label();
            comboBox_EstadoCivil = new CustomComboBox();
            label_EstadoCivil = new Label();
            emailControl1 = new Controles.Ofl_Sara.EmailControl();
            numeroTelefonicoControl1 = new Controles.Ofl_Sara.NumeroTelefonicoControl();
            dateTimePicker_FechaNacimiento = new Controles.Ofl_Sara.CustomDate();
            label_agrGeo2 = new Label();
            label_agrGeo = new Label();
            label_AgregarDomicilio = new Label();
            textBox_LugarNacimiento = new CustomTextBox();
            label_LugarNacimiento = new Label();
            textBox_Ocupacion = new CustomTextBox();
            label_Ocupacion = new Label();
            btn_Buscar = new Button();
            checkBox_Notificacion258 = new CheckBox();
            label_Notificacion258 = new Label();
            btn_Limpiar = new Button();
            btn_Guardar = new Button();
            comboBox_Nacionalidad = new CustomComboBox();
            label_Email = new Label();
            label_Telefono = new Label();
            pictureBox_Geoposicionamiento = new PictureBox();
            pictureBox_Domicilio = new PictureBox();
            label_Nacionalidad = new Label();
            textBox_Localidad = new CustomTextBox();
            textBox_Domicilio = new CustomTextBox();
            textBox_Edad = new CustomTextBox();
            textBox_Dni = new CustomTextBox();
            textBox_Nombre = new CustomTextBox();
            label_Localidad = new Label();
            label_Domicilio = new Label();
            label_Edad = new Label();
            label_FechaNacimiento = new Label();
            label_Dni = new Label();
            label_Nombre = new Label();
            label_CircunstanciasPersonales = new Label();
            label_Titulo = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Geoposicionamiento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Domicilio).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(botonDeslizable_StudRML);
            panel1.Controls.Add(label_StudRML);
            panel1.Controls.Add(comboBox_EstadoCivil);
            panel1.Controls.Add(label_EstadoCivil);
            panel1.Controls.Add(emailControl1);
            panel1.Controls.Add(numeroTelefonicoControl1);
            panel1.Controls.Add(dateTimePicker_FechaNacimiento);
            panel1.Controls.Add(label_agrGeo2);
            panel1.Controls.Add(label_agrGeo);
            panel1.Controls.Add(label_AgregarDomicilio);
            panel1.Controls.Add(textBox_LugarNacimiento);
            panel1.Controls.Add(label_LugarNacimiento);
            panel1.Controls.Add(textBox_Ocupacion);
            panel1.Controls.Add(label_Ocupacion);
            panel1.Controls.Add(btn_Buscar);
            panel1.Controls.Add(checkBox_Notificacion258);
            panel1.Controls.Add(label_Notificacion258);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(comboBox_Nacionalidad);
            panel1.Controls.Add(label_Email);
            panel1.Controls.Add(label_Telefono);
            panel1.Controls.Add(pictureBox_Geoposicionamiento);
            panel1.Controls.Add(pictureBox_Domicilio);
            panel1.Controls.Add(label_Nacionalidad);
            panel1.Controls.Add(textBox_Localidad);
            panel1.Controls.Add(textBox_Domicilio);
            panel1.Controls.Add(textBox_Edad);
            panel1.Controls.Add(textBox_Dni);
            panel1.Controls.Add(textBox_Nombre);
            panel1.Controls.Add(label_Localidad);
            panel1.Controls.Add(label_Domicilio);
            panel1.Controls.Add(label_Edad);
            panel1.Controls.Add(label_FechaNacimiento);
            panel1.Controls.Add(label_Dni);
            panel1.Controls.Add(label_Nombre);
            panel1.Controls.Add(label_CircunstanciasPersonales);
            panel1.Location = new Point(19, 21);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 470);
            panel1.TabIndex = 2;
            // 
            // botonDeslizable_StudRML
            // 
            botonDeslizable_StudRML.Cursor = Cursors.Hand;
            botonDeslizable_StudRML.IsOn = false;
            botonDeslizable_StudRML.Location = new Point(380, 375);
            botonDeslizable_StudRML.Margin = new Padding(3, 4, 3, 4);
            botonDeslizable_StudRML.Name = "botonDeslizable_StudRML";
            botonDeslizable_StudRML.Size = new Size(32, 16);
            botonDeslizable_StudRML.TabIndex = 100;
            botonDeslizable_StudRML.ValidarCampos = null;
            // 
            // label_StudRML
            // 
            label_StudRML.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_StudRML.Location = new Point(305, 375);
            label_StudRML.Margin = new Padding(2, 0, 2, 0);
            label_StudRML.Name = "label_StudRML";
            label_StudRML.Size = new Size(108, 16);
            label_StudRML.TabIndex = 99;
            label_StudRML.Text = "Stud. R.M.L   ";
            label_StudRML.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_EstadoCivil
            // 
            comboBox_EstadoCivil.ArrowImage = (Image)resources.GetObject("comboBox_EstadoCivil.ArrowImage");
            comboBox_EstadoCivil.ArrowPictureBox = null;
            comboBox_EstadoCivil.AutoCompleteMode = AutoCompleteMode.None;
            comboBox_EstadoCivil.AutoCompleteSource = AutoCompleteSource.None;
            comboBox_EstadoCivil.BackColor = Color.White;
            comboBox_EstadoCivil.DataSource = null;
            comboBox_EstadoCivil.DefaultImage = (Image)resources.GetObject("comboBox_EstadoCivil.DefaultImage");
            comboBox_EstadoCivil.DisabledImage = (Image)resources.GetObject("comboBox_EstadoCivil.DisabledImage");
            comboBox_EstadoCivil.DisplayMember = null;
            comboBox_EstadoCivil.DropDownHeight = 252;
            comboBox_EstadoCivil.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_EstadoCivil.DroppedDown = false;
            comboBox_EstadoCivil.ErrorColor = Color.Red;
            comboBox_EstadoCivil.FocusColor = Color.Blue;
            comboBox_EstadoCivil.ForeColor = Color.Gray;
            comboBox_EstadoCivil.Location = new Point(320, 133);
            comboBox_EstadoCivil.Margin = new Padding(2);
            comboBox_EstadoCivil.MaxDropDownItems = 10;
            comboBox_EstadoCivil.Name = "comboBox_EstadoCivil";
            comboBox_EstadoCivil.PlaceholderColor = Color.Gray;
            comboBox_EstadoCivil.PlaceholderText = " ";
            comboBox_EstadoCivil.PressedImage = (Image)resources.GetObject("comboBox_EstadoCivil.PressedImage");
            comboBox_EstadoCivil.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedItem = null;
            comboBox_EstadoCivil.SelectedText = "";
            comboBox_EstadoCivil.SelectionStart = 0;
            comboBox_EstadoCivil.ShowError = false;
            comboBox_EstadoCivil.Size = new Size(96, 17);
            comboBox_EstadoCivil.TabIndex = 98;
            comboBox_EstadoCivil.Text = " ";
            comboBox_EstadoCivil.TextValue = " ";
            // 
            // label_EstadoCivil
            // 
            label_EstadoCivil.AutoSize = true;
            label_EstadoCivil.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_EstadoCivil.Location = new Point(247, 134);
            label_EstadoCivil.Margin = new Padding(2, 0, 2, 0);
            label_EstadoCivil.Name = "label_EstadoCivil";
            label_EstadoCivil.Size = new Size(88, 15);
            label_EstadoCivil.TabIndex = 97;
            label_EstadoCivil.Text = "Estado civil :";
            // 
            // emailControl1
            // 
            emailControl1.Location = new Point(89, 343);
            emailControl1.Margin = new Padding(4, 3, 4, 3);
            emailControl1.Name = "emailControl1";
            emailControl1.Size = new Size(323, 25);
            emailControl1.TabIndex = 93;
            // 
            // numeroTelefonicoControl1
            // 
            numeroTelefonicoControl1.AutoSize = true;
            numeroTelefonicoControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            numeroTelefonicoControl1.ControlWidth = 198;
            numeroTelefonicoControl1.Location = new Point(89, 320);
            numeroTelefonicoControl1.Margin = new Padding(4, 3, 4, 3);
            numeroTelefonicoControl1.Name = "numeroTelefonicoControl1";
            numeroTelefonicoControl1.Size = new Size(198, 25);
            numeroTelefonicoControl1.TabIndex = 92;
            // 
            // dateTimePicker_FechaNacimiento
            // 
            dateTimePicker_FechaNacimiento.AñoMaximo = 2025;
            dateTimePicker_FechaNacimiento.AñoMinimo = 1930;
            dateTimePicker_FechaNacimiento.BackColor = Color.Transparent;
            dateTimePicker_FechaNacimiento.ControlInvocador = null;
            dateTimePicker_FechaNacimiento.Location = new Point(319, 89);
            dateTimePicker_FechaNacimiento.Margin = new Padding(2);
            dateTimePicker_FechaNacimiento.Name = "dateTimePicker_FechaNacimiento";
            dateTimePicker_FechaNacimiento.Size = new Size(119, 16);
            dateTimePicker_FechaNacimiento.SubrayadoGeneralErrorColor = Color.Red;
            dateTimePicker_FechaNacimiento.SubrayadoGeneralFocusColor = Color.Blue;
            dateTimePicker_FechaNacimiento.TabIndex = 91;
            dateTimePicker_FechaNacimiento.TextoAsociado = null;
            // 
            // label_agrGeo2
            // 
            label_agrGeo2.AutoSize = true;
            label_agrGeo2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_agrGeo2.Location = new Point(54, 242);
            label_agrGeo2.Margin = new Padding(2, 0, 2, 0);
            label_agrGeo2.Name = "label_agrGeo2";
            label_agrGeo2.Size = new Size(94, 15);
            label_agrGeo2.TabIndex = 84;
            label_agrGeo2.Text = "de domicilio :";
            // 
            // label_agrGeo
            // 
            label_agrGeo.AutoSize = true;
            label_agrGeo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_agrGeo.Location = new Point(18, 226);
            label_agrGeo.Margin = new Padding(2, 0, 2, 0);
            label_agrGeo.Name = "label_agrGeo";
            label_agrGeo.Size = new Size(195, 15);
            label_agrGeo.TabIndex = 83;
            label_agrGeo.Text = "Agregar geoposicionamiento ";
            // 
            // label_AgregarDomicilio
            // 
            label_AgregarDomicilio.AutoSize = true;
            label_AgregarDomicilio.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_AgregarDomicilio.Location = new Point(14, 281);
            label_AgregarDomicilio.Margin = new Padding(2, 0, 2, 0);
            label_AgregarDomicilio.Name = "label_AgregarDomicilio";
            label_AgregarDomicilio.Size = new Size(200, 15);
            label_AgregarDomicilio.TabIndex = 82;
            label_AgregarDomicilio.Text = "Agregar imagen de domicilio :";
            // 
            // textBox_LugarNacimiento
            // 
            textBox_LugarNacimiento.AutoCompleteMode = AutoCompleteMode.None;
            textBox_LugarNacimiento.AutoCompleteSource = AutoCompleteSource.None;
            textBox_LugarNacimiento.BackColor = Color.White;
            textBox_LugarNacimiento.ErrorColor = Color.Red;
            textBox_LugarNacimiento.FocusColor = Color.Blue;
            textBox_LugarNacimiento.Location = new Point(159, 151);
            textBox_LugarNacimiento.Margin = new Padding(2);
            textBox_LugarNacimiento.MaxLength = 32767;
            textBox_LugarNacimiento.Multiline = false;
            textBox_LugarNacimiento.Name = "textBox_LugarNacimiento";
            textBox_LugarNacimiento.PasswordChar = '\0';
            textBox_LugarNacimiento.PlaceholderColor = Color.Gray;
            textBox_LugarNacimiento.PlaceholderText = "";
            textBox_LugarNacimiento.ReadOnly = false;
            textBox_LugarNacimiento.SelectionStart = 0;
            textBox_LugarNacimiento.ShowError = false;
            textBox_LugarNacimiento.Size = new Size(159, 16);
            textBox_LugarNacimiento.TabIndex = 4;
            textBox_LugarNacimiento.TextAlign = HorizontalAlignment.Center;
            textBox_LugarNacimiento.TextValue = "";
            textBox_LugarNacimiento.Whidth = 0;
            textBox_LugarNacimiento.TextChanged += TextBox_LugarNacimiento_TextChanged;
            textBox_LugarNacimiento.KeyPress += TextBox_LugarNacimiento_KeyPress;
            // 
            // label_LugarNacimiento
            // 
            label_LugarNacimiento.AutoSize = true;
            label_LugarNacimiento.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_LugarNacimiento.Location = new Point(20, 152);
            label_LugarNacimiento.Margin = new Padding(2, 0, 2, 0);
            label_LugarNacimiento.Name = "label_LugarNacimiento";
            label_LugarNacimiento.Size = new Size(172, 15);
            label_LugarNacimiento.TabIndex = 81;
            label_LugarNacimiento.Text = "LUGAR DE NACIMIENTO :";
            // 
            // textBox_Ocupacion
            // 
            textBox_Ocupacion.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Ocupacion.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Ocupacion.BackColor = Color.White;
            textBox_Ocupacion.ErrorColor = Color.Red;
            textBox_Ocupacion.FocusColor = Color.Blue;
            textBox_Ocupacion.Location = new Point(94, 130);
            textBox_Ocupacion.Margin = new Padding(2);
            textBox_Ocupacion.MaxLength = 32767;
            textBox_Ocupacion.Multiline = false;
            textBox_Ocupacion.Name = "textBox_Ocupacion";
            textBox_Ocupacion.PasswordChar = '\0';
            textBox_Ocupacion.PlaceholderColor = Color.Gray;
            textBox_Ocupacion.PlaceholderText = "";
            textBox_Ocupacion.ReadOnly = false;
            textBox_Ocupacion.SelectionStart = 0;
            textBox_Ocupacion.ShowError = false;
            textBox_Ocupacion.Size = new Size(111, 16);
            textBox_Ocupacion.TabIndex = 5;
            textBox_Ocupacion.TextAlign = HorizontalAlignment.Center;
            textBox_Ocupacion.TextValue = "";
            textBox_Ocupacion.Whidth = 0;
            textBox_Ocupacion.TextChanged += TextBox_Ocupacion_TextChanged;
            textBox_Ocupacion.KeyPress += TextBox_Ocupacion_KeyPress;
            // 
            // label_Ocupacion
            // 
            label_Ocupacion.AutoSize = true;
            label_Ocupacion.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Ocupacion.Location = new Point(20, 131);
            label_Ocupacion.Margin = new Padding(2, 0, 2, 0);
            label_Ocupacion.Name = "label_Ocupacion";
            label_Ocupacion.Size = new Size(94, 15);
            label_Ocupacion.TabIndex = 79;
            label_Ocupacion.Text = "OCUPACION :";
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = Color.SkyBlue;
            btn_Buscar.Cursor = Cursors.Hand;
            btn_Buscar.Image = (Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new Point(51, 406);
            btn_Buscar.Margin = new Padding(2);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(60, 54);
            btn_Buscar.TabIndex = 78;
            btn_Buscar.UseVisualStyleBackColor = false;
            btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // checkBox_Notificacion258
            // 
            checkBox_Notificacion258.AutoSize = true;
            checkBox_Notificacion258.Location = new Point(172, 381);
            checkBox_Notificacion258.Margin = new Padding(2);
            checkBox_Notificacion258.Name = "checkBox_Notificacion258";
            checkBox_Notificacion258.Size = new Size(15, 14);
            checkBox_Notificacion258.TabIndex = 11;
            checkBox_Notificacion258.UseVisualStyleBackColor = true;
            // 
            // label_Notificacion258
            // 
            label_Notificacion258.AutoSize = true;
            label_Notificacion258.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Notificacion258.Location = new Point(16, 379);
            label_Notificacion258.Margin = new Padding(2, 0, 2, 0);
            label_Notificacion258.Name = "label_Notificacion258";
            label_Notificacion258.Size = new Size(175, 15);
            label_Notificacion258.TabIndex = 76;
            label_Notificacion258.Text = "Notificacion Art 258 C.P.P.";
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = Color.SkyBlue;
            btn_Limpiar.Cursor = Cursors.Hand;
            btn_Limpiar.Image = (Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new Point(187, 406);
            btn_Limpiar.Margin = new Padding(2);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new Size(60, 54);
            btn_Limpiar.TabIndex = 13;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = Color.SkyBlue;
            btn_Guardar.Cursor = Cursors.Hand;
            btn_Guardar.Image = (Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new Point(319, 406);
            btn_Guardar.Margin = new Padding(2);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(60, 54);
            btn_Guardar.TabIndex = 12;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // comboBox_Nacionalidad
            // 
            comboBox_Nacionalidad.ArrowImage = (Image)resources.GetObject("comboBox_Nacionalidad.ArrowImage");
            comboBox_Nacionalidad.ArrowPictureBox = null;
            comboBox_Nacionalidad.AutoCompleteMode = AutoCompleteMode.None;
            comboBox_Nacionalidad.AutoCompleteSource = AutoCompleteSource.None;
            comboBox_Nacionalidad.BackColor = Color.White;
            comboBox_Nacionalidad.DataSource = null;
            comboBox_Nacionalidad.DefaultImage = (Image)resources.GetObject("comboBox_Nacionalidad.DefaultImage");
            comboBox_Nacionalidad.DisabledImage = (Image)resources.GetObject("comboBox_Nacionalidad.DisabledImage");
            comboBox_Nacionalidad.DisplayMember = null;
            comboBox_Nacionalidad.DropDownHeight = 252;
            comboBox_Nacionalidad.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Nacionalidad.DroppedDown = false;
            comboBox_Nacionalidad.ErrorColor = Color.Red;
            comboBox_Nacionalidad.FocusColor = Color.Blue;
            comboBox_Nacionalidad.ForeColor = Color.Gray;
            comboBox_Nacionalidad.Location = new Point(311, 111);
            comboBox_Nacionalidad.Margin = new Padding(2);
            comboBox_Nacionalidad.MaxDropDownItems = 10;
            comboBox_Nacionalidad.Name = "comboBox_Nacionalidad";
            comboBox_Nacionalidad.PlaceholderColor = Color.Gray;
            comboBox_Nacionalidad.PlaceholderText = " ";
            comboBox_Nacionalidad.PressedImage = (Image)resources.GetObject("comboBox_Nacionalidad.PressedImage");
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_Nacionalidad.SelectedItem = null;
            comboBox_Nacionalidad.SelectedText = "";
            comboBox_Nacionalidad.SelectionStart = 0;
            comboBox_Nacionalidad.ShowError = false;
            comboBox_Nacionalidad.Size = new Size(105, 17);
            comboBox_Nacionalidad.TabIndex = 6;
            comboBox_Nacionalidad.Text = " ";
            comboBox_Nacionalidad.TextValue = " ";
            comboBox_Nacionalidad.TextChanged += ComboBox_Nacionalidad_TextChanged;
            comboBox_Nacionalidad.KeyPress += ComboBox_Nacionalidad_KeyPress;
            // 
            // label_Email
            // 
            label_Email.AutoSize = true;
            label_Email.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Email.Location = new Point(16, 343);
            label_Email.Margin = new Padding(2, 0, 2, 0);
            label_Email.Name = "label_Email";
            label_Email.Size = new Size(56, 15);
            label_Email.TabIndex = 73;
            label_Email.Text = "EMAIL :";
            // 
            // label_Telefono
            // 
            label_Telefono.AutoSize = true;
            label_Telefono.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Telefono.Location = new Point(16, 323);
            label_Telefono.Margin = new Padding(2, 0, 2, 0);
            label_Telefono.Name = "label_Telefono";
            label_Telefono.Size = new Size(87, 15);
            label_Telefono.TabIndex = 71;
            label_Telefono.Text = "TELEFONO :";
            // 
            // pictureBox_Geoposicionamiento
            // 
            pictureBox_Geoposicionamiento.BackColor = SystemColors.ButtonFace;
            pictureBox_Geoposicionamiento.BackgroundImage = (Image)resources.GetObject("pictureBox_Geoposicionamiento.BackgroundImage");
            pictureBox_Geoposicionamiento.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_Geoposicionamiento.Location = new Point(177, 217);
            pictureBox_Geoposicionamiento.Margin = new Padding(2);
            pictureBox_Geoposicionamiento.Name = "pictureBox_Geoposicionamiento";
            pictureBox_Geoposicionamiento.Size = new Size(236, 44);
            pictureBox_Geoposicionamiento.TabIndex = 70;
            pictureBox_Geoposicionamiento.TabStop = false;
            pictureBox_Geoposicionamiento.Click += PictureBox_Click;
            pictureBox_Geoposicionamiento.DragDrop += PictureBox_DragDrop;
            pictureBox_Geoposicionamiento.DragEnter += PictureBox_DragEnter;
            // 
            // pictureBox_Domicilio
            // 
            pictureBox_Domicilio.BackColor = SystemColors.ButtonFace;
            pictureBox_Domicilio.BackgroundImage = (Image)resources.GetObject("pictureBox_Domicilio.BackgroundImage");
            pictureBox_Domicilio.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_Domicilio.Location = new Point(177, 266);
            pictureBox_Domicilio.Margin = new Padding(2);
            pictureBox_Domicilio.Name = "pictureBox_Domicilio";
            pictureBox_Domicilio.Size = new Size(236, 44);
            pictureBox_Domicilio.TabIndex = 69;
            pictureBox_Domicilio.TabStop = false;
            pictureBox_Domicilio.Click += PictureBox_Click;
            pictureBox_Domicilio.DragDrop += PictureBox_DragDrop;
            pictureBox_Domicilio.DragEnter += PictureBox_DragEnter;
            // 
            // label_Nacionalidad
            // 
            label_Nacionalidad.AutoSize = true;
            label_Nacionalidad.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Nacionalidad.Location = new Point(222, 113);
            label_Nacionalidad.Margin = new Padding(2, 0, 2, 0);
            label_Nacionalidad.Name = "label_Nacionalidad";
            label_Nacionalidad.Size = new Size(114, 15);
            label_Nacionalidad.TabIndex = 66;
            label_Nacionalidad.Text = "NACIONALIDAD :";
            // 
            // textBox_Localidad
            // 
            textBox_Localidad.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Localidad.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Localidad.BackColor = Color.White;
            textBox_Localidad.ErrorColor = Color.Red;
            textBox_Localidad.FocusColor = Color.Blue;
            textBox_Localidad.Location = new Point(94, 194);
            textBox_Localidad.Margin = new Padding(2);
            textBox_Localidad.MaxLength = 32767;
            textBox_Localidad.Multiline = false;
            textBox_Localidad.Name = "textBox_Localidad";
            textBox_Localidad.PasswordChar = '\0';
            textBox_Localidad.PlaceholderColor = Color.Gray;
            textBox_Localidad.PlaceholderText = "";
            textBox_Localidad.ReadOnly = false;
            textBox_Localidad.SelectionStart = 0;
            textBox_Localidad.ShowError = false;
            textBox_Localidad.Size = new Size(319, 16);
            textBox_Localidad.TabIndex = 8;
            textBox_Localidad.TextAlign = HorizontalAlignment.Center;
            textBox_Localidad.TextValue = "";
            textBox_Localidad.Whidth = 0;
        
            // 
            // textBox_Domicilio
            // 
            textBox_Domicilio.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Domicilio.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Domicilio.BackColor = Color.White;
            textBox_Domicilio.ErrorColor = Color.Red;
            textBox_Domicilio.FocusColor = Color.Blue;
            textBox_Domicilio.Location = new Point(94, 174);
            textBox_Domicilio.Margin = new Padding(2);
            textBox_Domicilio.MaxLength = 32767;
            textBox_Domicilio.Multiline = false;
            textBox_Domicilio.Name = "textBox_Domicilio";
            textBox_Domicilio.PasswordChar = '\0';
            textBox_Domicilio.PlaceholderColor = Color.Gray;
            textBox_Domicilio.PlaceholderText = "";
            textBox_Domicilio.ReadOnly = false;
            textBox_Domicilio.SelectionStart = 0;
            textBox_Domicilio.ShowError = false;
            textBox_Domicilio.Size = new Size(319, 16);
            textBox_Domicilio.TabIndex = 7;
            textBox_Domicilio.TextAlign = HorizontalAlignment.Center;
            textBox_Domicilio.TextValue = "";
            textBox_Domicilio.Whidth = 0;
            textBox_Domicilio.TextChanged += TextBox_Domicilio_TextChanged;
            // 
            // textBox_Edad
            // 
            textBox_Edad.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Edad.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Edad.BackColor = Color.White;
            textBox_Edad.ErrorColor = Color.Red;
            textBox_Edad.FocusColor = Color.Blue;
            textBox_Edad.Location = new Point(70, 110);
            textBox_Edad.Margin = new Padding(2);
            textBox_Edad.MaxLength = 32767;
            textBox_Edad.Multiline = false;
            textBox_Edad.Name = "textBox_Edad";
            textBox_Edad.PasswordChar = '\0';
            textBox_Edad.PlaceholderColor = Color.Gray;
            textBox_Edad.PlaceholderText = "";
            textBox_Edad.ReadOnly = false;
            textBox_Edad.SelectionStart = 0;
            textBox_Edad.ShowError = false;
            textBox_Edad.Size = new Size(48, 16);
            textBox_Edad.TabIndex = 3;
            textBox_Edad.TextAlign = HorizontalAlignment.Center;
            textBox_Edad.TextValue = "";
            textBox_Edad.Whidth = 0;
            textBox_Edad.TextChanged += TextBox_Edad_TextChanged;
          
            // 
            // textBox_Dni
            // 
            textBox_Dni.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Dni.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Dni.BackColor = Color.White;
            textBox_Dni.ErrorColor = Color.Red;
            textBox_Dni.FocusColor = Color.Blue;
            textBox_Dni.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Dni.Location = new Point(55, 89);
            textBox_Dni.Margin = new Padding(2);
            textBox_Dni.MaxLength = 32767;
            textBox_Dni.Multiline = false;
            textBox_Dni.Name = "textBox_Dni";
            textBox_Dni.PasswordChar = '\0';
            textBox_Dni.PlaceholderColor = Color.Gray;
            textBox_Dni.PlaceholderText = "";
            textBox_Dni.ReadOnly = false;
            textBox_Dni.SelectionStart = 0;
            textBox_Dni.ShowError = false;
            textBox_Dni.Size = new Size(145, 16);
            textBox_Dni.TabIndex = 1;
            textBox_Dni.TextAlign = HorizontalAlignment.Center;
            textBox_Dni.TextValue = "";
            textBox_Dni.Whidth = 0;
        
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Nombre.BackColor = Color.White;
            textBox_Nombre.ErrorColor = Color.Red;
            textBox_Nombre.FocusColor = Color.Blue;
            textBox_Nombre.Location = new Point(81, 65);
            textBox_Nombre.Margin = new Padding(2);
            textBox_Nombre.MaxLength = 32767;
            textBox_Nombre.Multiline = false;
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.PasswordChar = '\0';
            textBox_Nombre.PlaceholderColor = Color.Gray;
            textBox_Nombre.PlaceholderText = "";
            textBox_Nombre.ReadOnly = false;
            textBox_Nombre.SelectionStart = 0;
            textBox_Nombre.ShowError = false;
            textBox_Nombre.Size = new Size(335, 16);
            textBox_Nombre.TabIndex = 0;
            textBox_Nombre.TextAlign = HorizontalAlignment.Center;
            textBox_Nombre.TextValue = "";
            textBox_Nombre.Whidth = 0;
            textBox_Nombre.TextChanged += TextBox_Nombre_TextChanged;
            // 
            // label_Localidad
            // 
            label_Localidad.AutoSize = true;
            label_Localidad.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Localidad.Location = new Point(20, 195);
            label_Localidad.Margin = new Padding(2, 0, 2, 0);
            label_Localidad.Name = "label_Localidad";
            label_Localidad.Size = new Size(90, 15);
            label_Localidad.TabIndex = 65;
            label_Localidad.Text = "LOCALIDAD :";
            // 
            // label_Domicilio
            // 
            label_Domicilio.AutoSize = true;
            label_Domicilio.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Domicilio.Location = new Point(20, 174);
            label_Domicilio.Margin = new Padding(2, 0, 2, 0);
            label_Domicilio.Name = "label_Domicilio";
            label_Domicilio.Size = new Size(86, 15);
            label_Domicilio.TabIndex = 62;
            label_Domicilio.Text = "DOMICILIO :";
            // 
            // label_Edad
            // 
            label_Edad.AutoSize = true;
            label_Edad.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Edad.Location = new Point(24, 111);
            label_Edad.Margin = new Padding(2, 0, 2, 0);
            label_Edad.Name = "label_Edad";
            label_Edad.Size = new Size(52, 15);
            label_Edad.TabIndex = 61;
            label_Edad.Text = "EDAD :";
            // 
            // label_FechaNacimiento
            // 
            label_FechaNacimiento.AutoSize = true;
            label_FechaNacimiento.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_FechaNacimiento.Location = new Point(202, 90);
            label_FechaNacimiento.Margin = new Padding(2, 0, 2, 0);
            label_FechaNacimiento.Name = "label_FechaNacimiento";
            label_FechaNacimiento.Size = new Size(147, 15);
            label_FechaNacimiento.TabIndex = 58;
            label_FechaNacimiento.Text = "FECHA NACIMIENTO :";
            // 
            // label_Dni
            // 
            label_Dni.AutoSize = true;
            label_Dni.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Dni.Location = new Point(22, 90);
            label_Dni.Margin = new Padding(2, 0, 2, 0);
            label_Dni.Name = "label_Dni";
            label_Dni.Size = new Size(39, 15);
            label_Dni.TabIndex = 56;
            label_Dni.Text = "DNI :";
            // 
            // label_Nombre
            // 
            label_Nombre.AutoSize = true;
            label_Nombre.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Nombre.Location = new Point(22, 66);
            label_Nombre.Margin = new Padding(2, 0, 2, 0);
            label_Nombre.Name = "label_Nombre";
            label_Nombre.Size = new Size(75, 15);
            label_Nombre.TabIndex = 54;
            label_Nombre.Text = "NOMBRE :";
            // 
            // label_CircunstanciasPersonales
            // 
            label_CircunstanciasPersonales.AutoSize = true;
            label_CircunstanciasPersonales.BackColor = Color.FromArgb(0, 192, 192);
            label_CircunstanciasPersonales.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label_CircunstanciasPersonales.Location = new Point(86, 31);
            label_CircunstanciasPersonales.Margin = new Padding(2, 0, 2, 0);
            label_CircunstanciasPersonales.Name = "label_CircunstanciasPersonales";
            label_CircunstanciasPersonales.Padding = new Padding(24, 4, 24, 4);
            label_CircunstanciasPersonales.Size = new Size(337, 28);
            label_CircunstanciasPersonales.TabIndex = 52;
            label_CircunstanciasPersonales.Text = "CIRCUNSTANCIAS PERSONALES";
            // 
            // label_Titulo
            // 
            label_Titulo.AutoSize = true;
            label_Titulo.BackColor = Color.FromArgb(0, 154, 174);
            label_Titulo.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Titulo.ForeColor = SystemColors.ControlLightLight;
            label_Titulo.Location = new Point(147, 9);
            label_Titulo.Margin = new Padding(2, 0, 2, 0);
            label_Titulo.Name = "label_Titulo";
            label_Titulo.Padding = new Padding(8, 0, 8, 0);
            label_Titulo.Size = new Size(190, 25);
            label_Titulo.TabIndex = 51;
            label_Titulo.Text = "DATOS VICTIMA";
            // 
            // AgregarDatosPersonalesVictima
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(490, 518);
            Controls.Add(panel1);
            Controls.Add(label_Titulo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(503, 473);
            Name = "AgregarDatosPersonalesVictima";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CIRCUNSTANCIAS PERSONALES VICTIMA";
            HelpButtonClicked += AgregarDatosPersonalesVictima_HelpButtonClicked;
            Load += AgregarDatosPersonalesVictima_Load;
            Controls.SetChildIndex(label_Titulo, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Geoposicionamiento).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Domicilio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion



        #region BTN PANEL INFERIOR
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_EstadoCivil.SelectedIndex = -1;

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            datosGuardados = true; // Marcar que los datos fueron guardados
            MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario BuscarPersonal
            BuscarForm buscarForm = new();

            buscarForm.ShowDialog();
        }
        #endregion

        #region METODOS GENERALES
        private void ComboBox_Nacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es una letra
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la entrada si no es una letra
            }
        }

     

        private void TextBox_Edad_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto actual del TextBox es "0" o "00"
            if (/*textBox_Edad.Text == "0" || */textBox_Edad.Text == "00")
            {
                // Mostrar un mensaje de error y limpiar el TextBox
                MensajeGeneral.Mostrar("El valor no puede ser 0 o 00", MensajeGeneral.TipoMensaje.Error);
                textBox_Edad.Clear();
            }
        }

      

        


        /// <summary>
        /// PARA RECUADRO VERDE Y ROJO DEL PICKTUREBOX
        /// </summary>
        private void ActualizarControlesPicture()
        {
            // Verifica si TextoDomicilio y localidad tienen texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Domicilio.Text) && !string.IsNullOrWhiteSpace(textBox_Localidad.Text);

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

        #region EVENTOS PICTURE
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                Color borderColor = pictureBox.Tag is Color ? (Color)pictureBox.Tag : Color.Transparent;

                using (Pen pen = new Pen(borderColor, 3)) // Grosor del borde
                {
                    // Dibuja el borde exterior
                    e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
                }
            }
        }


        /// <summary>
        /// Eventos para cargar imagenes en los pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            MensajeGeneral.Mostrar("No se pudo cargar la imagen: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                        }
                    }
                }
            }
        }

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
                    MensajeGeneral.Mostrar("No se pudo cargar la imagen: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }
        #endregion


        /// <summary>
        /// PARA QUE SE ACTUALICE DEPENDIENDO LO QUE SE INGRESE EN DOMICILIO Y LOCALIDAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Domicilio_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPicture();
        }

        


        /// <summary>
        /// Método para actualizar el textBox2 en tiempo real
        /// </summary>
        /// <param name="text"></param>
        public void UpdateVictimaTextBox(string text)
        {
            textBox_Nombre.TextValue = text;
        }

        private void TextBox_Nombre_TextChanged(object sender, EventArgs e)
        {
           

            VictimaTextChanged?.Invoke(textBox_Nombre.TextValue);
            // Obtiene el texto actual del TextBox
            string input = textBox_Nombre.TextValue;

            // Convierte el texto a mayúsculas
            string upperText = input.ToUpper();

          
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
            string input = comboBox_Nacionalidad.Text;

            // Convierte el texto a mayúsculas
            string upperText = input.ToUpper();

            // Evita la modificación del texto si ya está en mayúsculas
            if (comboBox_Nacionalidad.Text != upperText)
            {
                // Actualiza el texto del TextBox con el texto convertido a mayúsculas
                comboBox_Nacionalidad.Text = upperText;

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



     

        private void TextBox_LugarNacimiento_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto a mayúsculas
            if (sender is CustomTextBox textBox)
            {
                // Guarda la posición del cursor
                int cursorPosition = textBox.SelectionStart;

                // Convierte el texto a mayúsculas
                textBox.TextValue = textBox.TextValue.ToUpper();

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


        /// <summary>
        /// verificar si los datos están guardados antes de cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarDatosPersonalesVictima_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                MostrarMensajeCierre(e, "No has guardado los datos del Victima. ¿Estás seguro de que deseas cerrar sin guardar?");


            }
        }
        #endregion

        /// <summary>
        /// mensaje de ayuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarDatosPersonalesVictima_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MostrarMensajeAyuda("Los datos de la victima serán empleados para notificaciones y otras actuaciones.");
        }
    }
}
