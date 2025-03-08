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
            label2 = new System.Windows.Forms.Label();
            label_ArtInfraccion = new System.Windows.Forms.Label();
            label_FechaAudiencia = new System.Windows.Forms.Label();
            label_Nombre = new System.Windows.Forms.Label();
            label_Dni = new System.Windows.Forms.Label();
            label_FechaNacimiento = new System.Windows.Forms.Label();
            label_Domicilio = new System.Windows.Forms.Label();
            label_Localidad = new System.Windows.Forms.Label();
            label_Nacionalidad = new System.Windows.Forms.Label();
            label_Edad = new System.Windows.Forms.Label();
            textBox_ArtInfraccion = new CustomTextBox();
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
            btn_AgregarArtContravencion = new System.Windows.Forms.Button();
            btn_Buscar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Imprimir = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            Fecha_Instruccion = new Controles.Ofl_Sara.TimePickerPersonalizado();
            FechaAudiencia = new Controles.Ofl_Sara.DateCompromiso_Control();
            botonDeslizable_StarPlana = new BotonDeslizable();
            label_StarPlana = new System.Windows.Forms.Label();
            comboBox_Nacionalidad = new CustomComboBox();
            Fecha_Nacimiento = new Controles.Ofl_Sara.CustomDate();
            label_TITULO = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_DatosInfraccion
            // 
            label_DatosInfraccion.AutoSize = true;
            label_DatosInfraccion.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosInfraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_DatosInfraccion.Location = new System.Drawing.Point(116, 33);
            label_DatosInfraccion.Name = "label_DatosInfraccion";
            label_DatosInfraccion.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            label_DatosInfraccion.Size = new System.Drawing.Size(282, 28);
            label_DatosInfraccion.TabIndex = 0;
            label_DatosInfraccion.Text = "DATOS DE LA INFRACCION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(116, 160);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            label2.Size = new System.Drawing.Size(261, 28);
            label2.TabIndex = 1;
            label2.Text = "DATOS DEL INFRACTOR";
            // 
            // label_ArtInfraccion
            // 
            label_ArtInfraccion.AutoSize = true;
            label_ArtInfraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_ArtInfraccion.Location = new System.Drawing.Point(43, 78);
            label_ArtInfraccion.Name = "label_ArtInfraccion";
            label_ArtInfraccion.Size = new System.Drawing.Size(37, 15);
            label_ArtInfraccion.TabIndex = 2;
            label_ArtInfraccion.Text = "ART.";
            // 
            // label_FechaAudiencia
            // 
            label_FechaAudiencia.AutoSize = true;
            label_FechaAudiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_FechaAudiencia.Location = new System.Drawing.Point(43, 110);
            label_FechaAudiencia.Name = "label_FechaAudiencia";
            label_FechaAudiencia.Size = new System.Drawing.Size(154, 15);
            label_FechaAudiencia.TabIndex = 3;
            label_FechaAudiencia.Text = "FECHA DE AUDIENCIA:";
            // 
            // label_Nombre
            // 
            label_Nombre.AutoSize = true;
            label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nombre.Location = new System.Drawing.Point(41, 203);
            label_Nombre.Name = "label_Nombre";
            label_Nombre.Size = new System.Drawing.Size(67, 15);
            label_Nombre.TabIndex = 4;
            label_Nombre.Text = "NOMBRE";
            // 
            // label_Dni
            // 
            label_Dni.AutoSize = true;
            label_Dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dni.Location = new System.Drawing.Point(41, 231);
            label_Dni.Name = "label_Dni";
            label_Dni.Size = new System.Drawing.Size(43, 15);
            label_Dni.TabIndex = 6;
            label_Dni.Text = "D.N.I.";
            // 
            // label_FechaNacimiento
            // 
            label_FechaNacimiento.AutoSize = true;
            label_FechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_FechaNacimiento.Location = new System.Drawing.Point(41, 257);
            label_FechaNacimiento.Name = "label_FechaNacimiento";
            label_FechaNacimiento.Size = new System.Drawing.Size(139, 15);
            label_FechaNacimiento.TabIndex = 7;
            label_FechaNacimiento.Text = "FECHA NACIMIENTO";
            // 
            // label_Domicilio
            // 
            label_Domicilio.AutoSize = true;
            label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Domicilio.Location = new System.Drawing.Point(41, 281);
            label_Domicilio.Name = "label_Domicilio";
            label_Domicilio.Size = new System.Drawing.Size(78, 15);
            label_Domicilio.TabIndex = 9;
            label_Domicilio.Text = "DOMICILIO";
            // 
            // label_Localidad
            // 
            label_Localidad.AutoSize = true;
            label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Localidad.Location = new System.Drawing.Point(396, 287);
            label_Localidad.Name = "label_Localidad";
            label_Localidad.Size = new System.Drawing.Size(82, 15);
            label_Localidad.TabIndex = 10;
            label_Localidad.Text = "LOCALIDAD";
            // 
            // label_Nacionalidad
            // 
            label_Nacionalidad.AutoSize = true;
            label_Nacionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nacionalidad.Location = new System.Drawing.Point(372, 260);
            label_Nacionalidad.Name = "label_Nacionalidad";
            label_Nacionalidad.Size = new System.Drawing.Size(106, 15);
            label_Nacionalidad.TabIndex = 11;
            label_Nacionalidad.Text = "NACIONALIDAD";
            // 
            // label_Edad
            // 
            label_Edad.AutoSize = true;
            label_Edad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Edad.Location = new System.Drawing.Point(434, 231);
            label_Edad.Name = "label_Edad";
            label_Edad.Size = new System.Drawing.Size(44, 15);
            label_Edad.TabIndex = 12;
            label_Edad.Text = "EDAD";
            // 
            // textBox_ArtInfraccion
            // 
            textBox_ArtInfraccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_ArtInfraccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_ArtInfraccion.BackColor = System.Drawing.Color.White;
            textBox_ArtInfraccion.ErrorColor = System.Drawing.Color.Red;
            textBox_ArtInfraccion.FocusColor = System.Drawing.Color.Blue;
            textBox_ArtInfraccion.Location = new System.Drawing.Point(82, 76);
            textBox_ArtInfraccion.MaxLength = 32767;
            textBox_ArtInfraccion.Multiline = false;
            textBox_ArtInfraccion.Name = "textBox_ArtInfraccion";
            textBox_ArtInfraccion.PasswordChar = '\0';
            textBox_ArtInfraccion.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_ArtInfraccion.PlaceholderText = "";
            textBox_ArtInfraccion.ReadOnly = false;
            textBox_ArtInfraccion.SelectionStart = 0;
            textBox_ArtInfraccion.ShowError = false;
            textBox_ArtInfraccion.Size = new System.Drawing.Size(65, 20);
            textBox_ArtInfraccion.TabIndex = 1;
            textBox_ArtInfraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_ArtInfraccion.TextValue = "";
            textBox_ArtInfraccion.Whidth = 0;
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Nombre.BackColor = System.Drawing.Color.White;
            textBox_Nombre.ErrorColor = System.Drawing.Color.Red;
            textBox_Nombre.FocusColor = System.Drawing.Color.Blue;
            textBox_Nombre.Location = new System.Drawing.Point(125, 202);
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
            textBox_Dni.Location = new System.Drawing.Point(125, 228);
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
            textBox_Dni.TextChanged += textBox_Dni_TextChanged;
            textBox_Dni.KeyPress += textBox_Dni_KeyPress;
            // 
            // textBox_Edad
            // 
            textBox_Edad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Edad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Edad.BackColor = System.Drawing.Color.White;
            textBox_Edad.ErrorColor = System.Drawing.Color.Red;
            textBox_Edad.FocusColor = System.Drawing.Color.Blue;
            textBox_Edad.Location = new System.Drawing.Point(485, 231);
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
            textBox_Edad.TextChanged += textBox_Edad_TextChanged;
            textBox_Edad.KeyPress += textBox_Edad_KeyPress;
            // 
            // textBox_Localidad
            // 
            textBox_Localidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Localidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Localidad.BackColor = System.Drawing.Color.White;
            textBox_Localidad.ErrorColor = System.Drawing.Color.Red;
            textBox_Localidad.FocusColor = System.Drawing.Color.Blue;
            textBox_Localidad.Location = new System.Drawing.Point(484, 287);
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
            textBox_Localidad.KeyPress += textBox_Localidad_KeyPress;
            // 
            // textBox_Domicilio
            // 
            textBox_Domicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Domicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Domicilio.BackColor = System.Drawing.Color.White;
            textBox_Domicilio.ErrorColor = System.Drawing.Color.Red;
            textBox_Domicilio.FocusColor = System.Drawing.Color.Blue;
            textBox_Domicilio.Location = new System.Drawing.Point(125, 280);
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
            label_DatosInstruccion.Location = new System.Drawing.Point(116, 352);
            label_DatosInstruccion.Name = "label_DatosInstruccion";
            label_DatosInstruccion.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            label_DatosInstruccion.Size = new System.Drawing.Size(295, 28);
            label_DatosInstruccion.TabIndex = 30;
            label_DatosInstruccion.Text = "DATOS DE LA INSTRUCCION";
            // 
            // label_Secretario
            // 
            label_Secretario.AutoSize = true;
            label_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Secretario.Location = new System.Drawing.Point(43, 397);
            label_Secretario.Name = "label_Secretario";
            label_Secretario.Size = new System.Drawing.Size(93, 15);
            label_Secretario.TabIndex = 31;
            label_Secretario.Text = "SECRETARIO";
            // 
            // label_Instructor
            // 
            label_Instructor.AutoSize = true;
            label_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Instructor.Location = new System.Drawing.Point(43, 424);
            label_Instructor.Name = "label_Instructor";
            label_Instructor.Size = new System.Drawing.Size(95, 15);
            label_Instructor.TabIndex = 32;
            label_Instructor.Text = "INSTRUCTOR";
            // 
            // label_Dependencia
            // 
            label_Dependencia.AutoSize = true;
            label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dependencia.Location = new System.Drawing.Point(43, 451);
            label_Dependencia.Name = "label_Dependencia";
            label_Dependencia.Size = new System.Drawing.Size(104, 15);
            label_Dependencia.TabIndex = 33;
            label_Dependencia.Text = "DEPENDENCIA";
            // 
            // label_Fecha
            // 
            label_Fecha.AutoSize = true;
            label_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Fecha.Location = new System.Drawing.Point(43, 478);
            label_Fecha.Name = "label_Fecha";
            label_Fecha.Size = new System.Drawing.Size(51, 15);
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
            comboBox_Secretario.Location = new System.Drawing.Point(153, 394);
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
            comboBox_Instructor.Location = new System.Drawing.Point(153, 421);
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
            comboBox_Dependencia.Location = new System.Drawing.Point(153, 448);
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
            // btn_AgregarArtContravencion
            // 
            btn_AgregarArtContravencion.Location = new System.Drawing.Point(144, 74);
            btn_AgregarArtContravencion.Name = "btn_AgregarArtContravencion";
            btn_AgregarArtContravencion.Size = new System.Drawing.Size(19, 23);
            btn_AgregarArtContravencion.TabIndex = 43;
            btn_AgregarArtContravencion.Text = "+";
            toolTip1.SetToolTip(btn_AgregarArtContravencion, "Agregar Art Infraccion");
            btn_AgregarArtContravencion.UseVisualStyleBackColor = true;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Buscar.Image = (System.Drawing.Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new System.Drawing.Point(46, 530);
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
            btn_Guardar.Location = new System.Drawing.Point(209, 530);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 45;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(375, 530);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 46;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += btnLimpiar_Click;
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Imprimir.Image = (System.Drawing.Image)resources.GetObject("btn_Imprimir.Image");
            btn_Imprimir.Location = new System.Drawing.Point(525, 512);
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.Size = new System.Drawing.Size(122, 93);
            btn_Imprimir.TabIndex = 47;
            btn_Imprimir.UseVisualStyleBackColor = false;
            btn_Imprimir.Click += btn_Imprimir_Click;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(Fecha_Instruccion);
            panel1.Controls.Add(FechaAudiencia);
            panel1.Controls.Add(botonDeslizable_StarPlana);
            panel1.Controls.Add(label_StarPlana);
            panel1.Controls.Add(comboBox_Nacionalidad);
            panel1.Controls.Add(Fecha_Nacimiento);
            panel1.Controls.Add(textBox_Nombre);
            panel1.Controls.Add(btn_Imprimir);
            panel1.Controls.Add(label_DatosInfraccion);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(label_ArtInfraccion);
            panel1.Controls.Add(btn_Buscar);
            panel1.Controls.Add(label_FechaAudiencia);
            panel1.Controls.Add(btn_AgregarArtContravencion);
            panel1.Controls.Add(label_Nombre);
            panel1.Controls.Add(label_Dni);
            panel1.Controls.Add(label_FechaNacimiento);
            panel1.Controls.Add(label_Domicilio);
            panel1.Controls.Add(label_Localidad);
            panel1.Controls.Add(comboBox_Dependencia);
            panel1.Controls.Add(label_Nacionalidad);
            panel1.Controls.Add(comboBox_Instructor);
            panel1.Controls.Add(label_Edad);
            panel1.Controls.Add(comboBox_Secretario);
            panel1.Controls.Add(textBox_ArtInfraccion);
            panel1.Controls.Add(label_Fecha);
            panel1.Controls.Add(label_Dependencia);
            panel1.Controls.Add(label_Instructor);
            panel1.Controls.Add(label_Secretario);
            panel1.Controls.Add(label_DatosInstruccion);
            panel1.Controls.Add(textBox_Domicilio);
            panel1.Controls.Add(textBox_Dni);
            panel1.Controls.Add(textBox_Localidad);
            panel1.Controls.Add(textBox_Edad);
            panel1.Location = new System.Drawing.Point(15, 20);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(689, 620);
            panel1.TabIndex = 48;
            // 
            // Fecha_Instruccion
            // 
            Fecha_Instruccion.AñoMaximo = 2025;
            Fecha_Instruccion.AñoMinimo = 1930;
            Fecha_Instruccion.BackColor = System.Drawing.SystemColors.Window;
            Fecha_Instruccion.FechaSeleccionada = new System.DateTime(0L);
            Fecha_Instruccion.Location = new System.Drawing.Point(153, 476);
            Fecha_Instruccion.Name = "Fecha_Instruccion";
            Fecha_Instruccion.Size = new System.Drawing.Size(296, 21);
            Fecha_Instruccion.SubrayadoGeneralErrorColor = System.Drawing.Color.Red;
            Fecha_Instruccion.SubrayadoGeneralFocusColor = System.Drawing.Color.Blue;
            Fecha_Instruccion.TabIndex = 103;
            // 
            // FechaAudiencia
            // 
            FechaAudiencia.AutoSize = true;
            FechaAudiencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            FechaAudiencia.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            FechaAudiencia.Location = new System.Drawing.Point(203, 108);
            FechaAudiencia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FechaAudiencia.Name = "FechaAudiencia";
            FechaAudiencia.Size = new System.Drawing.Size(381, 24);
            FechaAudiencia.TabIndex = 102;
            // 
            // botonDeslizable_StarPlana
            // 
            botonDeslizable_StarPlana.Cursor = System.Windows.Forms.Cursors.Hand;
            botonDeslizable_StarPlana.IsOn = false;
            botonDeslizable_StarPlana.Location = new System.Drawing.Point(127, 304);
            botonDeslizable_StarPlana.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            botonDeslizable_StarPlana.Name = "botonDeslizable_StarPlana";
            botonDeslizable_StarPlana.Size = new System.Drawing.Size(47, 23);
            botonDeslizable_StarPlana.TabIndex = 101;
            botonDeslizable_StarPlana.ValidarCampos = null;
            // 
            // label_StarPlana
            // 
            label_StarPlana.AutoSize = true;
            label_StarPlana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_StarPlana.Location = new System.Drawing.Point(43, 305);
            label_StarPlana.Name = "label_StarPlana";
            label_StarPlana.Size = new System.Drawing.Size(83, 16);
            label_StarPlana.TabIndex = 100;
            label_StarPlana.Text = "Star. Plana";
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
            comboBox_Nacionalidad.Location = new System.Drawing.Point(484, 259);
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
            // Fecha_Nacimiento
            // 
            Fecha_Nacimiento.AñoMaximo = 2025;
            Fecha_Nacimiento.AñoMinimo = 1930;
            Fecha_Nacimiento.BackColor = System.Drawing.Color.Transparent;
            Fecha_Nacimiento.ControlInvocador = null;
            Fecha_Nacimiento.Location = new System.Drawing.Point(195, 254);
            Fecha_Nacimiento.Name = "Fecha_Nacimiento";
            Fecha_Nacimiento.Size = new System.Drawing.Size(159, 21);
            Fecha_Nacimiento.SubrayadoGeneralErrorColor = System.Drawing.Color.Red;
            Fecha_Nacimiento.SubrayadoGeneralFocusColor = System.Drawing.Color.Blue;
            Fecha_Nacimiento.TabIndex = 91;
            Fecha_Nacimiento.TextoAsociado = null;
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
            label_TITULO.Size = new System.Drawing.Size(282, 25);
            label_TITULO.TabIndex = 49;
            label_TITULO.Text = "CONTRAVENCIONES";
            // 
            // Contravenciones
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            ClientSize = new System.Drawing.Size(722, 675);
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
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_DatosInfraccion;
        private System.Windows.Forms.Label label2;
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
    }
}