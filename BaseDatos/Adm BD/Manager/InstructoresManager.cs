using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Formularios.General.Mensajes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Ofelia_Sara.BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.BaseDatos;

namespace BaseDatos.Adm_BD.Manager
{
    public class InstructoresManager
    {
        private readonly DatabaseConnection dbConnection;

        public InstructoresManager()
        {
            dbConnection = BloqueadorTiempoDiseño.GetDatabaseConnection();
        }

        // Método para insertar un nuevo instructor en la base de datos
        public void InsertInstructor(float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "INSERT INTO Instructor (legajo, subescalafon, jerarquia, nombre, apellido, dependencia, funcion) VALUES (@legajo, @subescalafon, @jerarquia, @nombre, @apellido, @dependencia, @funcion)";

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
                    //  MensajeGeneral.Mostrar($"{rowsAffected} fila(s) insertada(s) en la base de datos.", MensajeGeneral.TipoMensaje.Error);
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }


        // Método para obtener todos los instructores desde la base de datos
        public List<Instructor> GetInstructors()
        {
            List<Instructor> instructores = new List<Instructor>();
            string query = "SELECT * FROM Instructor";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        instructores.Add(new Instructor
                        {
                            Id = reader.GetInt32("ID"),
                            Legajo = reader.GetInt32("legajo"),
                            Subescalafon = reader.GetString("subescalafon"),
                            Jerarquia = reader.GetString("jerarquia"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            Dependencia = reader.GetString("dependencia"),
                            Funcion = reader.GetString("funcion")
                        });
                    }
                }
            }
            dbConnection.CloseConnection();
            return instructores;
        }

        // Método para actualizar un instructor existente
        public void UpdateInstructor(int id, float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "UPDATE Instructor SET legajo = @legajo, subescalafon = @subescalafon, jerarquia = @jerarquia, nombre = @nombre, apellido = @apellido, dependencia = @dependencia, funcion = @funcion WHERE ID = @id";

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
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al actualizar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        // Método para eliminar un instructor
        public void DeleteInstructor(int id)
        {
            string query = "DELETE FROM Instructor WHERE ID = @id";

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
                    MensajeGeneral.Mostrar($"Error al eliminar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }
    }
}
