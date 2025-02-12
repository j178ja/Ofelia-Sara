using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;
using Ofelia_Sara.Formularios.General.Mensajes;

public class DataManager<T>
{
    private DatabaseConnection dbConnection;

    public DataManager()
    {
        // Evitar ejecución en tiempo de diseño
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            return; // No inicializar nada en modo diseño
        }

        dbConnection = new DatabaseConnection();
    }

    public void Create(string query, params SQLiteParameter[] parameters)
    {
        try
        {
            dbConnection.OpenConnection(); // Asegura que la conexión esté abierta
            using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection.Connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters); // Añadir parámetros si los hay
                }

                cmd.ExecuteNonQuery(); // Ejecuta la consulta
            }
        }
        catch (Exception ex)
        {
            MensajeGeneral.Mostrar($"Error al crear registro: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    public DataTable Read(string query, params SQLiteParameter[] parameters)
    {
        DataTable dt = new DataTable();

        try
        {
            dbConnection.OpenConnection();

            using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection.Connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters); // Añadir parámetros si los hay
                }

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt); // Llenar el DataTable con los resultados
                }
            }
        }
        catch (Exception ex)
        {
            MensajeGeneral.Mostrar($"Error al leer datos: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return dt;
    }

    public void Update(string query, params SQLiteParameter[] parameters)
    {
        try
        {
            dbConnection.OpenConnection();

            using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection.Connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters); // Añadir parámetros si los hay
                }

                cmd.ExecuteNonQuery(); // Ejecuta la consulta para actualizar
            }
        }
        catch (Exception ex)
        {
            MensajeGeneral.Mostrar($"Error al actualizar datos: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    public void Delete(string query, params SQLiteParameter[] parameters)
    {
        try
        {
            dbConnection.OpenConnection();

            using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection.Connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters); // Añadir parámetros si los hay
                }

                cmd.ExecuteNonQuery(); // Ejecuta la consulta para eliminar
            }
        }
        catch (Exception ex)
        {
            MensajeGeneral.Mostrar($"Error al eliminar datos: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }
}
