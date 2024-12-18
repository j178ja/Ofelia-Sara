using BaseDatos.Adm_BD.Modelos;
using Ofelia_Sara.Formularios.General.Mensajes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Ofelia_Sara.BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.BaseDatos;

namespace BaseDatos.Adm_BD.Manager
{
    public class PersonalManager
    {
        private readonly DatabaseConnection dbConnection;

        // Constructor que inicializa DatabaseConnection y evita ejecución en tiempo de diseño
        public PersonalManager()
        {
            dbConnection = BloqueadorTiempoDiseño.GetDatabaseConnection();
        }

        // Método para insertar un nuevo registro en Personal
        public void InsertPersonal(Personal personal)
        {
            string query = @"INSERT INTO Personal 
                            (Jerarquia, Escalafon, Legajo,DNI, Apellido, Nombres, Funcion,Dependencia,Domicilio_Dependencia,LocalidadDependencia,Partido_Dependencia, Domicilio, Localidad, Partido, Edad, Fecha_Nacimiento, Nacionalidad, Telefono1, Telefono2, Correo, Fecha_Ingreso, Posicion_Puesto, Armamento, Arma_Numeracion, Chaleco, Chaleco_Numeracion) 
                            VALUES 
                            (@Jerarquia, @Escalafon, @Legajo,@DNI, @Apellido, @Nombres, @Funcion,@Dependencia,@Domicilio_Dependencia, @LocalidadDependencia, @Partido_Dependencia, @Domicilio, @Localidad, @Partido, @Edad, @Fecha_Nacimiento, @Nacionalidad, @Telefono1, @Telefono2, @Correo, @Fecha_Ingreso, @Posicion_Puesto, @Armamento, @Arma_Numeracion, @Chaleco, @Chaleco_Numeracion)";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                // Agregar parámetros
                command.Parameters.AddWithValue("@Jerarquia", personal.Jerarquia.Trim());
                command.Parameters.AddWithValue("@Escalafon", personal.Escalafon.Trim());
                command.Parameters.AddWithValue("@Legajo", personal.Legajo);
                command.Parameters.AddWithValue("@DNI", personal.DNI.Trim());
                command.Parameters.AddWithValue("@Apellido", personal.Apellido.Trim());
                command.Parameters.AddWithValue("@Nombres", personal.Nombres.Trim());
                command.Parameters.AddWithValue("@Funcion", personal.Funcion.Trim());
                command.Parameters.AddWithValue("@Dependencia", personal.Dependencia.Trim());
                command.Parameters.AddWithValue("@Domicilio_Dependencia", personal.Domicilio_Dependencia.Trim());
                command.Parameters.AddWithValue("@LocalidadDependencia", personal.LocalidadDependencia.Trim());
                command.Parameters.AddWithValue("@Partido_Dependencia", personal.Partido_Dependencia.Trim());
                command.Parameters.AddWithValue("@Domicilio", personal.Domicilio.Trim());
                command.Parameters.AddWithValue("@Localidad", personal.Localidad.Trim());
                command.Parameters.AddWithValue("@Partido", personal.Partido.Trim());
                command.Parameters.AddWithValue("@Edad", personal.Edad);
                command.Parameters.AddWithValue("@Fecha_Nacimiento", personal.Fecha_Nacimiento);
                command.Parameters.AddWithValue("@Nacionalidad", personal.Nacionalidad.Trim());
                command.Parameters.AddWithValue("@Telefono1", personal.Telefono1.Trim());
                command.Parameters.AddWithValue("@Telefono2", personal.Telefono2.Trim());
                command.Parameters.AddWithValue("@Correo", personal.Correo.Trim());
                command.Parameters.AddWithValue("@Fecha_Ingreso", personal.Fecha_Ingreso);
                command.Parameters.AddWithValue("@Posicion_Puesto", personal.Posicion_Puesto.Trim());
                command.Parameters.AddWithValue("@Armamento", personal.Armamento.Trim());
                command.Parameters.AddWithValue("@Arma_Numeracion", personal.Arma_Numeracion.Trim());
                command.Parameters.AddWithValue("@Chaleco", personal.Chaleco.Trim());
                command.Parameters.AddWithValue("@Chaleco_Numeracion", personal.Chaleco_Numeracion.Trim());

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al insertar personal: {ex.Message}", MensajeGeneral.TipoMensaje.Error);

                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        // Método para obtener todos los registros de Personal
        public List<Personal> GetPersonal()
        {
            List<Personal> personalList = new List<Personal>();
            string query = "SELECT * FROM Personal";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personalList.Add(new Personal
                        {
                            ID = reader.GetInt32("ID"),
                            Jerarquia = reader.GetString("Jerarquia"),
                            Escalafon = reader.GetString("Escalafon"),
                            Legajo = reader.GetDecimal("Legajo"),
                            DNI = reader.GetString("DNI"),
                            Apellido = reader.GetString("Apellido"),
                            Nombres = reader.GetString("Nombres"),
                            Funcion = reader.GetString("Funcion"),
                            Dependencia = reader.GetString("Dependencia"),
                            Domicilio_Dependencia = reader.GetString("Domicilio_Dependencia"),
                            LocalidadDependencia = reader.GetString("LocalidadDependencia"),
                            Partido_Dependencia = reader.GetString("Partido_Dependencia"),
                            Domicilio = reader.GetString("Domicilio"),
                            Localidad = reader.GetString("Localidad"),
                            Partido = reader.GetString("Partido"),
                            Edad = reader.GetInt32("Edad"),
                            Fecha_Nacimiento = reader.GetDateTime("Fecha_Nacimiento"),
                            Nacionalidad = reader.GetString("Nacionalidad"),
                            Telefono1 = reader.GetString("Telefono1"),
                            Telefono2 = reader.GetString("Telefono2"),
                            Correo = reader.GetString("Correo"),
                            Fecha_Ingreso = reader.GetDateTime("Fecha_Ingreso"),
                            Posicion_Puesto = reader.GetString("Posicion_Puesto"),
                            Armamento = reader.GetString("Armamento"),
                            Arma_Numeracion = reader.GetString("Arma_Numeracion"),
                            Chaleco = reader.GetString("Chaleco"),
                            Chaleco_Numeracion = reader.GetString("Chaleco_Numeracion")
                        });
                    }
                }
            }
            dbConnection.CloseConnection();
            return personalList;
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Método para actualizar un registro existente en Personal
        public void UpdatePersonal(Personal personal)
        {
            string query = @"UPDATE Personal SET 
                            Jerarquia = @Jerarquia, 
                            Escalafon = @Escalafon, 
                            Legajo = @Legajo, 
                            DNI=@DNI,
                            Apellido = @Apellido, 
                            Nombres = @Nombres, 
                            Funcion = @Funcion, 
                            Dependencia = @Dependencia, 
                            Domicilio_Dependencia = @Domicilio_Dependencia, 
                            Domicilio_Dependencia = @Domicilio_Dependencia, 
                            LocalidadDependencia = @LocalidadDependencia, 
                            Partido_Dependencia = @Partido_Dependencia, 
                            Domicilio = @Domicilio, 
                            Localidad = @Localidad, 
                            Partido = @Partido, 
                            Edad = @Edad, 
                            Fecha_Nacimiento = @Fecha_Nacimiento, 
                            Nacionalidad = @Nacionalidad, 
                            Telefono1 = @Telefono1, 
                            Telefono2 = @Telefono2, 
                            Correo = @Correo, 
                            Fecha_Ingreso = @Fecha_Ingreso, 
                            Posicion_Puesto = @Posicion_Puesto, 
                            Armamento = @Armamento, 
                            Arma_Numeracion = @Arma_Numeracion, 
                            Chaleco = @Chaleco, 
                            Chaleco_Numeracion = @Chaleco_Numeracion 
                            WHERE ID = @ID";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                // Agregar parámetros
                command.Parameters.AddWithValue("@Jerarquia", personal.Jerarquia.Trim());
                command.Parameters.AddWithValue("@Escalafon", personal.Escalafon.Trim());
                command.Parameters.AddWithValue("@Legajo", personal.Legajo);
                command.Parameters.AddWithValue("@DNI", personal.DNI.Trim());
                command.Parameters.AddWithValue("@Apellido", personal.Apellido.Trim());
                command.Parameters.AddWithValue("@Nombres", personal.Nombres.Trim());
                command.Parameters.AddWithValue("@Funcion", personal.Funcion.Trim());
                command.Parameters.AddWithValue("@Dependencia", personal.Dependencia.Trim());

                command.Parameters.AddWithValue("@Domicilio_Dependencia", personal.Domicilio_Dependencia.Trim());
                command.Parameters.AddWithValue("@LocalidadDependencia", personal.LocalidadDependencia.Trim());
                command.Parameters.AddWithValue("@Partido_Dependencia", personal.Partido_Dependencia.Trim());
                command.Parameters.AddWithValue("@Domicilio", personal.Domicilio.Trim());
                command.Parameters.AddWithValue("@Localidad", personal.Localidad.Trim());
                command.Parameters.AddWithValue("@Partido", personal.Partido.Trim());
                command.Parameters.AddWithValue("@Edad", personal.Edad);
                command.Parameters.AddWithValue("@Fecha_Nacimiento", personal.Fecha_Nacimiento);
                command.Parameters.AddWithValue("@Nacionalidad", personal.Nacionalidad.Trim());
                command.Parameters.AddWithValue("@Telefono1", personal.Telefono1.Trim());
                command.Parameters.AddWithValue("@Telefono2", personal.Telefono2.Trim());
                command.Parameters.AddWithValue("@Correo", personal.Correo.Trim());
                command.Parameters.AddWithValue("@Fecha_Ingreso", personal.Fecha_Ingreso);
                command.Parameters.AddWithValue("@Posicion_Puesto", personal.Posicion_Puesto.Trim());
                command.Parameters.AddWithValue("@Armamento", personal.Armamento.Trim());
                command.Parameters.AddWithValue("@Arma_Numeracion", personal.Arma_Numeracion.Trim());
                command.Parameters.AddWithValue("@Chaleco", personal.Chaleco.Trim());
                command.Parameters.AddWithValue("@Chaleco_Numeracion", personal.Chaleco_Numeracion.Trim());
                command.Parameters.AddWithValue("@ID", personal.ID);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al actualizar personal: {ex.Message}", MensajeGeneral.TipoMensaje.Error);

                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        // Método para eliminar un registro de Personal
        public void DeletePersonal(int id)
        {
            string query = "DELETE FROM Personal WHERE ID = @ID";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@ID", id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MensajeGeneral.Mostrar($"Error al eliminar personal: {ex.Message}", MensajeGeneral.TipoMensaje.Error);

                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        // Método para verificar si un legajo existe
        public bool ExisteLegajo(string legajo)
        {
            string query = "SELECT COUNT(*) FROM Personal WHERE Legajo = @Legajo";

            dbConnection.OpenConnection();
            using (var command = new MySqlCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@Legajo", legajo);
                int count = Convert.ToInt32(command.ExecuteScalar());
                dbConnection.CloseConnection();
                return count > 0;
            }
        }
        public PersonalDTO ObtenerPersonalDTOPorLegajo(string legajo)
        {
            var databaseConnection = new DatabaseConnection();
            var personalDTO = new PersonalDTO(); // Instancia inicial con valores predeterminados

            try
            {
                databaseConnection.OpenConnection();

                // Crear el comando SQL
                string query = @"SELECT Jerarquia, Escalafon, Legajo, DNI, Nombres, Apellido, Funcion, Dependencia, 
                            Domicilio_Dependencia, LocalidadDependencia, Partido_Dependencia, Domicilio, 
                            Localidad, Partido, Edad, Fecha_Nacimiento, Nacionalidad, Telefono1, Telefono2, 
                            Correo, Fecha_Ingreso, Posicion_Puesto, Armamento, Arma_Numeracion, 
                            Chaleco, Chaleco_Numeracion
                         FROM Personal WHERE Legajo = @Legajo";

                using (var command = new MySqlCommand(query, databaseConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Legajo", legajo);

                    // Ejecutar la consulta
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Asignar los valores al objeto DTO, utilizando el operador ?? para valores nulos
                            personalDTO.Jerarquia = reader["Jerarquia"]?.ToString() ?? personalDTO.Jerarquia;
                            personalDTO.Escalafon = reader["Escalafon"]?.ToString() ?? personalDTO.Escalafon;
                            personalDTO.Legajo = reader["Legajo"]?.ToString() ?? personalDTO.Legajo;
                            personalDTO.DNI = reader["DNI"]?.ToString() ?? personalDTO.DNI;
                            personalDTO.Nombres = reader["Nombres"]?.ToString() ?? personalDTO.Nombres;
                            personalDTO.Apellido = reader["Apellido"]?.ToString() ?? personalDTO.Apellido;
                            personalDTO.Funcion = reader["Funcion"]?.ToString() ?? personalDTO.Funcion;
                            personalDTO.Dependencia = reader["Dependencia"]?.ToString() ?? personalDTO.Dependencia;
                            personalDTO.Domicilio_Dependencia = reader["Domicilio_Dependencia"]?.ToString() ?? personalDTO.Domicilio_Dependencia;
                            personalDTO.LocalidadDependencia = reader["LocalidadDependencia"]?.ToString() ?? personalDTO.LocalidadDependencia;
                            personalDTO.Partido_Dependencia = reader["Partido_Dependencia"]?.ToString() ?? personalDTO.Partido_Dependencia;
                            personalDTO.Domicilio = reader["Domicilio"]?.ToString() ?? personalDTO.Domicilio;
                            personalDTO.Localidad = reader["Localidad"]?.ToString() ?? personalDTO.Localidad;
                            personalDTO.Partido = reader["Partido"]?.ToString() ?? personalDTO.Partido;

                            // Campos con tipos de datos específicos (int, DateTime)
                            personalDTO.Edad = reader["Edad"] != DBNull.Value ? Convert.ToInt32(reader["Edad"]) : personalDTO.Edad;
                            personalDTO.Fecha_Nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha_Nacimiento"]) : personalDTO.Fecha_Nacimiento;
                            personalDTO.Nacionalidad = reader["Nacionalidad"]?.ToString() ?? personalDTO.Nacionalidad;
                            personalDTO.Telefono1 = reader["Telefono1"]?.ToString() ?? personalDTO.Telefono1;
                            personalDTO.Telefono2 = reader["Telefono2"]?.ToString() ?? personalDTO.Telefono2;
                            personalDTO.Correo = reader["Correo"]?.ToString() ?? personalDTO.Correo;
                            personalDTO.Fecha_Ingreso = reader["Fecha_Ingreso"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha_Ingreso"]) : personalDTO.Fecha_Ingreso;
                            personalDTO.Posicion_Puesto = reader["Posicion_Puesto"]?.ToString() ?? personalDTO.Posicion_Puesto;
                            personalDTO.Armamento = reader["Armamento"]?.ToString() ?? personalDTO.Armamento;
                            personalDTO.Arma_Numeracion = reader["Arma_Numeracion"]?.ToString() ?? personalDTO.Arma_Numeracion;
                            personalDTO.Chaleco = reader["Chaleco"]?.ToString() ?? personalDTO.Chaleco;
                            personalDTO.Chaleco_Numeracion = reader["Chaleco_Numeracion"]?.ToString() ?? personalDTO.Chaleco_Numeracion;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores o registrar el error
                MensajeGeneral.Mostrar($"Error al obtener el personal por legajo: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
            finally
            {
                databaseConnection.CloseConnection();
            }

            return personalDTO;
        }

    }
}