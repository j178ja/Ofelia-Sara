namespace Ofelia_Sara.Registro_de_personal
{
    partial class BuscarPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPersonal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.lbl_Legajo = new System.Windows.Forms.Label();
            this.textBox_NumeroIpp = new System.Windows.Forms.TextBox();
            this.btn_AgregarCausa = new System.Windows.Forms.Button();
            this.btn_Registrarse = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 8, 13, 17, 10, 52, 236);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.btn_Registrarse);
            this.panel1.Controls.Add(this.btn_AgregarCausa);
            this.panel1.Controls.Add(this.textBox_NumeroIpp);
            this.panel1.Controls.Add(this.lbl_Legajo);
            this.panel1.Controls.Add(this.lbl_Titulo);
            this.panel1.Location = new System.Drawing.Point(24, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 239);
            this.panel1.TabIndex = 2;
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Titulo.Location = new System.Drawing.Point(106, 0);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbl_Titulo.Size = new System.Drawing.Size(228, 24);
            this.lbl_Titulo.TabIndex = 32;
            this.lbl_Titulo.Text = "BUSCAR PERSONAL";
            // 
            // lbl_Legajo
            // 
            this.lbl_Legajo.AutoSize = true;
            this.lbl_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Legajo.Location = new System.Drawing.Point(34, 61);
            this.lbl_Legajo.Name = "lbl_Legajo";
            this.lbl_Legajo.Size = new System.Drawing.Size(131, 15);
            this.lbl_Legajo.TabIndex = 33;
            this.lbl_Legajo.Text = "LEGAJO POLICIAL :";
            // 
            // textBox_NumeroIpp
            // 
            this.textBox_NumeroIpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NumeroIpp.Location = new System.Drawing.Point(171, 60);
            this.textBox_NumeroIpp.Name = "textBox_NumeroIpp";
            this.textBox_NumeroIpp.Size = new System.Drawing.Size(163, 20);
            this.textBox_NumeroIpp.TabIndex = 34;
            this.textBox_NumeroIpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_AgregarCausa
            // 
            this.btn_AgregarCausa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AgregarCausa.BackColor = System.Drawing.Color.White;
            this.btn_AgregarCausa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarCausa.FlatAppearance.BorderSize = 3;
            this.btn_AgregarCausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarCausa.Location = new System.Drawing.Point(336, 59);
            this.btn_AgregarCausa.Name = "btn_AgregarCausa";
            this.btn_AgregarCausa.Size = new System.Drawing.Size(15, 23);
            this.btn_AgregarCausa.TabIndex = 35;
            this.btn_AgregarCausa.Text = "+";
            this.btn_AgregarCausa.UseVisualStyleBackColor = false;
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Registrarse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Registrarse.Location = new System.Drawing.Point(49, 129);
            this.btn_Registrarse.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(116, 62);
            this.btn_Registrarse.TabIndex = 36;
            this.btn_Registrarse.Text = "REGISTRAR NUEVO PERSONAL";
            this.btn_Registrarse.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(300, 124);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 37;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // BuscarPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 315);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarPersonal";
            this.Text = "BUSCAR PERSONAL POLICIAL";
            this.Load += new System.EventHandler(this.BuscarPersonal_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Label lbl_Legajo;
        private System.Windows.Forms.TextBox textBox_NumeroIpp;
        private System.Windows.Forms.Button btn_AgregarCausa;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.Button btn_Guardar;
    }
}