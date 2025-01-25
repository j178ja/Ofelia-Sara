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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaDependencia));
            panel1 = new System.Windows.Forms.Panel();
            textBox_Partido = new Controles.General.CustomTextBox();
            textBox_Localidad = new Controles.General.CustomTextBox();
            label_Partido = new System.Windows.Forms.Label();
            label_Localidad = new System.Windows.Forms.Label();
            checkBox_AgregarSellos = new System.Windows.Forms.CheckBox();
            label_AgregarSellos = new System.Windows.Forms.Label();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            textBox_Domicilio = new Controles.General.CustomTextBox();
            textBox_Dependencia = new Controles.General.CustomTextBox();
            label_Domicilio = new System.Windows.Forms.Label();
            label_Dependencia = new System.Windows.Forms.Label();
            label_NuevaDep = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            help_NuevaDependencia = new System.Windows.Forms.HelpProvider();
            pictureBox_CheckAgregarSellos = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckAgregarSellos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(pictureBox_CheckAgregarSellos);
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
            panel1.Controls.Add(label_NuevaDep);
            panel1.Location = new System.Drawing.Point(20, 15);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(524, 320);
            panel1.TabIndex = 2;
            // 
            // textBox_Partido
            // 
            textBox_Partido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Partido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Partido.BackColor = System.Drawing.Color.White;
            textBox_Partido.ErrorColor = System.Drawing.Color.Red;
            textBox_Partido.FocusColor = System.Drawing.Color.Blue;
            textBox_Partido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            textBox_Partido.Location = new System.Drawing.Point(144, 157);
            textBox_Partido.MaxLength = 32767;
            textBox_Partido.Multiline = false;
            textBox_Partido.Name = "textBox_Partido";
            textBox_Partido.PasswordChar = '\0';
            textBox_Partido.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Partido.PlaceholderText = "";
            textBox_Partido.ReadOnly = false;
            textBox_Partido.SelectionStart = 0;
            textBox_Partido.ShowError = false;
            textBox_Partido.Size = new System.Drawing.Size(326, 21);
            textBox_Partido.TabIndex = 24;
            textBox_Partido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Partido.TextValue = "";
            textBox_Partido.TextChanged += TextBox_TextChanged;
            // 
            // textBox_Localidad
            // 
            textBox_Localidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Localidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Localidad.BackColor = System.Drawing.Color.White;
            textBox_Localidad.ErrorColor = System.Drawing.Color.Red;
            textBox_Localidad.FocusColor = System.Drawing.Color.Blue;
            textBox_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            textBox_Localidad.Location = new System.Drawing.Point(144, 127);
            textBox_Localidad.MaxLength = 32767;
            textBox_Localidad.Multiline = false;
            textBox_Localidad.Name = "textBox_Localidad";
            textBox_Localidad.PasswordChar = '\0';
            textBox_Localidad.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Localidad.PlaceholderText = "";
            textBox_Localidad.ReadOnly = false;
            textBox_Localidad.SelectionStart = 0;
            textBox_Localidad.ShowError = false;
            textBox_Localidad.Size = new System.Drawing.Size(326, 21);
            textBox_Localidad.TabIndex = 23;
            textBox_Localidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Localidad.TextValue = "";
            textBox_Localidad.TextChanged += TextBox_Localidad_TextChanged;
            // 
            // label_Partido
            // 
            label_Partido.AutoSize = true;
            label_Partido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Partido.Location = new System.Drawing.Point(56, 157);
            label_Partido.Name = "label_Partido";
            label_Partido.Size = new System.Drawing.Size(82, 16);
            label_Partido.TabIndex = 22;
            label_Partido.Text = "PARTIDO :";
            // 
            // label_Localidad
            // 
            label_Localidad.AutoSize = true;
            label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Localidad.Location = new System.Drawing.Point(40, 127);
            label_Localidad.Name = "label_Localidad";
            label_Localidad.Size = new System.Drawing.Size(98, 16);
            label_Localidad.TabIndex = 21;
            label_Localidad.Text = "LOCALIDAD :";
            // 
            // checkBox_AgregarSellos
            // 
            checkBox_AgregarSellos.AutoSize = true;
            checkBox_AgregarSellos.Cursor = Cursors.Hand;
            checkBox_AgregarSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_AgregarSellos.Location = new System.Drawing.Point(186, 205);
            checkBox_AgregarSellos.Name = "checkBox_AgregarSellos";
            checkBox_AgregarSellos.Size = new System.Drawing.Size(15, 14);
            checkBox_AgregarSellos.TabIndex = 2;
            checkBox_AgregarSellos.UseVisualStyleBackColor = true;
            checkBox_AgregarSellos.CheckedChanged += CheckBox_AgregarSellos_CheckedChanged;
            // 
            // label_AgregarSellos
            // 
            label_AgregarSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_AgregarSellos.Location = new System.Drawing.Point(12, 200);
            label_AgregarSellos.Name = "label_AgregarSellos";
            label_AgregarSellos.Size = new System.Drawing.Size(207, 25);
            label_AgregarSellos.TabIndex = 20;
            label_AgregarSellos.Text = " AGREGAR SELLOS";
            label_AgregarSellos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(144, 239);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 4;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(395, 239);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 3;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // textBox_Domicilio
            // 
            textBox_Domicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Domicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Domicilio.BackColor = System.Drawing.Color.White;
            textBox_Domicilio.ErrorColor = System.Drawing.Color.Red;
            textBox_Domicilio.FocusColor = System.Drawing.Color.Blue;
            textBox_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Domicilio.Location = new System.Drawing.Point(144, 97);
            textBox_Domicilio.MaxLength = 32767;
            textBox_Domicilio.Multiline = false;
            textBox_Domicilio.Name = "textBox_Domicilio";
            textBox_Domicilio.PasswordChar = '\0';
            textBox_Domicilio.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Domicilio.PlaceholderText = "";
            textBox_Domicilio.ReadOnly = false;
            textBox_Domicilio.SelectionStart = 0;
            textBox_Domicilio.ShowError = false;
            textBox_Domicilio.Size = new System.Drawing.Size(326, 21);
            textBox_Domicilio.TabIndex = 1;
            textBox_Domicilio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Domicilio.TextValue = "";
            // 
            // textBox_Dependencia
            // 
            textBox_Dependencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Dependencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Dependencia.BackColor = System.Drawing.Color.White;
            textBox_Dependencia.ErrorColor = System.Drawing.Color.Red;
            textBox_Dependencia.FocusColor = System.Drawing.Color.Blue;
            textBox_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Dependencia.Location = new System.Drawing.Point(144, 60);
            textBox_Dependencia.MaxLength = 32767;
            textBox_Dependencia.Multiline = false;
            textBox_Dependencia.Name = "textBox_Dependencia";
            textBox_Dependencia.PasswordChar = '\0';
            textBox_Dependencia.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Dependencia.PlaceholderText = "";
            textBox_Dependencia.ReadOnly = false;
            textBox_Dependencia.SelectionStart = 0;
            textBox_Dependencia.ShowError = false;
            textBox_Dependencia.Size = new System.Drawing.Size(326, 21);
            textBox_Dependencia.TabIndex = 0;
            textBox_Dependencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Dependencia.TextValue = "";
            textBox_Dependencia.TextChanged += TextBox_Dependencia_TextChanged;
            // 
            // label_Domicilio
            // 
            label_Domicilio.AutoSize = true;
            label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Domicilio.Location = new System.Drawing.Point(48, 97);
            label_Domicilio.Name = "label_Domicilio";
            label_Domicilio.Size = new System.Drawing.Size(90, 16);
            label_Domicilio.TabIndex = 2;
            label_Domicilio.Text = "DOMICILIO :";
            // 
            // label_Dependencia
            // 
            label_Dependencia.AutoSize = true;
            label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dependencia.Location = new System.Drawing.Point(15, 61);
            label_Dependencia.Name = "label_Dependencia";
            label_Dependencia.Size = new System.Drawing.Size(123, 16);
            label_Dependencia.TabIndex = 1;
            label_Dependencia.Text = "DEPENDENCIA :";
            // 
            // label_NuevaDep
            // 
            label_NuevaDep.AutoSize = true;
            label_NuevaDep.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_NuevaDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_NuevaDep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_NuevaDep.Location = new System.Drawing.Point(140, 0);
            label_NuevaDep.Name = "label_NuevaDep";
            label_NuevaDep.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            label_NuevaDep.Size = new System.Drawing.Size(253, 24);
            label_NuevaDep.TabIndex = 0;
            label_NuevaDep.Text = "NUEVA DEPENDENCIA";
            // 
            // pictureBox_CheckAgregarSellos
            // 
            pictureBox_CheckAgregarSellos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_CheckAgregarSellos.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_CheckAgregarSellos.Image = Properties.Resources.check_Personalizado;
            pictureBox_CheckAgregarSellos.Location = new System.Drawing.Point(186, 200);
            pictureBox_CheckAgregarSellos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_CheckAgregarSellos.Name = "pictureBox_CheckAgregarSellos";
            pictureBox_CheckAgregarSellos.Size = new System.Drawing.Size(30, 32);
            pictureBox_CheckAgregarSellos.TabIndex = 68;
            pictureBox_CheckAgregarSellos.TabStop = false;
            // 
            // NuevaDependencia
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(569, 376);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuevaDependencia";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "AGREGAR NUEVA DEPENDENCIA";
            HelpButtonClicked += NuevaDependencia_HelpButtonClicked;
            Load += NuevaDependencia_Load;
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CheckAgregarSellos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_NuevaDep;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Domicilio;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Dependencia;
        private System.Windows.Forms.Label label_Domicilio;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_AgregarSellos;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.CheckBox checkBox_AgregarSellos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.HelpProvider help_NuevaDependencia;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Partido;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Localidad;
        private System.Windows.Forms.Label label_Partido;
        private System.Windows.Forms.Label label_Localidad;
        private System.Windows.Forms.PictureBox pictureBox_CheckAgregarSellos;
    }
}