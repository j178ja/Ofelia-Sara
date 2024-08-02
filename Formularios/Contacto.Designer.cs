namespace Ofelia_Sara.Formularios
{
    partial class Contacto
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
            this.label_NombreContacto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 8, 2, 8, 28, 2, 217);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.label_NombreContacto);
            this.panel1.Location = new System.Drawing.Point(26, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 526);
            this.panel1.TabIndex = 2;
            // 
            // label_NombreContacto
            // 
            this.label_NombreContacto.AutoSize = true;
            this.label_NombreContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_NombreContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NombreContacto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_NombreContacto.Location = new System.Drawing.Point(210, -16);
            this.label_NombreContacto.Name = "label_NombreContacto";
            this.label_NombreContacto.Padding = new System.Windows.Forms.Padding(30, 0, 30, 5);
            this.label_NombreContacto.Size = new System.Drawing.Size(338, 36);
            this.label_NombreContacto.TabIndex = 0;
            this.label_NombreContacto.Text = "JORGE A. BONATO";
            // 
            // Contacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 604);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Contacto";
            this.Text = "FORMULARIO DE CONTACTO";
            this.Load += new System.EventHandler(this.Contacto_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_NombreContacto;
    }
}