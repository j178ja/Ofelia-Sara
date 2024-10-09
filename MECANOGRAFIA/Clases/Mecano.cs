using System;
using System.Drawing;
using System.Windows.Forms;

namespace MECANOGRAFIA.Clases
{
    public class Mecano
    {
        private RichTextBox _richTextBox;
        private string _textoOriginal;
        private int _currentPosition;
        private Button[] _tecladoButtons; // Array para almacenar los botones

        public Mecano(RichTextBox richTextBox, Button[] tecladoButtons)
        {
            _richTextBox = richTextBox;
            _textoOriginal = richTextBox.Text; // Almacena el texto original
            _currentPosition = 0; // Inicializa la posición actual
            _tecladoButtons = tecladoButtons; // Inicializa los botones
        }

        public void KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if (_currentPosition < _textoOriginal.Length)
            {
                // Verifica si la tecla presionada es igual al carácter correspondiente
                if (e.KeyChar.ToString().ToLower() == _textoOriginal[_currentPosition].ToString().ToLower())
                {
                    // Cambia el color del carácter a verde si es correcto
                    _richTextBox.SelectionStart = _currentPosition;
                    _richTextBox.SelectionLength = 1;
                    _richTextBox.SelectionColor = Color.Green; // Cambia a verde

                    // Cambia el color de fondo del botón correspondiente
                    CambiarColorBoton(_textoOriginal[_currentPosition], Color.LightGreen);

                    // Avanza a la siguiente posición
                    _currentPosition++;
                }
                else
                {
                    // Cambia el color del carácter a rojo si es incorrecto
                    _richTextBox.SelectionStart = _currentPosition;
                    _richTextBox.SelectionLength = 1;
                    _richTextBox.SelectionColor = Color.Red; // Cambia a rojo

                    // Cambia el color de fondo del botón correspondiente
                    CambiarColorBoton(_textoOriginal[_currentPosition], Color.Red);
                }
            }

            // Para evitar que se escriba en el RichTextBox
            e.Handled = true; // Evita que se procese el carácter
        }

        private void CambiarColorBoton(char letra, Color color)
        {
            // Asume que los botones están nombrados como btn_A, btn_B, etc.
            string buttonName = "btn_" + letra.ToString().ToUpper();
            foreach (var button in _tecladoButtons)
            {
                if (button.Name == buttonName)
                {
                    button.BackColor = color; // Cambia el color del botón
                    break;
                }
            }
        }

        public void StartTypingTest()
        {
            _richTextBox.Clear(); // Limpia el RichTextBox
            _richTextBox.Text = _textoOriginal; // Restaura el texto original
            _richTextBox.SelectionStart = 0; // Reinicia la posición de selección
            _richTextBox.SelectionLength = 0; // Reinicia la longitud de selección
            _richTextBox.SelectionColor = Color.Black; // Restablece el color a negro

            // Suscribirse al evento KeyPress del RichTextBox
            _richTextBox.KeyPress += KeyPressHandler; // Manejar la entrada de teclas

            // Restablecer el color de los botones
            RestablecerColoresBotones();
        }

        private void RestablecerColoresBotones()
        {
            foreach (var button in _tecladoButtons)
            {
                button.BackColor = SystemColors.Control; // Restablece el color del botón
            }
        }
    }
}
