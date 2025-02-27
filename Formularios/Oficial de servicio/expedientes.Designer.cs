using Ofelia_Sara.Controles.General;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class Expedientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expedientes));
            panel1 = new System.Windows.Forms.Panel();
            textBox_NumeroIpp = new CustomTextBox();
            comboBox_Ipp1 = new CustomComboBox();
            comboBox_Ipp2 = new CustomComboBox();
            lbl_00 = new System.Windows.Forms.Label();
            comboBox_Ipp4 = new CustomComboBox();
            label_Ipp = new System.Windows.Forms.Label();
            panel_ConversorDocumentos = new System.Windows.Forms.Panel();
            panel_ControlesInferiores = new System.Windows.Forms.Panel();
            btn_Imprimir = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Buscar = new System.Windows.Forms.Button();
            btn_Limpiar = new System.Windows.Forms.Button();
            groupBox_TextosConvertidos = new System.Windows.Forms.GroupBox();
            btn_Convertir = new System.Windows.Forms.Button();
            groupBox_ConversorDocumentos = new System.Windows.Forms.GroupBox();
            btn_EliminarArchivo = new System.Windows.Forms.Button();
            radioButton_Word = new System.Windows.Forms.RadioButton();
            radioButton_Pdf = new System.Windows.Forms.RadioButton();
            pictureBox_AWord = new System.Windows.Forms.PictureBox();
            pictureBox_APdf = new System.Windows.Forms.PictureBox();
            label_ConvertirAWord = new System.Windows.Forms.Label();
            label_ConvertirAPdf = new System.Windows.Forms.Label();
            label_ConversorDocumentos = new System.Windows.Forms.Label();
            panel_Control = new System.Windows.Forms.Panel();
            panel_DatosInstruccion = new System.Windows.Forms.Panel();
            label_DatosInstruccion = new System.Windows.Forms.Label();
            label_Instructor = new System.Windows.Forms.Label();
            label_Secretario = new System.Windows.Forms.Label();
            Fecha_Instruccion = new Controles.Ofl_Sara.TimePickerPersonalizado();
            label_Fecha = new System.Windows.Forms.Label();
            label_Dependencia = new System.Windows.Forms.Label();
            comboBox_Dependencia = new CustomComboBox();
            comboBox_Instructor = new CustomComboBox();
            comboBox_Secretario = new CustomComboBox();
            groupBox_SeleccionadorProcedencia = new System.Windows.Forms.GroupBox();
            radioButton_Juzgado = new System.Windows.Forms.RadioButton();
            radioButton_Fiscalia = new System.Windows.Forms.RadioButton();
            label_DatosActuacion = new System.Windows.Forms.Label();
            textBox_Caratula = new CustomTextBox();
            label_Caratula = new System.Windows.Forms.Label();
            textBox_Nombre = new CustomTextBox();
            label_Victima = new System.Windows.Forms.Label();
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel_ConversorDocumentos.SuspendLayout();
            panel_ControlesInferiores.SuspendLayout();
            groupBox_ConversorDocumentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AWord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_APdf).BeginInit();
            panel_DatosInstruccion.SuspendLayout();
            groupBox_SeleccionadorProcedencia.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(textBox_NumeroIpp);
            panel1.Controls.Add(comboBox_Ipp1);
            panel1.Controls.Add(comboBox_Ipp2);
            panel1.Controls.Add(lbl_00);
            panel1.Controls.Add(comboBox_Ipp4);
            panel1.Controls.Add(label_Ipp);
            panel1.Controls.Add(panel_ConversorDocumentos);
            panel1.Controls.Add(panel_Control);
            panel1.Controls.Add(panel_DatosInstruccion);
            panel1.Controls.Add(groupBox_SeleccionadorProcedencia);
            panel1.Controls.Add(label_DatosActuacion);
            panel1.Controls.Add(textBox_Caratula);
            panel1.Controls.Add(label_Caratula);
            panel1.Controls.Add(textBox_Nombre);
            panel1.Controls.Add(label_Victima);
            panel1.Name = "panel1";
            // 
            // textBox_NumeroIpp
            // 
            textBox_NumeroIpp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_NumeroIpp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_NumeroIpp.BackColor = System.Drawing.Color.White;
            textBox_NumeroIpp.ErrorColor = System.Drawing.Color.Red;
            textBox_NumeroIpp.FocusColor = System.Drawing.Color.Blue;
            resources.ApplyResources(textBox_NumeroIpp, "textBox_NumeroIpp");
            textBox_NumeroIpp.MaxLength = 32767;
            textBox_NumeroIpp.Multiline = false;
            textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            textBox_NumeroIpp.PasswordChar = '\0';
            textBox_NumeroIpp.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_NumeroIpp.PlaceholderText = "";
            textBox_NumeroIpp.ReadOnly = false;
            textBox_NumeroIpp.SelectionStart = 0;
            textBox_NumeroIpp.ShowError = false;
            textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_NumeroIpp.TextValue = "";
            textBox_NumeroIpp.Whidth = 0;
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
            comboBox_Ipp1.DropDownHeight = 252;
            comboBox_Ipp1.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp1.DroppedDown = false;
            comboBox_Ipp1.ErrorColor = System.Drawing.Color.Red;
            comboBox_Ipp1.FocusColor = System.Drawing.Color.Blue;
            comboBox_Ipp1.ForeColor = System.Drawing.Color.Gray;
            resources.ApplyResources(comboBox_Ipp1, "comboBox_Ipp1");
            comboBox_Ipp1.MaxDropDownItems = 10;
            comboBox_Ipp1.Name = "comboBox_Ipp1";
            comboBox_Ipp1.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Ipp1.PlaceholderText = " ";
            comboBox_Ipp1.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp1.PressedImage");
            comboBox_Ipp1.SelectedIndex = -1;
            comboBox_Ipp1.SelectedItem = null;
            comboBox_Ipp1.SelectedText = "";
            comboBox_Ipp1.SelectionStart = 0;
            comboBox_Ipp1.ShowError = false;
            comboBox_Ipp1.TextValue = "";
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
            comboBox_Ipp2.DropDownHeight = 252;
            comboBox_Ipp2.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp2.DroppedDown = false;
            comboBox_Ipp2.ErrorColor = System.Drawing.Color.Red;
            comboBox_Ipp2.FocusColor = System.Drawing.Color.Blue;
            comboBox_Ipp2.ForeColor = System.Drawing.Color.Gray;
            resources.ApplyResources(comboBox_Ipp2, "comboBox_Ipp2");
            comboBox_Ipp2.MaxDropDownItems = 10;
            comboBox_Ipp2.Name = "comboBox_Ipp2";
            comboBox_Ipp2.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Ipp2.PlaceholderText = " ";
            comboBox_Ipp2.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp2.PressedImage");
            comboBox_Ipp2.SelectedIndex = -1;
            comboBox_Ipp2.SelectedItem = null;
            comboBox_Ipp2.SelectedText = "";
            comboBox_Ipp2.SelectionStart = 0;
            comboBox_Ipp2.ShowError = false;
            comboBox_Ipp2.TextValue = "";
            // 
            // lbl_00
            // 
            resources.ApplyResources(lbl_00, "lbl_00");
            lbl_00.Name = "lbl_00";
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
            comboBox_Ipp4.DropDownHeight = 252;
            comboBox_Ipp4.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Ipp4.DroppedDown = false;
            comboBox_Ipp4.ErrorColor = System.Drawing.Color.Red;
            comboBox_Ipp4.FocusColor = System.Drawing.Color.Blue;
            comboBox_Ipp4.ForeColor = System.Drawing.Color.Gray;
            resources.ApplyResources(comboBox_Ipp4, "comboBox_Ipp4");
            comboBox_Ipp4.MaxDropDownItems = 10;
            comboBox_Ipp4.Name = "comboBox_Ipp4";
            comboBox_Ipp4.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Ipp4.PlaceholderText = " ";
            comboBox_Ipp4.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Ipp4.PressedImage");
            comboBox_Ipp4.SelectedIndex = -1;
            comboBox_Ipp4.SelectedItem = null;
            comboBox_Ipp4.SelectedText = "";
            comboBox_Ipp4.SelectionStart = 0;
            comboBox_Ipp4.ShowError = false;
            comboBox_Ipp4.TextValue = "";
            // 
            // label_Ipp
            // 
            resources.ApplyResources(label_Ipp, "label_Ipp");
            label_Ipp.Name = "label_Ipp";
            // 
            // panel_ConversorDocumentos
            // 
            resources.ApplyResources(panel_ConversorDocumentos, "panel_ConversorDocumentos");
            panel_ConversorDocumentos.BackColor = System.Drawing.Color.Transparent;
            panel_ConversorDocumentos.Controls.Add(panel_ControlesInferiores);
            panel_ConversorDocumentos.Controls.Add(groupBox_TextosConvertidos);
            panel_ConversorDocumentos.Controls.Add(btn_Convertir);
            panel_ConversorDocumentos.Controls.Add(groupBox_ConversorDocumentos);
            panel_ConversorDocumentos.Controls.Add(label_ConversorDocumentos);
            panel_ConversorDocumentos.Name = "panel_ConversorDocumentos";
            panel_ConversorDocumentos.Paint += panel_ConversorDocumentos_Paint;
            // 
            // panel_ControlesInferiores
            // 
            resources.ApplyResources(panel_ControlesInferiores, "panel_ControlesInferiores");
            panel_ControlesInferiores.BackColor = System.Drawing.Color.Transparent;
            panel_ControlesInferiores.Controls.Add(btn_Imprimir);
            panel_ControlesInferiores.Controls.Add(btn_Guardar);
            panel_ControlesInferiores.Controls.Add(btn_Buscar);
            panel_ControlesInferiores.Controls.Add(btn_Limpiar);
            panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(btn_Imprimir, "btn_Imprimir");
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.UseVisualStyleBackColor = false;
            btn_Imprimir.Click += Btn_Imprimir_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(btn_Guardar, "btn_Guardar");
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(btn_Buscar, "btn_Buscar");
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(btn_Limpiar, "btn_Limpiar");
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // groupBox_TextosConvertidos
            // 
            resources.ApplyResources(groupBox_TextosConvertidos, "groupBox_TextosConvertidos");
            groupBox_TextosConvertidos.Name = "groupBox_TextosConvertidos";
            groupBox_TextosConvertidos.TabStop = false;
            // 
            // btn_Convertir
            // 
            btn_Convertir.BackColor = System.Drawing.Color.WhiteSmoke;
            btn_Convertir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Convertir.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            btn_Convertir.FlatAppearance.BorderSize = 2;
            btn_Convertir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btn_Convertir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            resources.ApplyResources(btn_Convertir, "btn_Convertir");
            btn_Convertir.Name = "btn_Convertir";
            btn_Convertir.UseVisualStyleBackColor = false;
            btn_Convertir.Click += btn_Convertir_Click;
            // 
            // groupBox_ConversorDocumentos
            // 
            resources.ApplyResources(groupBox_ConversorDocumentos, "groupBox_ConversorDocumentos");
            groupBox_ConversorDocumentos.BackColor = System.Drawing.SystemColors.ButtonFace;
            groupBox_ConversorDocumentos.Controls.Add(btn_EliminarArchivo);
            groupBox_ConversorDocumentos.Controls.Add(radioButton_Word);
            groupBox_ConversorDocumentos.Controls.Add(radioButton_Pdf);
            groupBox_ConversorDocumentos.Controls.Add(pictureBox_AWord);
            groupBox_ConversorDocumentos.Controls.Add(pictureBox_APdf);
            groupBox_ConversorDocumentos.Controls.Add(label_ConvertirAWord);
            groupBox_ConversorDocumentos.Controls.Add(label_ConvertirAPdf);
            groupBox_ConversorDocumentos.Name = "groupBox_ConversorDocumentos";
            groupBox_ConversorDocumentos.TabStop = false;
            // 
            // btn_EliminarArchivo
            // 
            btn_EliminarArchivo.BackgroundImage = Properties.Resources.borrar;
            resources.ApplyResources(btn_EliminarArchivo, "btn_EliminarArchivo");
            btn_EliminarArchivo.Name = "btn_EliminarArchivo";
            btn_EliminarArchivo.UseVisualStyleBackColor = true;
            btn_EliminarArchivo.Click += Btn_EliminarArchivo_Click;
            // 
            // radioButton_Word
            // 
            resources.ApplyResources(radioButton_Word, "radioButton_Word");
            radioButton_Word.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Word.Name = "radioButton_Word";
            radioButton_Word.TabStop = true;
            radioButton_Word.UseVisualStyleBackColor = true;
            radioButton_Word.CheckedChanged += RadioButton_Word_CheckedChanged;
            // 
            // radioButton_Pdf
            // 
            resources.ApplyResources(radioButton_Pdf, "radioButton_Pdf");
            radioButton_Pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Pdf.Name = "radioButton_Pdf";
            radioButton_Pdf.TabStop = true;
            radioButton_Pdf.UseVisualStyleBackColor = true;
            radioButton_Pdf.CheckedChanged += radioButton_Pdf_CheckedChanged;
            // 
            // pictureBox_AWord
            // 
            pictureBox_AWord.BackColor = System.Drawing.SystemColors.ControlLight;
            pictureBox_AWord.BackgroundImage = Properties.Resources.subir_documentos;
            resources.ApplyResources(pictureBox_AWord, "pictureBox_AWord");
            pictureBox_AWord.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_AWord.Name = "pictureBox_AWord";
            pictureBox_AWord.TabStop = false;
            pictureBox_AWord.Click += PictureBox_AWord_Click;
            pictureBox_AWord.DragDrop += PictureBox_AWord_DragDrop;
            pictureBox_AWord.DragEnter += PictureBox_AWord_DragEnter;
            pictureBox_AWord.Paint += PictureBox_Paint;
            // 
            // pictureBox_APdf
            // 
            pictureBox_APdf.BackColor = System.Drawing.SystemColors.ControlLight;
            pictureBox_APdf.BackgroundImage = Properties.Resources.subir_documentos;
            resources.ApplyResources(pictureBox_APdf, "pictureBox_APdf");
            pictureBox_APdf.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_APdf.Name = "pictureBox_APdf";
            pictureBox_APdf.TabStop = false;
            pictureBox_APdf.Click += PictureBox_APdf_Click;
            pictureBox_APdf.DragDrop += PictureBox_APdf_DragDrop;
            pictureBox_APdf.DragEnter += PictureBox_APdf_DragEnter;
            pictureBox_APdf.Paint += PictureBox_Paint;
            // 
            // label_ConvertirAWord
            // 
            resources.ApplyResources(label_ConvertirAWord, "label_ConvertirAWord");
            label_ConvertirAWord.Name = "label_ConvertirAWord";
            // 
            // label_ConvertirAPdf
            // 
            resources.ApplyResources(label_ConvertirAPdf, "label_ConvertirAPdf");
            label_ConvertirAPdf.Name = "label_ConvertirAPdf";
            // 
            // label_ConversorDocumentos
            // 
            resources.ApplyResources(label_ConversorDocumentos, "label_ConversorDocumentos");
            label_ConversorDocumentos.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_ConversorDocumentos.Name = "label_ConversorDocumentos";
            // 
            // panel_Control
            // 
            resources.ApplyResources(panel_Control, "panel_Control");
            panel_Control.Name = "panel_Control";
            // 
            // panel_DatosInstruccion
            // 
            resources.ApplyResources(panel_DatosInstruccion, "panel_DatosInstruccion");
            panel_DatosInstruccion.Controls.Add(label_DatosInstruccion);
            panel_DatosInstruccion.Controls.Add(label_Instructor);
            panel_DatosInstruccion.Controls.Add(label_Secretario);
            panel_DatosInstruccion.Controls.Add(Fecha_Instruccion);
            panel_DatosInstruccion.Controls.Add(label_Fecha);
            panel_DatosInstruccion.Controls.Add(label_Dependencia);
            panel_DatosInstruccion.Controls.Add(comboBox_Dependencia);
            panel_DatosInstruccion.Controls.Add(comboBox_Instructor);
            panel_DatosInstruccion.Controls.Add(comboBox_Secretario);
            panel_DatosInstruccion.Name = "panel_DatosInstruccion";
            // 
            // label_DatosInstruccion
            // 
            resources.ApplyResources(label_DatosInstruccion, "label_DatosInstruccion");
            label_DatosInstruccion.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosInstruccion.Name = "label_DatosInstruccion";
            // 
            // label_Instructor
            // 
            resources.ApplyResources(label_Instructor, "label_Instructor");
            label_Instructor.Name = "label_Instructor";
            // 
            // label_Secretario
            // 
            resources.ApplyResources(label_Secretario, "label_Secretario");
            label_Secretario.Name = "label_Secretario";
            // 
            // Fecha_Instruccion
            // 
            Fecha_Instruccion.AñoMaximo = 2025;
            Fecha_Instruccion.AñoMinimo = 1930;
            Fecha_Instruccion.BackColor = System.Drawing.SystemColors.Window;
            Fecha_Instruccion.FechaSeleccionada = new System.DateTime(0L);
            resources.ApplyResources(Fecha_Instruccion, "Fecha_Instruccion");
            Fecha_Instruccion.Name = "Fecha_Instruccion";
            Fecha_Instruccion.SubrayadoGeneralErrorColor = System.Drawing.Color.Red;
            Fecha_Instruccion.SubrayadoGeneralFocusColor = System.Drawing.Color.Blue;
            // 
            // label_Fecha
            // 
            resources.ApplyResources(label_Fecha, "label_Fecha");
            label_Fecha.Name = "label_Fecha";
            // 
            // label_Dependencia
            // 
            resources.ApplyResources(label_Dependencia, "label_Dependencia");
            label_Dependencia.Name = "label_Dependencia";
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
            resources.ApplyResources(comboBox_Dependencia, "comboBox_Dependencia");
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
            comboBox_Dependencia.TextValue = "";
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
            resources.ApplyResources(comboBox_Instructor, "comboBox_Instructor");
            comboBox_Instructor.ForeColor = System.Drawing.Color.Gray;
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
            comboBox_Instructor.TextValue = "";
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
            resources.ApplyResources(comboBox_Secretario, "comboBox_Secretario");
            comboBox_Secretario.ForeColor = System.Drawing.Color.Gray;
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
            comboBox_Secretario.TextValue = "";
            // 
            // groupBox_SeleccionadorProcedencia
            // 
            groupBox_SeleccionadorProcedencia.Controls.Add(radioButton_Juzgado);
            groupBox_SeleccionadorProcedencia.Controls.Add(radioButton_Fiscalia);
            groupBox_SeleccionadorProcedencia.Cursor = System.Windows.Forms.Cursors.Hand;
            groupBox_SeleccionadorProcedencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(groupBox_SeleccionadorProcedencia, "groupBox_SeleccionadorProcedencia");
            groupBox_SeleccionadorProcedencia.Name = "groupBox_SeleccionadorProcedencia";
            groupBox_SeleccionadorProcedencia.TabStop = false;
            // 
            // radioButton_Juzgado
            // 
            resources.ApplyResources(radioButton_Juzgado, "radioButton_Juzgado");
            radioButton_Juzgado.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Juzgado.Name = "radioButton_Juzgado";
            radioButton_Juzgado.TabStop = true;
            radioButton_Juzgado.UseVisualStyleBackColor = true;
            radioButton_Juzgado.CheckedChanged += RadioButton_Juzgado_CheckedChanged;
            // 
            // radioButton_Fiscalia
            // 
            resources.ApplyResources(radioButton_Fiscalia, "radioButton_Fiscalia");
            radioButton_Fiscalia.Name = "radioButton_Fiscalia";
            radioButton_Fiscalia.TabStop = true;
            radioButton_Fiscalia.UseVisualStyleBackColor = true;
            radioButton_Fiscalia.CheckedChanged += RadioButton_Fiscalia_CheckedChanged;
            // 
            // label_DatosActuacion
            // 
            resources.ApplyResources(label_DatosActuacion, "label_DatosActuacion");
            label_DatosActuacion.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosActuacion.Name = "label_DatosActuacion";
            // 
            // textBox_Caratula
            // 
            textBox_Caratula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Caratula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Caratula.BackColor = System.Drawing.Color.White;
            textBox_Caratula.ErrorColor = System.Drawing.Color.Red;
            textBox_Caratula.FocusColor = System.Drawing.Color.Blue;
            resources.ApplyResources(textBox_Caratula, "textBox_Caratula");
            textBox_Caratula.MaxLength = 32767;
            textBox_Caratula.Multiline = true;
            textBox_Caratula.Name = "textBox_Caratula";
            textBox_Caratula.PasswordChar = '\0';
            textBox_Caratula.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Caratula.PlaceholderText = "";
            textBox_Caratula.ReadOnly = false;
            textBox_Caratula.SelectionStart = 0;
            textBox_Caratula.ShowError = false;
            textBox_Caratula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Caratula.TextValue = "";
            textBox_Caratula.Whidth = 0;
            // 
            // label_Caratula
            // 
            resources.ApplyResources(label_Caratula, "label_Caratula");
            label_Caratula.Name = "label_Caratula";
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Nombre.BackColor = System.Drawing.Color.White;
            textBox_Nombre.ErrorColor = System.Drawing.Color.Red;
            textBox_Nombre.FocusColor = System.Drawing.Color.Blue;
            resources.ApplyResources(textBox_Nombre, "textBox_Nombre");
            textBox_Nombre.MaxLength = 32767;
            textBox_Nombre.Multiline = false;
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.PasswordChar = '\0';
            textBox_Nombre.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Nombre.PlaceholderText = "";
            textBox_Nombre.ReadOnly = false;
            textBox_Nombre.SelectionStart = 0;
            textBox_Nombre.ShowError = false;
            textBox_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Nombre.TextValue = "";
            textBox_Nombre.Whidth = 0;
            // 
            // label_Victima
            // 
            resources.ApplyResources(label_Victima, "label_Victima");
            label_Victima.Name = "label_Victima";
            // 
            // label_TITULO
            // 
            resources.ApplyResources(label_TITULO, "label_TITULO");
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Name = "label_TITULO";
            // 
            // Expedientes
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Expedientes";
            HelpButtonClicked += Expedientes_HelpButtonClicked;
            Load += Expedientes_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_ConversorDocumentos.ResumeLayout(false);
            panel_ConversorDocumentos.PerformLayout();
            panel_ControlesInferiores.ResumeLayout(false);
            groupBox_ConversorDocumentos.ResumeLayout(false);
            groupBox_ConversorDocumentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AWord).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_APdf).EndInit();
            panel_DatosInstruccion.ResumeLayout(false);
            panel_DatosInstruccion.PerformLayout();
            groupBox_SeleccionadorProcedencia.ResumeLayout(false);
            groupBox_SeleccionadorProcedencia.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Secretario;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Instructor;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_Fecha;
        private Ofelia_Sara.Controles.Ofl_Sara.TimePickerPersonalizado Fecha_Instruccion;
        private System.Windows.Forms.Label label_Secretario;
        private System.Windows.Forms.Label label_Instructor;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Caratula;
        private System.Windows.Forms.Label label_Caratula;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Victima;
        private System.Windows.Forms.Label label_DatosInstruccion;
        private System.Windows.Forms.GroupBox groupBox_ConversorDocumentos;
        private System.Windows.Forms.Label label_DatosActuacion;
        private System.Windows.Forms.Label label_ConversorDocumentos;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.PictureBox pictureBox_AWord;
        private System.Windows.Forms.PictureBox pictureBox_APdf;
        private System.Windows.Forms.Label label_ConvertirAWord;
        private System.Windows.Forms.Label label_ConvertirAPdf;
        private System.Windows.Forms.Button btn_Convertir;
        private System.Windows.Forms.GroupBox groupBox_SeleccionadorProcedencia;
        private System.Windows.Forms.RadioButton radioButton_Juzgado;
        private System.Windows.Forms.RadioButton radioButton_Fiscalia;
        private System.Windows.Forms.RadioButton radioButton_Pdf;
        private System.Windows.Forms.RadioButton radioButton_Word;
        private System.Windows.Forms.Button btn_EliminarArchivo;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Panel panel_DatosInstruccion;
        private System.Windows.Forms.Panel panel_ConversorDocumentos;
        private System.Windows.Forms.GroupBox groupBox_TextosConvertidos;
        private System.Windows.Forms.Panel panel_ControlesInferiores;
        private System.Windows.Forms.Label label_Ipp;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_NumeroIpp;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp1;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp2;
        private System.Windows.Forms.Label lbl_00;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Ipp4;
    }
}