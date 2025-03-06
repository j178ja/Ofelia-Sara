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
                        Legajo = reader.GetInt32("Legajo"),
                        Subescalafon = reader.GetString("Subescalafon"),
                        Jerarquia = reader.GetString("Jerarquia"),
                        Nombre = reader.GetString("Nombre"),
                        Apellido = reader.GetString("Apellido"),
                        Dependencia = reader.GetString("Dependencia"),
                        Funcion = reader.GetString("Funcion")
                    });
                }
            }
            dbConnection.CloseConnection();  // Cerrar la conexión
            return instructores;
        }

        /// <summary>
        /// Actualizar un instructor existente
        /// </summary>
        public void UpdateInstructor(int Id, float? legajo, string subescalafon, string jerarquia, string nombre, string apellido, string dependencia, string funcion)
        {
            string query = "UPDATE Instructores SET legajo = @Legajo, subescalafon = @Subescalafon, jerarquia = @Jerarquia, nombre = @Nombre, apellido = @Apellido, dependencia = @Dependencia, funcion = @Funcion WHERE ID = @id";

            dbConnection.OpenConnection();  // Abrir la conexión
            using var command = new SQLiteCommand(query, dbConnection.Connection);  // Utilizar SQLiteCommand
                                                                                    // Usar DBNull.Value si legajo es null
            command.Parameters.AddWithValue("@Legajo", (object)legajo ?? DBNull.Value);
            command.Parameters.AddWithValue("@Subescalafon", subescalafon.Trim());
            command.Parameters.AddWithValue("@Jerarquia", jerarquia.Trim());
            command.Parameters.AddWithValue("@Nombre", nombre.Trim());
            command.Parameters.AddWithValue("@Apellido", apellido.Trim());
            command.Parameters.AddWithValue("@Dependencia", dependencia.Trim());
            command.Parameters.AddWithValue("@Funcion", funcion.Trim());
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
