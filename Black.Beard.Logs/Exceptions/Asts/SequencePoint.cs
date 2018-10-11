using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pssa.Sdk.Loggings.Exceptions.Asts
{

    public sealed class SequencePoint
    {

        Document document;

        int start_line;
        int start_column;
        int end_line;
        int end_column;

        public int StartLine
        {
            get { return start_line; }
            set { start_line = value; }
        }

        public int StartColumn
        {
            get { return start_column; }
            set { start_column = value; }
        }

        public int EndLine
        {
            get { return end_line; }
            set { end_line = value; }
        }

        public int EndColumn
        {
            get { return end_column; }
            set { end_column = value; }
        }

        public Document Document
        {
            get { return document; }
            set { document = value; }
        }

        public SequencePoint(Document document)
        {
            this.document = document;
        }
    }

}
