using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// specify this class contains method to expose
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ExposeIncomingMessage : Attribute
    {

        public ExposeIncomingMessage(string domain, string version, string incomingMessageKey)
        {
            this.Domain = domain;
            this.Version = version;
            this.IncomingMessageKey = incomingMessageKey;
        }

        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; }

        /// <summary>
        /// Gets the message key for matching the incoming message.
        /// </summary>
        /// <value>
        /// The message key.
        /// </value>
        public string IncomingMessageKey { get; }

    }

}