namespace Controles.Controles
{
    partial class CALENDARIO
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CALENDARIO));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.AutoSize = true;
            this.btn_Guardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Guardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Guardar.Location = new System.Drawing.Point(187, 182);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(71, 23);
            this.btn_Guardar.TabIndex = 1;
            this.btn_Guardar.Text = "GUARDAR";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            this.btn_Guardar.MouseLeave += new System.EventHandler(this.btn_Guardar_MouseLeave);
            this.btn_Guardar.MouseHover += new System.EventHandler(this.btn_Guardar_MouseHover);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.AutoSize = true;
            this.btn_Cancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Location = new System.Drawing.Point(12, 182);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(74, 23);
            this.btn_Cancelar.TabIndex = 2;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            this.btn_Cancelar.MouseLeave += new System.EventHandler(this.btn_Cancelar_MouseLeave);
            this.btn_Cancelar.MouseHover += new System.EventHandler(this.btn_Cancelar_MouseHover);
            // 
            // CALENDARIO
            // 
            this.AcceptButton = this.btn_Guardar;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.CancelButton = this.btn_Cancelar;
            this.ClientSize = new System.Drawing.Size(274, 210);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CALENDARIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FECHA NACIMIENTO";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.CALENDARIO_HelpButtonClicked);
            this.Load += new System.EventHandler(this.CalendarForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}