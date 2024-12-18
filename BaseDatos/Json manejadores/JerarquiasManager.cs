using System.Collections.Generic;

namespace BaseDatos.Entidades
{
    public class JerarquiasManager
    {
        // Diccionario que asocia escalafones con sus respectivas jerarquías
        private static readonly Dictionary<string, List<string>> escalafonJerarquias = new Dictionary<string, List<string>>()
        {
            { "COMANDO", new List<string> { "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "SUBCOMISARIO","COMISARIO","COMISARIO INSPECTOR","COMISARIO MAYOR","COMISARIO GENERAL" } },
            { "GENERAL", new List<string> { "CADETE","OFICIAL","SARGENTO","SUBTENIENTE","TENIENTE", "TENIENTE 1°","CAPITAN", "MAYOR"  } },
            { "ADMINISTRATIVO", new List<string> { "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "OFICIAL SUBINSPECTOR", "SUBTENIENTE", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "SUBCOMISARIO","COMISARIO","COMISARIO INSPECTOR","COMISARIO MAYOR","COMISARIO GENERAL" } },
            { "TECNICO", new List<string> { "OFICIAL", "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "SARGENTO", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "TENIENTE", "TENIENTE 1°", "SUBCOMISARIO", "CAPITAN", "MAYOR","COMISARIO", "COMISARIO INSPECTOR", "COMISARIO MAYOR", "COMISARIO GENERAL" } },
            { "PROFESIONAL", new List<string>  { "OFICIAL", "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "SARGENTO", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "TENIENTE", "TENIENTE 1°", "SUBCOMISARIO", "CAPITAN", "MAYOR","COMISARIO", "COMISARIO INSPECTOR", "COMISARIO MAYOR", "COMISARIO GENERAL" } },
            { "SERVICIOS GENERALES", new List<string> { "OFICIAL","SARGENTO","SUBTENIENTE","TENIENTE", "TENIENTE 1°","CAPITAN", "MAYOR"  } },
            { "EMERGENCIAS TELEFONICAS 911", new List<string>  { "OFICIAL", "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "SARGENTO", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "TENIENTE", "TENIENTE 1°", "SUBCOMISARIO", "CAPITAN", "MAYOR","COMISARIO", "COMISARIO INSPECTOR", "COMISARIO MAYOR", "COMISARIO GENERAL" } },
            { "PERSONAL CIVIL", new List<string>  { "OFICIAL", "OFICIAL SUBAYUDANTE", "OFICIAL AYUDANTE", "SARGENTO", "OFICIAL SUBINSPECTOR", "OFICIAL INSPECTOR", "OFICIAL PRINCIPAL", "TENIENTE", "TENIENTE 1°", "SUBCOMISARIO", "CAPITAN", "MAYOR","COMISARIO", "COMISARIO INSPECTOR", "COMISARIO MAYOR", "COMISARIO GENERAL" } },
        };

        // Lista de escalafones disponibles
        private static readonly List<string> escalafones = new List<string> { "COMANDO", "GENERAL", "ADMINISTRATIVO", "TECNICO", "PROFESIONAL", "SERVICIOS GENERALES", "EMERGENCIAS TELEFONICAS 911", "PERSONAL CIVIL" };

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
