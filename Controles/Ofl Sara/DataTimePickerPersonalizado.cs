using Ofelia_Sara.Controles.Controles.Tooltip;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{

    public partial class TimePickerPersonalizado : UserControl
    {
        private Button Btn_Calendario; // Botón para abrir el formulario de calendario
        private DateTime fechaSeleccionada;

        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;
        internal DateTime SelectedDate;

        public DateTime FechaSeleccionada
        {
            get => fechaSeleccionada;
            set
            {
                fechaSeleccionada = value;
                ActualizarCamposFecha();
            }
        }

        public TimePickerPersonalizado()
        {
            InitializeComponent();

            ToolTipGeneral.ShowToolTip(Btn_Calendario, " Seleccionar fecha.");
            ToolTipGeneral.ShowToolTip(textBox_DIA, " Seleccionar DIA.");
            ToolTipGeneral.ShowToolTip(textBox_MES, " Seleccionar MES.");
            ToolTipGeneral.ShowToolTip(textBox_AÑO, " Seleccionar AÑO.");

            textBox_DIA.Click += (s, e) => MostrarSelectorFecha();
            textBox_MES.Click += (s, e) => MostrarSelectorFecha();
            textBox_AÑO.Click += (s, e) => MostrarSelectorFecha();
            Btn_Calendario.Click += (s, e) => MostrarSelectorFecha();

            textBox_DIA.Leave += (s, e) => RemoveFocus();
            textBox_MES.Leave += (s, e) => RemoveFocus();
            textBox_AÑO.Leave += (s, e) => RemoveFocus();
            Btn_Calendario.Leave += (s, e) => RemoveFocus();

            // Inicializar con la fecha actual
            FechaSeleccionada = DateTime.Now;
        }

        private void MostrarSelectorFecha()
        {
            FocusControl();
            var controlPos = this.PointToScreen(Point.Empty); // Obtiene la posición del control en la pantalla

            using (var selectorFecha = new SelectorFecha(SelectorFecha.TipoSeleccion.Dias))
            {
                selectorFecha.StartPosition = FormStartPosition.Manual;
                selectorFecha.Location = new Point(
                 controlPos.X + (this.Width / 2) - (selectorFecha.Width / 2),
                 controlPos.Y + (this.Height / 2) - (selectorFecha.Height / 2)
             );


                if (selectorFecha.ShowDialog() == DialogResult.OK)
                {
                    FechaSeleccionada = selectorFecha.FechaSeleccionada;
                }
            }
        }

        private void Btn_Calendario_Click(object sender, EventArgs e)
        {
            FocusControl();

            var controlPos = this.PointToScreen(Point.Empty); // Obtiene la posición del control en la pantalla
            using (var calendarForm = new CALENDARIO())
            {
                calendarForm.StartPosition = FormStartPosition.Manual;
                calendarForm.Location = new Point(
                 controlPos.X + (this.Width / 2) - (calendarForm.Width / 2),
                 controlPos.Y + (this.Height / 2) - (calendarForm.Height / 2)
                 );
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = calendarForm.SelectedDate;

                }
            }
        }
        private void RemoveFocus()
        {
            isFocused = false;
            showError = false;
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
            base.OnPaint(e);
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

        private void ActualizarCamposFecha()
        {
            textBox_DIA.Text = fechaSeleccionada.Day.ToString("00");

            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                       "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            textBox_MES.Text = meses[fechaSeleccionada.Month - 1].ToUpper();

            textBox_AÑO.Text = fechaSeleccionada.Year.ToString();
        }

        private void FocusControl()
        {
            isFocused = true;
            showError = false;
            StartAnimation();
        }
    }
}
