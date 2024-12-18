using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class Boton_Contador : Control
    {
        private Button btnContador;
        private ContextMenuStrip listaDesplegable;

        public Boton_Contador()
        {
            CrearControles();
            ActualizarTamañoYColor();
           
        }

        // Propiedad 'Text' para establecer el texto del botón
        private string texto;
        public override string Text
        {
            get => texto;
            set
            {
                texto = value;
                btnContador.Text = value;
                ActualizarTamañoYColor();
            }
        }

        // Propiedad 'Visible'
        public new bool Visible
        {
            get => base.Visible;
            set
            {
                base.Visible = value;
                btnContador.Visible = value;
            }
        }

        // Propiedad 'Enabled'
        public new bool Enabled
        {
            get => base.Enabled;
            set
            {
                base.Enabled = value;
                btnContador.Enabled = value;
            }
        }

        private void CrearControles()
        {
            btnContador = new Button
            {
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(0, 154, 174),
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill
            };

            btnContador.Click += BtnContador_Click;
            Controls.Add(btnContador);

            listaDesplegable = new ContextMenuStrip
            {
                Renderer = new CustomRenderer()
            };
        }

        public void CargarElementos(List<string> elementos)
        {
            listaDesplegable.Items.Clear();
            foreach (var item in elementos)
            {
                var menuItem = CrearMenuItem(item);
                listaDesplegable.Items.Add(menuItem);
            }
        }

        private ToolStripMenuItem CrearMenuItem(string item)
        {
            var menuItem = new ToolStripMenuItem(item)
            {
                BackColor = Color.FromArgb(178, 213, 230),
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            var iconoEliminar = new ToolStripMenuItem
            {
                Image = Properties.Resources.eliminarUsuario,
                Alignment = ToolStripItemAlignment.Right
            };

            iconoEliminar.Click += (s, e) => MostrarMensajeEliminacion(menuItem, item);
            menuItem.DropDownItems.Add(iconoEliminar);

            return menuItem;
        }

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

        private void BtnContador_Click(object sender, EventArgs e)
        {
            listaDesplegable.Show(btnContador, new Point(0, btnContador.Height));
        }

        private void ActualizarTamañoYColor()
        {
            if (btnContador.Text == "0")
            {
                btnContador.BackColor = Color.Crimson;
                btnContador.ForeColor = Color.White;
            }
            else
            {
                btnContador.BackColor = Color.FromArgb(0, 154, 174);
                btnContador.ForeColor = Color.White;
            }
        }

        private class CustomRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(178, 213, 230)), e.Item.Bounds);
                base.OnRenderMenuItemBackground(e);
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            // Tu lógica aquí
            ActualizarTamañoYColor();
        }


        private void Boton_Contador_Load(object sender, EventArgs e)
        {
            // Lógica de inicialización
            ActualizarTamañoYColor();
        }
    }
}





//using Ofelia_Sara.Formularios.General.Mensajes;
//using Mysqlx.Session;
//using MySqlX.XDevAPI.Common;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Ofelia_Sara.Controles.Ofl_Sara
//{
//    public partial class Boton_Contador : UserControl
//    {
//        private Button btnContador;
//        private ContextMenuStrip listaDesplegable;

//        public Boton_Contador()
//        {
//            InitializeComponent();
//            CrearControles();
//        }

//        public Button BtnContador => btnContador;

//        public new string Text
//        {
//            get => btnContador.Text;
//            set
//            {
//                btnContador.Text = value;

//                ActualizarTamañoYColor();

//            }
//        }

//        private void CrearControles()
//        {
//            btnContador = new Button
//            {
//                FlatStyle = FlatStyle.Flat,
//                TextAlign = ContentAlignment.MiddleCenter,
//                BackColor = Color.FromArgb(0, 154, 174),
//                Cursor = Cursors.Hand
//            };

//            btnContador.Click += BtnContador_Click;
//            Controls.Add(btnContador);

//            listaDesplegable = new ContextMenuStrip
//            {
//                Renderer = new CustomRenderer()
//            };
//        }

//        public void CargarElementos(List<string> elementos)
//        {
//            listaDesplegable.Items.Clear();
//            foreach (var item in elementos)
//            {
//                var menuItem = CrearMenuItem(item);
//                listaDesplegable.Items.Add(menuItem);
//            }
//        }

//        private ToolStripMenuItem CrearMenuItem(string item)
//        {
//            var menuItem = new ToolStripMenuItem(item)
//            {
//                BackColor = Color.FromArgb(178, 213, 230),
//                ForeColor = Color.Black,
//                Font = new Font("Arial", 10, FontStyle.Bold),
//                Image = Properties.Resources.EscudoPolicia_PNG
//            };

//            menuItem.MouseHover += (s, e) => menuItem.BackColor = Color.FromArgb(81, 169, 251);
//            menuItem.MouseLeave += (s, e) => menuItem.BackColor = Color.FromArgb(178, 213, 230);

//            var iconoEliminar = new ToolStripMenuItem
//            {
//                Image = Properties.Resources.eliminarUsuario,
//                Alignment = ToolStripItemAlignment.Right
//            };

//            iconoEliminar.Click += (s, e) => MostrarMensajeEliminacion(menuItem, item);
//            menuItem.DropDownItems.Add(iconoEliminar);

//            return menuItem;
//        }

//        private void MostrarMensajeEliminacion(ToolStripMenuItem menuItem, string item)
//        {
//            using (var mensaje = new MensajeGeneral(
//                $"¿Desea eliminar: {item} de la lista de Ratificaciones testimoniales?",
//                MensajeGeneral.TipoMensaje.Advertencia))
//            {
//                mensaje.MostrarBotonesConfirmacion(true);
//                if (mensaje.ShowDialog() == DialogResult.OK)
//                {
//                    listaDesplegable.Items.Remove(menuItem);
//                    this.Text = listaDesplegable.Items.Count.ToString();
//                }
//            }
//        }

//        private void BtnContador_Click(object sender, EventArgs e)
//        {
//            listaDesplegable.Show(btnContador, new Point(0, btnContador.Height));
//        }

//        private void ActualizarTamañoYColor()
//        {
//            Cambiar el color del fondo según el valor del texto
//            if (btnContador.Text == "0")
//            {
//                btnContador.BackColor = Color.Crimson;
//                btnContador.ForeColor = Color.White;
//            }
//            else
//            {
//                btnContador.BackColor = Color.FromArgb(0, 154, 174);
//                btnContador.ForeColor = Color.White;
//            }

//            Medir el ancho necesario para el texto
//            using (Graphics g = btnContador.CreateGraphics())
//            {
//                SizeF textSize = g.MeasureString(btnContador.Text, btnContador.Font);
//                int newWidth = Math.Max(21, (int)textSize.Width + 10); // Ancho mínimo de 21 px más margen

//                Si el texto excede el tamaño mínimo, expandir el botón hacia la izquierda
//                int offset = newWidth - btnContador.Width;

//                if (offset > 0)
//                {
//                    btnContador.Width = newWidth;
//                    btnContador.Left -= offset;

//                    Ajustar el tamaño del UserControl para que coincida con el botón
//                    this.Size = new Size(btnContador.Width, btnContador.Height);
//                }
//            }
//        }



//        private class CustomRenderer : ToolStripProfessionalRenderer
//        {
//            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
//            {
//                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(178, 213, 230)), e.Item.Bounds);
//                base.OnRenderMenuItemBackground(e);
//            }
//        }

//        private void Boton_Contador_Load(object sender, EventArgs e)
//        {
//            ActualizarTamañoYColor();
//        }
//    }
//}