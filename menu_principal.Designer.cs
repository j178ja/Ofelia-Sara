namespace Ofelia_Sara
{
    partial class MenuPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.Btn_Configuracion = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_InicioCierre = new System.Windows.Forms.Button();
            this.btn_Denuncias = new System.Windows.Forms.Button();
            this.btn_expedientes = new System.Windows.Forms.Button();
            this.btn_Ipp = new System.Windows.Forms.Button();
            this.btn_Notas = new System.Windows.Forms.Button();
            this.btn_LegajoDetenidos = new System.Windows.Forms.Button();
            this.btn_LegajoAutomotor = new System.Windows.Forms.Button();
            this.btn_Contravenciones = new System.Windows.Forms.Button();
            this.btn_cargo = new System.Windows.Forms.Button();
            this.btn_Inspecciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Configuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Configuracion
            // 
            this.Btn_Configuracion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Configuracion.BackgroundImage")));
            this.Btn_Configuracion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_Configuracion.Location = new System.Drawing.Point(41, 18);
            this.Btn_Configuracion.Name = "Btn_Configuracion";
            this.Btn_Configuracion.Size = new System.Drawing.Size(46, 50);
            this.Btn_Configuracion.TabIndex = 0;
            this.Btn_Configuracion.TabStop = false;
            this.Btn_Configuracion.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(454, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(360, 35);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 36);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btn_InicioCierre
            // 
            this.btn_InicioCierre.Location = new System.Drawing.Point(65, 139);
            this.btn_InicioCierre.Name = "btn_InicioCierre";
            this.btn_InicioCierre.Size = new System.Drawing.Size(104, 34);
            this.btn_InicioCierre.TabIndex = 5;
            this.btn_InicioCierre.Text = "INICIO-CIERRE";
            this.btn_InicioCierre.UseVisualStyleBackColor = true;
            this.btn_InicioCierre.Click += new System.EventHandler(this.btn_InicioCierre_Click);
            // 
            // btn_Denuncias
            // 
            this.btn_Denuncias.Location = new System.Drawing.Point(65, 362);
            this.btn_Denuncias.Name = "btn_Denuncias";
            this.btn_Denuncias.Size = new System.Drawing.Size(85, 34);
            this.btn_Denuncias.TabIndex = 6;
            this.btn_Denuncias.Text = "DENUNCIAS";
            this.btn_Denuncias.UseVisualStyleBackColor = true;
            // 
            // btn_expedientes
            // 
            this.btn_expedientes.Location = new System.Drawing.Point(65, 194);
            this.btn_expedientes.Name = "btn_expedientes";
            this.btn_expedientes.Size = new System.Drawing.Size(104, 31);
            this.btn_expedientes.TabIndex = 7;
            this.btn_expedientes.Text = "EXPEDIENTES";
            this.btn_expedientes.UseVisualStyleBackColor = true;
            // 
            // btn_Ipp
            // 
            this.btn_Ipp.Location = new System.Drawing.Point(179, 139);
            this.btn_Ipp.Name = "btn_Ipp";
            this.btn_Ipp.Size = new System.Drawing.Size(75, 34);
            this.btn_Ipp.TabIndex = 8;
            this.btn_Ipp.Text = "I.P.P.";
            this.btn_Ipp.UseVisualStyleBackColor = true;
            // 
            // btn_Notas
            // 
            this.btn_Notas.Location = new System.Drawing.Point(156, 362);
            this.btn_Notas.Name = "btn_Notas";
            this.btn_Notas.Size = new System.Drawing.Size(75, 34);
            this.btn_Notas.TabIndex = 9;
            this.btn_Notas.Text = "NOTAS";
            this.btn_Notas.UseVisualStyleBackColor = true;
            // 
            // btn_LegajoDetenidos
            // 
            this.btn_LegajoDetenidos.Location = new System.Drawing.Point(189, 194);
            this.btn_LegajoDetenidos.Name = "btn_LegajoDetenidos";
            this.btn_LegajoDetenidos.Size = new System.Drawing.Size(136, 31);
            this.btn_LegajoDetenidos.TabIndex = 10;
            this.btn_LegajoDetenidos.Text = "LEGAJO DETENIDOS";
            this.btn_LegajoDetenidos.UseVisualStyleBackColor = true;
            // 
            // btn_LegajoAutomotor
            // 
            this.btn_LegajoAutomotor.Location = new System.Drawing.Point(341, 194);
            this.btn_LegajoAutomotor.Name = "btn_LegajoAutomotor";
            this.btn_LegajoAutomotor.Size = new System.Drawing.Size(142, 31);
            this.btn_LegajoAutomotor.TabIndex = 11;
            this.btn_LegajoAutomotor.Text = "LEGAJO AUTOMOTOR";
            this.btn_LegajoAutomotor.UseVisualStyleBackColor = true;
            // 
            // btn_Contravenciones
            // 
            this.btn_Contravenciones.Location = new System.Drawing.Point(263, 140);
            this.btn_Contravenciones.Name = "btn_Contravenciones";
            this.btn_Contravenciones.Size = new System.Drawing.Size(136, 34);
            this.btn_Contravenciones.TabIndex = 12;
            this.btn_Contravenciones.Text = "CONTRAVENCIONES";
            this.btn_Contravenciones.UseVisualStyleBackColor = true;
            // 
            // btn_cargo
            // 
            this.btn_cargo.Location = new System.Drawing.Point(408, 142);
            this.btn_cargo.Name = "btn_cargo";
            this.btn_cargo.Size = new System.Drawing.Size(75, 31);
            this.btn_cargo.TabIndex = 13;
            this.btn_cargo.Text = "CARGO";
            this.btn_cargo.UseVisualStyleBackColor = true;
            this.btn_cargo.Click += new System.EventHandler(this.button9_Click);
            // 
            // btn_Inspecciones
            // 
            this.btn_Inspecciones.Location = new System.Drawing.Point(237, 362);
            this.btn_Inspecciones.Name = "btn_Inspecciones";
            this.btn_Inspecciones.Size = new System.Drawing.Size(104, 34);
            this.btn_Inspecciones.TabIndex = 14;
            this.btn_Inspecciones.Text = "INSPECIONES";
            this.btn_Inspecciones.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(542, 506);
            this.Controls.Add(this.btn_Inspecciones);
            this.Controls.Add(this.btn_cargo);
            this.Controls.Add(this.btn_Contravenciones);
            this.Controls.Add(this.btn_LegajoAutomotor);
            this.Controls.Add(this.btn_LegajoDetenidos);
            this.Controls.Add(this.btn_Notas);
            this.Controls.Add(this.btn_Ipp);
            this.Controls.Add(this.btn_expedientes);
            this.Controls.Add(this.btn_Denuncias);
            this.Controls.Add(this.btn_InicioCierre);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Btn_Configuracion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuPrincipal";
            this.Text = "MENU PRINCIPAL";
            this.Load += new System.EventHandler(this.MenuPrincipalLoad);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Configuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Btn_Configuracion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_InicioCierre;
        private System.Windows.Forms.Button btn_Denuncias;
        private System.Windows.Forms.Button btn_expedientes;
        private System.Windows.Forms.Button btn_Ipp;
        private System.Windows.Forms.Button btn_Notas;
        private System.Windows.Forms.Button btn_LegajoDetenidos;
        private System.Windows.Forms.Button btn_LegajoAutomotor;
        private System.Windows.Forms.Button btn_Contravenciones;
        private System.Windows.Forms.Button btn_cargo;
        private System.Windows.Forms.Button btn_Inspecciones;
    }
}

