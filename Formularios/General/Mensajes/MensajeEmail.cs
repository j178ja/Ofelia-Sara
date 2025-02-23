using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
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

namespace Ofelia_Sara.Formularios.General.Mensajes
{

    public partial class MensajeEmail : BaseForm
    {
        #region VARIABLES


        private int alturaOriginalPanel_Vehiculo;
        private int alturaOriginalPanel_DatosVictima;
        private int alturaOriginalPanel_DatosHecho;
        private int alturaOriginalPanel_Instruccion;

        private bool panelExpandido_Vehiculo = true;
        private bool panelExpandido_DatosVictima = true;
        private bool panelExpandido_DatosHecho = true;
        private bool panelExpandido_Instruccion = true;

        private int alturaContraidaPanel = 30;

        private object mensajeEmail;
        #endregion

        #region CONSTRUCTOR
        public MensajeEmail()
        {
            InitializeComponent();

            pictureBox_Icono.BringToFront();
            boton_Contador_Personas.Visible = false;
            boton_Contador_Vehiculos.Visible = false;

            // llevar al frente label y picture

            pictureBox_DatosVehiculo.BringToFront();
            label_DatosInstruccion.BringToFront();
            pictureBox_PanelInstruccion.BringToFront();
            btn_AmpliarReducir_INSTRUCCION.BringToFront();
            label_DatosVehiculo.BringToFront();
            label_Hecho.BringToFront();

            Fecha_Instruccion.SelectedDate = DateTime.Now; //para que actualice automaticamente la fecha


            //// Guardar la altura original del panel
            alturaOriginalPanel_Vehiculo = panel_DatosVehiculo.Height;
            alturaOriginalPanel_DatosVictima = panel_DatosVictima.Height;
            alturaOriginalPanel_DatosHecho = panel_DatosHecho.Height;
            alturaOriginalPanel_Instruccion = panel_Instruccion.Height;



            //si es cargado para insertar secuestro
            panel_DatosVehiculo.Visible = true;
            panel_DatosInstruccion.Visible = true;
            panel_DatosHecho.Visible = true;
            panel_Instruccion.Visible = true;
            panel_DatosVictima.Visible = true;
            panel_PlanaPersona.Visible = false;

            label_Texto.Text = "Solicitar INSERCTE SECUESTRO de vehiculo.";
        }
        #endregion


        /// <summary>
        /// SELECCION DE RADIOBUTON Y VISUALIZACION DE PANELES
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {

            // Verificar si algún RadioButton en el grupo está seleccionado
            bool isChecked = panel_TipoSolicitud.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Cambiar el color del borde del GroupBox según el estado de los RadioButton
            if (isChecked)
            {
                panel_TipoSolicitud.Paint += panel_TipoSolicitud_Paint_Activated;
            }
            else
            {
                panel_TipoSolicitud.Paint += panel_TipoSolicitud_Paint_Default;
            }

            // Forzar el repintado del GroupBox
            panel_TipoSolicitud.Invalidate();

            if (sender is RadioButton radioButton)
            {
                // Verifica qué RadioButton fue marcado y aplica el estilo correspondiente
                if (radioButton.Checked)
                {
                    // Aplica el estilo personalizado (negrita y subrayado)
                    ApplyCustomFontStyle(radioButton);


                    ////         AjustarTamanoFormulario();
                    //// Controla la visibilidad del panel de datos del vehículo
                    //panel_DatosVehiculo.Visible = radioButton_Vehiculo.Checked || radioButton_Persona.Checked;
                    //panel_DatosEspecificos.Visible = radioButton_Vehiculo.Checked || radioButton_Persona.Checked;
                    ////        AjustarTamanoFormulario();

                    //LimpiarFormulario.Limpiar(panel_DatosEspecificos); //limpias los conrtoles de datos de vehiculo



                    // Cambia la imagen y el color de fondo del PictureBox correspondiente
                    if (radioButton == radioButton_Vehiculo)
                    {

                        ApplyRoundedCorners(pictureBox_Vehiculo, 6, true, false, false, true); // Solo esquinas izquierdas
                        ResetPictureBoxStyles(); // Restaura los estilos por defecto de los PictureBox
                        pictureBox_Vehiculo.BackColor = Color.FromArgb(4, 234, 0);
                        ApplyRoundedCorners(radioButton, 6, false, true, true, false); // Solo esquinas derechas
                    }
                    else if (radioButton == radioButton_Persona)
                    {

                        ApplyRoundedCorners(pictureBox_Persona, 6, true, false, false, true);
                        ResetPictureBoxStyles();
                        pictureBox_Persona.BackColor = Color.FromArgb(4, 234, 0);
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
                //  AjustarTamanoFormulario();
            }
        }

        /// <summary>
        /// Restaura los estilos por defecto de todos los PictureBox.
        /// </summary>
        private void ResetPictureBoxStyles()
        {
            pictureBox_Vehiculo.BackColor = Color.FromArgb(178, 213, 230);
            pictureBox_Persona.BackColor = Color.FromArgb(178, 213, 230);


        }

        /// <summary>
        /// Método para aplicar el estilo personalizado (negrita y subrayado)
        /// </summary>
        /// <param name="radioButton"></param>
        private static void ApplyCustomFontStyle(RadioButton radioButton)
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
            panel_TipoSolicitud.Location = new System.Drawing.Point(panel_TipoSolicitud.Location.X, posicionVertical);
            posicionVertical += panel_TipoSolicitud.Height;
            // Agregar separación de 10 píxeles entre panel_SeleccionVisu y panel_Imagenes
            posicionVertical += 10;



            // Ajustar posición de panel_DatosVehiculo(se contrae y expande)
            if (panel_DatosVehiculo.Visible)
            {
                panel_DatosVehiculo.Location = new System.Drawing.Point(panel_DatosVehiculo.Location.X, posicionVertical);
                posicionVertical += panel_DatosVehiculo.Height;
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
        /// METODOS PARA CAMBIAR EL COLOR DE BORDE DEL GROUP SEGUN ESTE SELECCIONADO O NO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_TipoSolicitud_Paint_Activated(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Green, 2)) // Borde verde cuando algún CheckBox está seleccionado
            {
                e.Graphics.DrawRectangle(pen, panel_TipoSolicitud.ClientRectangle);
            }
        }

        private void panel_TipoSolicitud_Paint_Default(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 1)) // Borde negro por defecto
            {
                e.Graphics.DrawRectangle(pen, panel_TipoSolicitud.ClientRectangle);
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            MensajeGeneral.Mostrar("Si cancela se eliminaran los datos ingresados");
            DialogResult = DialogResult.Cancel;
        }



        /// <summary>
        /// Mostrar mensaje de ayuda segun elementos seleccionado en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MensajeEmail_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if (radioButton_Persona.Checked)
            {

                MostrarMensajeAyuda("Se solitará PLANA INFORMATICA con los datos de la persona ingresados.");
                return;
            }
            if (radioButton_Vehiculo.Checked)
            {
                MostrarMensajeAyuda("Se solicitará PLANA Y PERTENENCIA de vehiculo.");
                return;
            }
            else
            {
                MostrarMensajeAyuda("Se solicitará INSERTE SECUESTRO con los datos de vehiculo aportados.");
            }

        }

        private void RadioButton_Vehiculo_CheckedChanged(object sender, EventArgs e)
        {
            label_Texto.Text = "Solicitar PLANA Y PERTENENCIA de vehiculo.";
            panel_DatosVehiculo.Visible = true;
            panel_DatosVictima.Visible = false;
            panel_DatosHecho.Visible = false;
            panel_Instruccion.Visible = false;
            panel_PlanaPersona.Visible = false;

        }

        private void RadioButton_Persona_CheckedChanged(object sender, EventArgs e)
        {
            label_Texto.Text = "Solicitar PLANA INFORMATICA de persona.";
            panel_DatosVehiculo.Visible = false;
            panel_DatosVictima.Visible = false;
            panel_DatosHecho.Visible = false;
            panel_Instruccion.Visible = false;
            panel_PlanaPersona.Visible = true;

        }

        private void MensajeEmail_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel_TipoSolicitud.Controls)
            {
                if (ctrl is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += RadioButton_CheckedChanged;
                }
            }


        }

        private void btn_AgregarSolicitud_Click(object sender, EventArgs e)
        {
            radioButton_Persona.Checked = false;
            radioButton_Vehiculo.Checked = false;
            ResetPictureBoxStyles();
            label_Texto.Text = "Seleccione que tipo de solicitud desea realizar.";
        }

        /// <summary>
        /// METODOS PARA LOS BOTONES AMPLIAR Y REDUCIR PANELES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_AmpliarReducir_INSTRUCCION_Click(object sender, EventArgs e)
        {
            if (panel_Instruccion is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Instruccion)
                {
                    // Contraer el panel
                    panel_Instruccion.Height = alturaContraidaPanel;
                    btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Instruccion = false; //PANEL CONTRAIDO

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(true, false); // Panel contraído, campos no completos

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
                    panel_Instruccion.Height = alturaOriginalPanel_Instruccion;
                    panel_Instruccion.BorderStyle = BorderStyle.None;
                    btn_AmpliarReducir_INSTRUCCION.Image = Properties.Resources.dobleFlechaARRIBA; // Cambiar la imagen a "Flecha hacia arriba"
                    panelExpandido_Instruccion = true;
                    panel_DatosInstruccion.Visible = true;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_INSTRUCCION.Parent = panel_DatosInstruccion;
                    btn_AmpliarReducir_INSTRUCCION.Location = new System.Drawing.Point(558, 1);

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
                //  AjustarTamanoFormulario();
            }

        }

        private void Btn_AmpliarReducir_VEHICULO_Click(object sender, EventArgs e)
        {
            if (panel_DatosVehiculo is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_Vehiculo)
                {
                    // Contraer el panel
                    panel_DatosVehiculo.Height = alturaContraidaPanel;
                    panel_DatosVehiculo.BorderStyle = BorderStyle.None;

                    btn_AmpliarReducir_VEHICULO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_Vehiculo = false;

                    // Aplicar borde neón para el estado contraído
                    bool camposCompletos = VerificarCamposEnPanel(panel_DatosEspecificos); // Método personalizado para verificar campos
                    panelConNeon.CambiarEstado(true, camposCompletos);

                    // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                    btn_AmpliarReducir_VEHICULO.Parent = panel_DatosVehiculo;
                    btn_AmpliarReducir_VEHICULO.Location = new System.Drawing.Point(561, 1);


                    panel_DatosEspecificos.Visible = false;
                }
                else
                {
                    // Expandir el panel
                    panel_DatosVehiculo.Height = alturaOriginalPanel_Vehiculo;
                    btn_AmpliarReducir_VEHICULO.Image = Properties.Resources.dobleFlechaARRIBA;
                    panelExpandido_Vehiculo = true;
                    panel_DatosVehiculo.BorderStyle = BorderStyle.None;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

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
                // AjustarTamanoFormulario();
            }
        }

        private void Btn_AmpliarReducir_HECHO_Click(object sender, EventArgs e)
        {
            if (panel_DatosHecho is PanelConBordeNeon panelConNeon)
            {
                if (panelExpandido_DatosHecho)
                {
                    // Contraer el panel
                    panel_DatosHecho.Height = alturaContraidaPanel;
                    panel_DatosHecho.BorderStyle = BorderStyle.None;

                    btn_AmpliarReducir_HECHO.Image = Properties.Resources.dobleFlechaABAJO; // Cambiar la imagen a "Flecha hacia abajo"
                    panelExpandido_DatosHecho = false;

                    // Aplicar borde neón para el estado contraído
                    bool camposCompletos = VerificarCamposEnPanel(panel_DetalleHecho); // Método personalizado para verificar campos
                    panelConNeon.CambiarEstado(true, camposCompletos);

                    // Cambiar la posición y el padre del botón al panel_DatosVehiculo
                    btn_AmpliarReducir_HECHO.Parent = panel_DatosHecho;
                    btn_AmpliarReducir_HECHO.Location = new System.Drawing.Point(561, 1);


                    panel_DetalleHecho.Visible = false;
                }
                else
                {
                    // Expandir el panel
                    panel_DatosHecho.Height = alturaOriginalPanel_DatosHecho;
                    btn_AmpliarReducir_HECHO.Image = Properties.Resources.dobleFlechaARRIBA;
                    panelExpandido_DatosHecho = true;
                    panel_DatosHecho.BorderStyle = BorderStyle.None;

                    // Cambiar el estilo del borde
                    panelConNeon.CambiarEstado(false, false); // Panel expandido, campos completos

                    // Mover el botón al panel_DatosEspecificos
                    btn_AmpliarReducir_HECHO.Parent = panel_DetalleHecho;
                    btn_AmpliarReducir_HECHO.Location = new System.Drawing.Point(558, 1);

                    

                    // Mostrar los demás controles del panel
                    foreach (Control control in panel_DatosHecho.Controls)
                    {
                        control.Visible = true;
                    }
                }

                // Ajustar el tamaño del formulario si es necesario
                // AjustarTamanoFormulario();
            }
        }
    }
}

