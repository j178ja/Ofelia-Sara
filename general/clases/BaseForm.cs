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

        public BaseForm()
        {
            InitializeComponent();

            //---buscar alternativa para que obtenga el archivo desde almacenamiento interno----
            IconoEscudo.SetFormIcon(this, "C:/Users/Usuario/OneDrive/Escritorio/Ofelia-Sara/general/imagenes/IconoEscudoPolicia.ico");
            //  InitializeComponent(); COMENTADO PORQUE SE SACO EL CAMBIO DE COLOR EN LA BARRA DE TITULO
            InitializeFooterLabel();

            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color activeCaptionColor = SystemColors.ActiveCaption; // Color ActiveCaption
            AparienciaFormularios.CambiarColorDeFondo(this, activeCaptionColor);

            // Configurar la navegación entre controles
            _saltoDeImput = new SaltoDeImput(this);

            // Suscribir todos los TextBox al método ConvertirTextoAMayusculas
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    TextoEnMayuscula.ConvertirTextoAMayusculas(textBox);
                }
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