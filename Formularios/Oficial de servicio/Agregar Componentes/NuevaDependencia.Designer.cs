using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    partial class NuevaDependencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaDependencia));
            panel1 = new Panel();
            textBox_Partido = new Controles.General.CustomTextBox();
            textBox_Localidad = new Controles.General.CustomTextBox();
            label_Partido = new Label();
            label_Localidad = new Label();
            checkBox_AgregarSellos = new CheckBox();
            label_AgregarSellos = new Label();
            btn_Limpiar = new Button();
            btn_Guardar = new Button();
            textBox_Domicilio = new Controles.General.CustomTextBox();
            textBox_Dependencia = new Controles.General.CustomTextBox();
            label_Domicilio = new Label();
            label_Dependencia = new Label();
            label_TITULO = new Label();
            help_NuevaDependencia = new HelpProvider();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(textBox_Partido);
            panel1.Controls.Add(textBox_Localidad);
            panel1.Controls.Add(label_Partido);
            panel1.Controls.Add(label_Localidad);
            panel1.Controls.Add(checkBox_AgregarSellos);
            panel1.Controls.Add(label_AgregarSellos);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(textBox_Domicilio);
            panel1.Controls.Add(textBox_Dependencia);
            panel1.Controls.Add(label_Domicilio);
            panel1.Controls.Add(label_Dependencia);
            panel1.Location = new System.Drawing.Point(20, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(619, 299);
            panel1.TabIndex = 2;
            // 
            // textBox_Partido
            // 
            textBox_Partido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Partido.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Partido.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Partido.BackColor = System.Drawing.Color.White;
            textBox_Partido.ErrorColor = System.Drawing.Color.Red;
            textBox_Partido.FocusColor = System.Drawing.Color.Blue;
            textBox_Partido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            textBox_Partido.Location = new System.Drawing.Point(175, 133);
            textBox_Partido.MaxLength = 32767;
            textBox_Partido.Multiline = false;
            textBox_Partido.Name = "textBox_Partido";
            textBox_Partido.PasswordChar = '\0';
            textBox_Partido.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Partido.PlaceholderText = "";
            textBox_Partido.ReadOnly = false;
            textBox_Partido.SelectionStart = 0;
            textBox_Partido.ShowError = false;
            textBox_Partido.Size = new System.Drawing.Size(390, 21);
            textBox_Partido.TabIndex = 3;
            textBox_Partido.TextAlign = HorizontalAlignment.Center;
            textBox_Partido.TextValue = "";
            textBox_Partido.Whidth = 0;
            // 
            // textBox_Localidad
            // 
            textBox_Localidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Localidad.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Localidad.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Localidad.BackColor = System.Drawing.Color.White;
            textBox_Localidad.ErrorColor = System.Drawing.Color.Red;
            textBox_Localidad.FocusColor = System.Drawing.Color.Blue;
            textBox_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            textBox_Localidad.Location = new System.Drawing.Point(175, 103);
            textBox_Localidad.MaxLength = 32767;
            textBox_Localidad.Multiline = false;
            textBox_Localidad.Name = "textBox_Localidad";
            textBox_Localidad.PasswordChar = '\0';
            textBox_Localidad.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Localidad.PlaceholderText = "";
            textBox_Localidad.ReadOnly = false;
            textBox_Localidad.SelectionStart = 0;
            textBox_Localidad.ShowError = false;
            textBox_Localidad.Size = new System.Drawing.Size(390, 21);
            textBox_Localidad.TabIndex = 2;
            textBox_Localidad.TextAlign = HorizontalAlignment.Center;
            textBox_Localidad.TextValue = "";
            textBox_Localidad.Whidth = 0;
            textBox_Localidad.TextChanged += TextBox_Localidad_TextChanged;
            // 
            // label_Partido
            // 
            label_Partido.AutoSize = true;
            label_Partido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Partido.Location = new System.Drawing.Point(78, 133);
            label_Partido.Name = "label_Partido";
            label_Partido.Size = new System.Drawing.Size(82, 16);
            label_Partido.TabIndex = 104;
            label_Partido.Text = "PARTIDO :";
            // 
            // label_Localidad
            // 
            label_Localidad.AutoSize = true;
            label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Localidad.Location = new System.Drawing.Point(62, 103);
            label_Localidad.Name = "label_Localidad";
            label_Localidad.Size = new System.Drawing.Size(98, 16);
            label_Localidad.TabIndex = 103;
            label_Localidad.Text = "LOCALIDAD :";
            // 
            // checkBox_AgregarSellos
            // 
            checkBox_AgregarSellos.AutoSize = true;
            checkBox_AgregarSellos.Cursor = Cursors.Hand;
            checkBox_AgregarSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_AgregarSellos.Location = new System.Drawing.Point(211, 178);
            checkBox_AgregarSellos.Name = "checkBox_AgregarSellos";
            checkBox_AgregarSellos.Size = new System.Drawing.Size(15, 14);
            checkBox_AgregarSellos.TabIndex = 4;
            checkBox_AgregarSellos.UseVisualStyleBackColor = true;
            checkBox_AgregarSellos.CheckedChanged += CheckBox_AgregarSellos_CheckedChanged;
            // 
            // label_AgregarSellos
            // 
            label_AgregarSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_AgregarSellos.Location = new System.Drawing.Point(37, 173);
            label_AgregarSellos.Name = "label_AgregarSellos";
            label_AgregarSellos.Size = new System.Drawing.Size(207, 25);
            label_AgregarSellos.TabIndex = 105;
            label_AgregarSellos.Text = " AGREGAR SELLOS";
            label_AgregarSellos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.Anchor = AnchorStyles.Top;
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(191, 215);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 6;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Anchor = AnchorStyles.Top;
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(442, 215);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 5;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // textBox_Domicilio
            // 
            textBox_Domicilio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Domicilio.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Domicilio.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Domicilio.BackColor = System.Drawing.Color.White;
            textBox_Domicilio.ErrorColor = System.Drawing.Color.Red;
            textBox_Domicilio.FocusColor = System.Drawing.Color.Blue;
            textBox_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Domicilio.Location = new System.Drawing.Point(175, 73);
            textBox_Domicilio.MaxLength = 32767;
            textBox_Domicilio.Multiline = false;
            textBox_Domicilio.Name = "textBox_Domicilio";
            textBox_Domicilio.PasswordChar = '\0';
            textBox_Domicilio.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Domicilio.PlaceholderText = "";
            textBox_Domicilio.ReadOnly = false;
            textBox_Domicilio.SelectionStart = 0;
            textBox_Domicilio.ShowError = false;
            textBox_Domicilio.Size = new System.Drawing.Size(390, 21);
            textBox_Domicilio.TabIndex = 1;
            textBox_Domicilio.TextAlign = HorizontalAlignment.Center;
            textBox_Domicilio.TextValue = "";
            textBox_Domicilio.Whidth = 0;
            // 
            // textBox_Dependencia
            // 
            textBox_Dependencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Dependencia.AutoCompleteMode = AutoCompleteMode.None;
            textBox_Dependencia.AutoCompleteSource = AutoCompleteSource.None;
            textBox_Dependencia.BackColor = System.Drawing.Color.White;
            textBox_Dependencia.ErrorColor = System.Drawing.Color.Red;
            textBox_Dependencia.FocusColor = System.Drawing.Color.Blue;
            textBox_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Dependencia.Location = new System.Drawing.Point(175, 36);
            textBox_Dependencia.MaxLength = 32767;
            textBox_Dependencia.Multiline = false;
            textBox_Dependencia.Name = "textBox_Dependencia";
            textBox_Dependencia.PasswordChar = '\0';
            textBox_Dependencia.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Dependencia.PlaceholderText = "";
            textBox_Dependencia.ReadOnly = false;
            textBox_Dependencia.SelectionStart = 0;
            textBox_Dependencia.ShowError = false;
            textBox_Dependencia.Size = new System.Drawing.Size(390, 21);
            textBox_Dependencia.TabIndex = 0;
            textBox_Dependencia.TextAlign = HorizontalAlignment.Center;
            textBox_Dependencia.TextValue = "";
            textBox_Dependencia.Whidth = 0;
            textBox_Dependencia.TextChanged += TextBox_Dependencia_TextChanged;
            // 
            // label_Domicilio
            // 
            label_Domicilio.AutoSize = true;
            label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Domicilio.Location = new System.Drawing.Point(70, 73);
            label_Domicilio.Name = "label_Domicilio";
            label_Domicilio.Size = new System.Drawing.Size(90, 16);
            label_Domicilio.TabIndex = 102;
            label_Domicilio.Text = "DOMICILIO :";
            // 
            // label_Dependencia
            // 
            label_Dependencia.AutoSize = true;
            label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dependencia.Location = new System.Drawing.Point(37, 37);
            label_Dependencia.Name = "label_Dependencia";
            label_Dependencia.Size = new System.Drawing.Size(123, 16);
            label_Dependencia.TabIndex = 101;
            label_Dependencia.Text = "DEPENDENCIA :";
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(164, 9);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new Padding(10, 0, 10, 0);
            label_TITULO.Size = new System.Drawing.Size(253, 24);
            label_TITULO.TabIndex = 100;
            label_TITULO.Text = "NUEVA DEPENDENCIA";
            // 
            // NuevaDependencia
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(664, 360);
            Controls.Add(panel1);
            Controls.Add(label_TITULO);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuevaDependencia";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            Text = "AGREGAR NUEVA DEPENDENCIA";
            HelpButtonClicked += NuevaDependencia_HelpButtonClicked;
            Load += NuevaDependencia_Load;
            Controls.SetChildIndex(label_TITULO, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Domicilio;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Dependencia;
        private System.Windows.Forms.Label label_Domicilio;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_AgregarSellos;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.CheckBox checkBox_AgregarSellos;
        private System.Windows.Forms.HelpProvider help_NuevaDependencia;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Partido;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Localidad;
        private System.Windows.Forms.Label label_Partido;
        private System.Windows.Forms.Label label_Localidad;
    }
}