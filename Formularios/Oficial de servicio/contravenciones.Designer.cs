using Ofelia_Sara.Controles.General;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class Contravenciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contravenciones));
            label_DatosInfraccion = new System.Windows.Forms.Label();
            label_DatosInfractor = new System.Windows.Forms.Label();
            label_FechaAudiencia = new System.Windows.Forms.Label();
            label_Nombre = new System.Windows.Forms.Label();
            label_Dni = new System.Windows.Forms.Label();
            label_FechaNacimiento = new System.Windows.Forms.Label();
            label_Domicilio = new System.Windows.Forms.Label();
            label_Localidad = new System.Windows.Forms.Label();
            label_Nacionalidad = new System.Windows.Forms.Label();
            label_Edad = new System.Windows.Forms.Label();
            textBox_Nombre = new CustomTextBox();
            textBox_Dni = new CustomTextBox();
            textBox_Edad = new CustomTextBox();
            textBox_Localidad = new CustomTextBox();
            textBox_Domicilio = new CustomTextBox();
            label_DatosInstruccion = new System.Windows.Forms.Label();
            label_Secretario = new System.Windows.Forms.Label();
            label_Instructor = new System.Windows.Forms.Label();
            label_Dependencia = new System.Windows.Forms.Label();
            label_Fecha = new System.Windows.Forms.Label();
            comboBox_Secretario = new CustomComboBox();
            comboBox_Instructor = new CustomComboBox();
            comboBox_Dependencia = new CustomComboBox();
            btn_Buscar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Imprimir = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel_DatosInfraccion = new PanelConBordeNeon();
            panel_Detalle_Infraccion = new System.Windows.Forms.Panel();
            btn_AmpliarReducir_INFRACCION = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            FechaAudiencia = new Controles.Ofl_Sara.DateCompromiso_Control();
            btn_BuscarArt = new System.Windows.Forms.Button();
            TextBox_LugarDelHecho = new CustomTextBox();
            label_ArtInfraccion = new System.Windows.Forms.Label();
            label_FechaHecho = new System.Windows.Forms.Label();
            btn_AgregarArtContravencion = new System.Windows.Forms.Button();
            dateCompromiso_Hecho = new Controles.Ofl_Sara.DateCompromiso_Control();
            panel_ArtInfraccion = new System.Windows.Forms.Panel();
            textBox_ArtInfraccion = new CustomTextBox();
            panel_DatosInstruccion = new PanelConBordeNeon();
            panel_Detalle_Instruccion = new System.Windows.Forms.Panel();
            btn_AmpliarReducir_INSTRUCCION = new System.Windows.Forms.Button();
            panel_RatificacionPersonal = new System.Windows.Forms.Panel();
            label_RatificacionPersonal = new System.Windows.Forms.Label();
            checkBox_RatificacionTestimonial = new System.Windows.Forms.CheckBox();
            btn_ContadorRatificaciones = new Controles.Ofl_Sara.Boton_Contador();
            panel_Cargo = new System.Windows.Forms.Panel();
            label_Cargo = new System.Windows.Forms.Label();
            checkBox_Cargo = new System.Windows.Forms.CheckBox();
            label_Juzgado = new System.Windows.Forms.Label();
            Fecha_Instruccion = new Controles.Ofl_Sara.TimePickerPersonalizado();
            comboBox_Juzgado = new CustomComboBox();
            comboBox_DrJuzgado = new CustomComboBox();
            label_DrJuzgado = new System.Windows.Forms.Label();
            panel_DatosInfractor = new PanelConBordeNeon();
            panel_Detalle_Infractor = new System.Windows.Forms.Panel();
            btn_AmpliarReducir_INFRACTOR = new System.Windows.Forms.Button();
            Fecha_Nacimiento = new Controles.Ofl_Sara.CustomDate();
            comboBox_Nacionalidad = new CustomComboBox();
            label_StarPlana = new System.Windows.Forms.Label();
            botonDeslizable_StarPlana = new BotonDeslizable();
            label_TITULO = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            panel_DatosInfraccion.SuspendLayout();
            panel_Detalle_Infraccion.SuspendLayout();
            panel_DatosInstruccion.SuspendLayout();
            panel_Detalle_Instruccion.SuspendLayout();
            panel_RatificacionPersonal.SuspendLayout();
            panel_Cargo.SuspendLayout();
            panel_DatosInfractor.SuspendLayout();
            panel_Detalle_Infractor.SuspendLayout();
            SuspendLayout();
            // 
            // label_DatosInfraccion
            // 
            label_DatosInfraccion.AutoSize = true;
            label_DatosInfraccion.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosInfraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_DatosInfraccion.Location = new System.Drawing.Point(103, 7);
            label_DatosInfraccion.Name = "label_DatosInfraccion";
            label_DatosInfraccion.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            label_DatosInfraccion.Size = new System.Drawing.Size(336, 34);
            label_DatosInfraccion.TabIndex = 0;
            label_DatosInfraccion.Text = "DATOS DE LA INFRACCION";
            // 
            // label_DatosInfractor
            // 
            label_DatosInfractor.AutoSize = true;
            label_DatosInfractor.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosInfractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_DatosInfractor.Location = new System.Drawing.Point(97, -18);
            label_DatosInfractor.Name = "label_DatosInfractor";
            label_DatosInfractor.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            label_DatosInfractor.Size = new System.Drawing.Size(309, 34);
            label_DatosInfractor.TabIndex = 1;
            label_DatosInfractor.Text = "DATOS DEL INFRACTOR";
            // 
            // label_FechaAudiencia
            // 
            label_FechaAudiencia.AutoSize = true;
            label_FechaAudiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_FechaAudiencia.Location = new System.Drawing.Point(20, 143);
            label_FechaAudiencia.Name = "label_FechaAudiencia";
            label_FechaAudiencia.Size = new System.Drawing.Size(188, 18);
            label_FechaAudiencia.TabIndex = 3;
            label_FechaAudiencia.Text = "FECHA DE AUDIENCIA:";
            // 
            // label_Nombre
            // 
            label_Nombre.AutoSize = true;
            label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nombre.Location = new System.Drawing.Point(27, 42);
            label_Nombre.Name = "label_Nombre";
            label_Nombre.Size = new System.Drawing.Size(81, 18);
            label_Nombre.TabIndex = 4;
            label_Nombre.Text = "NOMBRE";
            // 
            // label_Dni
            // 
            label_Dni.AutoSize = true;
            label_Dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dni.Location = new System.Drawing.Point(27, 70);
            label_Dni.Name = "label_Dni";
            label_Dni.Size = new System.Drawing.Size(51, 18);
            label_Dni.TabIndex = 6;
            label_Dni.Text = "D.N.I.";
            // 
            // label_FechaNacimiento
            // 
            label_FechaNacimiento.AutoSize = true;
            label_FechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_FechaNacimiento.Location = new System.Drawing.Point(27, 96);
            label_FechaNacimiento.Name = "label_FechaNacimiento";
            label_FechaNacimiento.Size = new System.Drawing.Size(170, 18);
            label_FechaNacimiento.TabIndex = 7;
            label_FechaNacimiento.Text = "FECHA NACIMIENTO";
            // 
            // label_Domicilio
            // 
            label_Domicilio.AutoSize = true;
            label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Domicilio.Location = new System.Drawing.Point(27, 120);
            label_Domicilio.Name = "label_Domicilio";
            label_Domicilio.Size = new System.Drawing.Size(93, 18);
            label_Domicilio.TabIndex = 9;
            label_Domicilio.Text = "DOMICILIO";
            // 
            // label_Localidad
            // 
            label_Localidad.AutoSize = true;
            label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Localidad.Location = new System.Drawing.Point(382, 126);
            label_Localidad.Name = "label_Localidad";
            label_Localidad.Size = new System.Drawing.Size(99, 18);
            label_Localidad.TabIndex = 10;
            label_Localidad.Text = "LOCALIDAD";
            // 
            // label_Nacionalidad
            // 
            label_Nacionalidad.AutoSize = true;
            label_Nacionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nacionalidad.Location = new System.Drawing.Point(358, 99);
            label_Nacionalidad.Name = "label_Nacionalidad";
            label_Nacionalidad.Size = new System.Drawing.Size(128, 18);
            label_Nacionalidad.TabIndex = 11;
            label_Nacionalidad.Text = "NACIONALIDAD";
            // 
            // label_Edad
            // 
            label_Edad.AutoSize = true;
            label_Edad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Edad.Location = new System.Drawing.Point(420, 70);
            label_Edad.Name = "label_Edad";
            label_Edad.Size = new System.Drawing.Size(53, 18);
            label_Edad.TabIndex = 12;
            label_Edad.Text = "EDAD";
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Nombre.BackColor = System.Drawing.Color.White;
            textBox_Nombre.ErrorColor = System.Drawing.Color.Red;
            textBox_Nombre.FocusColor = System.Drawing.Color.Blue;
            textBox_Nombre.Location = new System.Drawing.Point(111, 41);
            textBox_Nombre.MaxLength = 32767;
            textBox_Nombre.Multiline = false;
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.PasswordChar = '\0';
            textBox_Nombre.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Nombre.PlaceholderText = "";
            textBox_Nombre.ReadOnly = false;
            textBox_Nombre.SelectionStart = 0;
            textBox_Nombre.ShowError = false;
            textBox_Nombre.Size = new System.Drawing.Size(522, 20);
            textBox_Nombre.TabIndex = 5;
            textBox_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Nombre.TextValue = "";
            textBox_Nombre.Whidth = 0;
            // 
            // textBox_Dni
            // 
            textBox_Dni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Dni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Dni.BackColor = System.Drawing.Color.White;
            textBox_Dni.ErrorColor = System.Drawing.Color.Red;
            textBox_Dni.FocusColor = System.Drawing.Color.Blue;
            textBox_Dni.Location = new System.Drawing.Point(111, 67);
            textBox_Dni.MaxLength = 32767;
            textBox_Dni.Multiline = false;
            textBox_Dni.Name = "textBox_Dni";
            textBox_Dni.PasswordChar = '\0';
            textBox_Dni.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Dni.PlaceholderText = "";
            textBox_Dni.ReadOnly = false;
            textBox_Dni.SelectionStart = 0;
            textBox_Dni.ShowError = false;
            textBox_Dni.Size = new System.Drawing.Size(241, 20);
            textBox_Dni.TabIndex = 7;
            textBox_Dni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Dni.TextValue = "";
            textBox_Dni.Whidth = 0;
            // 
            // textBox_Edad
            // 
            textBox_Edad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Edad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Edad.BackColor = System.Drawing.Color.White;
            textBox_Edad.ErrorColor = System.Drawing.Color.Red;
            textBox_Edad.FocusColor = System.Drawing.Color.Blue;
            textBox_Edad.Location = new System.Drawing.Point(471, 70);
            textBox_Edad.MaxLength = 32767;
            textBox_Edad.Multiline = false;
            textBox_Edad.Name = "textBox_Edad";
            textBox_Edad.PasswordChar = '\0';
            textBox_Edad.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Edad.PlaceholderText = "";
            textBox_Edad.ReadOnly = false;
            textBox_Edad.SelectionStart = 0;
            textBox_Edad.ShowError = false;
            textBox_Edad.Size = new System.Drawing.Size(77, 20);
            textBox_Edad.TabIndex = 8;
            textBox_Edad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Edad.TextValue = "";
            textBox_Edad.Whidth = 0;
            textBox_Edad.TextChanged += TextBox_Edad_TextChanged;
            // 
            // textBox_Localidad
            // 
            textBox_Localidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Localidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Localidad.BackColor = System.Drawing.Color.White;
            textBox_Localidad.ErrorColor = System.Drawing.Color.Red;
            textBox_Localidad.FocusColor = System.Drawing.Color.Blue;
            textBox_Localidad.Location = new System.Drawing.Point(470, 126);
            textBox_Localidad.MaxLength = 32767;
            textBox_Localidad.Multiline = false;
            textBox_Localidad.Name = "textBox_Localidad";
            textBox_Localidad.PasswordChar = '\0';
            textBox_Localidad.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Localidad.PlaceholderText = "";
            textBox_Localidad.ReadOnly = false;
            textBox_Localidad.SelectionStart = 0;
            textBox_Localidad.ShowError = false;
            textBox_Localidad.Size = new System.Drawing.Size(163, 20);
            textBox_Localidad.TabIndex = 12;
            textBox_Localidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Localidad.TextValue = "";
            textBox_Localidad.Whidth = 0;
            // 
            // textBox_Domicilio
            // 
            textBox_Domicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Domicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Domicilio.BackColor = System.Drawing.Color.White;
            textBox_Domicilio.ErrorColor = System.Drawing.Color.Red;
            textBox_Domicilio.FocusColor = System.Drawing.Color.Blue;
            textBox_Domicilio.Location = new System.Drawing.Point(111, 119);
            textBox_Domicilio.MaxLength = 32767;
            textBox_Domicilio.Multiline = false;
            textBox_Domicilio.Name = "textBox_Domicilio";
            textBox_Domicilio.PasswordChar = '\0';
            textBox_Domicilio.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Domicilio.PlaceholderText = "";
            textBox_Domicilio.ReadOnly = false;
            textBox_Domicilio.SelectionStart = 0;
            textBox_Domicilio.ShowError = false;
            textBox_Domicilio.Size = new System.Drawing.Size(241, 20);
            textBox_Domicilio.TabIndex = 11;
            textBox_Domicilio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Domicilio.TextValue = "";
            textBox_Domicilio.Whidth = 0;
            // 
            // label_DatosInstruccion
            // 
            label_DatosInstruccion.AutoSize = true;
            label_DatosInstruccion.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosInstruccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_DatosInstruccion.Location = new System.Drawing.Point(97, 0);
            label_DatosInstruccion.Name = "label_DatosInstruccion";
            label_DatosInstruccion.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            label_DatosInstruccion.Size = new System.Drawing.Size(349, 34);
            label_DatosInstruccion.TabIndex = 30;
            label_DatosInstruccion.Text = "DATOS DE LA INSTRUCCION";
            // 
            // label_Secretario
            // 
            label_Secretario.AutoSize = true;
            label_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Secretario.Location = new System.Drawing.Point(11, 62);
            label_Secretario.Name = "label_Secretario";
            label_Secretario.Size = new System.Drawing.Size(114, 18);
            label_Secretario.TabIndex = 31;
            label_Secretario.Text = "SECRETARIO";
            // 
            // label_Instructor
            // 
            label_Instructor.AutoSize = true;
            label_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Instructor.Location = new System.Drawing.Point(11, 89);
            label_Instructor.Name = "label_Instructor";
            label_Instructor.Size = new System.Drawing.Size(116, 18);
            label_Instructor.TabIndex = 32;
            label_Instructor.Text = "INSTRUCTOR";
            // 
            // label_Dependencia
            // 
            label_Dependencia.AutoSize = true;
            label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dependencia.Location = new System.Drawing.Point(11, 116);
            label_Dependencia.Name = "label_Dependencia";
            label_Dependencia.Size = new System.Drawing.Size(126, 18);
            label_Dependencia.TabIndex = 33;
            label_Dependencia.Text = "DEPENDENCIA";
            // 
            // label_Fecha
            // 
            label_Fecha.AutoSize = true;
            label_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Fecha.Location = new System.Drawing.Point(11, 171);
            label_Fecha.Name = "label_Fecha";
            label_Fecha.Size = new System.Drawing.Size(63, 18);
            label_Fecha.TabIndex = 34;
            label_Fecha.Text = "FECHA";
            // 
            // comboBox_Secretario
            // 
            comboBox_Secretario.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Secretario.ArrowImage");
            comboBox_Secretario.ArrowPictureBox = null;
            comboBox_Secretario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Secretario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Secretario.BackColor = System.Drawing.Color.White;
            comboBox_Secretario.DataSource = null;
            comboBox_Secretario.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Secretario.DefaultImage");
            comboBox_Secretario.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Secretario.DisabledImage");
            comboBox_Secretario.DisplayMember = null;
            comboBox_Secretario.DropDownHeight = 252;
            comboBox_Secretario.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Secretario.DroppedDown = false;
            comboBox_Secretario.ErrorColor = System.Drawing.Color.Red;
            comboBox_Secretario.FocusColor = System.Drawing.Color.Blue;
            comboBox_Secretario.ForeColor = System.Drawing.Color.Gray;
            comboBox_Secretario.Location = new System.Drawing.Point(121, 59);
            comboBox_Secretario.MaxDropDownItems = 10;
            comboBox_Secretario.Name = "comboBox_Secretario";
            comboBox_Secretario.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Secretario.PlaceholderText = " ";
            comboBox_Secretario.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Secretario.PressedImage");
            comboBox_Secretario.SelectedIndex = -1;
            comboBox_Secretario.SelectedItem = null;
            comboBox_Secretario.SelectedText = "";
            comboBox_Secretario.SelectionStart = 0;
            comboBox_Secretario.ShowError = false;
            comboBox_Secretario.Size = new System.Drawing.Size(296, 21);
            comboBox_Secretario.TabIndex = 13;
            comboBox_Secretario.Text = " ";
            comboBox_Secretario.TextValue = "";
            // 
            // comboBox_Instructor
            // 
            comboBox_Instructor.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Instructor.ArrowImage");
            comboBox_Instructor.ArrowPictureBox = null;
            comboBox_Instructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Instructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Instructor.BackColor = System.Drawing.Color.White;
            comboBox_Instructor.DataSource = null;
            comboBox_Instructor.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Instructor.DefaultImage");
            comboBox_Instructor.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Instructor.DisabledImage");
            comboBox_Instructor.DisplayMember = null;
            comboBox_Instructor.DropDownHeight = 252;
            comboBox_Instructor.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Instructor.DroppedDown = false;
            comboBox_Instructor.ErrorColor = System.Drawing.Color.Red;
            comboBox_Instructor.FocusColor = System.Drawing.Color.Blue;
            comboBox_Instructor.ForeColor = System.Drawing.Color.Gray;
            comboBox_Instructor.Location = new System.Drawing.Point(121, 86);
            comboBox_Instructor.MaxDropDownItems = 10;
            comboBox_Instructor.Name = "comboBox_Instructor";
            comboBox_Instructor.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Instructor.PlaceholderText = " ";
            comboBox_Instructor.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Instructor.PressedImage");
            comboBox_Instructor.SelectedIndex = -1;
            comboBox_Instructor.SelectedItem = null;
            comboBox_Instructor.SelectedText = "";
            comboBox_Instructor.SelectionStart = 0;
            comboBox_Instructor.ShowError = false;
            comboBox_Instructor.Size = new System.Drawing.Size(296, 21);
            comboBox_Instructor.TabIndex = 14;
            comboBox_Instructor.Text = " ";
            comboBox_Instructor.TextValue = "";
            // 
            // comboBox_Dependencia
            // 
            comboBox_Dependencia.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Dependencia.ArrowImage");
            comboBox_Dependencia.ArrowPictureBox = null;
            comboBox_Dependencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Dependencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Dependencia.BackColor = System.Drawing.Color.White;
            comboBox_Dependencia.DataSource = null;
            comboBox_Dependencia.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Dependencia.DefaultImage");
            comboBox_Dependencia.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Dependencia.DisabledImage");
            comboBox_Dependencia.DisplayMember = null;
            comboBox_Dependencia.DropDownHeight = 252;
            comboBox_Dependencia.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Dependencia.DroppedDown = false;
            comboBox_Dependencia.ErrorColor = System.Drawing.Color.Red;
            comboBox_Dependencia.FocusColor = System.Drawing.Color.Blue;
            comboBox_Dependencia.ForeColor = System.Drawing.Color.Gray;
            comboBox_Dependencia.Location = new System.Drawing.Point(121, 113);
            comboBox_Dependencia.MaxDropDownItems = 10;
            comboBox_Dependencia.Name = "comboBox_Dependencia";
            comboBox_Dependencia.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Dependencia.PlaceholderText = " ";
            comboBox_Dependencia.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Dependencia.PressedImage");
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Dependencia.SelectedItem = null;
            comboBox_Dependencia.SelectedText = "";
            comboBox_Dependencia.SelectionStart = 0;
            comboBox_Dependencia.ShowError = false;
            comboBox_Dependencia.Size = new System.Drawing.Size(296, 21);
            comboBox_Dependencia.TabIndex = 15;
            comboBox_Dependencia.Text = " ";
            comboBox_Dependencia.TextValue = "";
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Buscar.Image = (System.Drawing.Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new System.Drawing.Point(40, 673);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new System.Drawing.Size(75, 67);
            btn_Buscar.TabIndex = 44;
            btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(203, 673);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 45;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(369, 673);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 46;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Imprimir.Image = (System.Drawing.Image)resources.GetObject("btn_Imprimir.Image");
            btn_Imprimir.Location = new System.Drawing.Point(519, 655);
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.Size = new System.Drawing.Size(122, 93);
            btn_Imprimir.TabIndex = 47;
            btn_Imprimir.UseVisualStyleBackColor = false;
            btn_Imprimir.Click += Btn_Imprimir_Click;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel_DatosInfraccion);
            panel1.Controls.Add(panel_DatosInstruccion);
            panel1.Controls.Add(panel_DatosInfractor);
            panel1.Controls.Add(btn_Imprimir);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(btn_Buscar);
            panel1.Location = new System.Drawing.Point(21, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(680, 763);
            panel1.TabIndex = 48;
            // 
            // panel_DatosInfraccion
            // 
            panel_DatosInfraccion.BorderRadius = 10;
            panel_DatosInfraccion.CamposCompletos = false;
            panel_DatosInfraccion.Controls.Add(panel_Detalle_Infraccion);
            panel_DatosInfraccion.Controls.Add(label_DatosInfraccion);
            panel_DatosInfraccion.EstaContraido = false;
            panel_DatosInfraccion.Location = new System.Drawing.Point(16, 26);
            panel_DatosInfraccion.Name = "panel_DatosInfraccion";
            panel_DatosInfraccion.NeonColorCompleto = System.Drawing.Color.FromArgb(0, 255, 0);
            panel_DatosInfraccion.NeonColorIncompleto = System.Drawing.Color.FromArgb(255, 0, 0);
            panel_DatosInfraccion.Size = new System.Drawing.Size(651, 201);
            panel_DatosInfraccion.SombraColor = System.Drawing.Color.FromArgb(200, 0, 198, 255);
            panel_DatosInfraccion.TabIndex = 119;
            // 
            // panel_Detalle_Infraccion
            // 
            panel_Detalle_Infraccion.Controls.Add(btn_AmpliarReducir_INFRACCION);
            panel_Detalle_Infraccion.Controls.Add(label1);
            panel_Detalle_Infraccion.Controls.Add(label_FechaAudiencia);
            panel_Detalle_Infraccion.Controls.Add(FechaAudiencia);
            panel_Detalle_Infraccion.Controls.Add(btn_BuscarArt);
            panel_Detalle_Infraccion.Controls.Add(TextBox_LugarDelHecho);
            panel_Detalle_Infraccion.Controls.Add(label_ArtInfraccion);
            panel_Detalle_Infraccion.Controls.Add(label_FechaHecho);
            panel_Detalle_Infraccion.Controls.Add(btn_AgregarArtContravencion);
            panel_Detalle_Infraccion.Controls.Add(dateCompromiso_Hecho);
            panel_Detalle_Infraccion.Controls.Add(panel_ArtInfraccion);
            panel_Detalle_Infraccion.Controls.Add(textBox_ArtInfraccion);
            panel_Detalle_Infraccion.Location = new System.Drawing.Point(3, 24);
            panel_Detalle_Infraccion.Name = "panel_Detalle_Infraccion";
            panel_Detalle_Infraccion.Size = new System.Drawing.Size(645, 177);
            panel_Detalle_Infraccion.TabIndex = 118;
            // 
            // btn_AmpliarReducir_INFRACCION
            // 
            btn_AmpliarReducir_INFRACCION.BackColor = System.Drawing.SystemColors.ButtonFace;
            btn_AmpliarReducir_INFRACCION.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AmpliarReducir_INFRACCION.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 192, 192);
            btn_AmpliarReducir_INFRACCION.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btn_AmpliarReducir_INFRACCION.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            btn_AmpliarReducir_INFRACCION.Image = Properties.Resources.dobleFlechaARRIBA;
            btn_AmpliarReducir_INFRACCION.Location = new System.Drawing.Point(597, 0);
            btn_AmpliarReducir_INFRACCION.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AmpliarReducir_INFRACCION.Name = "btn_AmpliarReducir_INFRACCION";
            btn_AmpliarReducir_INFRACCION.Size = new System.Drawing.Size(36, 27);
            btn_AmpliarReducir_INFRACCION.TabIndex = 156;
            btn_AmpliarReducir_INFRACCION.UseVisualStyleBackColor = false;
            btn_AmpliarReducir_INFRACCION.Click += Btn_AmpliarReducir_INFRACCION_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(16, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(200, 20);
            label1.TabIndex = 112;
            label1.Text = "LUGAR DEL HECHO :";
            // 
            // FechaAudiencia
            // 
            FechaAudiencia.AutoSize = true;
            FechaAudiencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            FechaAudiencia.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            FechaAudiencia.Location = new System.Drawing.Point(180, 141);
            FechaAudiencia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FechaAudiencia.Name = "FechaAudiencia";
            FechaAudiencia.Size = new System.Drawing.Size(436, 32);
            FechaAudiencia.TabIndex = 102;
            // 
            // btn_BuscarArt
            // 
            btn_BuscarArt.BackgroundImage = Properties.Resources.buscar75_;
            btn_BuscarArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_BuscarArt.Location = new System.Drawing.Point(4, 33);
            btn_BuscarArt.Name = "btn_BuscarArt";
            btn_BuscarArt.Size = new System.Drawing.Size(37, 33);
            btn_BuscarArt.TabIndex = 0;
            btn_BuscarArt.UseVisualStyleBackColor = true;
            btn_BuscarArt.Click += Btn_BuscarArt_Click;
            // 
            // TextBox_LugarDelHecho
            // 
            TextBox_LugarDelHecho.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextBox_LugarDelHecho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            TextBox_LugarDelHecho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            TextBox_LugarDelHecho.BackColor = System.Drawing.Color.White;
            TextBox_LugarDelHecho.ErrorColor = System.Drawing.Color.Red;
            TextBox_LugarDelHecho.FocusColor = System.Drawing.Color.Blue;
            TextBox_LugarDelHecho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            TextBox_LugarDelHecho.Location = new System.Drawing.Point(180, 76);
            TextBox_LugarDelHecho.MaxLength = 32767;
            TextBox_LugarDelHecho.Multiline = false;
            TextBox_LugarDelHecho.Name = "TextBox_LugarDelHecho";
            TextBox_LugarDelHecho.PasswordChar = '\0';
            TextBox_LugarDelHecho.PlaceholderColor = System.Drawing.Color.Gray;
            TextBox_LugarDelHecho.PlaceholderText = "";
            TextBox_LugarDelHecho.ReadOnly = false;
            TextBox_LugarDelHecho.SelectionStart = 0;
            TextBox_LugarDelHecho.ShowError = false;
            TextBox_LugarDelHecho.Size = new System.Drawing.Size(296, 21);
            TextBox_LugarDelHecho.TabIndex = 111;
            TextBox_LugarDelHecho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TextBox_LugarDelHecho.TextValue = "";
            TextBox_LugarDelHecho.Whidth = 0;
            // 
            // label_ArtInfraccion
            // 
            label_ArtInfraccion.AutoSize = true;
            label_ArtInfraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_ArtInfraccion.Location = new System.Drawing.Point(47, 42);
            label_ArtInfraccion.Name = "label_ArtInfraccion";
            label_ArtInfraccion.Size = new System.Drawing.Size(45, 18);
            label_ArtInfraccion.TabIndex = 48;
            label_ArtInfraccion.Text = "ART.";
            // 
            // label_FechaHecho
            // 
            label_FechaHecho.AutoSize = true;
            label_FechaHecho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_FechaHecho.Location = new System.Drawing.Point(20, 105);
            label_FechaHecho.Name = "label_FechaHecho";
            label_FechaHecho.Size = new System.Drawing.Size(165, 18);
            label_FechaHecho.TabIndex = 109;
            label_FechaHecho.Text = "FECHA DEL HECHO";
            // 
            // btn_AgregarArtContravencion
            // 
            btn_AgregarArtContravencion.Location = new System.Drawing.Point(129, 37);
            btn_AgregarArtContravencion.Name = "btn_AgregarArtContravencion";
            btn_AgregarArtContravencion.Size = new System.Drawing.Size(22, 29);
            btn_AgregarArtContravencion.TabIndex = 49;
            btn_AgregarArtContravencion.Text = "+";
            btn_AgregarArtContravencion.UseVisualStyleBackColor = true;
            btn_AgregarArtContravencion.Click += Btn_AgregarArtContravencion_Click;
            // 
            // dateCompromiso_Hecho
            // 
            dateCompromiso_Hecho.AutoSize = true;
            dateCompromiso_Hecho.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dateCompromiso_Hecho.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            dateCompromiso_Hecho.Location = new System.Drawing.Point(180, 103);
            dateCompromiso_Hecho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dateCompromiso_Hecho.Name = "dateCompromiso_Hecho";
            dateCompromiso_Hecho.Size = new System.Drawing.Size(436, 32);
            dateCompromiso_Hecho.TabIndex = 110;
            // 
            // panel_ArtInfraccion
            // 
            panel_ArtInfraccion.Location = new System.Drawing.Point(154, 29);
            panel_ArtInfraccion.Name = "panel_ArtInfraccion";
            panel_ArtInfraccion.Size = new System.Drawing.Size(491, 41);
            panel_ArtInfraccion.TabIndex = 104;
            // 
            // textBox_ArtInfraccion
            // 
            textBox_ArtInfraccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_ArtInfraccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_ArtInfraccion.BackColor = System.Drawing.Color.White;
            textBox_ArtInfraccion.ErrorColor = System.Drawing.Color.Red;
            textBox_ArtInfraccion.FocusColor = System.Drawing.Color.Blue;
            textBox_ArtInfraccion.Location = new System.Drawing.Point(89, 42);
            textBox_ArtInfraccion.MaxLength = 32767;
            textBox_ArtInfraccion.Multiline = false;
            textBox_ArtInfraccion.Name = "textBox_ArtInfraccion";
            textBox_ArtInfraccion.PasswordChar = '\0';
            textBox_ArtInfraccion.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_ArtInfraccion.PlaceholderText = "";
            textBox_ArtInfraccion.ReadOnly = false;
            textBox_ArtInfraccion.SelectionStart = 0;
            textBox_ArtInfraccion.ShowError = false;
            textBox_ArtInfraccion.Size = new System.Drawing.Size(39, 21);
            textBox_ArtInfraccion.TabIndex = 47;
            textBox_ArtInfraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_ArtInfraccion.TextValue = "";
            textBox_ArtInfraccion.Whidth = 0;
            textBox_ArtInfraccion.TextChanged += TextBox_ArtInfraccion_TextChanged;
            // 
            // panel_DatosInstruccion
            // 
            panel_DatosInstruccion.BorderRadius = 10;
            panel_DatosInstruccion.CamposCompletos = false;
            panel_DatosInstruccion.Controls.Add(panel_Detalle_Instruccion);
            panel_DatosInstruccion.Controls.Add(label_DatosInstruccion);
            panel_DatosInstruccion.EstaContraido = false;
            panel_DatosInstruccion.Location = new System.Drawing.Point(16, 422);
            panel_DatosInstruccion.Name = "panel_DatosInstruccion";
            panel_DatosInstruccion.NeonColorCompleto = System.Drawing.Color.FromArgb(0, 255, 0);
            panel_DatosInstruccion.NeonColorIncompleto = System.Drawing.Color.FromArgb(255, 0, 0);
            panel_DatosInstruccion.Size = new System.Drawing.Size(651, 219);
            panel_DatosInstruccion.SombraColor = System.Drawing.Color.FromArgb(200, 0, 198, 255);
            panel_DatosInstruccion.TabIndex = 117;
            // 
            // panel_Detalle_Instruccion
            // 
            panel_Detalle_Instruccion.Controls.Add(btn_AmpliarReducir_INSTRUCCION);
            panel_Detalle_Instruccion.Controls.Add(panel_RatificacionPersonal);
            panel_Detalle_Instruccion.Controls.Add(label_Secretario);
            panel_Detalle_Instruccion.Controls.Add(panel_Cargo);
            panel_Detalle_Instruccion.Controls.Add(label_Instructor);
            panel_Detalle_Instruccion.Controls.Add(label_Dependencia);
            panel_Detalle_Instruccion.Controls.Add(label_Fecha);
            panel_Detalle_Instruccion.Controls.Add(comboBox_Secretario);
            panel_Detalle_Instruccion.Controls.Add(comboBox_Instructor);
            panel_Detalle_Instruccion.Controls.Add(comboBox_Dependencia);
            panel_Detalle_Instruccion.Controls.Add(label_Juzgado);
            panel_Detalle_Instruccion.Controls.Add(Fecha_Instruccion);
            panel_Detalle_Instruccion.Controls.Add(comboBox_Juzgado);
            panel_Detalle_Instruccion.Controls.Add(comboBox_DrJuzgado);
            panel_Detalle_Instruccion.Controls.Add(label_DrJuzgado);
            panel_Detalle_Instruccion.Location = new System.Drawing.Point(3, 20);
            panel_Detalle_Instruccion.Name = "panel_Detalle_Instruccion";
            panel_Detalle_Instruccion.Size = new System.Drawing.Size(645, 198);
            panel_Detalle_Instruccion.TabIndex = 116;
            // 
            // btn_AmpliarReducir_INSTRUCCION
            // 
            btn_AmpliarReducir_INSTRUCCION.BackColor = System.Drawing.SystemColors.ButtonFace;
            btn_AmpliarReducir_INSTRUCCION.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AmpliarReducir_INSTRUCCION.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 192, 192);
            btn_AmpliarReducir_INSTRUCCION.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btn_AmpliarReducir_INSTRUCCION.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaARRIBA;
            btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(599, 3);
            btn_AmpliarReducir_INSTRUCCION.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AmpliarReducir_INSTRUCCION.Name = "btn_AmpliarReducir_INSTRUCCION";
            btn_AmpliarReducir_INSTRUCCION.Size = new System.Drawing.Size(36, 27);
            btn_AmpliarReducir_INSTRUCCION.TabIndex = 155;
            btn_AmpliarReducir_INSTRUCCION.UseVisualStyleBackColor = false;
            btn_AmpliarReducir_INSTRUCCION.Click += Btn_AmpliarReducir_INSTRUCCION_Click;
            // 
            // panel_RatificacionPersonal
            // 
            panel_RatificacionPersonal.Controls.Add(label_RatificacionPersonal);
            panel_RatificacionPersonal.Controls.Add(checkBox_RatificacionTestimonial);
            panel_RatificacionPersonal.Controls.Add(btn_ContadorRatificaciones);
            panel_RatificacionPersonal.Location = new System.Drawing.Point(40, 18);
            panel_RatificacionPersonal.Name = "panel_RatificacionPersonal";
            panel_RatificacionPersonal.Size = new System.Drawing.Size(196, 33);
            panel_RatificacionPersonal.TabIndex = 113;
            // 
            // label_RatificacionPersonal
            // 
            label_RatificacionPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_RatificacionPersonal.Location = new System.Drawing.Point(35, 4);
            label_RatificacionPersonal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_RatificacionPersonal.Name = "label_RatificacionPersonal";
            label_RatificacionPersonal.Size = new System.Drawing.Size(133, 28);
            label_RatificacionPersonal.TabIndex = 38;
            label_RatificacionPersonal.Text = "Ratificación testimonial   ";
            label_RatificacionPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_RatificacionTestimonial
            // 
            checkBox_RatificacionTestimonial.AutoSize = true;
            checkBox_RatificacionTestimonial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            checkBox_RatificacionTestimonial.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            checkBox_RatificacionTestimonial.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_RatificacionTestimonial.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            checkBox_RatificacionTestimonial.Location = new System.Drawing.Point(170, 7);
            checkBox_RatificacionTestimonial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_RatificacionTestimonial.Name = "checkBox_RatificacionTestimonial";
            checkBox_RatificacionTestimonial.Size = new System.Drawing.Size(18, 17);
            checkBox_RatificacionTestimonial.TabIndex = 8;
            checkBox_RatificacionTestimonial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            checkBox_RatificacionTestimonial.UseVisualStyleBackColor = true;
            // 
            // btn_ContadorRatificaciones
            // 
            btn_ContadorRatificaciones.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            btn_ContadorRatificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_ContadorRatificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_ContadorRatificaciones.ForeColor = System.Drawing.SystemColors.ControlText;
            btn_ContadorRatificaciones.Location = new System.Drawing.Point(5, 2);
            btn_ContadorRatificaciones.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            btn_ContadorRatificaciones.MinimumSize = new System.Drawing.Size(24, 24);
            btn_ContadorRatificaciones.Name = "btn_ContadorRatificaciones";
            btn_ContadorRatificaciones.Size = new System.Drawing.Size(24, 27);
            btn_ContadorRatificaciones.TabIndex = 53;
            btn_ContadorRatificaciones.Text = null;
            // 
            // panel_Cargo
            // 
            panel_Cargo.Controls.Add(label_Cargo);
            panel_Cargo.Controls.Add(checkBox_Cargo);
            panel_Cargo.Location = new System.Drawing.Point(351, 17);
            panel_Cargo.Name = "panel_Cargo";
            panel_Cargo.Size = new System.Drawing.Size(125, 34);
            panel_Cargo.TabIndex = 114;
            // 
            // label_Cargo
            // 
            label_Cargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Cargo.Location = new System.Drawing.Point(1, 8);
            label_Cargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Cargo.Name = "label_Cargo";
            label_Cargo.Size = new System.Drawing.Size(85, 19);
            label_Cargo.TabIndex = 40;
            label_Cargo.Text = "   Cargo   ";
            label_Cargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_Cargo
            // 
            checkBox_Cargo.AutoSize = true;
            checkBox_Cargo.BackColor = System.Drawing.Color.Transparent;
            checkBox_Cargo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            checkBox_Cargo.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_Cargo.Location = new System.Drawing.Point(94, 9);
            checkBox_Cargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_Cargo.Name = "checkBox_Cargo";
            checkBox_Cargo.Size = new System.Drawing.Size(18, 17);
            checkBox_Cargo.TabIndex = 9;
            checkBox_Cargo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkBox_Cargo.UseVisualStyleBackColor = false;
            // 
            // label_Juzgado
            // 
            label_Juzgado.AutoSize = true;
            label_Juzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Juzgado.Location = new System.Drawing.Point(9, 146);
            label_Juzgado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label_Juzgado.Name = "label_Juzgado";
            label_Juzgado.Size = new System.Drawing.Size(87, 18);
            label_Juzgado.TabIndex = 108;
            label_Juzgado.Text = "JUZGADO";
            // 
            // Fecha_Instruccion
            // 
            Fecha_Instruccion.AñoMaximo = 2025;
            Fecha_Instruccion.AñoMinimo = 1930;
            Fecha_Instruccion.BackColor = System.Drawing.SystemColors.Window;
            Fecha_Instruccion.FechaSeleccionada = new System.DateTime(0L);
            Fecha_Instruccion.Location = new System.Drawing.Point(121, 169);
            Fecha_Instruccion.Name = "Fecha_Instruccion";
            Fecha_Instruccion.Size = new System.Drawing.Size(296, 21);
            Fecha_Instruccion.SubrayadoGeneralErrorColor = System.Drawing.Color.Red;
            Fecha_Instruccion.SubrayadoGeneralFocusColor = System.Drawing.Color.Blue;
            Fecha_Instruccion.TabIndex = 103;
            // 
            // comboBox_Juzgado
            // 
            comboBox_Juzgado.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Juzgado.ArrowImage");
            comboBox_Juzgado.ArrowPictureBox = null;
            comboBox_Juzgado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Juzgado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Juzgado.BackColor = System.Drawing.Color.White;
            comboBox_Juzgado.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_Juzgado.DataSource = null;
            comboBox_Juzgado.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Juzgado.DefaultImage");
            comboBox_Juzgado.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Juzgado.DisabledImage");
            comboBox_Juzgado.DisplayMember = null;
            comboBox_Juzgado.DropDownHeight = 127;
            comboBox_Juzgado.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Juzgado.DroppedDown = false;
            comboBox_Juzgado.ErrorColor = System.Drawing.Color.Red;
            comboBox_Juzgado.FocusColor = System.Drawing.Color.Blue;
            comboBox_Juzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Juzgado.ForeColor = System.Drawing.Color.Gray;
            comboBox_Juzgado.Location = new System.Drawing.Point(121, 141);
            comboBox_Juzgado.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            comboBox_Juzgado.MaxDropDownItems = 5;
            comboBox_Juzgado.Name = "comboBox_Juzgado";
            comboBox_Juzgado.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Juzgado.PlaceholderText = " ";
            comboBox_Juzgado.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Juzgado.PressedImage");
            comboBox_Juzgado.SelectedIndex = -1;
            comboBox_Juzgado.SelectedItem = null;
            comboBox_Juzgado.SelectedText = "";
            comboBox_Juzgado.SelectionStart = 0;
            comboBox_Juzgado.ShowError = false;
            comboBox_Juzgado.Size = new System.Drawing.Size(296, 21);
            comboBox_Juzgado.TabIndex = 107;
            comboBox_Juzgado.Text = " ";
            comboBox_Juzgado.TextValue = " ";
            // 
            // comboBox_DrJuzgado
            // 
            comboBox_DrJuzgado.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_DrJuzgado.ArrowImage");
            comboBox_DrJuzgado.ArrowPictureBox = null;
            comboBox_DrJuzgado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_DrJuzgado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_DrJuzgado.BackColor = System.Drawing.Color.White;
            comboBox_DrJuzgado.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_DrJuzgado.DataSource = null;
            comboBox_DrJuzgado.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_DrJuzgado.DefaultImage");
            comboBox_DrJuzgado.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_DrJuzgado.DisabledImage");
            comboBox_DrJuzgado.DisplayMember = null;
            comboBox_DrJuzgado.DropDownHeight = 127;
            comboBox_DrJuzgado.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_DrJuzgado.DroppedDown = false;
            comboBox_DrJuzgado.ErrorColor = System.Drawing.Color.Red;
            comboBox_DrJuzgado.FocusColor = System.Drawing.Color.Blue;
            comboBox_DrJuzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_DrJuzgado.ForeColor = System.Drawing.Color.Gray;
            comboBox_DrJuzgado.Location = new System.Drawing.Point(453, 143);
            comboBox_DrJuzgado.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            comboBox_DrJuzgado.MaxDropDownItems = 5;
            comboBox_DrJuzgado.Name = "comboBox_DrJuzgado";
            comboBox_DrJuzgado.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_DrJuzgado.PlaceholderText = " ";
            comboBox_DrJuzgado.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_DrJuzgado.PressedImage");
            comboBox_DrJuzgado.SelectedIndex = -1;
            comboBox_DrJuzgado.SelectedItem = null;
            comboBox_DrJuzgado.SelectedText = "";
            comboBox_DrJuzgado.SelectionStart = 0;
            comboBox_DrJuzgado.ShowError = false;
            comboBox_DrJuzgado.Size = new System.Drawing.Size(169, 21);
            comboBox_DrJuzgado.TabIndex = 106;
            comboBox_DrJuzgado.Text = " ";
            comboBox_DrJuzgado.TextValue = " ";
            // 
            // label_DrJuzgado
            // 
            label_DrJuzgado.AutoSize = true;
            label_DrJuzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_DrJuzgado.Location = new System.Drawing.Point(425, 146);
            label_DrJuzgado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label_DrJuzgado.Name = "label_DrJuzgado";
            label_DrJuzgado.Size = new System.Drawing.Size(31, 18);
            label_DrJuzgado.TabIndex = 105;
            label_DrJuzgado.Text = "Dr.";
            // 
            // panel_DatosInfractor
            // 
            panel_DatosInfractor.BorderRadius = 10;
            panel_DatosInfractor.CamposCompletos = false;
            panel_DatosInfractor.Controls.Add(panel_Detalle_Infractor);
            panel_DatosInfractor.EstaContraido = false;
            panel_DatosInfractor.Location = new System.Drawing.Point(16, 230);
            panel_DatosInfractor.Name = "panel_DatosInfractor";
            panel_DatosInfractor.NeonColorCompleto = System.Drawing.Color.FromArgb(0, 255, 0);
            panel_DatosInfractor.NeonColorIncompleto = System.Drawing.Color.FromArgb(255, 0, 0);
            panel_DatosInfractor.Size = new System.Drawing.Size(651, 189);
            panel_DatosInfractor.SombraColor = System.Drawing.Color.FromArgb(200, 0, 198, 255);
            panel_DatosInfractor.TabIndex = 115;
            // 
            // panel_Detalle_Infractor
            // 
            panel_Detalle_Infractor.Controls.Add(btn_AmpliarReducir_INFRACTOR);
            panel_Detalle_Infractor.Controls.Add(textBox_Nombre);
            panel_Detalle_Infractor.Controls.Add(textBox_Edad);
            panel_Detalle_Infractor.Controls.Add(textBox_Localidad);
            panel_Detalle_Infractor.Controls.Add(textBox_Dni);
            panel_Detalle_Infractor.Controls.Add(textBox_Domicilio);
            panel_Detalle_Infractor.Controls.Add(label_Edad);
            panel_Detalle_Infractor.Controls.Add(label_Nacionalidad);
            panel_Detalle_Infractor.Controls.Add(label_Localidad);
            panel_Detalle_Infractor.Controls.Add(label_Domicilio);
            panel_Detalle_Infractor.Controls.Add(label_FechaNacimiento);
            panel_Detalle_Infractor.Controls.Add(label_Dni);
            panel_Detalle_Infractor.Controls.Add(label_Nombre);
            panel_Detalle_Infractor.Controls.Add(Fecha_Nacimiento);
            panel_Detalle_Infractor.Controls.Add(comboBox_Nacionalidad);
            panel_Detalle_Infractor.Controls.Add(label_StarPlana);
            panel_Detalle_Infractor.Controls.Add(botonDeslizable_StarPlana);
            panel_Detalle_Infractor.Controls.Add(label_DatosInfractor);
            panel_Detalle_Infractor.Location = new System.Drawing.Point(3, 18);
            panel_Detalle_Infractor.Name = "panel_Detalle_Infractor";
            panel_Detalle_Infractor.Size = new System.Drawing.Size(648, 168);
            panel_Detalle_Infractor.TabIndex = 0;
            // 
            // btn_AmpliarReducir_INFRACTOR
            // 
            btn_AmpliarReducir_INFRACTOR.BackColor = System.Drawing.SystemColors.ButtonFace;
            btn_AmpliarReducir_INFRACTOR.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AmpliarReducir_INFRACTOR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 192, 192);
            btn_AmpliarReducir_INFRACTOR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btn_AmpliarReducir_INFRACTOR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            btn_AmpliarReducir_INFRACTOR.Image = Properties.Resources.dobleFlechaARRIBA;
            btn_AmpliarReducir_INFRACTOR.Location = new System.Drawing.Point(597, 3);
            btn_AmpliarReducir_INFRACTOR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AmpliarReducir_INFRACTOR.Name = "btn_AmpliarReducir_INFRACTOR";
            btn_AmpliarReducir_INFRACTOR.Size = new System.Drawing.Size(36, 27);
            btn_AmpliarReducir_INFRACTOR.TabIndex = 154;
            btn_AmpliarReducir_INFRACTOR.UseVisualStyleBackColor = false;
            btn_AmpliarReducir_INFRACTOR.Click += Btn_AmpliarReducir_INFRACTOR_Click;
            // 
            // Fecha_Nacimiento
            // 
            Fecha_Nacimiento.AñoMaximo = 2025;
            Fecha_Nacimiento.AñoMinimo = 1930;
            Fecha_Nacimiento.BackColor = System.Drawing.Color.Transparent;
            Fecha_Nacimiento.ControlInvocador = null;
            Fecha_Nacimiento.Location = new System.Drawing.Point(181, 93);
            Fecha_Nacimiento.Name = "Fecha_Nacimiento";
            Fecha_Nacimiento.Size = new System.Drawing.Size(159, 21);
            Fecha_Nacimiento.SubrayadoGeneralErrorColor = System.Drawing.Color.Red;
            Fecha_Nacimiento.SubrayadoGeneralFocusColor = System.Drawing.Color.Blue;
            Fecha_Nacimiento.TabIndex = 91;
            Fecha_Nacimiento.TextoAsociado = null;
            // 
            // comboBox_Nacionalidad
            // 
            comboBox_Nacionalidad.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Nacionalidad.ArrowImage");
            comboBox_Nacionalidad.ArrowPictureBox = null;
            comboBox_Nacionalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Nacionalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Nacionalidad.BackColor = System.Drawing.Color.White;
            comboBox_Nacionalidad.DataSource = null;
            comboBox_Nacionalidad.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Nacionalidad.DefaultImage");
            comboBox_Nacionalidad.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Nacionalidad.DisabledImage");
            comboBox_Nacionalidad.DisplayMember = null;
            comboBox_Nacionalidad.DropDownHeight = 252;
            comboBox_Nacionalidad.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Nacionalidad.DroppedDown = false;
            comboBox_Nacionalidad.ErrorColor = System.Drawing.Color.Red;
            comboBox_Nacionalidad.FocusColor = System.Drawing.Color.Blue;
            comboBox_Nacionalidad.ForeColor = System.Drawing.Color.Gray;
            comboBox_Nacionalidad.Location = new System.Drawing.Point(470, 98);
            comboBox_Nacionalidad.MaxDropDownItems = 10;
            comboBox_Nacionalidad.Name = "comboBox_Nacionalidad";
            comboBox_Nacionalidad.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Nacionalidad.PlaceholderText = " ";
            comboBox_Nacionalidad.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Nacionalidad.PressedImage");
            comboBox_Nacionalidad.SelectedIndex = -1;
            comboBox_Nacionalidad.SelectedItem = null;
            comboBox_Nacionalidad.SelectedText = "";
            comboBox_Nacionalidad.SelectionStart = 0;
            comboBox_Nacionalidad.ShowError = false;
            comboBox_Nacionalidad.Size = new System.Drawing.Size(163, 21);
            comboBox_Nacionalidad.TabIndex = 93;
            comboBox_Nacionalidad.Text = " ";
            comboBox_Nacionalidad.TextValue = "";
            // 
            // label_StarPlana
            // 
            label_StarPlana.AutoSize = true;
            label_StarPlana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_StarPlana.Location = new System.Drawing.Point(29, 144);
            label_StarPlana.Name = "label_StarPlana";
            label_StarPlana.Size = new System.Drawing.Size(102, 20);
            label_StarPlana.TabIndex = 100;
            label_StarPlana.Text = "Star. Plana";
            // 
            // botonDeslizable_StarPlana
            // 
            botonDeslizable_StarPlana.Cursor = System.Windows.Forms.Cursors.Hand;
            botonDeslizable_StarPlana.IsOn = false;
            botonDeslizable_StarPlana.Location = new System.Drawing.Point(113, 143);
            botonDeslizable_StarPlana.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            botonDeslizable_StarPlana.Name = "botonDeslizable_StarPlana";
            botonDeslizable_StarPlana.Size = new System.Drawing.Size(47, 23);
            botonDeslizable_StarPlana.TabIndex = 101;
            botonDeslizable_StarPlana.ValidarCampos = null;
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(224, 9);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            label_TITULO.Size = new System.Drawing.Size(351, 31);
            label_TITULO.TabIndex = 49;
            label_TITULO.Text = "CONTRAVENCIONES";
            // 
            // Contravenciones
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            ClientSize = new System.Drawing.Size(722, 818);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Contravenciones";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ACTUACIONES CONTRAVENCIONALES                               ";
            HelpButtonClicked += Contravenciones_HelpButtonClicked;
            Load += Contravenciones_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            panel_DatosInfraccion.ResumeLayout(false);
            panel_DatosInfraccion.PerformLayout();
            panel_Detalle_Infraccion.ResumeLayout(false);
            panel_Detalle_Infraccion.PerformLayout();
            panel_DatosInstruccion.ResumeLayout(false);
            panel_DatosInstruccion.PerformLayout();
            panel_Detalle_Instruccion.ResumeLayout(false);
            panel_Detalle_Instruccion.PerformLayout();
            panel_RatificacionPersonal.ResumeLayout(false);
            panel_RatificacionPersonal.PerformLayout();
            panel_Cargo.ResumeLayout(false);
            panel_Cargo.PerformLayout();
            panel_DatosInfractor.ResumeLayout(false);
            panel_Detalle_Infractor.ResumeLayout(false);
            panel_Detalle_Infractor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_DatosInfraccion;
        private System.Windows.Forms.Label label_DatosInfractor;
        private System.Windows.Forms.Label label_ArtInfraccion;
        private System.Windows.Forms.Label label_FechaAudiencia;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.Label label_Dni;
        private System.Windows.Forms.Label label_FechaNacimiento;
        private System.Windows.Forms.Label label_Domicilio;
        private System.Windows.Forms.Label label_Localidad;
        private System.Windows.Forms.Label label_Nacionalidad;
        private System.Windows.Forms.Label label_Edad;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_ArtInfraccion;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Nombre;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Dni;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Edad;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Localidad;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Domicilio;
        private System.Windows.Forms.Label label_DatosInstruccion;
        private System.Windows.Forms.Label label_Secretario;
        private System.Windows.Forms.Label label_Instructor;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_Fecha;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Secretario;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Instructor;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
        private System.Windows.Forms.Button btn_AgregarArtContravencion;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.ToolTip toolTip1;
        private Ofelia_Sara.Controles.Ofl_Sara.CustomDate Fecha_Nacimiento;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Nacionalidad;
        private Ofelia_Sara.Controles.General.BotonDeslizable botonDeslizable_StarPlana;
        private System.Windows.Forms.Label label_StarPlana;
        private Ofelia_Sara.Controles.Ofl_Sara.DateCompromiso_Control FechaAudiencia;
        private Ofelia_Sara.Controles.Ofl_Sara.TimePickerPersonalizado Fecha_Instruccion;
        private System.Windows.Forms.Panel panel_ArtInfraccion;
        private System.Windows.Forms.Button btn_BuscarArt;
        private System.Windows.Forms.Label label_Juzgado;
        private CustomComboBox comboBox_Juzgado;
        private System.Windows.Forms.Label label_DrJuzgado;
        private CustomComboBox comboBox_DrJuzgado;
        private Controles.Ofl_Sara.DateCompromiso_Control dateCompromiso_Hecho;
        private System.Windows.Forms.Label label_FechaHecho;
        private CustomTextBox TextBox_LugarDelHecho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_RatificacionPersonal;
        private System.Windows.Forms.Label label_RatificacionPersonal;
        private System.Windows.Forms.CheckBox checkBox_RatificacionTestimonial;
        private Controles.Ofl_Sara.Boton_Contador btn_ContadorRatificaciones;
        private System.Windows.Forms.Panel panel_Cargo;
        private System.Windows.Forms.Label label_Cargo;
        private System.Windows.Forms.CheckBox checkBox_Cargo;
        private PanelConBordeNeon panel_DatosInfractor;
        private System.Windows.Forms.Panel panel_Detalle_Infractor;
        private PanelConBordeNeon panel_DatosInstruccion;
        private System.Windows.Forms.Panel panel_Detalle_Instruccion;
        private System.Windows.Forms.Button btn_AmpliarReducir_INFRACTOR;
        private System.Windows.Forms.Button btn_AmpliarReducir_INSTRUCCION;
        private System.Windows.Forms.Panel panel_Detalle_Infraccion;
        private PanelConBordeNeon panel_DatosInfraccion;
        private System.Windows.Forms.Button btn_AmpliarReducir_INFRACCION;
    }
}