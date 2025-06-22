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
        
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer bottomSplitContainer;
        private System.Windows.Forms.RichTextBox editor;
        private System.Windows.Forms.RichTextBox terminalBox;
        private System.Windows.Forms.TextBox txtOutput;
        
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        // ===== VSCode风格自定义标题栏 =====
        private System.Windows.Forms.Panel titleBarPanel;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnClose;

        // ===== 底部状态栏 =====
        private System.Windows.Forms.StatusStrip bottomStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel fileInfoLabel;
        private System.Windows.Forms.ToolStripStatusLabel languageLabel;
        private System.Windows.Forms.ToolStripStatusLabel formatLabel;
        private System.Windows.Forms.ToolStripStatusLabel compilerLabel;

        // 新增底部TabControl用于输出区
        private System.Windows.Forms.TabControl bottomTabControl;
        private System.Windows.Forms.TabPage tabPageProblems;
        private System.Windows.Forms.TabPage tabPageOutput;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.TabPage tabPageTerminal;

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

            // 先实例化所有控件（顺序很重要，先TabPage再TabControl）
            this.fileInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.languageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.formatLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.compilerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomStatusBar = new System.Windows.Forms.StatusStrip();

            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsSGLuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsLuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.goToLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.stepOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepIntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.runBuildTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runActiveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.debugToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.terminalToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.bottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.editor = new System.Windows.Forms.RichTextBox();
            this.terminalBox = new System.Windows.Forms.RichTextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.titleBarPanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            // ===== VSCode风格自定义标题栏 =====
            this.titleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBarPanel.Height = 35;
            this.titleBarPanel.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.titleBarPanel.Controls.Clear();

            // ====== 标题栏按钮尺寸参数 ======
            int titleBarButtonWidth = 22;
            int titleBarButtonHeight = 22;
            float titleBarButtonFontSize = 8f;

            // 菜单栏字体和高度加大
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.menuStrip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.menuStrip.Height = 40;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))); // 更大字体

            // 菜单项字体加大
            foreach (System.Windows.Forms.ToolStripMenuItem item in this.menuStrip.Items)
            {
                item.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }

            // 标题栏按钮更大，便于统一调整
            this.btnMinimize.Size = new System.Drawing.Size(titleBarButtonWidth, titleBarButtonHeight);
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI Symbol", titleBarButtonFontSize, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.btnMinimize.TabStop = false;

            this.btnMaximize.Size = new System.Drawing.Size(titleBarButtonWidth, titleBarButtonHeight);
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI Symbol", titleBarButtonFontSize, System.Drawing.FontStyle.Bold);
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.btnMaximize.TabStop = false;

            this.btnClose.Size = new System.Drawing.Size(titleBarButtonWidth, titleBarButtonHeight);
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Symbol", titleBarButtonFontSize, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.btnClose.TabStop = false;

            // 菜单栏和按钮布局
            this.menuStrip.Left = 0;
            this.menuStrip.Top = 0;
            this.menuStrip.Height = 32;

            this.btnClose.Top = 0;
            this.btnMaximize.Top = 0;
            this.btnMinimize.Top = 0;

            // 右侧按钮位置动态调整（在 MainForm.cs 构造函数已处理）

            // 添加到标题栏
            this.titleBarPanel.Controls.Add(this.menuStrip);
            this.titleBarPanel.Controls.Add(this.btnMinimize);
            this.titleBarPanel.Controls.Add(this.btnMaximize);
            this.titleBarPanel.Controls.Add(this.btnClose);

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
            this.fileToolStripMenuItem.Text = "文件(&F)"; // 添加快捷键F
            
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
            this.editToolStripMenuItem.Text = "编辑(&E)"; // 添加快捷键E
            
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
            this.navigateToolStripMenuItem.Text = "导航(&S)"; // 添加快捷键S
            
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
            this.debugToolStripMenuItem.Text = "调试(&D)"; // 添加快捷键D
            
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
            this.toolStrip.Size = new System.Drawing.Size(800, 40); // 高度加大
            this.toolStrip.TabIndex = 1;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden; // 隐藏拖动柄
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(37, 37, 38); // VSCode 深色
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32); // 图标更大

            // 工具栏按钮样式
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(36, 36); // 更大
            this.newToolStripButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newToolStripButton.ToolTipText = "新建";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);

            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.openToolStripButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openToolStripButton.ToolTipText = "打开";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);

            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.saveToolStripButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveToolStripButton.ToolTipText = "保存";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);

            this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runToolStripButton.Name = "runToolStripButton";
            this.runToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.runToolStripButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runToolStripButton.ToolTipText = "运行";
            this.runToolStripButton.Click += new System.EventHandler(this.RunButton_Click);

            this.debugToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugToolStripButton.Name = "debugToolStripButton";
            this.debugToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.debugToolStripButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.debugToolStripButton.ToolTipText = "调试";
            this.debugToolStripButton.Click += new System.EventHandler(this.DebugButton_Click);

            this.terminalToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.terminalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.terminalToolStripButton.Name = "terminalToolStripButton";
            this.terminalToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.terminalToolStripButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.terminalToolStripButton.ToolTipText = "终端";
            this.terminalToolStripButton.Click += new System.EventHandler(this.NewTerminalToolStripMenuItem_Click);
            
            // 新增底部TabControl及各TabPage
            this.bottomTabControl = new System.Windows.Forms.TabControl();
            this.tabPageProblems = new System.Windows.Forms.TabPage();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.tabPageTerminal = new System.Windows.Forms.TabPage();

            // bottomTabControl
            this.bottomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomTabControl.TabPages.Add(this.tabPageProblems);
            this.bottomTabControl.TabPages.Add(this.tabPageOutput);
            this.bottomTabControl.TabPages.Add(this.tabPageDebug);
            this.bottomTabControl.TabPages.Add(this.tabPageTerminal);
            this.bottomTabControl.SelectedIndex = 1; // 默认选中“输出”
            // 深色主题
            this.bottomTabControl.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.bottomTabControl.ForeColor = System.Drawing.Color.White;

            // tabPageProblems
            this.tabPageProblems.Text = "问题";
            this.tabPageProblems.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.tabPageProblems.ForeColor = System.Drawing.Color.White;
            // 可添加ListView或DataGridView用于显示问题
            // this.tabPageProblems.Controls.Add(...);

            // tabPageOutput
            this.tabPageOutput.Text = "输出";
            this.tabPageOutput.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.tabPageOutput.ForeColor = System.Drawing.Color.White;
            this.tabPageOutput.Controls.Add(this.txtOutput);

            // tabPageDebug
            this.tabPageDebug.Text = "调试控制台";
            this.tabPageDebug.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.tabPageDebug.ForeColor = System.Drawing.Color.White;
            // 可添加调试输出控件
            // this.tabPageDebug.Controls.Add(...);

            // tabPageTerminal
            this.tabPageTerminal.Text = "终端";
            this.tabPageTerminal.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.tabPageTerminal.ForeColor = System.Drawing.Color.White;
            this.tabPageTerminal.Controls.Add(this.terminalBox);

            // mainSplitContainer
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.mainSplitContainer.SplitterDistance = 300;
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Panel1.Controls.Add(this.editor);
            this.mainSplitContainer.Panel2.Controls.Add(this.bottomTabControl);

            // bottomSplitContainer
            this.bottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.bottomSplitContainer.SplitterDistance = 400;
            this.bottomSplitContainer.Name = "bottomSplitContainer";
            this.bottomSplitContainer.Panel1.Controls.Add(this.terminalBox);
            this.bottomSplitContainer.Panel2.Controls.Add(this.txtOutput);

            // txtOutput
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.TabIndex = 0;

            // terminalBox 允许输入，按钮风格与主题一致
            this.terminalBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalBox.ReadOnly = false;
            this.terminalBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.terminalBox.ForeColor = System.Drawing.Color.LightGreen;
            this.terminalBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.terminalBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.terminalBox.Name = "terminalBox";

            // 编辑器和终端字体加大
            this.editor.Font = new System.Drawing.Font("Consolas", 15F);
            this.terminalBox.Font = new System.Drawing.Font("Consolas", 15F);

            // 主窗体
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.titleBarPanel);
            this.Controls.Add(this.bottomStatusBar);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "SG-Lua IDE";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // 无边框
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 34); // VSCode 深色

            // ====== 圆角主窗体 ======
            this.Load += (s, e) =>
            {
                int radius = 12; // 圆角半径
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.StartFigure();
                path.AddArc(new System.Drawing.Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new System.Drawing.Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
                path.AddArc(new System.Drawing.Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
                path.AddArc(new System.Drawing.Rectangle(0, this.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();
                this.Region = new System.Drawing.Region(path);
            };
            this.Resize += (s, e) =>
            {
                int radius = 12;
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.StartFigure();
                path.AddArc(new System.Drawing.Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new System.Drawing.Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
                path.AddArc(new System.Drawing.Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
                path.AddArc(new System.Drawing.Rectangle(0, this.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();
                this.Region = new System.Drawing.Region(path);
            };

            // ====== VSCode风格LOGO按钮 ======
            System.Windows.Forms.PictureBox logoBox = new System.Windows.Forms.PictureBox();
            logoBox.Image = System.Drawing.Icon.ExtractAssociatedIcon("Resources\\AppIcon.ico").ToBitmap();
            logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            logoBox.Size = new System.Drawing.Size(28, 28);
            logoBox.Location = new System.Drawing.Point(6, 3);
            logoBox.BackColor = System.Drawing.Color.Transparent;
            logoBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            logoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            logoBox.Click += (s, e) => { /* 可自定义点击事件 */ };

            // 菜单栏左移，留出logo空间
            this.menuStrip.Left = logoBox.Right + 4;
            this.menuStrip.Top = 0;
            this.menuStrip.Height = 32;

            // 添加到标题栏（logo最左，菜单栏右移）
            this.titleBarPanel.Controls.Add(logoBox);
            this.titleBarPanel.Controls.Add(this.menuStrip);
            this.titleBarPanel.Controls.Add(this.btnMinimize);
            this.titleBarPanel.Controls.Add(this.btnMaximize);
            this.titleBarPanel.Controls.Add(this.btnClose);

            // 标题栏按钮属性
            this.btnMinimize.Text = "🗕";
            this.btnMaximize.Text = "🗖";
            this.btnClose.Text = "🗙";

            // 标题栏按钮事件绑定（确保事件绑定在这里）
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            this.btnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
        }
    }
}