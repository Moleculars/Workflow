namespace Bb.Mappings.Models
{
    public class PropertyPath
    {
        public int LineNumber;
        public int LinePosition;

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