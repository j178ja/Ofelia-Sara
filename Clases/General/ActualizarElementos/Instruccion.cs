using Ofelia_Sara.Controles.General;
using Ofelia_Sara.Controles.Ofl_Sara;
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Formularios.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Clases.General.Texto;
using BaseDatos.Entidades;

/*trabaja conjuntamente con clase reposicionar paneles*/

namespace Ofelia_Sara.Clases.General.ActualizarElementos
{
    public class Instruccion(BaseForm baseForm)
    {
        #region VARIABLES
        private Dictionary<string, (string, string, string, List<string>?, string?)> ConfiguracionesBotones;
        private Dictionary<Button, (Panel, string, string, List<string>?, string?)> BotonesConfigurados = [];
        private BaseForm _baseForm = baseForm;
      
        public object Controls { get; private set; }

        #endregion

        /// <summary>
        /// Inicializa valores por defecto en los ComboBox IPP.
        /// </summary>
        public static void InicializarComboBoxIpp(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CustomComboBox comboBox)
                {
                    switch (comboBox.Name)
                    {
                        case "comboBox_Ipp1":
                        case "comboBox_Ipp2":
                            ConfigurarItemsComboBox(comboBox);
                            comboBox.SelectedIndex = 3; // Establecer la posición predeterminada
                      
                            // Asegurarse de que el InnerTextBox refleje el valor seleccionado
                            if (comboBox.InnerTextBox != null)
                            {
                                comboBox.InnerTextBox.Text = comboBox.SelectedItem?.ToString() ?? string.Empty;
                            }
                            break;
                        case "comboBox_Ipp4":
                        case "comboBox_Año":
                            CargarAño(comboBox);
                            break;
                        
                    }
                }

                // Si el control tiene hijos, llamar recursivamente al método
                if (control.HasChildren)
                {
                    InicializarComboBoxIpp(control);
                }
            }
        }


        /// <summary>
        /// Configura eventos para los controles IPP.
        /// </summary>
        public void ConfigurarEventosIpp()
        {
            ConfigurarEventosEnControles(_baseForm.Controls);
         }



        /// <summary>
        /// Registra botones para agregar nuevos controles.
        /// </summary>
        public void RegistrarBotonesAgregar(List<string> victimas, List<string> imputados)
        {
            ConfiguracionesBotones = new()
    {
        { "btn_AgregarCausa", ("panel_Caratula", "CARATULA", "Causa", null, null) },
        { "btn_AgregarVictima", ("panel_Victima", "VICTIMA", "Victima", victimas,
            "Todos los campos en los controles existentes deben completarse antes de agregar una nueva víctima.") },
        { "btn_AgregarImputado", ("panel_Victima", "IMPUTADO", "Imputado", imputados,
            "Todos los campos en los controles existentes deben completarse antes de agregar un nuevo imputado.") }
    };

            foreach (var (nombreBoton, config) in ConfiguracionesBotones)
            {
                if (_baseForm.Controls.Find(nombreBoton, true).FirstOrDefault() is Button boton &&
                    _baseForm.Controls.Find(config.Item1, true).FirstOrDefault() is Panel panel)
                {
                    BotonesConfigurados[boton] = (panel, config.Item2, config.Item3, config.Item4, config.Item5);
                    boton.Click -= Btn_Agregar_Click;
                    boton.Click += Btn_Agregar_Click;
                }
            }
        }


        /// <summary>
        /// Abre un formulario secundario y lo posiciona junto al formulario principal.
        /// </summary>
        public void AbrirFormularioSecundario<T>(ref T formularioSecundario, CustomTextBox textBoxOrigen, string propiedadTexto) where T : Form, new()
        {
            if (formularioSecundario == null || formularioSecundario.IsDisposed)
            {
                formularioSecundario = new T();

                if (formularioSecundario is IFormularioConTexto formularioConTexto)
                {
                    formularioConTexto.TextoCambiado += (s, e) =>
                    {
                        textBoxOrigen.TextValue = formularioConTexto.TextoNombre;
                    };
                }
            }

            T formulario = formularioSecundario;
            var propiedad = formulario.GetType().GetProperty(propiedadTexto);
            propiedad?.SetValue(formulario, textBoxOrigen.TextValue);

            textBoxOrigen.TextChanged += (s, ev) =>
            {
                propiedad?.SetValue(formulario, textBoxOrigen.TextValue);
            };

            Form originalForm = _baseForm;

            int totalWidth = originalForm.Width + formulario.Width;
            int height = Math.Max(originalForm.Height, formulario.Height);

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int startX = (screenWidth - totalWidth) / 2;
            int startY = (screenHeight - height) / 2;

            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point(startX, startY);
            originalForm.Location = new Point(startX + formulario.Width, startY);

            formulario.FormClosed += (s, args) =>
            {
                int centerX = (screenWidth - originalForm.Width) / 2;
                int centerY = (screenHeight - originalForm.Height) / 2;
                originalForm.Location = new Point(centerX, centerY);
            };

            formulario.Show();
        }


        // ESTE TRAIA PROBLEMAS
        public void ConfigurarEventosEnControles(System.Windows.Forms.Control.ControlCollection controles)
        {
            //foreach (Control control in controles)
            //{
            //    if (control is CustomComboBox comboBox)
            //    {
            //        comboBox.InnerTextBox.Leave += ComboBox_Ipp_Leave;
            //        comboBox.InnerTextBox.KeyPress += ComboBox_Ipp_KeyPress;
            //    }
            //    else if (control is CustomTextBox textBox)
            //    {
            //        textBox.InnerTextBox.Leave += TextBox_NumeroIpp_Leave;
            //        textBox.InnerTextBox.KeyPress += TextBox_NumeroIpp_KeyPress;
            //    }

            //    if (control.HasChildren)
            //    {
            //        ConfigurarEventosEnControles(control.Controls);
            //    }
            //}
        }



        /// <summary>
        /// botones agregar nueva caratula, victima, imputado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (sender is Button boton && BotonesConfigurados.TryGetValue(boton, out var config))
            {
                AgregarNuevoControl(config.Item1, config.Item2, config.Item3, config.Item4, config.Item5);
            }
        }

        /// <summary>
        /// agrega el nuevo control en panel de destino segun se haya  invocado y muestra mensaje de advertencia en caso de que ese panel contenga
        /// controles vacios
        /// </summary>
        /// <param name="panelDestino"></param>
        /// <param name="tipoControl"></param>
        /// <param name="etiqueta"></param>
        /// <param name="lista"></param>
        /// <param name="mensajeValidacion"></param>
        private void AgregarNuevoControl(Panel panelDestino, string tipoControl, string etiqueta, List<string> lista = null, string mensajeValidacion = null)
        {
            if (!string.IsNullOrEmpty(mensajeValidacion) && !ValidarControlesExistentes(panelDestino))
            {
                MensajeGeneral.Mostrar(mensajeValidacion, MensajeGeneral.TipoMensaje.Advertencia);
                return;
            }

            var nuevoControl = NuevaPersonaControl.NuevaPersonaControlHelper.AgregarNuevoControl(panelDestino, tipoControl, etiqueta);

            if (lista != null && nuevoControl != null)
            {
                lista.Add("Nombre de la nueva " + etiqueta);
            }

            if (nuevoControl != null)
            {
                AsignarEventosCustomTextBox(nuevoControl);
            }
        }

        /// <summary>
        /// valida para que los paneles para que contengan texto y no haya campos vacios
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        private bool ValidarControlesExistentes(Panel panel)
        {
            string tipoPersona = panel.Name.Contains("Victima", StringComparison.OrdinalIgnoreCase) ? "VICTIMA" :
                                 panel.Name.Contains("Imputado", StringComparison.OrdinalIgnoreCase) ? "IMPUTADO" : "PERSONA";

            foreach (Control control in panel.Controls)
            {
                if (control is NuevaPersonaControl personaControl)
                {
                    string texto = personaControl.TextBox_Persona.Text.Trim();

                    if (texto.Length < 3)
                    {
                        MensajeGeneral.Mostrar($"Complete todos los campos con al menos 3 caracteres para agregar una nueva {tipoPersona}",
                                               MensajeGeneral.TipoMensaje.Advertencia);
                        return false;
                    }
                }
            }
            return true;
        }

        public void AsignarEventosCustomTextBox(Control nuevoControl)
        {
            if (nuevoControl is CustomTextBox customTextBox)
            {
                customTextBox.TextChanged += (s, e) => { };
            }
        }


        #region EVENTOS

        /// <summary>
        /// completa con ceros a la izquierda para los comboBox IPP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static  void ComboBox_Ipp_Leave(object sender, EventArgs e)
        {
            if (sender is CustomComboBox customComboBox && int.TryParse(customComboBox.TextValue, out _))
            {
                customComboBox.TextValue = customComboBox.TextValue.PadLeft(2, '0');
                customComboBox.SelectionStart = customComboBox.TextValue.Length;
            }
        }

        /// <summary>
        /// Completa con 0 el numero de ipp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_NumeroIpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                CompletarConCeros(sender as CustomTextBox);
                e.Handled = true;
            }
        }

        /// <summary>
        /// completa con 0 al salir del textBox numero de ipp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_NumeroIpp_Leave(object sender, EventArgs e)
        {
            CompletarConCeros(sender as CustomTextBox);
        }

        /// <summary>
        /// completa con 0 el numero de ipp hasta 6 caracteres
        /// </summary>
        /// <param name="customTextBox"></param>
        private static void CompletarConCeros(CustomTextBox customTextBox)
        {
            if (customTextBox != null && int.TryParse(customTextBox.TextValue, out _))
            {
                customTextBox.TextValue = customTextBox.TextValue.PadLeft(6, '0');
                customTextBox.SelectionStart = customTextBox.TextValue.Length;
            }
        }

        /// <summary>
        /// permite solo numeros y autocompleta con 0 en caso de que se presione enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ComboBox_Ipp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter && sender is CustomTextBox innerTextBox && innerTextBox.Parent is CustomComboBox customComboBox)
            {
                if (int.TryParse(customComboBox.TextValue, out _))
                {
                    customComboBox.TextValue = customComboBox.TextValue.PadLeft(2, '0');
                    customComboBox.SelectionStart = customComboBox.TextValue.Length;
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region MÉTODOS ESTÁTICOS

        /// <summary>
        /// carga listado de años desde el actual hacia atras 5 años
        /// </summary>
        /// <param name="customComboBox"></param>
        public static void CargarAño(CustomComboBox customComboBox)
        {
            customComboBox.Items.Clear();
            int anioActual = DateTime.Now.Year;

            for (int i = 0; i <= 5; i++)
            {
                int ultimosDosDigitos = (anioActual - i) % 100;
                customComboBox.Items.Add(ultimosDosDigitos.ToString("D2"));
            }
            // Selecciona automáticamente el año actual (el primer elemento cargado)
            if (customComboBox.Items.Count > 0)
            {
                customComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// carga en item de comboBox IPP 10 item
        /// </summary>
        /// <param name="comboBox"></param>
        private static void ConfigurarItemsComboBox(CustomComboBox comboBox)
        {
            comboBox.DataSource = null;
            comboBox.Items.Clear();

            for (int i = 0; i <= 10; i++)
            {
                comboBox.Items.Add(i.ToString("D2"));
            }
        }
        #endregion
    

        /// </summary>
    public void InicializarComboBoxFiscalia(CustomComboBox comboFiscalia, CustomComboBox comboAgente, CustomComboBox comboLocalidad, CustomComboBox comboDepto)
        {
            // Obtener los datos únicos para los ComboBox
            comboFiscalia.DataSource = FiscaliaManager.ObtenerNombresFiscalias().Distinct().ToList();
            comboAgente.DataSource = FiscaliaManager.ObtenerAgentesFiscales().Distinct().ToList();
            comboLocalidad.DataSource = FiscaliaManager.ObtenerLocalidades().Distinct().ToList();
            comboDepto.DataSource = FiscaliaManager.ObtenerDeptosJudiciales().Distinct().ToList();

            // Inicializar selección en -1 para mostrar vacío
            comboFiscalia.SelectedIndex = -1;
            comboAgente.SelectedIndex = -1;
            comboLocalidad.SelectedIndex = -1;
            comboDepto.SelectedIndex = -1;
        }

        /// <summary>
        /// Maneja la selección de una fiscalía y actualiza los demás ComboBox con los datos correspondientes.
        /// </summary>
        public void ActualizarComboBoxFiscalia(string nombreFiscalia, CustomComboBox comboAgente, CustomComboBox comboLocalidad, CustomComboBox comboDepto)
        {
            // Desactivar los ComboBox mientras se actualizan
            comboAgente.Enabled = false;
            comboLocalidad.Enabled = false;
            comboDepto.Enabled = false;

            if (!string.IsNullOrEmpty(nombreFiscalia))
            {
                Fiscaliajson fiscalia = FiscaliaManager.ObtenerFiscaliaPorNombre(nombreFiscalia);

                if (fiscalia != null)
                {
                    comboAgente.DataSource = new List<string> { fiscalia.AgenteFiscal };
                    comboLocalidad.DataSource = new List<string> { fiscalia.Localidad };
                    comboDepto.DataSource = new List<string> { fiscalia.DeptoJudicial };
                }
                else
                {
                    comboAgente.DataSource = null;
                    comboLocalidad.DataSource = null;
                    comboDepto.DataSource = null;
                }

                // Reactivar los ComboBox después de la actualización
                comboAgente.Enabled = true;
                comboLocalidad.Enabled = true;
                comboDepto.Enabled = true;
            }
            else
            {
                // Si no hay selección, limpiar y desactivar los ComboBox
                comboAgente.DataSource = null;
                comboLocalidad.DataSource = null;
                comboDepto.DataSource = null;

                comboAgente.Enabled = false;
                comboLocalidad.Enabled = false;
                comboDepto.Enabled = false;
            }
        }
    

    #region INTERFAZ
    public interface IFormularioConTexto
    {
        event EventHandler TextoCambiado;
        string TextoNombre { get; set; }
    }
}
}
#endregion