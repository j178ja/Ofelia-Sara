using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.GenerarDocumentos;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
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
using System.Web.UI.WebControls.WebParts;
using Ofelia_Sara.Registro_de_personal;
//using Ofelia_Sara.Base_de_Datos;
using Mysqlx.Cursor;
using Ofelia_Sara.Base_de_Datos.Entidades;
using System.Text.Json;
using Ofelia_Sara.general.clases.Apariencia_General.Generales;
using System.Drawing.Drawing2D;



namespace Ofelia_Sara
{
    public partial class InicioCierre : BaseForm
    {
        // Listas para almacenar víctimas e imputados
        private List<string> victimas = new List<string>();
        private List<string> imputados = new List<string>();

        private int totalCampos;////declaracion de variables que se emplean para progressVerticalBar
        private int camposCompletos;
        private ToolTip toolTip;
        private const string ComboBoxFilePath = "comboBoxDependenciaItems.txt"; // Ruta del archivo
        private AgregarDatosPersonalesVictima agregarDatosPersonalesVictima;
        private AgregarDatosPersonalesImputado agregarDatosPersonalesImputado;
        public InicioCierre()
        {
            InitializeComponent();

            textBox_NumeroIpp.TextChanged += (s, e) => ActualizarEstado();
            textBox_Caratula.TextChanged += (s, e) => ActualizarEstado();
            textBox_Victima.TextChanged += (s, e) => ActualizarEstado();
            textBox_Imputado.TextChanged += (s, e) => ActualizarEstado();
          
            comboBox_AgenteFiscal.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Instructor.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Secretario.SelectedIndexChanged += (s, e) => ActualizarEstado();
            comboBox_Dependencia.SelectedIndexChanged += (s, e) => ActualizarEstado();

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBotonAgregar(btn_AgregarCausa);
            InicializarEstiloBotonAgregar(btn_AgregarVictima);
            InicializarEstiloBotonAgregar(btn_AgregarImputado);

            this.Load += new System.EventHandler(this.InicioCierre_Load);

            // Asocia el evento TextChanged al método de validación
            textBox_Victima.TextChanged += new EventHandler(textBox_Victima_TextChanged);
            textBox_Imputado.TextChanged += new EventHandler(textBox_Imputado_TextChanged);

            //-----para los botones de agregar datos personales completos------------------
            // Inicialmente, deshabilita el botón
            btn_AgregarDatosVictima.Enabled = false;
            btn_AgregarDatosVictima.BackColor = Color.Tomato;

            // Inicialmente, deshabilita el botón
            btn_AgregarDatosImputado.Enabled = false;
            btn_AgregarDatosImputado.BackColor = Color.Tomato;

            comboBox_DeptoJudicial.TextChanged += comboBox_DeptoJudicial_TextChanged;
        }


        private void InicioCierre_Load(object sender, EventArgs e)
        {
            InicializarComboBox(); //para que se inicialicen los indices predeterminados de comboBox

            timePickerPersonalizado1.SelectedDate = DateTime.Now;
            TooltipEnBtnDesactivado.ConfigurarToolTipYTimer(this, btn_AgregarDatosVictima, "Completar nombre de VICTIMA para ingresar más datos");
            TooltipEnBtnDesactivado.ConfigurarToolTipYTimer(this, btn_AgregarDatosImputado, "Completar nombre de IMPUTADO para ingresar más datos");

            //-------------------------------------------------------------------------------
            MayusculaYnumeros.AplicarAControl(textBox_Caratula);
            MayusculaSola.AplicarAControl(textBox_Victima);
            MayusculaSola.AplicarAControl(textBox_Imputado);
            MayusculaSola.AplicarAControl(comboBox_Localidad);
            MayusculaYnumeros.AplicarAControl(comboBox_Instructor);
            MayusculaYnumeros.AplicarAControl(comboBox_Secretario);
            MayusculaYnumeros.AplicarAControl(comboBox_Dependencia);

            //-----------------------------------------------------------------
            //---Inicializar para desactivar los btn AGREGAR CAUSA,VICTIMA, IMPUTADO
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//inicializacion de deshabilitacion de btn_agregarVictima
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);

            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxSECRETARIO();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxINSTRUCTOR();
            InicializarComboBoxDEPENDENCIAS();

            ActualizarEstado();//PARA LABEL Y CHECK CARGO
        }
        
        //-----------------------------------------------------------------------------
        private void GuardarDatos()
        {
            // Obtener los datos del formulario
            int numeroIpp = int.Parse(textBox_NumeroIpp.Text);
            string ufid = comboBox_Fiscalia.Text;
            string dr = comboBox_AgenteFiscal.Text;
            string localidad = comboBox_Localidad.Text;
            string DeptoJudicial = comboBox_DeptoJudicial.Text;
            string instructor = comboBox_Instructor.Text;
            string secretario = comboBox_Secretario.Text;
            string dependencia = comboBox_Dependencia.Text;
            //string fecha = timePickerPersonalizado1.Value.ToString("yyyy-MM-dd");

            // Obtener las listas de víctimas e imputados
            List<string> victimas = new List<string>();
            List<string> imputados = new List<string>();

            //foreach (var item in lstVictimas.Items)
            //{
            //    victimas.Add(item.ToString());
            //}

            //foreach (var item in lstImputados.Items)
            //{
            //    imputados.Add(item.ToString());
            //}

            //// Llamar al método GuardarIPP
            //dataInserter.GuardarIPP(numeroIpp, ufid, dr, localidad, DeptoJudicial, instructor, secretario, dependencia, fecha, victimas, imputados);

        }
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

            InicializarComboBoxFISCALIA(); // INICIALIZA LAS FISCALIAS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxSECRETARIO();// INICIALIZA LOS SECRETARIOS DE ACUERDO A ARCHIVO JSON
            InicializarComboBoxINSTRUCTOR();
            InicializarComboBoxDEPENDENCIAS();

            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //-------------------------------------------------------------------------------


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
                ActualizarEstado();
            }

        }
        //-------------------------------------------------------------
      
        //---------------COMBO BOX IPP 1      ------------------
        //--------LIMITANDO CANTIDAD DE CARACTERES A 2
        private void comboBox_Ipp1_TextUpdate(object sender, EventArgs e)
        {
          if (comboBox_Ipp1.Text.Length > 2) // Limitar a 2 caracteres
            {
                comboBox_Ipp1.Text = comboBox_Ipp1.Text.Substring(0, 2);// Si el texto excede los 2 caracteres, cortar el exceso
                comboBox_Ipp1.SelectionStart = comboBox_Ipp1.Text.Length; // Mover el cursor al final del texto
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
        //-----EVENTO PARA COMPLETAR CON "0" LOS CARACTERES FALTANTE EN NUMERO IPP------
        private void textBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada si no es un número
            }

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

                        // Posiciona el cursor al final del texto
                        textBox.SelectionStart = textBox.Text.Length;

                        // Cancelar el manejo predeterminado de la tecla Enter
                        e.Handled = true;
                    }
                }
            }
        }



        //--------------------------------------------------------------------------------------------
        //--------BOTON IMPRIMIR-------------------------------

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

                CargarImpresion();

                var generador = new GeneradorDocumentos();
                var datosFormulario = ObtenerDatosFormulario();

                // Definir rutas
                string rutaPlantilla = @"C:\Users\Usuario\OneDrive\Escritorio\.net\plantillaPrototipo.dotx";
                string rutaArchivoSalida = @"C:\Users\Usuario\OneDrive\Escritorio\.net\archivos de salida";

                generador.GenerarDocumento(rutaPlantilla, rutaArchivoSalida, datosFormulario);

            }
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

        }
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
         };
            return datosFormulario;
        }

        //----BOTON AGREGAR DATOS VICTIMA-----------------------------
        private void btn_AgregarDatosVictima_Click(object sender, EventArgs e)
        {
            if (agregarDatosPersonalesVictima == null || agregarDatosPersonalesVictima.IsDisposed)
            {
                agregarDatosPersonalesVictima = new AgregarDatosPersonalesVictima();

                // Suscribirse al evento personalizado del formulario de destino
                agregarDatosPersonalesVictima.VictimaTextChanged += UpdateVictimaTextBox;
            }

            // Establecer el texto inicial en el formulario de destino
            agregarDatosPersonalesVictima.TextoNombre = textBox_Victima.Text;

            // Suscribirse al evento TextChanged del TextBox en el formulario de origen
            textBox_Victima.TextChanged += (s, ev) =>
            {
                agregarDatosPersonalesVictima.TextoNombre = textBox_Victima.Text;
            };


            // Obtener el formulario original (inicioCierre)
            Form originalForm = this;

            // Obtener el tamaño de ambos formularios
            int totalWidth = originalForm.Width + agregarDatosPersonalesVictima.Width;
            int height = Math.Max(originalForm.Height, agregarDatosPersonalesVictima.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario agregarDatosPersonales a la izquierda del original
            agregarDatosPersonalesVictima.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesVictima.Location = new Point(startX, startY);

            // Posicionar el formulario original a la derecha del agregarDatosPersonales
            originalForm.Location = new Point(startX + agregarDatosPersonalesVictima.Width, startY);

            // Suscribirse al evento FormClosed del formulario Cargo
            agregarDatosPersonalesVictima.FormClosed += (s, args) =>
            {
                // Calcular la nueva posición para centrar el formulario original
                int centerX = (screenWidth - originalForm.Width) / 2;
                int centerY = (screenHeight - originalForm.Height) / 2;

                // Reposicionar el formulario original en el centro de la pantalla
                originalForm.Location = new Point(centerX, centerY);
            };

            agregarDatosPersonalesVictima.Show();

        }

        // Método para actualizar el TextBox en inicioCierre
        private void UpdateVictimaTextBox(string text)
        {
            textBox_Victima.Text = text;
        }


        //------------------------------------------------------------------------------

        //-----------------METODO HABILITA BTN AGREGAR CAUSA------------------------------
        private void textBox_Caratula_TextChanged(object sender, EventArgs e)
        {
            btn_AgregarCausa.Enabled = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);//habilita el btn_AgregarCausa en caso de tener texto
            ActualizarEstado();
        }

        //-------------------------------------------------------------------------------
        //--------Evento para abrir FORMULARIO AGREGAR DATOS IMPUTADO-----------------------
        private void btn_AgregarDatosImputado_Click(object sender, EventArgs e)
        {
  
            if (agregarDatosPersonalesImputado == null || agregarDatosPersonalesImputado.IsDisposed)
            {
                agregarDatosPersonalesImputado = new AgregarDatosPersonalesImputado();

                // Suscribirse al evento personalizado del formulario de destino
                agregarDatosPersonalesImputado.ImputadoTextChanged += UpdateImputadoTextBox;
            }

            // Establecer el texto inicial en el formulario de destino
            agregarDatosPersonalesImputado.TextoNombre = textBox_Imputado.Text;

            // Suscribirse al evento TextChanged del TextBox en el formulario de origen
            textBox_Imputado.TextChanged += (s, ev) =>
            {
                agregarDatosPersonalesImputado.TextoNombre = textBox_Imputado.Text;
            };

            // Obtener el formulario original(inicioCierre)
            Form originalForm = this;

            // Obtener el tamaño de ambos formularios
            int totalWidth = originalForm.Width + agregarDatosPersonalesImputado.Width;
            int height = Math.Max(originalForm.Height, agregarDatosPersonalesImputado.Height);

            // Calcular la posición para centrar ambos formularios en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            // Posicionar el formulario agregarDatosPersonales a la izquierda del original
            agregarDatosPersonalesImputado.StartPosition = FormStartPosition.Manual;
            agregarDatosPersonalesImputado.Location = new Point(startX, startY);

            // Posicionar el formulario original a la derecha del agregarDatosPersonales
            originalForm.Location = new Point(startX + agregarDatosPersonalesImputado.Width, startY);

            // Suscribirse al evento FormClosed del formulario Cargo
            agregarDatosPersonalesImputado.FormClosed += (s, args) =>
            {
                // Calcular la nueva posición para centrar el formulario original
                int centerX = (screenWidth - originalForm.Width) / 2;
                int centerY = (screenHeight - originalForm.Height) / 2;

                // Reposicionar el formulario original en el centro de la pantalla
                originalForm.Location = new Point(centerX, centerY);
            };

            agregarDatosPersonalesImputado.Show();
        }

        // Método para actualizar el TextBox en inicioCierre
        private void UpdateImputadoTextBox(string text)
        {
            textBox_Imputado.Text = text;
        }

        //-------------------TEXTBOX VICTIMA------------------------------------------------------------
        private void textBox_Victima_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text))
            {
                btn_AgregarDatosVictima.BackColor = Color.GreenYellow;
                ActualizarEstado();
                if (agregarDatosPersonalesVictima != null && !agregarDatosPersonalesVictima.IsDisposed)
                {
                                        // Actualizar el TextBox en el formulario de destino
                    agregarDatosPersonalesVictima.UpdateVictimaTextBox(textBox_Victima.Text);
                }
            }
            else
            {
                btn_AgregarDatosVictima.BackColor = Color.Tomato;

            }
            // Habilita o deshabilita btn_AgregarVictima según si el TextBox tiene texto
            btn_AgregarVictima.Enabled = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
        }

        //-------------------TEXTBOX IMPUTADO------------------------------------------------------------
        private void textBox_Imputado_TextChanged(object sender, EventArgs e)
        {
            // Habilita o deshabilita el botón según si el TextBox tiene texto
            if (btn_AgregarDatosImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text))
            {
                btn_AgregarDatosImputado.BackColor = Color.GreenYellow;
                ActualizarEstado();
                if (agregarDatosPersonalesImputado != null && !agregarDatosPersonalesImputado.IsDisposed)
                {
                    // Actualizar el TextBox en el formulario de destino
                    agregarDatosPersonalesImputado.UpdateImputadoTextBox(textBox_Imputado.Text);
                }
            }
            else
            {
                btn_AgregarDatosImputado.BackColor = Color.Tomato;
            }
            btn_AgregarImputado.Enabled = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);// deshabilita el btn agregarImputado si el textBox no tiene texto

        }


        //--------------------------------------------------------------------------------------------------------

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
                MessageBox.Show("Todos los campos en los controles existentes deben completarse antes de agregar una nueva víctima.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Todos los campos en los controles existentes deben completarse antes de agregar un nuevo imputado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void checkBox_LegajoDetenido_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkBox_LegajoDetenido.Checked)
            {
                // Crear y mostrar el formulario BuscarPersonal
                BuscarPersonal buscarPersonalForm = new BuscarPersonal();

                // Obtener el formulario original (inicioCierre)
                Form originalForm = this;

                // Obtener el tamaño de ambos formularios
                int totalWidth = originalForm.Width + buscarPersonalForm.Width;
                int height = Math.Max(originalForm.Height, buscarPersonalForm.Height);

                // Calcular la posición para centrar ambos formularios en la pantalla
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int startX = (screenWidth - totalWidth) / 2;
                int startY = (screenHeight - height) / 2;

                // Posicionar el formulario original a la izquierda
                originalForm.Location = new Point(startX, startY);

                // Posicionar el formulario  a la derecha del formulario original
                buscarPersonalForm.StartPosition = FormStartPosition.Manual;
                buscarPersonalForm.Location = new Point(startX + originalForm.Width, startY);

                // Suscribirse al evento FormClosed del formulario Cargo
                buscarPersonalForm.FormClosed += (s, args) =>
                {
                    // Calcular la nueva posición para centrar el formulario original
                    int centerX = (screenWidth - originalForm.Width) / 2;
                    int centerY = (screenHeight - originalForm.Height) / 2;

                    // Reposicionar el formulario original en el centro de la pantalla
                    originalForm.Location = new Point(centerX, centerY);
                };

                buscarPersonalForm.ShowDialog();
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            // Crear y mostrar el formulario BuscarPersonal
            BuscarForm buscarForm = new BuscarForm();

            buscarForm.ShowDialog();
        }
        //------------------------------------------------------------------------------
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
            comboBox_DeptoJudicial.DataSource = deptosJudiciales;


            comboBox_Fiscalia.SelectedIndex = -1;
            comboBox_AgenteFiscal.SelectedIndex = -1;
            comboBox_Localidad.SelectedIndex = -1;
            comboBox_DeptoJudicial.SelectedIndex = -1;
        }

        private void ComboBox_Fiscalia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desactivar los ComboBoxes de detalle mientras se actualizan
            comboBox_AgenteFiscal.Enabled = false;
            comboBox_Localidad.Enabled = false;
            comboBox_DeptoJudicial.Enabled = false;

            // Verificar si hay un ítem seleccionado en el comboBox_Fiscalia
            if (comboBox_Fiscalia.SelectedItem != null)
            {
                string nombreFiscalia = comboBox_Fiscalia.SelectedItem.ToString();
                Fiscalia fiscalia = FiscaliaManager.ObtenerFiscaliaPorNombre(nombreFiscalia);

                if (fiscalia != null)
                {
                    // Asignar los valores de la fiscalía a los ComboBoxes correspondientes
                    comboBox_AgenteFiscal.DataSource = new List<string> { fiscalia.AgenteFiscal }.Distinct().ToList();
                    comboBox_Localidad.DataSource = new List<string> { fiscalia.Localidad }.Distinct().ToList();
                    comboBox_DeptoJudicial.DataSource = new List<string> { fiscalia.DeptoJudicial }.Distinct().ToList();
                    ActualizarEstado();
                }
                else
                {
                    // Si no se encuentra la fiscalía, limpiar los ComboBoxes
                    comboBox_AgenteFiscal.DataSource = null;
                    comboBox_Localidad.DataSource = null;
                    comboBox_DeptoJudicial.DataSource = null;
                }

                // Reactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.Enabled = true;
                comboBox_Localidad.Enabled = true;
                comboBox_DeptoJudicial.Enabled = true;
            }
            else
            {
                // Si no hay selección, limpiar y desactivar los ComboBoxes de detalle
                comboBox_AgenteFiscal.DataSource = null;
                comboBox_Localidad.DataSource = null;
                comboBox_DeptoJudicial.DataSource = null;

                comboBox_AgenteFiscal.Enabled = false;
                comboBox_Localidad.Enabled = false;
                comboBox_DeptoJudicial.Enabled = false;
            }
        }
        //----------------------------------------------------------------
        private void InicializarComboBoxSECRETARIO()
        {
            List<Secretario> secretarios = SecretarioManager.ObtenerSecretarios();
            comboBox_Secretario.DataSource = secretarios;
            comboBox_Secretario.DisplayMember = "DescripcionCompleta";
            comboBox_Secretario.SelectedIndex = -1;
        }
        //---------------------------------------------------------------------
        private void InicializarComboBoxINSTRUCTOR()
        {
            List<Instructor> instructores = InstructorManager.ObtenerInstructores();
            comboBox_Instructor.DataSource = instructores;
            comboBox_Instructor.DisplayMember = "DescripcionCompleta";
            comboBox_Instructor.SelectedIndex = -1;
        }
        //------------------------------------------------------------------------
        private void InicializarComboBoxDEPENDENCIAS()
        {
            List<DependenciasPoliciales> dependencias = DependenciaManager.ObtenerDependencias();
            comboBox_Dependencia.DataSource = dependencias;
            comboBox_Dependencia.DisplayMember = "Dependencia";
            comboBox_Dependencia.SelectedIndex = -1;
        }

        private void comboBox_AgenteFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza caracteres no válidos.
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convierte a mayúsculas.
            }
        }

        private void comboBox_Localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza caracteres no válidos.
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convierte a mayúsculas.
            }
        }

        private void textBox_Caratula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Rechaza caracteres no válidos.
            }
            else
            {
                // Convierte letras a mayúsculas y mantiene números y espacios sin cambios
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
        }

        private void comboBox_AgenteFiscal_TextChanged(object sender, EventArgs e)
        {
            comboBox_AgenteFiscal.Text = ConvertirACamelCase.Convertir(comboBox_AgenteFiscal.Text);
            comboBox_AgenteFiscal.SelectionStart = comboBox_AgenteFiscal.Text.Length;
        }

        private void comboBox_Ipp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox_Ipp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox_Ipp4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //--Para habilitar check y modificar label
        private void ActualizarEstado()
        {
            // Verifica si cada campo no está vacío ni solo con espacios
            bool esTextoValidoNumeroIPP = !string.IsNullOrWhiteSpace(textBox_NumeroIpp.Text);
            bool esTextoValidoCaratula = !string.IsNullOrWhiteSpace(textBox_Caratula.Text);
            bool esTextoValidoVictima = !string.IsNullOrWhiteSpace(textBox_Victima.Text);
            bool esTextoValidoImputado = !string.IsNullOrWhiteSpace(textBox_Imputado.Text);
            bool esTextoValidoUfid = !string.IsNullOrWhiteSpace(comboBox_Fiscalia.Text);
            bool esTextoValidoInstructor = !string.IsNullOrWhiteSpace(comboBox_Instructor.Text);
            bool esTextoValidoSecretario = !string.IsNullOrWhiteSpace(comboBox_Secretario.Text);
            bool esTextoValidoDependencia = !string.IsNullOrWhiteSpace(comboBox_Dependencia.Text);
         

            // Todos los campos deben ser válidos para que esTextoValido sea verdadero
            bool esTextoValido = esTextoValidoNumeroIPP && esTextoValidoCaratula && esTextoValidoVictima &&
                                 esTextoValidoImputado && esTextoValidoUfid  &&
                                 esTextoValidoInstructor && esTextoValidoSecretario && esTextoValidoDependencia ;


            // Actualiza el color del label y el estado del checkbox según el estado de validación
            if (esTextoValido)
            {
                label_Cargo.ForeColor = Color.Black;
                label_Cargo.BackColor = Color.Transparent;
                checkBox_Cargo.Enabled = true;
                checkBox_Cargo.BackColor = Color.Transparent;
            }
            else
            {
                label_Cargo.ForeColor = Color.Tomato;
                label_Cargo.BackColor = Color.FromArgb(211, 211, 211); // Gris claro
                checkBox_Cargo.Enabled = false;
                checkBox_Cargo.BackColor = Color.Tomato;
            }
        }

        private void checkBox_Cargo_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkBox_Cargo.Checked)
            {
                string Ipp1 = comboBox_Ipp1.Text;
                string Ipp2 = comboBox_Ipp2.Text;
                string NumeroIpp = textBox_NumeroIpp.Text;
                string Ipp4 = comboBox_Ipp4.Text;
                string Caratula = textBox_Caratula.Text;
                string Victima = textBox_Victima.Text;
                string Imputado = textBox_Imputado.Text;
                string Fiscalia = comboBox_Fiscalia.Text;
                string AgenteFiscal = comboBox_AgenteFiscal.Text;
                string Instructor = comboBox_Instructor.Text;
                string Secretario = comboBox_Secretario.Text;
                string Dependencia = comboBox_Dependencia.Text ;

              // Crear y mostrar el formulario CARGO, pasando los valores obtenidos
        Cargo cargo = new Cargo (Ipp1, Ipp2, NumeroIpp, Ipp4, Caratula, Victima, Imputado,
                                Fiscalia, AgenteFiscal, Instructor, Secretario, Dependencia);


                // Obtener el formulario original (inicioCierre)
                Form originalForm = this;

                // Obtener el tamaño de ambos formularios
                int totalWidth = originalForm.Width + cargo.Width;
                int height = Math.Max(originalForm.Height, cargo.Height);

                // Calcular la posición para centrar ambos formularios en la pantalla
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int startX = (screenWidth - totalWidth) / 2;
                int startY = (screenHeight - height) / 2;

                // Posicionar el formulario original a la izquierda
                originalForm.Location = new Point(startX, startY);

                // Posicionar el formulario Cargo a la derecha del formulario original
                cargo.StartPosition = FormStartPosition.Manual;
                cargo.Location = new Point(startX + originalForm.Width, startY);

                // Suscribirse al evento FormClosed del formulario Cargo
                cargo.FormClosed += (s, args) =>
                {
                    // Calcular la nueva posición para centrar el formulario original
                    int centerX = (screenWidth - originalForm.Width) / 2;
                    int centerY = (screenHeight - originalForm.Height) / 2;

                    // Reposicionar el formulario original en el centro de la pantalla
                    originalForm.Location = new Point(centerX, centerY);
                };

                // Mostrar el nuevo formulario
                cargo.ShowDialog();
            }
        
        }

        //________________________________________________________________________________________
        //---para que permita desbloquear check cargo tambien con texto

        // Este método maneja la lógica común para desmarcar el CheckBox
        private void DesmarcarCheckBoxConTexto()
        {
            if (checkBox_Cargo.Checked)
            {
                checkBox_Cargo.Checked = false;
            }
        }

     

        private void comboBox_Dependencia_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
            DesmarcarCheckBoxConTexto();
        }

        private void comboBox_Secretario_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
            DesmarcarCheckBoxConTexto();
        }

        private void comboBox_Instructor_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
            DesmarcarCheckBoxConTexto();
        }

       
        private void comboBox_DeptoJudicial_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                // Guarda la posición actual del cursor para evitar perderla
                int cursorPosition = comboBox.SelectionStart;

                // Convierte el texto a camelCase
                string textoConvertido = ConvertirACamelCase.Convertir(comboBox.Text);

                // Actualiza el texto del ComboBox
                comboBox.Text = textoConvertido;

                // Mueve el cursor al final del texto
                comboBox.SelectionStart = comboBox.Text.Length;
                comboBox.SelectionLength = 0; // Opcional, para asegurarse de que no haya selección activa
            }
            ActualizarEstado();
        }

      
    }
}