//using AxWMPLib;
using Ofelia_Sara.Controles.Controles.Redactador;


namespace Ofelia_Sara.Formularios.Redactador
{
    //partial class VideoInstructivo
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoInstructivo));
    //        this.panel1 = new System.Windows.Forms.Panel();
    //        this.panel_ContenedorCarrusel = new System.Windows.Forms.Panel();
    //        this.Carrusel = new System.Windows.Forms.TableLayoutPanel();
    //        this.AnteriorImagen = new Ofelia_Sara.Controles.Controles.Redactador.PictureBoxCircular();
    //        this.SiguienteImagen = new Ofelia_Sara.Controles.Controles.Redactador.PictureBoxCircular();
    //        this.panel1.SuspendLayout();
    //        this.panel_ContenedorCarrusel.SuspendLayout();
    //        ((System.ComponentModel.ISupportInitialize)(this.AnteriorImagen)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.SiguienteImagen)).BeginInit();
    //        this.SuspendLayout();
    //        // 
    //        // panel1
    //        // 
    //        this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
    //        | System.Windows.Forms.AnchorStyles.Left) 
    //        | System.Windows.Forms.AnchorStyles.Right)));
    //        this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(213)))), ((int)(((byte)(230)))));
    //        this.panel1.Controls.Add(this.panel_ContenedorCarrusel);
    //        this.panel1.Location = new System.Drawing.Point(22, 12);
    //        this.panel1.MinimumSize = new System.Drawing.Size(530, 276);
    //        this.panel1.Name = "panel1";
    //        this.panel1.Size = new System.Drawing.Size(530, 276);
    //        this.panel1.TabIndex = 1;
    //        // 
    //        // panel_ContenedorCarrusel
    //        // 
    //        this.panel_ContenedorCarrusel.Anchor = System.Windows.Forms.AnchorStyles.Top;
    //        this.panel_ContenedorCarrusel.Controls.Add(this.Carrusel);
    //        this.panel_ContenedorCarrusel.Controls.Add(this.AnteriorImagen);
    //        this.panel_ContenedorCarrusel.Controls.Add(this.SiguienteImagen);
    //        this.panel_ContenedorCarrusel.Location = new System.Drawing.Point(5, 14);
    //        this.panel_ContenedorCarrusel.Name = "panel_ContenedorCarrusel";
    //        this.panel_ContenedorCarrusel.Size = new System.Drawing.Size(520, 82);
    //        this.panel_ContenedorCarrusel.TabIndex = 5;
    //        // 
    //        // Carrusel
    //        // 
    //        this.Carrusel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
    //        | System.Windows.Forms.AnchorStyles.Left) 
    //        | System.Windows.Forms.AnchorStyles.Right)));
    //        this.Carrusel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
    //        this.Carrusel.ColumnCount = 5;
    //        this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
    //        this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
    //        this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
    //        this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
    //        this.Carrusel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
    //        this.Carrusel.Cursor = System.Windows.Forms.Cursors.Hand;
    //        this.Carrusel.Location = new System.Drawing.Point(31, 3);
    //        this.Carrusel.Name = "Carrusel";
    //        this.Carrusel.RowCount = 1;
    //        this.Carrusel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
    //        this.Carrusel.Size = new System.Drawing.Size(459, 76);
    //        this.Carrusel.TabIndex = 1;
    //        this.Carrusel.Paint += new System.Windows.Forms.PaintEventHandler(this.Carrusel_Paint);
    //        // 
    //        // AnteriorImagen
    //        // 
    //        this.AnteriorImagen.Anchor = System.Windows.Forms.AnchorStyles.Left;
    //        this.AnteriorImagen.BackColor = System.Drawing.Color.Transparent;
    //        this.AnteriorImagen.Cursor = System.Windows.Forms.Cursors.Hand;
    //        this.AnteriorImagen.Image = ((System.Drawing.Image)(resources.GetObject("AnteriorImagen.Image")));
    //        this.AnteriorImagen.Location = new System.Drawing.Point(0, 25);
    //        this.AnteriorImagen.Name = "AnteriorImagen";
    //        this.AnteriorImagen.Size = new System.Drawing.Size(27, 27);
    //        this.AnteriorImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
    //        this.AnteriorImagen.TabIndex = 4;
    //        this.AnteriorImagen.TabStop = false;
    //        this.AnteriorImagen.Click += new System.EventHandler(this.btn_AnteriorImagen_Click);
    //        // 
    //        // SiguienteImagen
    //        // 
    //        this.SiguienteImagen.Anchor = System.Windows.Forms.AnchorStyles.Right;
    //        this.SiguienteImagen.BackColor = System.Drawing.Color.Transparent;
    //        this.SiguienteImagen.Cursor = System.Windows.Forms.Cursors.Hand;
    //        this.SiguienteImagen.Image = ((System.Drawing.Image)(resources.GetObject("SiguienteImagen.Image")));
    //        this.SiguienteImagen.Location = new System.Drawing.Point(493, 25);
    //        this.SiguienteImagen.Name = "SiguienteImagen";
    //        this.SiguienteImagen.Size = new System.Drawing.Size(27, 27);
    //        this.SiguienteImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
    //        this.SiguienteImagen.TabIndex = 3;
    //        this.SiguienteImagen.TabStop = false;
    //        this.SiguienteImagen.Click += new System.EventHandler(this.btn_SiguienteImagen_Click);
    //        // 
    //        // VideoInstructivo
    //        // 
    //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.AutoSize = true;
    //        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(174)))));
    //        this.ClientSize = new System.Drawing.Size(574, 311);
    //        this.Controls.Add(this.panel1);
    //        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    //        this.MinimumSize = new System.Drawing.Size(590, 350);
    //        this.Name = "VideoInstructivo";
    //        this.Text = "INSTRUCTIVO DIGITAL";
    //        this.Load += new System.EventHandler(this.VideoInstructivo_Load);
    //        this.panel1.ResumeLayout(false);
    //        this.panel_ContenedorCarrusel.ResumeLayout(false);
    //        ((System.ComponentModel.ISupportInitialize)(this.AnteriorImagen)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.SiguienteImagen)).EndInit();
    //        this.ResumeLayout(false);

    //    }

    //    #endregion

    //    private System.Windows.Forms.Panel panel1;
    //    private System.Windows.Forms.TableLayoutPanel Carrusel;
    //    private PictureBoxCircular AnteriorImagen;
    //    private PictureBoxCircular SiguienteImagen;
    //    private System.Windows.Forms.Panel panel_ContenedorCarrusel;
    //}
//}
}