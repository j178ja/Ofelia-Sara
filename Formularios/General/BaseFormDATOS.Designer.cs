using System.Windows.Forms;

namespace Ofelia_Sara.Formularios.General
{
    public partial class BaseFormDATOS : Form
    {
        /// <summary>
        /// Requerido por el diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos en uso.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados deben eliminarse.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Inicialización del diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseFormBase
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "BaseFormBase";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
