using Ofelia_Sara.general.clases.Apariencia_General;
using System;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;

namespace Ofelia_Sara.general.clases


{
    using Ofelia_Sara.general.clases.Apariencia_General;
    using System.Windows.Forms;
    public class BaseForm : Form
    {
        private LinkLabel footerLinkLabel;
        private Panel mainPanel; // Panel que contiene los TextBox
      
        protected TimePickerPersonalizado timePickerPersonalizadoFecha;
        

        public BaseForm()
        {
            //---buscar alternativa para que obtenga el archivo desde almacenamiento interno----
            IconoEscudo.SetFormIcon(this, "C:/Users/Usuario/OneDrive/Escritorio/Ofelia-Sara/general/imagenes/IconoEscudoPolicia.ico");

            InitializeFooterLinkLabel();
            this.timePickerPersonalizadoFecha = new Ofelia_Sara.general.clases.Apariencia_General.TimePickerPersonalizado();
            //------------------CAMBIAR FONDO----------------------------------------------------
            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
                                                             //---ESTE COLOR PERTENECE AL ACTUAL DE MINISTERIO DE SEGURIDAD-----
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);//llama a la clase que modifica el color de fondo
            //-------------------------------------------------------------------------
            
            // Inicializa el panel principal
            mainPanel = new Panel { Dock = DockStyle.Fill };
            this.Controls.Add(mainPanel);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Load += BaseForm_Load;
        }



        //--------BOTON LIMPIAR FORMULARIO --------------------
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
        }


        //-----METODO PARA MOSTRAR FOOTER-----------------------
        private void InitializeFooterLinkLabel()
        {
            
            // Llama al método estático de FooterHelper para obtener el footerLabel configurado
            this.footerLinkLabel = FooterHelper.CreateFooterLinkLabel(this);
            this.Controls.Add(this.footerLinkLabel);
        }

        protected void InitializeComponent()
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
      

        //------METODO PARA VERIFICAR CAMPOS COMPLETOS Y CACTIVAR BOTON------------
        private void Control_TextChanged(object sender, EventArgs e)
        {
          
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
                boton.BackColor = Color.FromArgb(51, 174, 189);
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
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


        //--eventos para evitar conflictos-------------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

           
        }
    }
}

