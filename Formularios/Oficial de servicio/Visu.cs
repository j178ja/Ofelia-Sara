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
using BaseDatos.Entidades;
using BaseDatos.Mensaje;
using Clases.Animaciones;
using Clases.Apariencia;
using Clases.Texto;
using iTextSharp.text.pdf.codec.wmf;
using Microsoft.Office.Interop.Word;
using Ofelia_Sara.Clases.Apariencia;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Visu : BaseForm
    {
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
                                            
        private List<string> victimas = new List<string>(); // Listas para almacenar víctimas e imputados
        private List<string> imputados = new List<string>(); // Listas para almacenar víctimas e imputados

        private bool panelExpandido_Instruccion = true;// Variable para rastrear el estado del panel
        private bool panelExpandido_Imagenes = true;// 
        private bool panelExpandido_Vehiculo = true;// 
        private bool panelExpandido_Descripcion = true;// 

        // Altura original y contraída del panel
        private int alturaOriginalPanel;
        private int alturaOriginalPanel_Imagenes;
        private int alturaOriginalPanel_Vehiculo;
        private int alturaOriginalPanel_Descripcion;
        private int alturaContraidaPanel = 30;


        


        public Visu()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(panel1, borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
            //..............................
           
            //..............................
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarCausa);
            InicializarEstiloBotonAgregar(btn_AgregarVictima);
            InicializarEstiloBotonAgregar(btn_AgregarImputado);

            panel_Imagenes.Visible = false;
            panel_DatosVehiculo.Visible = false;
            panel_DatosEspecificos.Visible = false;
            panel_Descripcion.Visible = false;

            richTextBox_Descripcion.TextChanged += (sender, e) => ValidarPanelDescripcion();

            comboBox_Marca.TextChanged += (s, e) =>  ValidarPanelVehiculo();
            comboBox_Modelo.TextChanged += (s, e) =>  ValidarPanelVehiculo();
            comboBox_Color.TextChanged += (s, e) =>  ValidarPanelVehiculo();
            textBox_Chasis.TextChanged += (s, e) =>  ValidarPanelVehiculo();
            textBox_Motor.TextChanged += (s, e) =>  ValidarPanelVehiculo();
            textBox_Dominio.TextChanged += (s, e) =>  ValidarPanelVehiculo();

          
        }
      

        private void Visu_Load(object sender, EventArgs e)
        {
            MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            MayusculaSola.AplicarAControl(textBox_Victima);
            MayusculaSola.AplicarAControl(textBox_Imputado);
            MayusculaSola.AplicarAControl(comboBox_Localidad);
            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Fiscalia);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);
            //......................................................
            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);
            //.......................................................................
            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON

            //cargar desde base de datos
            CargarDatosDependencia(comboBox_Dependencia, dbManager);
            CargarDatosInstructor(comboBox_Instructor, instructoresManager);
            CargarDatosSecretario(comboBox_Secretario, secretariosManager);

            pictureBox_AgregarImagen.BringToFront();
            pictureBox_QuitarImagen.BringToFront();
            pictureBox_DatosVehiculo.BringToFront();
            label_DatosInstruccion.BringToFront();
            btn_AmpliarReducir_INSTRUCCION.BringToFront();
            label_DatosVehiculo.BringToFront();

            Fecha_Instruccion.SelectedDate = DateTime.Now; //para que actualice automaticamente la fecha
         
            alturaOriginalPanel = panel_DatosInstruccion.Height;// Guardar la altura original del panel
            alturaOriginalPanel_Imagenes = panel_Imagenes.Height;// Guardar la altura original del panel
            alturaOriginalPanel_Vehiculo = panel_DatosVehiculo.Height;// Guardar la altura original del panel
            alturaOriginalPanel_Descripcion = panel_Descripcion.Height;// Guardar la altura original del panel

            ValidarPanelDatosInstruccion();
            ValidarPanelDescripcion();
            ValidarPanelVehiculo();

            //para que se carge el panel contraido
            if (panelExpandido_Instruccion)
            {
                // Contraer el panel
                panel_DatosInstruccion.Height = alturaContraidaPanel;
                btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Instruccion = false;

                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    if (control == btn_AmpliarReducir_INSTRUCCION)
                    {
                        control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                    }
                    else
                    {
                        control.Visible = false; // Oculta los demás controles
                    }
                }
            }
            //.................
            //Para cambiar el borde del group segun este seleccionado o no un radiobutom
            foreach (Control ctrl in groupBox_TipoExamenVisu.Controls)
            {
                if (ctrl is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += radioButton_CheckedChanged;
                }
            }

        }
        //--------------------------------------------------------------------------
        //-----para inicializar los COMBOBOX FISCALIA----------------
        private void InicializarComboBoxFISCALIA()
        {

            // Obtener las listas de fiscalías, agentes fiscales, localidades y departamentos judiciales
            List<string> nombresFiscalias = FiscaliaManager.ObtenerNombresFiscalias().Distinct().ToList();
            List<string> agentesFiscales = FiscaliaManager.ObtenerAgentesFiscales().Distinct().ToList();
            List<string> localidades = FiscaliaManager.ObtenerLocalidades().Distinct().ToList();
            List<string> deptosJudiciales = FiscaliaManager.ObtenerDeptosJudiciales().Distinct().ToList();

            // Asignar las listas a los ComboBoxes correspondientes
            comboBox_Fiscalia.DataSource = nombresFiscalias;
            comboBox_AgenteFiscal.DataSource = agentesFiscales;
            comboBox_Localidad.DataSource = localidades;
        


            comboBox_Fiscalia.SelectedIndex = -1;
            comboBox_AgenteFiscal.SelectedIndex = -1;
            comboBox_Localidad.SelectedIndex = -1;
          
        }

        private void ComboBox_Fiscalia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desactivar los ComboBoxes de detalle mientras se actualizan
            comboBox_AgenteFiscal.Enabled = false;
            comboBox_Localidad.Enabled = false;
    

            // Verificar si hay un ítem seleccionado en el comboBox_Fiscalia
            if (comboBox_Fiscalia.SelectedItem != null)
            {
                string nombreFiscalia = comboBox_Fiscalia.SelectedItem.ToString();
                Fiscaliajson fiscalia = FiscaliaManager.ObtenerFiscaliaPorNombre(nombreFiscalia);

                if (fiscalia != null)
                {
                    // Asignar los valores de la fiscalía a los ComboBoxes correspondientes
                    comboBox_AgenteFiscal.DataSource = new List<string> { fiscalia.AgenteFiscal }.Distinct().ToList();
                    comboBox_Localidad.DataSource = new List<string> { fiscalia.Localidad }.Distinct().ToList();
                   
                }
                else
                {
                    // Si no se encuentra la fiscalía, limpiar los ComboBoxes
                    comboBox_AgenteFiscal.DataSource = null;
                    comboBox_Localidad.DataSource = null;
             
                }

                // Reactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.Enabled = true;
                comboBox_Localidad.Enabled = true;
         
            }
            else
            {
                // Si no hay selección, limpiar y desactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.DataSource = null;
                comboBox_Localidad.DataSource = null;
              

                comboBox_AgenteFiscal.Enabled = false;
                comboBox_Localidad.Enabled = false;

            }
        }
        //----------------------------------------------------------------
        //-------------------BOTON AGREGAR CAUSA---------------------
        private void Btn_AgregarCausa_Click(object sender, EventArgs e)
        {
            // Llamar al método en el UserControl para agregar el control
            NuevaCaratulaControl.NuevaCaratulaControlHelper.AgregarNuevoControl(panel_Caratula);

        }

        //------------BOTON AGREGAR VICTIMA----------------------------
        private void Btn_AgregarVictima_Click(object sender, EventArgs e)
        {
            // Primero, valida todos los controles existentes en el panel
            bool controlesCompletos = ValidarControlesExistentes(panel_Victima);

            if (!controlesCompletos)
            {

                // Muestra un mensaje si algún control en el panel está vacío
                MensajeGeneral.Mostrar("Todos los campos en los controles existentes deben completarse antes de agregar una nueva víctima.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Sal de la función para evitar agregar un nuevo control
            }
            else
            {
                // Llamar al método en el UserControl para agregar el control
                NuevaPersonaControl.NuevaPersonaControlHelper.AgregarNuevoControl(panel_Victima, "Victima");

                // Agregar la nueva víctima a la lista
                string nuevaVictima = "Nombre de la nueva víctima";
                victimas.Add(nuevaVictima);

                // Actualizar la lista visual en el formulario, si corresponde
                //lstVictimas.Items.Add(nuevaVictima);
            }
        }

        //-------------BOTON AGREGAR IMPUTADO------------------------------
        private void Btn_AgregarImputado_Click(object sender, EventArgs e)
        {
            // Primero, valida todos los controles existentes en el panel
            bool controlesCompletos = ValidarControlesExistentes(panel_Imputado);

            if (!controlesCompletos)
            {
                // Muestra un mensaje si algún control en el panel está vacío
                MensajeGeneral.Mostrar("Todos los campos en los controles existentes deben completarse antes de agregar un nuevo imputado.", MensajeGeneral.TipoMensaje.Advertencia);
                return; // Sal de la función para evitar agregar un nuevo control
            }
            else
            {
                // Llamar al método en el UserControl para agregar el control
                NuevaPersonaControl.NuevaPersonaControlHelper.AgregarNuevoControl(panel_Imputado, "Imputado");

                // Agregar el nuevo imputado a la lista
                string nuevoImputado = "Nombre del nuevo imputado"; // Aquí deberías obtener el nombre del imputado del nuevo control agregado
                imputados.Add(nuevoImputado);

            }
        }
        // ---METODO PARA VALIDAR LOS CONTROLES DENTRO DE UN PANEL
        private bool ValidarControlesExistentes(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                var personaControl = control as NuevaPersonaControl;
                if (personaControl != null && string.IsNullOrWhiteSpace(personaControl.TextBox_Persona.Text))
                {
                    return false; // Retorna false si se encuentra un control vacío
                }
            }
            return true; // Todos los controles están completos
        }
        //---------------------------------------------------------------------------
        private void Visu_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MensajeGeneral.Mostrar("Completando los datos requeridos se creara documento de examen de VISU y se agregarán las imagenes.", MensajeGeneral.TipoMensaje.Informacion);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }
        //---------------------------------------------------------------------------

        /// <summary>
        /// metodo para destacar seleccion de VISU
        /// </summary>

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si algún RadioButton en el grupo está seleccionado
            bool isChecked = groupBox_TipoExamenVisu.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Cambiar el color del borde del GroupBox según el estado de los RadioButton
            if (isChecked)
            {
                groupBox_TipoExamenVisu.Paint += GroupBox_TipoExamenVisu_Paint_Activated;
            }
            else
            {
                groupBox_TipoExamenVisu.Paint += GroupBox_TipoExamenVisu_Paint_Default;
            }

            // Forzar el repintado del GroupBox
            groupBox_TipoExamenVisu.Invalidate();
       //............................
            // Asegúrate de que el sender es un RadioButton
            if (sender is RadioButton radioButton)
            {
                // Verifica qué RadioButton fue marcado y aplica el estilo correspondiente
                if (radioButton.Checked)
                {
                    // Aplica el estilo personalizado (negrita y subrayado)
                    ApplyCustomFontStyle(radioButton);

                    panel_Imagenes.Visible = true;
                    panel_Descripcion.Visible = true;
           //         AjustarTamanoFormulario();
                    // Controla la visibilidad del panel de datos del vehículo
                    panel_DatosVehiculo.Visible = radioButton_Automovil.Checked || radioButton_Motovehiculo.Checked;
                    panel_DatosEspecificos.Visible = radioButton_Automovil.Checked || radioButton_Motovehiculo.Checked;
            //        AjustarTamanoFormulario();
                    // Cambia la imagen y el color de fondo del PictureBox correspondiente
                    if (radioButton == radioButton_Automovil)
                    {
                        ApplyRoundedCorners(pictureBox_Automovil, 6, true, false, false, true); // Solo esquinas izquierdas
                        ResetPictureBoxStyles(); // Restaura los estilos por defecto de los PictureBox
                        pictureBox_Automovil.BackColor = Color.FromArgb(4, 234, 0);
                        ApplyRoundedCorners(radioButton, 6, false, true, true, false); // Solo esquinas derechas
                    }
                    else if (radioButton == radioButton_Motovehiculo)
                    {
                        ApplyRoundedCorners(pictureBox_Motovehiculo, 6, true, false, false, true);
                        ResetPictureBoxStyles();
                        pictureBox_Motovehiculo.BackColor = Color.FromArgb(4, 234, 0);
                        ApplyRoundedCorners(radioButton, 6, false, true, true, false); 
                    }
                    else if (radioButton == radioButton_Objeto)
                    {
                        ApplyRoundedCorners(pictureBox_Objeto, 6, true, false, false, true);
                        ResetPictureBoxStyles();
                        pictureBox_Objeto.BackColor = Color.FromArgb(4, 234, 0);
                        ApplyRoundedCorners(radioButton, 6, false, true, true, false);
                    }
                    
                }
                else 
                {
                    // Restaura el estilo normal si el RadioButton se desmarca
                    radioButton.Font = new System.Drawing.Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Regular);
                    radioButton.ForeColor = SystemColors.ControlText;
                    radioButton.BackColor = Color.FromArgb(178, 213, 230);
                }
            }
        }

        /// <summary>
        /// Restaura los estilos por defecto de todos los PictureBox.
        /// </summary>
        private void ResetPictureBoxStyles()
        {
            pictureBox_Automovil.BackColor = Color.FromArgb(178, 213, 230);
            pictureBox_Motovehiculo.BackColor = Color.FromArgb(178, 213, 230);
            pictureBox_Objeto.BackColor = Color.FromArgb(178, 213, 230);

        }

        // Método para aplicar el estilo personalizado (negrita y subrayado)
        private void ApplyCustomFontStyle(RadioButton radioButton)
        {
            // Crea una fuente con negrita y subrayado
            System.Drawing.Font customFont = new System.Drawing.Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Bold);

            // Cambia la fuente del RadioButton
            radioButton.Font = customFont;
            radioButton.ForeColor = SystemColors.HotTrack;
            radioButton.BackColor = Color.FromArgb(228, 247, 222);
           
            // Redibuja el RadioButton para reflejar el cambio
            radioButton.Invalidate();
        }
        //----------------------------------------------------------------------------------------------------
        // METODOS PARA CAMBIAR EL COLOR DE BORDE DEL GROUP SEGUN ESTE SELECCIONADO O NO 

        private void GroupBox_TipoExamenVisu_Paint_Activated(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Green, 2)) // Borde verde cuando algún CheckBox está seleccionado
            {
                e.Graphics.DrawRectangle(pen, groupBox_TipoExamenVisu.ClientRectangle);
            }
        }

        private void GroupBox_TipoExamenVisu_Paint_Default(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 1)) // Borde negro por defecto
            {
                e.Graphics.DrawRectangle(pen, groupBox_TipoExamenVisu.ClientRectangle);
            }
        }

        //---------------------------------------------------------------------------------

        /// <summary>
        /// METODO PARA AGREGAR IMAGENES
        /// </summary>

        private void pictureBox_AgregarImagen_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel_AgregarImagenes.Controls)
            {
                NuevaImagen imagenControl = ctrl as NuevaImagen;
                if (imagenControl != null) // Si es de tipo NuevaImagen
                {
                    if (imagenControl.Image == null || imagenControl.Image == Properties.Resources.agregar_imagen1)
                    {
                        MessageBox.Show("Control sin imagen o imagen predeterminada detectada.");
                        MessageBox.Show("Todos los controles deben contener una imagen antes de agregar una nueva.");
                        return; // No agregar una nueva imagen si alguna no tiene una imagen cargada o tiene la imagen predeterminada
                    }
                }
                else
                {
                    MessageBox.Show($"El control {ctrl.Name} no es de tipo NuevaImagen.");
                }
            }



            // Si llegamos aquí, significa que todos los controles tienen una imagen válida
            // Verificar el límite de 5 controles
            if (panel_AgregarImagenes.Controls.Count >= 5)
            {
                MensajeGeneral.Mostrar("Límite máximo de 5 imágenes alcanzado.", MensajeGeneral.TipoMensaje.Error);
                return;
            }

            // Crear una instancia del control NuevaImagen
            NuevaImagen nuevoControlImagen = new NuevaImagen();

            // Establecer la posición de la nueva imagen
            int nuevaPosicionX = (panel_AgregarImagenes.Controls.Count > 0) ?
                                 panel_AgregarImagenes.Controls[panel_AgregarImagenes.Controls.Count - 1].Right + 5 :
                                 8; // Ajusta este valor para definir el margen inicial

            nuevoControlImagen.Location = new System.Drawing.Point(nuevaPosicionX, 8);

            // Agregar el nuevo control al panel
            panel_AgregarImagenes.Controls.Add(nuevoControlImagen);

            // Calcular el ancho total de todos los controles en el panel, con márgenes
            int totalWidth = 0;
            foreach (Control control in panel_AgregarImagenes.Controls)
            {
                totalWidth += control.Width + 5; // 5 es el margen entre controles
            }

            // Calcular la posición de inicio para centrar los controles en el panel
            int startX = (panel_AgregarImagenes.Width - totalWidth) / 2;

            // Posicionar cada control para que estén centrados horizontalmente
            int currentX = startX;
            foreach (Control control in panel_AgregarImagenes.Controls)
            {
                control.Location = new System.Drawing.Point(currentX, control.Top);
                currentX += control.Width + 5; // Mover a la derecha para el siguiente control
            }
        }

        /// <summary>
        /// METODO PARA QUITAR IMAGENES
        /// </summary>

        private void pictureBox_QuitarImagen_Click(object sender, EventArgs e)
        {
            // Verifica que haya más de un control en el panel
            if (panel_AgregarImagenes.Controls.Count > 1)
            {
                // Eliminar el último control agregado
                Control ultimoControl = panel_AgregarImagenes.Controls[panel_AgregarImagenes.Controls.Count - 1];
                panel_AgregarImagenes.Controls.Remove(ultimoControl);
                ultimoControl.Dispose(); // Liberar recursos del control eliminado

                // Calcular el ancho total de los controles restantes
                int totalWidth = 0;
                foreach (Control control in panel_AgregarImagenes.Controls)
                {
                    totalWidth += control.Width + 5; // 5 es el margen entre controles
                }

                // Calcular la posición de inicio para centrar los controles restantes
                int startX = (panel_AgregarImagenes.Width - totalWidth) / 2;

                // Reposicionar los controles para que estén centrados horizontalmente
                int currentX = startX;
                foreach (Control control in panel_AgregarImagenes.Controls)
                {
                    control.Location = new System.Drawing.Point(currentX, control.Top);
                    currentX += control.Width + 5; // Mover a la derecha para el siguiente control
                }
            }
            else
            {
                // Mostrar mensaje si se intenta eliminar el último control
                MensajeGeneral.Mostrar("El examen de visu debe tener al menos una imagen.", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// METODO ESPECIFICO PARA REDONDEAR PICTURE Y RADIOBUTON
        /// </summary>
       
        private GraphicsPath GetRoundedRectanglePath(System.Drawing.Rectangle bounds, int radius,
                                             bool roundTopLeft, bool roundTopRight,
                                             bool roundBottomRight, bool roundBottomLeft)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Esquina superior izquierda
            if (roundTopLeft)
                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            else
                path.AddLine(bounds.X, bounds.Y, bounds.X + radius, bounds.Y);

            // Esquina superior derecha
            if (roundTopRight)
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            else
                path.AddLine(bounds.Right - radius, bounds.Y, bounds.Right, bounds.Y);

            // Esquina inferior derecha
            if (roundBottomRight)
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            else
                path.AddLine(bounds.Right, bounds.Bottom - radius, bounds.Right, bounds.Bottom);

            // Esquina inferior izquierda
            if (roundBottomLeft)
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            else
                path.AddLine(bounds.X + radius, bounds.Bottom, bounds.X, bounds.Bottom);

            path.CloseFigure();
            return path;
        }
        private void ApplyRoundedCorners(Control control, int radius,
                                         bool roundTopLeft, bool roundTopRight,
                                         bool roundBottomRight, bool roundBottomLeft)
        {
            if (control.Region != null)
                control.Region.Dispose();

            using (GraphicsPath path = GetRoundedRectanglePath(control.ClientRectangle, radius,
                                                               roundTopLeft, roundTopRight,
                                                               roundBottomRight, roundBottomLeft))
            {
                control.Region = new Region(path);
            }
        }
        /// <summary>
        /// METODO PARA AJUSTAR TAMAÑO DE FORMULARIO Y REPOSICIONAR PANELES
        /// </summary>
        private void AjustarTamanoFormulario()
        {
            
                int posicionVertical = 0; // Comienza desde la parte superior de panel1

                // Ajustar posición de groupBox_TipoExamenVisu (siempre visible)
                groupBox_TipoExamenVisu.Location = new System.Drawing.Point(groupBox_TipoExamenVisu.Location.X, posicionVertical);
                posicionVertical += groupBox_TipoExamenVisu.Height;

                // Ajustar posición de panel_DatosInstruccion
                if (panel_DatosInstruccion.Visible)
                {
                    panel_DatosInstruccion.Location = new System.Drawing.Point(panel_DatosInstruccion.Location.X, posicionVertical);
                    posicionVertical += panel_DatosInstruccion.Height;
                }

                // Ajustar posición de panel_Imagenes
                if (panel_Imagenes.Visible)
                {
                    panel_Imagenes.Location = new System.Drawing.Point(panel_Imagenes.Location.X, posicionVertical);
                    posicionVertical += panel_Imagenes.Height;
                }

                // Ajustar posición de panel_DatosVehiculo
                if (panel_DatosVehiculo.Visible)
                {
                    panel_DatosVehiculo.Location = new System.Drawing.Point(panel_DatosVehiculo.Location.X, posicionVertical);
                    posicionVertical += panel_DatosVehiculo.Height;
                }

                // Ajustar posición de panel_Descripcion
                if (panel_Descripcion.Visible)
                {
                    panel_Descripcion.Location = new System.Drawing.Point(panel_Descripcion.Location.X, posicionVertical);
                    posicionVertical += panel_Descripcion.Height;
                }

                // Ajustar la altura de panel1
                panel1.Height = posicionVertical;

                // Ajustar la altura del formulario (+20 px)
                this.Height = panel1.Location.Y + panel1.Height + 20;
        }
        //----------------------------------------------------------------------------------
        private void AplicarBordePanel(PanelConBordePersonalizado panel, bool camposCompletos)
        {
            if (panel.Width == panel.MinimumSize.Width) // Verifica si el panel está contraído
            {
                if (camposCompletos)
                {
                    panel.BordeColor = Color.FromArgb(4, 200, 0); // Verde
                    panel.BordeGrosor = 2;
                }
                else
                {
                    panel.BordeColor = Color.FromArgb(255, 0, 0); // Rojo
                    panel.BordeGrosor = 2;
                }
            }
            else
            {
                // Restaurar el borde original cuando el panel no esté contraído
                panel.BordeColor = Color.Transparent;
                panel.BordeGrosor = 1;
            }
        }


        //----------------------------------------------------------------------------------
        /// <summary>
        /// METODOS PARA LOS BOTONES AMPLIAR Y REDUCIR PANELES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_AmpliarReducir_INSTRUCCION_Click(object sender, EventArgs e)
        {
            if (panelExpandido_Instruccion)
            {
                // Contraer el panel
                panel_DatosInstruccion.Height = alturaContraidaPanel;
                btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Instruccion = false;

                // Ocultar todos los controles excepto el botón de ampliación/reducción
                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    if (control == btn_AmpliarReducir_INSTRUCCION)
                    {
                        control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                    }
                    else
                    {
                        control.Visible = false; // Oculta los demás controles
                    }
                }

                // Ocultar controles de error personalizados
                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                    {
                        control.Visible = false; // Ocultar imágenes de error
                    }
                }
            }
            else
            {
                // Expandir el panel
                panel_DatosInstruccion.Height = alturaOriginalPanel;
                btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                panelExpandido_Instruccion = true;

                // Mostrar todos los controles
                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    control.Visible = true;
                }

                // Asegurarte de que las imágenes de error se muestren si es necesario
                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
                    {
                        control.Visible = true; // Mostrar imágenes de error
                    }
                }
            }
        }





        private void btn_AmpliarReducir_IMAGENES_Click(object sender, EventArgs e)
        {
            if (panelExpandido_Imagenes)
            {
                // Contraer el panel
                panel_Imagenes.Height = alturaContraidaPanel;
                btn_AmpliarReducir_IMAGENES.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Imagenes = false;

                // Crear un nuevo Label y configurarlo con las propiedades especificadas
                Label labelImagenes = new Label();
                labelImagenes.BackColor = Color.FromArgb(0, 192, 192);
                labelImagenes.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold | FontStyle.Underline);
                labelImagenes.ForeColor = SystemColors.ControlText;
                labelImagenes.Padding = new Padding(20, 3, 20, 5);
                labelImagenes.Text = "IMAGENES";
                labelImagenes.AutoSize = true;
                labelImagenes.Location = new System.Drawing.Point(23, 1);

                // Asegurar que el Label esté al frente en el panel
                labelImagenes.BringToFront();

                // Agregar el Label al panel
                panel_Imagenes.Controls.Add(labelImagenes);

                // Ocultar otros controles excepto el botón de ampliar/reducir
                foreach (Control control in panel_Imagenes.Controls)
                {
                    if (control == btn_AmpliarReducir_IMAGENES || control == labelImagenes)
                    {
                        control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
                    }
                    else
                    {
                        control.Visible = false; // Oculta los demás controles
                    }
                }
            }
            else
            {
                // Expandir el panel
                panel_Imagenes.Height = alturaOriginalPanel_Imagenes;
                btn_AmpliarReducir_IMAGENES.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                panelExpandido_Imagenes = true;

                // Ocultar o quitar el Label cuando el panel se expande
                foreach (Control control in panel_Imagenes.Controls)
                {
                    if (control is Label && control.Text == "IMAGENES")
                    {
                        control.Visible = false; //OCULTAR ESTE CONTROL
                                                
                    }
                    else
                    {
                        control.Visible = true; // Mostrar los demás controles
                    }
                }
            }
       //     AjustarTamanoFormulario();
        }

        private void btn_AmpliarReducir_VEHICULO_Click(object sender, EventArgs e)
        {
            if (panelExpandido_Vehiculo)
            {
                // Contraer el panel
                panel_DatosVehiculo.Height = alturaContraidaPanel;
                btn_AmpliarReducir_VEHICULO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Vehiculo = false;
                panel_DatosVehiculo.BorderStyle = BorderStyle.FixedSingle;

                // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                btn_AmpliarReducir_VEHICULO.Parent = panel_DatosVehiculo;
                btn_AmpliarReducir_VEHICULO.Location = new System.Drawing.Point(558, 1);

                // Crear y agregar el Label "DATOS DEL VEHICULO"
                Label labelVehiculo = new Label
                {
                    Name = "labelVehiculo", // Asegúrate de asignar un nombre único al Label
                    BackColor = Color.FromArgb(0, 192, 192),
                    Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold | FontStyle.Underline),
                    ForeColor = SystemColors.ControlText,
                    Padding = new Padding(20, 3, 20, 5),
                    Text = "DATOS DEL VEHICULO",
                    AutoSize = true,
                    Location = new System.Drawing.Point(23, 1)
                };

                // Asegurarse de que el Label esté visible en el frente
                labelVehiculo.BringToFront();

                // Agregar el Label al panel
                panel_DatosVehiculo.Controls.Add(labelVehiculo);

                // Ocultar otros controles excepto el botón y el Label
                foreach (Control control in panel_DatosVehiculo.Controls)
                {
                    if (control == btn_AmpliarReducir_VEHICULO || control == labelVehiculo
                        ||  control == pictureBox_DatosVehiculo) 
                    {
                        control.Visible = true; // Mantener visible
                    }
                    else
                    {
                        control.Visible = false; // Ocultar los demás controles
                    }
                }
            }
            else
            {
                // Expandir el panel
                panel_DatosVehiculo.Height = alturaOriginalPanel_Vehiculo;
                btn_AmpliarReducir_VEHICULO.Image = Properties.Resources.dobleFlechaARRIBA;
                panelExpandido_Vehiculo = true;
                panel_DatosVehiculo.BorderStyle = BorderStyle.None;

                // Mover el botón al panel_DatosEspecificos
                btn_AmpliarReducir_VEHICULO.Parent = panel_DatosEspecificos;
                btn_AmpliarReducir_VEHICULO.Location = new System.Drawing.Point(558, 1);

                // Buscar y ocultar o eliminar el Label dinámico
                Control labelVehiculo = panel_DatosVehiculo.Controls["labelVehiculo"];
                if (labelVehiculo != null)
                {
                    panel_DatosVehiculo.Controls.Remove(labelVehiculo);
                    labelVehiculo.Dispose(); // Liberar recursos del Label
                }

                // Mostrar los demás controles del panel
                foreach (Control control in panel_DatosVehiculo.Controls)
                {
                    control.Visible = true;
                }
            }

            // Ajustar el tamaño del formulario si es necesario
        //    AjustarTamanoFormulario();
        }
        //---------------------------------------------------------------------
        private void btn_AmpliarReducir_DESCRIPCION_Click(object sender, EventArgs e)
        {
            if (panelExpandido_Descripcion)
            {
                // Contraer el panel
                panel_Descripcion.Height = alturaContraidaPanel;
                btn_AmpliarReducir_DESCRIPCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Descripcion = false;
                panel_Descripcion.BorderStyle = BorderStyle.FixedSingle;




                foreach (Control control in panel_Descripcion.Controls)
                {
                    if (control == btn_AmpliarReducir_DESCRIPCION ||
                        control == label_Descripcion ||
                        control == pictureBox_Descripcion) // Compara directamente el control
                    {
                        control.Visible = true; // Mantener visible
                    }
                    else
                    {
                        control.Visible = false; // Ocultar los demás controles
                    }
                }

            }
            else
            {
                // Expandir el panel
                panel_Descripcion.Height = alturaOriginalPanel_Descripcion;
                btn_AmpliarReducir_DESCRIPCION.Image = Properties.Resources.dobleFlechaARRIBA;
                panelExpandido_Descripcion = true;
                panel_Descripcion.BorderStyle = BorderStyle.None;

                // Mostrar los demás controles del panel
                foreach (Control control in panel_Descripcion.Controls)
                {
                    control.Visible = true;
                }
            }

            // Ajustar el tamaño del formulario si es necesario
            //    AjustarTamanoFormulario();
        }

        /// <summary>
        /// METODO PARA VALIDAR DAROS DE LOS PANELES
        /// </summary>

        private void ValidarPanelDatosInstruccion()
        {
            bool camposValidos = true;

          

            // Iterar sobre los controles dentro del panel
            foreach (Control control in panel_DatosInstruccion.Controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    camposValidos = false;
                    break; // Si encontramos un campo vacío, no es necesario seguir buscando
                }
                else if (control is ComboBox comboBox && (comboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox.Text)))
                {
                    camposValidos = false;
                    break; // Si encontramos un ComboBox sin selección o sin texto, salimos
                }
            }

            // Actualizar la imagen en pictureBox
            if (camposValidos)
            {
                pictureBox_Validacion.Image = Properties.Resources.verificacion_exitosa; // Imagen personalizada para validación correcta
                pictureBox_Validacion.BackColor = Color.Transparent; // Fondo transparente
                label_DatosInstruccion.BackColor = Color.FromArgb(4, 200, 0); // resalta con color verde más brillante que el original
               
            }
            else
            {
                pictureBox_Validacion.Image = Properties.Resources.Advertencia_Faltante; // Imagen para error
                pictureBox_Validacion.BackColor = Color.Transparent; // Fondo transparente
                label_DatosInstruccion.BackColor = Color.FromArgb(0, 192, 192); // retoma color original verde agua
              
            }

            // Ajustar la posición del pictureBox al lado del label
            pictureBox_Validacion.Location = new System.Drawing.Point(
                label_DatosInstruccion.Right + 5, // A la derecha del label con un margen de 5 px
                label_DatosInstruccion.Top + (label_DatosInstruccion.Height - pictureBox_Validacion.Height) / 2 // Centrado verticalmente
            );

            // Configurar el tamaño de la imagen para que abarque todo el contenedor del pictureBox
            pictureBox_Validacion.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asegurarse de que el pictureBox sea visible
            pictureBox_Validacion.Visible = true;
        }



        // METODO VALIDAR DATOS EN PANEL IMAGENES
        // METODO PARA VALIDAR DATOS EN PANEL DATOS VEHICULO
        private void ValidarPanelVehiculo()
        {
            bool camposValidos = true;

            // Iterar sobre los controles dentro del panel
            foreach (Control control in panel_DatosEspecificos.Controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    camposValidos = false;
                    break; // Si encontramos un campo vacío, no es necesario seguir buscando
                }
                else if (control is ComboBox comboBox && (comboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox.Text)))
                {
                    camposValidos = false;
                    break; // Si encontramos un ComboBox sin selección o sin texto, salimos
                }
            }
            if (camposValidos)
            {
                pictureBox_DatosVehiculo.Image = Properties.Resources.verificacion_exitosa; // Imagen personalizada para validación correcta
                pictureBox_DatosVehiculo.BackColor = Color.Transparent; // Fondo transparente
                label_DatosVehiculo.BackColor = Color.FromArgb(4, 200, 0);//resalta con color verde mas brillante que el original
            }
            else
            {
                pictureBox_DatosVehiculo.Image = Properties.Resources.Advertencia_Faltante; // Imagen para error
                pictureBox_DatosVehiculo.BackColor = Color.Transparent; // Fondo  de imagen transparente
                label_DatosVehiculo.BackColor = Color.FromArgb(0, 192, 192); //retoma color original verde agua
            }

            // Ajustar la posición del pictureBox al lado del label
            pictureBox_DatosVehiculo.Location = new System.Drawing.Point(
                label_DatosVehiculo.Right + 5, // A la derecha del label con un margen de 5 px
                label_DatosVehiculo.Top + (label_Descripcion.Height - pictureBox_Descripcion.Height) / 2 // Centrado verticalmente
            );

            // Configurar el tamaño de la imagen para que abarque todo el contenedor del pictureBox
            pictureBox_DatosVehiculo.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asegurarse de que el pictureBox sea visible
            pictureBox_DatosVehiculo.Visible = true;
        }


        //----------------------------------------------------------------------------------------------
        // METODO PARA VALIDAR DATOS EN PANEL DESCRIPCION
        private void ValidarPanelDescripcion()
        {
            bool camposValidos = !string.IsNullOrWhiteSpace(richTextBox_Descripcion.Text);

            if (camposValidos)
            {
                pictureBox_Descripcion.Image = Properties.Resources.verificacion_exitosa; // Imagen personalizada para validación correcta
                pictureBox_Descripcion.BackColor = Color.Transparent; // Fondo transparente
                label_Descripcion.BackColor = Color.FromArgb(4, 200, 0); // Resalta con color verde más brillante que el original
            }
            else
            {
                pictureBox_Descripcion.Image = Properties.Resources.Advertencia_Faltante; // Imagen para error
                pictureBox_Descripcion.BackColor = Color.Transparent; // Fondo de imagen transparente
                label_Descripcion.BackColor = Color.FromArgb(0, 192, 192); // Retoma color original verde agua
            }

            

            // Ajustar la posición del pictureBox al lado del label
            pictureBox_Descripcion.Location = new System.Drawing.Point(
                label_Descripcion.Right + 5, // A la derecha del label con un margen de 5 px
                label_Descripcion.Top + (label_Descripcion.Height - pictureBox_Descripcion.Height) / 2 // Centrado verticalmente
            );

            // Configurar el tamaño de la imagen para que abarque todo el contenedor del pictureBox
            pictureBox_Descripcion.SizeMode = PictureBoxSizeMode.StretchImage;

            // Asegurarse de que el pictureBox sea visible
            pictureBox_Descripcion.Visible = true;
        }

        //-----------------------------------------------------------------------------------
        //--para que muestre mensaje de advertencia previo cerrar formulario
        private void Visu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {
                using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
                {
                    // Hacer visibles los botones
                    mensaje.MostrarBotonesConfirmacion(true);

                    DialogResult result = mensaje.ShowDialog();
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Cancelar el cierre del formulario
                    }
                }
            }
        }

        //---------BOTON GUARDAR--------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos básicos están completos
            if (!ValidarAntesdeGuardar()) // Verificación usando ErrorProvider
            {
                // Mostrar mensaje de advertencia si hay errores
                MensajeGeneral.Mostrar("Debe completar los campos Carátula, Imputado y Víctima.",
                                       MensajeGeneral.TipoMensaje.Advertencia);
                return; // Detener la ejecución si hay errores
            }

            datosGuardados = true; // Evitar mensaje de alerta al cerrar el formulario
                                   // Mostrar mensaje de confirmación al guardar exitosamente
            MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);

        }

        private bool ValidarAntesdeGuardar()
        {
            bool esValido = false;

            // Validar campos requeridos
            esValido &= ValidarCampo(textBox_Caratula, "El campo 'Carátula' es obligatorio.");
            esValido &= ValidarCampo(textBox_Imputado, "El campo 'Imputado' es obligatorio.");
            esValido &= ValidarCampo(textBox_Victima, "El campo 'Víctima' es obligatorio.");

            return esValido;
        }

        private bool ValidarCampo(Control control, string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                // Si el campo está vacío, se establece un error en el control y se muestra el PictureBoxError
                SetError(control, mensajeError);
                return false;
            }

            // Si el campo está completo, se limpia el error
            ClearError(control);
            return true;
        }

       
    }

}
