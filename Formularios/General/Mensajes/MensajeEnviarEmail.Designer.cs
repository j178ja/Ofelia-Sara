namespace Ofelia_Sara.Formularios.General.Mensajes
{
    partial class MensajeEnviarEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajeEnviarEmail));
            panel1 = new System.Windows.Forms.Panel();
            label_Texto = new System.Windows.Forms.Label();
            pictureBox_Icono = new System.Windows.Forms.PictureBox();
            btn_No = new System.Windows.Forms.Button();
            btn_Si = new System.Windows.Forms.Button();
            pictureBox_Automovil = new System.Windows.Forms.PictureBox();
            radioButton_Automovil = new System.Windows.Forms.RadioButton();
            radioButton_Motovehiculo = new System.Windows.Forms.RadioButton();
            pictureBox_Motovehiculo = new System.Windows.Forms.PictureBox();
            label_Dominio = new System.Windows.Forms.Label();
            label_Chasis = new System.Windows.Forms.Label();
            label_Motor = new System.Windows.Forms.Label();
            label_Modelo = new System.Windows.Forms.Label();
            textBox_Dominio = new Controles.General.CustomTextBox();
            label_Marca = new System.Windows.Forms.Label();
            comboBox_Modelo = new Controles.General.CustomComboBox();
            textBox_Motor = new Controles.General.CustomTextBox();
            comboBox_Marca = new Controles.General.CustomComboBox();
            textBox_Chasis = new Controles.General.CustomTextBox();
            textBox_Nombre = new Controles.General.CustomTextBox();
            label_Nombre = new System.Windows.Forms.Label();
            textBox_Dni = new Controles.General.CustomTextBox();
            label_Dni = new System.Windows.Forms.Label();
            customTextBox1 = new Controles.General.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Icono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Automovil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Motovehiculo).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_No);
            panel1.Controls.Add(btn_Si);
            panel1.Controls.Add(label_Texto);
            panel1.Controls.Add(pictureBox_Icono);
            panel1.Location = new System.Drawing.Point(22, 24);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(580, 309);
            panel1.TabIndex = 5;
            // 
            // label_Texto
            // 
            label_Texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Texto.ForeColor = System.Drawing.Color.FromArgb(0, 115, 130);
            label_Texto.Location = new System.Drawing.Point(3, 32);
            label_Texto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Texto.Name = "label_Texto";
            label_Texto.Size = new System.Drawing.Size(573, 28);
            label_Texto.TabIndex = 4;
            label_Texto.Text = "Cargando...";
            label_Texto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_Icono
            // 
            pictureBox_Icono.BackgroundImage = Properties.Resources.enviar_Correo;
            pictureBox_Icono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_Icono.Location = new System.Drawing.Point(261, -29);
            pictureBox_Icono.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_Icono.Name = "pictureBox_Icono";
            pictureBox_Icono.Size = new System.Drawing.Size(64, 58);
            pictureBox_Icono.TabIndex = 3;
            pictureBox_Icono.TabStop = false;
            // 
            // btn_No
            // 
            btn_No.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            btn_No.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_No.ForeColor = System.Drawing.SystemColors.ControlText;
            btn_No.Location = new System.Drawing.Point(398, 293);
            btn_No.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_No.Name = "btn_No";
            btn_No.Size = new System.Drawing.Size(105, 35);
            btn_No.TabIndex = 10;
            btn_No.Text = "CANCELAR";
            btn_No.UseVisualStyleBackColor = false;
            // 
            // btn_Si
            // 
            btn_Si.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            btn_Si.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Si.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Si.ForeColor = System.Drawing.SystemColors.ControlText;
            btn_Si.Location = new System.Drawing.Point(103, 293);
            btn_Si.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Si.Name = "btn_Si";
            btn_Si.Size = new System.Drawing.Size(105, 35);
            btn_Si.TabIndex = 9;
            btn_Si.Text = "ENVIAR";
            btn_Si.UseVisualStyleBackColor = false;
            // 
            // pictureBox_Automovil
            // 
            pictureBox_Automovil.BackgroundImage = Properties.Resources.rueda;
            pictureBox_Automovil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_Automovil.Location = new System.Drawing.Point(125, 3);
            pictureBox_Automovil.Name = "pictureBox_Automovil";
            pictureBox_Automovil.Size = new System.Drawing.Size(40, 39);
            pictureBox_Automovil.TabIndex = 38;
            pictureBox_Automovil.TabStop = false;
            // 
            // radioButton_Automovil
            // 
            radioButton_Automovil.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Automovil.Location = new System.Drawing.Point(167, 3);
            radioButton_Automovil.Name = "radioButton_Automovil";
            radioButton_Automovil.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            radioButton_Automovil.Size = new System.Drawing.Size(103, 39);
            radioButton_Automovil.TabIndex = 36;
            radioButton_Automovil.TabStop = true;
            radioButton_Automovil.Text = "VEHICULO";
            radioButton_Automovil.UseVisualStyleBackColor = true;
            // 
            // radioButton_Motovehiculo
            // 
            radioButton_Motovehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Motovehiculo.Location = new System.Drawing.Point(380, 3);
            radioButton_Motovehiculo.Name = "radioButton_Motovehiculo";
            radioButton_Motovehiculo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            radioButton_Motovehiculo.Size = new System.Drawing.Size(95, 39);
            radioButton_Motovehiculo.TabIndex = 37;
            radioButton_Motovehiculo.TabStop = true;
            radioButton_Motovehiculo.Text = "PERSONA";
            radioButton_Motovehiculo.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Motovehiculo
            // 
            pictureBox_Motovehiculo.BackgroundImage = Properties.Resources.persona;
            pictureBox_Motovehiculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_Motovehiculo.Location = new System.Drawing.Point(338, 3);
            pictureBox_Motovehiculo.Name = "pictureBox_Motovehiculo";
            pictureBox_Motovehiculo.Size = new System.Drawing.Size(40, 39);
            pictureBox_Motovehiculo.TabIndex = 39;
            pictureBox_Motovehiculo.TabStop = false;
            // 
            // label_Dominio
            // 
            label_Dominio.AutoSize = true;
            label_Dominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dominio.Location = new System.Drawing.Point(178, 4);
            label_Dominio.Name = "label_Dominio";
            label_Dominio.Size = new System.Drawing.Size(75, 15);
            label_Dominio.TabIndex = 99;
            label_Dominio.Text = "DOMINIO :";
            // 
            // label_Chasis
            // 
            label_Chasis.AutoSize = true;
            label_Chasis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Chasis.Location = new System.Drawing.Point(283, 59);
            label_Chasis.Name = "label_Chasis";
            label_Chasis.Size = new System.Drawing.Size(84, 15);
            label_Chasis.TabIndex = 98;
            label_Chasis.Text = "N° CHASIS :";
            // 
            // label_Motor
            // 
            label_Motor.AutoSize = true;
            label_Motor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Motor.Location = new System.Drawing.Point(11, 58);
            label_Motor.Name = "label_Motor";
            label_Motor.Size = new System.Drawing.Size(85, 15);
            label_Motor.TabIndex = 97;
            label_Motor.Text = "N° MOTOR :";
            // 
            // label_Modelo
            // 
            label_Modelo.AutoSize = true;
            label_Modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Modelo.Location = new System.Drawing.Point(294, 34);
            label_Modelo.Name = "label_Modelo";
            label_Modelo.Size = new System.Drawing.Size(74, 15);
            label_Modelo.TabIndex = 96;
            label_Modelo.Text = "MODELO :";
            // 
            // textBox_Dominio
            // 
            textBox_Dominio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Dominio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Dominio.BackColor = System.Drawing.Color.White;
            textBox_Dominio.ErrorColor = System.Drawing.Color.Red;
            textBox_Dominio.FocusColor = System.Drawing.Color.Blue;
            textBox_Dominio.Location = new System.Drawing.Point(255, 3);
            textBox_Dominio.MaxLength = 32767;
            textBox_Dominio.Multiline = false;
            textBox_Dominio.Name = "textBox_Dominio";
            textBox_Dominio.PasswordChar = '\0';
            textBox_Dominio.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Dominio.PlaceholderText = "";
            textBox_Dominio.ReadOnly = false;
            textBox_Dominio.SelectionStart = 0;
            textBox_Dominio.ShowError = false;
            textBox_Dominio.Size = new System.Drawing.Size(171, 21);
            textBox_Dominio.TabIndex = 102;
            textBox_Dominio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Dominio.TextValue = "";
            textBox_Dominio.Whidth = 0;
            // 
            // label_Marca
            // 
            label_Marca.AutoSize = true;
            label_Marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Marca.Location = new System.Drawing.Point(34, 34);
            label_Marca.Name = "label_Marca";
            label_Marca.Size = new System.Drawing.Size(62, 15);
            label_Marca.TabIndex = 95;
            label_Marca.Text = "MARCA :";
            // 
            // comboBox_Modelo
            // 
            comboBox_Modelo.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Modelo.ArrowImage");
            comboBox_Modelo.ArrowPictureBox = null;
            comboBox_Modelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Modelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Modelo.BackColor = System.Drawing.Color.White;
            comboBox_Modelo.DataSource = null;
            comboBox_Modelo.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Modelo.DefaultImage");
            comboBox_Modelo.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Modelo.DisabledImage");
            comboBox_Modelo.DisplayMember = null;
            comboBox_Modelo.DropDownHeight = 252;
            comboBox_Modelo.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Modelo.DroppedDown = false;
            comboBox_Modelo.ErrorColor = System.Drawing.Color.Red;
            comboBox_Modelo.FocusColor = System.Drawing.Color.Blue;
            comboBox_Modelo.ForeColor = System.Drawing.Color.Gray;
            comboBox_Modelo.Location = new System.Drawing.Point(372, 34);
            comboBox_Modelo.MaxDropDownItems = 10;
            comboBox_Modelo.Name = "comboBox_Modelo";
            comboBox_Modelo.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Modelo.PlaceholderText = " ";
            comboBox_Modelo.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Modelo.PressedImage");
            comboBox_Modelo.SelectedIndex = -1;
            comboBox_Modelo.SelectedItem = null;
            comboBox_Modelo.SelectedText = "";
            comboBox_Modelo.SelectionStart = 0;
            comboBox_Modelo.ShowError = false;
            comboBox_Modelo.Size = new System.Drawing.Size(171, 22);
            comboBox_Modelo.TabIndex = 93;
            comboBox_Modelo.Text = " ";
            comboBox_Modelo.TextValue = " ";
            // 
            // textBox_Motor
            // 
            textBox_Motor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Motor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Motor.BackColor = System.Drawing.Color.White;
            textBox_Motor.ErrorColor = System.Drawing.Color.Red;
            textBox_Motor.FocusColor = System.Drawing.Color.Blue;
            textBox_Motor.Location = new System.Drawing.Point(98, 58);
            textBox_Motor.MaxLength = 32767;
            textBox_Motor.Multiline = false;
            textBox_Motor.Name = "textBox_Motor";
            textBox_Motor.PasswordChar = '\0';
            textBox_Motor.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Motor.PlaceholderText = "";
            textBox_Motor.ReadOnly = false;
            textBox_Motor.SelectionStart = 0;
            textBox_Motor.ShowError = false;
            textBox_Motor.Size = new System.Drawing.Size(171, 21);
            textBox_Motor.TabIndex = 104;
            textBox_Motor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Motor.TextValue = "";
            textBox_Motor.Whidth = 0;
            // 
            // comboBox_Marca
            // 
            comboBox_Marca.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Marca.ArrowImage");
            comboBox_Marca.ArrowPictureBox = null;
            comboBox_Marca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Marca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Marca.BackColor = System.Drawing.Color.White;
            comboBox_Marca.DataSource = null;
            comboBox_Marca.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Marca.DefaultImage");
            comboBox_Marca.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Marca.DisabledImage");
            comboBox_Marca.DisplayMember = null;
            comboBox_Marca.DropDownHeight = 252;
            comboBox_Marca.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Marca.DroppedDown = false;
            comboBox_Marca.ErrorColor = System.Drawing.Color.Red;
            comboBox_Marca.FocusColor = System.Drawing.Color.Blue;
            comboBox_Marca.ForeColor = System.Drawing.Color.Gray;
            comboBox_Marca.Location = new System.Drawing.Point(98, 33);
            comboBox_Marca.MaxDropDownItems = 10;
            comboBox_Marca.Name = "comboBox_Marca";
            comboBox_Marca.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Marca.PlaceholderText = " ";
            comboBox_Marca.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Marca.PressedImage");
            comboBox_Marca.SelectedIndex = -1;
            comboBox_Marca.SelectedItem = null;
            comboBox_Marca.SelectedText = "";
            comboBox_Marca.SelectionStart = 0;
            comboBox_Marca.ShowError = false;
            comboBox_Marca.Size = new System.Drawing.Size(171, 22);
            comboBox_Marca.TabIndex = 94;
            comboBox_Marca.Text = " ";
            comboBox_Marca.TextValue = " ";
            // 
            // textBox_Chasis
            // 
            textBox_Chasis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Chasis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Chasis.BackColor = System.Drawing.Color.White;
            textBox_Chasis.ErrorColor = System.Drawing.Color.Red;
            textBox_Chasis.FocusColor = System.Drawing.Color.Blue;
            textBox_Chasis.Location = new System.Drawing.Point(372, 58);
            textBox_Chasis.MaxLength = 32767;
            textBox_Chasis.Multiline = false;
            textBox_Chasis.Name = "textBox_Chasis";
            textBox_Chasis.PasswordChar = '\0';
            textBox_Chasis.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Chasis.PlaceholderText = "";
            textBox_Chasis.ReadOnly = false;
            textBox_Chasis.SelectionStart = 0;
            textBox_Chasis.ShowError = false;
            textBox_Chasis.Size = new System.Drawing.Size(171, 21);
            textBox_Chasis.TabIndex = 105;
            textBox_Chasis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Chasis.TextValue = "";
            textBox_Chasis.Whidth = 0;
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Nombre.BackColor = System.Drawing.Color.White;
            textBox_Nombre.ErrorColor = System.Drawing.Color.Red;
            textBox_Nombre.FocusColor = System.Drawing.Color.Blue;
            textBox_Nombre.Location = new System.Drawing.Point(98, 33);
            textBox_Nombre.MaxLength = 32767;
            textBox_Nombre.Multiline = false;
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.PasswordChar = '\0';
            textBox_Nombre.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Nombre.PlaceholderText = "";
            textBox_Nombre.ReadOnly = false;
            textBox_Nombre.SelectionStart = 0;
            textBox_Nombre.ShowError = false;
            textBox_Nombre.Size = new System.Drawing.Size(399, 20);
            textBox_Nombre.TabIndex = 106;
            textBox_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Nombre.TextValue = "";
            textBox_Nombre.Whidth = 0;
            // 
            // label_Nombre
            // 
            label_Nombre.AutoSize = true;
            label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nombre.Location = new System.Drawing.Point(20, 33);
            label_Nombre.Name = "label_Nombre";
            label_Nombre.Size = new System.Drawing.Size(75, 15);
            label_Nombre.TabIndex = 108;
            label_Nombre.Text = "NOMBRE :";
            // 
            // textBox_Dni
            // 
            textBox_Dni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Dni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Dni.BackColor = System.Drawing.Color.White;
            textBox_Dni.ErrorColor = System.Drawing.Color.Red;
            textBox_Dni.FocusColor = System.Drawing.Color.Blue;
            textBox_Dni.Location = new System.Drawing.Point(97, 7);
            textBox_Dni.MaxLength = 32767;
            textBox_Dni.Multiline = false;
            textBox_Dni.Name = "textBox_Dni";
            textBox_Dni.PasswordChar = '\0';
            textBox_Dni.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Dni.PlaceholderText = "";
            textBox_Dni.ReadOnly = false;
            textBox_Dni.SelectionStart = 0;
            textBox_Dni.ShowError = false;
            textBox_Dni.Size = new System.Drawing.Size(162, 20);
            textBox_Dni.TabIndex = 110;
            textBox_Dni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Dni.TextValue = "";
            textBox_Dni.Whidth = 0;
            // 
            // label_Dni
            // 
            label_Dni.AutoSize = true;
            label_Dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dni.Location = new System.Drawing.Point(56, 8);
            label_Dni.Name = "label_Dni";
            label_Dni.Size = new System.Drawing.Size(39, 15);
            label_Dni.TabIndex = 111;
            label_Dni.Text = "DNI :";
            // 
            // customTextBox1
            // 
            customTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            customTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            customTextBox1.BackColor = System.Drawing.Color.White;
            customTextBox1.ErrorColor = System.Drawing.Color.Red;
            customTextBox1.FocusColor = System.Drawing.Color.Blue;
            customTextBox1.Location = new System.Drawing.Point(335, 7);
            customTextBox1.MaxLength = 32767;
            customTextBox1.Multiline = false;
            customTextBox1.Name = "customTextBox1";
            customTextBox1.PasswordChar = '\0';
            customTextBox1.PlaceholderColor = System.Drawing.Color.Gray;
            customTextBox1.PlaceholderText = "";
            customTextBox1.ReadOnly = false;
            customTextBox1.SelectionStart = 0;
            customTextBox1.ShowError = false;
            customTextBox1.Size = new System.Drawing.Size(162, 20);
            customTextBox1.TabIndex = 112;
            customTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            customTextBox1.TextValue = "";
            customTextBox1.Whidth = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(273, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 15);
            label1.TabIndex = 113;
            label1.Text = "CLASE :";
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(pictureBox_Motovehiculo);
            panel2.Controls.Add(radioButton_Automovil);
            panel2.Controls.Add(pictureBox_Automovil);
            panel2.Controls.Add(radioButton_Motovehiculo);
            panel2.Location = new System.Drawing.Point(3, 63);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(577, 51);
            panel2.TabIndex = 114;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox_Dominio);
            panel3.Controls.Add(label_Dominio);
            panel3.Controls.Add(label_Chasis);
            panel3.Controls.Add(label_Motor);
            panel3.Controls.Add(label_Modelo);
            panel3.Controls.Add(label_Marca);
            panel3.Controls.Add(comboBox_Modelo);
            panel3.Controls.Add(textBox_Motor);
            panel3.Controls.Add(textBox_Chasis);
            panel3.Controls.Add(comboBox_Marca);
            panel3.Location = new System.Drawing.Point(6, 120);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(559, 86);
            panel3.TabIndex = 115;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label_Nombre);
            panel4.Controls.Add(textBox_Nombre);
            panel4.Controls.Add(customTextBox1);
            panel4.Controls.Add(label_Dni);
            panel4.Controls.Add(textBox_Dni);
            panel4.Location = new System.Drawing.Point(6, 212);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(559, 62);
            panel4.TabIndex = 116;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.agregar_General;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button1.Location = new System.Drawing.Point(532, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(30, 27);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = true;
            // 
            // MensajeEnviarEmail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 390);
            Controls.Add(panel1);
            Name = "MensajeEnviarEmail";
            Text = "MensajeEnviarEmail";
            Load += MensajeEnviarEmail_Load;
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Icono).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Automovil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Motovehiculo).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Texto;
        private System.Windows.Forms.PictureBox pictureBox_Icono;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Si;
        private System.Windows.Forms.PictureBox pictureBox_Automovil;
        private System.Windows.Forms.RadioButton radioButton_Automovil;
        private System.Windows.Forms.PictureBox pictureBox_Motovehiculo;
        private System.Windows.Forms.RadioButton radioButton_Motovehiculo;
        private Controles.General.CustomTextBox textBox_Chasis;
        private Controles.General.CustomComboBox comboBox_Marca;
        private Controles.General.CustomTextBox textBox_Motor;
        private Controles.General.CustomComboBox comboBox_Modelo;
        private System.Windows.Forms.Label label_Marca;
        private Controles.General.CustomTextBox textBox_Dominio;
        private System.Windows.Forms.Label label_Modelo;
        private System.Windows.Forms.Label label_Motor;
        private System.Windows.Forms.Label label_Chasis;
        private System.Windows.Forms.Label label_Dominio;
        private System.Windows.Forms.Panel panel2;
        private Controles.General.CustomTextBox customTextBox1;
        private System.Windows.Forms.Label label1;
        private Controles.General.CustomTextBox textBox_Dni;
        private System.Windows.Forms.Label label_Dni;
        private Controles.General.CustomTextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
    }
}