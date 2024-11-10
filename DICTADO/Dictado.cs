





namespace DICTADO
{
    public partial class Dictado : Form
    {
        // Constructor modificado para aceptar datos
        public Dictado(string mensaje)
        {
            InitializeComponent();
            // Aquí puedes usar el parámetro para inicializar el formulario o mostrar el mensaje
            MessageBox.Show(mensaje);
        }
    }
}
