﻿using BaseDatos.Entidades;
using Ofelia_Sara.Clases.General.AmpliarReducir_Paneles;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
//using iTextSharp.text.pdf.codec.wmf;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Visu : BaseForm
    {
        #region VARIABLES
        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados
        private List<string> victimas = []; // Listas para almacenar víctimas e imputados
        private List<string> imputados = []; // Listas para almacenar víctimas e imputados
        private bool panelExpandido_Instruccion = true;// Variable para rastrear el estado del panel
        private bool panelExpandido_Imagenes = true;// 
        private bool panelExpandido_Vehiculo = true;// 
        private bool panelExpandido_Descripcion = true;// 
        // Altura original y contraída del panel
        private int alturaOriginalPanel_Instruccion;
        private int alturaOriginalPanel_Imagenes;
        private int alturaOriginalPanel_Vehiculo;
        private int alturaOriginalPanel_Descripcion;
        private int alturaContraidaPanel = 30;
        private Label labelImagenes;// Para la imagen de carga completa en panel imagenes
        private Cargo formularioCargo; //para cambiar el estado de btn deslizable en cargo

        #endregion

        #region CONSTRUCTOR
        public Visu()
        {
            InitializeComponent();

            // Asignación de eventos
            comboBox_Marca.TextChanged += (s, e) => ValidarPanelVehiculo();
            comboBox_Marca.SelectedIndexChanged += (s, e) => ValidarPanelVehiculo();
            comboBox_Modelo.TextChanged += (s, e) => ValidarPanelVehiculo();
            comboBox_Modelo.SelectedIndexChanged += (s, e) => ValidarPanelVehiculo();
            comboBox_Color.TextChanged += (s, e) => ValidarPanelVehiculo();
            comboBox_Color.SelectedIndexChanged += (s, e) => ValidarPanelVehiculo();
            textBox_Chasis.TextChanged += (s, e) => ValidarPanelVehiculo();
            textBox_Motor.TextChanged += (s, e) => ValidarPanelVehiculo();
            textBox_Dominio.TextChanged += (s, e) => ValidarPanelVehiculo();

            // Validar panel al cargar
            this.Load += (s, e) => ValidarPanelVehiculo();

            panel_Imagenes.Visible = false;
            panel_DatosVehiculo.Visible = false;
            panel_DatosEspecificos.Visible = false;

            //para q se actualize imagen de panel descripcion
            richTextBox_Descripcion.TextChanged += (sender, e) => ValidarPanelDescripcion();
            panel_ControlesInferiores.Visible = false;// inicialice no visible
            panel_Descripcion.Visible = true;

            AjustarTamanoFormulario();// para que carge con altura de formulario ajustada
           
            //pictureBox_CheckLegajoVehicular.Visible = false;
        }
        #endregion

        /// <summary>
        /// SOBRECARGA PARA RECIBIR DATOS DE CARGO Y REFERENCIA AL FORMULARIO PADRE
        /// </summary>
        public Visu(Cargo cargoReferencia, string ipp1, string ipp2, string numeroIpp, string ipp4, string caratula,
                    string victima, string imputado, string fiscalia, string agenteFiscal, string localidad,
                    string instructor, string secretario, string dependencia)
        {
            InitializeComponent();

            // Guardar la referencia al formulario Cargo
            formularioCargo = cargoReferencia;

            // Asignar los valores a los controles específicos del formulario
            comboBox_Ipp1.TextValue = ipp1;
            comboBox_Ipp2.TextValue = ipp2;
            textBox_NumeroIpp.TextValue = numeroIpp;
            comboBox_Ipp4.TextValue = ipp4;
            textBox_Caratula.TextValue = caratula;
            textBox_Victima.TextValue = victima;
            textBox_Imputado.TextValue = imputado;
            comboBox_Fiscalia.TextValue = fiscalia;
            comboBox_AgenteFiscal.TextValue = agenteFiscal;
            comboBox_Localidad.TextValue = localidad;
            comboBox_Instructor.TextValue = instructor;
            comboBox_Secretario.TextValue = secretario;
            comboBox_Dependencia.TextValue = dependencia;
        }

        #region LOAD
        private void Visu_Load(object sender, EventArgs e)
        {
            pictureBox_PanelImagenes.Visible = true;
        
            // llevar al frente label y picture
            pictureBox_AgregarImagen.BringToFront();
            pictureBox_QuitarImagen.BringToFront();
            pictureBox_DatosVehiculo.BringToFront();
            label_DatosInstruccion.BringToFront();
            pictureBox_PanelInstruccion.BringToFront();
            btn_AmpliarReducir_INSTRUCCION.BringToFront();
            label_DatosVehiculo.BringToFront();
            label_SeleccionVisu.BringToFront();

            Fecha_Instruccion.SelectedDate = DateTime.Now; //para que actualice automaticamente la fecha


            //// Guardar la altura original del panel
            alturaOriginalPanel_Instruccion = panel_Instruccion.Height;
            alturaOriginalPanel_Imagenes = panel_Imagenes.Height;
            alturaOriginalPanel_Vehiculo = panel_DatosVehiculo.Height;
            alturaOriginalPanel_Descripcion = panel_Descripcion.Height;


            //validar datos de los paneles y mostras picture de completo-impleto y error
            ValidarPanelDatosInstruccion();
            ValidarPanelDescripcion();
            ValidarPanelVehiculo();
            // Validar panel solo si está contraído
            if (!panelExpandido_Imagenes && labelImagenes != null)
            {
                ValidarPanelImagenes();
            }

            //para que se carge el panel INSTRUCION contraido
            if (panelExpandido_Instruccion)
            {
                // Contraer el panel
                panel_Instruccion.Height = alturaContraidaPanel;
                btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                panelExpandido_Instruccion = false; //PANEL CONTRAIDO
                panel_Instruccion.BorderStyle = BorderStyle.FixedSingle;

                // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                btn_AmpliarReducir_INSTRUCCION.Parent = panel_Instruccion;
                btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(561, 1);
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
                        panel_DatosInstruccion.Visible = false;
                    }
                }
                //para que carge no visible
                panel_Imagenes.Visible = false;
                panel_DatosVehiculo.Visible = false;
                panel_DatosEspecificos.Visible = false;
                panel_Descripcion.Visible = false;
                panel_ControlesInferiores.Visible = false;
            }

            //Para cambiar el borde del PANEL SELECCIONAR TIPO VISU segun este seleccionado o no un radiobutom
            foreach (Control ctrl in panel_TipoExamenVisu.Controls)
            {
                if (ctrl is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += RadioButton_CheckedChanged;
                }
            }
            AjustarTamanoFormulario();// para que carge con altura de formulario ajustada
        }
        #endregion

        #region METODOS GENERALES


        /// <summary>
        /// OBTENER DATOS DEL FORMULARIO
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>();

            // Verificar si los datos del formulario son válidos
            if (datosFormulario == null)
            {
                // Detener la generación de documentos si hay algún error
                return null;
            }

            // Añadimos los valores de los controles al diccionario

            datosFormulario.Add("NumeroIpp", textBox_NumeroIpp.TextValue);
            datosFormulario.Add("Caratula", textBox_Caratula.TextValue);
            datosFormulario.Add("Victima", textBox_Victima.TextValue);
            datosFormulario.Add("Imputado", textBox_Imputado.TextValue);

            datosFormulario.Add("Instructor", comboBox_Instructor.SelectedItem.ToString());
            datosFormulario.Add("Secretario", comboBox_Secretario.SelectedItem.ToString());
            datosFormulario.Add("Dependencia", comboBox_Dependencia.SelectedItem.ToString());


            return datosFormulario;
        }


  



      

        #endregion

        #region BOTONES
    
        private void Btn_Guardar_Click(object sender, EventArgs e)
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
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario


        }

        /// <summary>
        /// METODOS PARA LOS BOTONES AMPLIAR Y REDUCIR PANELES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AmpliarReducir_INSTRUCCION_Click(object sender, EventArgs e)
        {
            //if (panel_Instruccion is PanelConBordeNeon panelConNeon)
            //{
            //    if (panelExpandido_Instruccion)
            //    {
            //        // Contraer el panel
            //        panel_Instruccion.Height = alturaContraidaPanel;
            //        btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
            //        panelExpandido_Instruccion = false; //PANEL CONTRAIDO

            //        // Cambiar el estilo del borde
            //        panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

            //        // Cambiar la posición y el padre del botón al panel_DatosVehiculo
            //        btn_AmpliarReducir_INSTRUCCION.Parent = panel_Instruccion;
            //        btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(561, 1);


            //        // Ocultar todos los controles excepto el botón de ampliación/reducción
            //        foreach (Control control in panel_DatosInstruccion.Controls)
            //        {
            //            if (control == btn_AmpliarReducir_INSTRUCCION)
            //            {
            //                control.Visible = true; // Mantén visible el botón btn_AmpliarReducir
            //            }
            //            else
            //            {
            //                control.Visible = false; // Oculta los demás controles
            //                panel_DatosInstruccion.Visible = false;
            //            }
            //        }

            //        // Ocultar controles de error personalizados
            //        foreach (Control control in panel_DatosInstruccion.Controls)
            //        {
            //            if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
            //            {
            //                control.Visible = false; // Ocultar imágenes de error
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // Expandir el panel
            //        panel_Instruccion.Height = alturaOriginalPanel_Instruccion;
            //        panel_Instruccion.BorderStyle = BorderStyle.None;
            //        btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
            //        panelExpandido_Instruccion = true;
            //        panel_DatosInstruccion.Visible = true;

            //        // Cambiar el estilo del borde
            //        panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

            //        // Mover el botón al panel_DatosEspecificos
            //        btn_AmpliarReducir_INSTRUCCION.Parent = panel_DatosInstruccion;
            //        btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(558, 1);

            //        // Mostrar todos los controles
            //        foreach (Control control in panel_DatosInstruccion.Controls)
            //        {
            //            control.Visible = true;
            //        }

            //        // Asegurarte de que las imágenes de error se muestren si es necesario
            //        foreach (Control control in panel_DatosInstruccion.Controls)
            //        {
            //            if (control is PictureBox pictureBox && pictureBox.Name.Contains("Error"))
            //            {
            //                control.Visible = true; // Mostrar imágenes de error
            //            }
            //        }
            //    }
            //    AjustarTamanoFormulario();
            //}
                        AmpliarReducirPanel.AlternarPanel(
             panelConNeon: panel_Instruccion,
             panelDetalle: panel_DatosInstruccion,
             panelExpandido: ref panelExpandido_Instruccion,
             btnAmpliarReducir: btn_AmpliarReducir_INSTRUCCION,
             imgExpandir: Properties.Resources.dobleFlechaABAJO,
             imgContraer: Properties.Resources.dobleFlechaARRIBA,
             alturaOriginal: alturaOriginalPanel_Instruccion,
             alturaContraida: alturaContraidaPanel,
               borderStyleAlExpandir: BorderStyle.None,
             ajustarFormulario: AjustarTamanoFormulario,
              usarAnimacion: true
            );
        }
        private void Btn_AmpliarReducir_IMAGENES_Click(object sender, EventArgs e)
        {
            //if (panel_Imagenes is PanelConBordeNeon panelConNeon)
            //{
            //    if (panelExpandido_Imagenes)
            //    {
            //        // Contraer el panel
            //        panel_Imagenes.Height = alturaContraidaPanel;
            //        btn_AmpliarReducir_IMAGENES.Image = Properties.Resources.dobleFlechaABAJO;
            //        panel_Imagenes.BorderStyle = BorderStyle.None;
            //        panelExpandido_Imagenes = false;
            //        panelConNeon.CambiarEstado(true, false);

            //        // Crear Label si no existe
            //        if (labelImagenes == null)
            //        {
            //            labelImagenes = new Label
            //            {
            //                BackColor = Color.FromArgb(0, 192, 192),
            //                Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold | FontStyle.Underline),
            //                ForeColor = SystemColors.ControlText,
            //                Padding = new Padding(20, 3, 20, 5),
            //                Text = "IMAGENES",
            //                AutoSize = true,
            //                Location = new System.Drawing.Point(23, 1)
            //            };

            //            panel_Imagenes.Controls.Add(labelImagenes);
            //            labelImagenes.BringToFront();
            //        }

            //        foreach (Control control in panel_Imagenes.Controls)
            //        {
            //            control.Visible = control == btn_AmpliarReducir_IMAGENES || control == labelImagenes || control == pictureBox_PanelImagenes;
            //        }
            //        pictureBox_PanelImagenes.Visible = true;
            //    }
            //    else
            //    {
            //        // Expandir el panel
            //        panel_Imagenes.Height = alturaOriginalPanel_Imagenes;
            //        btn_AmpliarReducir_IMAGENES.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
            //        panelExpandido_Imagenes = true;
            //        panel_Imagenes.BorderStyle = BorderStyle.FixedSingle;

            //        // Cambiar el estilo del borde
            //        panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

            //        // Ocultar o quitar el Label cuando el panel se expande
            //        foreach (Control control in panel_Imagenes.Controls)
            //        {
            //            if (control is Label && control.Text == "IMAGENES")
            //            {
            //                control.Visible = false; //OCULTAR ESTE CONTROL

            //            }
            //            else
            //            {
            //                control.Visible = true; // Mostrar los demás controles
            //            }
            //        }
            //    }
            //    AjustarTamanoFormulario();
            //}
            AmpliarReducirPanel.AlternarPanel(
       panelConNeon: panel_Imagenes,
       panelDetalle: panel_AgregarImagenes,
       panelExpandido: ref panelExpandido_Imagenes,
       btnAmpliarReducir: btn_AmpliarReducir_IMAGENES,
       imgExpandir: Properties.Resources.dobleFlechaABAJO,
       imgContraer: Properties.Resources.dobleFlechaARRIBA,
       alturaOriginal: alturaOriginalPanel_Imagenes,
       alturaContraida: alturaContraidaPanel,
         borderStyleAlExpandir: BorderStyle.None,
       ajustarFormulario: AjustarTamanoFormulario,
        usarAnimacion: true
   );
        }
        private void Btn_AmpliarReducir_VEHICULO_Click(object sender, EventArgs e)
        {
            //if (panel_DatosVehiculo is PanelConBordeNeon panelConNeon)
            //{
            //    if (panelExpandido_Vehiculo)
            //    {
            //        // Contraer el panel
            //        panel_DatosVehiculo.Height = alturaContraidaPanel;
            //        panel_DatosVehiculo.BorderStyle = BorderStyle.None;

            //        btn_AmpliarReducir_VEHICULO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
            //        panelExpandido_Vehiculo = false;

            //        // Aplicar borde neón para el estado contraído
            //        bool camposCompletos = VerificarCamposEnPanel(panel_DatosEspecificos); // Método personalizado para verificar campos
            //        panelConNeon.CambiarEstado(true, camposCompletos);

            //        // Cambiar la posición y el padre del botón al panel_DatosVehiculo
            //        btn_AmpliarReducir_VEHICULO.Parent = panel_DatosVehiculo;
            //        btn_AmpliarReducir_VEHICULO.Location = new System.Drawing.Point(561, 1);


            //        panel_DatosEspecificos.Visible = false;
            //    }
            //    else
            //    {
            //        // Expandir el panel
            //        panel_DatosVehiculo.Height = alturaOriginalPanel_Vehiculo;
            //        btn_AmpliarReducir_VEHICULO.Image = Properties.Resources.dobleFlechaARRIBA;
            //        panelExpandido_Vehiculo = true;
            //        panel_DatosVehiculo.BorderStyle = BorderStyle.None;

            //        // Cambiar el estilo del borde
            //        panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

            //        // Mover el botón al panel_DatosEspecificos
            //        btn_AmpliarReducir_VEHICULO.Parent = panel_DatosEspecificos;
            //        btn_AmpliarReducir_VEHICULO.Location = new System.Drawing.Point(558, 1);

            //        // Buscar y ocultar o eliminar el Label dinámico
            //        Control labelVehiculo = panel_DatosVehiculo.Controls["labelVehiculo"];
            //        if (labelVehiculo != null)
            //        {
            //            panel_DatosVehiculo.Controls.Remove(labelVehiculo);
            //            labelVehiculo.Dispose(); // Liberar recursos del Label
            //        }

            //        // Mostrar los demás controles del panel
            //        foreach (Control control in panel_DatosVehiculo.Controls)
            //        {
            //            control.Visible = true;
            //        }
            //    }

            //    // Ajustar el tamaño del formulario si es necesario
            //    AjustarTamanoFormulario();
            //}
            AmpliarReducirPanel.AlternarPanel(
              panelConNeon: panel_DatosVehiculo,
              panelDetalle: panel_DatosEspecificos,
              panelExpandido: ref panelExpandido_Vehiculo,
              btnAmpliarReducir: btn_AmpliarReducir_VEHICULO,
              imgExpandir: Properties.Resources.dobleFlechaABAJO,
              imgContraer: Properties.Resources.dobleFlechaARRIBA,
              alturaOriginal: alturaOriginalPanel_Vehiculo,
              alturaContraida: alturaContraidaPanel,
               borderStyleAlExpandir: BorderStyle.None,
              ajustarFormulario: AjustarTamanoFormulario,
               usarAnimacion: true
               );
       
        }
        private void Btn_AmpliarReducir_DESCRIPCION_Click(object sender, EventArgs e)
        {
           // Verificar si el panel es de tipo PanelConBordeNeon
            if (panel_Descripcion is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Descripcion)
                {
                    // Contraer el panel
                    panelConNeon.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_DESCRIPCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Descripcion = false;

                    // Aplicar borde neón para el estado contraído
                    bool camposCompletos = VerificarCamposEnPanel(panelConNeon); // Método personalizado para verificar campos
                    panelConNeon.CambiarEstado(true, camposCompletos);

                    foreach (Control control in panelConNeon.Controls)
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
                    panelConNeon.Height = alturaOriginalPanel_Descripcion;
                    btn_AmpliarReducir_DESCRIPCION.Image = Properties.Resources.dobleFlechaARRIBA;
                    panelExpandido_Descripcion = true;

                    // Eliminar el efecto neón para el estado expandido
                    panelConNeon.CambiarEstado(false, false);

                    // Mostrar los demás controles del panel
                    foreach (Control control in panelConNeon.Controls)
                    {
                        control.Visible = true;
                    }
                }
                AjustarTamanoFormulario();
            }
            //            AmpliarReducirPanel.AlternarPanel(
            //panelConNeon: panel_Descripcion,
            //panelDetalle: panelDetalle,
            //panelExpandido: ref panelExpandido_Descripcion,
            //btnAmpliarReducir: btn_AmpliarReducir_DESCRIPCION,
            //imgExpandir: Properties.Resources.dobleFlechaABAJO,
            //imgContraer: Properties.Resources.dobleFlechaARRIBA,
            //alturaOriginal: alturaOriginalPanel_Descripcion,
            //alturaContraida: alturaContraidaPanel,
            //ajustarFormulario: AjustarTamanoFormulario,
            // usarAnimacion: true
            // );
        }

        #endregion

        #region PANEL IMAGENES

        /// <summary>
        /// SELECCION DE RADIOBUTON Y VISUALIZACION DE PANELES
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {

            // Verificar si algún RadioButton en el grupo está seleccionado
            bool isChecked = panel_TipoExamenVisu.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Cambiar el color del borde del GroupBox según el estado de los RadioButton
            if (isChecked)
            {
                panel_TipoExamenVisu.Paint += Panel_TipoExamenVisu_Paint_Activated;
            }
            else
            {
                panel_TipoExamenVisu.Paint += Panel_TipoExamenVisu_Paint_Default;
            }

            // Forzar el repintado del GroupBox
            panel_TipoExamenVisu.Invalidate();

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

                    LimpiarFormulario.Limpiar(panel_Descripcion); //limpia la descripcion de la imagen
                    LimpiarFormulario.Limpiar(panel_DatosEspecificos); //limpias los conrtoles de datos de vehiculo



                    // Cambia la imagen y el color de fondo del PictureBox correspondiente
                    if (radioButton == radioButton_Automovil)
                    {

                        RedondearBordes.Aplicar(pictureBox_Automovil, 6, true, false, false, true); // Solo esquinas izquierdas
                        ResetPictureBoxStyles(); // Restaura los estilos por defecto de los PictureBox
                        pictureBox_Automovil.BackColor = Color.FromArgb(4, 234, 0);
                        RedondearBordes.Aplicar(radioButton, 6, false, true, true, false); // Solo esquinas derechas
                    }
                    else if (radioButton == radioButton_Motovehiculo)
                    {

                        RedondearBordes.Aplicar(pictureBox_Motovehiculo, 6, true, false, false, true);
                        ResetPictureBoxStyles();
                        pictureBox_Motovehiculo.BackColor = Color.FromArgb(4, 234, 0);
                        RedondearBordes.Aplicar(radioButton, 6, false, true, true, false);
                    }
                    else if (radioButton == radioButton_Objeto)
                    {

                        RedondearBordes.Aplicar(pictureBox_Objeto, 6, true, false, false, true);
                        ResetPictureBoxStyles();
                        pictureBox_Objeto.BackColor = Color.FromArgb(4, 234, 0);
                        RedondearBordes.Aplicar(radioButton, 6, false, true, true, false);
                    }

                }
                else
                {
                    // Restaura el estilo normal si el RadioButton se desmarca
                    radioButton.Font = new System.Drawing.Font(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Regular);
                    radioButton.ForeColor = SystemColors.ControlText;
                    radioButton.BackColor = Color.FromArgb(178, 213, 230);
                }
                AjustarTamanoFormulario();
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

        /// <summary>
        /// Método para aplicar el estilo personalizado (negrita y subrayado)
        /// </summary>
        /// <param name="radioButton"></param>
        private static void ApplyCustomFontStyle(RadioButton radioButton)
        {
            // Crea una fuente con negrita y subrayado
            System.Drawing.Font customFont = new(radioButton.Font.FontFamily, radioButton.Font.Size, FontStyle.Bold);

            // Cambia la fuente del RadioButton
            radioButton.Font = customFont;
            radioButton.ForeColor = SystemColors.HotTrack;
            radioButton.BackColor = Color.FromArgb(228, 247, 222);

            // Redibuja el RadioButton para reflejar el cambio
            radioButton.Invalidate();
        }

        /// <summary>
        /// METODOS PARA CAMBIAR EL COLOR DE BORDE DEL GROUP SEGUN ESTE SELECCIONADO O NO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_TipoExamenVisu_Paint_Activated(object sender, PaintEventArgs e)
        {
            using Pen pen = new(Color.Green, 2); // Borde verde cuando algún CheckBox está seleccionado
            e.Graphics.DrawRectangle(pen, panel_TipoExamenVisu.ClientRectangle);
        }

        private void Panel_TipoExamenVisu_Paint_Default(object sender, PaintEventArgs e)
        {
            using Pen pen = new(Color.Black, 1); // Borde negro por defecto
            e.Graphics.DrawRectangle(pen, panel_TipoExamenVisu.ClientRectangle);
        }


        /// <summary>
        /// METODO PARA AGREGAR IMAGENES
        /// </summary>
        private void PictureBox_AgregarImagen_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel_AgregarImagenes.Controls)
            {
                if (ctrl is NuevaImagen imagenControl) // Si es de tipo NuevaImagen
                {
                    if (imagenControl.Image == null || imagenControl.Image == Properties.Resources.agregar_imagen)
                    {
                        MensajeGeneral.Mostrar("No ha asignado una imagen.", MensajeGeneral.TipoMensaje.Error);
                        MensajeGeneral.Mostrar("Todos los controles deben contener una imagen antes de agregar una nueva.", MensajeGeneral.TipoMensaje.Advertencia);
                        return; // No agregar una nueva imagen si alguna no tiene una imagen cargada o tiene la imagen predeterminada
                    }
                }
                else
                {
                    MensajeGeneral.Mostrar($"El control {ctrl.Name} no es de tipo NuevaImagen.", MensajeGeneral.TipoMensaje.Advertencia);
                }
            }
            // Verificar el límite de 5 controles
            if (panel_AgregarImagenes.Controls.Count >= 5)
            {
                MensajeGeneral.Mostrar("Límite máximo de 5 imágenes alcanzado.", MensajeGeneral.TipoMensaje.Error);
                return;
            }

            // Crear una instancia del control NuevaImagen
            NuevaImagen nuevoControlImagen = new();

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
        private void PictureBox_QuitarImagen_Click(object sender, EventArgs e)
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


        #endregion

        #region VALIDAR PANELES Y CONTROLES
        //private static void ValidarPanel(Control panel, PictureBox pictureBox, Label label, Func<bool> validarCampos)
        //{
        //    bool camposValidos = validarCampos();

        //    if (camposValidos)
        //    {
        //        pictureBox.Image = Properties.Resources.verificacion_exitosa;
        //        label.BackColor = Color.FromArgb(4, 200, 0);
        //    }
        //    else|
        //    {
        //        pictureBox.Image = Properties.Resources.Advertencia_Faltante;
        //        label.BackColor = Color.FromArgb(0, 192, 192);
        //    }

        //    pictureBox.Location = new System.Drawing.Point(
        //        label.Right + 5,
        //        label.Top + (label.Height - pictureBox.Height) / 2
        //    );

        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        //    pictureBox.Visible = true;
        //}

        /// <summary>
        /// METODO PARA VALIDAR DATOS DE LOS PANELES
        /// </summary>
        private void ValidarPanelDatosInstruccion()
        {
            ValidarPanel(panel_DatosInstruccion, pictureBox_PanelInstruccion, label_DatosInstruccion, () =>
            {
                foreach (Control control in panel_DatosInstruccion.Controls)
                {
                    if (control is CustomTextBox customTextBox && string.IsNullOrWhiteSpace(customTextBox.TextValue))
                        return false;

                    if (control is CustomComboBox customComboBox && (customComboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(customComboBox.TextValue)))
                        return false;
                }
                return true;
            });

            AjustarTamanoFormulario();
        }

        /// <summary>
        /// METODO PARA VALIDAR DATOS EN PANEL DATOS VEHICULO
        /// </summary>
        private void ValidarPanelVehiculo()
        {
            ValidarPanel(panel_DatosEspecificos, pictureBox_DatosVehiculo, label_DatosVehiculo, () => VerificarCamposEnPanel(panel_DatosEspecificos));
        }

        /// <summary>
        /// VERIFICA MINIMO DE TEXTO EN DESCRIPCION
        /// </summary>
        private void ValidarPanelDescripcion()
        {
            int minimoCaracteres = 20; // Define el mínimo de caracteres requeridos
            bool descripcionValida = !string.IsNullOrWhiteSpace(richTextBox_Descripcion.Text)
                                     && richTextBox_Descripcion.Text.Trim().Length >= minimoCaracteres;

            // Aplicar validación con la nueva condición
            ValidarPanel(richTextBox_Descripcion, pictureBox_Descripcion, label_Descripcion, () => descripcionValida);

            // Ocultar controles inferiores si la descripción es insuficiente
            panel_ControlesInferiores.Visible = descripcionValida;

            // Ajustar el tamaño del formulario solo si es necesario
            AjustarTamanoFormulario();
        }


        /// <summary>
        /// METODO PARA VALIDAR DATOS EN PANEL IMAGEES
        /// </summary>
        private void ValidarPanelImagenes()
        {
            ValidarPanel(richTextBox_Descripcion, pictureBox_PanelImagenes, labelImagenes, () =>
                !string.IsNullOrWhiteSpace(richTextBox_Descripcion.Text));
        }

        private static bool ValidarCampo(Control control, string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                // Si el campo está vacío, se establece un error en el control y se muestra el PictureBoxError
                //SetError(control, mensajeError);
                return false;
            }

            // Si el campo está completo, se limpia el error
            //ClearError(control);
            return true;
        }



        /// <summary>
        /// METODO PARA VALIDAR LOS CONTROLES DENTRO DE UN PANEL
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        private static bool ValidarControlesExistentes(Panel panel)
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

        #endregion

        /// <summary>
        /// MENSAJE AYUDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visu_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Completando los datos requeridos se creara documento de examen de VISU y se agregarán las imagenes.");

        }

        /// <summary>
        /// MENSAJE CONFIRMACION AL CERRAR FORMULARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visu_FormClosing(object sender, FormClosingEventArgs e)
        {
                MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
                    // Cambiar el estado del botón
                    formularioCargo?.CambiarEstadoBotonDeslizable(false); // O true, según sea necesario
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

        /// <summary>
        /// METODO PARA AJUSTAR TAMAÑO DE FORMULARIO Y REPOSICIONAR PANELES
        /// </summary>
        private void AjustarTamanoFormulario()
        {
            int posicionVertical = 35; // Comienza desde la parte superior de panel1

            // Ajustar posición de panel_Instruccion (se contrae y expande)
            if (panel_Instruccion.Visible)
            {
                panel_Instruccion.Location = new System.Drawing.Point(panel_Instruccion.Location.X, posicionVertical);
                posicionVertical += panel_Instruccion.Height;
                // Agregar separación de 10 píxeles entre panel_Instruccion y panel_SeleccionVisu
                posicionVertical += 10;
            }

            // Ajustar posición de panel_SeleccionVisu (tamaño fijo)
            panel_SeleccionVisu.Location = new System.Drawing.Point(panel_SeleccionVisu.Location.X, posicionVertical);
            posicionVertical += panel_SeleccionVisu.Height;
            // Agregar separación de 10 píxeles entre panel_SeleccionVisu y panel_Imagenes
            posicionVertical += 10;

            // Ajustar posición de panel_Imagenes (se contrae y expande)
            if (panel_Imagenes.Visible)
            {
                panel_Imagenes.Location = new System.Drawing.Point(panel_Imagenes.Location.X, posicionVertical);
                posicionVertical += panel_Imagenes.Height;
                posicionVertical += 10;
            }

            // Ajustar posición de panel_DatosVehiculo(se contrae y expande)
            if (panel_DatosVehiculo.Visible)
            {
                panel_DatosVehiculo.Location = new System.Drawing.Point(panel_DatosVehiculo.Location.X, posicionVertical);
                posicionVertical += panel_DatosVehiculo.Height;
                posicionVertical += 10;
            }

            // Ajustar posición de panel_DatosVehiculo(se contrae y expande)
            if (panel_Descripcion.Visible)
            {
                panel_Descripcion.Location = new System.Drawing.Point(panel_Descripcion.Location.X, posicionVertical);
                posicionVertical += panel_Descripcion.Height;
                posicionVertical += 10; // Agregar separación después de panel_Descripción
            }

            // Ajustar posición de panel_ControlesInferiores
            if (panel_ControlesInferiores.Visible)
            {
                panel_ControlesInferiores.Location = new System.Drawing.Point(panel_ControlesInferiores.Location.X, posicionVertical);
                posicionVertical += panel_ControlesInferiores.Height;
                posicionVertical += 10;
            }
            // Ajustar la altura de panel1 para que se ajuste al contenido visible
            panel1.Height = posicionVertical;

            // Ajustar la altura del formulario sumando un margen adicional de 20 px
            this.Height = panel1.Location.Y + panel1.Height + 75;

            // Activar scroll si la altura del formulario supera los 800 píxeles
            if (this.Height > 800)
            {
                this.AutoScroll = true;
            }
            else
            {
                this.AutoScroll = false;
            }
        }

        /// <summary>
        /// valida para que no se ingrease un año de vehiculo posterior al año en  curso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ComboBox_AñoVehiculo_Validated(object sender, EventArgs e)
        {
            if (sender is CustomComboBox comboBox)
            {
                // Obtener el texto ingresado
                string input = comboBox.TextValue.Trim();

                // Obtener el año actual
                int añoActual = DateTime.Now.Year;

                // Validar si es un número de 4 dígitos y menor o igual al año actual
                if (!int.TryParse(input, out int año) || año < 1900 || año > añoActual)
                {
                    // Obtener la posición del control para centrar el mensaje debajo
                    Point posicionComboBox = comboBox.Parent.PointToScreen(comboBox.Location);
                    int x = posicionComboBox.X + (comboBox.Width / 2);
                    int y = posicionComboBox.Y + comboBox.Height + 5; // Posicionar justo debajo con un margen de 5px

                    // Crear y mostrar el mensaje como ventana modal (ShowDialog)
                    using (MensajeGeneral mensajeForm = new("El año del vehículo no puede ser posterior al año en curso.",
                                                                            MensajeGeneral.TipoMensaje.Advertencia))
                    {
                        mensajeForm.StartPosition = FormStartPosition.Manual;
                        mensajeForm.Location = new Point(x - (mensajeForm.Width / 2), y);
                        mensajeForm.ShowDialog(); // Mostrar como modal
                    }

                    // Limpiar el contenido del ComboBox
                    comboBox.Text = string.Empty;
                    comboBox.SelectedIndex = -1;
                }
            }
        }

      
       
    }

}




