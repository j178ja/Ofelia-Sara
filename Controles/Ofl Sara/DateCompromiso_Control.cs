using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class DateCompromiso_Control : UserControl
    {
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;

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

            SelectFecha_Compromiso.Enter += (s, e) => FocusControl(SelectFecha_Compromiso);
            SelectHora_Compromiso.Enter += (s, e) => FocusControl(SelectHora_Compromiso);

            SelectFecha_Compromiso.Leave += (s, e) => ValidateControl(SelectFecha_Compromiso);
            SelectHora_Compromiso.Leave += (s, e) => ValidateControl(SelectHora_Compromiso);

            this.Paint += OnCustomPaint;
        }

        private void FocusControl(Control control)
        {
            isFocused = true;
            showError = false;
            StartAnimation();
        }

        private void ValidateControl(Control control)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                showError = true;
                isFocused = false;
            }
            else
            {
                showError = false;
                isFocused = false;
            }
            this.Invalidate();
        }

        private void StartAnimation()
        {
            animationProgress = 0;

            if (animationTimer == null)
            {
                animationTimer = new Timer { Interval = 15 };
                animationTimer.Tick += (s, e) =>
                {
                    if (animationProgress < 100)
                    {
                        animationProgress += 5;
                        this.Invalidate();
                    }
                    else
                    {
                        animationTimer.Stop();
                    }
                };
            }

            animationTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e); // causa que el resto de los controles no se visualicen 
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color underlineColor = showError ? errorColor : (isFocused ? focusColor : this.BackColor);
            using (Brush brush = new SolidBrush(underlineColor))
            {
                int lineWidth = 3;
                float progress = animationProgress / 100f;
                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
            }
        }

        private void OnCustomPaint(object sender, PaintEventArgs e)
        {
            this.Invalidate();
        }



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

    }
}
