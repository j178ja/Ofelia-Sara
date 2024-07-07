
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
        private Button btnCancel;

        public MensajeCargarImprimir()
        {
            InitializeComponent();
        }

        private void MensajeCargarImprimir_Load(object sender, EventArgs e)
        {
            progressValue = 0;
            timer1.Start();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (progressValue < progressBar1.Maximum)
        //    {
        //        progressValue++;
        //        progressBar1.Value = progressValue;

        //        if (progressValue == 50)
        //        {
        //            label1.Text = "Preparando archivo para impresión...";
        //            label1.ForeColor = System.Drawing.Color.FromArgb(0, 154, 174); // Cambia el color del texto si lo deseas
        //        }
        //    }
        //    else
        //    {
        //        timer1.Stop();
        //        this.Close();
        //    }
        //}
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

            private void btnCancel_Click(object sender, EventArgs e)
        {
            //using (MessageForm messageForm = new MessageForm("Operación cancelada"))
          //  using (Ofelia_Sara.general.clases.MessageForm messageForm = new Ofelia_Sara.general.clases.MessageForm("Operación cancelada"))
            {
                // messageForm.ShowDialog(); // Mostrar el formulario de mensaje modalmente
                MessageBox.Show("Operacion Cancelada", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Cerrar el formulario actual después de mostrar el mensaje
            timer1.Stop();//detener timer
                          //mostrar mensaje de cancelacion
            this.Close();// cerrar ventana
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container(); // Inicialización de components

            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.outerPanel = new System.Windows.Forms.Panel();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new CustomProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.outerPanel.SuspendLayout();
            this.innerPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // outerPanel
            // 
            this.outerPanel.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            this.outerPanel.Controls.Add(this.innerPanel);
            this.outerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerPanel.Location = new System.Drawing.Point(0, 0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Padding = new System.Windows.Forms.Padding(10, 30, 10, 7);
            this.outerPanel.Size = new System.Drawing.Size(350, 200);
            this.outerPanel.TabIndex = 0;
            // 
            // innerPanel
            // 
            this.innerPanel.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            this.innerPanel.Controls.Add(this.label1);
            this.innerPanel.Controls.Add(this.progressBar1);
            this.innerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerPanel.Location = new System.Drawing.Point(10, 30); // Padding superior del outerPanel
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Padding = new System.Windows.Forms.Padding(10); // Padding interior del innerPanel
            this.innerPanel.Size = new System.Drawing.Size(330, 163);
            this.innerPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cargando...";
            this.label1.ForeColor = System.Drawing.Color.White; // Color del texto del label
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold); // Estilo de la fuente negrita
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = System.Drawing.Color.Red; 
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // MensajeCargarImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 200);
            this.Controls.Add(this.outerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeCargarImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MensajeCargarImprimir";
            this.outerPanel.ResumeLayout(false);
            this.innerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            // Inicializar el ProgressBar
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 50;
        }
    }
}
