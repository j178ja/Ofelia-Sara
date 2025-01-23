using BaseDatos.Adm_BD.Modelos;
using MySql.Data.MySqlClient;
using Ofelia_Sara.BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.BaseDatos;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;

namespace BaseDatos.Adm_BD.Manager
{

    public class SecretariosManager
    {
        private readonly DatabaseConnection dbConnection;

        public SecretariosManager()
        {
            dbConnection = BloqueadorTiempoDiseño.GetDatabaseConnection();
        }
        // Método para insertar un nuevo SECRETARIO en la base de datos
        public void InsertSecretario(float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "INSERT INTO Secretario (legajo, subescalafon, jerarquia, nombre, apellido, dependencia, funcion) VALUES (@legajo, @subescalafon, @jerarquia, @nombre, @apellido, @dependencia, @funcion)";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
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

        //metodo para acceder a los datos de tabla SECRETARIO
        public List<Secretario> GetSecretarios()
        {
            List<Secretario> secretarios = new List<Secretario>();
            string query = "SELECT * FROM Secretario";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var secretario = new Secretario()
                        {
                            Id = reader.GetInt32("ID"),
                            Legajo = reader.IsDBNull(reader.GetOrdinal("legajo")) ? 0 : reader.GetInt32("legajo"), // Manejo de nulos
                            Subescalafon = reader.IsDBNull(reader.GetOrdinal("subescalafon")) ? string.Empty : reader.GetString("subescalafon"), // Manejo de nulos
                            Jerarquia = reader.IsDBNull(reader.GetOrdinal("jerarquia")) ? string.Empty : reader.GetString("jerarquia"), // Manejo de nulos
                            Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString("nombre"), // Manejo de nulos
                            Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString("apellido"), // Manejo de nulos
                            Dependencia = reader.IsDBNull(reader.GetOrdinal("dependencia")) ? string.Empty : reader.GetString("dependencia"), // Manejo de nulos
                            Funcion = reader.IsDBNull(reader.GetOrdinal("funcion")) ? string.Empty : reader.GetString("funcion") // Manejo de nulos
                        };
                        secretarios.Add(secretario);
                    }
                }
            }
            dbConnection.CloseConnection();

            return secretarios;


        }

        // Método para actualizar un SECRETARIO existente
        public void UpdateSecretarios(int id, float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "UPDATE Secretario SET legajo = @legajo, subescalafon = @subescalafon, jerarquia = @jerarquia, nombre = @nombre, apellido = @apellido, dependencia = @dependencia, funcion = @funcion WHERE ID = @id";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
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


        // Método para eliminar un secretario
        public void DeleteSecretario(int id)
        {
            string query = "DELETE FROM Secretario WHERE ID = @id";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
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