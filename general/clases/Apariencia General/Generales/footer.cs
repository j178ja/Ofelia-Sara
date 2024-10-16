﻿/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE INTRODUCIR 
  ---------------DESARROLLADOR Y VERSION ---------------------------*/
using System;
using System.Windows.Forms;
using Ofelia_Sara.Formularios;

namespace Ofelia_Sara.general.clases
{
    public static class FooterHelper
    {
        public static LinkLabel CreateFooterLinkLabel(Form form)
        {
            LinkLabel footerLinkLabel = new LinkLabel();
            footerLinkLabel.AutoSize = true;
            footerLinkLabel.Location = new System.Drawing.Point(50, form.ClientSize.Height - 50); // Ajusta la ubicación en Y
            footerLinkLabel.Name = "footerLabel";
            footerLinkLabel.Size = new System.Drawing.Size(200, 16);
            footerLinkLabel.TabIndex = 0;
            footerLinkLabel.Text = "Desarrollado por Jorge A. Bonato - V. 1.0.0";
            footerLinkLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right; // Anclar a la parte inferior y derecha

            // Añadir evento de clic
            footerLinkLabel.LinkClicked += (sender, e) =>
            {
                // Abrir el formulario deseado al hacer clic en el link
                Form contacto = new Contacto();
               contacto.Show();
            };

            // Ajustar la posición para que siempre esté cerca del borde inferior
            form.Controls.Add(footerLinkLabel);
            form.Resize += (sender, e) =>
            {
                footerLinkLabel.Location = new System.Drawing.Point(form.ClientSize.Width -footerLinkLabel.Width - 10, form.ClientSize.Height - footerLinkLabel.Height - 10);
            };

            return footerLinkLabel;
        }
    }
}
