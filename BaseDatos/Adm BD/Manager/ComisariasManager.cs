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
        /// Insertar una nueva comisaría en la base de datos
        /// </summary>
        public void InsertComisaria(string nombre, string direccion, string localidad, string partido)
        {
            string query = "INSERT INTO Comisarias (nombre, direccion, Localidad, Partido) VALUES (@nombre, @direccion, @localidad, @partido)";

            try
            {
                dbConnection.OpenConnection();
                using (var command = new SQLiteCommand(query, dbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre.Trim());
                    command.Parameters.AddWithValue("@direccion", direccion.Trim());
                    command.Parameters.AddWithValue("@localidad", localidad.Trim());
                    command.Parameters.AddWithValue("@partido", partido.Trim());

                    command.ExecuteNonQuery();
                }
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

        /// <summary>
        /// Obtener todas las comisarías desde la base de datos
        /// </summary>
        public List<Comisarias> GetComisarias()
        {
            List<Comisarias> comisarias = [];//lista de comisarias
            string query = "SELECT * FROM Comisarias";

            try
            {
                // Abrir la conexión
                dbConnection.OpenConnection();

                using (var command = new SQLiteCommand(query, dbConnection.Connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comisarias.Add(new Comisarias
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                Localidad = reader.GetString(reader.GetOrdinal("Localidad")),
                                Partido = reader.GetString(reader.GetOrdinal("Partido"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al obtener comisarias: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                // Asegurarse de cerrar la conexión al finalizar la operación
                dbConnection.CloseConnection();
            }

            return comisarias;
        }



        /// <summary>
        /// Actualizar una comisaría existente
        /// </summary>
        public void UpdateComisaria(int id, string nombre, string direccion, string localidad, string partido)
        {
            string query = "UPDATE Comisarias SET nombre = @nombre, direccion = @direccion, Localidad = @localidad, Partido = @partido WHERE ID = @id";

            try
            {
                dbConnection.OpenConnection();
                using (var command = new SQLiteCommand(query, dbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre.Trim());
                    command.Parameters.AddWithValue("@direccion", direccion.Trim());
                    command.Parameters.AddWithValue("@localidad", localidad.Trim());
                    command.Parameters.AddWithValue("@partido", partido.Trim());

                    command.ExecuteNonQuery();
                }
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

        /// <summary>
        /// Eliminar una comisaría
        /// </summary>
        public void DeleteComisaria(int id)
        {
            string query = "DELETE FROM Comisarias WHERE ID = @id";

            try
            {
                dbConnection.OpenConnection();
                using (var command = new SQLiteCommand(query, dbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
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
