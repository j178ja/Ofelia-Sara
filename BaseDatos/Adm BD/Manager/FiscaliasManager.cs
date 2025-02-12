using BaseDatos.Adm_BD.Modelos;
using System.Data.SQLite;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace BaseDatos.Adm_BD
{
    public class FiscaliasManager
    {
        private readonly SQLiteConnection dbConnection;

        public FiscaliasManager(SQLiteConnection connection = null)
        {
            // Si no se pasa una conexión externa, se inicializa una nueva conexión de SQLite
            dbConnection = connection ?? new SQLiteConnection("Data Source=your_database_file_path;Version=3;");
        }

        /// <summary>
        /// obtener todas las fiscalías
        /// </summary>
        /// <returns></returns>
        public List<Fiscalia> GetFiscalias()
        {
            List<Fiscalia> fiscalias = new List<Fiscalia>();
            string query = "SELECT Id, Ufid, AgenteFiscal, Localidad, DeptoJudicial FROM Fiscalia";

            dbConnection.Open();
            using (var command = new SQLiteCommand(query, dbConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fiscalia fiscalia = new Fiscalia
                        {
                            Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32("Id"),
                            Ufid = reader.IsDBNull(reader.GetOrdinal("Ufid")) ? string.Empty : reader.GetString("Ufid"),
                            AgenteFiscal = reader.IsDBNull(reader.GetOrdinal("AgenteFiscal")) ? string.Empty : reader.GetString("AgenteFiscal"),
                            Localidad = reader.IsDBNull(reader.GetOrdinal("Localidad")) ? string.Empty : reader.GetString("Localidad"),
                            DeptoJudicial = reader.IsDBNull(reader.GetOrdinal("DeptoJudicial")) ? string.Empty : reader.GetString("DeptoJudicial")

                        };
                        fiscalias.Add(fiscalia);
                    }
                }
            }
            dbConnection.Close();
            return fiscalias;
        }

    
        /// <summary>
        /// insertar una nueva fiscalía
        /// </summary>
        /// <param name="fiscalia"></param>
        public void InsertFiscalia(Fiscalia fiscalia)
        {
            string query = "INSERT INTO Fiscalia (Ufid, AgenteFiscal, Localidad, DeptoJudicial) VALUES (@Ufid, @AgenteFiscal, @Localidad, @DeptoJudicial)";

            try
            {
                dbConnection.Open();
                using (var command = new SQLiteCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("@Ufid", fiscalia.Ufid);
                    command.Parameters.AddWithValue("@AgenteFiscal", fiscalia.AgenteFiscal);
                    command.Parameters.AddWithValue("@Localidad", fiscalia.Localidad);
                    command.Parameters.AddWithValue("@DeptoJudicial", fiscalia.DeptoJudicial);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al insertar la fiscalía: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                dbConnection.Close();
            }
        }


        /// <summary>
        /// actualizar una fiscalía existente
        /// </summary>
        /// <param name="fiscalia"></param>
        public void UpdateFiscalia(Fiscalia fiscalia)
        {
            string query = "UPDATE Fiscalia SET Ufid = @Ufid, AgenteFiscal = @AgenteFiscal, Localidad = @Localidad, DeptoJudicial = @DeptoJudicial WHERE Id = @Id";

            dbConnection.Open();
            using (var command = new SQLiteCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@Id", fiscalia.Id);
                command.Parameters.AddWithValue("@Ufid", fiscalia.Ufid);
                command.Parameters.AddWithValue("@AgenteFiscal", fiscalia.AgenteFiscal);
                command.Parameters.AddWithValue("@Localidad", fiscalia.Localidad);
                command.Parameters.AddWithValue("@DeptoJudicial", fiscalia.DeptoJudicial);

                command.ExecuteNonQuery();
            }
            dbConnection.Close();
        }

         
        /// <summary>
        /// eliminar una fiscalía por Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFiscalia(int id)
        {
            string query = "DELETE FROM Fiscalia WHERE Id = @Id";

            dbConnection.Open();
            using (var command = new SQLiteCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
}
