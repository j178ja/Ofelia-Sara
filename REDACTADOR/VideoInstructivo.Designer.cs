using AxWMPLib;


namespace REDACTADOR
{
    partial class VideoInstructivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoInstructivo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Carrusel = new System.Windows.Forms.TableLayoutPanel();
            this.AnteriorImagen = new REDACTADOR.Clases.PictureBoxCircular();
            this.SiguienteImagen = new REDACTADOR.Clases.PictureBoxCircular();
            this.instructivo = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnteriorImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiguienteImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructivo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.AnteriorImagen);
            this.panel1.Controls.Add(this.SiguienteImagen);
            this.panel1.Controls.Add(this.Carrusel);
            this.panel1.Controls.Add(this.instructivo);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 434);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Carrusel
            // 
            this.Carrusel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Carrusel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.Carrusel.ColumnCount = 5;
            this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.Carrusel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Carrusel.Location = new System.Drawing.Point(43, 18);
            this.Carrusel.Name = "Carrusel";
            this.Carrusel.RowCount = 1;
            this.Carrusel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Carrusel.Size = new System.Drawing.Size(444, 76);
            this.Carrusel.TabIndex = 1;
            this.Carrusel.Paint += new System.Windows.Forms.PaintEventHandler(this.Carrusel_Paint);
            // 
            // AnteriorImagen
            // 
            this.AnteriorImagen.BackColor = System.Drawing.Color.Transparent;
            this.AnteriorImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnteriorImagen.Image = ((System.Drawing.Image)(resources.GetObject("AnteriorImagen.Image")));
            this.AnteriorImagen.Location = new System.Drawing.Point(12, 40);
            this.AnteriorImagen.Name = "AnteriorImagen";
            this.AnteriorImagen.Size = new System.Drawing.Size(27, 27);
            this.AnteriorImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AnteriorImagen.TabIndex = 4;
            this.AnteriorImagen.TabStop = false;
            // 
            // SiguienteImagen
            // 
            this.SiguienteImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SiguienteImagen.BackColor = System.Drawing.Color.Transparent;
            this.SiguienteImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SiguienteImagen.Image = ((System.Drawing.Image)(resources.GetObject("SiguienteImagen.Image")));
            this.SiguienteImagen.Location = new System.Drawing.Point(490, 40);
            this.SiguienteImagen.Name = "SiguienteImagen";
            this.SiguienteImagen.Size = new System.Drawing.Size(27, 27);
            this.SiguienteImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SiguienteImagen.TabIndex = 3;
            this.SiguienteImagen.TabStop = false;
            // 
            // instructivo
            // 
            this.instructivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instructivo.Enabled = true;
            this.instructivo.Location = new System.Drawing.Point(43, 102);
            this.instructivo.Name = "instructivo";
            this.instructivo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("instructivo.OcxState")));
            this.instructivo.Size = new System.Drawing.Size(444, 319);
            this.instructivo.TabIndex = 0;
            // 
            // VideoInstructivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(574, 471);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(584, 437);
            this.Name = "VideoInstructivo";
            this.Text = "INSTRUCTIVO DIGITAL";
            this.Load += new System.EventHandler(this.VideoInstructivo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnteriorImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiguienteImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructivo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer instructivo;
        private System.Windows.Forms.TableLayoutPanel Carrusel;
        private Clases.PictureBoxCircular AnteriorImagen;
        private Clases.PictureBoxCircular SiguienteImagen;
    }
}