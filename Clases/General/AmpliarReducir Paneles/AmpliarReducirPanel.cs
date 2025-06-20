#region COMO USARLO
/* LLAMAR DESDE EL FORMULARIO ASI:
 private void btn_TogglePanel_Click(object sender, EventArgs e)
{
    PanelUtils.AlternarPanel(
        panelConNeon: panel_MiPanel,
        panelDetalle: panelDetalle,
        panelExpandido: ref panelEstaExpandido,
        btnAmpliarReducir: btn_TogglePanel,
         imgExpandir: Properties.Resources.dobleFlechaABAJO,
         imgContraer: Properties.Resources.dobleFlechaARRIBA,
        alturaOriginal: 320,
        alturaContraida: 55,
  borderStyleAlExpandir: BorderStyle.None,
        ajustarFormulario: AjustarTamanoFormulario,
 usarAnimacion: true
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
using Ofelia_Sara.Clases.General.Animaciones;

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
            Action ajustarFormulario = null,
            BorderStyle? borderStyleAlExpandir = null,
            bool usarAnimacion = false
        )
        {
            if (panelConNeon == null || panelDetalle == null || btnAmpliarReducir == null)
                return;

            //if (panelExpandido)
            //{
            //    // Contraer
            //    panelConNeon.Height = alturaContraida;
            //    btnAmpliarReducir.Image = imgExpandir;
            //    panelExpandido = false;
            //    panelConNeon.CambiarEstado(true, false);

            //    btnAmpliarReducir.Parent = panelConNeon;
            //    AmpliarReducirPanel.PosicionarBotonDerecha(btnAmpliarReducir); 

            //    foreach (Control control in panelDetalle.Controls)
            //        control.Visible = control == btnAmpliarReducir;

            //    panelDetalle.Visible = false;
            //}
            //else
            //{
            //    // Expandir
            //    panelConNeon.Height = alturaOriginal;
            //    btnAmpliarReducir.Image = imgContraer;
            //    panelExpandido = true;
            //    panelDetalle.Visible = true;

            //    panelConNeon.CambiarEstado(false, false);

            //    if (borderStyleAlExpandir.HasValue)
            //        panelConNeon.BorderStyle = borderStyleAlExpandir.Value;

            //    btnAmpliarReducir.Parent = panelDetalle;
            //    AmpliarReducirPanel.PosicionarBotonDerecha(btnAmpliarReducir); 

            //    foreach (Control control in panelDetalle.Controls)
            //        control.Visible = true;
            //}
            if (panelExpandido)
            {
                // CONTRAER
                panelExpandido = false;
                btnAmpliarReducir.Image = imgExpandir;
                panelConNeon.CambiarEstado(true, false);
                btnAmpliarReducir.Parent = panelConNeon;

                if (usarAnimacion)
                {
                    Animar.CrecimientoY(panelConNeon, panelConNeon.Height, alturaContraida, 300, () =>
                    {
                        panelDetalle.Visible = false;
                        AmpliarReducirPanel.PosicionarBotonDerecha(btnAmpliarReducir);
                    });
                }
                else
                {
                    panelConNeon.Height = alturaContraida;
                    panelDetalle.Visible = false;
                    AmpliarReducirPanel.PosicionarBotonDerecha(btnAmpliarReducir);
                }

                foreach (Control control in panelDetalle.Controls)
                    control.Visible = control == btnAmpliarReducir;
            }
            else
            {
                // EXPANDIR
                panelExpandido = true;
                btnAmpliarReducir.Image = imgContraer;
                panelConNeon.CambiarEstado(false, false);
                panelDetalle.Visible = true;
                btnAmpliarReducir.Parent = panelDetalle;

                if (usarAnimacion)
                {
                    panelConNeon.Height = alturaContraida; // arranca desde contraído
                    Animar.CrecimientoY(panelConNeon, alturaContraida, alturaOriginal, 300, () =>
                    {
                        AmpliarReducirPanel.PosicionarBotonDerecha(btnAmpliarReducir);
                    });
                }
                else
                {
                    panelConNeon.Height = alturaOriginal;
                    AmpliarReducirPanel.PosicionarBotonDerecha(btnAmpliarReducir);
                }

                foreach (Control control in panelDetalle.Controls)
                    control.Visible = true;

                if (borderStyleAlExpandir.HasValue)
                    panelConNeon.BorderStyle = borderStyleAlExpandir.Value;
            }
            ajustarFormulario?.Invoke();
        }




        public static void PosicionarBotonDerecha(Control boton, int paddingDerecho = 10, int offsetY = 1)
        {
            if (boton?.Parent == null) return;

            int x = boton.Parent.Width - boton.Width - paddingDerecho;
            boton.Location = new Point(x, offsetY);
        }

    }
}
