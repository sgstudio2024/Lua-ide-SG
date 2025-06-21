using System;
using System.IO;
using System.Windows.Forms;

namespace SG_Lua_IDE.Components
{
    public static class OutputRedirector
    {
        private static TextBox _outputTextBox;
        private static readonly TextWriter _originalOutput;

        static OutputRedirector()
        {
            _originalOutput = Console.Out;
        }

        public static void Redirect(TextBox textBox)
        {
            _outputTextBox = textBox;
            Console.SetOut(new TextBoxWriter(textBox));
        }

        public static void Restore()
        {
            Console.SetOut(_originalOutput);
        }

        private class TextBoxWriter : TextWriter
        {
            private readonly TextBox _textBox;

            public TextBoxWriter(TextBox textBox)
            {
                _textBox = textBox;
            }

            public override void Write(char value)
            {
                _textBox.BeginInvoke(new Action(() => 
                {
                    _textBox.AppendText(value.ToString());
                    _textBox.ScrollToCaret();
                }));
            }

            public override void Write(string value)
            {
                _textBox.BeginInvoke(new Action(() => 
                {
                    _textBox.AppendText(value);
                    _textBox.ScrollToCaret();
                }));
            }

            public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
        }
    }
}