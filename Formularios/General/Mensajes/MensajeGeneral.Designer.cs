namespace Ofelia_Sara.Formularios.General.Mensajes
{
    partial class MensajeGeneral
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
            label_OfeliaSara = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            Fecha_Compromiso = new Controles.Ofl_Sara.DateCompromiso_Control();
            label_Texto = new System.Windows.Forms.TextBox();
            pictureBox_Icono = new System.Windows.Forms.PictureBox();
            btn_Cerrar = new System.Windows.Forms.Button();
            pictureBox_EscudoPolicial = new System.Windows.Forms.PictureBox();
            btn_Si = new System.Windows.Forms.Button();
            btn_No = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Icono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_EscudoPolicial).BeginInit();
            SuspendLayout();
            // 
            // label_OfeliaSara
            // 
            label_OfeliaSara.AutoSize = true;
            label_OfeliaSara.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label_OfeliaSara.Location = new System.Drawing.Point(209, 4);
            label_OfeliaSara.Margin = new System.Windows.Forms.Padding(0);
            label_OfeliaSara.Name = "label_OfeliaSara";
            label_OfeliaSara.Size = new System.Drawing.Size(139, 37);
            label_OfeliaSara.TabIndex = 5;
            label_OfeliaSara.Text = "Ofelia-Sara";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(Fecha_Compromiso);
            panel1.Controls.Add(label_Texto);
            panel1.Controls.Add(pictureBox_Icono);
            panel1.Location = new System.Drawing.Point(16, 60);
            panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(513, 172);
            panel1.TabIndex = 4;
            // 
            // Fecha_Compromiso
            // 
            Fecha_Compromiso.AutoSize = true;
            Fecha_Compromiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Fecha_Compromiso.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            Fecha_Compromiso.Location = new System.Drawing.Point(29, 49);
            Fecha_Compromiso.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            Fecha_Compromiso.Name = "Fecha_Compromiso";
            Fecha_Compromiso.Size = new System.Drawing.Size(436, 32);
            Fecha_Compromiso.TabIndex = 5;
            // 
            // label_Texto
            // 
            label_Texto.BackColor = System.Drawing.SystemColors.Control;
            label_Texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Texto.ForeColor = System.Drawing.Color.FromArgb(0, 115, 130);
            label_Texto.Location = new System.Drawing.Point(5, 100);
            label_Texto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label_Texto.Multiline = true;
            label_Texto.Name = "label_Texto";
            label_Texto.ReadOnly = true;
            label_Texto.Size = new System.Drawing.Size(505, 37);
            label_Texto.TabIndex = 4;
            label_Texto.TabStop = false;
            label_Texto.Text = "Cargando...";
            label_Texto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox_Icono
            // 
            pictureBox_Icono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_Icono.Location = new System.Drawing.Point(225, 13);
            pictureBox_Icono.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            pictureBox_Icono.Name = "pictureBox_Icono";
            pictureBox_Icono.Size = new System.Drawing.Size(73, 77);
            pictureBox_Icono.TabIndex = 3;
            pictureBox_Icono.TabStop = false;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(234, 40, 0);
            btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Cerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_Cerrar.Location = new System.Drawing.Point(216, 213);
            btn_Cerrar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.Size = new System.Drawing.Size(120, 47);
            btn_Cerrar.TabIndex = 2;
            btn_Cerrar.Text = "CERRAR";
            btn_Cerrar.UseVisualStyleBackColor = false;
            btn_Cerrar.Click += Btn_Cerrar_Click;
            btn_Cerrar.Paint += Subrayado_Paint;
            btn_Cerrar.MouseEnter += Subrayado_MouseEnter;
            btn_Cerrar.MouseLeave += Subrayado_MouseLeave;
            // 
            // pictureBox_EscudoPolicial
            // 
            pictureBox_EscudoPolicial.BackgroundImage = Properties.Resources.EscudoPolicia_PNG;
            pictureBox_EscudoPolicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox_EscudoPolicial.Location = new System.Drawing.Point(2, 4);
            pictureBox_EscudoPolicial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            pictureBox_EscudoPolicial.Name = "pictureBox_EscudoPolicial";
            pictureBox_EscudoPolicial.Size = new System.Drawing.Size(48, 47);
            pictureBox_EscudoPolicial.TabIndex = 5;
            pictureBox_EscudoPolicial.TabStop = false;
            // 
            // btn_Si
            // 
            btn_Si.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            btn_Si.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Si.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Si.ForeColor = System.Drawing.SystemColors.ControlText;
            btn_Si.Location = new System.Drawing.Point(101, 213);
            btn_Si.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btn_Si.Name = "btn_Si";
            btn_Si.Size = new System.Drawing.Size(120, 47);
            btn_Si.TabIndex = 6;
            btn_Si.Text = "SI";
            btn_Si.UseVisualStyleBackColor = false;
            btn_Si.Click += Btn_Si_Click;
            btn_Si.Paint += Subrayado_Paint;
            btn_Si.MouseEnter += Subrayado_MouseEnter;
            btn_Si.MouseLeave += Subrayado_MouseLeave;
            // 
            // btn_No
            // 
            btn_No.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            btn_No.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_No.ForeColor = System.Drawing.SystemColors.ControlText;
            btn_No.Location = new System.Drawing.Point(330, 213);
            btn_No.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btn_No.Name = "btn_No";
            btn_No.Size = new System.Drawing.Size(120, 47);
            btn_No.TabIndex = 7;
            btn_No.Text = "NO";
            btn_No.UseVisualStyleBackColor = false;
            btn_No.Click += Btn_No_Click;
            btn_No.Paint += Subrayado_Paint;
            btn_No.MouseEnter += Subrayado_MouseEnter;
            btn_No.MouseLeave += Subrayado_MouseLeave;
            // 
            // MensajeGeneral
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            ClientSize = new System.Drawing.Size(545, 267);
            Controls.Add(btn_No);
            Controls.Add(btn_Si);
            Controls.Add(pictureBox_EscudoPolicial);
            Controls.Add(label_OfeliaSara);
            Controls.Add(btn_Cerrar);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            Name = "MensajeGeneral";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "MensajeGral";
            Load += MensajeGeneral_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Icono).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_EscudoPolicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_OfeliaSara;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox label_Texto;
        private System.Windows.Forms.PictureBox pictureBox_Icono;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.PictureBox pictureBox_EscudoPolicial;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Si;
        private Ofelia_Sara.Controles.Ofl_Sara.DateCompromiso_Control Fecha_Compromiso;
    }
}