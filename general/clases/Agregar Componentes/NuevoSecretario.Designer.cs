﻿namespace Ofelia_Sara.general.clases.Agregar_Componentes
{
    partial class NuevoSecretario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoSecretario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_FirmaDigitalizada = new System.Windows.Forms.PictureBox();
            this.textBox_Funcion = new System.Windows.Forms.TextBox();
            this.label_Funcion = new System.Windows.Forms.Label();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.checkBox_AgregarFirma = new System.Windows.Forms.CheckBox();
            this.label_AgregaFirma = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.textBox_Jerarquia = new System.Windows.Forms.TextBox();
            this.label_Dependencia = new System.Windows.Forms.Label();
            this.label_NuevoSecretario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FirmaDigitalizada)).BeginInit();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 7, 30, 16, 45, 55, 651);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.pictureBox_FirmaDigitalizada);
            this.panel1.Controls.Add(this.textBox_Funcion);
            this.panel1.Controls.Add(this.label_Funcion);
            this.panel1.Controls.Add(this.textBox_Apellido);
            this.panel1.Controls.Add(this.label_Apellido);
            this.panel1.Controls.Add(this.textBox_Nombre);
            this.panel1.Controls.Add(this.label_Nombre);
            this.panel1.Controls.Add(this.checkBox_AgregarFirma);
            this.panel1.Controls.Add(this.label_AgregaFirma);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.textBox_Jerarquia);
            this.panel1.Controls.Add(this.label_Dependencia);
            this.panel1.Controls.Add(this.label_NuevoSecretario);
            this.panel1.Location = new System.Drawing.Point(23, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 359);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox_FirmaDigitalizada
            // 
            this.pictureBox_FirmaDigitalizada.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox_FirmaDigitalizada.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_FirmaDigitalizada.BackgroundImage")));
            this.pictureBox_FirmaDigitalizada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_FirmaDigitalizada.Location = new System.Drawing.Point(332, 177);
            this.pictureBox_FirmaDigitalizada.Name = "pictureBox_FirmaDigitalizada";
            this.pictureBox_FirmaDigitalizada.Size = new System.Drawing.Size(134, 63);
            this.pictureBox_FirmaDigitalizada.TabIndex = 51;
            this.pictureBox_FirmaDigitalizada.TabStop = false;
            this.pictureBox_FirmaDigitalizada.Click += new System.EventHandler(this.PictureBox_Click);
            this.pictureBox_FirmaDigitalizada.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.pictureBox_FirmaDigitalizada.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            this.pictureBox_FirmaDigitalizada.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_FirmaDigitalizada_Paint);
            // 
            // textBox_Funcion
            // 
            this.textBox_Funcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Funcion.Location = new System.Drawing.Point(140, 139);
            this.textBox_Funcion.Name = "textBox_Funcion";
            this.textBox_Funcion.Size = new System.Drawing.Size(326, 21);
            this.textBox_Funcion.TabIndex = 3;
            // 
            // label_Funcion
            // 
            this.label_Funcion.AutoSize = true;
            this.label_Funcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Funcion.Location = new System.Drawing.Point(52, 142);
            this.label_Funcion.Name = "label_Funcion";
            this.label_Funcion.Size = new System.Drawing.Size(82, 16);
            this.label_Funcion.TabIndex = 49;
            this.label_Funcion.Text = "FUNCION :";
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Apellido.Location = new System.Drawing.Point(140, 110);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(326, 21);
            this.textBox_Apellido.TabIndex = 2;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Apellido.Location = new System.Drawing.Point(47, 113);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(87, 16);
            this.label_Apellido.TabIndex = 47;
            this.label_Apellido.Text = "APELLIDO :";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nombre.Location = new System.Drawing.Point(140, 81);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(326, 21);
            this.textBox_Nombre.TabIndex = 1;
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nombre.Location = new System.Drawing.Point(54, 84);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(80, 16);
            this.label_Nombre.TabIndex = 45;
            this.label_Nombre.Text = "NOMBRE :";
            // 
            // checkBox_AgregarFirma
            // 
            this.checkBox_AgregarFirma.AutoSize = true;
            this.checkBox_AgregarFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_AgregarFirma.Location = new System.Drawing.Point(303, 198);
            this.checkBox_AgregarFirma.Name = "checkBox_AgregarFirma";
            this.checkBox_AgregarFirma.Size = new System.Drawing.Size(15, 14);
            this.checkBox_AgregarFirma.TabIndex = 4;
            this.checkBox_AgregarFirma.UseVisualStyleBackColor = true;
            this.checkBox_AgregarFirma.CheckedChanged += new System.EventHandler(this.checkBox_AgregarFirma_CheckedChanged);
            // 
            // label_AgregaFirma
            // 
            this.label_AgregaFirma.AutoSize = true;
            this.label_AgregaFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AgregaFirma.Location = new System.Drawing.Point(33, 196);
            this.label_AgregaFirma.Name = "label_AgregaFirma";
            this.label_AgregaFirma.Size = new System.Drawing.Size(237, 16);
            this.label_AgregaFirma.TabIndex = 43;
            this.label_AgregaFirma.Text = "AGREGAR FIRMA DIGITALIZADA";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(140, 264);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 6;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(391, 264);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 5;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // textBox_Jerarquia
            // 
            this.textBox_Jerarquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Jerarquia.Location = new System.Drawing.Point(140, 54);
            this.textBox_Jerarquia.Name = "textBox_Jerarquia";
            this.textBox_Jerarquia.Size = new System.Drawing.Size(326, 21);
            this.textBox_Jerarquia.TabIndex = 0;
            // 
            // label_Dependencia
            // 
            this.label_Dependencia.AutoSize = true;
            this.label_Dependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dependencia.Location = new System.Drawing.Point(33, 57);
            this.label_Dependencia.Name = "label_Dependencia";
            this.label_Dependencia.Size = new System.Drawing.Size(101, 16);
            this.label_Dependencia.TabIndex = 39;
            this.label_Dependencia.Text = "JERARQUIA :";
            // 
            // label_NuevoSecretario
            // 
            this.label_NuevoSecretario.AutoSize = true;
            this.label_NuevoSecretario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_NuevoSecretario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NuevoSecretario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_NuevoSecretario.Location = new System.Drawing.Point(145, 0);
            this.label_NuevoSecretario.Name = "label_NuevoSecretario";
            this.label_NuevoSecretario.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label_NuevoSecretario.Size = new System.Drawing.Size(240, 24);
            this.label_NuevoSecretario.TabIndex = 38;
            this.label_NuevoSecretario.Text = "NUEVO SECRETARIO";
            // 
            // NuevoSecretario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 432);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevoSecretario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR NUEVO SECRETARIO";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.NuevoSecretario_HelpButtonClicked);
            this.Load += new System.EventHandler(this.NuevoSecretario_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FirmaDigitalizada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_FirmaDigitalizada;
        private System.Windows.Forms.TextBox textBox_Funcion;
        private System.Windows.Forms.Label label_Funcion;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.CheckBox checkBox_AgregarFirma;
        private System.Windows.Forms.Label label_AgregaFirma;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.TextBox textBox_Jerarquia;
        private System.Windows.Forms.Label label_Dependencia;
        private System.Windows.Forms.Label label_NuevoSecretario;
    }
}