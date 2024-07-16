using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Ofelia_Sara.general.clases
{
    //--------------------------------------------------------
    //----DESABILITAR BOTON MAXIMIZAR---------
    //---la siguiente clase solo deshabilita el boton en la totalidad de fomularios
    //---deribados de form-------------
    //
    //public static class EliminarBotonMaximizar
    //{
    //    public static void DeshabilitarMaximizar(Form form)
    //    {
    //        form.MaximizeBox = false;
    //    }
    //}
    //--------------------------------------------------------
    // Clase estática para deshabilitar y ocultar el botón de maximizar
    public static class EliminarBotonMaximizar
    {
        // Importa la función SetWindowLong de user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Importa la función GetWindowLong de user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private const int GWL_STYLE = -16; // Constante para el índice del estilo de la ventana
        private const int WS_MAXIMIZEBOX = 0x00010000; // Constante para el estilo del botón de maximizar
        private const int WS_SYSMENU = 0x00080000; // Constante para el menú del sistema (incluye botones de control de la ventana)

        // Método para deshabilitar y ocultar el botón de maximizar
        public static void DeshabilitarMaximizar(Form form)
        {
            // Obtiene el handle de la ventana del formulario
            IntPtr hWnd = form.Handle;

            // Obtiene el estilo actual de la ventana
            int style = GetWindowLong(hWnd, GWL_STYLE);

            // Elimina el estilo de maximizar y el menú del sistema
            style &= ~WS_MAXIMIZEBOX;
            style &= ~WS_SYSMENU;

            // Establece el nuevo estilo de la ventana
            SetWindowLong(hWnd, GWL_STYLE, style);
        }
    }
}
