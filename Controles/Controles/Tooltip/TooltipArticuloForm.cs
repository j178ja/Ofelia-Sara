using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Ofelia_Sara.Controles.Controles.Tooltip
{
    public class TooltipArticuloForm : Form
    {
        private Label lblCabecera;
        private Label lblContenido;

        public TooltipArticuloForm(string capitulo, int numeroArticulo, string contenido)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            BackColor = Color.FromArgb(178, 213, 230);
            Padding = new Padding(20, 15, 20, 15);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            ShowInTaskbar = false;

            // Contenedor vertical
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                ColumnCount = 1,
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Etiqueta Cabecera (centrado)
            lblCabecera = new Label
            {
                Text = $"Capítulo: {capitulo}\nArtículo: {numeroArticulo}",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
            };

            // Etiqueta Contenido (justificado)
            lblContenido = new Label
            {
                Text = contenido,
                AutoSize = true,
                MaximumSize = new System.Drawing.Size(400, 0),
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.TopLeft,
                Dock = DockStyle.Top,
            };

            layout.Controls.Add(lblCabecera);
            layout.Controls.Add(lblContenido);
            Controls.Add(layout);
        }

        // Borde
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        // Sombra
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }
    }
}
