﻿namespace Ofelia_Sara.Formularios.Oficial_de_servicio
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
            this.label_TITULO = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.listView_Documentos);
            this.panel1.Controls.Add(this.label_TITULO);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 272);
            this.panel1.TabIndex = 2;
            // 
            // listView_Documentos
            // 
            this.listView_Documentos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listView_Documentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView_Documentos.HideSelection = false;
            this.listView_Documentos.Location = new System.Drawing.Point(3, 36);
            this.listView_Documentos.Name = "listView_Documentos";
            this.listView_Documentos.Size = new System.Drawing.Size(524, 209);
            this.listView_Documentos.TabIndex = 2;
            this.listView_Documentos.UseCompatibleStateImageBehavior = false;
            // 
            // label_TITULO
            // 
            this.label_TITULO.AutoSize = true;
            this.label_TITULO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITULO.Location = new System.Drawing.Point(120, -10);
            this.label_TITULO.Name = "label_TITULO";
            this.label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.label_TITULO.Size = new System.Drawing.Size(272, 30);
            this.label_TITULO.TabIndex = 1;
            this.label_TITULO.Text = "LEYES Y DECRETOS";
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
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.ListView listView_Documentos;
    }
}