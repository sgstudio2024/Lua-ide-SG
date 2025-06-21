using System;
using System.Windows.Forms;

namespace SG_Lua_IDE.Components
{
    public partial class GoToLineDialog : Form
    {
        public int LineNumber { get; private set; }
        private readonly int _maxLines;
        
        public GoToLineDialog(int maxLines)
        {
            _maxLines = maxLines;
            InitializeComponent();
        }
        
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lineNumberTextBox.Text, out int line) && line > 0 && line <= _maxLines)
            {
                LineNumber = line;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show($"请输入有效的行号 (1 - {_maxLines})", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void InitializeComponent()
        {
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.lineNumberTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lineNumberLabel
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(10, 15);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(65, 12);
            this.lineNumberLabel.TabIndex = 0;
            this.lineNumberLabel.Text = "行号(&L)：";
            
            // lineNumberTextBox
            this.lineNumberTextBox.Location = new System.Drawing.Point(80, 12);
            this.lineNumberTextBox.Name = "lineNumberTextBox";
            this.lineNumberTextBox.Size = new System.Drawing.Size(100, 21);
            this.lineNumberTextBox.TabIndex = 1;
            
            // okButton
            this.okButton.Location = new System.Drawing.Point(50, 45);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            
            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(130, 45);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            
            // GoToLineDialog
            this.ClientSize = new System.Drawing.Size(220, 80);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.lineNumberTextBox);
            this.Controls.Add(this.lineNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToLineDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "转到行";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private Label lineNumberLabel;
        private TextBox lineNumberTextBox;
        private Button okButton;
        private Button cancelButton;
    }
}