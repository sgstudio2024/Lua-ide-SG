using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SG_Lua_IDE.Forms;

namespace SG_Lua_IDE
{
    static class Program
    {
        public static string AppName = "SG-Lua IDE";
        public static string Version = "1.1.0";
        
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // 设置应用程序信息
            var assembly = Assembly.GetExecutingAssembly();
            var titleAttribute = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
            if (titleAttribute != null)
            {
                AppName = titleAttribute.Title;
            }
            
            // 创建并显示启动画面
            using (var splash = new SplashForm())
            {
                splash.Show();
                
                // 模拟加载过程
                for (int i = 0; i <= 100; i += 10)
                {
                    splash.UpdateProgress(i);
                    Application.DoEvents(); // 处理UI事件
                    Thread.Sleep(150); // 模拟加载延迟
                }
                
                Thread.Sleep(500); // 额外停留时间
                
                // 加载主窗体
                var mainForm = new MainForm();
                splash.Close();
                Application.Run(mainForm);
            }
        }
    }
}