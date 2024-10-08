/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE ("ASIGNAR EVENTO A IMAGEN IMPRIMIR")
         1) GUARDAR AUTOMATICAMENTE EL DOCUMENTO Y CONTENIDO DEL FORMULARIO
         2) ABRIR DOCUMENTO WORD PARA REVISION
         3) "A FUTURO: AGREGAR FUNCION QUE HABRA DIRECTO A IMPRESION
        ---------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clases.Botones
{
    public static class ValidadorCamposImpresion
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

        public static void ActualizarEstadoBoton(Button btn_Imprimir, Control.ControlCollection controls)
        {
            bool camposCompletos = VerificarCamposCompletos(controls);

            if (camposCompletos)
            {
                btn_Imprimir.Enabled = true;
                btn_Imprimir.BackColor = Color.FromArgb(0, 204, 0); // Verde
            }
            else
            {
                btn_Imprimir.Enabled = false;
                btn_Imprimir.BackColor = Color.FromArgb(211, 47, 47); // Rojo
            }
        }
        // Método que unifica la validación y actualización del estado del botón
        public static void VerificarYActualizarBotonImprimir(Button btn_Imprimir, Control.ControlCollection controls)
        {
            ActualizarEstadoBoton(btn_Imprimir, controls);
        }
    }
}