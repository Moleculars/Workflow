
using Newtonsoft.Json;
using System.Text;

namespace Bb.Compilers.Models
{

    public class CompilerModelRoot : CompilerModel
    {

        public CompilerModelRoot()
        {
            Models = new CompilerModels();
        }

        /// <summary>
        /// Gets or sets the key of the model's cluster.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the model's list.
        /// </summary>
        /// <value>
        /// The models.
        /// </value>
        public CompilerModels Models { get; set; }

        public override object Accept(CompilerBaseVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Deserializes the payload in <see cref="Bb.Compilers.Models.CompilerModelRoot"/>.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static CompilerModelRoot Load(StringBuilder sb)
        {
            return JsonConvert.DeserializeObject<CompilerModelRoot>(sb.ToString()

                , new PropertyConverter()
                , new CompilerModelConverter()

                );
        }

    }

}


