namespace Ofelia_Sara.Formularios
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBoxIMG1 = new comboBoxIMG();
            this.SuspendLayout();
            // 
            // comboBoxIMG1
            // 
            this.comboBoxIMG1.BorderColor = System.Drawing.Color.Blue;
            this.comboBoxIMG1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIMG1.Location = new System.Drawing.Point(339, 58);
            this.comboBoxIMG1.Name = "comboBoxIMG1";
            this.comboBoxIMG1.SelectedIndex = -1;
            this.comboBoxIMG1.SelectedItem = null;
            this.comboBoxIMG1.SelectedText = "";
            this.comboBoxIMG1.Size = new System.Drawing.Size(231, 39);
            this.comboBoxIMG1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxIMG1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private comboBoxIMG comboBoxIMG1;
    }
}