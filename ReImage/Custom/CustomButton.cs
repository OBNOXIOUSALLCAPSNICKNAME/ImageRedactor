using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace ReImage
{
    class CustomButton : UserControl
    {
        Color PressedBackColor = new Color();
        Color PressedFontColor = new Color();
        Color NormalBackColor = new Color();
        Color NormalFontColor = new Color();
        StringFormat Align = new StringFormat();
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; Invalidate(); }
        }
        public bool ClickEffect { get; set; }
        int alpha = 255;
        public int Alpha
        {
            get { return alpha; }
            set
            {
                if (value <= 255 && value >= 0)
                    alpha = value;
            }
        }
        [DefaultValue(typeof(Color), "0xFF0000")]
        public Color ActiveColor { get; set; }
        public CustomButton()
        {
            SetStyle(
                  ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
            UpdateStyles();
            Align.LineAlignment = StringAlignment.Center;
            Align.Alignment = StringAlignment.Center;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            NormalBackColor = BackColor;
            NormalFontColor = ForeColor;
            PressedBackColor = Color.FromArgb(Alpha,
                ActiveColor.R,
                ActiveColor.G,
                ActiveColor.B);
            PressedFontColor = NormalBackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new SolidBrush(ForeColor))
                e.Graphics.DrawString(Text, Font, brush, Width / 2, Height / 2, Align);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = ActiveColor;
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = NormalBackColor;
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!ClickEffect)
                return;
            base.OnMouseDown(e);
            BackColor = PressedBackColor;
            ForeColor = PressedFontColor;
            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!ClickEffect || !Focused)
                return;
            base.OnMouseUp(e);
            BackColor = ActiveColor;
            ForeColor = NormalFontColor;
            Refresh();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            BackColor = NormalBackColor;
            ForeColor = NormalFontColor;
            Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomButton
            // 
            this.DoubleBuffered = true;
            this.Name = "CustomButton";
            this.ResumeLayout(false);

        }
    }
}
