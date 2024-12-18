/* Clase para ocultar formularios y mostrar formularios especificos
 COMO USARLO EJ.
private void AbrirContacto()
{
    Form contacto = new Contacto();
    contacto.FormClosed += (s, args) =>
    {
        // Restaurar todos los formularios minimizados al cerrar Contacto
        foreach (Form f in Application.OpenForms.Cast<Form>())
        {
            f.WindowState = FormWindowState.Normal;
        }
    };

  VisibilidadYOcultamientoForm.MostrarFormulario(contacto);//MOSTRAR SOLO UN FORMULARIO
}
//..........
private void AbrirVisu()
{
    Form visu = new Visu();
    Form cargo = Application.OpenForms["Cargo"]; // Por ejemplo, recuperar un formulario ya abierto.

   VisibilidadYOcultamientoForm.MostrarFormulario(visu, cargo);//MANTENER DOS FORM VISIBLES
}

 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Apariencia
{


    public static class VisibilidadYOcultamientoForm
    {
        /// <summary>
        /// Muestra el formulario especificado y oculta o minimiza los demás.
        /// </summary>
        /// <param name="formToShow">El formulario principal que debe mostrarse.</param>
        /// <param name="additionalFormsToKeepVisible">Formularios adicionales que deben permanecer visibles.</param>
        public static void MostrarFormulario(Form formToShow, params Form[] additionalFormsToKeepVisible)
        {
            // Obtener todos los formularios abiertos
            List<Form> allForms = Application.OpenForms.Cast<Form>().ToList();

            // Formularios que deben permanecer visibles
            List<Form> formsToKeepVisible = new List<Form> { formToShow };
            formsToKeepVisible.AddRange(additionalFormsToKeepVisible);

            // Ocultar o minimizar formularios no deseados
            foreach (Form f in allForms)
            {
                if (!formsToKeepVisible.Contains(f))
                {
                    f.WindowState = FormWindowState.Minimized; // Minimizar en lugar de ocultar si se prefiere
                }
            }

            // Mostrar el formulario principal
            formToShow.Show();
            formToShow.BringToFront();
            formToShow.Activate();

            // Restaurar formularios adicionales, si corresponde
            foreach (Form f in additionalFormsToKeepVisible)
            {
                f.WindowState = FormWindowState.Normal;
                f.Show();
            }
        }
    }
}