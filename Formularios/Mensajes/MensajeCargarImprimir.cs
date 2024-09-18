/*--------este archivo crea un formulario con caracteristicas especificas----
 -------creo que seria mas facil creaun un win form y modificar sus propiedadees y 
----------crear una nueva instancia tras  hacer click en boton imprimir-----*/
//------------------------------------------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public partial class MensajeCargarImprimir : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Panel outerPanel;
        private Panel innerPanel;
        private CustomProgressBar progressBar1;
        private Label label1;
        private Timer timer1;
        private Button btn_CancelarImpresion;
        private Label label3;
        private Label label2;
        private PictureBox iconoEscudo;

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
            if (progressBar1 != null)
            {
                progressBar1.Location = new Point(15, 38);
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Error: progressBar1 no se ha inicializado correctamente.", "Error de inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1;

                if (progressBar1.Value == 50)
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MensajeCargarImprimir));
            this.timer1 = new Timer(this.components);
            this.outerPanel = new Panel();
            this.label3 = new Label();
            this.label2 = new Label();
            this.innerPanel = new Panel();
            this.iconoEscudo = new PictureBox();
            this.btn_CancelarImpresion = new Button();
            this.label1 = new Label();
            this.progressBar1 = new CustomProgressBar();
            this.outerPanel.SuspendLayout();
            this.innerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoEscudo)).BeginInit();
            this.SuspendLayout();

            // outerPanel
            this.outerPanel.BackColor = Color.FromArgb(0, 154, 174);
            this.outerPanel.Controls.Add(this.label3);
            this.outerPanel.Controls.Add(this.label2);
            this.outerPanel.Controls.Add(this.innerPanel);
            this.outerPanel.Dock = DockStyle.Fill;
            this.outerPanel.Location = new Point(0, 0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Padding = new Padding(10, 30, 10, 7);
            this.outerPanel.Size = new Size(350, 186);
            this.outerPanel.TabIndex = 0;

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(75, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Impresión";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(262, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(71, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ofelia-Sara";

            // innerPanel
            this.innerPanel.BackColor = Color.FromArgb(178, 213, 230);
            this.innerPanel.Controls.Add(this.iconoEscudo);
            this.innerPanel.Controls.Add(this.btn_CancelarImpresion);
            this.innerPanel.Controls.Add(this.label1);
            this.innerPanel.Controls.Add(this.progressBar1);
            this.innerPanel.Dock = DockStyle.Fill;
            this.innerPanel.Location = new Point(10, 30);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Padding = new Padding(10);
            this.innerPanel.Size = new Size(330, 149);
            this.innerPanel.TabIndex = 0;

            // iconoEscudo
            this.iconoEscudo.BackgroundImage = ((Image)(resources.GetObject("iconoEscudo.BackgroundImage")));
            this.iconoEscudo.BackgroundImageLayout = ImageLayout.Center;
            this.iconoEscudo.Location = new Point(15, 67);
            this.iconoEscudo.Name = "iconoEscudo";
            this.iconoEscudo.Size = new Size(100, 70);
            this.iconoEscudo.SizeMode = PictureBoxSizeMode.AutoSize;
            this.iconoEscudo.TabIndex = 2;
            this.iconoEscudo.TabStop = false;

            // btn_CancelarImpresion
            this.btn_CancelarImpresion.BackColor = Color.FromArgb(234, 40, 0);
            this.btn_CancelarImpresion.Cursor = Cursors.Hand;
            this.btn_CancelarImpresion.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btn_CancelarImpresion.ForeColor = SystemColors.ControlLightLight;
            this.btn_CancelarImpresion.Location = new Point(213, 82);
            this.btn_CancelarImpresion.Name = "btn_CancelarImpresion";
            this.btn_CancelarImpresion.Size = new Size(90, 30);
            this.btn_CancelarImpresion.TabIndex = 1;
            this.btn_CancelarImpresion.Text = "CANCELAR";
            this.btn_CancelarImpresion.UseVisualStyleBackColor = false;
            this.btn_CancelarImpresion.Click += new EventHandler(this.btnCancel_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(112, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(93, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cargando...";

            // progressBar1
            this.progressBar1.Location = new Point(15, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(300, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 50;

            // MensajeCargarImprimir
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(350, 186);
            this.Controls.Add(this.outerPanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MensajeCargarImprimir";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "MensajeCargarImprimir";
            this.outerPanel.ResumeLayout(false);
            this.outerPanel.PerformLayout();
            this.innerPanel.ResumeLayout(false);
            this.innerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoEscudo)).EndInit();
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
