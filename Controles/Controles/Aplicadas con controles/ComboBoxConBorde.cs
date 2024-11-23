using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    public class ComboBoxConBorde : ComboBox
    {
        private bool mostrarBordeError;

        // Propiedad para mostrar el borde de error
        public bool MostrarBordeError
        {
            get { return mostrarBordeError; }
            set
            {
                mostrarBordeError = value;
                Invalidate();  // Vuelve a dibujar el control cuando cambia el borde
            }
        }

        // Sobrescribir el método OnPaint para dibujar el borde
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mostrarBordeError)
            {
                // Dibujar un borde rojo alrededor del ComboBox
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                }
            }
        }
    }
}