/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;
using Ofelia_Sara.Base_de_Datos;
using System.Xml.Linq;

namespace Ofelia_Sara.Base_de_Datos
{
    public class DataInserter
{
    protected readonly DatabaseManager dbManager;

    public DataInserter(DatabaseManager dbManager)
    {
        this.dbManager = dbManager;
    }

    public void InsertarUsuario(string jerarquia,string escalafon, string nombre, string apellido, double legajo, string nombreUsuario, string contrasena)
    {
        using (var connection = dbManager.GetConnection())
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                INSERT INTO Usuarios (Jerarquia,Escalafon, Nombre, Apellido, Legajo, Nombre_Usuario, Contrasena)
                VALUES (@Jerarquia,@Escalafon, @Nombre, @Apellido, @Legajo, @Nombre_Usuario, @Contrasena)";

            command.Parameters.AddWithValue("@Jerarquia", jerarquia);
            command.Parameters.AddWithValue("@Escalafon", escalafon);
            command.Parameters.AddWithValue("@Nombre", nombre);
            command.Parameters.AddWithValue("@Apellido", apellido);
            command.Parameters.AddWithValue("@Legajo", legajo);
            command.Parameters.AddWithValue("@Nombre_Usuario", nombreUsuario);
            command.Parameters.AddWithValue("@Contrasena", contrasena);

            command.ExecuteNonQuery();
        }
    }

    public void InsertarInstructor(string jerarquia,string escalafon, string nombre, string apellido, double legajo, byte[] firmaDigitalizada)
    {
        using (var connection = dbManager.GetConnection())
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                INSERT INTO Instructor (Jerarquia,Escalafon, Nombre, Apellido, Legajo, Firma_Digitalizada)
                VALUES (@Jerarquia,@Escalafon, @Nombre, @Apellido, @Legajo, @Firma_Digitalizada)";

            command.Parameters.AddWithValue("@Jerarquia", jerarquia);
            command.Parameters.AddWithValue("@Escalafon", escalafon);
            command.Parameters.AddWithValue("@Nombre", nombre);
            command.Parameters.AddWithValue("@Apellido", apellido);
            command.Parameters.AddWithValue("@Legajo", legajo);
            command.Parameters.AddWithValue("@Firma_Digitalizada", firmaDigitalizada);

            command.ExecuteNonQuery();
        }
    }

        public void GuardarSecretario(string jerarquia,string escalafon, string nombre, string apellido, double legajo, string funcion, byte[] firmaDigitalizada)
        {
            using (var connection = dbManager.GetConnection()) // Abre la conexión
            using (var command = connection.CreateCommand()) // Crea el comando
            {
                command.CommandText = @"
            INSERT INTO Secretario (Jerarquia,Escalafon, Nombre, Apellido, Legajo, Funcion, FirmaDigitalizada)
            VALUES (@Jerarquia,@Escalafon, @Nombre, @Apellido, @Legajo, @Funcion, @FirmaDigitalizada)";

                command.Parameters.AddWithValue("@Jerarquia", jerarquia);
                command.Parameters.AddWithValue("@Escalafon", escalafon);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Legajo", legajo);
                command.Parameters.AddWithValue("@Funcion", funcion);
                command.Parameters.AddWithValue("@FirmaDigitalizada", (object)firmaDigitalizada ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
        }

        public void GuardarFiscalia(string ufid, string agente_Fiscal, string localidad, string deptoJudicial)
        {
            using (var connection = dbManager.GetConnection()) // Abre la conexión
            using (var command = connection.CreateCommand()) // Crea el comando
            {
                command.CommandText = @"
            INSERT INTO Ficalia (Ufid,agente_Fiscal,Localidad,DeptoJudcial)
            VALUES (@Ufid,@Agente_Fiscal,@Localidad,@DeptoJudicial)";

                command.Parameters.AddWithValue("@Ufid", ufid);
                command.Parameters.AddWithValue("@Agente_Fiscal", agente_Fiscal);
                command.Parameters.AddWithValue("@Localidad", localidad);
                command.Parameters.AddWithValue("@DeptoJudicial", deptoJudicial);
              
                command.ExecuteNonQuery();
            }
        }


        public void GuardarIPP(int numeroIpp, string ufid, string dr,string localidad, string DeptoJudicial, string instructor, string secretario,string dependencia, string fecha, List<string> victimas, List<string> imputados)
        {
            using (var connection = dbManager.GetConnection())
            using (var command = connection.CreateCommand())
            {
                // Insertar en la tabla IPP
                command.CommandText = @"
        INSERT INTO IPP (Numero_IPP, Ufid, Dr,Localidad, DeptoJudicial, Instructor, Secretario, Dependencia, Fecha)
        VALUES (@Numero_IPP, @Ufid, @Dr,@Localidad, @DeptoJudicial, @Instructor, @Secretario,♠Dependencia, @Fecha)";

                command.Parameters.AddWithValue("@Numero_IPP", numeroIpp);
                command.Parameters.AddWithValue("@Ufid", ufid);
                command.Parameters.AddWithValue("@Dr", dr);
                command.Parameters.AddWithValue("@Localidad", localidad);
                command.Parameters.AddWithValue("@DeptoJudicial", DeptoJudicial);
                command.Parameters.AddWithValue("@Instructor", instructor);
                command.Parameters.AddWithValue("@Dependencia", secretario);
                command.Parameters.AddWithValue("@Secretario", dependencia);
                command.Parameters.AddWithValue("@Fecha", fecha);

                command.ExecuteNonQuery();

                // Obtener el ID recién insertado
                command.CommandText = "SELECT last_insert_rowid();";
                int ippId = Convert.ToInt32(command.ExecuteScalar());

                // Insertar las víctimas
                foreach (var victima in victimas)
                {
                    command.CommandText = @"
            INSERT INTO Victimas (IPP_ID, Nombre)
            VALUES (@IPP_ID, @Nombre)";

                    command.Parameters.Clear(); // Limpiar parámetros para reutilizar el comando
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

                    command.Parameters.Clear(); // Limpiar parámetros para reutilizar el comando
                    command.Parameters.AddWithValue("@IPP_ID", ippId);
                    command.Parameters.AddWithValue("@Nombre", imputado);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void InsertarVictima(int ippId, string nombre)
    {
        using (var connection = dbManager.GetConnection())
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                INSERT INTO Victimas (IPP_ID, Nombre)
                VALUES (@IPP_ID, @Nombre)";

            command.Parameters.AddWithValue("@IPP_ID", ippId);
            command.Parameters.AddWithValue("@Nombre", nombre);

            command.ExecuteNonQuery();
        }
    }

    public void InsertarImputado(int ippId, string nombre)
    {
        using (var connection = dbManager.GetConnection())
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                INSERT INTO Imputados (IPP_ID, Nombre)
                VALUES (@IPP_ID, @Nombre)";

            command.Parameters.AddWithValue("@IPP_ID", ippId);
            command.Parameters.AddWithValue("@Nombre", nombre);

            command.ExecuteNonQuery();
        }
    }
}
}

*/
