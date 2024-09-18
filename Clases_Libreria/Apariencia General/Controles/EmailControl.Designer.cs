namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    partial class EmailControl
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
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label_arroba = new System.Windows.Forms.Label();
            this.comboBox_EmpresaEmail = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(0, 0);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(230, 20);
            this.textBox_Email.TabIndex = 0;
            this.textBox_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            // 
            // label_arroba
            // 
            this.label_arroba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_arroba.Location = new System.Drawing.Point(236, 1);
            this.label_arroba.Name = "label_arroba";
            this.label_arroba.Size = new System.Drawing.Size(17, 16);
            this.label_arroba.TabIndex = 2;
            this.label_arroba.Text = "@";
            this.label_arroba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_EmpresaEmail
            // 
            this.comboBox_EmpresaEmail.FormattingEnabled = true;
            this.comboBox_EmpresaEmail.Items.AddRange(new object[] {
            "gmail.com",
            "hotmail.com",
            "outlook.com"});
            this.comboBox_EmpresaEmail.Location = new System.Drawing.Point(254, 0);
            this.comboBox_EmpresaEmail.Name = "comboBox_EmpresaEmail";
            this.comboBox_EmpresaEmail.Size = new System.Drawing.Size(75, 21);
            this.comboBox_EmpresaEmail.TabIndex = 3;
            this.comboBox_EmpresaEmail.Text = "gmail.com";
            this.comboBox_EmpresaEmail.TextChanged += new System.EventHandler(this.comboBox_EmpresaEmail_TextChanged);
            // 
            // EmailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_EmpresaEmail);
            this.Controls.Add(this.label_arroba);
            this.Controls.Add(this.textBox_Email);
            this.Name = "EmailControl";
            this.Size = new System.Drawing.Size(329, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label_arroba;
        private System.Windows.Forms.ComboBox comboBox_EmpresaEmail;
    }
}
