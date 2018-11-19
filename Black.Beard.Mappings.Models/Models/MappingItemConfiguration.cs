namespace Bb.Mappings.Models
{

    [System.Diagnostics.DebuggerDisplay("{SourcePath} -> {TargetPath}")]
    public class MappingItemConfiguration
    {

        internal int LineNumber;
        internal int LinePosition;

        public MappingItemConfiguration()
        {

        }

        public int GetLineNumber() => LineNumber;

        public int GetLinePosition() => LinePosition;

        public PropertyPath SourcePath { get; set; }

        public PropertyPath TargetPath { get; set; }

    }

}