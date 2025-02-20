using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    /// <summary>
    /// FORMULARIO QUE MUESTRA LISTADO DE DOCUMENTOS DE CONSULTA
    /// </summary>
    public partial class LeyesForm : BaseForm
    {
        #region VARIABLES
        private ListViewItem hoverItem = null; // Ítem actualmente en hover
        private Color hoverColor = Color.LightBlue; // Color de fondo al pasar el cursor
        private Color selectedColor = Color.FromArgb(0, 154, 174); // Color de fondo al hacer clic
        private Color selectedTextColor = Color.White; // Color del texto al hacer clic
        private Color subrayadoColor = Color.Blue; // Color del subrayado
        #endregion

        #region CONSTRUCTOR
        public LeyesForm()
        {
            InitializeComponent();

            RedondearBordes.Aplicar(panel1, 15);
            // Eventos del ListView
            listView_Documentos.Click += ListView_Documentos_Click;
          //  listView_Documentos.SelectedIndexChanged += ListView_Documentos_SelectedIndexChanged;
            listView_Documentos.OwnerDraw = true;
            listView_Documentos.DrawItem += ListView_Documentos_DrawItem;
            listView_Documentos.MouseMove += ListView_Documentos_MouseMove;
            listView_Documentos.MouseLeave += ListView_Documentos_MouseLeave;

    
        }

        #endregion

        #region LOAD
        private void LeyesForm_Load(object sender, EventArgs e)
        {
            CargarDocumentosEnListView();
            ConfigurarListView();
            listView_Documentos.SelectedItems.Clear(); // Limpia selección inicial
            listView_Documentos.Invalidate(); // Redibuja el ListView

        }
        #endregion
        private void ConfigurarListView()
        {
            listView_Documentos.Font = new Font(listView_Documentos.Font.FontFamily, 12);
            listView_Documentos.View = View.Details;
            listView_Documentos.Scrollable = true;
            listView_Documentos.FullRowSelect = true;

            if (listView_Documentos.Columns.Count == 0)
            {
                listView_Documentos.Columns.Add("", listView_Documentos.Width - 4);
            }

            if (listView_Documentos.Columns.Count > 0)
            {
                listView_Documentos.Columns[0].Width = listView_Documentos.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }

        #region APARIENCIA
        /// <summary>
        /// CARGA LISTADO DE DOCUMENTOS PARA EXHIBIR
        /// </summary>
        private void CargarDocumentosEnListView()
        {
            string carpetaDocumentos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "Leyes");

            if (!Directory.Exists(carpetaDocumentos))
            {
                MensajeGeneral.Mostrar($"La carpeta no existe: {carpetaDocumentos}", MensajeGeneral.TipoMensaje.Error);
                return;
            }

            string[] archivos = Directory.GetFiles(carpetaDocumentos, "*.pdf");

            foreach (string archivo in archivos)
            {
                FileInfo fileInfo = new FileInfo(archivo);
                string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);

                ListViewItem item = new ListViewItem(nombreArchivoSinExtension)
                {
                    Tag = fileInfo.FullName
                };

                listView_Documentos.Items.Add(item);
            }
        }

        /// <summary>
        /// CARACTERISTICAS DEL LIST
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Documentos_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            int leftMargin = 10; // Margen izquierdo adicional en píxeles

            bool isHovered = (hoverItem == e.Item);
            bool isSelected = e.Item.Selected;

            // Establecer colores según el estado del ítem
            Color backgroundColor = isSelected ? selectedColor : isHovered ? hoverColor : listView_Documentos.BackColor;
            Color textColor = isSelected ? selectedTextColor : listView_Documentos.ForeColor;

            // Dibujar fondo
            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Crear una fuente temporal para el texto en negrita si está en hover
            Font textFont = isHovered
                ? new Font(listView_Documentos.Font, FontStyle.Bold)
                : listView_Documentos.Font;

            // Dibujar texto desplazado con margen izquierdo
            Rectangle textBounds = new Rectangle(e.Bounds.Left + leftMargin, e.Bounds.Top, e.Bounds.Width - leftMargin, e.Bounds.Height);

            TextRenderer.DrawText(
                e.Graphics,
                e.Item.Text,
                textFont,
                textBounds, // Usar los límites desplazados
                textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );

            // Subrayado dinámico si el ítem está en hover
            if (isHovered)
            {
                SubrayadoAnimado.Aplicar(e.Item, e.Graphics, subrayadoColor, 3);
            }

          
        }


        private void ListView_Documentos_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView_Documentos.GetItemAt(e.X, e.Y);

            if (item != hoverItem)
            {
                // Detener subrayado en el ítem anterior
                if (hoverItem != null)
                {
                    SubrayadoAnimado.Detener(hoverItem);
                    listView_Documentos.Invalidate(hoverItem.Bounds);
                }

                // Actualizar el ítem actual
                hoverItem = item;

                if (hoverItem != null)
                {
                    SubrayadoAnimado.Iniciar(hoverItem);
                    listView_Documentos.Invalidate(hoverItem.Bounds);
                }
            }
        }

        private void ListView_Documentos_MouseLeave(object sender, EventArgs e)
        {
            if (hoverItem != null)
            {
                SubrayadoAnimado.Detener(hoverItem);
                hoverItem = null;
            }

            listView_Documentos.Invalidate();
        }

        private async void ListView_Documentos_Click(object sender, EventArgs e)
        {
            if (listView_Documentos.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView_Documentos.SelectedItems[0];
                string fileNameWithoutExtension = selectedItem.Text;
                string fileName = fileNameWithoutExtension + ".pdf";

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string carpetaDocumentos = Path.Combine(baseDirectory, "BaseDatos", "Leyes");
                string filePath = Path.Combine(carpetaDocumentos, fileName);

                // Introducir un retraso antes de abrir el archivo
                await Task.Delay(100); // Agregar un pequeño retraso

                if (File.Exists(filePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });

                    // Restablecer el estilo del ítem seleccionado
                    selectedItem.BackColor = listView_Documentos.BackColor; // Fondo predeterminado del ListView
                    selectedItem.ForeColor = listView_Documentos.ForeColor; // Color de texto predeterminado
                    selectedItem.Font = listView_Documentos.Font;           // Fuente predeterminada

                    // Forzar redibujo del ítem
                    selectedItem.Selected = false; // Desseleccionar el ítem
                    listView_Documentos.Invalidate(selectedItem.Bounds); // Redibujar el ítem
                }
                else
                {
                    MensajeGeneral.Mostrar("El archivo no existe: " + filePath, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }




        //private void ListView_Documentos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem item in listView_Documentos.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            item.BackColor = selectedColor;
        //            item.ForeColor = selectedTextColor;
        //            item.Font = new Font(listView_Documentos.Font, FontStyle.Bold);
        //        }
        //        else
        //        {
        //            item.BackColor = listView_Documentos.BackColor;
        //            item.ForeColor = listView_Documentos.ForeColor;
        //            item.Font = listView_Documentos.Font;
        //        }
        //    }
        //}



    }
}
#endregion