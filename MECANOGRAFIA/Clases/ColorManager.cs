using System.Windows.Forms;

public class ColorManager
{
    private RichTextBox _richTextBox;
    private int _posicionActual;

    public ColorManager(RichTextBox richTextBox)
    {
        _richTextBox = richTextBox;
        _posicionActual = 0;
    }

    public void ResaltarLetraActual()
    {
        if (_posicionActual < _richTextBox.Text.Length)
        {
            // Deselecciona el texto antes de resaltar
            _richTextBox.SelectAll();
            _richTextBox.SelectionColor = System.Drawing.Color.Black; // Color normal para el texto

            // Resaltar la letra actual
            _richTextBox.Select(_posicionActual, 1); // Selecciona solo la letra actual
            _richTextBox.SelectionColor = System.Drawing.Color.Blue; // Cambia el color a azul

            _richTextBox.DeselectAll(); // Deselecciona para evitar efectos visuales
        }
    }

    public bool VerificarLetra(KeyPressEventArgs e)
    {
        if (_posicionActual < _richTextBox.Text.Length)
        {
            char letraEsperada = _richTextBox.Text[_posicionActual];

            // Compara la letra esperada con la tecla presionada
            if (e.KeyChar == letraEsperada)
            {
                _posicionActual++; // Avanza a la siguiente letra
                return true; // Letra correcta
            }
        }
        return false; // Letra incorrecta
    }
}
