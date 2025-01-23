using Ofelia_Sara.Clases.BaseDatos;
using System;
using System.ComponentModel;
using System.Diagnostics;

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
            if (IsInDesignMode())
            {
                Debug.WriteLine("Modo diseño detectado. DatabaseConnection no será inicializado.");
                return null;
            }

          
            DatabaseConnection connection = new DatabaseConnection();
            if (connection == null)
            {
                throw new InvalidOperationException("DatabaseConnection se inicializó como null inesperadamente.");
            }

            return connection;
        }


        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                   AppDomain.CurrentDomain.FriendlyName.Contains("DefaultDomain");
        }

    }
}
