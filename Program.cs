﻿using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.Formularios.Oficial_de_servicio.Registro_de_personal;
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
            //  ConfigEncryptor.EncryptConnectionString();

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //// //// Mostrar el formulario de presentación y luego continuar con el menú principal
            //using (Presentacion presentacion = new Presentacion())
            //{
            //    Application.Run(presentacion);
            //}

            //// Después de cerrar Presentacion, abrir MenuPrincipal
              Application.Run(new MenuPrincipal());
         


        }
    }
    }
