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
        private ProgressBar progressBar;
        private Label lblStatus;
        private bool _isRunning = true;
        private const int LOGO_SIZE = 120; // 减小Logo大小
        
        public SplashForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.ClientSize = new Size(500, 350);
            this.BackColor = Color.FromArgb(30, 30, 45);
            
            // 设置圆角
            SetRoundRegion(20);
            
            // 初始化标准进度条
            progressBar = new ProgressBar();
            progressBar.Location = new Point(30, 260);
            progressBar.Size = new Size(440, 25);
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.ForeColor = Color.FromArgb(0, 150, 255);
            this.Controls.Add(progressBar);
            
            // 初始化状态标签
            lblStatus = new Label();
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(30, 290);
            lblStatus.Text = "加载中 0%...";
            this.Controls.Add(lblStatus);
            
            // 启动旋转线程
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
        
        public void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgress), value);
                return;
            }
            progressBar.Value = value;
            lblStatus.Text = $"加载中 {value}%...";
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
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Logo.png");
                if (File.Exists(logoPath))
                {
                    using (var logo = Image.FromFile(logoPath))
                    {
                        var centerX = ClientRectangle.Width / 2;
                        var centerY = ClientRectangle.Height / 3;
                        
                        e.Graphics.TranslateTransform(centerX, centerY);
                        e.Graphics.RotateTransform(rotationAngle);
                        e.Graphics.TranslateTransform(-centerX, -centerY);
                        
                        // 减小Logo大小
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
            
            // 为进度条添加圆角效果
            using (var path = CreateRoundedRectanglePath(progressBar.Bounds, 8))
            using (var pen = new Pen(Color.FromArgb(80, 80, 100), 1))
            {
                e.Graphics.DrawPath(pen, path);
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