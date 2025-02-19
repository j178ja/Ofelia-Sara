using DocumentFormat.OpenXml.Drawing;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Formularios.General.Mensajes;
using Spire.Xls.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
  /// <summary>
  /// formulario para mostrar el panel selector de meses
  /// </summary>

    public partial class SelectorCalendario : Form
    {
        #region VARIABLES
        private List<Label> labels;
        private int currentIndex = 0;
        private TextBox textBoxDestino; // para mostrar el texto en el control del datetimepiker
        #endregion

        #region CONSTRUCTOR
        public SelectorCalendario(TextBox textBoxMes)
        {
            InitializeComponent();
            RedondearBordes.Aplicar(panel1, 8);//Redondea los bordes de panel1
            textBoxDestino = textBoxMes; // Guardamos la referencia del TextBox
        }
        #endregion

        #region LOAD
        private void SelectorCalendario_Load(object sender, EventArgs e)
        {
            labels = [];
            int mesActual = DateTime.Now.Month;

            // Crear lista temporal para ordenar por posición
            List<(Label label, int fila, int columna)> listaTemporal = [];

            foreach (Control ctrl in DistribuidorMeses.Controls)
            {
                if (ctrl is Label lbl)
                {
                    // Obtener la posición en el TableLayoutPanel
                    int fila = DistribuidorMeses.GetRow(lbl);
                    int columna = DistribuidorMeses.GetColumn(lbl);

                    // Guardar el Label con su posición
                    listaTemporal.Add((lbl, fila, columna));

                    // Configurar eventos
                    lbl.MouseEnter += Mes_MouseEnter;
                    lbl.MouseLeave += Mes_MouseLeave;
                    lbl.MouseClick += Mes_MouseClick;
                    lbl.Cursor = Cursors.Hand;
                    lbl.TabStop = true;
                    lbl.KeyDown += Label_KeyDown;
                    lbl.Enter += Label_Enter;
                    lbl.Leave += Label_Leave;
                }
            }

            // Ordenar los Labels según su posición en el TableLayoutPanel (por filas y luego por columnas)
            labels = listaTemporal.OrderBy(x => x.fila).ThenBy(x => x.columna).Select(x => x.label).ToList();

            // Establecer el foco en el mes actual cuando el formulario esté completamente cargado
            BeginInvoke(new Action(() =>
            {
                int indiceMesActual = mesActual - 1; // Ajuste porque los meses van de 1 a 12, pero los índices de 0 a 11
                if (indiceMesActual >= 0 && indiceMesActual < labels.Count)
                {
                    labels[indiceMesActual].Focus();
                    currentIndex = indiceMesActual;
                }
            }));
        }



        #endregion

        /// <summary>
        /// Cambiar aspecto al ir moviendo el foco 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Enter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.FromArgb(0, 154, 174); // Cambiar color al recibir el foco
                lbl.ForeColor = Color.White;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                lbl.Invalidate();
            }
        }
        /// <summary>
        /// Cambiar aspecto al ir saliendo del foco 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Leave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.FromArgb(178, 213, 230); // Restaurar color al perder el foco
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.Invalidate();
            }
        }

        /// <summary>
        /// Cambiar aspecto al tener el foco  con el cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mes_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.FromArgb(0, 154, 174);
                lbl.ForeColor = Color.White;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);

                // Remover el foco del label en curso para que no haya dos label resaltado
                this.ActiveControl = null;

                lbl.Invalidate();
            }
        }

        /// <summary>
        /// Cambiar aspecto al perder el foco  con el cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mes_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.FromArgb(178, 213, 230);
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.Invalidate();
            }
        }

        /// <summary>
        /// Cambiar aspecto al seleccionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mes_MouseClick(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                SeleccionarYCerrar(lbl);
            }

        }

        /// <summary>
        /// manejador de desplazamiento con teclas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is Label lbl)
            {
                switch (e.KeyCode)
                {
                    case Keys.Tab:
                    case Keys.Right:
                        MoveFocus(1, 0); // Mover a la derecha
                        break;
                    case Keys.Left:
                        MoveFocus(-1, 0); // Mover a la izquierda
                        break;
                    case Keys.Down:
                        MoveFocus(0, 1); // Mover hacia abajo
                        break;
                    case Keys.Up:
                        MoveFocus(0, -1); // Mover hacia arriba
                        break;
                    case Keys.Enter:
                       
                            SeleccionarYCerrar(lbl);//llama al metodo para cambiar back y cerrar con delay
                   
                        lbl.Invalidate();
                        break;
                }
            }
        }

        /// <summary>
        /// desplazamiento de foco
        /// </summary>
        /// <param name="direction"></param>
        private void MoveFocus(int columnOffset, int rowOffset)
        {
            int totalColumns = 3; // Número de columnas en el TableLayoutPanel
            int totalRows = 4;    // Número de filas en el TableLayoutPanel

            // Obtener la posición actual del Label en la tabla
            int currentRow = currentIndex / totalColumns;
            int currentColumn = currentIndex % totalColumns;

            // Calcular la nueva posición
            int newRow = currentRow + rowOffset;
            int newColumn = currentColumn + columnOffset;

            // Verificar que la nueva posición está dentro de los límites
            if (newRow >= 0 && newRow < totalRows && newColumn >= 0 && newColumn < totalColumns)
            {
                int newIndex = newRow * totalColumns + newColumn; // Convertir fila/columna a índice de la lista
                if (newIndex < labels.Count) // Verificar que el índice es válido
                {
                    currentIndex = newIndex;
                    labels[currentIndex].Focus(); // Mover el foco al nuevo Label
                }
            }
        }

        private async void SeleccionarYCerrar(Label lbl)
        {
            if (lbl == null) return;

            lbl.BackColor = SystemColors.Highlight;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            lbl.Invalidate();

            // Asignar el texto del label seleccionado al TextBox
            if (textBoxDestino != null)
            {
                textBoxDestino.Text = lbl.Text;
            }

            await Task.Delay(200); // Pequeño delay  antes de cerrar
            this.Close();
        }

        /// <summary>
        /// clase publica que permite que los label reciban el foco
        /// </summary>
        public class FocusableLabel : Label
        {
            public FocusableLabel()
            {
                SetStyle(ControlStyles.Selectable, true);
                TabStop = true; // Permitir recibir foco
            }
        }

    }
}