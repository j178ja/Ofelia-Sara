/*---------------CLASE PARA CONTROLAR LOS PROGRESS VERTICAL BAR DE LOS FORMULARIOS-------------*/

using System;
using System.Drawing;

namespace Ofelia_Sara.general.clases
{
    public static class ControladorProgressVerticalBar
    {
        public static void ConfigurarProgressVerticalBar(ProgressVerticalBar progressVerticalBar1, ProgressVerticalBar progressVerticalBar2, int camposCompletos, int totalCampos)
        {
            // Calcula el porcentaje de campos completos
            double porcentajeCompletado = (double)camposCompletos / totalCampos;

            // Calcula el valor máximo para el progress bar basado en porcentaje
            int valorMaximo = (int)(progressVerticalBar1.Maximum * porcentajeCompletado);

            // Asegúrate de que el valor esté dentro del rango
            valorMaximo = Math.Max(progressVerticalBar1.Minimum, Math.Min(valorMaximo, progressVerticalBar1.Maximum));

            // Configura ambos ProgressBar de manera sincrónica
            foreach (var progressBar in new[] { progressVerticalBar1, progressVerticalBar2 })
            {
                progressBar.ForeColor = Color.DodgerBlue; // Color de la barra de progreso
                progressBar.BackColor = Color.FromArgb(178, 213, 230); // Color de fondo del ProgressBar
                progressBar.Value = valorMaximo; // Valor actual del ProgressBar
                progressBar.Invalidate(); // Forzar redibujado
            }
        }
    }
}
