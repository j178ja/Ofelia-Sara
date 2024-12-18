namespace Ofelia_Sara.Controles.Controles.General
{
    partial class TooltipError
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
            this.icono = new System.Windows.Forms.PictureBox();
            this.mensaje = new System.Windows.Forms.Label();
            this.escudo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escudo)).BeginInit();
            this.SuspendLayout();
            // 
            // icono
            // 
            this.icono.BackgroundImage = global::Ofelia_Sara.Properties.Resources.errorProvider_PNG;  // Asegúrate de que esta imagen esté en tus recursos
            this.icono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.icono.Location = new System.Drawing.Point(0, 1);
            this.icono.Name = "icono";
            this.icono.Size = new System.Drawing.Size(18, 18);  // Dimensión de 18px
            this.icono.TabIndex = 0;
            this.icono.TabStop = false;
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.Location = new System.Drawing.Point(24, 3);  // La posición del texto del mensaje
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(55, 15);
            this.mensaje.TabIndex = 1;
            this.mensaje.Text = "Mensaje";
            // 
            // escudo
            // 
            this.escudo.BackgroundImage = global::Ofelia_Sara.Properties.Resources.EscudoPolicia_PNG;  // Asegúrate de que esta imagen esté en tus recursos
            this.escudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.escudo.Location = new System.Drawing.Point(120, 1);  // Posición de la imagen final, alejada 10px del Label
            this.escudo.Name = "escudo";
            this.escudo.Size = new System.Drawing.Size(18, 18);  // Dimensión de 18px
            this.escudo.TabIndex = 2;
            this.escudo.TabStop = false;
            // 
            // TooltipError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.escudo);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.icono);
            this.Name = "TooltipError";
            this.Size = new System.Drawing.Size(150, 20);  // Ajuste el tamaño para que encajen los tres elementos
            ((System.ComponentModel.ISupportInitialize)(this.icono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escudo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox icono;
        private System.Windows.Forms.Label mensaje;
        private System.Windows.Forms.PictureBox escudo;
    }
    #endregion
}

