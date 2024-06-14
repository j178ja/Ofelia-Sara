/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
   ---------------EL ICONO DE ESCUDO DE LA PROVINCIA -----------*/

using System;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
   public class IconoEscudoPolProvincia : Form
    {
        public IconoEscudoPolProvincia()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurar el icono del formulario
            this.Icon = new System.Drawing.Icon("C:/Users/Usuario/OneDrive/Escritorio/Ofelia-Sara/imagenes/ICOes.ico");
        }
    }
}

