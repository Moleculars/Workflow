namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    /// InlineSigInstruction
    /// </summary>
    public class InlineSigInstruction : ILInstruction
    {
        private ITokenResolver m_resolver;
        private byte[] m_signature;
        private int m_token;

        internal InlineSigInstruction(int offset, OpCode opCode, int token, ITokenResolver resolver) : base(offset, opCode)
        {
            this.m_resolver = resolver;
            this.m_token = token;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(ILInstructionVisitor visitor)
        {
            visitor.VisitInlineSigInstruction(this);
        }

        /// <summary>
        /// Gets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        public byte[] Signature
        {
            get
            {
                if (this.m_signature == null)
                {
                    this.m_signature = this.m_resolver.AsSignature(this.m_token);
                }
                return this.m_signature;
            }
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public int Token
        {
            get
            {
                return this.m_token;
            }
        }
    }
}
