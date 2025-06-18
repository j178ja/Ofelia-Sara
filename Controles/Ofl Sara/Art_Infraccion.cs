using Ofelia_Sara.Controles.Controles.Tooltip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class Art_Infraccion : UserControl
    {
        public event EventHandler Eliminado; //Evento para invocar el centrado de los controles al elimianr

        public Art_Infraccion()
        {
            InitializeComponent();
            ToolTipPersonalizado.Mostrar (btn_EliminarArt,"ELIMINAR ART.",ToolTipPersonalizado.TipoToolTip.Eliminar);
             }

        /// <summary>
        /// AGREGA UN NUEVO CONTROL DE INFRACCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public event EventHandler SolicitarNuevoArt;

        private void Btn_EliminarArt_Click(object sender, EventArgs e)
        {
            // Verifica que el control tenga un contenedor
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
                this.Dispose(); // opcional: para liberar recursos del control eliminado
                Eliminado?.Invoke(this, EventArgs.Empty);
            }
        }

        public string NumeroArticulo
        {
            get => label_NumeroArt.Text;
            set => label_NumeroArt.Text = value;
        }



    }
}
