


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

using System.Windows.Forms;

namespace Ofelia_Sara.Controles.General
{

    public class CustomComboBox : Control
    {
        #region VARIABLES
        private TextBox textBox;
        private PictureBox arrowPictureBox;
        private ListBox dropdownList;
        private Timer animationTimer;
        private int animationProgress;
        private bool isFocused;
        private bool showError;
        private Color focusColor = Color.Blue;
        private Color errorColor = Color.Red;
        private Image defaultImage = Properties.Resources.Flecha_Triangulo; // Imagen predeterminada
        private Image pressedImage = Properties.Resources.flechaG_Verde; // Imagen cuando se presiona
        private Image disabledImage = Properties.Resources.flechaG_Roja; // Imagen cuando está deshabilitado
        private string placeholderText = " ";//para que no se muestre placeholder y se asigne en cada control especifico
        private Color placeholderColor = Color.Gray;
        private Color defaultTextColor = Color.Black;
        private bool isPlaceholderActive = true;
        private bool isPlaceholderVisible = false; // Bandera para saber si el placeholder está visible
        public event EventHandler SelectedIndexChanged;
        private static CustomComboBox activeComboBox; // para guardar el comboBox activo
        private int hoveredIndex = -1; // Índice del elemento bajo el cursor
        private  Color subrayadoColor = Color.Blue; // Color del subrayado
        private Dictionary<int, int> subrayadoAncho = new(); // Guarda la animación por índice
        private Timer animTimer;
       
        #endregion

        #region CONSTRUCTOR
        public CustomComboBox()
        {
            // Configuración del TextBox
            textBox = new TextBox
            {
                Size = new Size(21, this.Height),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                TextAlign = HorizontalAlignment.Center,
                ForeColor = placeholderColor, // Inicia con el color del placeholder
                Text = placeholderText // Inicializa con el texto del placeholder /se puede editar en forma especifica segun el control
            };

            // agregar metodos al textbox
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.MouseEnter += TextBox_MouseEnter;
            textBox.MouseLeave += TextBox_MouseLeave;

            Controls.Add(textBox);

            // Configuración del PictureBox (flecha)
            arrowPictureBox = new PictureBox
            {
                Size = new Size(21, this.Height),
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                Image = defaultImage, // Imagen predeterminada "triangulo"
                SizeMode = PictureBoxSizeMode.CenterImage,
            };
            // Manejar los eventos de clic
            arrowPictureBox.Click += ArrowPictureBox_Click;//mostrar listado en el click
            arrowPictureBox.MouseDown += ArrowPictureBox_MouseDown; //cambiar imagen al presionar
            arrowPictureBox.MouseUp += ArrowPictureBox_MouseUp; //cambiar imagen al soltar
            Controls.Add(arrowPictureBox);

            // Configuración del ListBox (desplegable)
            dropdownList = new ListBox
            {
                Visible = false,
                BackColor = Color.FromArgb(165, 224, 247),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand,
          
            };
            dropdownList.SelectedIndexChanged += DropdownList_SelectedIndexChanged;
            dropdownList.MouseClick += DropdownList_MouseClick;//para seleccionar el item
            // Estilo adicional
            dropdownList.DrawMode = DrawMode.OwnerDrawFixed; // Activar dibujo personalizado
            dropdownList.DrawItem += DropdownList_DrawItem;

            // Agregar evento de redibujado para bordes personalizados
        
            dropdownList.MouseMove += DropdownList_MouseMove;
            dropdownList.MouseLeave += DropdownList_MouseLeave;
            Controls.Add(dropdownList);

            // Configuración del Timer para animaciones
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            // Estilo inicial
            this.Height = 30;
            this.Width = 200;
            this.BackColor = Color.White;
            dropdownList.LostFocus += DropdownList_LostFocus;

        }
        #endregion

        #region LISTA


        private void DropdownList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool isSelected = (e.State & DrawItemState.Selected) != 0;
            bool isHovered = (e.Index == hoveredIndex);

            // Configuración de colores
            Color backgroundColor = isSelected
                ? Color.LightBlue
                : isHovered
                    ? Color.FromArgb(0, 154, 174)
                    : dropdownList.BackColor;

            Color textColor = isHovered ? Color.White : dropdownList.ForeColor;
            Font textFont = isHovered ? new Font(dropdownList.Font, FontStyle.Bold) : dropdownList.Font;

            // Dibujar fondo
            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Dibujar texto con alineación adecuada
            string itemText = dropdownList.Items[e.Index].ToString();
            using (Brush textBrush = new SolidBrush(textColor))
            {
                StringFormat format = new()
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                };

                Rectangle textBounds = new(e.Bounds.Left + 5, e.Bounds.Top, e.Bounds.Width , e.Bounds.Height); // el texto interno levemente hacia la derecha
                e.Graphics.DrawString(itemText, textFont, textBrush, textBounds, format);
            }

            // Dibujar borde de foco si es necesario
            e.DrawFocusRectangle();

          
        }
     



        /// <summary>
        /// metodos para cambiar color al indice del droplist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropdownList_MouseMove(object sender, MouseEventArgs e)
        {
            int index = dropdownList.IndexFromPoint(e.Location);

            if (index != hoveredIndex) // Actualiza solo si el índice ha cambiado
            {
                hoveredIndex = index;
                dropdownList.Invalidate(); // Redibuja el control
            }
        }
      

        private void DropdownList_MouseLeave(object sender, EventArgs e)
        {
            hoveredIndex = -1; // Resetea el índice hover
            dropdownList.Invalidate(); // Redibuja el control
        }
        private void DropdownList_LostFocus(object sender, EventArgs e)
        {
            OcultarDropdown();

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                showError = true; // Mostrar subrayado rojo
                Invalidate(); // Redibujar el control
            }
        }

        /// <summary>
        /// OCULTAR LISTA
        /// </summary>
        private void OcultarDropdown()
        {
            if (!dropdownList.Visible) return;

            dropdownList.Visible = false;
            activeComboBox = null;
            Form parentForm = FindForm();
            if (parentForm != null)
            {
                // Eliminar la suscripción al evento MouseDown
                parentForm.MouseDown -= ParentForm_ClickOutside;
            }

            // Validar si no hay texto ni un elemento seleccionado
            if (string.IsNullOrWhiteSpace(textBox.Text) && dropdownList.SelectedItem == null)
            {
                showError = true; // Mostrar subrayado rojo
                animationProgress = 0; // Reiniciar animación
                animationTimer.Start();
            }
            else
            {
                showError = false; // No hay error
                animationProgress = 100;
                animationTimer.Stop();
            }

            Invalidate(); // Redibujar
        }

        /// <summary>
        /// MOSTRAR LISTA
        /// </summary>
        private void MostrarDropdown()
        {
            if (dropdownList.Visible) return;

            dropdownList.Visible = true;
           AjustarAlturaDesplegable();
            dropdownList.BringToFront();
            activeComboBox = this;

            Form parentForm = FindForm();
            if (parentForm != null)
            {
                // Registrar el evento MouseDown del formulario
                parentForm.MouseDown -= ParentForm_ClickOutside; // Evitar duplicados
                parentForm.MouseDown += ParentForm_ClickOutside;
            }

            isFocused = true;
            animationProgress = 0;
            animationTimer.Start();

            // Registrar eventos globales en el formulario
            RegistrarEventosGlobales();
        }
        private void DropdownList_MouseClick(object sender, MouseEventArgs e)
        {
            if (dropdownList.SelectedItem != null)
            {
                textBox.Text = dropdownList.SelectedItem.ToString();
                dropdownList.Visible = false;

                isFocused = false;
                showError = false; // Quitar error al seleccionar un ítem
                animationProgress = 100; // Completar la animación
                animationTimer.Stop();

                Invalidate(); // Redibujar
            }
        }
        private void DropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
             SelectedIndexChanged?.Invoke(this, e);
            if (dropdownList.SelectedItem != null)
            {
                textBox.Text = dropdownList.SelectedItem.ToString();
                showError = false; // Quitar subrayado rojo
                isFocused = false; // Desactivar el estado de foco
                animationProgress = 100; // Completar la animación
                animationTimer.Stop();

                Invalidate(); // Redibujar el control
            }

            SelectedIndexChanged?.Invoke(this, e); // Invocar evento si es necesario
        }

   


        private void AjustarAlturaDesplegable()
        {
            int itemHeight = 23; // Altura de cada elemento en la lista
            int maxVisibleItems = maxDropDownItems;//cantidad max  item es igual a variable de max can
            int itemCount = dropdownList.Items.Count;

            dropdownList.IntegralHeight = false; // Permitir ajustes en la altura

            if (itemCount == 0)
            {
                // Limpiar y agregar mensaje de no elementos
                dropdownList.Items.Clear();
                dropdownList.Items.Add("NO HAY ELEMENTOS A MOSTRAR");
                dropdownList.ForeColor = Color.Red;
                dropdownList.Height = itemHeight ; // Ajustar altura a un solo ítem
                dropdownList.Enabled = false;
                return;
            }

            // Si hay elementos, restablecer valores
            dropdownList.Enabled = true;
            dropdownList.ForeColor = Color.Black;
            dropdownList.Visible = true;

            // Ajustar la altura del desplegable
            if (itemCount <= maxDropDownItems)
            {
                dropdownList.Height = (itemHeight * itemCount) ;
                dropdownList.ScrollAlwaysVisible = false;
            }
            else
            {
                dropdownList.Height = (itemHeight * maxDropDownItems) ;
                dropdownList.ScrollAlwaysVisible = true;
            }

            // Forzar actualización del control para reflejar cambios
            dropdownList.Parent = this.Parent;
            dropdownList.Top = this.Bottom;
            dropdownList.Left = this.Left;
            dropdownList.BringToFront();
       
            dropdownList.Invalidate();
            Application.DoEvents();  // Forzar a que el control se actualice
        }



        #endregion

        #region TEXTBOX

        /// <summary>
        /// METODO PARA INICIAR ANIMACION CUANDO EL TEXTBOX TIENE EL FOCO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            isFocused = true;
            showError = false;
            animationProgress = 0;
            animationTimer.Start();

            HidePlaceholder();
        }

        /// <summary>
        /// METODO PARA CUANDO EL CONTROL PIERDE EL FOCO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            isFocused = false;
            // Ocultar el placeholder si aún está visible
            if (isPlaceholderVisible)
            {
                HidePlaceholder();
            }
            // Si no hay texto y no se seleccionó un ítem, activar error
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                showError = true; // Mostrar subrayado rojo
                animationProgress = 0; // Reiniciar animación
                animationTimer.Start();
               
            }
            else
            {
                showError = false; // No hay error, detener animación si estaba activa
                animationProgress = 100;
                animationTimer.Stop();
            }
            Invalidate(); // Redibujar
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        /// <summary>
        /// Evento cuando el mouse entra en el TextBox MUESTRA PLACEHOLDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ShowPlaceholder();
            }
        }
        
        /// <summary>
        /// Evento cuando el mouse sale del TextBox OCULTA PLACEHOLDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) && !textBox.Focused)
            {
                HidePlaceholder();
            }
        }

        /// <summary>
        /// EVENTO PARA MOSTRAR PLACEHOLDER
        /// </summary>
        private void ShowPlaceholder()
        {
            // Mostrar el placeholder solo si el texto está vacío
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = placeholderColor; // Cambiar al color del placeholder
                isPlaceholderVisible = true;
            }
        }

        /// <summary>
        /// EVENTO PARA OCULTAR PLACEHOLDER
        /// </summary>
        private void HidePlaceholder()
        {
            // Solo ocultar el placeholder si está visible y el texto actual es el placeholder
            if (isPlaceholderVisible && textBox.Text == placeholderText)
            {
                textBox.Text = string.Empty; // Limpiar el texto
                textBox.ForeColor = defaultTextColor; // Cambiar el color al texto por defecto
                isPlaceholderVisible = false;
            }
        }

        /// <summary>
        /// para centrar textbox interno para que tenga pequeña separacion superior y separacion inferior permitiendo ver el subraado
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int textBoxHeight = (int)(this.Height * 0.8); // Acomoda la altura del textBox dentro del control permitiendo ver el subrayado debajo
            int verticalPadding = (this.Height - textBoxHeight) / 2; // Centrar verticalmente

            textBox.SetBounds(0, verticalPadding, this.Width - arrowPictureBox.Width, textBoxHeight);
            arrowPictureBox.SetBounds(this.Width - arrowPictureBox.Width, 0, arrowPictureBox.Width, this.Height);
        }
        #endregion

        #region IMAGEN
        private void ArrowPictureBox_Click(object sender, EventArgs e)
        {

            if (dropdownList.Visible)
            {
                dropdownList.Visible = false; // Ocultar si ya está abierto
                OcultarDropdown();
                // Quitar el foco del TextBox
                FindForm().ActiveControl = null; // Establece que ningún control tenga foco
                return;
            }
            else
            {
                
                MostrarDropdown();// Mostrar el dropdownList y posicionarlo correctamente
              
                textBox.Focus();  // Dar foco al TextBox
            }

            Form parentForm = FindForm();
            if (dropdownList.Parent != parentForm)
            {
                parentForm.Controls.Add(dropdownList);
                dropdownList.BringToFront();
            }

            // Establecer la posición y tamaño del ListBox
            Point locationOnForm = PointToScreen(Point.Empty);
            Point dropdownLocation = parentForm.PointToClient(locationOnForm);
            dropdownList.Location = new Point(dropdownLocation.X, dropdownLocation.Y + Height);// lo posiciona justo debajo del control
            dropdownList.Width = Width;

          
            //// Manejo del clic fuera del dropdown
            parentForm.MouseClick -= ParentForm_ClickOutside; // Elimina suscripciones duplicadas
            parentForm.MouseClick += ParentForm_ClickOutside; // Vuelve a suscribirse
        }
        private void ParentForm_ClickOutside(object sender, MouseEventArgs e)
        {
            Form parentForm = FindForm();
            if (parentForm == null) return;

            Point cursorPosition = parentForm.PointToClient(Cursor.Position);

            if (!dropdownList.Bounds.Contains(cursorPosition) && !Bounds.Contains(cursorPosition))
            {
                OcultarDropdown();
            }
        }

        /// <summary>
        /// METODO PARA CAMBIAR IMAGEN EN EL CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ArrowPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Cambiar la imagen cuando se presiona el botón
            arrowPictureBox.Image = pressedImage;
            Form parentForm = FindForm();
            if (dropdownList.Parent != parentForm)
            {
                parentForm.Controls.Add(dropdownList);
                dropdownList.BringToFront();
            }
        }
        private void ArrowPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Restablecer la imagen cuando se suelta el botón
            arrowPictureBox.Image = defaultImage;


        }

        #endregion

        #region ANIMACION

        /// <summary>
        /// TIMER ANIMACION DE SUBRAYADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100);// avance dinamico de la animacion de subrayado
            this.Invalidate();
            if (animationProgress == 100) animationTimer.Stop();// se detiene al finalizar 
        }

        /// <summary>
        /// ANIMACION DE SUBRRAYADO
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Establece color azul en estado de foco y rojo en error
            using (Brush brush = new SolidBrush(isFocused ? focusColor : (showError ? errorColor : this.BackColor)))
            {
                int lineWidth = 3;// ancho de linea
                float progress = animationProgress / 100f;
                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);// para que inicie desde el centro
                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
            }
        }

        #endregion

        #region EVENTOS GLOBALES
        /// <summary>
        ///  Registrar eventos globales en el formulario y sus controles
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnParentChanged(e);
            RegistrarEventosGlobales();
        }
        private void RegistrarEventosGlobales()
        {
            Form parentForm = FindForm();
            if (parentForm != null)
            {
                parentForm.MouseDown -= Global_MouseDown; // Evita duplicados
                parentForm.MouseDown += Global_MouseDown; // Registrar el evento global
            }
        }
        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Global_MouseDown;

            foreach (Control child in control.Controls)
            {
                RegistrarEventos(child);
            }
        }
        private void Global_MouseDown(object sender, MouseEventArgs e)
        {
            Form parentForm = FindForm();
            if (parentForm == null) return;

            // Obtener la posición del cursor en el formulario
            Point cursorPosition = parentForm.PointToClient(Cursor.Position);

            // Validar si el clic ocurrió fuera del CustomComboBox o su dropdownList
            if (activeComboBox == this &&
                !dropdownList.Bounds.Contains(cursorPosition) &&
                !Bounds.Contains(cursorPosition))
            {
                OcultarDropdown();
            }
        }
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new();

            // Esquinas redondeadas
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Superior izquierda
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Superior derecha
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Inferior derecha
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Inferior izquierda
            path.CloseFigure();

            return path;
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            // Cambiar la imagen según el estado habilitado/deshabilitado
            arrowPictureBox.Image = this.Enabled ? defaultImage : disabledImage;
        }
        #endregion

        #region PROPIEDADES PUBLICAS

        /// <summary>
        /// CAMBIO DE IMAGEN 
        /// </summary>
        public Image DefaultImage
        {
            get => defaultImage;
            set
            {
                defaultImage = value;
                arrowPictureBox.Image = defaultImage;
            }
        }

        public Image PressedImage
        {
            get => pressedImage;
            set => pressedImage = value;
        }

        public Image DisabledImage
        {
            get => disabledImage;
            set
            {
                disabledImage = value;
                if (!this.Enabled)
                {
                    arrowPictureBox.Image = disabledImage;
                }
            }
        }

        public PictureBox ArrowPictureBox { get; set; }
        public ListBox.ObjectCollection Items => dropdownList.Items;

        // Propiedad para DataSource
        public object DataSource
        {
            get => dropdownList.DataSource;
            set => dropdownList.DataSource = value;
        }

        public object SelectedItem
        {
            get => dropdownList.SelectedItem;
            set
            {
                dropdownList.SelectedItem = value;
                textBox.Text = value?.ToString();
            }
        }

        public int SelectedIndex
        {
            get => dropdownList.SelectedIndex;
            set
            {
                if (value >= 0 && value < dropdownList.Items.Count)
                {
                    dropdownList.SelectedIndex = value;
                    textBox.Text = dropdownList.Items[value].ToString();
                }
            }
        }


        // Propiedad pública para acceder al TextBox interno
        public TextBox InnerTextBox => textBox;

        // acceder a las propiedades de TextBox
        public int SelectionStart
        {
            get => textBox.SelectionStart;
            set => textBox.SelectionStart = value;
        }

        public string SelectedText
        {
            get => textBox.SelectedText;
            set => textBox.SelectedText = value;
        }

        public string TextValue
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        // Evento para TextChanged
        public new event EventHandler TextChanged
        {
            add => textBox.TextChanged += value;
            remove => textBox.TextChanged -= value;
        }

        public bool ShowError
        {
            get => showError;
            set
            {
                showError = value;
                this.Invalidate();
            }
        }

        public Image ArrowImage
        {
            get => arrowPictureBox.Image;
            set => arrowPictureBox.Image = value;
        }

        public Color FocusColor
        {
            get => focusColor;
            set => focusColor = value;
        }

        public Color ErrorColor
        {
            get => errorColor;
            set => errorColor = value;
        }

        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => textBox.AutoCompleteCustomSource;
            set => textBox.AutoCompleteCustomSource = value;
        }

        public AutoCompleteMode AutoCompleteMode
        {
            get => textBox.AutoCompleteMode;
            set => textBox.AutoCompleteMode = value;
        }

        public AutoCompleteSource AutoCompleteSource
        {
            get => textBox.AutoCompleteSource;
            set
            {
                // Solo permite CustomSource
                if (value == AutoCompleteSource.CustomSource)
                {
                    textBox.AutoCompleteSource = value;
                }
                else
                {
                    textBox.AutoCompleteSource = AutoCompleteSource.None; // Desactiva el autocompletado
                }
            }
        }


        // Propiedad DisplayMember
        private string displayMember;

        public string DisplayMember
        {
            get => displayMember;
            set
            {
                displayMember = value;
                dropdownList.DisplayMember = displayMember; // Configurar el miembro de visualización
            }
        }
  
        private int maxDropDownItems = 5;
        public int MaxDropDownItems
        {
            get => maxDropDownItems;
            set
            {
                if (value > 0)
                {
                    maxDropDownItems = value;
            
                }
            }
        }
     
        public int DropDownHeight
        {
            get => dropdownList.Height; // Obtener la altura actual del desplegable
            set
            {
                if (value > 0)
                {
                    dropdownList.Height = value; // Ajustar la altura del ListBox
                }
            }
        }
        public bool DroppedDown
        {
            get => dropdownList.Visible; // Retorna si el desplegable está visible
            set
            {
                dropdownList.Visible = value; // Configura la visibilidad del desplegable
                if (value) // Si se debe mostrar
                {
                    dropdownList.Location = new Point(this.Left, this.Bottom);
                    dropdownList.Width = this.Width;
                    dropdownList.BringToFront(); // Asegura que esté delante de otros controles
                }
            }
        }


        public enum CustomComboBoxStyle
        {
            DropDown,
            DropDownList
        }

        private CustomComboBoxStyle dropDownStyle = CustomComboBoxStyle.DropDown;

        public CustomComboBoxStyle DropDownStyle
        {
            get => dropDownStyle;
            set
            {
                dropDownStyle = value;
                if (dropDownStyle == CustomComboBoxStyle.DropDownList)
                {
                    // Desactiva la escritura
                    textBox.ReadOnly = true;
                    textBox.Cursor = Cursors.Default; // Cambia el cursor para reflejar que no es editable
                    textBox.BackColor = Color.White; // Fondo gris como DropDownList
                }
                else
                {
                    // Permite la escritura
                    textBox.ReadOnly = false;
                    textBox.Cursor = Cursors.IBeam; // Vuelve al cursor de texto
                    textBox.BackColor = Color.White; // Fondo editable
                }
            }
        }

        /// <summary>
        /// Propiedades públicas para configurar el placeholder
        /// </summary>
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;

                // Si el texto actual está vacío o igual al placeholder, restáuralo
                if (string.IsNullOrWhiteSpace(this.Text) || this.Text == placeholderText)
                {
                    RestorePlaceholders();
                }
            }
        }

        public Color PlaceholderColor
        {
            get => placeholderColor;
            set
            {
                placeholderColor = value;
                if (isPlaceholderVisible)
                {
                    textBox.ForeColor = placeholderColor;
                }
            }
        }

        public new event KeyPressEventHandler KeyPress
        {
            add => textBox.KeyPress += value; // textBox es el TextBox interno del CustomComboBox
            remove => textBox.KeyPress -= value;
        }
        public void RestorePlaceholders()
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                this.Text = placeholderText; // Aplica el placeholder
                this.ForeColor = Color.Gray; // Cambia el color del texto a gris
            }
        }
        public void RemovePlaceholder()
        {
            if (this.Text == placeholderText)
            {
                this.Text = string.Empty; // Limpia el texto
                this.ForeColor = Color.Black; // Cambia el color del texto a negro
            }
        }
        #endregion
    }
}
