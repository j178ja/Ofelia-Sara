using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BaseDatos.Adm_BD.Manager
{

    public class SecretariosManager
    {
        private readonly DatabaseConnection dbConnection;

        public SecretariosManager()
        {
            dbConnection = new DatabaseConnection();  // Obtiene la instancia de la conexión SQLite
        }
       
        /// <summary>
        /// insertar un nuevo SECRETARIO en la base de datos
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="subescalafon"></param>
        /// <param name="jerarquia"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dependencia"></param>
        /// <param name="funcion"></param>
        public void InsertSecretario(float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "INSERT INTO Secretario (legajo, subescalafon, jerarquia, nombre, apellido, dependencia, funcion) VALUES (@legajo, @subescalafon, @jerarquia, @nombre, @apellido, @dependencia, @funcion)";

            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                // Usar DBNull.Value si legajo es null
                command.Parameters.AddWithValue("@legajo", (object)legajo ?? DBNull.Value);
                command.Parameters.AddWithValue("@subescalafon", subescalafon.Trim());
                command.Parameters.AddWithValue("@jerarquia", jerarquia.Trim());
                command.Parameters.AddWithValue("@nombre", nombre.Trim());
                command.Parameters.AddWithValue("@apellido", apellido.Trim());
                command.Parameters.AddWithValue("@dependencia", dependencia.Trim());
                command.Parameters.AddWithValue("@funcion", funcion.Trim());

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    // MensajeGeneral.Mostrar($"{rowsAffected} fila(s) insertada(s) en la base de datos.", MensajeGeneral.TipoMensaje.Exito);
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar secretario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        
        /// <summary>
        /// acceder a los datos de tabla SECRETARIO
        /// </summary>
        /// <returns></returns>
        public List<Secretarios> GetSecretarios()
        {
            List<Secretarios> secretarios = new List<Secretarios>();
            string query = "SELECT * FROM Secretario";

            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var secretario = new Secretarios()
                        {
                            Id = reader.IsDBNull(reader.GetOrdinal("ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID")),

                            Legajo = reader.IsDBNull(reader.GetOrdinal("legajo")) ? 0 : reader.GetInt32(reader.GetOrdinal("legajo")),// Manejo de nulos
                            Subescalafon = reader.IsDBNull(reader.GetOrdinal("subescalafon")) ? string.Empty : reader.GetString(reader.GetOrdinal("subescalafon")),
                            Jerarquia = reader.IsDBNull(reader.GetOrdinal("jerarquia")) ? string.Empty : reader.GetString(reader.GetOrdinal("jerarquia")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString(reader.GetOrdinal("apellido")),
                            Dependencia = reader.IsDBNull(reader.GetOrdinal("dependencia")) ? string.Empty : reader.GetString(reader.GetOrdinal("dependencia")),
                            Funcion = reader.IsDBNull(reader.GetOrdinal("funcion")) ? string.Empty : reader.GetString(reader.GetOrdinal("funcion"))

                        };
                        secretarios.Add(secretario);
                    }
                }
            }
            dbConnection.CloseConnection();

            return secretarios;


        }

        
        /// <summary>
        /// actualizar un SECRETARIO existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="legajo"></param>
        /// <param name="subescalafon"></param>
        /// <param name="jerarquia"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dependencia"></param>
        /// <param name="funcion"></param>
        public void UpdateSecretarios(int id, float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "UPDATE Secretario SET legajo = @legajo, subescalafon = @subescalafon, jerarquia = @jerarquia, nombre = @nombre, apellido = @apellido, dependencia = @dependencia, funcion = @funcion WHERE ID = @id";

            dbConnection.OpenConnection();
            using (var command = new  SQLiteCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@id", id);

                // Usar DBNull.Value si legajo es null
                command.Parameters.AddWithValue("@legajo", (object)legajo ?? DBNull.Value);
                command.Parameters.AddWithValue("@subescalafon", subescalafon.Trim());
                command.Parameters.AddWithValue("@jerarquia", jerarquia.Trim());
                command.Parameters.AddWithValue("@nombre", nombre.Trim());
                command.Parameters.AddWithValue("@apellido", apellido.Trim());
                command.Parameters.AddWithValue("@dependencia", dependencia.Trim());
                command.Parameters.AddWithValue("@funcion", funcion.Trim());

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al actualizar secretario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }


        /// <summary>
        /// eliminar un secretario
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSecretario(int id)
        {
            string query = "DELETE FROM Secretario WHERE ID = @id";

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
                    MensajeGeneral.Mostrar($"Error al eliminar secretario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }
    }
}