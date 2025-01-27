namespace Ofelia_Sara.Controles.Ofl_Sara
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
            maskedTextBox_Telefono = new System.Windows.Forms.MaskedTextBox();
            panel_ContenedorMasked = new System.Windows.Forms.Panel();
            panel_ContenedorMasked.SuspendLayout();
            SuspendLayout();
            // 
            // maskedTextBox_Telefono
            // 
            maskedTextBox_Telefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            maskedTextBox_Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            maskedTextBox_Telefono.Location = new System.Drawing.Point(2, 2);
            maskedTextBox_Telefono.Margin = new System.Windows.Forms.Padding(0);
            maskedTextBox_Telefono.Mask = " +54  (99999)  15-0   0000000";
            maskedTextBox_Telefono.Name = "maskedTextBox_Telefono";
            maskedTextBox_Telefono.Size = new System.Drawing.Size(189, 15);
            maskedTextBox_Telefono.TabIndex = 0;
            maskedTextBox_Telefono.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // panel_ContenedorMasked
            // 
            panel_ContenedorMasked.BackColor = System.Drawing.Color.White;
            panel_ContenedorMasked.Controls.Add(maskedTextBox_Telefono);
            panel_ContenedorMasked.Location = new System.Drawing.Point(0, 0);
            panel_ContenedorMasked.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            panel_ContenedorMasked.Name = "panel_ContenedorMasked";
            panel_ContenedorMasked.Size = new System.Drawing.Size(198, 21);
            panel_ContenedorMasked.TabIndex = 1;
            // 
            // NumeroTelefonicoControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(panel_ContenedorMasked);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "NumeroTelefonicoControl";
            Size = new System.Drawing.Size(201, 26);
            Load += NumeroTelefonicoControl_Load;
            panel_ContenedorMasked.ResumeLayout(false);
            panel_ContenedorMasked.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox_Telefono;
        private System.Windows.Forms.Panel panel_ContenedorMasked;
    }
}
