using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;



namespace Ofelia_Sara.Clases.BaseDatos.Ofelia_DB
    {
        public class DataInserter(DataManager<DatabaseConnection> dbManager)
    {
            protected readonly DataManager<DatabaseConnection> dbManager = dbManager; // Usar DataManager con tipo DatabaseConnection

        public void InsertarUsuario(string jerarquia, string escalafon, string nombre, string apellido, double legajo, string nombreUsuario, string contrasena)
            {
                try
                {
                    string query = @"
                    INSERT INTO Usuarios (Jerarquia, Escalafon, Nombre, Apellido, Legajo, Nombre_Usuario, Contrasena)
                    VALUES (@Jerarquia, @Escalafon, @Nombre, @Apellido, @Legajo, @Nombre_Usuario, @Contrasena)";

                    var parameters = new SQLiteParameter[]
                    {
                    new("@Jerarquia", jerarquia),
                    new("@Escalafon", escalafon),
                    new("@Nombre", nombre),
                    new("@Apellido", apellido),
                    new("@Legajo", legajo),
                    new("@Nombre_Usuario", nombreUsuario),
                    new("@Contrasena", contrasena)
                    };

                    dbManager.Create(query, parameters); // Usar el método Create de DataManager
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar usuario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }

        public void InsertarInstructor(string jerarquia, string escalafon, string nombre, string apellido, double legajo, byte[] firmaDigitalizada)
            {
                try
                {
                    string query = @"
                    INSERT INTO Instructor (Jerarquia, Escalafon, Nombre, Apellido, Legajo, Firma_Digitalizada)
                    VALUES (@Jerarquia, @Escalafon, @Nombre, @Apellido, @Legajo, @Firma_Digitalizada)";

                    var parameters = new SQLiteParameter[]
                    {
                    new("@Jerarquia", jerarquia),
                    new("@Escalafon", escalafon),
                    new("@Nombre", nombre),
                    new("@Apellido", apellido),
                    new("@Legajo", legajo),
                    new("@Firma_Digitalizada", firmaDigitalizada)
                    };

                    dbManager.Create(query, parameters); // Usar el método Create de DataManager
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }


        public static void GuardarSecretario(string jerarquia, string escalafon, string nombre, string apellido, double legajo, string funcion, byte[] firmaDigitalizada)
        {
            try
            {
                var dbManager = new DatabaseConnection();

                // Usamos dbManager.Connection para obtener la conexión
                using var connection = dbManager.Connection;
                using var command = connection.CreateCommand();
                command.CommandText = @"
                INSERT INTO Secretario (Jerarquia, Escalafon, Nombre, Apellido, Legajo, Funcion, FirmaDigitalizada)
                VALUES (@Jerarquia, @Escalafon, @Nombre, @Apellido, @Legajo, @Funcion, @FirmaDigitalizada)";

                command.Parameters.AddWithValue("@Jerarquia", jerarquia);
                command.Parameters.AddWithValue("@Escalafon", escalafon);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Legajo", legajo);
                command.Parameters.AddWithValue("@Funcion", funcion);
                command.Parameters.AddWithValue("@FirmaDigitalizada", firmaDigitalizada ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al guardar secretario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        public static void GuardarFiscalia(string ufid, string agenteFiscal, string localidad, string deptoJudicial)
        {
            try
            {
                var dbManager = new DatabaseConnection();

                // Usamos dbManager.Connection para obtener la conexión
                using var connection = dbManager.Connection;
                using var command = connection.CreateCommand();
                command.CommandText = @"
                INSERT INTO Fiscalia (Ufid, Agente_Fiscal, Localidad, DeptoJudicial)
                VALUES (@Ufid, @Agente_Fiscal, @Localidad, @DeptoJudicial)";

                command.Parameters.AddWithValue("@Ufid", ufid);
                command.Parameters.AddWithValue("@Agente_Fiscal", agenteFiscal);
                command.Parameters.AddWithValue("@Localidad", localidad);
                command.Parameters.AddWithValue("@DeptoJudicial", deptoJudicial);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al guardar fiscalía: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        public static void GuardarIPP(int numeroIpp, string ufid, string dr, string localidad, string deptoJudicial, string instructor, string secretario, string dependencia, string fecha, List<string> victimas, List<string> imputados)
        {
            try
            {
                var dbManager = new DatabaseConnection();

                // Usamos dbManager.Connection para obtener la conexión
                using (var connection = dbManager.Connection)
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                INSERT INTO IPP (Numero_IPP, Ufid, Dr, Localidad, DeptoJudicial, Instructor, Secretario, Dependencia, Fecha)
                VALUES (@Numero_IPP, @Ufid, @Dr, @Localidad, @DeptoJudicial, @Instructor, @Secretario, @Dependencia, @Fecha)";

                    command.Parameters.AddWithValue("@Numero_IPP", numeroIpp);
                    command.Parameters.AddWithValue("@Ufid", ufid);
                    command.Parameters.AddWithValue("@Dr", dr);
                    command.Parameters.AddWithValue("@Localidad", localidad);
                    command.Parameters.AddWithValue("@DeptoJudicial", deptoJudicial);
                    command.Parameters.AddWithValue("@Instructor", instructor);
                    command.Parameters.AddWithValue("@Secretario", secretario);
                    command.Parameters.AddWithValue("@Dependencia", dependencia);
                    command.Parameters.AddWithValue("@Fecha", fecha);

                    command.ExecuteNonQuery();

                    // Obtener el ID del último registro insertado
                    command.CommandText = "SELECT last_insert_rowid();";
                    int ippId = Convert.ToInt32(command.ExecuteScalar());

                    // Insertar las víctimas
                    foreach (var victima in victimas)
                    {
                        command.CommandText = @"
                    INSERT INTO Victimas (IPP_ID, Nombre)
                    VALUES (@IPP_ID, @Nombre)";

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@IPP_ID", ippId);
                        command.Parameters.AddWithValue("@Nombre", victima);

                        command.ExecuteNonQuery();
                    }

                    // Insertar los imputados
                    foreach (var imputado in imputados)
                    {
                        command.CommandText = @"
                    INSERT INTO Imputados (IPP_ID, Nombre)
                    VALUES (@IPP_ID, @Nombre)";

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@IPP_ID", ippId);
                        command.Parameters.AddWithValue("@Nombre", imputado);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al guardar IPP: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }
    }
}