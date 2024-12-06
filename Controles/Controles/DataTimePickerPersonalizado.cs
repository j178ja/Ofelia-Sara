using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Ofelia_Sara.Controles.Controles;
using Controles.Controles;
using Ofelia_Sara.Controles.Controles.Aplicadas_con_controles;

namespace Ofelia_Sara.Controles.Controles
{
    public partial class TimePickerPersonalizado : UserControl
    {
        private Button Btn_Calendario; // Botón para abrir el formulario de calendario
        private DateTime fechaSeleccionada;

        public DateTime FechaSeleccionada // o SelectedDate
        {
            get => fechaSeleccionada;
            set
            {
                fechaSeleccionada = value;
              


            }
        }

        public TimePickerPersonalizado()
        {
            InitializeComponent();
            CrearPanelDias();
            CrearPanelMeses();
            CrearPanelAños();

            //ToolTipGeneral.ShowToolTip(Btn_Calendario, " Seleccionar fecha.");
            //ToolTipGeneral.ShowToolTip(textBox_DIA, " Seleccionar DIA.");
            //ToolTipGeneral.ShowToolTip(textBox_MES, " Seleccionar MES.");
            //ToolTipGeneral.ShowToolTip(textBox_AÑO, " Seleccionar AÑO.");
        }
        /// <summary>
        /// metodo para limitar ingreso de caracteres 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Limitar_TextUpdate(object sender, EventArgs e)
        {
            if (textBox_DIA.Text.Length > 2)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                textBox_DIA.Text = textBox_DIA.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                textBox_DIA.SelectionStart = textBox_DIA.Text.Length;
            }
            if (textBox_AÑO.Text.Length > 4)
            {
                // Si el texto excede los 2 caracteres, cortar el exceso
                textBox_AÑO.Text = textBox_AÑO.Text.Substring(0, 2);

                // Mover el cursor al final del texto
                textBox_AÑO.SelectionStart = textBox_AÑO.Text.Length;
            }
        }
        //-------------------------------------------------------------------

        /// <summary>
        /// metodo par que acceda solo numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar el evento
                e.Handled = true;
            }
        }
        //-------------------------------------------------------------

        /// <summary>
        /// habre fomulario calendario personalizado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Calendario_Click(object sender, EventArgs e)
        {
            using (var calendarForm = new CALENDARIO())
            {
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = calendarForm.SelectedDate;

                    // Actualiza los campos con la fecha seleccionada
                    textBox_DIA.Text = selectedDate.Day.ToString("00");
                    textBox_MES.Text = selectedDate.ToString("MMMM").ToUpper(); // Mes en texto
                    textBox_AÑO.Text = selectedDate.Year.ToString();
                }

                // Detén el Timer y libera el ToolTip tras cerrar el formulario
                ToolTipGeneral.DisposeToolTips();
            }

        }
        /// <summary>
        /// metodo validacion caracteres y convertir a mayusculas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_MES_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es una letra o la tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Rechaza la entrada de caracteres no permitidos
            }
            else
            {
                // Convierte la tecla presionada a mayúsculas si es una letra
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void textBox_DIA_Click(object sender, EventArgs e)
        {
            MostrarPanel(textBox_DIA, panelDias);

        }

        private void textBox_DIA_Enter(object sender, EventArgs e)
        {
            MostrarPanel(textBox_DIA, panelDias);

        }
        private void textBox_MES_Click(object sender, EventArgs e)
        {
            MostrarPanel(textBox_MES, panelMeses);

        }

        private void textBox_MES_Enter(object sender, EventArgs e)
        {
            MostrarPanel(textBox_MES, panelMeses);
           
        }
        private void textBox_AÑO_Click(object sender, EventArgs e)
        {
            MostrarPanel(textBox_AÑO, panelAños);

        }

        private void textBox_AÑO_Enter(object sender, EventArgs e)
        {
            MostrarPanel(textBox_AÑO, panelAños);

        }

        private void MostrarPanel(Control controlPadre, Panel panel)
        {
            // Calcular la posición centrada del panel con respecto al control padre
            int posicionX = controlPadre.Left + (controlPadre.Width / 2) - (panel.Width / 2);
            int posicionY = controlPadre.Top - panel.Height - 100; // 

            // Asegurarse de que el panel esté dentro de los límites del formulario
            if (posicionX < 0) posicionX = 0;
            if (posicionY < 0) posicionY = 0;

            // Establecer la posición del panel
            panel.Location = new Point(posicionX, posicionY);

            // Mostrar el panel y llevarlo al frente
            panel.Visible = true;
            panel.BringToFront();
        }
        //--------------------------------------------------------


        private Panel panelDias;


        private void CrearPanelDias()
        {
            // Crear el panel
            panelDias = new Panel
            {
                Size = new Size(120, 120), 
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,  // Fondo blanco
                Visible = false          
            };

            // Agregar al formulario o control principal
            this.Controls.Add(panelDias);

            // Llenar el panel con los días
            LlenarDiasEnPanel();
        }

        private void LlenarDiasEnPanel()
        {
            // Limpiar cualquier control previo en el panel
            panelDias.Controls.Clear();

            int totalDias = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); // Obtener días del mes actual
            int columnas = 7; // Número de columnas (una semana)
            int filas = (int)Math.Ceiling(totalDias / (double)columnas);
            int botonAncho = panelDias.Width / columnas;
            int botonAlto = panelDias.Height / filas;

            for (int dia = 1; dia <= totalDias; dia++)
            {
                Button botonDia = new Button
                {
                    Text = dia.ToString(),
                    Size = new Size(botonAncho, botonAlto),
                    BackColor = Color.LightGray,    // Color de fondo del botón
                    FlatStyle = FlatStyle.Flat,     // Estilo plano
                    Tag = dia                       // Guardar el día en el Tag
                };

                // Calcular posición del botón en la cuadrícula
                int fila = (dia - 1) / columnas;
                int columna = (dia - 1) % columnas;
                botonDia.Location = new Point(columna * botonAncho, fila * botonAlto);

                // Evento para manejar la selección del día
                botonDia.Click += BotonDia_Click;

                // Agregar el botón al panel
                panelDias.Controls.Add(botonDia);
            }
        }
        private void BotonDia_Click(object sender, EventArgs e)
        {
            Button botonDia = sender as Button;
            if (botonDia != null)
            {
                int diaSeleccionado = (int)botonDia.Tag; // Obtener el día seleccionado
                textBox_DIA.Text = diaSeleccionado.ToString("00"); // Actualizar el campo de texto con el día
                panelDias.Visible = false; // Ocultar el panel después de la selección
            }
        }

        private Panel panelMeses;

        private void CrearPanelMeses()
        {
            // Crear el panel
            panelMeses = new Panel
            {
                Size = new Size(200, 150), // Tamaño del panel (ajustable)
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,  // Fondo blanco
                Visible = false           // Inicia como invisible
            };

            // Agregar al formulario o control principal
            this.Controls.Add(panelMeses);

            // Llenar el panel con los meses
            LlenarMesesEnPanel();
        }

        private void LlenarMesesEnPanel()
        {
            // Limpiar cualquier control previo en el panel
            panelMeses.Controls.Clear();

            string[] nombresMeses = new string[]
            {
        "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };

            int columnas = 3; // Número de columnas
            int filas = 4;    // Número de filas
            int botonAncho = panelMeses.Width / columnas;
            int botonAlto = panelMeses.Height / filas;

            for (int i = 0; i < nombresMeses.Length; i++)
            {
                Button botonMes = new Button
                {
                    Text = nombresMeses[i].ToUpper(), // Mostrar nombre en mayúsculas
                    Size = new Size(botonAncho, botonAlto),
                    BackColor = Color.LightGray,       // Color de fondo
                    FlatStyle = FlatStyle.Flat,        // Estilo plano
                    Tag = i + 1                        // Guardar el número del mes (1 a 12)
                };

                // Calcular posición del botón en la cuadrícula
                int fila = i / columnas;
                int columna = i % columnas;
                botonMes.Location = new Point(columna * botonAncho, fila * botonAlto);

                // Evento para manejar la selección del mes
                botonMes.Click += BotonMes_Click;

                // Agregar el botón al panel
                panelMeses.Controls.Add(botonMes);
            }
        }
        private void BotonMes_Click(object sender, EventArgs e)
        {
            Button botonMes = sender as Button;
            if (botonMes != null)
            {
                int mesSeleccionado = (int)botonMes.Tag; // Obtener el número del mes seleccionado
                string nombreMes = botonMes.Text;       // Obtener el nombre del mes seleccionado

                textBox_MES.Text = nombreMes;           // Actualizar el campo de texto con el nombre del mes
                panelMeses.Visible = false;            // Ocultar el panel después de la selección
            }
        }
        //--------------------------------------------------------------------------
        private Panel panelAños;
        private int añoInicio = DateTime.Now.Year - 5; // Año inicial (5 años atrás)
        private int rangoAños = 10;                   // Rango de años a mostrar

        private void CrearPanelAños()
        {
            // Crear el panel
            panelAños = new Panel
            {
                Size = new Size(100, 200), // Tamaño del panel (ajustable)
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,  // Fondo blanco
                Visible = false           // Inicia como invisible
            };

            // Agregar al formulario o control principal
            this.Controls.Add(panelAños);

            // Llenar el panel con los años
            LlenarAñosEnPanel();
        }
        private void LlenarAñosEnPanel()
        {
            // Limpiar cualquier control previo en el panel
            panelAños.Controls.Clear();

            int botonAncho = panelAños.Width;
            int botonAlto = 30; // Altura de cada botón

            for (int i = 0; i < rangoAños; i++)
            {
                int añoActual = añoInicio + i;

                Button botonAño = new Button
                {
                    Text = añoActual.ToString(),
                    Size = new Size(botonAncho, botonAlto),
                    BackColor = Color.LightGray,       // Color de fondo
                    FlatStyle = FlatStyle.Flat,        // Estilo plano
                    Tag = añoActual                   // Guardar el año en el Tag
                };

                // Calcular posición vertical del botón
                botonAño.Location = new Point(0, i * botonAlto);

                // Evento para manejar la selección del año
                botonAño.Click += BotonAño_Click;

                // Agregar el botón al panel
                panelAños.Controls.Add(botonAño);
            }
        }
        private void BotonAño_Click(object sender, EventArgs e)
        {
            Button botonAño = sender as Button;
            if (botonAño != null)
            {
                int añoSeleccionado = (int)botonAño.Tag; // Obtener el año seleccionado
                textBox_AÑO.Text = añoSeleccionado.ToString(); // Actualizar el campo de texto
                panelAños.Visible = false;              // Ocultar el panel después de la selección
            }
        }
        private void AgregarBotonesNavegacion()
        {
            // Botón para años anteriores
            Button btnAñosAnteriores = new Button
            {
                Text = "◀",
                Size = new Size(panelAños.Width / 2, 30),
                Location = new Point(0, panelAños.Height - 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnAñosAnteriores.Click += (s, e) =>
            {
                añoInicio -= rangoAños;
                LlenarAñosEnPanel();
            };
            panelAños.Controls.Add(btnAñosAnteriores);

            // Botón para años posteriores
            Button btnAñosPosteriores = new Button
            {
                Text = "▶",
                Size = new Size(panelAños.Width / 2, 30),
                Location = new Point(panelAños.Width / 2, panelAños.Height - 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnAñosPosteriores.Click += (s, e) =>
            {
                añoInicio += rangoAños;
                LlenarAñosEnPanel();
            };
            panelAños.Controls.Add(btnAñosPosteriores);
        }
        //-------------------------------------------------------------------------------------------------
        private DateTime _selectedDate = DateTime.Now;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                ActualizarCamposFecha(); // Actualiza los campos visuales con la nueva fecha
            }
        }

        private void ActualizarCamposFecha()
        {
            // Actualizar los campos de texto con la fecha seleccionada
            textBox_DIA.Text = _selectedDate.Day.ToString("00"); // Día con dos dígitos

            // Obtener el nombre del mes en texto y convertirlo a mayúsculas
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                       "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            textBox_MES.Text = meses[_selectedDate.Month - 1].ToUpper();

            textBox_AÑO.Text = _selectedDate.Year.ToString(); // Año completo
        }


    }
}