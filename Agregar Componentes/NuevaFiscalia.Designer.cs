namespace Ofelia_Sara.Agregar_Componentes
{
    partial class NuevaFiscalia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaFiscalia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.textBox_DeptoJudicial = new System.Windows.Forms.TextBox();
            this.textBox_Localidad = new System.Windows.Forms.TextBox();
            this.textBox_AgenteFiscal = new System.Windows.Forms.TextBox();
            this.textBox_Fiscalia = new System.Windows.Forms.TextBox();
            this.label_DptoJudicial = new System.Windows.Forms.Label();
            this.label_Localidad = new System.Windows.Forms.Label();
            this.label_Dr = new System.Windows.Forms.Label();
            this.label_Ufid = new System.Windows.Forms.Label();
            this.label_fisc = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
         
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.textBox_DeptoJudicial);
            this.panel1.Controls.Add(this.textBox_Localidad);
            this.panel1.Controls.Add(this.textBox_AgenteFiscal);
            this.panel1.Controls.Add(this.textBox_Fiscalia);
            this.panel1.Controls.Add(this.label_DptoJudicial);
            this.panel1.Controls.Add(this.label_Localidad);
            this.panel1.Controls.Add(this.label_Dr);
            this.panel1.Controls.Add(this.label_Ufid);
            this.panel1.Controls.Add(this.label_fisc);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 243);
            this.panel1.TabIndex = 2;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(147, 162);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 30;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(367, 162);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 29;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // textBox_DeptoJudicial
            // 
            this.textBox_DeptoJudicial.Location = new System.Drawing.Point(147, 124);
            this.textBox_DeptoJudicial.Name = "textBox_DeptoJudicial";
            this.textBox_DeptoJudicial.Size = new System.Drawing.Size(295, 20);
            this.textBox_DeptoJudicial.TabIndex = 8;
            // 
            // textBox_Localidad
            // 
            this.textBox_Localidad.Location = new System.Drawing.Point(147, 98);
            this.textBox_Localidad.Name = "textBox_Localidad";
            this.textBox_Localidad.Size = new System.Drawing.Size(295, 20);
            this.textBox_Localidad.TabIndex = 7;
            
            // 
            // textBox_AgenteFiscal
            // 
            this.textBox_AgenteFiscal.Location = new System.Drawing.Point(147, 72);
            this.textBox_AgenteFiscal.Name = "textBox_AgenteFiscal";
            this.textBox_AgenteFiscal.Size = new System.Drawing.Size(295, 20);
            this.textBox_AgenteFiscal.TabIndex = 6;
            // 
            // textBox_Fiscalia
            // 
            this.textBox_Fiscalia.Location = new System.Drawing.Point(147, 46);
            this.textBox_Fiscalia.Name = "textBox_Fiscalia";
            this.textBox_Fiscalia.Size = new System.Drawing.Size(295, 20);
            this.textBox_Fiscalia.TabIndex = 5;
            this.textBox_Fiscalia.TextChanged += new System.EventHandler(this.TextBox_Fiscalia_TextChanged);
            // 
            // label_DptoJudicial
            // 
            this.label_DptoJudicial.AutoSize = true;
            this.label_DptoJudicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DptoJudicial.Location = new System.Drawing.Point(31, 125);
            this.label_DptoJudicial.Name = "label_DptoJudicial";
            this.label_DptoJudicial.Size = new System.Drawing.Size(110, 16);
            this.label_DptoJudicial.TabIndex = 4;
            this.label_DptoJudicial.Text = "Dpto. Judicial :";
            // 
            // label_Localidad
            // 
            this.label_Localidad.AutoSize = true;
            this.label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Localidad.Location = new System.Drawing.Point(43, 99);
            this.label_Localidad.Name = "label_Localidad";
            this.label_Localidad.Size = new System.Drawing.Size(98, 16);
            this.label_Localidad.TabIndex = 3;
            this.label_Localidad.Text = "LOCALIDAD :";
            // 
            // label_Dr
            // 
            this.label_Dr.AutoSize = true;
            this.label_Dr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dr.Location = new System.Drawing.Point(106, 72);
            this.label_Dr.Name = "label_Dr";
            this.label_Dr.Size = new System.Drawing.Size(35, 16);
            this.label_Dr.TabIndex = 2;
            this.label_Dr.Text = "Dr. :";
            // 
            // label_Ufid
            // 
            this.label_Ufid.AutoSize = true;
            this.label_Ufid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ufid.Location = new System.Drawing.Point(79, 46);
            this.label_Ufid.Name = "label_Ufid";
            this.label_Ufid.Size = new System.Drawing.Size(62, 16);
            this.label_Ufid.TabIndex = 1;
            this.label_Ufid.Text = "U.F.I.D.:";
            // 
            // label_fisc
            // 
            this.label_fisc.AutoSize = true;
            this.label_fisc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_fisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fisc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_fisc.Location = new System.Drawing.Point(163, 0);
            this.label_fisc.Name = "label_fisc";
            this.label_fisc.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_fisc.Size = new System.Drawing.Size(235, 30);
            this.label_fisc.TabIndex = 0;
            this.label_fisc.Text = "DATOS FISCALIA";
            // 
            // NuevaFiscalia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 294);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaFiscalia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiscalia";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FISCALIA_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Fiscalia_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_fisc;
        private System.Windows.Forms.Label label_DptoJudicial;
        private System.Windows.Forms.Label label_Localidad;
        private System.Windows.Forms.Label label_Dr;
        private System.Windows.Forms.Label label_Ufid;
        private System.Windows.Forms.TextBox textBox_DeptoJudicial;
        private System.Windows.Forms.TextBox textBox_Localidad;
        private System.Windows.Forms.TextBox textBox_AgenteFiscal;
        private System.Windows.Forms.TextBox textBox_Fiscalia;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
    }
}