namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Acceso_Usuarios
{
    partial class AccesoUsuario
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
            panel1 = new System.Windows.Forms.Panel();
            pictureBox_MayusculaActivada = new System.Windows.Forms.PictureBox();
            pictureBox_OjoContraseña = new System.Windows.Forms.PictureBox();
            btn_Registrarse = new System.Windows.Forms.Button();
            btn_Ingresar = new System.Windows.Forms.Button();
            textBox_Contraseña = new Controles.General.CustomTextBox();
            textBox_Usuario = new Controles.General.CustomTextBox();
            label_Contraseña = new System.Windows.Forms.Label();
            label_Usuario = new System.Windows.Forms.Label();
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MayusculaActivada).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_OjoContraseña).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(pictureBox_MayusculaActivada);
            panel1.Controls.Add(pictureBox_OjoContraseña);
            panel1.Controls.Add(btn_Registrarse);
            panel1.Controls.Add(btn_Ingresar);
            panel1.Controls.Add(textBox_Contraseña);
            panel1.Controls.Add(textBox_Usuario);
            panel1.Controls.Add(label_Contraseña);
            panel1.Controls.Add(label_Usuario);
            panel1.Location = new System.Drawing.Point(20, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(615, 179);
            panel1.TabIndex = 3;
            // 
            // pictureBox_MayusculaActivada
            // 
            pictureBox_MayusculaActivada.BackColor = System.Drawing.Color.MediumTurquoise;
            pictureBox_MayusculaActivada.BackgroundImage = Properties.Resources.letra_mayuscula;
            pictureBox_MayusculaActivada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox_MayusculaActivada.Location = new System.Drawing.Point(169, 81);
            pictureBox_MayusculaActivada.Name = "pictureBox_MayusculaActivada";
            pictureBox_MayusculaActivada.Size = new System.Drawing.Size(21, 24);
            pictureBox_MayusculaActivada.TabIndex = 29;
            pictureBox_MayusculaActivada.TabStop = false;
            // 
            // pictureBox_OjoContraseña
            // 
            pictureBox_OjoContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_OjoContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_OjoContraseña.Location = new System.Drawing.Point(516, 87);
            pictureBox_OjoContraseña.Name = "pictureBox_OjoContraseña";
            pictureBox_OjoContraseña.Size = new System.Drawing.Size(32, 22);
            pictureBox_OjoContraseña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox_OjoContraseña.TabIndex = 28;
            pictureBox_OjoContraseña.TabStop = false;
            pictureBox_OjoContraseña.MouseDown += PictureBox_OjoContraseña_MouseDown;
            pictureBox_OjoContraseña.MouseUp += PictureBox_OjoContraseña_MouseUp;
            // 
            // btn_Registrarse
            // 
            btn_Registrarse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_Registrarse.BackColor = System.Drawing.Color.SkyBlue;
            btn_Registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Registrarse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_Registrarse.Location = new System.Drawing.Point(189, 129);
            btn_Registrarse.Margin = new System.Windows.Forms.Padding(0);
            btn_Registrarse.Name = "btn_Registrarse";
            btn_Registrarse.Size = new System.Drawing.Size(116, 33);
            btn_Registrarse.TabIndex = 3;
            btn_Registrarse.Text = "REGISTRARSE";
            btn_Registrarse.UseVisualStyleBackColor = false;
            btn_Registrarse.Click += Btn_Registrarse_Click;
            btn_Registrarse.Paint += Subrayado_Paint;
            btn_Registrarse.MouseEnter += Subrayado_MouseEnter;
            btn_Registrarse.MouseLeave += Subrayado_MouseLeave;
            // 
            // btn_Ingresar
            // 
            btn_Ingresar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_Ingresar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Ingresar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            btn_Ingresar.FlatAppearance.BorderSize = 0;
            btn_Ingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Ingresar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_Ingresar.Location = new System.Drawing.Point(408, 129);
            btn_Ingresar.Name = "btn_Ingresar";
            btn_Ingresar.Size = new System.Drawing.Size(102, 33);
            btn_Ingresar.TabIndex = 2;
            btn_Ingresar.Text = "INGRESAR";
            btn_Ingresar.UseVisualStyleBackColor = false;
            btn_Ingresar.Click += Btn_Ingresar_Click;
            btn_Ingresar.Paint += Subrayado_Paint;
            btn_Ingresar.MouseEnter += Subrayado_MouseEnter;
            btn_Ingresar.MouseLeave += Subrayado_MouseLeave;
            // 
            // textBox_Contraseña
            // 
            textBox_Contraseña.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_Contraseña.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Contraseña.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Contraseña.BackColor = System.Drawing.Color.White;
            textBox_Contraseña.ErrorColor = System.Drawing.Color.Red;
            textBox_Contraseña.FocusColor = System.Drawing.Color.Blue;
            textBox_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Contraseña.Location = new System.Drawing.Point(189, 85);
            textBox_Contraseña.MaxLength = 32767;
            textBox_Contraseña.Multiline = false;
            textBox_Contraseña.Name = "textBox_Contraseña";
            textBox_Contraseña.PasswordChar = '*';
            textBox_Contraseña.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Contraseña.PlaceholderText = "";
            textBox_Contraseña.ReadOnly = false;
            textBox_Contraseña.SelectionStart = 0;
            textBox_Contraseña.ShowError = false;
            textBox_Contraseña.Size = new System.Drawing.Size(321, 21);
            textBox_Contraseña.TabIndex = 1;
            textBox_Contraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Contraseña.TextValue = "";
            textBox_Contraseña.Whidth = 0;
            textBox_Contraseña.TextChanged += TextBox_Contraseña_TextChanged;
            // 
            // textBox_Usuario
            // 
            textBox_Usuario.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_Usuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Usuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Usuario.BackColor = System.Drawing.Color.White;
            textBox_Usuario.ErrorColor = System.Drawing.Color.Red;
            textBox_Usuario.FocusColor = System.Drawing.Color.Blue;
            textBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Usuario.Location = new System.Drawing.Point(189, 46);
            textBox_Usuario.MaxLength = 32767;
            textBox_Usuario.Multiline = false;
            textBox_Usuario.Name = "textBox_Usuario";
            textBox_Usuario.PasswordChar = '\0';
            textBox_Usuario.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Usuario.PlaceholderText = "";
            textBox_Usuario.ReadOnly = false;
            textBox_Usuario.SelectionStart = 0;
            textBox_Usuario.ShowError = false;
            textBox_Usuario.Size = new System.Drawing.Size(321, 21);
            textBox_Usuario.TabIndex = 0;
            textBox_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Usuario.TextValue = "";
            textBox_Usuario.Whidth = 0;
            // 
            // label_Contraseña
            // 
            label_Contraseña.AutoSize = true;
            label_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Contraseña.Location = new System.Drawing.Point(53, 86);
            label_Contraseña.Name = "label_Contraseña";
            label_Contraseña.Size = new System.Drawing.Size(146, 20);
            label_Contraseña.TabIndex = 102;
            label_Contraseña.Text = "CONTRASEÑA :";
            // 
            // label_Usuario
            // 
            label_Usuario.AutoSize = true;
            label_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Usuario.Location = new System.Drawing.Point(89, 47);
            label_Usuario.Name = "label_Usuario";
            label_Usuario.Size = new System.Drawing.Size(103, 20);
            label_Usuario.TabIndex = 101;
            label_Usuario.Text = "USUARIO :";
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(135, 12);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            label_TITULO.Size = new System.Drawing.Size(357, 31);
            label_TITULO.TabIndex = 100;
            label_TITULO.Text = "VALIDACION DE USUARIOS";
            // 
            // AccesoUsuario
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(658, 232);
            Controls.Add(panel1);
            Controls.Add(label_TITULO);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccesoUsuario";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "VALIDACION DE PERMISOS";
            HelpButtonClicked += UsuarioForm_HelpButtonClicked;
            Load += Usuario_Load;
            Controls.SetChildIndex(label_TITULO, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MayusculaActivada).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_OjoContraseña).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Button btn_Ingresar;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Contraseña;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Usuario;
        private System.Windows.Forms.Label label_Contraseña;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.PictureBox pictureBox_OjoContraseña;
        private System.Windows.Forms.PictureBox pictureBox_MayusculaActivada;
    }
}