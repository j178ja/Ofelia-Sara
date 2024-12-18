using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Ofelia_Sara.Clases.BaseDatos;


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
        public void Create(string query)
        {
            dbConnection.OpenConnection(); // Asegura que la conexión esté abierta
            using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Read(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return dt;
        }


        public void Update(string query)
        {
            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        public void Delete(string query)
        {
            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

    }
