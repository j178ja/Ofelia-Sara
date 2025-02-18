namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class BuscarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarForm));
            panel1 = new System.Windows.Forms.Panel();
            Fecha_Actuacion = new Controles.Ofl_Sara.TimePickerPersonalizado();
            comboBox_Secretario = new Controles.General.CustomComboBox();
            comboBox_Instructor = new Controles.General.CustomComboBox();
            comboBox_Dependencia = new Controles.General.CustomComboBox();
            label_00 = new System.Windows.Forms.Label();
            comboBox_Ipp4 = new Controles.General.CustomComboBox();
            comboBox_Ipp2 = new Controles.General.CustomComboBox();
            comboBox_Ipp1 = new Controles.General.CustomComboBox();
            label_Caratula = new System.Windows.Forms.Label();
            textBox_Caratula = new Controles.General.CustomTextBox();
            btn_Buscar = new System.Windows.Forms.Button();
            btn_Limpiar = new System.Windows.Forms.Button();
            label_Fecha = new System.Windows.Forms.Label();
            label_Secretario = new System.Windows.Forms.Label();
            label_Instructor = new System.Windows.Forms.Label();
            label_Dependencia = new System.Windows.Forms.Label();
            label_Imputado = new System.Windows.Forms.Label();
            label_Victima = new System.Windows.Forms.Label();
            textBox_NumeroIpp = new Controles.General.CustomTextBox();
            textBox_Imputado = new Controles.General.CustomTextBox();
            textBox_Victima = new Controles.General.CustomTextBox();
            label_Ipp = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(Fecha_Actuacion);
            panel1.Controls.Add(comboBox_Secretario);
            panel1.Controls.Add(comboBox_Instructor);
            panel1.Controls.Add(comboBox_Dependencia);
            panel1.Controls.Add(label_00);
            panel1.Controls.Add(comboBox_Ipp4);
            panel1.Controls.Add(comboBox_Ipp2);
            panel1.Controls.Add(comboBox_Ipp1);
            panel1.Controls.Add(label_Caratula);
            panel1.Controls.Add(textBox_Caratula);
            panel1.Controls.Add(btn_Buscar);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(label_Fecha);
            panel1.Controls.Add(label_Secretario);
            panel1.Controls.Add(label_Instructor);
            panel1.Controls.Add(label_Dependencia);
            panel1.Controls.Add(label_Imputado);
            panel1.Controls.Add(label_Victima);
            panel1.Controls.Add(textBox_NumeroIpp);
            panel1.Controls.Add(textBox_Imputado);
            panel1.Controls.Add(textBox_Victima);
            panel1.Controls.Add(label_Ipp);
            panel1.Location = new System.Drawing.Point(20, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(536, 396);
            panel1.TabIndex = 2;
            // 
            // Fecha_Actuacion
            // 
            Fecha_Actuacion.BackColor = System.Drawing.SystemColors.Window;
            Fecha_Actuacion.FechaSeleccionada = new System.DateTime(0L);
            Fecha_Actuacion.Location = new System.Drawing.Point(141, 267);
            Fecha_Actuacion.Name = "Fecha_Actuacion";
            Fecha_Actuacion.Size = new System.Drawing.Size(364, 26);
            Fecha_Actuacion.TabIndex = 29;
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
            comboBox_Secretario.DropDownHeight = 96;
            comboBox_Secretario.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Secretario.DroppedDown = false;
            comboBox_Secretario.ErrorColor = System.Drawing.Color.Red;
            comboBox_Secretario.FocusColor = System.Drawing.Color.Blue;
            comboBox_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Secretario.Location = new System.Drawing.Point(142, 231);
            comboBox_Secretario.MaxDropDownItems = 5;
            comboBox_Secretario.Name = "comboBox_Secretario";
            comboBox_Secretario.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Secretario.PlaceholderText = " ";
            comboBox_Secretario.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Secretario.PressedImage");
            comboBox_Secretario.SelectedIndex = -1;
            comboBox_Secretario.SelectedItem = null;
            comboBox_Secretario.SelectedText = "";
            comboBox_Secretario.SelectionStart = 0;
            comboBox_Secretario.ShowError = false;
            comboBox_Secretario.Size = new System.Drawing.Size(363, 26);
            comboBox_Secretario.TabIndex = 28;
            comboBox_Secretario.TextValue = " ";
            comboBox_Secretario.TextChanged += ComboBox_Secretario_TextChanged;
            comboBox_Secretario.KeyPress += ComboBox_Secretario_KeyPress;
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
            comboBox_Instructor.DropDownHeight = 96;
            comboBox_Instructor.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Instructor.DroppedDown = false;
            comboBox_Instructor.ErrorColor = System.Drawing.Color.Red;
            comboBox_Instructor.FocusColor = System.Drawing.Color.Blue;
            comboBox_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Instructor.Location = new System.Drawing.Point(142, 196);
            comboBox_Instructor.MaxDropDownItems = 5;
            comboBox_Instructor.Name = "comboBox_Instructor";
            comboBox_Instructor.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Instructor.PlaceholderText = " ";
            comboBox_Instructor.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Instructor.PressedImage");
            comboBox_Instructor.SelectedIndex = -1;
            comboBox_Instructor.SelectedItem = null;
            comboBox_Instructor.SelectedText = "";
            comboBox_Instructor.SelectionStart = 0;
            comboBox_Instructor.ShowError = false;
            comboBox_Instructor.Size = new System.Drawing.Size(363, 26);
            comboBox_Instructor.TabIndex = 27;
            comboBox_Instructor.TextValue = " ";
            comboBox_Instructor.TextChanged += ComboBox_Instructor_TextChanged;
            comboBox_Instructor.KeyPress += ComboBox_Instructor_KeyPress;
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
            comboBox_Dependencia.DropDownHeight = 96;
            comboBox_Dependencia.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Dependencia.DroppedDown = false;
            comboBox_Dependencia.ErrorColor = System.Drawing.Color.Red;
            comboBox_Dependencia.FocusColor = System.Drawing.Color.Blue;
            comboBox_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Dependencia.Location = new System.Drawing.Point(142, 161);
            comboBox_Dependencia.MaxDropDownItems = 5;
            comboBox_Dependencia.Name = "comboBox_Dependencia";
            comboBox_Dependencia.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Dependencia.PlaceholderText = " ";
            comboBox_Dependencia.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Dependencia.PressedImage");
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Dependencia.SelectedItem = null;
            comboBox_Dependencia.SelectedText = "";
            comboBox_Dependencia.SelectionStart = 0;
            comboBox_Dependencia.ShowError = false;
            comboBox_Dependencia.Size = new System.Drawing.Size(363, 26);
            comboBox_Dependencia.TabIndex = 26;
            comboBox_Dependencia.TextValue = " ";
            comboBox_Dependencia.TextChanged += ComboBox_Dependencia_TextChanged;
            comboBox_Dependencia.KeyPress += ComboBox_Dependencia_KeyPress;
            // 
            // label_00
            // 
            label_00.AutoSize = true;
            label_00.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_00.Location = new System.Drawing.Point(465, 30);
            label_00.Name = "label_00";
            label_00.Size = new System.Drawing.Size(28, 16);
            label_00.TabIndex = 25;
            label_00.Text = "/00";
            // 
            // comboBox_Ipp4
            // 
            comboBox_Ipp4.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp4.ArrowImage");
            comboBox_Ipp4.ArrowPictureBox = null;
            comboBox_Ipp4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp4.BackColor = System.Drawing.Color.White;
            comboBox_Ipp4.DataSource = null;
            comboBox_Ipp4.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp4.DefaultImage");
            comboBox_Ipp4.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp4.DisabledImage");
            comboBox_Ipp4.DisplayMember = null;
            comboBox_Ipp4.DropDownHeight = 96;
            comboBox_Ipp4.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp4.DroppedDown = false;
            comboBox_Ipp4.ErrorColor = System.Drawing.Color.Red;
            comboBox_Ipp4.FocusColor = System.Drawing.Color.Blue;
            comboBox_Ipp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Ipp4.Location = new System.Drawing.Point(402, 24);
            comboBox_Ipp4.MaxDropDownItems = 5;
            comboBox_Ipp4.Name = "comboBox_Ipp4";
            comboBox_Ipp4.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Ipp4.PlaceholderText = " ";
            comboBox_Ipp4.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp4.PressedImage");
            comboBox_Ipp4.SelectedIndex = -1;
            comboBox_Ipp4.SelectedItem = null;
            comboBox_Ipp4.SelectedText = "";
            comboBox_Ipp4.SelectionStart = 0;
            comboBox_Ipp4.ShowError = false;
            comboBox_Ipp4.Size = new System.Drawing.Size(57, 26);
            comboBox_Ipp4.TabIndex = 24;
            comboBox_Ipp4.TextValue = " ";
            comboBox_Ipp4.KeyPress += ComboBox_Ipp4_KeyPress;
            // 
            // comboBox_Ipp2
            // 
            comboBox_Ipp2.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp2.ArrowImage");
            comboBox_Ipp2.ArrowPictureBox = null;
            comboBox_Ipp2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp2.BackColor = System.Drawing.Color.White;
            comboBox_Ipp2.DataSource = null;
            comboBox_Ipp2.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp2.DefaultImage");
            comboBox_Ipp2.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp2.DisabledImage");
            comboBox_Ipp2.DisplayMember = null;
            comboBox_Ipp2.DropDownHeight = 96;
            comboBox_Ipp2.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp2.DroppedDown = false;
            comboBox_Ipp2.ErrorColor = System.Drawing.Color.Red;
            comboBox_Ipp2.FocusColor = System.Drawing.Color.Blue;
            comboBox_Ipp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Ipp2.Location = new System.Drawing.Point(205, 24);
            comboBox_Ipp2.MaxDropDownItems = 5;
            comboBox_Ipp2.Name = "comboBox_Ipp2";
            comboBox_Ipp2.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Ipp2.PlaceholderText = " ";
            comboBox_Ipp2.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp2.PressedImage");
            comboBox_Ipp2.SelectedIndex = -1;
            comboBox_Ipp2.SelectedItem = null;
            comboBox_Ipp2.SelectedText = "";
            comboBox_Ipp2.SelectionStart = 0;
            comboBox_Ipp2.ShowError = false;
            comboBox_Ipp2.Size = new System.Drawing.Size(57, 26);
            comboBox_Ipp2.TabIndex = 23;
            comboBox_Ipp2.TextValue = " ";
            comboBox_Ipp2.KeyPress += ComboBox_Ipp2_KeyPress;
            // 
            // comboBox_Ipp1
            // 
            comboBox_Ipp1.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp1.ArrowImage");
            comboBox_Ipp1.ArrowPictureBox = null;
            comboBox_Ipp1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp1.BackColor = System.Drawing.Color.White;
            comboBox_Ipp1.DataSource = null;
            comboBox_Ipp1.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp1.DefaultImage");
            comboBox_Ipp1.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp1.DisabledImage");
            comboBox_Ipp1.DisplayMember = null;
            comboBox_Ipp1.DropDownHeight = 96;
            comboBox_Ipp1.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp1.DroppedDown = false;
            comboBox_Ipp1.ErrorColor = System.Drawing.Color.Red;
            comboBox_Ipp1.FocusColor = System.Drawing.Color.Blue;
            comboBox_Ipp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Ipp1.Location = new System.Drawing.Point(142, 24);
            comboBox_Ipp1.MaxDropDownItems = 5;
            comboBox_Ipp1.Name = "comboBox_Ipp1";
            comboBox_Ipp1.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Ipp1.PlaceholderText = " ";
            comboBox_Ipp1.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp1.PressedImage");
            comboBox_Ipp1.SelectedIndex = -1;
            comboBox_Ipp1.SelectedItem = null;
            comboBox_Ipp1.SelectedText = "";
            comboBox_Ipp1.SelectionStart = 0;
            comboBox_Ipp1.ShowError = false;
            comboBox_Ipp1.Size = new System.Drawing.Size(57, 26);
            comboBox_Ipp1.TabIndex = 3;
            comboBox_Ipp1.TextValue = " ";
            comboBox_Ipp1.KeyPress += ComboBox_Ipp1_KeyPress;
            // 
            // label_Caratula
            // 
            label_Caratula.AutoSize = true;
            label_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Caratula.Location = new System.Drawing.Point(47, 64);
            label_Caratula.Name = "label_Caratula";
            label_Caratula.Size = new System.Drawing.Size(87, 16);
            label_Caratula.TabIndex = 22;
            label_Caratula.Text = "CARATULA";
            // 
            // textBox_Caratula
            // 
            textBox_Caratula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Caratula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Caratula.BackColor = System.Drawing.Color.White;
            textBox_Caratula.ErrorColor = System.Drawing.Color.Red;
            textBox_Caratula.FocusColor = System.Drawing.Color.Blue;
            textBox_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Caratula.Location = new System.Drawing.Point(142, 58);
            textBox_Caratula.MaxLength = 32767;
            textBox_Caratula.Multiline = false;
            textBox_Caratula.Name = "textBox_Caratula";
            textBox_Caratula.PasswordChar = '\0';
            textBox_Caratula.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Caratula.PlaceholderText = "";
            textBox_Caratula.ReadOnly = false;
            textBox_Caratula.SelectionStart = 0;
            textBox_Caratula.ShowError = false;
            textBox_Caratula.Size = new System.Drawing.Size(363, 26);
            textBox_Caratula.TabIndex = 1;
            textBox_Caratula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Caratula.TextValue = "";
            textBox_Caratula.Whidth = 0;
            textBox_Caratula.TextChanged += TextBox_Caratula_TextChanged;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Buscar.Image = (System.Drawing.Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new System.Drawing.Point(430, 310);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new System.Drawing.Size(75, 67);
            btn_Buscar.TabIndex = 8;
            btn_Buscar.UseVisualStyleBackColor = false;
            btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(142, 310);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 9;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // label_Fecha
            // 
            label_Fecha.AutoSize = true;
            label_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Fecha.Location = new System.Drawing.Point(77, 267);
            label_Fecha.Name = "label_Fecha";
            label_Fecha.Size = new System.Drawing.Size(57, 16);
            label_Fecha.TabIndex = 11;
            label_Fecha.Text = "FECHA";
            // 
            // label_Secretario
            // 
            label_Secretario.AutoSize = true;
            label_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Secretario.Location = new System.Drawing.Point(30, 236);
            label_Secretario.Name = "label_Secretario";
            label_Secretario.Size = new System.Drawing.Size(104, 16);
            label_Secretario.TabIndex = 10;
            label_Secretario.Text = "SECRETARIO";
            // 
            // label_Instructor
            // 
            label_Instructor.AutoSize = true;
            label_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Instructor.Location = new System.Drawing.Point(30, 201);
            label_Instructor.Name = "label_Instructor";
            label_Instructor.Size = new System.Drawing.Size(106, 16);
            label_Instructor.TabIndex = 9;
            label_Instructor.Text = "INSTRUCTOR";
            // 
            // label_Dependencia
            // 
            label_Dependencia.AutoSize = true;
            label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dependencia.Location = new System.Drawing.Point(21, 166);
            label_Dependencia.Name = "label_Dependencia";
            label_Dependencia.Size = new System.Drawing.Size(115, 16);
            label_Dependencia.TabIndex = 8;
            label_Dependencia.Text = "DEPENDENCIA";
            // 
            // label_Imputado
            // 
            label_Imputado.AutoSize = true;
            label_Imputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Imputado.Location = new System.Drawing.Point(50, 132);
            label_Imputado.Name = "label_Imputado";
            label_Imputado.Size = new System.Drawing.Size(86, 16);
            label_Imputado.TabIndex = 7;
            label_Imputado.Text = "IMPUTADO";
            // 
            // label_Victima
            // 
            label_Victima.AutoSize = true;
            label_Victima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Victima.Location = new System.Drawing.Point(69, 98);
            label_Victima.Name = "label_Victima";
            label_Victima.Size = new System.Drawing.Size(67, 16);
            label_Victima.TabIndex = 6;
            label_Victima.Text = "VICTIMA";
            // 
            // textBox_NumeroIpp
            // 
            textBox_NumeroIpp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_NumeroIpp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_NumeroIpp.BackColor = System.Drawing.Color.White;
            textBox_NumeroIpp.ErrorColor = System.Drawing.Color.Red;
            textBox_NumeroIpp.FocusColor = System.Drawing.Color.Blue;
            textBox_NumeroIpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_NumeroIpp.Location = new System.Drawing.Point(268, 24);
            textBox_NumeroIpp.MaxLength = 32767;
            textBox_NumeroIpp.Multiline = false;
            textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            textBox_NumeroIpp.PasswordChar = '\0';
            textBox_NumeroIpp.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_NumeroIpp.PlaceholderText = "";
            textBox_NumeroIpp.ReadOnly = false;
            textBox_NumeroIpp.SelectionStart = 0;
            textBox_NumeroIpp.ShowError = false;
            textBox_NumeroIpp.Size = new System.Drawing.Size(128, 26);
            textBox_NumeroIpp.TabIndex = 0;
            textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_NumeroIpp.TextValue = "";
            textBox_NumeroIpp.Whidth = 0;
            textBox_NumeroIpp.TextChanged += TextBox_NumeroIpp_TextChanged;
            textBox_NumeroIpp.KeyPress += TextBox_NumeroIpp_KeyPress;
            // 
            // textBox_Imputado
            // 
            textBox_Imputado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Imputado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Imputado.BackColor = System.Drawing.Color.White;
            textBox_Imputado.ErrorColor = System.Drawing.Color.Red;
            textBox_Imputado.FocusColor = System.Drawing.Color.Blue;
            textBox_Imputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Imputado.Location = new System.Drawing.Point(142, 126);
            textBox_Imputado.MaxLength = 32767;
            textBox_Imputado.Multiline = false;
            textBox_Imputado.Name = "textBox_Imputado";
            textBox_Imputado.PasswordChar = '\0';
            textBox_Imputado.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Imputado.PlaceholderText = "";
            textBox_Imputado.ReadOnly = false;
            textBox_Imputado.SelectionStart = 0;
            textBox_Imputado.ShowError = false;
            textBox_Imputado.Size = new System.Drawing.Size(363, 26);
            textBox_Imputado.TabIndex = 3;
            textBox_Imputado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Imputado.TextValue = "";
            textBox_Imputado.Whidth = 0;
            textBox_Imputado.TextChanged += TextBox_Imputado_TextChanged;
            textBox_Imputado.KeyPress += TextBox_Imputado_KeyPress;
            // 
            // textBox_Victima
            // 
            textBox_Victima.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Victima.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Victima.BackColor = System.Drawing.Color.White;
            textBox_Victima.ErrorColor = System.Drawing.Color.Red;
            textBox_Victima.FocusColor = System.Drawing.Color.Blue;
            textBox_Victima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Victima.Location = new System.Drawing.Point(142, 92);
            textBox_Victima.MaxLength = 32767;
            textBox_Victima.Multiline = false;
            textBox_Victima.Name = "textBox_Victima";
            textBox_Victima.PasswordChar = '\0';
            textBox_Victima.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Victima.PlaceholderText = "";
            textBox_Victima.ReadOnly = false;
            textBox_Victima.SelectionStart = 0;
            textBox_Victima.ShowError = false;
            textBox_Victima.Size = new System.Drawing.Size(363, 26);
            textBox_Victima.TabIndex = 2;
            textBox_Victima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Victima.TextValue = "";
            textBox_Victima.Whidth = 0;
            textBox_Victima.TextChanged += TextBox_Victima_TextChanged;
            textBox_Victima.KeyPress += TextBox_Victima_KeyPress;
            // 
            // label_Ipp
            // 
            label_Ipp.AutoSize = true;
            label_Ipp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Ipp.Location = new System.Drawing.Point(93, 29);
            label_Ipp.Name = "label_Ipp";
            label_Ipp.Size = new System.Drawing.Size(43, 16);
            label_Ipp.TabIndex = 0;
            label_Ipp.Text = "I.P.P.";
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(133, 12);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            label_TITULO.Size = new System.Drawing.Size(333, 26);
            label_TITULO.TabIndex = 30;
            label_TITULO.Text = "BUSCAR ARCHIVOS CREADOS";
            // 
            // BuscarForm
            // 
            AcceptButton = btn_Buscar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_Limpiar;
            ClientSize = new System.Drawing.Size(573, 451);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BuscarForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BUSCAR EN BASE DE DATOS";
            HelpButtonClicked += BuscarForm_HelpButtonClicked;
            Load += Buscar_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Ipp;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_NumeroIpp;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Imputado;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Victima;
        private System.Windows.Forms.Label label_Fecha;
        private System.Windows.Forms.Label label_Secretario;
        private System.Windows.Forms.Label label_Instructor;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_Imputado;
        private System.Windows.Forms.Label label_Victima;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_Caratula;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Caratula;
        private System.Windows.Forms.Label label_00;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp4;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp2;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp1;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Secretario;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Instructor;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
       
        private Ofelia_Sara.Controles.Ofl_Sara.TimePickerPersonalizado Fecha_Actuacion;
        private System.Windows.Forms.Label label_TITULO;
    }
}