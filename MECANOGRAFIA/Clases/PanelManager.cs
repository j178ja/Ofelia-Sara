using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MECANOGRAFIA.Clases
{


    public class PanelManager
    {
        private Form _form; // Referencia al formulario
        private Panel _panel; // Panel que se va a gestionar

        // Constructor
        public PanelManager(Form form)
        {
            _form = form; // Guardar la referencia del formulario
        }

        // Método para agregar paneles al formulario (opcional)
        public void AgregarPanel(Panel panel)
        {
            _form.Controls.Add(panel);
        }

        // Método para remover un panel específico
        public void RemoverPanel(Panel panel)
        {
            if (_form.Controls.Contains(panel))
            {
                _form.Controls.Remove(panel); // Remover el panel del formulario
                AjustarTamanoFormulario(); // Ajustar tamaño después de remover
            }
        }

        // Método para ajustar el tamaño del formulario
        private void AjustarTamanoFormulario()
        {
            // Aquí puedes ajustar el tamaño del formulario según tus necesidades
            _form.AutoSize = true; // Ajustar automáticamente el tamaño del formulario
            _form.ClientSize = new System.Drawing.Size(800, 600); // Establecer un tamaño específico (opcional)
        }
    }
}