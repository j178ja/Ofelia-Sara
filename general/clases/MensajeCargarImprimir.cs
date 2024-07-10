/*--------este archivo crea un formulario con caracteristicas especificas----
 -------creo que seria mas facil creaun un win form y modificar sus propiedadees y 
----------crear una nueva instancia tras  hacer click en boton imprimir-----*/
//------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;

namespace Ofelia_Sara.general.clases
{
    public partial class MensajeCargarImprimir : Form
    {
        private System.ComponentModel.IContainer components = null; // Declaración de components

        private Panel outerPanel;
        private Panel innerPanel;
        private CustomProgressBar progressBar1;
        private Label label1;
        private Timer timer1;
        private int progressValue;
        private Button btn_CancelarImpresion;
        private Label label3;
        private Label label2;
        private PictureBox iconoEscudo;
        private Button btnCancel;

        public MensajeCargarImprimir()
        {
            InitializeComponent();
        }

         private void MensajeCargarImprimir_Load(object sender, EventArgs e)
        {
            // Verificar que progressBar1 se inicializó correctamente en InitializeComponent()
            if (progressBar1 != null)
            {
                progressBar1.Location = new System.Drawing.Point(15, 38); // Establecer la ubicación de progressBar1
                progressBar1.Maximum = 100; // Establecer el valor máximo de la barra de progreso
                progressBar1.Value = 0; // Inicializar el valor actual de la barra de progreso
                progressBar1.ForeColor = Color.FromArgb(0, 154, 174); // Establecer el color de la barra de progreso

                // Iniciar el temporizador para simular el progreso
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

                // Cambiar el mensaje después de 2 segundos
                if (progressBar1.Value == 50) // Suponiendo que el ProgressBar tarda 4 segundos en completarse
                {
                    label1.Text = "Preparando archivo para impresión...";
                    label1.ForeColor = System.Drawing.Color.LightGray;
                }
            }
            else
            {
                timer1.Stop();
                this.Close(); // Cierra el MessageBox personalizado cuando se completa
            }
        }

        //-----------------------BOTON CANCELAR---------------------------------
        //---DETIENE LA CARGA, MUESTRA MENSAJE DE CANCELACION---

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Detener el temporizador
            timer1.Stop();
            // Mostrar mensaje de cancelación
            MessageBox.Show("Operación Cancelada", "Confirmación Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Cerrar el formulario
            this.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajeCargarImprimir));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.outerPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.iconoEscudo = new System.Windows.Forms.PictureBox();
            this.btn_CancelarImpresion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new CustomProgressBar(); // Aquí se inicializa progressBar1 como CustomProgressBar
            this.outerPanel.SuspendLayout();
            this.innerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoEscudo)).BeginInit();
            this.SuspendLayout();
            // 
            // outerPanel
            // 
            this.outerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.outerPanel.Controls.Add(this.label3);
            this.outerPanel.Controls.Add(this.label2);
            this.outerPanel.Controls.Add(this.innerPanel);
            this.outerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerPanel.Location = new System.Drawing.Point(0, 0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Padding = new System.Windows.Forms.Padding(10, 30, 10, 7);
            this.outerPanel.Size = new System.Drawing.Size(350, 186);
            this.outerPanel.TabIndex = 0;
            this.outerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.outerPanel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Impresión";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ofelia-Sara";
            // 
            // innerPanel
            // 
            this.innerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.innerPanel.Controls.Add(this.iconoEscudo);
            this.innerPanel.Controls.Add(this.btn_CancelarImpresion);
            this.innerPanel.Controls.Add(this.label1);
//            this.innerPanel.Controls.Add(this.progressBar1);
            this.innerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerPanel.Location = new System.Drawing.Point(10, 30);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Padding = new System.Windows.Forms.Padding(10);
            this.innerPanel.Size = new System.Drawing.Size(330, 149);
            this.innerPanel.TabIndex = 0;
            // 
            // iconoEscudo
            // 
            this.iconoEscudo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconoEscudo.BackgroundImage")));
            this.iconoEscudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconoEscudo.Location = new System.Drawing.Point(15, 67);
            this.iconoEscudo.Name = "iconoEscudo";
            this.iconoEscudo.Size = new System.Drawing.Size(100, 70);
            this.iconoEscudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconoEscudo.TabIndex = 2;
            this.iconoEscudo.TabStop = false;
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
            this.btn_CancelarImpresion.Click += new System.EventHandler(this.btnCancel_Click); // Asociar el evento
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
            // progressBar1
            // 
     /*       this.progressBar1.Location = new System.Drawing.Point(15, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 50;*/
            // 
            // MensajeCargarImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 186);
            this.Controls.Add(this.outerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeCargarImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MensajeCargarImprimir";
            this.Load += new System.EventHandler(this.MensajeCargarImprimir_Load);
            this.outerPanel.ResumeLayout(false);
            this.outerPanel.PerformLayout();
            this.innerPanel.ResumeLayout(false);
            this.innerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoEscudo)).EndInit();
            this.ResumeLayout(false);

        }

        private void outerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // -------------Clase personalizada para ProgressBar---------
        //---MODIFICA COLOR DE PROGRESSBAR
        public class CustomProgressBar : ProgressBar
        {
            public CustomProgressBar()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Rectangle rect = this.ClientRectangle;
                Graphics g = e.Graphics;

                ProgressBarRenderer.DrawHorizontalBar(g, rect);
                rect.Inflate(-3, -3);

                if (this.Value > 0)
                {
                    Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round((float)rect.Width * ((float)this.Value / this.Maximum)), rect.Height);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, 154, 174)), clip); // COLOR ESPECIFICO EN RGB
                }
            }
        }
    }
}
