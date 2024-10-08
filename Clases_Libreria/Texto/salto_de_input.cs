/*  Este archivo contiene la clase que afecta a todos los formularios para
  que al precionar enter o tecla tab 
------------PASE AL SIGUIENTE ELEMENTO A COMPLETAR-----------------------*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clases.Texto
{
    public class SaltoDeImput
    {
        private Form _form;
        private Dictionary<Keys, Func<bool>> _keyActions;

        public SaltoDeImput(Form form)
        {
            _form = form;

            // Inicialización del diccionario _keyActions que mapea teclas a funciones booleanas
            _keyActions = new Dictionary<Keys, Func<bool>>
            {
                { Keys.Enter, MoveNextControl },   // Al presionar Enter, mueve al siguiente control
                { Keys.Tab, MoveNextControl },     // Al presionar Tab, mueve al siguiente control
                { Keys.Right, MoveNextControl },   // Al presionar Flecha Derecha, mueve al siguiente control
                { Keys.Down, MoveNextControl },    // Al presionar Flecha Abajo, mueve al siguiente control
                { Keys.Left, MovePreviousControl },// Al presionar Flecha Izquierda, mueve al control anterior
                { Keys.Up, MovePreviousControl }   // Al presionar Flecha Arriba, mueve al control anterior
            };

            // Configura el formulario para recibir eventos de teclado antes de que los controles los manejen
            _form.KeyPreview = true;

            // Suscribe el método Form_KeyDown al evento KeyDown del formulario _form
            _form.KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si la tecla presionada está en el diccionario _keyActions
            if (_keyActions.ContainsKey(e.KeyCode))
            {
                // Ejecuta la función asociada a la tecla y obtiene el resultado (true o false)
                bool handled = _keyActions[e.KeyCode]();

                // Si la acción fue manejada (handled es true), suprime la pulsación de tecla
                if (handled)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true; // Suprime la tecla para que no se propague el evento
                }
            }
        }

        private bool MoveNextControl()
        {
            Control currentControl = _form.ActiveControl; // Obtiene el control activo actual
            if (currentControl != null)
            {
                int currentIndex = _form.Controls.IndexOf(currentControl); // Obtiene el índice del control actual en la colección de controles

                // Si hay un siguiente control en la colección, lo enfoca y retorna true indicando que la acción fue manejada
                if (currentIndex < _form.Controls.Count - 1)
                {
                    Control nextControl = _form.Controls[currentIndex + 1];
                    nextControl.Focus(); // Enfoca el siguiente control
                    return true; // Indica que la acción fue manejada correctamente
                }
            }
            return false; // Indica que no se manejó la acción porque no hay siguiente control o no se pudo enfocar
        }

        private bool MovePreviousControl()
        {
            Control currentControl = _form.ActiveControl; // Obtiene el control activo actual
            if (currentControl != null)
            {
                int currentIndex = _form.Controls.IndexOf(currentControl); // Obtiene el índice del control actual en la colección de controles

                // Si hay un control anterior en la colección, lo enfoca y retorna true indicando que la acción fue manejada
                if (currentIndex > 0)
                {
                    Control previousControl = _form.Controls[currentIndex - 1];
                    previousControl.Focus(); // Enfoca el control anterior
                    return true; // Indica que la acción fue manejada correctamente
                }
            }
            return false; // Indica que no se manejó la acción porque no hay control anterior o no se pudo enfocar
        }
    }
}
