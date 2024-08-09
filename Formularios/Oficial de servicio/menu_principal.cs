using Ofelia_Sara.general.clases;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using Ofelia_Sara.general.clases.Botones;
using Ofelia_Sara.Formularios.Oficial_de_servicio;
using Ofelia_Sara.general.clases.Apariencia_General;

namespace Ofelia_Sara
{
    public partial class MenuPrincipal : BaseForm
    {
       
        private ContextMenuStrip contextMenu;
        private AuxiliarConfiguracion auxiliarConfiguracion;


        public MenuPrincipal()
        {
            InitializeComponent();
            auxiliarConfiguracion = new AuxiliarConfiguracion();

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Configurar el botón para usar el menú de contexto
            btn_Configurar.ContextMenuStrip = auxiliarConfiguracion.CrearMenuConfigurar();

            //Para incrementar el tamaño de btn_configuracion y btn_CambiarTema
            IncrementarTamaño.Incrementar(btn_Configurar);
            IncrementarTamaño.Incrementar(btn_CambiarTema);
        }
        //--------------------------------------------------------------------------------
    
        

        //------------BOTON CONFIGURAR--------------------------------------------------
        private void btn_Configurar_Click(object sender, EventArgs e)
        {
            // Mostrar el ContextMenuStrip en la posición del botón
            Point botonPosicion = btn_Configurar.PointToScreen(Point.Empty);
            btn_Configurar.ContextMenuStrip.Show(botonPosicion);
        }


       
     

        //------BOTON CARGO--------------------------------------------
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
