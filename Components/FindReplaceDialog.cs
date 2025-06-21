using System;
using System.Drawing;
using System.Windows.Forms;

namespace SG_Lua_IDE.Components
{
    public partial class FindReplaceDialog : Form
    {
        private readonly RichTextBox _editor;
        private int _lastIndex = 0;
        
        public FindReplaceDialog(RichTextBox editor)
        {
            _editor = editor;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                _editor.FindForm().Location.X + _editor.FindForm().Width - this.Width - 20,
                _editor.FindForm().Location.Y + 100);
        }
        
        public void ShowFind()
        {
            replacePanel.Visible = false;
            this.Text = "查找";
            this.Height = findPanel.Height + 40;
            findTextBox.Focus();
            findTextBox.SelectAll();
            Show();
        }
        
        public void ShowReplace()
        {
            replacePanel.Visible = true;
            this.Text = "查找和替换";
            this.Height = replacePanel.Height + findPanel.Height + 40;
            findTextBox.Focus();
            findTextBox.SelectAll();
            Show();
        }
        
        private void FindNextButton_Click(object sender, EventArgs e)
        {
            string searchText = findTextBox.Text;
            if (string.IsNullOrEmpty(searchText)) return;
            
            bool matchCase = matchCaseCheckBox.Checked;
            bool wholeWord = wholeWordCheckBox.Checked;
            
            int startIndex = _lastIndex + 1;
            if (startIndex >= _editor.TextLength) startIndex = 0;
            
            StringComparison comparison = matchCase ? 
                StringComparison.CurrentCulture : 
                StringComparison.CurrentCultureIgnoreCase;
            
            int index = _editor.Text.IndexOf(searchText, startIndex, comparison);
            if (index < 0 && startIndex > 0)
            {
                // 从开头重新搜索
                index = _editor.Text.IndexOf(searchText, 0, comparison);
            }
            
            if (index >= 0)
            {
                _editor.Select(index, searchText.Length);
                _editor.ScrollToCaret();
                _lastIndex = index;
            }
            else
            {
                MessageBox.Show($"未找到 \"{searchText}\"", "查找", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            if (_editor.SelectionLength > 0 && 
                string.Equals(_editor.SelectedText, findTextBox.Text, 
                    matchCaseCheckBox.Checked ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase))
            {
                _editor.SelectedText = replaceTextBox.Text;
            }
            FindNextButton_Click(sender, e);
        }
        
        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            string searchText = findTextBox.Text;
            string replaceText = replaceTextBox.Text;
            if (string.IsNullOrEmpty(searchText)) return;
            
            int count = 0;
            int index = 0;
            StringComparison comparison = matchCaseCheckBox.Checked ? 
                StringComparison.CurrentCulture : 
                StringComparison.CurrentCultureIgnoreCase;
            
            while ((index = _editor.Text.IndexOf(searchText, index, comparison)) >= 0)
            {
                _editor.Select(index, searchText.Length);
                _editor.SelectedText = replaceText;
                index += replaceText.Length;
                count++;
            }
            
            MessageBox.Show($"已替换 {count} 处", "替换", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void InitializeComponent()
        {
            this.findPanel = new System.Windows.Forms.Panel();
            this.findLabel = new System.Windows.Forms.Label();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.findNextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.wholeWordCheckBox = new System.Windows.Forms.CheckBox();
            this.replacePanel = new System.Windows.Forms.Panel();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.replaceButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.findPanel.SuspendLayout();
            this.replacePanel.SuspendLayout();
            this.SuspendLayout();
            
            // findPanel
            this.findPanel.Controls.Add(this.findLabel);
            this.findPanel.Controls.Add(this.findTextBox);
            this.findPanel.Controls.Add(this.findNextButton);
            this.findPanel.Controls.Add(this.cancelButton);
            this.findPanel.Controls.Add(this.matchCaseCheckBox);
            this.findPanel.Controls.Add(this.wholeWordCheckBox);
            this.findPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.findPanel.Location = new System.Drawing.Point(0, 0);
            this.findPanel.Name = "findPanel";
            this.findPanel.Size = new System.Drawing.Size(400, 120);
            this.findPanel.TabIndex = 0;
            
            // findLabel
            this.findLabel.AutoSize = true;
            this.findLabel.Location = new System.Drawing.Point(10, 10);
            this.findLabel.Name = "findLabel";
            this.findLabel.Size = new System.Drawing.Size(65, 12);
            this.findLabel.TabIndex = 0;
            this.findLabel.Text = "查找内容：";
            
            // findTextBox
            this.findTextBox.Location = new System.Drawing.Point(80, 7);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(200, 21);
            this.findTextBox.TabIndex = 1;
            
            // findNextButton
            this.findNextButton.Location = new System.Drawing.Point(290, 5);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(100, 25);
            this.findNextButton.TabIndex = 2;
            this.findNextButton.Text = "查找下一个";
            this.findNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            
            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(290, 35);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            
            // matchCaseCheckBox
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Location = new System.Drawing.Point(80, 40);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(72, 16);
            this.matchCaseCheckBox.TabIndex = 4;
            this.matchCaseCheckBox.Text = "区分大小写";
            
            // wholeWordCheckBox
            this.wholeWordCheckBox.AutoSize = true;
            this.wholeWordCheckBox.Location = new System.Drawing.Point(80, 65);
            this.wholeWordCheckBox.Name = "wholeWordCheckBox";
            this.wholeWordCheckBox.Size = new System.Drawing.Size(72, 16);
            this.wholeWordCheckBox.TabIndex = 5;
            this.wholeWordCheckBox.Text = "全字匹配";
            
            // replacePanel
            this.replacePanel.Controls.Add(this.replaceLabel);
            this.replacePanel.Controls.Add(this.replaceTextBox);
            this.replacePanel.Controls.Add(this.replaceButton);
            this.replacePanel.Controls.Add(this.replaceAllButton);
            this.replacePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.replacePanel.Location = new System.Drawing.Point(0, 120);
            this.replacePanel.Name = "replacePanel";
            this.replacePanel.Size = new System.Drawing.Size(400, 80);
            this.replacePanel.TabIndex = 1;
            
            // replaceLabel
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Location = new System.Drawing.Point(10, 15);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(65, 12);
            this.replaceLabel.TabIndex = 0;
            this.replaceLabel.Text = "替换为：";
            
            // replaceTextBox
            this.replaceTextBox.Location = new System.Drawing.Point(80, 12);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(200, 21);
            this.replaceTextBox.TabIndex = 1;
            
            // replaceButton
            this.replaceButton.Location = new System.Drawing.Point(290, 10);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(100, 25);
            this.replaceButton.TabIndex = 2;
            this.replaceButton.Text = "替换";
            this.replaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            
            // replaceAllButton
            this.replaceAllButton.Location = new System.Drawing.Point(290, 40);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(100, 25);
            this.replaceAllButton.TabIndex = 3;
            this.replaceAllButton.Text = "全部替换";
            this.replaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            
            // FindReplaceDialog
            this.ClientSize = new System.Drawing.Size(400, 120);
            this.Controls.Add(this.replacePanel);
            this.Controls.Add(this.findPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindReplaceDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "查找";
            this.findPanel.ResumeLayout(false);
            this.findPanel.PerformLayout();
            this.replacePanel.ResumeLayout(false);
            this.replacePanel.PerformLayout();
            this.ResumeLayout(false);
        }
        
        private Panel findPanel;
        private Label findLabel;
        private TextBox findTextBox;
        private Button findNextButton;
        private Button cancelButton;
        private CheckBox matchCaseCheckBox;
        private CheckBox wholeWordCheckBox;
        private Panel replacePanel;
        private Label replaceLabel;
        private TextBox replaceTextBox;
        private Button replaceButton;
        private Button replaceAllButton;
    }
}