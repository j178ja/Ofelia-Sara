/*using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Ofelia_Sara.Base_de_Datos
{
    public class TableCreator
    {
        private readonly DatabaseManager dbManager;

        public TableCreator(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void CreateTables()
        {
            using (var connection = dbManager.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    // Crear tabla Usuarios
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Usuarios (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Jerarquia VARCHAR(100) NOT NULL,
                        Nombre VARCHAR(50) NOT NULL,
                        Apellido VARCHAR(50) NOT NULL,
                        Legajo REAL,
                        Nombre_Usuario VARCHAR(50),
                        Contrasena VARCHAR(100)
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla Instructor
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Instructor (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Jerarquia VARCHAR(100) NOT NULL,
                        Nombre VARCHAR(50) NOT NULL,
                        Apellido VARCHAR(50) NOT NULL,
                        Legajo REAL,
                        Firma_Digitalizada BLOB
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla Secretario
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Secretario (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Jerarquia VARCHAR(100) NOT NULL,
                        Nombre VARCHAR(50) NOT NULL,
                        Apellido VARCHAR(50) NOT NULL,
                        Funcion VARCHAR(100),
                        Legajo REAL,
                        Firma_Digitalizada BLOB
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla Fiscalia
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Fiscalia (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        UFID VARCHAR(50) NOT NULL,
                        DR VARCHAR(50) NOT NULL,
                        LOCALIDAD VARCHAR(50) NOT NULL,
                        DPTO_JUDICIAL VARCHAR(50) NOT NULL
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla Dependencia
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Dependencia (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Dependencia VARCHAR(100) NOT NULL,
                        Domicilio VARCHAR(50) NOT NULL,
                        Localidad VARCHAR(50) NOT NULL
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla IPP
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS IPP (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Numero_IPP INTEGER NOT NULL,
                        Ufid VARCHAR(50) NOT NULL,
                        Dr VARCHAR(50) NOT NULL,
                        Localidad VARCHAR(50) NOT NULL,
                        DeptoJudicial VARCHAR(50) NOT NULL,
                        Instructor VARCHAR(100) NOT NULL,
                        Secretario VARCHAR(100) NOT NULL,
                        Dependencia VARCHAR(100) NOT NULL,
                        Fecha VARCHAR(100) NOT NULL
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla Victimas con clave foránea
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Victimas (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        IPP_ID INTEGER NOT NULL,
                        Nombre VARCHAR(100) NOT NULL,
                        FOREIGN KEY (IPP_ID) REFERENCES IPP(ID) ON DELETE CASCADE
                    );";
                    command.ExecuteNonQuery();

                    // Crear tabla Imputados con clave foránea
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Imputados (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        IPP_ID INTEGER NOT NULL,
                        Nombre VARCHAR(100) NOT NULL,
                        FOREIGN KEY (IPP_ID) REFERENCES IPP(ID) ON DELETE CASCADE
                    );";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
*/