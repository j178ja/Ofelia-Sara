using Ofelia_Sara.general.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Formularios;


namespace Ofelia_Sara.Formularios
{
    public partial class Contacto : BaseForm
    {
        public Contacto()
        {
            InitializeComponent();

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);
        }
        // Implementación del método de la interfaz IFormulario
        public void Inicializar()
        {
            // para logica de interfaz IFormulario
        }

        private void Contacto_Load(object sender, EventArgs e)
        {
            txt_Curriculum();
        }

        private void pictureBox_Correo_Click(object sender, EventArgs e)
        {
            // Define el destinatario, el asunto y el cuerpo del mensaje (opcional)
            string to = "jbestudiosycapacitaciones@gmail.com";
            string subject = "Asunto del correo";
            string body = "Cuerpo del mensaje";

            // Construye la URL mailto
            string mailtoUrl = $"mailto:{to}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

            // Abre la aplicación de correo predeterminada del usuario
            try
            {
                System.Diagnostics.Process.Start(mailtoUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el cliente de correo. Error: {ex.Message}");
            }
        }

        private void pictureBox_Wpp_Click(object sender, EventArgs e)
        {
            // Define el número de teléfono en formato internacional (sin + ni espacios)
            string phoneNumber = "+542236971880"; // Reemplaza con el número deseado
                                               // Define el mensaje (opcional)
            string message = "Hola, ¿cómo estás?";

            // Construye la URL de WhatsApp
            string whatsappUrl = $"https://wa.me/{phoneNumber}?text={Uri.EscapeDataString(message)}";

            // Abre la URL en el navegador predeterminado
            try
            {
                System.Diagnostics.Process.Start(whatsappUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir WhatsApp. Error: {ex.Message}");
            }
        }

        private void pictureBox_Linkedin_Click(object sender, EventArgs e)
        {
            // Define la URL del perfil de LinkedIn
    string linkedinProfileUrl = "https://www.linkedin.com/in/jorge-bonato-ba2521271/"; 

            // Abre la URL en el navegador predeterminado
            try
            {
                System.Diagnostics.Process.Start(linkedinProfileUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir LinkedIn. Error: {ex.Message}");
            }

        }

        private void pictureBox_Github_Click(object sender, EventArgs e)
        {
            // Define la URL del perfil de Github
            string GithubUrl = "https://github.com/j178ja"; 

            // Abre la URL en el navegador predeterminado
            try
            {
                System.Diagnostics.Process.Start(GithubUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir Github. Error: {ex.Message}");
            }
        }

      
        private void txt_Curriculum()
        {

            // Establecer el texto del TextBox
            textBox_Curriculum.Text = "TECNICO SUPERIOR EN SEGURIDAD PUBLICA" + Environment.NewLine + Environment.NewLine +
                                "TECNICO SUPERIOR EN DOCUMENTOLOGIA" + Environment.NewLine + Environment.NewLine +
                                "ESTUDIANTE AUTODIDACTA DE PROGRAMACION." + Environment.NewLine + Environment.NewLine +
                                "ESTUDIANTE DE FILOSOFIA Y ANALISIS DELICTUAL.";
        }
    }
}
