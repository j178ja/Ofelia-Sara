namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class prueba
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCargarExcel = new System.Windows.Forms.Button();
            this.dataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 9, 13, 8, 57, 28, 712);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.dataGridViewExcel);
            this.panel1.Controls.Add(this.btnCargarExcel);
            this.panel1.Location = new System.Drawing.Point(32, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 379);
            this.panel1.TabIndex = 2;
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Location = new System.Drawing.Point(319, 20);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(75, 23);
            this.btnCargarExcel.TabIndex = 0;
            this.btnCargarExcel.Text = "button1";
            this.btnCargarExcel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExcel
            // 
            this.dataGridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcel.Location = new System.Drawing.Point(3, 72);
            this.dataGridViewExcel.Name = "dataGridViewExcel";
            this.dataGridViewExcel.Size = new System.Drawing.Size(730, 289);
            this.dataGridViewExcel.TabIndex = 1;
            // 
            // prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "prueba";
            this.Text = "prueba";
            this.Load += new System.EventHandler(this.prueba_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCargarExcel;
        private System.Windows.Forms.DataGridView dataGridViewExcel;
    }
}