

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General
{
    partial class TimePickerPersonalizado
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerGeneral;

        private void InitializeComponent()
        {
            this.dateTimePickerGeneral = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateTimePickerGeneral
            // 
            this.dateTimePickerGeneral.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerGeneral.CustomFormat = "dd 'DE' MMMM 'DE' yyyy"; // Formato específico para INICIO-CIERRE e IPP
            this.dateTimePickerGeneral.Value = DateTime.Now;
            this.dateTimePickerGeneral.ShowUpDown = false; // Permite seleccionar fecha y hora
            this.dateTimePickerGeneral.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right; // Alinea el calendario a la derecha del control
            this.dateTimePickerGeneral.ValueChanged += new System.EventHandler(this.DateTimePickerGeneral_ValueChanged);
            this.Controls.Add(this.dateTimePickerGeneral);
            // 
            // TimePickerPersonalizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TimePickerPersonalizado";
            this.SizeChanged += new System.EventHandler(this.TimePickerPersonalizado_SizeChanged);
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
