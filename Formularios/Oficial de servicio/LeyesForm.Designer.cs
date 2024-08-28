namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    partial class LeyesForm
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
            this.listView_Documentos = new System.Windows.Forms.ListView();
            this.label_Leyes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 8, 28, 14, 12, 11, 891);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.listView_Documentos);
            this.panel1.Controls.Add(this.label_Leyes);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 272);
            this.panel1.TabIndex = 2;
            // 
            // listView_Documentos
            // 
            this.listView_Documentos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listView_Documentos.HideSelection = false;
            this.listView_Documentos.Location = new System.Drawing.Point(3, 49);
            this.listView_Documentos.Name = "listView_Documentos";
            this.listView_Documentos.Size = new System.Drawing.Size(524, 196);
            this.listView_Documentos.TabIndex = 2;
            this.listView_Documentos.UseCompatibleStateImageBehavior = false;
            // 
            // label_Leyes
            // 
            this.label_Leyes.AutoSize = true;
            this.label_Leyes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_Leyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Leyes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Leyes.Location = new System.Drawing.Point(120, 0);
            this.label_Leyes.Name = "label_Leyes";
            this.label_Leyes.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_Leyes.Size = new System.Drawing.Size(272, 30);
            this.label_Leyes.TabIndex = 1;
            this.label_Leyes.Text = "LEYES Y DECRETOS";
            // 
            // LeyesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 321);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LeyesForm";
            this.Text = "LEYES Y DECCRETOS UTILES";
            this.Load += new System.EventHandler(this.LeyesForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Leyes;
        private System.Windows.Forms.ListView listView_Documentos;
    }
}