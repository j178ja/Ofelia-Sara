using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
    public partial class CustomDateTextBox : UserControl
    {
        public CustomDateTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Lógica para formatear y validar la entrada del TextBox
        }

        private void buttonCalendar_Click(object sender, EventArgs e)
        {
            using (var calendarForm = new CalendarForm())
            {
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = calendarForm.SelectedDate.ToShortDateString();
                }
            }
        }

    }
}
