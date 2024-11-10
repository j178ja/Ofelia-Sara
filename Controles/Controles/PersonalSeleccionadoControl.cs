
using BaseDatos.Adm_BD.Manager;
using Controles.Controles.Reposicionar_paneles.Buscar_Personal;
using Ofelia_Sara.Formularios;
using Ofelia_Sara.Mensajes;
using Ofelia_Sara.Registro_de_personal;
using System;
using System.Drawing;
using System.Windows.Forms;





namespace Controles.Controles
{

    public partial class PersonalSeleccionadoControl : UserControl
    {
        // Evento que será lanzado cuando se clickee el botón para modificar el personal
        public event EventHandler ModificarPersonalClicked;

        private PersonalManager _personalManager;
        public PersonalSeleccionadoControl()
        {
            InitializeComponent();
            _personalManager = new PersonalManager();

        }

        public void ActualizarDatosPorLegajo(string numeroLegajo)
        {
            var personal = _personalManager.ObtenerPersonalDTOPorLegajo(numeroLegajo);

            if (personal != null)
            {
                // Asignar los valores obtenidos a los labels correspondientes
                label_NumeroLegajo.Text = personal.Legajo.ToString();
                label_Funcion.Text = personal.Funcion;
                label_Dependencia.Text = personal.Dependencia + " " + personal.LocalidadDependencia;
                label_Nombre.Text = personal.Nombres;
                label_Apellido.Text = personal.Apellido;

                // Combinar Jerarquía y Escalafón en el formato solicitado
                string jerarquiaEscalafon = $"{personal.Jerarquia} ({personal.Escalafon})";

                // Limpiar el RichTextBox antes de asignar texto
                richTextBox_JerarquiaEscalafon.Clear();

                // Mostrar en el RichTextBox el texto combinado
                richTextBox_JerarquiaEscalafon.Text = $"{personal.Jerarquia} ";

                // Encontrar la posición del Escalafón en el texto
                int posicionEscalafon = richTextBox_JerarquiaEscalafon.Text.Length;
                richTextBox_JerarquiaEscalafon.AppendText($"({personal.Escalafon})");

                // Cambiar el color de Jerarquía a RGB(0, 56, 97) y estilo de fuente
                richTextBox_JerarquiaEscalafon.Select(0, personal.Jerarquia.Length); // Seleccionar "Jerarquía"
                richTextBox_JerarquiaEscalafon.SelectionColor = Color.FromArgb(0, 56, 97); // Color Jerarquía
                richTextBox_JerarquiaEscalafon.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold); // Fuente Jerarquía

                // Cambiar el color de Escalafón a RGB(0, 154, 174) y estilo de fuente
                richTextBox_JerarquiaEscalafon.Select(posicionEscalafon, personal.Escalafon.Length + 2); // Seleccionar "(Escalafón)"
                richTextBox_JerarquiaEscalafon.SelectionColor = Color.FromArgb(0, 154, 174); // Color Escalafón
                richTextBox_JerarquiaEscalafon.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold); // Fuente Escalafón

                // Para que el color y la fuente se apliquen, desmarcamos la selección
                richTextBox_JerarquiaEscalafon.SelectionLength = 0;


            }
            else
            {
                // llegada a esta instancia no deberia no aparecer el legajo peeero por si surge el error
                MensajeGeneral.Mostrar("No se encontró el personal con el número de legajo ingresado.", MensajeGeneral.TipoMensaje.Error);
            }
        }


        //------------------------------------------------------------------------------------------

        private void btn_ModificarPersonal_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de usuario para la validación previa
            using (UsuarioForm usuarioForm = new UsuarioForm())
            {
                DialogResult result = usuarioForm.ShowDialog();

                // Verificar el resultado de la validación
                if (result == DialogResult.OK)
                {
                    string numeroLegajo = label_NumeroLegajo.Text;

                    // Crear una instancia del formulario NuevoPersonal, pasando el número de legajo si es necesario
                    NuevoPersonal formularioEdicion = new NuevoPersonal(numeroLegajo); // Asegúrate de que el constructor acepte un string

                    // Mostrar el formulario de edición
                    formularioEdicion.ShowDialog();
                }
                else
                {
                    // Si la validación falla, mostrar un mensaje de advertencia
                    MensajeGeneral.Mostrar("Validación fallida. No se puede editar el personal.", MensajeGeneral.TipoMensaje.Advertencia);
                }
            }
        }


        private void Btn_EliminarControl_Click(object sender, EventArgs e)
        {
            Control controlEliminado = this;
            // Obtener el panel y el formulario principal donde están los controles
            Panel panel_PersonalSeleccionado = this.Parent as Panel; // Asumiendo que este control está dentro de este panel
            Panel panel1 = panel_PersonalSeleccionado.Parent as Panel; // El panel contenedor del panel_PersonalSeleccionado
            Form formulario = panel1.FindForm(); // El formulario principal

            // Verificar si las referencias son válidas antes de llamar al método
            if (panel_PersonalSeleccionado != null && panel1 != null && formulario != null)
            {
                // Instanciar la clase AgregarPersonal
                AgregarPersonal agregarPersonal = new AgregarPersonal();
                // Llamar al método para reposicionar los controles y ajustar tamaños
                agregarPersonal.ReposicionarControles(panel_PersonalSeleccionado, controlEliminado, panel1, formulario);
            }

            // Eliminar este control del panel
            panel_PersonalSeleccionado.Controls.Remove(controlEliminado);
        }



        private void PersonalSeleccionadoControl_Load(object sender, EventArgs e)
        {

        }

    }
}
