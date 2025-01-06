using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General
{
    public partial class BaseFormBase : Form
    {
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
                    Debug.WriteLine($"Error en tiempo de diseño: {ex.Message}");
                }
            }
            else
            {
                InitializeRuntimeMode();
            }
        }

        protected virtual void InitializeRuntimeMode()
        {
            // Lógica específica para tiempo de ejecución
        }
    }
}



