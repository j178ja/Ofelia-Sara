namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes
{
    partial class NuevaFiscalia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaFiscalia));
            panel1 = new System.Windows.Forms.Panel();
            btn_Limpiar = new System.Windows.Forms.Button();
            btn_Guardar = new System.Windows.Forms.Button();
            label_TITULO = new System.Windows.Forms.Label();
            textBox_DeptoJudicial = new Controles.General.CustomTextBox();
            textBox_Localidad = new Controles.General.CustomTextBox();
            textBox_AgenteFiscal = new Controles.General.CustomTextBox();
            textBox_Fiscalia = new Controles.General.CustomTextBox();
            label_DptoJudicial = new System.Windows.Forms.Label();
            label_Localidad = new System.Windows.Forms.Label();
            label_Dr = new System.Windows.Forms.Label();
            label_Ufid = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(btn_Limpiar);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(label_TITULO);
            panel1.Controls.Add(textBox_DeptoJudicial);
            panel1.Controls.Add(textBox_Localidad);
            panel1.Controls.Add(textBox_AgenteFiscal);
            panel1.Controls.Add(textBox_Fiscalia);
            panel1.Controls.Add(label_DptoJudicial);
            panel1.Controls.Add(label_Localidad);
            panel1.Controls.Add(label_Dr);
            panel1.Controls.Add(label_Ufid);
            panel1.Location = new System.Drawing.Point(20, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(620, 243);
            panel1.TabIndex = 2;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Limpiar.Image = (System.Drawing.Image)resources.GetObject("btn_Limpiar.Image");
            btn_Limpiar.Location = new System.Drawing.Point(218, 163);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            btn_Limpiar.TabIndex = 30;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Limpiar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Guardar.Image = (System.Drawing.Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new System.Drawing.Point(438, 163);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new System.Drawing.Size(75, 67);
            btn_Guardar.TabIndex = 29;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // label_TITULO
            // 
            label_TITULO.AutoSize = true;
            label_TITULO.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            label_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_TITULO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label_TITULO.Location = new System.Drawing.Point(159, -16);
            label_TITULO.Name = "label_TITULO";
            label_TITULO.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            label_TITULO.Size = new System.Drawing.Size(235, 30);
            label_TITULO.TabIndex = 0;
            label_TITULO.Text = "DATOS FISCALIA";
            // 
            // textBox_DeptoJudicial
            // 
            textBox_DeptoJudicial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_DeptoJudicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_DeptoJudicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_DeptoJudicial.BackColor = System.Drawing.Color.White;
            textBox_DeptoJudicial.ErrorColor = System.Drawing.Color.Red;
            textBox_DeptoJudicial.FocusColor = System.Drawing.Color.Blue;
            textBox_DeptoJudicial.Location = new System.Drawing.Point(170, 125);
            textBox_DeptoJudicial.MaxLength = 32767;
            textBox_DeptoJudicial.Multiline = false;
            textBox_DeptoJudicial.Name = "textBox_DeptoJudicial";
            textBox_DeptoJudicial.PasswordChar = '\0';
            textBox_DeptoJudicial.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_DeptoJudicial.PlaceholderText = "";
            textBox_DeptoJudicial.ReadOnly = false;
            textBox_DeptoJudicial.SelectionStart = 0;
            textBox_DeptoJudicial.ShowError = false;
            textBox_DeptoJudicial.Size = new System.Drawing.Size(390, 20);
            textBox_DeptoJudicial.TabIndex = 3;
            textBox_DeptoJudicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_DeptoJudicial.TextValue = "";
            textBox_DeptoJudicial.Whidth = 0;
            // 
            // textBox_Localidad
            // 
            textBox_Localidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_Localidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Localidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Localidad.BackColor = System.Drawing.Color.White;
            textBox_Localidad.ErrorColor = System.Drawing.Color.Red;
            textBox_Localidad.FocusColor = System.Drawing.Color.Blue;
            textBox_Localidad.Location = new System.Drawing.Point(170, 99);
            textBox_Localidad.MaxLength = 32767;
            textBox_Localidad.Multiline = false;
            textBox_Localidad.Name = "textBox_Localidad";
            textBox_Localidad.PasswordChar = '\0';
            textBox_Localidad.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Localidad.PlaceholderText = "";
            textBox_Localidad.ReadOnly = false;
            textBox_Localidad.SelectionStart = 0;
            textBox_Localidad.ShowError = false;
            textBox_Localidad.Size = new System.Drawing.Size(390, 20);
            textBox_Localidad.TabIndex = 2;
            textBox_Localidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Localidad.TextValue = "";
            textBox_Localidad.Whidth = 0;
            // 
            // textBox_AgenteFiscal
            // 
            textBox_AgenteFiscal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_AgenteFiscal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_AgenteFiscal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_AgenteFiscal.BackColor = System.Drawing.Color.White;
            textBox_AgenteFiscal.ErrorColor = System.Drawing.Color.Red;
            textBox_AgenteFiscal.FocusColor = System.Drawing.Color.Blue;
            textBox_AgenteFiscal.Location = new System.Drawing.Point(170, 73);
            textBox_AgenteFiscal.MaxLength = 32767;
            textBox_AgenteFiscal.Multiline = false;
            textBox_AgenteFiscal.Name = "textBox_AgenteFiscal";
            textBox_AgenteFiscal.PasswordChar = '\0';
            textBox_AgenteFiscal.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_AgenteFiscal.PlaceholderText = "";
            textBox_AgenteFiscal.ReadOnly = false;
            textBox_AgenteFiscal.SelectionStart = 0;
            textBox_AgenteFiscal.ShowError = false;
            textBox_AgenteFiscal.Size = new System.Drawing.Size(390, 20);
            textBox_AgenteFiscal.TabIndex = 1;
            textBox_AgenteFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_AgenteFiscal.TextValue = "";
            textBox_AgenteFiscal.Whidth = 0;
            // 
            // textBox_Fiscalia
            // 
            textBox_Fiscalia.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_Fiscalia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Fiscalia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Fiscalia.BackColor = System.Drawing.Color.White;
            textBox_Fiscalia.ErrorColor = System.Drawing.Color.Red;
            textBox_Fiscalia.FocusColor = System.Drawing.Color.Blue;
            textBox_Fiscalia.Location = new System.Drawing.Point(170, 47);
            textBox_Fiscalia.MaxLength = 32767;
            textBox_Fiscalia.Multiline = false;
            textBox_Fiscalia.Name = "textBox_Fiscalia";
            textBox_Fiscalia.PasswordChar = '\0';
            textBox_Fiscalia.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Fiscalia.PlaceholderText = "";
            textBox_Fiscalia.ReadOnly = false;
            textBox_Fiscalia.SelectionStart = 0;
            textBox_Fiscalia.ShowError = false;
            textBox_Fiscalia.Size = new System.Drawing.Size(390, 20);
            textBox_Fiscalia.TabIndex = 5;
            textBox_Fiscalia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Fiscalia.TextValue = "";
            textBox_Fiscalia.Whidth = 0;
            // 
            // label_DptoJudicial
            // 
            label_DptoJudicial.AutoSize = true;
            label_DptoJudicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_DptoJudicial.Location = new System.Drawing.Point(54, 126);
            label_DptoJudicial.Name = "label_DptoJudicial";
            label_DptoJudicial.Size = new System.Drawing.Size(110, 16);
            label_DptoJudicial.TabIndex = 4;
            label_DptoJudicial.Text = "Dpto. Judicial :";
            // 
            // label_Localidad
            // 
            label_Localidad.AutoSize = true;
            label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Localidad.Location = new System.Drawing.Point(66, 100);
            label_Localidad.Name = "label_Localidad";
            label_Localidad.Size = new System.Drawing.Size(98, 16);
            label_Localidad.TabIndex = 3;
            label_Localidad.Text = "LOCALIDAD :";
            // 
            // label_Dr
            // 
            label_Dr.AutoSize = true;
            label_Dr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Dr.Location = new System.Drawing.Point(129, 73);
            label_Dr.Name = "label_Dr";
            label_Dr.Size = new System.Drawing.Size(35, 16);
            label_Dr.TabIndex = 2;
            label_Dr.Text = "Dr. :";
            // 
            // label_Ufid
            // 
            label_Ufid.AutoSize = true;
            label_Ufid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Ufid.Location = new System.Drawing.Point(102, 47);
            label_Ufid.Name = "label_Ufid";
            label_Ufid.Size = new System.Drawing.Size(62, 16);
            label_Ufid.TabIndex = 1;
            label_Ufid.Text = "U.F.I.D.:";
            // 
            // NuevaFiscalia
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(664, 306);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuevaFiscalia";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AGREGAR NUEVA FISCALIA";
            HelpButtonClicked += FISCALIA_HelpButtonClicked;
            Load += Fiscalia_Load;
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_TITULO;
        private System.Windows.Forms.Label label_DptoJudicial;
        private System.Windows.Forms.Label label_Localidad;
        private System.Windows.Forms.Label label_Dr;
        private System.Windows.Forms.Label label_Ufid;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_DeptoJudicial;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Localidad;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_AgenteFiscal;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Fiscalia;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
    }
}