namespace Ofelia_Sara.Controles.Controles.Ofl_Sara
{
    partial class AgregarFiscaliaControl
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
            groupBox_ProvenienteFiscalia = new System.Windows.Forms.GroupBox();
            comboBox_Localidad = new Ofelia_Sara.Controles.General.CustomComboBox();
            lbl_Dr = new System.Windows.Forms.Label();
            lbl_Ufid = new System.Windows.Forms.Label();
            comboBox_DeptoJudicial = new Ofelia_Sara.Controles.General.CustomComboBox();
            comboBox_AgenteFiscal = new Ofelia_Sara.Controles.General.CustomComboBox();
            lbl_DeptoJudicial = new System.Windows.Forms.Label();
            comboBox_Fiscalia = new Ofelia_Sara.Controles.General.CustomComboBox();
            lbl_Localidad = new System.Windows.Forms.Label();
            groupBox_ProvenienteFiscalia.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_ProvenienteFiscalia
            // 
            groupBox_ProvenienteFiscalia.Controls.Add(comboBox_Localidad);
            groupBox_ProvenienteFiscalia.Controls.Add(lbl_Dr);
            groupBox_ProvenienteFiscalia.Controls.Add(lbl_Ufid);
            groupBox_ProvenienteFiscalia.Controls.Add(comboBox_DeptoJudicial);
            groupBox_ProvenienteFiscalia.Controls.Add(comboBox_AgenteFiscal);
            groupBox_ProvenienteFiscalia.Controls.Add(lbl_DeptoJudicial);
            groupBox_ProvenienteFiscalia.Controls.Add(comboBox_Fiscalia);
            groupBox_ProvenienteFiscalia.Controls.Add(lbl_Localidad);
            groupBox_ProvenienteFiscalia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            groupBox_ProvenienteFiscalia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            groupBox_ProvenienteFiscalia.Location = new System.Drawing.Point(4, 3);
            groupBox_ProvenienteFiscalia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_ProvenienteFiscalia.Name = "groupBox_ProvenienteFiscalia";
            groupBox_ProvenienteFiscalia.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_ProvenienteFiscalia.Size = new System.Drawing.Size(510, 129);
            groupBox_ProvenienteFiscalia.TabIndex = 89;
            groupBox_ProvenienteFiscalia.TabStop = false;
            groupBox_ProvenienteFiscalia.Text = "PROVENIENTE DE FISCALIA";
            groupBox_ProvenienteFiscalia.Enter += groupBox1_Enter;
            // 
            // comboBox_Localidad
            // 
            comboBox_Localidad.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            comboBox_Localidad.Items.AddRange(new object[] { "PINAMAR", "VILLA GESELL", "GRAL. MADARIAGA" });
            comboBox_Localidad.Location = new System.Drawing.Point(169, 65);
            comboBox_Localidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Localidad.Name = "comboBox_Localidad";
            comboBox_Localidad.Size = new System.Drawing.Size(333, 21);
            comboBox_Localidad.TabIndex = 74;
            // 
            // lbl_Dr
            // 
            lbl_Dr.AutoSize = true;
            lbl_Dr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_Dr.Location = new System.Drawing.Point(282, 37);
            lbl_Dr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Dr.Name = "lbl_Dr";
            lbl_Dr.Size = new System.Drawing.Size(26, 15);
            lbl_Dr.TabIndex = 72;
            lbl_Dr.Text = "Dr.";
            // 
            // lbl_Ufid
            // 
            lbl_Ufid.AutoSize = true;
            lbl_Ufid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_Ufid.Location = new System.Drawing.Point(70, 37);
            lbl_Ufid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Ufid.Name = "lbl_Ufid";
            lbl_Ufid.Size = new System.Drawing.Size(51, 15);
            lbl_Ufid.TabIndex = 76;
            lbl_Ufid.Text = "U.F.I.D";
            // 
            // comboBox_DeptoJudicial
            // 
            comboBox_DeptoJudicial.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_DeptoJudicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            comboBox_DeptoJudicial.Items.AddRange(new object[] { "DOLORES" });
            comboBox_DeptoJudicial.Location = new System.Drawing.Point(169, 96);
            comboBox_DeptoJudicial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_DeptoJudicial.Name = "comboBox_DeptoJudicial";
            comboBox_DeptoJudicial.Size = new System.Drawing.Size(333, 21);
            comboBox_DeptoJudicial.TabIndex = 75;
            // 
            // comboBox_AgenteFiscal
            // 
            comboBox_AgenteFiscal.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_AgenteFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            comboBox_AgenteFiscal.Items.AddRange(new object[] { "Calderón Pablo", "Mercuri Walter", "Zamboni Veronica" });
            comboBox_AgenteFiscal.Location = new System.Drawing.Point(314, 33);
            comboBox_AgenteFiscal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_AgenteFiscal.Name = "comboBox_AgenteFiscal";
            comboBox_AgenteFiscal.Size = new System.Drawing.Size(188, 21);
            comboBox_AgenteFiscal.TabIndex = 73;
            // 
            // lbl_DeptoJudicial
            // 
            lbl_DeptoJudicial.AutoSize = true;
            lbl_DeptoJudicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_DeptoJudicial.Location = new System.Drawing.Point(9, 99);
            lbl_DeptoJudicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_DeptoJudicial.Name = "lbl_DeptoJudicial";
            lbl_DeptoJudicial.Size = new System.Drawing.Size(103, 15);
            lbl_DeptoJudicial.TabIndex = 77;
            lbl_DeptoJudicial.Text = "Depto. Judicial";
            // 
            // comboBox_Fiscalia
            // 
            comboBox_Fiscalia.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_Fiscalia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            
            comboBox_Fiscalia.Items.AddRange(new object[] { "04", "05", "08" });
            comboBox_Fiscalia.Location = new System.Drawing.Point(169, 33);
            comboBox_Fiscalia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Fiscalia.Name = "comboBox_Fiscalia";
            comboBox_Fiscalia.Size = new System.Drawing.Size(106, 21);
            comboBox_Fiscalia.TabIndex = 71;
            // 
            // lbl_Localidad
            // 
            lbl_Localidad.AutoSize = true;
            lbl_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_Localidad.Location = new System.Drawing.Point(48, 66);
            lbl_Localidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Localidad.Name = "lbl_Localidad";
            lbl_Localidad.Size = new System.Drawing.Size(70, 15);
            lbl_Localidad.TabIndex = 78;
            lbl_Localidad.Text = "Localidad";
            // 
            // AgregarFiscaliaControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(groupBox_ProvenienteFiscalia);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AgregarFiscaliaControl";
            Size = new System.Drawing.Size(518, 135);
            groupBox_ProvenienteFiscalia.ResumeLayout(false);
            groupBox_ProvenienteFiscalia.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ProvenienteFiscalia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Localidad;
        private System.Windows.Forms.Label lbl_Dr;
        private System.Windows.Forms.Label lbl_Ufid;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_DeptoJudicial;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_AgenteFiscal;
        private System.Windows.Forms.Label lbl_DeptoJudicial;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Fiscalia;
        private System.Windows.Forms.Label lbl_Localidad;
    }
}
