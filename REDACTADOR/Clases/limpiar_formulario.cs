/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE AL HACER CLICK EN LA IMAGEN DE LIMPIAR
------SE BORRE EL CONTENIDO DEL FORMULARIO SEA CUAL SEA EN EL PROYECTO----*/

using System.Drawing;
using System.Windows.Forms;


namespace REDACTADOR.Clases

{
    public static class LimpiarFormulario
    {

        // Método estático para limpiar todos los controles dentro del formulario
        // Itera a través de todos los controles dentro del control proporcionado (form o panel)

        public static void Limpiar(Control control)
        {
            foreach (Control c in control.Controls)
            {
                switch (c)
                {
                    // Si el control es un TextBox, limpia su contenido
                    case TextBox textBox:
                        textBox.Clear();
                        break;



                    // Si el control es un RichTextBox, limpiar su contenido
                    case RichTextBox richTextBox:
                        richTextBox.Text = string.Empty;
                        break;


                    case Button button when (button.Name == "btn_Negrita" ||
                                     button.Name == "btn_Cursiva" ||
                                     button.Name == "btn_Subrayado" ||
                                     button.Name == "btn_AlinearDerecha" ||
                                     button.Name == "btn_AlinearIzquierda" ||
                                     button.Name == "btn_Centrar" ||
                                     button.Name == "btn_Justificar"):
                        // Restablecer el color de fondo de los botones de formato
                        button.BackColor = Color.White;
                        break;

                    case Button button when (button.Name == "btn_Microfono"):
                        // Restablecer el color de fondo 
                        button.BackColor = Color.Red;
                        //StopRecording();
                        break;

                    case Control nestedControl when nestedControl.HasChildren:
                        Limpiar(nestedControl);
                        break;


                        control.Controls.Remove(c);
                        c.Dispose();
                        break;
                }
            }
        }




    }
}
