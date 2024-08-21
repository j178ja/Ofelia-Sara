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
        private TextBox textBox_Dependencia;
        private TextBox textBox_Domicilio;
        private Label label_Dependencia;
        private Label label_Domicilio;
        private Panel panel_Detalles;

        public ModificarEliminar()
        {
            InitializeComponent();

            InicializarEstiloBotonAgregar(btn_Eliminar);
            InicializarEstiloBotonAgregar(btn_Cancelar);
            InicializarEstiloBotonAgregar(btn_Guardar);
            InicializarEstiloBotonAgregar(btn_Editar);
        }

        private void ModificarEliminar_Load(object sender, EventArgs e)
        {
            listBox_Datos.Enabled = false; // Desactiva el listBox al inicio
            UpdateListBoxStyle(); // Actualiza el estilo del listBox

            // Deshabilitar botones al inicio
            btn_Editar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = false;

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

            // Habilitar botones si se ha seleccionado un ítem
            if (listBox_Seleccion.SelectedIndex != -1)
            {
                btn_Editar.Enabled = true;
                btn_Cancelar.Enabled = true;
              

                listBox_Datos.Enabled = true; // Habilita el comboBox
                listBox_Datos.BackColor = Color.White;
            }

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
        private void listBox_Datos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar botones si se ha seleccionado un ítem
            if (listBox_Datos.SelectedIndex != -1)
            {
                btn_Eliminar.Enabled = true;
                btn_Guardar.Enabled = true;
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
        private void CrearPanelDetallesDependencia()
        {
            // Verifica si el panel ya existe, para no duplicarlo
            if (panel_Detalles != null)
            {
                panel_Detalles.Visible = true;
                return;
            }

            // Crear e inicializar el panel que contendrá los controles de detalle
            panel_Detalles = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Location = new Point(3, 137) // Ajusta la ubicación dentro de panel1
            };

            // Inicializa los TextBox para mostrar los detalles
            textBox_Dependencia = new TextBox { ReadOnly = true, Width = 326, Height = 21 };
            textBox_Domicilio = new TextBox { ReadOnly = true, Width = 326, Height = 21 };


            // Inicializa los Label para los nombres de los campos con un tamaño de letra más grande
            label_Dependencia = new Label
            {
                Text = "DEPENDENCIA :",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold) // Cambia "Arial" y 12 según lo necesites
            };

            label_Domicilio = new Label
            {
                Text = "DOMICILIO :",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold) // Cambia "Arial" y 12 según lo necesites
            };

            // Añade los controles al panel
            panel_Detalles.Controls.Add(label_Dependencia);
            panel_Detalles.Controls.Add(textBox_Dependencia);
            panel_Detalles.Controls.Add(label_Domicilio);
            panel_Detalles.Controls.Add(textBox_Domicilio);

            // Organiza la posición de los controles dentro del panel
            label_Dependencia.Location = new Point(40, 1);
            textBox_Dependencia.Location = new Point(180, 0);

            label_Domicilio.Location = new Point(40, 35);
            textBox_Domicilio.Location = new Point(180, 36);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            // Define un margen superior (la distancia entre el panel superior y panel_Detalles)
            int topMargin = 10;

            // Ajusta la posición de panel_Detalles teniendo en cuenta el margen superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom + topMargin);

            // Mueve el panel_Botones hacia abajo para evitar superposición
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom + 10);

            // Ajusta la altura del formulario para acomodar los paneles
            this.Height = panel_Botones.Bottom + 100;
        }

        private void ActualizarDetallesDependencia(DependenciasPoliciales dependencia)
        {
            // Asume que el parámetro dependencia contiene los datos del objeto seleccionado
            textBox_Dependencia.Text = dependencia.Dependencia;
            textBox_Domicilio.Text = dependencia.Domicilio;
        }
        //----------------BOTON EDITAR
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            // Limpia los controles anteriores
            ClearModificationControls();

            // Verifica si hay un ítem seleccionado
            if (listBox_Seleccion.SelectedItem != null)
            {
                // Obtiene el ítem seleccionado como una cadena
                string selectedItem = listBox_Seleccion.SelectedItem.ToString();

                // Habilita y actualiza el panel dependiendo del ítem seleccionado
                listBox_Datos.Enabled = true; // Habilita el listBox_Datos
                listBox_Datos.BackColor = Color.White;
                switch (selectedItem)// Dependiendo del ítem seleccionado, crea el panel de detalles correspondiente
                {
                    case "Dependencia":
                        CrearPanelDetallesDependencia();
                        break;

                    case "Secretario":
                        // Crear  panel de detalles
                        //CrearPanelDetallesSecretario();
                        break;

                    case "Instructor":
                        // Crear  panel de detalles
                        //CrearPanelDetallesInstructor();
                        break;

                    case "Fiscalia":
                        // Crear  panel de detalles
                        //CrearPanelDetallesFiscalia();
                        break;

                    // Puedes añadir más casos según los ítems disponibles en listBox_Seleccion
                    default:
                        MessageBox.Show("El elemento seleccionado no tiene un panel de edición asociado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
            //-------------BOTON CANCELAR---------------------------

            private void btn_Cancelar_Click(object sender, EventArgs e)
            {
                // Ocultar el panel de detalles si está visible
                if (panel_Detalles != null && panel_Detalles.Visible)
                {
                    panel_Detalles.Visible = false;
                    Controls.Remove(panel_Detalles);
                    panel_Detalles.Dispose(); // Libera los recursos utilizados por el panel
                    panel_Detalles = null; // Asegura que el panel ya no esté referenciado
                }
                listBox_Datos.DataSource = null;

                // Restablecer el estado de los controles principales
                listBox_Datos.Items.Clear(); // Limpiar elementos si es necesario
                listBox_Datos.Enabled = false; // Desactivar si estaba habilitado
                listBox_Datos.BackColor = Color.LightGray;

                // Reubica el panel_Botones a la posición deseada
                panel_Botones.Location = new Point(29, 129);

                panel_Botones.Visible = true;   // que el panel_Botones sea visible

                // Ajustar la altura del formulario para eliminar el panel de detalles
                this.Height = 354; // Ajusta según necesites, para restaurar la altura original

                // Restablecer la selección en listBox_Seleccion si es necesario
                listBox_Seleccion.SelectedIndex = -1;

            // Deshabilitar botones 
            btn_Editar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = false;
        }

        }
    }

