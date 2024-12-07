using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDatos.Mensaje;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.Oficial_de_servicio;

namespace Ofelia_Sara.Controles.Controles
{
    public partial class Verificador_ACTUACION : UserControl
    {
        public event EventHandler ImagenVisibleChanged;// para indicar que esta seleccionado

        private PictureBox enlargedPictureBox; // PictureBox flotante para la imagen ampliada

        private IMPRESION formulario;
        public Verificador_ACTUACION(IMPRESION form)
        {
            InitializeComponent();

           

            // Configuración inicial
            pictureBox_CheckSeleccionado.Visible = false;
            //checkBox_Selecionar.Visible = false;

            // Suscripción al evento Load del formulario
            this.Load += Verificador_ACTUACION_Load;
        }

        private void Verificador_ACTUACION_Load(object sender, EventArgs e)
        {
            // Configuración de ToolTips para los controles
           // ToolTipGeneral.ShowToolTip(Remover_Control, "ELIMINAR del listado de actuaciones.");
           // ToolTipGeneral.ShowToolTip(linkLabel_Actuacion, "REDIRIGIR a formulario.");
            //ToolTipGeneral.ShowToolTip(pictureBox_PrevisualizadorDocumento, "VISUALIZAR documento.");
        }
        public bool IsImagenVisible
        {
            get { return pictureBox_CheckSeleccionado.Visible; }
        }


        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (enlargedPictureBox != null) return; // Evitar duplicados

            // Crear y configurar el PictureBox ampliado
            enlargedPictureBox = new PictureBox
            {
                Image = pictureBox_PrevisualizadorDocumento.Image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(300, 400), // Tamaño ampliado
                BackColor = Color.White, // Fondo opcional
                BorderStyle = BorderStyle.FixedSingle // Borde opcional
            };

            // Posicionar el PictureBox cerca del control original
            Point controlLocation = pictureBox_PrevisualizadorDocumento.PointToScreen(Point.Empty);
            enlargedPictureBox.Location = new Point(controlLocation.X, controlLocation.Y - enlargedPictureBox.Height - 10);

            // Agregar el PictureBox ampliado al formulario
            this.Controls.Add(enlargedPictureBox);
            enlargedPictureBox.BringToFront();

            // Evento para ocultar la imagen ampliada al mover el cursor fuera de ella
            enlargedPictureBox.MouseLeave += (s, args) => RemoveEnlargedPictureBox();
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            RemoveEnlargedPictureBox(); // Ocultar la imagen ampliada
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Acción para abrir la estructura de visualización/edición
            MostrarEstructuraEdicion(); // Implementa este método según tu lógica
        }

        private void RemoveEnlargedPictureBox()
        {
            if (enlargedPictureBox != null)
            {
                this.Controls.Remove(enlargedPictureBox);
                enlargedPictureBox.Dispose();
                enlargedPictureBox = null;
            }
        }

        private void MostrarEstructuraEdicion()
        {
            // Abre la estructura de visualización y edición del documento
            MessageBox.Show("Abrir estructura para visualizar y editar el documento.");
        }

        private void checkBox_Selecionar_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Selecionar.Visible = false;
            CambiarVisibilidad();
        }
        public void CambiarVisibilidad()
        {
            // Cambiar la visibilidad
            pictureBox_CheckSeleccionado.Visible = !pictureBox_CheckSeleccionado.Visible;

            // Disparar el evento si la imagen se hizo visible
            if (pictureBox_CheckSeleccionado.Visible)
            {
                ImagenVisibleChanged?.Invoke(this, EventArgs.Empty);
                //ActualizarContadores();
            }
        }


        private void pictureBox_CheckSeleccionado_Click(object sender, EventArgs e)
        {
            checkBox_Selecionar.Checked = false;
            pictureBox_CheckSeleccionado.Visible = false;
            
           

            checkBox_Selecionar.Visible = true;
        }
        private void Remover_Control_Click(object sender, EventArgs e)
        {
            using (MensajeGeneral mensaje = new MensajeGeneral(
                "Se eliminará el documento creado mediante formulario. ¿Está seguro de eliminar el documento?",
                MensajeGeneral.TipoMensaje.Advertencia))
            {
                // Hacer visibles los botones de confirmación (Sí / No)
                mensaje.MostrarBotonesConfirmacion(true);

                // Mostrar el mensaje y capturar la respuesta del usuario
                DialogResult result = mensaje.ShowDialog();

                // Verificar si el usuario seleccionó "No"
                if (result == DialogResult.No)
                {
                    // No hacer nada (el usuario canceló la acción)
                    return;
                }

                // Si el usuario seleccionó "Sí", proceder con la eliminación
                RemoverVerificador();
               // ActualizarContadores();
            }
        }

        private void RemoverVerificador()
        {
            // Obtener el contenedor (TableLayoutPanel) que aloja este control
            TableLayoutPanel parentTable = this.Parent as TableLayoutPanel;

            if (parentTable != null)
            {
                // Remover este control del contenedor
                parentTable.Controls.Remove(this);
               
                // Ajustar la distribución después de eliminar el control
                AjustarDistribucionGeneral(parentTable);

                // Liberar recursos del control
                this.Dispose();
            }
            else
            {
                MensajeGeneral.Mostrar("El control no se encuentra dentro de un TableLayoutPanel.", MensajeGeneral.TipoMensaje.Error);
            }
        }

        // ---------------------------------------
        // Métodos de Ajuste y Redistribución
        // ---------------------------------------

        private void AjustarDistribucionGeneral(TableLayoutPanel table)
        {
            // Reorganizar controles en filas y columnas
            ReorganizarControles(table);

            // Eliminar filas vacías
            for (int i = table.RowCount - 1; i >= 0; i--)
            {
                if (EsFilaVacia(table, i))
                {
                    table.RowStyles.RemoveAt(i);
                    table.RowCount--;
                }
            }

            // Eliminar columnas vacías si es necesario
            for (int j = table.ColumnCount - 1; j >= 0; j--)
            {
                if (EsColumnaVacia(table, j))
                {
                    EliminarColumna(table, j);
                }
            }

            // Redistribuir y centrar columnas
            CentrarColumnas(table);
        }

        private void EliminarColumna(TableLayoutPanel table, int columnIndex)
        {
            // Eliminar controles de la columna
            for (int row = 0; row < table.RowCount; row++)
            {
                var control = table.GetControlFromPosition(columnIndex, row);
                if (control != null)
                    table.Controls.Remove(control);
            }

            // Ajustar las columnas restantes
            table.ColumnStyles.RemoveAt(columnIndex);
            table.ColumnCount--;

            // Redistribuir el espacio equitativamente
            foreach (ColumnStyle style in table.ColumnStyles)
            {
                style.SizeType = SizeType.Percent;
                style.Width = 100f / table.ColumnCount;
            }
        }

        private void ReorganizarControles(TableLayoutPanel table)
        {
            for (int row = 0; row < table.RowCount; row++)
            {
                for (int col = 0; col < table.ColumnCount; col++)
                {
                    if (table.GetControlFromPosition(col, row) == null)
                    {
                        // Buscar el siguiente control en columnas posteriores
                        for (int nextCol = col + 1; nextCol < table.ColumnCount; nextCol++)
                        {
                            var control = table.GetControlFromPosition(nextCol, row);
                            if (control != null)
                            {
                                table.SetColumn(control, col);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void CentrarColumnas(TableLayoutPanel table)
        {
            // Verificar si el TableLayoutPanel tiene columnas configuradas
            if (table.ColumnCount == 0) return;

            // Calcular el total del ancho de las columnas visibles
            float totalWidth = 0;
            foreach (ColumnStyle style in table.ColumnStyles)
            {
                if (style.SizeType == SizeType.Percent)
                {
                    totalWidth += style.Width;
                }
            }

            // Asegurarse de que el total del ancho no exceda el 100%
            totalWidth = Math.Min(totalWidth, 100);

            // Calcular el margen izquierdo necesario para centrar las columnas
            float margenIzquierdo = (100 - totalWidth) / 2;

            // Ajustar las columnas para centrar el contenido
            for (int i = 0; i < table.ColumnStyles.Count; i++)
            {
                ColumnStyle style = table.ColumnStyles[i];

                if (style.SizeType == SizeType.Percent)
                {
                    // Redistribuir los márgenes iniciales en la primera y última columna
                    if (i == 0)
                    {
                        style.Width = margenIzquierdo + style.Width;
                    }
                    else if (i == table.ColumnStyles.Count - 1)
                    {
                        style.Width = style.Width + margenIzquierdo;
                    }
                }
            }
        }

        /// <summary>
        /// metodo para recorrer filas
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private bool EsFilaVacia(TableLayoutPanel table, int rowIndex)
        {
            for (int col = 0; col < table.ColumnCount; col++)
            {
                if (table.GetControlFromPosition(col, rowIndex) != null)
                {
                    return false;
                }
            }
            return true;
        }
        //--------------------------------------------------------------------

        /// <summary>
        /// metodo para recorre columna
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private bool EsColumnaVacia(TableLayoutPanel table, int columnIndex)
        {
            for (int row = 0; row < table.RowCount; row++)
            {
                if (table.GetControlFromPosition(columnIndex, row) != null)
                {
                    return false;
                }
            }
            return true;
        }



    }
}
