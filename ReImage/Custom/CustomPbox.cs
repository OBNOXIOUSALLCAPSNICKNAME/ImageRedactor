using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace ReImage
{
    public class CustomPbox : UserControl
    {
        Bitmap image;
        PointF visibleCenter;
        float zoom = 1f;
        MouseState mouseState;
        Point startDragged;
        PointF startDraggedVisibleCenter;
        int sourceImageWidth;
        int sourceImageHeight;

        public event EventHandler ZoomValueChanged;
        public event EventHandler VisibleCenterChanged;

        [DefaultValue(0.1f)]
        public float ZoomDelta { get; set; }
        [DefaultValue(true)]
        public bool AllowUserDrag { get; set; }
        [DefaultValue(true)]
        public bool AllowUserZoom { get; set; }
        public bool SetImageOnCenter = true;
        public InterpolationMode InterpolationMode { get; set; }
        public InterpolationMode InterpolationModeZoomOut { get; set; }
        public PixelOffsetMode PixelOffsetMode { get; set; }

        public bool Locked = false;

        public CustomPbox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);
            ZoomDelta = 0.1f;
            AllowUserDrag = true;
            AllowUserZoom = true;
            InterpolationMode = InterpolationMode.Bicubic;
            InterpolationModeZoomOut = InterpolationMode.Bilinear;
            PixelOffsetMode = PixelOffsetMode.HighQuality;
        }

        [DefaultValue(null)]
        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;

                if (value == null)
                {
                    sourceImageWidth = 0;
                    sourceImageHeight = 0;
                    VisibleCenter = new PointF(0, 0);
                }
                else
                {
                    sourceImageWidth = value.Width;
                    sourceImageHeight = value.Height;
                    if (SetImageOnCenter)
                    {
                        VisibleCenter = new PointF(sourceImageWidth / 2f, sourceImageHeight / 2f);
                        SetImageOnCenter = false;
                    }
                }

                Refresh();
            }
        }

        public void UpdateImage(Bitmap image)
        {
            this.image = image;

            if (image != null)
            {
                sourceImageWidth = image.Width;
                sourceImageHeight = image.Height;
            }

            Invalidate();
        }

        [DefaultValue(1f)]
        public float Zoom
        {
            get { return zoom; }
            set
            {
                if (Math.Abs(value) <= float.Epsilon)
                    return;
                zoom = value;
                var handler = ZoomValueChanged;
                if (handler != null) handler(this, EventArgs.Empty);
                Invalidate();
            }
        }

        public PointF VisibleCenter
        {
            get { return visibleCenter; }
            set
            {
                visibleCenter = value;
                OnVisibleCenterChanged();
            }
        }

        public virtual void OnVisibleCenterChanged()
        {
            if (VisibleCenterChanged != null)
                VisibleCenterChanged(this, EventArgs.Empty);
            Invalidate();
        }
        
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (!AllowUserZoom)
                return;

            if (e.Delta > 0)
                IncreazeZoom();

            if (e.Delta < 0)
                DecreaseZoom();
            var handler = ZoomValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (AllowUserDrag)
                if (e.Button == MouseButtons.Left)
                {
                    Cursor = Cursors.SizeAll;
                    mouseState = MouseState.Drag;
                }

            startDragged = e.Location;
            startDraggedVisibleCenter = VisibleCenter;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor = Cursors.Default;
            mouseState = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (mouseState == MouseState.Drag)
            {
                var dx = e.Location.X - startDragged.X;
                var dy = e.Location.Y - startDragged.Y;
                VisibleCenter = new PointF(startDraggedVisibleCenter.X - dx / zoom, startDraggedVisibleCenter.Y - dy / zoom);
            }
        }

        public void DecreaseZoom()
        {
            Zoom -= 0.5f;
        }

        public void IncreazeZoom()
        {
            Zoom += 0.5f;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Locked = true;
            if (image == null)
                return;

            e.Graphics.ResetTransform();
            e.Graphics.InterpolationMode = Zoom < 1f ? InterpolationModeZoomOut : InterpolationMode;
            e.Graphics.PixelOffsetMode = PixelOffsetMode;

            if (mouseState == MouseState.Drag)
            {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            }

            var p = ImagePointToClient(Point.Empty);

            e.Graphics.DrawImage(image, p.X, p.Y, image.Width * Zoom, image.Height * Zoom);

            base.OnPaint(e);
            Locked = false;
        }

        public Point ClientToImagePoint(Point point)
        {
            return Point.Round(ClientToImagePoint((PointF)point));
        }

        public Point ImagePointToClient(Point point)
        {
            return Point.Round(ImagePointToClient((PointF)point));
        }

        public PointF ClientToImagePoint(PointF point)
        {
            var dx = (point.X - ClientSize.Width / 2f) / Zoom + visibleCenter.X;
            var dy = (point.Y - ClientSize.Height / 2f) / Zoom + visibleCenter.Y;
            return new PointF(dx, dy);
        }

        public PointF ImagePointToClient(PointF point)
        {
            var dx = (point.X - visibleCenter.X) * Zoom + ClientSize.Width / 2f;
            var dy = (point.Y - visibleCenter.Y) * Zoom + ClientSize.Height / 2f;
            return new PointF(dx, dy);
        }

        public Image GetScreenshot()
        {
            Image img = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (var gr = Graphics.FromImage(img))
                OnPaint(new PaintEventArgs(gr, ClientRectangle));
            return img;
        }

        enum MouseState
        {
            None, Drag
        }
    }
}
