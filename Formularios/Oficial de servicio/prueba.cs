using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class prueba : BaseForm
    {
        public prueba()
        {
            InitializeComponent();
        }

        private void prueba_Load(object sender, EventArgs e)
        {

        }
        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            // Especifica la ruta de tu archivo Excel
            string rutaArchivoExcel = @"E:\personal\RP2100.xlsx"; // Cambia esta ruta a la correcta

            // Crear una instancia de la clase ExcelReader
            ExcelReader lectorExcel = new ExcelReader();

            try
            {
                // Leer los datos desde el archivo Excel
                List<Dictionary<string, string>> datos = lectorExcel.LeerDatosDesdeExcel(rutaArchivoExcel);

                // Convertir los datos a una DataTable
                DataTable tablaDatos = ConvertirADataTable(datos);

                // Mostrar los datos en el DataGridView
                dataGridViewExcel.DataSource = tablaDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al leer el archivo Excel: {ex.Message}");
            }
        }

        // Método para convertir una lista de diccionarios a DataTable
        private DataTable ConvertirADataTable(List<Dictionary<string, string>> listaDatos)
        {
            DataTable dataTable = new DataTable();

            if (listaDatos.Count > 0)
            {
                // Crear columnas en la DataTable basadas en los encabezados
                foreach (var clave in listaDatos[0].Keys)
                {
                    dataTable.Columns.Add(clave);
                }

                // Añadir las filas a la DataTable
                foreach (var fila in listaDatos)
                {
                    DataRow nuevaFila = dataTable.NewRow();
                    foreach (var par in fila)
                    {
                        nuevaFila[par.Key] = par.Value;
                    }
                    dataTable.Rows.Add(nuevaFila);
                }
            }

            return dataTable;
        }
    }
}

