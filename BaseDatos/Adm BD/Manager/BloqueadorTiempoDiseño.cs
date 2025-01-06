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
        /// <summary>
        /// Devuelve una instancia de DatabaseConnection si no se encuentra en modo diseño.
        /// </summary>
        /// <returns>Una instancia de DatabaseConnection o null si está en modo diseño.</returns>
        public static DatabaseConnection GetDatabaseConnection()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return null; // No inicializamos nada en modo diseño
            }
            return new DatabaseConnection();
        }

        /// <summary>
        /// Determina si la aplicación está en modo diseño.
        /// </summary>
        /// <returns>true si está en modo diseño; de lo contrario, false.</returns>
        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                   AppDomain.CurrentDomain.FriendlyName.Contains("DefaultDomain");
        }
    }
}
