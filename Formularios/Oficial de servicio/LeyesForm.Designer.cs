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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeyesForm));
            panel1 = new System.Windows.Forms.Panel();
            listView_Documentos = new System.Windows.Forms.ListView();
            label_TITULO = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(listView_Documentos);
            panel1.Controls.Add(label_TITULO);
            panel1.Location = new System.Drawing.Point(20, 15);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(529, 272);
            panel1.TabIndex = 2;
            // 
            // listView_Documentos
            // 
            listView_Documentos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            listView_Documentos.Cursor = System.Windows.Forms.Cursors.Hand;
            listView_Documentos.Location = new System.Drawing.Point(3, 36);
            listView_Documentos.Name = "listView_Documentos";
            listView_Documentos.Size = new System.Drawing.Size(524, 209);
            listView_Documentos.TabIndex = 2;
            listView_Documentos.UseCompatibleStateImageBehavior = false;
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(120, -10);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            label_TITULO.Size = new System.Drawing.Size(272, 30);
            label_TITULO.TabIndex = 1;
            label_TITULO.Text = "LEYES Y DECRETOS";
            // 
            // LeyesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(571, 321);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LeyesForm";
            Text = "LEYES Y DECCRETOS UTILES";
            Load += LeyesForm_Load;
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.ListView listView_Documentos;
    }
}