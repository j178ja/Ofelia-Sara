﻿
//---------CREA UNA BARRA PERSONALIZADA----------------------------

using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public class CustomProgressBar : ProgressBar
    {
        private System.ComponentModel.IContainer components;

        public CustomProgressBar()
        {
            // Permitir estilos de propietario
            this.SetStyle(ControlStyles.UserPaint, true);// Esto permite que el control maneje su propio pintado en lugar de dejar que Windows lo haga.
                                                         // Establecer características predeterminadas
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.FromArgb(178, 213, 230); // Color de fondo igual a panel1
            this.ForeColor = Color.FromArgb(30, 144, 255); // Color de dodgeblue
        }

        protected override void OnPaint(PaintEventArgs e) //Este método se llama cada vez que el control necesita repintarse.
        {
            Rectangle rec = e.ClipRectangle; //Obtiene el rectángulo que representa el área del control.

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle); //Obtiene el objeto Graphics que se utiliza para dibujar en el control.
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(Brushes.DarkCyan, 2, 2, rec.Width, rec.Height);
            //Por ahora elcolor se mantiene a posteriori habra que emplearmismo tono para todos los progressBar
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}