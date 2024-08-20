
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Ofelia_Sara.Base_de_Datos
{
    public class DatabaseManager : IDisposable
    {
        private readonly string connectionString;
        private SQLiteConnection connection;

        public DatabaseManager(string databasePath)
        {
            // Configura la cadena de conexión usando la ruta de la base de datos.
            connectionString = $"Data Source={databasePath};Version=3;";
        }

        public SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
            }

            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        public void Dispose()
        {
            // Asegura que la conexión esté cerrada y liberada cuando se destruye el objeto.
            CloseConnection();
        }
    }
}*/