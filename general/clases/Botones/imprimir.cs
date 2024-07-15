/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE ("ASIGNAR EVENTO A IMAGEN IMPRIMIR")
         1) GUARDAR AUTOMATICAMENTE EL DOCUMENTO Y CONTENIDO DEL FORMULARIO
         2) ABRIR DOCUMENTO WORD PARA REVISION
         3) "A FUTURO: AGREGAR FUNCION QUE HABRA DIRECTO A IMPRESION
        ---------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofelia_Sara.general.clases
{
    using System.Windows.Forms;

    namespace Ofelia_Sara.general.clases
    {
        //------logica de validacion para desbloquear boton imprimir-----

        // Función para verificar si todos los campos están completos

        public class ValidadorCamposImpresion
        {
            public static bool VerificarCamposCompletos(Control.ControlCollection controls)
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false; // Si algún TextBox está vacío, retornar falso
                    }
                    else if (control is ComboBox comboBox && string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        return false; // Si algún ComboBox está vacío, retornar falso
                    }
                }
                return true; // Todos los campos están completos
            }
        }
    }
}
