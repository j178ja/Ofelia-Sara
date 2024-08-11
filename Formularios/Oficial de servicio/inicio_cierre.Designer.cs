
using Ofelia_Sara.general.clases;
using System.Drawing;

namespace Ofelia_Sara
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioCierre));
            this.lbl_Dr = new System.Windows.Forms.Label();
            this.textBox_NumeroIpp = new System.Windows.Forms.TextBox();
            this.lbl_Ipp = new System.Windows.Forms.Label();
            this.lbl_Caratula = new System.Windows.Forms.Label();
            this.lbl_Victima = new System.Windows.Forms.Label();
            this.lbl_Imputado = new System.Windows.Forms.Label();
            this.lbl_Ufid = new System.Windows.Forms.Label();
            this.lbl_Instructor = new System.Windows.Forms.Label();
            this.lbl_Secretario = new System.Windows.Forms.Label();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.lbl_Dependencia = new System.Windows.Forms.Label();
            this.textBox_Caratula = new System.Windows.Forms.TextBox();
            this.textBox_Victima = new System.Windows.Forms.TextBox();
            this.textBox_Imputado = new System.Windows.Forms.TextBox();
            this.comboBox_Ufid = new System.Windows.Forms.ComboBox();
            this.comboBox_Instructor = new System.Windows.Forms.ComboBox();
            this.comboBox_Secretario = new System.Windows.Forms.ComboBox();
            this.comboBox_Dependencia = new System.Windows.Forms.ComboBox();
            this.comboBox_Dr = new System.Windows.Forms.ComboBox();
            this.comboBox_Ipp1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Ipp2 = new System.Windows.Forms.ComboBox();
            this.lbl_00 = new System.Windows.Forms.Label();
            this.comboBox_Ipp4 = new System.Windows.Forms.ComboBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.btn_AgregarCausa = new System.Windows.Forms.Button();
            this.btn_AgregarVictima = new System.Windows.Forms.Button();
            this.btn_AgregarImputado = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_AgregarDatosImputado = new System.Windows.Forms.Button();
            this.btn_AgregarDatosVictima = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Caratula = new System.Windows.Forms.Panel();
            this.panel_ControlesInferiores = new System.Windows.Forms.Panel();
            this.lbl_Localida = new System.Windows.Forms.Label();
            this.comboBox_Localidad = new System.Windows.Forms.ComboBox();
            this.lbl_DeptoJudicial = new System.Windows.Forms.Label();
            this.comboBox_DeptoJudicial = new System.Windows.Forms.ComboBox();
            this.timePickerPersonalizado1 = new Ofelia_Sara.general.clases.Apariencia_General.TimePickerPersonalizado();
            this.panel_Imputado = new System.Windows.Forms.Panel();
            this.panel_Victima = new System.Windows.Forms.Panel();
            this.progressVerticalBar1 = new Ofelia_Sara.general.clases.ProgressVerticalBar();
            this.progressVerticalBar2 = new Ofelia_Sara.general.clases.ProgressVerticalBar();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_Caratula.SuspendLayout();
            this.panel_ControlesInferiores.SuspendLayout();
            this.panel_Imputado.SuspendLayout();
            this.panel_Victima.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 7, 24, 18, 43, 35, 659);
            // 
            // lbl_Dr
            // 
            this.lbl_Dr.AutoSize = true;
            this.lbl_Dr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dr.Location = new System.Drawing.Point(208, 6);
            this.lbl_Dr.Name = "lbl_Dr";
            this.lbl_Dr.Size = new System.Drawing.Size(26, 15);
            this.lbl_Dr.TabIndex = 0;
            this.lbl_Dr.Text = "Dr.";
            // 
            // textBox_NumeroIpp
            // 
            this.textBox_NumeroIpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NumeroIpp.Location = new System.Drawing.Point(234, 44);
            this.textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            this.textBox_NumeroIpp.Size = new System.Drawing.Size(96, 20);
            this.textBox_NumeroIpp.TabIndex = 2;
            this.textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NumeroIpp.TextChanged += new System.EventHandler(this.textBox_NumeroIpp_TextChanged);
            this.textBox_NumeroIpp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NumeroIpp_KeyPress);
            // 
            // lbl_Ipp
            // 
            this.lbl_Ipp.AutoSize = true;
            this.lbl_Ipp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ipp.Location = new System.Drawing.Point(82, 46);
            this.lbl_Ipp.Name = "lbl_Ipp";
            this.lbl_Ipp.Size = new System.Drawing.Size(41, 15);
            this.lbl_Ipp.TabIndex = 3;
            this.lbl_Ipp.Text = "l.P.P.";
            // 
            // lbl_Caratula
            // 
            this.lbl_Caratula.AutoSize = true;
            this.lbl_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Caratula.Location = new System.Drawing.Point(1, 4);
            this.lbl_Caratula.Name = "lbl_Caratula";
            this.lbl_Caratula.Size = new System.Drawing.Size(76, 15);
            this.lbl_Caratula.TabIndex = 4;
            this.lbl_Caratula.Text = "CARATULA";
            // 
            // lbl_Victima
            // 
            this.lbl_Victima.AutoSize = true;
            this.lbl_Victima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Victima.Location = new System.Drawing.Point(56, 4);
            this.lbl_Victima.Name = "lbl_Victima";
            this.lbl_Victima.Size = new System.Drawing.Size(60, 15);
            this.lbl_Victima.TabIndex = 5;
            this.lbl_Victima.Text = "VICTIMA";
            // 
            // lbl_Imputado
            // 
            this.lbl_Imputado.AutoSize = true;
            this.lbl_Imputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Imputado.Location = new System.Drawing.Point(35, 4);
            this.lbl_Imputado.Name = "lbl_Imputado";
            this.lbl_Imputado.Size = new System.Drawing.Size(78, 15);
            this.lbl_Imputado.TabIndex = 6;
            this.lbl_Imputado.Text = "lMPUTADO";
            // 
            // lbl_Ufid
            // 
            this.lbl_Ufid.AutoSize = true;
            this.lbl_Ufid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ufid.Location = new System.Drawing.Point(53, 5);
            this.lbl_Ufid.Name = "lbl_Ufid";
            this.lbl_Ufid.Size = new System.Drawing.Size(51, 15);
            this.lbl_Ufid.TabIndex = 7;
            this.lbl_Ufid.Text = "U.F.I.D";
            // 
            // lbl_Instructor
            // 
            this.lbl_Instructor.AutoSize = true;
            this.lbl_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Instructor.Location = new System.Drawing.Point(9, 95);
            this.lbl_Instructor.Name = "lbl_Instructor";
            this.lbl_Instructor.Size = new System.Drawing.Size(95, 15);
            this.lbl_Instructor.TabIndex = 8;
            this.lbl_Instructor.Text = "INSTRUCTOR";
            // 
            // lbl_Secretario
            // 
            this.lbl_Secretario.AutoSize = true;
            this.lbl_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Secretario.Location = new System.Drawing.Point(13, 124);
            this.lbl_Secretario.Name = "lbl_Secretario";
            this.lbl_Secretario.Size = new System.Drawing.Size(93, 15);
            this.lbl_Secretario.TabIndex = 9;
            this.lbl_Secretario.Text = "SECRETARIO";
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fecha.Location = new System.Drawing.Point(53, 181);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(51, 15);
            this.lbl_Fecha.TabIndex = 10;
            this.lbl_Fecha.Text = "FECHA";
            // 
            // lbl_Dependencia
            // 
            this.lbl_Dependencia.AutoSize = true;
            this.lbl_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dependencia.Location = new System.Drawing.Point(2, 153);
            this.lbl_Dependencia.Name = "lbl_Dependencia";
            this.lbl_Dependencia.Size = new System.Drawing.Size(104, 15);
            this.lbl_Dependencia.TabIndex = 11;
            this.lbl_Dependencia.Text = "DEPENDENCIA";
            // 
            // textBox_Caratula
            // 
            this.textBox_Caratula.Location = new System.Drawing.Point(89, 2);
            this.textBox_Caratula.Multiline = true;
            this.textBox_Caratula.Name = "textBox_Caratula";
            this.textBox_Caratula.Size = new System.Drawing.Size(265, 20);
            this.textBox_Caratula.TabIndex = 4;
            this.textBox_Caratula.TextChanged += new System.EventHandler(this.textBox_Caratula_TextChanged);
            // 
            // textBox_Victima
            // 
            this.textBox_Victima.Location = new System.Drawing.Point(128, 3);
            this.textBox_Victima.Name = "textBox_Victima";
            this.textBox_Victima.Size = new System.Drawing.Size(265, 20);
            this.textBox_Victima.TabIndex = 5;
            this.textBox_Victima.TextChanged += new System.EventHandler(this.textBox_Victima_TextChanged);
            // 
            // textBox_Imputado
            // 
            this.textBox_Imputado.Location = new System.Drawing.Point(125, 3);
            this.textBox_Imputado.Name = "textBox_Imputado";
            this.textBox_Imputado.Size = new System.Drawing.Size(265, 20);
            this.textBox_Imputado.TabIndex = 6;
            this.textBox_Imputado.TextChanged += new System.EventHandler(this.textBox_Imputado_TextChanged);
            // 
            // comboBox_Ufid
            // 
            this.comboBox_Ufid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Ufid.FormattingEnabled = true;
            this.comboBox_Ufid.Items.AddRange(new object[] {
            "04",
            "05",
            "08"});
            this.comboBox_Ufid.Location = new System.Drawing.Point(116, 1);
            this.comboBox_Ufid.Name = "comboBox_Ufid";
            this.comboBox_Ufid.Size = new System.Drawing.Size(78, 24);
            this.comboBox_Ufid.TabIndex = 7;
            // 
            // comboBox_Instructor
            // 
            this.comboBox_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Instructor.FormattingEnabled = true;
            this.comboBox_Instructor.Items.AddRange(new object[] {
            "Comisario Miguel Moreno",
            "subcomisario Melisa Perea Peña",
            "Comisario Arias"});
            this.comboBox_Instructor.Location = new System.Drawing.Point(116, 94);
            this.comboBox_Instructor.Name = "comboBox_Instructor";
            this.comboBox_Instructor.Size = new System.Drawing.Size(281, 24);
            this.comboBox_Instructor.TabIndex = 11;
            // 
            // comboBox_Secretario
            // 
            this.comboBox_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Secretario.FormattingEnabled = true;
            this.comboBox_Secretario.Items.AddRange(new object[] {
            "Oficial Ayudante Jorge A. Bonato",
            "Oficial Subayudante Ariel Vasquez",
            "Oficial Subinspector Martin Ali Bonato",
            "Sargento Nerea Sandoval",
            "Sargento Eleana Dirocco"});
            this.comboBox_Secretario.Location = new System.Drawing.Point(116, 123);
            this.comboBox_Secretario.Name = "comboBox_Secretario";
            this.comboBox_Secretario.Size = new System.Drawing.Size(281, 24);
            this.comboBox_Secretario.TabIndex = 12;
            // 
            // comboBox_Dependencia
            // 
            this.comboBox_Dependencia.FormattingEnabled = true;
            this.comboBox_Dependencia.Items.AddRange(new object[] {
            "EPC I PINAMAR",
            "EPC II OSTENDE",
            "EPC III VALERIA DEL MAR",
            "EPC IV CARILÓ"});
            this.comboBox_Dependencia.Location = new System.Drawing.Point(116, 152);
            this.comboBox_Dependencia.Name = "comboBox_Dependencia";
            this.comboBox_Dependencia.Size = new System.Drawing.Size(281, 21);
            this.comboBox_Dependencia.TabIndex = 13;
            // 
            // comboBox_Dr
            // 
            this.comboBox_Dr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Dr.FormattingEnabled = true;
            this.comboBox_Dr.Items.AddRange(new object[] {
            "Calderón Pablo",
            "Mercuri Walter",
            "Zamboni Veronica"});
            this.comboBox_Dr.Location = new System.Drawing.Point(235, 2);
            this.comboBox_Dr.Name = "comboBox_Dr";
            this.comboBox_Dr.Size = new System.Drawing.Size(162, 24);
            this.comboBox_Dr.TabIndex = 8;
            // 
            // comboBox_Ipp1
            // 
            this.comboBox_Ipp1.FormattingEnabled = true;
            this.comboBox_Ipp1.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09"});
            this.comboBox_Ipp1.Location = new System.Drawing.Point(135, 43);
            this.comboBox_Ipp1.MaxDropDownItems = 10;
            this.comboBox_Ipp1.MaxLength = 2;
            this.comboBox_Ipp1.Name = "comboBox_Ipp1";
            this.comboBox_Ipp1.Size = new System.Drawing.Size(45, 21);
            this.comboBox_Ipp1.TabIndex = 0;
            this.comboBox_Ipp1.TextUpdate += new System.EventHandler(this.comboBox_Ipp1_TextUpdate);
            // 
            // comboBox_Ipp2
            // 
            this.comboBox_Ipp2.FormattingEnabled = true;
            this.comboBox_Ipp2.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09"});
            this.comboBox_Ipp2.Location = new System.Drawing.Point(184, 43);
            this.comboBox_Ipp2.Name = "comboBox_Ipp2";
            this.comboBox_Ipp2.Size = new System.Drawing.Size(45, 21);
            this.comboBox_Ipp2.TabIndex = 1;
            this.comboBox_Ipp2.TextUpdate += new System.EventHandler(this.comboBox_Ipp2_TextUpdate);
            // 
            // lbl_00
            // 
            this.lbl_00.AutoSize = true;
            this.lbl_00.Location = new System.Drawing.Point(390, 48);
            this.lbl_00.Name = "lbl_00";
            this.lbl_00.Size = new System.Drawing.Size(24, 13);
            this.lbl_00.TabIndex = 26;
            this.lbl_00.Text = "/00";
            // 
            // comboBox_Ipp4
            // 
            this.comboBox_Ipp4.FormattingEnabled = true;
            this.comboBox_Ipp4.Items.AddRange(new object[] {
            "24",
            "25",
            "26"});
            this.comboBox_Ipp4.Location = new System.Drawing.Point(336, 43);
            this.comboBox_Ipp4.Name = "comboBox_Ipp4";
            this.comboBox_Ipp4.Size = new System.Drawing.Size(51, 21);
            this.comboBox_Ipp4.TabIndex = 3;
            this.comboBox_Ipp4.TextUpdate += new System.EventHandler(this.comboBox_Ipp4_TextUpdate);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(16, 229);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 67);
            this.btn_Buscar.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btn_Buscar, "Buscar archivos guardados");
            this.btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(116, 229);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btn_Guardar, "Guardar ");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(215, 229);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btn_Limpiar, "Limpiar formulario");
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Imprimir.Image")));
            this.btn_Imprimir.Location = new System.Drawing.Point(314, 221);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(93, 83);
            this.btn_Imprimir.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btn_Imprimir, "Guardar e IMPRIMIR");
            this.btn_Imprimir.UseVisualStyleBackColor = false;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // btn_AgregarCausa
            // 
            this.btn_AgregarCausa.BackColor = System.Drawing.Color.White;
            this.btn_AgregarCausa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarCausa.FlatAppearance.BorderSize = 3;
            this.btn_AgregarCausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarCausa.Location = new System.Drawing.Point(356, 1);
            this.btn_AgregarCausa.Name = "btn_AgregarCausa";
            this.btn_AgregarCausa.Size = new System.Drawing.Size(15, 23);
            this.btn_AgregarCausa.TabIndex = 27;
            this.btn_AgregarCausa.Text = "+";
            this.toolTip1.SetToolTip(this.btn_AgregarCausa, "Agregar una caratula adicional");
            this.btn_AgregarCausa.UseVisualStyleBackColor = false;
            this.btn_AgregarCausa.Click += new System.EventHandler(this.btn_AgregarCausa_Click);
            // 
            // btn_AgregarVictima
            // 
            this.btn_AgregarVictima.BackColor = System.Drawing.Color.White;
            this.btn_AgregarVictima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarVictima.FlatAppearance.BorderSize = 0;
            this.btn_AgregarVictima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarVictima.Location = new System.Drawing.Point(395, 1);
            this.btn_AgregarVictima.Name = "btn_AgregarVictima";
            this.btn_AgregarVictima.Size = new System.Drawing.Size(15, 23);
            this.btn_AgregarVictima.TabIndex = 28;
            this.btn_AgregarVictima.Text = "+";
            this.toolTip1.SetToolTip(this.btn_AgregarVictima, "Agregar victima");
            this.btn_AgregarVictima.UseVisualStyleBackColor = false;
            this.btn_AgregarVictima.Click += new System.EventHandler(this.btn_AgregarVictima_Click);
            // 
            // btn_AgregarImputado
            // 
            this.btn_AgregarImputado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarImputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarImputado.Location = new System.Drawing.Point(392, 1);
            this.btn_AgregarImputado.Name = "btn_AgregarImputado";
            this.btn_AgregarImputado.Size = new System.Drawing.Size(15, 23);
            this.btn_AgregarImputado.TabIndex = 29;
            this.btn_AgregarImputado.Text = "+";
            this.toolTip1.SetToolTip(this.btn_AgregarImputado, "Agregar imputado");
            this.btn_AgregarImputado.UseVisualStyleBackColor = true;
            this.btn_AgregarImputado.Click += new System.EventHandler(this.btn_AgregarImputado_Click);
            // 
            // btn_AgregarDatosImputado
            // 
            this.btn_AgregarDatosImputado.Image = ((System.Drawing.Image)(resources.GetObject("btn_AgregarDatosImputado.Image")));
            this.btn_AgregarDatosImputado.Location = new System.Drawing.Point(0, 1);
            this.btn_AgregarDatosImputado.Name = "btn_AgregarDatosImputado";
            this.btn_AgregarDatosImputado.Size = new System.Drawing.Size(27, 23);
            this.btn_AgregarDatosImputado.TabIndex = 38;
            this.btn_AgregarDatosImputado.Text = "+";
            this.toolTip1.SetToolTip(this.btn_AgregarDatosImputado, "Agregar datos personales de Imputado");
            this.btn_AgregarDatosImputado.UseVisualStyleBackColor = true;
            this.btn_AgregarDatosImputado.Click += new System.EventHandler(this.btn_AgregarDatosImputado_Click);
            // 
            // btn_AgregarDatosVictima
            // 
            this.btn_AgregarDatosVictima.Image = ((System.Drawing.Image)(resources.GetObject("btn_AgregarDatosVictima.Image")));
            this.btn_AgregarDatosVictima.Location = new System.Drawing.Point(3, 0);
            this.btn_AgregarDatosVictima.Name = "btn_AgregarDatosVictima";
            this.btn_AgregarDatosVictima.Size = new System.Drawing.Size(27, 23);
            this.btn_AgregarDatosVictima.TabIndex = 39;
            this.btn_AgregarDatosVictima.Text = "+";
            this.toolTip1.SetToolTip(this.btn_AgregarDatosVictima, "Agregar datos personales de Victima");
            this.btn_AgregarDatosVictima.UseVisualStyleBackColor = true;
            this.btn_AgregarDatosVictima.Click += new System.EventHandler(this.btn_AgregarDatosVictima_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 0);
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.panel_Caratula);
            this.panel1.Controls.Add(this.panel_ControlesInferiores);
            this.panel1.Controls.Add(this.panel_Imputado);
            this.panel1.Controls.Add(this.panel_Victima);
            this.panel1.Controls.Add(this.progressVerticalBar1);
            this.panel1.Controls.Add(this.textBox_NumeroIpp);
            this.panel1.Controls.Add(this.lbl_Ipp);
            this.panel1.Controls.Add(this.progressVerticalBar2);
            this.panel1.Controls.Add(this.comboBox_Ipp4);
            this.panel1.Controls.Add(this.lbl_00);
            this.panel1.Controls.Add(this.comboBox_Ipp2);
            this.panel1.Controls.Add(this.comboBox_Ipp1);
            this.panel1.Location = new System.Drawing.Point(20, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 482);
            this.panel1.TabIndex = 30;
            this.panel1.TabStop = true;
            // 
            // panel_Caratula
            // 
            this.panel_Caratula.AutoSize = true;
            this.panel_Caratula.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_Caratula.BackColor = System.Drawing.Color.Yellow;
            this.panel_Caratula.Controls.Add(this.textBox_Caratula);
            this.panel_Caratula.Controls.Add(this.lbl_Caratula);
            this.panel_Caratula.Controls.Add(this.btn_AgregarCausa);
            this.panel_Caratula.Location = new System.Drawing.Point(46, 74);
            this.panel_Caratula.Name = "panel_Caratula";
            this.panel_Caratula.Size = new System.Drawing.Size(374, 27);
            this.panel_Caratula.TabIndex = 43;
            // 
            // panel_ControlesInferiores
            // 
            this.panel_ControlesInferiores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel_ControlesInferiores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel_ControlesInferiores.Controls.Add(this.btn_Imprimir);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_Secretario);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_Instructor);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Localida);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_Dependencia);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_Localidad);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_Ufid);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Dependencia);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_DeptoJudicial);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_Dr);
            this.panel_ControlesInferiores.Controls.Add(this.comboBox_DeptoJudicial);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Fecha);
            this.panel_ControlesInferiores.Controls.Add(this.timePickerPersonalizado1);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Secretario);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Instructor);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Ufid);
            this.panel_ControlesInferiores.Controls.Add(this.lbl_Dr);
            this.panel_ControlesInferiores.Controls.Add(this.btn_Buscar);
            this.panel_ControlesInferiores.Controls.Add(this.btn_Guardar);
            this.panel_ControlesInferiores.Controls.Add(this.btn_Limpiar);
            this.panel_ControlesInferiores.Location = new System.Drawing.Point(20, 161);
            this.panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            this.panel_ControlesInferiores.Size = new System.Drawing.Size(410, 321);
            this.panel_ControlesInferiores.TabIndex = 42;
            // 
            // lbl_Localida
            // 
            this.lbl_Localida.AutoSize = true;
            this.lbl_Localida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Localida.Location = new System.Drawing.Point(34, 36);
            this.lbl_Localida.Name = "lbl_Localida";
            this.lbl_Localida.Size = new System.Drawing.Size(70, 15);
            this.lbl_Localida.TabIndex = 37;
            this.lbl_Localida.Text = "Localidad";
            // 
            // comboBox_Localidad
            // 
            this.comboBox_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Localidad.FormattingEnabled = true;
            this.comboBox_Localidad.Items.AddRange(new object[] {
            "PINAMAR",
            "VILLA GESELL",
            "GRAL. MADARIAGA"});
            this.comboBox_Localidad.Location = new System.Drawing.Point(116, 33);
            this.comboBox_Localidad.Name = "comboBox_Localidad";
            this.comboBox_Localidad.Size = new System.Drawing.Size(280, 24);
            this.comboBox_Localidad.TabIndex = 9;
            // 
            // lbl_DeptoJudicial
            // 
            this.lbl_DeptoJudicial.AutoSize = true;
            this.lbl_DeptoJudicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DeptoJudicial.Location = new System.Drawing.Point(1, 66);
            this.lbl_DeptoJudicial.Name = "lbl_DeptoJudicial";
            this.lbl_DeptoJudicial.Size = new System.Drawing.Size(103, 15);
            this.lbl_DeptoJudicial.TabIndex = 35;
            this.lbl_DeptoJudicial.Text = "Depto. Judicial";
            // 
            // comboBox_DeptoJudicial
            // 
            this.comboBox_DeptoJudicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_DeptoJudicial.FormattingEnabled = true;
            this.comboBox_DeptoJudicial.Items.AddRange(new object[] {
            "DOLORES"});
            this.comboBox_DeptoJudicial.Location = new System.Drawing.Point(116, 63);
            this.comboBox_DeptoJudicial.Name = "comboBox_DeptoJudicial";
            this.comboBox_DeptoJudicial.Size = new System.Drawing.Size(281, 24);
            this.comboBox_DeptoJudicial.TabIndex = 10;
            // 
            // timePickerPersonalizado1
            // 
            this.timePickerPersonalizado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.timePickerPersonalizado1.Location = new System.Drawing.Point(116, 179);
            this.timePickerPersonalizado1.Name = "timePickerPersonalizado1";
            this.timePickerPersonalizado1.SelectedDate = new System.DateTime(2024, 7, 16, 18, 52, 0, 926);
            this.timePickerPersonalizado1.Size = new System.Drawing.Size(281, 24);
            this.timePickerPersonalizado1.TabIndex = 14;
            // 
            // panel_Imputado
            // 
            this.panel_Imputado.AutoSize = true;
            this.panel_Imputado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_Imputado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel_Imputado.Controls.Add(this.textBox_Imputado);
            this.panel_Imputado.Controls.Add(this.lbl_Imputado);
            this.panel_Imputado.Controls.Add(this.btn_AgregarDatosImputado);
            this.panel_Imputado.Controls.Add(this.btn_AgregarImputado);
            this.panel_Imputado.Location = new System.Drawing.Point(10, 132);
            this.panel_Imputado.Name = "panel_Imputado";
            this.panel_Imputado.Size = new System.Drawing.Size(410, 27);
            this.panel_Imputado.TabIndex = 41;
            // 
            // panel_Victima
            // 
            this.panel_Victima.AutoSize = true;
            this.panel_Victima.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_Victima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel_Victima.Controls.Add(this.textBox_Victima);
            this.panel_Victima.Controls.Add(this.btn_AgregarDatosVictima);
            this.panel_Victima.Controls.Add(this.lbl_Victima);
            this.panel_Victima.Controls.Add(this.btn_AgregarVictima);
            this.panel_Victima.Location = new System.Drawing.Point(7, 102);
            this.panel_Victima.Name = "panel_Victima";
            this.panel_Victima.Size = new System.Drawing.Size(413, 27);
            this.panel_Victima.TabIndex = 40;
            // 
            // progressVerticalBar1
            // 
            this.progressVerticalBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.progressVerticalBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.progressVerticalBar1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.progressVerticalBar1.Location = new System.Drawing.Point(450, 44);
            this.progressVerticalBar1.Name = "progressVerticalBar1";
            this.progressVerticalBar1.Size = new System.Drawing.Size(4, 413);
            this.progressVerticalBar1.TabIndex = 33;
            // 
            // progressVerticalBar2
            // 
            this.progressVerticalBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.progressVerticalBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.progressVerticalBar2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.progressVerticalBar2.Location = new System.Drawing.Point(-175, 19);
            this.progressVerticalBar2.Name = "progressVerticalBar2";
            this.progressVerticalBar2.Size = new System.Drawing.Size(4, 381);
            this.progressVerticalBar2.TabIndex = 32;
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Titulo.Location = new System.Drawing.Point(43, 29);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbl_Titulo.Size = new System.Drawing.Size(411, 24);
            this.lbl_Titulo.TabIndex = 31;
            this.lbl_Titulo.Text = "CARATULA-INICIO-CIERRE-ELEVACION";
            // 
            // InicioCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(500, 559);
            this.Controls.Add(this.lbl_Titulo);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 598);
            this.Name = "InicioCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO - CIERRE";
            this.Load += new System.EventHandler(this.InicioCierre_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InicioCierre_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lbl_Titulo, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Caratula.ResumeLayout(false);
            this.panel_Caratula.PerformLayout();
            this.panel_ControlesInferiores.ResumeLayout(false);
            this.panel_ControlesInferiores.PerformLayout();
            this.panel_Imputado.ResumeLayout(false);
            this.panel_Imputado.PerformLayout();
            this.panel_Victima.ResumeLayout(false);
            this.panel_Victima.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Dr;
        private System.Windows.Forms.TextBox textBox_NumeroIpp;
        private System.Windows.Forms.Label lbl_Ipp;
        private System.Windows.Forms.Label lbl_Caratula;
        private System.Windows.Forms.Label lbl_Victima;
        private System.Windows.Forms.Label lbl_Imputado;
        private System.Windows.Forms.Label lbl_Ufid;
        private System.Windows.Forms.Label lbl_Instructor;
        private System.Windows.Forms.Label lbl_Secretario;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.Label lbl_Dependencia;
        private System.Windows.Forms.TextBox textBox_Caratula;
        private System.Windows.Forms.TextBox textBox_Victima;
        private System.Windows.Forms.TextBox textBox_Imputado;
        private System.Windows.Forms.ComboBox comboBox_Ufid;
        private System.Windows.Forms.ComboBox comboBox_Instructor;
        private System.Windows.Forms.ComboBox comboBox_Secretario;
        private System.Windows.Forms.ComboBox comboBox_Dependencia;
        private System.Windows.Forms.ComboBox comboBox_Dr;
        private System.Windows.Forms.ComboBox comboBox_Ipp1;
        private System.Windows.Forms.ComboBox comboBox_Ipp2;
        private System.Windows.Forms.Label lbl_00;
        private System.Windows.Forms.ComboBox comboBox_Ipp4;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_AgregarCausa;
        private System.Windows.Forms.Button btn_AgregarVictima;
        private System.Windows.Forms.Button btn_AgregarImputado;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Titulo;
        private ProgressVerticalBar progressVerticalBar2;
        private ProgressVerticalBar progressVerticalBar1;
        private general.clases.Apariencia_General.TimePickerPersonalizado timePickerPersonalizado1;
        private System.Windows.Forms.Label lbl_DeptoJudicial;
        private System.Windows.Forms.ComboBox comboBox_DeptoJudicial;
        private System.Windows.Forms.Label lbl_Localida;
        private System.Windows.Forms.ComboBox comboBox_Localidad;
        private System.Windows.Forms.Button btn_AgregarDatosVictima;
        private System.Windows.Forms.Button btn_AgregarDatosImputado;
        private System.Windows.Forms.Panel panel_Victima;
        private System.Windows.Forms.Panel panel_Imputado;
        private System.Windows.Forms.Panel panel_ControlesInferiores;
        private System.Windows.Forms.Panel panel_Caratula;
    }
}