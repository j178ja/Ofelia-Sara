using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Controles
{
    public partial class TooltipError : UserControl
    {
        //// Definición de los controles
        //private PictureBox icono;
        //private Label mensaje; // Este es el label para el mensaje
        //private PictureBox escudo;

        public TooltipError()
        {
            InitializeComponent();
        }

        // Método para mostrar el mensaje en el label
        public void MostrarMensaje(string mensajeError)
        {
            // Aquí accedemos al control 'mensaje' que es un Label
            mensaje.Text = mensajeError;
        }

        // Aquí van otros métodos y controles
    }
}
