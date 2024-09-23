using System;
using System.Drawing;
using System.Windows.Forms;

public class PlaceholderComboBox : ComboBox
{
    private string placeholderText = "Placeholder";
    private Color placeholderColor = Color.Gray;

    public string PlaceholderText
    {
        get { return placeholderText; }
        set { placeholderText = value; Invalidate(); }
    }

    public Color PlaceholderColor
    {
        get { return placeholderColor; }
        set { placeholderColor = value; Invalidate(); }
    }

    public PlaceholderComboBox()
    {
        this.DrawMode = DrawMode.OwnerDrawFixed;
        this.DropDownStyle = ComboBoxStyle.DropDown;
        this.ForeColor = placeholderColor;
        this.Text = placeholderText;
        this.Enter += PlaceholderComboBox_Enter;
        this.Leave += PlaceholderComboBox_Leave;
        this.DrawItem += PlaceholderComboBox_DrawItem;
    }

    private void PlaceholderComboBox_Enter(object sender, EventArgs e)
    {
        if (Text == placeholderText)
        {
            Text = "";
            ForeColor = SystemColors.WindowText;
        }
    }

    private void PlaceholderComboBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Text))
        {
            Text = placeholderText;
            ForeColor = placeholderColor;
        }
    }

    private void PlaceholderComboBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        if (e.Index >= 0)
        {
            string itemText = Items[e.Index].ToString();
            using (var brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
            }
        }
        e.DrawFocusRectangle();
    }
}
