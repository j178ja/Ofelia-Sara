namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
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
            this.components = new System.ComponentModel.Container();
            this.label_Caratula = new System.Windows.Forms.Label();
            this.textBox_Caratula = new System.Windows.Forms.TextBox();
            this.btn_EliminarControl = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label_Caratula
            // 
            this.label_Caratula.BackColor = System.Drawing.Color.Transparent;
            this.label_Caratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Caratula.Location = new System.Drawing.Point(0, 3);
            this.label_Caratula.Name = "label_Caratula";
            this.label_Caratula.Size = new System.Drawing.Size(95, 19);
            this.label_Caratula.TabIndex = 41;
            this.label_Caratula.Text = "Caratula ";
            // 
            // textBox_Caratula
            // 
            this.textBox_Caratula.Location = new System.Drawing.Point(90, 2);
            this.textBox_Caratula.Name = "textBox_Caratula";
            this.textBox_Caratula.Size = new System.Drawing.Size(265, 20);
            this.textBox_Caratula.TabIndex = 42;
            this.textBox_Caratula.TextChanged += new System.EventHandler(this.TextBox_Caratula_TextChanged);
            // 
            // btn_EliminarControl
            // 
            this.btn_EliminarControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EliminarControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_EliminarControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarControl.Location = new System.Drawing.Point(356, 0);
            this.btn_EliminarControl.Name = "btn_EliminarControl";
            this.btn_EliminarControl.Size = new System.Drawing.Size(15, 23);
            this.btn_EliminarControl.TabIndex = 44;
            this.btn_EliminarControl.Text = "-";
            this.toolTip1.SetToolTip(this.btn_EliminarControl, "Eliminar");
            this.btn_EliminarControl.UseVisualStyleBackColor = true;
            this.btn_EliminarControl.Click += new System.EventHandler(this.Btn_EliminarControl_Click);
            // 
            // NuevaCaratulaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_EliminarControl);
            this.Controls.Add(this.textBox_Caratula);
            this.Controls.Add(this.label_Caratula);
            this.Name = "NuevaCaratulaControl";
            this.Size = new System.Drawing.Size(374, 26);
            this.Load += new System.EventHandler(this.NuevaCaratulaControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Caratula;
        private System.Windows.Forms.TextBox textBox_Caratula;
        private System.Windows.Forms.Button btn_EliminarControl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
