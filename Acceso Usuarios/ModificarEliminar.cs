using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Base_de_Datos.Entidades;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.Formularios;

namespace Ofelia_Sara.Acceso_Usuarios
{
    public partial class ModificarEliminar : BaseForm
    {
        private TextBox textBox_Dependencia;
        private TextBox textBox_Domicilio;
        private Label label_Dependencia;
        private Label label_Domicilio;
        private Panel panel_Detalles;
        //private Panel panel_DetallesFiscalia;

        public ModificarEliminar()
        {
            InitializeComponent();

            InicializarEstiloBotonPropio(btn_Eliminar);
            InicializarEstiloBotonPropio(btn_Cancelar);
            InicializarEstiloBotonPropio(btn_Guardar);
            InicializarEstiloBotonPropio(btn_Editar);

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
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
        //------------------------------------------------------------------------
        //-----------PANEL MODIFICAR DEPENDENCIA--------------------------------------
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

       

        //------------------------------------------------------------------------
        //-----------PANEL MODIFICAR FISCALIA--------------------------------------
       
        private void CrearPanelDetallesFiscalia()
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
                Location = new Point(3, 137)
            };

            // Inicializa los controles para mostrar los detalles
            TextBox textBox_NombreFiscalia = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_AgenteFiscal = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_Localidad = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_DeptoJudicial = new TextBox { ReadOnly = true, Width = 295, Height = 20 };

            // Inicializa los Label para los nombres de los campos
            Label label_NombreFiscalia = new Label { Text = "FISCALIA :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_AgenteFiscal = new Label { Text = "DR. :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Localidad = new Label { Text = "Localidad :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_DeptoJudicial = new Label { Text = "Depto. Judicial :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };

            // Añade los controles al panel
            panel_Detalles.Controls.Add(label_NombreFiscalia);
            panel_Detalles.Controls.Add(textBox_NombreFiscalia);
            panel_Detalles.Controls.Add(label_AgenteFiscal);
            panel_Detalles.Controls.Add(textBox_AgenteFiscal);
            panel_Detalles.Controls.Add(label_Localidad);
            panel_Detalles.Controls.Add(textBox_Localidad);
            panel_Detalles.Controls.Add(label_DeptoJudicial);
            panel_Detalles.Controls.Add(textBox_DeptoJudicial);

            // Organiza la posición de los controles dentro del panel
            label_NombreFiscalia.Location = new Point(152, 10);
            textBox_NombreFiscalia.Location = new Point(245, 10);

            label_AgenteFiscal.Location = new Point(195, 40);
            textBox_AgenteFiscal.Location = new Point(245, 40);

            label_Localidad.Location = new Point(148, 69);
            textBox_Localidad.Location = new Point(245, 70);

            label_DeptoJudicial.Location = new Point(110, 99);
            textBox_DeptoJudicial.Location = new Point(245, 100);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            // Define un margen superior (la distancia entre el panel superior y panel_Detalles)
            int topMargin = 10;

            // Ajusta la posición de panel_Detalles teniendo en cuenta el margen superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom + topMargin);

            // Mueve el panel_Botones hacia abajo para evitar superposición
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom + 1);

            // Ajusta la altura del formulario para acomodar los paneles
            this.Height = panel_Botones.Bottom + 220;
        }
        //------------------------------------------------------------------------
        //-----------PANEL MODIFICAR SECRETARIO--------------------------------------
        private void CrearPanelDetallesSecretario()
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
                Location = new Point(3, 137),
                
            };

            // Inicializa los controles para mostrar los detalles
            TextBox textBox_Legajo = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            ComboBox comboBox_Escalafon = new ComboBox { Width = 295, Height = 20, Enabled = false };
            ComboBox comboBox_Jerarquia = new ComboBox { Width = 295, Height = 20, Enabled = false };
            TextBox textBox_Nombre = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_Apellido = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            ComboBox comboBox_Dependencia = new ComboBox { Width = 295, Height = 20, Enabled = false };
            TextBox textBox_Funcion = new TextBox { ReadOnly = true, Width = 295, Height = 20 };

            // Inicializa los Label para los nombres de los campos
            Label label_Legajo = new Label { Text = "LEGAJO :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Escalafon = new Label { Text = "ESCALAFON :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Jerarquia = new Label { Text = "JERARQUIA :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Nombre = new Label { Text = "NOMBRE :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Apellido = new Label { Text = "APELLIDO :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Dependencia = new Label { Text = "DEPENDENCIA :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Funcion = new Label { Text = "FUNCION :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };

            // Añade los controles al panel
            panel_Detalles.Controls.Add(label_Legajo);
            panel_Detalles.Controls.Add(textBox_Legajo);
            panel_Detalles.Controls.Add(label_Escalafon);
            panel_Detalles.Controls.Add(comboBox_Escalafon);
            panel_Detalles.Controls.Add(label_Jerarquia);
            panel_Detalles.Controls.Add(comboBox_Jerarquia);
            panel_Detalles.Controls.Add(label_Nombre);
            panel_Detalles.Controls.Add(textBox_Nombre);
            panel_Detalles.Controls.Add(label_Apellido);
            panel_Detalles.Controls.Add(textBox_Apellido);
            panel_Detalles.Controls.Add(label_Dependencia);
            panel_Detalles.Controls.Add(comboBox_Dependencia);
            panel_Detalles.Controls.Add(label_Funcion);
            panel_Detalles.Controls.Add(textBox_Funcion);

            // Organiza la posición de los controles dentro del panel
            label_Legajo.Location = new Point(156, 9);
            textBox_Legajo.Location = new Point(245, 10);

            label_Escalafon.Location = new Point(121, 40);
            comboBox_Escalafon.Location = new Point(245, 40);

            label_Jerarquia.Location = new Point(128, 70);
            comboBox_Jerarquia.Location = new Point(245, 70);

            label_Nombre.Location = new Point(150, 100);
            textBox_Nombre.Location = new Point(245, 100);

            label_Apellido.Location = new Point(140, 130);
            textBox_Apellido.Location = new Point(245, 130);

            label_Dependencia.Location = new Point(104, 160);
            comboBox_Dependencia.Location = new Point(245, 160);

            label_Funcion.Location = new Point(148, 190);
            textBox_Funcion.Location = new Point(245, 190);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            //// Define un margen superior (la distancia entre el panel superior y panel_Detalles)
            int topMargin = 0;

            //// Ajusta la posición de panel_Detalles teniendo en cuenta el margen superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom + topMargin);
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom + topMargin);

            //// Define el margen exacto entre panel_Detalles y panel_Botones
            int margenEntrePaneles = 10; // Cambia a 10 para una separación exacta

            //// Mueve el panel_Botones hacia abajo para evitar superposición
            panel_Botones.Location = new Point(30, panel_Detalles.Bottom + margenEntrePaneles);

            //// Ajusta la altura del formulario para que panel_Botones esté alineado con el final de panel1
            this.Height = panel_Botones.Bottom + 10; // Ajuste final para acomodar los paneles

            //// También puedes ajustar el tamaño del formulario para asegurar que los paneles sean visibles
            this.Height = Math.Max(this.Height, panel_Botones.Bottom + 300);

            // Desplaza el formulario hacia arriba en la pantalla
            int desplazamientoVertical = 250; // Cantidad de píxeles para desplazar el formulario hacia arriba
            this.Top -= desplazamientoVertical; // Ajusta la posición del formulario hacia arriba
        }
        //------------------------------------------------------------------------
        //-----------PANEL MODIFICAR INSTRUCTOR--------------------------------------
        private void CrearPanelDetallesInstructor()
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
                Location = new Point(3, 137),
               
            };

            // Inicializa los controles para mostrar los detalles
            TextBox textBox_Legajo = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            ComboBox comboBox_Escalafon = new ComboBox { Width = 295, Height = 20, Enabled = false };
            ComboBox comboBox_Jerarquia = new ComboBox { Width = 295, Height = 20, Enabled = false };
            TextBox textBox_Nombre = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_Apellido = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            ComboBox comboBox_Dependencia = new ComboBox { Width = 295, Height = 20, Enabled = false };
            TextBox textBox_Funcion = new TextBox { ReadOnly = true, Width = 295, Height = 20 };

            // Inicializa los Label para los nombres de los campos
            Label label_Legajo = new Label { Text = "LEGAJO :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Escalafon = new Label { Text = "ESCALAFON :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Jerarquia = new Label { Text = "JERARQUIA :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Nombre = new Label { Text = "NOMBRE :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Apellido = new Label { Text = "APELLIDO :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Dependencia = new Label { Text = "DEPENDENCIA :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            Label label_Funcion = new Label { Text = "FUNCION :", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };

            // Añade los controles al panel
            panel_Detalles.Controls.Add(label_Legajo);
            panel_Detalles.Controls.Add(textBox_Legajo);
            panel_Detalles.Controls.Add(label_Escalafon);
            panel_Detalles.Controls.Add(comboBox_Escalafon);
            panel_Detalles.Controls.Add(label_Jerarquia);
            panel_Detalles.Controls.Add(comboBox_Jerarquia);
            panel_Detalles.Controls.Add(label_Nombre);
            panel_Detalles.Controls.Add(textBox_Nombre);
            panel_Detalles.Controls.Add(label_Apellido);
            panel_Detalles.Controls.Add(textBox_Apellido);
            panel_Detalles.Controls.Add(label_Dependencia);
            panel_Detalles.Controls.Add(comboBox_Dependencia);
            panel_Detalles.Controls.Add(label_Funcion);
            panel_Detalles.Controls.Add(textBox_Funcion);

            // Organiza la posición de los controles dentro del panel
            label_Legajo.Location = new Point(156, 9);
            textBox_Legajo.Location = new Point(245, 10);

            label_Escalafon.Location = new Point(121, 40);
            comboBox_Escalafon.Location = new Point(245, 40);

            label_Jerarquia.Location = new Point(128, 70);
            comboBox_Jerarquia.Location = new Point(245, 70);

            label_Nombre.Location = new Point(150, 100);
            textBox_Nombre.Location = new Point(245, 100);

            label_Apellido.Location = new Point(140, 130);
            textBox_Apellido.Location = new Point(245, 130);

            label_Dependencia.Location = new Point(104, 160);
            comboBox_Dependencia.Location = new Point(245, 160);

            label_Funcion.Location = new Point(148, 190);
            textBox_Funcion.Location = new Point(245, 190);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            //// Define un margen superior (la distancia entre el panel superior y panel_Detalles)
            int topMargin = 0;

            //// Ajusta la posición de panel_Detalles teniendo en cuenta el margen superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom + topMargin);
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom + topMargin);

            //// Define el margen exacto entre panel_Detalles y panel_Botones
            int margenEntrePaneles = 10; // Cambia a 10 para una separación exacta

            //// Mueve el panel_Botones hacia abajo para evitar superposición
            panel_Botones.Location = new Point(30, panel_Detalles.Bottom + margenEntrePaneles);

            //// Ajusta la altura del formulario para que panel_Botones esté alineado con el final de panel1
            this.Height = panel_Botones.Bottom + 10; // Ajuste final para acomodar los paneles

            //// También puedes ajustar el tamaño del formulario para asegurar que los paneles sean visibles
            this.Height = Math.Max(this.Height, panel_Botones.Bottom + 300);

            // Desplaza el formulario hacia arriba en la pantalla
            int desplazamientoVertical = 250; // Cantidad de píxeles para desplazar el formulario hacia arriba
            this.Top -= desplazamientoVertical; // Ajusta la posición del formulario hacia arriba
            //int desplazamientoLateral = 50; 
            //this.Left += desplazamientoLateral;
        }
        //_________________________________________________________________________________
        //-----ESTETICA DE BOTONES---------------------------------------------------

        protected void InicializarEstiloBotonPropio(Button boton)
        {
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;

            // Evento Paint: Dibuja un borde redondeado y aplica el color del texto solo si el botón está habilitado
            boton.Paint += (sender, e) =>
            {
                int bordeGrosor;
                int bordeRadio;
                Color bordeColor;

                if (boton.Enabled)
                {
                    bordeGrosor = 3;
                    bordeRadio = 4;
                    bordeColor = Color.LightGreen; // Color del borde cuando el botón está habilitado
                }
                else
                {
                    bordeGrosor = 2;
                    bordeRadio = 8;
                    bordeColor = Color.Tomato; // Color del borde cuando el botón está deshabilitado
                }

                using (GraphicsPath path = new GraphicsPath())
                {
                    // Define el rectángulo con el radio especificado
                    path.AddArc(new Rectangle(0, 0, bordeRadio, bordeRadio), 180, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, 0, bordeRadio, bordeRadio), 270, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 0, 90);
                    path.AddArc(new Rectangle(0, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 90, 90);
                    path.CloseAllFigures();

                    // Dibuja el borde con el color especificado
                    e.Graphics.DrawPath(new Pen(bordeColor, bordeGrosor), path);
                }
            };

            // Evento MouseEnter: Cambia el tamaño desde el centro y el color de fondo
            boton.MouseEnter += (sender, e) =>
            {
                int incremento = 12; // Incremento de tamaño
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

                boton.BackColor = Color.FromArgb(51, 174, 189); // Color de fondo al pasar el mouse
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
                boton.BackColor = Color.FromArgb(51, 174, 189); // Color de fondo cuando el mouse está sobre el botón
            };

            // Evento MouseLeave: Restaura el tamaño, la posición y el color de fondo original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.SkyBlue; // Color de fondo original
            };

            // Llama a Invalidate para asegurarse de que el borde se dibuje inicialmente
            boton.Invalidate();
        }





        //-------------------------------------------------------------------------------------------
        //----------------BOTON EDITAR------------------------------------------
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
                        CrearPanelDetallesSecretario();
                        break;

                    case "Instructor":
                        // Crear  panel de detalles
                        CrearPanelDetallesInstructor();
                        break;

                    case "Fiscalía":
                        // Crear  panel de detalles
                        CrearPanelDetallesFiscalia();
                        break;

                    // Puedes añadir más casos según los ítems disponibles en listBox_Seleccion
                    default:
                        MessageBox.Show("El elemento seleccionado no tiene un panel de edición asociado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
        //__________________________________________________________________________________
        //-------------BOTON CANCELAR---------------------------

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            // Ocultar y eliminar panel_Detalles si está visible
            if (panel_Detalles != null && panel_Detalles.Visible)
            {
                panel_Detalles.Visible = false;
                Controls.Remove(panel_Detalles);
                panel_Detalles.Dispose(); // Libera los recursos utilizados por el panel
                panel_Detalles = null; // Asegura que el panel ya no esté referenciado
            }


            // Restablecer el estado de los controles principales
            listBox_Datos.DataSource = null;
            listBox_Datos.Items.Clear(); // Limpiar elementos si es necesario
            listBox_Datos.Enabled = false; // Desactivar si estaba habilitado
            listBox_Datos.BackColor = Color.LightGray;

            // Reubicar y hacer visible el panel_Botones
            panel_Botones.Location = new Point(29, 129);
            panel_Botones.Visible = true;

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
