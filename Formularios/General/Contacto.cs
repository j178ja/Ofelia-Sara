using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Controles.Controles.Tooltip;
using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Diagnostics;
using System.Drawing;


namespace Ofelia_Sara.Formularios.General
{
    public partial class Contacto : BaseForm
    {
        public Contacto()
        {
            InitializeComponent();

            RedondearBordes.Aplicar(panel1, 15);
        }



        private void Contacto_Load(object sender, EventArgs e)
        {
            Txt_Curriculum(); //carga el texto
            //incrementar imagen de los picture en el hover
            IncrementarTamaño.Incrementar(pictureBox_Linkedin);
            IncrementarTamaño.Incrementar(pictureBox_Github);
            IncrementarTamaño.Incrementar(pictureBox_Wpp);
            IncrementarTamaño.Incrementar(pictureBox_Correo);
            ToolTipGeneral.Mostrar(pictureBox_Linkedin, " Revise perfil de trajo.");
            ToolTipGeneral.Mostrar(pictureBox_Github, " Explore portafolio de proyectos.");
            ToolTipGeneral.Mostrar(pictureBox_Wpp, " Comuniquese mediante mensaje WhatsApp.");
            ToolTipGeneral.Mostrar(pictureBox_Correo, " Envíe un correo electronico.");
        }


        private static void AbrirUrl(string url)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Usa el navegador predeterminado o cliente de correo
                };
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir el enlace: {url}. Error: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// abre correo electronico y genera mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Correo_Click(object sender, EventArgs e)
        {
            // Define el destinatario, el asunto y el cuerpo del mensaje (opcional)
            string to = "jbestudiosycapacitaciones@gmail.com";
            string subject = "Asunto del correo";
            string body = "Cuerpo del mensaje";


            // Abre la aplicación de correo predeterminada del usuario
            try
            {
                string mailtoUrl = $"mailto:{to}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

                AbrirUrl(mailtoUrl);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir el cliente de correo. Error: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// abre wpp y  genera mensaje predeterminado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Wpp_Click(object sender, EventArgs e)
        {
            // Define el número de teléfono en formato internacional (sin + ni espacios)
            string phoneNumber = "+542236971880"; // Reemplaza con el número deseado
                                                  // Define el mensaje (opcional)
            string message = "Hola, ¿cómo estás?";


            // Abre la URL en el navegador predeterminado
            try
            {
                string whatsappUrl = $"https://wa.me/{phoneNumber}?text={Uri.EscapeDataString(message)}";

                AbrirUrl(whatsappUrl);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir WhatsApp. Error: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// abre linkedin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Linkedin_Click(object sender, EventArgs e)
        {

            // Abre la URL en el navegador predeterminado
            try
            {
                string linkedinProfileUrl = "https://www.linkedin.com/in/jorge-bonato-ba2521271/";
                AbrirUrl(linkedinProfileUrl);
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir LinkedIn. Error: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }

        }

        /// <summary>
        /// abre github
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Github_Click(object sender, EventArgs e)
        {

            // Abre la URL en el navegador predeterminado
            try
            {
                string githubUrl = "https://github.com/j178ja";
                AbrirUrl(githubUrl); // Llama al método genérico para abrir la URL
            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo abrir Github. Error: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// contiene el texto que se mostrara 
        /// </summary>
        private void Txt_Curriculum()
        {

            // Establecer el texto del TextBox
            textBox_Curriculum.Text = "TECNICO SUPERIOR EN SEGURIDAD PUBLICA" + Environment.NewLine + Environment.NewLine +
                                "TECNICO SUPERIOR EN DOCUMENTOLOGIA" + Environment.NewLine + Environment.NewLine +
                                "ESTUDIANTE AUTODIDACTA DE PROGRAMACION." + Environment.NewLine + Environment.NewLine +
                                "ESTUDIANTE DE FILOSOFIA Y ANALISIS DELICTUAL.";
        }
    }
}
