

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class TimePickerPersonalizado
    {
        private System.ComponentModel.IContainer components = null;


        private void InitializeComponent()
        {
            Btn_Calendario = new Button();
            textBox_DIA = new TextBox();
            label_DE1 = new Label();
            label1 = new Label();
            textBox_MES = new TextBox();
            textBox_AÑO = new TextBox();
            SuspendLayout();
            // 
            // Btn_Calendario
            // 
            Btn_Calendario.AutoSize = true;
            Btn_Calendario.BackColor = SystemColors.Window;
            Btn_Calendario.BackgroundImage = Properties.Resources.Calendario;
            Btn_Calendario.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_Calendario.Cursor = Cursors.Hand;
            Btn_Calendario.Dock = DockStyle.Right;
            Btn_Calendario.Location = new Point(263, 0);
            Btn_Calendario.Name = "Btn_Calendario";
            Btn_Calendario.Size = new Size(24, 19);
            Btn_Calendario.TabIndex = 1;
            Btn_Calendario.UseVisualStyleBackColor = false;
            Btn_Calendario.Click += Btn_Calendario_Click;
            // 
            // textBox_DIA
            // 
            textBox_DIA.BorderStyle = BorderStyle.None;
            textBox_DIA.Cursor = Cursors.Hand;
            textBox_DIA.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_DIA.Location = new Point(24, 4);
            textBox_DIA.Name = "textBox_DIA";
            textBox_DIA.Size = new Size(33, 13);
            textBox_DIA.TabIndex = 2;
            textBox_DIA.TextAlign = HorizontalAlignment.Center;
            textBox_DIA.Click += textBox_DIA_Click;
            textBox_DIA.TextChanged += Limitar_TextUpdate;
            textBox_DIA.Enter += textBox_DIA_Enter;
            textBox_DIA.KeyPress += SoloNumeros_KeyPress;
            // 
            // label_DE1
            // 
            label_DE1.AutoSize = true;
            label_DE1.Location = new Point(58, 3);
            label_DE1.Name = "label_DE1";
            label_DE1.Size = new Size(21, 15);
            label_DE1.TabIndex = 3;
            label_DE1.Text = "DE";
            label_DE1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 3);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 4;
            label1.Text = "DE";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // textBox_MES
            // 
            textBox_MES.BorderStyle = BorderStyle.None;
            textBox_MES.Cursor = Cursors.Hand;
            textBox_MES.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_MES.Location = new Point(80, 4);
            textBox_MES.Name = "textBox_MES";
            textBox_MES.Size = new Size(79, 13);
            textBox_MES.TabIndex = 5;
            textBox_MES.TextAlign = HorizontalAlignment.Center;
            textBox_MES.Click += textBox_MES_Click;
            textBox_MES.Enter += textBox_MES_Enter;
            textBox_MES.KeyPress += textBox_MES_KeyPress;
            // 
            // textBox_AÑO
            // 
            textBox_AÑO.BorderStyle = BorderStyle.None;
            textBox_AÑO.Cursor = Cursors.Hand;
            textBox_AÑO.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_AÑO.Location = new Point(188, 4);
            textBox_AÑO.Name = "textBox_AÑO";
            textBox_AÑO.Size = new Size(55, 13);
            textBox_AÑO.TabIndex = 6;
            textBox_AÑO.Click += textBox_AÑO_Click;
            textBox_AÑO.TextChanged += Limitar_TextUpdate;
            textBox_AÑO.Enter += textBox_AÑO_Enter;
            textBox_AÑO.KeyPress += SoloNumeros_KeyPress;
            // 
            // TimePickerPersonalizado
            // 
            BackColor = SystemColors.Window;
            Controls.Add(textBox_AÑO);
            Controls.Add(textBox_MES);
            Controls.Add(label1);
            Controls.Add(label_DE1);
            Controls.Add(textBox_DIA);
            Controls.Add(Btn_Calendario);
            Name = "TimePickerPersonalizado";
            Size = new Size(287, 19);
            ResumeLayout(false);
            PerformLayout();
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

