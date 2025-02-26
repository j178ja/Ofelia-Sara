using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;




public static class CursorHelper
    {
        public static Cursor ObtenerCursorDesdeRecursos(byte[] cursorBytes)
        {
            using (MemoryStream stream = new MemoryStream(cursorBytes))
            {
                return new Cursor(stream);
            }
        }
    }


