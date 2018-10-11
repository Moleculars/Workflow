namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    /// InlineNoneInstruction
    /// </summary>
    public class InlineNoneInstruction : ILInstruction
    {
        internal InlineNoneInstruction(int offset, OpCode opCode) : base(offset, opCode)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(ILInstructionVisitor visitor)
        {
            visitor.VisitInlineNoneInstruction(this);
        }
    }
}
