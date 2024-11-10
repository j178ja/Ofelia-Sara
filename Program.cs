using Ofelia_Sara.Formularios;
using System;
using System.Windows.Forms;

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
            // Llamar al método para encriptar la cadena de conexión
            ConfigEncryptor.EncryptConnectionString();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());


        }
    }
}
