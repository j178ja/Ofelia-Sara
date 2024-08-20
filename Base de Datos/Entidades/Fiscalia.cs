using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.Base_de_Datos.Entidades
{
    public class Fiscalia
    {
        public string NombreFiscalia { get; set; }
        public string AgenteFiscal { get; set; }
        public string Localidad { get; set; }
        public string DeptoJudicial { get; set; }
    }

    public static class FiscaliaManager
    {
        private static List<Fiscalia> listaFiscalias = new List<Fiscalia>();

        internal static void AgregarFiscalia(Fiscalia fiscalia)
        {
            listaFiscalias.Add(fiscalia);
        }

        public static  List<Fiscalia> ObtenerFiscalias()
        {
            return new List<Fiscalia>(listaFiscalias);
        }



        // Métodos para obtener listas específicas de nombres, agentes, localidades, etc.
        public static List<string> ObtenerNombresFiscalias()
        {
            return listaFiscalias.Select(f => f.NombreFiscalia).ToList();
        }

        public static List<string> ObtenerAgentesFiscales()
        {
            return listaFiscalias.Select(f => f.AgenteFiscal).ToList();
        }

        public static List<string> ObtenerLocalidades()
        {
            return listaFiscalias.Select(f => f.Localidad).ToList();
        }

        public static List<string> ObtenerDeptosJudiciales()
        {
            return listaFiscalias.Select(f => f.DeptoJudicial).ToList();
        }
    }
}
