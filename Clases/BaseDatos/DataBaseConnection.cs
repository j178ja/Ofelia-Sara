using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;

namespace Ofelia_Sara.Clases.BaseDatos
{ 
public class DatabaseConnection
{
    private readonly string connectionString;
    private MySqlConnection connection;

    public DatabaseConnection()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            Console.WriteLine("Modo diseño detectado, omitiendo inicialización de DatabaseConnection.");
            return; // Salir en tiempo de diseño
        }

        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        connection = new MySqlConnection(connectionString);
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