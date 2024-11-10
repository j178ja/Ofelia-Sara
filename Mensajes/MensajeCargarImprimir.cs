/*--------este archivo crea un formulario con caracteristicas especificas----
 -------creo que seria mas facil creaun un win form y modificar sus propiedadees y 
----------crear una nueva instancia tras  hacer click en boton imprimir-----*/
//------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public partial class MensajeCargarImprimir : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Panel MensajeImprimir;
        private Panel innerPanel;
        private CustomProgressBar progressBar;
        private Label label1;
        private Timer timer1;
        private Button btn_CancelarImpresion;
        private Label label_Impresion;
        private Label label_OfeliaSara;
        private PictureBox imagen_Impresora;

        public MensajeCargarImprimir()
        {
            InitializeComponent();
            this.timer1.Interval = 100;

            // Aplicar bordes redondeados al innerPanel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            innerPanel.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.Load += new EventHandler(this.MensajeCargarImprimir_Load);
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
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Operación Cancelada", "Confirmación Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajeCargarImprimir));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MensajeImprimir = new System.Windows.Forms.Panel();
            this.label_Impresion = new System.Windows.Forms.Label();
            this.label_OfeliaSara = new System.Windows.Forms.Label();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.imagen_Impresora = new System.Windows.Forms.PictureBox();
            this.btn_CancelarImpresion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new Ofelia_Sara.general.clases.CustomProgressBar();
            this.MensajeImprimir.SuspendLayout();
            this.innerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagen_Impresora)).BeginInit();
            this.SuspendLayout();
            // 
            // MensajeImprimir
            // 
            this.MensajeImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.MensajeImprimir.Controls.Add(this.label_Impresion);
            this.MensajeImprimir.Controls.Add(this.label_OfeliaSara);
            this.MensajeImprimir.Controls.Add(this.innerPanel);
            this.MensajeImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MensajeImprimir.Location = new System.Drawing.Point(0, 0);
            this.MensajeImprimir.Name = "MensajeImprimir";
            this.MensajeImprimir.Padding = new System.Windows.Forms.Padding(10, 30, 10, 7);
            this.MensajeImprimir.Size = new System.Drawing.Size(350, 186);
            this.MensajeImprimir.TabIndex = 0;
            // 
            // label_Impresion
            // 
            this.label_Impresion.AutoSize = true;
            this.label_Impresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Impresion.Location = new System.Drawing.Point(22, 9);
            this.label_Impresion.Name = "label_Impresion";
            this.label_Impresion.Size = new System.Drawing.Size(75, 16);
            this.label_Impresion.TabIndex = 3;
            this.label_Impresion.Text = "Impresión";
            // 
            // label_OfeliaSara
            // 
            this.label_OfeliaSara.AutoSize = true;
            this.label_OfeliaSara.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OfeliaSara.Location = new System.Drawing.Point(262, 9);
            this.label_OfeliaSara.Name = "label_OfeliaSara";
            this.label_OfeliaSara.Size = new System.Drawing.Size(71, 18);
            this.label_OfeliaSara.TabIndex = 2;
            this.label_OfeliaSara.Text = "Ofelia-Sara";
            // 
            // innerPanel
            // 
            this.innerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.innerPanel.Controls.Add(this.imagen_Impresora);
            this.innerPanel.Controls.Add(this.btn_CancelarImpresion);
            this.innerPanel.Controls.Add(this.label1);
            this.innerPanel.Controls.Add(this.progressBar);
            this.innerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerPanel.Location = new System.Drawing.Point(10, 30);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Padding = new System.Windows.Forms.Padding(10);
            this.innerPanel.Size = new System.Drawing.Size(330, 149);
            this.innerPanel.TabIndex = 0;
            // 
            // imagen_Impresora
            // 
            this.imagen_Impresora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imagen_Impresora.BackgroundImage")));
            this.imagen_Impresora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imagen_Impresora.Location = new System.Drawing.Point(15, 67);
            this.imagen_Impresora.Name = "imagen_Impresora";
            this.imagen_Impresora.Size = new System.Drawing.Size(100, 70);
            this.imagen_Impresora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagen_Impresora.TabIndex = 2;
            this.imagen_Impresora.TabStop = false;
            // 
            // btn_CancelarImpresion
            // 
            this.btn_CancelarImpresion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(40)))), ((int)(((byte)(0)))));
            this.btn_CancelarImpresion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelarImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarImpresion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_CancelarImpresion.Location = new System.Drawing.Point(213, 82);
            this.btn_CancelarImpresion.Name = "btn_CancelarImpresion";
            this.btn_CancelarImpresion.Size = new System.Drawing.Size(90, 30);
            this.btn_CancelarImpresion.TabIndex = 1;
            this.btn_CancelarImpresion.Text = "CANCELAR";
            this.btn_CancelarImpresion.UseVisualStyleBackColor = false;
            this.btn_CancelarImpresion.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cargando...";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.progressBar.Location = new System.Drawing.Point(15, 38);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.Value = 50;
            // 
            // MensajeCargarImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 186);
            this.Controls.Add(this.MensajeImprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeCargarImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MensajeCargarImprimir";
            this.MensajeImprimir.ResumeLayout(false);
            this.MensajeImprimir.PerformLayout();
            this.innerPanel.ResumeLayout(false);
            this.innerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagen_Impresora)).EndInit();
            this.ResumeLayout(false);

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
