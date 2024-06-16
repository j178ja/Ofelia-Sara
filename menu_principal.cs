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
        public MenuPrincipal()
        {
            InitializeComponent();
            //inicializar el evento click sobre la imagen
            pictureBox1.Click += new EventHandler(Btn_Configuracion_Click);
            pictureBox1.Click += new EventHandler(Btn_CambiarTema_Click); 

        }

        private void MenuPrincipalLoad(object sender, EventArgs e)
        {

        }

        private void Btn_Configuracion(object sender, EventArgs e)
        {
            // Mostrar un mensaje de alerta PROVISORIO HASTA QUE SE DESARROLLE COMPLETO
            MessageBox.Show("Este botón esta en desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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

        private void Btn_CambiarTema_Click(object sender, EventArgs e)
        {
                // Mostrar un mensaje de alerta PROVISORIO HASTA QUE SE DESARROLLE COMPLETO
                MessageBox.Show("Este botón esta en desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
