using BaseDatos.Mensaje;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles
{
    public partial class Boton_Contador : UserControl
    {
        private Button btnContador;
        private ContextMenuStrip listaDesplegable;

        public Boton_Contador()
        {
            InitializeComponent();
            CrearControles();

            this.Text = "0"; // Inicializar el texto del botón en "0"
            ActualizarColorTexto(); // Actualizar el color del texto en función de su valor
        }

        // Propiedad pública para acceder al botón desde el formulario
        public Button BtnContador => btnContador;

        /// <summary>
        /// Permite modificar el contenido de texto desde diferentes formularios y actualiza el color del texto
        /// </summary>
        public new string Text
        {
            get => btnContador.Text;
            set
            {
                btnContador.Text = value;
                ActualizarColorTexto();
            }
        }

        /// <summary>
        /// Crear controles iniciales
        /// </summary>
        private void CrearControles()
        {
            // Inicializar el botón
            btnContador = new Button
            {
                Size = new Size(21, 21),
               // Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
               
                Text = "0",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(0, 154, 174),
               
                Cursor = Cursors.Hand
            };

            btnContador.Click += BtnContador_Click;
            Controls.Add(btnContador);

            // Crear el ContextMenuStrip
            listaDesplegable = new ContextMenuStrip
            {
                Renderer = new CustomRenderer()
            };
        }

        /// <summary>
        /// Cargar elementos dinámicamente en el menú desplegable
        /// </summary>
        /// <param name="elementos">Lista de elementos a mostrar</param>
        public void CargarElementos(List<string> elementos)
        {
            listaDesplegable.Items.Clear(); // Limpiar lista previa

            foreach (var item in elementos)
            {
                var menuItem = CrearMenuItem(item);
                listaDesplegable.Items.Add(menuItem);
            }
        }

        /// <summary>
        /// Crear un ToolStripMenuItem personalizado
        /// </summary>
        private ToolStripMenuItem CrearMenuItem(string item)
        {
            var menuItem = new ToolStripMenuItem(item)
            {
                BackColor = Color.FromArgb(178, 213, 230),
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Image = Properties.Resources.ICOes
            };

            // Eventos de hover
            menuItem.MouseHover += (s, e) => menuItem.BackColor = Color.FromArgb(81, 169, 251);
            menuItem.MouseLeave += (s, e) => menuItem.BackColor = Color.FromArgb(178, 213, 230);

            // Ícono de eliminación
            var iconoEliminar = new ToolStripMenuItem
            {
                Image = Properties.Resources.eliminarUsuario,
                Alignment = ToolStripItemAlignment.Right
            };

            iconoEliminar.Click += (s, e) => MostrarMensajeEliminacion(menuItem, item);
            menuItem.DropDownItems.Add(iconoEliminar);

            return menuItem;
        }

        /// <summary>
        /// Mostrar un mensaje de confirmación para eliminar un elemento
        /// </summary>
        private void MostrarMensajeEliminacion(ToolStripMenuItem menuItem, string item)
        {
            using (var mensaje = new MensajeGeneral(
                $"¿Desea eliminar: {item} de la lista de Ratificaciones testimoniales?",
                MensajeGeneral.TipoMensaje.Advertencia))
            {
                mensaje.MostrarBotonesConfirmacion(true);
                if (mensaje.ShowDialog() == DialogResult.OK)
                {
                    listaDesplegable.Items.Remove(menuItem);
                    this.Text = listaDesplegable.Items.Count.ToString();
                }
            }
        }

        /// <summary>
        /// Evento de clic del botón principal
        /// </summary>
        private void BtnContador_Click(object sender, EventArgs e)
        {
            listaDesplegable.Show(btnContador, new Point(0, btnContador.Height));
        }

        /// <summary>
        /// Actualizar el color del texto del botón según su valor
        /// </summary>
        public void ActualizarColorTexto()
        {
            btnContador.ForeColor = btnContador.Text == "0" ? Color.Crimson : Color.White;
        }

        /// <summary>
        /// Renderer personalizado para el ContextMenuStrip
        /// </summary>
        private class CustomRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(178, 213, 230)), e.Item.Bounds);
                base.OnRenderMenuItemBackground(e);
            }
        }
    }
}

