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

        public IConfigurationDocument Document { get; set; }

        public string Message { get; set; }

    }


}
