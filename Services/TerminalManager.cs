using System;
using System.Diagnostics;

namespace SG_Lua_IDE.Services
{
    public class TerminalManager
    {
        public void OpenTerminal()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    WorkingDirectory = Environment.CurrentDirectory,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"打开终端时出错: {ex.Message}");
            }
        }
        
        public void SplitTerminal()
        {
            OpenTerminal();
        }
        
        public void RunBuildTask()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "build",
                    WorkingDirectory = Environment.CurrentDirectory,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"运行生成任务时出错: {ex.Message}");
            }
        }
        
        public void RunFile(string filePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "lua",
                    Arguments = $"\"{filePath}\"",
                    WorkingDirectory = Environment.CurrentDirectory,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"运行文件时出错: {ex.Message}");
            }
        }
    }
}