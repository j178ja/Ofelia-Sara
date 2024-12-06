namespace Ofelia_Sara.Controles.Controles
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
            this.SelectHora_Compromiso = new System.Windows.Forms.MaskedTextBox();
            this.panel_Horario = new System.Windows.Forms.Panel();
            this.SelectFecha_Compromiso = new Ofelia_Sara.Controles.Controles.TimePickerPersonalizado();
            this.panel_Horario.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectHora_Compromiso
            // 
            this.SelectHora_Compromiso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectHora_Compromiso.CausesValidation = false;
            this.SelectHora_Compromiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectHora_Compromiso.Location = new System.Drawing.Point(5, 3);
            this.SelectHora_Compromiso.Mask = "00:00 hs.";
            this.SelectHora_Compromiso.Name = "SelectHora_Compromiso";
            this.SelectHora_Compromiso.Size = new System.Drawing.Size(61, 17);
            this.SelectHora_Compromiso.TabIndex = 7;
            this.SelectHora_Compromiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SelectHora_Compromiso.Validating += new System.ComponentModel.CancelEventHandler(this.SelectedHora_Compromiso_Validating);
            // 
            // panel_Horario
            // 
            this.panel_Horario.BackColor = System.Drawing.SystemColors.Window;
            this.panel_Horario.Controls.Add(this.SelectHora_Compromiso);
            this.panel_Horario.Location = new System.Drawing.Point(290, 0);
            this.panel_Horario.Name = "panel_Horario";
            this.panel_Horario.Size = new System.Drawing.Size(70, 21);
            this.panel_Horario.TabIndex = 9;
            // 
            // SelectFecha_Compromiso
            // 
            this.SelectFecha_Compromiso.BackColor = System.Drawing.SystemColors.Window;
            this.SelectFecha_Compromiso.FechaSeleccionada = new System.DateTime(((long)(0)));
            this.SelectFecha_Compromiso.Location = new System.Drawing.Point(0, 0);
            this.SelectFecha_Compromiso.Name = "SelectFecha_Compromiso";
            this.SelectFecha_Compromiso.SelectedDate = new System.DateTime(2024, 12, 5, 0, 0, 0, 0);
            this.SelectFecha_Compromiso.Size = new System.Drawing.Size(287, 21);
            this.SelectFecha_Compromiso.TabIndex = 8;
            // 
            // DateCompromiso_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.panel_Horario);
            this.Controls.Add(this.SelectFecha_Compromiso);
            this.Name = "DateCompromiso_Control";
            this.Size = new System.Drawing.Size(363, 24);
            this.panel_Horario.ResumeLayout(false);
            this.panel_Horario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox SelectHora_Compromiso;
        private TimePickerPersonalizado SelectFecha_Compromiso;
        private System.Windows.Forms.Panel panel_Horario;
    }
}
