using BaseDatos.Adm_BD.Modelos;
using MySql.Data.MySqlClient;
using Ofelia_Sara.BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.BaseDatos;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BaseDatos.Adm_BD.Manager
{
    public class ComisariasManager
    {
        private readonly DatabaseConnection dbConnection;

        // Constructor que inicializa DatabaseConnection y evita ejecución en tiempo de diseño
        public ComisariasManager()
        {
           
            // Obtener la conexión desde BloqueadorTiempoDiseño
            dbConnection = BloqueadorTiempoDiseño.GetDatabaseConnection();

            // Si dbConnection es null, lanza una excepción con un mensaje claro
            if (dbConnection == null)
            {
                throw new InvalidOperationException("DatabaseConnection no pudo inicializarse. Verifica que la aplicación no esté en modo diseño y que la configuración de la base de datos sea válida.");
            }
        }




        // Método para insertar una nueva comisaría en la base de datos
        public void InsertComisaria(string nombre, string direccion, string localidad, string partido)
        {
            string query = "INSERT INTO Comisarias (nombre, direccion, Localidad, Partido) VALUES (@nombre, @direccion, @localidad, @partido)";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
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

        // Método para obtener todas las comisarías desde la base de datos
        public List<Comisaria> GetComisarias()
        {
            List<Comisaria> comisarias = new List<Comisaria>();
            string query = "SELECT * FROM Comisarias";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comisarias.Add(new Comisaria
                        {
                            Id = reader.GetInt32("ID"),
                            Nombre = reader.GetString("nombre"),
                            Direccion = reader.GetString("direccion"),
                            Localidad = reader.GetString("Localidad"),
                            Partido = reader.GetString("Partido")
                        });
                    }
                }
            }
            dbConnection.CloseConnection();
            return comisarias;
        }

        // Método para actualizar una comisaría existente
        public void UpdateComisaria(int id, string nombre, string direccion, string localidad, string partido)
        {
            string query = "UPDATE Comisarias SET nombre = @nombre, direccion = @direccion, Localidad = @localidad, Partido = @partido WHERE ID = @id";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
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

        // Método para eliminar una comisaría
        public void DeleteComisaria(int id)
        {
            string query = "DELETE FROM Comisarias WHERE ID = @id";

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
