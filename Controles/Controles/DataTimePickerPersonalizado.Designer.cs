

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles
{
    partial class TimePickerPersonalizado
    {
        private System.ComponentModel.IContainer components = null;
       

        private void InitializeComponent()
        {
            this.Btn_Calendario = new System.Windows.Forms.Button();
            this.textBox_DIA = new System.Windows.Forms.TextBox();
            this.label_DE1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_MES = new System.Windows.Forms.TextBox();
            this.textBox_AÑO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_Calendario
            // 
            this.Btn_Calendario.BackColor = System.Drawing.SystemColors.Window;
            this.Btn_Calendario.BackgroundImage = global::Ofelia_Sara.Properties.Resources.Calendario1;
            this.Btn_Calendario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Calendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Calendario.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Calendario.Location = new System.Drawing.Point(263, 0);
            this.Btn_Calendario.Name = "Btn_Calendario";
            this.Btn_Calendario.Size = new System.Drawing.Size(24, 21);
            this.Btn_Calendario.TabIndex = 1;
            this.Btn_Calendario.UseVisualStyleBackColor = false;
            this.Btn_Calendario.Click += new System.EventHandler(this.Btn_Calendario_Click);
            // 
            // textBox_DIA
            // 
            this.textBox_DIA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DIA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_DIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIA.Location = new System.Drawing.Point(24, 4);
            this.textBox_DIA.Name = "textBox_DIA";
            this.textBox_DIA.Size = new System.Drawing.Size(33, 13);
            this.textBox_DIA.TabIndex = 2;
            this.textBox_DIA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DIA.Click += new System.EventHandler(this.textBox_DIA_Click);
            this.textBox_DIA.TextChanged += new System.EventHandler(this.Limitar_TextUpdate);
            this.textBox_DIA.Enter += new System.EventHandler(this.textBox_DIA_Enter);
            this.textBox_DIA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // label_DE1
            // 
            this.label_DE1.AutoSize = true;
            this.label_DE1.Location = new System.Drawing.Point(58, 4);
            this.label_DE1.Name = "label_DE1";
            this.label_DE1.Size = new System.Drawing.Size(22, 13);
            this.label_DE1.TabIndex = 3;
            this.label_DE1.Text = "DE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DE";
            // 
            // textBox_MES
            // 
            this.textBox_MES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_MES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_MES.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MES.Location = new System.Drawing.Point(80, 4);
            this.textBox_MES.Name = "textBox_MES";
            this.textBox_MES.Size = new System.Drawing.Size(79, 13);
            this.textBox_MES.TabIndex = 5;
            this.textBox_MES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MES.Click += new System.EventHandler(this.textBox_MES_Click);
            this.textBox_MES.Enter += new System.EventHandler(this.textBox_MES_Enter);
            this.textBox_MES.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_MES_KeyPress);
            // 
            // textBox_AÑO
            // 
            this.textBox_AÑO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_AÑO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_AÑO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AÑO.Location = new System.Drawing.Point(188, 4);
            this.textBox_AÑO.Name = "textBox_AÑO";
            this.textBox_AÑO.Size = new System.Drawing.Size(69, 13);
            this.textBox_AÑO.TabIndex = 6;
            this.textBox_AÑO.Click += new System.EventHandler(this.textBox_AÑO_Click);
            this.textBox_AÑO.TextChanged += new System.EventHandler(this.Limitar_TextUpdate);
            this.textBox_AÑO.Enter += new System.EventHandler(this.textBox_AÑO_Enter);
            this.textBox_AÑO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // TimePickerPersonalizado
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.textBox_AÑO);
            this.Controls.Add(this.textBox_MES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_DE1);
            this.Controls.Add(this.textBox_DIA);
            this.Controls.Add(this.Btn_Calendario);
            this.Name = "TimePickerPersonalizado";
            this.Size = new System.Drawing.Size(287, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private TextBox textBox_DIA;
        private Label label_DE1;
        private Label label1;
        private TextBox textBox_MES;
        private TextBox textBox_AÑO;
    }
}

