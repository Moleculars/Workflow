namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    /// ShortInlineRInstruction
    /// </summary>
    public class ShortInlineRInstruction : ILInstruction
    {
        private float m_value;

        internal ShortInlineRInstruction(int offset, OpCode opCode, float value) : base(offset, opCode)
        {
            this.m_value = value;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(ILInstructionVisitor visitor)
        {
            visitor.VisitShortInlineRInstruction(this);
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <value>
        /// The single.
        /// </value>
        public float Single
        {
            get
            {
                return this.m_value;
            }
        }
    }
}
