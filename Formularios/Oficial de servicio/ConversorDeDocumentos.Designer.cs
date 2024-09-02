namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class ConversorDeDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversorDeDocumentos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Convertir = new System.Windows.Forms.Button();
            this.groupBox_ConversorDocumentos = new System.Windows.Forms.GroupBox();
            this.radioButton_Word = new System.Windows.Forms.RadioButton();
            this.radioButton_Pdf = new System.Windows.Forms.RadioButton();
            this.pictureBox_Word = new System.Windows.Forms.PictureBox();
            this.pictureBox_Pdf = new System.Windows.Forms.PictureBox();
            this.label_SelloEscalera = new System.Windows.Forms.Label();
            this.label_SelloMedalla = new System.Windows.Forms.Label();
            this.label_SellosDependencia = new System.Windows.Forms.Label();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox_ConversorDocumentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Word)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Pdf)).BeginInit();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 9, 2, 17, 44, 51, 660);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.btn_Imprimir);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.btn_Convertir);
            this.panel1.Controls.Add(this.groupBox_ConversorDocumentos);
            this.panel1.Controls.Add(this.label_SellosDependencia);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 491);
            this.panel1.TabIndex = 2;
            // 
            // btn_Convertir
            // 
            this.btn_Convertir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Convertir.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Convertir.FlatAppearance.BorderSize = 2;
            this.btn_Convertir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Convertir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Convertir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Convertir.Font = new System.Drawing.Font("Castellar", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Convertir.Location = new System.Drawing.Point(299, 325);
            this.btn_Convertir.Name = "btn_Convertir";
            this.btn_Convertir.Size = new System.Drawing.Size(117, 29);
            this.btn_Convertir.TabIndex = 82;
            this.btn_Convertir.Text = "CONVERTIR";
            this.btn_Convertir.UseVisualStyleBackColor = true;
            // 
            // groupBox_ConversorDocumentos
            // 
            this.groupBox_ConversorDocumentos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_ConversorDocumentos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_ConversorDocumentos.Controls.Add(this.radioButton_Word);
            this.groupBox_ConversorDocumentos.Controls.Add(this.radioButton_Pdf);
            this.groupBox_ConversorDocumentos.Controls.Add(this.pictureBox_Word);
            this.groupBox_ConversorDocumentos.Controls.Add(this.pictureBox_Pdf);
            this.groupBox_ConversorDocumentos.Controls.Add(this.label_SelloEscalera);
            this.groupBox_ConversorDocumentos.Controls.Add(this.label_SelloMedalla);
            this.groupBox_ConversorDocumentos.Location = new System.Drawing.Point(151, 70);
            this.groupBox_ConversorDocumentos.Name = "groupBox_ConversorDocumentos";
            this.groupBox_ConversorDocumentos.Size = new System.Drawing.Size(422, 262);
            this.groupBox_ConversorDocumentos.TabIndex = 81;
            this.groupBox_ConversorDocumentos.TabStop = false;
            // 
            // radioButton_Word
            // 
            this.radioButton_Word.AutoSize = true;
            this.radioButton_Word.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_Word.Location = new System.Drawing.Point(393, 17);
            this.radioButton_Word.Name = "radioButton_Word";
            this.radioButton_Word.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Word.TabIndex = 45;
            this.radioButton_Word.TabStop = true;
            this.radioButton_Word.UseVisualStyleBackColor = true;
            // 
            // radioButton_Pdf
            // 
            this.radioButton_Pdf.AutoSize = true;
            this.radioButton_Pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_Pdf.Location = new System.Drawing.Point(179, 15);
            this.radioButton_Pdf.Name = "radioButton_Pdf";
            this.radioButton_Pdf.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Pdf.TabIndex = 44;
            this.radioButton_Pdf.TabStop = true;
            this.radioButton_Pdf.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Word
            // 
            this.pictureBox_Word.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_Word.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Word.BackgroundImage")));
            this.pictureBox_Word.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Word.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Word.Location = new System.Drawing.Point(242, 36);
            this.pictureBox_Word.Name = "pictureBox_Word";
            this.pictureBox_Word.Size = new System.Drawing.Size(151, 213);
            this.pictureBox_Word.TabIndex = 43;
            this.pictureBox_Word.TabStop = false;
            // 
            // pictureBox_Pdf
            // 
            this.pictureBox_Pdf.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_Pdf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Pdf.BackgroundImage")));
            this.pictureBox_Pdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Pdf.Location = new System.Drawing.Point(30, 36);
            this.pictureBox_Pdf.Name = "pictureBox_Pdf";
            this.pictureBox_Pdf.Size = new System.Drawing.Size(151, 213);
            this.pictureBox_Pdf.TabIndex = 42;
            this.pictureBox_Pdf.TabStop = false;
            // 
            // label_SelloEscalera
            // 
            this.label_SelloEscalera.AutoSize = true;
            this.label_SelloEscalera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelloEscalera.Location = new System.Drawing.Point(239, 15);
            this.label_SelloEscalera.Name = "label_SelloEscalera";
            this.label_SelloEscalera.Size = new System.Drawing.Size(148, 16);
            this.label_SelloEscalera.TabIndex = 41;
            this.label_SelloEscalera.Text = "COVERTIR a WORD";
            // 
            // label_SelloMedalla
            // 
            this.label_SelloMedalla.AutoSize = true;
            this.label_SelloMedalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelloMedalla.Location = new System.Drawing.Point(27, 13);
            this.label_SelloMedalla.Name = "label_SelloMedalla";
            this.label_SelloMedalla.Size = new System.Drawing.Size(146, 16);
            this.label_SelloMedalla.TabIndex = 40;
            this.label_SelloMedalla.Text = "CONVERTIR  a PDF";
            // 
            // label_SellosDependencia
            // 
            this.label_SellosDependencia.AutoSize = true;
            this.label_SellosDependencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_SellosDependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SellosDependencia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_SellosDependencia.Location = new System.Drawing.Point(177, 0);
            this.label_SellosDependencia.Name = "label_SellosDependencia";
            this.label_SellosDependencia.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_SellosDependencia.Size = new System.Drawing.Size(386, 30);
            this.label_SellosDependencia.TabIndex = 1;
            this.label_SellosDependencia.Text = "CONVERSOR DE DOCUMENTOS";
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Imprimir.Image")));
            this.btn_Imprimir.Location = new System.Drawing.Point(537, 377);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(122, 93);
            this.btn_Imprimir.TabIndex = 90;
            this.btn_Imprimir.UseVisualStyleBackColor = false;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(389, 386);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 89;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(223, 386);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 88;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(60, 386);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 67);
            this.btn_Buscar.TabIndex = 87;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // ConversorDeDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 548);
            this.Controls.Add(this.panel1);
            this.Name = "ConversorDeDocumentos";
            this.Text = "ConversorDeDocumentos";
            this.Load += new System.EventHandler(this.ConversorDeDocumentos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_ConversorDocumentos.ResumeLayout(false);
            this.groupBox_ConversorDocumentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Word)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Pdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_SellosDependencia;
        private System.Windows.Forms.GroupBox groupBox_ConversorDocumentos;
        private System.Windows.Forms.RadioButton radioButton_Word;
        private System.Windows.Forms.RadioButton radioButton_Pdf;
        private System.Windows.Forms.PictureBox pictureBox_Word;
        private System.Windows.Forms.PictureBox pictureBox_Pdf;
        private System.Windows.Forms.Label label_SelloEscalera;
        private System.Windows.Forms.Label label_SelloMedalla;
        private System.Windows.Forms.Button btn_Convertir;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Buscar;
    }
}