using Microsoft.Office.Interop.Word;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Formularios.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class SelectorFecha : Form
    {
        public enum TipoSeleccion
        {
            Dias,
            Meses,
            Años
        }

        public DateTime FechaSeleccionada { get; private set; }
        public string SeleccionTexto { get; set; } = "";
        public TipoSeleccion TipoActual { get; set; }

        private bool mostrarSubrayado = false;
        private int lineWidth = 0;
        private bool isAnimating = false;
        private Timer animationTimer;
        private bool mostrarBorde = false;

        public SelectorFecha(TipoSeleccion tipoSeleccion)
        {
            InitializeComponent();
            TipoActual = tipoSeleccion;
            ConfigurarSelector();
            CentrarLabelHorizontal();
            InicializarTimer();
        }

        private void ConfigurarSelector()
        {
            switch (TipoActual)
            {
                case TipoSeleccion.Dias:
                    Text = "SELECCIONE DÍA";
                    break;
                case TipoSeleccion.Meses:
                    Text = "SELECCIONE MES";
                    break;
                case TipoSeleccion.Años:
                    Text = "SELECCIONE AÑO";
                    break;
            }
        }

        private void SeleccionarFecha(int valor, bool isMes = false, bool isAño = false)
        {
            if (isMes)
            {
                FechaSeleccionada = new DateTime(DateTime.Now.Year, valor, 1);
            }
            else if (isAño)
            {
                FechaSeleccionada = new DateTime(valor, DateTime.Now.Month, 1);
            }
            else
            {
                FechaSeleccionada = new DateTime(DateTime.Now.Year, DateTime.Now.Month, valor);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Dias_Load(object sender, EventArgs e)
        {
            ConfigurarSelector();
            RedondearBordes.Aplicar(label_TextoMesAño, 20);
            ActualizarMes();
            label_TextoMesAño.Invalidate();
        }

        private void CentrarLabelHorizontal()
        {
            label_TextoMesAño.Location = new System.Drawing.Point(
                (panel_Selector.Width - label_TextoMesAño.Width) / 2,
                label_TextoMesAño.Location.Y
            );
        }
        /// <summary>
        /// METODO PARA MOSTRAR LISTADO DE MESES
        /// </summary>

        private int mesActual = DateTime.Now.Month; // Mes actual (1-12)
        private readonly string[] meses =
        {
    "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO",
    "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"
};

        private void ActualizarMes()
        {
            label_TextoMesAño.Text = meses[mesActual - 1]; // Los meses están basados en índices (0-11)
            CentrarLabelHorizontal(); // Asegura que el texto esté centrado
            label_TextoMesAño.Invalidate();
        }

        private void Btn_Anterior_Click(object sender, EventArgs e)
        {
            mesActual--;
            if (mesActual < 1)
            {
                mesActual = 12; // Volver a Diciembre si se pasa antes de Enero
            }
            ActualizarMes();
        }

        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            mesActual++;
            if (mesActual > 12)
            {
                mesActual = 1; // Volver a Enero si se pasa después de Diciembre
            }
            ActualizarMes();
        }

        //--------------------------------------------------------

        private void InicializarTimer()
        {
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += (s, args) =>
            {
                if (lineWidth < label_TextoMesAño.Width / 2)
                {
                    lineWidth += 2;
                    label_TextoMesAño.Invalidate();
                }
                else
                {
                    animationTimer.Stop();
                    isAnimating = false;
                }
            };
        }

        private void Label_TextoMesAño_Click(object sender, EventArgs e)
        {
            
         
        }

        private void Label_TextoMesAño_MouseHover(object sender, EventArgs e)
        {
            RedondearBordes.Aplicar(label_TextoMesAño, 20);
            label_TextoMesAño.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            label_TextoMesAño.ForeColor = System.Drawing.Color.Black;
            mostrarSubrayado = true;
            isAnimating = true;
            lineWidth = 0;
            animationTimer.Start();
        }

        private void Label_TextoMesAño_MouseLeave(object sender, EventArgs e)
        {
            label_TextoMesAño.BackColor = Color.FromArgb(131, 175, 195);
            label_TextoMesAño.ForeColor = System.Drawing.Color.White;
            RedondearBordes.Aplicar(label_TextoMesAño, 16);
            mostrarBorde = false;
            mostrarSubrayado = false;
            label_TextoMesAño.Invalidate();
        }

        private void Label_TextoMesAño_Paint(object sender, PaintEventArgs e)
        {
            if (isAnimating)
            {
                using (Pen pen = new Pen(SystemColors.Highlight, 3))
                {
                    // Calcular el ancho exacto del texto visible
                    SizeF textoSize = e.Graphics.MeasureString(label_TextoMesAño.Text, label_TextoMesAño.Font);

                    // Redondear el ancho del texto al valor entero más cercano
                    int textoAncho = (int)Math.Round(textoSize.Width);

                    // Calcular el ancho actual de la animación (limitado al ancho del texto)
                    int subrayadoAncho = Math.Min(lineWidth, textoAncho);

                    // Calcular las posiciones inicial y final para el subrayado animado
                    int startX = (label_TextoMesAño.Width - subrayadoAncho -45) / 2;
                    int endX = startX + subrayadoAncho+45;

                    // Posición vertical del subrayado
                    int y = label_TextoMesAño.Height - 3;

                    // Dibujar la línea de subrayado animada
                    e.Graphics.DrawLine(pen, startX, y, endX, y);
                }

            }

            if (mostrarBorde)
            {
              
                using (Pen borderPen = new Pen(Color.Blue, 3))
                {
                    
                    // Crear un GraphicsPath para un borde redondeado
                    int radius = 16; // Radio de las esquinas redondeadas
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(1, 1, label_TextoMesAño.Width-2 , label_TextoMesAño.Height -3);

                    using (GraphicsPath path = CrearRectanguloRedondeado(rect, radius))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Habilitar suavizado
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
                RedondearBordes.Aplicar(label_TextoMesAño, 32);
            }

        }
        private GraphicsPath CrearRectanguloRedondeado(System.Drawing.Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            // Agregar esquinas redondeadas
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Esquina superior izquierda
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Esquina superior derecha
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Esquina inferior derecha
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Esquina inferior izquierda

            path.CloseFigure(); // Cierra el camino para formar un rectángulo completo
            return path;
        }

        private void Label_TextoMesAño_MouseDown(object sender, MouseEventArgs e)
        {

            label_TextoMesAño.BackColor = Color.FromArgb(229, 248, 251);
            label_TextoMesAño.ForeColor = System.Drawing.Color.Blue;

            mostrarSubrayado = false;
            mostrarBorde = true;
            animationTimer.Stop();
            isAnimating = false;
            label_TextoMesAño.Invalidate();
        }

        private void Label_TextoMesAño_MouseUp(object sender, MouseEventArgs e)
        {
            mostrarBorde = false;
            label_TextoMesAño.Invalidate();
        }


    }
}
