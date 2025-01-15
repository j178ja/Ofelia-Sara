using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles.Reposicionar_paneles.InicioCierre
{


    public class ReposicionarSegunAgregado
    {
        private Form formulario;
        private Panel panelIpp;
        private Panel panelCaratula;
        private Panel panelVictima;
        private Panel panelImputado;
        private Panel panelInstruccion;
        private Panel panelControlesInferiores;

        private Dictionary<Panel, int> panelHeightsOriginales;

        public ReposicionarSegunAgregado(Form formulario,
                                          Panel panelIpp,
                                          Panel panelCaratula,
                                          Panel panelVictima,
                                          Panel panelImputado,
                                          Panel panelInstruccion,
                                          Panel panelControlesInferiores)
        {
            this.formulario = formulario;
            this.panelIpp = panelIpp;
            this.panelCaratula = panelCaratula;
            this.panelVictima = panelVictima;
            this.panelImputado = panelImputado;
            this.panelInstruccion = panelInstruccion;
            this.panelControlesInferiores = panelControlesInferiores;

            // Guardar las alturas originales de los paneles
            panelHeightsOriginales = new Dictionary<Panel, int>
        {
            { panelCaratula, panelCaratula.Height },
            { panelVictima, panelVictima.Height },
            { panelImputado, panelImputado.Height },
            { panelInstruccion, panelInstruccion.Height }
        };

            // Suscribir al evento SizeChanged de los paneles expansibles
            panelCaratula.SizeChanged += OnPanelSizeChanged;
            panelVictima.SizeChanged += OnPanelSizeChanged;
            panelImputado.SizeChanged += OnPanelSizeChanged;
            panelInstruccion.SizeChanged += OnPanelSizeChanged;
        }

        private void OnPanelSizeChanged(object sender, EventArgs e)
        {
            ReposicionarPaneles();
        }

        private void ReposicionarPaneles()
        {
            int offsetY = panelIpp.Bottom; // Punto de inicio del siguiente panel

            // Reposicionar panelCaratula
            panelCaratula.Top = offsetY;
            offsetY = panelCaratula.Bottom;

            // Reposicionar panelVictima
            panelVictima.Top = offsetY;
            offsetY = panelVictima.Bottom;

            // Reposicionar panelImputado
            panelImputado.Top = offsetY;
            offsetY = panelImputado.Bottom;

            // Reposicionar panelInstruccion
            panelInstruccion.Top = offsetY;
            offsetY = panelInstruccion.Bottom;

            // Reposicionar panelControlesInferiores (fijo respecto al último panel expansible)
            panelControlesInferiores.Top = offsetY;

            // Si la altura total del formulario supera 800, activar el "cross vertical"
            if (offsetY > 800)
            {
                formulario.AutoScroll = true;
            }
        }


    }
}