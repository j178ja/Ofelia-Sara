





namespace DICTADO
{
    public partial class Dictado : Form
    {
        // Constructor modificado para aceptar datos
        public Dictado(string mensaje)
        {
            InitializeComponent();
            // Aqu� puedes usar el par�metro para inicializar el formulario o mostrar el mensaje
            MessageBox.Show(mensaje);
        }
    }
}
