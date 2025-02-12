
using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;

namespace Ofelia_Sara.Clases.BaseDatos.Ofelia_DB
{
    public class DatabaseConnection
    {
        private SQLiteConnection connection;
        private readonly string databasePath;

        public DatabaseConnection()
        {
            if (IsInDesignMode())
            {
                Console.WriteLine("Modo diseño detectado, omitiendo inicialización de DatabaseConnection.");
                return;
            }

            // Ruta donde se almacenará la base de datos SQLite
            databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.sqlite");

            InitializeConnection();
        }

        private void InitializeConnection()
        {
            // Verifica si la base de datos existe; si no, la crea
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            // Define la cadena de conexión
            connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
        }

        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                   AppDomain.CurrentDomain.FriendlyName.Contains("DefaultDomain");
        }

        public SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
                }
                return connection;
            }
        }

        public void OpenConnection()
        {
            if (connection?.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection?.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
