using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Controles;
using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Formularios.General.Mensajes;
using Ofelia_Sara.Controles.Ofl_Sara;
using BaseDatos.Adm_BD.Manager;
using Ofelia_Sara.Clases;
using Ofelia_Sara.Formularios.General;

namespace Ofelia_Sara.Formularios.General
{
    public partial class IMPRESION : BaseForm
    {
        public IMPRESION()
        {
        
            InitializeComponent();

         

            Color customBorderColor = Color.FromArgb(0, 154, 174);
            panel1.ApplyRoundedCorners(borderRadius: 15, borderSize: 7, borderColor: customBorderColor);

            // Crear un ejemplo de Verificador_ACTUACION y añadirlo al TableLayoutPanel
            Verificador_ACTUACION verificador = new Verificador_ACTUACION(this);// amodo de prueba
            ContenedorActuaciones.Controls.Add(verificador);
        }


        private void IMPRESION_Load(object sender, EventArgs e)
        {


            // Suscribirse a los eventos de imagen visible solo una vez
            foreach (Control control in ContenedorActuaciones.Controls)
            {
                if (control is Verificador_ACTUACION verificador)
                {
                    verificador.ImagenVisibleChanged += Verificador_ImagenVisibleChanged;
                }
            }

            // Actualizar los contadores al cargar el formulario
            ActualizarContadores();
            RedondearBordes.Aplicar(panel_informacionSeleccion, 16);//Redondea los bordes de panel superior e inferior
        }

        public void ActualizarContadores()
        {
            int totalControles = 0;
            int archivosSeleccionados = 0;

            // Iterar sobre los controles en el contenedor
            foreach (Control control in ContenedorActuaciones.Controls)
            {
                if (control is Verificador_ACTUACION verificador)
                {
                    totalControles++; // Incrementar el contador de controles totales

                    // Verificar si la imagen está visible (indica selección)
                    if (verificador.IsImagenVisible)
                    {
                        archivosSeleccionados++; // Incrementar el contador de archivos seleccionados
                    }
                }
            }

            // Actualizar los textos de los Labels
            label_CantidadArchivos.Text = $"Documentos creados: {totalControles}";
            label_Seleccionados.Text = $"Documentos seleccionados: {archivosSeleccionados}";
        }

        private void Verificador_ImagenVisibleChanged(object sender, EventArgs e)
        {
            Verificador_ACTUACION verificador = sender as Verificador_ACTUACION;
            if (verificador != null && verificador.IsImagenVisible)
            {
                // Lógica para actualizar los contadores o realizar acciones
                ActualizarContadores();
            }
        }

        private void ContenedorActuaciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxIMG1_Load(object sender, EventArgs e)
        {

        }




        /* private void CompendioActuaciones_FormClosing(object sender, FormClosingEventArgs e)
         {
             if (!datosGuardados) // Si los datos no han sido guardados
             {
                 using (MensajeGeneral mensaje = new MensajeGeneral("No has guardado los cambios. ¿Estás seguro de que deseas cerrar sin guardar?", MensajeGeneral.TipoMensaje.Advertencia))
                 {
                     // Hacer visibles los botones
                     mensaje.MostrarBotonesConfirmacion(true);

                     DialogResult result = mensaje.ShowDialog();
                     if (result == DialogResult.No)
                     {
                         e.Cancel = true; // Cancelar el cierre del formulario
                     }
                 }
             }
         }*/
    }
}
