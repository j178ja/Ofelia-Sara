using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    public class TextBoxConBorde : TextBox
    {
        private bool mostrarBordeError;

        public bool MostrarBordeError
        {
            get { return mostrarBordeError; }
            set
            {
                mostrarBordeError = value;
                Invalidate(); // Forzar redibujado
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mostrarBordeError)
            {
                ControlPaint.DrawBorder(
                    e.Graphics,
                    ClientRectangle,
                    Color.Red,
                    ButtonBorderStyle.Solid);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BorderStyle = BorderStyle.None; // Eliminar el borde predeterminado
        }
    }
}
