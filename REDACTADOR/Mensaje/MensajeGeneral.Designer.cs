namespace REDACTADOR.Mensaje
{
    partial class MensajeGeneral
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
            this.label_OfeliaSara = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Texto = new System.Windows.Forms.Label();
            this.pictureBox_Icono = new System.Windows.Forms.PictureBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.pictureBox_EscudoPolicial = new System.Windows.Forms.PictureBox();
            this.btn_Si = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EscudoPolicial)).BeginInit();
            this.SuspendLayout();
            // 
            // label_OfeliaSara
            // 
            this.label_OfeliaSara.AutoSize = true;
            this.label_OfeliaSara.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OfeliaSara.Location = new System.Drawing.Point(157, 3);
            this.label_OfeliaSara.Margin = new System.Windows.Forms.Padding(0);
            this.label_OfeliaSara.Name = "label_OfeliaSara";
            this.label_OfeliaSara.Size = new System.Drawing.Size(109, 28);
            this.label_OfeliaSara.TabIndex = 5;
            this.label_OfeliaSara.Text = "Ofelia-Sara";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.label_Texto);
            this.panel1.Controls.Add(this.pictureBox_Icono);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 112);
            this.panel1.TabIndex = 4;
            // 
            // label_Texto
            // 
            this.label_Texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Texto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(130)))));
            this.label_Texto.Location = new System.Drawing.Point(3, 65);
            this.label_Texto.Name = "label_Texto";
            this.label_Texto.Size = new System.Drawing.Size(379, 24);
            this.label_Texto.TabIndex = 4;
            this.label_Texto.Text = "Cargando...";
            this.label_Texto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_Icono
            // 
            this.pictureBox_Icono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Icono.Location = new System.Drawing.Point(169, 9);
            this.pictureBox_Icono.Name = "pictureBox_Icono";
            this.pictureBox_Icono.Size = new System.Drawing.Size(55, 50);
            this.pictureBox_Icono.TabIndex = 3;
            this.pictureBox_Icono.TabStop = false;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(40)))), ((int)(((byte)(0)))));
            this.btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Cerrar.Location = new System.Drawing.Point(162, 139);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(90, 30);
            this.btn_Cerrar.TabIndex = 2;
            this.btn_Cerrar.Text = "CERRAR";
            this.btn_Cerrar.UseVisualStyleBackColor = false;
            this.btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // pictureBox_EscudoPolicial
            // 
            this.pictureBox_EscudoPolicial.BackgroundImage = global::REDACTADOR.Properties.Resources.ICOes;
            this.pictureBox_EscudoPolicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_EscudoPolicial.Location = new System.Drawing.Point(2, 3);
            this.pictureBox_EscudoPolicial.Name = "pictureBox_EscudoPolicial";
            this.pictureBox_EscudoPolicial.Size = new System.Drawing.Size(36, 30);
            this.pictureBox_EscudoPolicial.TabIndex = 5;
            this.pictureBox_EscudoPolicial.TabStop = false;
            // 
            // btn_Si
            // 
            this.btn_Si.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Si.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Si.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Si.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Si.Location = new System.Drawing.Point(75, 139);
            this.btn_Si.Name = "btn_Si";
            this.btn_Si.Size = new System.Drawing.Size(90, 30);
            this.btn_Si.TabIndex = 6;
            this.btn_Si.Text = "SI";
            this.btn_Si.UseVisualStyleBackColor = false;
            this.btn_Si.Click += new System.EventHandler(this.Btn_Si_Click);
            // 
            // btn_No
            // 
            this.btn_No.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_No.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_No.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_No.Location = new System.Drawing.Point(248, 139);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(90, 30);
            this.btn_No.TabIndex = 7;
            this.btn_No.Text = "NO";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.Btn_No_Click);
            // 
            // MensajeGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(409, 173);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Si);
            this.Controls.Add(this.pictureBox_EscudoPolicial);
            this.Controls.Add(this.label_OfeliaSara);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MensajeGral";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EscudoPolicial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_OfeliaSara;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Texto;
        private System.Windows.Forms.PictureBox pictureBox_Icono;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.PictureBox pictureBox_EscudoPolicial;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Si;
    }
}