using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public class BaseForm : Form
    {
        private Label footerLabel;
        private SaltoDeImput _saltoDeImput; // Declaración a nivel de clase
        private Panel mainPanel; // Panel que contiene los TextBox

        public BaseForm()
        {
            InitializeComponent();

            //---buscar alternativa para que obtenga el archivo desde almacenamiento interno----
            IconoEscudo.SetFormIcon(this, "C:/Users/Usuario/OneDrive/Escritorio/Ofelia-Sara/general/imagenes/IconoEscudoPolicia.ico");
            //  InitializeComponent(); COMENTADO PORQUE SE SACO EL CAMBIO DE COLOR EN LA BARRA DE TITULO
            InitializeFooterLabel();

            //-----------------------------------------------------------------------
            //-------para usar fondo estandar (en modificacion por el momento-----
            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            //Color activeCaptionColor = SystemColors.ControlDark; // Color ActiveCaption
            //AparienciaFormularios.CambiarColorDeFondo(this, activeCaptionColor);
            //-----------------------------------------------------------------------

            //------------------CAMBIAR FONDO----------------------------------------------------
            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
                                                             //---ESTE COLOR PERTENECE AL ACTUAL DE MINISTERIO DE SEGURIDAD-----
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);
            //--------------------------------------------------------------------------

            // Configurar la navegación entre controles
            _saltoDeImput = new SaltoDeImput(this);

            //// Suscribir todos los TextBox al método ConvertirTextoAMayusculas
            //foreach (Control control in this.Controls)
            //{
            //    if (control is TextBox textBox)
            //    {
            //        TextoEnMayuscula.ConvertirTextoAMayusculas(textBox);
            //    }
            //}

            // Inicializa el panel principal
            mainPanel = new Panel { Dock = DockStyle.Fill };
            this.Controls.Add(mainPanel);

            // Verificación adicional para asegurar que mainPanel no sea nulo
            if (mainPanel != null)
            {
                // Suscribe todos los TextBox dentro del panel al método ConvertirTextoAMayusculas
                TextoEnMayuscula.ConvertirTextoAMayusculas(mainPanel);
            }
        }


        //---------------------------------------------------------------------------------------------
        //
        //-------SE ESTA APLICANDO PERO SOLO EN VISUAL STUDIO...NO AL MOMENTO DE COMPILAR!!-------

        //    // Cambiar el color de la barra del título
        //    //--- NO SE ESTA APLICANDO !!!------------
        //    Color titleBarColor = Color.Black; // Color deseado
        //    FormAppearanceHelper.SetTitleBarColor(this, titleBarColor);
        //}


        //    private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // BaseForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Name = "BaseForm";
        //    this.Load += new System.EventHandler(this.BaseForm_Load);
        //    this.ResumeLayout(false);
        //}

        //---------------------------------------------------------------------------------------------
        // Evento de clic para el botón que limpia el formulario
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
        }

        private void InitializeFooterLabel()
        {
            // Llama al método estático de FooterHelper para obtener el footerLabel configurado
            this.footerLabel = FooterHelper.CreateFooterLabel(this);
            this.Controls.Add(this.footerLabel);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            // Código adicional para el evento Load si es necesario
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load_1);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load_1(object sender, EventArgs e)
        {

              
        }
    }
}