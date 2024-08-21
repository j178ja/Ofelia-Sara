using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Base_de_Datos.Entidades;
using Ofelia_Sara.general.clases;

namespace Ofelia_Sara.Acceso_Usuarios
{
    public partial class ModificarEliminar : BaseForm
    {
        public ModificarEliminar()
        {
            InitializeComponent();
        }

        private void ModificarEliminar_Load(object sender, EventArgs e)
        {
            listBox_Datos.Enabled = false; // Desactiva el listBox al inicio
            UpdateListBoxStyle(); // Actualiza el estilo del listBox

            listBox_Seleccion.Visible = true;
            listBox_Seleccion.Enabled = true;
            listBox_Seleccion.Items.Clear();

            listBox_Seleccion.Items.Add("Fiscalía");
            listBox_Seleccion.Items.Add("Instructor");
            listBox_Seleccion.Items.Add("Secretario");
            listBox_Seleccion.Items.Add("Dependencia");

            listBox_Seleccion.SelectedIndex = -1;
        }

        private void Registro_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Seleccione qué tipo de elemento desea modificar y posteriormente seleccione cuál elemento desea modificar o eliminar.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = true; // Cancelar el evento para que no se cierre el formulario
        }

        private void listBox_Seleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearModificationControls();

            if (listBox_Seleccion.SelectedIndex != -1)
            {
                listBox_Datos.Enabled = true; // Habilita el listBox
                UpdateListBoxStyle(); // Actualiza el estilo del listBox

                switch (listBox_Seleccion.SelectedItem.ToString())
                {
                    case "Fiscalía":
                        CargarDatosFiscalia();
                        break;
                    case "Instructor":
                        CargarDatosInstructor();
                        break;
                    case "Secretario":
                        CargarDatosSecretario();
                        break;
                    case "Dependencia":
                        CargarDatosDependencia();
                        break;
                }
            }
        }

        private void CargarDatosFiscalia()
        {
            try
            {
                // Elimina el DataSource para evitar conflictos
                listBox_Datos.DataSource = null;
                listBox_Datos.Items.Clear(); // Limpia los elementos actuales

                List<Fiscalia> fiscalias = FiscaliaManager.ObtenerFiscalias();
                listBox_Datos.DataSource = fiscalias;
                listBox_Datos.DisplayMember = "NombreFiscalia"; // Lo que se mostrará en el listBox
                listBox_Datos.SelectedIndex = -1; // Inicializar con ningún elemento seleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Fiscalía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosInstructor()
        {
            try
            {
                // Elimina el DataSource para evitar conflictos
                listBox_Datos.DataSource = null;
                listBox_Datos.Items.Clear(); // Limpia los elementos actuales

                List<Instructor> instructores = InstructorManager.ObtenerInstructores();
                listBox_Datos.DataSource = instructores;
                listBox_Datos.DisplayMember = "DescripcionCompleta";
                listBox_Datos.SelectedIndex = -1; // Inicializar con ningún elemento seleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Instructor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosSecretario()
        {
            try
            {
                // Elimina el DataSource para evitar conflictos
                listBox_Datos.DataSource = null;
                listBox_Datos.Items.Clear(); // Limpia los elementos actuales

                List<Secretario> secretarios = SecretarioManager.ObtenerSecretarios();
                listBox_Datos.DataSource = secretarios;
                listBox_Datos.DisplayMember = "DescripcionCompleta";
                listBox_Datos.SelectedIndex = -1; // Inicializar con ningún elemento seleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Secretario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDependencia()
        {
            try
            {
                // Elimina el DataSource para evitar conflictos
                listBox_Datos.DataSource = null;
                listBox_Datos.Items.Clear(); // Limpia los elementos actuales

                List<DependenciasPoliciales> dependencias = DependenciaManager.ObtenerDependencias();
                listBox_Datos.DataSource = dependencias;
                listBox_Datos.DisplayMember = "Dependencia";
                listBox_Datos.SelectedIndex = -1; // Inicializar con ningún elemento seleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Dependencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearModificationControls()
        {
            // Elimina la fuente de datos para evitar conflictos
            listBox_Datos.DataSource = null;
            // Limpia los elementos actuales (no necesario, pero puede ser útil)
            listBox_Datos.Items.Clear();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            listBox_Datos.Enabled = false; // Desactiva el listBox
            UpdateListBoxStyle(); // Actualiza el estilo del listBox
        }

        private void UpdateListBoxStyle()
        {
            if (listBox_Datos.Enabled)
            {
                listBox_Datos.BackColor = Color.White;
                listBox_Datos.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                listBox_Datos.BackColor = Color.LightGray;
                listBox_Datos.BorderStyle = BorderStyle.None;
            }
        }
        //-------------------------------------------------------------------------
        // En el constructor del formulario o en el método InitializeComponent
        private TextBox textBoxDependencia;
        private TextBox textBoxDomicilio;

        private void InitializeDetailControls()
        {
            // Inicializa los controles para mostrar los detalles
            textBoxDependencia = new TextBox { ReadOnly = true, Width = 200 };
            textBoxDomicilio = new TextBox { ReadOnly = true, Width = 200 };

            // Añade los controles al formulario
            Controls.Add(textBoxDependencia);
            Controls.Add(textBoxDomicilio);

            // Organiza la posición de los controles
            textBoxDependencia.Location = new Point(10, 50); // Ajusta la posición según necesites
            textBoxDomicilio.Location = new Point(10, 80); // Ajusta la posición según necesites
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            InitializeDetailControls();
        }
    }
}
