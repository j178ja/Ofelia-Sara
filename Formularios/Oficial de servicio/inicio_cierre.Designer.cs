using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Clases.General;
using System.Drawing;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class InicioCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioCierre));
            lbl_Dr = new System.Windows.Forms.Label();
            textBox_NumeroIpp = new CustomTextBox();
            lbl_Ipp = new System.Windows.Forms.Label();
            lbl_Caratula = new System.Windows.Forms.Label();
            lbl_Victima = new System.Windows.Forms.Label();
            lbl_Imputado = new System.Windows.Forms.Label();
            lbl_Ufid = new System.Windows.Forms.Label();
            lbl_Instructor = new System.Windows.Forms.Label();
            lbl_Secretario = new System.Windows.Forms.Label();
            lbl_Fecha = new System.Windows.Forms.Label();
            lbl_Dependencia = new System.Windows.Forms.Label();
            textBox_Caratula = new CustomTextBox();
            textBox_Victima = new CustomTextBox();
            textBox_Imputado = new CustomTextBox();
            comboBox_Fiscalia = new CustomComboBox();
            comboBox_Instructor = new CustomComboBox();
            comboBox_Secretario = new CustomComboBox();
            comboBox_Dependencia = new CustomComboBox();
            comboBox_AgenteFiscal = new CustomComboBox();
            comboBox_Ipp1 = new CustomComboBox();
            comboBox_Ipp2 = new CustomComboBox();
            lbl_00 = new System.Windows.Forms.Label();
            comboBox_Ipp4 = new CustomComboBox();
            btn_Buscar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Imprimir = new System.Windows.Forms.Button();
            btn_AgregarCausa = new System.Windows.Forms.Button();
            btn_AgregarVictima = new System.Windows.Forms.Button();
            btn_AgregarImputado = new System.Windows.Forms.Button();
            toolTip = new System.Windows.Forms.ToolTip(components);
            checkBox_RatificacionTestimonial = new System.Windows.Forms.CheckBox();
            btn_AgregarDatosImputado = new System.Windows.Forms.Button();
            btn_AgregarDatosVictima = new System.Windows.Forms.Button();
            checkBox_Cargo = new System.Windows.Forms.CheckBox();
            panel1 = new System.Windows.Forms.Panel();
            panel_Instruccion = new System.Windows.Forms.Panel();
            timePickerPersonalizado1 = new Controles.Ofl_Sara.TimePickerPersonalizado();
            comboBox_DeptoJudicial = new CustomComboBox();
            lbl_Localida = new System.Windows.Forms.Label();
            lbl_DeptoJudicial = new System.Windows.Forms.Label();
            comboBox_Localidad = new CustomComboBox();
            panel_Ipp = new System.Windows.Forms.Panel();
            panel_Caratula = new System.Windows.Forms.Panel();
            panel_ControlesInferiores = new System.Windows.Forms.Panel();
            panel_Not247 = new System.Windows.Forms.Panel();
            Btn_Contador247 = new Controles.Ofl_Sara.Boton_Contador();
            fecha_Pericia = new System.Windows.Forms.MaskedTextBox();
            botonDeslizable_Not247 = new BotonDeslizable();
            label_Not247 = new System.Windows.Forms.Label();
            Btn_ContadorRML = new Controles.Ofl_Sara.Boton_Contador();
            btn_ContadorRatificaciones = new Controles.Ofl_Sara.Boton_Contador();
            label_StudRML = new System.Windows.Forms.Label();
            pictureBox_CheckCargo = new System.Windows.Forms.PictureBox();
            pictureBox_CheckRatificacion = new System.Windows.Forms.PictureBox();
            label_Cargo = new System.Windows.Forms.Label();
            label_RatificacionPersonal = new System.Windows.Forms.Label();
            panel_Imputado = new System.Windows.Forms.Panel();
            panel_Victima = new System.Windows.Forms.Panel();
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel_Instruccion.SuspendLayout();
            panel_Ipp.SuspendLayout();
            panel_Caratula.SuspendLayout();
            panel_ControlesInferiores.SuspendLayout();
            panel_Not247.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckCargo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckRatificacion).BeginInit();
            panel_Imputado.SuspendLayout();
            panel_Victima.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Dr
            // 
            lbl_Dr.AutoSize = true;
            lbl_Dr.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Dr.Location = new Point(245, 8);
            lbl_Dr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Dr.Name = "lbl_Dr";
            lbl_Dr.Size = new Size(26, 15);
            lbl_Dr.TabIndex = 0;
            lbl_Dr.Text = "Dr.";
            // 
            // textBox_NumeroIpp
            // 
            textBox_NumeroIpp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_NumeroIpp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_NumeroIpp.BackColor = Color.White;
            textBox_NumeroIpp.ErrorColor = Color.Red;
            textBox_NumeroIpp.FocusColor = Color.Blue;
            textBox_NumeroIpp.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_NumeroIpp.Location = new Point(245, 8);
            textBox_NumeroIpp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_NumeroIpp.MaxLength = 32767;
            textBox_NumeroIpp.Multiline = false;
            textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            textBox_NumeroIpp.PasswordChar = '\0';
            textBox_NumeroIpp.ReadOnly = false;
            textBox_NumeroIpp.SelectionStart = 0;
            textBox_NumeroIpp.ShowError = false;
            textBox_NumeroIpp.Size = new Size(111, 21);
            textBox_NumeroIpp.TabIndex = 2;
            textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_NumeroIpp.TextValue = "";
            textBox_NumeroIpp.TextChanged += TextBox_NumeroIpp_TextChanged;
            textBox_NumeroIpp.KeyPress += TextBox_NumeroIpp_KeyPress;
            textBox_NumeroIpp.Leave += TextBox_NumeroIpp_Leave;
            // 
            // lbl_Ipp
            // 
            lbl_Ipp.AutoSize = true;
            lbl_Ipp.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Ipp.Location = new Point(75, 10);
            lbl_Ipp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Ipp.Name = "lbl_Ipp";
            lbl_Ipp.Size = new Size(41, 15);
            lbl_Ipp.TabIndex = 3;
            lbl_Ipp.Text = "l.P.P.";
            // 
            // lbl_Caratula
            // 
            lbl_Caratula.AutoSize = true;
            lbl_Caratula.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Caratula.Location = new Point(13, 6);
            lbl_Caratula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Caratula.Name = "lbl_Caratula";
            lbl_Caratula.Size = new Size(76, 15);
            lbl_Caratula.TabIndex = 4;
            lbl_Caratula.Text = "CARATULA";
            // 
            // lbl_Victima
            // 
            lbl_Victima.AutoSize = true;
            lbl_Victima.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Victima.Location = new Point(75, 5);
            lbl_Victima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Victima.Name = "lbl_Victima";
            lbl_Victima.Size = new Size(60, 15);
            lbl_Victima.TabIndex = 5;
            lbl_Victima.Text = "VICTIMA";
            // 
            // lbl_Imputado
            // 
            lbl_Imputado.AutoSize = true;
            lbl_Imputado.BackColor = Color.Transparent;
            lbl_Imputado.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Imputado.Location = new Point(56, 6);
            lbl_Imputado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Imputado.Name = "lbl_Imputado";
            lbl_Imputado.Size = new Size(78, 15);
            lbl_Imputado.TabIndex = 6;
            lbl_Imputado.Text = "lMPUTADO";
            // 
            // lbl_Ufid
            // 
            lbl_Ufid.AutoSize = true;
            lbl_Ufid.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Ufid.Location = new Point(68, 9);
            lbl_Ufid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Ufid.Name = "lbl_Ufid";
            lbl_Ufid.Size = new Size(51, 15);
            lbl_Ufid.TabIndex = 7;
            lbl_Ufid.Text = "U.F.I.D";
            // 
            // lbl_Instructor
            // 
            lbl_Instructor.AutoSize = true;
            lbl_Instructor.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Instructor.Location = new Point(24, 84);
            lbl_Instructor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Instructor.Name = "lbl_Instructor";
            lbl_Instructor.Size = new Size(95, 15);
            lbl_Instructor.TabIndex = 8;
            lbl_Instructor.Text = "INSTRUCTOR";
            // 
            // lbl_Secretario
            // 
            lbl_Secretario.AutoSize = true;
            lbl_Secretario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Secretario.Location = new Point(26, 111);
            lbl_Secretario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Secretario.Name = "lbl_Secretario";
            lbl_Secretario.Size = new Size(93, 15);
            lbl_Secretario.TabIndex = 9;
            lbl_Secretario.Text = "SECRETARIO";
            // 
            // lbl_Fecha
            // 
            lbl_Fecha.AutoSize = true;
            lbl_Fecha.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Fecha.Location = new Point(68, 166);
            lbl_Fecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Fecha.Name = "lbl_Fecha";
            lbl_Fecha.Size = new Size(51, 15);
            lbl_Fecha.TabIndex = 10;
            lbl_Fecha.Text = "FECHA";
            // 
            // lbl_Dependencia
            // 
            lbl_Dependencia.AutoSize = true;
            lbl_Dependencia.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Dependencia.Location = new Point(14, 142);
            lbl_Dependencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Dependencia.Name = "lbl_Dependencia";
            lbl_Dependencia.Size = new Size(104, 15);
            lbl_Dependencia.TabIndex = 11;
            lbl_Dependencia.Text = "DEPENDENCIA";
            // 
            // textBox_Caratula
            // 
            textBox_Caratula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            textBox_Caratula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            textBox_Caratula.BackColor = Color.White;
            textBox_Caratula.ErrorColor = Color.Red;
            textBox_Caratula.FocusColor = Color.Blue;
            textBox_Caratula.Location = new Point(102, 3);
            textBox_Caratula.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Caratula.MaxLength = 32767;
            textBox_Caratula.Multiline = true;
            textBox_Caratula.Name = "textBox_Caratula";
            textBox_Caratula.PasswordChar = '\0';
            textBox_Caratula.ReadOnly = false;
            textBox_Caratula.SelectionStart = 0;
            textBox_Caratula.ShowError = false;
            textBox_Caratula.Size = new Size(333, 21);
            textBox_Caratula.TabIndex = 0;
            textBox_Caratula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Caratula.TextValue = "";
            textBox_Caratula.TextChanged += TextBox_Caratula_TextChanged;
            textBox_Caratula.KeyPress += TextBox_Caratula_KeyPress;
            // 
            // textBox_Victima
            // 
            textBox_Victima.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Victima.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Victima.BackColor = Color.White;
            textBox_Victima.ErrorColor = Color.Red;
            textBox_Victima.FocusColor = Color.Blue;
            textBox_Victima.Location = new Point(147, 3);
            textBox_Victima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Victima.MaxLength = 32767;
            textBox_Victima.Multiline = false;
            textBox_Victima.Name = "textBox_Victima";
            textBox_Victima.PasswordChar = '\0';
            textBox_Victima.ReadOnly = false;
            textBox_Victima.SelectionStart = 0;
            textBox_Victima.ShowError = false;
            textBox_Victima.Size = new Size(333, 21);
            textBox_Victima.TabIndex = 0;
            textBox_Victima.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Victima.TextValue = "";
            textBox_Victima.TextChanged += TextBox_Victima_TextChanged;
            // 
            // textBox_Imputado
            // 
            textBox_Imputado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Imputado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Imputado.BackColor = Color.White;
            textBox_Imputado.ErrorColor = Color.Red;
            textBox_Imputado.FocusColor = Color.Blue;
            textBox_Imputado.Location = new Point(147, 3);
            textBox_Imputado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Imputado.MaxLength = 32767;
            textBox_Imputado.Multiline = false;
            textBox_Imputado.Name = "textBox_Imputado";
            textBox_Imputado.PasswordChar = '\0';
            textBox_Imputado.ReadOnly = false;
            textBox_Imputado.SelectionStart = 0;
            textBox_Imputado.ShowError = false;
            textBox_Imputado.Size = new Size(333, 21);
            textBox_Imputado.TabIndex = 0;
            textBox_Imputado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Imputado.TextValue = "";
            textBox_Imputado.TextChanged += TextBox_Imputado_TextChanged;
            // 
            // comboBox_Fiscalia
            // 
            comboBox_Fiscalia.ArrowImage = (Image)resources.GetObject("comboBox_Fiscalia.ArrowImage");
            comboBox_Fiscalia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Fiscalia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Fiscalia.BackColor = Color.White;
            comboBox_Fiscalia.DataSource = null;
            comboBox_Fiscalia.DefaultImage = (Image)resources.GetObject("comboBox_Fiscalia.DefaultImage");
            comboBox_Fiscalia.DisabledImage = (Image)resources.GetObject("comboBox_Fiscalia.DisabledImage");
            comboBox_Fiscalia.DisplayMember = null;
            comboBox_Fiscalia.DropDownHeight = 252;
            comboBox_Fiscalia.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Fiscalia.DroppedDown = false;
            comboBox_Fiscalia.ErrorColor = Color.Red;
            comboBox_Fiscalia.FocusColor = Color.Blue;
            comboBox_Fiscalia.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Fiscalia.Location = new Point(132, 3);
            comboBox_Fiscalia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Fiscalia.MaxDropDownItems = 10;
            comboBox_Fiscalia.Name = "comboBox_Fiscalia";
            comboBox_Fiscalia.PlaceholderColor = Color.Gray;
            comboBox_Fiscalia.PlaceholderText = " ";
            comboBox_Fiscalia.PressedImage = (Image)resources.GetObject("comboBox_Fiscalia.PressedImage");
            comboBox_Fiscalia.SelectedIndex = -1;
            comboBox_Fiscalia.SelectedItem = null;
            comboBox_Fiscalia.SelectedText = "";
            comboBox_Fiscalia.SelectionStart = 0;
            comboBox_Fiscalia.ShowError = false;
            comboBox_Fiscalia.Size = new Size(106, 21);
            comboBox_Fiscalia.TabIndex = 0;
            comboBox_Fiscalia.SelectedIndexChanged += ComboBox_Fiscalia_SelectedIndexChanged;
            // 
            // comboBox_Instructor
            // 
            comboBox_Instructor.ArrowImage = (Image)resources.GetObject("comboBox_Instructor.ArrowImage");
            comboBox_Instructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Instructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Instructor.BackColor = Color.White;
            comboBox_Instructor.DataSource = null;
            comboBox_Instructor.DefaultImage = (Image)resources.GetObject("comboBox_Instructor.DefaultImage");
            comboBox_Instructor.DisabledImage = (Image)resources.GetObject("comboBox_Instructor.DisabledImage");
            comboBox_Instructor.DisplayMember = null;
            comboBox_Instructor.DropDownHeight = 252;
            comboBox_Instructor.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Instructor.DroppedDown = false;
            comboBox_Instructor.ErrorColor = Color.Red;
            comboBox_Instructor.FocusColor = Color.Blue;
            comboBox_Instructor.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Instructor.Location = new Point(131, 84);
            comboBox_Instructor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Instructor.MaxDropDownItems = 10;
            comboBox_Instructor.Name = "comboBox_Instructor";
            comboBox_Instructor.PlaceholderColor = Color.Gray;
            comboBox_Instructor.PlaceholderText = " ";
            comboBox_Instructor.PressedImage = (Image)resources.GetObject("comboBox_Instructor.PressedImage");
            comboBox_Instructor.SelectedIndex = -1;
            comboBox_Instructor.SelectedItem = null;
            comboBox_Instructor.SelectedText = "";
            comboBox_Instructor.SelectionStart = 0;
            comboBox_Instructor.ShowError = false;
            comboBox_Instructor.Size = new Size(333, 21);
            comboBox_Instructor.TabIndex = 4;
            comboBox_Instructor.TextChanged += ComboBox_Instructor_TextChanged;
            // 
            // comboBox_Secretario
            // 
            comboBox_Secretario.ArrowImage = (Image)resources.GetObject("comboBox_Secretario.ArrowImage");
            comboBox_Secretario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Secretario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Secretario.BackColor = Color.White;
            comboBox_Secretario.DataSource = null;
            comboBox_Secretario.DefaultImage = (Image)resources.GetObject("comboBox_Secretario.DefaultImage");
            comboBox_Secretario.DisabledImage = (Image)resources.GetObject("comboBox_Secretario.DisabledImage");
            comboBox_Secretario.DisplayMember = null;
            comboBox_Secretario.DropDownHeight = 252;
            comboBox_Secretario.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Secretario.DroppedDown = false;
            comboBox_Secretario.ErrorColor = Color.Red;
            comboBox_Secretario.FocusColor = Color.Blue;
            comboBox_Secretario.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Secretario.Location = new Point(131, 111);
            comboBox_Secretario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Secretario.MaxDropDownItems = 10;
            comboBox_Secretario.Name = "comboBox_Secretario";
            comboBox_Secretario.PlaceholderColor = Color.Gray;
            comboBox_Secretario.PlaceholderText = " ";
            comboBox_Secretario.PressedImage = (Image)resources.GetObject("comboBox_Secretario.PressedImage");
            comboBox_Secretario.SelectedIndex = -1;
            comboBox_Secretario.SelectedItem = null;
            comboBox_Secretario.SelectedText = "";
            comboBox_Secretario.SelectionStart = 0;
            comboBox_Secretario.ShowError = false;
            comboBox_Secretario.Size = new Size(333, 21);
            comboBox_Secretario.TabIndex = 5;
            comboBox_Secretario.TextChanged += ComboBox_Secretario_TextChanged;
            // 
            // comboBox_Dependencia
            // 
            comboBox_Dependencia.ArrowImage = (Image)resources.GetObject("comboBox_Dependencia.ArrowImage");
            comboBox_Dependencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Dependencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Dependencia.BackColor = Color.White;
            comboBox_Dependencia.DataSource = null;
            comboBox_Dependencia.DefaultImage = (Image)resources.GetObject("comboBox_Dependencia.DefaultImage");
            comboBox_Dependencia.DisabledImage = (Image)resources.GetObject("comboBox_Dependencia.DisabledImage");
            comboBox_Dependencia.DisplayMember = null;
            comboBox_Dependencia.DropDownHeight = 252;
            comboBox_Dependencia.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Dependencia.DroppedDown = false;
            comboBox_Dependencia.ErrorColor = Color.Red;
            comboBox_Dependencia.FocusColor = Color.Blue;
            comboBox_Dependencia.Location = new Point(131, 138);
            comboBox_Dependencia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Dependencia.MaxDropDownItems = 10;
            comboBox_Dependencia.Name = "comboBox_Dependencia";
            comboBox_Dependencia.PlaceholderColor = Color.Gray;
            comboBox_Dependencia.PlaceholderText = " ";
            comboBox_Dependencia.PressedImage = (Image)resources.GetObject("comboBox_Dependencia.PressedImage");
            comboBox_Dependencia.SelectedIndex = -1;
            comboBox_Dependencia.SelectedItem = null;
            comboBox_Dependencia.SelectedText = "";
            comboBox_Dependencia.SelectionStart = 0;
            comboBox_Dependencia.ShowError = false;
            comboBox_Dependencia.Size = new Size(333, 22);
            comboBox_Dependencia.TabIndex = 6;
            comboBox_Dependencia.TextChanged += ComboBox_Dependencia_TextChanged;
            // 
            // comboBox_AgenteFiscal
            // 
            comboBox_AgenteFiscal.ArrowImage = (Image)resources.GetObject("comboBox_AgenteFiscal.ArrowImage");
            comboBox_AgenteFiscal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_AgenteFiscal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_AgenteFiscal.BackColor = Color.White;
            comboBox_AgenteFiscal.DataSource = null;
            comboBox_AgenteFiscal.DefaultImage = (Image)resources.GetObject("comboBox_AgenteFiscal.DefaultImage");
            comboBox_AgenteFiscal.DisabledImage = (Image)resources.GetObject("comboBox_AgenteFiscal.DisabledImage");
            comboBox_AgenteFiscal.DisplayMember = null;
            comboBox_AgenteFiscal.DropDownHeight = 252;
            comboBox_AgenteFiscal.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_AgenteFiscal.DroppedDown = false;
            comboBox_AgenteFiscal.ErrorColor = Color.Red;
            comboBox_AgenteFiscal.FocusColor = Color.Blue;
            comboBox_AgenteFiscal.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_AgenteFiscal.Location = new Point(276, 3);
            comboBox_AgenteFiscal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_AgenteFiscal.MaxDropDownItems = 10;
            comboBox_AgenteFiscal.Name = "comboBox_AgenteFiscal";
            comboBox_AgenteFiscal.PlaceholderColor = Color.Gray;
            comboBox_AgenteFiscal.PlaceholderText = " ";
            comboBox_AgenteFiscal.PressedImage = (Image)resources.GetObject("comboBox_AgenteFiscal.PressedImage");
            comboBox_AgenteFiscal.SelectedIndex = -1;
            comboBox_AgenteFiscal.SelectedItem = null;
            comboBox_AgenteFiscal.SelectedText = "";
            comboBox_AgenteFiscal.SelectionStart = 0;
            comboBox_AgenteFiscal.ShowError = false;
            comboBox_AgenteFiscal.Size = new Size(188, 21);
            comboBox_AgenteFiscal.TabIndex = 1;
            comboBox_AgenteFiscal.TextChanged += ComboBox_AgenteFiscal_TextChanged;
            // 
            // comboBox_Ipp1
            // 
            comboBox_Ipp1.ArrowImage = (Image)resources.GetObject("comboBox_Ipp1.ArrowImage");
            comboBox_Ipp1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp1.BackColor = Color.White;
            comboBox_Ipp1.DataSource = null;
            comboBox_Ipp1.DefaultImage = (Image)resources.GetObject("comboBox_Ipp1.DefaultImage");
            comboBox_Ipp1.DisabledImage = (Image)resources.GetObject("comboBox_Ipp1.DisabledImage");
            comboBox_Ipp1.DisplayMember = null;
            comboBox_Ipp1.DropDownHeight = 252;
            comboBox_Ipp1.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Ipp1.DroppedDown = false;
            comboBox_Ipp1.ErrorColor = Color.Red;
            comboBox_Ipp1.FocusColor = Color.Blue;
            comboBox_Ipp1.Location = new Point(130, 7);
            comboBox_Ipp1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Ipp1.MaxDropDownItems = 10;
            comboBox_Ipp1.Name = "comboBox_Ipp1";
            comboBox_Ipp1.PlaceholderColor = Color.Gray;
            comboBox_Ipp1.PlaceholderText = " ";
            comboBox_Ipp1.PressedImage = (Image)resources.GetObject("comboBox_Ipp1.PressedImage");
            comboBox_Ipp1.SelectedIndex = -1;
            comboBox_Ipp1.SelectedItem = null;
            comboBox_Ipp1.SelectedText = "";
            comboBox_Ipp1.SelectionStart = 0;
            comboBox_Ipp1.ShowError = false;
            comboBox_Ipp1.Size = new Size(52, 21);
            comboBox_Ipp1.TabIndex = 0;
            comboBox_Ipp1.KeyPress += ComboBox_Ipp_KeyPress;
            // 
            // comboBox_Ipp2
            // 
            comboBox_Ipp2.ArrowImage = (Image)resources.GetObject("comboBox_Ipp2.ArrowImage");
            comboBox_Ipp2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp2.BackColor = Color.White;
            comboBox_Ipp2.DataSource = null;
            comboBox_Ipp2.DefaultImage = (Image)resources.GetObject("comboBox_Ipp2.DefaultImage");
            comboBox_Ipp2.DisabledImage = (Image)resources.GetObject("comboBox_Ipp2.DisabledImage");
            comboBox_Ipp2.DisplayMember = null;
            comboBox_Ipp2.DropDownHeight = 252;
            comboBox_Ipp2.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Ipp2.DroppedDown = false;
            comboBox_Ipp2.ErrorColor = Color.Red;
            comboBox_Ipp2.FocusColor = Color.Blue;
            comboBox_Ipp2.Location = new Point(187, 7);
            comboBox_Ipp2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Ipp2.MaxDropDownItems = 10;
            comboBox_Ipp2.Name = "comboBox_Ipp2";
            comboBox_Ipp2.PlaceholderColor = Color.Gray;
            comboBox_Ipp2.PlaceholderText = " ";
            comboBox_Ipp2.PressedImage = (Image)resources.GetObject("comboBox_Ipp2.PressedImage");
            comboBox_Ipp2.SelectedIndex = -1;
            comboBox_Ipp2.SelectedItem = null;
            comboBox_Ipp2.SelectedText = "";
            comboBox_Ipp2.SelectionStart = 0;
            comboBox_Ipp2.ShowError = false;
            comboBox_Ipp2.Size = new Size(52, 21);
            comboBox_Ipp2.TabIndex = 1;
            comboBox_Ipp2.KeyPress += ComboBox_Ipp_KeyPress;
            // 
            // lbl_00
            // 
            lbl_00.AutoSize = true;
            lbl_00.Location = new Point(427, 13);
            lbl_00.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_00.Name = "lbl_00";
            lbl_00.Size = new Size(24, 15);
            lbl_00.TabIndex = 26;
            lbl_00.Text = "/00";
            // 
            // comboBox_Ipp4
            // 
            comboBox_Ipp4.ArrowImage = (Image)resources.GetObject("comboBox_Ipp4.ArrowImage");
            comboBox_Ipp4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp4.BackColor = Color.White;
            comboBox_Ipp4.DataSource = null;
            comboBox_Ipp4.DefaultImage = (Image)resources.GetObject("comboBox_Ipp4.DefaultImage");
            comboBox_Ipp4.DisabledImage = (Image)resources.GetObject("comboBox_Ipp4.DisabledImage");
            comboBox_Ipp4.DisplayMember = null;
            comboBox_Ipp4.DropDownHeight = 252;
            comboBox_Ipp4.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Ipp4.DroppedDown = false;
            comboBox_Ipp4.ErrorColor = Color.Red;
            comboBox_Ipp4.FocusColor = Color.Blue;
            comboBox_Ipp4.Location = new Point(364, 7);
            comboBox_Ipp4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Ipp4.MaxDropDownItems = 10;
            comboBox_Ipp4.Name = "comboBox_Ipp4";
            comboBox_Ipp4.PlaceholderColor = Color.Gray;
            comboBox_Ipp4.PlaceholderText = " ";
            comboBox_Ipp4.PressedImage = (Image)resources.GetObject("comboBox_Ipp4.PressedImage");
            comboBox_Ipp4.SelectedIndex = -1;
            comboBox_Ipp4.SelectedItem = null;
            comboBox_Ipp4.SelectedText = "";
            comboBox_Ipp4.SelectionStart = 0;
            comboBox_Ipp4.ShowError = false;
            comboBox_Ipp4.Size = new Size(59, 21);
            comboBox_Ipp4.TabIndex = 3;
            comboBox_Ipp4.KeyPress += ComboBox_Ipp_KeyPress;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Buscar.Image = (Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new Point(27, 92);
            btn_Buscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(88, 77);
            btn_Buscar.TabIndex = 18;
            btn_Buscar.UseVisualStyleBackColor = false;
            btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new Point(144, 92);
            btn_Guardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(88, 77);
            btn_Guardar.TabIndex = 10;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new Point(259, 92);
            btn_Limpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new Size(88, 77);
            btn_Limpiar.TabIndex = 12;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.BackColor = Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Imprimir.Image = (Image)resources.GetObject("btn_Imprimir.Image");
            btn_Imprimir.Location = new Point(374, 83);
            btn_Imprimir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.Size = new Size(108, 96);
            btn_Imprimir.TabIndex = 11;
            btn_Imprimir.UseVisualStyleBackColor = false;
            btn_Imprimir.Click += Btn_Imprimir_Click;
            // 
            // btn_AgregarCausa
            // 
            btn_AgregarCausa.BackColor = Color.White;
            btn_AgregarCausa.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarCausa.FlatAppearance.BorderSize = 3;
            btn_AgregarCausa.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AgregarCausa.Location = new Point(440, 1);
            btn_AgregarCausa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarCausa.Name = "btn_AgregarCausa";
            btn_AgregarCausa.Size = new Size(18, 27);
            btn_AgregarCausa.TabIndex = 27;
            btn_AgregarCausa.Text = "+";
            btn_AgregarCausa.UseVisualStyleBackColor = false;
            btn_AgregarCausa.Click += Btn_AgregarCausa_Click;
            // 
            // btn_AgregarVictima
            // 
            btn_AgregarVictima.BackColor = Color.White;
            btn_AgregarVictima.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarVictima.FlatAppearance.BorderSize = 0;
            btn_AgregarVictima.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AgregarVictima.Location = new Point(485, 2);
            btn_AgregarVictima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarVictima.Name = "btn_AgregarVictima";
            btn_AgregarVictima.Size = new Size(18, 27);
            btn_AgregarVictima.TabIndex = 28;
            btn_AgregarVictima.Text = "+";
            btn_AgregarVictima.UseVisualStyleBackColor = false;
            btn_AgregarVictima.Click += Btn_AgregarVictima_Click;
            // 
            // btn_AgregarImputado
            // 
            btn_AgregarImputado.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarImputado.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AgregarImputado.Location = new Point(484, 1);
            btn_AgregarImputado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarImputado.Name = "btn_AgregarImputado";
            btn_AgregarImputado.Size = new Size(18, 27);
            btn_AgregarImputado.TabIndex = 29;
            btn_AgregarImputado.Text = "+";
            btn_AgregarImputado.UseVisualStyleBackColor = true;
            btn_AgregarImputado.Click += Btn_AgregarImputado_Click;
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 300;
            // 
            // checkBox_RatificacionTestimonial
            // 
            checkBox_RatificacionTestimonial.AutoSize = true;
            checkBox_RatificacionTestimonial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            checkBox_RatificacionTestimonial.CheckAlign = ContentAlignment.BottomCenter;
            checkBox_RatificacionTestimonial.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_RatificacionTestimonial.FlatAppearance.CheckedBackColor = SystemColors.ControlLight;
            checkBox_RatificacionTestimonial.Location = new Point(241, 50);
            checkBox_RatificacionTestimonial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_RatificacionTestimonial.Name = "checkBox_RatificacionTestimonial";
            checkBox_RatificacionTestimonial.Size = new Size(15, 14);
            checkBox_RatificacionTestimonial.TabIndex = 8;
            checkBox_RatificacionTestimonial.TextAlign = ContentAlignment.BottomCenter;
            checkBox_RatificacionTestimonial.UseVisualStyleBackColor = true;
            checkBox_RatificacionTestimonial.CheckedChanged += CheckBox_RatificacionTestimonial_CheckedChanged;
            // 
            // btn_AgregarDatosImputado
            // 
            btn_AgregarDatosImputado.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarDatosImputado.Image = (Image)resources.GetObject("btn_AgregarDatosImputado.Image");
            btn_AgregarDatosImputado.Location = new Point(2, 1);
            btn_AgregarDatosImputado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarDatosImputado.Name = "btn_AgregarDatosImputado";
            btn_AgregarDatosImputado.Size = new Size(31, 27);
            btn_AgregarDatosImputado.TabIndex = 38;
            btn_AgregarDatosImputado.Text = "+";
            btn_AgregarDatosImputado.UseVisualStyleBackColor = true;
            btn_AgregarDatosImputado.Click += Btn_AgregarDatosImputado_Click;
            // 
            // btn_AgregarDatosVictima
            // 
            btn_AgregarDatosVictima.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarDatosVictima.Image = (Image)resources.GetObject("btn_AgregarDatosVictima.Image");
            btn_AgregarDatosVictima.Location = new Point(4, 0);
            btn_AgregarDatosVictima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarDatosVictima.Name = "btn_AgregarDatosVictima";
            btn_AgregarDatosVictima.Size = new Size(31, 27);
            btn_AgregarDatosVictima.TabIndex = 39;
            btn_AgregarDatosVictima.Text = "+";
            btn_AgregarDatosVictima.UseVisualStyleBackColor = true;
            btn_AgregarDatosVictima.Click += Btn_AgregarDatosVictima_Click;
            // 
            // checkBox_Cargo
            // 
            checkBox_Cargo.BackColor = Color.Transparent;
            checkBox_Cargo.CheckAlign = ContentAlignment.BottomCenter;
            checkBox_Cargo.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_Cargo.Location = new Point(456, 44);
            checkBox_Cargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_Cargo.Name = "checkBox_Cargo";
            checkBox_Cargo.Size = new Size(21, 20);
            checkBox_Cargo.TabIndex = 9;
            checkBox_Cargo.UseVisualStyleBackColor = false;
            checkBox_Cargo.CheckedChanged += CheckBox_Cargo_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel1.AutoScrollMargin = new Size(5, 0);
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel_Instruccion);
            panel1.Controls.Add(panel_Ipp);
            panel1.Controls.Add(panel_Caratula);
            panel1.Controls.Add(panel_ControlesInferiores);
            panel1.Controls.Add(panel_Imputado);
            panel1.Controls.Add(panel_Victima);
            panel1.Location = new Point(21, 23);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.MinimumSize = new Size(532, 556);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 566);
            panel1.TabIndex = 30;
            panel1.TabStop = true;
            // 
            // panel_Instruccion
            // 
            panel_Instruccion.Controls.Add(timePickerPersonalizado1);
            panel_Instruccion.Controls.Add(comboBox_Fiscalia);
            panel_Instruccion.Controls.Add(lbl_Dr);
            panel_Instruccion.Controls.Add(lbl_Ufid);
            panel_Instruccion.Controls.Add(lbl_Instructor);
            panel_Instruccion.Controls.Add(lbl_Secretario);
            panel_Instruccion.Controls.Add(lbl_Fecha);
            panel_Instruccion.Controls.Add(comboBox_Secretario);
            panel_Instruccion.Controls.Add(comboBox_DeptoJudicial);
            panel_Instruccion.Controls.Add(comboBox_Instructor);
            panel_Instruccion.Controls.Add(comboBox_AgenteFiscal);
            panel_Instruccion.Controls.Add(lbl_Localida);
            panel_Instruccion.Controls.Add(lbl_DeptoJudicial);
            panel_Instruccion.Controls.Add(comboBox_Dependencia);
            panel_Instruccion.Controls.Add(lbl_Dependencia);
            panel_Instruccion.Controls.Add(comboBox_Localidad);
            panel_Instruccion.Location = new Point(24, 152);
            panel_Instruccion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Instruccion.Name = "panel_Instruccion";
            panel_Instruccion.Size = new Size(486, 217);
            panel_Instruccion.TabIndex = 45;
            // 
            // timePickerPersonalizado1
            // 
            timePickerPersonalizado1.BackColor = SystemColors.Window;
            timePickerPersonalizado1.FechaSeleccionada = new System.DateTime(0L);
            timePickerPersonalizado1.Location = new Point(130, 166);
            timePickerPersonalizado1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            timePickerPersonalizado1.Name = "timePickerPersonalizado1";
           // timePickerPersonalizado1.SelectedDate = new System.DateTime(2024, 12, 5, 18, 42, 59, 901);
            timePickerPersonalizado1.Size = new Size(335, 21);
            timePickerPersonalizado1.TabIndex = 38;
            // 
            // comboBox_DeptoJudicial
            // 
            comboBox_DeptoJudicial.ArrowImage = (Image)resources.GetObject("comboBox_DeptoJudicial.ArrowImage");
            comboBox_DeptoJudicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_DeptoJudicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_DeptoJudicial.BackColor = Color.White;
            comboBox_DeptoJudicial.DataSource = null;
            comboBox_DeptoJudicial.DefaultImage = (Image)resources.GetObject("comboBox_DeptoJudicial.DefaultImage");
            comboBox_DeptoJudicial.DisabledImage = (Image)resources.GetObject("comboBox_DeptoJudicial.DisabledImage");
            comboBox_DeptoJudicial.DisplayMember = null;
            comboBox_DeptoJudicial.DropDownHeight = 252;
            comboBox_DeptoJudicial.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_DeptoJudicial.DroppedDown = false;
            comboBox_DeptoJudicial.ErrorColor = Color.Red;
            comboBox_DeptoJudicial.FocusColor = Color.Blue;
            comboBox_DeptoJudicial.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_DeptoJudicial.Location = new Point(132, 57);
            comboBox_DeptoJudicial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_DeptoJudicial.MaxDropDownItems = 10;
            comboBox_DeptoJudicial.Name = "comboBox_DeptoJudicial";
            comboBox_DeptoJudicial.PlaceholderColor = Color.Gray;
            comboBox_DeptoJudicial.PlaceholderText = " ";
            comboBox_DeptoJudicial.PressedImage = (Image)resources.GetObject("comboBox_DeptoJudicial.PressedImage");
            comboBox_DeptoJudicial.SelectedIndex = -1;
            comboBox_DeptoJudicial.SelectedItem = null;
            comboBox_DeptoJudicial.SelectedText = "";
            comboBox_DeptoJudicial.SelectionStart = 0;
            comboBox_DeptoJudicial.ShowError = false;
            comboBox_DeptoJudicial.Size = new Size(333, 21);
            comboBox_DeptoJudicial.TabIndex = 3;
            comboBox_DeptoJudicial.TextChanged += ComboBox_DeptoJudicial_TextChanged;
            // 
            // lbl_Localida
            // 
            lbl_Localida.AutoSize = true;
            lbl_Localida.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Localida.Location = new Point(49, 30);
            lbl_Localida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Localida.Name = "lbl_Localida";
            lbl_Localida.Size = new Size(70, 15);
            lbl_Localida.TabIndex = 37;
            lbl_Localida.Text = "Localidad";
            // 
            // lbl_DeptoJudicial
            // 
            lbl_DeptoJudicial.AutoSize = true;
            lbl_DeptoJudicial.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_DeptoJudicial.Location = new Point(16, 57);
            lbl_DeptoJudicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_DeptoJudicial.Name = "lbl_DeptoJudicial";
            lbl_DeptoJudicial.Size = new Size(103, 15);
            lbl_DeptoJudicial.TabIndex = 35;
            lbl_DeptoJudicial.Text = "Depto. Judicial";
   
            // 
            // comboBox_Localidad
            // 
            comboBox_Localidad.ArrowImage = (Image)resources.GetObject("comboBox_Localidad.ArrowImage");
            comboBox_Localidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Localidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Localidad.BackColor = Color.White;
            comboBox_Localidad.DataSource = null;
            comboBox_Localidad.DefaultImage = (Image)resources.GetObject("comboBox_Localidad.DefaultImage");
            comboBox_Localidad.DisabledImage = (Image)resources.GetObject("comboBox_Localidad.DisabledImage");
            comboBox_Localidad.DisplayMember = null;
            comboBox_Localidad.DropDownHeight = 252;
            comboBox_Localidad.DropDownStyle = (CustomComboBox.CustomComboBoxStyle)System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_Localidad.DroppedDown = false;
            comboBox_Localidad.ErrorColor = Color.Red;
            comboBox_Localidad.FocusColor = Color.Blue;
            comboBox_Localidad.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Localidad.Location = new Point(132, 30);
            comboBox_Localidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Localidad.MaxDropDownItems = 10;
            comboBox_Localidad.Name = "comboBox_Localidad";
            comboBox_Localidad.PlaceholderColor = Color.Gray;
            comboBox_Localidad.PlaceholderText = " ";
            comboBox_Localidad.PressedImage = (Image)resources.GetObject("comboBox_Localidad.PressedImage");
            comboBox_Localidad.SelectedIndex = -1;
            comboBox_Localidad.SelectedItem = null;
            comboBox_Localidad.SelectedText = "";
            comboBox_Localidad.SelectionStart = 0;
            comboBox_Localidad.ShowError = false;
            comboBox_Localidad.Size = new Size(333, 21);
            comboBox_Localidad.TabIndex = 2;
            comboBox_Localidad.KeyPress += ComboBox_Localidad_KeyPress;
            // 
            // panel_Ipp
            // 
            panel_Ipp.BackColor = Color.Transparent;
            panel_Ipp.Controls.Add(textBox_NumeroIpp);
            panel_Ipp.Controls.Add(comboBox_Ipp1);
            panel_Ipp.Controls.Add(comboBox_Ipp2);
            panel_Ipp.Controls.Add(lbl_00);
            panel_Ipp.Controls.Add(comboBox_Ipp4);
            panel_Ipp.Controls.Add(lbl_Ipp);
            panel_Ipp.Location = new Point(27, 23);
            panel_Ipp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Ipp.Name = "panel_Ipp";
            panel_Ipp.Size = new Size(478, 39);
            panel_Ipp.TabIndex = 44;
            // 
            // panel_Caratula
            // 
            panel_Caratula.BackColor = Color.Transparent;
            panel_Caratula.Controls.Add(textBox_Caratula);
            panel_Caratula.Controls.Add(lbl_Caratula);
            panel_Caratula.Controls.Add(btn_AgregarCausa);
            panel_Caratula.Location = new Point(54, 63);
            panel_Caratula.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Caratula.Name = "panel_Caratula";
            panel_Caratula.Size = new Size(475, 29);
            panel_Caratula.TabIndex = 43;
            // 
            // panel_ControlesInferiores
            // 
            panel_ControlesInferiores.Anchor = System.Windows.Forms.AnchorStyles.Left;
            panel_ControlesInferiores.BackColor = Color.Transparent;
            panel_ControlesInferiores.Controls.Add(panel_Not247);
            panel_ControlesInferiores.Controls.Add(Btn_ContadorRML);
            panel_ControlesInferiores.Controls.Add(btn_ContadorRatificaciones);
            panel_ControlesInferiores.Controls.Add(label_StudRML);
            panel_ControlesInferiores.Controls.Add(pictureBox_CheckCargo);
            panel_ControlesInferiores.Controls.Add(pictureBox_CheckRatificacion);
            panel_ControlesInferiores.Controls.Add(checkBox_Cargo);
            panel_ControlesInferiores.Controls.Add(label_Cargo);
            panel_ControlesInferiores.Controls.Add(checkBox_RatificacionTestimonial);
            panel_ControlesInferiores.Controls.Add(label_RatificacionPersonal);
            panel_ControlesInferiores.Controls.Add(btn_Imprimir);
            panel_ControlesInferiores.Controls.Add(btn_Buscar);
            panel_ControlesInferiores.Controls.Add(btn_Guardar);
            panel_ControlesInferiores.Controls.Add(btn_Limpiar);
            panel_ControlesInferiores.Location = new Point(4, 373);
            panel_ControlesInferiores.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            panel_ControlesInferiores.Size = new Size(514, 190);
            panel_ControlesInferiores.TabIndex = 42;
            // 
            // panel_Not247
            // 
            panel_Not247.BackColor = Color.Transparent;
            panel_Not247.Controls.Add(Btn_Contador247);
            panel_Not247.Controls.Add(fecha_Pericia);
            panel_Not247.Controls.Add(botonDeslizable_Not247);
            panel_Not247.Controls.Add(label_Not247);
            panel_Not247.Location = new Point(5, 2);
            panel_Not247.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Not247.Name = "panel_Not247";
            panel_Not247.Size = new Size(376, 39);
            panel_Not247.TabIndex = 55;
            // 
            // Btn_Contador247
            // 
            Btn_Contador247.BackColor = Color.FromArgb(0, 154, 174);
            Btn_Contador247.Cursor = System.Windows.Forms.Cursors.Hand;
            Btn_Contador247.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Contador247.ForeColor = SystemColors.ControlText;
            Btn_Contador247.Location = new Point(5, 8);
            Btn_Contador247.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            Btn_Contador247.MinimumSize = new Size(24, 24);
            Btn_Contador247.Name = "Btn_Contador247";
            Btn_Contador247.Size = new Size(24, 24);
            Btn_Contador247.TabIndex = 56;
            Btn_Contador247.Text = null;
            // 
            // fecha_Pericia
            // 
            fecha_Pericia.BackColor = SystemColors.ActiveCaption;
            fecha_Pericia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fecha_Pericia.Cursor = System.Windows.Forms.Cursors.Hand;
            fecha_Pericia.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fecha_Pericia.Location = new Point(248, 9);
            fecha_Pericia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fecha_Pericia.Mask = "00/00/0000 00:00";
            fecha_Pericia.Name = "fecha_Pericia";
            fecha_Pericia.Size = new Size(127, 20);
            fecha_Pericia.TabIndex = 55;
            fecha_Pericia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            fecha_Pericia.ValidatingType = typeof(System.DateTime);
            fecha_Pericia.TypeValidationCompleted += Fecha_Pericia_TypeValidationCompleted;
            fecha_Pericia.Click += Fecha_Pericia_Click;
            fecha_Pericia.MouseEnter += Fecha_Pericia_Enter;
            fecha_Pericia.MouseLeave += Fecha_Pericia_MouseLeave;
            fecha_Pericia.Validating += Fecha_Pericia_Validating;
            // 
            // botonDeslizable_Not247
            // 
            botonDeslizable_Not247.Cursor = System.Windows.Forms.Cursors.Hand;
            botonDeslizable_Not247.IsOn = false;
            botonDeslizable_Not247.Location = new Point(209, 9);
            botonDeslizable_Not247.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            botonDeslizable_Not247.Name = "botonDeslizable_Not247";
            botonDeslizable_Not247.Size = new Size(47, 23);
            botonDeslizable_Not247.TabIndex = 54;
            botonDeslizable_Not247.ValidarCampos = null;
            // 
            // label_Not247
            // 
            label_Not247.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Not247.Location = new Point(34, 9);
            label_Not247.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Not247.Name = "label_Not247";
            label_Not247.Size = new Size(226, 24);
            label_Not247.TabIndex = 53;
            label_Not247.Text = "Not. Art. 247 C.P.P.   ";
            label_Not247.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Btn_ContadorRML
            // 
            Btn_ContadorRML.BackColor = Color.FromArgb(0, 154, 174);
            Btn_ContadorRML.Cursor = System.Windows.Forms.Cursors.Hand;
            Btn_ContadorRML.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_ContadorRML.ForeColor = SystemColors.ControlText;
            Btn_ContadorRML.Location = new Point(486, 10);
            Btn_ContadorRML.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            Btn_ContadorRML.MinimumSize = new Size(24, 24);
            Btn_ContadorRML.Name = "Btn_ContadorRML";
            Btn_ContadorRML.Size = new Size(24, 27);
            Btn_ContadorRML.TabIndex = 54;
            Btn_ContadorRML.Text = null;
            // 
            // btn_ContadorRatificaciones
            // 
            btn_ContadorRatificaciones.BackColor = Color.FromArgb(0, 154, 174);
            btn_ContadorRatificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_ContadorRatificaciones.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ContadorRatificaciones.ForeColor = SystemColors.ControlText;
            btn_ContadorRatificaciones.Location = new Point(8, 42);
            btn_ContadorRatificaciones.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            btn_ContadorRatificaciones.MinimumSize = new Size(24, 24);
            btn_ContadorRatificaciones.Name = "btn_ContadorRatificaciones";
            btn_ContadorRatificaciones.Size = new Size(24, 27);
            btn_ContadorRatificaciones.TabIndex = 53;
            btn_ContadorRatificaciones.Text = null;
            // 
            // label_StudRML
            // 
            label_StudRML.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_StudRML.Location = new Point(383, 13);
            label_StudRML.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_StudRML.Name = "label_StudRML";
            label_StudRML.Size = new Size(132, 23);
            label_StudRML.TabIndex = 45;
            label_StudRML.Text = "Stud. R.M.L   ";
            label_StudRML.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox_CheckCargo
            // 
            pictureBox_CheckCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_CheckCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_CheckCargo.Image = Properties.Resources.check_Personalizado;
            pictureBox_CheckCargo.Location = new Point(364, 39);
            pictureBox_CheckCargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_CheckCargo.Name = "pictureBox_CheckCargo";
            pictureBox_CheckCargo.Size = new Size(30, 32);
            pictureBox_CheckCargo.TabIndex = 44;
            pictureBox_CheckCargo.TabStop = false;
            pictureBox_CheckCargo.Click += CheckPickture_Click;
            // 
            // pictureBox_CheckRatificacion
            // 
            pictureBox_CheckRatificacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_CheckRatificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_CheckRatificacion.Image = Properties.Resources.check_Personalizado;
            pictureBox_CheckRatificacion.Location = new Point(266, 42);
            pictureBox_CheckRatificacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_CheckRatificacion.Name = "pictureBox_CheckRatificacion";
            pictureBox_CheckRatificacion.Size = new Size(30, 32);
            pictureBox_CheckRatificacion.TabIndex = 43;
            pictureBox_CheckRatificacion.TabStop = false;
            pictureBox_CheckRatificacion.Click += CheckPickture_Click;
            // 
            // label_Cargo
            // 
            label_Cargo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Cargo.Location = new Point(379, 44);
            label_Cargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Cargo.Name = "label_Cargo";
            label_Cargo.Size = new Size(98, 22);
            label_Cargo.TabIndex = 40;
            label_Cargo.Text = "   Cargo   ";
            label_Cargo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_RatificacionPersonal
            // 
            label_RatificacionPersonal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_RatificacionPersonal.Location = new Point(34, 38);
            label_RatificacionPersonal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_RatificacionPersonal.Name = "label_RatificacionPersonal";
            label_RatificacionPersonal.Size = new Size(238, 32);
            label_RatificacionPersonal.TabIndex = 38;
            label_RatificacionPersonal.Text = "Ratificación testimonial   ";
            label_RatificacionPersonal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_Imputado
            // 
            panel_Imputado.AutoSize = true;
            panel_Imputado.BackColor = Color.Transparent;
            panel_Imputado.Controls.Add(textBox_Imputado);
            panel_Imputado.Controls.Add(lbl_Imputado);
            panel_Imputado.Controls.Add(btn_AgregarDatosImputado);
            panel_Imputado.Controls.Add(btn_AgregarImputado);
            panel_Imputado.Location = new Point(9, 122);
            panel_Imputado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Imputado.Name = "panel_Imputado";
            panel_Imputado.Size = new Size(519, 33);
            panel_Imputado.TabIndex = 41;
            // 
            // panel_Victima
            // 
            panel_Victima.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel_Victima.BackColor = Color.Transparent;
            panel_Victima.Controls.Add(textBox_Victima);
            panel_Victima.Controls.Add(btn_AgregarDatosVictima);
            panel_Victima.Controls.Add(lbl_Victima);
            panel_Victima.Controls.Add(btn_AgregarVictima);
            panel_Victima.Location = new Point(8, 92);
            panel_Victima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Victima.Name = "panel_Victima";
            panel_Victima.Size = new Size(520, 31);
            panel_Victima.TabIndex = 40;
            // 
            // label_TITULO
            // 
            label_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label_TITULO.AutoSize = true;
            label_TITULO.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = SystemColors.ControlLightLight;
            label_TITULO.Location = new Point(108, 10);
            label_TITULO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            label_TITULO.Size = new Size(305, 24);
            label_TITULO.TabIndex = 31;
            label_TITULO.Text = "ESTRUCTURA BASICA I.P.P.";
            // 
            // InicioCierre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 154, 174);
            ClientSize = new Size(579, 631);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimumSize = new Size(599, 674);
            Name = "InicioCierre";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ACTUACIONES SUMARIALES PREVENCIONALES";
            FormClosing += InicioCierre_FormClosing;
            Load += InicioCierre_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_Instruccion.ResumeLayout(false);
            panel_Instruccion.PerformLayout();
            panel_Ipp.ResumeLayout(false);
            panel_Ipp.PerformLayout();
            panel_Caratula.ResumeLayout(false);
            panel_Caratula.PerformLayout();
            panel_ControlesInferiores.ResumeLayout(false);
            panel_ControlesInferiores.PerformLayout();
            panel_Not247.ResumeLayout(false);
            panel_Not247.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckCargo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckRatificacion).EndInit();
            panel_Imputado.ResumeLayout(false);
            panel_Imputado.PerformLayout();
            panel_Victima.ResumeLayout(false);
            panel_Victima.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_Dr;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_NumeroIpp;
        private System.Windows.Forms.Label lbl_Ipp;
        private System.Windows.Forms.Label lbl_Caratula;
        private System.Windows.Forms.Label lbl_Victima;
        private System.Windows.Forms.Label lbl_Imputado;
        private System.Windows.Forms.Label lbl_Ufid;
        private System.Windows.Forms.Label lbl_Instructor;
        private System.Windows.Forms.Label lbl_Secretario;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.Label lbl_Dependencia;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Caratula;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Victima;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Imputado;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Fiscalia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Instructor;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Secretario;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_AgenteFiscal;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp1;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp2;
        private System.Windows.Forms.Label lbl_00;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp4;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_AgregarCausa;
        private System.Windows.Forms.Button btn_AgregarVictima;
        private System.Windows.Forms.Button btn_AgregarImputado;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Label lbl_DeptoJudicial;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_DeptoJudicial;
        private System.Windows.Forms.Label lbl_Localida;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Localidad;
        private System.Windows.Forms.Button btn_AgregarDatosVictima;
        private System.Windows.Forms.Button btn_AgregarDatosImputado;
        private System.Windows.Forms.Panel panel_Victima;
        private System.Windows.Forms.Panel panel_Imputado;
        private System.Windows.Forms.Panel panel_ControlesInferiores;
        private System.Windows.Forms.Panel panel_Caratula;
        private System.Windows.Forms.Panel panel_Ipp;
        private System.Windows.Forms.Label label_RatificacionPersonal;
        private System.Windows.Forms.CheckBox checkBox_RatificacionTestimonial;
        private System.Windows.Forms.Label label_Cargo;
        private System.Windows.Forms.CheckBox checkBox_Cargo;
        private System.Windows.Forms.Panel panel_Instruccion;
        private System.Windows.Forms.PictureBox pictureBox_CheckRatificacion;
        private System.Windows.Forms.PictureBox pictureBox_CheckCargo;
        private System.Windows.Forms.Label label_StudRML;
        private Ofelia_Sara.Controles.Ofl_Sara.Boton_Contador Btn_ContadorRML;
        private Ofelia_Sara.Controles.Ofl_Sara.Boton_Contador btn_ContadorRatificaciones;
        private Ofelia_Sara.Controles.Ofl_Sara.TimePickerPersonalizado timePickerPersonalizado1;
        private System.Windows.Forms.Panel panel_Not247;
        private Ofelia_Sara.Controles.Ofl_Sara.Boton_Contador Btn_Contador247;
        private System.Windows.Forms.MaskedTextBox fecha_Pericia;
        private Ofelia_Sara.Controles.General.BotonDeslizable botonDeslizable_Not247;
        private System.Windows.Forms.Label label_Not247;
    }
}