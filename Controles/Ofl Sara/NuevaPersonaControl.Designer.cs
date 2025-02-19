namespace Ofelia_Sara.Controles.Ofl_Sara
{
    partial class NuevaPersonaControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaPersonaControl));
            btn_AgregarDatosPersona = new System.Windows.Forms.Button();
            label_Persona = new System.Windows.Forms.Label();
            textBox_Persona = new General.CustomTextBox();
            btn_EliminarControl = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            SuspendLayout();
            // 
            // btn_AgregarDatosPersona
            // 
            btn_AgregarDatosPersona.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_AgregarDatosPersona.Image = (System.Drawing.Image)resources.GetObject("btn_AgregarDatosPersona.Image");
            btn_AgregarDatosPersona.Location = new System.Drawing.Point(2, 1);
            btn_AgregarDatosPersona.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AgregarDatosPersona.Name = "btn_AgregarDatosPersona";
            btn_AgregarDatosPersona.Size = new System.Drawing.Size(31, 27);
            btn_AgregarDatosPersona.TabIndex = 42;
            btn_AgregarDatosPersona.UseVisualStyleBackColor = true;
            btn_AgregarDatosPersona.Click += Btn_AgregarDatosPersona_Click;
            // 
            // label_Persona
            // 
            label_Persona.BackColor = System.Drawing.Color.Transparent;
            label_Persona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label_Persona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_Persona.Location = new System.Drawing.Point(43, 3);
            label_Persona.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_Persona.Name = "label_Persona";
            label_Persona.Size = new System.Drawing.Size(105, 23);
            label_Persona.TabIndex = 40;
            label_Persona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Persona
            // 
            textBox_Persona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            textBox_Persona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            textBox_Persona.BackColor = System.Drawing.Color.White;
            textBox_Persona.ErrorColor = System.Drawing.Color.Red;
            textBox_Persona.FocusColor = System.Drawing.Color.Blue;
            textBox_Persona.Location = new System.Drawing.Point(146, 2);
            textBox_Persona.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Persona.MaxLength = 32767;
            textBox_Persona.Multiline = false;
            textBox_Persona.Name = "textBox_Persona";
            textBox_Persona.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            textBox_Persona.PasswordChar = '\0';
            textBox_Persona.PlaceholderColor = System.Drawing.Color.Gray;
            textBox_Persona.PlaceholderText = "";
            textBox_Persona.ReadOnly = false;
            textBox_Persona.SelectionStart = 0;
            textBox_Persona.ShowError = true;
            textBox_Persona.Size = new System.Drawing.Size(335, 23);
            textBox_Persona.TabIndex = 41;
            textBox_Persona.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Persona.TextValue = "";
            textBox_Persona.Whidth = 0;
            textBox_Persona.TextChanged += TextBox_Persona_TextChanged;
            // 
            // btn_EliminarControl
            // 
            btn_EliminarControl.BackColor = System.Drawing.Color.Tomato;
            btn_EliminarControl.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_EliminarControl.FlatAppearance.BorderSize = 0;
            btn_EliminarControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_EliminarControl.Location = new System.Drawing.Point(484, 0);
            btn_EliminarControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_EliminarControl.Name = "btn_EliminarControl";
            btn_EliminarControl.Size = new System.Drawing.Size(18, 27);
            btn_EliminarControl.TabIndex = 43;
            btn_EliminarControl.Text = "-";
            btn_EliminarControl.UseVisualStyleBackColor = false;
            btn_EliminarControl.Click += Btn_EliminarControl_Click;
            btn_EliminarControl.MouseLeave += Btn_EliminarControl_MouseLeave;
            btn_EliminarControl.MouseHover += Btn_EliminarControl_MouseHover;
            // 
            // NuevaPersonaControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(btn_EliminarControl);
            Controls.Add(btn_AgregarDatosPersona);
            Controls.Add(label_Persona);
            Controls.Add(textBox_Persona);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "NuevaPersonaControl";
            Size = new System.Drawing.Size(506, 31);
            Load += NuevaPersonaControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_AgregarDatosPersona;
        private System.Windows.Forms.Label label_Persona;
        private Ofelia_Sara.Controles.General.CustomTextBox textBox_Persona;
        private System.Windows.Forms.Button btn_EliminarControl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
