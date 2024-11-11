using System;
using System.Drawing;
using System.Windows.Forms;

namespace MeuComponenteGrafico
{
    public enum ProgressBarStyle
    {
        Horizontal,
        Vertical,
        Circular
    }

    public partial class ProgressBarControl : Control
    {
        private ProgressBarStyle style = ProgressBarStyle.Horizontal;
        private int progressValue = 0;
        private Color progressColor = Color.CornflowerBlue;
        private Color backgroundColor = Color.LightGray;
        private int thickness = 8;
        private bool isAnimating = true;
        private Timer animationTimer;

        public ProgressBarControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            animationTimer = new Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += (s, e) =>
            {
                if (isAnimating)
                {
                    progressValue = (progressValue + 1) % 101;
                    Invalidate();
                }
            };
            animationTimer.Start();
        }


        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = Math.Max(0, Math.Min(100, value));
                Invalidate();
            }
        }

        public ProgressBarStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                Invalidate();
            }
        }

        public Color ProgressColor
        {
            get { return progressColor; }
            set
            {
                progressColor = value;
                Invalidate();
            }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        public int Thickness
        {
            get { return thickness; }
            set
            {
                thickness = value;
                Invalidate();
            }
        }

        public bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (style)
            {
                case ProgressBarStyle.Horizontal:
                    DrawHorizontalProgress(e.Graphics);
                    break;
                case ProgressBarStyle.Vertical:
                    DrawVerticalProgress(e.Graphics);
                    break;
                case ProgressBarStyle.Circular:
                    
                    DrawCircularProgress(e.Graphics);
                    break;
            }
        }

        private void DrawHorizontalProgress(Graphics g)
        {
            float fillWidth = (Width * progressValue) / 100f;
            g.FillRectangle(new SolidBrush(progressColor), 0, 0, fillWidth, Height);
            g.FillRectangle(new SolidBrush(backgroundColor), fillWidth, 0, Width - fillWidth, Height);
        }

        private void DrawVerticalProgress(Graphics g)
        {
            float fillHeight = (Height * progressValue) / 100f;
            g.FillRectangle(new SolidBrush(progressColor), 0, Height - fillHeight, Width, fillHeight);
            g.FillRectangle(new SolidBrush(backgroundColor), 0, 0, Width, Height - fillHeight);
        }

        private void DrawCircularProgress(Graphics g)
        {
            float angle = (360f * progressValue) / 100f; 
            float startAngle = -90 + angle; 

            Rectangle bounds = new Rectangle(thickness, thickness, Width - 2 * thickness, Height - 2 * thickness);

            using (Pen backgroundPen = new Pen(backgroundColor, thickness))
            using (Pen progressPen = new Pen(progressColor, thickness))
            {
                g.DrawArc(backgroundPen, bounds, 0, 360);
                g.DrawArc(progressPen, bounds, startAngle, angle);
            }
        }

    }
}
