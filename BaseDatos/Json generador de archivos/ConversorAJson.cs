using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.General.Mensajes;

namespace Ofelia_Sara.Clases.GenerarDocumentos
{

   

public static class ConversorAJson
    {
        /// <summary>
        /// Convierte texto estructurado en un archivo JSON dentro de la carpeta "Datos".
        /// </summary>
        /// <param name="textoFuente">El texto fuente a procesar.</param>
        /// <param name="nombreArchivo">Nombre del archivo JSON (sin ruta).</param>
        /// <param name="patronSeparacion">Regex para identificar cada bloque (por defecto: Artículo X:)</param>
        public static void GuardarComoJson(string textoFuente, string nombreArchivo = "articulos.json", string patronSeparacion = @"Artículo\s+(\d+):\s*(.*?)(?=Artículo\s+\d+:|$)")
        {
    //        try
    //        {
    //            var matches = Regex.Matches(textoFuente, patronSeparacion, RegexOptions.Singleline);
    //            List<EntradaTexto> lista = new();

    //            foreach (Match match in matches)
    //            {
    //                if (int.TryParse(match.Groups[1].Value, out int numero))
    //                {
    //                    string contenido = match.Groups[2].Value.Trim();
    //                    lista.Add(new EntradaTexto { Articulo = numero, Contenido = contenido });
    //                }
    //            }

    //            var opciones = new JsonSerializerOptions { WriteIndented = true };
    //            string json = JsonSerializer.Serialize(lista, opciones);

    //            // Crear carpeta Datos si no existe
    //            string carpeta = Path.Combine(Application.StartupPath, "Datos");
    //            if (!Directory.Exists(carpeta))
    //                Directory.CreateDirectory(carpeta);

    //            // Guardar archivo
    //            string rutaSalida = Path.Combine(carpeta, nombreArchivo);
    //            File.WriteAllText(rutaSalida, json);

    //            MensajeGeneral.Mostrar($"Archivo JSON guardado correctamente en:\n{rutaSalida}", MensajeGeneral.TipoMensaje.Exito);
    //        }
    //        catch (Exception ex)
    //        {
    //            MensajeGeneral.Mostrar($"Error al generar JSON:\n{ex.Message}",MensajeGeneral.TipoMensaje.Error);
    //        }
       }
    }
}
/*FORMAS DE INVOCAR  A LA CASE PARA CONVERTIR TEXTO
 
private void btn_GenerarJson_Click(object sender, EventArgs e)
{
    string textoFuente = File.ReadAllText("articulos.txt"); // o desde un TextBox
    ConversorTextoAJson.GuardarComoJson(textoFuente);
}

*/