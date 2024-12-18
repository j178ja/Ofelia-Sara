using System;

namespace BaseDatos.Adm_BD.Modelos
{

    public class Personal
    {
        public int ID { get; set; }
        public string Jerarquia { get; set; }
        public string Escalafon { get; set; }
        public decimal Legajo { get; set; }
        public string DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Funcion { get; set; }
        public string Dependencia { get; set; }
        public string Domicilio_Dependencia { get; set; }
        public string LocalidadDependencia { get; set; }
        public string Partido_Dependencia { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Partido { get; set; }
        public int Edad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Posicion_Puesto { get; set; }
        public string Armamento { get; set; }
        public string Arma_Numeracion { get; set; }
        public string Chaleco { get; set; }
        public string Chaleco_Numeracion { get; set; }
    }
    // DTO para transferencia de datos de Personal
    public class PersonalDTO
    {
        public string Legajo { get; set; }
        public string DNI { get; set; } = "00.000.000";
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string Funcion { get; set; } = "NO ESPECIFICADO";
        public string Dependencia { get; set; } = "NO ESPECIFICADO";
        public string Domicilio_Dependencia { get; set; } = "NO ESPECIFICADO";
        public string LocalidadDependencia { get; set; } = "NO ESPECIFICADO";
        public string Partido_Dependencia { get; set; } = "NO ESPECIFICADO";
        public string Jerarquia { get; set; }
        public string Escalafon { get; set; }

        // Campos adicionales
        public string Domicilio { get; set; } = "NO ESPECIFICADO";
        public string Localidad { get; set; } = "NO ESPECIFICADO";
        public string Partido { get; set; } = "NO ESPECIFICADO";
        public int Edad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Posicion_Puesto { get; set; }
        public string Armamento { get; set; }
        public string Arma_Numeracion { get; set; }
        public string Chaleco { get; set; }
        public string Chaleco_Numeracion { get; set; }

        // Constructor para establecer valores predeterminados
        public PersonalDTO()
        {
            DNI = "00.000.000";
            Funcion = "NO ESPECIFICADO";
            Dependencia = "NO ESPECIFICADO";
            Domicilio_Dependencia = "NO ESPECIFICADO";
            LocalidadDependencia = "NO ESPECIFICADO";
            Partido_Dependencia = "NO ESPECIFICADO";
            Domicilio = "NO ESPECIFICADO";
            Localidad = "NO ESPECIFICADO";
            Partido = "NO ESPECIFICADO";
        }

    }

}