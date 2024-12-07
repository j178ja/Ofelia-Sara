namespace Ofelia_Sara.Formularios.Oficial_de_servicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_informacionSeleccion = new System.Windows.Forms.Panel();
            this.label_Seleccionados = new System.Windows.Forms.Label();
            this.label_CantidadArchivos = new System.Windows.Forms.Label();
            this.label_Incompletos = new System.Windows.Forms.Label();
            this.btn_DescargarCarpeta = new System.Windows.Forms.Button();
            this.btn_BuscarTarea = new System.Windows.Forms.Button();
            this.comboBox_Buscar = new System.Windows.Forms.ComboBox();
            this.ContenedorActuaciones = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.panel_DatosInstruccion = new Ofelia_Sara.Controles.Controles.Aplicadas_con_controles.PanelConBordeNeon();
            this.btn_AmpliarReducir_INSTRUCCION = new System.Windows.Forms.Button();
            this.pictureBox_PanelInstruccion = new System.Windows.Forms.PictureBox();
            this.label_DatosInstruccion = new System.Windows.Forms.Label();
            this.label_TITULO = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_informacionSeleccion.SuspendLayout();
            this.panel_DatosInstruccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PanelInstruccion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.panel_informacionSeleccion);
            this.panel1.Controls.Add(this.btn_DescargarCarpeta);
            this.panel1.Controls.Add(this.btn_BuscarTarea);
            this.panel1.Controls.Add(this.comboBox_Buscar);
            this.panel1.Controls.Add(this.ContenedorActuaciones);
            this.panel1.Controls.Add(this.btn_Imprimir);
            this.panel1.Controls.Add(this.panel_DatosInstruccion);
            this.panel1.Location = new System.Drawing.Point(18, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 632);
            this.panel1.TabIndex = 1;
            // 
            // panel_informacionSeleccion
            // 
            this.panel_informacionSeleccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_informacionSeleccion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel_informacionSeleccion.Controls.Add(this.label_Seleccionados);
            this.panel_informacionSeleccion.Controls.Add(this.label_CantidadArchivos);
            this.panel_informacionSeleccion.Controls.Add(this.label_Incompletos);
            this.panel_informacionSeleccion.Location = new System.Drawing.Point(366, 521);
            this.panel_informacionSeleccion.Name = "panel_informacionSeleccion";
            this.panel_informacionSeleccion.Size = new System.Drawing.Size(285, 92);
            this.panel_informacionSeleccion.TabIndex = 40;
            // 
            // label_Seleccionados
            // 
            this.label_Seleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seleccionados.ForeColor = System.Drawing.Color.Teal;
            this.label_Seleccionados.Location = new System.Drawing.Point(9, 67);
            this.label_Seleccionados.Name = "label_Seleccionados";
            this.label_Seleccionados.Size = new System.Drawing.Size(269, 20);
            this.label_Seleccionados.TabIndex = 2;
            this.label_Seleccionados.Text = "label1";
            this.label_Seleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CantidadArchivos
            // 
            this.label_CantidadArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CantidadArchivos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_CantidadArchivos.Location = new System.Drawing.Point(3, 8);
            this.label_CantidadArchivos.Name = "label_CantidadArchivos";
            this.label_CantidadArchivos.Size = new System.Drawing.Size(279, 20);
            this.label_CantidadArchivos.TabIndex = 1;
            this.label_CantidadArchivos.Text = "label1";
            this.label_CantidadArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Incompletos
            // 
            this.label_Incompletos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Incompletos.ForeColor = System.Drawing.Color.Crimson;
            this.label_Incompletos.Location = new System.Drawing.Point(3, 36);
            this.label_Incompletos.Name = "label_Incompletos";
            this.label_Incompletos.Size = new System.Drawing.Size(275, 20);
            this.label_Incompletos.TabIndex = 0;
            this.label_Incompletos.Text = "label1";
            this.label_Incompletos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_DescargarCarpeta
            // 
            this.btn_DescargarCarpeta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_DescargarCarpeta.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_DescargarCarpeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DescargarCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("btn_DescargarCarpeta.Image")));
            this.btn_DescargarCarpeta.Location = new System.Drawing.Point(235, 521);
            this.btn_DescargarCarpeta.Name = "btn_DescargarCarpeta";
            this.btn_DescargarCarpeta.Size = new System.Drawing.Size(106, 92);
            this.btn_DescargarCarpeta.TabIndex = 39;
            this.btn_DescargarCarpeta.UseVisualStyleBackColor = false;
            // 
            // btn_BuscarTarea
            // 
            this.btn_BuscarTarea.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_BuscarTarea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BuscarTarea.BackgroundImage")));
            this.btn_BuscarTarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BuscarTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BuscarTarea.FlatAppearance.BorderSize = 0;
            this.btn_BuscarTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuscarTarea.Location = new System.Drawing.Point(595, 25);
            this.btn_BuscarTarea.Name = "btn_BuscarTarea";
            this.btn_BuscarTarea.Size = new System.Drawing.Size(35, 35);
            this.btn_BuscarTarea.TabIndex = 38;
            this.btn_BuscarTarea.UseVisualStyleBackColor = true;
            // 
            // comboBox_Buscar
            // 
            this.comboBox_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_Buscar.BackColor = System.Drawing.Color.White;
            this.comboBox_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Buscar.FormattingEnabled = true;
            this.comboBox_Buscar.Location = new System.Drawing.Point(634, 28);
            this.comboBox_Buscar.Name = "comboBox_Buscar";
            this.comboBox_Buscar.Size = new System.Drawing.Size(294, 28);
            this.comboBox_Buscar.TabIndex = 37;
            // 
            // ContenedorActuaciones
            // 
            this.ContenedorActuaciones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ContenedorActuaciones.ColumnCount = 3;
            this.ContenedorActuaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.ContenedorActuaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.ContenedorActuaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            this.ContenedorActuaciones.Location = new System.Drawing.Point(14, 77);
            this.ContenedorActuaciones.Name = "ContenedorActuaciones";
            this.ContenedorActuaciones.RowCount = 12;
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ContenedorActuaciones.Size = new System.Drawing.Size(993, 417);
            this.ContenedorActuaciones.TabIndex = 36;
            this.ContenedorActuaciones.Paint += new System.Windows.Forms.PaintEventHandler(this.ContenedorActuaciones_Paint);
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Imprimir.Image")));
            this.btn_Imprimir.Location = new System.Drawing.Point(677, 523);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(106, 92);
            this.btn_Imprimir.TabIndex = 25;
            this.btn_Imprimir.UseVisualStyleBackColor = false;
            // 
            // panel_DatosInstruccion
            // 
            this.panel_DatosInstruccion.BorderRadius = 10;
            this.panel_DatosInstruccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_DatosInstruccion.CamposCompletos = false;
            this.panel_DatosInstruccion.Controls.Add(this.btn_AmpliarReducir_INSTRUCCION);
            this.panel_DatosInstruccion.Controls.Add(this.pictureBox_PanelInstruccion);
            this.panel_DatosInstruccion.Controls.Add(this.label_DatosInstruccion);
            this.panel_DatosInstruccion.EstaContraido = false;
            this.panel_DatosInstruccion.Location = new System.Drawing.Point(14, 28);
            this.panel_DatosInstruccion.Name = "panel_DatosInstruccion";
            this.panel_DatosInstruccion.NeonColorCompleto = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.panel_DatosInstruccion.NeonColorIncompleto = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel_DatosInstruccion.Size = new System.Drawing.Size(393, 30);
            this.panel_DatosInstruccion.SombraColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.panel_DatosInstruccion.TabIndex = 0;
            // 
            // btn_AmpliarReducir_INSTRUCCION
            // 
            this.btn_AmpliarReducir_INSTRUCCION.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AmpliarReducir_INSTRUCCION.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AmpliarReducir_INSTRUCCION.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_AmpliarReducir_INSTRUCCION.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_AmpliarReducir_INSTRUCCION.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_AmpliarReducir_INSTRUCCION.Image = ((System.Drawing.Image)(resources.GetObject("btn_AmpliarReducir_INSTRUCCION.Image")));
            this.btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(351, 0);
            this.btn_AmpliarReducir_INSTRUCCION.Name = "btn_AmpliarReducir_INSTRUCCION";
            this.btn_AmpliarReducir_INSTRUCCION.Size = new System.Drawing.Size(31, 23);
            this.btn_AmpliarReducir_INSTRUCCION.TabIndex = 84;
            this.btn_AmpliarReducir_INSTRUCCION.UseVisualStyleBackColor = false;
            // 
            // pictureBox_PanelInstruccion
            // 
            this.pictureBox_PanelInstruccion.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_PanelInstruccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_PanelInstruccion.Location = new System.Drawing.Point(278, 0);
            this.pictureBox_PanelInstruccion.Name = "pictureBox_PanelInstruccion";
            this.pictureBox_PanelInstruccion.Size = new System.Drawing.Size(29, 22);
            this.pictureBox_PanelInstruccion.TabIndex = 34;
            this.pictureBox_PanelInstruccion.TabStop = false;
            // 
            // label_DatosInstruccion
            // 
            this.label_DatosInstruccion.AutoSize = true;
            this.label_DatosInstruccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_DatosInstruccion.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DatosInstruccion.Location = new System.Drawing.Point(12, 0);
            this.label_DatosInstruccion.Name = "label_DatosInstruccion";
            this.label_DatosInstruccion.Padding = new System.Windows.Forms.Padding(20, 3, 20, 5);
            this.label_DatosInstruccion.Size = new System.Drawing.Size(260, 25);
            this.label_DatosInstruccion.TabIndex = 33;
            this.label_DatosInstruccion.Text = "DATOS DE LA INSTRUCCIÓN";
            // 
            // label_TITULO
            // 
            this.label_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_TITULO.AutoSize = true;
            this.label_TITULO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITULO.Location = new System.Drawing.Point(391, 7);
            this.label_TITULO.Name = "label_TITULO";
            this.label_TITULO.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label_TITULO.Size = new System.Drawing.Size(271, 24);
            this.label_TITULO.TabIndex = 35;
            this.label_TITULO.Text = "DOCUMENTOS A IMPRIMIR";
            // 
            // IMPRESION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_TITULO);
            this.Name = "IMPRESION";
            this.Text = "ACTUACIONES REALIZADAS";
            this.Load += new System.EventHandler(this.IMPRESION_Load);
            this.Controls.SetChildIndex(this.label_TITULO, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel_informacionSeleccion.ResumeLayout(false);
            this.panel_DatosInstruccion.ResumeLayout(false);
            this.panel_DatosInstruccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PanelInstruccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controles.Controles.Aplicadas_con_controles.PanelConBordeNeon panel_DatosInstruccion;
        private System.Windows.Forms.Label label_DatosInstruccion;
        private System.Windows.Forms.PictureBox pictureBox_PanelInstruccion;
        private System.Windows.Forms.Button btn_AmpliarReducir_INSTRUCCION;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.TableLayoutPanel ContenedorActuaciones;
        private System.Windows.Forms.Button btn_BuscarTarea;
        private System.Windows.Forms.ComboBox comboBox_Buscar;
        private System.Windows.Forms.Button btn_DescargarCarpeta;
        private System.Windows.Forms.Panel panel_informacionSeleccion;
        private System.Windows.Forms.Label label_Incompletos;
        private System.Windows.Forms.Label label_CantidadArchivos;
        private System.Windows.Forms.Label label_Seleccionados;
        private Controles.Controles.comboBoxIMG comboBoxIMG1;
    }
}