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
            panel1 = new System.Windows.Forms.Panel();
            radioButton_Acta = new System.Windows.Forms.RadioButton();
            pictureBox_Denuncia = new System.Windows.Forms.PictureBox();
            pictureBox_Acta = new System.Windows.Forms.PictureBox();
            radioButton_Denuncia = new System.Windows.Forms.RadioButton();
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Denuncia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Acta).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(radioButton_Acta);
            panel1.Controls.Add(pictureBox_Denuncia);
            panel1.Controls.Add(pictureBox_Acta);
            panel1.Controls.Add(radioButton_Denuncia);
            panel1.Location = new System.Drawing.Point(30, 33);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(740, 125);
            panel1.TabIndex = 1;
            // 
            // radioButton_Acta
            // 
            radioButton_Acta.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Acta.Location = new System.Drawing.Point(121, 20);
            radioButton_Acta.Name = "radioButton_Acta";
            radioButton_Acta.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            radioButton_Acta.Size = new System.Drawing.Size(224, 39);
            radioButton_Acta.TabIndex = 36;
            radioButton_Acta.TabStop = true;
            radioButton_Acta.Text = "ACTA DE PROCEDIMIENTO";
            radioButton_Acta.UseVisualStyleBackColor = true;
            radioButton_Acta.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // pictureBox_Denuncia
            // 
            pictureBox_Denuncia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_Denuncia.Location = new System.Drawing.Point(445, 20);
            pictureBox_Denuncia.Name = "pictureBox_Denuncia";
            pictureBox_Denuncia.Size = new System.Drawing.Size(40, 39);
            pictureBox_Denuncia.TabIndex = 38;
            pictureBox_Denuncia.TabStop = false;
            // 
            // pictureBox_Acta
            // 
            pictureBox_Acta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox_Acta.Location = new System.Drawing.Point(79, 20);
            pictureBox_Acta.Name = "pictureBox_Acta";
            pictureBox_Acta.Size = new System.Drawing.Size(40, 39);
            pictureBox_Acta.TabIndex = 37;
            pictureBox_Acta.TabStop = false;
            // 
            // radioButton_Denuncia
            // 
            radioButton_Denuncia.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButton_Denuncia.Location = new System.Drawing.Point(487, 20);
            radioButton_Denuncia.Name = "radioButton_Denuncia";
            radioButton_Denuncia.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            radioButton_Denuncia.Size = new System.Drawing.Size(188, 39);
            radioButton_Denuncia.TabIndex = 35;
            radioButton_Denuncia.TabStop = true;
            radioButton_Denuncia.Text = "DENUNCIA PENAL";
            radioButton_Denuncia.UseVisualStyleBackColor = true;
            radioButton_Denuncia.CheckedChanged += RadioButton_CheckedChanged;
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
            // ActaDenuncia
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 210);
            Controls.Add(label_TITULO);
            Controls.Add(panel1);
            Name = "ActaDenuncia";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DENUNCIA / ACTA DE PROCEDIMIENTO";
            Load += ActaDenuncia_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label_TITULO, 0);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Denuncia).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Acta).EndInit();
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
    }
}