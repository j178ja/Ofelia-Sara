namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class NuevaCaratulaControl
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
            components = new System.ComponentModel.Container();
            label_Caratula = new System.Windows.Forms.Label();
            textBox_Caratula = new General.CustomTextBox();
            btn_EliminarControl = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            SuspendLayout();
            // 
            // label_Caratula
            // 
            label_Caratula.BackColor = System.Drawing.Color.Transparent;
            label_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Caratula.Location = new System.Drawing.Point(0, 3);
            label_Caratula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Caratula.Name = "label_Caratula";
            label_Caratula.Size = new System.Drawing.Size(97, 21);
            label_Caratula.TabIndex = 41;
            label_Caratula.Text = "Caratula ";
            label_Caratula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Caratula
            // 
            textBox_Caratula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Caratula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Caratula.BackColor = System.Drawing.Color.White;
            textBox_Caratula.ErrorColor = System.Drawing.Color.Red;
            textBox_Caratula.FocusColor = System.Drawing.Color.Blue;
            textBox_Caratula.Location = new System.Drawing.Point(102, 3);
            textBox_Caratula.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Caratula.MaxLength = 32767;
            textBox_Caratula.Multiline = false;
            textBox_Caratula.Name = "textBox_Caratula";
            textBox_Caratula.PasswordChar = '\0';
            textBox_Caratula.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Caratula.PlaceholderText = "";
            textBox_Caratula.ReadOnly = false;
            textBox_Caratula.SelectionStart = 0;
            textBox_Caratula.ShowError = false;
            textBox_Caratula.Size = new System.Drawing.Size(334, 21);
            textBox_Caratula.TabIndex = 42;
            textBox_Caratula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Caratula.TextValue = "";
            textBox_Caratula.TextChanged += TextBox_Caratula_TextChanged;
            textBox_Caratula.KeyPress += TextBox_Caratula_KeyPress;
            // 
            // btn_EliminarControl
            // 
            btn_EliminarControl.BackColor = System.Drawing.Color.WhiteSmoke;
            btn_EliminarControl.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_EliminarControl.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
            btn_EliminarControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            btn_EliminarControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btn_EliminarControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_EliminarControl.ForeColor = System.Drawing.Color.IndianRed;
            btn_EliminarControl.Location = new System.Drawing.Point(439, 0);
            btn_EliminarControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_EliminarControl.Name = "btn_EliminarControl";
            btn_EliminarControl.Size = new System.Drawing.Size(18, 27);
            btn_EliminarControl.TabIndex = 44;
            btn_EliminarControl.Text = "-";
            toolTip1.SetToolTip(btn_EliminarControl, "Eliminar");
            btn_EliminarControl.UseVisualStyleBackColor = false;
            btn_EliminarControl.Click += Btn_EliminarControl_Click;
            // 
            // NuevaCaratulaControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(btn_EliminarControl);
            Controls.Add(textBox_Caratula);
            Controls.Add(label_Caratula);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "NuevaCaratulaControl";
            Size = new System.Drawing.Size(461, 28);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label_Caratula;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Caratula;
        private System.Windows.Forms.Button btn_EliminarControl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
