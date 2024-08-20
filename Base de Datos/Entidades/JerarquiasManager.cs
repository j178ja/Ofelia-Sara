using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.Base_de_Datos
{
    internal class JerarquiasManager
    {
  // Diccionario que asocia escalafones con sus respectivas jerarquías
        private static readonly Dictionary<string, List<string>> escalafonJerarquias = new Dictionary<string, List<string>>()
        {
            { "COMANDO", new List<string> { "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "SUBCOMISARIO","COMISARIO","COMISARIO INSPECTOR","COMISARIO MAYOR","COMISARIO GENERAL" } },
            { "GENERAL", new List<string> { "CADETE","OFICIAL","SARGENTO","SUBTENIENTE","TENIENTE", "TENIENTE 1°","CAPITAN", "MAYOR"  } },
            { "ADMINISTRATIVO", new List<string> { "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "SUBCOMISARIO","COMISARIO","COMISARIO INSPECTOR","COMISARIO MAYOR","COMISARIO GENERAL" } },
            { "TECNICO", new List<string> { "Indique Jerarquia" } },
            { "PROFESIONAL", new List<string> { "Indique Jerarquia" } },
            { "SERVICIOS GENERALES", new List<string> { "CADETE","OFICIAL","SARGENTO","SUBTENIENTE","TENIENTE", "TENIENTE 1°","CAPITAN", "MAYOR"  } },
            { "EMERGENCIAS TELEFONICAS 911", new List<string> { "Indique Jerarquia" } },
            { "PERSONAL CIVIL", new List<string> { "Indique Jerarquia" } }
        };

        // Lista de escalafones disponibles
        private static readonly List<string> escalafones = new List<string> { "COMANDO","GENERAL","ADMINISTRATIVO","TECNICO","PROFESIONAL","SERVICIOS GENERALES", "EMERGENCIAS TELEFONICAS 911", "PERSONAL CIVIL" };

        // Método para obtener los escalafones
        public static List<string> ObtenerEscalafones()
        {
            return new List<string>(escalafones);
        }

        // Método para obtener las jerarquías en función del escalafón
        public static List<string> ObtenerJerarquias(string escalafon)
        {
            if (escalafonJerarquias.ContainsKey(escalafon))
            {
                return new List<string>(escalafonJerarquias[escalafon]);
            }
            else
            {
                return new List<string>(); // Retorna una lista vacía si el escalafón no existe
            }
        }
    }
}
