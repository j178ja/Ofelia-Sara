namespace Ofelia_Sara.Controles.Ofl_Sara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailControl));
            textBox_Email = new General.CustomTextBox();
            label_arroba = new System.Windows.Forms.Label();
            comboBox_EmpresaEmail = new General.CustomComboBox();
            SuspendLayout();
            // 
            // textBox_Email
            // 
            textBox_Email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Email.BackColor = System.Drawing.Color.White;
            textBox_Email.ErrorColor = System.Drawing.Color.Red;
            textBox_Email.FocusColor = System.Drawing.Color.Blue;
            textBox_Email.Location = new System.Drawing.Point(0, 0);
            textBox_Email.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Email.MaxLength = 32767;
            textBox_Email.Multiline = false;
            textBox_Email.Name = "textBox_Email";
            textBox_Email.PasswordChar = '\0';
            textBox_Email.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Email.PlaceholderText = "";
            textBox_Email.ReadOnly = false;
            textBox_Email.SelectionStart = 0;
            textBox_Email.ShowError = false;
            textBox_Email.Size = new System.Drawing.Size(268, 23);
            textBox_Email.TabIndex = 0;
            textBox_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            textBox_Email.TextValue = "";
            // 
            // label_arroba
            // 
            label_arroba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_arroba.Location = new System.Drawing.Point(275, 1);
            label_arroba.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_arroba.Name = "label_arroba";
            label_arroba.Size = new System.Drawing.Size(20, 18);
            label_arroba.TabIndex = 2;
            label_arroba.Text = "@";
            label_arroba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_EmpresaEmail
            // 
            comboBox_EmpresaEmail.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_EmpresaEmail.ArrowImage");
            comboBox_EmpresaEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_EmpresaEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_EmpresaEmail.BackColor = System.Drawing.Color.White;
            comboBox_EmpresaEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_EmpresaEmail.DataSource = null;
            comboBox_EmpresaEmail.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_EmpresaEmail.DefaultImage");
            comboBox_EmpresaEmail.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_EmpresaEmail.DisabledImage");
            comboBox_EmpresaEmail.DisplayMember = null;
            comboBox_EmpresaEmail.DropDownHeight = 110;
            comboBox_EmpresaEmail.DropDownStyle = General.CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_EmpresaEmail.DroppedDown = false;
            comboBox_EmpresaEmail.ErrorColor = System.Drawing.Color.Red;
            comboBox_EmpresaEmail.FocusColor = System.Drawing.Color.Blue;
            comboBox_EmpresaEmail.Location = new System.Drawing.Point(296, 0);
            comboBox_EmpresaEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_EmpresaEmail.MaxDropDownItems = 10;
            comboBox_EmpresaEmail.Name = "comboBox_EmpresaEmail";
            comboBox_EmpresaEmail.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_EmpresaEmail.PlaceholderText = " ";
            comboBox_EmpresaEmail.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_EmpresaEmail.PressedImage");
            comboBox_EmpresaEmail.SelectedIndex = -1;
            comboBox_EmpresaEmail.SelectedItem = null;
            comboBox_EmpresaEmail.SelectedText = "";
            comboBox_EmpresaEmail.SelectionStart = 0;
            comboBox_EmpresaEmail.ShowError = false;
            comboBox_EmpresaEmail.Size = new System.Drawing.Size(88, 24);
            comboBox_EmpresaEmail.TabIndex = 3;
            comboBox_EmpresaEmail.Text = "gmail.com";
            comboBox_EmpresaEmail.TextValue = " ";
            comboBox_EmpresaEmail.TextChanged += comboBox_EmpresaEmail_TextChanged;
            // 
            // EmailControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(comboBox_EmpresaEmail);
            Controls.Add(label_arroba);
            Controls.Add(textBox_Email);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "EmailControl";
            Size = new System.Drawing.Size(384, 23);
            ResumeLayout(false);
        }

        #endregion

        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Email;
        private System.Windows.Forms.Label label_arroba;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_EmpresaEmail;
    }
}
