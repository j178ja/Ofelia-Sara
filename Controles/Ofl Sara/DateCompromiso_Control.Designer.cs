namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class DateCompromiso_Control
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
            SelectHora_Compromiso = new System.Windows.Forms.MaskedTextBox();
            panel_Horario = new System.Windows.Forms.Panel();
            SelectFecha_Compromiso = new TimePickerPersonalizado();
            panel_Horario.SuspendLayout();
            SuspendLayout();
            // 
            // SelectHora_Compromiso
            // 
            SelectHora_Compromiso.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            SelectHora_Compromiso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SelectHora_Compromiso.CausesValidation = false;
            SelectHora_Compromiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            SelectHora_Compromiso.Location = new System.Drawing.Point(4, 3);
            SelectHora_Compromiso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SelectHora_Compromiso.Mask = "00:00 hs.";
            SelectHora_Compromiso.Name = "SelectHora_Compromiso";
            SelectHora_Compromiso.Size = new System.Drawing.Size(65, 17);
            SelectHora_Compromiso.TabIndex = 7;
            SelectHora_Compromiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            SelectHora_Compromiso.Validating += SelectedHora_Compromiso_Validating;
            // 
            // panel_Horario
            // 
            panel_Horario.BackColor = System.Drawing.SystemColors.Window;
            panel_Horario.Controls.Add(SelectHora_Compromiso);
            panel_Horario.Location = new System.Drawing.Point(306, 0);
            panel_Horario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_Horario.Name = "panel_Horario";
            panel_Horario.Size = new System.Drawing.Size(71, 21);
            panel_Horario.TabIndex = 9;
            // 
            // SelectFecha_Compromiso
            // 
            SelectFecha_Compromiso.BackColor = System.Drawing.SystemColors.Window;
            SelectFecha_Compromiso.FechaSeleccionada = new System.DateTime(0L);
            SelectFecha_Compromiso.Location = new System.Drawing.Point(0, 0);
            SelectFecha_Compromiso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SelectFecha_Compromiso.Name = "SelectFecha_Compromiso";
         //   SelectFecha_Compromiso.SelectedDate = new System.DateTime(2024, 12, 5, 0, 0, 0, 0);
            SelectFecha_Compromiso.Size = new System.Drawing.Size(302, 21);
            SelectFecha_Compromiso.TabIndex = 8;
            // 
            // DateCompromiso_Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            Controls.Add(panel_Horario);
            Controls.Add(SelectFecha_Compromiso);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DateCompromiso_Control";
            Size = new System.Drawing.Size(377, 24);
            panel_Horario.ResumeLayout(false);
            panel_Horario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.MaskedTextBox SelectHora_Compromiso;
        private TimePickerPersonalizado SelectFecha_Compromiso;
        private System.Windows.Forms.Panel panel_Horario;
    }
}
