namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaPersonaControl));
            this.btn_AgregarDatosPersona = new System.Windows.Forms.Button();
            this.label_Persona = new System.Windows.Forms.Label();
            this.textBox_Persona = new System.Windows.Forms.TextBox();
            this.btn_EliminarControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_AgregarDatosPersona
            // 
            this.btn_AgregarDatosPersona.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarDatosPersona.Image = ((System.Drawing.Image)(resources.GetObject("btn_AgregarDatosPersona.Image")));
            this.btn_AgregarDatosPersona.Location = new System.Drawing.Point(0, -1);
            this.btn_AgregarDatosPersona.Name = "btn_AgregarDatosPersona";
            this.btn_AgregarDatosPersona.Size = new System.Drawing.Size(27, 23);
            this.btn_AgregarDatosPersona.TabIndex = 42;
            this.btn_AgregarDatosPersona.Text = "+";
            this.btn_AgregarDatosPersona.UseVisualStyleBackColor = true;
            // 
            // label_Persona
            // 
            this.label_Persona.BackColor = System.Drawing.Color.Transparent;
            this.label_Persona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Persona.Location = new System.Drawing.Point(28, 1);
            this.label_Persona.Name = "label_Persona";
            this.label_Persona.Size = new System.Drawing.Size(95, 19);
            this.label_Persona.TabIndex = 40;
            // 
            // textBox_Persona
            // 
            this.textBox_Persona.Location = new System.Drawing.Point(124, 1);
            this.textBox_Persona.Name = "textBox_Persona";
            this.textBox_Persona.Size = new System.Drawing.Size(265, 20);
            this.textBox_Persona.TabIndex = 41;
            // 
            // btn_EliminarControl
            // 
            this.btn_EliminarControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EliminarControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarControl.Location = new System.Drawing.Point(389, 0);
            this.btn_EliminarControl.Name = "btn_EliminarControl";
            this.btn_EliminarControl.Size = new System.Drawing.Size(15, 23);
            this.btn_EliminarControl.TabIndex = 43;
            this.btn_EliminarControl.Text = "-";
            this.btn_EliminarControl.UseVisualStyleBackColor = true;
            // 
            // NuevaPersonaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_EliminarControl);
            this.Controls.Add(this.btn_AgregarDatosPersona);
            this.Controls.Add(this.label_Persona);
            this.Controls.Add(this.textBox_Persona);
            this.Name = "NuevaPersonaControl";
            this.Size = new System.Drawing.Size(407, 26);
            this.Load += new System.EventHandler(this.NuevaPersonaControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AgregarDatosPersona;
        private System.Windows.Forms.Label label_Persona;
        private System.Windows.Forms.TextBox textBox_Persona;
        private System.Windows.Forms.Button btn_EliminarControl;
    }
}
