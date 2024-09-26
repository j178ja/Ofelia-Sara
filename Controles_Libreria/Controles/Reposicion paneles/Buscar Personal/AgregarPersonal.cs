using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Clases_Libreria.Reposicion_paneles.Buscar_Personal
{

    public class AgregarPersonal
    {
        private const int MaxControlesVisibles = 6;
        private readonly Color colorPar = Color.FromArgb(230, 230, 230); // Gris claro
        private readonly Color colorImpar = Color.FromArgb(200, 200, 200); // Gris medio
        private const int EspacioEntrePaneles = 0;//se solciono mediante anchor top
        private const int AlturaExtraFormulario = 85;
        private const int AlturaFormularioConScroll = 75;
        private const int PaddingInferior = 12;


        // Este método se encarga de agregar el control al panel y ajustar las posiciones
        public void AgregarControlAlPanel(Control nuevoControl, Panel panel, Panel panel_PersonalSeleccionado, Panel panel_ControlesInferiores, Panel panel1, Form formulario)
        {
            PosicionarControl(nuevoControl, panel);
            AsignarColorFondo(nuevoControl, panel.Controls.Count);
            panel.Controls.Add(nuevoControl);

            AjustarAlturaPanelPersonal(panel_PersonalSeleccionado, nuevoControl);
            ReposicionarPanelInferior(panel, panel_PersonalSeleccionado, panel_ControlesInferiores);
            AjustarAlturaPanelPrincipal(panel1, panel_ControlesInferiores, formulario);

            // Ajustar el ancho de los controles según el estado del scroll
            AjustarAnchoControles(panel);
        }


        // Posiciona el nuevo control dentro del panel
        private void PosicionarControl(Control nuevoControl, Panel panel)
        {
            if (panel.Controls.Count > 0)
            {
                Control ultimoControl = panel.Controls[panel.Controls.Count - 1];
                nuevoControl.Top = ultimoControl.Bottom;
            }
            else
            {
                nuevoControl.Top = 0;
            }
        }

        // este metodo hace que no aparesca el scroll horizontal
        private void AjustarAnchoControles(Panel panel)
        {
            // Determinar si el scroll vertical está activo
            bool scrollActivo = panel.VerticalScroll.Visible;

            foreach (Control control in panel.Controls)
            {
                if (scrollActivo)
                {
                    control.Width = panel.ClientSize.Width;
                }
                else
                {
                    control.Width = panel.ClientSize.Width; // Ancho completo si el scroll no está activo
                }
            }
        }


        // Asigna el color de fondo dependiendo de si el índice es par o impar
        private void AsignarColorFondo(Control control, int indice)
        {
            control.BackColor = indice % 2 == 0 ? colorPar : colorImpar;
        }

        // Ajusta la altura del panel que contiene los controles
        private void AjustarAlturaPanelPersonal(Panel panel_PersonalSeleccionado, Control ultimoControl)
        {
            panel_PersonalSeleccionado.Height = ultimoControl.Bottom;
        }

        // Reposiciona el panel inferior y ajusta el scroll si es necesario
        private void ReposicionarPanelInferior(Panel panel, Panel panel_PersonalSeleccionado, Panel panel_ControlesInferiores)
        {
             // Ajustar la altura y el scroll del panel basado en la cantidad de controles
            if (panel.Controls.Count > MaxControlesVisibles)
            {
                panel.Height = panel.Controls[MaxControlesVisibles - 1].Bottom;
                panel.AutoScroll = true; // Habilitar scroll vertical
            }
            else
            {
                panel.Height = panel.Controls[panel.Controls.Count - 1].Bottom;
                panel.AutoScroll = false; // Deshabilitar scroll si hay menos controles
            }

            // Asegurarse de que solo se habilite el scroll vertical
            panel.VerticalScroll.Visible = panel.AutoScroll; // Muestra el scroll vertical solo si está habilitado

          
            // Reposicionar el panel inferior
            panel_ControlesInferiores.Top = panel_PersonalSeleccionado.Bottom + EspacioEntrePaneles+10;
           
        }


        // Ajusta la altura del panel principal y del formulario
        public void AjustarAlturaPanelPrincipal(Panel panel1, Panel panel_ControlesInferiores, Form formulario)
        {
            panel1.Height = panel_ControlesInferiores.Bottom + PaddingInferior;
            formulario.Height = panel1.Bottom + (panel1.AutoScroll ? AlturaFormularioConScroll : AlturaExtraFormulario);
        }

        //----------------------------------------------------------------------------------
        public void ReposicionarControles(Panel panel, Control controlEliminado)
        {
            // Altura del control que fue eliminado
            int alturaEliminado = controlEliminado.Height;
            bool encontrado = false; // Variable para saber si se encontró el control eliminado

            // Recorremos los controles en el panel
            foreach (Control control in panel.Controls)
            {
                // Comprobar si hemos encontrado el control eliminado
                if (encontrado)
                {
                    // Reposicionar el control, ajustando su posición hacia arriba
                    control.Top -= alturaEliminado;
                }

                // Si el control actual es el que fue eliminado, marcamos que se ha encontrado
                if (control == controlEliminado)
                {
                    encontrado = true; // Marcamos que el control ha sido encontrado
                }
            }
        }
        //---------------------------------------------------------------------------------------
    }
}
