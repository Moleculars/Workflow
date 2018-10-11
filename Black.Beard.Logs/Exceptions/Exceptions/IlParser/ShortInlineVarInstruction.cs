namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    /// ShortInlineVarInstruction
    /// </summary>
    public class ShortInlineVarInstruction : ILInstruction
    {
        private byte m_ordinal;

        internal ShortInlineVarInstruction(int offset, OpCode opCode, byte ordinal) : base(offset, opCode)
        {
            this.m_ordinal = ordinal;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(ILInstructionVisitor visitor)
        {
            visitor.VisitShortInlineVarInstruction(this);
        }

        /// <summary>
        /// Gets the ordinal.
        /// </summary>
        /// <value>
        /// The ordinal.
        /// </value>
        public byte Ordinal
        {
            get
            {
                return this.m_ordinal;
            }
        }
    }
}
