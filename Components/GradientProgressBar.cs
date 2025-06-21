using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SG_Lua_IDE.Components
{
    public class GradientProgressBar : ProgressBar
    {
        public GradientProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            const int cornerRadius = 8;
            
            // 绘制背景
            using (var backgroundBrush = new SolidBrush(Color.FromArgb(40, 40, 55)))
            {
                var bgRect = new Rectangle(0, 0, Width, Height);
                FillRoundedRectangle(e.Graphics, backgroundBrush, bgRect, cornerRadius);
            }
            
            // 绘制进度
            if (Value > 0)
            {
                var progressWidth = (int)(Width * ((double)Value / Maximum));
                
                using (var progressBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, progressWidth, Height),
                    Color.FromArgb(0, 150, 255),
                    Color.FromArgb(0, 100, 200),
                    LinearGradientMode.Horizontal))
                {
                    var progressRect = new Rectangle(0, 0, progressWidth, Height);
                    FillRoundedRectangle(e.Graphics, progressBrush, progressRect, cornerRadius);
                }
                
                // 添加高光效果
                using (var highlightBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, progressWidth, Height / 2),
                    Color.FromArgb(100, 255, 255, 255),
                    Color.Transparent,
                    LinearGradientMode.Vertical))
                {
                    FillRoundedRectangle(e.Graphics, highlightBrush, 
                        new Rectangle(0, 0, progressWidth, Height / 2), 
                        cornerRadius);
                }
            }
            
            // 绘制边框
            using (var borderPen = new Pen(Color.FromArgb(80, 80, 100), 1))
            {
                var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                DrawRoundedRectangle(e.Graphics, borderPen, borderRect, cornerRadius);
            }
        }
        
        private void FillRoundedRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
        {
            using (var path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }
        
        private void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
        {
            using (var path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }
        
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}