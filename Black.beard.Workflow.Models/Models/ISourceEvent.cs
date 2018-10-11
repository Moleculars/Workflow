using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Minimal attributes Interface for input message incoming in the system.
    /// </summary>
    public interface ISourceEvent
    {

        /// <summary>
        /// The key that must matching with config event key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// External id 
        /// </summary>
        string Id { get; }

        /// <summary>
        /// uuid
        /// </summary>
        Guid Uid { get; }

    }

}
