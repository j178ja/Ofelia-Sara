namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Acceso_Usuarios
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarEliminar));
            panel1 = new System.Windows.Forms.Panel();
            panel_Superior = new System.Windows.Forms.Panel();
            listBox_Seleccion = new System.Windows.Forms.ListBox();
            label_Seleccion = new System.Windows.Forms.Label();
            listBox_Datos = new System.Windows.Forms.ListBox();
            panel_Botones = new System.Windows.Forms.Panel();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Cancelar = new System.Windows.Forms.Button();
            btn_Editar = new System.Windows.Forms.Button();
            btn_Eliminar = new System.Windows.Forms.Button();
            label_TITULO = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            panel_Superior.SuspendLayout();
            panel_Botones.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel_Superior);
            panel1.Controls.Add(panel_Botones);
            panel1.Location = new System.Drawing.Point(15, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(630, 209);
            panel1.TabIndex = 2;
            // 
            // panel_Superior
            // 
            panel_Superior.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel_Superior.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel_Superior.Controls.Add(listBox_Seleccion);
            panel_Superior.Controls.Add(label_Seleccion);
            panel_Superior.Controls.Add(listBox_Datos);
            panel_Superior.Location = new System.Drawing.Point(57, 37);
            panel_Superior.Name = "panel_Superior";
            panel_Superior.Size = new System.Drawing.Size(514, 72);
            panel_Superior.TabIndex = 35;
            // 
            // listBox_Seleccion
            // 
            listBox_Seleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            listBox_Seleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            listBox_Seleccion.FormattingEnabled = true;
            listBox_Seleccion.Items.AddRange(new object[] { "FISCALIA", "INSTRUCTOR", "SECRETARIO", "DEDPENDENCIA", "PERSONAL " });
            listBox_Seleccion.Location = new System.Drawing.Point(260, 10);
            listBox_Seleccion.Name = "listBox_Seleccion";
            listBox_Seleccion.Size = new System.Drawing.Size(198, 4);
            listBox_Seleccion.TabIndex = 29;
            listBox_Seleccion.SelectedIndexChanged += ListBox_Seleccion_SelectedIndexChanged;
            // 
            // label_Seleccion
            // 
            label_Seleccion.AutoSize = true;
            label_Seleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Seleccion.Location = new System.Drawing.Point(38, 14);
            label_Seleccion.Name = "label_Seleccion";
            label_Seleccion.Size = new System.Drawing.Size(270, 20);
            label_Seleccion.TabIndex = 26;
            label_Seleccion.Text = "SELECCION DE ELEMENTOS:";
            // 
            // listBox_Datos
            // 
            listBox_Datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            listBox_Datos.FormattingEnabled = true;
            listBox_Datos.ItemHeight = 25;
            listBox_Datos.Location = new System.Drawing.Point(61, 45);
            listBox_Datos.Name = "listBox_Datos";
            listBox_Datos.Size = new System.Drawing.Size(397, 4);
            listBox_Datos.TabIndex = 30;
            listBox_Datos.SelectedIndexChanged += ListBox_Datos_SelectedIndexChanged;
            // 
            // panel_Botones
            // 
            panel_Botones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel_Botones.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel_Botones.Controls.Add(btn_Guardar);
            panel_Botones.Controls.Add(btn_Cancelar);
            panel_Botones.Controls.Add(btn_Editar);
            panel_Botones.Controls.Add(btn_Eliminar);
            panel_Botones.Location = new System.Drawing.Point(57, 112);
            panel_Botones.Name = "panel_Botones";
            panel_Botones.Size = new System.Drawing.Size(514, 91);
            panel_Botones.TabIndex = 34;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(382, 13);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 31;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Cancelar.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_Cancelar.BackgroundImage");
            btn_Cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Cancelar.Location = new System.Drawing.Point(61, 12);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new System.Drawing.Size(69, 68);
            btn_Cancelar.TabIndex = 15;
            toolTip1.SetToolTip(btn_Cancelar, "CANCELAR");
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // btn_Editar
            // 
            btn_Editar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Editar.BackgroundImage = Properties.Resources.editarUsuario;
            btn_Editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Editar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Editar.Location = new System.Drawing.Point(275, 13);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new System.Drawing.Size(75, 66);
            btn_Editar.TabIndex = 17;
            btn_Editar.UseVisualStyleBackColor = false;
            btn_Editar.Click += Btn_Editar_Click;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Eliminar.Image = (System.Drawing.Image)resources.GetObject("btn_Eliminar.Image");
            btn_Eliminar.Location = new System.Drawing.Point(163, 12);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new System.Drawing.Size(75, 67);
            btn_Eliminar.TabIndex = 32;
            btn_Eliminar.UseVisualStyleBackColor = false;
            btn_Eliminar.Click += Btn_Eliminar_Click;
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(111, 12);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            label_TITULO.Size = new System.Drawing.Size(425, 31);
            label_TITULO.TabIndex = 14;
            label_TITULO.Text = "ADMINISTRADOR DE ELEMENTOS";
            // 
            // ModificarEliminar
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(662, 262);
            Controls.Add(panel1);
            Controls.Add(label_TITULO);
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(589, 291);
            Name = "ModificarEliminar";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ADMINISTRADOR DE ELEMENTOS";
            HelpButtonClicked += Registro_HelpButtonClicked;
            Load += ModificarEliminar_Load;
            Controls.SetChildIndex(label_TITULO, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel_Superior.ResumeLayout(false);
            panel_Superior.PerformLayout();
            panel_Botones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
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