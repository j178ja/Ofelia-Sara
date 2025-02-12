using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using System.Data.SQLite;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;

namespace BaseDatos.Adm_BD.Manager
{
    public class ComisariasManager
    {
        private readonly DatabaseConnection dbConnection;

        // Constructor que inicializa DatabaseConnection y evita ejecución en tiempo de diseño
        public ComisariasManager()
        {

            dbConnection = new DatabaseConnection();  // Obtiene la instancia de la conexión SQLite

            // Si dbConnection es null, lanza una excepción con un mensaje claro
            if (dbConnection == null)
            {
                throw new InvalidOperationException("DatabaseConnection no pudo inicializarse. Verifica que la aplicación no esté en modo diseño y que la configuración de la base de datos sea válida.");
            }
        }



        /// <summary>
        ///  insertar una nueva comisaría en la base de datos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="direccion"></param>
        /// <param name="localidad"></param>
        /// <param name="partido"></param>
        public void InsertComisaria(string nombre, string direccion, string localidad, string partido)
        {
            string query = "INSERT INTO Comisarias (nombre, direccion, Localidad, Partido) VALUES (@nombre, @direccion, @localidad, @partido)";

            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@nombre", nombre.Trim());
                command.Parameters.AddWithValue("@direccion", direccion.Trim());
                command.Parameters.AddWithValue("@localidad", localidad.Trim());
                command.Parameters.AddWithValue("@partido", partido.Trim());

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar comisaría: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        
        /// <summary>
        ///  obtener todas las comisarías desde la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Comisaria> GetComisarias()
        {
            List<Comisaria> comisarias = new List<Comisaria>();
            string query = "SELECT * FROM Comisarias";

            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comisarias.Add(new Comisaria
                        {
                            Id = reader.IsDBNull(reader.GetOrdinal("ID")) ? 0 : reader.GetInt32("ID"),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString("nombre"),
                            Direccion = reader.IsDBNull(reader.GetOrdinal("direccion")) ? string.Empty : reader.GetString("direccion"),
                            Localidad = reader.IsDBNull(reader.GetOrdinal("Localidad")) ? string.Empty : reader.GetString("Localidad"),
                            Partido = reader.IsDBNull(reader.GetOrdinal("Partido")) ? string.Empty : reader.GetString("Partido")

                        });
                    }
                }
            }
            dbConnection.CloseConnection();
            return comisarias;
        }

        /// <summary>
        /// actualizar una comisaría existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="direccion"></param>
        /// <param name="localidad"></param>
        /// <param name="partido"></param>
        public void UpdateComisaria(int id, string nombre, string direccion, string localidad, string partido)
        {
            string query = "UPDATE Comisarias SET nombre = @nombre, direccion = @direccion, Localidad = @localidad, Partido = @partido WHERE ID = @id";

            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", nombre.Trim());
                command.Parameters.AddWithValue("@direccion", direccion.Trim());
                command.Parameters.AddWithValue("@localidad", localidad.Trim());
                command.Parameters.AddWithValue("@partido", partido.Trim());

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al actualizar comisaría: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// eliminar una comisaría
        /// </summary>
        /// <param name="id"></param>
        public void DeleteComisaria(int id)
        {
            string query = "DELETE FROM Comisarias WHERE ID = @id";

            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al eliminar comisaría: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }
    }
}
