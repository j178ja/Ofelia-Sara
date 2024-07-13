/*---------------ESTA CLASE MUESTRA LA CONSTRUCCION DE MENSAJE PERSONALIZADO-------------
 --------------WIN-FROM NO PERMITE CAMBIAR COLORES DE "MESSAGE" POR LO QUE SE DEBE CREAR UNA VENTANA---------*/


using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string title, Color backgroundColor, Color textColor)
        {
            InitializeComponent();

            this.Text = title;
            this.BackColor = backgroundColor;
            lblMessage.Text = message;
            lblMessage.ForeColor = textColor;
        }

        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnOK = new Button();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new Point(12, 9);
            this.lblMessage.MaximumSize = new Size(260, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(50, 20);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "label1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new Point(97, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(284, 111);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label lblMessage;
        private Button btnOK;
    }
}
