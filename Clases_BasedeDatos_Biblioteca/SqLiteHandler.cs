using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class SQLiteHandler
{
    private string _connectionString;

    public SQLiteHandler(string databasePath)
    {
        _connectionString = $"Data Source={databasePath};Version=3;";
    }

    public void InsertarDatosEnBaseDeDatos(List<Dictionary<string, string>> datos, string nombreTabla)
    {
        using (SQLiteConnection conexion = new SQLiteConnection(_connectionString))
        {
            conexion.Open();

            using (SQLiteTransaction transaction = conexion.BeginTransaction())
            {
                foreach (var fila in datos)
                {
                    string columnas = string.Join(",", fila.Keys);
                    string valores = string.Join(",", fila.Values);

                    string query = $"INSERT INTO {nombreTabla} ({columnas}) VALUES ({valores})";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
        }
    }
}
