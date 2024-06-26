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
    // NO SE ESTAN APLICANDO MODIFICACIONES DE POSICION DERECHA, TAMAÑO, SI SE MODIFICA PONERLO MAS ARRIBA
    public static class FooterHelper
    {
        public static Label CreateFooterLabel(Form form)
        {
            Label footerLabel = new Label();
            footerLabel.AutoSize = true;
            footerLabel.Location = new System.Drawing.Point(10, form.ClientSize.Height -5 );
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new System.Drawing.Size(200, 16);
            footerLabel.TabIndex = 0;
            footerLabel.Text = "Desarrollado por Jorge A. Bonato - V. 1.0.0";
            footerLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            return footerLabel;
        }
    }
}