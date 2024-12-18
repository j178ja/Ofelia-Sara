namespace BaseDatos.Adm_BD.Modelos
{

    public class Comisaria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Partido { get; set; }

        // Propiedad para combinar Nombre y Localidad
        public string NombreYLocalidad
        {
            get { return $"{Nombre}   {Localidad}"; }
        }
    }


}
