using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.GenerarDocumentos;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics.Eventing.Reader;
using Ofelia_Sara.general.clases.Botones;
using Ofelia_Sara.general.clases.Apariencia_General;
using System.Diagnostics;
using Ofelia_Sara.general.clases.Agregar_Componentes;
using Ofelia_Sara.general.clases.Apariencia_General.Controles;


namespace Ofelia_Sara
{
    public partial class InicioCierre : BaseForm
    {
        private int totalCampos;////declaracion de variables que se emplean para progressVerticalBar
        private int camposCompletos;
        private ToolTip toolTip;
        private const string ComboBoxFilePath = "comboBoxDependenciaItems.txt"; // Ruta del archivo

        public InicioCierre()
        {
            InitializeComponent();

            //----------------------------------------------
            //---manejador de teclado--------------
            panel1.KeyDown += new KeyEventHandler(InicioCierre_KeyDown);
            panel1.Focus(); // Asegúrate de que el panel tenga el foco para recibir eventos

            progressVerticalBar1 = new ProgressVerticalBar();
            progressVerticalBar2 = new ProgressVerticalBar();

            //------------inicialización de totalCampos y camposCompletos
            totalCampos = ObtenerTotalCampos();
            camposCompletos = ObtenerCamposCompletos();


            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarCausa);
            InicializarEstiloBotonAgregar(btn_AgregarVictima);
            InicializarEstiloBotonAgregar(btn_AgregarImputado);

            // Actualizar los ProgressVerticalBar según los campos completos
            ActualizarProgressBars();

            this.Load += new System.EventHandler(this.InicioCierre_Load);

            // Asocia el evento TextChanged al método de validación
            textBox_Victima.TextChanged += new EventHandler(textBox_Victima_TextChanged);

            //--------------------------------------------------------------------------------
            //-----para los botones de agregar datos personales completos------------------
            // Inicialmente, deshabilita el botón
            btn_AgregarDatosVictima.Enabled = false;
            btn_AgregarDatosVictima.BackColor = Color.Tomato;

            // Inicialmente, deshabilita el botón
            btn_AgregarDatosImputado.Enabled = false;
            btn_AgregarDatosImputado.BackColor = Color.Tomato;
            //--------------------------------------------------------------------------------

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(InicioCierre_KeyDown);

            //-----------control de saltos de input--------------------------------------
            // Registra el método Form_KeyDown al evento KeyDown del formulario
            //this.KeyDown += InicioCierre_KeyDown;

            // Cargar ítems en el ComboBox al iniciar el formulario
            //ComboBoxManager.LoadComboBoxItems(comboBox_Dependencia, ComboBoxFilePath);
        }
        //-----------------------------------------------------------------

        private void Control_Enter(object sender, EventArgs e)
        {
            Debug.WriteLine($"Control con foco: {((Control)sender)?.Name}");
        }

        //-------------------------------------------------------------------
        private void InicioCierre_Load(object sender, EventArgs e)
        {
            InicializarComboBox(); //para que se inicialicen los indices predeterminados de comboBox
            ActualizarProgressBars();
            timePickerPersonalizado1.SelectedDate = DateTime.Now;
            TooltipEnBtnDesactivado.ConfigurarToolTipYTimer(this, btn_AgregarDatosVictima, "Completar nombre de VICTIMA para ingresar más datos");
            TooltipEnBtnDesactivado.ConfigurarToolTipYTimer(this, btn_AgregarDatosImputado, "Completar nombre de IMPUTADO para ingresar más datos");

            ComboBoxManager.ItemAdded += ComboBoxManager_ItemAdded;//para recargar y agregar nuevos items en comboBox
            //-------------------------------------------------------------------------------
            // Define las excepciones para los TextBox y ComboBox.
            var textBoxExcepciones = new Dictionary<string, bool>
        {
            { "textBox_NumeroIpp", true }  // Este TextBox solo acepta números.
        };

            var comboBoxExcepciones = new Dictionary<string, bool>
        {
            { "ComboBox_Ufid", true }  // Este ComboBox acepta letras, números y espacios.
        };

            // Aplica la configuración a todos los controles del formulario.
            TextoEnMayuscula.AplicarAControles(this, textBoxExcepciones, comboBoxExcepciones); //para guardar los items

            //-----------------------------------------------------------------
            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);

        }


        //-----------------------------------------------------------------------------

        //---------BOTON GUARDAR--------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {


            // Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_Caratula.Text) ||
                string.IsNullOrWhiteSpace(textBox_Imputado.Text) ||
                string.IsNullOrWhiteSpace(textBox_Victima.Text))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar los campos Caratula, Imputado y Victima.", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //--------------------------------------------------------------


        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //-------------------------------------------------------------------------------


        //----------------------------------------------------------


        //--------EVENTO PARA QUE SEA SOLO NUMERO ---------------------
        //--------EL TEXTBOX DE NUMERO DE IPP---------------------


        //--------------METODO PARA LIMITAR LOS CARACTERES A 6--------------
        private void textBox_NumeroIpp_TextChanged(object sender, EventArgs e)
        {
            // Limitar a 6 caracteres
            if (textBox_NumeroIpp.Text.Length > 6)
            {
                // Si el texto excede los 6 caracteres, cortar el exceso
                textBox_NumeroIpp.Text = textBox_NumeroIpp.Text.Substring(0, 6);

                // Mover el cursor al final del texto
                textBox_NumeroIpp.SelectionStart = textBox_NumeroIpp.Text.Length;
            }
        }
        //-------------------------------------------------------------
        //---------------COMBO BOX IPP 1      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp1_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp1.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp1.Text = comboBox_Ipp1.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp1.SelectionStart = comboBox_Ipp1.Text.Length;
            }
        }

        //---------------COMBO BOX IPP 2      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp2_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp2.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp2.Text = comboBox_Ipp2.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp2.SelectionStart = comboBox_Ipp2.Text.Length;
            }
        }

        //---------------COMBO BOX IPP 4      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp4_TextUpdate(object sender, EventArgs e)
        {
            // Limitar a 2 caracteres
            if (comboBox_Ipp4.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp4.Text = comboBox_Ipp4.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                comboBox_Ipp4.SelectionStart = comboBox_Ipp4.Text.Length;
            }
        }

        //-----------------------------------------------------
        //------------BOTON IMPRIMIR---------------



        //// Método para actualizar el estado del botón Imprimir
        //private void ActualizarEstadoBotonImprimir()
        //{
        //    btn_Imprimir.Enabled = ValidadorCamposImpresion.VerificarCamposCompletos(Controls);

        //    if (btn_Imprimir.Enabled)
        //    {
        //        // Si todos los campos están completos, habilitar el botón y poner el fondo en verde
        //        btn_Imprimir.Enabled = true;
        //        //btn_Imprimir.BackColor = Color.Green; /*COLOR NORMAL*/
        //        btn_Imprimir.BackColor = Color.FromArgb(0, 204, 0);//FromArgb permite uso RGB (este seria color verder)
        //    }
        //    else
        //    {
        //        // Si no todos los campos están completos, deshabilitar el botón y poner el fondo en rojo
        //        btn_Imprimir.Enabled = false;
        //        btn_Imprimir.BackColor = Color.FromArgb(211, 47, 47); //Color rojo
        //    }
        //}






        // Crea ventana que muestra archivo cargando
        private void CargarImpresion()
        {
            using (MensajeCargarImprimir imprimirMessageBox = new MensajeCargarImprimir())
            {
                imprimirMessageBox.ShowDialog();//showdialog implica "bloquea interaccion con ventana principal hasta que se cierra"
            }
        }

        // Evento Click del botón Imprimir
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {

            if (btn_Imprimir.Enabled) //si el boton esta habilitado -->mostrar progreso
            {
                //logica para guardar el archivo en base de datos
                CargarImpresion();

                var generador = new GeneradorDocumentos();
                var datosFormulario = ObtenerDatosFormulario();

                // Definir rutas
                string rutaPlantilla = @"C:\Users\Usuario\OneDrive\Escritorio\.net\plantillaPrototipo.dotx";
                string rutaArchivoSalida = @"C:\Users\Usuario\OneDrive\Escritorio\.net\archivos de salida";

                generador.GenerarDocumento(rutaPlantilla, rutaArchivoSalida, datosFormulario);

            }
        }

        //--------------------------------------------------------------------------------
        //---------METODO PARA MOSTRAR EL AVANCE DE ProgressVerticalBar--------------------
        //-------este metodo esta presente en BaseForm---------------------------------
        // Suponiendo que tienes progressBar1 y progressBar2 en tu formulario

        private void ActualizarProgressBars()
        {

            ControladorProgressVerticalBar.ConfigurarProgressVerticalBar(progressVerticalBar1, progressVerticalBar2, camposCompletos, totalCampos);
        }
        private int ObtenerTotalCampos()
        {
            // Lógica para obtener el número total de campos específica para este formulario
            return this.Controls.OfType<System.Windows.Forms.TextBox>().Count();
        }

        private int ObtenerCamposCompletos()
        {
            // Lógica para obtener el número de campos completos específica para este formulario
            int completos = 0;
            foreach (System.Windows.Forms.TextBox textBox in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                    completos++;
            }
            return completos;
        }

        //---------------------------------------------------------------------------------
        //--Para corregir el error de que los indices predeterminados no se cargan al inicio, sino tras ejecutar la logica de btm_limpiar
        // y si se carga directamente en . designer, se borran los indices predeterminados
        //----SE ASIGNARA LOS INDICE PREDETERMINADOS EN ESTE METODO  "LOAD" PARA QUE SE CARGE AL INICIO
        // Establecer índices predeterminados de ComboBox aquí
        private void InicializarComboBox()
        {
            comboBox_Ipp1.SelectedIndex = 3;
            comboBox_Ipp2.SelectedIndex = 3;
            comboBox_Ipp4.SelectedIndex = 0;
            comboBox_Ufid.SelectedIndex = 0;
            comboBox_Dr.SelectedIndex = 0;
            comboBox_Instructor.SelectedIndex = 0;
            comboBox_Secretario.SelectedIndex = 0;
            comboBox_Dependencia.SelectedIndex = 0;
            comboBox_Localidad.SelectedIndex = 0;
            comboBox_DeptoJudicial.SelectedIndex = 0;
        }         //---------------------------------------------------------------------------------


        // Evento TextChanged o SelectedIndexChanged de los controles relevantes
        //private void Control_TextChanged(object sender, EventArgs e)
        //{
        //    ValidadorCamposImpresion.VerificarYActualizarBotonImprimir(this, btn_Imprimir);
        //}

        //----------------------------------------------------------------------

        //--------Diccionario para cargar los datos a los marcadores del documento-------------
        private Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>
    {
        { "caratula", textBox_Caratula.Text },
        { "victima", textBox_Caratula.Text },
        { "imputado", textBox_Caratula.Text },
        { "instructor", textBox_Caratula.Text },
        { "secretario", textBox_Caratula.Text },
        { "DeptoJudicial", textBox_Caratula.Text },
      //  { "fecha", dateTimePicker_Fecha.Value.ToString("dd/MM/yyyy") },  // Convertir a string con formato
       // { "ufid", numericUpDown_Edad.Value.ToString() }  // Convertir a string
        // Agrega aquí más datos y sus respectivos marcadores
    };

            return datosFormulario;
        }

        private void btn_AgregarDatosVictima_Click(object sender, EventArgs e)
        {
            AgregarDatosPersonalesVictima agregarDatosPersonales = new AgregarDatosPersonalesVictima();

            agregarDatosPersonales.TextoNombre = textBox_Victima.Text; // Pasa el contenido del TextBox
            agregarDatosPersonales.Show();

        }
        //------------------------------------------------------------------------------
        //-----METODO HABILITA BTN AGREGAR CAUSA
        private void textBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);
        }

        //-------------------------------------------------------------------------------
        //--------Evento para abrir FORMULARIO AGREGAR DATOS IMPUTADO-----------------------
        private void btn_AgregarDatosImputado_Click(object sender, EventArgs e)
        {
            AgregarDatosPersonalesImputado agregarDatosPersonales = new AgregarDatosPersonalesImputado();

            agregarDatosPersonales.TextoNombre = textBox_Imputado.Text; // Pasa el contenido del TextBox
            agregarDatosPersonales.Show();
        }

        private void textBox_Victima_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text))
            {
                btn_AgregarDatosVictima.BackColor = Color.GreenYellow;
                
            }
            else
            {
                btn_AgregarDatosVictima.BackColor = Color.Tomato;
              
            }
            // Habilita o deshabilita btn_AgregarVictima según si el TextBox tiene texto
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
        }

        private void textBox_Imputado_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text))
            {
                btn_AgregarDatosImputado.BackColor = Color.GreenYellow;
            }
            else
            {
                btn_AgregarDatosImputado.BackColor = Color.Tomato;
            }
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);// deshabilita el btn agregarImputado si el textBox no tiene texto

        }

        //-----EVENTO PARA COMPLETAR CON "0" LOS CARACTERES FALTANTE EN NUMERO IPP------
        private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Obtiene el TextBox que disparó el evento
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Obtiene el texto actual del TextBox
                    string currentText = textBox.Text;

                    // Verifica si el texto es numérico
                    if (int.TryParse(currentText, out _))
                    {
                        // Completa el texto con ceros a la izquierda hasta alcanzar 6 caracteres
                        string completedText = currentText.PadLeft(6, '0');

                        // Actualiza el texto del TextBox
                        textBox.Text = completedText;
                    }
                }

                // Marca el evento como manejado para evitar el comportamiento predeterminado
                e.Handled = true;
            }
        }

        //---prueba para ver si logro implementar manejo de teclas
        private void InicioCierre_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"Tecla presionada: {e.KeyCode}"); // Verifica si el evento se activa
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Suprime el efecto predeterminado del Tab
                SelectNextControl(ActiveControl, true, true, true, true); // Mueve al siguiente control
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoveToPreviousControl();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveToNextControl();
                e.SuppressKeyPress = true;
            }
        }

        private void MoveToNextControl()
        {
            var controls = this.Controls.Cast<Control>().ToList();
            var currentIndex = controls.IndexOf(ActiveControl);
            if (currentIndex >= 0 && currentIndex < controls.Count - 1)
            {
                var nextControl = controls[currentIndex + 1];
                Debug.WriteLine($"Moviendo foco a: {nextControl.Name}, Habilitado: {nextControl.Enabled}, Visible: {nextControl.Visible}");
                if (nextControl.Enabled && nextControl.Visible)
                {
                    nextControl.Focus();
                }
            }
        }

        private void MoveToPreviousControl()
        {
            var controls = this.Controls.Cast<Control>().ToList();
            var currentIndex = controls.IndexOf(ActiveControl);
            if (currentIndex > 0)
            {
                var previousControl = controls[currentIndex - 1];
                Debug.WriteLine($"Moviendo foco a: {previousControl.Name}, Habilitado: {previousControl.Enabled}, Visible: {previousControl.Visible}");
                if (previousControl.Enabled && previousControl.Visible)
                {
                    previousControl.Focus();
                }
            }
        }


        //-------------------------------------------------------------------------
        //----eventos PARA ACTUALIZAR COMBO BOX---------------------------------
        private void InicioCierre_FormClosed(object sender, FormClosedEventArgs e)
        {
            ComboBoxManager.ItemAdded -= ComboBoxManager_ItemAdded;
        }

        private void ComboBoxManager_ItemAdded(string nuevoItem)
        {
            // Aquí puedes actualizar el ComboBox o realizar otras acciones
            comboBox_Dependencia.Items.Add(nuevoItem);
        }

        private void btn_AgregarVictima_Click(object sender, EventArgs e)
        {


            // Crear una instancia de NuevaPersonaControl
            NuevaPersonaControl nuevaVictimaControl = new NuevaPersonaControl
            {
                TipoPersona = "Victima"
            };

            // Establecer la posición del nuevo control
            if (panel_Victima.Controls.Count == 0)
            {
                // Si es el primer control, colócalo justo debajo del botón
                // Ajusta la coordenada Y según la posición del botón
                nuevaVictimaControl.Location = new Point(3, btn_AgregarVictima.Bottom + 6);
            }
            else
            {
                // Para otros controles, colócalos debajo del último control agregado
                var ultimoControl = panel_Victima.Controls[panel_Victima.Controls.Count - 1];
                nuevaVictimaControl.Location = new Point(3, ultimoControl.Bottom + 1); // Ajusta la distancia entre controles
            }
            // Agregar el nuevo control al panel_Victima
            panel_Victima.Controls.Add(nuevaVictimaControl);

            // Ajustar la altura del panel_Victima para incluir el nuevo control
            AjustarAlturaPanel(panel_Victima);

            // Ajustar la posición de los paneles siguientes para que se muevan hacia abajo
            AjustarPosicionPanelesSiguientes(panel_Victima);

            // Ajustar la posición de los paneles siguientes
            AjustarPosicionPanelesInferiores();

            // Reposicionar panel_Imputado y panel_ControlesInferiores
            ReposicionarPanelesDinamicamente();

        }

        private void btn_AgregarImputado_Click(object sender, EventArgs e)
        {
            // Crear una instancia de NuevaPersonaControl
            NuevaPersonaControl nuevoImputadoControl = new NuevaPersonaControl
            {
                TipoPersona = "Imputado"
            };

            // Establecer la posición del nuevo control
            if (panel_Imputado.Controls.Count == 0)
            {
                // Si es el primer control, colócalo justo debajo del botón
                // Ajusta la coordenada Y según la posición del botón
                nuevoImputadoControl.Location = new Point(3, btn_AgregarImputado.Bottom + 4);
            }
            else
            {
                // Para otros controles, colócalos debajo del último control agregado
                var ultimoControl = panel_Imputado.Controls[panel_Imputado.Controls.Count - 1];
                nuevoImputadoControl.Location = new Point(0, ultimoControl.Bottom + 1); // Ajusta la distancia entre controles
            }
            // Agregar el nuevo control al panel_Imputado
            panel_Imputado.Controls.Add(nuevoImputadoControl);

            // Ajustar la altura del panel_Imputado
            AjustarAlturaPanel(panel_Imputado);

            // Ajustar la posición de los paneles siguientes
            AjustarPosicionPanelesSiguientes(panel_Imputado);

            // Ajustar la posición de los paneles siguientes
            AjustarPosicionPanelesInferiores();

            // Reposicionar panel_ControlesInferiores
            ReposicionarPanelesDinamicamente();

        }

        private void AgregarNuevoControl(string tipoPersona, Panel panel)
        {
            // Crear una nueva instancia del control NuevaPersonaControl
            NuevaPersonaControl nuevoControl = new NuevaPersonaControl
            {
                TipoPersona = tipoPersona
            };
            // Establecer la posición inicial en el panel
            int y = 10; // Posición vertical inicial
            int x = 0; // Posición horizontal

            // Determinar la posición para el nuevo control
            if (panel.Controls.Count > 0)
            {
                // Obtener el último control para determinar la nueva posición
                Control ultimoControl = panel.Controls[panel.Controls.Count - 1];
                y = ultimoControl.Bottom + 6; // 9 es el espacio entre controles
            }

            // Configurar la posición del nuevo control
            nuevoControl.Location = new Point(x, y);

            // Agregar el nuevo control al panel
            panel.Controls.Add(nuevoControl);

            // Ajustar la altura del panel para acomodar el nuevo control
            AjustarAlturaPanel(panel);

        }

        private void AjustarAlturaPanel(Panel panel)
        {
            // Calcular la altura necesaria del panel basada en todos los controles visibles
            int nuevaAltura = 0;

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl.Visible)
                {
                    int posicionYConAltura = ctrl.Bottom;
                    if (posicionYConAltura > nuevaAltura)
                    {
                        nuevaAltura = posicionYConAltura;
                    }
                }
            }

            // Añadir un margen para evitar que el panel esté justo en el borde
            nuevaAltura += 6; // Ajustar según el margen deseado

            // Establecer la nueva altura del panel
            panel.Height = nuevaAltura;
        }

        private void AjustarPosicionPanelesSiguientes(Panel panelAjustado)
        {
            // Determinar la referencia al panel que contiene los controles inferiores
            Panel panelControlesInferiores = panel_ControlesInferiores;

            // Ajustar la posición del panel que contiene los controles inferiores
            if (panelControlesInferiores != null)
            {
                panelControlesInferiores.Location = new Point(panelControlesInferiores.Location.X, panelAjustado.Bottom + 10); // Ajuste de 10 píxeles
            }

            // Finalmente, ajustar la altura del formulario principal si es necesario
            Form formularioPrincipal = panelAjustado.FindForm();
            if (formularioPrincipal != null)
            {
                formularioPrincipal.Height = formularioPrincipal.Controls.OfType<Control>().Max(c => c.Bottom) + 20;
            }
        }

        private void AjustarAlturaFormulario()
        {
            // Calcular la altura total necesaria para el formulario
            int nuevaAltura = panel_Victima.Bottom + panel_Imputado.Height + panel_ControlesInferiores.Height + 20; // Ajustar el margen según sea necesario

            // Asegurarse de que la altura del formulario sea suficiente para incluir todos los paneles
            if (this.Height < nuevaAltura)
            {
                this.Height = nuevaAltura;
            }
        }
        private void AjustarPosicionPanelesInferiores()
        {
            // Ajustar la posición del panel_Imputado
            panel_Imputado.Location = new Point(panel_Imputado.Location.X, panel_Victima.Bottom + 10); // Ajustar la distancia entre paneles si es necesario

            // Ajustar la posición del panel_ControlesInferiores
            panel_ControlesInferiores.Location = new Point(panel_ControlesInferiores.Location.X, panel_Imputado.Bottom + 10); // Ajustar la distancia entre paneles si es necesario
        }

        private void ReposicionarPanelesDinamicamente()
        {
            // Ajustar la posición de panel_Imputado con respecto a panel_Victima
            panel_Imputado.Location = new Point(panel_Imputado.Location.X, panel_Victima.Bottom + 10);

            // Ajustar la posición de panel_ControlesInferiores con respecto a panel_Imputado
            panel_ControlesInferiores.Location = new Point(panel_ControlesInferiores.Location.X, panel_Imputado.Bottom + 10);

            // Ajustar la altura del formulario si es necesario
            AjustarAlturaFormulario();
        }

        private void btn_AgregarCausa_Click(object sender, EventArgs e)
        {

        }
    }
}