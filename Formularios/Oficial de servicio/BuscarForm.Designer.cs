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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_Secretario = new System.Windows.Forms.ComboBox();
            this.comboBox_Instructor = new System.Windows.Forms.ComboBox();
            this.comboBox_Dependencia = new System.Windows.Forms.ComboBox();
            this.label_00 = new System.Windows.Forms.Label();
            this.comboBox_Ipp4 = new System.Windows.Forms.ComboBox();
            this.comboBox_Ipp2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Ipp1 = new System.Windows.Forms.ComboBox();
            this.label_Caratula = new System.Windows.Forms.Label();
            this.textBox_Caratula = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.label_Fecha = new System.Windows.Forms.Label();
            this.label_Secretario = new System.Windows.Forms.Label();
            this.label_Instructor = new System.Windows.Forms.Label();
            this.label_Dependencia = new System.Windows.Forms.Label();
            this.label_Imputado = new System.Windows.Forms.Label();
            this.label_Victima = new System.Windows.Forms.Label();
            this.textBox_NumeroIpp = new System.Windows.Forms.TextBox();
            this.textBox_Imputado = new System.Windows.Forms.TextBox();
            this.textBox_Victima = new System.Windows.Forms.TextBox();
            this.label_Ipp = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Fecha_Actuacion = new Controles_Libreria.Controles.TimePickerPersonalizado();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.Fecha_Actuacion);
            this.panel1.Controls.Add(this.comboBox_Secretario);
            this.panel1.Controls.Add(this.comboBox_Instructor);
            this.panel1.Controls.Add(this.comboBox_Dependencia);
            this.panel1.Controls.Add(this.label_00);
            this.panel1.Controls.Add(this.comboBox_Ipp4);
            this.panel1.Controls.Add(this.comboBox_Ipp2);
            this.panel1.Controls.Add(this.comboBox_Ipp1);
            this.panel1.Controls.Add(this.label_Caratula);
            this.panel1.Controls.Add(this.textBox_Caratula);
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.label_Fecha);
            this.panel1.Controls.Add(this.label_Secretario);
            this.panel1.Controls.Add(this.label_Instructor);
            this.panel1.Controls.Add(this.label_Dependencia);
            this.panel1.Controls.Add(this.label_Imputado);
            this.panel1.Controls.Add(this.label_Victima);
            this.panel1.Controls.Add(this.textBox_NumeroIpp);
            this.panel1.Controls.Add(this.textBox_Imputado);
            this.panel1.Controls.Add(this.textBox_Victima);
            this.panel1.Controls.Add(this.label_Ipp);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 396);
            this.panel1.TabIndex = 2;
            // 
            // comboBox_Secretario
            // 
            this.comboBox_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Secretario.FormattingEnabled = true;
            this.comboBox_Secretario.Location = new System.Drawing.Point(142, 231);
            this.comboBox_Secretario.Name = "comboBox_Secretario";
            this.comboBox_Secretario.Size = new System.Drawing.Size(363, 26);
            this.comboBox_Secretario.TabIndex = 28;
            this.comboBox_Secretario.TextChanged += new System.EventHandler(this.comboBox_Secretario_TextChanged);
            this.comboBox_Secretario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Secretario_KeyPress);
            // 
            // comboBox_Instructor
            // 
            this.comboBox_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Instructor.FormattingEnabled = true;
            this.comboBox_Instructor.Location = new System.Drawing.Point(142, 196);
            this.comboBox_Instructor.Name = "comboBox_Instructor";
            this.comboBox_Instructor.Size = new System.Drawing.Size(363, 26);
            this.comboBox_Instructor.TabIndex = 27;
            this.comboBox_Instructor.TextChanged += new System.EventHandler(this.comboBox_Instructor_TextChanged);
            this.comboBox_Instructor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Instructor_KeyPress);
            // 
            // comboBox_Dependencia
            // 
            this.comboBox_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Dependencia.FormattingEnabled = true;
            this.comboBox_Dependencia.Location = new System.Drawing.Point(142, 161);
            this.comboBox_Dependencia.Name = "comboBox_Dependencia";
            this.comboBox_Dependencia.Size = new System.Drawing.Size(363, 26);
            this.comboBox_Dependencia.TabIndex = 26;
            this.comboBox_Dependencia.TextChanged += new System.EventHandler(this.comboBox_Dependencia_TextChanged);
            this.comboBox_Dependencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Dependencia_KeyPress);
            // 
            // label_00
            // 
            this.label_00.AutoSize = true;
            this.label_00.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_00.Location = new System.Drawing.Point(465, 30);
            this.label_00.Name = "label_00";
            this.label_00.Size = new System.Drawing.Size(28, 16);
            this.label_00.TabIndex = 25;
            this.label_00.Text = "/00";
            // 
            // comboBox_Ipp4
            // 
            this.comboBox_Ipp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Ipp4.FormattingEnabled = true;
            this.comboBox_Ipp4.Items.AddRange(new object[] {
            "24",
            "25",
            "26"});
            this.comboBox_Ipp4.Location = new System.Drawing.Point(402, 24);
            this.comboBox_Ipp4.Name = "comboBox_Ipp4";
            this.comboBox_Ipp4.Size = new System.Drawing.Size(57, 26);
            this.comboBox_Ipp4.TabIndex = 24;
            this.comboBox_Ipp4.TextUpdate += new System.EventHandler(this.comboBox_Ipp4_TextUpdate);
            this.comboBox_Ipp4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Ipp4_KeyPress);
            // 
            // comboBox_Ipp2
            // 
            this.comboBox_Ipp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.comboBox_Ipp2.Location = new System.Drawing.Point(205, 24);
            this.comboBox_Ipp2.Name = "comboBox_Ipp2";
            this.comboBox_Ipp2.Size = new System.Drawing.Size(57, 26);
            this.comboBox_Ipp2.TabIndex = 23;
            this.comboBox_Ipp2.TextUpdate += new System.EventHandler(this.comboBox_Ipp2_TextUpdate);
            this.comboBox_Ipp2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Ipp2_KeyPress);
            // 
            // comboBox_Ipp1
            // 
            this.comboBox_Ipp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.comboBox_Ipp1.Location = new System.Drawing.Point(142, 24);
            this.comboBox_Ipp1.Name = "comboBox_Ipp1";
            this.comboBox_Ipp1.Size = new System.Drawing.Size(57, 26);
            this.comboBox_Ipp1.TabIndex = 3;
            this.comboBox_Ipp1.TextUpdate += new System.EventHandler(this.comboBox_Ipp1_TextUpdate);
            this.comboBox_Ipp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Ipp1_KeyPress);
            // 
            // label_Caratula
            // 
            this.label_Caratula.AutoSize = true;
            this.label_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Caratula.Location = new System.Drawing.Point(47, 64);
            this.label_Caratula.Name = "label_Caratula";
            this.label_Caratula.Size = new System.Drawing.Size(87, 16);
            this.label_Caratula.TabIndex = 22;
            this.label_Caratula.Text = "CARATULA";
            // 
            // textBox_Caratula
            // 
            this.textBox_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Caratula.Location = new System.Drawing.Point(142, 58);
            this.textBox_Caratula.Name = "textBox_Caratula";
            this.textBox_Caratula.Size = new System.Drawing.Size(363, 26);
            this.textBox_Caratula.TabIndex = 1;
            this.textBox_Caratula.TextChanged += new System.EventHandler(this.textBox_Caratula_TextChanged);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(430, 310);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 67);
            this.btn_Buscar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btn_Buscar, "Buscar archivo");
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(142, 310);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btn_Limpiar, "Eliminar busqueda");
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // label_Fecha
            // 
            this.label_Fecha.AutoSize = true;
            this.label_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Fecha.Location = new System.Drawing.Point(77, 267);
            this.label_Fecha.Name = "label_Fecha";
            this.label_Fecha.Size = new System.Drawing.Size(57, 16);
            this.label_Fecha.TabIndex = 11;
            this.label_Fecha.Text = "FECHA";
            // 
            // label_Secretario
            // 
            this.label_Secretario.AutoSize = true;
            this.label_Secretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Secretario.Location = new System.Drawing.Point(30, 236);
            this.label_Secretario.Name = "label_Secretario";
            this.label_Secretario.Size = new System.Drawing.Size(104, 16);
            this.label_Secretario.TabIndex = 10;
            this.label_Secretario.Text = "SECRETARIO";
            // 
            // label_Instructor
            // 
            this.label_Instructor.AutoSize = true;
            this.label_Instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Instructor.Location = new System.Drawing.Point(30, 201);
            this.label_Instructor.Name = "label_Instructor";
            this.label_Instructor.Size = new System.Drawing.Size(106, 16);
            this.label_Instructor.TabIndex = 9;
            this.label_Instructor.Text = "INSTRUCTOR";
            // 
            // label_Dependencia
            // 
            this.label_Dependencia.AutoSize = true;
            this.label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dependencia.Location = new System.Drawing.Point(21, 166);
            this.label_Dependencia.Name = "label_Dependencia";
            this.label_Dependencia.Size = new System.Drawing.Size(115, 16);
            this.label_Dependencia.TabIndex = 8;
            this.label_Dependencia.Text = "DEPENDENCIA";
            // 
            // label_Imputado
            // 
            this.label_Imputado.AutoSize = true;
            this.label_Imputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Imputado.Location = new System.Drawing.Point(50, 132);
            this.label_Imputado.Name = "label_Imputado";
            this.label_Imputado.Size = new System.Drawing.Size(86, 16);
            this.label_Imputado.TabIndex = 7;
            this.label_Imputado.Text = "IMPUTADO";
            // 
            // label_Victima
            // 
            this.label_Victima.AutoSize = true;
            this.label_Victima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Victima.Location = new System.Drawing.Point(69, 98);
            this.label_Victima.Name = "label_Victima";
            this.label_Victima.Size = new System.Drawing.Size(67, 16);
            this.label_Victima.TabIndex = 6;
            this.label_Victima.Text = "VICTIMA";
            // 
            // textBox_NumeroIpp
            // 
            this.textBox_NumeroIpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NumeroIpp.Location = new System.Drawing.Point(268, 24);
            this.textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            this.textBox_NumeroIpp.Size = new System.Drawing.Size(128, 26);
            this.textBox_NumeroIpp.TabIndex = 0;
            this.textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NumeroIpp.TextChanged += new System.EventHandler(this.textBox_NumeroIpp_TextChanged);
            this.textBox_NumeroIpp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NumeroIpp_KeyPress);
            // 
            // textBox_Imputado
            // 
            this.textBox_Imputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Imputado.Location = new System.Drawing.Point(142, 126);
            this.textBox_Imputado.Name = "textBox_Imputado";
            this.textBox_Imputado.Size = new System.Drawing.Size(363, 26);
            this.textBox_Imputado.TabIndex = 3;
            this.textBox_Imputado.TextChanged += new System.EventHandler(this.textBox_Imputado_TextChanged);
            this.textBox_Imputado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Imputado_KeyPress);
            // 
            // textBox_Victima
            // 
            this.textBox_Victima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Victima.Location = new System.Drawing.Point(142, 92);
            this.textBox_Victima.Name = "textBox_Victima";
            this.textBox_Victima.Size = new System.Drawing.Size(363, 26);
            this.textBox_Victima.TabIndex = 2;
            this.textBox_Victima.TextChanged += new System.EventHandler(this.textBox_Victima_TextChanged);
            this.textBox_Victima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Victima_KeyPress);
            // 
            // label_Ipp
            // 
            this.label_Ipp.AutoSize = true;
            this.label_Ipp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ipp.Location = new System.Drawing.Point(93, 29);
            this.label_Ipp.Name = "label_Ipp";
            this.label_Ipp.Size = new System.Drawing.Size(43, 16);
            this.label_Ipp.TabIndex = 0;
            this.label_Ipp.Text = "I.P.P.";
            // 
            // Fecha_Actuacion
            // 
            this.Fecha_Actuacion.Location = new System.Drawing.Point(141, 267);
            this.Fecha_Actuacion.Name = "Fecha_Actuacion";
            this.Fecha_Actuacion.SelectedDate = new System.DateTime(2024, 10, 5, 20, 38, 40, 690);
            this.Fecha_Actuacion.Size = new System.Drawing.Size(364, 27);
            this.Fecha_Actuacion.TabIndex = 29;
            // 
            // BuscarForm
            // 
            this.AcceptButton = this.btn_Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Limpiar;
            this.ClientSize = new System.Drawing.Size(573, 451);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR EN BASE DE DATOS";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.BuscarForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Buscar_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Ipp;
        private System.Windows.Forms.TextBox textBox_NumeroIpp;
        private System.Windows.Forms.TextBox textBox_Imputado;
        private System.Windows.Forms.TextBox textBox_Victima;
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
        private System.Windows.Forms.TextBox textBox_Caratula;
        private System.Windows.Forms.Label label_00;
        private System.Windows.Forms.ComboBox comboBox_Ipp4;
        private System.Windows.Forms.ComboBox comboBox_Ipp2;
        private System.Windows.Forms.ComboBox comboBox_Ipp1;
        private System.Windows.Forms.ComboBox comboBox_Secretario;
        private System.Windows.Forms.ComboBox comboBox_Instructor;
        private System.Windows.Forms.ComboBox comboBox_Dependencia;
        private Controles_Libreria.Controles.TimePickerPersonalizado timePickerPersonalizado1;
        private Controles_Libreria.Controles.TimePickerPersonalizado Fecha_Actuacion;
    }
}