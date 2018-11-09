﻿using System;
using System.Collections.Generic;

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
        void Initialize(IEnumerable<IConfigurationDocument> documents, CompileContext context);

    }


}
