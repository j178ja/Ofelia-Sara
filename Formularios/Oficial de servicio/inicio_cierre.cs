using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Ofelia_Sara.general.clases;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara
{
    public partial class InicioCierre : BaseForm
    {
        private int totalCampos;////declaracion de variables que se emplean para progressVerticalBar
        private int camposCompletos;

        public InicioCierre()
        {
            InitializeComponent();
            ValidacionControles();

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

            // Inicializar el DateTimePicker y asignar el evento
            //pickTime_DatoFecha.ValueChanged += new EventHandler(dateTimePicker_ValueChanged);
        }

        //-----------------------------------------------------------------
        private void ValidacionControles()
        { // Llama a TextoEnMayuscula.ConvertirTextoAMayusculas y pasa los ComboBox necesarios
            TextoEnMayuscula.ConvertirTextoAMayusculas(this, textBox_NumeroIpp, comboBox_Ipp1, comboBox_Ipp2, comboBox_Ipp4, comboBox_Ufid);
        }

        //-------------------------------------------------------------------

        private void InicioCierre_Load(object sender, EventArgs e)
        {
            InicializarComboBox(); //para que se inicialicen los indices predeterminados de comboBox
            ActualizarEstadoBotonImprimir();
            ActualizarProgressBars();
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
        //---------------evento para boton GUARDAR
        private void btn_Guardar_MouseHover(object sender, EventArgs e)
        {
            btn_Guardar.BackColor = Color.DodgerBlue;
        }

        //------------------------------------------------------------------

        //-----FORMATO ESPECIAL DateTimePicker------------
        // !!!! HACER METODO APARTE!!!--------------------
        //---Este metodo no se aplica..crear modificacion para que se aplique mediante label--
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        //-------------------------------------------------------

        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //-------------------------------------------------------------------------------
        //--------------------------------------------------------------
        //---------------evento para boton ELIMINAR

        private void btn_Limpiar_MouseHover(object sender, EventArgs e)
        {
            btn_Limpiar.BackColor = Color.DodgerBlue;
        }
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



        // Método para actualizar el estado del botón Imprimir
        private void ActualizarEstadoBotonImprimir()
        {
            btn_Imprimir.Enabled = ValidadorCamposImpresion.VerificarCamposCompletos(Controls);

            if (btn_Imprimir.Enabled)
            {
                // Si todos los campos están completos, habilitar el botón y poner el fondo en verde
                btn_Imprimir.Enabled = true;
                //btn_Imprimir.BackColor = Color.Green; /*COLOR NORMAL*/
                btn_Imprimir.BackColor = Color.FromArgb(0, 204, 0);//FromArgb permite uso RGB (este seria color verder)
            }
            else
            {
                // Si no todos los campos están completos, deshabilitar el botón y poner el fondo en rojo
                btn_Imprimir.Enabled = false;
                btn_Imprimir.BackColor = Color.FromArgb(211, 47, 47); //Color rojo
            }
        }

        // Método para mostrar progreso en el progressBar
        private void MostrarProgreso()
        {
            using (MensajeCargarImprimir progressMessageBox = new MensajeCargarImprimir())
            {
                progressMessageBox.ShowDialog();
            }
        }

        // Evento Click del botón Imprimir
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            MostrarProgreso();
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
        }         //---------------------------------------------------------------------------------


        // Evento TextChanged o SelectedIndexChanged de los controles relevantes
        private void Control_TextChanged(object sender, EventArgs e)
        {
            // Al cambiar el texto o la selección en un control relevante, actualizar el estado del botón Imprimir
            ActualizarEstadoBotonImprimir();
        }

        //----------------------------------------------------------------------

        //-----------AGREGAR CAUSA-----------------
        private void btn_AgregarCausa_Click(object sender, EventArgs e)
        {
            // Crear TextBox
            System.Windows.Forms.TextBox nuevoTextBox_Causa = new System.Windows.Forms.TextBox();
            nuevoTextBox_Causa.Size = new Size(279, 24);  // Tamaño
            nuevoTextBox_Causa.Location = new Point(135, 105);  // Posición

            // Cambiar el color de fondo a rojo
            nuevoTextBox_Causa.BackColor = Color.Red;

            // Agregar al formulario
            this.Controls.Add(nuevoTextBox_Causa);
        }

        //-----------BOTON BUSCAR---------------------------
        //----eventos boton buscar 
        private void btn_Buscar_MouseHover(object sender, EventArgs e)
        {
            btn_Buscar.BackColor = Color.DodgerBlue;
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}





