namespace Bb.Mappings.Models
{
    public class PropertyPath
    {
        
        internal int LineNumber;
        internal int LinePosition;

        public int GetLineNumber() => LineNumber;

        public int GetLinePosition() => LinePosition;
        
        public string Name { get; set; }

        public PropertyPath Sub { get; set; }

        public override string ToString()
        {
            if (Sub == null)
                return this.Name;

            return Sub.ToString() + "." + this.Name; 

        }

    }

}