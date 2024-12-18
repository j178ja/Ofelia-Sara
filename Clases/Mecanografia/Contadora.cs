
/*ESTA CLASE CUENTA LAS PALABRAS Y LOS CARACTERES DE UN ARCHIVO SELECCIONADO*/

using DocumentFormat.OpenXml.Packaging;
using System;
using System.IO;

namespace Ofelia_Sara.Clases.Mecanografia
{
    public class ContadorArchivo
    {
        public (int cantidadPalabras, int cantidadCaracteres) ContarPalabrasYCaracteresDocx(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("El archivo no existe.");

            string contenido = "";

            // Abrir el archivo .docx
            using (WordprocessingDocument doc = WordprocessingDocument.Open(rutaArchivo, false))
            {
                contenido = doc.MainDocumentPart.Document.Body.InnerText;
            }

            // Contar palabras
            string[] palabras = contenido.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int cantidadPalabras = palabras.Length;

            // Contar caracteres (sin contar espacios ni saltos de línea)
            int cantidadCaracteres = contenido.Replace(" ", "").Replace("\n", "").Replace("\r", "").Length;

            return (cantidadPalabras, cantidadCaracteres);
        }
    }
}
