namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class ActaDenuncia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActaDenuncia));
            panel1 = new System.Windows.Forms.Panel();
            radioButton_Acta = new System.Windows.Forms.RadioButton();
            groupBox_SeleccionPlantilla = new System.Windows.Forms.GroupBox();
            comboBox_ModeloActuacion = new Controles.General.CustomComboBox();
            radioButton_ActuacionEstandar = new System.Windows.Forms.RadioButton();
            radioButton_ModeloActuacion = new System.Windows.Forms.RadioButton();
            radioButton_Denuncia = new System.Windows.Forms.RadioButton();
            pictureBox_Acta = new System.Windows.Forms.PictureBox();
            pictureBox_Denuncia = new System.Windows.Forms.PictureBox();
            panel_ControlesInferiores = new Controles.General.PanelConBordeNeon();
            btn_Imprimir = new System.Windows.Forms.Button();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Buscar = new System.Windows.Forms.Button();
            panel_TipoActuacion = new System.Windows.Forms.Panel();
            customComboBox1 = new Controles.General.CustomComboBox();
            label_TITULO = new System.Windows.Forms.Label();
            panel_Actuacion = new System.Windows.Forms.Panel();
            label_TipoActuacion = new System.Windows.Forms.Label();
            richTextBox_Actuacion = new System.Windows.Forms.RichTextBox();
            panel1.SuspendLayout();
            groupBox_SeleccionPlantilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Acta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Denuncia).BeginInit();
            panel_ControlesInferiores.SuspendLayout();
            panel_Actuacion.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(radioButton_Acta);
            panel1.Controls.Add(groupBox_SeleccionPlantilla);
            panel1.Controls.Add(radioButton_Denuncia);
            panel1.Controls.Add(pictureBox_Acta);
            panel1.Controls.Add(pictureBox_Denuncia);
            panel1.Location = new System.Drawing.Point(30, 33);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(740, 165);
            panel1.TabIndex = 1;
            // 
            // radioButton_Acta
            // 
            radioButton_Acta.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Acta.Location = new System.Drawing.Point(129, 15);
            radioButton_Acta.Name = "radioButton_Acta";
            radioButton_Acta.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            radioButton_Acta.Size = new System.Drawing.Size(200, 39);
            radioButton_Acta.TabIndex = 36;
            radioButton_Acta.TabStop = true;
            radioButton_Acta.Text = "   ACTA DE PROCEDIMIENTO";
            radioButton_Acta.UseVisualStyleBackColor = true;
            radioButton_Acta.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // groupBox_SeleccionPlantilla
            // 
            groupBox_SeleccionPlantilla.Controls.Add(comboBox_ModeloActuacion);
            groupBox_SeleccionPlantilla.Controls.Add(radioButton_ActuacionEstandar);
            groupBox_SeleccionPlantilla.Controls.Add(radioButton_ModeloActuacion);
            groupBox_SeleccionPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            groupBox_SeleccionPlantilla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox_SeleccionPlantilla.Location = new System.Drawing.Point(75, 71);
            groupBox_SeleccionPlantilla.Name = "groupBox_SeleccionPlantilla";
            groupBox_SeleccionPlantilla.Size = new System.Drawing.Size(600, 83);
            groupBox_SeleccionPlantilla.TabIndex = 40;
            groupBox_SeleccionPlantilla.TabStop = false;
            groupBox_SeleccionPlantilla.Text = "Selecione plantilla a trabajar";
            // 
            // comboBox_ModeloActuacion
            // 
            comboBox_ModeloActuacion.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_ModeloActuacion.ArrowImage");
            comboBox_ModeloActuacion.ArrowPictureBox = null;
            comboBox_ModeloActuacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_ModeloActuacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_ModeloActuacion.BackColor = System.Drawing.Color.White;
            comboBox_ModeloActuacion.DataSource = null;
            comboBox_ModeloActuacion.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_ModeloActuacion.DefaultImage");
            comboBox_ModeloActuacion.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_ModeloActuacion.DisabledImage");
            comboBox_ModeloActuacion.DisplayMember = null;
            comboBox_ModeloActuacion.DropDownHeight = 96;
            comboBox_ModeloActuacion.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_ModeloActuacion.DroppedDown = false;
            comboBox_ModeloActuacion.ErrorColor = System.Drawing.Color.Red;
            comboBox_ModeloActuacion.FocusColor = System.Drawing.Color.Blue;
            comboBox_ModeloActuacion.ForeColor = System.Drawing.Color.Gray;
            comboBox_ModeloActuacion.Location = new System.Drawing.Point(87, 54);
            comboBox_ModeloActuacion.MaxDropDownItems = 5;
            comboBox_ModeloActuacion.Name = "comboBox_ModeloActuacion";
            comboBox_ModeloActuacion.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_ModeloActuacion.PlaceholderText = " SELECCIONE MODELO DE ACTUACIÓN";
            comboBox_ModeloActuacion.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_ModeloActuacion.PressedImage");
            comboBox_ModeloActuacion.SelectedIndex = -1;
            comboBox_ModeloActuacion.SelectedItem = null;
            comboBox_ModeloActuacion.SelectedText = "";
            comboBox_ModeloActuacion.SelectionStart = 0;
            comboBox_ModeloActuacion.ShowError = false;
            comboBox_ModeloActuacion.Size = new System.Drawing.Size(403, 23);
            comboBox_ModeloActuacion.TabIndex = 2;
            comboBox_ModeloActuacion.Text = "comboBox_ModeloActuacion";
            comboBox_ModeloActuacion.TextValue = " ";
            // 
            // radioButton_ActuacionEstandar
            // 
            radioButton_ActuacionEstandar.AutoSize = true;
            radioButton_ActuacionEstandar.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_ActuacionEstandar.Location = new System.Drawing.Point(346, 22);
            radioButton_ActuacionEstandar.Name = "radioButton_ActuacionEstandar";
            radioButton_ActuacionEstandar.Size = new System.Drawing.Size(183, 24);
            radioButton_ActuacionEstandar.TabIndex = 1;
            radioButton_ActuacionEstandar.TabStop = true;
            radioButton_ActuacionEstandar.Text = "Actuación ESTANDAR";
            radioButton_ActuacionEstandar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton_ActuacionEstandar.UseVisualStyleBackColor = true;
            radioButton_ActuacionEstandar.CheckedChanged += RadioButton_ActuacionEstandar_CheckedChanged;
            // 
            // radioButton_ModeloActuacion
            // 
            radioButton_ModeloActuacion.AutoSize = true;
            radioButton_ModeloActuacion.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_ModeloActuacion.Location = new System.Drawing.Point(87, 22);
            radioButton_ModeloActuacion.Name = "radioButton_ModeloActuacion";
            radioButton_ModeloActuacion.Size = new System.Drawing.Size(193, 24);
            radioButton_ModeloActuacion.TabIndex = 0;
            radioButton_ModeloActuacion.TabStop = true;
            radioButton_ModeloActuacion.Text = "MODELOS de actuación";
            radioButton_ModeloActuacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton_ModeloActuacion.UseVisualStyleBackColor = true;
            radioButton_ModeloActuacion.CheckedChanged += RadioButton_ModeloActuacion_CheckedChanged;
            // 
            // radioButton_Denuncia
            // 
            radioButton_Denuncia.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Denuncia.Location = new System.Drawing.Point(495, 15);
            radioButton_Denuncia.Name = "radioButton_Denuncia";
            radioButton_Denuncia.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            radioButton_Denuncia.Size = new System.Drawing.Size(159, 39);
            radioButton_Denuncia.TabIndex = 35;
            radioButton_Denuncia.TabStop = true;
            radioButton_Denuncia.Text = "   DENUNCIA PENAL";
            radioButton_Denuncia.UseVisualStyleBackColor = true;
            radioButton_Denuncia.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // pictureBox_Acta
            // 
            pictureBox_Acta.BackgroundImage = Properties.Resources.esposas;
            pictureBox_Acta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_Acta.Location = new System.Drawing.Point(87, 16);
            pictureBox_Acta.Name = "pictureBox_Acta";
            pictureBox_Acta.Size = new System.Drawing.Size(40, 39);
            pictureBox_Acta.TabIndex = 37;
            pictureBox_Acta.TabStop = false;
            // 
            // pictureBox_Denuncia
            // 
            pictureBox_Denuncia.BackgroundImage = Properties.Resources.denuncia_penal;
            pictureBox_Denuncia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_Denuncia.Location = new System.Drawing.Point(453, 15);
            pictureBox_Denuncia.Name = "pictureBox_Denuncia";
            pictureBox_Denuncia.Size = new System.Drawing.Size(40, 39);
            pictureBox_Denuncia.TabIndex = 38;
            pictureBox_Denuncia.TabStop = false;
            // 
            // panel_ControlesInferiores
            // 
            panel_ControlesInferiores.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            panel_ControlesInferiores.BorderRadius = 10;
            panel_ControlesInferiores.CamposCompletos = false;
            panel_ControlesInferiores.Controls.Add(btn_Imprimir);
            panel_ControlesInferiores.Controls.Add(btn_Limpiar);
            panel_ControlesInferiores.Controls.Add(btn_Guardar);
            panel_ControlesInferiores.Controls.Add(btn_Buscar);
            panel_ControlesInferiores.EstaContraido = false;
            panel_ControlesInferiores.Location = new System.Drawing.Point(30, 296);
            panel_ControlesInferiores.Name = "panel_ControlesInferiores";
            panel_ControlesInferiores.NeonColorCompleto = System.Drawing.Color.FromArgb(0, 255, 0);
            panel_ControlesInferiores.NeonColorIncompleto = System.Drawing.Color.FromArgb(255, 0, 0);
            panel_ControlesInferiores.Size = new System.Drawing.Size(740, 102);
            panel_ControlesInferiores.SombraColor = System.Drawing.Color.FromArgb(200, 0, 198, 255);
            panel_ControlesInferiores.TabIndex = 95;
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Imprimir.Image = (System.Drawing.Image)resources.GetObject("btn_Imprimir.Image");
            btn_Imprimir.Location = new System.Drawing.Point(580, 6);
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.Size = new System.Drawing.Size(106, 92);
            btn_Imprimir.TabIndex = 24;
            btn_Imprimir.UseVisualStyleBackColor = false;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(418, 19);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 25;
            btn_Limpiar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(240, 19);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 23;
            btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Buscar.Image = (System.Drawing.Image)resources.GetObject("btn_Buscar.Image");
            btn_Buscar.Location = new System.Drawing.Point(61, 19);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new System.Drawing.Size(75, 67);
            btn_Buscar.TabIndex = 26;
            btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // panel_TipoActuacion
            // 
            panel_TipoActuacion.Location = new System.Drawing.Point(0, 0);
            panel_TipoActuacion.Name = "panel_TipoActuacion";
            panel_TipoActuacion.Size = new System.Drawing.Size(200, 100);
            panel_TipoActuacion.TabIndex = 0;
            // 
            // customComboBox1
            // 
            customComboBox1.ArrowImage = (System.Drawing.Image)resources.GetObject("customComboBox1.ArrowImage");
            customComboBox1.ArrowPictureBox = null;
            customComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            customComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            customComboBox1.BackColor = System.Drawing.Color.White;
            customComboBox1.DataSource = null;
            customComboBox1.DefaultImage = (System.Drawing.Image)resources.GetObject("customComboBox1.DefaultImage");
            customComboBox1.DisabledImage = (System.Drawing.Image)resources.GetObject("customComboBox1.DisabledImage");
            customComboBox1.DisplayMember = null;
            customComboBox1.DropDownHeight = 96;
            customComboBox1.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            customComboBox1.DroppedDown = false;
            customComboBox1.ErrorColor = System.Drawing.Color.Red;
            customComboBox1.FocusColor = System.Drawing.Color.Blue;
            customComboBox1.ForeColor = System.Drawing.Color.Gray;
            customComboBox1.Location = new System.Drawing.Point(69, 92);
            customComboBox1.MaxDropDownItems = 5;
            customComboBox1.Name = "customComboBox1";
            customComboBox1.PlaceholderColor = System.Drawing.Color.Gray;
            customComboBox1.PlaceholderText = " ";
            customComboBox1.PressedImage = (System.Drawing.Image)resources.GetObject("customComboBox1.PressedImage");
            customComboBox1.SelectedIndex = -1;
            customComboBox1.SelectedItem = null;
            customComboBox1.SelectedText = "";
            customComboBox1.SelectionStart = 0;
            customComboBox1.ShowError = false;
            customComboBox1.Size = new System.Drawing.Size(0, 0);
            customComboBox1.TabIndex = 39;
            customComboBox1.Text = "customComboBox1";
            customComboBox1.TextValue = " ";
            // 
            // label_TITULO
            // 
            label_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label_TITULO.AutoSize = true;
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(254, 9);
            label_TITULO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            label_TITULO.Size = new System.Drawing.Size(296, 29);
            label_TITULO.TabIndex = 32;
            label_TITULO.Text = "TIPO DE ACTUACION";
            // 
            // panel_Actuacion
            // 
            panel_Actuacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel_Actuacion.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel_Actuacion.Controls.Add(label_TipoActuacion);
            panel_Actuacion.Controls.Add(richTextBox_Actuacion);
            panel_Actuacion.Location = new System.Drawing.Point(30, 204);
            panel_Actuacion.Name = "panel_Actuacion";
            panel_Actuacion.Size = new System.Drawing.Size(740, 86);
            panel_Actuacion.TabIndex = 96;
            // 
            // label_TipoActuacion
            // 
            label_TipoActuacion.AutoSize = true;
            label_TipoActuacion.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TipoActuacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TipoActuacion.ForeColor = System.Drawing.Color.PaleGreen;
            label_TipoActuacion.Location = new System.Drawing.Point(280, -3);
            label_TipoActuacion.Name = "label_TipoActuacion";
            label_TipoActuacion.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label_TipoActuacion.Size = new System.Drawing.Size(137, 28);
            label_TipoActuacion.TabIndex = 1;
            label_TipoActuacion.Text = "ACTUACION";
            label_TipoActuacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox_Actuacion
            // 
            richTextBox_Actuacion.Location = new System.Drawing.Point(15, 19);
            richTextBox_Actuacion.Name = "richTextBox_Actuacion";
            richTextBox_Actuacion.Size = new System.Drawing.Size(706, 49);
            richTextBox_Actuacion.TabIndex = 0;
            richTextBox_Actuacion.Text = "";
            // 
            // ActaDenuncia
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 448);
            Controls.Add(panel_Actuacion);
            Controls.Add(panel_ControlesInferiores);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Name = "ActaDenuncia";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DENUNCIA / ACTA DE PROCEDIMIENTO";
            Load += ActaDenuncia_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            Controls.SetChildIndex(panel_ControlesInferiores, 0);
            Controls.SetChildIndex(panel_Actuacion, 0);
            panel1.ResumeLayout(false);
            groupBox_SeleccionPlantilla.ResumeLayout(false);
            groupBox_SeleccionPlantilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Acta).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Denuncia).EndInit();
            panel_ControlesInferiores.ResumeLayout(false);
            panel_Actuacion.ResumeLayout(false);
            panel_Actuacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.RadioButton radioButton_Acta;
        private System.Windows.Forms.PictureBox pictureBox_Denuncia;
        private System.Windows.Forms.PictureBox pictureBox_Acta;
        private System.Windows.Forms.RadioButton radioButton_Denuncia;
        private Controles.General.CustomComboBox customComboBox1;
        private System.Windows.Forms.GroupBox groupBox_SeleccionPlantilla;
        private Controles.General.CustomComboBox comboBox_ModeloActuacion;
        private System.Windows.Forms.RadioButton radioButton_ActuacionEstandar;
        private System.Windows.Forms.RadioButton radioButton_ModeloActuacion;
        private System.Windows.Forms.Panel panel_TipoActuacion;
        private Controles.General.PanelConBordeNeon panel_ControlesInferiores;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Panel panel_Actuacion;
        private System.Windows.Forms.RichTextBox richTextBox_Actuacion;
        private System.Windows.Forms.Label label_TipoActuacion;
    }
}