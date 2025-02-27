/*  Este archivo contiene la clase que afecta a todos los formularios para
  que al precionar enter o tecla tab 
------------PASE AL SIGUIENTE ELEMENTO A COMPLETAR-----------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ofelia_Sara.Clases.General.Texto
{
    
        public class SaltoDeImput
        {
            private Form _form;
            private List<Control> _controlsList;

            public SaltoDeImput(Form form)
            {
                _form = form;
                _form.KeyPreview = true;
                _form.KeyDown += Form_KeyDown;

                ActualizarListaControles();
            }

            private void Form_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                    case Keys.Tab:
                    case Keys.Right:
                    case Keys.Down:
                        if (MoveNextControl()) e.Handled = e.SuppressKeyPress = true;
                        break;

                    case Keys.Left:
                    case Keys.Up:
                        if (MovePreviousControl()) e.Handled = e.SuppressKeyPress = true;
                        break;
                }
            }

            public void ActualizarListaControles()
            {
                _controlsList = GetAllControls(_form)
                    .Where(c => c.TabStop && c.Enabled && c.Visible)
                    .OrderBy(c => c.TabIndex)
                    .ToList();
            }

            private bool MoveNextControl()
            {
                Control current = _form.ActiveControl;
                if (current == null) return false;

                int index = _controlsList.IndexOf(current);
                if (index >= 0 && index < _controlsList.Count - 1)
                {
                    _controlsList[index + 1].Focus();
                    return true;
                }
                return false;
            }

            private bool MovePreviousControl()
            {
                Control current = _form.ActiveControl;
                if (current == null) return false;

                int index = _controlsList.IndexOf(current);
                if (index > 0)
                {
                    _controlsList[index - 1].Focus();
                    return true;
                }
                return false;
            }

            private List<Control> GetAllControls(Control parent)
            {
                List<Control> controls = new List<Control>();
                foreach (Control c in parent.Controls)
                {
                    controls.Add(c);
                    if (c.HasChildren) controls.AddRange(GetAllControls(c));
                }
                return controls;
            }
        }
    }
