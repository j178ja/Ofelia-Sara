
using REDACTADOR.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace REDACTADOR
{
    partial class Redactador
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Redactador));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.panel_Botones = new System.Windows.Forms.Panel();
            this.btn_ReducirTamaño = new System.Windows.Forms.Button();
            this.btn_AumentarTamaño = new System.Windows.Forms.Button();
            this.btn_MayusculaMiniscula = new System.Windows.Forms.Button();
            this.btn_Justificar = new System.Windows.Forms.Button();
            this.btn_AlinearDerecha = new System.Windows.Forms.Button();
            this.btn_Centrar = new System.Windows.Forms.Button();
            this.btn_AlinearIzquierda = new System.Windows.Forms.Button();
            this.btn_Subrayado = new System.Windows.Forms.Button();
            this.btn_Cursiva = new System.Windows.Forms.Button();
            this.btn_Negrita = new System.Windows.Forms.Button();
            this.richTextBox_Redactor = new System.Windows.Forms.RichTextBox();
            this.btn_Microfono = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.audioVisualizerControl = new REDACTADOR.AudioVisualizerControl();
            this.panel1.SuspendLayout();
            this.panel_Botones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.audioVisualizerControl);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.btn_Eliminar);
            this.panel1.Controls.Add(this.panel_Botones);
            this.panel1.Controls.Add(this.richTextBox_Redactor);
            this.panel1.Location = new System.Drawing.Point(17, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 324);
            this.panel1.TabIndex = 0;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.BackgroundImage")));
            this.btn_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Guardar.Location = new System.Drawing.Point(335, 255);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(64, 58);
            this.btn_Guardar.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_Guardar, "CREAR DOCUMENTO WORD");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Eliminar.BackgroundImage")));
            this.btn_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Eliminar.Location = new System.Drawing.Point(138, 255);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(64, 58);
            this.btn_Eliminar.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btn_Eliminar, "ELIMINAR");
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            // 
            // panel_Botones
            // 
            this.panel_Botones.AutoSize = true;
            this.panel_Botones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_Botones.Controls.Add(this.btn_ReducirTamaño);
            this.panel_Botones.Controls.Add(this.btn_AumentarTamaño);
            this.panel_Botones.Controls.Add(this.btn_MayusculaMiniscula);
            this.panel_Botones.Controls.Add(this.btn_Justificar);
            this.panel_Botones.Controls.Add(this.btn_AlinearDerecha);
            this.panel_Botones.Controls.Add(this.btn_Centrar);
            this.panel_Botones.Controls.Add(this.btn_AlinearIzquierda);
            this.panel_Botones.Controls.Add(this.btn_Subrayado);
            this.panel_Botones.Controls.Add(this.btn_Cursiva);
            this.panel_Botones.Controls.Add(this.btn_Negrita);
            this.panel_Botones.Location = new System.Drawing.Point(138, 40);
            this.panel_Botones.Name = "panel_Botones";
            this.panel_Botones.Size = new System.Drawing.Size(261, 28);
            this.panel_Botones.TabIndex = 1;
            // 
            // btn_ReducirTamaño
            // 
            this.btn_ReducirTamaño.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ReducirTamaño.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReducirTamaño.Location = new System.Drawing.Point(102, 3);
            this.btn_ReducirTamaño.Name = "btn_ReducirTamaño";
            this.btn_ReducirTamaño.Size = new System.Drawing.Size(21, 22);
            this.btn_ReducirTamaño.TabIndex = 9;
            this.btn_ReducirTamaño.Text = "A";
            this.btn_ReducirTamaño.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_ReducirTamaño, "DISMINUIR TAMAÑO");
            this.btn_ReducirTamaño.UseVisualStyleBackColor = true;
            // 
            // btn_AumentarTamaño
            // 
            this.btn_AumentarTamaño.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AumentarTamaño.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AumentarTamaño.Location = new System.Drawing.Point(81, 3);
            this.btn_AumentarTamaño.Name = "btn_AumentarTamaño";
            this.btn_AumentarTamaño.Size = new System.Drawing.Size(21, 22);
            this.btn_AumentarTamaño.TabIndex = 8;
            this.btn_AumentarTamaño.Text = "A";
            this.btn_AumentarTamaño.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btn_AumentarTamaño, "AUMENTAR TAMAÑO");
            this.btn_AumentarTamaño.UseVisualStyleBackColor = true;
            // 
            // btn_MayusculaMiniscula
            // 
            this.btn_MayusculaMiniscula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MayusculaMiniscula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MayusculaMiniscula.Location = new System.Drawing.Point(123, 3);
            this.btn_MayusculaMiniscula.Name = "btn_MayusculaMiniscula";
            this.btn_MayusculaMiniscula.Size = new System.Drawing.Size(29, 22);
            this.btn_MayusculaMiniscula.TabIndex = 7;
            this.btn_MayusculaMiniscula.Text = "Aa";
            this.toolTip1.SetToolTip(this.btn_MayusculaMiniscula, "MAYUSCULA/minuscula");
            this.btn_MayusculaMiniscula.UseVisualStyleBackColor = true;
            // 
            // btn_Justificar
            // 
            this.btn_Justificar.BackgroundImage = global::REDACTADOR.Properties.Resources.justificar;
            this.btn_Justificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Justificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Justificar.Location = new System.Drawing.Point(237, 3);
            this.btn_Justificar.Name = "btn_Justificar";
            this.btn_Justificar.Size = new System.Drawing.Size(21, 22);
            this.btn_Justificar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btn_Justificar, "Justificar");
            this.btn_Justificar.UseVisualStyleBackColor = true;
            // 
            // btn_AlinearDerecha
            // 
            this.btn_AlinearDerecha.BackgroundImage = global::REDACTADOR.Properties.Resources.derecha;
            this.btn_AlinearDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AlinearDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AlinearDerecha.Location = new System.Drawing.Point(216, 3);
            this.btn_AlinearDerecha.Name = "btn_AlinearDerecha";
            this.btn_AlinearDerecha.Size = new System.Drawing.Size(21, 22);
            this.btn_AlinearDerecha.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btn_AlinearDerecha, "Alinear a la DERECHA");
            this.btn_AlinearDerecha.UseVisualStyleBackColor = true;
            // 
            // btn_Centrar
            // 
            this.btn_Centrar.BackgroundImage = global::REDACTADOR.Properties.Resources.centro;
            this.btn_Centrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Centrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Centrar.Location = new System.Drawing.Point(195, 3);
            this.btn_Centrar.Name = "btn_Centrar";
            this.btn_Centrar.Size = new System.Drawing.Size(21, 22);
            this.btn_Centrar.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btn_Centrar, "Centrar");
            this.btn_Centrar.UseVisualStyleBackColor = true;
            // 
            // btn_AlinearIzquierda
            // 
            this.btn_AlinearIzquierda.BackgroundImage = global::REDACTADOR.Properties.Resources.izquierda;
            this.btn_AlinearIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AlinearIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AlinearIzquierda.Location = new System.Drawing.Point(173, 3);
            this.btn_AlinearIzquierda.Name = "btn_AlinearIzquierda";
            this.btn_AlinearIzquierda.Size = new System.Drawing.Size(21, 22);
            this.btn_AlinearIzquierda.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_AlinearIzquierda, "Alinear a la IZQUIERDA");
            this.btn_AlinearIzquierda.UseVisualStyleBackColor = true;
            // 
            // btn_Subrayado
            // 
            this.btn_Subrayado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Subrayado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Subrayado.Location = new System.Drawing.Point(47, 3);
            this.btn_Subrayado.Name = "btn_Subrayado";
            this.btn_Subrayado.Size = new System.Drawing.Size(21, 22);
            this.btn_Subrayado.TabIndex = 2;
            this.btn_Subrayado.Text = "S";
            this.toolTip1.SetToolTip(this.btn_Subrayado, "SUBRAYADO");
            this.btn_Subrayado.UseVisualStyleBackColor = true;
            // 
            // btn_Cursiva
            // 
            this.btn_Cursiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cursiva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cursiva.Location = new System.Drawing.Point(26, 3);
            this.btn_Cursiva.Name = "btn_Cursiva";
            this.btn_Cursiva.Size = new System.Drawing.Size(21, 22);
            this.btn_Cursiva.TabIndex = 1;
            this.btn_Cursiva.Text = "C";
            this.toolTip1.SetToolTip(this.btn_Cursiva, "CURSIVA");
            this.btn_Cursiva.UseVisualStyleBackColor = true;
            // 
            // btn_Negrita
            // 
            this.btn_Negrita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Negrita.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Negrita.Location = new System.Drawing.Point(4, 3);
            this.btn_Negrita.Name = "btn_Negrita";
            this.btn_Negrita.Size = new System.Drawing.Size(21, 22);
            this.btn_Negrita.TabIndex = 0;
            this.btn_Negrita.Text = "N";
            this.toolTip1.SetToolTip(this.btn_Negrita, "NEGRITA");
            this.btn_Negrita.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Redactor
            // 
            this.richTextBox_Redactor.Location = new System.Drawing.Point(10, 74);
            this.richTextBox_Redactor.Name = "richTextBox_Redactor";
            this.richTextBox_Redactor.Size = new System.Drawing.Size(519, 165);
            this.richTextBox_Redactor.TabIndex = 0;
            this.richTextBox_Redactor.Text = "";
            // 
            // btn_Microfono
            // 
            this.btn_Microfono.BackColor = System.Drawing.Color.Red;
            this.btn_Microfono.BackgroundImage = global::REDACTADOR.Properties.Resources.microfono_activo;
            this.btn_Microfono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Microfono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Microfono.Location = new System.Drawing.Point(260, 3);
            this.btn_Microfono.Name = "btn_Microfono";
            this.btn_Microfono.Size = new System.Drawing.Size(44, 45);
            this.btn_Microfono.TabIndex = 10;
            this.btn_Microfono.UseVisualStyleBackColor = false;
            this.btn_Microfono.Click += new System.EventHandler(this.btn_Microfono_Click);
            // 
            // audioVisualizerControl
            // 
            this.audioVisualizerControl.AutoSize = true;
            this.audioVisualizerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.audioVisualizerControl.Location = new System.Drawing.Point(14, 6);
            this.audioVisualizerControl.Name = "audioVisualizerControl";
            this.audioVisualizerControl.Size = new System.Drawing.Size(518, 36);
            this.audioVisualizerControl.TabIndex = 4;
            // 
            // Redactador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(568, 361);
            this.Controls.Add(this.btn_Microfono);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(584, 400);
            this.Name = "Redactador";
            this.Text = "REDACTAR TEXTO MEDIANTE VOZ";
            this.Load += new System.EventHandler(this.Redactador_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Botones.ResumeLayout(false);
            this.ResumeLayout(false);

    }

#endregion

    private Panel panel1;
    private RichTextBox richTextBox_Redactor;
    private Panel panel_Botones;
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
        private AudioVisualizerControl audioVisualizerControl;
        private ToolTip toolTip1;
    }
}

    
