﻿using BaseDatos.Adm_BD.Modelos;
using MySql.Data.MySqlClient;
using Ofelia_Sara.BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BaseDatos.Adm_BD
{
    public class FiscaliasManager
    {
        private readonly MySqlConnection dbConnection;

        public FiscaliasManager(MySqlConnection connection = null)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; // No inicializar nada en modo de diseño
            }

            dbConnection = connection ?? BloqueadorTiempoDiseño.GetDatabaseConnection()?.Connection;
        }
        // Método para obtener todas las fiscalías
        public List<Fiscalia> GetFiscalias()
        {
            List<Fiscalia> fiscalias = new List<Fiscalia>();
            string query = "SELECT Id, Ufid, AgenteFiscal, Localidad, DeptoJudicial FROM Fiscalia";

            dbConnection.Open();
            using (var command = new MySqlCommand(query, dbConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fiscalia fiscalia = new Fiscalia
                        {
                            Id = reader.GetInt32("Id"),
                            Ufid = reader.GetString("Ufid"),
                            AgenteFiscal = reader.GetString("AgenteFiscal"),
                            Localidad = reader.GetString("Localidad"),
                            DeptoJudicial = reader.GetString("DeptoJudicial")
                        };
                        fiscalias.Add(fiscalia);
                    }
                }
            }
            dbConnection.Close();
            return fiscalias;
        }

        // Método para insertar una nueva fiscalía
        public void InsertFiscalia(Fiscalia fiscalia)
        {
            string query = "INSERT INTO Fiscalia (Ufid, AgenteFiscal, Localidad, DeptoJudicial) VALUES (@Ufid, @AgenteFiscal, @Localidad, @DeptoJudicial)";

            try
            {
                dbConnection.Open();
                using (var command = new MySqlCommand(query, dbConnection))
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


        // Método para actualizar una fiscalía existente
        public void UpdateFiscalia(Fiscalia fiscalia)
        {
            string query = "UPDATE Fiscalia SET Ufid = @Ufid, AgenteFiscal = @AgenteFiscal, Localidad = @Localidad, DeptoJudicial = @DeptoJudicial WHERE Id = @Id";

            dbConnection.Open();
            using (var command = new MySqlCommand(query, dbConnection))
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

        // Método para eliminar una fiscalía por Id
        public void DeleteFiscalia(int id)
        {
            string query = "DELETE FROM Fiscalia WHERE Id = @Id";

            dbConnection.Open();
            using (var command = new MySqlCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
}
