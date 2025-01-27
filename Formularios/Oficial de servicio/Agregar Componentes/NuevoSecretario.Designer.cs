using Ofelia_Sara.Controles.General;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    partial class NuevoSecretario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoSecretario));
            panel1 = new Panel();
            pictureBox_CheckFirmaDigitalizada = new PictureBox();
            comboBox_Dependencia = new CustomComboBox();
            label_Dependencia = new Label();
            comboBox_Jerarquia = new CustomComboBox();
            comboBox_Escalafon = new CustomComboBox();
            label_Escalafon = new Label();
            label_Jerarquia = new Label();
            textBox_NumeroLegajo = new CustomTextBox();
            label_Legajo = new Label();
            pictureBox_FirmaDigitalizada = new PictureBox();
            textBox_Funcion = new CustomTextBox();
            label_Funcion = new Label();
            textBox_Apellido = new CustomTextBox();
            label_Apellido = new Label();
            textBox_Nombre = new CustomTextBox();
            label_Nombre = new Label();
            checkBox_AgregarFirma = new CheckBox();
            label_AgregaFirma = new Label();
            btn_Limpiar = new Button();
            btn_Guardar = new Button();
            label_NuevoSecretario = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckFirmaDigitalizada).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FirmaDigitalizada).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(pictureBox_CheckFirmaDigitalizada);
            panel1.Controls.Add(comboBox_Dependencia);
            panel1.Controls.Add(label_Dependencia);
            panel1.Controls.Add(comboBox_Jerarquia);
            panel1.Controls.Add(comboBox_Escalafon);
            panel1.Controls.Add(label_Escalafon);
            panel1.Controls.Add(label_Jerarquia);
            panel1.Controls.Add(textBox_NumeroLegajo);
            panel1.Controls.Add(label_Legajo);
            panel1.Controls.Add(pictureBox_FirmaDigitalizada);
            panel1.Controls.Add(textBox_Funcion);
            panel1.Controls.Add(label_Funcion);
            panel1.Controls.Add(textBox_Apellido);
            panel1.Controls.Add(label_Apellido);
            panel1.Controls.Add(textBox_Nombre);
            panel1.Controls.Add(label_Nombre);
            panel1.Controls.Add(checkBox_AgregarFirma);
            panel1.Controls.Add(label_AgregaFirma);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(label_NuevoSecretario);
            panel1.Location = new System.Drawing.Point(23, 27);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(523, 461);
            panel1.TabIndex = 2;
            // 
            // pictureBox_CheckFirmaDigitalizada
            // 
            pictureBox_CheckFirmaDigitalizada.BackgroundImageLayout = ImageLayout.Center;
            pictureBox_CheckFirmaDigitalizada.Cursor = Cursors.Hand;
            pictureBox_CheckFirmaDigitalizada.Image = Properties.Resources.check_Personalizado;
            pictureBox_CheckFirmaDigitalizada.Location = new System.Drawing.Point(246, 294);
            pictureBox_CheckFirmaDigitalizada.Margin = new Padding(4, 3, 4, 3);
            pictureBox_CheckFirmaDigitalizada.Name = "pictureBox_CheckFirmaDigitalizada";
            pictureBox_CheckFirmaDigitalizada.Size = new System.Drawing.Size(27, 32);
            pictureBox_CheckFirmaDigitalizada.TabIndex = 68;
            pictureBox_CheckFirmaDigitalizada.TabStop = false;
            pictureBox_CheckFirmaDigitalizada.Click += PictureBox_CheckFirmaDigitalizada_Click;
            // 
            // comboBox_Dependencia
            // 
            comboBox_Dependencia.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Dependencia.ArrowImage");
            comboBox_Dependencia.ArrowPictureBox = null;
            comboBox_Dependencia.AutoCompleteMode = AutoCompleteMode.None;
            comboBox_Dependencia.AutoCompleteSource = AutoCompleteSource.None;
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
            comboBox_Dependencia.Location = new System.Drawing.Point(154, 211);
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
            comboBox_Dependencia.Size = new System.Drawing.Size(327, 21);
            comboBox_Dependencia.TabIndex = 64;
            comboBox_Dependencia.Text = " ";
            comboBox_Dependencia.TextValue = "";
            // 
            // label_Dependencia
            // 
            label_Dependencia.AutoSize = true;
            label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dependencia.Location = new System.Drawing.Point(27, 212);
            label_Dependencia.Name = "label_Dependencia";
            label_Dependencia.Size = new System.Drawing.Size(123, 16);
            label_Dependencia.TabIndex = 63;
            label_Dependencia.Text = "DEPENDENCIA :";
            // 
            // comboBox_Jerarquia
            // 
            comboBox_Jerarquia.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Jerarquia.ArrowImage");
            comboBox_Jerarquia.ArrowPictureBox = null;
            comboBox_Jerarquia.AutoCompleteMode = AutoCompleteMode.None;
            comboBox_Jerarquia.AutoCompleteSource = AutoCompleteSource.None;
            comboBox_Jerarquia.BackColor = System.Drawing.Color.White;
            comboBox_Jerarquia.DataSource = null;
            comboBox_Jerarquia.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Jerarquia.DefaultImage");
            comboBox_Jerarquia.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Jerarquia.DisabledImage");
            comboBox_Jerarquia.DisplayMember = null;
            comboBox_Jerarquia.DropDownHeight = 252;
            comboBox_Jerarquia.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Jerarquia.DroppedDown = false;
            comboBox_Jerarquia.ErrorColor = System.Drawing.Color.Red;
            comboBox_Jerarquia.FocusColor = System.Drawing.Color.Blue;
            comboBox_Jerarquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Jerarquia.ForeColor = System.Drawing.Color.Gray;
            comboBox_Jerarquia.Location = new System.Drawing.Point(155, 107);
            comboBox_Jerarquia.Margin = new Padding(0);
            comboBox_Jerarquia.MaxDropDownItems = 10;
            comboBox_Jerarquia.Name = "comboBox_Jerarquia";
            comboBox_Jerarquia.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Jerarquia.PlaceholderText = " ";
            comboBox_Jerarquia.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Jerarquia.PressedImage");
            comboBox_Jerarquia.SelectedIndex = -1;
            comboBox_Jerarquia.SelectedItem = null;
            comboBox_Jerarquia.SelectedText = "";
            comboBox_Jerarquia.SelectionStart = 0;
            comboBox_Jerarquia.ShowError = false;
            comboBox_Jerarquia.Size = new System.Drawing.Size(326, 23);
            comboBox_Jerarquia.TabIndex = 62;
            comboBox_Jerarquia.Text = " ";
            comboBox_Jerarquia.TextValue = "";
            // 
            // comboBox_Escalafon
            // 
            comboBox_Escalafon.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Escalafon.ArrowImage");
            comboBox_Escalafon.ArrowPictureBox = null;
            comboBox_Escalafon.AutoCompleteMode = AutoCompleteMode.None;
            comboBox_Escalafon.AutoCompleteSource = AutoCompleteSource.None;
            comboBox_Escalafon.BackColor = System.Drawing.Color.White;
            comboBox_Escalafon.DataSource = null;
            comboBox_Escalafon.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Escalafon.DefaultImage");
            comboBox_Escalafon.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Escalafon.DisabledImage");
            comboBox_Escalafon.DisplayMember = null;
            comboBox_Escalafon.DropDownHeight = 252;
            comboBox_Escalafon.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Escalafon.DroppedDown = false;
            comboBox_Escalafon.ErrorColor = System.Drawing.Color.Red;
            comboBox_Escalafon.FocusColor = System.Drawing.Color.Blue;
            comboBox_Escalafon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Escalafon.ForeColor = System.Drawing.Color.Gray;
            comboBox_Escalafon.Location = new System.Drawing.Point(155, 80);
            comboBox_Escalafon.MaxDropDownItems = 10;
            comboBox_Escalafon.Name = "comboBox_Escalafon";
            comboBox_Escalafon.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Escalafon.PlaceholderText = " ";
            comboBox_Escalafon.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Escalafon.PressedImage");
            comboBox_Escalafon.SelectedIndex = -1;
            comboBox_Escalafon.SelectedItem = null;
            comboBox_Escalafon.SelectedText = "";
            comboBox_Escalafon.SelectionStart = 0;
            comboBox_Escalafon.ShowError = false;
            comboBox_Escalafon.Size = new System.Drawing.Size(326, 21);
            comboBox_Escalafon.TabIndex = 61;
            comboBox_Escalafon.Text = " ";
            comboBox_Escalafon.TextValue = "";
            // 
            // label_Escalafon
            // 
            label_Escalafon.AutoSize = true;
            label_Escalafon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Escalafon.Location = new System.Drawing.Point(15, 82);
            label_Escalafon.Name = "label_Escalafon";
            label_Escalafon.Size = new System.Drawing.Size(135, 16);
            label_Escalafon.TabIndex = 60;
            label_Escalafon.Text = "SUBESCALAFON :";
            // 
            // label_Jerarquia
            // 
            label_Jerarquia.AutoSize = true;
            label_Jerarquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Jerarquia.Location = new System.Drawing.Point(48, 109);
            label_Jerarquia.Name = "label_Jerarquia";
            label_Jerarquia.Size = new System.Drawing.Size(101, 16);
            label_Jerarquia.TabIndex = 59;
            label_Jerarquia.Text = "JERARQUIA :";
            // 
            // textBox_NumeroLegajo
            // 
            textBox_NumeroLegajo.AutoCompleteMode = AutoCompleteMode.None;
            textBox_NumeroLegajo.AutoCompleteSource = AutoCompleteSource.None;
            textBox_NumeroLegajo.BackColor = System.Drawing.Color.White;
            textBox_NumeroLegajo.ErrorColor = System.Drawing.Color.Red;
            textBox_NumeroLegajo.FocusColor = System.Drawing.Color.Blue;
            textBox_NumeroLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_NumeroLegajo.Location = new System.Drawing.Point(154, 53);
            textBox_NumeroLegajo.MaxLength = 32767;
            textBox_NumeroLegajo.Multiline = false;
            textBox_NumeroLegajo.Name = "textBox_NumeroLegajo";
            textBox_NumeroLegajo.PasswordChar = '\0';
            textBox_NumeroLegajo.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_NumeroLegajo.PlaceholderText = "";
            textBox_NumeroLegajo.ReadOnly = false;
            textBox_NumeroLegajo.SelectionStart = 0;
            textBox_NumeroLegajo.ShowError = false;
            textBox_NumeroLegajo.Size = new System.Drawing.Size(195, 21);
            textBox_NumeroLegajo.TabIndex = 53;
            textBox_NumeroLegajo.TextAlign = HorizontalAlignment.Center;
            textBox_NumeroLegajo.TextValue = "";
            textBox_NumeroLegajo.TextChanged += TextBox_NumeroLegajo_TextChanged;
            textBox_NumeroLegajo.KeyPress += TextBox_NumeroLegajo_KeyPress;
            // 
            // label_Legajo
            // 
            label_Legajo.AutoSize = true;
            label_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Legajo.Location = new System.Drawing.Point(78, 56);
            label_Legajo.Name = "label_Legajo";
            label_Legajo.Size = new System.Drawing.Size(73, 16);
            label_Legajo.TabIndex = 52;
            label_Legajo.Text = "LEGAJO :";
            // 
            // pictureBox_FirmaDigitalizada
            // 
            pictureBox_FirmaDigitalizada.BackColor = System.Drawing.SystemColors.ControlLight;
            pictureBox_FirmaDigitalizada.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox_FirmaDigitalizada.BackgroundImage");
            pictureBox_FirmaDigitalizada.BackgroundImageLayout = ImageLayout.Center;
            pictureBox_FirmaDigitalizada.Location = new System.Drawing.Point(275, 275);
            pictureBox_FirmaDigitalizada.Name = "pictureBox_FirmaDigitalizada";
            pictureBox_FirmaDigitalizada.Size = new System.Drawing.Size(206, 81);
            pictureBox_FirmaDigitalizada.TabIndex = 51;
            pictureBox_FirmaDigitalizada.TabStop = false;
            pictureBox_FirmaDigitalizada.Click += PictureBox_Click;
            pictureBox_FirmaDigitalizada.DragDrop += PictureBox_DragDrop;
            pictureBox_FirmaDigitalizada.DragEnter += PictureBox_DragEnter;
            pictureBox_FirmaDigitalizada.Paint += PictureBox_FirmaDigitalizada_Paint;
            // 
            // textBox_Funcion
            // 
            textBox_Funcion.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Funcion.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Funcion.BackColor = System.Drawing.Color.White;
            textBox_Funcion.ErrorColor = System.Drawing.Color.Red;
            textBox_Funcion.FocusColor = System.Drawing.Color.Blue;
            textBox_Funcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Funcion.Location = new System.Drawing.Point(155, 238);
            textBox_Funcion.MaxLength = 32767;
            textBox_Funcion.Multiline = false;
            textBox_Funcion.Name = "textBox_Funcion";
            textBox_Funcion.PasswordChar = '\0';
            textBox_Funcion.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Funcion.PlaceholderText = "";
            textBox_Funcion.ReadOnly = false;
            textBox_Funcion.SelectionStart = 0;
            textBox_Funcion.ShowError = false;
            textBox_Funcion.Size = new System.Drawing.Size(326, 21);
            textBox_Funcion.TabIndex = 3;
            textBox_Funcion.TextAlign = HorizontalAlignment.Center;
            textBox_Funcion.TextValue = "";
            // 
            // label_Funcion
            // 
            label_Funcion.AutoSize = true;
            label_Funcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Funcion.Location = new System.Drawing.Point(68, 241);
            label_Funcion.Name = "label_Funcion";
            label_Funcion.Size = new System.Drawing.Size(82, 16);
            label_Funcion.TabIndex = 49;
            label_Funcion.Text = "FUNCION :";
            // 
            // textBox_Apellido
            // 
            textBox_Apellido.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Apellido.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Apellido.BackColor = System.Drawing.Color.White;
            textBox_Apellido.ErrorColor = System.Drawing.Color.Red;
            textBox_Apellido.FocusColor = System.Drawing.Color.Blue;
            textBox_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Apellido.Location = new System.Drawing.Point(155, 174);
            textBox_Apellido.MaxLength = 32767;
            textBox_Apellido.Multiline = false;
            textBox_Apellido.Name = "textBox_Apellido";
            textBox_Apellido.PasswordChar = '\0';
            textBox_Apellido.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Apellido.PlaceholderText = "";
            textBox_Apellido.ReadOnly = false;
            textBox_Apellido.SelectionStart = 0;
            textBox_Apellido.ShowError = false;
            textBox_Apellido.Size = new System.Drawing.Size(326, 21);
            textBox_Apellido.TabIndex = 2;
            textBox_Apellido.TextAlign = HorizontalAlignment.Center;
            textBox_Apellido.TextValue = "";
            // 
            // label_Apellido
            // 
            label_Apellido.AutoSize = true;
            label_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Apellido.Location = new System.Drawing.Point(62, 177);
            label_Apellido.Name = "label_Apellido";
            label_Apellido.Size = new System.Drawing.Size(87, 16);
            label_Apellido.TabIndex = 47;
            label_Apellido.Text = "APELLIDO :";
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Nombre.BackColor = System.Drawing.Color.White;
            textBox_Nombre.ErrorColor = System.Drawing.Color.Red;
            textBox_Nombre.FocusColor = System.Drawing.Color.Blue;
            textBox_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Nombre.Location = new System.Drawing.Point(155, 145);
            textBox_Nombre.MaxLength = 32767;
            textBox_Nombre.Multiline = false;
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.PasswordChar = '\0';
            textBox_Nombre.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Nombre.PlaceholderText = "";
            textBox_Nombre.ReadOnly = false;
            textBox_Nombre.SelectionStart = 0;
            textBox_Nombre.ShowError = false;
            textBox_Nombre.Size = new System.Drawing.Size(326, 21);
            textBox_Nombre.TabIndex = 1;
            textBox_Nombre.TextAlign = HorizontalAlignment.Center;
            textBox_Nombre.TextValue = "";
            // 
            // label_Nombre
            // 
            label_Nombre.AutoSize = true;
            label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nombre.Location = new System.Drawing.Point(69, 146);
            label_Nombre.Name = "label_Nombre";
            label_Nombre.Size = new System.Drawing.Size(80, 16);
            label_Nombre.TabIndex = 45;
            label_Nombre.Text = "NOMBRE :";
            // 
            // checkBox_AgregarFirma
            // 
            checkBox_AgregarFirma.AutoSize = true;
            checkBox_AgregarFirma.Cursor = Cursors.Hand;
            checkBox_AgregarFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_AgregarFirma.Location = new System.Drawing.Point(248, 299);
            checkBox_AgregarFirma.Name = "checkBox_AgregarFirma";
            checkBox_AgregarFirma.Size = new System.Drawing.Size(15, 14);
            checkBox_AgregarFirma.TabIndex = 4;
            checkBox_AgregarFirma.UseVisualStyleBackColor = true;
            checkBox_AgregarFirma.CheckedChanged += CheckBox_AgregarFirma_CheckedChanged;
            // 
            // label_AgregaFirma
            // 
            label_AgregaFirma.AutoSize = true;
            label_AgregaFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_AgregaFirma.Location = new System.Drawing.Point(27, 296);
            label_AgregaFirma.Name = "label_AgregaFirma";
            label_AgregaFirma.Size = new System.Drawing.Size(212, 15);
            label_AgregaFirma.TabIndex = 43;
            label_AgregaFirma.Text = "AGREGAR FIRMA DIGITALIZADA";
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(81, 375);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 6;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(408, 375);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 5;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // label_NuevoSecretario
            // 
            label_NuevoSecretario.AutoSize = true;
            label_NuevoSecretario.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_NuevoSecretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_NuevoSecretario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_NuevoSecretario.Location = new System.Drawing.Point(145, 0);
            label_NuevoSecretario.Name = "label_NuevoSecretario";
            label_NuevoSecretario.Padding = new Padding(10, 0, 10, 0);
            label_NuevoSecretario.Size = new System.Drawing.Size(240, 24);
            label_NuevoSecretario.TabIndex = 38;
            label_NuevoSecretario.Text = "NUEVO SECRETARIO";
            // 
            // NuevoSecretario
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(569, 530);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuevoSecretario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGREGAR NUEVO SECRETARIO";
            HelpButtonClicked += NuevoSecretario_HelpButtonClicked;
            Load += NuevoSecretario_Load;
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckFirmaDigitalizada).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FirmaDigitalizada).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_FirmaDigitalizada;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Funcion;
        private System.Windows.Forms.Label label_Funcion;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Apellido;
        private System.Windows.Forms.Label label_Apellido;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.CheckBox checkBox_AgregarFirma;
        private System.Windows.Forms.Label label_AgregaFirma;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Label label_NuevoSecretario;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_NumeroLegajo;
        private System.Windows.Forms.Label label_Legajo;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
        private System.Windows.Forms.Label label_Dependencia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Jerarquia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Escalafon;
        private System.Windows.Forms.Label label_Escalafon;
        private System.Windows.Forms.Label label_Jerarquia;
        private System.Windows.Forms.PictureBox pictureBox_CheckFirmaDigitalizada;
    }
}