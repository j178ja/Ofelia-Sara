using Ofelia_Sara.BaseDatos.Json_generador_de_archivos;
using Ofelia_Sara.Controles.Controles.Tooltip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        private void label_NumeroArt_MouseEnter(object sender, EventArgs e)
        {
            MostrarTooltipArticulo();
        }

        private void label_NumeroArt_MouseLeave(object sender, EventArgs e)
        {
            if (tooltipForm != null && !tooltipForm.Bounds.Contains(Cursor.Position))
                tooltipForm.Close();
        }

        private TooltipArticuloForm tooltipForm;

        private void MostrarTooltipArticulo()
        {
            if (!int.TryParse(label_NumeroArt.Text, out int numero)) return;

            string ruta = Path.Combine(Application.StartupPath, "BaseDatos", "Json", "contravencion.json");
            if (!File.Exists(ruta)) return;

            string json = File.ReadAllText(ruta);
            List<Capitulos> capitulos = JsonSerializer.Deserialize<List<Capitulos>>(json);

            var resultado = capitulos
                .SelectMany(c => c.Articulos, (cap, art) => new { cap.Capitulo, art.Articulo, art.Contenido })
                .FirstOrDefault(x => x.Articulo == numero);

            if (resultado == null) return;

            string mensaje = $"Capítulo: {resultado.Capitulo}\nArtículo: {resultado.Articulo}\n\n{resultado.Contenido}";

            tooltipForm = new TooltipArticuloForm(resultado.Capitulo, resultado.Articulo, resultado.Contenido);
            Point posicion = label_NumeroArt.PointToScreen(new Point(0, label_NumeroArt.Height));
            tooltipForm.Location = posicion;
            tooltipForm.Show();
        }

    }
}
