using Ofelia_Sara.Controles.Controles.General;

namespace Ofelia_Sara.Controles.Ofl_Sara
{ 
    partial class Verificador_ACTUACION
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verificador_ACTUACION));
            panelConBordeNeon1 = new General.PanelConBordeNeon();
            Remover_Control = new System.Windows.Forms.PictureBox();
            linkLabel_Actuacion = new System.Windows.Forms.LinkLabel();
            checkBox_Selecionar = new System.Windows.Forms.CheckBox();
            pictureBox_ImprimirEnviar = new System.Windows.Forms.PictureBox();
            pictureBox_PrevisualizadorDocumento = new System.Windows.Forms.PictureBox();
            pictureBox_EstadoDocumento = new System.Windows.Forms.PictureBox();
            panelConBordeNeon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Remover_Control).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_ImprimirEnviar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PrevisualizadorDocumento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_EstadoDocumento).BeginInit();
            SuspendLayout();
            // 
            // panelConBordeNeon1
            // 
            panelConBordeNeon1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panelConBordeNeon1.BorderRadius = 10;
            panelConBordeNeon1.CamposCompletos = false;
            panelConBordeNeon1.Controls.Add(Remover_Control);
            panelConBordeNeon1.Controls.Add(linkLabel_Actuacion);
            panelConBordeNeon1.Controls.Add(checkBox_Selecionar);
            panelConBordeNeon1.Controls.Add(pictureBox_ImprimirEnviar);
            panelConBordeNeon1.Controls.Add(pictureBox_PrevisualizadorDocumento);
            panelConBordeNeon1.Controls.Add(pictureBox_EstadoDocumento);
            panelConBordeNeon1.EstaContraido = false;
            panelConBordeNeon1.Location = new System.Drawing.Point(0, 0);
            panelConBordeNeon1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelConBordeNeon1.Name = "panelConBordeNeon1";
            panelConBordeNeon1.NeonColorCompleto = System.Drawing.Color.FromArgb(0, 255, 0);
            panelConBordeNeon1.NeonColorIncompleto = System.Drawing.Color.FromArgb(255, 0, 0);
            panelConBordeNeon1.Size = new System.Drawing.Size(379, 35);
            panelConBordeNeon1.SombraColor = System.Drawing.Color.FromArgb(200, 0, 198, 255);
            panelConBordeNeon1.TabIndex = 0;
            // 
            // Remover_Control
            // 
            Remover_Control.BackgroundImage = (System.Drawing.Image)resources.GetObject("Remover_Control.BackgroundImage");
            Remover_Control.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            Remover_Control.Cursor = System.Windows.Forms.Cursors.Hand;
            Remover_Control.Location = new System.Drawing.Point(317, 0);
            Remover_Control.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Remover_Control.Name = "Remover_Control";
            Remover_Control.Size = new System.Drawing.Size(26, 33);
            Remover_Control.TabIndex = 92;
            Remover_Control.TabStop = false;
            Remover_Control.Click += Remover_Control_Click;
            // 
            // linkLabel_Actuacion
            // 
            linkLabel_Actuacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            linkLabel_Actuacion.Cursor = System.Windows.Forms.Cursors.Hand;
            linkLabel_Actuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            linkLabel_Actuacion.Location = new System.Drawing.Point(49, 7);
            linkLabel_Actuacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel_Actuacion.Name = "linkLabel_Actuacion";
            linkLabel_Actuacion.Size = new System.Drawing.Size(163, 21);
            linkLabel_Actuacion.TabIndex = 89;
            linkLabel_Actuacion.TabStop = true;
            linkLabel_Actuacion.Text = "ACTUACION REALIZADA";
            linkLabel_Actuacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_Selecionar
            // 
            checkBox_Selecionar.AutoSize = true;
            checkBox_Selecionar.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBox_Selecionar.Location = new System.Drawing.Point(355, 10);
            checkBox_Selecionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_Selecionar.Name = "checkBox_Selecionar";
            checkBox_Selecionar.Size = new System.Drawing.Size(15, 14);
            checkBox_Selecionar.TabIndex = 91;
            checkBox_Selecionar.UseVisualStyleBackColor = true;
            checkBox_Selecionar.CheckedChanged += checkBox_Selecionar_CheckedChanged;
            // 
            // pictureBox_ImprimirEnviar
            // 
            pictureBox_ImprimirEnviar.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox_ImprimirEnviar.BackgroundImage");
            pictureBox_ImprimirEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_ImprimirEnviar.Location = new System.Drawing.Point(264, 0);
            pictureBox_ImprimirEnviar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_ImprimirEnviar.Name = "pictureBox_ImprimirEnviar";
            pictureBox_ImprimirEnviar.Size = new System.Drawing.Size(44, 33);
            pictureBox_ImprimirEnviar.TabIndex = 90;
            pictureBox_ImprimirEnviar.TabStop = false;
            // 
            // pictureBox_PrevisualizadorDocumento
            // 
            pictureBox_PrevisualizadorDocumento.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            pictureBox_PrevisualizadorDocumento.BackgroundImage = Properties.Resources.doc;
            pictureBox_PrevisualizadorDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_PrevisualizadorDocumento.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_PrevisualizadorDocumento.Location = new System.Drawing.Point(225, 0);
            pictureBox_PrevisualizadorDocumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_PrevisualizadorDocumento.Name = "pictureBox_PrevisualizadorDocumento";
            pictureBox_PrevisualizadorDocumento.Size = new System.Drawing.Size(37, 35);
            pictureBox_PrevisualizadorDocumento.TabIndex = 89;
            pictureBox_PrevisualizadorDocumento.TabStop = false;
            pictureBox_PrevisualizadorDocumento.Click += PictureBox_Click;
            pictureBox_PrevisualizadorDocumento.MouseEnter += PictureBox_MouseEnter;
            pictureBox_PrevisualizadorDocumento.MouseLeave += PictureBox_MouseLeave;
            // 
            // pictureBox_EstadoDocumento
            // 
            pictureBox_EstadoDocumento.BackColor = System.Drawing.Color.Transparent;
            pictureBox_EstadoDocumento.BackgroundImage = Properties.Resources.verificacion_exitosa;
            pictureBox_EstadoDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_EstadoDocumento.Location = new System.Drawing.Point(4, 0);
            pictureBox_EstadoDocumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_EstadoDocumento.Name = "pictureBox_EstadoDocumento";
            pictureBox_EstadoDocumento.Size = new System.Drawing.Size(42, 35);
            pictureBox_EstadoDocumento.TabIndex = 87;
            pictureBox_EstadoDocumento.TabStop = false;
            // 
            // Verificador_ACTUACION
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(panelConBordeNeon1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Verificador_ACTUACION";
            Size = new System.Drawing.Size(383, 38);
            panelConBordeNeon1.ResumeLayout(false);
            panelConBordeNeon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Remover_Control).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_ImprimirEnviar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PrevisualizadorDocumento).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_EstadoDocumento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Ofelia_Sara.Controles.General.PanelConBordeNeon panelConBordeNeon1;
        private System.Windows.Forms.PictureBox pictureBox_EstadoDocumento;
        private System.Windows.Forms.PictureBox pictureBox_PrevisualizadorDocumento;
        private System.Windows.Forms.PictureBox pictureBox_ImprimirEnviar;
        private System.Windows.Forms.CheckBox checkBox_Selecionar;
        private System.Windows.Forms.LinkLabel linkLabel_Actuacion;
        private System.Windows.Forms.PictureBox Remover_Control;
    }
}
