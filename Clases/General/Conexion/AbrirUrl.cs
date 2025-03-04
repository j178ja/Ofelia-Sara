using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ofelia_Sara.Clases.General.Conexion
{
    public static class ConexionGeneral
    {
        public static void AbrirUrl(string url)
        {
            try
            {
                // Verifica si la URL requiere conexión a Internet
                if (!url.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase) &&
                    !ConexionInternet.CheckInternetConnection())
                {
                    MensajeGeneral.Mostrar("No hay conexión a internet. Verifique su conexión e intente nuevamente.", MensajeGeneral.TipoMensaje.ErrorConexion);
                    return;
                }

                // Crear y configurar el proceso
                var processInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Usa el navegador predeterminado o cliente de correo
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir el enlace: {url}. Error: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }
    }
}

