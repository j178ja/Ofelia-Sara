namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Registro_de_personal
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPersonal));
            panel1 = new System.Windows.Forms.Panel();
            panel_ControlesInferiores = new System.Windows.Forms.Panel();
            btn_Registrar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            panel_PersonalSeleccionado = new System.Windows.Forms.Panel();
            btn_AgregarPersonal = new System.Windows.Forms.Button();
            textBox_NumeroLegajo = new Controles.General.CustomTextBox();
            lbl_Legajo = new System.Windows.Forms.Label();
            label_TITULO = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            panel_ControlesInferiores.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel_ControlesInferiores);
            panel1.Controls.Add(panel_PersonalSeleccionado);
            panel1.Controls.Add(btn_AgregarPersonal);
            panel1.Controls.Add(textBox_NumeroLegajo);
            panel1.Controls.Add(lbl_Legajo);
            panel1.Location = new System.Drawing.Point(20, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(671, 190);
            panel1.TabIndex = 2;
            // 
            // panel_ControlesInferiores
            // 
            panel_ControlesInferiores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel_ControlesInferiores.BackColor = System.Drawing.Color.Transparent;
            panel_ControlesInferiores.Controls.Add(btn_Registrar);
            panel_ControlesInferiores.Controls.Add(btn_Guardar);
            panel_ControlesInferiores.Location = new System.Drawing.Point(164, 99);
            panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            panel_ControlesInferiores.Size = new System.Drawing.Size(386, 88);
            panel_ControlesInferiores.TabIndex = 39;
            // 
            // btn_Registrar
            // 
            btn_Registrar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Registrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_Registrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btn_Registrar.Location = new System.Drawing.Point(18, 10);
            btn_Registrar.Margin = new System.Windows.Forms.Padding(0);
            btn_Registrar.Name = "btn_Registrar";
            btn_Registrar.Size = new System.Drawing.Size(116, 62);
            btn_Registrar.TabIndex = 36;
            btn_Registrar.Text = "REGISTRAR  EDITAR PERSONAL";
            toolTip1.SetToolTip(btn_Registrar, "Registrar un nuevo personal");
            btn_Registrar.UseVisualStyleBackColor = false;
            btn_Registrar.Click += Btn_Registrar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(272, 10);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 37;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // panel_PersonalSeleccionado
            // 
            panel_PersonalSeleccionado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel_PersonalSeleccionado.BackColor = System.Drawing.Color.Transparent;
            panel_PersonalSeleccionado.Location = new System.Drawing.Point(5, 75);
            panel_PersonalSeleccionado.Name = "panel_PersonalSeleccionado";
            panel_PersonalSeleccionado.Size = new System.Drawing.Size(663, 24);
            panel_PersonalSeleccionado.TabIndex = 38;
            // 
            // btn_AgregarPersonal
            // 
            btn_AgregarPersonal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_AgregarPersonal.BackColor = System.Drawing.Color.White;
            btn_AgregarPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarPersonal.FlatAppearance.BorderSize = 3;
            btn_AgregarPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_AgregarPersonal.Location = new System.Drawing.Point(496, 37);
            btn_AgregarPersonal.Name = "btn_AgregarPersonal";
            btn_AgregarPersonal.Size = new System.Drawing.Size(15, 23);
            btn_AgregarPersonal.TabIndex = 35;
            btn_AgregarPersonal.Text = "+";
            toolTip1.SetToolTip(btn_AgregarPersonal, "Agregar nueva ratificacion");
            btn_AgregarPersonal.UseVisualStyleBackColor = false;
            btn_AgregarPersonal.Click += Btn_AgregarPersonal_Click;
            // 
            // textBox_NumeroLegajo
            // 
            textBox_NumeroLegajo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_NumeroLegajo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_NumeroLegajo.BackColor = System.Drawing.Color.White;
            textBox_NumeroLegajo.ErrorColor = System.Drawing.Color.Red;
            textBox_NumeroLegajo.FocusColor = System.Drawing.Color.Blue;
            textBox_NumeroLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_NumeroLegajo.Location = new System.Drawing.Point(327, 38);
            textBox_NumeroLegajo.MaxLength = 32767;
            textBox_NumeroLegajo.Multiline = false;
            textBox_NumeroLegajo.Name = "textBox_NumeroLegajo";
            textBox_NumeroLegajo.PasswordChar = '\0';
            textBox_NumeroLegajo.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_NumeroLegajo.PlaceholderText = "";
            textBox_NumeroLegajo.ReadOnly = false;
            textBox_NumeroLegajo.SelectionStart = 0;
            textBox_NumeroLegajo.ShowError = false;
            textBox_NumeroLegajo.Size = new System.Drawing.Size(163, 22);
            textBox_NumeroLegajo.TabIndex = 34;
            textBox_NumeroLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_NumeroLegajo.TextValue = "";
            textBox_NumeroLegajo.Whidth = 0;
            textBox_NumeroLegajo.TextChanged += TextBox_NumeroLegajo_TextChanged;
            textBox_NumeroLegajo.KeyPress += TextBox_NumeroLegajo_KeyPress;
            // 
            // lbl_Legajo
            // 
            lbl_Legajo.AutoSize = true;
            lbl_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_Legajo.Location = new System.Drawing.Point(179, 41);
            lbl_Legajo.Name = "lbl_Legajo";
            lbl_Legajo.Size = new System.Drawing.Size(142, 16);
            lbl_Legajo.TabIndex = 33;
            lbl_Legajo.Text = "LEGAJO POLICIAL :";
            // 
            // label_TITULO
            // 
            label_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(245, 9);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            label_TITULO.Size = new System.Drawing.Size(248, 24);
            label_TITULO.TabIndex = 32;
            label_TITULO.Text = "BUSCAR PERSONAL";
            // 
            // BuscarPersonal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(714, 250);
            Controls.Add(panel1);
            Controls.Add(label_TITULO);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(734, 270);
            Name = "BuscarPersonal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = " SELECCIONAR PERSONAL POLICIAL";
            HelpButtonClicked += BuscarPersonal_HelpButtonClicked;
            Load += BuscarPersonal_Load;
            Controls.SetChildIndex(label_TITULO, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_ControlesInferiores.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Label lbl_Legajo;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_NumeroLegajo;
        private System.Windows.Forms.Button btn_AgregarPersonal;
        private System.Windows.Forms.Button btn_Registrar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Panel panel_PersonalSeleccionado;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_ControlesInferiores;
    }
}