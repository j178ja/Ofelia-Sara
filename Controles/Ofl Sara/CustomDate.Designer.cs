using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class CustomDate
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox_Date;

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
            components = new System.ComponentModel.Container();
            textBox_Date = new TextBox();
            toolTip1 = new ToolTip(components);
            label_barra = new Label();
            label1 = new Label();
            textBox_DateDIA = new TextBox();
            textBox_DateMES = new TextBox();
            textBox_DateAÑO = new TextBox();
            btn_Calendario = new Button();
            SuspendLayout();
            // 
            // textBox_Date
            // 
            textBox_Date.BackColor = System.Drawing.Color.White;
            textBox_Date.Location = new System.Drawing.Point(1, 1);
            textBox_Date.Name = "textBox_Date";
            textBox_Date.Size = new System.Drawing.Size(120, 23);
            textBox_Date.TabIndex = 0;
            // 
            // label_barra
            // 
            label_barra.BackColor = System.Drawing.Color.White;
            label_barra.FlatStyle = FlatStyle.Flat;
            label_barra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_barra.Location = new System.Drawing.Point(25, 2);
            label_barra.Name = "label_barra";
            label_barra.Size = new System.Drawing.Size(10, 15);
            label_barra.TabIndex = 2;
            label_barra.Text = "/";
            label_barra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.White;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(60, 2);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(10, 15);
            label1.TabIndex = 3;
            label1.Text = "/";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_DateDIA
            // 
            textBox_DateDIA.BackColor = System.Drawing.Color.White;
            textBox_DateDIA.BorderStyle = BorderStyle.None;
            textBox_DateDIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_DateDIA.Location = new System.Drawing.Point(3, 3);
            textBox_DateDIA.Name = "textBox_DateDIA";
            textBox_DateDIA.Size = new System.Drawing.Size(23, 14);
            textBox_DateDIA.TabIndex = 4;
            textBox_DateDIA.TextAlign = HorizontalAlignment.Center;
            textBox_DateDIA.TextChanged += textBox_DateDIA_TextChanged;
            textBox_DateDIA.KeyPress += TextBox_Date_KeyPress;
            // 
            // textBox_DateMES
            // 
            textBox_DateMES.BackColor = System.Drawing.Color.White;
            textBox_DateMES.BorderStyle = BorderStyle.None;
            textBox_DateMES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_DateMES.Location = new System.Drawing.Point(36, 3);
            textBox_DateMES.Name = "textBox_DateMES";
            textBox_DateMES.Size = new System.Drawing.Size(23, 14);
            textBox_DateMES.TabIndex = 5;
            textBox_DateMES.TextAlign = HorizontalAlignment.Center;
            textBox_DateMES.TextChanged += textBox_DateMES_TextChanged;
            textBox_DateMES.KeyPress += TextBox_Date_KeyPress;
            // 
            // textBox_DateAÑO
            // 
            textBox_DateAÑO.BackColor = System.Drawing.Color.White;
            textBox_DateAÑO.BorderStyle = BorderStyle.None;
            textBox_DateAÑO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_DateAÑO.Location = new System.Drawing.Point(72, 3);
            textBox_DateAÑO.Name = "textBox_DateAÑO";
            textBox_DateAÑO.Size = new System.Drawing.Size(45, 14);
            textBox_DateAÑO.TabIndex = 6;
            textBox_DateAÑO.TextChanged += textBox_DateAÑO_TextChanged;
            textBox_DateAÑO.KeyPress += TextBox_Date_KeyPress;
            textBox_DateAÑO.Validating += textBox_DateAÑO_Validating;
            // 
            // btn_Calendario
            // 
            btn_Calendario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Calendario.AutoSize = true;
            btn_Calendario.BackColor = System.Drawing.SystemColors.Window;
            btn_Calendario.BackgroundImage = Properties.Resources.Calendario;
            btn_Calendario.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Calendario.Cursor = Cursors.Hand;
            btn_Calendario.Location = new System.Drawing.Point(124, 0);
            btn_Calendario.Name = "btn_Calendario";
            btn_Calendario.Size = new System.Drawing.Size(27, 23);
            btn_Calendario.TabIndex = 7;
            btn_Calendario.UseVisualStyleBackColor = false;
            btn_Calendario.Click += btn_Calendario_Click;
            // 
            // CustomDate
            // 
            Controls.Add(btn_Calendario);
            Controls.Add(textBox_DateAÑO);
            Controls.Add(textBox_DateMES);
            Controls.Add(textBox_DateDIA);
            Controls.Add(label1);
            Controls.Add(label_barra);
            Controls.Add(textBox_Date);
            Name = "CustomDate";
            Size = new System.Drawing.Size(151, 23);
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolTip toolTip1;
        private Label label_barra;
        private Label label1;
        public TextBox textBox_DateDIA;
        public TextBox textBox_DateMES;
        public TextBox textBox_DateAÑO;
        private Button btn_Calendario;
    }
}
