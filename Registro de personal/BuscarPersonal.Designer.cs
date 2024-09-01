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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPersonal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_ControlesInferiores = new System.Windows.Forms.Panel();
            this.btn_Registrar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.panel_PersonalSeleccionado = new System.Windows.Forms.Panel();
            this.btn_AgregarPersonal = new System.Windows.Forms.Button();
            this.textBox_NumeroLegajo = new System.Windows.Forms.TextBox();
            this.lbl_Legajo = new System.Windows.Forms.Label();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel_ControlesInferiores.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 8, 13, 17, 10, 52, 236);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.panel_ControlesInferiores);
            this.panel1.Controls.Add(this.panel_PersonalSeleccionado);
            this.panel1.Controls.Add(this.btn_AgregarPersonal);
            this.panel1.Controls.Add(this.textBox_NumeroLegajo);
            this.panel1.Controls.Add(this.lbl_Legajo);
            this.panel1.Controls.Add(this.lbl_Titulo);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 190);
            this.panel1.TabIndex = 2;
            // 
            // panel_ControlesInferiores
            // 
            this.panel_ControlesInferiores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_ControlesInferiores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel_ControlesInferiores.Controls.Add(this.btn_Registrar);
            this.panel_ControlesInferiores.Controls.Add(this.btn_Guardar);
            this.panel_ControlesInferiores.Location = new System.Drawing.Point(164, 99);
            this.panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            this.panel_ControlesInferiores.Size = new System.Drawing.Size(386, 88);
            this.panel_ControlesInferiores.TabIndex = 39;
            // 
            // btn_Registrar
            // 
            this.btn_Registrar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Registrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Registrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Registrar.Location = new System.Drawing.Point(18, 10);
            this.btn_Registrar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Registrar.Name = "btn_Registrar";
            this.btn_Registrar.Size = new System.Drawing.Size(116, 62);
            this.btn_Registrar.TabIndex = 36;
            this.btn_Registrar.Text = "REGISTRAR NUEVO PERSONAL";
            this.toolTip1.SetToolTip(this.btn_Registrar, "Registrar un nuevo personal");
            this.btn_Registrar.UseVisualStyleBackColor = false;
            this.btn_Registrar.Click += new System.EventHandler(this.btn_Registrar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(272, 10);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 37;
            this.toolTip1.SetToolTip(this.btn_Guardar, "GUARDAR personal seleccionado");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // panel_PersonalSeleccionado
            // 
            this.panel_PersonalSeleccionado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_PersonalSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.panel_PersonalSeleccionado.Location = new System.Drawing.Point(5, 75);
            this.panel_PersonalSeleccionado.Name = "panel_PersonalSeleccionado";
            this.panel_PersonalSeleccionado.Size = new System.Drawing.Size(663, 24);
            this.panel_PersonalSeleccionado.TabIndex = 38;
            // 
            // btn_AgregarPersonal
            // 
            this.btn_AgregarPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AgregarPersonal.BackColor = System.Drawing.Color.White;
            this.btn_AgregarPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarPersonal.FlatAppearance.BorderSize = 3;
            this.btn_AgregarPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarPersonal.Location = new System.Drawing.Point(478, 44);
            this.btn_AgregarPersonal.Name = "btn_AgregarPersonal";
            this.btn_AgregarPersonal.Size = new System.Drawing.Size(15, 23);
            this.btn_AgregarPersonal.TabIndex = 35;
            this.btn_AgregarPersonal.Text = "+";
            this.toolTip1.SetToolTip(this.btn_AgregarPersonal, "Agregar nueva ratificacion");
            this.btn_AgregarPersonal.UseVisualStyleBackColor = false;
            this.btn_AgregarPersonal.Click += new System.EventHandler(this.btn_AgregarPersonal_Click);
            // 
            // textBox_NumeroLegajo
            // 
            this.textBox_NumeroLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NumeroLegajo.Location = new System.Drawing.Point(309, 45);
            this.textBox_NumeroLegajo.Name = "textBox_NumeroLegajo";
            this.textBox_NumeroLegajo.Size = new System.Drawing.Size(163, 22);
            this.textBox_NumeroLegajo.TabIndex = 34;
            this.textBox_NumeroLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NumeroLegajo.TextChanged += new System.EventHandler(this.textBox_NumeroLegajo_TextChanged);
            this.textBox_NumeroLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NumeroLegajo_KeyPress);
            // 
            // lbl_Legajo
            // 
            this.lbl_Legajo.AutoSize = true;
            this.lbl_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Legajo.Location = new System.Drawing.Point(161, 48);
            this.lbl_Legajo.Name = "lbl_Legajo";
            this.lbl_Legajo.Size = new System.Drawing.Size(142, 16);
            this.lbl_Legajo.TabIndex = 33;
            this.lbl_Legajo.Text = "LEGAJO POLICIAL :";
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Titulo.Location = new System.Drawing.Point(227, 0);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbl_Titulo.Size = new System.Drawing.Size(228, 24);
            this.lbl_Titulo.TabIndex = 32;
            this.lbl_Titulo.Text = "BUSCAR PERSONAL";
            // 
            // BuscarPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(714, 241);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(734, 270);
            this.Name = "BuscarPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR PERSONAL POLICIAL";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.BuscarPersonal_HelpButtonClicked);
            this.Load += new System.EventHandler(this.BuscarPersonal_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_ControlesInferiores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Label lbl_Legajo;
        private System.Windows.Forms.TextBox textBox_NumeroLegajo;
        private System.Windows.Forms.Button btn_AgregarPersonal;
        private System.Windows.Forms.Button btn_Registrar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Panel panel_PersonalSeleccionado;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_ControlesInferiores;
    }
}