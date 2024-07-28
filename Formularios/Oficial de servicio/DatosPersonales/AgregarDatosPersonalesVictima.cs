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
        }

        private void AgregarDatosPersonalesVictima_Load(object sender, EventArgs e)
        {
           
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarDatosPersonalesVictima));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_Nacionalidad = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label_Nacionalidad = new System.Windows.Forms.Label();
            this.textBox_Localidad = new System.Windows.Forms.TextBox();
            this.textBox_Domicilio = new System.Windows.Forms.TextBox();
            this.textBox_FechaNacimiento = new System.Windows.Forms.TextBox();
            this.textBox_Edad = new System.Windows.Forms.TextBox();
            this.textBox_Dni = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label_Localidad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Domicilio = new System.Windows.Forms.Label();
            this.label_Edad = new System.Windows.Forms.Label();
            this.label_FechaNacimiento = new System.Windows.Forms.Label();
            this.label_Dni = new System.Windows.Forms.Label();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.label_CircunstanciasPersonales = new System.Windows.Forms.Label();
            this.label_Titulo = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_Notificacion258 = new System.Windows.Forms.Label();
            this.checkBox_Notificacion258 = new System.Windows.Forms.CheckBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // timePickerPersonalizadoFecha
            // 
            this.timePickerPersonalizadoFecha.SelectedDate = new System.DateTime(2024, 7, 27, 17, 8, 5, 929);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.checkBox_Notificacion258);
            this.panel1.Controls.Add(this.label_Notificacion258);
            this.panel1.Controls.Add(this.btn_Limpiar);
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.comboBox_Nacionalidad);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label_Nacionalidad);
            this.panel1.Controls.Add(this.textBox_Localidad);
            this.panel1.Controls.Add(this.textBox_Domicilio);
            this.panel1.Controls.Add(this.textBox_FechaNacimiento);
            this.panel1.Controls.Add(this.textBox_Edad);
            this.panel1.Controls.Add(this.textBox_Dni);
            this.panel1.Controls.Add(this.textBox_Nombre);
            this.panel1.Controls.Add(this.label_Localidad);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label_Domicilio);
            this.panel1.Controls.Add(this.label_Edad);
            this.panel1.Controls.Add(this.label_FechaNacimiento);
            this.panel1.Controls.Add(this.label_Dni);
            this.panel1.Controls.Add(this.label_Nombre);
            this.panel1.Controls.Add(this.label_CircunstanciasPersonales);
            this.panel1.Controls.Add(this.label_Titulo);
            this.panel1.Location = new System.Drawing.Point(24, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 480);
            this.panel1.TabIndex = 2;
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
            this.comboBox_Nacionalidad.Location = new System.Drawing.Point(371, 167);
            this.comboBox_Nacionalidad.Name = "comboBox_Nacionalidad";
            this.comboBox_Nacionalidad.Size = new System.Drawing.Size(133, 21);
            this.comboBox_Nacionalidad.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 296);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(271, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 73;
            this.label2.Text = "EMAIL :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 71;
            this.label1.Text = "TELEFONO :";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Location = new System.Drawing.Point(445, 229);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(78, 19);
            this.pictureBox6.TabIndex = 70;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "Arrastrar imagen aqui");
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Location = new System.Drawing.Point(445, 204);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(78, 19);
            this.pictureBox5.TabIndex = 69;
            this.pictureBox5.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox5, "Arrastrar imagen aqui");
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(400, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 25);
            this.button2.TabIndex = 68;
            this.button2.Text = "+";
            this.toolTip1.SetToolTip(this.button2, "Buscar imagen en galeria");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label_Nacionalidad
            // 
            this.label_Nacionalidad.AutoSize = true;
            this.label_Nacionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nacionalidad.Location = new System.Drawing.Point(259, 169);
            this.label_Nacionalidad.Name = "label_Nacionalidad";
            this.label_Nacionalidad.Size = new System.Drawing.Size(114, 15);
            this.label_Nacionalidad.TabIndex = 66;
            this.label_Nacionalidad.Text = "NACIONALIDAD :";
            // 
            // textBox_Localidad
            // 
            this.textBox_Localidad.Location = new System.Drawing.Point(124, 228);
            this.textBox_Localidad.Name = "textBox_Localidad";
            this.textBox_Localidad.Size = new System.Drawing.Size(270, 20);
            this.textBox_Localidad.TabIndex = 6;
            // 
            // textBox_Domicilio
            // 
            this.textBox_Domicilio.Location = new System.Drawing.Point(124, 202);
            this.textBox_Domicilio.Name = "textBox_Domicilio";
            this.textBox_Domicilio.Size = new System.Drawing.Size(270, 20);
            this.textBox_Domicilio.TabIndex = 5;
            // 
            // textBox_FechaNacimiento
            // 
            this.textBox_FechaNacimiento.Location = new System.Drawing.Point(408, 134);
            this.textBox_FechaNacimiento.Name = "textBox_FechaNacimiento";
            this.textBox_FechaNacimiento.Size = new System.Drawing.Size(96, 20);
            this.textBox_FechaNacimiento.TabIndex = 2;
            // 
            // textBox_Edad
            // 
            this.textBox_Edad.Location = new System.Drawing.Point(90, 165);
            this.textBox_Edad.Name = "textBox_Edad";
            this.textBox_Edad.Size = new System.Drawing.Size(60, 20);
            this.textBox_Edad.TabIndex = 3;
            // 
            // textBox_Dni
            // 
            this.textBox_Dni.Location = new System.Drawing.Point(73, 133);
            this.textBox_Dni.Name = "textBox_Dni";
            this.textBox_Dni.Size = new System.Drawing.Size(181, 20);
            this.textBox_Dni.TabIndex = 1;
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(123, 103);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(381, 20);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // label_Localidad
            // 
            this.label_Localidad.AutoSize = true;
            this.label_Localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Localidad.Location = new System.Drawing.Point(32, 229);
            this.label_Localidad.Name = "label_Localidad";
            this.label_Localidad.Size = new System.Drawing.Size(90, 15);
            this.label_Localidad.TabIndex = 65;
            this.label_Localidad.Text = "LOCALIDAD :";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(400, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 25);
            this.button1.TabIndex = 67;
            this.toolTip1.SetToolTip(this.button1, "buscar en GoogleMaps");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label_Domicilio
            // 
            this.label_Domicilio.AutoSize = true;
            this.label_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Domicilio.Location = new System.Drawing.Point(32, 203);
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
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar.Image")));
            this.btn_Limpiar.Location = new System.Drawing.Point(243, 391);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 67);
            this.btn_Limpiar.TabIndex = 75;
            this.toolTip1.SetToolTip(this.btn_Limpiar, "Limpiar Formulario");
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.Location = new System.Drawing.Point(408, 391);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 67);
            this.btn_Guardar.TabIndex = 74;
            this.toolTip1.SetToolTip(this.btn_Guardar, "Guardar");
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // label_Notificacion258
            // 
            this.label_Notificacion258.AutoSize = true;
            this.label_Notificacion258.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Notificacion258.Location = new System.Drawing.Point(32, 350);
            this.label_Notificacion258.Name = "label_Notificacion258";
            this.label_Notificacion258.Size = new System.Drawing.Size(175, 15);
            this.label_Notificacion258.TabIndex = 76;
            this.label_Notificacion258.Text = "Notificacion Art 258 C.P.P.";
            // 
            // checkBox_Notificacion258
            // 
            this.checkBox_Notificacion258.AutoSize = true;
            this.checkBox_Notificacion258.Location = new System.Drawing.Point(227, 352);
            this.checkBox_Notificacion258.Name = "checkBox_Notificacion258";
            this.checkBox_Notificacion258.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Notificacion258.TabIndex = 77;
            this.toolTip1.SetToolTip(this.checkBox_Notificacion258, "Marcar si requiere notificacion de pericia");
            this.checkBox_Notificacion258.UseVisualStyleBackColor = true;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(73, 391);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 67);
            this.btn_Buscar.TabIndex = 78;
            this.toolTip1.SetToolTip(this.btn_Buscar, "Buscar archivos guardados");
            this.btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // AgregarDatosPersonalesVictima
            // 
            this.ClientSize = new System.Drawing.Size(608, 542);
            this.Controls.Add(this.panel1);
            this.Name = "AgregarDatosPersonalesVictima";
            this.Text = "CIRCUNSTANCIAS PERSONALES VICTIMA";
            this.Load += new System.EventHandler(this.AgregarDatosPersonalesVictima_Load_1);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AgregarDatosPersonalesVictima_Load_1(object sender, EventArgs e)
        {
            // Llamada para aplicar el estilo de boton de BaseForm
            InicializarEstiloBoton(btn_Limpiar);
            InicializarEstiloBoton(btn_Guardar);
            InicializarEstiloBoton(btn_Buscar);
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Formulario guardado.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
