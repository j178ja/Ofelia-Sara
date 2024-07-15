/*--------SE CREO PARA NO TENER QUE ASIGNA EVENTOS A CADA BOTON DE CADA FORMULARIO
  ------------PERO NO SE APLICA CORRECTAMENTE
  ---------SE AGREGO EL CODIGO A BASEFORM----------------------*/






using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Botones
{
    public class EstiloBotones
    {
        public EstiloBotones(Button button) //(tipo de dato y nombre parametro)
        {
            //designacion de variables
            button.MouseHover += Button_MouseHover;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
        }
        //-----EVENTO PARA CUANDO PASA EL CURSOR POR ENCIMA--------------
        private void Button_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.DodgerBlue;
            }
        }

        //-----EVENTO PARA CUANDO EL CURSOR  PERMANECE--------------
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Size = new Size(button.Width + 9, button.Height + 9);
            }
        }


        //--------EVENTO PARA CUADNO EL CURSOR SALE DEL BOTON -------------------
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.SkyBlue;
                button.Size = new Size(button.Width - 9, button.Height - 9);
            }
        }
    }
}