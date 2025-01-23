using BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases.BaseDatos;
using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using Ofelia_Sara.Formularios.General.Mensajes;


namespace Ofelia_Sara.Formularios.General
{
    public partial class BaseFormBase : Form
    {
        // Propiedades y campos específicos de BaseForm
        private Cursor cursorHandPersonalizado;
        private Cursor CursorLapizDerecha;
        private DatabaseConnection dbConnection;
        private AutocompletarManager autocompletarManager;
        protected ComisariasManager dbManager;
        protected InstructoresManager instructoresManager;
        protected SecretariosManager secretariosManager;
        protected bool IsInDesignMode => DesignMode ||
                                  LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                                  Process.GetCurrentProcess().ProcessName == "devenv";


        public BaseFormBase()
        {
            if (IsInDesignMode)
            {
                try
                {
                    InitializeComponent(); // Solo se llama al método generado automáticamente
                }
                catch (Exception ex)
                {
                    // Log o manejo de errores para evitar bloqueos en el diseñador
                    Console.WriteLine("Error en tiempo de diseño: {ex.Message}" );
                }
            }
            else
            {
                InitializeRuntimeMode();
            }
        }

        private void MensajeGeneral(string v, MensajeGeneral.TipoMensaje error)
        {
            throw new NotImplementedException();
        }

        protected void InitializeRuntimeMode()
        {
            InitializeComponent(); // Llama primero para inicializar los controles
            this.AutoScaleMode = AutoScaleMode.Dpi;
            dbManager = new ComisariasManager();
            instructoresManager = new InstructoresManager();
            secretariosManager = new SecretariosManager();
            InitializeManagers();
            InitializeCustomCursors();
            TraerLabelsAlFrente();
        }


        /// <summary>
        /// Inicializa los manejadores necesarios.
        /// </summary>
        private void InitializeManagers()
        {
            try
            {
                dbManager = new ComisariasManager();
                instructoresManager = new InstructoresManager();
                secretariosManager = new SecretariosManager();
                autocompletarManager = new AutocompletarManager(@"path\to\Cartatulas_Autocompletar.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inicializando managers: {ex.Message}");
            }
        }

        //para traer label titulo siempre al frente
        private void TraerLabelsAlFrente(Control parent = null)
        {
            parent ??= this;

            foreach (Control control in parent.Controls)
            {
                if (control is Label label && label.Name.StartsWith("label_TITULO"))
                {
                    label.BringToFront();
                }
                else if (control.HasChildren)
                {
                    TraerLabelsAlFrente(control);
                }
            }
        }


        /// <summary>
        /// Inicializa cursores personalizados.
        /// </summary>
        private void InitializeCustomCursors()
        {
            try
            {
                using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.cursorFlecha))
                {
                    this.Cursor = new Cursor(cursorStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando cursorFlecha: {ex.Message}");
            }

            try
            {
                using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.hand))
                {
                   cursorHandPersonalizado = new Cursor(cursorStream);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando cursorHand: {ex.Message}");
            }

            try
            {
                using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.CursorlapizDerecha))
                {
                    CursorLapizDerecha = new Cursor(cursorStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando CursorlapizDerecha: {ex.Message}");
            }
        }

    }
}



