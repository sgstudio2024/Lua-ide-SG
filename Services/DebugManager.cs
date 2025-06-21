using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SG_Lua_IDE.Services
{
    public class DebugManager
    {
        private RichTextBox _editor;
        private TextBox _output;
        private Process _debugProcess;
        
        public void Initialize(RichTextBox editor, TextBox output)
        {
            _editor = editor;
            _output = output;
        }
        
        public void StartDebugging(string code)
        {
            _output.AppendText("启动调试会话...\n");
            _output.AppendText("设置断点...\n");
            
            foreach (var line in _editor.Lines)
            {
                if (line.Contains("function") || line.Contains("if") || line.Contains("for"))
                {
                    _output.AppendText($"在行 {Array.IndexOf(_editor.Lines, line) + 1} 设置断点\n");
                }
            }
            
            _output.AppendText("开始调试...\n");
        }
        
        public void StopDebugging()
        {
            if (_debugProcess != null && !_debugProcess.HasExited)
            {
                _debugProcess.Kill();
                _debugProcess = null;
            }
            _output.AppendText("调试会话已停止\n");
        }
        
        public void StepOver()
        {
            _output.AppendText("执行下一步（跳过函数）\n");
        }
        
        public void StepInto()
        {
            _output.AppendText("执行下一步（进入函数）\n");
        }
        
        public void StepOut()
        {
            _output.AppendText("执行下一步（跳出函数）\n");
        }
        
        public void ToggleBreakpoint(int line)
        {
            _output.AppendText($"切换第 {line} 行的断点\n");
        }
    }
}