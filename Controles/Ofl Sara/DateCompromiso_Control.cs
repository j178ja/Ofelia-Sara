using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.General.Mensajes;

using Microsoft.Office.Interop.Word;

namespace Ofelia_Sara.Controles.Ofl_Sara
{


    public partial class DateCompromiso_Control : UserControl
    {
        public DateCompromiso_Control()
        {
            InitializeComponent();

            SelectFecha_Compromiso.Click += (sender, e) =>
            {
                using (var calendarForm = new CALENDARIO())
                {
                    if (calendarForm.ShowDialog() == DialogResult.OK)
                    {
                        DateTime selectedDate = calendarForm.SelectedDate;
                    }
                }
            };
            SelectHora_Compromiso.Paint += Select_Paint;
            SelectFecha_Compromiso.Paint += Select_Paint;

        }

        //--------------------------------------------------------


        private void SelectedHora_Compromiso_Validating(object sender, CancelEventArgs e)
        {
            // Extrae la parte de hora y minutos del texto
            string[] partes = SelectHora_Compromiso.Text.Split(':');
            if (partes.Length == 2)
            {
                if (int.TryParse(partes[0], out int hora) && int.TryParse(partes[1], out int minutos))
                {
                    if (hora >= 0 && hora <= 23 && minutos >= 0 && minutos <= 59)
                    {
                        // Entrada válida, permite que el control pierda el foco
                        e.Cancel = false;
                    }
                    else
                    {
                        // Muestra un mensaje si los valores de hora o minutos están fuera de rango
                        MensajeGeneral.Mostrar("Por favor, ingrese una hora válida en el rango de 00:00 a 23:59.",
                                        MensajeGeneral.TipoMensaje.Advertencia);

                        // Retoma el foco en el control
                        e.Cancel = true;
                        SelectHora_Compromiso.Focus();
                    }
                }
                else
                {
                    // Muestra un mensaje si no se pueden convertir los valores
                    MensajeGeneral.Mostrar("Por favor, ingrese una hora válida en el formato HH:mm.",
                                    MensajeGeneral.TipoMensaje.Advertencia);

                    e.Cancel = true;
                    SelectHora_Compromiso.Focus();
                }
            }
        }
        //------------------------------------------------
        //-----------------------------------------------------------------------------------

        // Bandera para activar o desactivar el subrayado personalizado
        private bool mostrarSubrayado = false;
        //para hacer que se extienda 
        private int lineWidth = 0;
        private bool isAnimating = false;
        private Timer animationTimer;

        private void Select_Focus(object sender, EventArgs e)
        {
            if (sender == SelectHora_Compromiso)
            {
                ConfigurarAnimacion(SelectHora_Compromiso);
            }
            else if (sender == SelectFecha_Compromiso)
            {
                ConfigurarAnimacion(SelectFecha_Compromiso);
            }
            else
            {
                isAnimating = false;
                lineWidth = 0;
                animationTimer?.Stop();
                SelectHora_Compromiso.Invalidate();
            }
        }
        //-------------------------------------------
        private void ConfigurarAnimacion(Control control)
        {
            control.Focus();
            isAnimating = true;
            lineWidth = 0;

            if (animationTimer == null)
            {
                animationTimer = new Timer();
                animationTimer.Interval = 15; // Intervalo de animación
                animationTimer.Tick += (s, args) =>
                {
                    if (lineWidth < control.Width / 2)
                    {
                        lineWidth += 2; // Incremento gradual
                        control.Invalidate(); // Redibuja el control
                    }
                    else
                    {
                        animationTimer.Stop(); // Detiene la animación
                    }
                };
            }
            animationTimer.Start(); // Inicia la animación
        }

        private void Select_Paint(object sender, PaintEventArgs e)
        {
            if (isAnimating)
            {
                // Define el color y grosor de la línea
                using (Pen pen = new Pen(SystemColors.Highlight, 3))
                {
                    // Centro del Label
                    int centerX = SelectHora_Compromiso.Width / 2;
                    int y = SelectHora_Compromiso.Font.Height; // Posición 3 píxeles debajo del texto

                    // Dibuja la línea desde el centro hacia los extremos
                    e.Graphics.DrawLine(pen, centerX - lineWidth, y, centerX + lineWidth, y);
                }
            }
        }

        private void SelectFecha_Compromiso_Load(object sender, EventArgs e)
        {

        }

        private void SelectHora_Compromiso_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        //------------------------------------------------------------


    }
}
