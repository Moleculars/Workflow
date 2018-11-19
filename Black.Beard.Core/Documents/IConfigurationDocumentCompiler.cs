using System;
using System.Collections.Generic;

namespace Bb.Core.Documents
{

    public interface IConfigurationDocumentCompiler
    {
        
        /// <summary>
        /// Initializes the default value if not specified.
        /// </summary>
        /// <param name="document">The file.</param>
        /// <param name="context">The context.</param>
        bool InitializeDefault(IConfigurationDocument document, CompileContext context);

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        List<CheckResult> CheckPrecompilation(IConfigurationDocument document, CompileContext context);

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument list.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        List<CheckResult> CheckPreCompilation(IEnumerable<IConfigurationDocument> documents, CompileContext context);

        /// <summary>
        /// prepare to compile the specified documents.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <param name="context">The context.</param>
        void InitializePreCompilation(IEnumerable<IConfigurationDocument> documents, CompileContext context);
        
        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        List<CheckResult> CheckPostCompilation(IConfigurationDocument document, CompileContext context);

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument list.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        List<CheckResult> CheckPostCompilation(IEnumerable<IConfigurationDocument> documents, CompileContext context);

    }


}
