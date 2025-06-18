using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.BaseDatos.Json_generador_de_archivos
{
    public class Articulos
    {
        public int Articulo { get; set; }
        public string Contenido { get; set; }
    }

    public class Capitulos
    {
        public string Capitulo { get; set; }
        public List<Articulos> Articulos { get; set; }
    }

}
