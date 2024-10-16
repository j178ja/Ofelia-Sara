namespace Ofelia_Sara.Acceso_Usuarios
{
    partial class ModificarEliminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarEliminar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Superior = new System.Windows.Forms.Panel();
            this.listBox_Seleccion = new System.Windows.Forms.ListBox();
            this.label_Seleccion = new System.Windows.Forms.Label();
            this.listBox_Datos = new System.Windows.Forms.ListBox();
            this.panel_Botones = new System.Windows.Forms.Panel();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.label_Titulo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel_Superior.SuspendLayout();
            this.panel_Botones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.panel_Superior);
            this.panel1.Controls.Add(this.panel_Botones);
            this.panel1.Controls.Add(this.label_Titulo);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 209);
            this.panel1.TabIndex = 2;
            // 
            // panel_Superior
            // 
            this.panel_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel_Superior.Controls.Add(this.listBox_Seleccion);
            this.panel_Superior.Controls.Add(this.label_Seleccion);
            this.panel_Superior.Controls.Add(this.listBox_Datos);
            this.panel_Superior.Location = new System.Drawing.Point(12, 37);
            this.panel_Superior.Name = "panel_Superior";
            this.panel_Superior.Size = new System.Drawing.Size(514, 72);
            this.panel_Superior.TabIndex = 35;
            // 
            // listBox_Seleccion
            // 
            this.listBox_Seleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox_Seleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Seleccion.FormattingEnabled = true;
            this.listBox_Seleccion.ItemHeight = 16;
            this.listBox_Seleccion.Items.AddRange(new object[] {
            "FISCALIA",
            "INSTRUCTOR",
            "SECRETARIO",
            "DEDPENDENCIA",
            "PERSONAL "});
            this.listBox_Seleccion.Location = new System.Drawing.Point(260, 10);
            this.listBox_Seleccion.Name = "listBox_Seleccion";
            this.listBox_Seleccion.Size = new System.Drawing.Size(198, 20);
            this.listBox_Seleccion.TabIndex = 29;
            this.listBox_Seleccion.SelectedIndexChanged += new System.EventHandler(this.ListBox_Seleccion_SelectedIndexChanged);
            // 
            // label_Seleccion
            // 
            this.label_Seleccion.AutoSize = true;
            this.label_Seleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seleccion.Location = new System.Drawing.Point(38, 14);
            this.label_Seleccion.Name = "label_Seleccion";
            this.label_Seleccion.Size = new System.Drawing.Size(216, 16);
            this.label_Seleccion.TabIndex = 26;
            this.label_Seleccion.Text = "SELECCION DE ELEMENTOS:";
            // 
            // listBox_Datos
            // 
            this.listBox_Datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Datos.FormattingEnabled = true;
            this.listBox_Datos.ItemHeight = 20;
            this.listBox_Datos.Location = new System.Drawing.Point(61, 45);
            this.listBox_Datos.Name = "listBox_Datos";
            this.listBox_Datos.Size = new System.Drawing.Size(397, 24);
            this.listBox_Datos.TabIndex = 30;
            this.listBox_Datos.SelectedIndexChanged += new System.EventHandler(this.ListBox_Datos_SelectedIndexChanged);
            // 
            // panel_Botones
            // 
            this.panel_Botones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Botones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel_Botones.Controls.Add(this.btn_Guardar);
            this.panel_Botones.Controls.Add(this.btn_Cancelar);
            this.panel_Botones.Controls.Add(this.btn_Editar);
            this.panel_Botones.Controls.Add(this.btn_Eliminar);
            this.panel_Botones.Location = new System.Drawing.Point(10, 112);
            this.panel_Botones.Name = "panel_Botones";
            this.panel_Botones.Size = new System.Drawing.Size(514, 91);
            this.panel_Botones.TabIndex = 34;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(382, 13);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 31;
            this.toolTip1.SetToolTip(this.btn_Guardar, "GUARDAR CAMBIOS");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancelar.BackgroundImage")));
            this.btn_Cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Cancelar.Location = new System.Drawing.Point(61, 12);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(69, 68);
            this.btn_Cancelar.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btn_Cancelar, "CANCELAR");
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Editar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Editar.BackgroundImage")));
            this.btn_Editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Editar.Location = new System.Drawing.Point(275, 13);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(75, 66);
            this.btn_Editar.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btn_Editar, "EDITAR");
            this.btn_Editar.UseVisualStyleBackColor = false;
            this.btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Eliminar.Image")));
            this.btn_Eliminar.Location = new System.Drawing.Point(163, 12);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(75, 67);
            this.btn_Eliminar.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btn_Eliminar, "ELIMINAR ELEMENTO");
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // label_Titulo
            // 
            this.label_Titulo.AutoSize = true;
            this.label_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Titulo.Location = new System.Drawing.Point(91, 0);
            this.label_Titulo.Name = "label_Titulo";
            this.label_Titulo.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_Titulo.Size = new System.Drawing.Size(360, 26);
            this.label_Titulo.TabIndex = 14;
            this.label_Titulo.Text = "ADMINISTRADOR DE ELEMENTOS";
            // 
            // ModificarEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(573, 252);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(589, 291);
            this.Name = "ModificarEliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMINISTRADOR DE ELEMENTOS";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Registro_HelpButtonClicked);
            this.Load += new System.EventHandler(this.ModificarEliminar_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Superior.ResumeLayout(false);
            this.panel_Superior.PerformLayout();
            this.panel_Botones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Titulo;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label_Seleccion;
        private System.Windows.Forms.ListBox listBox_Seleccion;
        private System.Windows.Forms.ListBox listBox_Datos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Panel panel_Botones;
        private System.Windows.Forms.Panel panel_Superior;
    }
}