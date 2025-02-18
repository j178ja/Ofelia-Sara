namespace Ofelia_Sara.Formularios.General
{
    partial class IMPRESION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IMPRESION));
            panel1 = new System.Windows.Forms.Panel();
            panel_informacionSeleccion = new System.Windows.Forms.Panel();
            label_Seleccionados = new System.Windows.Forms.Label();
            label_CantidadArchivos = new System.Windows.Forms.Label();
            label_Incompletos = new System.Windows.Forms.Label();
            btn_DescargarCarpeta = new System.Windows.Forms.Button();
            btn_BuscarTarea = new System.Windows.Forms.Button();
            comboBox_Buscar = new Controles.General.CustomComboBox();
            ContenedorActuaciones = new System.Windows.Forms.TableLayoutPanel();
            btn_Imprimir = new System.Windows.Forms.Button();
            panel_DatosInstruccion = new Controles.General.PanelConBordeNeon();
            btn_AmpliarReducir_INSTRUCCION = new System.Windows.Forms.Button();
            pictureBox_PanelInstruccion = new System.Windows.Forms.PictureBox();
            label_DatosInstruccion = new System.Windows.Forms.Label();
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel_informacionSeleccion.SuspendLayout();
            panel_DatosInstruccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelInstruccion).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel_informacionSeleccion);
            panel1.Controls.Add(btn_DescargarCarpeta);
            panel1.Controls.Add(btn_BuscarTarea);
            panel1.Controls.Add(comboBox_Buscar);
            panel1.Controls.Add(ContenedorActuaciones);
            panel1.Controls.Add(btn_Imprimir);
            panel1.Controls.Add(panel_DatosInstruccion);
            panel1.Location = new System.Drawing.Point(18, 20);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1017, 632);
            panel1.TabIndex = 1;
            // 
            // panel_informacionSeleccion
            // 
            panel_informacionSeleccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel_informacionSeleccion.BackColor = System.Drawing.SystemColors.ButtonFace;
            panel_informacionSeleccion.Controls.Add(label_Seleccionados);
            panel_informacionSeleccion.Controls.Add(label_CantidadArchivos);
            panel_informacionSeleccion.Controls.Add(label_Incompletos);
            panel_informacionSeleccion.Location = new System.Drawing.Point(366, 521);
            panel_informacionSeleccion.Name = "panel_informacionSeleccion";
            panel_informacionSeleccion.Size = new System.Drawing.Size(285, 92);
            panel_informacionSeleccion.TabIndex = 40;
            // 
            // label_Seleccionados
            // 
            label_Seleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Seleccionados.ForeColor = System.Drawing.Color.Teal;
            label_Seleccionados.Location = new System.Drawing.Point(9, 67);
            label_Seleccionados.Name = "label_Seleccionados";
            label_Seleccionados.Size = new System.Drawing.Size(269, 20);
            label_Seleccionados.TabIndex = 2;
            label_Seleccionados.Text = "label1";
            label_Seleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CantidadArchivos
            // 
            label_CantidadArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_CantidadArchivos.ForeColor = System.Drawing.Color.DodgerBlue;
            label_CantidadArchivos.Location = new System.Drawing.Point(3, 8);
            label_CantidadArchivos.Name = "label_CantidadArchivos";
            label_CantidadArchivos.Size = new System.Drawing.Size(279, 20);
            label_CantidadArchivos.TabIndex = 1;
            label_CantidadArchivos.Text = "label1";
            label_CantidadArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Incompletos
            // 
            label_Incompletos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Incompletos.ForeColor = System.Drawing.Color.Crimson;
            label_Incompletos.Location = new System.Drawing.Point(3, 36);
            label_Incompletos.Name = "label_Incompletos";
            label_Incompletos.Size = new System.Drawing.Size(275, 20);
            label_Incompletos.TabIndex = 0;
            label_Incompletos.Text = "label1";
            label_Incompletos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_DescargarCarpeta
            // 
            btn_DescargarCarpeta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_DescargarCarpeta.BackColor = System.Drawing.Color.SkyBlue;
            btn_DescargarCarpeta.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_DescargarCarpeta.Image = (System.Drawing.Image)resources.GetObject("btn_DescargarCarpeta.Image");
            btn_DescargarCarpeta.Location = new System.Drawing.Point(235, 521);
            btn_DescargarCarpeta.Name = "btn_DescargarCarpeta";
            btn_DescargarCarpeta.Size = new System.Drawing.Size(106, 92);
            btn_DescargarCarpeta.TabIndex = 39;
            btn_DescargarCarpeta.UseVisualStyleBackColor = false;
            // 
            // btn_BuscarTarea
            // 
            btn_BuscarTarea.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_BuscarTarea.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_BuscarTarea.BackgroundImage");
            btn_BuscarTarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_BuscarTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_BuscarTarea.FlatAppearance.BorderSize = 0;
            btn_BuscarTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_BuscarTarea.Location = new System.Drawing.Point(595, 25);
            btn_BuscarTarea.Name = "btn_BuscarTarea";
            btn_BuscarTarea.Size = new System.Drawing.Size(35, 35);
            btn_BuscarTarea.TabIndex = 38;
            btn_BuscarTarea.UseVisualStyleBackColor = true;
            // 
            // comboBox_Buscar
            // 
            comboBox_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            comboBox_Buscar.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.ArrowImage");
            comboBox_Buscar.ArrowPictureBox = null;
            comboBox_Buscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Buscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Buscar.BackColor = System.Drawing.Color.White;
            comboBox_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_Buscar.DataSource = null;
            comboBox_Buscar.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.DefaultImage");
            comboBox_Buscar.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.DisabledImage");
            comboBox_Buscar.DisplayMember = null;
            comboBox_Buscar.DropDownHeight = 96;
            comboBox_Buscar.DropDownStyle = Controles.General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Buscar.DroppedDown = false;
            comboBox_Buscar.ErrorColor = System.Drawing.Color.Red;
            comboBox_Buscar.FocusColor = System.Drawing.Color.Blue;
            comboBox_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Buscar.ForeColor = System.Drawing.Color.Gray;
            comboBox_Buscar.Location = new System.Drawing.Point(634, 28);
            comboBox_Buscar.MaxDropDownItems = 5;
            comboBox_Buscar.Name = "comboBox_Buscar";
            comboBox_Buscar.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Buscar.PlaceholderText = " ";
            comboBox_Buscar.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.PressedImage");
            comboBox_Buscar.SelectedIndex = -1;
            comboBox_Buscar.SelectedItem = null;
            comboBox_Buscar.SelectedText = "";
            comboBox_Buscar.SelectionStart = 0;
            comboBox_Buscar.ShowError = false;
            comboBox_Buscar.Size = new System.Drawing.Size(294, 28);
            comboBox_Buscar.TabIndex = 37;
            comboBox_Buscar.Text = " ";
            comboBox_Buscar.TextValue = " ";
            // 
            // ContenedorActuaciones
            // 
            ContenedorActuaciones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            ContenedorActuaciones.ColumnCount = 3;
            ContenedorActuaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            ContenedorActuaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            ContenedorActuaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            ContenedorActuaciones.Location = new System.Drawing.Point(14, 77);
            ContenedorActuaciones.Name = "ContenedorActuaciones";
            ContenedorActuaciones.RowCount = 12;
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            ContenedorActuaciones.Size = new System.Drawing.Size(993, 417);
            ContenedorActuaciones.TabIndex = 36;
           
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Imprimir.Image = (System.Drawing.Image)resources.GetObject("btn_Imprimir.Image");
            btn_Imprimir.Location = new System.Drawing.Point(677, 523);
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.Size = new System.Drawing.Size(106, 92);
            btn_Imprimir.TabIndex = 25;
            btn_Imprimir.UseVisualStyleBackColor = false;
            // 
            // panel_DatosInstruccion
            // 
            panel_DatosInstruccion.BorderRadius = 10;
            panel_DatosInstruccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel_DatosInstruccion.CamposCompletos = false;
            panel_DatosInstruccion.Controls.Add(btn_AmpliarReducir_INSTRUCCION);
            panel_DatosInstruccion.Controls.Add(pictureBox_PanelInstruccion);
            panel_DatosInstruccion.Controls.Add(label_DatosInstruccion);
            panel_DatosInstruccion.EstaContraido = false;
            panel_DatosInstruccion.Location = new System.Drawing.Point(14, 28);
            panel_DatosInstruccion.Name = "panel_DatosInstruccion";
            panel_DatosInstruccion.NeonColorCompleto = System.Drawing.Color.FromArgb(0, 255, 0);
            panel_DatosInstruccion.NeonColorIncompleto = System.Drawing.Color.FromArgb(255, 0, 0);
            panel_DatosInstruccion.Size = new System.Drawing.Size(393, 30);
            panel_DatosInstruccion.SombraColor = System.Drawing.Color.FromArgb(200, 0, 198, 255);
            panel_DatosInstruccion.TabIndex = 0;
            // 
            // btn_AmpliarReducir_INSTRUCCION
            // 
            btn_AmpliarReducir_INSTRUCCION.BackColor = System.Drawing.SystemColors.ButtonFace;
            btn_AmpliarReducir_INSTRUCCION.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AmpliarReducir_INSTRUCCION.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 192, 192);
            btn_AmpliarReducir_INSTRUCCION.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btn_AmpliarReducir_INSTRUCCION.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            btn_AmpliarReducir_INSTRUCCION.Image = (System.Drawing.Image)resources.GetObject("btn_AmpliarReducir_INSTRUCCION.Image");
            btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(351, 0);
            btn_AmpliarReducir_INSTRUCCION.Name = "btn_AmpliarReducir_INSTRUCCION";
            btn_AmpliarReducir_INSTRUCCION.Size = new System.Drawing.Size(31, 23);
            btn_AmpliarReducir_INSTRUCCION.TabIndex = 84;
            btn_AmpliarReducir_INSTRUCCION.UseVisualStyleBackColor = false;
            // 
            // pictureBox_PanelInstruccion
            // 
            pictureBox_PanelInstruccion.BackColor = System.Drawing.Color.Transparent;
            pictureBox_PanelInstruccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_PanelInstruccion.Location = new System.Drawing.Point(278, 0);
            pictureBox_PanelInstruccion.Name = "pictureBox_PanelInstruccion";
            pictureBox_PanelInstruccion.Size = new System.Drawing.Size(29, 22);
            pictureBox_PanelInstruccion.TabIndex = 34;
            pictureBox_PanelInstruccion.TabStop = false;
            // 
            // label_DatosInstruccion
            // 
            label_DatosInstruccion.AutoSize = true;
            label_DatosInstruccion.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            label_DatosInstruccion.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_DatosInstruccion.Location = new System.Drawing.Point(12, 0);
            label_DatosInstruccion.Name = "label_DatosInstruccion";
            label_DatosInstruccion.Padding = new System.Windows.Forms.Padding(20, 3, 20, 5);
            label_DatosInstruccion.Size = new System.Drawing.Size(260, 25);
            label_DatosInstruccion.TabIndex = 33;
            label_DatosInstruccion.Text = "DATOS DE LA INSTRUCCIÓN";
            // 
            // label_TITULO
            // 
            label_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(393, 9);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            label_TITULO.Size = new System.Drawing.Size(271, 24);
            label_TITULO.TabIndex = 35;
            label_TITULO.Text = "DOCUMENTOS A IMPRIMIR";
      
            // 
            // IMPRESION
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1052, 681);
            Controls.Add(panel1);
            Controls.Add(label_TITULO);
            Name = "IMPRESION";
            Text = "ACTUACIONES REALIZADAS";
            Load += IMPRESION_Load;
            Controls.SetChildIndex(label_TITULO, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel_informacionSeleccion.ResumeLayout(false);
            panel_DatosInstruccion.ResumeLayout(false);
            panel_DatosInstruccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelInstruccion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ofelia_Sara.Controles.General.PanelConBordeNeon panel_DatosInstruccion;
        private System.Windows.Forms.Label label_DatosInstruccion;
        private System.Windows.Forms.PictureBox pictureBox_PanelInstruccion;
        private System.Windows.Forms.Button btn_AmpliarReducir_INSTRUCCION;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.TableLayoutPanel ContenedorActuaciones;
        private System.Windows.Forms.Button btn_BuscarTarea;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Buscar;
        private System.Windows.Forms.Button btn_DescargarCarpeta;
        private System.Windows.Forms.Panel panel_informacionSeleccion;
        private System.Windows.Forms.Label label_Incompletos;
        private System.Windows.Forms.Label label_CantidadArchivos;
        private System.Windows.Forms.Label label_Seleccionados;
       
    }
}