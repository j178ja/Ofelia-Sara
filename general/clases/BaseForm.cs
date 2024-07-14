using System;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.general.clases;
using Ofelia_Sara.general.clases.Validaciones;
namespace Ofelia_Sara.general.clases

{
    public class BaseForm : Form
    {
        private Label footerLabel;
        private SaltoDeImput _saltoDeImput; // Declaración a nivel de clase
        private Panel mainPanel; // Panel que contiene los TextBox
        private ErrorProvider errorProvider;
        protected ProgressVerticalBar progressVerticalBar1;
       // protected ProgressVerticalBar progressVerticalBar2;

        public BaseForm()
        {
                      //---buscar alternativa para que obtenga el archivo desde almacenamiento interno----
            IconoEscudo.SetFormIcon(this, "C:/Users/Usuario/OneDrive/Escritorio/Ofelia-Sara/general/imagenes/IconoEscudoPolicia.ico");
     
            InitializeFooterLabel();
                          //------------------CAMBIAR FONDO----------------------------------------------------
                         // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
                                                             //---ESTE COLOR PERTENECE AL ACTUAL DE MINISTERIO DE SEGURIDAD-----
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);//llama a la clase que modifica el color de fondo
                                                                         //-----------SALTOS DE INPUT---------------------------
                                                                         // Configurar la navegación entre controles
            _saltoDeImput = new SaltoDeImput(this);// llama a la clase salto_de_Input
                                                   //-------------------------------------------------------------------------
                                                   // Inicializa el panel principal
            mainPanel = new Panel { Dock = DockStyle.Fill };
            this.Controls.Add(mainPanel);

            errorProvider = new ErrorProvider();

            AplicarConversionMayusculas(mainPanel);
                               

        }


        //----CLASE PRIVADA PARA QUE SE APLIQUE MAYUSCULA--------
        private void AplicarConversionMayusculas(Control control)
        {
            // Invocar el método de TextoEnMayuscula para convertir texto a mayúsculas
            TextoEnMayuscula.ConvertirTextoAMayusculas(control, null); // Pasar null si no se necesita filtrar ningún TextBox específico
        }

        //-----------------------------------------------------------------------------------------
        

        //--------BOTON LIMPIAR FORMULARIO --------------------
        private void Btn_Limpiar_Click(object sender, EventArgs e)
            {
                LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
            }
                            //--------BOTON GUARDAR-IMPRIMIR --------------------
                                //para que valide en todos los formularios
                                //que se encuentran con todos los campos completos
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            bool allValid = ValidacionError.ValidacionFaltanteCampos(this, errorProvider);
            if (allValid)
            {
                // Lógica adicional para guardar e imprimir si es necesario
            }
        }
       
        
        
        //-----METODO PARA MOSTRAR FOOTER-----------------------
        private void InitializeFooterLabel()
            {
                        // Llama al método estático de FooterHelper para obtener el footerLabel configurado
                this.footerLabel = FooterHelper.CreateFooterLabel(this);
                this.Controls.Add(this.footerLabel);
            }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

    }
    }
