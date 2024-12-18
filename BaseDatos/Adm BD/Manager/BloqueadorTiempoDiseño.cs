using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ofelia_Sara.Clases.BaseDatos;

namespace Ofelia_Sara.BaseDatos.Adm_BD.Manager
{
    public static class BloqueadorTiempoDiseño
    {
        //public static DatabaseConnection GetDatabaseConnection()
        //{
        //    if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        //    {
        //        return null; // No inicializar conexión en modo diseño
        //    }
        //    return new DatabaseConnection();
        //}
        public static DatabaseConnection GetDatabaseConnection()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                // Confirmar que estamos en tiempo de diseño
                Console.WriteLine("Modo diseño detectado: no se inicializa la conexión.");
                return null; // No inicializar conexión en modo diseño
            }
            return new DatabaseConnection();
        }
    }
}
