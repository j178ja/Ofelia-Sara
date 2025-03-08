
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class BuscarForm : BaseForm
    {
        public BuscarForm()
        {
            InitializeComponent();

    

            // Crear una instancia de TimePickerPersonalizado con tamaño especificado
            TimePickerPersonalizado fecha_Instruccion = new TimePickerPersonalizado();

            // Establecer la ubicación del UserControl
            fecha_Instruccion.Location = new Point(150, 50);

            // Agregar el UserControl al formulario
            this.Controls.Add(fecha_Instruccion);
        }

        private void Buscar_Load(object sender, EventArgs e)
        {


        }
     


        private void BuscarForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Complete alguno de los campos requeridos para iniciar la busqueda.");
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario

            MensajeGeneral.Mostrar("Formulario eliminado.", MensajeGeneral.TipoMensaje.Cancelacion);
        }

       

    }
}