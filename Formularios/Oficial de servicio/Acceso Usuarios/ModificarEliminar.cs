﻿using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.Acceso_Usuarios
{
    //private SecretariosManager secretariosManager;
    public partial class ModificarEliminar : BaseForm
    {
        private TextBox textBox_Dependencia;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia;
        private TextBox textBox_Domicilio;
        private TextBox textBox_Localidad;
        private TextBox textBox_Partido;
        private Label label_Dependencia;
        private Label label_Domicilio;
        private Label label_Localidad;
        private Label label_Partido;
        private Panel panel_Detalles;
        private Panel panel_DetallesFiscalia;

        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Escalafon;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Jerarquia;
        private TextBox textBox_NumeroLegajo;
        private TextBox textBox_Nombre;
        private TextBox textBox_Apellido;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Instructor;
        private TextBox textBox_Funcion;




        public ModificarEliminar()
        {
            InitializeComponent();

            InicializarEstiloBotonPropio(btn_Eliminar);
            InicializarEstiloBotonPropio(btn_Cancelar);
            InicializarEstiloBotonPropio(btn_Guardar);
            InicializarEstiloBotonPropio(btn_Editar);


            //para redondear bordes panel
            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 12, borderSize: 7, borderColor: customBorderColor);
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

            secretariosManager = new SecretariosManager();

            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_Editar, "Seleccione los campos requeridos para poder EDITAR.", "EDITAR");
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_Eliminar, "Seleccione los campos requeridos para poder ELIMINARLO.", "ELIMINAR");
            ToolTipGeneral.ShowToolTip(btn_Cancelar, "CANCELAR");

        }

        private void Registro_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MensajeGeneral.Mostrar("Seleccione qué tipo de elemento desea modificar y posteriormente seleccione cuál elemento desea modificar o eliminar."
                , MensajeGeneral.TipoMensaje.Informacion);

            e.Cancel = true; // Cancelar el evento para que no se cierre el formulario
        }

        private void ListBox_Seleccion_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearModificationControls();

            // Verificar si hay un ítem seleccionado
            if (listBox_Seleccion.SelectedIndex != -1)
            {
                btn_Editar.Enabled = true;
                btn_Cancelar.Enabled = true;

                // Habilitar y actualizar el listBox_Datos
                listBox_Datos.Enabled = true; // Habilita el listBox
                listBox_Datos.BackColor = Color.White;
                UpdateListBoxStyle(); // Actualiza el estilo del listBox

                // Cargar datos según la selección
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
            else
            {
                // Deshabilitar botones si no hay selección
                btn_Editar.Enabled = false;
                btn_Cancelar.Enabled = false;
                listBox_Datos.Enabled = false; // Deshabilita el listBox si no hay selección
                listBox_Datos.BackColor = SystemColors.Control; // Restaura el color de fondo
            }


        }

        private void ListBox_Datos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar botones si se ha seleccionado un ítem
            if (listBox_Datos.SelectedIndex != -1)
            {
                btn_Eliminar.Enabled = true;
                btn_Guardar.Enabled = false;// lo mantiene desactivado
            }

        }

        private void CargarDatosFiscalia()
        {
            try
            {
                // Elimina el DataSource para evitar conflictos
                listBox_Datos.DataSource = null;
                listBox_Datos.Items.Clear(); // Limpia los elementos actuales

                //  List<Fiscalia> fiscalias = FiscaliaManager.ObtenerFiscalias();
                //  listBox_Datos.DataSource = fiscalias;
                listBox_Datos.DisplayMember = "NombreFiscalia"; // Lo que se mostrará en el listBox
                listBox_Datos.SelectedIndex = -1; // Inicializar con ningún elemento seleccionado
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Fiscalía: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        private void CargarDatosInstructor()
        {
            try
            {
                listBox_Datos.DataSource = null;
                List<Instructor> instructores = instructoresManager.GetInstructors();

                if (instructores.Count == 0)
                {
                    MensajeGeneral.Mostrar("No hay instructores disponibles para cargar.", MensajeGeneral.TipoMensaje.Informacion);
                    return;
                }

                listBox_Datos.DataSource = instructores;
                listBox_Datos.DisplayMember = "JerarquiaYNombre";
                listBox_Datos.ValueMember = "Id";

                if (listBox_Datos.Items.Count > 0)
                {
                    listBox_Datos.SelectedIndex = 0; // Selecciona el primer elemento
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Instructores: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }




        private void CargarDatosSecretario()
        {
            try
            {
                listBox_Datos.DataSource = null; // Elimina el DataSource para evitar conflictos
                List<Secretario> secretarios = secretariosManager.GetSecretarios(); // Usar la instancia

                if (secretarios.Count == 0)
                {
                    MensajeGeneral.Mostrar("No hay secretarios disponibles para cargar.", MensajeGeneral.TipoMensaje.Informacion);
                    return;
                }

                listBox_Datos.DataSource = secretarios; // Asigna la lista de secretarios al ListBox
                listBox_Datos.DisplayMember = "JerarquiaYNombre"; // Muestra jerarquía y nombre
                listBox_Datos.ValueMember = "Id"; // Utiliza el ID como valor

                if (listBox_Datos.Items.Count > 0)
                {
                    listBox_Datos.SelectedIndex = 0; // Selecciona el primer elemento
                }
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Secretarios: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        private void CargarDatosDependencia()
        {
            try
            {
                // Elimina el DataSource para evitar conflictos
                listBox_Datos.DataSource = null;
                listBox_Datos.Items.Clear(); // Limpia los elementos actuales

                ComisariasManager comisariasManager = new ComisariasManager();
                List<Comisaria> comisarias = comisariasManager.GetComisarias();

                listBox_Datos.DataSource = comisarias;
                listBox_Datos.DisplayMember = "NombreYLocalidad";  //trae nombre y localidad con metodo de comisaria.cs
                listBox_Datos.SelectedIndex = -1; // Inicializa con ningún elemento seleccionado


            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar datos de Comisaría: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
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
                Location = new Point(10, 137) // Ajusta la ubicación dentro de panel1
            };

            // Inicializa los TextBox para mostrar los detalles
            textBox_Dependencia = new TextBox { ReadOnly = true, Width = 300, Height = 21 };
            textBox_Domicilio = new TextBox { ReadOnly = true, Width = 300, Height = 21 };
            textBox_Localidad = new TextBox { ReadOnly = true, Width = 300, Height = 21 };
            textBox_Partido = new TextBox { ReadOnly = true, Width = 300, Height = 21 };
            MayusculaYnumeros.AplicarAControl(textBox_Dependencia);
            MayusculaYnumeros.AplicarAControl(textBox_Domicilio);
            MayusculaYnumeros.AplicarAControl(textBox_Localidad);

            // Suscribirse al evento TextChanged para aplicar CamelCase
            textBox_Partido.TextChanged += TextBox_Partido_TextChanged;



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

            label_Localidad = new Label
            {
                Text = "LOCALIDAD :",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold) // Cambia "Arial" y 12 según lo necesites
            };

            label_Partido = new Label
            {
                Text = "PARTIDO :",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold) // Cambia "Arial" y 12 según lo necesites
            };

            // Añade los controles al panel
            panel_Detalles.Controls.Add(label_Dependencia);
            panel_Detalles.Controls.Add(textBox_Dependencia);
            panel_Detalles.Controls.Add(label_Domicilio);
            panel_Detalles.Controls.Add(textBox_Domicilio);
            panel_Detalles.Controls.Add(label_Localidad);
            panel_Detalles.Controls.Add(textBox_Localidad);
            panel_Detalles.Controls.Add(label_Partido);
            panel_Detalles.Controls.Add(textBox_Partido);

            // Organiza la posición de los controles dentro del panel
            label_Dependencia.Location = new Point(20, 10);
            textBox_Dependencia.Location = new Point(160, 9);

            label_Domicilio.Location = new Point(54, 35);
            textBox_Domicilio.Location = new Point(160, 36);

            label_Localidad.Location = new Point(44, 62);
            textBox_Localidad.Location = new Point(160, 63);

            label_Partido.Location = new Point(66, 89);
            textBox_Partido.Location = new Point(160, 90);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            // Ajusta la posición de panel_Detalles inmediatamente después de panel_Superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom);

            // Ajusta la posición de panel_Botones justo debajo de panel_Detalles con el margen definido
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom - 45);


            // Ajusta la altura de panel1 para que contenga ambos paneles con un margen de 10 px debajo de panel_Botones
            panel1.Height = panel_Botones.Bottom + 70;

            // Ajusta la altura del formulario para que sea 30 píxeles mayor que panel1
            this.Height = panel1.Bottom + 75;
        }

        private void ActualizarDetallesDependencia(DependenciasPoliciales dependencia)
        {
            // Asume que el parámetro dependencia contiene los datos del objeto seleccionado
            textBox_Dependencia.Text = dependencia.Dependencia;
            textBox_Domicilio.Text = dependencia.Domicilio;
        }

        // Método para manejar el evento TextChanged
        private void TextBox_Partido_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto a CamelCase
            string textoConvertido = ConvertirACamelCase.Convertir(textBox_Partido.Text);
            textBox_Partido.TextChanged -= TextBox_Partido_TextChanged; // Desuscribirse para evitar un bucle
            textBox_Partido.Text = textoConvertido; // Asigna el texto convertido
            textBox_Partido.SelectionStart = textBox_Partido.Text.Length; // Mantiene el cursor al final
            textBox_Partido.TextChanged += TextBox_Partido_TextChanged; // Volver a suscribirse
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
                Location = new Point(10, 137)
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
            label_NombreFiscalia.Location = new Point(72, 10);
            textBox_NombreFiscalia.Location = new Point(165, 10);

            label_AgenteFiscal.Location = new Point(115, 40);
            textBox_AgenteFiscal.Location = new Point(165, 40);

            label_Localidad.Location = new Point(68, 69);
            textBox_Localidad.Location = new Point(165, 70);

            label_DeptoJudicial.Location = new Point(30, 99);
            textBox_DeptoJudicial.Location = new Point(165, 100);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            // Ajusta la posición de panel_Detalles inmediatamente después de panel_Superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom);

            // Ajusta la posición de panel_Botones justo debajo de panel_Detalles con el margen definido
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom - 60);


            // Ajusta la altura de panel1 para que contenga ambos paneles con un margen de 10 px debajo de panel_Botones
            panel1.Height = panel_Botones.Bottom + 85;

            // Ajusta la altura del formulario para que sea 30 píxeles mayor que panel1
            this.Height = panel1.Bottom + 75;
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
                Location = new Point(7, 137),

            };

            // Inicializa los controles para mostrar los detalles
            TextBox textBox_Legajo = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            Ofelia_Sara.Controles.General.CustomComboBox comboBox_Escalafon = new Ofelia_Sara.Controles.General.CustomComboBox { Width = 295, Height = 20, Enabled = false };
            Ofelia_Sara.Controles.General.CustomComboBox comboBox_Jerarquia = new Ofelia_Sara.Controles.General.CustomComboBox { Width = 295, Height = 20, Enabled = false };
            TextBox textBox_Nombre = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_Apellido = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia = new Ofelia_Sara.Controles.General.CustomComboBox { Width = 295, Height = 20, Enabled = false };
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
            label_Legajo.Location = new Point(79, 9);
            textBox_Legajo.Location = new Point(168, 10);

            label_Escalafon.Location = new Point(44, 40);
            comboBox_Escalafon.Location = new Point(168, 40);

            label_Jerarquia.Location = new Point(51, 70);
            comboBox_Jerarquia.Location = new Point(168, 70);

            label_Nombre.Location = new Point(73, 100);
            textBox_Nombre.Location = new Point(168, 100);

            label_Apellido.Location = new Point(63, 130);
            textBox_Apellido.Location = new Point(168, 130);

            label_Dependencia.Location = new Point(27, 160);
            comboBox_Dependencia.Location = new Point(168, 160);

            label_Funcion.Location = new Point(71, 190);
            textBox_Funcion.Location = new Point(168, 190);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            AjustarFormulario();


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
                Location = new Point(7, 137),

            };
            //LimpiarControlesInstructor();

            // Inicializa los controles para mostrar los detalles
            TextBox textBox_Legajo = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            Ofelia_Sara.Controles.General.CustomComboBox comboBox_Escalafon = new Ofelia_Sara.Controles.General.CustomComboBox { Width = 295, Height = 20, Enabled = false };
            Ofelia_Sara.Controles.General.CustomComboBox comboBox_Jerarquia = new Ofelia_Sara.Controles.General.CustomComboBox { Width = 295, Height = 20, Enabled = false };
            TextBox textBox_Nombre = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            TextBox textBox_Apellido = new TextBox { ReadOnly = true, Width = 295, Height = 20 };
            Ofelia_Sara.Controles.General.CustomComboBox comboBox_Dependencia = new Ofelia_Sara.Controles.General.CustomComboBox { Width = 295, Height = 20, Enabled = false };
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

            label_Legajo.Location = new Point(79, 9);
            textBox_Legajo.Location = new Point(168, 10);

            label_Escalafon.Location = new Point(44, 40);
            comboBox_Escalafon.Location = new Point(168, 40);

            label_Jerarquia.Location = new Point(51, 70);
            comboBox_Jerarquia.Location = new Point(168, 70);

            label_Nombre.Location = new Point(73, 100);
            textBox_Nombre.Location = new Point(168, 100);

            label_Apellido.Location = new Point(63, 130);
            textBox_Apellido.Location = new Point(168, 130);

            label_Dependencia.Location = new Point(27, 160);
            comboBox_Dependencia.Location = new Point(168, 160);

            label_Funcion.Location = new Point(71, 190);
            textBox_Funcion.Location = new Point(168, 190);

            // Añade el panel_Detalles dentro de panel1
            panel1.Controls.Add(panel_Detalles);

            AjustarFormulario();


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

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            // Verificar si no hay ningún elemento seleccionado en el ListBox
            if (listBox_Datos.SelectedIndex == -1)
            {
                MensajeGeneral.Mostrar("Debe seleccionar un elemento de la lista para EDITAR.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Salir si no hay selección
            }
            else
            {

                // Verifica si hay un ítem seleccionado
                if (listBox_Seleccion.SelectedItem != null)
                {
                    // Obtiene el ítem seleccionado como una cadena
                    string selectedItem = listBox_Seleccion.SelectedItem.ToString();

                    btn_Guardar.Enabled = true;//sehabilita seleccion

                    switch (selectedItem)// Dependiendo del ítem seleccionado, crea el panel de detalles correspondiente
                    {
                        case "Dependencia":
                            CrearPanelDetallesDependencia();
                            CargarDatosSeleccionados();
                            break;

                        case "Secretario":
                            // Crear  panel de detalles
                            CrearPanelDetallesSecretario();
                            CargarDatosSeleccionados();
                            break;

                        case "Instructor":
                            // Crear  panel de detalles
                            CrearPanelDetallesInstructor();
                            CargarDatosSeleccionados();
                            break;

                        case "Fiscalía":
                            // Crear  panel de detalles
                            CrearPanelDetallesFiscalia();
                            CargarDatosSeleccionados();
                            break;

                        // Puedes añadir más casos según los ítems disponibles en listBox_Seleccion
                        default:
                            MensajeGeneral.Mostrar("El elemento seleccionado no tiene un panel de edición asociado.", MensajeGeneral.TipoMensaje.Informacion);
                            break;
                    }
                }
            }
        }
        //-----para cargar los datos al editar---

        private void CargarDatosSeleccionados()

        {
            if (listBox_Datos.SelectedItem is Comisaria selectedComisaria)
            {
                CargarDatosComisaria(selectedComisaria);
            }
            else if (listBox_Datos.SelectedItem is Instructor selectedInstructor)
            {
                CargarDatosInstructor(selectedInstructor);
            }
            else if (listBox_Datos.SelectedItem is Secretario selectedSecretario)
            {
                CargarDatosSecretario(selectedSecretario);
            }
        }


        private void CargarDatosComisaria(Comisaria selectedComisaria)
        {
            //  Carga datos de Comisaría
            textBox_Dependencia.Text = selectedComisaria.Nombre;
            textBox_Dependencia.ReadOnly = false;
            textBox_Domicilio.Text = selectedComisaria.Direccion;
            textBox_Domicilio.ReadOnly = false;
            textBox_Localidad.Text = selectedComisaria.Localidad;
            textBox_Localidad.ReadOnly = false;
            textBox_Partido.Text = selectedComisaria.Partido;
            textBox_Partido.ReadOnly = false;
        }

        private void CargarDatosInstructor(Instructor selectedInstructor)
        {
            try
            {
                // Carga datos de Instructor
                textBox_NumeroLegajo.Text = selectedInstructor.Legajo.ToString();
                textBox_NumeroLegajo.ReadOnly = false;
                comboBox_Escalafon.Text = selectedInstructor.Subescalafon;
                comboBox_Jerarquia.Text = selectedInstructor.Jerarquia;
                textBox_Nombre.Text = selectedInstructor.Nombre;
                textBox_Nombre.ReadOnly = false;
                textBox_Apellido.Text = selectedInstructor.Apellido;
                textBox_Apellido.ReadOnly = false;
                comboBox_Dependencia.Text = selectedInstructor.Dependencia;
                textBox_Funcion.Text = selectedInstructor.Funcion;
                textBox_Funcion.ReadOnly = false;

            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar los datos del instructor seleccionado: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }


        private void CargarDatosSecretario(Secretario selectedSecretario)
        {
            try
            {
                // Carga datos de Secretario
                textBox_NumeroLegajo.Text = selectedSecretario.Legajo.ToString();
                textBox_NumeroLegajo.ReadOnly = false;
                comboBox_Escalafon.Text = selectedSecretario.Subescalafon;
                comboBox_Jerarquia.Text = selectedSecretario.Jerarquia;
                textBox_Nombre.Text = selectedSecretario.Nombre;
                textBox_Nombre.ReadOnly = false;
                textBox_Apellido.Text = selectedSecretario.Apellido;
                textBox_Apellido.ReadOnly = false;
                comboBox_Dependencia.Text = selectedSecretario.Dependencia;
                textBox_Funcion.Text = selectedSecretario.Funcion;
                textBox_Funcion.ReadOnly = false;

            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al cargar los datos del secretario seleccionado" +
                    $" : {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }
        //--------------------------------------------------------


        //__________________________________________________________________________________
        //-------------BOTON CANCELAR---------------------------

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            FinalizarEdicion();

            listBox_Seleccion.SelectedIndex = -1; // hace que se deshabiliten los botones y se ponga gris listbox_Seleccion
        }

        private void FinalizarEdicion()
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

            // Ajustar la altura del formulario para eliminar el panel de detalles
            this.Height = 291; // restaurar la altura original
            panel1.Height = 209;

            // Reubicar  panel_Botones
            panel_Botones.Location = new Point(12, 112);

            // Restablecer la selección en listBox_Seleccion si es necesario
            listBox_Seleccion.SelectedIndex = -1;

            // Deshabilitar botones
            btn_Editar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = false;
        }

        private void AjustarFormulario()
        {
            // Ajusta la posición de panel_Detalles inmediatamente después de panel_Superior
            panel_Detalles.Location = new Point(panel_Detalles.Location.X, panel_Superior.Bottom);

            // Ajusta la posición de panel_Botones justo debajo de panel_Detalles con el margen definido
            panel_Botones.Location = new Point(panel_Botones.Location.X, panel_Detalles.Bottom - 100);


            // Ajusta la altura de panel1 para que contenga ambos paneles con un margen de 10 px debajo de panel_Botones
            panel1.Height = panel_Botones.Bottom + 110;

            // Ajusta la altura del formulario para que sea 30 píxeles mayor que panel1
            this.Height = panel1.Bottom + 75;
        }
        //---------------------------------------------------------------------------------------
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            // Verificar si no hay ningún elemento seleccionado en el ListBox
            if (listBox_Datos.SelectedIndex == -1)
            {
                MensajeGeneral.Mostrar("Debe seleccionar un elemento de la lista para ELIMINAR.", MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            // Obtener el elemento seleccionado
            var selectedItem = listBox_Datos.SelectedItem;

            if (selectedItem == null)
            {
                MensajeGeneral.Mostrar("El elemento seleccionado no es válido.", MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            // Verificar el tipo de objeto y eliminarlo de la base de datos
            if (selectedItem is Comisaria selectedComisaria)
            {
                var dbManager = new ComisariasManager();
                dbManager.DeleteComisaria(selectedComisaria.Id);
                EliminarElementoDeLista(selectedComisaria);
            }
            else if (selectedItem is Instructor selectedInstructor)
            {
                var instructorManager = new InstructoresManager();
                instructorManager.DeleteInstructor(selectedInstructor.Id);
                EliminarElementoDeLista(selectedInstructor);
            }
            else if (selectedItem is Secretario selectedSecretario)
            {
                var secretarioManager = new SecretariosManager();
                secretarioManager.DeleteSecretario(selectedSecretario.Id);
                EliminarElementoDeLista(selectedSecretario);
            }
            //else if (selectedItem is Fiscalia selectedFiscalia)
            //{
            //    var fiscaliaManager = new FiscaliasManager();
            //    fiscaliaManager.DeleteFiscalia(selectedFiscalia.Id);
            //    EliminarElementoDeLista(selectedFiscalia);
            //}
            else
            {
                MensajeGeneral.Mostrar("Tipo de elemento no soportado para eliminación.", MensajeGeneral.TipoMensaje.Error);
                return;
            }

            // Limpiar el ListBox y recargar datos

            //CargarDatosEnListBox();
            ClearModificationControls();
            // Deshabilitar botones
            btn_Editar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = false;
            listBox_Datos.Enabled = false;
            listBox_Datos.BackColor = Color.LightGray;
            MensajeGeneral.Mostrar("El elemento ha sido eliminado.", MensajeGeneral.TipoMensaje.Exito);
        }

        // Método auxiliar para eliminar el elemento seleccionado de la fuente de datos
        private void EliminarElementoDeLista<T>(T item)
        {
            var dataSource = listBox_Datos.DataSource as IList<T>;
            dataSource?.Remove(item);
        }


        //---------------------------------------------------------------------------------------


        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica qué tipo de dependencia se está editando
                if (listBox_Datos.SelectedItem is Comisaria)
                {
                    // Lógica para guardar cambios de Comisaria
                    GuardarCambiosDependencia();
                    FinalizarEdicion();
                }
                else if (listBox_Datos.SelectedItem is Instructor)
                {
                    // Lógica para guardar cambios de Instructor
                    GuardarCambiosInstructor();
                    FinalizarEdicion();
                }
                else if (listBox_Datos.SelectedItem is Secretario)
                {
                    // Lógica para guardar cambios de Secretario
                    GuardarCambiosSecretario();
                    FinalizarEdicion();
                }
                else if (listBox_Datos.SelectedItem is Fiscalia)
                {
                    // Lógica para guardar cambios de Fiscalía
                    GuardarCambiosFiscalia();
                    FinalizarEdicion();
                }

            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"Error al guardar los cambios: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        //------------------------------------------------------------------------
        private void GuardarCambiosDependencia()
        {
            // Verifica que un elemento esté seleccionado y que sea del tipo correcto
            if (listBox_Datos.SelectedItem is Comisaria selectedComisaria)
            {
                // Realiza las asignaciones de datos desde los TextBox
                selectedComisaria.Nombre = textBox_Dependencia.Text.Trim();
                selectedComisaria.Direccion = textBox_Domicilio.Text.Trim();
                selectedComisaria.Localidad = textBox_Localidad.Text.Trim();
                selectedComisaria.Partido = textBox_Partido.Text.Trim();

                // Validaciones básicas antes de guardar
                if (string.IsNullOrWhiteSpace(selectedComisaria.Nombre) ||
                    string.IsNullOrWhiteSpace(selectedComisaria.Localidad))
                {
                    MensajeGeneral.Mostrar("Por favor, complete todos los campos obligatorios.", MensajeGeneral.TipoMensaje.Advertencia);
                    return; // Sale del método si hay campos vacíos
                }

                try
                {
                    // Llama a tu manager para guardar en la base de datos
                    ComisariasManager comisariasManager = new ComisariasManager();
                    comisariasManager.UpdateComisaria(selectedComisaria.Id, selectedComisaria.Nombre, selectedComisaria.Direccion, selectedComisaria.Localidad, selectedComisaria.Partido);

                    MensajeGeneral.Mostrar("Los cambios han sido guardados exitosamente.", MensajeGeneral.TipoMensaje.Exito);
                }
                catch (Exception ex)
                {
                    // Manejo de errores durante la actualización
                    MensajeGeneral.Mostrar($"Error al guardar los cambios: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
                }
            }
            else
            {
                MensajeGeneral.Mostrar("No se ha seleccionado una comisaría válida.", MensajeGeneral.TipoMensaje.Advertencia);
            }
        }

        //-----------------------------------------------------------------------------------------
        private void GuardarCambiosInstructor()
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(comboBox_Jerarquia.Text) ||
                string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                string.IsNullOrWhiteSpace(textBox_Apellido.Text))
            {
                MensajeGeneral.Mostrar("Debe completar los campos JERARQUIA, NOMBRE y APELLIDO.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Salir del método si hay campos vacíos
            }

            // Suponiendo que el ID del instructor que se desea editar está almacenado en un campo o variable
            int instructorId = ObtenerIdDelInstructorSeleccionado(); // Método para obtener el ID del instructor seleccionado

            // Crear el objeto Instructor con los datos editados
            var instructorEditado = new Instructor
            {
                Legajo = float.Parse(textBox_NumeroLegajo.Text),
                Subescalafon = comboBox_Escalafon.Text,
                Jerarquia = comboBox_Jerarquia.Text,
                Nombre = textBox_Nombre.Text,
                Apellido = textBox_Apellido.Text,
                Dependencia = comboBox_Dependencia.Text,
                Funcion = textBox_Funcion.Text
            };

            // Crear instancia del manager y llamar al método de actualización
            InstructoresManager manager = new InstructoresManager();
            manager.UpdateInstructor(instructorId, instructorEditado.Legajo, instructorEditado.Subescalafon, instructorEditado.Jerarquia, instructorEditado.Nombre, instructorEditado.Apellido, instructorEditado.Dependencia, instructorEditado.Funcion);

            // Mostrar mensaje de confirmación
            MensajeGeneral.Mostrar("Los datos del instructor han sido actualizados.", MensajeGeneral.TipoMensaje.Exito);

            // Limpiar los campos del formulario (opcional)
            LimpiarFormulario.Limpiar(this);
            comboBox_Escalafon.SelectedIndex = -1;
            comboBox_Dependencia.SelectedIndex = -1;

            // Recargar los datos del ComboBox de instructores
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
        }

        private int ObtenerIdDelInstructorSeleccionado()
        {
            // Asumiendo que tienes un ComboBox llamado comboBox_Instructor
            // que contiene objetos Instructor o una representación adecuada.

            if (comboBox_Instructor.SelectedItem != null)
            {
                // Obtener el instructor seleccionado
                Instructor instructorSeleccionado = (Instructor)comboBox_Instructor.SelectedItem;

                // Retornar el ID del instructor
                return instructorSeleccionado.Id; // Asegúrate de que la clase Instructor tenga una propiedad Id
            }

            // Retorna un valor por defecto o lanza una excepción si no hay selección
            throw new InvalidOperationException("No se ha seleccionado ningún instructor.");
        }

        //----------------------------------------------------------------------------------------------
        private void GuardarCambiosSecretario()
        {

        }
        private void GuardarCambiosFiscalia()
        {

        }
    }
}
