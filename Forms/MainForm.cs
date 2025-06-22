using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using SG_Lua_IDE.Components;
using SG_Lua_IDE.Services;

namespace SG_Lua_IDE.Forms
{
    public partial class MainForm : Form
    {
        private readonly FileManager _fileManager = new FileManager();
        private readonly LuaExecutor _luaExecutor = new LuaExecutor();
        private bool _isDarkMode = true;
        private System.Windows.Forms.Timer statusTimer;
        private FindReplaceDialog _findReplaceDialog;
        private DebugManager _debugManager = new DebugManager();
        private TerminalManager _terminalManager = new TerminalManager();

        public RichTextBox Editor => editor;

        public MainForm()
        {
            InitializeComponent();
            InitializeEditor();
            InitializeOutputRedirector();
            ApplyDarkTheme();

            // 标题栏按钮位置自适应
            this.Resize += (s, e) =>
            {
                int btnWidth = 40;
                if (btnMinimize != null && btnMaximize != null && btnClose != null)
                {
                    btnMinimize.Left = this.ClientSize.Width - btnWidth * 3;
                    btnMaximize.Left = this.ClientSize.Width - btnWidth * 2;
                    btnClose.Left = this.ClientSize.Width - btnWidth * 1;
                }
            };
            // 初始化时也设置一次
            int btnW = 40;
            if (btnMinimize != null && btnMaximize != null && btnClose != null)
            {
                btnMinimize.Left = this.ClientSize.Width - btnW * 3;
                btnMaximize.Left = this.ClientSize.Width - btnW * 2;
                btnClose.Left = this.ClientSize.Width - btnW * 1;
            }

            // 支持无边框窗口拖动
            if (titleBarPanel != null)
            {
                titleBarPanel.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        NativeMethods.ReleaseCapture();
                        NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
                    }
                };
            }

            // 设置应用程序标题和图标
            this.Text = $"{Program.AppName} v{Program.Version}";
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "AppIcon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
            }
            catch
            {
                // 忽略图标加载错误
            }
            
            // 初始化状态栏计时器
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 5000;
            statusTimer.Tick += StatusTimer_Tick;
            
            // 初始化调试管理器
            _debugManager.Initialize(editor, txtOutput);
        }

        private void InitializeEditor()
        {
            editor.Font = new Font("Consolas", 12);
            editor.Dock = DockStyle.Fill;
            editor.WordWrap = false;
            editor.ScrollBars = RichTextBoxScrollBars.Both;
            editor.BackColor = Color.FromArgb(30, 30, 40);
            editor.ForeColor = Color.White;
            
            // 应用语法高亮
            LuaSyntaxHighlighter.ApplyDefaultStyles(editor);
        }

        private void InitializeOutputRedirector()
        {
            OutputRedirector.Redirect(txtOutput);
        }

        private void ApplyDarkTheme()
        {
            // VSCode 深色风格
            menuStrip.BackColor = Color.FromArgb(37, 37, 38);
            menuStrip.ForeColor = Color.White;
            toolStrip.BackColor = Color.FromArgb(37, 37, 38);
            toolStrip.ForeColor = Color.White;
            toolStrip.ImageScalingSize = new Size(32, 32);

            // 工具栏图标
            try
            {
                string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ToolbarIcons");
                if (Directory.Exists(resourcesPath))
                {
                    newToolStripButton.Image = Image.FromFile(Path.Combine(resourcesPath, "NewFile.png"));
                    openToolStripButton.Image = Image.FromFile(Path.Combine(resourcesPath, "OpenFile.png"));
                    saveToolStripButton.Image = Image.FromFile(Path.Combine(resourcesPath, "SaveFile.png"));
                    runToolStripButton.Image = Image.FromFile(Path.Combine(resourcesPath, "Run.png"));
                    debugToolStripButton.Image = Image.FromFile(Path.Combine(resourcesPath, "Debug.png"));
                    terminalToolStripButton.Image = Image.FromFile(Path.Combine(resourcesPath, "Terminal.png"));
                }
            }
            catch { /* 忽略图标加载错误 */ }

            editor.BackColor = Color.FromArgb(30, 30, 34);
            editor.ForeColor = Color.FromArgb(212, 212, 212);
            editor.BorderStyle = BorderStyle.None;
            txtOutput.BackColor = Color.FromArgb(25, 25, 28);
            txtOutput.ForeColor = Color.FromArgb(130, 220, 130);
            txtOutput.BorderStyle = BorderStyle.None;
            // splitContainer1.BackColor = Color.FromArgb(37, 37, 38); // 删除此行
            mainSplitContainer.BackColor = Color.FromArgb(37, 37, 38); // 新增
            bottomSplitContainer.BackColor = Color.FromArgb(37, 37, 38); // 新增
            statusStrip.BackColor = Color.FromArgb(37, 37, 38);
            statusStrip.ForeColor = Color.White;
            statusLabel.ForeColor = Color.White;

            // 设置底部TabControl和各TabPage为深色
            bottomTabControl.BackColor = Color.FromArgb(30, 30, 34);
            bottomTabControl.ForeColor = Color.White;
            tabPageProblems.BackColor = Color.FromArgb(30, 30, 34);
            tabPageProblems.ForeColor = Color.White;
            tabPageOutput.BackColor = Color.FromArgb(30, 30, 34);
            tabPageOutput.ForeColor = Color.White;
            tabPageDebug.BackColor = Color.FromArgb(30, 30, 34);
            tabPageDebug.ForeColor = Color.White;
            tabPageTerminal.BackColor = Color.FromArgb(30, 30, 34);
            tabPageTerminal.ForeColor = Color.White;

            // 终端输入区风格
            terminalBox.BackColor = Color.FromArgb(30, 30, 34);
            terminalBox.ForeColor = Color.LightGreen;
            terminalBox.BorderStyle = BorderStyle.None;

            // 标题栏按钮风格
            btnMinimize.BackColor = Color.FromArgb(37, 37, 38);
            btnMinimize.ForeColor = Color.White;
            btnMaximize.BackColor = Color.FromArgb(37, 37, 38);
            btnMaximize.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(37, 37, 38);
            btnClose.ForeColor = Color.White;

            bottomStatusBar.BackColor = Color.FromArgb(25, 25, 28);
            bottomStatusBar.ForeColor = Color.LightGray;
        }

        #region 文件操作
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.Modified && !string.IsNullOrEmpty(_fileManager.CurrentFilePath))
            {
                var result = MessageBox.Show("当前文件已修改，是否保存更改？", 
                    "保存更改", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            editor.Clear();
            _fileManager.CurrentFilePath = null;
            UpdateTitle();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.Modified && !string.IsNullOrEmpty(_fileManager.CurrentFilePath))
            {
                var result = MessageBox.Show("当前文件已修改，是否保存更改？", 
                    "保存更改", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            openFileDialog.Filter = "SG-Lua 工程文件 (*.sglua)|*.sglua|Lua 脚本文件 (*.lua)|*.lua|所有文件 (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    editor.Text = _fileManager.OpenFile(openFileDialog.FileName);
                    UpdateTitle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"打开文件时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileManager.CurrentFilePath))
            {
                SaveAsSGLuaToolStripMenuItem_Click(sender, e);
                return;
            }

            try
            {
                _fileManager.SaveFile(_fileManager.CurrentFilePath, editor.Text);
                editor.Modified = false;
                UpdateTitle();
                ShowStatusMessage($"文件已保存: {Path.GetFileName(_fileManager.CurrentFilePath)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存文件时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsSGLuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "SG-Lua 工程文件 (*.sglua)|*.sglua";
            saveFileDialog.DefaultExt = "sglua";
            saveFileDialog.Title = "保存为 SG-Lua 工程文件";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _fileManager.SaveFile(saveFileDialog.FileName, editor.Text);
                    editor.Modified = false;
                    UpdateTitle();
                    ShowStatusMessage($"文件已保存为 SG-Lua 工程: {Path.GetFileName(saveFileDialog.FileName)}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"保存文件时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportAsLuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Lua 脚本文件 (*.lua)|*.lua";
            saveFileDialog.DefaultExt = "lua";
            saveFileDialog.Title = "导出为 Lua 文件";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _fileManager.ExportToLua(saveFileDialog.FileName, editor.Text);
                    ShowStatusMessage($"文件已导出为 Lua: {Path.GetFileName(saveFileDialog.FileName)}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出文件时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.Modified)
            {
                var result = MessageBox.Show("当前文件已修改，是否保存更改？", 
                    "保存更改", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            Application.Exit();
        }
        #endregion

        #region 运行与调试
        private void RunButton_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            try
            {
                _luaExecutor.Execute(editor.Text);
                ShowStatusMessage("脚本执行完成");
                ShowCompilerMessage("运行完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"执行错误: {ex.Message}");
                ShowStatusMessage($"执行错误: {ex.Message}");
            }
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            _debugManager.StartDebugging(editor.Text);
            ShowStatusMessage("调试会话已启动");
        }

        private void StopDebugButton_Click(object sender, EventArgs e)
        {
            _debugManager.StopDebugging();
            ShowStatusMessage("调试会话已停止");
        }

        private void StepOverButton_Click(object sender, EventArgs e)
        {
            _debugManager.StepOver();
            ShowStatusMessage("单步跳过");
        }

        private void StepIntoButton_Click(object sender, EventArgs e)
        {
            _debugManager.StepInto();
            ShowStatusMessage("单步进入");
        }

        private void StepOutButton_Click(object sender, EventArgs e)
        {
            _debugManager.StepOut();
            ShowStatusMessage("单步跳出");
        }
        #endregion

        #region 编辑功能
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.CanUndo)
            {
                editor.Undo();
                ShowStatusMessage("撤销操作");
            }
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.CanRedo)
            {
                editor.Redo();
                ShowStatusMessage("重做操作");
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Cut();
            ShowStatusMessage("剪切选中内容");
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Copy();
            ShowStatusMessage("复制选中内容");
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Paste();
            ShowStatusMessage("粘贴内容");
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_findReplaceDialog == null || _findReplaceDialog.IsDisposed)
            {
                _findReplaceDialog = new FindReplaceDialog(editor);
            }
            _findReplaceDialog.ShowFind();
            _findReplaceDialog.BringToFront();
        }

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_findReplaceDialog == null || _findReplaceDialog.IsDisposed)
            {
                _findReplaceDialog = new FindReplaceDialog(editor);
            }
            _findReplaceDialog.ShowReplace();
            _findReplaceDialog.BringToFront();
        }

        private void CommentLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleLineComment();
        }

        private void CommentBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleBlockComment();
        }

        private void ToggleLineComment()
        {
            int selectionStart = editor.SelectionStart;
            int selectionLength = editor.SelectionLength;
            string selectedText = editor.SelectedText;

            if (string.IsNullOrEmpty(selectedText))
            {
                // 如果没有选中文本，注释当前行
                int line = editor.GetLineFromCharIndex(selectionStart);
                int lineStart = editor.GetFirstCharIndexFromLine(line);
                int lineEnd = editor.GetFirstCharIndexFromLine(line + 1);
                if (lineEnd < 0) lineEnd = editor.Text.Length;

                string lineText = editor.Text.Substring(lineStart, lineEnd - lineStart);
                
                if (lineText.TrimStart().StartsWith("--"))
                {
                    // 取消注释
                    int commentIndex = lineText.IndexOf("--");
                    editor.Select(lineStart + commentIndex, 2);
                    editor.SelectedText = "";
                }
                else
                {
                    // 添加注释
                    editor.Select(lineStart, 0);
                    editor.SelectedText = "--";
                }
            }
            else
            {
                // 处理多行注释
                string[] lines = selectedText.Split('\n');
                bool allCommented = true;
                
                // 检查是否所有行都已注释
                foreach (string line in lines)
                {
                    if (!line.TrimStart().StartsWith("--") && !string.IsNullOrWhiteSpace(line))
                    {
                        allCommented = false;
                        break;
                    }
                }
                
                // 添加或移除注释
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                    {
                        if (allCommented)
                        {
                            // 移除注释
                            if (lines[i].TrimStart().StartsWith("--"))
                            {
                                int commentIndex = lines[i].IndexOf("--");
                                lines[i] = lines[i].Remove(commentIndex, 2);
                            }
                        }
                        else
                        {
                            // 添加注释
                            int firstNonWhitespace = 0;
                            while (firstNonWhitespace < lines[i].Length && char.IsWhiteSpace(lines[i][firstNonWhitespace]))
                            {
                                firstNonWhitespace++;
                            }
                            lines[i] = lines[i].Insert(firstNonWhitespace, "--");
                        }
                    }
                }
                
                string newText = string.Join("\n", lines);
                editor.SelectedText = newText;
                editor.Select(selectionStart, newText.Length);
                
                // 更新状态消息
                ShowStatusMessage(allCommented ? "取消行注释" : "添加行注释");
            }
        }

        private void ToggleBlockComment()
        {
            int selectionStart = editor.SelectionStart;
            int selectionLength = editor.SelectionLength;
            string selectedText = editor.SelectedText;
            
            if (selectedText.StartsWith("--[[") && selectedText.EndsWith("]]"))
            {
                // 取消块注释
                editor.SelectedText = selectedText.Substring(4, selectedText.Length - 6);
                ShowStatusMessage("取消块注释");
            }
            else
            {
                // 添加块注释
                editor.SelectedText = $"--[[{selectedText}]]";
                ShowStatusMessage("添加块注释");
            }
        }
        #endregion

        #region 导航功能
        private void GoToDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 简化的转到定义实现
            string word = GetWordAtCursor();
            if (!string.IsNullOrEmpty(word))
            {
                // 在实际应用中，这里应该解析代码并找到定义位置
                // 这里只是简单搜索
                int index = editor.Text.IndexOf($"function {word}(");
                if (index >= 0)
                {
                    editor.Select(index, word.Length);
                    editor.ScrollToCaret();
                    ShowStatusMessage($"转到定义: {word}");
                    return;
                }
                
                index = editor.Text.IndexOf($"local {word} =");
                if (index >= 0)
                {
                    editor.Select(index, word.Length);
                    editor.ScrollToCaret();
                    ShowStatusMessage($"转到定义: {word}");
                    return;
                }
            }
            ShowStatusMessage("未找到定义");
        }

        private void GoToReferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 简化的转到引用实现
            string word = GetWordAtCursor();
            if (!string.IsNullOrEmpty(word))
            {
                // 在实际应用中，这里应该解析代码并找到所有引用
                // 这里只是简单搜索
                int index = editor.Text.IndexOf(word);
                if (index >= 0)
                {
                    editor.Select(index, word.Length);
                    editor.ScrollToCaret();
                    ShowStatusMessage($"找到引用: {word}");
                    return;
                }
            }
            ShowStatusMessage("未找到引用");
        }

        private void GoToLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new GoToLineDialog(editor.Lines.Length))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int lineNumber = dialog.LineNumber;
                    if (lineNumber > 0 && lineNumber <= editor.Lines.Length)
                    {
                        int index = editor.GetFirstCharIndexFromLine(lineNumber - 1);
                        editor.Select(index, 0);
                        editor.ScrollToCaret();
                        ShowStatusMessage($"转到第 {lineNumber} 行");
                    }
                }
            }
        }

        private string GetWordAtCursor()
        {
            int cursorPos = editor.SelectionStart;
            if (cursorPos >= editor.TextLength) return string.Empty;

            // 找到单词开始位置
            int startPos = cursorPos;
            while (startPos > 0 && (char.IsLetterOrDigit(editor.Text[startPos - 1]) || editor.Text[startPos - 1] == '_'))
            {
                startPos--;
            }

            // 找到单词结束位置
            int endPos = cursorPos;
            while (endPos < editor.TextLength && (char.IsLetterOrDigit(editor.Text[endPos]) || editor.Text[endPos] == '_'))
            {
                endPos++;
            }

            return editor.Text.Substring(startPos, endPos - startPos);
        }
        #endregion

        #region 终端功能
        private void NewTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bottomTabControl.SelectedTab = tabPageTerminal;
            terminalBox.Focus();
            AppendTerminalText("新终端已打开。\n");
            ShowStatusMessage("打开新终端");
        }

        private void SplitTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bottomTabControl.SelectedTab = tabPageTerminal;
            terminalBox.Focus();
            AppendTerminalText("拆分终端（模拟）。\n");
            ShowStatusMessage("拆分终端");
        }

        private void RunBuildTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bottomTabControl.SelectedTab = tabPageTerminal;
            terminalBox.Focus();
            AppendTerminalText("运行生成任务...\n");
            ShowStatusMessage("运行生成任务");
        }

        private void RunActiveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bottomTabControl.SelectedTab = tabPageTerminal;
            terminalBox.Focus();
            if (!string.IsNullOrEmpty(_fileManager.CurrentFilePath))
            {
                AppendTerminalText($"运行文件: {_fileManager.CurrentFilePath}\n");
                ShowStatusMessage("运行活动文件");
            }
            else
            {
                AppendTerminalText("没有活动文件可运行。\n");
                ShowStatusMessage("没有活动文件可运行");
            }
        }

        // 输出、终端、调试控制台、问题Tab的切换和内容管理
        // 你可以根据需要将调试输出和问题输出分别写入对应Tab

        // 输出到“输出”Tab
        private void AppendOutputText(string text)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action<string>(AppendOutputText), text);
            }
            else
            {
                txtOutput.AppendText(text);
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }
        }

        // 输出到“终端”Tab
        private void AppendTerminalText(string text)
        {
            if (terminalBox.InvokeRequired)
            {
                terminalBox.Invoke(new Action<string>(AppendTerminalText), text);
            }
            else
            {
                terminalBox.AppendText(text);
                terminalBox.SelectionStart = terminalBox.Text.Length;
                terminalBox.ScrollToCaret();
            }
        }

        // 输出到“调试控制台”Tab（如需实现调试输出，建议添加一个RichTextBox debugConsoleBox到tabPageDebug）
        // private void AppendDebugText(string text) { ... }

        // 输出到“问题”Tab（如需实现问题列表，建议添加ListView或DataGridView到tabPageProblems）
        // private void AddProblem(string message, int line, int column) { ... }
        #endregion

        #region 其他功能
        private void Editor_TextChanged(object sender, EventArgs e)
        {
            LuaSyntaxHighlighter.HighlightSyntax(editor);
            UpdateTitle();
        }
        
        private void UpdateTitle()
        {
            // 文件信息
            string fileName = string.IsNullOrEmpty(_fileManager.CurrentFilePath)
                ? "未打开文件"
                : Path.GetFileName(_fileManager.CurrentFilePath);
            fileInfoLabel.Text = fileName;

            // 语言
            languageLabel.Text = "Lua";

            // 文件格式
            try
            {
                if (!string.IsNullOrEmpty(_fileManager.CurrentFilePath))
                {
                    using (var fs = File.OpenRead(_fileManager.CurrentFilePath))
                    using (var reader = new StreamReader(fs, true))
                    {
                        reader.Peek(); // 触发自动检测
                        formatLabel.Text = reader.CurrentEncoding.EncodingName;
                    }
                }
                else
                {
                    formatLabel.Text = "UTF-8";
                }
            }
            catch
            {
                formatLabel.Text = "未知";
            }

            // 编译器通知（可由其它方法设置）
            // compilerLabel.Text = "";
        }

        private void UpdateBottomStatusBar()
        {
            // 文件信息
            string fileName = string.IsNullOrEmpty(_fileManager.CurrentFilePath)
                ? "未打开文件"
                : Path.GetFileName(_fileManager.CurrentFilePath);
            if (fileInfoLabel != null) fileInfoLabel.Text = fileName;

            // 语言
            if (languageLabel != null) languageLabel.Text = "Lua";

            // 文件格式
            try
            {
                if (!string.IsNullOrEmpty(_fileManager.CurrentFilePath))
                {
                    using (var fs = File.OpenRead(_fileManager.CurrentFilePath))
                    using (var reader = new StreamReader(fs, true))
                    {
                        reader.Peek(); // 触发自动检测
                        if (formatLabel != null)
                            formatLabel.Text = reader.CurrentEncoding.EncodingName;
                    }
                }
                else
                {
                    if (formatLabel != null) formatLabel.Text = "UTF-8";
                }
            }
            catch
            {
                if (formatLabel != null) formatLabel.Text = "未知";
            }

            // 编译器通知（可由其它方法设置）
            // compilerLabel.Text = "";
        }

        private void ShowCompilerMessage(string message)
        {
            if (compilerLabel != null)
                compilerLabel.Text = message;
            // 可加定时清空等逻辑
        }
        
        private void ShowStatusMessage(string message)
        {
            statusLabel.Text = message;
            statusTimer.Stop();
            statusTimer.Start();
        }
        
        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = "就绪";
            statusTimer.Stop();
        }
        
        private void ToggleThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isDarkMode = !_isDarkMode;
            if (_isDarkMode)
            {
                ApplyDarkTheme();
                editor.BackColor = Color.FromArgb(30, 30, 40);
                editor.ForeColor = Color.White;
            }
            else
            {
                // 应用浅色主题
                menuStrip.BackColor = SystemColors.MenuBar;
                menuStrip.ForeColor = SystemColors.MenuText;
                toolStrip.BackColor = SystemColors.Control;
                toolStrip.ForeColor = SystemColors.ControlText;
                editor.BackColor = SystemColors.Window;
                editor.ForeColor = SystemColors.WindowText;
                txtOutput.BackColor = SystemColors.Window;
                txtOutput.ForeColor = SystemColors.WindowText;
                // splitContainer1.BackColor = SystemColors.Control; // 删除此行
                mainSplitContainer.BackColor = SystemColors.Control; // 新增
                bottomSplitContainer.BackColor = SystemColors.Control; // 新增
                statusStrip.BackColor = SystemColors.Control;
                statusStrip.ForeColor = SystemColors.ControlText;
                statusLabel.ForeColor = SystemColors.ControlText;
                
                // 设置底部TabControl和各TabPage为浅色
                bottomTabControl.BackColor = SystemColors.Control;
                bottomTabControl.ForeColor = SystemColors.ControlText;
                tabPageProblems.BackColor = SystemColors.Control;
                tabPageProblems.ForeColor = SystemColors.ControlText;
                tabPageOutput.BackColor = SystemColors.Control;
                tabPageOutput.ForeColor = SystemColors.ControlText;
                tabPageDebug.BackColor = SystemColors.Control;
                tabPageDebug.ForeColor = SystemColors.ControlText;
                tabPageTerminal.BackColor = SystemColors.Control;
                tabPageTerminal.ForeColor = SystemColors.ControlText;

                // 终端输入区风格
                terminalBox.BackColor = SystemColors.Window;
                terminalBox.ForeColor = SystemColors.WindowText;
                terminalBox.BorderStyle = BorderStyle.None;

                // 标题栏按钮风格
                btnMinimize.BackColor = SystemColors.Control;
                btnMinimize.ForeColor = SystemColors.ControlText;
                btnMaximize.BackColor = SystemColors.Control;
                btnMaximize.ForeColor = SystemColors.ControlText;
                btnClose.BackColor = SystemColors.Control;
                btnClose.ForeColor = SystemColors.ControlText;
            }
        }
        
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"{Program.AppName} v{Program.Version}\n\n" +
                "一个专业的Lua脚本编辑和执行环境\n" +
                "支持加密的SG-Lua工程文件(.sglua)\n\n" +
                "© 2024 SG-Lua IDE 开发团队",
                "关于 SG-Lua IDE",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion

        // 支持无边框窗口拖动
        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ReleaseCapture();
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "🗖";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "🗗";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}