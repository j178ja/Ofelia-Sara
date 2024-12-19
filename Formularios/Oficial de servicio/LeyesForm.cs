using Ofelia_Sara.Clases.General.Apariencia;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class LeyesForm : BaseForm
    {
        public LeyesForm()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            this.listView_Documentos.DoubleClick += new System.EventHandler(this.listView_Documentos_DoubleClick);

        }

        private void LeyesForm_Load(object sender, EventArgs e)
        {
            CargarDocumentosEnListView();

            ConfigurarListView();


        }
        private void ConfigurarListView()
        {
            // Configurar el tamaño de la fuente
            listView_Documentos.Font = new Font(listView_Documentos.Font.FontFamily, 12);

            // Configurar el modo de vista
            listView_Documentos.View = View.Details;

            // Asegurarse de que el ListView sea scrollable verticalmente
            listView_Documentos.Scrollable = true;
            listView_Documentos.FullRowSelect = true;

            // Añadir una columna si no hay ninguna
            if (listView_Documentos.Columns.Count == 0)
            {
                listView_Documentos.Columns.Add("", listView_Documentos.Width - 4); // Ajustar el ancho de la columna al ancho del ListView
            }

            // Ajustar la columna al ancho del control para evitar el scroll horizontal
            if (listView_Documentos.Columns.Count > 0)
            {
                listView_Documentos.Columns[0].Width = listView_Documentos.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }

        private void CargarDocumentosEnListView()
        {
            // Ruta relativa a la carpeta "BaseDatos\Leyes" desde el directorio base de la aplicación
            string carpetaDocumentos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "Leyes");

            // Verificar que la carpeta exista
            if (!Directory.Exists(carpetaDocumentos))
            {
                MensajeGeneral.Mostrar($"La carpeta no existe: {carpetaDocumentos}", MensajeGeneral.TipoMensaje.Error);
                return;
            }

            // Obtener los archivos PDF en la carpeta
            string[] archivos = Directory.GetFiles(carpetaDocumentos, "*.pdf");

            // Iterar sobre los archivos encontrados
            foreach (string archivo in archivos)
            {
                FileInfo fileInfo = new FileInfo(archivo);

                // Obtener el nombre del archivo sin la extensión
                string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);

                // Crear un ListViewItem con el nombre del archivo sin la extensión
                ListViewItem item = new ListViewItem(nombreArchivoSinExtension)
                {
                    Tag = fileInfo.FullName // Guardar la ruta completa en la propiedad Tag
                };

                // Añadir el ítem al ListView
                listView_Documentos.Items.Add(item);
            }
        }

        private void listView_Documentos_DoubleClick(object sender, EventArgs e)
        {
            // Verifica si hay elementos seleccionados
            if (listView_Documentos.SelectedItems.Count > 0)
            {
                // Obtén el nombre del archivo seleccionado sin la extensión
                string fileNameWithoutExtension = listView_Documentos.SelectedItems[0].Text;

                // Agrega la extensión .pdf al nombre del archivo
                string fileName = fileNameWithoutExtension + ".pdf";

                // Construye la ruta relativa a partir del directorio base
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string carpetaDocumentos = Path.Combine(baseDirectory, "BaseDatos", "Leyes");
                string filePath = Path.Combine(carpetaDocumentos, fileName);

                // Verifica si el archivo existe
                if (File.Exists(filePath))
                {
                    // Abre el archivo con el programa predeterminado
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true // Usa el programa asociado para abrir el archivo
                    });
                }
                else
                {
                    MensajeGeneral.Mostrar("El archivo no existe: " + filePath, MensajeGeneral.TipoMensaje.Error);
                }
            }
        }




    }
}
