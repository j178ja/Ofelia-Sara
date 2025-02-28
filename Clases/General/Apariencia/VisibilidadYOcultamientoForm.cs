

// OCULTAR    VisibilidadYOcultamientoForm.MostrarFormularioYOcultar(actaDenunciaForm);
// MINIMIZAR     VisibilidadYOcultamientoForm.MostrarFormulario(actaDenunciaForm);
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Apariencia
{

    public static class VisibilidadYOcultamientoForm
    {
        private static List<Form> formsModificados = new(); // Almacena los formularios minimizados u ocultos
        private static bool ocultarEnLugarDeMinimizar = false; // Controla el comportamiento

        /// <summary>
        /// Muestra el formulario especificado y minimiza los demás por defecto.
        /// </summary>
        /// <param name="formToShow">El formulario que debe mostrarse.</param>
        public static void MostrarFormulario(Form formToShow)
        {
            ocultarEnLugarDeMinimizar = false; // Se minimizan los formularios por defecto
            AplicarAccionSobreFormularios(formToShow);
        }

        /// <summary>
        /// Muestra el formulario especificado y oculta los demás en lugar de minimizarlos.
        /// </summary>
        /// <param name="formToShow">El formulario que debe mostrarse.</param>
        public static void MostrarFormularioYOcultar(Form formToShow)
        {
            ocultarEnLugarDeMinimizar = true; // Se ocultan los formularios en vez de minimizarlos
            AplicarAccionSobreFormularios(formToShow);
        }

        /// <summary>
        /// Aplica la acción de ocultar o minimizar sobre los formularios abiertos.
        /// </summary>
        private static void AplicarAccionSobreFormularios(Form formToShow)
        {
            formsModificados.Clear(); // Limpiar la lista de formularios modificados

            List<Form> allForms = Application.OpenForms.Cast<Form>().ToList();

            foreach (Form f in allForms)
            {
                if (f != formToShow && f.Visible) // Solo afecta a los formularios visibles
                {
                    formsModificados.Add(f); // Guardamos el formulario en la lista

                    if (ocultarEnLugarDeMinimizar)
                        f.Hide(); // Ocultar formulario
                    else
                        f.WindowState = FormWindowState.Minimized; // Minimizar formulario
                }
            }

            // Mostrar y traer al frente el formulario principal
            formToShow.Show();
            formToShow.BringToFront();
            formToShow.Activate();

            // Restaurar formularios cuando se cierre formToShow
            formToShow.FormClosed += (s, e) => RestaurarFormularios();
        }

        /// <summary>
        /// Restaura todos los formularios ocultos o minimizados.
        /// </summary>
        private static void RestaurarFormularios()
        {
            foreach (Form f in formsModificados)
            {
                if (f != null && !f.IsDisposed)
                {
                    f.WindowState = FormWindowState.Normal; // Restaurar tamaño normal
                    f.Show(); // Asegurar que esté visible
                    f.BringToFront();
                }
            }
            formsModificados.Clear(); // Limpiar la lista después de restaurar
        }
    }
}
