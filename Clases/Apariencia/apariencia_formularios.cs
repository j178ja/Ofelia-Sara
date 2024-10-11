/* ESTE ARCHIVO CONTIENE LA CLASE APLICABLE A TODOS LOS FORMULARIOS
  QUE PERMITE DARLE APARIENCIA A LOS FORMULARIOS
  --------------COLOR/TAMAÑO/--------------*/
using System.Drawing;
using System.Windows.Forms;


namespace Clases.Apariencia
{
    public static class AparienciaFormularios
    {
        // Método para cambiar el color de fondo del formulario
        public static void CambiarColorDeFondo(Form form, Color color)
        {
            form.BackColor = color;
        }
    }
}

////----- CAMBIAR COLOR DE BARRA SUPERIOR------------
///-------NO SE ESTA APLICANDO CORRECTAMENTE !!-----------
//
//
//public static class FormAppearanceHelper
//{
//    private const int WM_NCPAINT = 0x0085;
//    private const int WM_NCACTIVATE = 0x0086;
//    private const int WM_NCCALCSIZE = 0x0083;

//    private const int GWL_STYLE = -16;
//    private const int WS_SYSMENU = 0x80000;

//    [DllImport("user32.dll")]
//    private static extern IntPtr GetWindowDC(IntPtr hWnd);

//    [DllImport("user32.dll")]
//    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

//    [DllImport("user32.dll")]
//    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

//    [DllImport("user32.dll", SetLastError = true)]
//    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

//    public static void SetTitleBarColor(Form form, Color color)
//    {
//        form.Paint += (sender, e) =>
//        {
//            PaintTitleBar(form, color);
//        };
//    }

//    private static void PaintTitleBar(Form form, Color color)
//    {
//        IntPtr hdc = GetWindowDC(form.Handle);
//        if (hdc != IntPtr.Zero)
//        {
//            using (Graphics g = Graphics.FromHdc(hdc))
//            {
//                Rectangle rect = new Rectangle(0, 0, form.Width, SystemInformation.CaptionHeight);
//                g.FillRectangle(new SolidBrush(color), rect);
//            }
//            ReleaseDC(form.Handle, hdc);
//        }
//}
