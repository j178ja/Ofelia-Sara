using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles
{
    partial class DateNacimiento
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox_Date;
        private System.Windows.Forms.Button btn_Calendario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_Date = new System.Windows.Forms.TextBox();
            this.btn_Calendario = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_barra = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_DateDIA = new System.Windows.Forms.TextBox();
            this.textBox_DateMES = new System.Windows.Forms.TextBox();
            this.textBox_DateAÑO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Date
            // 
            this.textBox_Date.BackColor = System.Drawing.Color.White;
            this.textBox_Date.Location = new System.Drawing.Point(1, 1);
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.Size = new System.Drawing.Size(120, 20);
            this.textBox_Date.TabIndex = 0;
            // 
            // btn_Calendario
            // 
            this.btn_Calendario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Calendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Calendario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Calendario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Calendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Calendario.Location = new System.Drawing.Point(127, 1);
            this.btn_Calendario.Name = "btn_Calendario";
            this.btn_Calendario.Size = new System.Drawing.Size(18, 20);
            this.btn_Calendario.TabIndex = 1;
            this.btn_Calendario.Text = "...";
            this.toolTip1.SetToolTip(this.btn_Calendario, "Seleccione fecha");
            this.btn_Calendario.UseVisualStyleBackColor = false;
            this.btn_Calendario.Click += new System.EventHandler(this.btn_Calendario_Click);
            // 
            // label_barra
            // 
            this.label_barra.BackColor = System.Drawing.Color.White;
            this.label_barra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_barra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_barra.Location = new System.Drawing.Point(25, 2);
            this.label_barra.Name = "label_barra";
            this.label_barra.Size = new System.Drawing.Size(10, 15);
            this.label_barra.TabIndex = 2;
            this.label_barra.Text = "/";
            this.label_barra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "/";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_DateDIA
            // 
            this.textBox_DateDIA.BackColor = System.Drawing.Color.White;
            this.textBox_DateDIA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DateDIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DateDIA.Location = new System.Drawing.Point(3, 3);
            this.textBox_DateDIA.Name = "textBox_DateDIA";
            this.textBox_DateDIA.Size = new System.Drawing.Size(23, 14);
            this.textBox_DateDIA.TabIndex = 4;
            this.textBox_DateDIA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DateDIA.TextChanged += new System.EventHandler(this.textBox_DateDIA_TextChanged);
            // 
            // textBox_DateMES
            // 
            this.textBox_DateMES.BackColor = System.Drawing.Color.White;
            this.textBox_DateMES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DateMES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DateMES.Location = new System.Drawing.Point(36, 3);
            this.textBox_DateMES.Name = "textBox_DateMES";
            this.textBox_DateMES.Size = new System.Drawing.Size(23, 14);
            this.textBox_DateMES.TabIndex = 5;
            this.textBox_DateMES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DateMES.TextChanged += new System.EventHandler(this.textBox_DateMES_TextChanged);
            // 
            // textBox_DateAÑO
            // 
            this.textBox_DateAÑO.BackColor = System.Drawing.Color.White;
            this.textBox_DateAÑO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DateAÑO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DateAÑO.Location = new System.Drawing.Point(72, 3);
            this.textBox_DateAÑO.Name = "textBox_DateAÑO";
            this.textBox_DateAÑO.Size = new System.Drawing.Size(45, 14);
            this.textBox_DateAÑO.TabIndex = 6;
            this.textBox_DateAÑO.TextChanged += new System.EventHandler(this.textBox_DateAÑO_TextChanged);
            // 
            // CustomDateTextBox
            // 
            this.Controls.Add(this.textBox_DateAÑO);
            this.Controls.Add(this.textBox_DateMES);
            this.Controls.Add(this.textBox_DateDIA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_barra);
            this.Controls.Add(this.btn_Calendario);
            this.Controls.Add(this.textBox_Date);
            this.Name = "CustomDateTextBox";
            this.Size = new System.Drawing.Size(150, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolTip toolTip1;
        private Label label_barra;
        private Label label1;
        public TextBox textBox_DateDIA;
        public TextBox textBox_DateMES;
        public TextBox textBox_DateAÑO;

    }
}
