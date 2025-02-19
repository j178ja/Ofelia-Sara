using Ofelia_Sara.Controles.General;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class CustomDate
    {
        private System.ComponentModel.IContainer components = null;

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
            label_barra2 = new Label();
            label_barra1 = new Label();
            textBox_DateDIA = new CustomTextBox();
            textBox_DateMES = new CustomTextBox();
            textBox_DateAÑO = new CustomTextBox();
            btn_Calendario = new Button();
            panel_ContenedorFecha = new Panel();
            panel_ContenedorFecha.SuspendLayout();
            SuspendLayout();
            // 
            // label_barra2
            // 
            label_barra2.Anchor = AnchorStyles.None;
            label_barra2.BackColor = System.Drawing.Color.White;
            label_barra2.FlatStyle = FlatStyle.Popup;
            label_barra2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_barra2.Location = new System.Drawing.Point(27, 3);
            label_barra2.Margin = new Padding(0);
            label_barra2.Name = "label_barra2";
            label_barra2.Size = new System.Drawing.Size(10, 15);
            label_barra2.TabIndex = 2;
            label_barra2.Text = "/";
            label_barra2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_barra1
            // 
            label_barra1.Anchor = AnchorStyles.None;
            label_barra1.BackColor = System.Drawing.Color.White;
            label_barra1.FlatStyle = FlatStyle.Flat;
            label_barra1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_barra1.Location = new System.Drawing.Point(73, 1);
            label_barra1.Margin = new Padding(0);
            label_barra1.Name = "label_barra1";
            label_barra1.Size = new System.Drawing.Size(10, 14);
            label_barra1.TabIndex = 3;
            label_barra1.Text = "/";
            label_barra1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_DateDIA
            // 
            textBox_DateDIA.AutoCompleteMode = AutoCompleteMode.None;
            textBox_DateDIA.AutoCompleteSource = AutoCompleteSource.None;
            textBox_DateDIA.BackColor = System.Drawing.Color.White;
            textBox_DateDIA.Cursor = Cursors.Hand;
            textBox_DateDIA.ErrorColor = System.Drawing.Color.Red;
            textBox_DateDIA.FocusColor = System.Drawing.Color.Blue;
            textBox_DateDIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_DateDIA.Location = new System.Drawing.Point(2, 0);
            textBox_DateDIA.MaxLength = 32767;
            textBox_DateDIA.Multiline = false;
            textBox_DateDIA.Name = "textBox_DateDIA";
            textBox_DateDIA.PasswordChar = '\0';
            textBox_DateDIA.PlaceholderColor = System.Drawing.Color.LightGray;
            textBox_DateDIA.PlaceholderText = "";
            textBox_DateDIA.ReadOnly = false;
            textBox_DateDIA.SelectionStart = 0;
            textBox_DateDIA.ShowError = false;
            textBox_DateDIA.Size = new System.Drawing.Size(23, 20);
            textBox_DateDIA.TabIndex = 0;
            textBox_DateDIA.TextAlign = HorizontalAlignment.Center;
            textBox_DateDIA.TextValue = "";
            textBox_DateDIA.Whidth = 0;
            // 
            // textBox_DateMES
            // 
            textBox_DateMES.AutoCompleteMode = AutoCompleteMode.None;
            textBox_DateMES.AutoCompleteSource = AutoCompleteSource.None;
            textBox_DateMES.BackColor = System.Drawing.Color.White;
            textBox_DateMES.Cursor = Cursors.Hand;
            textBox_DateMES.ErrorColor = System.Drawing.Color.Red;
            textBox_DateMES.FocusColor = System.Drawing.Color.Blue;
            textBox_DateMES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_DateMES.Location = new System.Drawing.Point(35, 0);
            textBox_DateMES.MaxLength = 32767;
            textBox_DateMES.Multiline = false;
            textBox_DateMES.Name = "textBox_DateMES";
            textBox_DateMES.PasswordChar = '\0';
            textBox_DateMES.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_DateMES.PlaceholderText = "";
            textBox_DateMES.ReadOnly = false;
            textBox_DateMES.SelectionStart = 0;
            textBox_DateMES.ShowError = false;
            textBox_DateMES.Size = new System.Drawing.Size(35, 20);
            textBox_DateMES.TabIndex = 1;
            textBox_DateMES.TextAlign = HorizontalAlignment.Center;
            textBox_DateMES.TextValue = "";
            textBox_DateMES.Whidth = 0;
            // 
            // textBox_DateAÑO
            // 
            textBox_DateAÑO.AutoCompleteMode = AutoCompleteMode.None;
            textBox_DateAÑO.AutoCompleteSource = AutoCompleteSource.None;
            textBox_DateAÑO.BackColor = System.Drawing.Color.White;
            textBox_DateAÑO.Cursor = Cursors.Hand;
            textBox_DateAÑO.ErrorColor = System.Drawing.Color.Red;
            textBox_DateAÑO.FocusColor = System.Drawing.Color.Blue;
            textBox_DateAÑO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_DateAÑO.Location = new System.Drawing.Point(84, 0);
            textBox_DateAÑO.MaxLength = 32767;
            textBox_DateAÑO.Multiline = false;
            textBox_DateAÑO.Name = "textBox_DateAÑO";
            textBox_DateAÑO.PasswordChar = '\0';
            textBox_DateAÑO.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_DateAÑO.PlaceholderText = "";
            textBox_DateAÑO.ReadOnly = false;
            textBox_DateAÑO.SelectionStart = 0;
            textBox_DateAÑO.ShowError = false;
            textBox_DateAÑO.Size = new System.Drawing.Size(41, 20);
            textBox_DateAÑO.TabIndex = 2;
            textBox_DateAÑO.TextAlign = HorizontalAlignment.Left;
            textBox_DateAÑO.TextValue = "";
            textBox_DateAÑO.Whidth = 0;
            // 
            // btn_Calendario
            // 
            btn_Calendario.AutoSize = true;
            btn_Calendario.BackColor = System.Drawing.SystemColors.Window;
            btn_Calendario.BackgroundImage = Properties.Resources.Calendario;
            btn_Calendario.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Calendario.Cursor = Cursors.Hand;
            btn_Calendario.Location = new System.Drawing.Point(128, 0);
            btn_Calendario.Name = "btn_Calendario";
            btn_Calendario.Size = new System.Drawing.Size(27, 22);
            btn_Calendario.TabIndex = 7;
            btn_Calendario.UseVisualStyleBackColor = false;
            btn_Calendario.Click += Btn_Calendario_Click;
            // 
            // panel_ContenedorFecha
            // 
            panel_ContenedorFecha.BackColor = System.Drawing.Color.White;
            panel_ContenedorFecha.Controls.Add(textBox_DateMES);
            panel_ContenedorFecha.Controls.Add(label_barra2);
            panel_ContenedorFecha.Controls.Add(textBox_DateAÑO);
            panel_ContenedorFecha.Controls.Add(label_barra1);
            panel_ContenedorFecha.Controls.Add(textBox_DateDIA);
            panel_ContenedorFecha.Location = new System.Drawing.Point(0, 0);
            panel_ContenedorFecha.Margin = new Padding(0);
            panel_ContenedorFecha.Name = "panel_ContenedorFecha";
            panel_ContenedorFecha.Size = new System.Drawing.Size(125, 20);
            panel_ContenedorFecha.TabIndex = 8;
            // 
            // CustomDate
            // 
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(panel_ContenedorFecha);
            Controls.Add(btn_Calendario);
            Name = "CustomDate";
            Size = new System.Drawing.Size(158, 25);
            panel_ContenedorFecha.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label_barra2;
        private Label label_barra1;
        public CustomTextBox textBox_DateDIA;
        public CustomTextBox textBox_DateMES;
        public CustomTextBox textBox_DateAÑO;
        private Button btn_Calendario;
        private Panel panel_ContenedorFecha;
    }
}
