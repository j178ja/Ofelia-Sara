/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE QUE EL TEXTO INTRODUCIDO SE COLOQUE AUTOMATICAMENTE EN
  ---------------MAYUSCULAS---------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio.DatosPersonales;

//namespace Ofelia_Sara.general.clases
//{
//    public static class TextoEnMayuscula
//    {
//        //// Método para suscribir TextBox y ComboBox al evento TextChanged/KeyPress que convierte texto a mayúsculas y filtra números y caracteres especiales
//        //public static void ConvertirTextoAMayusculas(Control control, TextBox textBox_NumeroIpp, params ComboBox[] comboBoxesNumericos)
//        //{
//        //    if (control == null)
//        //    {
//        //        throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");
//        //    }

//        //    foreach (Control c in control.Controls)
//        //    {
//        //        if (c is TextBox textBox)
//        //        {
//        //            if (textBox == textBox_NumeroIpp || 
//        //                textBox == textBox_Edad ||
//        //                textBox == textBox_Dni ||
//        //                textBox == textBox_FechaNacimiento)
//        //            {
//        //                // Solo permitir dígitos y teclas de control en textBox_NumeroIpp
//        //                textBox.KeyPress += (sender, e) =>
//        //                {
//        //                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
//        //                    {
//        //                        e.Handled = true;
//        //                    }
//        //                };
//        //            }

//        //            else
//        //            {
//        //                // Para todos los demás TextBox, aplicar la lógica de filtrado y conversión a mayúsculas
//        //                textBox.TextChanged += (sender, e) =>
//        //                {
//        //                    int selectionStart = textBox.SelectionStart;
//        //                    string filteredText = FiltrarTexto(textBox.Text);
//        //                    textBox.Text = filteredText.ToUpper();
//        //                    textBox.SelectionStart = selectionStart;
//        //                };
//        //            }
//        //        }
//        //---------------------------------------------
//        public static void ConvertirTextoAMayusculas(Control control, Dictionary<string, bool> textBoxExcepciones)
//        {
//            foreach (Control c in control.Controls)
//            {
//                if (c is TextBox textBox)
//                {
//                    if (textBoxExcepciones != null && textBoxExcepciones.ContainsKey(textBox.Name) && textBoxExcepciones[textBox.Name])
//                    {
//                        // Solo permitir dígitos y teclas de control en los TextBox excepcionados
//                        textBox.KeyPress += (sender, e) =>
//                        {
//                            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
//                            {
//                                e.Handled = true;
//                            }
//                        };
//                    }
//                    else
//                    {
//                        // Para todos los demás TextBox, aplicar la lógica de filtrado y conversión a mayúsculas
//                        textBox.TextChanged += (sender, e) =>
//                        {
//                            int selectionStart = textBox.SelectionStart;
//                            string filteredText = FiltrarTexto(textBox.Text);
//                            textBox.Text = filteredText.ToUpper();
//                            textBox.SelectionStart = selectionStart;
//                        };
//                    }
//                }

//               else if (c is ComboBox comboBox)
//                {
//                    if (comboBoxesNumericos.Contains(comboBox))
//                    {
//                        comboBox.KeyPress += (sender, e) =>
//                        {
//                            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
//                            {
//                                e.Handled = true;
//                            }
//                        };
//                    }
//                    else
//                    {
//                        comboBox.KeyPress += (sender, e) =>
//                        {
//                            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
//                            {
//                                e.Handled = true;
//                            }
//                            else
//                            {
//                                e.KeyChar = char.ToUpper(e.KeyChar);
//                            }
//                        };
//                    }
//                }

//                //// Llama recursivamente al método para procesar controles anidados
//                //ConvertirTextoAMayusculas(c, textBox_NumeroIpp, comboBoxesNumericos);
//                // Aplica recursivamente para los controles hijos
//                if (c.HasChildren)
//                {
//                    ConvertirTextoAMayusculas(c, textBoxExcepciones);
//                }
//            }
//        }

//        // Método auxiliar para filtrar caracteres no deseados
//        private static string FiltrarTexto(string input)
//        {
//            StringBuilder filteredText = new StringBuilder();
//            foreach (char c in input)
//            {
//                if (char.IsLetter(c) || char.IsWhiteSpace(c))
//                {
//                    filteredText.Append(c);
//                }
//            }
//            return filteredText.ToString();
//        }
//    }
//}
//private static readonly ComboBox[] comboBoxesNumericos =
//{
//    comboBox_NumeroIpp,
//    comboBox_Edad,

//};


//namespace Ofelia_Sara.general.clases
//{
//    public static class TextoEnMayuscula
//    {
//        // Método para convertir texto a mayúsculas y aplicar validaciones
//        public static void ConvertirTextoAMayusculas(Control control, Dictionary<string, bool> textBoxExcepciones, ComboBox[] comboBoxesNumericos)
//        {
//            foreach (Control c in control.Controls)
//            {
//                if (c is TextBox textBox)
//                {
//                    if (textBoxExcepciones != null && textBoxExcepciones.ContainsKey(textBox.Name) && textBoxExcepciones[textBox.Name])
//                    {
//                        // Solo permitir dígitos y teclas de control en los TextBox excepcionados
//                        textBox.KeyPress += (sender, e) =>
//                        {
//                            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
//                            {
//                                e.Handled = true;
//                            }
//                        };
//                    }
//                    else
//                    {
//                        // Para todos los demás TextBox, aplicar la lógica de filtrado y conversión a mayúsculas
//                        textBox.TextChanged += (sender, e) =>
//                        {
//                            int selectionStart = textBox.SelectionStart;
//                            string filteredText = FiltrarTexto(textBox.Text);
//                            textBox.Text = filteredText.ToUpper();
//                            textBox.SelectionStart = selectionStart;
//                        };
//                    }
//                }
//                else if (c is ComboBox comboBox)
//                {
//                    if (Array.Exists(comboBoxesNumericos, element => element == comboBox))
//                    {
//                        // Solo permitir dígitos y teclas de control en ComboBox numéricos
//                        comboBox.KeyPress += (sender, e) =>
//                        {
//                            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
//                            {
//                                e.Handled = true;
//                            }
//                        };
//                    }
//                    else
//                    {
//                        // Aplicar la lógica para otros ComboBox (solo letras y convertir a mayúsculas)
//                        comboBox.KeyPress += (sender, e) =>
//                        {
//                            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
//                            {
//                                e.Handled = true;
//                            }
//                            else
//                            {
//                                e.KeyChar = char.ToUpper(e.KeyChar);
//                            }
//                        };
//                    }
//                }

//                // Aplica recursivamente para los controles hijos
//                if (c.HasChildren)
//                {
//                    ConvertirTextoAMayusculas(c, textBoxExcepciones, comboBoxesNumericos);
//                }
//            }
//        }

//        // Método auxiliar para filtrar caracteres no deseados
//        private static string FiltrarTexto(string input)
//        {
//            StringBuilder filteredText = new StringBuilder();
//            foreach (char c in input)
//            {
//                if (char.IsLetter(c) || char.IsWhiteSpace(c))
//                {
//                    filteredText.Append(c);
//                }
//            }
//            return filteredText.ToString();
//        }
//    }
//}


