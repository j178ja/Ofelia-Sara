using System;
using Ofelia_Sara.general.clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;
using Ofelia_Sara.general.clases.Apariencia_General.Texto;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales
{
    public partial class AgregarDatosPersonalesVictima : BaseForm
    {
        public string TextoNombre
        {
            get { return textBox_Nombre.Text; }
            set { textBox_Nombre.Text = value; }
        }
        public AgregarDatosPersonalesVictima()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.AgregarDatosPersonalesVictima_Load);


        }

        private void AgregarDatosPersonalesVictima_Load(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            // Configura el arrastrar y soltar para los PictureBox
            pictureBox_Domicilio.AllowDrop = true;
            pictureBox_Geoposicionamiento.AllowDrop = true;

            pictureBox_Domicilio.DragEnter += PictureBox_DragEnter;
            pictureBox_Geoposicionamiento.DragEnter += PictureBox_DragEnter;

            pictureBox_Geoposicionamiento.DragDrop += PictureBox_DragDrop;
            pictureBox_Domicilio.DragDrop += PictureBox_DragDrop;

            // Ajusta el SizeMode de cada PictureBox
            pictureBox_Domicilio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Geoposicionamiento.SizeMode = PictureBoxSizeMode.StretchImage;

            //-------------------------------------------------------------------------------
            // Define las excepciones para los TextBox y ComboBox.
            var textBoxExcepciones = new Dictionary<string, bool>
        {
            { "textBox_Dni", true },  // Este TextBox solo acepta números.
            {"textBox_Edad", true },
              {"textBox_DateDIA", true },
            {"textBox_DateMES", true },
            {"textBox_DateAÑO", true },
            {"textBox_FechaNacimiento", true },
            {"textBox_Telefono", true }
            };
             // Aplica la configuración a todos los controles del formulario.
            TextoEnMayuscula.AplicarAControles(this, textBoxExcepciones, null);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarDatosPersonalesVictima));
            this.panel1 = new System.Windows.Forms.Panel();
            this.customDateTextBox1 = new Ofelia_Sara.general.clases.Apariencia_General.Controles.CustomDateTextBox();
            this.label_agrGeo2 = new System.Windows.Forms.Label();
            this.label_agrGeo = new System.Windows.Forms.Label();
            this.label_AgregarDomicilio = new System.Windows.Forms.Label();
            this.textBox_LugarNacimiento = new System.Windows.Forms.TextBox();
            this.label_LugarNacimiento = new System.Windows.Forms.Label();
            this.textBox_Ocupacion = new System.Windows.Forms.TextBox();
            this.label_Ocupacion = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.checkBox_Notificacion258 = new System.Windows.Forms.CheckBox();
            this.label_Notificacion258 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.comboBox_Nacionalidad = new System.Windows.Forms.ComboBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.textBox_Telefono = new System.Windows.Forms.TextBox();
            this.label_Telefono = new System.Windows.Forms.Label();
            this.pictureBox_Geoposicionamiento = new System.Windows.Forms.PictureBox();
            this.pictureBox_Domicilio = new System.Windows.Forms.PictureBox();
            this.label_Nacionalidad = new System.Windows.Forms.Label();
            this.textBox_Localidad = new System.Windows.Forms.TextBox();
            this.textBox_Domicilio = new System.Windows.Forms.TextBox();
            this.textBox_Edad = new System.Windows.Forms.TextBox();
            this.textBox_Dni = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label_Localidad = new System.Windows.Forms.Label();
            this.label_Domicilio = new System.Windows.Forms.Label();
            this.label_Edad = new System.Windows.Forms.Label();
            this.label_FechaNacimiento = new System.Windows.Forms.Label();
            this.label_Dni = new System.Windows.Forms.Label();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.label_CircunstanciasPersonales = new System.Windows.Forms.Label();
            this.label_Titulo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Geoposicionamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Domicilio)).BeginInit();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 7, 27, 17, 8, 5, 929);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.customDateTextBox1);
            this.panel1.Controls.Add(this.label_agrGeo2);
            this.panel1.Controls.Add(this.label_agrGeo);
            this.panel1.Controls.Add(this.label_AgregarDomicilio);
            this.panel1.Controls.Add(this.textBox_LugarNacimiento);
            this.panel1.Controls.Add(this.label_LugarNacimiento);
            this.panel1.Controls.Add(this.textBox_Ocupacion);
            this.panel1.Controls.Add(this.label_Ocupacion);
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.checkBox_Notificacion258);
            this.panel1.Controls.Add(this.label_Notificacion258);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.comboBox_Nacionalidad);
            this.panel1.Controls.Add(this.textBox_Email);
            this.panel1.Controls.Add(this.label_Email);
            this.panel1.Controls.Add(this.textBox_Telefono);
            this.panel1.Controls.Add(this.label_Telefono);
            this.panel1.Controls.Add(this.pictureBox_Geoposicionamiento);
            this.panel1.Controls.Add(this.pictureBox_Domicilio);
            this.panel1.Controls.Add(this.label_Nacionalidad);
            this.panel1.Controls.Add(this.textBox_Localidad);
            this.panel1.Controls.Add(this.textBox_Domicilio);
            this.panel1.Controls.Add(this.textBox_Edad);
            this.panel1.Controls.Add(this.textBox_Dni);
            this.panel1.Controls.Add(this.textBox_Nombre);
            this.panel1.Controls.Add(this.label_Localidad);
            this.panel1.Controls.Add(this.label_Domicilio);
            this.panel1.Controls.Add(this.label_Edad);
            this.panel1.Controls.Add(this.label_FechaNacimiento);
            this.panel1.Controls.Add(this.label_Dni);
            this.panel1.Controls.Add(this.label_Nombre);
            this.panel1.Controls.Add(this.label_CircunstanciasPersonales);
            this.panel1.Controls.Add(this.label_Titulo);
            this.panel1.Location = new System.Drawing.Point(24, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 639);
            this.panel1.TabIndex = 2;
            // 
            // customDateTextBox1
            // 
            this.customDateTextBox1.Location = new System.Drawing.Point(403, 133);
            this.customDateTextBox1.Name = "customDateTextBox1";
            this.customDateTextBox1.Size = new System.Drawing.Size(149, 20);
            this.customDateTextBox1.TabIndex = 91;
            this.toolTip1.SetToolTip(this.customDateTextBox1, "Seleccione la fecha");
            // 
            // label_agrGeo2
            // 
            this.label_agrGeo2.AutoSize = true;
            this.label_agrGeo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_agrGeo2.Location = new System.Drawing.Point(75, 306);
            this.label_agrGeo2.Name = "label_agrGeo2";
            this.label_agrGeo2.Size = new System.Drawing.Size(94, 15);
            this.label_agrGeo2.TabIndex = 84;
            this.label_agrGeo2.Text = "de domicilio :";
            // 
            // label_agrGeo
            // 
            this.label_agrGeo.AutoSize = true;
            this.label_agrGeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_agrGeo.Location = new System.Drawing.Point(31, 287);
            this.label_agrGeo.Name = "label_agrGeo";
            this.label_agrGeo.Size = new System.Drawing.Size(195, 15);
            this.label_agrGeo.TabIndex = 83;
            this.label_agrGeo.Text = "Agregar geoposicionamiento ";
            // 
            // label_AgregarDomicilio
            // 
            this.label_AgregarDomicilio.AutoSize = true;
            this.label_AgregarDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AgregarDomicilio.Location = new System.Drawing.Point(26, 355);
            this.label_AgregarDomicilio.Name = "label_AgregarDomicilio";
            this.label_AgregarDomicilio.Size = new System.Drawing.Size(200, 15);
            this.label_AgregarDomicilio.TabIndex = 82;
            this.label_AgregarDomicilio.Text = "Agregar imagen de domicilio :";
            // 
            // textBox_LugarNacimiento
            // 
            this.textBox_LugarNacimiento.Location = new System.Drawing.Point(325, 165);
            this.textBox_LugarNacimiento.Name = "textBox_LugarNacimiento";
            this.textBox_LugarNacimiento.Size = new System.Drawing.Size(199, 20);
            this.textBox_LugarNacimiento.TabIndex = 4;
            // 
            // label_LugarNacimiento
            // 
            this.label_LugarNacimiento.AutoSize = true;
            this.label_LugarNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LugarNacimiento.Location = new System.Drawing.Point(160, 166);
            this.label_LugarNacimiento.Name = "label_LugarNacimiento";
            this.label_LugarNacimiento.Size = new System.Drawing.Size(168, 15);
            this.label_LugarNacimiento.TabIndex = 81;
            this.label_LugarNacimiento.Text = "LUGAR DE NACIMIENTO:";
            // 
            // textBox_Ocupacion
            // 
            this.textBox_Ocupacion.Location = new System.Drawing.Point(125, 194);
            this.textBox_Ocupacion.Name = "textBox_Ocupacion";
            this.textBox_Ocupacion.Size = new System.Drawing.Size(139, 20);
            this.textBox_Ocupacion.TabIndex = 5;
            // 
            // label_Ocupacion
            // 
            this.label_Ocupacion.AutoSize = true;
            this.label_Ocupacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ocupacion.Location = new System.Drawing.Point(33, 195);
            this.label_Ocupacion.Name = "label_Ocupacion";
            this.label_Ocupacion.Size = new System.Drawing.Size(94, 15);
            this.label_Ocupacion.TabIndex = 79;
            this.label_Ocupacion.Text = "OCUPACION :";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(74, 538);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 67);
            this.btn_Buscar.TabIndex = 78;
            this.toolTip1.SetToolTip(this.btn_Buscar, "Buscar archivos guardados");
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // checkBox_Notificacion258
            // 
            this.checkBox_Notificacion258.AutoSize = true;
            this.checkBox_Notificacion258.Location = new System.Drawing.Point(229, 493);
            this.checkBox_Notificacion258.Name = "checkBox_Notificacion258";
            this.checkBox_Notificacion258.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Notificacion258.TabIndex = 11;
            this.toolTip1.SetToolTip(this.checkBox_Notificacion258, "Marcar si requiere notificacion de pericia");
            this.checkBox_Notificacion258.UseVisualStyleBackColor = true;
            // 
            // label_Notificacion258
            // 
            this.label_Notificacion258.AutoSize = true;
            this.label_Notificacion258.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Notificacion258.Location = new System.Drawing.Point(34, 491);
            this.label_Notificacion258.Name = "label_Notificacion258";
            this.label_Notificacion258.Size = new System.Drawing.Size(175, 15);
            this.label_Notificacion258.TabIndex = 76;
            this.label_Notificacion258.Text = "Notificacion Art 258 C.P.P.";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(244, 538);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btn_Limpiar, "Limpiar Formulario");
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(409, 538);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btn_Guardar, "Guardar");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // comboBox_Nacionalidad
            // 
            this.comboBox_Nacionalidad.AutoCompleteCustomSource.AddRange(new string[] {
            "ARGENTINA",
            "PARAGUAYA",
            "BOLIVIANA"});
            this.comboBox_Nacionalidad.FormattingEnabled = true;
            this.comboBox_Nacionalidad.Items.AddRange(new object[] {
            "ARGENTINA",
            "PARAGUAYA",
            "BOLIVIANA",
            "CHILENA",
            "PERUANA",
            "URUGUAYA"});
            this.comboBox_Nacionalidad.Location = new System.Drawing.Point(393, 192);
            this.comboBox_Nacionalidad.Name = "comboBox_Nacionalidad";
            this.comboBox_Nacionalidad.Size = new System.Drawing.Size(131, 21);
            this.comboBox_Nacionalidad.TabIndex = 6;
            this.comboBox_Nacionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Nacionalidad_KeyPress);
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(124, 446);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(271, 20);
            this.textBox_Email.TabIndex = 10;
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Email.Location = new System.Drawing.Point(34, 446);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(56, 15);
            this.label_Email.TabIndex = 73;
            this.label_Email.Text = "EMAIL :";
            // 
            // textBox_Telefono
            // 
            this.textBox_Telefono.Location = new System.Drawing.Point(125, 420);
            this.textBox_Telefono.Name = "textBox_Telefono";
            this.textBox_Telefono.Size = new System.Drawing.Size(270, 20);
            this.textBox_Telefono.TabIndex = 9;
            // 
            // label_Telefono
            // 
            this.label_Telefono.AutoSize = true;
            this.label_Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Telefono.Location = new System.Drawing.Point(34, 421);
            this.label_Telefono.Name = "label_Telefono";
            this.label_Telefono.Size = new System.Drawing.Size(87, 15);
            this.label_Telefono.TabIndex = 71;
            this.label_Telefono.Text = "TELEFONO :";
            // 
            // pictureBox_Geoposicionamiento
            // 
            this.pictureBox_Geoposicionamiento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox_Geoposicionamiento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Geoposicionamiento.BackgroundImage")));
            this.pictureBox_Geoposicionamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Geoposicionamiento.Location = new System.Drawing.Point(229, 275);
            this.pictureBox_Geoposicionamiento.Name = "pictureBox_Geoposicionamiento";
            this.pictureBox_Geoposicionamiento.Size = new System.Drawing.Size(295, 55);
            this.pictureBox_Geoposicionamiento.TabIndex = 70;
            this.pictureBox_Geoposicionamiento.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox_Geoposicionamiento, "Arrastrar imagen aqui");
            this.pictureBox_Geoposicionamiento.Click += new System.EventHandler(this.PictureBox_Click);
            this.pictureBox_Geoposicionamiento.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.pictureBox_Geoposicionamiento.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            // 
            // pictureBox_Domicilio
            // 
            this.pictureBox_Domicilio.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox_Domicilio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Domicilio.BackgroundImage")));
            this.pictureBox_Domicilio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Domicilio.Location = new System.Drawing.Point(229, 336);
            this.pictureBox_Domicilio.Name = "pictureBox_Domicilio";
            this.pictureBox_Domicilio.Size = new System.Drawing.Size(295, 55);
            this.pictureBox_Domicilio.TabIndex = 69;
            this.pictureBox_Domicilio.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox_Domicilio, "Arrastrar imagen aqui");
            this.pictureBox_Domicilio.Click += new System.EventHandler(this.PictureBox_Click);
            this.pictureBox_Domicilio.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.pictureBox_Domicilio.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            // 
            // label_Nacionalidad
            // 
            this.label_Nacionalidad.AutoSize = true;
            this.label_Nacionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nacionalidad.Location = new System.Drawing.Point(281, 194);
            this.label_Nacionalidad.Name = "label_Nacionalidad";
            this.label_Nacionalidad.Size = new System.Drawing.Size(114, 15);
            this.label_Nacionalidad.TabIndex = 66;
            this.label_Nacionalidad.Text = "NACIONALIDAD :";
            // 
            // textBox_Localidad
            // 
            this.textBox_Localidad.Location = new System.Drawing.Point(125, 247);
            this.textBox_Localidad.Name = "textBox_Localidad";
            this.textBox_Localidad.Size = new System.Drawing.Size(399, 20);
            this.textBox_Localidad.TabIndex = 8;
            this.textBox_Localidad.TextChanged += new System.EventHandler(this.textBox_Localidad_TextChanged);
            // 
            // textBox_Domicilio
            // 
            this.textBox_Domicilio.Location = new System.Drawing.Point(125, 221);
            this.textBox_Domicilio.Name = "textBox_Domicilio";
            this.textBox_Domicilio.Size = new System.Drawing.Size(399, 20);
            this.textBox_Domicilio.TabIndex = 7;
            this.textBox_Domicilio.TextChanged += new System.EventHandler(this.textBox_Domicilio_TextChanged);
            // 
            // textBox_Edad
            // 
            this.textBox_Edad.Location = new System.Drawing.Point(90, 165);
            this.textBox_Edad.Name = "textBox_Edad";
            this.textBox_Edad.Size = new System.Drawing.Size(60, 20);
            this.textBox_Edad.TabIndex = 3;
            this.textBox_Edad.TextChanged += new System.EventHandler(this.textBox_Edad_TextChanged);
            this.textBox_Edad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Edad_KeyPress);
            // 
            // textBox_Dni
            // 
            this.textBox_Dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Dni.Location = new System.Drawing.Point(73, 133);
            this.textBox_Dni.Name = "textBox_Dni";
            this.textBox_Dni.Size = new System.Drawing.Size(181, 20);
            this.textBox_Dni.TabIndex = 1;
            this.textBox_Dni.TextChanged += new System.EventHandler(this.textBox_Dni_TextChanged);
            this.textBox_Dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Dni_KeyPress);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(105, 103);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(419, 20);
            this.textBox_Nombre.TabIndex = 0;
            
            // 
            // label_Localidad
            // 
            this.label_Localidad.AutoSize = true;
            this.label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Localidad.Location = new System.Drawing.Point(33, 248);
            this.label_Localidad.Name = "label_Localidad";
            this.label_Localidad.Size = new System.Drawing.Size(90, 15);
            this.label_Localidad.TabIndex = 65;
            this.label_Localidad.Text = "LOCALIDAD :";
            // 
            // label_Domicilio
            // 
            this.label_Domicilio.AutoSize = true;
            this.label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Domicilio.Location = new System.Drawing.Point(33, 222);
            this.label_Domicilio.Name = "label_Domicilio";
            this.label_Domicilio.Size = new System.Drawing.Size(86, 15);
            this.label_Domicilio.TabIndex = 62;
            this.label_Domicilio.Text = "DOMICILIO :";
            // 
            // label_Edad
            // 
            this.label_Edad.AutoSize = true;
            this.label_Edad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Edad.Location = new System.Drawing.Point(32, 167);
            this.label_Edad.Name = "label_Edad";
            this.label_Edad.Size = new System.Drawing.Size(52, 15);
            this.label_Edad.TabIndex = 61;
            this.label_Edad.Text = "EDAD :";
            // 
            // label_FechaNacimiento
            // 
            this.label_FechaNacimiento.AutoSize = true;
            this.label_FechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FechaNacimiento.Location = new System.Drawing.Point(257, 135);
            this.label_FechaNacimiento.Name = "label_FechaNacimiento";
            this.label_FechaNacimiento.Size = new System.Drawing.Size(147, 15);
            this.label_FechaNacimiento.TabIndex = 58;
            this.label_FechaNacimiento.Text = "FECHA NACIMIENTO :";
            // 
            // label_Dni
            // 
            this.label_Dni.AutoSize = true;
            this.label_Dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dni.Location = new System.Drawing.Point(32, 134);
            this.label_Dni.Name = "label_Dni";
            this.label_Dni.Size = new System.Drawing.Size(39, 15);
            this.label_Dni.TabIndex = 56;
            this.label_Dni.Text = "DNI :";
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nombre.Location = new System.Drawing.Point(31, 104);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(75, 15);
            this.label_Nombre.TabIndex = 54;
            this.label_Nombre.Text = "NOMBRE :";
            // 
            // label_CircunstanciasPersonales
            // 
            this.label_CircunstanciasPersonales.AutoSize = true;
            this.label_CircunstanciasPersonales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_CircunstanciasPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CircunstanciasPersonales.Location = new System.Drawing.Point(88, 39);
            this.label_CircunstanciasPersonales.Name = "label_CircunstanciasPersonales";
            this.label_CircunstanciasPersonales.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
            this.label_CircunstanciasPersonales.Size = new System.Drawing.Size(349, 30);
            this.label_CircunstanciasPersonales.TabIndex = 52;
            this.label_CircunstanciasPersonales.Text = "CIRCUNSTANCIAS PERSONALES";
            // 
            // label_Titulo
            // 
            this.label_Titulo.AutoSize = true;
            this.label_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
            this.label_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Titulo.Location = new System.Drawing.Point(166, 0);
            this.label_Titulo.Name = "label_Titulo";
            this.label_Titulo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label_Titulo.Size = new System.Drawing.Size(194, 25);
            this.label_Titulo.TabIndex = 51;
            this.label_Titulo.Text = "DATOS VICTIMA";
            // 
            // AgregarDatosPersonalesVictima
            // 
            this.ClientSize = new System.Drawing.Size(608, 702);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(624, 581);
            this.Name = "AgregarDatosPersonalesVictima";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIRCUNSTANCIAS PERSONALES VICTIMA";
            this.Load += new System.EventHandler(this.AgregarDatosPersonalesVictima_Load_1);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Geoposicionamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Domicilio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AgregarDatosPersonalesVictima_Load_1(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);

            ActualizarControlesPicture();
        }


        //---------BOTON LIMPIAR----------------------------
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //---------BOTON GUARDAR----------------------------
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //-------CONTROL DE CARACTERES EN NACIONALIDAD-----------------------
        private void comboBox_Nacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es una letra
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la entrada si no es una letra
            }
        }
        //---METODO PARA CONTROL DE EDAD----------------------
        private void textBox_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene menos de 2 caracteres
            if (textBox_Edad.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 2 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }

        private void textBox_Edad_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto actual del TextBox es "0" o "00"
            if (/*textBox_Edad.Text == "0" || */textBox_Edad.Text == "00")
            {
                // Mostrar un mensaje de error y limpiar el TextBox
                MessageBox.Show("El valor no puede ser 0 o 00", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Edad.Clear();
            }
        }
        //------CONTROL DE CANTIDAD DE CARACTERES DNI------------------------
        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }

            // Verificar si el texto actual del TextBox tiene  10 caracteres
            if (textBox_Dni.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                // Si ya tiene 10 caracteres y no es una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }
        //-------METODO PARA MANEJAR EL NUMERO DNI---------------------------

        private void textBox_Dni_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Obtener la posición del cursor antes del formateo
            int cursorPosition = textBox.SelectionStart;

            // Usar la clase separada para formatear el texto con puntos
            string textoFormateado = ClaseNumeros.FormatearNumeroConPuntos(textBox.Text);

            // Actualizar el texto en el TextBox
            textBox.Text = textoFormateado;

            // Asegurarse de que el cursor se posicione al final del texto
            textBox.SelectionStart = textBox.Text.Length;
        }

        //------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------
        //----PARA RECUADRO VERDE Y ROJO DEL PICKTUREBOX-------------
        private void ActualizarControlesPicture()
        {
            // Verifica si TextoDomicilio y localidad tienen texto
            bool esTextoValido = !string.IsNullOrWhiteSpace(textBox_Domicilio.Text) && !string.IsNullOrWhiteSpace(textBox_Localidad.Text);

            // Actualiza el estado de los PictureBox
            ActualizarPictureBox(pictureBox_Geoposicionamiento, esTextoValido);
            ActualizarPictureBox(pictureBox_Domicilio, esTextoValido);

            pictureBox_Geoposicionamiento.Paint += PictureBox_Paint;
            pictureBox_Domicilio.Paint += PictureBox_Paint;

        }

        private void ActualizarPictureBox(PictureBox pictureBox, bool habilitar)
        {
            if (habilitar)
            {
                pictureBox.Enabled = true;
                pictureBox.Tag = Color.LimeGreen; // Color del borde cuando está habilitado
                pictureBox.BackColor = SystemColors.ControlLight;
            }
            else
            {
                pictureBox.Enabled = false;
                pictureBox.Tag = Color.Tomato; // Color del borde cuando está deshabilitado
                pictureBox.BackColor = Color.DarkGray;
            }

            pictureBox.Invalidate(); // Redibuja el borde
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                Color borderColor = pictureBox.Tag is Color ? (Color)pictureBox.Tag : Color.Transparent;

                using (Pen pen = new Pen(borderColor, 3)) // Grosor del borde
                {
                    // Dibuja el borde exterior
                    e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
                }
            }
        }
        //---------------------------------------------------------------------
        //Eventos para cargar imagenes en los pictureBox
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Enabled)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && (files[0].EndsWith(".jpg") || files[0].EndsWith(".jpeg") || files[0].EndsWith(".png") || files[0].EndsWith(".bmp")))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        //------------------------------------------------------------
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files.Length > 0)
                    {
                        // Cargar la imagen desde el archivo
                        Image img = Image.FromFile(files[0]);

                        // Establecer la imagen en el PictureBox
                        pictureBox.Image = img;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                }
            }
        }


        //---- METODOS PARA QUE SE ACTUALICE DEPENDIENDO LO QUE SE INGRESE EN DOMICILIO Y LOCALIDAD-------
        private void textBox_Domicilio_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPicture();
        }

        private void textBox_Localidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarControlesPicture();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario BuscarPersonal
            BuscarForm buscarForm = new BuscarForm();

            buscarForm.ShowDialog();
        }
        // Método para actualizar el textBox2 en tiempo real
        public void UpdateTextBox(string text)
        {
            textBox_Nombre.Text = text;
        }

       
    }
}
