using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Core
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
        /// External id . id of the object embedded in the message
        /// </summary>
        string Id { get; }

        /// <summary>
        /// unique identity event
        /// </summary>
        Guid Uid { get; }

        /// <summary>
        /// Gets the date of the post.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        DateTimeOffset PostDate { get; }

        /// <summary>
        /// Date of the event
        /// </summary>
        DateTimeOffset EventDate { get; }

    }

}
