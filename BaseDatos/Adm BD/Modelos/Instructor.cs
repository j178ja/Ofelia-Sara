namespace BaseDatos.Adm_BD.Modelos
{
    public class Instructores
    {
        public int Id { get; set; }
        public float? Legajo { get; set; }
        public string Subescalafon { get; set; }
        public string Jerarquia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dependencia { get; set; }
        public string Funcion { get; set; }

        // Propiedad para combinar Nombre y Localidad
        public string JerarquiaYNombre
        {
            get { return $"{Jerarquia} {Nombre} {Apellido}"; }
        }
    }
}

