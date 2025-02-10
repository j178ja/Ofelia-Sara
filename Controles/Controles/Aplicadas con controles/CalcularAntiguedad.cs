using System;

namespace Ofelia_Sara.Controles.Controles.Aplicadas_con_controles
{
    /// <summary>
    /// CLASE PARA CALCULAR ANTIGUEDAD (AÑOS , MESES) DEPENDIENDO DE FECHA INGRESADA EN CONTROL ESPECIFICO
    /// </summary>
    public class CalcularAntiguedad
    {
        public static void Calcular(DateTime fechaInicio, out int años, out int meses)
        {
            DateTime hoy = DateTime.Now;

            if (fechaInicio > hoy)
            {
                // Si la fecha de inicio es en el futuro, asignar valores por defecto
                años = 0;
                meses = 0;
                return;
            }

            años = hoy.Year - fechaInicio.Year;
            meses = hoy.Month - fechaInicio.Month;

            // Ajustar si el mes actual es menor al mes de la fecha de inicio
            if (meses < 0)
            {
                años--;
                meses += 12;
            }

            // Ajustar si el día actual es menor al día de la fecha de inicio
            if (hoy.Day < fechaInicio.Day)
            {
                meses--;
                if (meses < 0)
                {
                    años--;
                    meses += 12;
                }
            }
        }

    }
}