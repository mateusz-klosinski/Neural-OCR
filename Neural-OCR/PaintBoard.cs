using System.Drawing;
using System.Windows.Forms;

namespace Neural_OCR
{
    public partial class PaintBoard : Control
    {
        private Bitmap image;
        private bool tracking;

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
            image = new Bitmap(width, height);

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
                        g.FillEllipse(brush, x - 10, y - 10, 20, 20);

                        g.Dispose();
                    }

                    Invalidate();
                }
            }
        }
    }
}
