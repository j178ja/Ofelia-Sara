
using BaseDatos.Adm_BD;
using BaseDatos.Adm_BD.Manager;
using BaseDatos.Adm_BD.Modelos;
using BaseDatos.Entidades;
using Clases.Apariencia;
using Controles.Controles;
using System;
// Alias para el ShadowForm de tu propia clase
// using Ofelia_Sara.Base_de_Datos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;




namespace Ofelia_Sara.Formularios

{


    public class BaseForm : Form
    {
        private DatabaseConnection dbConnection;



        protected ComisariasManager dbManager = new ComisariasManager();//para cargar comisarias// Para cargar comisarías
        protected InstructoresManager instructoresManager = new InstructoresManager();    // Para cargar instructores
        protected SecretariosManager secretariosManager = new SecretariosManager();    // Para cargar instructores
        //protected FiscaliasManager fiscaliasManager = new FiscaliasManager();    // Para cargar fiscalias

        private readonly AutocompletarManager autocompletarManager; // Define una lista para almacenar los elementos de autocompletado

        private LinkLabel footerLinkLabel;

        protected TimePickerPersonalizado timePickerPersonalizadoFecha;

        // Método OnLoad combinado
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public BaseForm()
        {
            CargarIconoFormulario();

            InitializeFooterLinkLabel();

            //------------------CAMBIAR FONDO----------------------------------------------------
            // Cambiar el color de fondo del formulario usando AparienciaFormularios
            Color customColor = Color.FromArgb(0, 154, 174); // Color personalizado #009AAE
                                                             //---ESTE COLOR PERTENECE AL ACTUAL DE MINISTERIO DE SEGURIDAD-----
            AparienciaFormularios.CambiarColorDeFondo(this, customColor);//llama a la clase que modifica el color de fondo
                                                                         //-------------------------------------------------------------------------

            this.Paint += new PaintEventHandler(BaseForm_Paint);
            //this.Load += new System.EventHandler(this.BaseForm_Load);
            //---------------------------------------------
            //--para cargar los distintos comboBox desde la base de datos
            // Solo ejecutar si NO es tiempo de diseño
            InitializeComponent();

            // Verificamos si está en tiempo de ejecución
            // Evitar que se ejecute el código en modo diseño
            // Evitar ejecución en tiempo de diseño
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; // Salir si estamos en modo diseño
            }

            autocompletarManager = new AutocompletarManager(@"path\to\Cartatulas_Autocompletar.json");
            ConfigureTextBoxAutoComplete();

            instructoresManager = new InstructoresManager();
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
        }



        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            // Obtener las dimensiones del formulario
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Llamar al método que dibuja el fondo degradado
            DibujarFondoDegradado(e.Graphics, width, height);
        }
        //----------------------------------------------
        // Método para cargar el ícono según el modo (diseñador o ejecución)
        private void CargarIconoFormulario()
        {
            string iconPath;

            if (this.DesignMode)
            {
                // Ruta de ícono para el diseñador de Visual Studio
                iconPath = Path.Combine(@"C:\Ruta\Absoluta\A\Tu\Proyecto\Resources\imagenes", "IconoEscudoPolicia.ico");
            }
            else
            {
                // Ruta relativa para el tiempo de ejecución
                iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "imagenes", "IconoEscudoPolicia.ico");
            }

            // Llama a SetFormIcon solo si el archivo existe
            if (File.Exists(iconPath))
            {
                IconoEscudo.SetFormIcon(this, iconPath);
            }
            else
            {
                // Opcional: log o advertencia si el ícono no se encuentra
                Console.WriteLine("No se pudo encontrar el ícono en la ruta especificada.");
            }
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



        //-----METODO PARA MOSTRAR FOOTER-----------------------
        private void InitializeFooterLinkLabel()
        {

            // Llama al método estático de FooterHelper para obtener el footerLabel configurado
            this.footerLinkLabel = FooterHelper.CreateFooterLinkLabel(this);
            this.Controls.Add(this.footerLinkLabel);
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


        //--------
        public void CargarDatosDependencia(ComboBox comboBox, ComisariasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Comisaria> comisarias = dbManager.GetComisarias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de comisarías y agregar los datos al ComboBox
                foreach (Comisaria comisaria in comisarias)
                {
                    string item = $"{comisaria.Nombre}   {comisaria.Localidad}"; // Utiliza las propiedades de la clase Comisaria
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Dependencias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---


        public void CargarDatosInstructor(ComboBox comboBox, InstructoresManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Instructor> instructores = dbManager.GetInstructors(); // Asegúrate de usar el método correcto

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de instructores y agregar los datos al ComboBox
                foreach (Instructor instructor in instructores)
                {
                    // Utiliza las propiedades de la clase Instructor
                    string item = $"{instructor.Jerarquia} {instructor.Nombre} {instructor.Apellido}";
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Instructores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CargarDatosSecretario(ComboBox comboBox, SecretariosManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Secretario> secretarios = dbManager.GetSecretarios();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de secretarios y agregar los datos al ComboBox
                foreach (Secretario secretario in secretarios)
                {
                    // Utiliza las propiedades de la clase Secretario
                    string item = $"{secretario.Jerarquia} {secretario.Nombre} {secretario.Apellido}";
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Secretarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CargarDatosFiscalia(ComboBox comboBox, FiscaliasManager dbManager)
        {
            try
            {
                // Obtener los datos desde la base de datos
                List<Fiscalia> fiscalias = dbManager.GetFiscalias();

                // Limpiar los ítems existentes en el ComboBox antes de añadir nuevos
                comboBox.Items.Clear();

                // Recorrer la lista de fiscalías y agregar los datos al ComboBox
                foreach (Fiscalia fiscalia in fiscalias)
                {
                    string item = $"{fiscalia.Ufid} - {fiscalia.AgenteFiscal} - {fiscalia.Localidad}"; // Puedes personalizar el formato
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de Fiscalías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Método virtual para ser sobreescrito en los formularios hijos
        protected virtual ComboBox ObtenerComboBoxDependencia()
        {
            return null; // Devuelve null por defecto, será sobrescrito en cada formulario específico
        }

    }
}



