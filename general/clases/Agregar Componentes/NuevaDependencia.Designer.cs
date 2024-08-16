namespace Ofelia_Sara.general.clases.Agregar_Componentes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaDependencia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_AgregarSellos = new System.Windows.Forms.CheckBox();
            this.label_AgregarSellos = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.textBox_Domicilio = new System.Windows.Forms.TextBox();
            this.textBox_Dependencia = new System.Windows.Forms.TextBox();
            this.label_Domicilio = new System.Windows.Forms.Label();
            this.label_Dependencia = new System.Windows.Forms.Label();
            this.label_NuevaDep = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.help_NuevaDependencia = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 7, 30, 16, 2, 58, 50);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.checkBox_AgregarSellos);
            this.panel1.Controls.Add(this.label_AgregarSellos);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.textBox_Domicilio);
            this.panel1.Controls.Add(this.textBox_Dependencia);
            this.panel1.Controls.Add(this.label_Domicilio);
            this.panel1.Controls.Add(this.label_Dependencia);
            this.panel1.Controls.Add(this.label_NuevaDep);
            this.panel1.Location = new System.Drawing.Point(21, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 281);
            this.panel1.TabIndex = 2;
            // 
            // checkBox_AgregarSellos
            // 
            this.checkBox_AgregarSellos.AutoSize = true;
            this.checkBox_AgregarSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_AgregarSellos.Location = new System.Drawing.Point(186, 135);
            this.checkBox_AgregarSellos.Name = "checkBox_AgregarSellos";
            this.checkBox_AgregarSellos.Size = new System.Drawing.Size(15, 14);
            this.checkBox_AgregarSellos.TabIndex = 2;
            this.checkBox_AgregarSellos.UseVisualStyleBackColor = true;
            this.checkBox_AgregarSellos.CheckedChanged += new System.EventHandler(this.checkBox_AgregarSellos_CheckedChanged);
            // 
            // label_AgregarSellos
            // 
            this.label_AgregarSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AgregarSellos.Location = new System.Drawing.Point(12, 130);
            this.label_AgregarSellos.Name = "label_AgregarSellos";
            this.label_AgregarSellos.Size = new System.Drawing.Size(207, 25);
            this.label_AgregarSellos.TabIndex = 20;
            this.label_AgregarSellos.Text = " AGREGAR SELLOS";
            this.label_AgregarSellos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(144, 196);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btn_Limpiar, "Limpiar Formulario");
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(395, 196);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_Guardar, "Guardar y cargar Dependencia");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // textBox_Domicilio
            // 
            this.textBox_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Domicilio.Location = new System.Drawing.Point(144, 97);
            this.textBox_Domicilio.Name = "textBox_Domicilio";
            this.textBox_Domicilio.Size = new System.Drawing.Size(326, 21);
            this.textBox_Domicilio.TabIndex = 1;
            // 
            // textBox_Dependencia
            // 
            this.textBox_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Dependencia.Location = new System.Drawing.Point(144, 60);
            this.textBox_Dependencia.Name = "textBox_Dependencia";
            this.textBox_Dependencia.Size = new System.Drawing.Size(326, 21);
            this.textBox_Dependencia.TabIndex = 0;
            this.textBox_Dependencia.TextChanged += new System.EventHandler(this.textBox_Dependencia_TextChanged);
            // 
            // label_Domicilio
            // 
            this.label_Domicilio.AutoSize = true;
            this.label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Domicilio.Location = new System.Drawing.Point(15, 97);
            this.label_Domicilio.Name = "label_Domicilio";
            this.label_Domicilio.Size = new System.Drawing.Size(90, 16);
            this.label_Domicilio.TabIndex = 2;
            this.label_Domicilio.Text = "DOMICILIO :";
            // 
            // label_Dependencia
            // 
            this.label_Dependencia.AutoSize = true;
            this.label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dependencia.Location = new System.Drawing.Point(15, 61);
            this.label_Dependencia.Name = "label_Dependencia";
            this.label_Dependencia.Size = new System.Drawing.Size(123, 16);
            this.label_Dependencia.TabIndex = 1;
            this.label_Dependencia.Text = "DEPENDENCIA :";
            // 
            // label_NuevaDep
            // 
            this.label_NuevaDep.AutoSize = true;
            this.label_NuevaDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_NuevaDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NuevaDep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_NuevaDep.Location = new System.Drawing.Point(140, 0);
            this.label_NuevaDep.Name = "label_NuevaDep";
            this.label_NuevaDep.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label_NuevaDep.Size = new System.Drawing.Size(253, 24);
            this.label_NuevaDep.TabIndex = 0;
            this.label_NuevaDep.Text = "NUEVA DEPENDENCIA";
            // 
            // NuevaDependencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 346);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaDependencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR NUEVA DEPENDENCIA";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.NuevaDependencia_HelpButtonClicked);
            this.Load += new System.EventHandler(this.NuevaDependencia_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_NuevaDep;
        private System.Windows.Forms.TextBox textBox_Domicilio;
        private System.Windows.Forms.TextBox textBox_Dependencia;
        private System.Windows.Forms.Label label_Domicilio;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_AgregarSellos;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.CheckBox checkBox_AgregarSellos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.HelpProvider help_NuevaDependencia;
    }
}