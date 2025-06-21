using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SG_Lua_IDE.Components
{
    public static class LuaSyntaxHighlighter
    {
        private static readonly Color KeywordColor = Color.FromArgb(86, 156, 214);
        private static readonly Color StringColor = Color.FromArgb(214, 157, 133);
        private static readonly Color CommentColor = Color.FromArgb(87, 166, 74);
        private static readonly Color NumberColor = Color.FromArgb(181, 206, 168);
        private static readonly Color FunctionColor = Color.FromArgb(220, 220, 170);

        private static readonly string[] Keywords = {
            "and", "break", "do", "else", "elseif", "end", "false", "for", "function", 
            "if", "in", "local", "nil", "not", "or", "repeat", "return", "then", "true", 
            "until", "while"
        };
        
        private static readonly string[] Functions = {
            "print", "require", "tostring", "tonumber", "pairs", "ipairs", "next", 
            "assert", "error", "pcall", "xpcall", "select", "setmetatable", "getmetatable",
            "rawset", "rawget", "rawequal", "collectgarbage", "type", "dofile", "loadfile",
            "load", "module", "package", "io", "os", "string", "table", "math", "debug"
        };

        public static void ApplyDefaultStyles(RichTextBox editor)
        {
            editor.ForeColor = Color.White;
        }

        public static void HighlightSyntax(RichTextBox editor)
        {
            if (editor.TextLength == 0) return;
            
            int start = editor.SelectionStart;
            int length = editor.SelectionLength;
            Point scroll = editor.AutoScrollOffset;

            // 重置所有文本样式
            editor.Select(0, editor.TextLength);
            editor.SelectionColor = Color.White;
            editor.SelectionBackColor = editor.BackColor;
            
            // 高亮关键词
            foreach (string keyword in Keywords)
            {
                HighlightPattern(editor, $@"\b{keyword}\b", KeywordColor);
            }
            
            // 高亮函数
            foreach (string func in Functions)
            {
                HighlightPattern(editor, $@"\b{func}\b", FunctionColor);
            }

            // 高亮字符串
            HighlightPattern(editor, "\".*?\"", StringColor);
            HighlightPattern(editor, @"'.*?'", StringColor);
            HighlightPattern(editor, @"\[\[(.*?)\]\]", StringColor, RegexOptions.Singleline);

            // 高亮注释
            HighlightPattern(editor, "--.*$", CommentColor);
            HighlightPattern(editor, "--\\[\\[(.*?)\\]\\]", CommentColor, RegexOptions.Singleline);

            // 高亮数字
            HighlightPattern(editor, @"\b\d+\.?\d*\b", NumberColor);

            // 恢复选择状态和滚动位置
            editor.SelectionStart = start;
            editor.SelectionLength = length;
            editor.ScrollToCaret();
        }

        private static void HighlightPattern(RichTextBox editor, string pattern, Color color, 
                                            RegexOptions options = RegexOptions.None)
        {
            try
            {
                Regex regex = new Regex(pattern, options);
                MatchCollection matches = regex.Matches(editor.Text);

                foreach (Match match in matches)
                {
                    editor.Select(match.Index, match.Length);
                    editor.SelectionColor = color;
                }
            }
            catch
            {
                // 忽略正则表达式错误
            }
        }
    }
}