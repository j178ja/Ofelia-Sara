using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;

namespace Ofelia_Sara.Clases.BaseDatos
{ 
public class DatabaseConnection
{
        public string connectionString;
        private MySqlConnection connection;

    public DatabaseConnection()
    {

            if (IsInDesignMode())
            {
                Console.WriteLine("Modo diseño detectado, omitiendo inicialización de DatabaseConnection.");
                return;
            }

            InitializeConnection();
        }


        private void InitializeConnection()
        {
         
            connection = new MySqlConnection(connectionString);
        }

        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                   AppDomain.CurrentDomain.FriendlyName.Contains("DefaultDomain");
        }

        public MySqlConnection Connection
    {
        get
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
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