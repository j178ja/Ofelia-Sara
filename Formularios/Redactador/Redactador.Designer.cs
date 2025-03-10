 

using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Redactador;

namespace Ofelia_Sara.Formularios.Redactador
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
            components = new System.ComponentModel.Container();
            PictureBox iconoEscudo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Redactador));
            panel1 = new Panel();
            panel2 = new Panel();
            btn_Enviar = new Button();
            btn_Limpiar = new Button();
            btn_Guardar = new Button();
            audioVisualizerControl = new AudioVisualizerControl();
            panel_Botones = new Panel();
            btn_ReducirTamaño = new Button();
            btn_AumentarTamaño = new Button();
            btn_MayusculaMinuscula = new Button();
            btn_Justificar = new Button();
            btn_AlinearDerecha = new Button();
            btn_Centrar = new Button();
            btn_AlinearIzquierda = new Button();
            btn_Subrayado = new Button();
            btn_Cursiva = new Button();
            btn_Negrita = new Button();
            richTextBox_Redactor = new RichTextBox();
            btn_Actuacion = new Button();
            btn_Minimizar = new Button();
            label_OfeliaSara = new Label();
            btn_Cerrar = new Button();
            panel_MenuSuperior = new Panel();
            panel_SubirAudio = new Panel();
            label_SubirAudio = new Label();
            pictureBox_SubirAudio = new PictureBox();
            btn_Maximizar = new Button();
            label_Redactador = new Label();
            timer_Barras = new Timer(components);
            btn_Microfono = new Button();
            menu_SeleccionPlantilla = new ContextMenuStrip(components);
            MenuCortito = new ToolStripMenuItem();
            HechosDelictivos = new ToolStripMenuItem();
            Hurto_Robo = new ToolStripMenuItem();
            Estafa = new ToolStripMenuItem();
            Estupefacientes = new ToolStripMenuItem();
            Contravencion = new ToolStripMenuItem();
            InfraccionTransito = new ToolStripMenuItem();
            dETENIDOSToolStripMenuItem = new ToolStripMenuItem();
            mOVIMIENTODETENIDOToolStripMenuItem = new ToolStripMenuItem();
            LibertadDetenido = new ToolStripMenuItem();
            cONVERSIONToolStripMenuItem = new ToolStripMenuItem();
            cCARNOVEDADToolStripMenuItem = new ToolStripMenuItem();
            PU = new ToolStripMenuItem();
            Denuncia = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            iconoEscudo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)iconoEscudo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel_Botones.SuspendLayout();
            panel_MenuSuperior.SuspendLayout();
            panel_SubirAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_SubirAudio).BeginInit();
            menu_SeleccionPlantilla.SuspendLayout();
            SuspendLayout();
            // 
            // iconoEscudo
            // 
            iconoEscudo.BackgroundImage = (Image)resources.GetObject("iconoEscudo.BackgroundImage");
            iconoEscudo.BackgroundImageLayout = ImageLayout.Stretch;
            iconoEscudo.Location = new Point(1, 3);
            iconoEscudo.Name = "iconoEscudo";
            iconoEscudo.Size = new Size(30, 28);
            iconoEscudo.TabIndex = 18;
            iconoEscudo.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(audioVisualizerControl);
            panel1.Controls.Add(panel_Botones);
            panel1.Controls.Add(richTextBox_Redactor);
            panel1.Location = new Point(17, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(547, 309);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_Enviar);
            panel2.Controls.Add(btn_Limpiar);
            panel2.Controls.Add(btn_Guardar);
            panel2.Location = new Point(10, 221);
            panel2.Name = "panel2";
            panel2.Size = new Size(527, 86);
            panel2.TabIndex = 6;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Anchor = AnchorStyles.Bottom;
            btn_Enviar.BackColor = Color.LightBlue;
            btn_Enviar.BackgroundImage = Properties.Resources.EnviarWhatsApp;
            btn_Enviar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Enviar.Cursor = Cursors.Hand;
            btn_Enviar.Location = new Point(391, 8);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(82, 68);
            btn_Enviar.TabIndex = 5;
            btn_Enviar.UseVisualStyleBackColor = false;
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.Anchor = AnchorStyles.Bottom;
            btn_Limpiar.BackColor = Color.SkyBlue;
            btn_Limpiar.BackgroundImage = (Image)resources.GetObject("btn_Limpiar.BackgroundImage");
            btn_Limpiar.BackgroundImageLayout = ImageLayout.Center;
            btn_Limpiar.Cursor = Cursors.Hand;
            btn_Limpiar.Location = new Point(66, 13);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new Size(64, 58);
            btn_Limpiar.TabIndex = 2;
            btn_Limpiar.UseVisualStyleBackColor = false;
            btn_Limpiar.Click += Btn_Eliminar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Anchor = AnchorStyles.Bottom;
            btn_Guardar.BackColor = Color.SkyBlue;
            btn_Guardar.BackgroundImage = (Image)resources.GetObject("btn_Guardar.BackgroundImage");
            btn_Guardar.BackgroundImageLayout = ImageLayout.Center;
            btn_Guardar.Cursor = Cursors.Hand;
            btn_Guardar.Location = new Point(220, 13);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(64, 58);
            btn_Guardar.TabIndex = 3;
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // audioVisualizerControl
            // 
            audioVisualizerControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            audioVisualizerControl.AutoSize = true;
            audioVisualizerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            audioVisualizerControl.Location = new Point(14, 6);
            audioVisualizerControl.Margin = new Padding(4, 5, 4, 5);
            audioVisualizerControl.Name = "audioVisualizerControl";
            audioVisualizerControl.Size = new Size(691, 56);
            audioVisualizerControl.TabIndex = 4;
            // 
            // panel_Botones
            // 
            panel_Botones.Anchor = AnchorStyles.Top;
            panel_Botones.AutoSize = true;
            panel_Botones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Botones.Controls.Add(btn_ReducirTamaño);
            panel_Botones.Controls.Add(btn_AumentarTamaño);
            panel_Botones.Controls.Add(btn_MayusculaMinuscula);
            panel_Botones.Controls.Add(btn_Justificar);
            panel_Botones.Controls.Add(btn_AlinearDerecha);
            panel_Botones.Controls.Add(btn_Centrar);
            panel_Botones.Controls.Add(btn_AlinearIzquierda);
            panel_Botones.Controls.Add(btn_Subrayado);
            panel_Botones.Controls.Add(btn_Cursiva);
            panel_Botones.Controls.Add(btn_Negrita);
            panel_Botones.Location = new Point(142, 40);
            panel_Botones.Name = "panel_Botones";
            panel_Botones.Size = new Size(261, 28);
            panel_Botones.TabIndex = 1;
            // 
            // btn_ReducirTamaño
            // 
            btn_ReducirTamaño.BackColor = Color.White;
            btn_ReducirTamaño.Cursor = Cursors.Hand;
            btn_ReducirTamaño.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ReducirTamaño.Location = new Point(102, 3);
            btn_ReducirTamaño.Name = "btn_ReducirTamaño";
            btn_ReducirTamaño.Size = new Size(21, 22);
            btn_ReducirTamaño.TabIndex = 9;
            btn_ReducirTamaño.Text = "A";
            btn_ReducirTamaño.TextAlign = ContentAlignment.BottomCenter;
            btn_ReducirTamaño.UseVisualStyleBackColor = false;
            btn_ReducirTamaño.Click += Btn_DisminuirTamaño_Click;
            btn_ReducirTamaño.MouseDown += Btn_MouseDown;
            btn_ReducirTamaño.MouseUp += Btn_MouseUp;
            // 
            // btn_AumentarTamaño
            // 
            btn_AumentarTamaño.BackColor = Color.White;
            btn_AumentarTamaño.Cursor = Cursors.Hand;
            btn_AumentarTamaño.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AumentarTamaño.Location = new Point(81, 3);
            btn_AumentarTamaño.Name = "btn_AumentarTamaño";
            btn_AumentarTamaño.Size = new Size(21, 22);
            btn_AumentarTamaño.TabIndex = 8;
            btn_AumentarTamaño.Text = "A";
            btn_AumentarTamaño.TextAlign = ContentAlignment.TopCenter;
            btn_AumentarTamaño.UseVisualStyleBackColor = false;
            btn_AumentarTamaño.Click += Btn_AumentarTamaño_Click;
            btn_AumentarTamaño.MouseDown += Btn_MouseDown;
            btn_AumentarTamaño.MouseUp += Btn_MouseUp;
            // 
            // btn_MayusculaMinuscula
            // 
            btn_MayusculaMinuscula.BackColor = Color.White;
            btn_MayusculaMinuscula.Cursor = Cursors.Hand;
            btn_MayusculaMinuscula.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_MayusculaMinuscula.Location = new Point(123, 3);
            btn_MayusculaMinuscula.Name = "btn_MayusculaMinuscula";
            btn_MayusculaMinuscula.Size = new Size(29, 22);
            btn_MayusculaMinuscula.TabIndex = 7;
            btn_MayusculaMinuscula.Text = "Aa";
            btn_MayusculaMinuscula.UseVisualStyleBackColor = false;
            btn_MayusculaMinuscula.Click += Btn_MayusculaMiniscula_Click;
            btn_MayusculaMinuscula.MouseDown += Btn_MouseDown;
            btn_MayusculaMinuscula.MouseUp += Btn_MouseUp;
            // 
            // btn_Justificar
            // 
            btn_Justificar.BackColor = Color.White;
            btn_Justificar.BackgroundImage = (Image)resources.GetObject("btn_Justificar.BackgroundImage");
            btn_Justificar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Justificar.Cursor = Cursors.Hand;
            btn_Justificar.Location = new Point(237, 3);
            btn_Justificar.Name = "btn_Justificar";
            btn_Justificar.Size = new Size(21, 22);
            btn_Justificar.TabIndex = 6;
            btn_Justificar.UseVisualStyleBackColor = false;
            btn_Justificar.Click += Btn_Justificar_Click;
            // 
            // btn_AlinearDerecha
            // 
            btn_AlinearDerecha.BackColor = Color.White;
            btn_AlinearDerecha.BackgroundImage = (Image)resources.GetObject("btn_AlinearDerecha.BackgroundImage");
            btn_AlinearDerecha.BackgroundImageLayout = ImageLayout.Stretch;
            btn_AlinearDerecha.Cursor = Cursors.Hand;
            btn_AlinearDerecha.Location = new Point(216, 3);
            btn_AlinearDerecha.Name = "btn_AlinearDerecha";
            btn_AlinearDerecha.Size = new Size(21, 22);
            btn_AlinearDerecha.TabIndex = 5;
            btn_AlinearDerecha.UseVisualStyleBackColor = false;
            btn_AlinearDerecha.Click += Btn_AlinearDerecha_Click;
            // 
            // btn_Centrar
            // 
            btn_Centrar.BackColor = Color.White;
            btn_Centrar.BackgroundImage = (Image)resources.GetObject("btn_Centrar.BackgroundImage");
            btn_Centrar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Centrar.Cursor = Cursors.Hand;
            btn_Centrar.Location = new Point(195, 3);
            btn_Centrar.Name = "btn_Centrar";
            btn_Centrar.Size = new Size(21, 22);
            btn_Centrar.TabIndex = 4;
            btn_Centrar.UseVisualStyleBackColor = false;
            btn_Centrar.Click += Btn_Centrar_Click;
            // 
            // btn_AlinearIzquierda
            // 
            btn_AlinearIzquierda.BackColor = Color.White;
            btn_AlinearIzquierda.BackgroundImage = (Image)resources.GetObject("btn_AlinearIzquierda.BackgroundImage");
            btn_AlinearIzquierda.BackgroundImageLayout = ImageLayout.Stretch;
            btn_AlinearIzquierda.Cursor = Cursors.Hand;
            btn_AlinearIzquierda.Location = new Point(173, 3);
            btn_AlinearIzquierda.Name = "btn_AlinearIzquierda";
            btn_AlinearIzquierda.Size = new Size(21, 22);
            btn_AlinearIzquierda.TabIndex = 3;
            btn_AlinearIzquierda.UseVisualStyleBackColor = false;
            btn_AlinearIzquierda.Click += Btn_AlinearIzquierda_Click;
            // 
            // btn_Subrayado
            // 
            btn_Subrayado.BackColor = Color.White;
            btn_Subrayado.Cursor = Cursors.Hand;
            btn_Subrayado.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btn_Subrayado.Location = new Point(47, 3);
            btn_Subrayado.Name = "btn_Subrayado";
            btn_Subrayado.Size = new Size(21, 22);
            btn_Subrayado.TabIndex = 2;
            btn_Subrayado.Text = "S";
            btn_Subrayado.UseVisualStyleBackColor = false;
            btn_Subrayado.Click += Btn_Subrayado_Click;
            // 
            // btn_Cursiva
            // 
            btn_Cursiva.BackColor = Color.White;
            btn_Cursiva.Cursor = Cursors.Hand;
            btn_Cursiva.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_Cursiva.Location = new Point(26, 3);
            btn_Cursiva.Name = "btn_Cursiva";
            btn_Cursiva.Size = new Size(21, 22);
            btn_Cursiva.TabIndex = 1;
            btn_Cursiva.Text = "C";
            btn_Cursiva.UseVisualStyleBackColor = false;
            btn_Cursiva.Click += btn_Cursiva_Click;
            // 
            // btn_Negrita
            // 
            btn_Negrita.BackColor = Color.White;
            btn_Negrita.Cursor = Cursors.Hand;
            btn_Negrita.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Negrita.Location = new Point(4, 3);
            btn_Negrita.Name = "btn_Negrita";
            btn_Negrita.Size = new Size(21, 22);
            btn_Negrita.TabIndex = 0;
            btn_Negrita.Text = "N";
            btn_Negrita.UseVisualStyleBackColor = false;
            btn_Negrita.Click += Btn_Negrita_Click;
            // 
            // richTextBox_Redactor
            // 
            richTextBox_Redactor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_Redactor.Location = new Point(10, 74);
            richTextBox_Redactor.Name = "richTextBox_Redactor";
            richTextBox_Redactor.Size = new Size(527, 141);
            richTextBox_Redactor.TabIndex = 0;
            richTextBox_Redactor.Text = "";
            richTextBox_Redactor.TextChanged += RichTextBox_Redactor_TextChanged;
            richTextBox_Redactor.MouseMove += RichTextBox_Redactor_MouseMove;
            // 
            // btn_Actuacion
            // 
            btn_Actuacion.BackColor = SystemColors.Highlight;
            btn_Actuacion.Cursor = Cursors.Hand;
            btn_Actuacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Actuacion.ForeColor = SystemColors.Control;
            btn_Actuacion.Location = new Point(55, 47);
            btn_Actuacion.Name = "btn_Actuacion";
            btn_Actuacion.Size = new Size(110, 29);
            btn_Actuacion.TabIndex = 20;
            btn_Actuacion.Text = "ACTUACION";
            btn_Actuacion.UseVisualStyleBackColor = false;
            btn_Actuacion.Click += btn_Actuacion_Click;
            // 
            // btn_Minimizar
            // 
            btn_Minimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Minimizar.BackColor = SystemColors.ButtonFace;
            btn_Minimizar.Cursor = Cursors.Hand;
            btn_Minimizar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatStyle = FlatStyle.Flat;
            btn_Minimizar.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Minimizar.ForeColor = SystemColors.WindowFrame;
            btn_Minimizar.Location = new Point(490, 5);
            btn_Minimizar.Name = "btn_Minimizar";
            btn_Minimizar.Size = new Size(25, 25);
            btn_Minimizar.TabIndex = 20;
            btn_Minimizar.Text = "-";
            btn_Minimizar.TextAlign = ContentAlignment.BottomCenter;
            btn_Minimizar.UseVisualStyleBackColor = false;
            btn_Minimizar.Click += Btn_Minimizar_Click;
            btn_Minimizar.MouseLeave += Btn_Panel_MouseLeave;
            btn_Minimizar.MouseHover += Btn_Panel_MouseHover;
            // 
            // label_OfeliaSara
            // 
            label_OfeliaSara.Anchor = AnchorStyles.Top;
            label_OfeliaSara.AutoSize = true;
            label_OfeliaSara.Cursor = Cursors.Hand;
            label_OfeliaSara.FlatStyle = FlatStyle.Flat;
            label_OfeliaSara.Font = new Font("Monotype Corsiva", 16F, FontStyle.Italic);
            label_OfeliaSara.Location = new Point(230, 5);
            label_OfeliaSara.Name = "label_OfeliaSara";
            label_OfeliaSara.Size = new Size(135, 33);
            label_OfeliaSara.TabIndex = 16;
            label_OfeliaSara.Text = "Ofelia - Sara";
            label_OfeliaSara.Click += Label_OfeliaSara_Click;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Cerrar.BackColor = SystemColors.ButtonFace;
            btn_Cerrar.Cursor = Cursors.Hand;
            btn_Cerrar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btn_Cerrar.FlatAppearance.BorderSize = 2;
            btn_Cerrar.FlatStyle = FlatStyle.Flat;
            btn_Cerrar.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Cerrar.ForeColor = SystemColors.ControlDarkDark;
            btn_Cerrar.Location = new Point(544, 5);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.Size = new Size(25, 25);
            btn_Cerrar.TabIndex = 17;
            btn_Cerrar.Text = "X";
            btn_Cerrar.UseVisualStyleBackColor = false;
            btn_Cerrar.Click += Btn_Cerrar_Click;
            btn_Cerrar.MouseLeave += Btn_Cerrar_MouseLeave;
            btn_Cerrar.MouseHover += Btn_Cerrar_MouseHover;
            // 
            // panel_MenuSuperior
            // 
            panel_MenuSuperior.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_MenuSuperior.BackColor = SystemColors.Menu;
            panel_MenuSuperior.Controls.Add(panel_SubirAudio);
            panel_MenuSuperior.Controls.Add(btn_Maximizar);
            panel_MenuSuperior.Controls.Add(btn_Minimizar);
            panel_MenuSuperior.Controls.Add(label_Redactador);
            panel_MenuSuperior.Controls.Add(iconoEscudo);
            panel_MenuSuperior.Controls.Add(label_OfeliaSara);
            panel_MenuSuperior.Controls.Add(btn_Cerrar);
            panel_MenuSuperior.Location = new Point(0, 0);
            panel_MenuSuperior.Name = "panel_MenuSuperior";
            panel_MenuSuperior.Size = new Size(576, 34);
            panel_MenuSuperior.TabIndex = 18;
            panel_MenuSuperior.MouseDown += panel_MenuSuperior_MouseDown;
            // 
            // panel_SubirAudio
            // 
            panel_SubirAudio.AutoSize = true;
            panel_SubirAudio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_SubirAudio.Controls.Add(label_SubirAudio);
            panel_SubirAudio.Controls.Add(pictureBox_SubirAudio);
            panel_SubirAudio.Location = new Point(378, 3);
            panel_SubirAudio.Name = "panel_SubirAudio";
            panel_SubirAudio.Size = new Size(116, 28);
            panel_SubirAudio.TabIndex = 22;
            // 
            // label_SubirAudio
            // 
            label_SubirAudio.AutoSize = true;
            label_SubirAudio.Location = new Point(32, 5);
            label_SubirAudio.Name = "label_SubirAudio";
            label_SubirAudio.Size = new Size(81, 20);
            label_SubirAudio.TabIndex = 1;
            label_SubirAudio.Text = "Transcribir ";
            label_SubirAudio.TextAlign = ContentAlignment.MiddleLeft;
            label_SubirAudio.Click += SubirAudio_Click;
            label_SubirAudio.MouseLeave += SubirAudio_MouseLeave;
            label_SubirAudio.MouseHover += Btn_Panel_MouseHover;
            // 
            // pictureBox_SubirAudio
            // 
            pictureBox_SubirAudio.BackgroundImageLayout = ImageLayout.Center;
            pictureBox_SubirAudio.Cursor = Cursors.Hand;
            pictureBox_SubirAudio.Location = new Point(0, 1);
            pictureBox_SubirAudio.Name = "pictureBox_SubirAudio";
            pictureBox_SubirAudio.Size = new Size(32, 24);
            pictureBox_SubirAudio.TabIndex = 0;
            pictureBox_SubirAudio.TabStop = false;
            pictureBox_SubirAudio.Click += SubirAudio_Click;
            pictureBox_SubirAudio.MouseLeave += SubirAudio_MouseLeave;
            pictureBox_SubirAudio.MouseHover += SubirAudio_MouseHover;
            // 
            // btn_Maximizar
            // 
            btn_Maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Maximizar.BackColor = SystemColors.ButtonFace;
            btn_Maximizar.BackgroundImage = (Image)resources.GetObject("btn_Maximizar.BackgroundImage");
            btn_Maximizar.BackgroundImageLayout = ImageLayout.Center;
            btn_Maximizar.Cursor = Cursors.Hand;
            btn_Maximizar.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btn_Maximizar.FlatAppearance.BorderSize = 2;
            btn_Maximizar.FlatStyle = FlatStyle.Flat;
            btn_Maximizar.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Maximizar.ForeColor = SystemColors.ControlDarkDark;
            btn_Maximizar.Location = new Point(517, 5);
            btn_Maximizar.Name = "btn_Maximizar";
            btn_Maximizar.Size = new Size(25, 25);
            btn_Maximizar.TabIndex = 21;
            btn_Maximizar.TextAlign = ContentAlignment.BottomCenter;
            btn_Maximizar.UseVisualStyleBackColor = false;
            btn_Maximizar.Click += Btn_Maximizar_Click;
            btn_Maximizar.MouseLeave += Btn_Panel_MouseLeave;
            btn_Maximizar.MouseHover += Btn_Panel_MouseHover;
            // 
            // label_Redactador
            // 
            label_Redactador.AutoSize = true;
            label_Redactador.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Redactador.Location = new Point(37, 9);
            label_Redactador.Name = "label_Redactador";
            label_Redactador.Size = new Size(141, 24);
            label_Redactador.TabIndex = 19;
            label_Redactador.Text = "REDACTADOR";
            // 
            // btn_Microfono
            // 
            btn_Microfono.Anchor = AnchorStyles.Top;
            btn_Microfono.BackColor = Color.Red;
            btn_Microfono.BackgroundImage = (Image)resources.GetObject("btn_Microfono.BackgroundImage");
            btn_Microfono.BackgroundImageLayout = ImageLayout.Center;
            btn_Microfono.Cursor = Cursors.Hand;
            btn_Microfono.Location = new Point(259, 39);
            btn_Microfono.Name = "btn_Microfono";
            btn_Microfono.Size = new Size(44, 45);
            btn_Microfono.TabIndex = 10;
            btn_Microfono.UseVisualStyleBackColor = false;
            btn_Microfono.Click += Btn_Microfono_Click;
            // 
            // menu_SeleccionPlantilla
            // 
            menu_SeleccionPlantilla.ImageScalingSize = new Size(20, 20);
            menu_SeleccionPlantilla.Items.AddRange(new ToolStripItem[] { MenuCortito, PU, Denuncia });
            menu_SeleccionPlantilla.Name = "contextMenuStrip";
            menu_SeleccionPlantilla.Size = new Size(180, 82);
            // 
            // MenuCortito
            // 
            MenuCortito.DropDownItems.AddRange(new ToolStripItem[] { HechosDelictivos, dETENIDOSToolStripMenuItem, cCARNOVEDADToolStripMenuItem });
            MenuCortito.Image = Properties.Resources.EscudoPolicia_PNG;
            MenuCortito.Name = "MenuCortito";
            MenuCortito.Size = new Size(179, 26);
            MenuCortito.Text = "INFORME WPP";
            // 
            // HechosDelictivos
            // 
            HechosDelictivos.DropDownItems.AddRange(new ToolStripItem[] { Hurto_Robo, Estafa, Estupefacientes, Contravencion, InfraccionTransito });
            HechosDelictivos.Image = Properties.Resources.graficos;
            HechosDelictivos.Name = "HechosDelictivos";
            HechosDelictivos.Size = new Size(233, 26);
            HechosDelictivos.Text = "HECHOS DELICTIVOS";
            // 
            // Hurto_Robo
            // 
            Hurto_Robo.Image = Properties.Resources.pistola;
            Hurto_Robo.Name = "Hurto_Robo";
            Hurto_Robo.Size = new Size(212, 26);
            Hurto_Robo.Text = " HURTO / ROBO";
            // 
            // Estafa
            // 
            Estafa.Image = Properties.Resources.dinero;
            Estafa.Name = "Estafa";
            Estafa.Size = new Size(212, 26);
            Estafa.Text = "ESTAFA";
            // 
            // Estupefacientes
            // 
            Estupefacientes.Image = Properties.Resources.estupefacientes;
            Estupefacientes.Name = "Estupefacientes";
            Estupefacientes.Size = new Size(212, 26);
            Estupefacientes.Text = "LEY 23.737";
            // 
            // Contravencion
            // 
            Contravencion.Image = Properties.Resources.persona;
            Contravencion.Name = "Contravencion";
            Contravencion.Size = new Size(212, 26);
            Contravencion.Text = "CONTRAVENCION";
            // 
            // InfraccionTransito
            // 
            InfraccionTransito.Image = Properties.Resources.moto;
            InfraccionTransito.Name = "InfraccionTransito";
            InfraccionTransito.Size = new Size(212, 26);
            InfraccionTransito.Text = "INFR. TRANSITO";
            // 
            // dETENIDOSToolStripMenuItem
            // 
            dETENIDOSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mOVIMIENTODETENIDOToolStripMenuItem, LibertadDetenido, cONVERSIONToolStripMenuItem });
            dETENIDOSToolStripMenuItem.Image = Properties.Resources.arresto_policial;
            dETENIDOSToolStripMenuItem.Name = "dETENIDOSToolStripMenuItem";
            dETENIDOSToolStripMenuItem.Size = new Size(233, 26);
            dETENIDOSToolStripMenuItem.Text = "DETENIDOS";
            // 
            // mOVIMIENTODETENIDOToolStripMenuItem
            // 
            mOVIMIENTODETENIDOToolStripMenuItem.Image = Properties.Resources.esposas;
            mOVIMIENTODETENIDOToolStripMenuItem.Name = "mOVIMIENTODETENIDOToolStripMenuItem";
            mOVIMIENTODETENIDOToolStripMenuItem.Size = new Size(259, 26);
            mOVIMIENTODETENIDOToolStripMenuItem.Text = "MOVIMIENTO DETENIDO";
            // 
            // LibertadDetenido
            // 
            LibertadDetenido.Image = Properties.Resources.libertadDetenido;
            LibertadDetenido.Name = "LibertadDetenido";
            LibertadDetenido.Size = new Size(259, 26);
            LibertadDetenido.Text = "LIBERTAD";
            // 
            // cONVERSIONToolStripMenuItem
            // 
            cONVERSIONToolStripMenuItem.Image = Properties.Resources.detencion;
            cONVERSIONToolStripMenuItem.Name = "cONVERSIONToolStripMenuItem";
            cONVERSIONToolStripMenuItem.Size = new Size(259, 26);
            cONVERSIONToolStripMenuItem.Text = "CONVERSION";
            // 
            // cCARNOVEDADToolStripMenuItem
            // 
            cCARNOVEDADToolStripMenuItem.Name = "cCARNOVEDADToolStripMenuItem";
            cCARNOVEDADToolStripMenuItem.Size = new Size(233, 26);
            cCARNOVEDADToolStripMenuItem.Text = "CCAR. NOVEDAD";
            // 
            // PU
            // 
            PU.Image = Properties.Resources.EscudoPolicia_PNG;
            PU.Name = "PU";
            PU.Size = new Size(179, 26);
            PU.Text = "P.U.";
            // 
            // Denuncia
            // 
            Denuncia.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem5, toolStripMenuItem6 });
            Denuncia.Image = Properties.Resources.denuncia_penal;
            Denuncia.Name = "Denuncia";
            Denuncia.Size = new Size(179, 26);
            Denuncia.Text = "DENUNCIA";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Image = Properties.Resources.dinero;
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(199, 26);
            toolStripMenuItem5.Text = "ESTAFA";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Image = Properties.Resources.rueda;
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(199, 26);
            toolStripMenuItem6.Text = "RUEDA AUXILIO";
            // 
            // Redactador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 154, 174);
            ClientSize = new Size(576, 409);
            Controls.Add(btn_Actuacion);
            Controls.Add(panel_MenuSuperior);
            Controls.Add(btn_Microfono);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(576, 409);
            Name = "Redactador";
            Text = "REDACTAR TEXTO MEDIANTE VOZ";
            Load += Redactador_Load;
            Paint += Triangulo_Paint;
            MouseDown += Redactador_MouseDown;
            MouseMove += Redactador_MouseMove;
            MouseUp += Redactador_MouseUp;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(btn_Microfono, 0);
            Controls.SetChildIndex(panel_MenuSuperior, 0);
            Controls.SetChildIndex(btn_Actuacion, 0);
            ((System.ComponentModel.ISupportInitialize)iconoEscudo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel_Botones.ResumeLayout(false);
            panel_MenuSuperior.ResumeLayout(false);
            panel_MenuSuperior.PerformLayout();
            panel_SubirAudio.ResumeLayout(false);
            panel_SubirAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_SubirAudio).EndInit();
            menu_SeleccionPlantilla.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Panel panel_SubirAudio;
        private PictureBox pictureBox_SubirAudio;
        private Label label_SubirAudio;
       
        private Button btn_Actuacion;
        private ContextMenuStrip menu_SeleccionPlantilla;
        private ToolStripMenuItem MenuCortito;
        private ToolStripMenuItem PU;
        private ToolStripMenuItem Denuncia;
        private ToolStripMenuItem LibertadDetenido;
        private ToolStripMenuItem ConversionDetenido;
        private ToolStripMenuItem HechosDelictivos;
        private ToolStripMenuItem Hurto_Robo;
        private ToolStripMenuItem Estupefacientes;
        private ToolStripMenuItem InfraccionTransito;
        private Button btn_Enviar;
        private ToolStripMenuItem Contravencion;
        private ToolStripMenuItem Estafa;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private Panel panel2;
        private ToolStripMenuItem dETENIDOSToolStripMenuItem;
        private ToolStripMenuItem mOVIMIENTODETENIDOToolStripMenuItem;
        private ToolStripMenuItem lIBERTADToolStripMenuItem;
      
        private ToolStripMenuItem cCARNOVEDADToolStripMenuItem;
        private ToolStripMenuItem cONVERSIONToolStripMenuItem;
    }
}

    
