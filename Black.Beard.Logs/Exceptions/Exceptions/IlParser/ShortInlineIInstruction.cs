namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    /// ShortInlineIInstruction
    /// </summary>
    public class ShortInlineIInstruction : ILInstruction
    {
        private byte m_int8;

        internal ShortInlineIInstruction(int offset, OpCode opCode, byte value) : base(offset, opCode)
        {
            this.m_int8 = value;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(ILInstructionVisitor visitor)
        {
            visitor.VisitShortInlineIInstruction(this);
        }

        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <value>
        /// The byte.
        /// </value>
        public byte Byte
        {
            get
            {
                return this.m_int8;
            }
        }
    }
}
