using System;
using System.Windows.Forms;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.Acceso_Usuarios;

namespace Ofelia_Sara
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MenuPrincipal());
            Application.Run(new ModificarEliminar());
         
        }
    }
}
