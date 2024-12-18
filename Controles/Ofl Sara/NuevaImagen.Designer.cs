namespace Ofelia_Sara.Controles.Ofl_Sara
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Imagen
            // 
            this.pictureBox_Imagen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_Imagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Imagen.BackgroundImage")));
            this.pictureBox_Imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Imagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Imagen.ImageLocation = "";
            this.pictureBox_Imagen.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Imagen.Name = "pictureBox_Imagen";
            this.pictureBox_Imagen.Size = new System.Drawing.Size(94, 113);
            this.pictureBox_Imagen.TabIndex = 19;
            this.pictureBox_Imagen.TabStop = false;
            this.pictureBox_Imagen.Click += new System.EventHandler(this.NuevaImagen_Click);
            this.pictureBox_Imagen.DragDrop += new System.Windows.Forms.DragEventHandler(this.NuevaImagen_DragDrop);
            this.pictureBox_Imagen.DragEnter += new System.Windows.Forms.DragEventHandler(this.NuevaImagen_DragEnter);
            this.pictureBox_Imagen.MouseLeave += new System.EventHandler(this.NuevaImagen_MouseLeave);
            this.pictureBox_Imagen.MouseHover += new System.EventHandler(this.NuevaImagen_MouseHover);
            // 
            // NuevaImagen
            // 
            this.Size = new System.Drawing.Size(97, 116);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Imagen;
    }
}
