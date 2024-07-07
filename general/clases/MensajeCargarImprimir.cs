
//------este codigo funciona, muestra una barra de progreso NO PERSONALISADA (Color)
//------------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------------

//using System;
//using System.Windows.Forms;

//namespace Ofelia_Sara.general.clases
//{
//    public partial class MensajeCargarImprimir : Form
//    {
//        public MensajeCargarImprimir()
//        {
//            InitializeComponent();
//        }

//        private void MensajeCargarImprimir_Load(object sender, EventArgs e)
//        {
//            // Inicializar el ProgressBar
//            progressBar1.Minimum = 0;
//            progressBar1.Maximum = 100;
//            progressBar1.Value = 0;

//            // Iniciar el temporizador
//            timer1.Interval = 40; // Intervalo en milisegundos
//            timer1.Start();
//        }

//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            if (progressBar1.Value < progressBar1.Maximum)
//            {
//                progressBar1.Value += 1;

//                // Cambiar el mensaje después de 2 segundos
//                if (progressBar1.Value == 50) // Suponiendo que el ProgressBar tarda 4 segundos en completarse
//                {
//                    label1.Text = "Preparando archivo para impresión..." ;
//                }
//            }
//            else
//            {
//                timer1.Stop();
//                this.Close(); // Cierra el MessageBox personalizado cuando se completa
//            }
//        }

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.progressBar1 = new System.Windows.Forms.ProgressBar();
//            this.label1 = new System.Windows.Forms.Label();
//            this.timer1 = new System.Windows.Forms.Timer(this.components);
//            this.SuspendLayout();
//            // 
//            // progressBar1
//            // 
//            this.progressBar1.Location = new System.Drawing.Point(12, 12);
//            this.progressBar1.Name = "progressBar1";
//            this.progressBar1.Size = new System.Drawing.Size(260, 23);
//            this.progressBar1.TabIndex = 0;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(12, 38);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(64, 13);
//            this.label1.TabIndex = 1;
//            this.label1.Text = "Enviando Formulario...";
//            // 
//            // timer1
//            // 
//            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
//            // 
//            // MensajeCargarImprimir
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(284, 61);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.progressBar1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Name = "MensajeCargarImprimir";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "MensajeCargarImprimir";
//            this.Load += new System.EventHandler(this.MensajeCargarImprimir_Load);
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private System.ComponentModel.IContainer components = null;
//        private System.Windows.Forms.ProgressBar progressBar1;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Timer timer1;
//    }
//}
//------------------------------------------------------------------------------------------------------------------------------

//------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public partial class MensajeCargarImprimir : Form
    {

        public MensajeCargarImprimir()
        {
            InitializeComponent();

        }

        private void MensajeCargarImprimir_Load(object sender, EventArgs e)
        {
            // Inicializar el ProgressBar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // Iniciar el temporizador
            timer1.Interval = 30; // Intervalo en milisegundos
            timer1.Start();
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
                    this.label1.ForeColor = System.Drawing.Color.FromArgb(0, 154, 174);// color igual al back de los formularios
                }   // se emplea foreColor para color de letra y fromArgb para colo especifico
            }
            else
            {
                timer1.Stop();
                this.Close(); // Cierra el MessageBox personalizado cuando se completa
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new CustomProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enviando Formulario...";
            this.label1.ForeColor = System.Drawing.Color.FromArgb(0, 154, 174);// color igual al back de los formularios
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold); // Cambiar el estilo de la fuente a negrita
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MensajeCargarImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 61);
            this.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);//color igual a panel en los formularios
           // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // le da formato de formulario
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeCargarImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// lo posiciona en el centro
            this.Text = "MensajeCargarImprimir";
            this.Load += new System.EventHandler(this.MensajeCargarImprimir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.ComponentModel.IContainer components = null;
        private CustomProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
