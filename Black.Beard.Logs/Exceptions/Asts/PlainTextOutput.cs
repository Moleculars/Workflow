using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pssa.Sdk.Loggings.Exceptions.Asts
{
    public sealed class PlainTextOutput : ITextOutput
    {
        readonly TextWriter writer;
        int indent;
        bool needsIndent;

        int line = 1;
        int column = 1;

        public PlainTextOutput(TextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            this.writer = writer;
        }

        public PlainTextOutput()
        {
            this.writer = new StringWriter();
        }

        public TextLocation Location
        {
            get
            {
                return new TextLocation(line, column + (needsIndent ? indent : 0));
            }
        }

        public override string ToString()
        {
            return writer.ToString();
        }

        public void Indent()
        {
            indent++;
        }

        public void Unindent()
        {
            indent--;
        }

        void WriteIndent()
        {
            if (needsIndent)
            {
                needsIndent = false;
                for (int i = 0; i < indent; i++)
                {
                    writer.Write('\t');
                }
                column += indent;
            }
        }

        public void Write(char ch)
        {
            WriteIndent();
            writer.Write(ch);
            column++;
        }

        public void Write(string text)
        {
            WriteIndent();
            writer.Write(text);
            column += text.Length;
        }

        public void WriteLine()
        {
            writer.WriteLine();
            needsIndent = true;
            line++;
            column = 1;
        }

        public void WriteDefinition(string text, object definition, bool isLocal)
        {
            Write(text);
        }

        public void WriteReference(string text, object reference, bool isLocal)
        {
            Write(text);
        }

        void ITextOutput.MarkFoldStart(string collapsedText, bool defaultCollapsed)
        {
        }

        void ITextOutput.MarkFoldEnd()
        {
        }

        void ITextOutput.AddDebuggerMemberMapping(MemberMapping memberMapping)
        {
        }
    }

}
