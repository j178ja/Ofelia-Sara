using Ofelia_Sara.BaseDatos.Json_generador_de_archivos;
using Ofelia_Sara.Clases.General.AmpliarReducir_Paneles;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Clases.General.Texto;
using Ofelia_Sara.Clases.GenerarDocumentos;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;




namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{


    public partial class Contravenciones : BaseForm
    {
        #region VARIABLES

        // Variables para rastrear el estado de los paneles
        private bool panelExpandido_Infraccion = true;
        private bool panelExpandido_Infractor = true;
        private bool panelExpandido_Instruccion = true;
      

        // Altura original y contraída de los paneles (es usado para cuando se reduce y se amplia el panel)
        private int alturaOriginalPanel_Infraccion;
        private int alturaOriginalPanel_Infractor;
        private int alturaOriginalPanel_Instruccion;
     
        private int alturaContraidaPanel = 30; //establece altura minima del panel contraido

        private bool datosGuardados = false; // Variable que indica si los datos fueron guardados

        #endregion

        #region CONSTRUCTOR
        public Contravenciones()
        {
            InitializeComponent();
            btn_BuscarArt.Visible = false;//ocultar al cargar formulario
            TooltipEnControlDesactivado.ConfigurarToolTip(this, btn_AgregarArtContravencion, "Ingrese un Articulo para poder agregar uno adicional", "INGRESAR NUEVO ARTICULO");
            ToolTipGeneral.Mostrar(btn_BuscarArt, "BUSCAR detalle del Articulo");
        }
        #endregion

        #region LOAD
        private void Contravenciones_Load(object sender, EventArgs e)
        {
            this.FormClosing += BuscarPersonal_FormClosing;
            //Fecha_Instruccion.SelectedDate = DateTime.Now;

            TextBox_ArtInfraccion_TextChanged(textBox_ArtInfraccion, EventArgs.Empty);//permite validacion desde que se carga el formulario

            CalcularEdad.Inicializar(Fecha_Nacimiento, textBox_Edad);//para automatizar edad

            SetupBotonDeslizable();  // Configurar el delegado de validación

            ToolTipGeneral.Mostrar(btn_AmpliarReducir_INFRACCION, "Ampliar/Reducir DATOS INFRACCION.");
            ToolTipGeneral.Mostrar(btn_AmpliarReducir_INFRACTOR, "Ampliar/Reducir DATOS INFRACTOR.");
            ToolTipGeneral.Mostrar(btn_AmpliarReducir_INSTRUCCION, "Ampliar/Reducir DATOS INSTRUCCION.");

            //traer label al frent

            label_DatosInstruccion.BringToFront();
            label_DatosInfractor.BringToFront();
            label_DatosInfraccion.BringToFront();

            //// Guardar la altura original del panel
            alturaOriginalPanel_Infraccion = panel_DatosInfraccion.Height;
            alturaOriginalPanel_Infractor = panel_DatosInfractor.Height;
            alturaOriginalPanel_Instruccion = panel_DatosInstruccion.Height;

        }
        #endregion

        #region BOTON LIMPIAR
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario


        }
        #endregion

        #region BOTON GUARDAR
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_ArtInfraccion.TextValue) ||
                string.IsNullOrWhiteSpace(textBox_Nombre.TextValue) ||

                string.IsNullOrWhiteSpace(textBox_Dni.TextValue))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MensajeGeneral.Mostrar("Debe completar los campos Art, Nombre y DNI ", MensajeGeneral.TipoMensaje.Advertencia);
            }
            else
            {
                datosGuardados = true; // Marcar que los datos fueron guardados
                MensajeGeneral.Mostrar("Formulario guardado.", MensajeGeneral.TipoMensaje.Exito);
            }
        }
        #endregion

        #region FORMCLOSING

        // Evento FormClosing para verificar si los datos están guardados antes de cerrar
        private void BuscarPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosGuardados) // Si los datos no han sido guardados
            {

                MostrarMensajeCierre(e, "No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?");
            }
        }
        #endregion


        #region OBTENER DATOS DEL FORMULARIO
        public Dictionary<string, string> ObtenerDatosFormulario()
        {
            var datosFormulario = new Dictionary<string, string>();

            // Verificar si los datos del formulario son válidos
            if (datosFormulario == null)
            {
                // Detener la generación de documentos si hay algún error
                return null;
            }

            // Crear una instancia de CustomDateTextBox para llamar a ObtenerFecha()
            CustomDate customDateTextBox = new CustomDate();
            var fechaNacimiento = customDateTextBox.ObtenerFecha(); // Llamada al método de instancia

            // Añadimos los valores de los controles al diccionario
            datosFormulario.Add("Nombre", textBox_Nombre.TextValue);  // "Nombre" es el marcador en Word

            datosFormulario.Add("Dni", textBox_Dni.TextValue);
            datosFormulario.Add("Edad", textBox_Edad.TextValue);
            datosFormulario.Add("Domicilio", textBox_Domicilio.TextValue);
            datosFormulario.Add("Localidad", textBox_Localidad.TextValue);
            datosFormulario.Add("Nacionalidad", comboBox_Nacionalidad.SelectedItem.ToString());
            datosFormulario.Add("Instructor", comboBox_Instructor.SelectedItem.ToString());
            datosFormulario.Add("Secretario", comboBox_Secretario.SelectedItem.ToString());
            datosFormulario.Add("Dependencia", comboBox_Dependencia.SelectedItem.ToString());
            // datosFormulario.Add("Fecha_Instruccion", Fecha_Instruccion.SelectedDate.ToString("dd/MM/yyyy"));

            // Verificar que fechaNacimiento no sea nula antes de agregarla al diccionario
            if (fechaNacimiento.HasValue)
            {
                datosFormulario.Add("Fecha_Nacimiento", fechaNacimiento.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                MensajeGeneral.Mostrar("Por favor, ingrese una fecha de nacimiento válida.", MensajeGeneral.TipoMensaje.Advertencia);
                // Hacer que el control CustomDateTextBox reciba el foco
                customDateTextBox.Focus();

                return null;// Detener el proceso si la fecha de instrucción no es válida
            }

            return datosFormulario;
        }
        #endregion

        #region VALIDAR DATOS
        private bool ValidarDatosFormulario()
        {
            //Verificar si los campos están completados
            if (string.IsNullOrWhiteSpace(textBox_ArtInfraccion.TextValue) ||
                string.IsNullOrWhiteSpace(textBox_Nombre.TextValue) ||

                string.IsNullOrWhiteSpace(textBox_Dni.TextValue))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MensajeGeneral.Mostrar("Debe completar los campos Art, Nombre, Apellido y DNI ", MensajeGeneral.TipoMensaje.Advertencia);
                return false; // Indica que la validación falló
            }

            // Validar fecha de nacimiento
            if (!Fecha_Nacimiento.HasValue()) // Usando el método HasValue() de CustomDateTextBox
            {
                MensajeGeneral.Mostrar("Por favor, ingrese una fecha de nacimiento válida.", MensajeGeneral.TipoMensaje.Advertencia);
                Fecha_Nacimiento.Focus();
                return false; // Detener el proceso si la fecha no es válida
            }


            DateTime fechaNacimiento;
            // Convertir la fecha ingresada a un objeto DateTime
            if (!DateTime.TryParse(Fecha_Nacimiento.Text, out fechaNacimiento))
            {
                MensajeGeneral.Mostrar("La fecha de nacimiento no es válida. Por favor, intente nuevamente.", MensajeGeneral.TipoMensaje.Error);
                Fecha_Nacimiento.Focus();
                return false; // Detener el proceso si la fecha no se puede convertir
            }

            // Validar ComboBox Nacionalidad
            if (comboBox_Nacionalidad.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Nacionalidad.TextValue))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese una nacionalidad.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Nacionalidad.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Instructor
            if (comboBox_Instructor.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Instructor.TextValue))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese un instructor.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Instructor.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Secretario
            if (comboBox_Secretario.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Secretario.TextValue))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese un Secretario.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Secretario.Focus();
                return false; // Detener el proceso si no hay selección válida
            }

            // Validar ComboBox Dependencia
            if (comboBox_Dependencia.Items.Count == 0 ||
                string.IsNullOrWhiteSpace(comboBox_Dependencia.TextValue))
            {
                MensajeGeneral.Mostrar("Por favor, seleccione o ingrese una Dependencia.", MensajeGeneral.TipoMensaje.Advertencia);
                comboBox_Dependencia.Focus();
                return false; // Detener el proceso si no hay selección válida
            }
            return true; // Indica que la validación fue exitosa
        }
        #endregion

        #region BOTON IMPRIMIR
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {

            // Llamar al método de validación
            if (!ValidarDatosFormulario())
            {
                return; // Detener el proceso si la validación falla
            }

            // Usar FolderBrowserDialog para obtener la ruta donde el usuario quiere guardar los documentos
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Seleccione la carpeta donde desea guardar los documentos generados";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Ruta donde el usuario quiere guardar los documentos
                    string rutaCarpetaSalida = folderBrowserDialog.SelectedPath;

                    // Obtener el texto de textBox_Apellido y formar el nombre de la carpeta
                    //   string nombreCarpeta = $"Contrav. {textBox_Apellido.Text}";
                    string rutaSubcarpeta = Path.Combine(rutaCarpetaSalida/*, nombreCarpeta*/);

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(rutaSubcarpeta))
                    {
                        Directory.CreateDirectory(rutaSubcarpeta);
                    }

                    // rutas de las plantillas-->DEBEN REEMPLASARSE A RUTAS RELATIVAS
                    string rutaPlantillaRecepcion = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\DECRETO RECEPCION EXPEDIENTE.docx";
                    string rutaPlantillaCierre = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\DECRETO CIERRE EXPEDIENTE.docx";
                    string rutaPlantillaNotificacion = @"C:\Users\Usuario\OneDrive\Escritorio\Ofelia-Sara\Documentos\EXPEDIENTES\NOTIFICACION EXPEDIENTE.docx";

                    // Obtener los datos del formulario
                    var datosFormulario = ObtenerDatosFormulario();

                    // Generar cada documento con su respectiva plantilla y guardarlo en la carpeta
                    GeneradorDocumentos generador = new GeneradorDocumentos();
                    generador.GenerarYGuardarDocumento(rutaPlantillaRecepcion, rutaSubcarpeta, "DECRETO RECEPCION", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaCierre, rutaSubcarpeta, "DECRETO CIERRE", datosFormulario);
                    generador.GenerarYGuardarDocumento(rutaPlantillaNotificacion, rutaSubcarpeta, "NOTIFICACION", datosFormulario);

                    // Mostrar mensaje de éxito
                    // MessageBox.Show("Los documentos han sido generados correctamente.");

                    MensajeCargarImprimir mensajeCargarImprimir = new MensajeCargarImprimir();
                    mensajeCargarImprimir.ShowDialog();

                    // Abrir la ubicación de la carpeta generada
                    System.Diagnostics.Process.Start("explorer.exe", rutaSubcarpeta);
                }
            }
        }

        #endregion


  


        #region MENSAJE AYUDA

        private void Contravenciones_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MostrarMensajeAyuda("Complete la totalidad de campos requeridos para generar el documento.");
        }
        #endregion

        #region SOLICITAR PLANA
        private void SetupBotonDeslizable()
        {
            // Configurar el delegado de validación en el control BotonDeslizable
            botonDeslizable_StarPlana.ValidarCampos = () =>
            {
                // Lógica de validación
                bool camposIncompletos =
                    string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Dni.Text) ||
                        !Fecha_Nacimiento.HasValue();

                if (camposIncompletos)
                {
                    // Mostrar mensaje de advertencia si los campos están incompletos
                    MensajeGeneral.Mostrar("Debe completar los campos NOMBRE, DNI y FECHA DE NACIMIENTO para poder solicitar plana del ciudadano", MensajeGeneral.TipoMensaje.Advertencia);
                    return false; // Retorna false si los campos están incompletos
                }
                else
                {
                    // Mostrar mensaje de éxito si los campos están completos
                    MensajeGeneral.Mostrar("Datos Guardados para solicitar plana del ciudadano. Cuando imprima formulario  se enviara automaticamente la solicitud de plana"
                        , MensajeGeneral.TipoMensaje.Exito);
                    return true; // Retorna true si los campos están completos
                }
            };
        }

        #endregion

        #region ART INFRACCION

        /// <summary>
        /// VALIDACION DE BTN AGREGAR ART 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_ArtInfraccion_TextChanged(object sender, EventArgs e)
        {
            bool habilitar = !string.IsNullOrWhiteSpace(textBox_ArtInfraccion.TextValue);
            btn_AgregarArtContravencion.Enabled = habilitar;

            if (habilitar)
            {
                btn_AgregarArtContravencion.BackColor = Color.LightGreen;
                btn_AgregarArtContravencion.ForeColor = Color.White;
                btn_BuscarArt.Visible = true;
            }
            else
            {
                btn_AgregarArtContravencion.BackColor = Color.Tomato;
                btn_AgregarArtContravencion.ForeColor = Color.Black;
                btn_BuscarArt.Visible = false;
            }
        }

        /// <summary>
        /// AGREGA UN NUEVO CONTROL DE INFRACCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarArtContravencion_Click(object sender, EventArgs e)
        {
            if (!btn_AgregarArtContravencion.Enabled)
                return;

            if (!ValidarArticuloParaAgregar(out string error))
            {
                MensajeGeneral.Mostrar(error, MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }
            // Contar cuántos controles Art_Infraccion hay en el panel
            int cantidadActual = panel_ArtInfraccion.Controls
                .OfType<Art_Infraccion>()
                .Count();

            if (cantidadActual >= 5)
            {
                MensajeGeneral.Mostrar("No se pueden agregar más de 5 artículos de infracción.",
                                MensajeGeneral.TipoMensaje.Informacion);
                return;
            }

            // Crear nuevo control
            Art_Infraccion nuevoControl = new Art_Infraccion();

            // Transferir texto desde el TextBox al Label del nuevo control
            nuevoControl.NumeroArticulo = textBox_ArtInfraccion.TextValue;


            nuevoControl.Eliminado += (s, args) =>
            {
                RecentrarControlesHorizontales();
            };

            panel_ArtInfraccion.Controls.Add(nuevoControl);
            RecentrarControlesHorizontales();
            textBox_ArtInfraccion.Clear();
        }

        /// <summary>
        /// VALIDA QUE EL ART NO SE HAYA AGREGADO PREVIAMENTE Y QUE PERTENESCA A UN ART REGISTRADO COMO INFRACCION
        /// </summary>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        private bool ValidarArticuloParaAgregar(out string mensajeError)
        {
            mensajeError = "";

            string texto = textBox_ArtInfraccion.TextValue.Trim();

            // 1. Verificar si el TextBox está vacío
            if (string.IsNullOrWhiteSpace(texto))
            {
                mensajeError = "Debe ingresar un número de artículo.";
                return false;
            }

            // 2. Verificar si el contenido es un número
            if (!int.TryParse(texto, out int numero))
            {
                mensajeError = "El número de artículo ingresado no es válido.";
                return false;
            }

            // 3. Verificar si ya existe un control con ese artículo en el panel
            bool yaExiste = panel_ArtInfraccion.Controls
                .OfType<Art_Infraccion>()
                .Any(ctrl => int.TryParse(ctrl.NumeroArticulo, out int n) && n == numero);

            if (yaExiste)
            {
                mensajeError = $"El artículo {numero} ya fue agregado.";
                textBox_ArtInfraccion.Clear();
                textBox_ArtInfraccion.Focus();
                return false;

            }

            // 4. Verificar si el artículo existe en el JSON
            string ruta = Path.Combine(Application.StartupPath, "BaseDatos", "Json", "contravencion.json");
            if (!File.Exists(ruta))
            {
                mensajeError = "No se encontró el archivo de artículos.";
                textBox_ArtInfraccion.Clear();
                textBox_ArtInfraccion.Focus();
                return false;
            }

            string json = File.ReadAllText(ruta);
            List<Capitulos> capitulos = JsonSerializer.Deserialize<List<Capitulos>>(json);

            bool existeEnJson = capitulos
                .SelectMany(c => c.Articulos)
                .Any(art => art.Articulo == numero);

            if (!existeEnJson)
            {
                mensajeError = $"El artículo {numero} no corresponde a una falta contravencional.";
                textBox_ArtInfraccion.Clear();
                textBox_ArtInfraccion.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// CENTRA TODOS LOS ART DENTRO DEL PANEL ya sea se agregan o se eliminan
        /// </summary>
        private void RecentrarControlesHorizontales()
        {
            int margen = 6;

            // Obtener los controles relevantes
            var controles = panel_ArtInfraccion.Controls
                .OfType<Art_Infraccion>()
                .ToList();

            if (controles.Count == 0) return;

            // Calcular ancho total requerido (sumatoria de los controles + márgenes)
            int totalWidth = controles.Sum(c => c.Width) + margen * (controles.Count - 1);

            // Posición inicial X (centrado)
            int startX = (panel_ArtInfraccion.Width - totalWidth) / 2;
            int y = (panel_ArtInfraccion.Height - controles[0].Height) / 2; // centrado vertical opcional

            foreach (var ctrl in controles)
            {
                ctrl.Location = new Point(startX, y);
                startX += ctrl.Width + margen;
            }
        }

        private void panel_ArtInfraccion_Resize(object sender, EventArgs e)
        {
            RecentrarControlesHorizontales();
        }

        /// <summary>
        /// METODO PARA BUSCAR EL ART Y MOSTRARLO EN MENSAJE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_BuscarArt_Click(object sender, EventArgs e)
        {
            // Obtener número desde el CustomTextBox
            int numeroBuscado = int.Parse(textBox_ArtInfraccion.TextValue.Trim());

            // Ruta del archivo JSON
            string ruta = Path.Combine(Application.StartupPath, "BaseDatos", "Json", "contravencion.json");

            // Leer y deserializar JSON
            string json = File.ReadAllText(ruta);
            List<Capitulos> capitulos = JsonSerializer.Deserialize<List<Capitulos>>(json);

            // Buscar el artículo
            var resultado = capitulos
                .SelectMany(c => c.Articulos, (cap, art) => new { cap.Capitulo, art.Articulo, art.Contenido })
                .FirstOrDefault(x => x.Articulo == numeroBuscado);

            // Mostrar resultado
            if (resultado != null)
            {
                string mensaje = $"Capítulo: {resultado.Capitulo}\nArtículo: {resultado.Articulo}\n\n{resultado.Contenido}";
                MensajeGeneral.Mostrar(mensaje, MensajeGeneral.TipoMensaje.Informacion);
            }
            else
            {
                MensajeGeneral.Mostrar("No se encontró ningún artículo con ese número.", MensajeGeneral.TipoMensaje.Advertencia);
            }
        }

        #endregion

        #region BOTONES AMPLIAR REDUCIR
        private void Btn_AmpliarReducir_INFRACCION_Click(object sender, EventArgs e)
        {
            AmpliarReducirPanel.AlternarPanel(
             panelConNeon: panel_DatosInfraccion,
             panelDetalle: panel_Detalle_Infraccion,
             panelExpandido: ref panelExpandido_Infraccion,
             btnAmpliarReducir: btn_AmpliarReducir_INFRACCION,
             imgExpandir: Properties.Resources.dobleFlechaABAJO,
             imgContraer: Properties.Resources.dobleFlechaARRIBA,
             alturaOriginal: alturaOriginalPanel_Infraccion,
             alturaContraida: alturaContraidaPanel,
             ajustarFormulario: AjustarTamanoFormulario
             );
            //  InicializarValidaciones();//revisa los paneles y cambia su estado de acuerdo si esta completo o no 
        }

       

        private void Btn_AmpliarReducir_INFRACTOR_Click(object sender, EventArgs e)
        {
            AmpliarReducirPanel.AlternarPanel(
            panelConNeon: panel_DatosInfractor,
            panelDetalle: panel_Detalle_Infractor,
            panelExpandido: ref panelExpandido_Infractor,
            btnAmpliarReducir: btn_AmpliarReducir_INFRACTOR,
            imgExpandir: Properties.Resources.dobleFlechaABAJO,
            imgContraer: Properties.Resources.dobleFlechaARRIBA,
            alturaOriginal: alturaOriginalPanel_Infractor,
            alturaContraida: alturaContraidaPanel,
            ajustarFormulario: AjustarTamanoFormulario
            );
        }

        private void Btn_AmpliarReducir_INSTRUCCION_Click(object sender, EventArgs e)
        {
            AmpliarReducirPanel.AlternarPanel(
            panelConNeon: panel_DatosInstruccion,
            panelDetalle: panel_Detalle_Instruccion,
            panelExpandido: ref panelExpandido_Instruccion,
            btnAmpliarReducir: btn_AmpliarReducir_INSTRUCCION,
            imgExpandir: Properties.Resources.dobleFlechaABAJO,
            imgContraer: Properties.Resources.dobleFlechaARRIBA,
            alturaOriginal: alturaOriginalPanel_Instruccion,
            alturaContraida: alturaContraidaPanel,
            ajustarFormulario: AjustarTamanoFormulario
            );
        }
        
        /// <summary>
        /// METODO PARA AJUSTAR TAMAÑO DE FORMULARIO Y REPOSICIONAR PANELES
        /// </summary>
        private void AjustarTamanoFormulario()
        {
            //int posicionVertical = 65; // Comienza desde la parte superior de panel1

            //// Ajustar posición de panel DATOS PERSONALES
            //if (panel_DatosPersonales.Visible)
            //{
            //    panel_DatosPersonales.Location = new System.Drawing.Point(panel_DatosPersonales.Location.X, posicionVertical);
            //    posicionVertical += panel_DatosPersonales.Height;
            //    // Agregar separación de 10 píxeles entre panel_Instruccion y panel_SeleccionVisu
            //    posicionVertical += 5;
            //}

            //// Ajustar posición de panel REVISTA
            //if (panel_Revista.Visible)
            //{
            //    panel_Revista.Location = new System.Drawing.Point(panel_Revista.Location.X, posicionVertical);
            //    posicionVertical += panel_Revista.Height;
            //    posicionVertical += 5;
            //}

            //// Ajustar posición de panel ARMAMENTO
            //if (panel_Armamento.Visible)
            //{
            //    panel_Armamento.Location = new System.Drawing.Point(panel_Armamento.Location.X, posicionVertical);
            //    posicionVertical += panel_Armamento.Height;
            //    posicionVertical += 5;
            //}

            //// Ajustar posición de panel DESTINO
            //if (panel_Destino.Visible)
            //{
            //    panel_Destino.Location = new System.Drawing.Point(panel_Destino.Location.X, posicionVertical);
            //    posicionVertical += panel_Destino.Height;

            //}

            //// Ajustar posición de panel_ControlesInferiores
            //panel_ControlesInferiores.Location = new System.Drawing.Point(panel_ControlesInferiores.Location.X, posicionVertical);
            //posicionVertical += panel_ControlesInferiores.Height;

            //// Ajustar la altura de panel1 para que se ajuste al contenido visible
            //panel1.Height = posicionVertical;

            //// Ajustar la altura del formulario sumando un margen adicional de 20 px
            //this.Height = panel1.Location.Y + panel1.Height + 75;


            //// Activar scroll si la altura del formulario supera los 800 píxeles
            //if (this.Height > 800)
            //{
            //    this.AutoScroll = true;
            //}
            //else
            //{
            //    this.AutoScroll = false;
            //}
        }
#endregion
    }
}
