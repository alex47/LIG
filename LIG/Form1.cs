using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace LIG
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog exportImagesFolderDialog;

        private Image image;
        private Image imageOriginal;
        private Image imageBoxes;

        //The main image and the 3 cloning images
        private Bitmap bmpImage;
        private Bitmap bmpImage1;
        private Bitmap bmpImage2;
        private Bitmap bmpImage3;

        private Graphics g;
        private Graphics g1;
        private Graphics g2;
        private Graphics g3;

        //These variables are necessary to determine the position of the cloning boxes
        private Point pos;
        private Point posPrev;
        private Point posPrev2;

        private bool _mouse_down;

        /*
         * Without this 3 pixel wide gap in the right and bottom border
         * the bitmap the clones the part of the image would go
         * beyond the image, throwing System.OutOfMemoryException
         */
        private int GAP = 3;

        public Form1(string filePath)
        {
            InitializeComponent();

            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            imageBoxes = Properties.Resources.LIG;

            exportImagesFolderDialog = new System.Windows.Forms.FolderBrowserDialog();

            pos = new Point(0, 0);
            posPrev = new Point(0, 0);
            posPrev2 = new Point(0, 0);

            picturePanel.AutoScroll = true;
            zoomTrackBar.Enabled = false;
            exportImagesButon.Enabled = false;

            zoomPictureBox.Image = (Image)(new Bitmap(Properties.Resources.zoom, new Size(zoomPictureBox.Width, zoomPictureBox.Height)));

            loadImage(filePath);
        }

        public Form1()
        {
            InitializeComponent();

            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            imageBoxes = Properties.Resources.LIG;

            exportImagesFolderDialog = new System.Windows.Forms.FolderBrowserDialog();

            pos = new Point(0, 0);
            posPrev = new Point(0, 0);
            posPrev2 = new Point(0, 0);

            picturePanel.AutoScroll = true;
            zoomTrackBar.Enabled = false;
            exportImagesButon.Enabled = false;

            zoomPictureBox.Image = (Image)(new Bitmap(Properties.Resources.zoom, new Size(zoomPictureBox.Width, zoomPictureBox.Height)));
        }
        
        private void loadImageButtonClicked(object sender, EventArgs e)
        {
            OpenFileDialog openImageFileDialog = new OpenFileDialog();

            openImageFileDialog.Filter = "Image Files (jpg, png)|*.jpg;*.jpeg;*.png";
            openImageFileDialog.Title = "Select an image";

            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadImage(openImageFileDialog.FileName);
            }
        }

        private void loadImage(string filePath)
        {
            try
            {
                image = Image.FromFile(filePath);
            }
            catch
            {
                //Big images can not be loaded always and might throw System.OutOfMemoryException
                //Tested with 10000x10000 resolution ~20MB image and crashed
/*TODO: fix memory leak (the image above would allocate more than 400 MB memory)*/
                MessageBox.Show("Unable to load the image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            imageOriginal = image;

            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);

            //Filtering GIF files that are disguised as JPG or PNG files in the extension (Why would anyone do that?)
            if (image.GetFrameCount(dimension) > 1)
            {
                MessageBox.Show("Unable to work with animated images!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Scaling the image so that the boxes are able to cover the whole image
            int newWidth, newHeight;

            if (image.Width > image.Height)
            {
                float ratio = (float)imageBoxes.Height / image.Height;

                newWidth = (int)(ratio * image.Width);
                newHeight = (int)(ratio * image.Height);

                //Some resolutions work in a mysterious way
                if (newWidth < imageBoxes.Width)
                {
                    ratio = (float)imageBoxes.Width / image.Width;

                    newWidth = (int)(ratio * image.Width);
                    newHeight = (int)(ratio * image.Height);
                }
            }
            else
            {
                float ratio = (float)imageBoxes.Width / image.Width;

                newWidth = (int)(ratio * image.Width);
                newHeight = (int)(ratio * image.Height);

                //Some resolutions work in a mysterious way
                if(newHeight < imageBoxes.Height)
                {
                    ratio = (float)imageBoxes.Height / image.Height;

                    newWidth = (int)(ratio * image.Width);
                    newHeight = (int)(ratio * image.Height);
                }
            }

            pos.X = 0;
            pos.Y = 0;

            image = (Image)(new Bitmap(image, new Size(newWidth, newHeight)));

            mainPictureBox.Image = image;
            bmpImage = new Bitmap(image.Width + GAP, image.Height + GAP);

            zoomTrackBar.Value = 0;

            g = Graphics.FromImage(bmpImage);
            g.DrawImage(image, 0, 0, image.Width, image.Height);

            mainPictureBox.Refresh();
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            pictureBox3.Refresh();

            fileLocationTextBox.Text = filePath;

            zoomTrackBar.Enabled = true;
            exportImagesButon.Enabled = true;
            _mouse_down = false;
        }
        
        private void zoomTrackBarScroll(object sender, EventArgs e)
        {
            mainPictureBox.Image = (Image)(new Bitmap(imageOriginal, new Size(image.Width + image.Width * zoomTrackBar.Value / 10, image.Height + image.Height * zoomTrackBar.Value / 10)));
            bmpImage = new Bitmap(mainPictureBox.Image);

            drawingBoxesOnMainImage();
        }

        private void drawingBoxesOnMainImage()
        {
            //Preventing the boxes to go out of screen and preventing crash
            if (pos.X < 0)
            {
                pos.X = 0;
            }

            if (pos.Y < 0)
            {
                pos.Y = 0;
            }

            if (pos.X + imageBoxes.Width >= mainPictureBox.Width - GAP)
            {
                pos.X = mainPictureBox.Width - imageBoxes.Width - GAP;
            }

            if (pos.Y + imageBoxes.Height >= mainPictureBox.Height - GAP)
            {
                pos.Y = mainPictureBox.Height - imageBoxes.Height - GAP;
            }

            mainPictureBox.Refresh();
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            pictureBox3.Refresh();
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _mouse_down = true;

            posPrev = e.Location;
            posPrev2 = pos;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _mouse_down = false;
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mainPictureBox.Image != null && _mouse_down)
            {
                pos.X = posPrev2.X + e.Location.X - posPrev.X;
                pos.Y = posPrev2.Y + e.Location.Y - posPrev.Y;

                drawingBoxesOnMainImage();
            }
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(imageBoxes, new Point(pos.X, pos.Y));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(mainPictureBox.Image != null)
            {
                bmpImage1 = bmpImage.Clone(new Rectangle(pos.X, pos.Y, 250, 250), bmpImage.PixelFormat);

                g1 = e.Graphics;
                g1.DrawImage(bmpImage1, new Point(0, 0));
            }            
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (mainPictureBox.Image != null)
            {
                bmpImage2 = bmpImage.Clone(new Rectangle(pos.X + 312, pos.Y + 103, 124, 124), bmpImage.PixelFormat);

                g2 = e.Graphics;
                g2.DrawImage(bmpImage2, new Point(0, 0));
            }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            if (mainPictureBox.Image != null)
            {
                bmpImage3 = bmpImage.Clone(new Rectangle(pos.X + 312, pos.Y + 279, 124, 124), bmpImage.PixelFormat);

                g3 = e.Graphics;
                g3.DrawImage(bmpImage3, new Point(0, 0));
            }
        }

        private void exportImagesButon_Click(object sender, EventArgs e)
        {
            if (exportImagesFolderDialog.ShowDialog() == DialogResult.OK)
            {
                String folderName = exportImagesFolderDialog.SelectedPath;

                bmpImage1.Save(folderName + "\\" + "1.png");
                bmpImage2.Save(folderName + "\\" + "2.png");
                bmpImage3.Save(folderName + "\\" + "3.png");

/*TODO: check if files actually exist*/

                if(MessageBox.Show("Images exported successfully!\nWould you like to open the folder?", "Done!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(folderName);
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            //Why do lower case and upper case file extensions exist?
            if (files[0].EndsWith(".jpg") || files[0].EndsWith(".JPG") || files[0].EndsWith(".jpeg") || files[0].EndsWith(".JPEG") || files[0].EndsWith(".png") || files[0].EndsWith(".PNG"))
            {
                loadImage(files[0]);
            }
            else
            {
                MessageBox.Show("File format not supported!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
