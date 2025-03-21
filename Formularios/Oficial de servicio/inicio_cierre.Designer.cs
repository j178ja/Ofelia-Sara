﻿using Ofelia_Sara.Controles.General;
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
            checkBox_RatificacionTestimonial = new System.Windows.Forms.CheckBox();
            btn_AgregarDatosImputado = new System.Windows.Forms.Button();
            btn_AgregarDatosVictima = new System.Windows.Forms.Button();
            checkBox_Cargo = new System.Windows.Forms.CheckBox();
            panel1 = new System.Windows.Forms.Panel();
            panel_DatosIppCompleta = new System.Windows.Forms.Panel();
            btn_CrearDenuncia = new System.Windows.Forms.Button();
            panel_Ipp = new System.Windows.Forms.Panel();
            btn_SDA = new System.Windows.Forms.Button();
            panel_Victima = new System.Windows.Forms.Panel();
            panel_Instruccion = new System.Windows.Forms.Panel();
            timePickerPersonalizado1 = new Controles.Ofl_Sara.TimePickerPersonalizado();
            comboBox_DeptoJudicial = new CustomComboBox();
            lbl_Localida = new System.Windows.Forms.Label();
            lbl_DeptoJudicial = new System.Windows.Forms.Label();
            comboBox_Localidad = new CustomComboBox();
            panel_Imputado = new System.Windows.Forms.Panel();
            panel_Caratula = new System.Windows.Forms.Panel();
            textBox_Caratula = new CustomTextBox();
            panel_Compromisos = new System.Windows.Forms.Panel();
            panel_Cargo = new System.Windows.Forms.Panel();
            label_Cargo = new System.Windows.Forms.Label();
            panel_RatificacionPersonal = new System.Windows.Forms.Panel();
            label_RatificacionPersonal = new System.Windows.Forms.Label();
            btn_ContadorRatificaciones = new Controles.Ofl_Sara.Boton_Contador();
            panel_StudRML = new System.Windows.Forms.Panel();
            label_StudRML = new System.Windows.Forms.Label();
            Btn_ContadorRML = new Controles.Ofl_Sara.Boton_Contador();
            panel_Not247 = new System.Windows.Forms.Panel();
            Btn_Contador247 = new Controles.Ofl_Sara.Boton_Contador();
            fecha_Pericia = new System.Windows.Forms.MaskedTextBox();
            botonDeslizable_Not247 = new BotonDeslizable();
            label_Not247 = new System.Windows.Forms.Label();
            panel_InsertarSecuestro = new System.Windows.Forms.Panel();
            botonDeslizable_InsertarSecuestro = new BotonDeslizable();
            label_InsertarSecuestro = new System.Windows.Forms.Label();
            panel_ControlesInferiores = new System.Windows.Forms.Panel();
            label_TITULO = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            panel_DatosIppCompleta.SuspendLayout();
            panel_Ipp.SuspendLayout();
            panel_Victima.SuspendLayout();
            panel_Instruccion.SuspendLayout();
            panel_Imputado.SuspendLayout();
            panel_Caratula.SuspendLayout();
            panel_Compromisos.SuspendLayout();
            panel_Cargo.SuspendLayout();
            panel_RatificacionPersonal.SuspendLayout();
            panel_StudRML.SuspendLayout();
            panel_Not247.SuspendLayout();
            panel_InsertarSecuestro.SuspendLayout();
            panel_ControlesInferiores.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Dr
            // 
            lbl_Dr.AutoSize = true;
            lbl_Dr.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Dr.Location = new Point(260, 8);
            lbl_Dr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Dr.Name = "lbl_Dr";
            lbl_Dr.Size = new Size(31, 18);
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
            textBox_NumeroIpp.Location = new Point(265, 13);
            textBox_NumeroIpp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_NumeroIpp.MaxLength = 32767;
            textBox_NumeroIpp.Multiline = false;
            textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            textBox_NumeroIpp.PasswordChar = '\0';
            textBox_NumeroIpp.PlaceholderColor = Color.Gray;
            textBox_NumeroIpp.PlaceholderText = "";
            textBox_NumeroIpp.ReadOnly = false;
            textBox_NumeroIpp.SelectionStart = 0;
            textBox_NumeroIpp.ShowError = false;
            textBox_NumeroIpp.Size = new Size(111, 21);
            textBox_NumeroIpp.TabIndex = 2;
            textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_NumeroIpp.TextValue = "";
            textBox_NumeroIpp.Whidth = 0;
            // 
            // lbl_Ipp
            // 
            lbl_Ipp.AutoSize = true;
            lbl_Ipp.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Ipp.Location = new Point(95, 15);
            lbl_Ipp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Ipp.Name = "lbl_Ipp";
            lbl_Ipp.Size = new Size(49, 18);
            lbl_Ipp.TabIndex = 3;
            lbl_Ipp.Text = "l.P.P.";
            // 
            // lbl_Caratula
            // 
            lbl_Caratula.AutoSize = true;
            lbl_Caratula.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Caratula.Location = new Point(58, 7);
            lbl_Caratula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Caratula.Name = "lbl_Caratula";
            lbl_Caratula.Size = new Size(93, 18);
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
            lbl_Victima.Size = new Size(72, 18);
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
            lbl_Imputado.Size = new Size(94, 18);
            lbl_Imputado.TabIndex = 6;
            lbl_Imputado.Text = "lMPUTADO";
            // 
            // lbl_Ufid
            // 
            lbl_Ufid.AutoSize = true;
            lbl_Ufid.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Ufid.Location = new Point(83, 9);
            lbl_Ufid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Ufid.Name = "lbl_Ufid";
            lbl_Ufid.Size = new Size(61, 18);
            lbl_Ufid.TabIndex = 7;
            lbl_Ufid.Text = "U.F.I.D";
            // 
            // lbl_Instructor
            // 
            lbl_Instructor.AutoSize = true;
            lbl_Instructor.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Instructor.Location = new Point(39, 84);
            lbl_Instructor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Instructor.Name = "lbl_Instructor";
            lbl_Instructor.Size = new Size(116, 18);
            lbl_Instructor.TabIndex = 8;
            lbl_Instructor.Text = "INSTRUCTOR";
            // 
            // lbl_Secretario
            // 
            lbl_Secretario.AutoSize = true;
            lbl_Secretario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Secretario.Location = new Point(41, 111);
            lbl_Secretario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Secretario.Name = "lbl_Secretario";
            lbl_Secretario.Size = new Size(114, 18);
            lbl_Secretario.TabIndex = 9;
            lbl_Secretario.Text = "SECRETARIO";
            // 
            // lbl_Fecha
            // 
            lbl_Fecha.AutoSize = true;
            lbl_Fecha.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Fecha.Location = new Point(83, 166);
            lbl_Fecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Fecha.Name = "lbl_Fecha";
            lbl_Fecha.Size = new Size(63, 18);
            lbl_Fecha.TabIndex = 10;
            lbl_Fecha.Text = "FECHA";
            // 
            // lbl_Dependencia
            // 
            lbl_Dependencia.AutoSize = true;
            lbl_Dependencia.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Dependencia.Location = new Point(29, 142);
            lbl_Dependencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Dependencia.Name = "lbl_Dependencia";
            lbl_Dependencia.Size = new Size(126, 18);
            lbl_Dependencia.TabIndex = 11;
            lbl_Dependencia.Text = "DEPENDENCIA";
            // 
            // textBox_Victima
            // 
            textBox_Victima.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Victima.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Victima.BackColor = Color.White;
            textBox_Victima.ErrorColor = Color.Red;
            textBox_Victima.FocusColor = Color.Blue;
            textBox_Victima.Location = new Point(147, 4);
            textBox_Victima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Victima.MaxLength = 32767;
            textBox_Victima.Multiline = false;
            textBox_Victima.Name = "textBox_Victima";
            textBox_Victima.PasswordChar = '\0';
            textBox_Victima.PlaceholderColor = Color.Gray;
            textBox_Victima.PlaceholderText = "";
            textBox_Victima.ReadOnly = false;
            textBox_Victima.SelectionStart = 0;
            textBox_Victima.ShowError = false;
            textBox_Victima.Size = new Size(333, 21);
            textBox_Victima.TabIndex = 0;
            textBox_Victima.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Victima.TextValue = "";
            textBox_Victima.Whidth = 0;
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
            textBox_Imputado.PlaceholderColor = Color.Gray;
            textBox_Imputado.PlaceholderText = "";
            textBox_Imputado.ReadOnly = false;
            textBox_Imputado.SelectionStart = 0;
            textBox_Imputado.ShowError = false;
            textBox_Imputado.Size = new Size(333, 21);
            textBox_Imputado.TabIndex = 0;
            textBox_Imputado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Imputado.TextValue = "";
            textBox_Imputado.Whidth = 0;
            // 
            // comboBox_Fiscalia
            // 
            comboBox_Fiscalia.ArrowImage = (Image)resources.GetObject("comboBox_Fiscalia.ArrowImage");
            comboBox_Fiscalia.ArrowPictureBox = null;
            comboBox_Fiscalia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Fiscalia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Fiscalia.BackColor = Color.White;
            comboBox_Fiscalia.DataSource = null;
            comboBox_Fiscalia.DefaultImage = (Image)resources.GetObject("comboBox_Fiscalia.DefaultImage");
            comboBox_Fiscalia.DisabledImage = (Image)resources.GetObject("comboBox_Fiscalia.DisabledImage");
            comboBox_Fiscalia.DisplayMember = null;
            comboBox_Fiscalia.DropDownHeight = 252;
            comboBox_Fiscalia.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Fiscalia.DroppedDown = false;
            comboBox_Fiscalia.ErrorColor = Color.Red;
            comboBox_Fiscalia.FocusColor = Color.Blue;
            comboBox_Fiscalia.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Fiscalia.ForeColor = Color.Gray;
            comboBox_Fiscalia.Location = new Point(147, 3);
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
            comboBox_Fiscalia.Text = " ";
            comboBox_Fiscalia.TextValue = "";
            // 
            // comboBox_Instructor
            // 
            comboBox_Instructor.ArrowImage = (Image)resources.GetObject("comboBox_Instructor.ArrowImage");
            comboBox_Instructor.ArrowPictureBox = null;
            comboBox_Instructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Instructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Instructor.BackColor = Color.White;
            comboBox_Instructor.DataSource = null;
            comboBox_Instructor.DefaultImage = (Image)resources.GetObject("comboBox_Instructor.DefaultImage");
            comboBox_Instructor.DisabledImage = (Image)resources.GetObject("comboBox_Instructor.DisabledImage");
            comboBox_Instructor.DisplayMember = null;
            comboBox_Instructor.DropDownHeight = 252;
            comboBox_Instructor.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Instructor.DroppedDown = false;
            comboBox_Instructor.ErrorColor = Color.Red;
            comboBox_Instructor.FocusColor = Color.Blue;
            comboBox_Instructor.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Instructor.ForeColor = Color.Gray;
            comboBox_Instructor.Location = new Point(147, 84);
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
            comboBox_Instructor.Text = " ";
            comboBox_Instructor.TextValue = "";
            comboBox_Instructor.TextChanged += ComboBox_Instructor_TextChanged;
            // 
            // comboBox_Secretario
            // 
            comboBox_Secretario.ArrowImage = (Image)resources.GetObject("comboBox_Secretario.ArrowImage");
            comboBox_Secretario.ArrowPictureBox = null;
            comboBox_Secretario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Secretario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Secretario.BackColor = Color.White;
            comboBox_Secretario.DataSource = null;
            comboBox_Secretario.DefaultImage = (Image)resources.GetObject("comboBox_Secretario.DefaultImage");
            comboBox_Secretario.DisabledImage = (Image)resources.GetObject("comboBox_Secretario.DisabledImage");
            comboBox_Secretario.DisplayMember = null;
            comboBox_Secretario.DropDownHeight = 252;
            comboBox_Secretario.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Secretario.DroppedDown = false;
            comboBox_Secretario.ErrorColor = Color.Red;
            comboBox_Secretario.FocusColor = Color.Blue;
            comboBox_Secretario.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Secretario.ForeColor = Color.Gray;
            comboBox_Secretario.Location = new Point(147, 111);
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
            comboBox_Secretario.Text = " ";
            comboBox_Secretario.TextValue = "";
            comboBox_Secretario.TextChanged += ComboBox_Secretario_TextChanged;
            // 
            // comboBox_Dependencia
            // 
            comboBox_Dependencia.ArrowImage = (Image)resources.GetObject("comboBox_Dependencia.ArrowImage");
            comboBox_Dependencia.ArrowPictureBox = null;
            comboBox_Dependencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Dependencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Dependencia.BackColor = Color.White;
            comboBox_Dependencia.DataSource = null;
            comboBox_Dependencia.DefaultImage = (Image)resources.GetObject("comboBox_Dependencia.DefaultImage");
            comboBox_Dependencia.DisabledImage = (Image)resources.GetObject("comboBox_Dependencia.DisabledImage");
            comboBox_Dependencia.DisplayMember = null;
            comboBox_Dependencia.DropDownHeight = 252;
            comboBox_Dependencia.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Dependencia.DroppedDown = false;
            comboBox_Dependencia.ErrorColor = Color.Red;
            comboBox_Dependencia.FocusColor = Color.Blue;
            comboBox_Dependencia.ForeColor = Color.Gray;
            comboBox_Dependencia.Location = new Point(147, 138);
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
            comboBox_Dependencia.Text = " ";
            comboBox_Dependencia.TextValue = "";
            comboBox_Dependencia.TextChanged += ComboBox_Dependencia_TextChanged;
            // 
            // comboBox_AgenteFiscal
            // 
            comboBox_AgenteFiscal.ArrowImage = (Image)resources.GetObject("comboBox_AgenteFiscal.ArrowImage");
            comboBox_AgenteFiscal.ArrowPictureBox = null;
            comboBox_AgenteFiscal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_AgenteFiscal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_AgenteFiscal.BackColor = Color.White;
            comboBox_AgenteFiscal.DataSource = null;
            comboBox_AgenteFiscal.DefaultImage = (Image)resources.GetObject("comboBox_AgenteFiscal.DefaultImage");
            comboBox_AgenteFiscal.DisabledImage = (Image)resources.GetObject("comboBox_AgenteFiscal.DisabledImage");
            comboBox_AgenteFiscal.DisplayMember = null;
            comboBox_AgenteFiscal.DropDownHeight = 252;
            comboBox_AgenteFiscal.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_AgenteFiscal.DroppedDown = false;
            comboBox_AgenteFiscal.ErrorColor = Color.Red;
            comboBox_AgenteFiscal.FocusColor = Color.Blue;
            comboBox_AgenteFiscal.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_AgenteFiscal.ForeColor = Color.Gray;
            comboBox_AgenteFiscal.Location = new Point(291, 3);
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
            comboBox_AgenteFiscal.Text = " ";
            comboBox_AgenteFiscal.TextValue = "";
            // 
            // comboBox_Ipp1
            // 
            comboBox_Ipp1.ArrowImage = (Image)resources.GetObject("comboBox_Ipp1.ArrowImage");
            comboBox_Ipp1.ArrowPictureBox = null;
            comboBox_Ipp1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp1.BackColor = Color.White;
            comboBox_Ipp1.DataSource = null;
            comboBox_Ipp1.DefaultImage = (Image)resources.GetObject("comboBox_Ipp1.DefaultImage");
            comboBox_Ipp1.DisabledImage = (Image)resources.GetObject("comboBox_Ipp1.DisabledImage");
            comboBox_Ipp1.DisplayMember = null;
            comboBox_Ipp1.DropDownHeight = 252;
            comboBox_Ipp1.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp1.DroppedDown = false;
            comboBox_Ipp1.ErrorColor = Color.Red;
            comboBox_Ipp1.FocusColor = Color.Blue;
            comboBox_Ipp1.ForeColor = Color.Gray;
            comboBox_Ipp1.Location = new Point(150, 12);
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
            comboBox_Ipp1.Text = " ";
            comboBox_Ipp1.TextValue = "";
            // 
            // comboBox_Ipp2
            // 
            comboBox_Ipp2.ArrowImage = (Image)resources.GetObject("comboBox_Ipp2.ArrowImage");
            comboBox_Ipp2.ArrowPictureBox = null;
            comboBox_Ipp2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp2.BackColor = Color.White;
            comboBox_Ipp2.DataSource = null;
            comboBox_Ipp2.DefaultImage = (Image)resources.GetObject("comboBox_Ipp2.DefaultImage");
            comboBox_Ipp2.DisabledImage = (Image)resources.GetObject("comboBox_Ipp2.DisabledImage");
            comboBox_Ipp2.DisplayMember = null;
            comboBox_Ipp2.DropDownHeight = 252;
            comboBox_Ipp2.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp2.DroppedDown = false;
            comboBox_Ipp2.ErrorColor = Color.Red;
            comboBox_Ipp2.FocusColor = Color.Blue;
            comboBox_Ipp2.ForeColor = Color.Gray;
            comboBox_Ipp2.Location = new Point(207, 12);
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
            comboBox_Ipp2.Text = " ";
            comboBox_Ipp2.TextValue = "";
            // 
            // lbl_00
            // 
            lbl_00.AutoSize = true;
            lbl_00.Location = new Point(447, 18);
            lbl_00.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_00.Name = "lbl_00";
            lbl_00.Size = new Size(31, 20);
            lbl_00.TabIndex = 26;
            lbl_00.Text = "/00";
            // 
            // comboBox_Ipp4
            // 
            comboBox_Ipp4.ArrowImage = (Image)resources.GetObject("comboBox_Ipp4.ArrowImage");
            comboBox_Ipp4.ArrowPictureBox = null;
            comboBox_Ipp4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Ipp4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Ipp4.BackColor = Color.White;
            comboBox_Ipp4.DataSource = null;
            comboBox_Ipp4.DefaultImage = (Image)resources.GetObject("comboBox_Ipp4.DefaultImage");
            comboBox_Ipp4.DisabledImage = (Image)resources.GetObject("comboBox_Ipp4.DisabledImage");
            comboBox_Ipp4.DisplayMember = null;
            comboBox_Ipp4.DropDownHeight = 252;
            comboBox_Ipp4.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp4.DroppedDown = false;
            comboBox_Ipp4.ErrorColor = Color.Red;
            comboBox_Ipp4.FocusColor = Color.Blue;
            comboBox_Ipp4.ForeColor = Color.Gray;
            comboBox_Ipp4.Location = new Point(384, 12);
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
            comboBox_Ipp4.Text = " ";
            comboBox_Ipp4.TextValue = "";
            // 
            // btn_Buscar
            // 
            btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            btn_Buscar.BackColor = Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Buscar.Image = (Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new Point(20, 20);
            btn_Buscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(88, 77);
            btn_Buscar.TabIndex = 18;
            btn_Buscar.UseVisualStyleBackColor = false;
            btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            btn_Guardar.BackColor = Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new Point(142, 20);
            btn_Guardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(88, 77);
            btn_Guardar.TabIndex = 10;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            btn_Limpiar.BackColor = Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new Point(265, 20);
            btn_Limpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new Size(88, 77);
            btn_Limpiar.TabIndex = 12;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.Anchor = System.Windows.Forms.AnchorStyles.None;
            btn_Imprimir.BackColor = Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Imprimir.Location = new Point(387, 10);
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
            btn_AgregarCausa.Location = new Point(485, 2);
            btn_AgregarCausa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarCausa.Name = "btn_AgregarCausa";
            btn_AgregarCausa.Size = new Size(18, 27);
            btn_AgregarCausa.TabIndex = 27;
            btn_AgregarCausa.Text = "+";
            btn_AgregarCausa.UseVisualStyleBackColor = false;
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
            // 
            // checkBox_RatificacionTestimonial
            // 
            checkBox_RatificacionTestimonial.AutoSize = true;
            checkBox_RatificacionTestimonial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            checkBox_RatificacionTestimonial.CheckAlign = ContentAlignment.BottomCenter;
            checkBox_RatificacionTestimonial.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_RatificacionTestimonial.FlatAppearance.CheckedBackColor = SystemColors.ControlLight;
            checkBox_RatificacionTestimonial.Location = new Point(210, 11);
            checkBox_RatificacionTestimonial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_RatificacionTestimonial.Name = "checkBox_RatificacionTestimonial";
            checkBox_RatificacionTestimonial.Size = new Size(18, 17);
            checkBox_RatificacionTestimonial.TabIndex = 8;
            checkBox_RatificacionTestimonial.TextAlign = ContentAlignment.BottomCenter;
            checkBox_RatificacionTestimonial.UseVisualStyleBackColor = true;
            checkBox_RatificacionTestimonial.CheckedChanged += CheckBox_RatificacionTestimonial_CheckedChanged;
            // 
            // btn_AgregarDatosImputado
            // 
            btn_AgregarDatosImputado.BackColor = Color.Tomato;
            btn_AgregarDatosImputado.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarDatosImputado.Image = (Image)resources.GetObject("btn_AgregarDatosImputado.Image");
            btn_AgregarDatosImputado.Location = new Point(3, 1);
            btn_AgregarDatosImputado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarDatosImputado.Name = "btn_AgregarDatosImputado";
            btn_AgregarDatosImputado.Size = new Size(31, 27);
            btn_AgregarDatosImputado.TabIndex = 38;
            btn_AgregarDatosImputado.UseVisualStyleBackColor = false;
            btn_AgregarDatosImputado.Click += Btn_AgregarDatosImputado_Click;
            // 
            // btn_AgregarDatosVictima
            // 
            btn_AgregarDatosVictima.BackColor = Color.Tomato;
            btn_AgregarDatosVictima.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarDatosVictima.Location = new Point(4, 0);
            btn_AgregarDatosVictima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarDatosVictima.Name = "btn_AgregarDatosVictima";
            btn_AgregarDatosVictima.Size = new Size(31, 27);
            btn_AgregarDatosVictima.TabIndex = 39;
            btn_AgregarDatosVictima.UseVisualStyleBackColor = false;
            btn_AgregarDatosVictima.Click += Btn_AgregarDatosVictima_Click;
            // 
            // checkBox_Cargo
            // 
            checkBox_Cargo.AutoSize = true;
            checkBox_Cargo.BackColor = Color.Transparent;
            checkBox_Cargo.CheckAlign = ContentAlignment.BottomCenter;
            checkBox_Cargo.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_Cargo.Location = new Point(71, 9);
            checkBox_Cargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_Cargo.Name = "checkBox_Cargo";
            checkBox_Cargo.Size = new Size(18, 17);
            checkBox_Cargo.TabIndex = 9;
            checkBox_Cargo.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_Cargo.UseVisualStyleBackColor = false;
            checkBox_Cargo.CheckedChanged += CheckBox_Cargo_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel1.AutoScrollMargin = new Size(5, 0);
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel_DatosIppCompleta);
            panel1.Controls.Add(panel_Compromisos);
            panel1.Controls.Add(panel_ControlesInferiores);
            panel1.Location = new Point(21, 23);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(539, 542);
            panel1.TabIndex = 30;
            panel1.TabStop = true;
            // 
            // panel_DatosIppCompleta
            // 
            panel_DatosIppCompleta.Controls.Add(btn_CrearDenuncia);
            panel_DatosIppCompleta.Controls.Add(panel_Ipp);
            panel_DatosIppCompleta.Controls.Add(panel_Victima);
            panel_DatosIppCompleta.Controls.Add(panel_Instruccion);
            panel_DatosIppCompleta.Controls.Add(panel_Imputado);
            panel_DatosIppCompleta.Controls.Add(panel_Caratula);
            panel_DatosIppCompleta.Location = new Point(3, 15);
            panel_DatosIppCompleta.Name = "panel_DatosIppCompleta";
            panel_DatosIppCompleta.Size = new Size(533, 332);
            panel_DatosIppCompleta.TabIndex = 104;
            // 
            // btn_CrearDenuncia
            // 
            btn_CrearDenuncia.BackgroundImage = (Image)resources.GetObject("btn_CrearDenuncia.BackgroundImage");
            btn_CrearDenuncia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_CrearDenuncia.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_CrearDenuncia.Location = new Point(489, 3);
            btn_CrearDenuncia.Name = "btn_CrearDenuncia";
            btn_CrearDenuncia.Size = new Size(38, 38);
            btn_CrearDenuncia.TabIndex = 40;
            btn_CrearDenuncia.UseVisualStyleBackColor = true;
            btn_CrearDenuncia.Click += Btn_CrearDenuncia_Click;
            // 
            // panel_Ipp
            // 
            panel_Ipp.BackColor = Color.Transparent;
            panel_Ipp.Controls.Add(btn_SDA);
            panel_Ipp.Controls.Add(textBox_NumeroIpp);
            panel_Ipp.Controls.Add(comboBox_Ipp1);
            panel_Ipp.Controls.Add(comboBox_Ipp2);
            panel_Ipp.Controls.Add(lbl_00);
            panel_Ipp.Controls.Add(comboBox_Ipp4);
            panel_Ipp.Controls.Add(lbl_Ipp);
            panel_Ipp.Location = new Point(1, 3);
            panel_Ipp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Ipp.Name = "panel_Ipp";
            panel_Ipp.Size = new Size(480, 39);
            panel_Ipp.TabIndex = 44;
            // 
            // btn_SDA
            // 
            btn_SDA.BackgroundImage = (Image)resources.GetObject("btn_SDA.BackgroundImage");
            btn_SDA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_SDA.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_SDA.Location = new Point(5, 11);
            btn_SDA.Name = "btn_SDA";
            btn_SDA.Size = new Size(75, 23);
            btn_SDA.TabIndex = 39;
            btn_SDA.UseVisualStyleBackColor = true;
            btn_SDA.Click += Btn_SDA_Click;
            // 
            // panel_Victima
            // 
            panel_Victima.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel_Victima.BackColor = Color.Transparent;
            panel_Victima.Controls.Add(textBox_Victima);
            panel_Victima.Controls.Add(btn_AgregarDatosVictima);
            panel_Victima.Controls.Add(lbl_Victima);
            panel_Victima.Controls.Add(btn_AgregarVictima);
            panel_Victima.Location = new Point(2, 72);
            panel_Victima.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Victima.Name = "panel_Victima";
            panel_Victima.Size = new Size(524, 31);
            panel_Victima.TabIndex = 40;
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
            panel_Instruccion.Location = new Point(2, 132);
            panel_Instruccion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Instruccion.Name = "panel_Instruccion";
            panel_Instruccion.Size = new Size(525, 195);
            panel_Instruccion.TabIndex = 45;
            // 
            // timePickerPersonalizado1
            // 
            timePickerPersonalizado1.AñoMaximo = 2025;
            timePickerPersonalizado1.AñoMinimo = 1930;
            timePickerPersonalizado1.BackColor = SystemColors.Window;
            timePickerPersonalizado1.FechaSeleccionada = new System.DateTime(0L);
            timePickerPersonalizado1.Location = new Point(147, 166);
            timePickerPersonalizado1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            timePickerPersonalizado1.Name = "timePickerPersonalizado1";
            timePickerPersonalizado1.Size = new Size(333, 21);
            timePickerPersonalizado1.SubrayadoGeneralErrorColor = Color.Red;
            timePickerPersonalizado1.SubrayadoGeneralFocusColor = Color.Blue;
            timePickerPersonalizado1.TabIndex = 38;
            // 
            // comboBox_DeptoJudicial
            // 
            comboBox_DeptoJudicial.ArrowImage = (Image)resources.GetObject("comboBox_DeptoJudicial.ArrowImage");
            comboBox_DeptoJudicial.ArrowPictureBox = null;
            comboBox_DeptoJudicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_DeptoJudicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_DeptoJudicial.BackColor = Color.White;
            comboBox_DeptoJudicial.DataSource = null;
            comboBox_DeptoJudicial.DefaultImage = (Image)resources.GetObject("comboBox_DeptoJudicial.DefaultImage");
            comboBox_DeptoJudicial.DisabledImage = (Image)resources.GetObject("comboBox_DeptoJudicial.DisabledImage");
            comboBox_DeptoJudicial.DisplayMember = null;
            comboBox_DeptoJudicial.DropDownHeight = 252;
            comboBox_DeptoJudicial.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_DeptoJudicial.DroppedDown = false;
            comboBox_DeptoJudicial.ErrorColor = Color.Red;
            comboBox_DeptoJudicial.FocusColor = Color.Blue;
            comboBox_DeptoJudicial.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_DeptoJudicial.ForeColor = Color.Gray;
            comboBox_DeptoJudicial.Location = new Point(147, 57);
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
            comboBox_DeptoJudicial.Text = " ";
            comboBox_DeptoJudicial.TextValue = "";
            comboBox_DeptoJudicial.TextChanged += ComboBox_DeptoJudicial_TextChanged;
            // 
            // lbl_Localida
            // 
            lbl_Localida.AutoSize = true;
            lbl_Localida.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Localida.Location = new Point(64, 30);
            lbl_Localida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Localida.Name = "lbl_Localida";
            lbl_Localida.Size = new Size(80, 18);
            lbl_Localida.TabIndex = 37;
            lbl_Localida.Text = "Localidad";
            // 
            // lbl_DeptoJudicial
            // 
            lbl_DeptoJudicial.AutoSize = true;
            lbl_DeptoJudicial.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_DeptoJudicial.Location = new Point(31, 57);
            lbl_DeptoJudicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_DeptoJudicial.Name = "lbl_DeptoJudicial";
            lbl_DeptoJudicial.Size = new Size(120, 18);
            lbl_DeptoJudicial.TabIndex = 35;
            lbl_DeptoJudicial.Text = "Depto. Judicial";
            // 
            // comboBox_Localidad
            // 
            comboBox_Localidad.ArrowImage = (Image)resources.GetObject("comboBox_Localidad.ArrowImage");
            comboBox_Localidad.ArrowPictureBox = null;
            comboBox_Localidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Localidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Localidad.BackColor = Color.White;
            comboBox_Localidad.DataSource = null;
            comboBox_Localidad.DefaultImage = (Image)resources.GetObject("comboBox_Localidad.DefaultImage");
            comboBox_Localidad.DisabledImage = (Image)resources.GetObject("comboBox_Localidad.DisabledImage");
            comboBox_Localidad.DisplayMember = null;
            comboBox_Localidad.DropDownHeight = 252;
            comboBox_Localidad.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Localidad.DroppedDown = false;
            comboBox_Localidad.ErrorColor = Color.Red;
            comboBox_Localidad.FocusColor = Color.Blue;
            comboBox_Localidad.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Localidad.ForeColor = Color.Gray;
            comboBox_Localidad.Location = new Point(147, 30);
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
            comboBox_Localidad.Text = " ";
            comboBox_Localidad.TextValue = "";
            // 
            // panel_Imputado
            // 
            panel_Imputado.AutoSize = true;
            panel_Imputado.BackColor = Color.Transparent;
            panel_Imputado.Controls.Add(textBox_Imputado);
            panel_Imputado.Controls.Add(lbl_Imputado);
            panel_Imputado.Controls.Add(btn_AgregarDatosImputado);
            panel_Imputado.Controls.Add(btn_AgregarImputado);
            panel_Imputado.Location = new Point(3, 102);
            panel_Imputado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Imputado.Name = "panel_Imputado";
            panel_Imputado.Size = new Size(524, 31);
            panel_Imputado.TabIndex = 41;
            // 
            // panel_Caratula
            // 
            panel_Caratula.BackColor = Color.Transparent;
            panel_Caratula.Controls.Add(textBox_Caratula);
            panel_Caratula.Controls.Add(lbl_Caratula);
            panel_Caratula.Controls.Add(btn_AgregarCausa);
            panel_Caratula.Location = new Point(3, 43);
            panel_Caratula.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Caratula.Name = "panel_Caratula";
            panel_Caratula.Size = new Size(523, 29);
            panel_Caratula.TabIndex = 43;
            // 
            // textBox_Caratula
            // 
            textBox_Caratula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Caratula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Caratula.BackColor = Color.White;
            textBox_Caratula.ErrorColor = Color.Red;
            textBox_Caratula.FocusColor = Color.Blue;
            textBox_Caratula.Location = new Point(146, 5);
            textBox_Caratula.MaxLength = 32767;
            textBox_Caratula.Multiline = false;
            textBox_Caratula.Name = "textBox_Caratula";
            textBox_Caratula.PasswordChar = '\0';
            textBox_Caratula.PlaceholderColor = Color.Gray;
            textBox_Caratula.PlaceholderText = "";
            textBox_Caratula.ReadOnly = false;
            textBox_Caratula.SelectionStart = 0;
            textBox_Caratula.ShowError = false;
            textBox_Caratula.Size = new Size(333, 21);
            textBox_Caratula.TabIndex = 28;
            textBox_Caratula.Text = "customTextBox1";
            textBox_Caratula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Caratula.TextValue = "";
            textBox_Caratula.Whidth = 0;
            // 
            // panel_Compromisos
            // 
            panel_Compromisos.Controls.Add(panel_Cargo);
            panel_Compromisos.Controls.Add(panel_RatificacionPersonal);
            panel_Compromisos.Controls.Add(panel_StudRML);
            panel_Compromisos.Controls.Add(panel_Not247);
            panel_Compromisos.Controls.Add(panel_InsertarSecuestro);
            panel_Compromisos.Location = new Point(4, 345);
            panel_Compromisos.Name = "panel_Compromisos";
            panel_Compromisos.Size = new Size(535, 81);
            panel_Compromisos.TabIndex = 103;
            // 
            // panel_Cargo
            // 
            panel_Cargo.Controls.Add(label_Cargo);
            panel_Cargo.Controls.Add(checkBox_Cargo);
            panel_Cargo.Location = new Point(242, 43);
            panel_Cargo.Name = "panel_Cargo";
            panel_Cargo.Size = new Size(90, 34);
            panel_Cargo.TabIndex = 19;
            // 
            // label_Cargo
            // 
            label_Cargo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Cargo.Location = new Point(4, 7);
            label_Cargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Cargo.Name = "label_Cargo";
            label_Cargo.Size = new Size(85, 19);
            label_Cargo.TabIndex = 40;
            label_Cargo.Text = "   Cargo   ";
            label_Cargo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_RatificacionPersonal
            // 
            panel_RatificacionPersonal.Controls.Add(label_RatificacionPersonal);
            panel_RatificacionPersonal.Controls.Add(checkBox_RatificacionTestimonial);
            panel_RatificacionPersonal.Controls.Add(btn_ContadorRatificaciones);
            panel_RatificacionPersonal.Location = new Point(5, 44);
            panel_RatificacionPersonal.Name = "panel_RatificacionPersonal";
            panel_RatificacionPersonal.Size = new Size(236, 33);
            panel_RatificacionPersonal.TabIndex = 19;
            // 
            // label_RatificacionPersonal
            // 
            label_RatificacionPersonal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_RatificacionPersonal.Location = new Point(35, 4);
            label_RatificacionPersonal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_RatificacionPersonal.Name = "label_RatificacionPersonal";
            label_RatificacionPersonal.Size = new Size(198, 28);
            label_RatificacionPersonal.TabIndex = 38;
            label_RatificacionPersonal.Text = "Ratificación testimonial   ";
            label_RatificacionPersonal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_ContadorRatificaciones
            // 
            btn_ContadorRatificaciones.BackColor = Color.FromArgb(0, 154, 174);
            btn_ContadorRatificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_ContadorRatificaciones.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ContadorRatificaciones.ForeColor = SystemColors.ControlText;
            btn_ContadorRatificaciones.Location = new Point(5, 2);
            btn_ContadorRatificaciones.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            btn_ContadorRatificaciones.MinimumSize = new Size(24, 24);
            btn_ContadorRatificaciones.Name = "btn_ContadorRatificaciones";
            btn_ContadorRatificaciones.Size = new Size(24, 27);
            btn_ContadorRatificaciones.TabIndex = 53;
            btn_ContadorRatificaciones.Text = null;
            // 
            // panel_StudRML
            // 
            panel_StudRML.Controls.Add(label_StudRML);
            panel_StudRML.Controls.Add(Btn_ContadorRML);
            panel_StudRML.Location = new Point(383, 3);
            panel_StudRML.Name = "panel_StudRML";
            panel_StudRML.Size = new Size(148, 39);
            panel_StudRML.TabIndex = 39;
            // 
            // label_StudRML
            // 
            label_StudRML.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_StudRML.Location = new Point(17, 11);
            label_StudRML.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_StudRML.Name = "label_StudRML";
            label_StudRML.Size = new Size(92, 20);
            label_StudRML.TabIndex = 45;
            label_StudRML.Text = "Stud. R.M.L   ";
            label_StudRML.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Btn_ContadorRML
            // 
            Btn_ContadorRML.BackColor = Color.FromArgb(0, 154, 174);
            Btn_ContadorRML.Cursor = System.Windows.Forms.Cursors.Hand;
            Btn_ContadorRML.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_ContadorRML.ForeColor = SystemColors.ControlText;
            Btn_ContadorRML.Location = new Point(118, 6);
            Btn_ContadorRML.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            Btn_ContadorRML.MinimumSize = new Size(24, 24);
            Btn_ContadorRML.Name = "Btn_ContadorRML";
            Btn_ContadorRML.Size = new Size(24, 27);
            Btn_ContadorRML.TabIndex = 54;
            Btn_ContadorRML.Text = null;
            // 
            // panel_Not247
            // 
            panel_Not247.BackColor = Color.Transparent;
            panel_Not247.Controls.Add(Btn_Contador247);
            panel_Not247.Controls.Add(fecha_Pericia);
            panel_Not247.Controls.Add(botonDeslizable_Not247);
            panel_Not247.Controls.Add(label_Not247);
            panel_Not247.Location = new Point(1, 3);
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
            Btn_Contador247.Location = new Point(9, 9);
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
            fecha_Pericia.Size = new Size(127, 23);
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
            botonDeslizable_Not247.Location = new Point(193, 9);
            botonDeslizable_Not247.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            botonDeslizable_Not247.Name = "botonDeslizable_Not247";
            botonDeslizable_Not247.Size = new Size(47, 23);
            botonDeslizable_Not247.TabIndex = 54;
            botonDeslizable_Not247.ValidarCampos = null;
            // 
            // label_Not247
            // 
            label_Not247.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Not247.Location = new Point(39, 9);
            label_Not247.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Not247.Name = "label_Not247";
            label_Not247.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            label_Not247.Size = new Size(201, 24);
            label_Not247.TabIndex = 53;
            label_Not247.Text = "Not. Art. 247 C.P.P.   ";
            label_Not247.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_InsertarSecuestro
            // 
            panel_InsertarSecuestro.Controls.Add(botonDeslizable_InsertarSecuestro);
            panel_InsertarSecuestro.Controls.Add(label_InsertarSecuestro);
            panel_InsertarSecuestro.Location = new Point(338, 43);
            panel_InsertarSecuestro.Name = "panel_InsertarSecuestro";
            panel_InsertarSecuestro.Size = new Size(194, 34);
            panel_InsertarSecuestro.TabIndex = 102;
            // 
            // botonDeslizable_InsertarSecuestro
            // 
            botonDeslizable_InsertarSecuestro.Cursor = System.Windows.Forms.Cursors.Hand;
            botonDeslizable_InsertarSecuestro.IsOn = false;
            botonDeslizable_InsertarSecuestro.Location = new Point(146, 7);
            botonDeslizable_InsertarSecuestro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            botonDeslizable_InsertarSecuestro.Name = "botonDeslizable_InsertarSecuestro";
            botonDeslizable_InsertarSecuestro.Size = new Size(47, 23);
            botonDeslizable_InsertarSecuestro.TabIndex = 101;
            botonDeslizable_InsertarSecuestro.ValidarCampos = null;
            // 
            // label_InsertarSecuestro
            // 
            label_InsertarSecuestro.AutoSize = true;
            label_InsertarSecuestro.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_InsertarSecuestro.Location = new Point(11, 10);
            label_InsertarSecuestro.Name = "label_InsertarSecuestro";
            label_InsertarSecuestro.Size = new Size(165, 20);
            label_InsertarSecuestro.TabIndex = 100;
            label_InsertarSecuestro.Text = "Insertar Secuestro";
            label_InsertarSecuestro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_ControlesInferiores
            // 
            panel_ControlesInferiores.Anchor = System.Windows.Forms.AnchorStyles.Left;
            panel_ControlesInferiores.BackColor = Color.Transparent;
            panel_ControlesInferiores.Controls.Add(btn_Imprimir);
            panel_ControlesInferiores.Controls.Add(btn_Buscar);
            panel_ControlesInferiores.Controls.Add(btn_Guardar);
            panel_ControlesInferiores.Controls.Add(btn_Limpiar);
            panel_ControlesInferiores.Location = new Point(4, 428);
            panel_ControlesInferiores.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            panel_ControlesInferiores.Size = new Size(524, 111);
            panel_ControlesInferiores.TabIndex = 42;
            // 
            // label_TITULO
            // 
            label_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label_TITULO.AutoSize = true;
            label_TITULO.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = SystemColors.ControlLightLight;
            label_TITULO.Location = new Point(142, 9);
            label_TITULO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            label_TITULO.Size = new Size(378, 29);
            label_TITULO.TabIndex = 31;
            label_TITULO.Text = "ESTRUCTURA BASICA I.P.P.";
            // 
            // InicioCierre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 154, 174);
            ClientSize = new Size(579, 602);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "InicioCierre";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ACTUACIONES SUMARIALES PREVENCIONALES";
            FormClosing += InicioCierre_FormClosing;
            Load += InicioCierre_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            panel_DatosIppCompleta.ResumeLayout(false);
            panel_DatosIppCompleta.PerformLayout();
            panel_Ipp.ResumeLayout(false);
            panel_Ipp.PerformLayout();
            panel_Victima.ResumeLayout(false);
            panel_Victima.PerformLayout();
            panel_Instruccion.ResumeLayout(false);
            panel_Instruccion.PerformLayout();
            panel_Imputado.ResumeLayout(false);
            panel_Imputado.PerformLayout();
            panel_Caratula.ResumeLayout(false);
            panel_Caratula.PerformLayout();
            panel_Compromisos.ResumeLayout(false);
            panel_Cargo.ResumeLayout(false);
            panel_Cargo.PerformLayout();
            panel_RatificacionPersonal.ResumeLayout(false);
            panel_RatificacionPersonal.PerformLayout();
            panel_StudRML.ResumeLayout(false);
            panel_Not247.ResumeLayout(false);
            panel_Not247.PerformLayout();
            panel_InsertarSecuestro.ResumeLayout(false);
            panel_InsertarSecuestro.PerformLayout();
            panel_ControlesInferiores.ResumeLayout(false);
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
        private System.Windows.Forms.Label label_StudRML;
        private Ofelia_Sara.Controles.Ofl_Sara.Boton_Contador Btn_ContadorRML;
        private Ofelia_Sara.Controles.Ofl_Sara.Boton_Contador btn_ContadorRatificaciones;
        private Ofelia_Sara.Controles.Ofl_Sara.TimePickerPersonalizado timePickerPersonalizado1;
        private System.Windows.Forms.Panel panel_Not247;
        private Ofelia_Sara.Controles.Ofl_Sara.Boton_Contador Btn_Contador247;
        private System.Windows.Forms.MaskedTextBox fecha_Pericia;
        private Ofelia_Sara.Controles.General.BotonDeslizable botonDeslizable_Not247;
        private System.Windows.Forms.Label label_Not247;
        private CustomTextBox textBox_Caratula;
        private BotonDeslizable botonDeslizable_InsertarSecuestro;
        private System.Windows.Forms.Label label_InsertarSecuestro;
        private System.Windows.Forms.Panel panel_InsertarSecuestro;
        private System.Windows.Forms.Panel panel_Compromisos;
        private System.Windows.Forms.Panel panel_DatosIppCompleta;
        private System.Windows.Forms.Button btn_SDA;
        private System.Windows.Forms.Button btn_CrearDenuncia;
        private System.Windows.Forms.Panel panel_StudRML;
        private System.Windows.Forms.Panel panel_RatificacionPersonal;
        private System.Windows.Forms.Panel panel_Cargo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}