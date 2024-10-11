//esta clase de reposicionamiento no la puedo usar hasta que logre acceder desde controles
// hacia elementos de ofelia-sara

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Controles.Controles.Reposicionar_paneles.Expedientes
{
    public class AgregarControl
    {
        //----AJUSTAR TAMAÑO Y ´POSICION DEL FORMULARIO DE ACUERDO AL CONTROL AGREGADO----
        //public void AjustarTamañoFormulario(int alturaControlRemovido, bool eliminar = false)
        //{
        //    // Calcula la altura del nuevo control agregado al panel_Control
        //    int alturaNuevoControl = panel_Control.Controls.OfType<Control>().LastOrDefault()?.Height ?? 0;

        //    // Ajusta el tamaño del formulario en función del tamaño del panel_Control
        //    int panelControlBottom = panel_Control.Bottom;
        //    int formHeight = Math.Max(panelControlBottom + 10, this.ClientSize.Height); // Añade un margen opcional de 10 píxeles

        //    // Ajustar la altura del formulario y panel1 según si se agrega o se elimina un control
        //    if (eliminar)
        //    {
        //        // Si se eliminó un control, reduce el tamaño del formulario y panel1
        //        formHeight -= alturaControlRemovido;
        //        panel1.Height -= (alturaControlRemovido); // Reducir la altura y restar 5 unidades a panel1
        //    }
        //    else
        //    {
        //        // Si se agregó un control, incrementa el tamaño del formulario y panel1
        //        formHeight += alturaNuevoControl;
        //        panel1.Height += (alturaNuevoControl); // Aumentar la altura y sumar 5 unidades a panel1
        //    }

        //    // Ajusta el tamaño del formulario
        //    this.ClientSize = new Size(this.ClientSize.Width, formHeight);

        //    // Calcula la posición horizontal para centrar el formulario en la pantalla
        //    int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int formWidth = this.ClientSize.Width;
        //    int leftPosition = (screenWidth - formWidth) / 2;

        //    // Ajusta la posición y el tamaño del formulario
        //    this.StartPosition = FormStartPosition.Manual; // Asegura que el formulario no use la posición predeterminada
        //    this.Location = new System.Drawing.Point(leftPosition, 0); // Centra horizontalmente y coloca en la parte superior

        //    // Ajusta la posición de panel2 con un espacio adicional
        //    int espacioEntreControlYPanel2 = 5; // Espacio adicional en píxeles entre el control y panel2
        //    if (panel_ConversorDocumentos != null)
        //    {
        //        if (eliminar)
        //        {
        //            // Si eliminamos un control, movemos panel2 hacia arriba
        //            panel_ConversorDocumentos.Top -= (alturaControlRemovido + espacioEntreControlYPanel2);
        //            panel_ConversorDocumentos.Height -= (alturaControlRemovido + espacioEntreControlYPanel2);
        //        }
        //        else
        //        {
        //            // Si agregamos un control, movemos panel2 hacia abajo
        //            panel_ConversorDocumentos.Top += (alturaNuevoControl + espacioEntreControlYPanel2);
        //            panel_ConversorDocumentos.Height += (alturaNuevoControl + espacioEntreControlYPanel2);
        //        }
        //    }
        //}
    }
}