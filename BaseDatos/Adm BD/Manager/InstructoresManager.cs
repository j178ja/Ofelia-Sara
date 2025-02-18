using BaseDatos.Adm_BD.Modelos;
using System.Data.SQLite;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.ExtendedProperties;
using System.Data;

namespace BaseDatos.Adm_BD.Manager
{
    public class InstructoresManager
    {
        private readonly DatabaseConnection dbConnection;

        public InstructoresManager()
        {
            dbConnection = new DatabaseConnection();  // Obtiene la instancia de la conexión SQLite
        }

        /// <summary>
        /// Insertar un nuevo instructor en la base de datos
        /// </summary>
        public void InsertInstructor(float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "INSERT INTO Instructores (legajo, subescalafon, jerarquia, nombre, apellido, dependencia, funcion) VALUES (@legajo, @subescalafon, @jerarquia, @nombre, @apellido, @dependencia, @funcion)";

            using (var connection = dbConnection.Connection)  // Utiliza la propiedad Connection de DatabaseConnection
            {
                dbConnection.OpenConnection();  // Abre la conexión
                using (var command = new SQLiteCommand(query, connection))
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
                        command.ExecuteNonQuery();  // Ejecutar la consulta
                    }
                    catch (Exception ex)
                    {
                        MensajeGeneral.Mostrar($"Error al insertar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                    }
                    finally
                    {
                        dbConnection.CloseConnection();  // Cerrar la conexión
                    }
                }
            }
        }

        /// <summary>
        /// Obtener todos los instructores desde la base de datos
        /// </summary>
        public List<Instructores> GetInstructors()
        {
            List<Instructores> instructores = [];
            string query = "SELECT * FROM Instructores";

            dbConnection.OpenConnection();  // Abrir la conexión
            using (var command = new SQLiteCommand(query, dbConnection.Connection))  // Utilizar SQLiteCommand
            {
                using var reader = command.ExecuteReader();  // Ejecutar la consulta
                while (reader.Read())
                {
                    instructores.Add(new Instructores
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
            dbConnection.CloseConnection();  // Cerrar la conexión
            return instructores;
        }

        /// <summary>
        /// Actualizar un instructor existente
        /// </summary>
        public void UpdateInstructor(int id, float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "UPDATE Instructores SET legajo = @legajo, subescalafon = @subescalafon, jerarquia = @jerarquia, nombre = @nombre, apellido = @apellido, dependencia = @dependencia, funcion = @funcion WHERE ID = @id";

            dbConnection.OpenConnection();  // Abrir la conexión
            using var command = new SQLiteCommand(query, dbConnection.Connection);  // Utilizar SQLiteCommand
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
                command.ExecuteNonQuery();  // Ejecutar la consulta
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al actualizar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                dbConnection.CloseConnection();  // Cerrar la conexión
            }
        }

        /// <summary>
        /// Eliminar un instructor
        /// </summary>
        public void DeleteInstructor(int id)
        {
            string query = "DELETE FROM Instructores WHERE ID = @id";

            dbConnection.OpenConnection();  // Abrir la conexión
            using var command = new SQLiteCommand(query, dbConnection.Connection);  // Utilizar SQLiteCommand
            command.Parameters.AddWithValue("@id", id);

            try
            {
                command.ExecuteNonQuery();  // Ejecutar la consulta
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al eliminar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                dbConnection.CloseConnection();  // Cerrar la conexión
            }
        }
    }
}
