namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    partial class SellosDependencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellosDependencia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Localidad = new Ofelia_Sara.Controles.General.CustomTextBox();
            this.label_Localidad = new System.Windows.Forms.Label();
            this.comboBox_Dependencia = new Ofelia_Sara.Controles.General.CustomComboBox();
            this.label_Dependencia = new System.Windows.Forms.Label();
            this.pictureBox_SelloFoliador = new System.Windows.Forms.PictureBox();
            this.pictureBox_SelloEscalera = new System.Windows.Forms.PictureBox();
            this.pictureBox_SelloMedalla = new System.Windows.Forms.PictureBox();
            this.label_SelloFoliador = new System.Windows.Forms.Label();
            this.label_SelloEscalera = new System.Windows.Forms.Label();
            this.label_SelloMedalla = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.label_SellosDependencia = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelloFoliador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelloEscalera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelloMedalla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.textBox_Localidad);
            this.panel1.Controls.Add(this.label_Localidad);
            this.panel1.Controls.Add(this.comboBox_Dependencia);
            this.panel1.Controls.Add(this.label_Dependencia);
            this.panel1.Controls.Add(this.pictureBox_SelloFoliador);
            this.panel1.Controls.Add(this.pictureBox_SelloEscalera);
            this.panel1.Controls.Add(this.pictureBox_SelloMedalla);
            this.panel1.Controls.Add(this.label_SelloFoliador);
            this.panel1.Controls.Add(this.label_SelloEscalera);
            this.panel1.Controls.Add(this.label_SelloMedalla);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.label_SellosDependencia);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 483);
            this.panel1.TabIndex = 0;
            // 
            // textBox_Localidad
            // 
            this.textBox_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Localidad.Location = new System.Drawing.Point(146, 82);
            this.textBox_Localidad.Name = "textBox_Localidad";
            this.textBox_Localidad.Size = new System.Drawing.Size(355, 24);
            this.textBox_Localidad.TabIndex = 46;
            // 
            // label_Localidad
            // 
            this.label_Localidad.AutoSize = true;
            this.label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Localidad.Location = new System.Drawing.Point(49, 87);
            this.label_Localidad.Name = "label_Localidad";
            this.label_Localidad.Size = new System.Drawing.Size(98, 16);
            this.label_Localidad.TabIndex = 44;
            this.label_Localidad.Text = "LOCALIDAD :";
            // 
            // comboBox_Dependencia
            // 
            this.comboBox_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            this.comboBox_Dependencia.Location = new System.Drawing.Point(146, 47);
            this.comboBox_Dependencia.Name = "comboBox_Dependencia";
            this.comboBox_Dependencia.Size = new System.Drawing.Size(355, 26);
            this.comboBox_Dependencia.TabIndex = 43;
            this.comboBox_Dependencia.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Dependencia_SelectedIndexChanged);
            this.comboBox_Dependencia.TextChanged += new System.EventHandler(this.ComboBox_Dependencia_TextChanged);
            // 
            // label_Dependencia
            // 
            this.label_Dependencia.AutoSize = true;
            this.label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dependencia.Location = new System.Drawing.Point(24, 50);
            this.label_Dependencia.Name = "label_Dependencia";
            this.label_Dependencia.Size = new System.Drawing.Size(123, 16);
            this.label_Dependencia.TabIndex = 41;
            this.label_Dependencia.Text = "DEPENDENCIA :";
            // 
            // pictureBox_SelloFoliador
            // 
            this.pictureBox_SelloFoliador.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_SelloFoliador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_SelloFoliador.BackgroundImage")));
            this.pictureBox_SelloFoliador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_SelloFoliador.Location = new System.Drawing.Point(352, 126);
            this.pictureBox_SelloFoliador.Name = "pictureBox_SelloFoliador";
            this.pictureBox_SelloFoliador.Size = new System.Drawing.Size(151, 213);
            this.pictureBox_SelloFoliador.TabIndex = 40;
            this.pictureBox_SelloFoliador.TabStop = false;
            this.pictureBox_SelloFoliador.Click += new System.EventHandler(this.PictureBox_Click);
            this.pictureBox_SelloFoliador.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.pictureBox_SelloFoliador.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            this.pictureBox_SelloFoliador.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // pictureBox_SelloEscalera
            // 
            this.pictureBox_SelloEscalera.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_SelloEscalera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_SelloEscalera.BackgroundImage")));
            this.pictureBox_SelloEscalera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_SelloEscalera.Location = new System.Drawing.Point(187, 126);
            this.pictureBox_SelloEscalera.Name = "pictureBox_SelloEscalera";
            this.pictureBox_SelloEscalera.Size = new System.Drawing.Size(151, 213);
            this.pictureBox_SelloEscalera.TabIndex = 39;
            this.pictureBox_SelloEscalera.TabStop = false;
            this.pictureBox_SelloEscalera.Click += new System.EventHandler(this.PictureBox_Click);
            this.pictureBox_SelloEscalera.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.pictureBox_SelloEscalera.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            this.pictureBox_SelloEscalera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // pictureBox_SelloMedalla
            // 
            this.pictureBox_SelloMedalla.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_SelloMedalla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_SelloMedalla.BackgroundImage")));
            this.pictureBox_SelloMedalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_SelloMedalla.Location = new System.Drawing.Point(23, 126);
            this.pictureBox_SelloMedalla.Name = "pictureBox_SelloMedalla";
            this.pictureBox_SelloMedalla.Size = new System.Drawing.Size(151, 213);
            this.pictureBox_SelloMedalla.TabIndex = 38;
            this.pictureBox_SelloMedalla.TabStop = false;
            this.pictureBox_SelloMedalla.Click += new System.EventHandler(this.PictureBox_Click);
            this.pictureBox_SelloMedalla.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.pictureBox_SelloMedalla.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            this.pictureBox_SelloMedalla.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // label_SelloFoliador
            // 
            this.label_SelloFoliador.AutoSize = true;
            this.label_SelloFoliador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelloFoliador.Location = new System.Drawing.Point(362, 351);
            this.label_SelloFoliador.Name = "label_SelloFoliador";
            this.label_SelloFoliador.Size = new System.Drawing.Size(137, 16);
            this.label_SelloFoliador.TabIndex = 3;
            this.label_SelloFoliador.Text = "SELLO FOLIADOR ";
            // 
            // label_SelloEscalera
            // 
            this.label_SelloEscalera.AutoSize = true;
            this.label_SelloEscalera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelloEscalera.Location = new System.Drawing.Point(195, 351);
            this.label_SelloEscalera.Name = "label_SelloEscalera";
            this.label_SelloEscalera.Size = new System.Drawing.Size(141, 16);
            this.label_SelloEscalera.TabIndex = 2;
            this.label_SelloEscalera.Text = "SELLO ESCALERA ";
            // 
            // label_SelloMedalla
            // 
            this.label_SelloMedalla.AutoSize = true;
            this.label_SelloMedalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelloMedalla.Location = new System.Drawing.Point(36, 351);
            this.label_SelloMedalla.Name = "label_SelloMedalla";
            this.label_SelloMedalla.Size = new System.Drawing.Size(135, 16);
            this.label_SelloMedalla.TabIndex = 1;
            this.label_SelloMedalla.Text = "SELLO MEDALLA  ";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(127, 400);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 5;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(345, 400);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 4;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // label_SellosDependencia
            // 
            this.label_SellosDependencia.AutoSize = true;
            this.label_SellosDependencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_SellosDependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SellosDependencia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_SellosDependencia.Location = new System.Drawing.Point(74, 0);
            this.label_SellosDependencia.Name = "label_SellosDependencia";
            this.label_SellosDependencia.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_SellosDependencia.Size = new System.Drawing.Size(377, 30);
            this.label_SellosDependencia.TabIndex = 0;
            this.label_SellosDependencia.Text = "SELLOS NUEVA DEPENDENCIA";
            // 
            // SellosDependencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 535);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellosDependencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELLOS DE NUEVA DEPENDENCIA";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SellosDependencia_HelpButtonClicked);
            this.Load += new System.EventHandler(this.SellosDependencia_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelloFoliador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelloEscalera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelloMedalla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_SellosDependencia;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Label label_SelloFoliador;
        private System.Windows.Forms.Label label_SelloEscalera;
        private System.Windows.Forms.Label label_SelloMedalla;
        private System.Windows.Forms.PictureBox pictureBox_SelloFoliador;
        private System.Windows.Forms.PictureBox pictureBox_SelloEscalera;
        private System.Windows.Forms.PictureBox pictureBox_SelloMedalla;
        private System.Windows.Forms.Label label_Dependencia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Localidad;
        private System.Windows.Forms.Label label_Localidad;
    }
}