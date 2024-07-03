using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofelia_Sara.general.clases
{
    public static class ProgressBarHelper
    {
        public static void UpdateProgressBar(ProgressBar progressBar, int value)
        {
            if (value < progressBar.Minimum)
            {
                progressBar.Value = progressBar.Minimum;
            }
            else if (value > progressBar.Maximum)
            {
                progressBar.Value = progressBar.Maximum;
            }
            else
            {
                progressBar.Value = value;
            }
        }
    }
}
