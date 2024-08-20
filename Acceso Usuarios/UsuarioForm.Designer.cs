namespace Ofelia_Sara.Formularios
{
    partial class UsuarioForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox_OjoContraseña = new System.Windows.Forms.PictureBox();
            this.btn_Registrarse = new System.Windows.Forms.Button();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.textBox_Contraseña = new System.Windows.Forms.TextBox();
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.label_Contraseña = new System.Windows.Forms.Label();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.label_Validacion = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OjoContraseña)).BeginInit();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 8, 7, 2, 24, 29, 988);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.pictureBox_OjoContraseña);
            this.panel2.Controls.Add(this.btn_Registrarse);
            this.panel2.Controls.Add(this.btn_Ingresar);
            this.panel2.Controls.Add(this.textBox_Contraseña);
            this.panel2.Controls.Add(this.textBox_Usuario);
            this.panel2.Controls.Add(this.label_Contraseña);
            this.panel2.Controls.Add(this.label_Usuario);
            this.panel2.Controls.Add(this.label_Validacion);
            this.panel2.Location = new System.Drawing.Point(23, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 239);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox_OjoContraseña
            // 
            this.pictureBox_OjoContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_OjoContraseña.Location = new System.Drawing.Point(427, 119);
            this.pictureBox_OjoContraseña.Name = "pictureBox_OjoContraseña";
            this.pictureBox_OjoContraseña.Size = new System.Drawing.Size(32, 19);
            this.pictureBox_OjoContraseña.TabIndex = 28;
            this.pictureBox_OjoContraseña.TabStop = false;
            this.pictureBox_OjoContraseña.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_OjoContraseña_MouseDown);
            this.pictureBox_OjoContraseña.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_OjoContraseña_MouseUp);
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Registrarse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Registrarse.Location = new System.Drawing.Point(189, 163);
            this.btn_Registrarse.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(116, 33);
            this.btn_Registrarse.TabIndex = 6;
            this.btn_Registrarse.Text = "REGISTRARSE";
            this.btn_Registrarse.UseVisualStyleBackColor = false;
            this.btn_Registrarse.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Ingresar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Ingresar.FlatAppearance.BorderSize = 0;
            this.btn_Ingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ingresar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Ingresar.Location = new System.Drawing.Point(333, 163);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(88, 33);
            this.btn_Ingresar.TabIndex = 5;
            this.btn_Ingresar.Text = "INGRESAR";
            this.btn_Ingresar.UseVisualStyleBackColor = false;
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Contraseña.Location = new System.Drawing.Point(189, 114);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.PasswordChar = '*';
            this.textBox_Contraseña.Size = new System.Drawing.Size(232, 24);
            this.textBox_Contraseña.TabIndex = 4;
            this.textBox_Contraseña.TextChanged += new System.EventHandler(this.textBox_Contraseña_TextChanged);
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Usuario.Location = new System.Drawing.Point(189, 80);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.Size = new System.Drawing.Size(232, 24);
            this.textBox_Usuario.TabIndex = 3;
            // 
            // label_Contraseña
            // 
            this.label_Contraseña.AutoSize = true;
            this.label_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Contraseña.Location = new System.Drawing.Point(53, 119);
            this.label_Contraseña.Name = "label_Contraseña";
            this.label_Contraseña.Size = new System.Drawing.Size(119, 16);
            this.label_Contraseña.TabIndex = 2;
            this.label_Contraseña.Text = "CONTRASEÑA :";
            // 
            // label_Usuario
            // 
            this.label_Usuario.AutoSize = true;
            this.label_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Usuario.Location = new System.Drawing.Point(89, 85);
            this.label_Usuario.Name = "label_Usuario";
            this.label_Usuario.Size = new System.Drawing.Size(83, 16);
            this.label_Usuario.TabIndex = 1;
            this.label_Usuario.Text = "USUARIO :";
            // 
            // label_Validacion
            // 
            this.label_Validacion.AutoSize = true;
            this.label_Validacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_Validacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Validacion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Validacion.Location = new System.Drawing.Point(115, 0);
            this.label_Validacion.Name = "label_Validacion";
            this.label_Validacion.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_Validacion.Size = new System.Drawing.Size(306, 26);
            this.label_Validacion.TabIndex = 0;
            this.label_Validacion.Text = "VALIDACION DE USUARIOS";
            // 
            // UsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 305);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VALIDACION DE PERMISOS";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.UsuarioForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OjoContraseña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.Label label_Validacion;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.TextBox textBox_Contraseña;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.Label label_Contraseña;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.PictureBox pictureBox_OjoContraseña;
    }
}