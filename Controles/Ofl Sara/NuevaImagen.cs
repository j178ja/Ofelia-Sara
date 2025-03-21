﻿using Ofelia_Sara.Formularios.General.Mensajes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ofelia_Sara.Controles.Ofl_Sara
{
    public partial class NuevaImagen : PictureBox
    {
        private Image originalImage; // Almacena la imagen original
        private Image hoverImage;   // Imagen para mostrar en el hover

        public NuevaImagen()
        {
            // Configurar propiedades iniciales
            this.SizeMode = PictureBoxSizeMode.CenterImage; // Escalar imagen
            this.BorderStyle = BorderStyle.FixedSingle;      // Borde visible
            this.BackColor = SystemColors.ControlLight;
            this.AllowDrop = true; // Permitir arrastrar y soltar
            this.Size = new Size(97, 116);
            this.Cursor = Cursors.Hand;

            // Establecer una imagen predeterminada
            this.Image = Properties.Resources.agregar_imagen; // Imagen predeterminada
            originalImage = this.Image; // Guardar como imagen original

            // Suscribir eventos
            this.DragEnter += NuevaImagen_DragEnter;
            this.DragDrop += NuevaImagen_DragDrop;
            this.Click += NuevaImagen_Click;
            this.MouseHover += NuevaImagen_MouseHover;
            this.MouseLeave += NuevaImagen_MouseLeave;
        }


        // Propiedad para establecer la imagen de hover desde el exterior
      
        public Image HoverImage
        {
            get => hoverImage;
            set => hoverImage = value;
        }

      /// <summary>
      /// CAMBIAR DE COLOR AL POSICIONAR EL CURSOR
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void NuevaImagen_MouseHover(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                originalImage = this.Image; // Guardar la imagen original
                                            // this.Image = Properties.Resources.agregar_imagen_HOVER; // Cambiar a la imagen de hover
                                            // this.BackColor= Color.FromArgb(86, 184, 254);
                this.BackColor = SystemColors.ControlLightLight;
            }
        }


        // Evento MouseLeave
        private void NuevaImagen_MouseLeave(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                this.Image = originalImage; // Restaurar la imagen original
                                            // this.Image = Properties.Resources.agregar_imagen1;// a ser reemplazado por animacion
                this.BackColor = SystemColors.ControlLight;
            }
        }

       /// <summary>
       /// ARRASTRAR NUEVA IMAGEN 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void NuevaImagen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// SOLTAR UNA NUEVA IMAGEN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaImagen_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && IsImageFile(files[0]))
            {
                LoadImage(files[0]);
            }
        }

     /// <summary>
     /// EVENTO CLICK SOBRE IMAGEN PARA CARGAR NUEVA IMAGEN
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void NuevaImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadImage(openFileDialog.FileName);
                }
            }
        }

      
        /// <summary>
        /// verificar si el archivo es una imagen
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" ||
                   extension == ".bmp" || extension == ".gif";
        }

        /// <summary>
        /// CARGAR LA IMAGEN
        /// </summary>
        /// <param name="filePath"></param>
        private void LoadImage(string filePath)
        {
            try
            {
                using (Image tempImage = Image.FromFile(filePath))
                {
                    // Crear una copia de la imagen para evitar problemas de archivo bloqueado
                    this.Image = new Bitmap(tempImage);
                }
                // Actualizar la imagen original
                originalImage = this.Image;
                this.SizeMode = PictureBoxSizeMode.Zoom; // Escalar la imagen para ajustarse al control

            }
            catch (Exception ex)
            {
                MensajeGeneral.Mostrar($"No se pudo cargar la imagen: {ex.Message}", MensajeGeneral.TipoMensaje.Error);
            }
        }

        /// <summary>
        /// RESTAURAR IMAGEN PREDETERMINADA
        /// </summary>
        public void RestaurarImagenPredeterminada()
        {
            this.Image = Properties.Resources.agregar_imagen; // Restaurar la imagen predeterminada
            originalImage = this.Image; // Actualizar la imagen original
            this.SizeMode = PictureBoxSizeMode.CenterImage; // Volver al modo de escalado original
        }

    }
}