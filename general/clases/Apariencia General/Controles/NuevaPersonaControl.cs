using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases.Apariencia_General.Controles
{
   
        public partial class NuevaPersonaControl : UserControl
        {
            public string TipoPersona { get; set; }

            public NuevaPersonaControl()
            {
                InitializeComponent();
                this.Load += NuevaPersonaControl_Load;
            }

            private void NuevaPersonaControl_Load(object sender, EventArgs e)
            {
                if (TipoPersona == "Victima")
                {
                    label_Persona.Text = "Victima n°";
                }
                else if (TipoPersona == "Imputado")
                {
                    label_Persona.Text = "Imputado n°";
                }
                else //inesesario pero por si acaso hay algun error
                {
                    label_Persona.Text = "Persona n°";
                }
            }
        }
    }
