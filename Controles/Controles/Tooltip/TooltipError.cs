using System.Drawing;
using System.Windows.Forms;


public static class ToolTipError
{
    private static ToolTip toolTipError; // Cambié Label por ToolTip

    /// <summary>
    /// Inicializa el ToolTip cuando se pasa el mouse sobre el PictureBoxError.
    /// </summary>
    /// <param name="control">Control PictureBox donde se desencadenará el evento de hover.</param>
    /// <param name="toolTipText">Texto que se mostrará en el ToolTip.</param>
    public static void InitializeToolTipOnHover(PictureBox pictureBoxError, string toolTipText)
    {
        // Crear el ToolTip solo una vez si no existe
        if (toolTipError == null)
        {
            toolTipError = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.Warning,
                IsBalloon = true, // Formato globo de diálogo
                BackColor = Color.LightBlue, // Color de fondo
                ForeColor = Color.Black // Color de texto

            };

            // Asignar eventos de hover
            pictureBoxError.MouseHover += (sender, e) => Mostrar(pictureBoxError, toolTipText);
            pictureBoxError.MouseLeave += (sender, e) => HideToolTip();
        }
    }

    /// <summary>
    /// Muestra el ToolTip con el texto especificado cuando se pasa el mouse sobre el control.
    /// </summary>
    /// <param name="control">Control sobre el que se pasa el mouse.</param>
    /// <param name="toolTipText">Texto a mostrar.</param>
    public static void Mostrar(Control control, string toolTipText)
    {
        if (control == null || string.IsNullOrEmpty(toolTipText))
            return;

        // Configurar el texto
        toolTipError.SetToolTip(control, toolTipText); // Usamos SetToolTip para asociar el texto

       
    }

    /// <summary>
    /// Oculta el ToolTip cuando el mouse sale del control.
    /// </summary>
    public static void HideToolTip()
    {
        // El ToolTip se oculta automáticamente al salir del control
        toolTipError.RemoveAll();  // Eliminar todos los ToolTips asociados
    }
}
