
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Ofelia_Sara.general.clases

{
    using Ofelia_Sara.general.clases.Apariencia_General;
    using System.Windows.Forms;
    public class BaseForm : Form
    {
        private Label footerLabel;
        private SaltoDeImput _saltoDeImput; // Declaración a nivel de clase
        private Panel mainPanel; // Panel que contiene los TextBox
        protected Button btn_Imprimir;
        protected TimePickerPersonalizado timePickerPersonalizadoFecha;

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

            AplicarConversionMayusculas(mainPanel);

            this.Load += new System.EventHandler(this.BaseForm_Load);
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
       



        //-----METODO PARA MOSTRAR FOOTER-----------------------
        private void InitializeFooterLabel()
        {
            this.timePickerPersonalizadoFecha = new Ofelia_Sara.general.clases.Apariencia_General.TimePickerPersonalizado();
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
            // Suponiendo que 'timePickerPersonalizado1' es el nombre del control en el BaseForm
            timePickerPersonalizadoFecha.SelectedDate = DateTime.Now;
        }



        //------------------------------------------------------------
        //-----METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES-------
        //-------BUSCAR----GUARDAR----LIMPIAR---------
        protected void InicializarEstiloBoton(Button boton)
        {
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;

            // Evento MouseEnter: Cambia el tamaño desde el centro y el color de fondo
            boton.MouseEnter += (sender, e) =>
            {
                // Calcula el incremento para centrar el cambio de tamaño
                int incremento = 12;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

                //boton.BackColor = Color.DodgerBlue;
                //boton.BackColor = Color.FromArgb(0, 154, 174);
                boton.BackColor = Color.FromArgb(51, 174, 189);
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
                //boton.BackColor = Color.DodgerBlue;
                //boton.BackColor = Color.FromArgb(0, 154, 174); // COLOR "OFICIAL" USADO EN FONDO FORMULARIO
                boton.BackColor = Color.FromArgb(51, 174, 189); //20% MAS CLARO QUE EL COLOR OFICIAL Y DE FONDO
            };

            // Evento MouseLeave: Restaura el tamaño y la posición original, y el color de fondo original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.SkyBlue;
            };
        }

        //------------------------------------------------------------
        //-----METODO GENERAL PARA CAMBIAR TAMAÑO DE BOTONES-------
        //-------AGREGAR --->CARATULA-->IMPUTADO--->VICTIMA---------
        protected void InicializarEstiloBotonAgregar(Button boton)
        {
            Size originalSize = boton.Size;
            Point originalLocation = boton.Location;



            // Evento MouseEnter: Cambia el tamaño desde el centro y el color de fondo
            boton.MouseEnter += (sender, e) =>
            {
                // Calcula el incremento para centrar el cambio de tamaño
                int incremento = 7;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

                boton.ForeColor = Color.White; // Cambia el color del texto a blanco

            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {

                boton.BackColor = Color.FromArgb(0, 204, 0);
            };

            // Evento MouseLeave: Restaura el tamaño y la posición original, y el color de fondo original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.White;
                boton.ForeColor = SystemColors.ControlText;
            };
        }
               
    }

}


