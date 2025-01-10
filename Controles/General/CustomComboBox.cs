using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ofelia_Sara.Properties;
using System.IO;
namespace Ofelia_Sara.Controles.General
{
   
    public class CustomComboBox : Control
    {
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

        public CustomComboBox()
        {
            
            // Configuración del TextBox
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
              
                BackColor = Color.GreenYellow,
                TextAlign = HorizontalAlignment.Center,
                ForeColor = placeholderColor, // Inicia con el color del placeholder
                Text = placeholderText // Inicializa con el texto del placeholder

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
                Size = new Size(20, this.Height),
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                Image = defaultImage, // Imagen predeterminada
                SizeMode = PictureBoxSizeMode.CenterImage,
            };
            arrowPictureBox.Click += ArrowPictureBox_Click;
            // Manejar los eventos de clic
            arrowPictureBox.MouseDown += ArrowPictureBox_MouseDown;
            arrowPictureBox.MouseUp += ArrowPictureBox_MouseUp;
            Controls.Add(arrowPictureBox);

            // Configuración del ListBox (desplegable)
            dropdownList = new ListBox
            {
                Visible = false,
                BackColor = Color.FromArgb(165, 224, 247),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand,
                ItemHeight = 25 // Ajuste de altura de los elementos
            };
            dropdownList.SelectedIndexChanged += DropdownList_SelectedIndexChanged;
            dropdownList.MouseClick += DropdownList_MouseClick;//para seleccionar el item
            // Estilo adicional
            dropdownList.DrawMode = DrawMode.OwnerDrawFixed; // Activar dibujo personalizado
            dropdownList.DrawItem += DropdownList_DrawItem;

            // Agregar evento de redibujado para bordes personalizados
            dropdownList.Paint += DropdownList_Paint;
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
        }


        private void DropdownList_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Rectángulo del control con esquinas redondeadas
            int radius = 10; // Radio para las esquinas redondeadas
            Rectangle rect = new Rectangle(0, 0, dropdownList.Width - 1, dropdownList.Height - 1);
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, radius))
            {
                // Dibujar sombra
                using (Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    Rectangle shadowRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height);
                    g.FillPath(shadowBrush, CreateRoundedRectanglePath(shadowRect, radius));
                }

                // Dibujar fondo
                using (Brush backgroundBrush = new SolidBrush(dropdownList.BackColor))
                {
                    g.FillPath(backgroundBrush, path);
                }

                // Dibujar borde de color
                using (Pen borderPen = new Pen(Color.FromArgb(0, 154, 174), 4)) 
                {
                    g.DrawPath(borderPen, path);
                }
            }
        }


        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            // Esquinas redondeadas
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Superior izquierda
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Superior derecha
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Inferior derecha
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Inferior izquierda
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Para configurar la apariencia del item
        /// </summary>
        /// 
        private int hoveredIndex = -1; // Índice del elemento bajo el cursor

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

            // Dibujar texto
            string itemText = dropdownList.Items[e.Index].ToString();
            using (Brush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(itemText, textFont, textBrush, e.Bounds.Left + 10, e.Bounds.Top + 5);
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

        //-------------------------------------------------------

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

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            isFocused = false;
            animationProgress = 0;
            animationTimer.Start();
            dropdownList.Visible = false;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ShowPlaceholder();
            }
        }
      

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }


        // Evento cuando el mouse entra en el TextBox
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ShowPlaceholder();
            }
        }

        // Evento cuando el mouse sale del TextBox
        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) && !textBox.Focused)
            {
                HidePlaceholder();
            }
        }

        // Mostrar placeholder
        private void ShowPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = placeholderColor;
                isPlaceholderVisible = true;
            }
        }

        // Ocultar placeholder
        private void HidePlaceholder()
        {
            if (isPlaceholderVisible)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = defaultTextColor;
                isPlaceholderVisible = false;
            }
        }



     
        //------------------------------------------------------------------------------


        private void ArrowPictureBox_Click(object sender, EventArgs e)
        {
            // Asegúrate de que el dropdownList esté en el formulario principal
            Form parentForm = this.FindForm();
            if (dropdownList.Parent != parentForm)
            {
                parentForm.Controls.Add(dropdownList);
                dropdownList.BringToFront();
            }

            // Calcular la posición relativa al CustomComboBox
            Point controlLocation = this.PointToScreen(Point.Empty); // Posición global del CustomComboBox
            Point dropdownLocation = parentForm.PointToClient(controlLocation); // Ajustar al formulario principal

            // Ajustar posición para que el dropdownList aparezca debajo del CustomComboBox
            dropdownList.Location = new Point(dropdownLocation.X, dropdownLocation.Y + this.Height);

            // Configurar el ancho del dropdownList
            dropdownList.Width = this.Width - arrowPictureBox.Width;

            // Alternar visibilidad
            dropdownList.Visible = !dropdownList.Visible;

            // Manejar clics fuera del dropdownList
            if (dropdownList.Visible)
            {
                parentForm.MouseClick += ParentForm_ClickOutside;
                dropdownList.LostFocus += DropdownList_LostFocus;
            }
            else
            {
                parentForm.MouseClick -= ParentForm_ClickOutside;
                dropdownList.LostFocus -= DropdownList_LostFocus;
            }
        }



        private void ParentForm_ClickOutside(object sender, EventArgs e)
        {
            // Ocultar el dropdownList si se hace clic fuera 
            dropdownList.Visible = false;

            // Eliminar eventos para evitar múltiples registros
            Form parentForm = this.FindForm();
            parentForm.Click -= ParentForm_ClickOutside;
            dropdownList.LostFocus -= DropdownList_LostFocus;
        }




        private void DropdownList_LostFocus(object sender, EventArgs e)
        {
            // Ocultar el dropdownList al perder el foco
            dropdownList.Visible = false;

            // Eliminar eventos
            Form parentForm = this.FindForm();
            parentForm.Click -= ParentForm_ClickOutside;
            dropdownList.LostFocus -= DropdownList_LostFocus;
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
        }

        private void ArrowPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Restablecer la imagen cuando se suelta el botón
            arrowPictureBox.Image = defaultImage;

            // Mostrar u ocultar el desplegable
            dropdownList.Location = new Point(this.Left, this.Bottom);
            dropdownList.Width = this.Width;
            dropdownList.Visible = !dropdownList.Visible;
        }

        private void DropdownList_MouseClick(object sender, MouseEventArgs e)
        {
            if (dropdownList.SelectedItem != null)
            {
                textBox.Text = dropdownList.SelectedItem.ToString();
                dropdownList.Visible = false;
            }
        }

        private void DropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, e);
        }

        //-------------------------------------------------------------

        /// <summary>
        /// ANIMACION DE SUBRAYADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress = Math.Min(animationProgress + 5, 100);
            this.Invalidate();
            if (animationProgress == 100) animationTimer.Stop();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            // Cambiar la imagen según el estado habilitado/deshabilitado
            arrowPictureBox.Image = this.Enabled ? defaultImage : disabledImage;
        }


        private ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDown; // Valor predeterminado

        public ComboBoxStyle DropDownStyle
        {
            get => dropDownStyle;
            set
            {
                dropDownStyle = value;
                if (dropDownStyle == ComboBoxStyle.DropDownList)
                {
                    textBox.ReadOnly = true; // Deshabilita la edición del TextBox
                    textBox.Cursor = Cursors.Default; // Cambia el cursor
                    textBox.BackColor = SystemColors.Control; // Fondo gris como DropDownList
                   
                }
                else
                {
                    textBox.ReadOnly = false;
                    textBox.Cursor = Cursors.IBeam;
                    textBox.BackColor = Color.White; // Fondo editable
                }
            }
        }

        //-----------------------------------------------------------------------------

        // Propiedades Públicas
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

        // Propiedades Públicas
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
                dropdownList.SelectedIndex = value;
                textBox.Text = dropdownList.SelectedItem?.ToString();
            }
        }
        // Propiedad pública para acceder al TextBox interno
        public TextBox InnerTextBox => textBox;

        // Ahora puedes acceder a las propiedades de TextBox, por ejemplo:
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
            set => textBox.AutoCompleteSource = value;
        }






        private string displayMember;



        // Propiedad DisplayMember
        public string DisplayMember
        {
            get => displayMember;
            set
            {
                displayMember = value;
                dropdownList.DisplayMember = displayMember; // Configurar el miembro de visualización
            }
        }



        private int maxDropDownItems = 10;

        public int MaxDropDownItems
        {
            get => maxDropDownItems;
            set
            {
                if (value > 0)
                {
                    maxDropDownItems = value;
                    AjustarAlturaDesplegable();
                }
            }
        }

        private void AjustarAlturaDesplegable()
        {
            // Ajustar la altura del ListBox para mostrar el número deseado de ítems
            int itemHeight = dropdownList.ItemHeight;
            dropdownList.Height = itemHeight * maxDropDownItems + 2; // +2 para el borde
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

        /// <summary>
        /// ANIMACION DE SUBRRAYADO
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush brush = new SolidBrush(isFocused ? focusColor : (showError ? errorColor : this.BackColor)))
            {
                int lineWidth = 3;
                float progress = animationProgress / 100f;
                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
            }
        }

        // altura de textBox
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int textBoxHeight = (int)(this.Height * 0.5); // 90% de la altura del control
            int verticalPadding = (this.Height - textBoxHeight) / 2; // Centrar verticalmente

            textBox.SetBounds(0, verticalPadding, this.Width - arrowPictureBox.Width, textBoxHeight);
            arrowPictureBox.SetBounds(this.Width - arrowPictureBox.Width, 0, arrowPictureBox.Width, this.Height);
        }


        // Propiedades públicas para configurar el placeholder
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                if (isPlaceholderVisible)
                {
                    textBox.Text = placeholderText;
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

    }
}
