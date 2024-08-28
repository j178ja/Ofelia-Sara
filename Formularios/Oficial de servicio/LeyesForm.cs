using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            string carpetaDocumentos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Base de Datos\Leyes");
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

            // Ajustar la columna después de cargar los documentos para asegurarse de que no hay scroll horizontal
           // listView_Documentos.Columns[0].Width = listView_Documentos.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
        }


    }
}
