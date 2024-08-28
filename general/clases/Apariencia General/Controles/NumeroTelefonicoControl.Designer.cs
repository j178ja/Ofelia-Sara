namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    partial class NumeroTelefonicoControl
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
            this.maskedTextBox_Telefono = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // maskedTextBox_Telefono
            // 
            this.maskedTextBox_Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_Telefono.Location = new System.Drawing.Point(0, 0);
            this.maskedTextBox_Telefono.Mask = "(99999)915-00000000";
            this.maskedTextBox_Telefono.Name = "maskedTextBox_Telefono";
            this.maskedTextBox_Telefono.Size = new System.Drawing.Size(230, 22);
            this.maskedTextBox_Telefono.TabIndex = 0;
            this.maskedTextBox_Telefono.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;

            // 
            // NumeroTelefonicoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.maskedTextBox_Telefono);
            this.Name = "NumeroTelefonicoControl";
            this.Size = new System.Drawing.Size(233, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox_Telefono;
    }
}
