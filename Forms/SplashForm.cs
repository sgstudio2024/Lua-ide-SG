using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

namespace SG_Lua_IDE.Forms
{
    public partial class SplashForm : Form
    {
        private float rotationAngle = 0f;
        private Thread rotationThread;
        private Label lblStatus;
        private bool _isRunning = true;
        private const int LOGO_SIZE = 120;
        private int progressValue = 0; // 进度值0-100

        public SplashForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.ClientSize = new Size(500, 350);
            this.BackColor = Color.FromArgb(30, 30, 45);

            SetRoundRegion(20);

            // 状态标签
            lblStatus = new Label();
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(30, 290);
            lblStatus.Text = "加载中 0%...";
            this.Controls.Add(lblStatus);

            rotationThread = new Thread(RotateLogo);
            rotationThread.IsBackground = true;
            rotationThread.Start();
        }

        private void SetRoundRegion(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        /// <summary>
        /// 程序自绘进度条，不依赖WinForms ProgressBar
        /// </summary>
        /// <param name="value">0-100</param>
        public void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(UpdateProgress), value);
                return;
            }
            if (progressValue != value)
            {
                progressValue = Math.Max(0, Math.Min(100, value));
                lblStatus.Text = $"加载中 {progressValue}%...";
                Invalidate(new Rectangle(30, 260, 440, 25)); // 只重绘进度条区域
            }
        }

        private void RotateLogo()
        {
            while (_isRunning && !IsDisposed)
            {
                rotationAngle = (rotationAngle + 2) % 360;
                if (!IsDisposed && IsHandleCreated)
                {
                    try
                    {
                        Invoke(new Action(Invalidate));
                    }
                    catch
                    {
                        // 忽略调用错误
                    }
                }
                Thread.Sleep(30);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 绘制背景
            using (var brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(30, 30, 45),
                Color.FromArgb(15, 15, 30),
                135f))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            // 绘制旋转的Logo
            try
            {
                string logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Logo.png");
                if (System.IO.File.Exists(logoPath))
                {
                    using (var logo = Image.FromFile(logoPath))
                    {
                        var centerX = ClientRectangle.Width / 2;
                        var centerY = ClientRectangle.Height / 3;

                        e.Graphics.TranslateTransform(centerX, centerY);
                        e.Graphics.RotateTransform(rotationAngle);
                        e.Graphics.TranslateTransform(-centerX, -centerY);

                        int logoWidth = LOGO_SIZE;
                        int logoHeight = LOGO_SIZE;

                        e.Graphics.DrawImage(
                            logo,
                            new Rectangle(
                                centerX - logoWidth / 2,
                                centerY - logoHeight / 2,
                                logoWidth,
                                logoHeight
                            )
                        );

                        e.Graphics.ResetTransform();
                    }
                }
            }
            catch
            {
                // 忽略图片加载错误
            }

            // 绘制自定义进度条
            DrawCustomProgressBar(e.Graphics, new Rectangle(30, 260, 440, 25), progressValue);

            // 绘制标题
            using (var titleFont = new Font("Segoe UI", 24, FontStyle.Bold))
            using (var titleBrush = new SolidBrush(Color.FromArgb(0, 150, 255)))
            {
                var title = Program.AppName;
                var size = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, titleBrush,
                    (ClientRectangle.Width - size.Width) / 2,
                    ClientRectangle.Height / 1.8f);
            }

            // 绘制版本信息
            using (var versionFont = new Font("Segoe UI", 9))
            using (var versionBrush = new SolidBrush(Color.LightGray))
            {
                var version = $"版本 {Program.Version} - © {DateTime.Now.Year}";
                var size = e.Graphics.MeasureString(version, versionFont);
                e.Graphics.DrawString(version, versionFont, versionBrush,
                    (ClientRectangle.Width - size.Width) / 2,
                    ClientRectangle.Height - 50);
            }
        }

        /// <summary>
        /// 纯自绘圆角渐变进度条（不依赖任何WinForms控件）
        /// </summary>
        private void DrawCustomProgressBar(Graphics g, Rectangle rect, int percent)
        {
            int radius = 8;
            percent = Math.Max(0, Math.Min(100, percent));
            // 背景
            using (var bgBrush = new SolidBrush(Color.FromArgb(40, 40, 60)))
            using (var path = CreateRoundedRectanglePath(rect, radius))
            {
                g.FillPath(bgBrush, path);
            }

            // 渐变进度
            if (percent > 0)
            {
                int fillWidth = (int)(rect.Width * percent / 100.0);
                Rectangle fillRect = new Rectangle(rect.X, rect.Y, fillWidth, rect.Height);
                using (var brush = new LinearGradientBrush(
                    fillRect,
                    Color.FromArgb(160, 80, 255),
                    Color.FromArgb(120, 0, 200),
                    LinearGradientMode.Horizontal))
                using (var path = CreateRoundedRectanglePath(new Rectangle(rect.X, rect.Y, Math.Max(radius, fillWidth), rect.Height), radius))
                {
                    g.SetClip(new Rectangle(rect.X, rect.Y, fillWidth, rect.Height));
                    g.FillPath(brush, path);
                    g.ResetClip();
                }
            }

            // 边框
            using (var pen = new Pen(Color.FromArgb(80, 80, 100), 1))
            using (var path = CreateRoundedRectanglePath(rect, radius))
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _isRunning = false;
                rotationThread?.Join(100);
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // 设计器代码已包含在构造函数中
        }
    }
}