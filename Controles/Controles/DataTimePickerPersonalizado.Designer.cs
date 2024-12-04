

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles
{
    partial class TimePickerPersonalizado
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerGeneral;

        private void InitializeComponent()
        {
            this.dateTimePickerPersonalizado = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateTimePickerPersonalizado
            // 
            this.dateTimePickerPersonalizado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerPersonalizado.CustomFormat = "dd \'DE\' MMMM \'DE\' yyyy";
            this.dateTimePickerPersonalizado.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerPersonalizado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPersonalizado.Location = new System.Drawing.Point(0, 0);
            this.dateTimePickerPersonalizado.Name = "dateTimePickerPersonalizado";
            this.dateTimePickerPersonalizado.Size = new System.Drawing.Size(286, 21);
            this.dateTimePickerPersonalizado.TabIndex = 0;
            this.dateTimePickerPersonalizado.Value = new System.DateTime(2024, 12, 3, 20, 29, 41, 389);
            this.dateTimePickerPersonalizado.ValueChanged += new System.EventHandler(this.dateTimePickerPersonalizado_ValueChanged);
            // 
            // TimePickerPersonalizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePickerPersonalizado);
            this.Name = "TimePickerPersonalizado";
            this.Size = new System.Drawing.Size(287, 21);
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
