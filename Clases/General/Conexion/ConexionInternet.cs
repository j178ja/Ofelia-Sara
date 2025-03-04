using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.Clases.General.Conexion
{
    /// <summary>
    /// se la llama desde evento click
    /// </summary>
    public static class ConexionInternet
    {
        /// <summary>
        /// Verifica si hay conexión a Internet intentando acceder a una URL.
        /// </summary>
        /// <param name="url">La URL a probar (por defecto Google).</param>
        /// <returns>True si hay conexión, False si no hay conexión.</returns>
        public static bool CheckInternetConnection(string url = "https://www.google.com")
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead(url)) // Intenta hacer una petición al sitio
                {
                    return true; // Conexión exitosa
                }
            }
            catch
            {//no recomendado el mensaje pero funciona
             // MensajeGeneral.Mostrar("No hay conexión a internet. Verifique su conexión e intente nuevamente.", MensajeGeneral.TipoMensaje.Error);
                return false; // No hay conexión

            }
        }
    }
}