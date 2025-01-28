namespace Ofelia_Sara.Controles.Ofl_Sara
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
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            btn_Guardar = new System.Windows.Forms.Button();
            btn_Cancelar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new System.Drawing.Point(12, 12);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // btn_Guardar
            // 
            btn_Guardar.AutoSize = true;
            btn_Guardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btn_Guardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Guardar.Location = new System.Drawing.Point(187, 182);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(69, 23);
            btn_Guardar.TabIndex = 1;
            btn_Guardar.Text = "GUARDAR";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += Btn_Guardar_Click;
            btn_Guardar.MouseLeave += Btn_Guardar_MouseLeave;
            btn_Guardar.MouseHover += Btn_Guardar_MouseHover;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.AutoSize = true;
            btn_Cancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Cancelar.Location = new System.Drawing.Point(12, 182);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new System.Drawing.Size(71, 23);
            btn_Cancelar.TabIndex = 2;
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.UseVisualStyleBackColor = true;
            btn_Cancelar.Click += Btn_Cancelar_Click;
            btn_Cancelar.MouseLeave += Btn_Cancelar_MouseLeave;
            btn_Cancelar.MouseHover += Btn_Cancelar_MouseHover;
            // 
            // CALENDARIO
            // 
            AcceptButton = btn_Guardar;
            BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            CancelButton = btn_Cancelar;
            ClientSize = new System.Drawing.Size(274, 210);
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Guardar);
            Controls.Add(monthCalendar1);
            Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CALENDARIO";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "FECHA NACIMIENTO";
            HelpButtonClicked += CALENDARIO_HelpButtonClicked;
            Load += CalendarForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}