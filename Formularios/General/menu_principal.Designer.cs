﻿using Ofelia_Sara.Controles.General;
namespace Ofelia_Sara.Formularios.General
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
       // private System.Windows.Forms.Button Btn_Configuracion;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            btn_InicioCierre = new System.Windows.Forms.Button();
            btn_Expedientes = new System.Windows.Forms.Button();
            btn_Contravenciones = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            btn_BuscarTarea = new System.Windows.Forms.Button();
            comboBox_Buscar = new CustomComboBox();
            btn_Configurar = new System.Windows.Forms.Button();
            btn_Leyes = new System.Windows.Forms.PictureBox();
            panel_MenuSuperior = new System.Windows.Forms.Panel();
            btn_BoletinOficial = new System.Windows.Forms.Button();
            btn_Redactador = new System.Windows.Forms.Button();
            btn_Mecanografia = new System.Windows.Forms.Button();
            btn_Minimizar = new System.Windows.Forms.Button();
            label_MenuPrincipal = new System.Windows.Forms.Label();
            label_OfeliaSara = new System.Windows.Forms.Label();
            btn_Cerrar = new System.Windows.Forms.Button();
            menu_Configurar = new System.Windows.Forms.ContextMenuStrip(components);
            aGREGARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            iNSTRUCTORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uFIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aGENTEFISCALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dEPENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sELLOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mEDALLAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            eSCALERAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fOLIADORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bUSCARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            nIPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cARATULAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            vICTIMAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            iMPUTADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fECHAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sECRETARIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            iNSTRUCTORToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            dEPENDENCIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Leyes).BeginInit();
            panel_MenuSuperior.SuspendLayout();
            menu_Configurar.SuspendLayout();
            SuspendLayout();
            // 
            // btn_InicioCierre
            // 
            btn_InicioCierre.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            btn_InicioCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_InicioCierre.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            btn_InicioCierre.FlatAppearance.BorderSize = 0;
            btn_InicioCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_InicioCierre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_InicioCierre.Location = new System.Drawing.Point(58, 99);
            btn_InicioCierre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_InicioCierre.Name = "btn_InicioCierre";
            btn_InicioCierre.Size = new System.Drawing.Size(147, 39);
            btn_InicioCierre.TabIndex = 2;
            btn_InicioCierre.Text = "I.P.P.";
            btn_InicioCierre.UseVisualStyleBackColor = false;
            btn_InicioCierre.Click += Btn_InicioCierre_Click;
            btn_InicioCierre.MouseDown += Boton_MouseDown;
            btn_InicioCierre.MouseUp += Boton_MouseUp;
            // 
            // btn_Expedientes
            // 
            btn_Expedientes.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            btn_Expedientes.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Expedientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Expedientes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_Expedientes.Location = new System.Drawing.Point(408, 99);
            btn_Expedientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Expedientes.Name = "btn_Expedientes";
            btn_Expedientes.Size = new System.Drawing.Size(138, 39);
            btn_Expedientes.TabIndex = 6;
            btn_Expedientes.Text = "EXPEDIENTES";
            btn_Expedientes.UseVisualStyleBackColor = false;
            btn_Expedientes.Click += Btn_Expedientes_Click;
            btn_Expedientes.MouseDown += Boton_MouseDown;
            btn_Expedientes.MouseUp += Boton_MouseUp;
            // 
            // btn_Contravenciones
            // 
            btn_Contravenciones.BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            btn_Contravenciones.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Contravenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Contravenciones.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btn_Contravenciones.Location = new System.Drawing.Point(212, 99);
            btn_Contravenciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Contravenciones.Name = "btn_Contravenciones";
            btn_Contravenciones.Size = new System.Drawing.Size(189, 39);
            btn_Contravenciones.TabIndex = 4;
            btn_Contravenciones.Text = "CONTRAVENCIONES";
            btn_Contravenciones.UseVisualStyleBackColor = false;
            btn_Contravenciones.Click += Btn_Contravenciones_Click;
            btn_Contravenciones.MouseDown += Boton_MouseDown;
            btn_Contravenciones.MouseUp += Boton_MouseUp;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = System.Drawing.Color.FromArgb(178, 213, 230);
            panel1.Controls.Add(btn_BuscarTarea);
            panel1.Controls.Add(comboBox_Buscar);
            panel1.Controls.Add(btn_Configurar);
            panel1.Controls.Add(btn_Leyes);
            panel1.Controls.Add(btn_Contravenciones);
            panel1.Controls.Add(btn_InicioCierre);
            panel1.Controls.Add(btn_Expedientes);
            panel1.Location = new System.Drawing.Point(23, 63);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(621, 170);
            panel1.TabIndex = 12;
            // 
            // btn_BuscarTarea
            // 
            btn_BuscarTarea.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_BuscarTarea.BackgroundImage");
            btn_BuscarTarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_BuscarTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_BuscarTarea.FlatAppearance.BorderSize = 0;
            btn_BuscarTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_BuscarTarea.Location = new System.Drawing.Point(110, 25);
            btn_BuscarTarea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_BuscarTarea.Name = "btn_BuscarTarea";
            btn_BuscarTarea.Size = new System.Drawing.Size(57, 59);
            btn_BuscarTarea.TabIndex = 15;
            btn_BuscarTarea.UseVisualStyleBackColor = true;
            btn_BuscarTarea.Click += Btn_BuscarTarea_Click;
            // 
            // comboBox_Buscar
            // 
            comboBox_Buscar.ArrowImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.ArrowImage");
            comboBox_Buscar.ArrowPictureBox = null;
            comboBox_Buscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            comboBox_Buscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            comboBox_Buscar.BackColor = System.Drawing.Color.White;
            comboBox_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBox_Buscar.DataSource = null;
            comboBox_Buscar.DefaultImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.DefaultImage");
            comboBox_Buscar.DisabledImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.DisabledImage");
            comboBox_Buscar.DisplayMember = null;
            comboBox_Buscar.DropDownHeight = 252;
            comboBox_Buscar.DropDownStyle = CustomComboBox.CustomComboBoxStyle.DropDown;
            comboBox_Buscar.DroppedDown = false;
            comboBox_Buscar.ErrorColor = System.Drawing.Color.Red;
            comboBox_Buscar.FocusColor = System.Drawing.Color.Blue;
            comboBox_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Buscar.ForeColor = System.Drawing.Color.Gray;
            comboBox_Buscar.Location = new System.Drawing.Point(174, 38);
            comboBox_Buscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_Buscar.MaxDropDownItems = 5;
            comboBox_Buscar.Name = "comboBox_Buscar";
            comboBox_Buscar.PlaceholderColor = System.Drawing.Color.Gray;
            comboBox_Buscar.PlaceholderText = " ";
            comboBox_Buscar.PressedImage = (System.Drawing.Image)resources.GetObject("comboBox_Buscar.PressedImage");
            comboBox_Buscar.SelectedIndex = -1;
            comboBox_Buscar.SelectedItem = null;
            comboBox_Buscar.SelectedText = "";
            comboBox_Buscar.SelectionStart = 0;
            comboBox_Buscar.ShowError = false;
            comboBox_Buscar.Size = new System.Drawing.Size(342, 28);
            comboBox_Buscar.TabIndex = 14;
            comboBox_Buscar.Text = " ";
            comboBox_Buscar.TextValue = "";
            // 
            // btn_Configurar
            // 
            btn_Configurar.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_Configurar.BackgroundImage");
            btn_Configurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Configurar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Configurar.FlatAppearance.BorderSize = 0;
            btn_Configurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Configurar.Location = new System.Drawing.Point(15, 13);
            btn_Configurar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Configurar.Name = "btn_Configurar";
            btn_Configurar.Size = new System.Drawing.Size(40, 37);
            btn_Configurar.TabIndex = 13;
            btn_Configurar.UseVisualStyleBackColor = false;
            btn_Configurar.Click += Btn_Configurar_Click;
            btn_Configurar.MouseHover += Btn_Configurar_Hover;
            // 
            // btn_Leyes
            // 
            btn_Leyes.BackgroundImage = Properties.Resources.EscudoPolicia_PNG;
            btn_Leyes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btn_Leyes.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Leyes.Location = new System.Drawing.Point(567, 13);
            btn_Leyes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Leyes.Name = "btn_Leyes";
            btn_Leyes.Size = new System.Drawing.Size(37, 37);
            btn_Leyes.TabIndex = 1;
            btn_Leyes.TabStop = false;
            btn_Leyes.Click += Btn_Leyes_Click;
            // 
            // panel_MenuSuperior
            // 
            panel_MenuSuperior.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel_MenuSuperior.BackColor = System.Drawing.SystemColors.Menu;
            panel_MenuSuperior.Controls.Add(btn_BoletinOficial);
            panel_MenuSuperior.Controls.Add(btn_Redactador);
            panel_MenuSuperior.Controls.Add(btn_Mecanografia);
            panel_MenuSuperior.Controls.Add(btn_Minimizar);
            panel_MenuSuperior.Controls.Add(label_MenuPrincipal);
            panel_MenuSuperior.Controls.Add(label_OfeliaSara);
            panel_MenuSuperior.Controls.Add(btn_Cerrar);
            panel_MenuSuperior.Location = new System.Drawing.Point(0, 0);
            panel_MenuSuperior.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_MenuSuperior.Name = "panel_MenuSuperior";
            panel_MenuSuperior.Size = new System.Drawing.Size(667, 39);
            panel_MenuSuperior.TabIndex = 17;
            panel_MenuSuperior.MouseDown += Panel_MenuSuperior_MouseDown;
            // 
            // btn_BoletinOficial
            // 
            btn_BoletinOficial.BackgroundImage = Properties.Resources.EscudoPolicia_PNG;
            btn_BoletinOficial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_BoletinOficial.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_BoletinOficial.FlatAppearance.BorderSize = 0;
            btn_BoletinOficial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_BoletinOficial.Location = new System.Drawing.Point(4, 3);
            btn_BoletinOficial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_BoletinOficial.Name = "btn_BoletinOficial";
            btn_BoletinOficial.Size = new System.Drawing.Size(36, 35);
            btn_BoletinOficial.TabIndex = 19;
            btn_BoletinOficial.UseVisualStyleBackColor = true;
            btn_BoletinOficial.Click += Btn_BoletinOficial_Click;
            // 
            // btn_Redactador
            // 
            btn_Redactador.BackgroundImage = Properties.Resources.microfono24;
            btn_Redactador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_Redactador.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Redactador.FlatAppearance.BorderSize = 0;
            btn_Redactador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Redactador.Location = new System.Drawing.Point(462, 1);
            btn_Redactador.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Redactador.Name = "btn_Redactador";
            btn_Redactador.Size = new System.Drawing.Size(37, 37);
            btn_Redactador.TabIndex = 22;
            btn_Redactador.UseVisualStyleBackColor = true;
            btn_Redactador.Click += Btn_Redactador_Click;
            btn_Redactador.MouseDown += Btn_MouseDown;
            btn_Redactador.MouseLeave += Btn_MouseLeave;
            btn_Redactador.MouseHover += Btn_MouseHover;
            btn_Redactador.MouseUp += Btn_MouseUp;
            // 
            // btn_Mecanografia
            // 
            btn_Mecanografia.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_Mecanografia.BackgroundImage");
            btn_Mecanografia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_Mecanografia.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Mecanografia.FlatAppearance.BorderSize = 0;
            btn_Mecanografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Mecanografia.Location = new System.Drawing.Point(513, 1);
            btn_Mecanografia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Mecanografia.Name = "btn_Mecanografia";
            btn_Mecanografia.Size = new System.Drawing.Size(49, 37);
            btn_Mecanografia.TabIndex = 21;
            btn_Mecanografia.UseVisualStyleBackColor = true;
            btn_Mecanografia.Click += Btn_Mecanografia_Click;
            btn_Mecanografia.MouseDown += Btn_MouseDown;
            btn_Mecanografia.MouseLeave += Btn_MouseLeave;
            btn_Mecanografia.MouseHover += Btn_MouseHover;
            btn_Mecanografia.MouseUp += Btn_MouseUp;
            // 
            // btn_Minimizar
            // 
            btn_Minimizar.BackColor = System.Drawing.SystemColors.ButtonFace;
            btn_Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Minimizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btn_Minimizar.FlatAppearance.BorderSize = 2;
            btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Minimizar.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Minimizar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            btn_Minimizar.Location = new System.Drawing.Point(603, 6);
            btn_Minimizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Minimizar.Name = "btn_Minimizar";
            btn_Minimizar.Size = new System.Drawing.Size(29, 29);
            btn_Minimizar.TabIndex = 20;
            btn_Minimizar.Text = "-";
            btn_Minimizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            toolTip1.SetToolTip(btn_Minimizar, "Minimizar");
            btn_Minimizar.UseVisualStyleBackColor = false;
            // 
            // label_MenuPrincipal
            // 
            label_MenuPrincipal.AutoSize = true;
            label_MenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_MenuPrincipal.Location = new System.Drawing.Point(43, 10);
            label_MenuPrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_MenuPrincipal.Name = "label_MenuPrincipal";
            label_MenuPrincipal.Size = new System.Drawing.Size(136, 24);
            label_MenuPrincipal.TabIndex = 19;
            label_MenuPrincipal.Text = "Menu Principal";
            // 
            // label_OfeliaSara
            // 
            label_OfeliaSara.AutoSize = true;
            label_OfeliaSara.Cursor = System.Windows.Forms.Cursors.Hand;
            label_OfeliaSara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label_OfeliaSara.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Italic);
            label_OfeliaSara.Location = new System.Drawing.Point(268, 6);
            label_OfeliaSara.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_OfeliaSara.Name = "label_OfeliaSara";
            label_OfeliaSara.Size = new System.Drawing.Size(135, 33);
            label_OfeliaSara.TabIndex = 16;
            label_OfeliaSara.Text = "Ofelia - Sara";
            label_OfeliaSara.Click += Label_OfeliaSara_Click;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btn_Cerrar.FlatAppearance.BorderSize = 2;
            btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Cerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_Cerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            btn_Cerrar.Location = new System.Drawing.Point(635, 6);
            btn_Cerrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.Size = new System.Drawing.Size(29, 29);
            btn_Cerrar.TabIndex = 17;
            btn_Cerrar.Text = "X";
            btn_Cerrar.UseVisualStyleBackColor = false;
            btn_Cerrar.Click += Btn_Cerrar_Click;
            // 
            // menu_Configurar
            // 
            menu_Configurar.ImageScalingSize = new System.Drawing.Size(20, 20);
            menu_Configurar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { aGREGARToolStripMenuItem, bUSCARToolStripMenuItem, salirToolStripMenuItem });
            menu_Configurar.Name = "menu_Configurar";
            menu_Configurar.Size = new System.Drawing.Size(146, 82);
            // 
            // aGREGARToolStripMenuItem
            // 
            aGREGARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { iNSTRUCTORToolStripMenuItem, sECToolStripMenuItem, uFIDToolStripMenuItem, aGENTEFISCALToolStripMenuItem, dEPENToolStripMenuItem, sELLOSToolStripMenuItem });
            aGREGARToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            aGREGARToolStripMenuItem.Image = Properties.Resources.editar;
            aGREGARToolStripMenuItem.Name = "aGREGARToolStripMenuItem";
            aGREGARToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            aGREGARToolStripMenuItem.Text = "AGREGAR";
            // 
            // iNSTRUCTORToolStripMenuItem
            // 
            iNSTRUCTORToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            iNSTRUCTORToolStripMenuItem.Image = Properties.Resources.editar;
            iNSTRUCTORToolStripMenuItem.Name = "iNSTRUCTORToolStripMenuItem";
            iNSTRUCTORToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            iNSTRUCTORToolStripMenuItem.Text = "INSTRUCTOR";
            // 
            // sECToolStripMenuItem
            // 
            sECToolStripMenuItem.Image = Properties.Resources.editar;
            sECToolStripMenuItem.Name = "sECToolStripMenuItem";
            sECToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            sECToolStripMenuItem.Text = "SECRETARIO";
            // 
            // uFIDToolStripMenuItem
            // 
            uFIDToolStripMenuItem.Image = Properties.Resources.editar;
            uFIDToolStripMenuItem.Name = "uFIDToolStripMenuItem";
            uFIDToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            uFIDToolStripMenuItem.Text = "U.F.I.D.";
            // 
            // aGENTEFISCALToolStripMenuItem
            // 
            aGENTEFISCALToolStripMenuItem.Image = Properties.Resources.editar;
            aGENTEFISCALToolStripMenuItem.Name = "aGENTEFISCALToolStripMenuItem";
            aGENTEFISCALToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            aGENTEFISCALToolStripMenuItem.Text = "AGENTE FISCAL";
            // 
            // dEPENToolStripMenuItem
            // 
            dEPENToolStripMenuItem.Image = Properties.Resources.editar;
            dEPENToolStripMenuItem.Name = "dEPENToolStripMenuItem";
            dEPENToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            dEPENToolStripMenuItem.Text = "DEPENDENCIA";
            // 
            // sELLOSToolStripMenuItem
            // 
            sELLOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mEDALLAToolStripMenuItem, eSCALERAToolStripMenuItem, fOLIADORToolStripMenuItem });
            sELLOSToolStripMenuItem.Image = Properties.Resources.editar;
            sELLOSToolStripMenuItem.Name = "sELLOSToolStripMenuItem";
            sELLOSToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            sELLOSToolStripMenuItem.Text = "SELLOS";
            // 
            // mEDALLAToolStripMenuItem
            // 
            mEDALLAToolStripMenuItem.Image = Properties.Resources.EscudoPolicia_PNG;
            mEDALLAToolStripMenuItem.Name = "mEDALLAToolStripMenuItem";
            mEDALLAToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            mEDALLAToolStripMenuItem.Text = "MEDALLA";
            // 
            // eSCALERAToolStripMenuItem
            // 
            eSCALERAToolStripMenuItem.Image = Properties.Resources.EscudoPolicia_PNG;
            eSCALERAToolStripMenuItem.Name = "eSCALERAToolStripMenuItem";
            eSCALERAToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            eSCALERAToolStripMenuItem.Text = "ESCALERA";
            // 
            // fOLIADORToolStripMenuItem
            // 
            fOLIADORToolStripMenuItem.Image = Properties.Resources.EscudoPolicia_PNG;
            fOLIADORToolStripMenuItem.Name = "fOLIADORToolStripMenuItem";
            fOLIADORToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            fOLIADORToolStripMenuItem.Text = "FOLIADOR";
            // 
            // bUSCARToolStripMenuItem
            // 
            bUSCARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { nIPPToolStripMenuItem, cARATULAToolStripMenuItem, vICTIMAToolStripMenuItem, iMPUTADOToolStripMenuItem, fECHAToolStripMenuItem, sECRETARIOToolStripMenuItem, iNSTRUCTORToolStripMenuItem1, dEPENDENCIAToolStripMenuItem });
            bUSCARToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("bUSCARToolStripMenuItem.Image");
            bUSCARToolStripMenuItem.Name = "bUSCARToolStripMenuItem";
            bUSCARToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            bUSCARToolStripMenuItem.Text = "BUSCAR";
            // 
            // nIPPToolStripMenuItem
            // 
            nIPPToolStripMenuItem.Image = Properties.Resources.buscar75_;
            nIPPToolStripMenuItem.Name = "nIPPToolStripMenuItem";
            nIPPToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            nIPPToolStripMenuItem.Text = "N° IPP";
            // 
            // cARATULAToolStripMenuItem
            // 
            cARATULAToolStripMenuItem.Image = Properties.Resources.buscar75_;
            cARATULAToolStripMenuItem.Name = "cARATULAToolStripMenuItem";
            cARATULAToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            cARATULAToolStripMenuItem.Text = "CARATULA";
            // 
            // vICTIMAToolStripMenuItem
            // 
            vICTIMAToolStripMenuItem.Image = Properties.Resources.buscar75_;
            vICTIMAToolStripMenuItem.Name = "vICTIMAToolStripMenuItem";
            vICTIMAToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            vICTIMAToolStripMenuItem.Text = "VICTIMA";
            // 
            // iMPUTADOToolStripMenuItem
            // 
            iMPUTADOToolStripMenuItem.Image = Properties.Resources.buscar75_;
            iMPUTADOToolStripMenuItem.Name = "iMPUTADOToolStripMenuItem";
            iMPUTADOToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            iMPUTADOToolStripMenuItem.Text = "IMPUTADO";
            // 
            // fECHAToolStripMenuItem
            // 
            fECHAToolStripMenuItem.Image = Properties.Resources.buscar75_;
            fECHAToolStripMenuItem.Name = "fECHAToolStripMenuItem";
            fECHAToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            fECHAToolStripMenuItem.Text = "FECHA";
            // 
            // sECRETARIOToolStripMenuItem
            // 
            sECRETARIOToolStripMenuItem.Image = Properties.Resources.buscar75_;
            sECRETARIOToolStripMenuItem.Name = "sECRETARIOToolStripMenuItem";
            sECRETARIOToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            sECRETARIOToolStripMenuItem.Text = "SECRETARIO";
            // 
            // iNSTRUCTORToolStripMenuItem1
            // 
            iNSTRUCTORToolStripMenuItem1.Image = Properties.Resources.buscar75_;
            iNSTRUCTORToolStripMenuItem1.Name = "iNSTRUCTORToolStripMenuItem1";
            iNSTRUCTORToolStripMenuItem1.Size = new System.Drawing.Size(191, 26);
            iNSTRUCTORToolStripMenuItem1.Text = "INSTRUCTOR";
            // 
            // dEPENDENCIAToolStripMenuItem
            // 
            dEPENDENCIAToolStripMenuItem.Image = Properties.Resources.buscar75_;
            dEPENDENCIAToolStripMenuItem.Name = "dEPENDENCIAToolStripMenuItem";
            dEPENDENCIAToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            dEPENDENCIAToolStripMenuItem.Text = "DEPENDENCIA";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Image = Properties.Resources.atras;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackColor = System.Drawing.Color.FromArgb(0, 154, 174);
            ClientSize = new System.Drawing.Size(667, 273);
            Controls.Add(panel_MenuSuperior);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(706, 747);
            MinimizeBox = false;
            Name = "MenuPrincipal";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "MENU PRINCIPAL";
            Load += MenuPrincipal_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(panel_MenuSuperior, 0);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_Leyes).EndInit();
            panel_MenuSuperior.ResumeLayout(false);
            panel_MenuSuperior.PerformLayout();
            menu_Configurar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox btn_Leyes;
        private System.Windows.Forms.Button btn_InicioCierre;
        private System.Windows.Forms.Button btn_Expedientes;
        private System.Windows.Forms.Button btn_Contravenciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Configurar;
        private System.Windows.Forms.ContextMenuStrip menu_Configurar;
        private System.Windows.Forms.ToolStripMenuItem aGREGARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNSTRUCTORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sECToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uFIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aGENTEFISCALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUSCARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nIPPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cARATULAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vICTIMAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMPUTADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fECHAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sECRETARIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNSTRUCTORToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dEPENDENCIAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEPENToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sELLOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mEDALLAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSCALERAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fOLIADORToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private Ofelia_Sara.Controles.General.CustomComboBox comboBox_Buscar;
        private System.Windows.Forms.Button btn_BuscarTarea;
        private System.Windows.Forms.Panel panel_MenuSuperior;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Label label_OfeliaSara;
        private System.Windows.Forms.Label label_MenuPrincipal;
        private System.Windows.Forms.Button btn_Minimizar;
        private System.Windows.Forms.Button btn_Mecanografia;
        private System.Windows.Forms.Button btn_Redactador;
        private System.Windows.Forms.Button btn_BoletinOficial;
    }    
 }


