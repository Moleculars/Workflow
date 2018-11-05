using Bb.Sdk.Csv;
using System;

namespace Bb.Referentiels
{

    public class ConfigCsv : Config
    {


        public bool HasHeaders { get; set; }

        public char DelimiterChar { get; set; } = ';';

        public char Quote { get; set; } = '"';

        public char Escape { get; set; } = '\\';

        public char Comment { get; set; } = '#';

        public ValueTrimmingOptions TrimmingOptions { get; set; } = ValueTrimmingOptions.All;


    }
}
