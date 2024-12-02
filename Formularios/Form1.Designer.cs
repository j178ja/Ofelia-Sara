namespace Ofelia_Sara.Formularios
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelConBordeNeon1 = new Ofelia_Sara.Controles.Controles.Aplicadas_con_controles.PanelConBordeNeon();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.panelConBordeNeon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelConBordeNeon1
            // 
            this.panelConBordeNeon1.BorderRadius = 10;
            this.panelConBordeNeon1.CamposCompletos = false;
            this.panelConBordeNeon1.Controls.Add(this.btn_Imprimir);
            this.panelConBordeNeon1.Controls.Add(this.btn_Limpiar);
            this.panelConBordeNeon1.Controls.Add(this.btn_Guardar);
            this.panelConBordeNeon1.Controls.Add(this.btn_Buscar);
            this.panelConBordeNeon1.EstaContraido = false;
            this.panelConBordeNeon1.Location = new System.Drawing.Point(172, 49);
            this.panelConBordeNeon1.Name = "panelConBordeNeon1";
            this.panelConBordeNeon1.NeonColorCompleto = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.panelConBordeNeon1.NeonColorIncompleto = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelConBordeNeon1.Size = new System.Drawing.Size(431, 102);
            this.panelConBordeNeon1.SombraColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.panelConBordeNeon1.TabIndex = 19;
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Imprimir.Image")));
            this.btn_Imprimir.Location = new System.Drawing.Point(315, 3);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(106, 92);
            this.btn_Imprimir.TabIndex = 24;
            this.btn_Imprimir.UseVisualStyleBackColor = false;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(216, 16);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 25;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(115, 16);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 23;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(10, 16);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 67);
            this.btn_Buscar.TabIndex = 26;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelConBordeNeon1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelConBordeNeon1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controles.Controles.Aplicadas_con_controles.PanelConBordeNeon panelConBordeNeon1;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Buscar;
    }
}