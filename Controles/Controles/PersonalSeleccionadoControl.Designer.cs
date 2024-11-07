namespace Controles.Controles
{
    partial class PersonalSeleccionadoControl
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
            this.components = new System.ComponentModel.Container();
            this.btn_ModificarPersonal = new System.Windows.Forms.Button();
            this.label_Legajo = new System.Windows.Forms.Label();
            this.label_Dependencias = new System.Windows.Forms.Label();
            this.label_Funciones = new System.Windows.Forms.Label();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_EliminarControl = new System.Windows.Forms.Button();
            this.label_NumeroLegajo = new System.Windows.Forms.Label();
            this.label_Dependencia = new System.Windows.Forms.Label();
            this.label_Funcion = new System.Windows.Forms.Label();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox_JerarquiaEscalafon = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ModificarPersonal
            // 
            this.btn_ModificarPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ModificarPersonal.BackColor = System.Drawing.Color.Transparent;
            this.btn_ModificarPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ModificarPersonal.FlatAppearance.BorderSize = 0;
            this.btn_ModificarPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModificarPersonal.Location = new System.Drawing.Point(677, 40);
            this.btn_ModificarPersonal.Name = "btn_ModificarPersonal";
            this.btn_ModificarPersonal.Size = new System.Drawing.Size(15, 23);
            this.btn_ModificarPersonal.TabIndex = 36;
            this.btn_ModificarPersonal.Text = "M";
            this.toolTip1.SetToolTip(this.btn_ModificarPersonal, "MODIFICAR Personal");
            this.btn_ModificarPersonal.UseVisualStyleBackColor = false;
            this.btn_ModificarPersonal.Click += new System.EventHandler(this.btn_ModificarPersonal_Click);
            // 
            // label_Legajo
            // 
            this.label_Legajo.AutoSize = true;
            this.label_Legajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Legajo.Location = new System.Drawing.Point(18, 4);
            this.label_Legajo.Name = "label_Legajo";
            this.label_Legajo.Size = new System.Drawing.Size(67, 15);
            this.label_Legajo.TabIndex = 38;
            this.label_Legajo.Text = "LEGAJO :";
            // 
            // label_Dependencias
            // 
            this.label_Dependencias.AutoSize = true;
            this.label_Dependencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dependencias.Location = new System.Drawing.Point(76, 28);
            this.label_Dependencias.Name = "label_Dependencias";
            this.label_Dependencias.Size = new System.Drawing.Size(112, 15);
            this.label_Dependencias.TabIndex = 40;
            this.label_Dependencias.Text = "DEPENDENCIA :";
            // 
            // label_Funciones
            // 
            this.label_Funciones.AutoSize = true;
            this.label_Funciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Funciones.Location = new System.Drawing.Point(112, 50);
            this.label_Funciones.Name = "label_Funciones";
            this.label_Funciones.Size = new System.Drawing.Size(76, 15);
            this.label_Funciones.TabIndex = 41;
            this.label_Funciones.Text = "FUNCIÓN :";
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nombre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_Nombre.Location = new System.Drawing.Point(3, 0);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(136, 15);
            this.label_Nombre.TabIndex = 42;
            this.label_Nombre.Text = "Juan de los palotes ";
            this.label_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EliminarControl
            // 
            this.btn_EliminarControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EliminarControl.BackColor = System.Drawing.Color.Transparent;
            this.btn_EliminarControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EliminarControl.FlatAppearance.BorderSize = 0;
            this.btn_EliminarControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_EliminarControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarControl.Location = new System.Drawing.Point(677, 11);
            this.btn_EliminarControl.Name = "btn_EliminarControl";
            this.btn_EliminarControl.Size = new System.Drawing.Size(15, 23);
            this.btn_EliminarControl.TabIndex = 46;
            this.btn_EliminarControl.Text = "-";
            this.toolTip1.SetToolTip(this.btn_EliminarControl, "ELIMINAR Personal seleccionado");
            this.btn_EliminarControl.UseVisualStyleBackColor = false;
            this.btn_EliminarControl.Click += new System.EventHandler(this.btn_EliminarControl_Click);
            // 
            // label_NumeroLegajo
            // 
            this.label_NumeroLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NumeroLegajo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_NumeroLegajo.Location = new System.Drawing.Point(83, 4);
            this.label_NumeroLegajo.Name = "label_NumeroLegajo";
            this.label_NumeroLegajo.Size = new System.Drawing.Size(100, 15);
            this.label_NumeroLegajo.TabIndex = 43;
            this.label_NumeroLegajo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_Dependencia
            // 
            this.label_Dependencia.AutoSize = true;
            this.label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dependencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_Dependencia.Location = new System.Drawing.Point(194, 31);
            this.label_Dependencia.Name = "label_Dependencia";
            this.label_Dependencia.Size = new System.Drawing.Size(32, 13);
            this.label_Dependencia.TabIndex = 44;
            this.label_Dependencia.Text = "epc ";
            this.label_Dependencia.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_Funcion
            // 
            this.label_Funcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Funcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_Funcion.Location = new System.Drawing.Point(193, 52);
            this.label_Funcion.Name = "label_Funcion";
            this.label_Funcion.Size = new System.Drawing.Size(400, 13);
            this.label_Funcion.TabIndex = 45;
            this.label_Funcion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Apellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(97)))));
            this.label_Apellido.Location = new System.Drawing.Point(145, 0);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(65, 15);
            this.label_Apellido.TabIndex = 48;
            this.label_Apellido.Text = "Jimenez ";
            this.label_Apellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label_Nombre);
            this.flowLayoutPanel1.Controls.Add(this.label_Apellido);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(401, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 43);
            this.flowLayoutPanel1.TabIndex = 49;
            // 
            // richTextBox_JerarquiaEscalafon
            // 
            this.richTextBox_JerarquiaEscalafon.BackColor = System.Drawing.Color.White;
            this.richTextBox_JerarquiaEscalafon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_JerarquiaEscalafon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.richTextBox_JerarquiaEscalafon.ForeColor = System.Drawing.Color.SkyBlue;
            this.richTextBox_JerarquiaEscalafon.Location = new System.Drawing.Point(189, 6);
            this.richTextBox_JerarquiaEscalafon.Name = "richTextBox_JerarquiaEscalafon";
            this.richTextBox_JerarquiaEscalafon.Size = new System.Drawing.Size(201, 22);
            this.richTextBox_JerarquiaEscalafon.TabIndex = 50;
            this.richTextBox_JerarquiaEscalafon.Text = "";
            // 
            // PersonalSeleccionadoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.richTextBox_JerarquiaEscalafon);
            this.Controls.Add(this.label_Dependencia);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_EliminarControl);
            this.Controls.Add(this.label_Funcion);
            this.Controls.Add(this.label_NumeroLegajo);
            this.Controls.Add(this.label_Funciones);
            this.Controls.Add(this.label_Dependencias);
            this.Controls.Add(this.label_Legajo);
            this.Controls.Add(this.btn_ModificarPersonal);
            this.Name = "PersonalSeleccionadoControl";
            this.Size = new System.Drawing.Size(695, 74);
            this.Load += new System.EventHandler(this.PersonalSeleccionadoControl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ModificarPersonal;
        private System.Windows.Forms.Label label_Legajo;
        private System.Windows.Forms.Label label_Dependencias;
        private System.Windows.Forms.Label label_Funciones;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_NumeroLegajo;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_Funcion;
        private System.Windows.Forms.Button btn_EliminarControl;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox_JerarquiaEscalafon;
    }
}
