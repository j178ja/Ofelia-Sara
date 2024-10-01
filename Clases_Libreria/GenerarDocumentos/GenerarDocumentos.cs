using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO; // Para operaciones de archivo
using System.Windows.Forms;//(usandolo se elimina error de que no reconosca menssageBox)
using Word = Microsoft.Office.Interop.Word;


namespace Ofelia_Sara.general.clases.GenerarDocumentos
{
    public class GeneradorDocumentos
    {
        public void GenerarDocumento(string rutaPlantilla, string rutaArchivoSalida, Dictionary<string, string> datosFormulario)
        {
            Word.Application wordApp = null;
            Word.Document wordDoc = null;

            try
            {
                // Crear una nueva instancia de la aplicación Word
                wordApp = new Word.Application();
                wordApp.Visible = false; // Mantener la aplicación oculta

                // Abrir el documento de plantilla
                wordDoc = wordApp.Documents.Open(rutaPlantilla);

                // Reemplazar los valores en los marcadores de la plantilla
                foreach (var dato in datosFormulario)
                {
                    if (wordDoc.Bookmarks.Exists(dato.Key))
                    {
                        // Seleccionar el marcador
                        Bookmark bookmark = wordDoc.Bookmarks[dato.Key];

                        // Reemplazar el texto del marcador
                        bookmark.Range.Text = dato.Value;

                        // Reestablecer el marcador en la nueva ubicación
                        wordDoc.Bookmarks.Add(dato.Key, bookmark.Range);
                    }
                }
                // Guardar el documento en la ruta de salida
                wordDoc.SaveAs2(rutaArchivoSalida);
                MessageBox.Show("Documento generado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el documento: " + ex.Message);
            }
            finally
            {
                // Cerrar el documento y la aplicación de Word
                if (wordDoc != null)
                {
                    wordDoc.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                }

                if (wordApp != null)
                {
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
            }
        }
    }
}