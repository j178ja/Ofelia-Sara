using Ofelia_Sara.general.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara
{
    public partial class MenuPrincipal : BaseForm
    {
        private ConfiguracionMenu configuracionMenu;

        public MenuPrincipal()
        {
            InitializeComponent();

            // Inicializar el evento click sobre el botón de configuración
            //Btn_CambiarTema.Click += Btn_CambiarTema_Click;


        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Inicializar el manejador del menú de configuración
            configuracionMenu = new ConfiguracionMenu();

            // Asociar el menú contextual al botón Btn_Configuracion si no es nulo
            if (Btn_Configuracion != null)
            {
                Btn_Configuracion.Click += (s, args) =>
                {
                    configuracionMenu.ShowMenu(Btn_Configuracion, new Point(0, Btn_Configuracion.Height));
                };
            }
        } 

        private void Btn_Configuracion_Click(object sender, EventArgs e)
        {
            // Mostrar el menú contextual en la posición del cursor del mouse
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null && mouseEventArgs.Button == MouseButtons.Left)
            {
                //configuracionMenu.ShowMenu(Btn_Configuracion, mouseEventArgs.Location);
             
                //------POSICIONAR EL MENU JUSTO DEAJO DEL BOTON-------------
                configuracionMenu.ShowMenu(Btn_Configuracion, new Point(0, Btn_Configuracion.Height));

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Tu lógica aquí
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            // Tu lógica aquí
        }

        private void Btn_Cargo_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Cargo CargoForm = new Cargo();

            // Mostrar el formulario
            CargoForm.Show();
        }

        //-----BOTON INICIO-CIERRE------------
        private void Btn_InicioCierre_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            InicioCierre inicioCierreForm = new InicioCierre();

            // Mostrar el formulario
            inicioCierreForm.Show();
        }

        //------BOTON IPP-----------------
        private void Btn_Ipp_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Ipp IppForm = new Ipp();

            // Mostrar el formulario
            IppForm.Show();
        }

        //-------------BOTON CONTRAVENCIONES------------
        private void Btn_Contravenciones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Contravenciones ContravencionesForm = new Contravenciones();

            // Mostrar el formulario
            ContravencionesForm.Show();
        }

        //----------------BOTON EXPEDIENTES-----------
        private void Btn_Expedientes_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Expedientes ExpedientesForm = new Expedientes();

            // Mostrar el formulario
            ExpedientesForm.Show();
        }

        //-----------BOTON LEGAJO DETENIDOS-----------
        private void Btn_LegajoDetenidos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            LegajoDetenidos LegajoDetenidosForm = new LegajoDetenidos();

            // Mostrar el formulario
            LegajoDetenidosForm.Show();
        }

        //-----------BOTON LEGAJO AUTOMOTOR-----------
        private void Btn_LegajoAutomotor_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            LegajoAutomotor LegajoAutomotorForm = new LegajoAutomotor();

            // Mostrar el formulario
            LegajoAutomotorForm.Show();
        }

        //---------BOTON DENUNCIAS-------------
        private void Btn_Denuncias_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Denuncias DenunciasForm = new Denuncias();

            // Mostrar el formulario
            DenunciasForm.Show();
        }

        //---------BOTON NOTAS------------------
        private void Btn_Notas_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Notas NotasForm = new Notas();

            // Mostrar el formulario
            NotasForm.Show();
        }

        //----------BOTON INSPECCIONES-------------
        private void Btn_Inspecciones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario a abrir
            Inspecciones InspeccionesForm = new Inspecciones();

            // Mostrar el formulario
            InspeccionesForm.Show();
        }

        //------------BOTON CAMBIAR TEMA------------
        private void Btn_CambiarTema_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de alerta PROVISORIO HASTA QUE SE DESARROLLE COMPLETO
            MessageBox.Show("Este botón está en desarrollo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
