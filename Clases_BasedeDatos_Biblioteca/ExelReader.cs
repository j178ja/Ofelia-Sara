using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

public class ExcelReader
{
    public List<Dictionary<string, string>> LeerDatosDesdeExcel(string rutaArchivo)
    {
        List<Dictionary<string, string>> listaDatos = new List<Dictionary<string, string>>();
        FileInfo archivoExcel = new FileInfo(rutaArchivo);

        using (ExcelPackage paquete = new ExcelPackage(archivoExcel))
        {
            ExcelWorksheet hoja = paquete.Workbook.Worksheets[0];
            int filas = hoja.Dimension.Rows;
            int columnas = hoja.Dimension.Columns;

            List<string> encabezados = new List<string>();
            for (int col = 1; col <= columnas; col++)
            {
                encabezados.Add(hoja.Cells[1, col].Text);
            }

            for (int fila = 2; fila <= filas; fila++)
            {
                Dictionary<string, string> filaDatos = new Dictionary<string, string>();
                for (int col = 1; col <= columnas; col++)
                {
                    filaDatos[encabezados[col - 1]] = hoja.Cells[fila, col].Text;
                }
                listaDatos.Add(filaDatos);
            }
        }

        return listaDatos;
    }
}
