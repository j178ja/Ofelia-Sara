
using System;
using System.Drawing;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using System.IO;
using BaseDatos_Libreria.Entidades;
using Controles_Libreria.Controles;
using Clases_Libreria.Apariencia;
using Clases_Libreria.Botones;
// Alias para el ShadowForm de tu propia clase




namespace Ofelia_Sara.Formularios

{ 

    using Newtonsoft.Json;
    // using Ofelia_Sara.Base_de_Datos;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Drawing.Drawing2D;
    using System.Text;
    using System.Windows.Forms;
    public class BaseForm : Form
    {
        //protected DatabaseManager dbManager;
        //protected DataInserter dataInserter;

        // Define una lista para almacenar los elementos de autocompletado
        private readonly AutocompletarManager autocompletarManager;

        private LinkLabel footerLinkLabel;
        private Panel mainPanel; // Panel que contiene los TextBox

        protected TimePickerPersonalizado timePickerPersonalizadoFecha;

        // Método OnLoad combinado
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public BaseForm()
        {
            //---buscar alternativa para que obtenga el archivo desde almacenamiento interno----
            IconoEscudo.SetFormIcon(this, "C:/Users/Usuario/OneDrive/Escritorio/Ofelia-Sara/Resources/imagenes/IconoEscudoPolicia.ico");

            InitializeFooterLinkLabel();
            this.timePickerPersonalizadoFecha = new Controles_Libreria.Controles.TimePickerPersonalizado();
            //------------------CAMBIAR FONDO----------------------------------------------------
            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
                                                             //---ESTE COLOR PERTENECE AL ACTUAL DE MINISTERIO DE SEGURIDAD-----
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);//llama a la clase que modifica el color de fondo
                                                                         //-------------------------------------------------------------------------

            // Inicializa el panel principal
            mainPanel = new Panel { Dock = DockStyle.Fill };
            this.Controls.Add(mainPanel);

            //this.Load += BaseForm_Load;

            this.Paint += new PaintEventHandler(BaseForm_Paint);
            this.Load += new System.EventHandler(this.BaseForm_Load);

            autocompletarManager = new AutocompletarManager(@"path\to\Cartatulas_Autocompletar.json");
            ConfigureTextBoxAutoComplete();
        }
        //--------------------------------------------------------------------------------

        private void DibujarFondoDegradado(Graphics g, int width, int height)
        {
            // Definir el centro del área de degradado
            PointF center = new PointF(width / 2f, height / 2f);

            // Ajustar el radio máximo del degradado para que se ajuste al tamaño del formulario
            float maxRadius = Math.Max(width, height) * 0.75f; // Ajusta el valor según sea necesario

            // Crear un rectángulo que envuelve el área del degradado
            RectangleF gradientRectangle = new RectangleF(center.X - maxRadius, center.Y - maxRadius, maxRadius * 2, maxRadius * 2);

            // Crear una ruta de gráfico para el degradado
            using (GraphicsPath path = new GraphicsPath())
            {
                // Crear un elipse que rodea el área del degradado
                path.AddEllipse(gradientRectangle);

                // Crear un PathGradientBrush con la ruta
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    // Configurar colores para el degradado
                    brush.CenterColor = Color.FromArgb(0, 100, 114); // Color más oscuro en el centro
                    brush.SurroundColors = new Color[] { Color.FromArgb(200, 255, 255) }; // Color más suave en los bordes

                    // Rellenar el área del formulario con el degradado
                    g.FillRectangle(brush, this.ClientRectangle);
                }
            }
        }



        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            // Obtener las dimensiones del formulario
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Llamar al método que dibuja el fondo degradado
            DibujarFondoDegradado(e.Graphics, width, height);
        }

        //-------------------------------------------------------------------------------
        //----para cargar lista en comboBox ESCALAFON Y JERARQUIA-------------------
        protected void ConfigurarComboBoxEscalafonJerarquia(ComboBox comboBox_Escalafon, ComboBox comboBox_Jerarquia)
        {    // Configurar el evento SelectedIndexChanged
            comboBox_Escalafon.SelectedIndexChanged += (sender, e) =>
            {
                if (comboBox_Escalafon.SelectedItem != null)
                {
                    string escalafon = comboBox_Escalafon.SelectedItem.ToString();
                    comboBox_Jerarquia.Enabled = true;
                    comboBox_Jerarquia.DataSource = JerarquiasManager.ObtenerJerarquias(escalafon);
                }
                else
                {
                    comboBox_Jerarquia.Enabled = false;
                    comboBox_Jerarquia.DataSource = null;
                }
            };

            // Configurar el ComboBox_Jerarquia inicialmente como desactivado
            comboBox_Jerarquia.Enabled = false;
            comboBox_Jerarquia.DataSource = null;

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

        //protected void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // BaseForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "BaseForm";
        //    this.Load += new System.EventHandler(this.BaseForm_Load);
        //    this.ResumeLayout(false);

        //}
        private void BaseForm_Load(object sender, EventArgs e)
        {
            // Suponiendo que 'timePickerPersonalizadoFecha' es el nombre del control en el BaseForm
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

            // Evento Paint: Dibuja un borde redondeado y aplica el color del texto solo si el botón está habilitado
            boton.Paint += (sender, e) =>
            {
                int bordeGrosor;
                int bordeRadio;
                Color bordeColor;
                Color textoColor;

                if (boton.Enabled)
                {
                    bordeGrosor = 3;
                    bordeRadio = 4;
                    bordeColor = Color.LightGreen;
                    textoColor = Color.Green; // Color del texto cuando el botón está habilitado
                }
                else
                {
                    bordeGrosor = 2;
                    bordeRadio = 8;
                    bordeColor = Color.Tomato;
                    textoColor = Color.Red;// Color del texto cuando el botón está deshabilitado //NO FUNCIONA!!
                }

                using (GraphicsPath path = new GraphicsPath())
                {
                    // Define el rectángulo con el radio especificado
                    path.AddArc(new Rectangle(0, 0, bordeRadio, bordeRadio), 180, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, 0, bordeRadio, bordeRadio), 270, 90);
                    path.AddArc(new Rectangle(boton.Width - bordeRadio - 1, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 0, 90);
                    path.AddArc(new Rectangle(0, boton.Height - bordeRadio - 1, bordeRadio, bordeRadio), 90, 90);
                    path.CloseAllFigures();

                    // Dibuja el borde con el color especificado
                    e.Graphics.DrawPath(new Pen(bordeColor, bordeGrosor), path);
                }

                // Establece el color del texto
                boton.ForeColor = textoColor;
            };

            // Evento MouseEnter: Cambia el tamaño desde el centro y el color del texto
            boton.MouseEnter += (sender, e) =>
            {
                int incremento = 5;
                int nuevoAncho = originalSize.Width + incremento;
                int nuevoAlto = originalSize.Height + incremento;
                int deltaX = (nuevoAncho - originalSize.Width) / 2;
                int deltaY = (nuevoAlto - originalSize.Height) / 2;

                boton.Size = new Size(nuevoAncho, nuevoAlto);
                boton.Location = new Point(originalLocation.X - deltaX, originalLocation.Y - deltaY);

                boton.ForeColor = Color.Green; // Cambia el color del texto a verde
                boton.Invalidate(); // Redibuja el botón para aplicar el borde
            };

            // Evento MouseHover: Cambia solo el color de fondo
            boton.MouseHover += (sender, e) =>
            {
                boton.BackColor = Color.FromArgb(15, 209, 29);
                boton.ForeColor = Color.White; // Cambia el color del texto a blanco
            };

            // Evento MouseLeave: Restaura el tamaño, la posición y el color del texto original
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = originalSize;
                boton.Location = originalLocation;
                boton.BackColor = Color.White;
                boton.ForeColor = Color.Green; // Mantiene el color del texto en verde
                boton.Invalidate(); // Redibuja el botón para aplicar el borde
            };

            // Llama a Invalidate para asegurarse de que el borde se dibuje inicialmente
            boton.Invalidate();
        }
                //--------------------------------------------------------------------------------------------------------

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
          
            this.ResumeLayout(false);

        }
        private void ConfigureTextBoxAutoComplete()
        {
           
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && textBox.Name.StartsWith("textBox_Caratula"))
                {
                    autocompletarManager.ConfigureTextBoxAutoComplete(textBox);
                }
            }
        }

        
    }
}


   
