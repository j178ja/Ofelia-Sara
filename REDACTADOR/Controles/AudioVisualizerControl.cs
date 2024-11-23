using System;
using System.Windows.Forms;

namespace REDACTADOR
{
    public partial class AudioVisualizerControl : UserControl
    {
        public AudioVisualizerControl()
        {
            InitializeComponent();
            CrearBarras(null, EventArgs.Empty); // Llama a CrearBarras al cargar

        }


        private void CrearBarras(object sender, EventArgs e)
        {
            // Limpiamos cualquier barra existente en el FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // Definimos el ancho de cada barra y su margen total
            int anchoBarra = 5;
            int margen = 2;
            int anchoTotalBarra = anchoBarra + (2 * margen);

            // Calculamos cuántas barras caben en el ancho total del FlowLayoutPanel
            int numeroBarras = flowLayoutPanel1.Width / anchoTotalBarra;

            // Creamos las barras dinámicamente hasta llenar el ancho del FlowLayoutPanel
            for (int i = 0; i < numeroBarras; i++)
            {
                var panel = new Panel
                {
                    BackColor = System.Drawing.Color.DeepSkyBlue,
                    Size = new System.Drawing.Size(anchoBarra, 38),
                    Margin = new Padding(margen)
                };
                flowLayoutPanel1.Controls.Add(panel);
            }

            int[] amplitudes = { 10, 20, 30, 25, 15 }; // Ejemplo de valores de altura
            UpdateVisualization(amplitudes);
        }


        public void UpdateVisualization(int[] amplitudes)
        {
            for (int i = 0; i < amplitudes.Length && i < flowLayoutPanel1.Controls.Count; i++)
            {
                var panel = flowLayoutPanel1.Controls[i] as Panel;
                if (panel != null)
                {
                    panel.Height = Math.Max(5, amplitudes[i]); // altura mínima de 5
                }
            }
        }




    }
}
