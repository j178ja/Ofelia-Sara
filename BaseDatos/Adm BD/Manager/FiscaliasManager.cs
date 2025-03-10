﻿using BaseDatos.Adm_BD.Modelos;
using System.Data.SQLite;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DocumentFormat.OpenXml.ExtendedProperties;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;

namespace BaseDatos.Adm_BD.Manager
{
    public class FiscaliasManager
    {

        private readonly DatabaseConnection dbConnection;
        
        public FiscaliasManager()
        {
            dbConnection = new DatabaseConnection();
            // Si dbConnection es null, lanza una excepción con un mensaje claro
            if (dbConnection == null)
            {
                throw new InvalidOperationException("DatabaseConnection no pudo inicializarse. Verifica que la aplicación no esté en modo diseño y que la configuración de la base de datos sea válida.");
            }
        }

     
        /// <summary>
        /// obtener todas las fiscalías
        /// </summary>
        /// <returns></returns>
        public List<Fiscalias> GetFiscalias()
        {
            List<Fiscalias> fiscalias = [];
           string query = "SELECT Id, Ufid, AgenteFiscal, Localidad, DeptoJudicial FROM Fiscalias";
          
            dbConnection.OpenConnection();
            using (var command = new SQLiteCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fiscalias fiscalia = new()
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
            dbConnection.CloseConnection();
            return fiscalias;
        }


        /// <summary>
        /// insertar una nueva fiscalía
        /// </summary>
        /// <param name="fiscalia"></param>
        public void InsertFiscalia(Fiscalias fiscalia)
        {
            string query = "INSERT INTO Fiscalias (Ufid, AgenteFiscal, Localidad, DeptoJudicial) VALUES (@Ufid, @AgenteFiscal, @Localidad, @DeptoJudicial)";

            try
            {
                dbConnection.OpenConnection();
                using (var command = new SQLiteCommand(query, dbConnection.Connection))
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
                dbConnection.CloseConnection();
            }
        }



        /// <summary>
        /// actualizar una fiscalía existente
        /// </summary>
        /// <param name="fiscalia"></param>
        public void UpdateFiscalia(Fiscalias fiscalia)
        {
            string query = "UPDATE Fiscalias SET Ufid = @Ufid, AgenteFiscal = @AgenteFiscal, Localidad = @Localidad, DeptoJudicial = @DeptoJudicial WHERE Id = @Id";

            try
            {
                dbConnection.OpenConnection();
                using (var command = new SQLiteCommand(query, dbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Id", fiscalia.Id);
                    command.Parameters.AddWithValue("@Ufid", fiscalia.Ufid);
                    command.Parameters.AddWithValue("@AgenteFiscal", fiscalia.AgenteFiscal);
                    command.Parameters.AddWithValue("@Localidad", fiscalia.Localidad);
                    command.Parameters.AddWithValue("@DeptoJudicial", fiscalia.DeptoJudicial);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al actualizar la fiscalía: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }



        /// <summary>
        /// eliminar una fiscalía por Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFiscalia(int id)
        {
            string query = "DELETE FROM Fiscalias WHERE Id = @Id";

            try
            {
                dbConnection.OpenConnection();
                using (var command = new SQLiteCommand(query, dbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar("Error al eliminar la fiscalía: " + ex.Message, MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

    }
}
