namespace SG_Lua_IDE.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsSGLuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsLuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem commentLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentBlockToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToReferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem goToLineToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem stepOverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepIntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepOutToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem terminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTerminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitTerminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem runBuildTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runActiveFileToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.ToolStripButton debugToolStripButton;
        private System.Windows.Forms.ToolStripButton terminalToolStripButton;
        
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox editor;
        private System.Windows.Forms.TextBox txtOutput;
        
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            
            // 文件菜单
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsSGLuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsLuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 编辑菜单
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.commentLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 导航菜单
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.goToLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 调试菜单
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.stepOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepIntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 终端菜单
            this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.runBuildTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runActiveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 主题菜单
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 帮助菜单
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // 工具栏
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.debugToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.terminalToolStripButton = new System.Windows.Forms.ToolStripButton();
            
            // 主容器
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editor = new System.Windows.Forms.RichTextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            
            // 状态栏
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            
            // 对话框
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            
            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileToolStripMenuItem,
                this.editToolStripMenuItem,
                this.navigateToolStripMenuItem,
                this.debugToolStripMenuItem,
                this.terminalToolStripMenuItem,
                this.themeToolStripMenuItem,
                this.helpToolStripMenuItem
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            
            // 文件菜单项
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newToolStripMenuItem,
                this.openToolStripMenuItem,
                this.saveToolStripMenuItem,
                this.saveAsSGLuaToolStripMenuItem,
                this.exportAsLuaToolStripMenuItem,
                this.toolStripSeparator1,
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "文件";
            
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newToolStripMenuItem.Text = "新建";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openToolStripMenuItem.Text = "打开...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            
            this.saveAsSGLuaToolStripMenuItem.Name = "saveAsSGLuaToolStripMenuItem";
            this.saveAsSGLuaToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveAsSGLuaToolStripMenuItem.Text = "另存为 SG-Lua 工程...";
            this.saveAsSGLuaToolStripMenuItem.Click += new System.EventHandler(this.SaveAsSGLuaToolStripMenuItem_Click);
            
            this.exportAsLuaToolStripMenuItem.Name = "exportAsLuaToolStripMenuItem";
            this.exportAsLuaToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exportAsLuaToolStripMenuItem.Text = "导出为 Lua 文件...";
            this.exportAsLuaToolStripMenuItem.Click += new System.EventHandler(this.ExportAsLuaToolStripMenuItem_Click);
            
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            
            // 编辑菜单项
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.undoToolStripMenuItem,
                this.redoToolStripMenuItem,
                this.toolStripSeparator2,
                this.cutToolStripMenuItem,
                this.copyToolStripMenuItem,
                this.pasteToolStripMenuItem,
                this.toolStripSeparator3,
                this.findToolStripMenuItem,
                this.replaceToolStripMenuItem,
                this.toolStripSeparator4,
                this.commentLineToolStripMenuItem,
                this.commentBlockToolStripMenuItem
            });
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.editToolStripMenuItem.Text = "编辑";
            
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "撤销";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "恢复";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cutToolStripMenuItem.Text = "剪切";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "复制";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "粘贴";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findToolStripMenuItem.Text = "查找";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.replaceToolStripMenuItem.Text = "替换";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.ReplaceToolStripMenuItem_Click);
            
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            
            this.commentLineToolStripMenuItem.Name = "commentLineToolStripMenuItem";
            this.commentLineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemQuestion)));
            this.commentLineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.commentLineToolStripMenuItem.Text = "行注释";
            this.commentLineToolStripMenuItem.Click += new System.EventHandler(this.CommentLineToolStripMenuItem_Click);
            
            this.commentBlockToolStripMenuItem.Name = "commentBlockToolStripMenuItem";
            this.commentBlockToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt) | System.Windows.Forms.Keys.A)));
            this.commentBlockToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.commentBlockToolStripMenuItem.Text = "块注释";
            this.commentBlockToolStripMenuItem.Click += new System.EventHandler(this.CommentBlockToolStripMenuItem_Click);
            
            // 导航菜单项
            this.navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.goToDefinitionToolStripMenuItem,
                this.goToReferencesToolStripMenuItem,
                this.toolStripSeparator5,
                this.goToLineToolStripMenuItem
            });
            this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            this.navigateToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.navigateToolStripMenuItem.Text = "导航";
            
            this.goToDefinitionToolStripMenuItem.Name = "goToDefinitionToolStripMenuItem";
            this.goToDefinitionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.goToDefinitionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goToDefinitionToolStripMenuItem.Text = "转到定义";
            this.goToDefinitionToolStripMenuItem.Click += new System.EventHandler(this.GoToDefinitionToolStripMenuItem_Click);
            
            this.goToReferencesToolStripMenuItem.Name = "goToReferencesToolStripMenuItem";
            this.goToReferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F12)));
            this.goToReferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goToReferencesToolStripMenuItem.Text = "转到引用";
            this.goToReferencesToolStripMenuItem.Click += new System.EventHandler(this.GoToReferencesToolStripMenuItem_Click);
            
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            
            this.goToLineToolStripMenuItem.Name = "goToLineToolStripMenuItem";
            this.goToLineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goToLineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goToLineToolStripMenuItem.Text = "转到行";
            this.goToLineToolStripMenuItem.Click += new System.EventHandler(this.GoToLineToolStripMenuItem_Click);
            
            // 调试菜单项
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.startDebugToolStripMenuItem,
                this.stopDebugToolStripMenuItem,
                this.toolStripSeparator6,
                this.stepOverToolStripMenuItem,
                this.stepIntoToolStripMenuItem,
                this.stepOutToolStripMenuItem
            });
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.debugToolStripMenuItem.Text = "调试";
            
            this.startDebugToolStripMenuItem.Name = "startDebugToolStripMenuItem";
            this.startDebugToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startDebugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startDebugToolStripMenuItem.Text = "启动调试";
            this.startDebugToolStripMenuItem.Click += new System.EventHandler(this.DebugButton_Click);
            
            this.stopDebugToolStripMenuItem.Name = "stopDebugToolStripMenuItem";
            this.stopDebugToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.stopDebugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopDebugToolStripMenuItem.Text = "停止调试";
            this.stopDebugToolStripMenuItem.Click += new System.EventHandler(this.StopDebugButton_Click);
            
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            
            this.stepOverToolStripMenuItem.Name = "stepOverToolStripMenuItem";
            this.stepOverToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.stepOverToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stepOverToolStripMenuItem.Text = "单步跳过";
            this.stepOverToolStripMenuItem.Click += new System.EventHandler(this.StepOverButton_Click);
            
            this.stepIntoToolStripMenuItem.Name = "stepIntoToolStripMenuItem";
            this.stepIntoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.stepIntoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stepIntoToolStripMenuItem.Text = "单步进入";
            this.stepIntoToolStripMenuItem.Click += new System.EventHandler(this.StepIntoButton_Click);
            
            this.stepOutToolStripMenuItem.Name = "stepOutToolStripMenuItem";
            this.stepOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F11)));
            this.stepOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stepOutToolStripMenuItem.Text = "单步跳出";
            this.stepOutToolStripMenuItem.Click += new System.EventHandler(this.StepOutButton_Click);
            
            // 终端菜单项
            this.terminalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newTerminalToolStripMenuItem,
                this.splitTerminalToolStripMenuItem,
                this.toolStripSeparator7,
                this.runBuildTaskToolStripMenuItem,
                this.runActiveFileToolStripMenuItem
            });
            this.terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            this.terminalToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.terminalToolStripMenuItem.Text = "终端";
            
            this.newTerminalToolStripMenuItem.Name = "newTerminalToolStripMenuItem";
            this.newTerminalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.Oemtilde)));
            this.newTerminalToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newTerminalToolStripMenuItem.Text = "新建终端";
            this.newTerminalToolStripMenuItem.Click += new System.EventHandler(this.NewTerminalToolStripMenuItem_Click);
            
            this.splitTerminalToolStripMenuItem.Name = "splitTerminalToolStripMenuItem";
            this.splitTerminalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.D5)));
            this.splitTerminalToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.splitTerminalToolStripMenuItem.Text = "拆分终端";
            this.splitTerminalToolStripMenuItem.Click += new System.EventHandler(this.SplitTerminalToolStripMenuItem_Click);
            
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(217, 6);
            
            this.runBuildTaskToolStripMenuItem.Name = "runBuildTaskToolStripMenuItem";
            this.runBuildTaskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.B)));
            this.runBuildTaskToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.runBuildTaskToolStripMenuItem.Text = "运行生成任务";
            this.runBuildTaskToolStripMenuItem.Click += new System.EventHandler(this.RunBuildTaskToolStripMenuItem_Click);
            
            this.runActiveFileToolStripMenuItem.Name = "runActiveFileToolStripMenuItem";
            this.runActiveFileToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.runActiveFileToolStripMenuItem.Text = "运行活动文件";
            this.runActiveFileToolStripMenuItem.Click += new System.EventHandler(this.RunActiveFileToolStripMenuItem_Click);
            
            // 主题菜单项
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toggleThemeToolStripMenuItem
            });
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.themeToolStripMenuItem.Text = "主题";
            
            this.toggleThemeToolStripMenuItem.Name = "toggleThemeToolStripMenuItem";
            this.toggleThemeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.toggleThemeToolStripMenuItem.Text = "切换主题";
            this.toggleThemeToolStripMenuItem.Click += new System.EventHandler(this.ToggleThemeToolStripMenuItem_Click);
            
            // 帮助菜单项
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.aboutToolStripMenuItem
            });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "帮助";
            
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "关于 SG-Lua IDE";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            
            // 工具栏
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newToolStripButton,
                this.openToolStripButton,
                this.saveToolStripButton,
                this.runToolStripButton,
                this.debugToolStripButton,
                this.terminalToolStripButton
            });
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 1;
            
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "新建";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "打开";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "保存";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            
            this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runToolStripButton.Name = "runToolStripButton";
            this.runToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.runToolStripButton.Text = "运行";
            this.runToolStripButton.Click += new System.EventHandler(this.RunButton_Click);
            
            this.debugToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugToolStripButton.Name = "debugToolStripButton";
            this.debugToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.debugToolStripButton.Text = "调试";
            this.debugToolStripButton.Click += new System.EventHandler(this.DebugButton_Click);
            
            this.terminalToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.terminalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.terminalToolStripButton.Name = "terminalToolStripButton";
            this.terminalToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.terminalToolStripButton.Text = "终端";
            this.terminalToolStripButton.Click += new System.EventHandler(this.NewTerminalToolStripMenuItem_Click);
            
            // 主容器
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            
            this.splitContainer1.Panel1.Controls.Add(this.editor);
            this.splitContainer1.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer1.Size = new System.Drawing.Size(800, 401);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 2;
            
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(800, 300);
            this.editor.TabIndex = 0;
            this.editor.Text = "";
            this.editor.TextChanged += new System.EventHandler(this.Editor_TextChanged);
            
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(800, 97);
            this.txtOutput.TabIndex = 0;
            
            // 状态栏
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusLabel
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 450);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 3;
            
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(32, 17);
            this.statusLabel.Text = "就绪";
            
            // 对话框
            this.openFileDialog.Filter = "SG-Lua 工程文件 (*.sglua)|*.sglua|Lua 脚本文件 (*.lua)|*.lua|所有文件 (*.*)|*.*";
            this.saveFileDialog.Filter = "SG-Lua 工程文件 (*.sglua)|*.sglua|Lua 脚本文件 (*.lua)|*.lua";
            
            // 主窗体
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "SG-Lua IDE";
        }
    }
}