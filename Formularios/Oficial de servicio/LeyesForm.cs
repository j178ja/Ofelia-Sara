using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class LeyesForm : BaseForm
    {
        public LeyesForm()
        {
            InitializeComponent();
         
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

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
            string carpetaDocumentos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BaseDatos\Leyes");
            string[] archivos = Directory.GetFiles(carpetaDocumentos, "*.pdf");

            foreach (string archivo in archivos)
            {
                FileInfo fileInfo = new FileInfo(archivo);

                // Eliminar la extensión .pdf del nombre del archivo
                string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);

                // Añadir el archivo al ListView sin la extensión
                ListViewItem item = new ListViewItem(nombreArchivoSinExtension);
                item.Tag = fileInfo.FullName;
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

                // Ruta completa del archivo
                string filePath = Path.Combine(@"BaseDatos\Leyes", fileName);

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
                    MessageBox.Show("El archivo no existe: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
