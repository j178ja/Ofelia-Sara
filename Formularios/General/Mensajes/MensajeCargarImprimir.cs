/*--------este archivo crea un formulario con caracteristicas especificas----
 -------creo que seria mas facil creaun un win form y modificar sus propiedadees y 
----------crear una nueva instancia tras  hacer click en boton imprimir-----*/
//------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General.Mensajes
{
    public partial class MensajeCargarImprimir : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Panel MensajeImprimir;
        private Panel innerPanel;
        private ProgressBar progressBar;
        private Label label1;
        private Timer timer1;
        private Button btn_CancelarImpresion;
        private Label label_Impresion;
        private Label label_OfeliaSara;
        private PictureBox imagen_Impresora;

        public MensajeCargarImprimir()
        {
            InitializeComponent();
            timer1.Interval = 100;

            // Aplicar bordes redondeados al innerPanel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            innerPanel.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            timer1.Tick += new EventHandler(timer1_Tick);
            Load += new EventHandler(MensajeCargarImprimir_Load);
        }

        private void MensajeCargarImprimir_Load(object sender, EventArgs e)
        {
            if (progressBar != null)
            {
                progressBar.Location = new Point(15, 38);
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Error: progressBar1 no se ha inicializado correctamente.", "Error de inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value += 1;

                if (progressBar.Value == 50)
                {
                    label1.Text = "Preparando archivo para impresión...";
                    label1.Location = new Point(15, label1.Location.Y);
                    label1.ForeColor = Color.White;
                }
            }
            else
            {
                timer1.Stop();
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Operación Cancelada", "Confirmación Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajeCargarImprimir));
            timer1 = new Timer(components);
            MensajeImprimir = new Panel();
            label_Impresion = new Label();
            label_OfeliaSara = new Label();
            innerPanel = new Panel();
            imagen_Impresora = new PictureBox();
            btn_CancelarImpresion = new Button();
            label1 = new Label();
            //this.progressBar = new Ofelia_Sara.general.clases.CustomProgressBar();
            MensajeImprimir.SuspendLayout();
            innerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagen_Impresora).BeginInit();
            SuspendLayout();
            // 
            // MensajeImprimir
            // 
            MensajeImprimir.BackColor = Color.FromArgb(0, 154, 174);
            MensajeImprimir.Controls.Add(label_Impresion);
            MensajeImprimir.Controls.Add(label_OfeliaSara);
            MensajeImprimir.Controls.Add(innerPanel);
            MensajeImprimir.Dock = DockStyle.Fill;
            MensajeImprimir.Location = new Point(0, 0);
            MensajeImprimir.Name = "MensajeImprimir";
            MensajeImprimir.Padding = new Padding(10, 30, 10, 7);
            MensajeImprimir.Size = new Size(350, 186);
            MensajeImprimir.TabIndex = 0;
            // 
            // label_Impresion
            // 
            label_Impresion.AutoSize = true;
            label_Impresion.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Impresion.Location = new Point(22, 9);
            label_Impresion.Name = "label_Impresion";
            label_Impresion.Size = new Size(75, 16);
            label_Impresion.TabIndex = 3;
            label_Impresion.Text = "Impresión";
            // 
            // label_OfeliaSara
            // 
            label_OfeliaSara.AutoSize = true;
            label_OfeliaSara.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label_OfeliaSara.Location = new Point(262, 9);
            label_OfeliaSara.Name = "label_OfeliaSara";
            label_OfeliaSara.Size = new Size(71, 18);
            label_OfeliaSara.TabIndex = 2;
            label_OfeliaSara.Text = "Ofelia-Sara";
            // 
            // innerPanel
            // 
            innerPanel.BackColor = Color.FromArgb(178, 213, 230);
            innerPanel.Controls.Add(imagen_Impresora);
            innerPanel.Controls.Add(btn_CancelarImpresion);
            innerPanel.Controls.Add(label1);
            innerPanel.Controls.Add(progressBar);
            innerPanel.Dock = DockStyle.Fill;
            innerPanel.Location = new Point(10, 30);
            innerPanel.Name = "innerPanel";
            innerPanel.Padding = new Padding(10);
            innerPanel.Size = new Size(330, 149);
            innerPanel.TabIndex = 0;
            // 
            // imagen_Impresora
            // 
            imagen_Impresora.BackgroundImage = (Image)resources.GetObject("imagen_Impresora.BackgroundImage");
            imagen_Impresora.BackgroundImageLayout = ImageLayout.Center;
            imagen_Impresora.Location = new Point(15, 67);
            imagen_Impresora.Name = "imagen_Impresora";
            imagen_Impresora.Size = new Size(100, 70);
            imagen_Impresora.SizeMode = PictureBoxSizeMode.AutoSize;
            imagen_Impresora.TabIndex = 2;
            imagen_Impresora.TabStop = false;
            // 
            // btn_CancelarImpresion
            // 
            btn_CancelarImpresion.BackColor = Color.FromArgb(234, 40, 0);
            btn_CancelarImpresion.Cursor = Cursors.Hand;
            btn_CancelarImpresion.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_CancelarImpresion.ForeColor = SystemColors.ControlLightLight;
            btn_CancelarImpresion.Location = new Point(213, 82);
            btn_CancelarImpresion.Name = "btn_CancelarImpresion";
            btn_CancelarImpresion.Size = new Size(90, 30);
            btn_CancelarImpresion.TabIndex = 1;
            btn_CancelarImpresion.Text = "CANCELAR";
            btn_CancelarImpresion.UseVisualStyleBackColor = false;
            btn_CancelarImpresion.Click += new EventHandler(btnCancel_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(112, 10);
            label1.Name = "label1";
            label1.Size = new Size(93, 17);
            label1.TabIndex = 1;
            label1.Text = "Cargando...";
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.FromArgb(178, 213, 230);
            progressBar.ForeColor = Color.FromArgb(30, 144, 255);
            progressBar.Location = new Point(15, 38);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(300, 23);
            progressBar.TabIndex = 0;
            progressBar.Value = 50;
            // 
            // MensajeCargarImprimir
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 186);
            Controls.Add(MensajeImprimir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MensajeCargarImprimir";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MensajeCargarImprimir";
            MensajeImprimir.ResumeLayout(false);
            MensajeImprimir.PerformLayout();
            innerPanel.ResumeLayout(false);
            innerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imagen_Impresora).EndInit();
            ResumeLayout(false);

        }


    }

    public static class PanelExtensions
    {
        public static void ApplyRoundedCorners(this Panel panel, int borderRadius, int borderSize, Color borderColor)
        {
            panel.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                Rectangle rect = panel.ClientRectangle;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
                    path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
                    path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
                    path.CloseFigure();

                    panel.Region = new Region(path);

                    using (Pen pen = new Pen(borderColor, borderSize))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.DrawPath(pen, path);
                    }
                }
            };
        }
    }
}
