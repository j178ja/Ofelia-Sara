namespace Ofelia_Sara.general.clases.Apariencia_General
{
    partial class TimePickerPersonalizado
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
            this.dateTimePickerGeneral = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateTimePickerGeneral
            // 
            this.dateTimePickerGeneral.CustomFormat = "\"dd \' DE  \' MMMM\' DE  \' yyyy\"";
            this.dateTimePickerGeneral.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerGeneral.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerGeneral.Location = new System.Drawing.Point(0, 0);
            this.dateTimePickerGeneral.Name = "dateTimePickerGeneral";
            this.dateTimePickerGeneral.Size = new System.Drawing.Size(279, 22);
            this.dateTimePickerGeneral.TabIndex = 1;
            this.dateTimePickerGeneral.ValueChanged += new System.EventHandler(this.dateTimePickerGeneral_ValueChanged_1);
            // 
            // TimePickerPersonalizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.dateTimePickerGeneral);
            this.Name = "TimePickerPersonalizado";
            this.Size = new System.Drawing.Size(278, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerGeneral;
    }
}
