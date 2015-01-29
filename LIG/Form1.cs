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

        private Bitmap bmpImage;
        private Bitmap bmpImage1;
        private Bitmap bmpImage2;
        private Bitmap bmpImage3;

        private Point pos;
        private Point posPrev;
        private Point posPrev2;

        private bool _mouse_down;

        private int GAP = 3;
        
        public Form1(string filePath = null)
        {
            InitializeComponent();

            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            imageBoxes = Properties.Resources.LIG;

            exportImagesFolderDialog = new System.Windows.Forms.FolderBrowserDialog();

            pos = new Point(0, 0);
            posPrev = new Point(0, 0);
            posPrev2 = new Point(0, 0);

            picturePanel.AutoScroll = true;
            trackBar1.Enabled = false;
            exportImagesButon.Enabled = false;

            zoomPictureBox.Image = (Image)(new Bitmap(Properties.Resources.zoom, new Size( zoomPictureBox.Width, zoomPictureBox.Height)));
            
            if(filePath != null)
            {
                loadImage(filePath);
            }            
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
            image = Image.FromFile(filePath);
            imageOriginal = image;

            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);

            if (image.GetFrameCount(dimension) > 1)
            {
                MessageBox.Show("Unable to work with animated images!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float ratio;

            if (image.Width >= image.Height)
            {
                ratio = (float)imageBoxes.Height / image.Height;
            }
            else
            {
                ratio = (float)imageBoxes.Width / image.Width;
            }

            image = (Image)(new Bitmap(image, new Size((int)(image.Width * ratio), (int)(image.Height * ratio))));

            mainPictureBox.Image = image;
            bmpImage = new Bitmap(image.Width + GAP, image.Height + GAP);

            using (Graphics g = Graphics.FromImage(bmpImage))
            {
                g.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            mainPictureBox.Refresh();
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            pictureBox3.Refresh();

            fileLocationTextBox.Text = filePath;

            trackBar1.Enabled = true;
            exportImagesButon.Enabled = true;
            _mouse_down = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            mainPictureBox.Image = (Image)(new Bitmap(imageOriginal, new Size(image.Width + image.Width * trackBar1.Value / 10, image.Height + image.Height * trackBar1.Value / 10)));
            bmpImage = new Bitmap(mainPictureBox.Image);

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

                if(pos.X < 0)
                {
                    pos.X = 0;
                }

                if(pos.Y < 0)
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
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(imageBoxes, new Point(pos.X, pos.Y));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(mainPictureBox.Image != null)
            {
                bmpImage1 = bmpImage.Clone(new Rectangle(pos.X, pos.Y, 250, 250), bmpImage.PixelFormat);

                Graphics g = e.Graphics;
                g.DrawImage(bmpImage1, new Point(0, 0));
            }            
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (mainPictureBox.Image != null)
            {
                bmpImage2 = bmpImage.Clone(new Rectangle(pos.X + 312, pos.Y + 103, 124, 124), bmpImage.PixelFormat);
            
                Graphics g = e.Graphics;
                g.DrawImage(bmpImage2, new Point(0, 0));
            }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            if (mainPictureBox.Image != null)
            {
                bmpImage3 = bmpImage.Clone(new Rectangle(pos.X + 312, pos.Y + 279, 124, 124), bmpImage.PixelFormat);

                Graphics g = e.Graphics;
                g.DrawImage(bmpImage3, new Point(0, 0));
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

            if (files[0].EndsWith(".jpg") || files[0].EndsWith(".jpeg") || files[0].EndsWith(".png"))
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
