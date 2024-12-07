using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.util;


    public partial class comboBoxIMG : UserControl
    {
        private Panel containerPanel; // Contenedor general
        private ComboBox comboBox; // ComboBox principal
        private PictureBox flechaPersonalizada; // Imagen de flecha personalizada
        private Timer animTimer; // Timer para animaciones
        private int animProgress = 0; // Progreso de la animación (0-100)
        private bool isAnimating = false; // Estado de animación activa
        private bool showError = false; // Indicador para mostrar el borde inferior rojo

        public comboBoxIMG()
        {
            // Configurar el panel contenedor
            containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            Controls.Add(containerPanel);

            // Configurar ComboBox
       
             comboBox = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Margin = new Padding(0, 6, SystemInformation.VerticalScrollBarWidth, 0) // Márgenes opcionales
            };
        containerPanel.Controls.Add(comboBox);

        flechaPersonalizada = new PictureBox
        {
            SizeMode = PictureBoxSizeMode.StretchImage,
            Dock = DockStyle.Right,
            Width = SystemInformation.VerticalScrollBarWidth,
            Height = comboBox.Height, // Ajustar al alto del ComboBox
           // Image = Properties.Resources.FlechaAbajo // Asignar la imagen desde recursos
        };

        // Manejar cambio de imagen en eventos del ComboBox
        comboBox.DropDown += (s, e) =>
        {
        //    flechaPersonalizada.Image = Properties.Resources.FlechaArriba; // Cambiar imagen al desplegar
        };

        comboBox.DropDownClosed += (s, e) =>
        {
       //     flechaPersonalizada.Image = Properties.Resources.FlechaAbajo; // Restaurar imagen al cerrar
        };


        containerPanel.Controls.Add(flechaPersonalizada);

            // Configurar Timer para animación
            animTimer = new Timer { Interval = 15 };
            animTimer.Tick += (s, e) => AnimarBorde();

            // Eventos de interacción
            comboBox.GotFocus += (s, e) => IniciarAnimacion(Color.Blue);
            comboBox.LostFocus += (s, e) => TerminarAnimacion();
            flechaPersonalizada.Click += (s, e) => comboBox.DroppedDown = true;

            // Estilo inicial del borde
            this.BorderColor = Color.Blue;
        }

        private void IniciarAnimacion(Color borderColor)
        {
            if (!isAnimating)
            {
                isAnimating = true;
                animProgress = 0;
                this.BorderColor = borderColor;
                animTimer.Start();
            }
        }

        private void TerminarAnimacion()
        {
            isAnimating = false;
            animTimer.Stop();
            animProgress = 0;
            this.Invalidate();
        }

        private void AnimarBorde()
        {
            if (animProgress < 100)
            {
                animProgress += 2;
                this.Invalidate();
            }
            else
            {
                animTimer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Dibujar borde animado superior
                if (isAnimating || animProgress > 0)
                {
                    int borderHeight = 3;
                    float progressRatio = animProgress / 100f;

                    using (Brush brush = new SolidBrush(this.BorderColor))
                    {
                        int startX = (int)(this.Width / 2 - (this.Width / 2) * progressRatio);
                        int endX = (int)(this.Width / 2 + (this.Width / 2) * progressRatio);
                        g.FillRectangle(brush, startX, 0, endX - startX, borderHeight);
                    }
                }

                // Dibujar borde inferior rojo en caso de error
                if (showError)
                {
                    using (Brush brush = new SolidBrush(Color.Red))
                    {
                        g.FillRectangle(brush, 0, this.Height - 3, this.Width, 3);
                    }
                }
            }
        }

        public void MostrarError()
        {
            showError = true;
            this.Invalidate();
        }

        public void OcultarError()
        {
            showError = false;
            this.Invalidate();
        }

        // Propiedades del ComboBox
        public ComboBox.ObjectCollection Items => comboBox.Items;
        public int SelectedIndex
        {
            get => comboBox.SelectedIndex;
            set => comboBox.SelectedIndex = value;
        }
        public object SelectedItem
        {
            get => comboBox.SelectedItem;
            set => comboBox.SelectedItem = value;
        }
        public Color BorderColor { get; set; } = Color.Blue;

    public ComboBoxStyle DropDownStyle
    {
        get => comboBox.DropDownStyle;
        set => comboBox.DropDownStyle = value;
    }

    public string SelectedText
    {
        get => comboBox.SelectedText;
        set => comboBox.SelectedText = value;
    }

}
