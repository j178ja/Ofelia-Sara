using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.IO; // Para operaciones de archivo
using System.Windows.Forms;//(usandolo se elimina error de que no reconosca menssageBox)
using Word = Microsoft.Office.Interop.Word;


namespace Ofelia_Sara.Clases.GenerarDocumentos
{
    public class GeneradorDocumentos
    {
        public void GenerarDocumento(string rutaPlantilla, string rutaArchivoSalida, Dictionary<string, string> datosFormulario)
        {
            Word.Application wordApp = null;
            Word.Document wordDoc = null;

            try
            {
                // Inicializa la aplicación de Word
                wordApp = new Word.Application();
                wordDoc = wordApp.Documents.Open(rutaPlantilla);

                // Lógica para procesar y generar el documento usando datosFormulario...
                // Ejemplo: Reemplazar marcadores en el documento

                foreach (var item in datosFormulario)
                {
                    // Suponiendo que los marcadores están en el documento
                    Word.Range range = wordDoc.Bookmarks[item.Key].Range;
                    range.Text = item.Value;
                }

                // Guarda el documento en la ruta de salida
                wordDoc.SaveAs2(rutaArchivoSalida);
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                MensajeGeneral.Mostrar("Error al comunicarse con Word: " + comEx.Message, MensajeGeneral.TipoMensaje.Error);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al generar el documento: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                // Cerrar y liberar recursos
                if (wordDoc != null)
                {
                    try
                    {
                        wordDoc.Close(false); // No guardar cambios en el documento original
                    }
                    catch (Exception ex)
                    {
                        MensajeGeneral.Mostrar("Error al cerrar el documento: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                    }
                }

                if (wordApp != null)
                {
                    try
                    {
                        wordApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        MensajeGeneral.Mostrar("Error al cerrar la aplicación de Word: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    }
                }

                // Fuerza la recolección de basura para liberar recursos COM
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public void GenerarYGuardarDocumento(string rutaPlantilla, string rutaSubcarpeta, string nombrePlantilla, Dictionary<string, string> datosFormulario)
        {
            // Verificar que la plantilla exista
            if (File.Exists(rutaPlantilla))
            {
                // Definir el nombre del archivo de salida igual al de la plantilla
                string nombreArchivoSalida = nombrePlantilla + ".docx";
                string rutaArchivoSalida = Path.Combine(rutaSubcarpeta, nombreArchivoSalida);

                // Llamar al método para generar el documento
                GenerarDocumento(rutaPlantilla, rutaArchivoSalida, datosFormulario);
            }
            else
            {
                MensajeGeneral.Mostrar($"La plantilla {nombrePlantilla} no se encuentra en la ruta especificada.", MensajeGeneral.TipoMensaje.Error);
            }
        }
    }
}
