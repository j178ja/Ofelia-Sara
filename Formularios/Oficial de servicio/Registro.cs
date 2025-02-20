﻿using Ofelia_Sara.Clases.General.Apariencia;
using Ofelia_Sara.Clases.General.Botones;
using Ofelia_Sara.Formularios.General;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.Oficial_de_servicio
{
    public partial class Registro : BaseForm
    {
        public Registro()
        {
            InitializeComponent();
            RedondearBordes.Aplicar(panel1, 15);
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            InicializarEstiloBoton(btn_Registrarse);
            InicializarEstiloBoton(btn_Limpiar);

        }


        private void textBox_Legajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos y el carácter de control de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Convertir el texto a mayúsculas ignorando caracteres especiales
                // textBox.Text = MayusculaSimple.ConvertirAMayusculasIgnorandoEspeciales(textBox.Text);

                // Para mantener el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están completados
            if (!ValidarTextBoxes(this))
            {
                // Si alguno de los campos está vacío, mostrar un mensaje de advertencia
                // crea ventana con icono de advertencia y titulo de advertencia
                MessageBox.Show("Debe completar la totalidad de campos", "Advertencia   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si todos los campos están completos, mostrar el mensaje de confirmación
                //Crea ventana con icono especial de confirmacion y titulo confirmacion
                MessageBox.Show("Se ha registrado un nuevo Usuario.", "Confirmación   Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ValidarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Verificar si es un TextBox y está vacío
                if (control is TextBox && string.IsNullOrWhiteSpace(((TextBox)control).Text))
                {
                    return false;
                }

                // Si el control tiene controles hijos, aplicar la validación recursivamente
                if (control.HasChildren)
                {
                    if (!ValidarTextBoxes(control))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //----BOTON LIMPIAR/ELIMINAR-----------------------

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario.Limpiar(this); // Llama al método estático Limpiar de la clase LimpiarFormulario
                                             // Mensaje para confirmar la limpieza
                                             //MessageBox.Show("Formulario eliminado.");//esto muestra una ventana con boton aceptar
            MessageBox.Show("Formulario eliminado.", "Información  Ofelia-Sara", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Registro_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            // Mostrar un mensaje de ayuda
            MessageBox.Show("Vomplete la totalidad de los campos para poder registrar un nuevo Usuario.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cancelar el evento para que no se cierre el formulario
            e.Cancel = true;
        }

        private void label_Registro_Click(object sender, EventArgs e)
        {

        }
    }

}
