namespace Ofelia_Sara.Controles.Controles
{
    partial class NuevaImagen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaImagen));
            this.pictureBox_Imagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Imagen
            // 
            this.pictureBox_Imagen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_Imagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Imagen.BackgroundImage")));
            this.pictureBox_Imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Imagen.ImageLocation = "";
            this.pictureBox_Imagen.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Imagen.Name = "pictureBox_Imagen";
            this.pictureBox_Imagen.Size = new System.Drawing.Size(94, 113);
            this.pictureBox_Imagen.TabIndex = 19;
            this.pictureBox_Imagen.TabStop = false;
            // 
            // NuevaImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pictureBox_Imagen);
            this.Name = "NuevaImagen";
            this.Size = new System.Drawing.Size(97, 116);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Imagen;
    }
}
