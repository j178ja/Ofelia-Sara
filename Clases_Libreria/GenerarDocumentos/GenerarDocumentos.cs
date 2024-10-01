using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO; // Para operaciones de archivo
using System.Windows.Forms;//(usandolo se elimina error de que no reconosca menssageBox)
using Word = Microsoft.Office.Interop.Word;


    namespace Clases.GenerarDocumentos
    {
        public class GeneradorDocumentos
        {
            public void GenerarDocumento(string rutaPlantilla, string rutaArchivoSalida, Dictionary<string, string> datosFormulario)
            {
                Word.Application wordApp = null;
                Word.Document wordDoc = null;

                try
                {
                    // Iniciar la aplicación de Word
                    wordApp = new Word.Application();
                    wordApp.Visible = false; // No mostrar la interfaz de Word

                    // Abrir el documento de plantilla
                    wordDoc = wordApp.Documents.Open(rutaPlantilla);

                    // Reemplazar los valores en los marcadores de la plantilla
                    foreach (var dato in datosFormulario)
                    {
                        if (wordDoc.Bookmarks.Exists(dato.Key))
                        {
                            // Seleccionar el marcador
                            Word.Bookmark bookmark = wordDoc.Bookmarks[dato.Key];

                            // Reemplazar el texto del marcador
                            bookmark.Range.Text = dato.Value;

                            // Reestablecer el marcador en la nueva ubicación (si es necesario)
                            wordDoc.Bookmarks.Add(dato.Key, bookmark.Range);
                        }
                        else
                        {
                            MessageBox.Show($"El marcador '{dato.Key}' no existe en el documento.");
                        }
                    }

                    // Guardar el documento modificado
                    wordDoc.SaveAs2(rutaArchivoSalida);
                    MessageBox.Show("Documento generado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el documento: " + ex.Message);
                }
                finally
                {
                    // Cerrar y liberar recursos
                    if (wordDoc != null)
                    {
                        wordDoc.Close(false); // No guardar cambios en el documento original
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
