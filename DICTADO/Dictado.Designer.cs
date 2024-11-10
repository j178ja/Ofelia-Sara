namespace DICTADO
{
    partial class Dictado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dictado));
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            panel2 = new Panel();
            btn_Negrita = new Button();
            btn_Cursiva = new Button();
            btn_Subrayado = new Button();
            btn_AlinearIzquierda = new Button();
            btn_Centrar = new Button();
            btn_AlinearDerecha = new Button();
            btn_Justificar = new Button();
            btn_Eliminar = new Button();
            btn_Guardar = new Button();
            btn_MayusculaMiniscula = new Button();
            btn_AumentarTamaño = new Button();
            btn_ReducirTamaño = new Button();
            btn_Microfono = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(btn_Eliminar);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(20, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(575, 332);
            panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 85);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(550, 150);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(btn_ReducirTamaño);
            panel2.Controls.Add(btn_AumentarTamaño);
            panel2.Controls.Add(btn_MayusculaMiniscula);
            panel2.Controls.Add(btn_Justificar);
            panel2.Controls.Add(btn_AlinearDerecha);
            panel2.Controls.Add(btn_Centrar);
            panel2.Controls.Add(btn_AlinearIzquierda);
            panel2.Controls.Add(btn_Subrayado);
            panel2.Controls.Add(btn_Cursiva);
            panel2.Controls.Add(btn_Negrita);
            panel2.Location = new Point(133, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 31);
            panel2.TabIndex = 1;
            // 
            // btn_Negrita
            // 
            btn_Negrita.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Negrita.Location = new Point(5, 3);
            btn_Negrita.Name = "btn_Negrita";
            btn_Negrita.Size = new Size(25, 25);
            btn_Negrita.TabIndex = 0;
            btn_Negrita.Text = "N";
            btn_Negrita.UseVisualStyleBackColor = true;
            // 
            // btn_Cursiva
            // 
            btn_Cursiva.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_Cursiva.Location = new Point(30, 3);
            btn_Cursiva.Name = "btn_Cursiva";
            btn_Cursiva.Size = new Size(25, 25);
            btn_Cursiva.TabIndex = 1;
            btn_Cursiva.Text = "C";
            btn_Cursiva.UseVisualStyleBackColor = true;
            // 
            // btn_Subrayado
            // 
            btn_Subrayado.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btn_Subrayado.Location = new Point(55, 3);
            btn_Subrayado.Name = "btn_Subrayado";
            btn_Subrayado.Size = new Size(25, 25);
            btn_Subrayado.TabIndex = 2;
            btn_Subrayado.Text = "S";
            btn_Subrayado.UseVisualStyleBackColor = true;
            // 
            // btn_AlinearIzquierda
            // 
            btn_AlinearIzquierda.BackgroundImage = Properties.Resources.izquierda;
            btn_AlinearIzquierda.BackgroundImageLayout = ImageLayout.Stretch;
            btn_AlinearIzquierda.Location = new Point(202, 3);
            btn_AlinearIzquierda.Name = "btn_AlinearIzquierda";
            btn_AlinearIzquierda.Size = new Size(25, 25);
            btn_AlinearIzquierda.TabIndex = 3;
            btn_AlinearIzquierda.UseVisualStyleBackColor = true;
            // 
            // btn_Centrar
            // 
            btn_Centrar.BackgroundImage = Properties.Resources.centro;
            btn_Centrar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Centrar.Location = new Point(227, 3);
            btn_Centrar.Name = "btn_Centrar";
            btn_Centrar.Size = new Size(25, 25);
            btn_Centrar.TabIndex = 4;
            btn_Centrar.UseVisualStyleBackColor = true;
            // 
            // btn_AlinearDerecha
            // 
            btn_AlinearDerecha.BackgroundImage = Properties.Resources.derecha;
            btn_AlinearDerecha.BackgroundImageLayout = ImageLayout.Stretch;
            btn_AlinearDerecha.Location = new Point(252, 3);
            btn_AlinearDerecha.Name = "btn_AlinearDerecha";
            btn_AlinearDerecha.Size = new Size(25, 25);
            btn_AlinearDerecha.TabIndex = 5;
            btn_AlinearDerecha.UseVisualStyleBackColor = true;
            // 
            // btn_Justificar
            // 
            btn_Justificar.BackgroundImage = Properties.Resources.justificar;
            btn_Justificar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Justificar.Location = new Point(277, 3);
            btn_Justificar.Name = "btn_Justificar";
            btn_Justificar.Size = new Size(25, 25);
            btn_Justificar.TabIndex = 6;
            btn_Justificar.UseVisualStyleBackColor = true;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.BackColor = Color.SkyBlue;
            btn_Eliminar.Image = (Image)resources.GetObject("btn_Eliminar.Image");
            btn_Eliminar.Location = new Point(133, 255);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(75, 67);
            btn_Eliminar.TabIndex = 2;
            btn_Eliminar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = Color.SkyBlue;
            btn_Guardar.Image = (Image)resources.GetObject("btn_Guardar.Image");
            btn_Guardar.Location = new Point(391, 255);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(75, 67);
            btn_Guardar.TabIndex = 3;
            btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_MayusculaMiniscula
            // 
            btn_MayusculaMiniscula.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_MayusculaMiniscula.Location = new Point(143, 3);
            btn_MayusculaMiniscula.Name = "btn_MayusculaMiniscula";
            btn_MayusculaMiniscula.Size = new Size(29, 25);
            btn_MayusculaMiniscula.TabIndex = 7;
            btn_MayusculaMiniscula.Text = "Aa";
            btn_MayusculaMiniscula.UseVisualStyleBackColor = true;
            // 
            // btn_AumentarTamaño
            // 
            btn_AumentarTamaño.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AumentarTamaño.Location = new Point(95, 3);
            btn_AumentarTamaño.Name = "btn_AumentarTamaño";
            btn_AumentarTamaño.Size = new Size(25, 25);
            btn_AumentarTamaño.TabIndex = 8;
            btn_AumentarTamaño.Text = "A";
            btn_AumentarTamaño.TextAlign = ContentAlignment.TopCenter;
            btn_AumentarTamaño.UseVisualStyleBackColor = true;
            // 
            // btn_ReducirTamaño
            // 
            btn_ReducirTamaño.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ReducirTamaño.Location = new Point(119, 3);
            btn_ReducirTamaño.Name = "btn_ReducirTamaño";
            btn_ReducirTamaño.Size = new Size(25, 25);
            btn_ReducirTamaño.TabIndex = 9;
            btn_ReducirTamaño.Text = "A";
            btn_ReducirTamaño.TextAlign = ContentAlignment.BottomCenter;
            btn_ReducirTamaño.UseVisualStyleBackColor = true;
            // 
            // btn_Microfono
            // 
            btn_Microfono.BackColor = Color.GreenYellow;
            btn_Microfono.BackgroundImage = Properties.Resources.microfono_activo;
            btn_Microfono.BackgroundImageLayout = ImageLayout.Center;
            btn_Microfono.Location = new Point(284, 5);
            btn_Microfono.Name = "btn_Microfono";
            btn_Microfono.Size = new Size(51, 52);
            btn_Microfono.TabIndex = 10;
            btn_Microfono.UseVisualStyleBackColor = false;
            // 
            // Dictado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 154, 174);
            ClientSize = new Size(617, 369);
            Controls.Add(btn_Microfono);
            Controls.Add(panel1);
            Name = "Dictado";
            Text = "REDACTAR TEXTO MEDIANTE VOZ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RichTextBox richTextBox1;
        private Panel panel2;
        private Button btn_Justificar;
        private Button btn_AlinearDerecha;
        private Button btn_Centrar;
        private Button btn_AlinearIzquierda;
        private Button btn_Subrayado;
        private Button btn_Cursiva;
        private Button btn_Negrita;
        private Button btn_Guardar;
        private Button btn_Eliminar;
        private Button btn_MayusculaMiniscula;
        private Button btn_ReducirTamaño;
        private Button btn_AumentarTamaño;
        private Button btn_Microfono;
    }
}
