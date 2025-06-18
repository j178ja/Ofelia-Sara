namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class Art_Infraccion
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
            label_ArtInfraccion = new System.Windows.Forms.Label();
            btn_EliminarArt = new System.Windows.Forms.Button();
            label_NumeroArt = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label_ArtInfraccion
            // 
            label_ArtInfraccion.AutoSize = true;
            label_ArtInfraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_ArtInfraccion.Location = new System.Drawing.Point(2, 5);
            label_ArtInfraccion.Name = "label_ArtInfraccion";
            label_ArtInfraccion.Size = new System.Drawing.Size(34, 18);
            label_ArtInfraccion.TabIndex = 45;
            label_ArtInfraccion.Text = "Art.";
            // 
            // btn_EliminarArt
            // 
            btn_EliminarArt.BackgroundImage = Properties.Resources.borrar;
            btn_EliminarArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_EliminarArt.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_EliminarArt.Location = new System.Drawing.Point(74, 1);
            btn_EliminarArt.Name = "btn_EliminarArt";
            btn_EliminarArt.Size = new System.Drawing.Size(31, 29);
            btn_EliminarArt.TabIndex = 46;
            btn_EliminarArt.UseVisualStyleBackColor = true;
            btn_EliminarArt.Click += Btn_EliminarArt_Click;
            // 
            // label_NumeroArt
            // 
            label_NumeroArt.AutoSize = true;
            label_NumeroArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_NumeroArt.Location = new System.Drawing.Point(30, 2);
            label_NumeroArt.Name = "label_NumeroArt";
            label_NumeroArt.Size = new System.Drawing.Size(48, 25);
            label_NumeroArt.TabIndex = 47;
            label_NumeroArt.Text = "000";
            label_NumeroArt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label_NumeroArt.MouseEnter += label_NumeroArt_MouseEnter;
            label_NumeroArt.MouseLeave += label_NumeroArt_MouseLeave;
            // 
            // Art_Infraccion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(label_NumeroArt);
            Controls.Add(label_ArtInfraccion);
            Controls.Add(btn_EliminarArt);
            Name = "Art_Infraccion";
            Size = new System.Drawing.Size(108, 33);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_ArtInfraccion;
        private System.Windows.Forms.Button btn_EliminarArt;
        private System.Windows.Forms.Label label_NumeroArt;
    }
}
