
using REDACTADOR.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace REDACTADOR.Formularios
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
            System.Windows.Forms.PictureBox iconoEscudo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Redactador));
            this.panel1 = new System.Windows.Forms.Panel();
            this.audioVisualizerControl = new REDACTADOR.AudioVisualizerControl();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.panel_Botones = new System.Windows.Forms.Panel();
            this.btn_ReducirTamaño = new System.Windows.Forms.Button();
            this.btn_AumentarTamaño = new System.Windows.Forms.Button();
            this.btn_MayusculaMinuscula = new System.Windows.Forms.Button();
            this.btn_Justificar = new System.Windows.Forms.Button();
            this.btn_AlinearDerecha = new System.Windows.Forms.Button();
            this.btn_Centrar = new System.Windows.Forms.Button();
            this.btn_AlinearIzquierda = new System.Windows.Forms.Button();
            this.btn_Subrayado = new System.Windows.Forms.Button();
            this.btn_Cursiva = new System.Windows.Forms.Button();
            this.btn_Negrita = new System.Windows.Forms.Button();
            this.richTextBox_Redactor = new System.Windows.Forms.RichTextBox();
            this.btn_Minimizar = new System.Windows.Forms.Button();
            this.label_OfeliaSara = new System.Windows.Forms.Label();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.panel_MenuSuperior = new System.Windows.Forms.Panel();
            this.panel_SubirAudio = new System.Windows.Forms.Panel();
            this.label_SubirAudio = new System.Windows.Forms.Label();
            this.pictureBox_SubirAudio = new System.Windows.Forms.PictureBox();
            this.btn_Maximizar = new System.Windows.Forms.Button();
            this.label_Redactador = new System.Windows.Forms.Label();
            this.timer_Barras = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Microfono = new System.Windows.Forms.Button();
            iconoEscudo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(iconoEscudo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_Botones.SuspendLayout();
            this.panel_MenuSuperior.SuspendLayout();
            this.panel_SubirAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SubirAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // iconoEscudo
            // 
            iconoEscudo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconoEscudo.BackgroundImage")));
            iconoEscudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            iconoEscudo.Location = new System.Drawing.Point(1, 3);
            iconoEscudo.Name = "iconoEscudo";
            iconoEscudo.Size = new System.Drawing.Size(30, 28);
            iconoEscudo.TabIndex = 18;
            iconoEscudo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.audioVisualizerControl);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.panel_Botones);
            this.panel1.Controls.Add(this.richTextBox_Redactor);
            this.panel1.Location = new System.Drawing.Point(17, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 360);
            this.panel1.TabIndex = 0;
            // 
            // audioVisualizerControl
            // 
            this.audioVisualizerControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioVisualizerControl.AutoSize = true;
            this.audioVisualizerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.audioVisualizerControl.Location = new System.Drawing.Point(14, 6);
            this.audioVisualizerControl.Name = "audioVisualizerControl";
            this.audioVisualizerControl.Size = new System.Drawing.Size(518, 36);
            this.audioVisualizerControl.TabIndex = 4;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.BackgroundImage")));
            this.btn_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Location = new System.Drawing.Point(339, 291);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(64, 58);
            this.btn_Guardar.TabIndex = 3;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.BackgroundImage")));
            this.btn_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Location = new System.Drawing.Point(142, 291);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(64, 58);
            this.btn_Limpiar.TabIndex = 2;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // panel_Botones
            // 
            this.panel_Botones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_Botones.AutoSize = true;
            this.panel_Botones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_Botones.Controls.Add(this.btn_ReducirTamaño);
            this.panel_Botones.Controls.Add(this.btn_AumentarTamaño);
            this.panel_Botones.Controls.Add(this.btn_MayusculaMinuscula);
            this.panel_Botones.Controls.Add(this.btn_Justificar);
            this.panel_Botones.Controls.Add(this.btn_AlinearDerecha);
            this.panel_Botones.Controls.Add(this.btn_Centrar);
            this.panel_Botones.Controls.Add(this.btn_AlinearIzquierda);
            this.panel_Botones.Controls.Add(this.btn_Subrayado);
            this.panel_Botones.Controls.Add(this.btn_Cursiva);
            this.panel_Botones.Controls.Add(this.btn_Negrita);
            this.panel_Botones.Location = new System.Drawing.Point(142, 40);
            this.panel_Botones.Name = "panel_Botones";
            this.panel_Botones.Size = new System.Drawing.Size(261, 28);
            this.panel_Botones.TabIndex = 1;
            // 
            // btn_ReducirTamaño
            // 
            this.btn_ReducirTamaño.BackColor = System.Drawing.Color.White;
            this.btn_ReducirTamaño.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ReducirTamaño.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReducirTamaño.Location = new System.Drawing.Point(102, 3);
            this.btn_ReducirTamaño.Name = "btn_ReducirTamaño";
            this.btn_ReducirTamaño.Size = new System.Drawing.Size(21, 22);
            this.btn_ReducirTamaño.TabIndex = 9;
            this.btn_ReducirTamaño.Text = "A";
            this.btn_ReducirTamaño.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ReducirTamaño.UseVisualStyleBackColor = false;
            this.btn_ReducirTamaño.Click += new System.EventHandler(this.btn_DisminuirTamaño_Click);
            this.btn_ReducirTamaño.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_ReducirTamaño.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_AumentarTamaño
            // 
            this.btn_AumentarTamaño.BackColor = System.Drawing.Color.White;
            this.btn_AumentarTamaño.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AumentarTamaño.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AumentarTamaño.Location = new System.Drawing.Point(81, 3);
            this.btn_AumentarTamaño.Name = "btn_AumentarTamaño";
            this.btn_AumentarTamaño.Size = new System.Drawing.Size(21, 22);
            this.btn_AumentarTamaño.TabIndex = 8;
            this.btn_AumentarTamaño.Text = "A";
            this.btn_AumentarTamaño.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_AumentarTamaño.UseVisualStyleBackColor = false;
            this.btn_AumentarTamaño.Click += new System.EventHandler(this.btn_AumentarTamaño_Click);
            this.btn_AumentarTamaño.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_AumentarTamaño.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_MayusculaMinuscula
            // 
            this.btn_MayusculaMinuscula.BackColor = System.Drawing.Color.White;
            this.btn_MayusculaMinuscula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MayusculaMinuscula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MayusculaMinuscula.Location = new System.Drawing.Point(123, 3);
            this.btn_MayusculaMinuscula.Name = "btn_MayusculaMinuscula";
            this.btn_MayusculaMinuscula.Size = new System.Drawing.Size(29, 22);
            this.btn_MayusculaMinuscula.TabIndex = 7;
            this.btn_MayusculaMinuscula.Text = "Aa";
            this.btn_MayusculaMinuscula.UseVisualStyleBackColor = false;
            this.btn_MayusculaMinuscula.Click += new System.EventHandler(this.btn_MayusculaMiniscula_Click);
            this.btn_MayusculaMinuscula.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_MayusculaMinuscula.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_Justificar
            // 
            this.btn_Justificar.BackColor = System.Drawing.Color.White;
            this.btn_Justificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Justificar.BackgroundImage")));
            this.btn_Justificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Justificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Justificar.Location = new System.Drawing.Point(237, 3);
            this.btn_Justificar.Name = "btn_Justificar";
            this.btn_Justificar.Size = new System.Drawing.Size(21, 22);
            this.btn_Justificar.TabIndex = 6;
            this.btn_Justificar.UseVisualStyleBackColor = false;
            this.btn_Justificar.Click += new System.EventHandler(this.btn_Justificar_Click);
            // 
            // btn_AlinearDerecha
            // 
            this.btn_AlinearDerecha.BackColor = System.Drawing.Color.White;
            this.btn_AlinearDerecha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AlinearDerecha.BackgroundImage")));
            this.btn_AlinearDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AlinearDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AlinearDerecha.Location = new System.Drawing.Point(216, 3);
            this.btn_AlinearDerecha.Name = "btn_AlinearDerecha";
            this.btn_AlinearDerecha.Size = new System.Drawing.Size(21, 22);
            this.btn_AlinearDerecha.TabIndex = 5;
            this.btn_AlinearDerecha.UseVisualStyleBackColor = false;
            this.btn_AlinearDerecha.Click += new System.EventHandler(this.btn_AlinearDerecha_Click);
            // 
            // btn_Centrar
            // 
            this.btn_Centrar.BackColor = System.Drawing.Color.White;
            this.btn_Centrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Centrar.BackgroundImage")));
            this.btn_Centrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Centrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Centrar.Location = new System.Drawing.Point(195, 3);
            this.btn_Centrar.Name = "btn_Centrar";
            this.btn_Centrar.Size = new System.Drawing.Size(21, 22);
            this.btn_Centrar.TabIndex = 4;
            this.btn_Centrar.UseVisualStyleBackColor = false;
            this.btn_Centrar.Click += new System.EventHandler(this.btn_Centrar_Click);
            // 
            // btn_AlinearIzquierda
            // 
            this.btn_AlinearIzquierda.BackColor = System.Drawing.Color.White;
            this.btn_AlinearIzquierda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AlinearIzquierda.BackgroundImage")));
            this.btn_AlinearIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AlinearIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AlinearIzquierda.Location = new System.Drawing.Point(173, 3);
            this.btn_AlinearIzquierda.Name = "btn_AlinearIzquierda";
            this.btn_AlinearIzquierda.Size = new System.Drawing.Size(21, 22);
            this.btn_AlinearIzquierda.TabIndex = 3;
            this.btn_AlinearIzquierda.UseVisualStyleBackColor = false;
            this.btn_AlinearIzquierda.Click += new System.EventHandler(this.btn_AlinearIzquierda_Click);
            // 
            // btn_Subrayado
            // 
            this.btn_Subrayado.BackColor = System.Drawing.Color.White;
            this.btn_Subrayado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Subrayado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Subrayado.Location = new System.Drawing.Point(47, 3);
            this.btn_Subrayado.Name = "btn_Subrayado";
            this.btn_Subrayado.Size = new System.Drawing.Size(21, 22);
            this.btn_Subrayado.TabIndex = 2;
            this.btn_Subrayado.Text = "S";
            this.btn_Subrayado.UseVisualStyleBackColor = false;
            this.btn_Subrayado.Click += new System.EventHandler(this.btn_Subrayado_Click);
            // 
            // btn_Cursiva
            // 
            this.btn_Cursiva.BackColor = System.Drawing.Color.White;
            this.btn_Cursiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cursiva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cursiva.Location = new System.Drawing.Point(26, 3);
            this.btn_Cursiva.Name = "btn_Cursiva";
            this.btn_Cursiva.Size = new System.Drawing.Size(21, 22);
            this.btn_Cursiva.TabIndex = 1;
            this.btn_Cursiva.Text = "C";
            this.btn_Cursiva.UseVisualStyleBackColor = false;
            this.btn_Cursiva.Click += new System.EventHandler(this.btn_Cursiva_Click);
            // 
            // btn_Negrita
            // 
            this.btn_Negrita.BackColor = System.Drawing.Color.White;
            this.btn_Negrita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Negrita.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Negrita.Location = new System.Drawing.Point(4, 3);
            this.btn_Negrita.Name = "btn_Negrita";
            this.btn_Negrita.Size = new System.Drawing.Size(21, 22);
            this.btn_Negrita.TabIndex = 0;
            this.btn_Negrita.Text = "N";
            this.btn_Negrita.UseVisualStyleBackColor = false;
            this.btn_Negrita.Click += new System.EventHandler(this.btn_Negrita_Click);
            // 
            // richTextBox_Redactor
            // 
            this.richTextBox_Redactor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Redactor.Location = new System.Drawing.Point(10, 74);
            this.richTextBox_Redactor.Name = "richTextBox_Redactor";
            this.richTextBox_Redactor.Size = new System.Drawing.Size(527, 201);
            this.richTextBox_Redactor.TabIndex = 0;
            this.richTextBox_Redactor.Text = "";
            this.richTextBox_Redactor.TextChanged += new System.EventHandler(this.richTextBox_Redactor_TextChanged);
            this.richTextBox_Redactor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RichTextBox_Redactor_MouseMove);
            // 
            // btn_Minimizar
            // 
            this.btn_Minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Minimizar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Minimizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Minimizar.FlatAppearance.BorderSize = 2;
            this.btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimizar.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimizar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_Minimizar.Location = new System.Drawing.Point(490, 5);
            this.btn_Minimizar.Name = "btn_Minimizar";
            this.btn_Minimizar.Size = new System.Drawing.Size(25, 25);
            this.btn_Minimizar.TabIndex = 20;
            this.btn_Minimizar.Text = "-";
            this.btn_Minimizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_Minimizar, "Minimizar");
            this.btn_Minimizar.UseVisualStyleBackColor = false;
            this.btn_Minimizar.Click += new System.EventHandler(this.Btn_Minimizar_Click);
            this.btn_Minimizar.MouseLeave += new System.EventHandler(this.Btn_Panel_MouseLeave);
            this.btn_Minimizar.MouseHover += new System.EventHandler(this.Btn_Panel_MouseHover);
            // 
            // label_OfeliaSara
            // 
            this.label_OfeliaSara.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_OfeliaSara.AutoSize = true;
            this.label_OfeliaSara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_OfeliaSara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_OfeliaSara.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Italic);
            this.label_OfeliaSara.Location = new System.Drawing.Point(230, 5);
            this.label_OfeliaSara.Name = "label_OfeliaSara";
            this.label_OfeliaSara.Size = new System.Drawing.Size(109, 26);
            this.label_OfeliaSara.TabIndex = 16;
            this.label_OfeliaSara.Text = "Ofelia - Sara";
            this.label_OfeliaSara.Click += new System.EventHandler(this.Label_OfeliaSara_Click);
            this.label_OfeliaSara.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_OfeliaSara_Paint);
            this.label_OfeliaSara.MouseLeave += new System.EventHandler(this.Label_OfeliaSara_MouseLeave);
            this.label_OfeliaSara.MouseHover += new System.EventHandler(this.Label_OfeliaSara_MouseHover);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cerrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Cerrar.FlatAppearance.BorderSize = 2;
            this.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Cerrar.Location = new System.Drawing.Point(544, 5);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(25, 25);
            this.btn_Cerrar.TabIndex = 17;
            this.btn_Cerrar.Text = "X";
            this.toolTip1.SetToolTip(this.btn_Cerrar, "Cerrar");
            this.btn_Cerrar.UseVisualStyleBackColor = false;
            this.btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            this.btn_Cerrar.MouseLeave += new System.EventHandler(this.Btn_Cerrar_MouseLeave);
            this.btn_Cerrar.MouseHover += new System.EventHandler(this.Btn_Cerrar_MouseHover);
            // 
            // panel_MenuSuperior
            // 
            this.panel_MenuSuperior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_MenuSuperior.BackColor = System.Drawing.SystemColors.Menu;
            this.panel_MenuSuperior.Controls.Add(this.panel_SubirAudio);
            this.panel_MenuSuperior.Controls.Add(this.btn_Maximizar);
            this.panel_MenuSuperior.Controls.Add(this.btn_Minimizar);
            this.panel_MenuSuperior.Controls.Add(this.label_Redactador);
            this.panel_MenuSuperior.Controls.Add(iconoEscudo);
            this.panel_MenuSuperior.Controls.Add(this.label_OfeliaSara);
            this.panel_MenuSuperior.Controls.Add(this.btn_Cerrar);
            this.panel_MenuSuperior.Location = new System.Drawing.Point(0, 0);
            this.panel_MenuSuperior.Name = "panel_MenuSuperior";
            this.panel_MenuSuperior.Size = new System.Drawing.Size(576, 34);
            this.panel_MenuSuperior.TabIndex = 18;
            this.panel_MenuSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MenuSuperior_MouseDown);
            // 
            // panel_SubirAudio
            // 
            this.panel_SubirAudio.AutoSize = true;
            this.panel_SubirAudio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_SubirAudio.Controls.Add(this.label_SubirAudio);
            this.panel_SubirAudio.Controls.Add(this.pictureBox_SubirAudio);
            this.panel_SubirAudio.Location = new System.Drawing.Point(378, 3);
            this.panel_SubirAudio.Name = "panel_SubirAudio";
            this.panel_SubirAudio.Size = new System.Drawing.Size(94, 28);
            this.panel_SubirAudio.TabIndex = 22;
            // 
            // label_SubirAudio
            // 
            this.label_SubirAudio.AutoSize = true;
            this.label_SubirAudio.Location = new System.Drawing.Point(32, 5);
            this.label_SubirAudio.Name = "label_SubirAudio";
            this.label_SubirAudio.Size = new System.Drawing.Size(59, 13);
            this.label_SubirAudio.TabIndex = 1;
            this.label_SubirAudio.Text = "Transcribir ";
            this.label_SubirAudio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_SubirAudio.Click += new System.EventHandler(this.SubirAudio_Click);
            this.label_SubirAudio.MouseLeave += new System.EventHandler(this.SubirAudio_MouseLeave);
            this.label_SubirAudio.MouseHover += new System.EventHandler(this.Btn_Panel_MouseHover);
            // 
            // pictureBox_SubirAudio
            // 
            this.pictureBox_SubirAudio.BackgroundImage = global::REDACTADOR.Properties.Resources.cargarAudio;
            this.pictureBox_SubirAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_SubirAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_SubirAudio.Location = new System.Drawing.Point(0, 1);
            this.pictureBox_SubirAudio.Name = "pictureBox_SubirAudio";
            this.pictureBox_SubirAudio.Size = new System.Drawing.Size(32, 24);
            this.pictureBox_SubirAudio.TabIndex = 0;
            this.pictureBox_SubirAudio.TabStop = false;
            this.pictureBox_SubirAudio.Click += new System.EventHandler(this.SubirAudio_Click);
            this.pictureBox_SubirAudio.MouseLeave += new System.EventHandler(this.SubirAudio_MouseLeave);
            this.pictureBox_SubirAudio.MouseHover += new System.EventHandler(this.SubirAudio_MouseHover);
            // 
            // btn_Maximizar
            // 
            this.btn_Maximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Maximizar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Maximizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Maximizar.BackgroundImage")));
            this.btn_Maximizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Maximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Maximizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Maximizar.FlatAppearance.BorderSize = 2;
            this.btn_Maximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Maximizar.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Maximizar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Maximizar.Location = new System.Drawing.Point(517, 5);
            this.btn_Maximizar.Name = "btn_Maximizar";
            this.btn_Maximizar.Size = new System.Drawing.Size(25, 25);
            this.btn_Maximizar.TabIndex = 21;
            this.btn_Maximizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_Maximizar, "Maximizar");
            this.btn_Maximizar.UseVisualStyleBackColor = false;
            this.btn_Maximizar.Click += new System.EventHandler(this.Btn_Maximizar_Click);
            this.btn_Maximizar.MouseLeave += new System.EventHandler(this.Btn_Panel_MouseLeave);
            this.btn_Maximizar.MouseHover += new System.EventHandler(this.Btn_Panel_MouseHover);
            // 
            // label_Redactador
            // 
            this.label_Redactador.AutoSize = true;
            this.label_Redactador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Redactador.Location = new System.Drawing.Point(37, 9);
            this.label_Redactador.Name = "label_Redactador";
            this.label_Redactador.Size = new System.Drawing.Size(112, 18);
            this.label_Redactador.TabIndex = 19;
            this.label_Redactador.Text = "REDACTADOR";
            // 
            // btn_Microfono
            // 
            this.btn_Microfono.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Microfono.BackColor = System.Drawing.Color.Red;
            this.btn_Microfono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Microfono.BackgroundImage")));
            this.btn_Microfono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Microfono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Microfono.Location = new System.Drawing.Point(259, 39);
            this.btn_Microfono.Name = "btn_Microfono";
            this.btn_Microfono.Size = new System.Drawing.Size(44, 45);
            this.btn_Microfono.TabIndex = 10;
            this.btn_Microfono.UseVisualStyleBackColor = false;
            this.btn_Microfono.Click += new System.EventHandler(this.btn_Microfono_Click);
            // 
            // Redactador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(576, 434);
            this.Controls.Add(this.panel_MenuSuperior);
            this.Controls.Add(this.btn_Microfono);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(576, 400);
            this.Name = "Redactador";
            this.Text = "REDACTAR TEXTO MEDIANTE VOZ";
            this.Load += new System.EventHandler(this.Redactador_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Triangulo_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Redactador_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Redactador_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Redactador_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(iconoEscudo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Botones.ResumeLayout(false);
            this.panel_MenuSuperior.ResumeLayout(false);
            this.panel_MenuSuperior.PerformLayout();
            this.panel_SubirAudio.ResumeLayout(false);
            this.panel_SubirAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SubirAudio)).EndInit();
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
    private Button btn_Limpiar;
    private Button btn_MayusculaMinuscula;
    private Button btn_ReducirTamaño;
    private Button btn_AumentarTamaño;
    private Button btn_Microfono;
        private AudioVisualizerControl audioVisualizerControl;
        private Panel panel_MenuSuperior;
        private Button btn_Minimizar;
        private Label label_Redactador;
        private Label label_OfeliaSara;
        private Button btn_Cerrar;
        private Button btn_Maximizar;
        private Timer timer_Barras;
        private ToolTip toolTip1;
        private Panel panel_SubirAudio;
        private PictureBox pictureBox_SubirAudio;
        private Label label_SubirAudio;
    }
}

    
