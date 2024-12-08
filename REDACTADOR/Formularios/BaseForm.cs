﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REDACTADOR.Formularios
{
    public partial class BaseForm : Form
    {
        private Cursor customHandCursor;// DECLARACION DEL CURSON PERSONALIZADO HAND
        public BaseForm()
        {
            InitializeComponent();

            // Cargar el cursor desde los recursos
            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.cursorFlecha))
            {
                this.Cursor = new Cursor(cursorStream);
            }
            // Cargar el cursor personalizado desde los recursos
            using (MemoryStream cursorHand = new MemoryStream(Properties.Resources.hand))
            {
                customHandCursor = new Cursor(cursorHand);
            }
        }
        /// <summary>
        /// Sustituir CURSOR HAND
        /// </summary>
        private void AsignarCursorPersonalizado(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Si el control tiene el cursor predeterminado "Hand", reemplázalo con el personalizado
                if (control.Cursor == Cursors.Hand)
                {
                    control.Cursor = customHandCursor;
                }

                // Si el control tiene hijos, aplica el cambio recursivamente
                if (control.HasChildren)
                {
                    AsignarCursorPersonalizado(control.Controls);
                }
            }
        }
    }
}
