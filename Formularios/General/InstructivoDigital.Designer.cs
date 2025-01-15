namespace Ofelia_Sara.Formularios.General
{
    partial class InstructivoDigital
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructivoDigital));
            panel1 = new System.Windows.Forms.Panel();
            btn_Anterior = new System.Windows.Forms.PictureBox();
            btn_Siguiente = new System.Windows.Forms.PictureBox();
            axWindowsMediaPlayer_Preview = new AxWMPLib.AxWindowsMediaPlayer();
            tableLayoutPanel_Videos = new System.Windows.Forms.TableLayoutPanel();
            pictureBox_Izquierda = new System.Windows.Forms.PictureBox();
            pictureBox_Central = new System.Windows.Forms.PictureBox();
            pictureBox_Derecha = new System.Windows.Forms.PictureBox();
            panel2 = new System.Windows.Forms.Panel();
            axWindowsMediaPlayer_Videos = new AxWMPLib.AxWindowsMediaPlayer();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Anterior).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Siguiente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer_Preview).BeginInit();
            tableLayoutPanel_Videos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Izquierda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Central).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Derecha).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer_Videos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(btn_Anterior);
            panel1.Controls.Add(btn_Siguiente);
            panel1.Controls.Add(axWindowsMediaPlayer_Preview);
            panel1.Controls.Add(tableLayoutPanel_Videos);
            panel1.Location = new System.Drawing.Point(23, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(608, 240);
            panel1.TabIndex = 1;
            // 
            // btn_Anterior
            // 
            btn_Anterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btn_Anterior.BackgroundImage = Properties.Resources.anterior;
            btn_Anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_Anterior.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Anterior.Location = new System.Drawing.Point(3, 100);
            btn_Anterior.Name = "btn_Anterior";
            btn_Anterior.Size = new System.Drawing.Size(40, 42);
            btn_Anterior.TabIndex = 5;
            btn_Anterior.TabStop = false;
            btn_Anterior.Click += Btn_Anterior_Click;
            btn_Anterior.MouseDown += Btn_Anterior_MouseDown;
            btn_Anterior.MouseLeave += Btn_Anterior_MouseLeave;
            btn_Anterior.MouseUp += Btn_Anterior_MouseUp;
            // 
            // btn_Siguiente
            // 
            btn_Siguiente.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btn_Siguiente.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_Siguiente.BackgroundImage");
            btn_Siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_Siguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Siguiente.Location = new System.Drawing.Point(567, 100);
            btn_Siguiente.Name = "btn_Siguiente";
            btn_Siguiente.Size = new System.Drawing.Size(38, 42);
            btn_Siguiente.TabIndex = 4;
            btn_Siguiente.TabStop = false;
            btn_Siguiente.Click += Btn_Siguiente_Click;
            btn_Siguiente.MouseDown += Btn_Siguiente_MouseDown;
            btn_Siguiente.MouseLeave += Btn_Siguiente_MouseLeave;
            btn_Siguiente.MouseUp += Btn_Siguiente_MouseUp;
            // 
            // axWindowsMediaPlayer_Preview
            // 
            axWindowsMediaPlayer_Preview.Enabled = true;
            axWindowsMediaPlayer_Preview.Location = new System.Drawing.Point(128, 8);
            axWindowsMediaPlayer_Preview.Name = "axWindowsMediaPlayer_Preview";
            axWindowsMediaPlayer_Preview.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axWindowsMediaPlayer_Preview.OcxState");
            axWindowsMediaPlayer_Preview.Size = new System.Drawing.Size(75, 10);
            axWindowsMediaPlayer_Preview.TabIndex = 3;
            // 
            // tableLayoutPanel_Videos
            // 
            tableLayoutPanel_Videos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel_Videos.ColumnCount = 3;
            tableLayoutPanel_Videos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel_Videos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel_Videos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel_Videos.Controls.Add(pictureBox_Izquierda, 0, 0);
            tableLayoutPanel_Videos.Controls.Add(pictureBox_Central, 1, 0);
            tableLayoutPanel_Videos.Controls.Add(pictureBox_Derecha, 2, 0);
            tableLayoutPanel_Videos.Location = new System.Drawing.Point(46, 18);
            tableLayoutPanel_Videos.Name = "tableLayoutPanel_Videos";
            tableLayoutPanel_Videos.RowCount = 1;
            tableLayoutPanel_Videos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel_Videos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel_Videos.Size = new System.Drawing.Size(518, 208);
            tableLayoutPanel_Videos.TabIndex = 0;
            // 
            // pictureBox_Izquierda
            // 
            pictureBox_Izquierda.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox_Izquierda.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            pictureBox_Izquierda.BackgroundImage = Properties.Resources.EscudoPolicia_PNG;
            pictureBox_Izquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_Izquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_Izquierda.Location = new System.Drawing.Point(0, 0);
            pictureBox_Izquierda.Margin = new System.Windows.Forms.Padding(0);
            pictureBox_Izquierda.Name = "pictureBox_Izquierda";
            pictureBox_Izquierda.Size = new System.Drawing.Size(129, 208);
            pictureBox_Izquierda.TabIndex = 1;
            pictureBox_Izquierda.TabStop = false;
            pictureBox_Izquierda.Tag = "rutaVideo";
            pictureBox_Izquierda.Click += PictureBox_Click;
            // 
            // pictureBox_Central
            // 
            pictureBox_Central.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox_Central.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            pictureBox_Central.BackgroundImage = Properties.Resources.EscudoPolicia_PNG;
            pictureBox_Central.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_Central.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_Central.Location = new System.Drawing.Point(139, 0);
            pictureBox_Central.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            pictureBox_Central.Name = "pictureBox_Central";
            pictureBox_Central.Size = new System.Drawing.Size(239, 208);
            pictureBox_Central.TabIndex = 0;
            pictureBox_Central.TabStop = false;
            pictureBox_Central.Tag = "rutaVideo";
            pictureBox_Central.Click += PictureBox_Click;
            // 
            // pictureBox_Derecha
            // 
            pictureBox_Derecha.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox_Derecha.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            pictureBox_Derecha.BackgroundImage = Properties.Resources.EscudoPolicia_PNG;
            pictureBox_Derecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox_Derecha.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox_Derecha.ErrorImage = Properties.Resources.IconoError;
            pictureBox_Derecha.Location = new System.Drawing.Point(388, 0);
            pictureBox_Derecha.Margin = new System.Windows.Forms.Padding(0);
            pictureBox_Derecha.Name = "pictureBox_Derecha";
            pictureBox_Derecha.Size = new System.Drawing.Size(130, 208);
            pictureBox_Derecha.TabIndex = 2;
            pictureBox_Derecha.TabStop = false;
            pictureBox_Derecha.Tag = "rutaVideo";
            pictureBox_Derecha.Click += PictureBox_Click;
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel2.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel2.Controls.Add(axWindowsMediaPlayer_Videos);
            panel2.Location = new System.Drawing.Point(23, 258);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(608, 353);
            panel2.TabIndex = 2;
            // 
            // axWindowsMediaPlayer_Videos
            // 
            axWindowsMediaPlayer_Videos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            axWindowsMediaPlayer_Videos.Enabled = true;
            axWindowsMediaPlayer_Videos.Location = new System.Drawing.Point(15, 16);
            axWindowsMediaPlayer_Videos.Name = "axWindowsMediaPlayer_Videos";
            axWindowsMediaPlayer_Videos.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axWindowsMediaPlayer_Videos.OcxState");
            axWindowsMediaPlayer_Videos.Size = new System.Drawing.Size(579, 320);
            axWindowsMediaPlayer_Videos.TabIndex = 0;
            axWindowsMediaPlayer_Videos.PlayStateChange += axWindowsMediaPlayer_Videos_PlayStateChange;
            // 
            // InstructivoDigital
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(654, 639);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "InstructivoDigital";
            Text = "INSTRUCTIVO DIGITAL";
            Load += InstructivoDigital_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(panel2, 0);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_Anterior).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Siguiente).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer_Preview).EndInit();
            tableLayoutPanel_Videos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Izquierda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Central).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Derecha).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer_Videos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Videos;
        private System.Windows.Forms.PictureBox pictureBox_Derecha;
        private System.Windows.Forms.PictureBox pictureBox_Izquierda;
        private System.Windows.Forms.PictureBox pictureBox_Central;
        private System.Windows.Forms.Panel panel2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer_Videos;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer_Preview;
        private System.Windows.Forms.PictureBox btn_Siguiente;
        private System.Windows.Forms.PictureBox btn_Anterior;
    }
}
