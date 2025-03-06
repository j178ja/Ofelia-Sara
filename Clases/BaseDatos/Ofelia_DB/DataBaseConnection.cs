
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Ofelia_Sara.Clases.BaseDatos.Ofelia_DB
{
    public class DatabaseConnection
    {
        private SQLiteConnection connection;
        private readonly string databasePath;

        // Constructor
        public DatabaseConnection()
        {
            // Evitar ejecución en tiempo de diseño
            if (IsInDesignMode())
            {
                Console.WriteLine("Modo diseño detectado, omitiendo inicialización de DatabaseConnection.");
                return;
            }

            // Establecer ruta de la base de datos
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "Ofelia_DB_Sqlite", "baseSqlite.db");
            Console.WriteLine($"Ruta de la base de datos: {databasePath}");

            // Verifica si el archivo existe (por si acaso lo copiaste en otra carpeta en el equipo)
            if (File.Exists(databasePath))
            {
                Console.WriteLine("Base de datos encontrada en: " + databasePath);
            }
            else
            {
                Console.WriteLine("La base de datos no fue encontrada en la ruta relativa especificada.");
            }


            // Inicializar la conexión
            connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
        }

        // Método para verificar si está en modo diseño
        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        // Propiedad para obtener la conexión
        public SQLiteConnection Connection
        {
            get
            {
                // Inicializar la conexión solo si es necesario
                if (connection == null)
                {
                    connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
                }
                return connection;
            }
        }

        /// <summary>
        /// Abre la conexión a la base de datos
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                if (connection?.State == ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta con éxito.");
                //    MensajeGeneral.Mostrar("Conexión abierta con éxito.",MensajeGeneral.TipoMensaje.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                
            }
        }

        /// <summary>
        /// Cierra la conexión a la base de datos
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
           
            }
        }

        /// <summary>
        /// Ejecuta una consulta de lectura (SELECT)
        /// </summary>
        public SQLiteDataReader ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();  // Abrir la conexión antes de ejecutar la consulta
                SQLiteCommand command = new SQLiteCommand(query, connection);
                return command.ExecuteReader(); // Retorna un lector de datos
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Ejecuta una consulta de escritura (INSERT, UPDATE, DELETE)
        /// </summary>
        public int ExecuteNonQuery(string query)
        {
            try
            {
                OpenConnection();  // Abrir la conexión antes de ejecutar la consulta
                SQLiteCommand command = new SQLiteCommand(query, connection);
                return command.ExecuteNonQuery(); // Retorna el número de filas afectadas
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                return -1;
            }
            finally
            {
                CloseConnection(); // Asegúrate de cerrar la conexión después de ejecutar la consulta
            }
        }
    }
}