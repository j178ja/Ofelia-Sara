/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE INTRODUCIR 
  ---------------DESARROLLADOR Y VERSION ---------------------------*/
using Ofelia_Sara.Formularios;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ofelia_Sara.Mensajes;



namespace Clases.Apariencia
{
    public static class FooterHelper
    {
        public static LinkLabel CreateFooterLinkLabel(Form form)
        {
            if (form is Contacto)
            {
                return null; // No agregar el LinkLabel si es el formulario Contacto
            }
            // Excluir los formularios Contacto y MensajeGeneral
            if (form is Contacto || form is MensajeGeneral)
            {
                return null; // No agregar el LinkLabel si es uno de los formularios excluidos
            }

            LinkLabel footerLinkLabel = new LinkLabel();
            footerLinkLabel.AutoSize = true;
            footerLinkLabel.Location = new System.Drawing.Point(50, form.ClientSize.Height - 50); // Ajusta la ubicación en Y
            footerLinkLabel.Name = "footerLabel";
            footerLinkLabel.Size = new System.Drawing.Size(200, 16);
            footerLinkLabel.TabIndex = 0;
            footerLinkLabel.Text = "Desarrollado por Jorge A. Bonato - V. 1.0.0";
            footerLinkLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Añadir evento de clic
            footerLinkLabel.LinkClicked += (sender, e) =>
            {
                // Ocultar todos los formularios visibles
                List<Form> formsToHide = Application.OpenForms.Cast<Form>()
                    .Where(f => f.Visible && !(f is Contacto)) // Excluir el formulario Contacto
                    .ToList();

                foreach (Form f in formsToHide)
                {
                    f.Hide();
                }

                // Abrir el formulario Contacto
                Form contacto = new Contacto();
                contacto.FormClosed += (s, args) =>
                {
                    // Restaurar los formularios previamente ocultos
                    foreach (Form f in formsToHide)
                    {
                        f.Show();
                    }
                };
                contacto.Show();
            };

            // Ajustar la posición para que siempre esté cerca del borde inferior
            form.Controls.Add(footerLinkLabel);
            form.Resize += (sender, e) =>
            {
                footerLinkLabel.Location = new System.Drawing.Point(form.ClientSize.Width - footerLinkLabel.Width - 10, form.ClientSize.Height - footerLinkLabel.Height - 10);
            };

            return footerLinkLabel;
        }
    }

}