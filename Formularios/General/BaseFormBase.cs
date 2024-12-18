using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofelia_Sara.Formularios.General
{
    public partial class BaseFormBase : Form // Nota el modificador partial
    {
        protected bool IsInDesignMode { get; private set; }

        public BaseFormBase()
        {
            IsInDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            if (IsInDesignMode)
            {
                InitializeComponent(); // Solo se llama al método generado automáticamente
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



