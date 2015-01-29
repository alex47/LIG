namespace LIG
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loadImageButton = new System.Windows.Forms.Button();
            this.fileLocationTextBox = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.exportImagesButon = new System.Windows.Forms.Button();
            this.zoomPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.picturePanel.SuspendLayout();
            this.previewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(8, 504);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(75, 23);
            this.loadImageButton.TabIndex = 5;
            this.loadImageButton.Text = "Open image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButtonClicked);
            // 
            // fileLocationTextBox
            // 
            this.fileLocationTextBox.Location = new System.Drawing.Point(89, 507);
            this.fileLocationTextBox.Name = "fileLocationTextBox";
            this.fileLocationTextBox.ReadOnly = true;
            this.fileLocationTextBox.Size = new System.Drawing.Size(558, 20);
            this.fileLocationTextBox.TabIndex = 6;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(654, 18);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 390);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // picturePanel
            // 
            this.picturePanel.Controls.Add(this.mainPictureBox);
            this.picturePanel.Location = new System.Drawing.Point(8, 18);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(640, 480);
            this.picturePanel.TabIndex = 11;
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Controls.Add(this.pictureBox1);
            this.previewGroupBox.Controls.Add(this.pictureBox3);
            this.previewGroupBox.Controls.Add(this.pictureBox2);
            this.previewGroupBox.Location = new System.Drawing.Point(705, 18);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(470, 458);
            this.previewGroupBox.TabIndex = 15;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // exportImagesButon
            // 
            this.exportImagesButon.Location = new System.Drawing.Point(705, 505);
            this.exportImagesButon.Name = "exportImagesButon";
            this.exportImagesButon.Size = new System.Drawing.Size(75, 23);
            this.exportImagesButon.TabIndex = 15;
            this.exportImagesButon.Text = "Export";
            this.exportImagesButon.UseVisualStyleBackColor = true;
            this.exportImagesButon.Click += new System.EventHandler(this.exportImagesButon_Click);
            // 
            // zoomPictureBox
            // 
            this.zoomPictureBox.Location = new System.Drawing.Point(654, 414);
            this.zoomPictureBox.Name = "zoomPictureBox";
            this.zoomPictureBox.Size = new System.Drawing.Size(45, 45);
            this.zoomPictureBox.TabIndex = 16;
            this.zoomPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(324, 299);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(124, 124);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox3_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(324, 123);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 124);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPictureBox.Location = new System.Drawing.Point(-1, -1);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(630, 470);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBox_Paint);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 536);
            this.Controls.Add(this.exportImagesButon);
            this.Controls.Add(this.zoomPictureBox);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.fileLocationTextBox);
            this.Controls.Add(this.loadImageButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LIG";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.previewGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoomPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.TextBox fileLocationTextBox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.Button exportImagesButon;
        private System.Windows.Forms.PictureBox zoomPictureBox;
    }
}

