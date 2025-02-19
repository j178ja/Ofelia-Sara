using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    /// <summary>
    /// selector calendario provisorio hasta que logre ajustar perfectamente todo dentro de CALENDARIO
    /// </summary>
    public partial class SelectorCalendario : Form
    {
        public SelectorCalendario()
        {
            InitializeComponent();
        }

        private void SelectorCalendario_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in DistribuidorMeses.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.MouseEnter += Mes_MouseEnter;
                    lbl.MouseLeave += Mes_MouseLeave; // ← CORREGIDO
                    lbl.Cursor = Cursors.Hand;
                }
            }
        }

        /// <summary>
        /// Modificar apariencia al entrar cursor
        /// </summary>
        private void Mes_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.FromArgb(0, 154, 174);
                lbl.ForeColor = Color.White;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                lbl.Invalidate(); // ← FORZAR REPINTADO
            }
        }

        /// <summary>
        /// Recomponer apariencia al salir cursor
        /// </summary>
        private void Mes_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.FromArgb(178, 213, 230);
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.Invalidate(); // ← FORZAR REPINTADO
            }
        }
    }
}