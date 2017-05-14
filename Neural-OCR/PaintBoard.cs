using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Neural_OCR
{
    public partial class PaintBoard : Control
    {
        private Bitmap image;
        private bool tracking = false;
        private bool scaleImage = true;

        private Shrink shrinkFilter = new Shrink(Color.FromArgb(255, 255, 255));
        private ResizeNearestNeighbor resizeFilter = new ResizeNearestNeighbor(0, 0);

        public PaintBoard()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                    ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;

            Pen blackPen = new Pen(Color.Black, 1);
            Pen bluePen = new Pen(Color.Blue, 1);
            Brush whiteBrush = new SolidBrush(Color.White);

            // draw border
            g.DrawRectangle(blackPen, 0, 0, rc.Width - 1, rc.Height - 1);

            // fill rectangle
            g.FillRectangle(whiteBrush, 1, 1, rc.Width - 2, rc.Height - 2);

            // draw image
            if (image != null)
            {
                g.DrawImage(image, 1, 1, image.Width, image.Height);
            }



            blackPen.Dispose();
            bluePen.Dispose();
            whiteBrush.Dispose();

            base.OnPaint(pe);
        }

        public void ClearImage()
        {
            int width = this.ClientRectangle.Width - 2;
            int height = this.ClientRectangle.Height - 2;
            Brush whiteBrush = new SolidBrush(Color.White);

            if (image != null)
                image.Dispose();

            // create new image
            image = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            // create graphics
            Graphics g = Graphics.FromImage(image);

            // fill rectangle
            g.FillRectangle(whiteBrush, 0, 0, width, height);

            g.Dispose();
            whiteBrush.Dispose();

            Invalidate();
        }

        private void PaintBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if ((!tracking) && (e.Button == MouseButtons.Left))
            {
                Capture = true;
                tracking = true;

                // creat a blank image
                if (image == null)
                    ClearImage();
            }
        }

        public Bitmap GetImage()
        {
            return GetImage(true);
        }
        public Bitmap GetImage(bool invalidate)
        {
            if (image == null)
                ClearImage();

            // scale image
            if (scaleImage)
            {
                // shrink image
                Bitmap tempImage = shrinkFilter.Apply(image);

                // image dimenstoin
                int width = image.Width;
                int height = image.Height;
                // shrinked image dimension
                int tw = tempImage.Width;
                int th = tempImage.Height;
                // resize factors
                float fx = (float)width / (float)tw;
                float fy = (float)height / (float)th;

                if (fx > fy)
                    fx = fy;
                // set new size of shrinked image
                int nw = (int)Math.Round(fx * tw);
                int nh = (int)Math.Round(fy * th);
                resizeFilter.NewWidth = nw;
                resizeFilter.NewHeight = nh;

                // resize image
                Bitmap tempImage2 = resizeFilter.Apply(tempImage);

                // 
                Brush whiteBrush = new SolidBrush(Color.White);

                // create graphics
                Graphics g = Graphics.FromImage(image);

                // fill rectangle
                g.FillRectangle(whiteBrush, 0, 0, width, height);

                int x = 0;
                int y = 0;

                if (nw > nh)
                {
                    y = (height - nh) / 2;
                }
                else
                {
                    x = (width - nw) / 2;
                }

                g.DrawImage(tempImage2, x, y, nw, nh);

                g.Dispose();
                whiteBrush.Dispose();

                // release temp images
                tempImage.Dispose();
                tempImage2.Dispose();
            }

            // should we repaint the control
            if (invalidate)
                Invalidate();

            return image;
        }

        private void PaintBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if ((tracking) && (e.Button == MouseButtons.Left))
            {
                Capture = false;
                tracking = false;
            }
        }

        private void PaintBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (tracking)
            {
                int x = e.X - 1;
                int y = e.Y - 1;

                if ((x > 0) && (y > 0) && (x < image.Width) && (y < image.Height))
                {
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        Graphics g = Graphics.FromImage(image);

                        // draw a point
                        g.FillEllipse(brush, x - 5, y - 5, 11, 11);

                        g.Dispose();
                    }

                    Invalidate();
                }
            }
        }
    }
}
