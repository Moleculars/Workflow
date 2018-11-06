using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Core.Documents
{

    public interface IConfigurationDocumentCompiler
    {

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        List<CheckResult> Check(IConfigurationDocument document);

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument list.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        List<CheckResult> Check(IEnumerable<IConfigurationDocument> documents);

        /// <summary>
        /// prepare to compile the specified documents.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <param name="context">The context.</param>
        void PrepareCompile(IEnumerable<IConfigurationDocument> documents, CompileContext context);

    }


    public class CheckResult
    {

        public string Document { get; set; }

        public string Message { get; set; }
        public int LineNumber { get; set; }
        public int LinePosition { get; set; }
        public string Name { get; set; }
        public string Severity { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder(100);

            sb.Append(Severity);
            sb.Append(" ");

            if (!string.IsNullOrEmpty(Name))
                sb.Append("property {Name} ");

            sb.Append($"at (line : {LineNumber}, position : {LinePosition}) in {Document} ");
            sb.Append(Message);

            return sb.ToString();

        }

    }


}
