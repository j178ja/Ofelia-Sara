﻿namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class Registro
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            panel1 = new System.Windows.Forms.Panel();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Registrarse = new System.Windows.Forms.Button();
            label_Legajo = new System.Windows.Forms.Label();
            textBox_Legajo = new Controles.General.CustomTextBox();
            label_Apellido = new System.Windows.Forms.Label();
            textBox_Apellido = new Controles.General.CustomTextBox();
            textBox_Nombre = new Controles.General.CustomTextBox();
            textBox_Jerarquia = new Controles.General.CustomTextBox();
            label_Nombre = new System.Windows.Forms.Label();
            label_Jerarquia = new System.Windows.Forms.Label();
            textBox_Contraseña = new Controles.General.CustomTextBox();
            textBox_Usuario = new Controles.General.CustomTextBox();
            label_Contraseña = new System.Windows.Forms.Label();
            label_Usuario = new System.Windows.Forms.Label();
            label_TITULO = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(btn_Registrarse);
            panel1.Controls.Add(label_Legajo);
            panel1.Controls.Add(textBox_Legajo);
            panel1.Controls.Add(label_Apellido);
            panel1.Controls.Add(textBox_Apellido);
            panel1.Controls.Add(textBox_Nombre);
            panel1.Controls.Add(textBox_Jerarquia);
            panel1.Controls.Add(label_Nombre);
            panel1.Controls.Add(label_Jerarquia);
            panel1.Controls.Add(textBox_Contraseña);
            panel1.Controls.Add(textBox_Usuario);
            panel1.Controls.Add(label_Contraseña);
            panel1.Controls.Add(label_Usuario);
            panel1.Location = new System.Drawing.Point(18, 23);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(469, 368);
            panel1.TabIndex = 4;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(99, 281);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 23;
            toolTip1.SetToolTip(btn_Limpiar, "Limpiar Formulario");
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += btn_Limpiar_Click;
            // 
            // btn_Registrarse
            // 
            btn_Registrarse.BackColor = System.Drawing.Color.SkyBlue;
            btn_Registrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Registrarse.Image = (System.Drawing.Image)resources.GetObject("btn_Registrarse.Image");
            btn_Registrarse.Location = new System.Drawing.Point(328, 281);
            btn_Registrarse.Name = "btn_Registrarse";
            btn_Registrarse.Size = new System.Drawing.Size(75, 67);
            btn_Registrarse.TabIndex = 22;
            toolTip1.SetToolTip(btn_Registrarse, "REGISTRARSE");
            btn_Registrarse.UseVisualStyleBackColor = false;
            btn_Registrarse.Click += btn_Registrarse_Click;
            // 
            // label_Legajo
            // 
            label_Legajo.AutoSize = true;
            label_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Legajo.Location = new System.Drawing.Point(90, 134);
            label_Legajo.Name = "label_Legajo";
            label_Legajo.Size = new System.Drawing.Size(94, 20);
            label_Legajo.TabIndex = 21;
            label_Legajo.Text = "LEGAJO :";
            // 
            // textBox_Legajo
            // 
            textBox_Legajo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Legajo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Legajo.BackColor = System.Drawing.Color.White;
            textBox_Legajo.ErrorColor = System.Drawing.Color.Red;
            textBox_Legajo.FocusColor = System.Drawing.Color.Blue;
            textBox_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Legajo.Location = new System.Drawing.Point(169, 131);
            textBox_Legajo.MaxLength = 32767;
            textBox_Legajo.Multiline = false;
            textBox_Legajo.Name = "textBox_Legajo";
            textBox_Legajo.PasswordChar = '\0';
            textBox_Legajo.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Legajo.PlaceholderText = "";
            textBox_Legajo.ReadOnly = false;
            textBox_Legajo.SelectionStart = 0;
            textBox_Legajo.ShowError = false;
            textBox_Legajo.Size = new System.Drawing.Size(232, 24);
            textBox_Legajo.TabIndex = 20;
            textBox_Legajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Legajo.TextValue = "";
            textBox_Legajo.Whidth = 0;
            textBox_Legajo.KeyPress += textBox_Legajo_KeyPress;
            // 
            // label_Apellido
            // 
            label_Apellido.AutoSize = true;
            label_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Apellido.Location = new System.Drawing.Point(76, 104);
            label_Apellido.Name = "label_Apellido";
            label_Apellido.Size = new System.Drawing.Size(112, 20);
            label_Apellido.TabIndex = 19;
            label_Apellido.Text = "APELLIDO :";
            // 
            // textBox_Apellido
            // 
            textBox_Apellido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Apellido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Apellido.BackColor = System.Drawing.Color.White;
            textBox_Apellido.ErrorColor = System.Drawing.Color.Red;
            textBox_Apellido.FocusColor = System.Drawing.Color.Blue;
            textBox_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Apellido.Location = new System.Drawing.Point(169, 99);
            textBox_Apellido.MaxLength = 32767;
            textBox_Apellido.Multiline = false;
            textBox_Apellido.Name = "textBox_Apellido";
            textBox_Apellido.PasswordChar = '\0';
            textBox_Apellido.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Apellido.PlaceholderText = "";
            textBox_Apellido.ReadOnly = false;
            textBox_Apellido.SelectionStart = 0;
            textBox_Apellido.ShowError = false;
            textBox_Apellido.Size = new System.Drawing.Size(232, 24);
            textBox_Apellido.TabIndex = 18;
            textBox_Apellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Apellido.TextValue = "";
            textBox_Apellido.Whidth = 0;
            textBox_Apellido.TextChanged += textBox_TextChanged;
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Nombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Nombre.BackColor = System.Drawing.Color.White;
            textBox_Nombre.ErrorColor = System.Drawing.Color.Red;
            textBox_Nombre.FocusColor = System.Drawing.Color.Blue;
            textBox_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Nombre.Location = new System.Drawing.Point(169, 66);
            textBox_Nombre.MaxLength = 32767;
            textBox_Nombre.Multiline = false;
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.PasswordChar = '\0';
            textBox_Nombre.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Nombre.PlaceholderText = "";
            textBox_Nombre.ReadOnly = false;
            textBox_Nombre.SelectionStart = 0;
            textBox_Nombre.ShowError = false;
            textBox_Nombre.Size = new System.Drawing.Size(232, 24);
            textBox_Nombre.TabIndex = 17;
            textBox_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Nombre.TextValue = "";
            textBox_Nombre.Whidth = 0;
            textBox_Nombre.TextChanged += textBox_TextChanged;
            // 
            // textBox_Jerarquia
            // 
            textBox_Jerarquia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Jerarquia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Jerarquia.BackColor = System.Drawing.Color.White;
            textBox_Jerarquia.ErrorColor = System.Drawing.Color.Red;
            textBox_Jerarquia.FocusColor = System.Drawing.Color.Blue;
            textBox_Jerarquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Jerarquia.Location = new System.Drawing.Point(169, 32);
            textBox_Jerarquia.MaxLength = 32767;
            textBox_Jerarquia.Multiline = false;
            textBox_Jerarquia.Name = "textBox_Jerarquia";
            textBox_Jerarquia.PasswordChar = '\0';
            textBox_Jerarquia.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Jerarquia.PlaceholderText = "";
            textBox_Jerarquia.ReadOnly = false;
            textBox_Jerarquia.SelectionStart = 0;
            textBox_Jerarquia.ShowError = false;
            textBox_Jerarquia.Size = new System.Drawing.Size(232, 24);
            textBox_Jerarquia.TabIndex = 16;
            textBox_Jerarquia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Jerarquia.TextValue = "";
            textBox_Jerarquia.Whidth = 0;
            textBox_Jerarquia.TextChanged += textBox_TextChanged;
            // 
            // label_Nombre
            // 
            label_Nombre.AutoSize = true;
            label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Nombre.Location = new System.Drawing.Point(83, 71);
            label_Nombre.Name = "label_Nombre";
            label_Nombre.Size = new System.Drawing.Size(101, 20);
            label_Nombre.TabIndex = 15;
            label_Nombre.Text = "NOMBRE :";
            // 
            // label_Jerarquia
            // 
            label_Jerarquia.AutoSize = true;
            label_Jerarquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Jerarquia.Location = new System.Drawing.Point(62, 37);
            label_Jerarquia.Name = "label_Jerarquia";
            label_Jerarquia.Size = new System.Drawing.Size(125, 20);
            label_Jerarquia.TabIndex = 14;
            label_Jerarquia.Text = "JERARQUIA :";
            // 
            // textBox_Contraseña
            // 
            textBox_Contraseña.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Contraseña.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Contraseña.BackColor = System.Drawing.Color.White;
            textBox_Contraseña.ErrorColor = System.Drawing.Color.Red;
            textBox_Contraseña.FocusColor = System.Drawing.Color.Blue;
            textBox_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Contraseña.Location = new System.Drawing.Point(169, 218);
            textBox_Contraseña.MaxLength = 32767;
            textBox_Contraseña.Multiline = false;
            textBox_Contraseña.Name = "textBox_Contraseña";
            textBox_Contraseña.PasswordChar = '*';
            textBox_Contraseña.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Contraseña.PlaceholderText = "";
            textBox_Contraseña.ReadOnly = false;
            textBox_Contraseña.SelectionStart = 0;
            textBox_Contraseña.ShowError = false;
            textBox_Contraseña.Size = new System.Drawing.Size(232, 24);
            textBox_Contraseña.TabIndex = 10;
            textBox_Contraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Contraseña.TextValue = "";
            textBox_Contraseña.Whidth = 0;
            // 
            // textBox_Usuario
            // 
            textBox_Usuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Usuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Usuario.BackColor = System.Drawing.Color.White;
            textBox_Usuario.ErrorColor = System.Drawing.Color.Red;
            textBox_Usuario.FocusColor = System.Drawing.Color.Blue;
            textBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Usuario.Location = new System.Drawing.Point(169, 184);
            textBox_Usuario.MaxLength = 32767;
            textBox_Usuario.Multiline = false;
            textBox_Usuario.Name = "textBox_Usuario";
            textBox_Usuario.PasswordChar = '\0';
            textBox_Usuario.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Usuario.PlaceholderText = "";
            textBox_Usuario.ReadOnly = false;
            textBox_Usuario.SelectionStart = 0;
            textBox_Usuario.ShowError = false;
            textBox_Usuario.Size = new System.Drawing.Size(232, 24);
            textBox_Usuario.TabIndex = 9;
            textBox_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Usuario.TextValue = "";
            textBox_Usuario.Whidth = 0;
            // 
            // label_Contraseña
            // 
            label_Contraseña.AutoSize = true;
            label_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Contraseña.Location = new System.Drawing.Point(44, 223);
            label_Contraseña.Name = "label_Contraseña";
            label_Contraseña.Size = new System.Drawing.Size(146, 20);
            label_Contraseña.TabIndex = 8;
            label_Contraseña.Text = "CONTRASEÑA :";
            // 
            // label_Usuario
            // 
            label_Usuario.AutoSize = true;
            label_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Usuario.Location = new System.Drawing.Point(80, 189);
            label_Usuario.Name = "label_Usuario";
            label_Usuario.Size = new System.Drawing.Size(103, 20);
            label_Usuario.TabIndex = 7;
            label_Usuario.Text = "USUARIO :";
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(108, 9);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            label_TITULO.Size = new System.Drawing.Size(335, 31);
            label_TITULO.TabIndex = 13;
            label_TITULO.Text = "REGISTRO DE USUARIOS";
            label_TITULO.Click += label_Registro_Click;
            // 
            // Registro
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(510, 435);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Registro";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Registro";
            HelpButtonClicked += Registro_HelpButtonClicked;
            Load += Registro_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Contraseña;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Usuario;
        private System.Windows.Forms.Label label_Contraseña;
        private System.Windows.Forms.Label label_Usuario;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Apellido;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Nombre;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Jerarquia;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.Label label_Jerarquia;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.Label label_Legajo;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Legajo;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}