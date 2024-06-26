/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE INTRODUCIR 
  ---------------DESARROLLADOR Y VERSION ---------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public static class FooterHelper
    {
        public static Label CreateFooterLabel(Form form)
        {
            Label footerLabel = new Label();
            footerLabel.AutoSize = true;
            footerLabel.Location = new System.Drawing.Point(50, form.ClientSize.Height - 50); // Ajusta la ubicación en Y
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new System.Drawing.Size(200, 16);
            footerLabel.TabIndex = 0;
            footerLabel.Text = "Desarrollado por Jorge A. Bonato - V. 1.0.0";
            footerLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right; // Anclar a la parte inferior y derecha

            // Ajustar la posición para que siempre esté cerca del borde inferior
            form.Controls.Add(footerLabel);
            form.Resize += (sender, e) =>
            {
                footerLabel.Location = new System.Drawing.Point(form.ClientSize.Width - footerLabel.Width - 10, form.ClientSize.Height - footerLabel.Height - 10);
            };

            return footerLabel;
        }
    }
}
