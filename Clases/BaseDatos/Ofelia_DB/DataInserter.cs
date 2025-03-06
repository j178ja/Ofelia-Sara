using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using Ofelia_Sara.Clases.BaseDatos.Ofelia_DB;

namespace Ofelia_Sara.Clases.BaseDatos.Ofelia_DB
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    namespace Ofelia_Sara.Clases.BaseDatos.Ofelia_DB
    {
        public class DataInserter
        {
            private readonly DataManager<DatabaseConnection> dbManager;

            // Constructor que recibe una instancia de dbManager
            public DataInserter(DataManager<DatabaseConnection> dbManager)
            {
                this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            }

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

                    dbManager.Create(query, parameters);
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

                    dbManager.Create(query, parameters);
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar instructor: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }

            public void GuardarSecretario(string jerarquia, string escalafon, string nombre, string apellido, double legajo, string funcion, byte[] firmaDigitalizada)
            {
                try
                {
                    string query = @"
                INSERT INTO Secretario (Jerarquia, Escalafon, Nombre, Apellido, Legajo, Funcion, FirmaDigitalizada)
                VALUES (@Jerarquia, @Escalafon, @Nombre, @Apellido, @Legajo, @Funcion, @FirmaDigitalizada)";

                    var parameters = new SQLiteParameter[]
                    {
                    new("@Jerarquia", jerarquia),
                    new("@Escalafon", escalafon),
                    new("@Nombre", nombre),
                    new("@Apellido", apellido),
                    new("@Legajo", legajo),
                    new("@Funcion", funcion),
                    new("@FirmaDigitalizada", firmaDigitalizada ?? (object)DBNull.Value)
                    };

                    dbManager.Create(query, parameters);
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al guardar secretario: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }

            public void GuardarFiscalia(string ufid, string agenteFiscal, string localidad, string deptoJudicial)
            {
                try
                {
                    string query = @"
                INSERT INTO Fiscalia (Ufid, Agente_Fiscal, Localidad, DeptoJudicial)
                VALUES (@Ufid, @Agente_Fiscal, @Localidad, @DeptoJudicial)";

                    var parameters = new SQLiteParameter[]
                    {
                    new("@Ufid", ufid),
                    new("@Agente_Fiscal", agenteFiscal),
                    new("@Localidad", localidad),
                    new("@DeptoJudicial", deptoJudicial)
                    };

                    dbManager.Create(query, parameters);
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al guardar fiscalía: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }

            public void GuardarIPP(int numeroIpp, string ufid, string dr, string localidad, string deptoJudicial, string instructor, string secretario, string dependencia, string fecha, List<string> victimas, List<string> imputados)
            {
                try
                {
                    string query = @"
                INSERT INTO IPP (Numero_IPP, Ufid, Dr, Localidad, DeptoJudicial, Instructor, Secretario, Dependencia, Fecha)
                VALUES (@Numero_IPP, @Ufid, @Dr, @Localidad, @DeptoJudicial, @Instructor, @Secretario, @Dependencia, @Fecha)";

                    var parameters = new SQLiteParameter[]
                    {
                    new("@Numero_IPP", numeroIpp),
                    new("@Ufid", ufid),
                    new("@Dr", dr),
                    new("@Localidad", localidad),
                    new("@DeptoJudicial", deptoJudicial),
                    new("@Instructor", instructor),
                    new("@Secretario", secretario),
                    new("@Dependencia", dependencia),
                    new("@Fecha", fecha)
                    };

                    dbManager.Create(query, parameters);

                    // Obtener el ID del último registro insertado
                    int ippId = dbManager.GetLastInsertedId();

                    // Insertar las víctimas
                    foreach (var victima in victimas)
                    {
                        string queryVictima = "INSERT INTO Victimas (IPP_ID, Nombre) VALUES (@IPP_ID, @Nombre)";
                        var parametersVictima = new SQLiteParameter[]
                        {
                        new("@IPP_ID", ippId),
                        new("@Nombre", victima)
                        };
                        dbManager.Create(queryVictima, parametersVictima);
                    }

                    // Insertar los imputados
                    foreach (var imputado in imputados)
                    {
                        string queryImputado = "INSERT INTO Imputados (IPP_ID, Nombre) VALUES (@IPP_ID, @Nombre)";
                        var parametersImputado = new SQLiteParameter[]
                        {
                        new("@IPP_ID", ippId),
                        new("@Nombre", imputado)
                        };
                        dbManager.Create(queryImputado, parametersImputado);
                    }
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al guardar IPP: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }
        }
    }
}