using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MECANOGRAFIA.Clases
{
    public class ManejadorTecladoTexto
    {
        private RichTextBox richTextBox;
        private Label labelTeclaPresionada;
        private Dictionary<char, Panel> teclaPanelMap;
        private int posicionActual;

        public ManejadorTecladoTexto(RichTextBox richTextBox, Label labelTeclaPresionada, Dictionary<char, Panel> teclaPanelMap)
        {
            this.richTextBox = richTextBox;
            this.labelTeclaPresionada = labelTeclaPresionada;
            this.teclaPanelMap = teclaPanelMap;
            this.posicionActual = 0;
        }

        public void InicializarTexto()
        {
            posicionActual = 0;

            if (richTextBox.Text.Length > 0)
            {
                ResaltarCaracterActual();
            }
        }

        public void ProcesarEntrada(char teclaPresionada)
        {
            if (posicionActual >= richTextBox.Text.Length)
                return;

            char caracterActual = richTextBox.Text[posicionActual];

            labelTeclaPresionada.Text = $"Tecla presionada: {teclaPresionada}";

            if (teclaPresionada == caracterActual)
            {
                // Correcto
                CambiarColorYEstilo(posicionActual, Color.Green, FontStyle.Bold);
                CambiarColorPanel(caracterActual, Color.Green);
                posicionActual++;

                if (posicionActual < richTextBox.Text.Length)
                {
                    ResaltarCaracterActual();
                }
            }
            else
            {
                // Incorrecto
                CambiarColorYEstilo(posicionActual, Color.Red, FontStyle.Bold);

                Timer timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (s, e) =>
                {
                    CambiarColorYEstilo(posicionActual, Color.Blue, FontStyle.Bold);
                    CambiarColorPanel(caracterActual, Color.Blue);
                    timer.Stop();
                };
                timer.Start();
            }
        }

        private void ResaltarCaracterActual()
        {
            char caracterActual = richTextBox.Text[posicionActual];
            CambiarColorYEstilo(posicionActual, Color.Blue, FontStyle.Bold);
            CambiarColorPanel(caracterActual, Color.Blue);
        }

        private void CambiarColorYEstilo(int posicion, Color color, FontStyle estilo)
        {
            richTextBox.Select(posicion, 1);
            richTextBox.SelectionColor = color;
            richTextBox.SelectionFont = new Font(richTextBox.Font, estilo);
            richTextBox.DeselectAll();
        }

        // Cambiar el color del panel asociado al carácter actual
        private void CambiarColorPanel(char caracterActual, Color color)
        {
            if (teclaPanelMap.ContainsKey(caracterActual))
            {
                Panel panel = teclaPanelMap[caracterActual];
                panel.BackColor = color;
            }
        }
    }
}
