namespace Ofelia_Sara.Controles.Controles.Ofl_Sara
{
    partial class AgregarJuzgadoControl
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
            groupBox_ProvenienteJuzgado = new System.Windows.Forms.GroupBox();
            label_Juzgado = new System.Windows.Forms.Label();
            comboBox_Juzgado = new Ofelia_Sara.Controles.General.CustomComboBox();
            label_DrJuzgado = new System.Windows.Forms.Label();
            comboBox_DrJuzgado = new Ofelia_Sara.Controles.General.CustomComboBox();
            groupBox_ProvenienteJuzgado.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_ProvenienteJuzgado
            // 
            groupBox_ProvenienteJuzgado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBox_ProvenienteJuzgado.Controls.Add(label_Juzgado);
            groupBox_ProvenienteJuzgado.Controls.Add(comboBox_Juzgado);
            groupBox_ProvenienteJuzgado.Controls.Add(label_DrJuzgado);
            groupBox_ProvenienteJuzgado.Controls.Add(comboBox_DrJuzgado);
            groupBox_ProvenienteJuzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            groupBox_ProvenienteJuzgado.Location = new System.Drawing.Point(4, 3);
            groupBox_ProvenienteJuzgado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_ProvenienteJuzgado.Name = "groupBox_ProvenienteJuzgado";
            groupBox_ProvenienteJuzgado.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_ProvenienteJuzgado.Size = new System.Drawing.Size(473, 110);
            groupBox_ProvenienteJuzgado.TabIndex = 90;
            groupBox_ProvenienteJuzgado.TabStop = false;
            groupBox_ProvenienteJuzgado.Text = "PROVENIENTE DE JUZGADO";
            groupBox_ProvenienteJuzgado.Enter += groupBox2_Enter;
            // 
            // label_Juzgado
            // 
            label_Juzgado.AutoSize = true;
            label_Juzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Juzgado.Location = new System.Drawing.Point(14, 42);
            label_Juzgado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Juzgado.Name = "label_Juzgado";
            label_Juzgado.Size = new System.Drawing.Size(70, 15);
            label_Juzgado.TabIndex = 78;
            label_Juzgado.Text = "JUZGADO";
            // 
            // comboBox_Juzgado
            // 
            comboBox_Juzgado.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_Juzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            comboBox_Juzgado.Items.AddRange(new object[] { "04", "05", "08" });
            comboBox_Juzgado.Location = new System.Drawing.Point(103, 38);
            comboBox_Juzgado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Juzgado.Name = "comboBox_Juzgado";
            comboBox_Juzgado.Size = new System.Drawing.Size(362, 21);
            comboBox_Juzgado.TabIndex = 77;
            // 
            // label_DrJuzgado
            // 
            label_DrJuzgado.AutoSize = true;
            label_DrJuzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_DrJuzgado.Location = new System.Drawing.Point(56, 70);
            label_DrJuzgado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_DrJuzgado.Name = "label_DrJuzgado";
            label_DrJuzgado.Size = new System.Drawing.Size(26, 15);
            label_DrJuzgado.TabIndex = 74;
            label_DrJuzgado.Text = "Dr.";
            // 
            // comboBox_DrJuzgado
            // 
            comboBox_DrJuzgado.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_DrJuzgado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            comboBox_DrJuzgado.Items.AddRange(new object[] { "Calderón Pablo", "Mercuri Walter", "Zamboni Veronica" });
            comboBox_DrJuzgado.Location = new System.Drawing.Point(103, 69);
            comboBox_DrJuzgado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_DrJuzgado.Name = "comboBox_DrJuzgado";
            comboBox_DrJuzgado.Size = new System.Drawing.Size(362, 21);
            comboBox_DrJuzgado.TabIndex = 75;
            // 
            // AgregarJuzgadoControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(groupBox_ProvenienteJuzgado);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AgregarJuzgadoControl";
            Size = new System.Drawing.Size(481, 116);
            groupBox_ProvenienteJuzgado.ResumeLayout(false);
            groupBox_ProvenienteJuzgado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ProvenienteJuzgado;
        private System.Windows.Forms.Label label_Juzgado;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Juzgado;
        private System.Windows.Forms.Label label_DrJuzgado;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_DrJuzgado;
    }
}
