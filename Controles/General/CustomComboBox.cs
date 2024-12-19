using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ofelia_Sara.Properties;
using System.IO;
namespace Ofelia_Sara.Controles.General
{
    //    public class CustomComboBox : Control
    //    {
    //        private TextBox textBox;
    //        private PictureBox arrowPictureBox;
    //        private ListBox dropdownList;
    //        private Timer animationTimer;
    //        private int animationProgress;
    //        private bool isFocused;
    //        private bool showError;
    //        private Color focusColor = Color.Blue;
    //        private Color errorColor = Color.Red;

    //        public event EventHandler SelectedIndexChanged;

    //        public CustomComboBox()
    //        {
    //            // Configuración del TextBox
    //            textBox = new TextBox
    //            {
    //                BorderStyle = BorderStyle.None,
    //                Dock = DockStyle.Fill, // O ajusta manualmente el tamaño y posición

    //                BackColor = Color.GreenYellow,
    //                TextAlign = HorizontalAlignment.Center, // Alineación horizontal centrada

    //            };


    //            textBox.GotFocus += TextBox_GotFocus;
    //            textBox.LostFocus += TextBox_LostFocus;
    //            textBox.TextChanged += TextBox_TextChanged;
    //            Controls.Add(textBox);

    //            // Configuración del PictureBox (flecha)
    //            arrowPictureBox = new PictureBox
    //            {
    //                Size = new Size(20, this.Height),
    //                Dock = DockStyle.Right,
    //                Cursor = Cursors.Hand,
    //                BackColor = Color.White
    //            };
    //            arrowPictureBox.Click += ArrowPictureBox_Click;
    //            Controls.Add(arrowPictureBox);

    //            // Configuración del ListBox (desplegable)
    //            dropdownList = new ListBox
    //            {
    //                Visible = false,
    //                BackColor = Color.FromArgb(240, 240, 240),
    //                ForeColor = Color.Black,
    //                BorderStyle = BorderStyle.FixedSingle
    //            };
    //            dropdownList.SelectedIndexChanged += DropdownList_SelectedIndexChanged;
    //            dropdownList.MouseClick += DropdownList_MouseClick;
    //            Controls.Add(dropdownList);

    //            // Configuración del Timer para animaciones
    //            animationTimer = new Timer { Interval = 15 };
    //            animationTimer.Tick += AnimationTimer_Tick;

    //            // Estilo inicial
    //            this.Height = 30;
    //            this.Width = 200;
    //            this.BackColor = Color.White;
    //        }

    //        private void TextBox_GotFocus(object sender, EventArgs e)
    //        {
    //            isFocused = true;
    //            showError = false;
    //            animationProgress = 0;
    //            animationTimer.Start();
    //        }

    //        private void TextBox_LostFocus(object sender, EventArgs e)
    //        {
    //            isFocused = false;
    //            animationProgress = 0;
    //            animationTimer.Start();
    //            dropdownList.Visible = false;
    //        }

    //        private void TextBox_TextChanged(object sender, EventArgs e)
    //        {
    //            OnTextChanged(e);
    //        }

    //        private void ArrowPictureBox_Click(object sender, EventArgs e)
    //        {
    //            dropdownList.Location = new Point(this.Left, this.Bottom);
    //            dropdownList.Width = this.Width;
    //            dropdownList.Visible = !dropdownList.Visible;
    //        }

    //        private void DropdownList_MouseClick(object sender, MouseEventArgs e)
    //        {
    //            if (dropdownList.SelectedItem != null)
    //            {
    //                textBox.Text = dropdownList.SelectedItem.ToString();
    //                dropdownList.Visible = false;
    //            }
    //        }

    //        private void DropdownList_SelectedIndexChanged(object sender, EventArgs e)
    //        {
    //            SelectedIndexChanged?.Invoke(this, e);
    //        }

    //        private void AnimationTimer_Tick(object sender, EventArgs e)
    //        {
    //            animationProgress = Math.Min(animationProgress + 5, 100);
    //            this.Invalidate();
    //            if (animationProgress == 100) animationTimer.Stop();
    //        }

    //        protected override void OnPaint(PaintEventArgs e)
    //        {
    //            base.OnPaint(e);
    //            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //            using (Brush brush = new SolidBrush(isFocused ? focusColor : (showError ? errorColor : this.BackColor)))
    //            {
    //                int lineWidth = 3;
    //                float progress = animationProgress / 100f;
    //                int startX = (int)(this.Width / 2 - (this.Width / 2) * progress);
    //                int endX = (int)(this.Width / 2 + (this.Width / 2) * progress);
    //                e.Graphics.FillRectangle(brush, startX, this.Height - lineWidth, endX - startX, lineWidth);
    //            }
    //        }

    //        // Propiedades Públicas
    //        public ListBox.ObjectCollection Items => dropdownList.Items;

    //        // Propiedad para DataSource
    //        public object DataSource
    //        {
    //            get => dropdownList.DataSource;
    //            set => dropdownList.DataSource = value;
    //        }

    //        public object SelectedItem
    //        {
    //            get => dropdownList.SelectedItem;
    //            set
    //            {
    //                dropdownList.SelectedItem = value;
    //                textBox.Text = value?.ToString();
    //            }
    //        }

    //        public int SelectedIndex
    //        {
    //            get => dropdownList.SelectedIndex;
    //            set
    //            {
    //                dropdownList.SelectedIndex = value;
    //                textBox.Text = dropdownList.SelectedItem?.ToString();
    //            }
    //        }
    //        // Propiedad pública para acceder al TextBox interno
    //        public TextBox InnerTextBox => textBox;

    //        // Ahora puedes acceder a las propiedades de TextBox, por ejemplo:
    //        public int SelectionStart
    //        {
    //            get => textBox.SelectionStart;
    //            set => textBox.SelectionStart = value;
    //        }

    //        public string SelectedText
    //        {
    //            get => textBox.SelectedText;
    //            set => textBox.SelectedText = value;
    //        }


    //        public bool ShowError
    //        {
    //            get => showError;
    //            set
    //            {
    //                showError = value;
    //                this.Invalidate();
    //            }
    //        }

    //        public Image ArrowImage
    //        {
    //            get => arrowPictureBox.Image;
    //            set => arrowPictureBox.Image = value;
    //        }

    //        public Color FocusColor
    //        {
    //            get => focusColor;
    //            set => focusColor = value;
    //        }

    //        public Color ErrorColor
    //        {
    //            get => errorColor;
    //            set => errorColor = value;
    //        }



    //        public AutoCompleteStringCollection AutoCompleteCustomSource
    //        {
    //            get => textBox.AutoCompleteCustomSource;
    //            set => textBox.AutoCompleteCustomSource = value;
    //        }

    //        public AutoCompleteMode AutoCompleteMode
    //        {
    //            get => textBox.AutoCompleteMode;
    //            set => textBox.AutoCompleteMode = value;
    //        }

    //        //public AutoCompleteSource AutoCompleteSource
    //        //{
    //        //    get => textBox.AutoCompleteSource;
    //        //    set => textBox.AutoCompleteSource = value;
    //        //}


    //        private ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDown; // Valor predeterminado

    //        public ComboBoxStyle DropDownStyle
    //        {
    //            get => dropDownStyle;
    //            set
    //            {
    //                dropDownStyle = value;
    //                if (dropDownStyle == ComboBoxStyle.DropDownList)
    //                {
    //                    textBox.ReadOnly = true; // Deshabilita la edición del TextBox
    //                    textBox.Cursor = Cursors.Default; // Cambia el cursor
    //                    textBox.BackColor = SystemColors.Control; // Fondo gris como DropDownList
    //                }
    //                else
    //                {
    //                    textBox.ReadOnly = false;
    //                    textBox.Cursor = Cursors.IBeam;
    //                    textBox.BackColor = Color.White; // Fondo editable
    //                }
    //            }
    //        }




    //        private string displayMember;



    //        // Propiedad DisplayMember
    //        public string DisplayMember
    //        {
    //            get => displayMember;
    //            set
    //            {
    //                displayMember = value;
    //                dropdownList.DisplayMember = displayMember; // Configurar el miembro de visualización
    //            }
    //        }



    //        private int maxDropDownItems = 10;

    //        public int MaxDropDownItems
    //        {
    //            get => maxDropDownItems;
    //            set
    //            {
    //                if (value > 0)
    //                {
    //                    maxDropDownItems = value;
    //                    AjustarAlturaDesplegable();
    //                }
    //            }
    //        }

    //        private void AjustarAlturaDesplegable()
    //        {
    //            // Ajustar la altura del ListBox para mostrar el número deseado de ítems
    //            int itemHeight = dropdownList.ItemHeight;
    //            dropdownList.Height = itemHeight * maxDropDownItems + 2; // +2 para el borde
    //        }


    //        public int DropDownHeight
    //        {
    //            get => dropdownList.Height; // Obtener la altura actual del desplegable
    //            set
    //            {
    //                if (value > 0)
    //                {
    //                    dropdownList.Height = value; // Ajustar la altura del ListBox
    //                }
    //            }
    //        }


    //        public bool DroppedDown
    //        {
    //            get => dropdownList.Visible; // Retorna si el desplegable está visible
    //            set
    //            {
    //                dropdownList.Visible = value; // Configura la visibilidad del desplegable
    //                if (value) // Si se debe mostrar
    //                {
    //                    dropdownList.Location = new Point(this.Left, this.Bottom);
    //                    dropdownList.Width = this.Width;
    //                    dropdownList.BringToFront(); // Asegura que esté delante de otros controles
    //                }
    //            }
    //        }

    //    }
    //}
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
       

        public event EventHandler SelectedIndexChanged;

        public CustomComboBox()
        {
            // Configuración del TextBox
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Color.GreenYellow,
                TextAlign = HorizontalAlignment.Center,
            };

            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            textBox.TextChanged += TextBox_TextChanged;
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
            Controls.Add(arrowPictureBox);

            // Configuración del ListBox (desplegable)
            dropdownList = new ListBox
            {
                Visible = false,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            dropdownList.SelectedIndexChanged += DropdownList_SelectedIndexChanged;
            dropdownList.MouseClick += DropdownList_MouseClick;
            Controls.Add(dropdownList);

            // Configuración del Timer para animaciones
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            // Estilo inicial
            this.Height = 30;
            this.Width = 200;
            this.BackColor = Color.White;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            isFocused = true;
            showError = false;
            animationProgress = 0;
            animationTimer.Start();
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            isFocused = false;
            animationProgress = 0;
            animationTimer.Start();
            dropdownList.Visible = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        private void ArrowPictureBox_Click(object sender, EventArgs e)
        {
            // Cambiar la imagen al presionar
            arrowPictureBox.Image = pressedImage;

            dropdownList.Location = new Point(this.Left, this.Bottom);
            dropdownList.Width = this.Width;
            dropdownList.Visible = !dropdownList.Visible;

            // Restablecer la imagen después de 200 ms
            var resetTimer = new Timer { Interval = 200 };
            resetTimer.Tick += (s, args) =>
            {
                arrowPictureBox.Image = defaultImage;
                resetTimer.Stop();
                resetTimer.Dispose();
            };
            resetTimer.Start();
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

        //public AutoCompleteSource AutoCompleteSource
        //{
        //    get => textBox.AutoCompleteSource;
        //    set => textBox.AutoCompleteSource = value;
        //}


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
    }
}
