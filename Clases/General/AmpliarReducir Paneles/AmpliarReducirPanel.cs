#region COMO USARLO
/* LLAMAR DESDE EL FORMULARIO ASI:
 private void btn_TogglePanel_Click(object sender, EventArgs e)
{
    PanelUtils.AlternarPanel(
        panelConNeon: panel_MiPanel,
        panelDetalle: panelDetalle,
        panelExpandido: ref panelEstaExpandido,
        btnAmpliarReducir: btn_TogglePanel,
        imgExpandir: Properties.Resources.FlechaAbajo,
        imgContraer: Properties.Resources.FlechaArriba,
        alturaOriginal: 320,
        alturaContraida: 55,
        ajustarFormulario: AjustarTamanoFormulario
    );
}

 */
#endregion



using Ofelia_Sara.Controles.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.AmpliarReducir_Paneles
{
    public static class AmpliarReducirPanel
    {
        public static void AlternarPanel(
             PanelConBordeNeon panelConNeon,
             Panel panelDetalle,
             ref bool panelExpandido,
             Button btnAmpliarReducir,
             Image imgExpandir,
             Image imgContraer,
             int alturaOriginal,
             int alturaContraida,
             Action ajustarFormulario = null
         )
        {
            if (panelConNeon == null || panelDetalle == null || btnAmpliarReducir == null)
                return;

            if (panelExpandido)
            {
                // Contraer
                panelConNeon.Height = alturaContraida;
                btnAmpliarReducir.Image = imgExpandir;
                panelExpandido = false;
                panelConNeon.CambiarEstado(true, false);

                btnAmpliarReducir.Parent = panelConNeon;
                PosicionarBotonDerecha(btnAmpliarReducir);


                foreach (Control control in panelDetalle.Controls)
                    control.Visible = control == btnAmpliarReducir;

                panelDetalle.Visible = false;
            }
            else
            {
                // Expandir
                panelConNeon.Height = alturaOriginal;
                btnAmpliarReducir.Image = imgContraer;
                panelExpandido = true;
                panelDetalle.Visible = true;
                panelConNeon.CambiarEstado(false, false);

                btnAmpliarReducir.Parent = panelDetalle;
                PosicionarBotonDerecha(btnAmpliarReducir);


                foreach (Control control in panelDetalle.Controls)
                    control.Visible = true;
            }

            // Llamar a método externo opcional para ajustar el formulario
            ajustarFormulario?.Invoke();
        }

        private static void PosicionarBotonDerecha(Control boton, int paddingDerecho = 10, int offsetY = 1)
        {
            if (boton?.Parent == null) return;

            int x = boton.Parent.Width - boton.Width - paddingDerecho;
            boton.Location = new Point(x, offsetY);
        }

    }
}